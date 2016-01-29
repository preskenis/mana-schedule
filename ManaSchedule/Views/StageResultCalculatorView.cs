using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;
using Janus.Windows.GridEX;
using NPOI.HSSF.UserModel;
using System.IO;


namespace ManaSchedule.Views
{
    public partial class StageResultCalculatorView : CompetitionView
    {
        public class ParamSetting
        {
            public GameValueType GameValueType { get; set; }
            public int OrigMinValue { get; set; }
            public int OrigMaxValue { get; set; }
            public int MinValue { get; set; }
            public int MaxValue { get; set; }

            public bool Enabled { get; set; }


            public string Name { get; set; }
        }

        public BindingList<ParamSetting> ParamSettings { get; set; }
        public Stage Stage { get; set; }

        public StageResultCalculatorView()
        {
            InitializeComponent();

            DbContext.TeamSet.Load();
            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.NoEdit;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.ToList(), "Name");

            GridEX.RootTable.SortKeys.Add(GridEX.RootTable.Columns["Score"], Janus.Windows.GridEX.SortOrder.Descending);
        }
        
        public override void Init(Competition content)
        {
            base.Init(content);

            var valueTypes = new List<GameValueType>();
            foreach (var referee in GameService.DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == content.Id))
            {
                valueTypes.AddRange(GameService.GetValueTypes(Stage, referee));
            }


          ParamSettings = new BindingList<ParamSetting>(valueTypes.Distinct().ToList().Select(f => 
            new ParamSetting()
                {
                    Enabled = true,
                    GameValueType = f,
                    Name = EnumHelper<GameValueType>.GetDisplayValue(f),
                    MinValue = GameService.MinValue(Stage, f),
                    MaxValue = GameService.MaxValue(Stage, f),
                    OrigMinValue = GameService.MinValue(Stage, f),
                    OrigMaxValue = GameService.MaxValue(Stage, f),
                }
            ).ToList());



          GridEX2.DataSource = ParamSettings;
            
            
            Recalc();

            GridEX2.CellEdited += GridEX2_CellValueChanged;

        }

        void GridEX2_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
            GridEX2.UpdateData();
            Recalc();
        }

        private void Recalc()
        {
            DbContext.GameSet.Where(f => f.StageId == Stage.Id).Load();
            DbContext.GameResultSet.Where(f => f.Game.StageId == Stage.Id).Load();
            DbContext.GameResultValueSet.Where(f => f.GameResult.Game.StageId == Stage.Id).Load();

            var result = new BindingList<TeamScore>();
            foreach (var game in DbContext.GameSet.Local)
            {
    
                var gameValues = ScaleResult(GameService.GetGameResultValues(game));


                

                var score = GameService.GetGameScore(game, gameValues, new StringBuilder());
                if (!score.HasValue) continue;
                var item = new TeamScore() { Team = game.Team, Score = score.Value };
                result.Add(item);
            }

            GridEX.DataSource = result;
            GridEX.Refetch();
           
        }

        private Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> ScaleResult(Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> original)
        {
            var result = new Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>>();

            foreach (var c in original)
            {
                result.Add(c.Key, new Dictionary<GameValueType, int?>());
                foreach (var gv in c.Value)
                {
                    var param = ParamSettings.First(f=>f.GameValueType == gv.Key);
                    if (!param.Enabled)
                        continue;

                    if ((param.OrigMaxValue == param.MaxValue && param.OrigMinValue == param.MinValue) || !gv.Value.HasValue)
                        result[c.Key].Add(gv.Key, gv.Value);
                    else
                    {
                        var procent = (double)(gv.Value - param.OrigMinValue) / (double)(param.OrigMaxValue - param.OrigMinValue);
                        var val = param.MinValue + (param.MaxValue - param.MinValue) * procent;
                        result[c.Key].Add(gv.Key, (int)val);
                    }
                   
                }
            }


            return result;

        }



    }
}
