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
    public partial class CookStageResultView : StageResultViewBase
    {

        public CookStageResultView()
        {
            InitializeComponent();
        }


        private class ColumnInfo
        {
            public CompetitionReferee Referee;
            public GameValueType ValueType;
            public string Name;
        }

       

        public Dictionary<CompetitionReferee, DataTable> Data { get; set; }

        private Dictionary<DataColumn, ColumnInfo> ColumnStructure;

        public override void Init()
        {
            
           
            GameService.DbContext.GameResultValueSet.Where(f => f.GameResult.Game.StageId == Stage.Id).Load();

            Data = new Dictionary<CompetitionReferee, DataTable>();

            grid.RootTable = new GridEXTable();



            var table = new DataTable();

           


            var teamColumn = table.Columns.Add("Команда", typeof(string));
            var teamZherColumn = table.Columns.Add("Жеребьевка", typeof(int));
  
             var allReferee = GameService.DbContext.CompetitionRefereeSet.Where(f=> f.CompetitionId == Stage.CompetitionId).ToList();

            var mainReferee = allReferee.First(f=>f.IsMainReferee);
            var referee = allReferee.Where(f=>!f.IsMainReferee).ToList();

           
           ColumnStructure = new Dictionary<DataColumn,ColumnInfo>();

           var nonMainRefereeValues = GameService.GetValueTypes(Stage, referee.First()).ToList();

            


            foreach(var valueType in nonMainRefereeValues)
            {


                for(int i =0; i< referee.Count; i++)
                {
                    var valColumn = table.Columns.Add(string.Format("{0}.{1}", (i + 1).ToString(), 
                        EnumHelper<GameValueType>.GetDisplayValue(valueType)), typeof(int));

                    ColumnStructure.Add(valColumn, new ColumnInfo() { Referee = referee[i], ValueType = valueType, Name = valColumn.Caption});
                }
                
            }

            foreach (var valueType in GameService.GetValueTypes(Stage, mainReferee))
            {
                var valColumn = table.Columns.Add(EnumHelper<GameValueType>.GetDisplayValue(valueType) , typeof(int));
                ColumnStructure.Add(valColumn, new ColumnInfo() { Referee = mainReferee, ValueType = valueType, Name = valColumn.Caption });
            }

            var zhereb = GameService.DbContext.TeamCompetitionSet.Where(f=>f.CompetitionId == GameService.Competition.Id).ToDictionary(f=>f.TeamId, f=>f.Order.Value);


            var refereeIds = allReferee.Select(f=>f.Id).ToList();

            foreach (var game in GameService.DbContext.GameSet.Where(f=>f.StageId == Stage.Id))
            {
                var row = table.NewRow();

                row[teamColumn] = game.Team.Name;
                row[teamZherColumn] = zhereb[game.Team.Id];

                foreach(var rs in GameService.DbContext.GameResultSet.Where(f=>refereeIds.Contains(f.CompetitionRefereeId) && f.GameId == game.Id))
                {
                    foreach(var rsValue in rs.Values)
                    {
                        var col = ColumnStructure.First(f => f.Value.ValueType == rsValue.Type && f.Value.Referee.Id == rs.CompetitionRefereeId).Key;
                        if (rsValue.Value.HasValue)
                            row[col] = rsValue.Value.Value;
                    }
                }


                table.Rows.Add(row);
            }

            grid.DataSource = table;
            grid.RetrieveStructure();
               grid.RowHeaderContent = RowHeaderContent.RowPosition;
              grid.RowHeaders = InheritableBoolean.True;

              grid.EnsureVisible(1);

             grid.RootTable.Columns["Команда"].EditType = EditType.NoEdit;
             
            //grid.RootTable.SortKeys.Add(grid.RootTable.Columns["Команда"]).SortOrder = Janus.Windows.GridEX.SortOrder.Ascending;

              grid.RootTable.Columns["Жеребьевка"].EditType = EditType.NoEdit;
              grid.RootTable.SortKeys.Add(grid.RootTable.Columns["Жеребьевка"]).SortOrder = Janus.Windows.GridEX.SortOrder.Ascending;
              grid.RootTable.Columns["Жеребьевка"].TextAlignment = TextAlignment.Center;

              grid.Update();


            
              grid.FrozenColumns = 1;

              
              grid.GroupByBoxVisible = false;

            foreach (var c in ColumnStructure)
            {
                var column =  grid.RootTable.Columns.Cast<GridEXColumn>().First(f => f.DataMember == c.Value.Name);
                column.TextAlignment = TextAlignment.Center;

                var condition = new GridEXFormatCondition();
                condition.Column = column;
                
                condition.ConditionOperator = ConditionOperator.IsEmpty;
                condition.FormatStyle.BackColor = Color.LightBlue;

                condition.TargetColumn = column;

                grid.RootTable.FormatConditions.Add(condition);
            }




              table.ColumnChanged += table_ColumnChanged;




            //foreach (var referee in GameService.DbContext.CompetitionRefereeSet.Where(f=>f.CompetitionId == content.CompetitionId))
            //{
            //    var page = new Janus.Windows.UI.Tab.UITabPage(referee.IsMainReferee ? "Гл. судья" : "Судья №" + refereeIndex.ToString())
            //         {
            //             Tag = referee
            //         };
            //    if (!referee.IsMainReferee) refereeIndex++;

            //    refereeTabs.TabPages.Add(page);
               
            //    var grid = new GridEX() { Dock = DockStyle.Fill, Name = "gridReferee" };
            //    page.Controls.Add(grid);
            //    var dt = GetTable(content, referee);
            //    grid.DataSource = dt;
            //    grid.RetrieveStructure();
            //    grid.RootTable.Columns["Команда"].EditType = EditType.NoEdit;
            //    grid.RootTable.SortKeys.Add(grid.RootTable.Columns["Команда"]);
            //    grid.GroupByBoxVisible = false;

                
            //    grid.ColumnAutoSizeMode = ColumnAutoSizeMode.ColumnHeader;
            //    grid.ColumnAutoResize = true;

            //    Data.Add(referee, dt);
            //    dt.RowChanged += dt_RowChanged;

            //    grid.RowHeaderContent = RowHeaderContent.RowPosition;
            //    grid.RowHeaders = InheritableBoolean.True;

            //    grid.EnsureVisible(1);
            //}

            /*
            var analizPage = new Janus.Windows.UI.Tab.UITabPage("Анализ")
            {
              
            };

            refereeTabs.TabPages.Add(analizPage);
            var analiz = new StageResultCalculatorView() { Dock = DockStyle.Fill, Stage = Stage };
            analiz.Init(Stage.Competition);
            analizPage.Controls.Add(analiz);
            */

        }

        void table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (!ColumnStructure.ContainsKey(e.Column)) return;

            var c = ColumnStructure[e.Column];

            var team = e.Row.Field<string>(0);

            int? newValue = null;

            int nv = 0;

            if (int.TryParse(e.ProposedValue.ToString(), out nv ))
            {
                newValue = nv;
            }

            
            
            if (newValue.HasValue)
            {
                if (newValue > GameService.MaxValue(Stage, c.ValueType)
                    || newValue < GameService.MinValue(Stage, c.ValueType))
                {
                    newValue = null;
                }
                   
            }
            if (!newValue.HasValue)
            {
                e.Row.SetColumnError(e.Column, "Неправильное значение");
            }
            else
                e.Row.SetColumnError(e.Column, "");

            var gameResult = GameService.DbContext.GameResultSet.First(f => f.Game.Stage.Id == Stage.Id && f.Referee.Id == c.Referee.Id && f.Game.Team.Name == team);
            var value = gameResult.Values.FirstOrDefault(f => f.Type == c.ValueType);

            if (value == null)
                GameService.DbContext.GameResultValueSet.Add(new GameResultValue() { GameResult = gameResult, Type = c.ValueType, Value = newValue });
            else
                value.Value = newValue;

            
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

        public bool SkipRowChange = false;

        public void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            
        //{
        //    if (SkipRowChange) return;
        //    var referee = Data.First(f => f.Value == e.Row.Table).Key;
        //    var valueTypes = GameService.GetValueTypes(Stage, referee);
        //    var team = e.Row.Field<string>(0);

        //    var gameResult = GameService.DbContext.GameResultSet.Local.First(f => f.Game.Stage.Id == Stage.Id && f.Referee.Id == referee.Id && f.Game.Team.Name == team);

        //    foreach (var valueType in valueTypes)
        //    {
        //        var value = gameResult.Values.FirstOrDefault(f => f.GameResult == gameResult && f.Type == valueType);
        //        var val = e.Row.Field<int?>(e.Row.Table.Columns[EnumHelper<GameValueType>.GetDisplayValue(valueType)]);

        //        if (val.HasValue)
        //        {
        //            if (val.Value > GameService.MaxValue(gameResult.Game.Stage, valueType)
        //                || val.Value < GameService.MinValue(gameResult.Game.Stage, valueType) 
        //                )
        //            {
        //                e.Row.SetField<int?>(e.Row.Table.Columns[EnumHelper<GameValueType>.GetDisplayValue(valueType)], null);
        //            }
        //            else
        //            {
        //                if (value == null) GameService.DbContext.GameResultValueSet.Add(new GameResultValue()
        //                {
        //                    GameResult = gameResult,
        //                    Type = valueType,
        //                    Value = val.Value,
        //                });
        //                else
        //                {
        //                    if (value.Value != val.Value)
        //                        value.Value = val.Value;
                           
        //                }
        //            }

                   
        //        }
        //        else
        //        {
        //            if (value != null)
        //            {
        //                GameService.DbContext.GameResultValueSet.Remove(value);
        //            }
        //        }
        //    }
        //    gameResult.Description = e.Row.Field<string>("Примечание");

        }

        public void UpdateValue( CompetitionReferee referee, GameValueType type, int? value)
        {

        }


        //public DataTable GetTable(Stage stage)
        //{
            

            //var valueTypes = GameService.GetValueTypes(stage, referee);
            //var dictTable = valueTypes.ToDictionary(f => f, f => table.Columns.Add(EnumHelper<GameValueType>.GetDisplayValue(f), typeof(int)));



            //var gamesIds = stage.Game.Where(f=>f.Team1Missed == false && !f.Team1Cancel).Select(f => f.Id).ToList();

            //var grs = GameService.DbContext.GameResultSet.Where(
            //    f => f.CompetitionRefereeId == referee.Id &&
            //         gamesIds.Contains(f.GameId)).ToList();

            //var grIds = grs.Select(f => f.Id).ToList();

            //var allValues = GameService.DbContext.GameResultValueSet.Where(f => grIds.Contains(f.GameResultId)).ToList();
            

            //foreach (
            //    var gr in
            //    grs)
            //{
            //    var row = table.NewRow();
            //    row[teamColumn] = gr.Game.Team.Name;


            //    var values = allValues.Where(f => f.GameResultId == gr.Id).ToList();



            //    values.ForEach(f =>
            //    {
            //        if (dictTable.ContainsKey(f.Type)) row[dictTable[f.Type]] = f.Value;
            //    });

            //    table.Rows.Add(row);
            //}


            //table.Columns.Add("Примечание", typeof(string));
         
            //return table;
        //}

      

        public override void FinishStage()
        {
            if (DialogResult.Yes != 
                MessageBox.Show(this, string.Format("Завершить этап {0}:{1}?", Stage.Competition.Name, Stage.Name), "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

           
                foreach (var row in (grid.DataSource as DataTable) .Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Any(f => f == DBNull.Value))
                    {
                        MessageBox.Show("Не все результаты введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            

            GameService.EndStage(Stage);
            MessageBox.Show("Этап завершен, места пересчитаны", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void FillRandom()
        {

        }
 



        public override void ShowNames(bool showNames)
        {
            //  var refereeIndex = 1;

            // foreach (var page in refereeTabs.TabPages.Cast<Janus.Windows.UI.Tab.UITabPage>())
            //{
            //    var referee = page.Tag as CompetitionReferee;
            //    if (referee == null) continue;

            //    if (showNames && referee.Person != null)
            //    {
            //        page.Text = string.Format("{0}", referee.Person.Name); 
            //    }
            //    else
            //    {
            //        page.Text = referee.IsMainReferee ? "Гл. судья" : "Судья №" + refereeIndex.ToString();
            //    }
                
            //        if (!referee.IsMainReferee) refereeIndex++;
            //}
        }

        internal override GridEX GetDataTable()
        {
            return grid;
        }

        internal override string GetFileName()
        {
            
            return Stage.Name;
        }

        public override void OnClosing()
        {
            
        }

        private void grid_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }
    }
}
