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
    public partial class LagerStageResultView : StageResultViewBase
    {

        public LagerStageResultView()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            
           
            GameService.DbContext.GameResultValueSet.Where(f => f.GameResult.Game.StageId == Stage.Id).Load();

            var table = new DataTable();

           
            var teamColumn = table.Columns.Add("Команда", typeof(string));
       
            
            foreach (var game in GameService.DbContext.GameSet.Where(f=>f.StageId == Stage.Id))
            {
                var row = table.NewRow();

                row[teamColumn] = game.Team.Name;
           
                table.Rows.Add(row);
            }

            grid.DataSource = table;
            grid.RetrieveStructure();
               grid.RowHeaderContent = RowHeaderContent.RowPosition;
              grid.RowHeaders = InheritableBoolean.True;

              grid.EnsureVisible(1);

             grid.RootTable.Columns["Команда"].EditType = EditType.NoEdit;
             
              grid.RootTable.SortKeys.Add(grid.RootTable.Columns["Команда"]).SortOrder = Janus.Windows.GridEX.SortOrder.Ascending;

              
              grid.GroupByBoxVisible = false;



              grid.SelectionChanged += grid_SelectionChanged;

            



          

        }

        void grid_SelectionChanged(object sender, EventArgs e)
        {
            uiGroupBox2.Text = string.Format("Баллы - {0}", SelectedTeam);
            if (string.IsNullOrEmpty(SelectedTeam)) return;


            LoadTeam();
        }

        internal override GridEX GetDataTable()
        {
            return gridData;
        }
        internal override string GetFileName()
        {
            return base.GetFileName();
        }

        

        private void LoadTeam()
        {
            var dt = gridData.DataSource as DataTable;
            if (dt != null)
            {
                dt.ColumnChanged -= dt_ColumnChanged;
                gridData.DataSource = null;
                gridData.Refetch();
                dt.Dispose();
                dt = null;
            }

            CurrentTeam = GameService.DbContext.TeamSet.First(f => f.Name == SelectedTeam);

            label1.Text = CurrentTeam.Name;

            dt = new DataTable();
            ColumnTable = new Dictionary<DataColumn, CompetitionReferee>();
            var markColumn = dt.Columns.Add("Оценка", typeof(string));


            var obhodIndex = 1;
            foreach (var referee in GameService.GetStageReferees(Stage))
            {
                ColumnTable.Add(dt.Columns.Add(string.Format("Обход №{0}", obhodIndex ++), typeof(int)), referee);
            }

            var valueTypes = GameService.GetValueTypes(Stage, null);

               RowTable = new Dictionary<DataRow,GameValueType>();
         
            foreach (var valueType in valueTypes)
            {
                var row = dt.NewRow();

                row[markColumn] = EnumHelper<GameValueType>.GetDisplayValue(valueType);
                dt.Rows.Add(row);
                RowTable.Add(row,valueType);
            }

            foreach (var c in ColumnTable)
            {
                var gs = GameService.DbContext.GameResultSet.First(f=>f.Game.Team.Id == CurrentTeam.Id && f.CompetitionRefereeId == c.Value.Id);

                for(int i = 0; i < valueTypes.Count; i++)
                {
                    var value = gs.Values.FirstOrDefault(f=>f.Type == valueTypes[i]);
                    if (value != null)
                        dt.Rows[i][c.Key] = value.Value.HasValue ? (object)value.Value.Value : (object)DBNull.Value;
                    else
                    GameService.DbContext.GameResultValueSet.Add(new GameResultValue()
                    {
                     GameResult = gs,
                      Type = valueTypes[i],
                       Value= null
                    });


                }


            }


            



            gridData.DataSource = dt;
            gridData.RetrieveStructure();

            gridData.RootTable.Columns["Оценка"].EditType = EditType.NoEdit;
            gridData.FrozenColumns = 1;

            gridData.GroupByBoxVisible = false;
            gridData.ColumnAutoSizeMode = ColumnAutoSizeMode.ColumnHeader;

            dt.ColumnChanged += dt_ColumnChanged;


            foreach (var c in ColumnTable)
            {
                var column = gridData.RootTable.Columns.Cast<GridEXColumn>().First(f => f.DataMember == c.Key.Caption);
                column.TextAlignment = TextAlignment.Center;

                var condition = new GridEXFormatCondition();
                condition.Column = column;

                condition.ConditionOperator = ConditionOperator.IsEmpty;
                condition.FormatStyle.BackColor = Color.LightBlue;

                condition.TargetColumn = column;

                gridData.RootTable.FormatConditions.Add(condition);
            }


        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (!ColumnTable.ContainsKey(e.Column)) return;
            if (!RowTable.ContainsKey(e.Row)) return;

           
            int? newValue = null;
            int nv = 0;
            if (int.TryParse(e.ProposedValue.ToString(), out nv))
            {
                newValue = nv;
            }

            if (newValue.HasValue)
            {
                if (newValue > GameService.MaxValue(Stage, RowTable[e.Row])
                    || newValue < GameService.MinValue(Stage, RowTable[e.Row]))
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

            var c = ColumnTable[e.Column];

            var gameResult = GameService.DbContext.GameResultSet.First(f => f.Game.Stage.Id == Stage.Id && f.Referee.Id == c.Id && f.Game.Team.Id == CurrentTeam.Id);
            var value = gameResult.Values.FirstOrDefault(f => f.Type == RowTable[e.Row]);

            if (value == null)
                GameService.DbContext.GameResultValueSet.Add(new GameResultValue() { GameResult = gameResult, Type = RowTable[e.Row], Value = newValue });
            else
                value.Value = newValue;

        }

        

        private string SelectedTeam
        {
            get 
            {
                return grid.SelectedItems.Count > 0 ? (grid.SelectedItems[0].GetRow().DataRow as DataRowView).Row[0].ToString() : "";
            }
        }


        void table_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            //if (!ColumnStructure.ContainsKey(e.Column)) return;

            //var c = ColumnStructure[e.Column];

            //var team = e.Row.Field<string>(0);

            //int? newValue = null;

            //int nv = 0;

            //if (int.TryParse(e.ProposedValue.ToString(), out nv ))
            //{
            //    newValue = nv;
            //}

            
            
            //if (newValue.HasValue)
            //{
            //    if (newValue > GameService.MaxValue(Stage, c.ValueType)
            //        || newValue < GameService.MinValue(Stage, c.ValueType))
            //    {
            //        newValue = null;
            //    }
                   
            //}
            //if (!newValue.HasValue)
            //{
            //    e.Row.SetColumnError(e.Column, "Неправильное значение");
            //}
            //else
            //    e.Row.SetColumnError(e.Column, "");

            //var gameResult = GameService.DbContext.GameResultSet.First(f => f.Game.Stage.Id == Stage.Id && f.Referee.Id == c.Referee.Id && f.Game.Team.Name == team);
            //var value = gameResult.Values.FirstOrDefault(f => f.Type == c.ValueType);

            //if (value == null)
            //    GameService.DbContext.GameResultValueSet.Add(new GameResultValue() { GameResult = gameResult, Type = c.ValueType, Value = newValue });
            //else
            //    value.Value = newValue;

            
        }

        private void btRandom_Click(object sender, EventArgs e)
        {

            //Data.Keys.ToList().ForEach(v =>
            //{
            //    GameService.DbContext.GameResultValueSet.RemoveRange(GameService.DbContext.GameResultValueSet.Where(f =>f.GameResult.Game.Stage.Id == Stage.Id && f.GameResult.CompetitionRefereeId == v.Id));
            //});



            //GameService.DbContext.Configuration.AutoDetectChangesEnabled = false;
            //GameService.DbContext.Configuration.ValidateOnSaveEnabled = false;

            //var rand = new Random();



            //foreach (var item in Data)
            //{
            //    var referee = item.Key;
            //    var valueTypes = GameService.GetValueTypes(Stage, referee);
                
            //    foreach (var row in item.Value.Rows)
            //    {
            //        var r = row as DataRow;

            //        var items = r.ItemArray;

            //        foreach (var valueType in valueTypes)
            //        {
            //            var value = rand.Next(10);
            //            while (GameService.MaxValue(Stage, valueType) < value || GameService.MinValue(Stage, valueType) > value)
            //            {
            //                value = rand.Next(10) - rand.Next(5);
            //            }

            //            items[item.Value.Columns[EnumHelper<GameValueType>.GetDisplayValue(valueType)].Ordinal] = value;

                      
            //        }

            //        r.ItemArray = items;
            //    }
                
            //}
            //GameService.DbContext.SaveChanges();
        }

        public bool SkipRowChange = false;
        private Team CurrentTeam;
        private Dictionary<DataColumn, CompetitionReferee> ColumnTable;
        private Dictionary<DataRow, GameValueType> RowTable;


        public void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            
       

        }

        public void UpdateValue( CompetitionReferee referee, GameValueType type, int? value)
        {

        }


       

        public override void FinishStage()
        {
            if (DialogResult.Yes != 
                MessageBox.Show(this, string.Format("Завершить этап {0}:{1}?", Stage.Competition.Name, Stage.Name), "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;


            for (int i = 0; i < grid.RowCount; i++)
            {
                grid.Row = i;
                Application.DoEvents();
                foreach (var row in (gridData.DataSource as DataTable).Rows.Cast<DataRow>())
                {
                    if (row.ItemArray.Any(f => f == DBNull.Value))
                    {
                        MessageBox.Show("Не все результаты введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

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
          
        }

       
        public override void OnClosing()
        {
            
        }

        private void grid_FormattingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void btTempResults_Click(object sender, EventArgs e)
        {
            var referees = GameService.GetStageReferees(Stage);

            var values = GameService.GetStageGames(Stage).ToDictionary(f => f, f => GameService.GetGameResultValues(f));

            var ref1 = referees.First();
            var ref2 = referees.Skip(1).First();

            var empty = GetEmptyGames(values, ref1).OrderBy(f=>f.Game1Name()).Distinct().ToList();

            if (empty.Any())
            {
                MessageBox.Show("Не заполнены данные первого обхода у комманд: " + string.Join(", ", empty.Select(f => f.Game1Name())));
                return;
            }

            empty = GetEmptyGames(values, ref2).OrderBy(f => f.Game1Name()).Distinct().ToList();

            if (empty.Any())
            {

               

                MessageBox.Show("Считаем ПЕРВЫЙ ОБХОД!Не заполнены данные второго обхода у комманд: " + string.Join(", ", empty.Select(f => f.Game1Name())));

                foreach ( var s in values.Select(g=>g.Value))
                {
                    s.Remove(ref2);
                }

                var scores = new List<TeamScore>();
                foreach (var item in values)
                {
                    var log = new StringBuilder();
                    scores.Add(new TeamScore() { Team = item.Key.Team, Score = GameService.GetGameScore(item.Key, item.Value, log).Value, Description = log.ToString() });


                }
                using (var form = new NextStageTeamsForm(GameService.DbContext, scores.OrderByDescending(f => f.Score).ToList()))
                {
                    form.Text = "Промежуточные результаты Первого Обхода";
                    form.ShowDialog();
                }

                return;
            }





        }

        private IEnumerable<Game> GetEmptyGames(Dictionary<Game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>>> values, CompetitionReferee referee)
        {
            foreach(var game in values)
            {
                foreach(var value in game.Value)
                {
                    if (value.Key.Id != referee.Id) continue;
                    if (value.Value.Any(f=>!f.Value.HasValue))
                    {
                        yield return game.Key;
                        break;
                    }
                }
            }
        }

        public override void SetRandomValues()
        {
            var valueTypes = GameService.GetValueTypes(Stage, null).ToDictionary(f=> EnumHelper<GameValueType>.GetDisplayValue(f),f=>f);
            
            if (MessageBox.Show("Заполнить первый обход?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            for (int i = 0; i < grid.RowCount; i++)
            {
                grid.Row = i;
                Application.DoEvents();
                foreach(var row in (gridData.DataSource as DataTable).Rows.Cast<DataRow>())
                {
                    var min = GameService.MinValue(Stage, valueTypes[row[0].ToString()]);
                    var max = GameService.MaxValue(Stage, valueTypes[row[0].ToString()]);

                    var value = min + new Random().Next(Math.Abs(max - min));
                    row[1] = value;

                }
            }

            if (MessageBox.Show("Заполнить второй обход?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                for (int i = 0; i < grid.RowCount; i++)
                {
                    grid.Row = i;
                    Application.DoEvents();
                    foreach (var row in (gridData.DataSource as DataTable).Rows.Cast<DataRow>())
                    {
                        var min = GameService.MinValue(Stage, valueTypes[row[0].ToString()]);
                        var max = GameService.MaxValue(Stage, valueTypes[row[0].ToString()]);

                        var value = min + new Random().Next(Math.Abs(max - min));
                        row[2] = value;

                    }
                }


        }
    }
}
