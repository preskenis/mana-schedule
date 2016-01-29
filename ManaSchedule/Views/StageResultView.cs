using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;
using System.Data.Entity;
using Janus.Windows.GridEX;
using ManaSchedule.Services;

namespace ManaSchedule.Views
{
    public partial class StageResultView : UserControl
    {

        public StageResultView()
        {
            InitializeComponent();
        }


        public void OnClosing()
        {
            
        }

        public Stage Stage { get; set; }

        public GameService GameService { get; set; }


        public Dictionary<CompetitionReferee, DataTable> Data { get; set; }


        public void Init(Stage content)
        {
           
            GameService.DbContext.GameResultValueSet.Where(f => f.GameResult.Game.StageId == content.Id).Load();

            Stage = content;
            Data = new Dictionary<CompetitionReferee, DataTable>();

            var refereeIndex = 1;

            foreach (var referee in GameService.DbContext.CompetitionRefereeSet.Where(f=>f.CompetitionId == content.CompetitionId))
            {
                var page = new Janus.Windows.UI.Tab.UITabPage(referee.IsMainReferee ? "Гл. судья" : "Судья №" + refereeIndex.ToString())
                     {
                         Tag = referee
                     };
                if (!referee.IsMainReferee) refereeIndex++;

                refereeTabs.TabPages.Add(page);
                var grid = new GridEX() { Dock = DockStyle.Fill };
                page.Controls.Add(grid);
                var dt = GetTable(content, referee);
                grid.DataSource = dt;
                grid.RetrieveStructure();
                grid.RootTable.Columns["Команда"].EditType = EditType.NoEdit;
                grid.ColumnAutoSizeMode = ColumnAutoSizeMode.ColumnHeader;
                grid.ColumnAutoResize = true;

                Data.Add(referee, dt);
                dt.RowChanged += dt_RowChanged;

             
            }

            var analizPage = new Janus.Windows.UI.Tab.UITabPage("Анализ")
            {
              
            };

            refereeTabs.TabPages.Add(analizPage);
            var analiz = new StageResultCalculatorView() { Dock = DockStyle.Fill, Stage = Stage };
            analiz.Init(Stage.Competition);
            analizPage.Controls.Add(analiz);
            

        }

        private void btRandom_Click(object sender, EventArgs e)
        {

            Data.Keys.ToList().ForEach(v =>
            {
                GameService.DbContext.GameResultValueSet.RemoveRange(GameService.DbContext.GameResultValueSet.Where(f =>f.GameResult.Game.Stage.Id == Stage.Id && f.GameResult.CompetitionRefereeId == v.Id));
            });



            GameService.DbContext.Configuration.AutoDetectChangesEnabled = false;
            GameService.DbContext.Configuration.ValidateOnSaveEnabled = false;

            var rand = new Random();



            foreach (var item in Data)
            {
                var referee = item.Key;
                var valueTypes = GameService.GetValueTypes(Stage, referee);
                
                foreach (var row in item.Value.Rows)
                {
                    var r = row as DataRow;

                    var items = r.ItemArray;

                    foreach (var valueType in valueTypes)
                    {
                        var value = rand.Next(10);
                        while (GameService.MaxValue(Stage, valueType) < value || GameService.MinValue(Stage, valueType) > value)
                        {
                            value = rand.Next(10) - rand.Next(5);
                        }

                        items[item.Value.Columns[EnumHelper<GameValueType>.GetDisplayValue(valueType)].Ordinal] = value;

                      
                    }

                    r.ItemArray = items;
                }
                
            }
            GameService.DbContext.SaveChanges();
        }


        void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            var referee = Data.First(f => f.Value == e.Row.Table).Key;
            var valueTypes = GameService.GetValueTypes(Stage, referee);
            var team = e.Row.Field<string>(0);

            var gameResult = GameService.DbContext.GameResultSet.Local.First(f => f.Game.Stage.Id == Stage.Id && f.Referee.Id == referee.Id && f.Game.Team.Name == team);

            foreach (var valueType in valueTypes)
            {
                var value = GameService.DbContext.GameResultValueSet.Local.FirstOrDefault(f => f.GameResult == gameResult && f.Type == valueType);
                var val = e.Row.Field<int?>(e.Row.Table.Columns[EnumHelper<GameValueType>.GetDisplayValue(valueType)]);

                if (val.HasValue)
                {
                    if (val.Value > GameService.MaxValue(gameResult.Game.Stage, valueType)
                        || val.Value < GameService.MinValue(gameResult.Game.Stage, valueType) 
                        )
                    {
                        e.Row.SetField<int?>(e.Row.Table.Columns[EnumHelper<GameValueType>.GetDisplayValue(valueType)], null);
                    }
                    else
                    {
                        if (value == null) GameService.DbContext.GameResultValueSet.Add(new GameResultValue()
                        {
                            GameResult = gameResult,
                            Type = valueType,
                            Value = val.Value,
                        });
                        else
                        {
                            if (value.Value != val.Value)
                                value.Value = val.Value;
                           
                        }
                    }

                   
                }
                else
                {
                    if (value != null)
                    {
                        GameService.DbContext.GameResultValueSet.Remove(value);
                    }
                }
            }
            gameResult.Description = e.Row.Field<string>("Примечание");

        }

        public void UpdateValue( CompetitionReferee referee, GameValueType type, int? value)
        {

        }


        public DataTable GetTable(Stage stage, CompetitionReferee referee)
        {
            var table = new DataTable();

            var teamColumn = table.Columns.Add("Команда", typeof(string));
  
            var valueTypes = GameService.GetValueTypes(stage, referee);
            var dictTable = valueTypes.ToDictionary(f => f, f => table.Columns.Add(EnumHelper<GameValueType>.GetDisplayValue(f), typeof(int)));

            GameService.DbContext.GameResultValueSet.Where(f => f.GameResult.Game.StageId == stage.Id).Load();

            foreach (var gr in GameService.DbContext.GameResultSet.Where(f => f.Game.StageId == stage.Id && f.Referee.Id == referee.Id && f.Game.Team1Missed == false && f.Game.Team1Cancel == false))
            {
                var row = table.NewRow();
                row[teamColumn] = gr.Game.Team.Name;

                GameService.DbContext.GameResultValueSet.Where(f => f.GameResult.Id == gr.Id).ToList().ForEach(f => 
                {
                    if (dictTable.ContainsKey(f.Type)) row[dictTable[f.Type]] = f.Value;
                });
            
                table.Rows.Add(row);
            }


            table.Columns.Add("Примечание", typeof(string));
         
            return table;
        }

        private void btFinishStage_Click(object sender, EventArgs e)
        {
            foreach (var item in Data)
            {
                foreach (var row in item.Value.Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Skip(1).Take(row.ItemArray.Length - 2).Any(f=>f == DBNull.Value))
                    {
                        MessageBox.Show("Не все результаты введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            GameService.EndStage(Stage);
            MessageBox.Show("Этап завершен, места пересчитаны", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    

    

      
    }
}
