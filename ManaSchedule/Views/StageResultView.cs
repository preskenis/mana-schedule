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
    public partial class StageResultView : StageResultViewBase
    {

        public StageResultView()
        {
            InitializeComponent();
        }


        

       

        public Dictionary<CompetitionReferee, DataTable> Data { get; set; }


        public override void Init()
        {
           
            GameService.DbContext.GameResultValueSet.Where(f => f.GameResult.Game.StageId == Stage.Id).Load();

            
            Data = new Dictionary<CompetitionReferee, DataTable>();

            var refereeIndex = 1;

            foreach (var referee in GameService.DbContext.CompetitionRefereeSet.Where(f=>f.CompetitionId == Stage.CompetitionId))
            {
                var page = new Janus.Windows.UI.Tab.UITabPage(referee.IsMainReferee ? "Гл. судья" : "Судья №" + refereeIndex.ToString())
                     {
                         Tag = referee
                     };
                if (!referee.IsMainReferee) refereeIndex++;

                refereeTabs.TabPages.Add(page);
               
                var grid = new GridEX() { Dock = DockStyle.Fill, Name = "gridReferee" };
                page.Controls.Add(grid);
                var dt = GetTable(Stage, referee);
                grid.DataSource = dt;
                grid.RetrieveStructure();
                grid.RootTable.Columns["Команда"].EditType = EditType.NoEdit;
                
                if (grid.RootTable.Columns.Contains("Жеребьевка"))
                {
                    grid.RootTable.Columns["Жеребьевка"].EditType = EditType.NoEdit;
                    grid.RootTable.SortKeys.Add(grid.RootTable.Columns["Жеребьевка"], Janus.Windows.GridEX.SortOrder.Ascending);
                    
                }
                else
                    grid.RootTable.SortKeys.Add(grid.RootTable.Columns["Команда"], Janus.Windows.GridEX.SortOrder.Ascending);


                grid.GroupByBoxVisible = false;

                
                grid.ColumnAutoSizeMode = ColumnAutoSizeMode.ColumnHeader;
                grid.ColumnAutoResize = true;

                grid.RootTable.Columns.Cast<GridEXColumn>().ToList().ForEach(f => 
                {
                    if (dt.Columns[f.DataMember].DataType == typeof(int))
                    {
                        var condition = new GridEXFormatCondition();
                        condition.Column = f;

                        condition.ConditionOperator = ConditionOperator.IsEmpty;
                        condition.FormatStyle.BackColor = Color.LightBlue;

                       
                       
                        condition.TargetColumn = f;

                        grid.RootTable.FormatConditions.Add(condition);
                    }
                
                });
                

                Data.Add(referee, dt);
                
                dt.RowChanged += dt_RowChanged;

                grid.RowHeaderContent = RowHeaderContent.RowPosition;
                grid.RowHeaders = InheritableBoolean.True;

                grid.EnsureVisible(1);
                
            }

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
            if (SkipRowChange) return;
            var referee = Data.First(f => f.Value == e.Row.Table).Key;
            var valueTypes = GameService.GetValueTypes(Stage, referee);
            var team = e.Row.Field<string>(0);

            var gameResult = GameService.DbContext.GameResultSet.Local.First(f => f.Game.Stage.Id == Stage.Id && f.Referee.Id == referee.Id && f.Game.Team.Name == team);

            foreach (var valueType in valueTypes)
            {
                var value = gameResult.Values.FirstOrDefault(f => f.GameResult == gameResult && f.Type == valueType);
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

            DataColumn teamZherColumn = null;
            if (GameService.HasZhereb(stage))
            {
               teamZherColumn = table.Columns.Add("Жеребьевка", typeof(int));
            }
            
           

            var valueTypes = GameService.GetValueTypes(stage, referee);
            var dictTable = valueTypes.ToDictionary(f => f, f => table.Columns.Add(EnumHelper<GameValueType>.GetDisplayValue(f), typeof(int)));



            var gamesIds = stage.Game.Where(f=>f.Team1Missed == false && !f.Team1Cancel).Select(f => f.Id).ToList();

            var grs = GameService.DbContext.GameResultSet.Where(
                f => f.CompetitionRefereeId == referee.Id &&
                     gamesIds.Contains(f.GameId)).ToList();

            var grIds = grs.Select(f => f.Id).ToList();

            var allValues = GameService.DbContext.GameResultValueSet.Where(f => grIds.Contains(f.GameResultId)).ToList();
            


            foreach (
                var gr in
                grs)
            {
                var row = table.NewRow();
                row[teamColumn] = gr.Game.Team.Name;
                if (teamZherColumn != null)
                {
                    row[teamZherColumn] = gr.Game.Team.Competitions.First(f => f.CompetitionId == stage.CompetitionId).Order.Value;
                }

                var values = allValues.Where(f => f.GameResultId == gr.Id).ToList();



                values.ForEach(f =>
                {
                    if (dictTable.ContainsKey(f.Type)) row[dictTable[f.Type]] = f.Value;
                });

                table.Rows.Add(row);
            }


            table.Columns.Add("Примечание", typeof(string));
         
            return table;
        }

      

        public override void FinishStage()
        {
            if (DialogResult.Yes != 
                MessageBox.Show(this, string.Format("Завершить этап {0}:{1}?", Stage.Competition.Name, Stage.Name), "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            foreach (var item in Data)
            {
                foreach (var row in item.Value.Rows.Cast<DataRow>())
                {
                    for (int i = 0; i < row.ItemArray.Length; i++ )
                    {
                        if (row.ItemArray[i] == DBNull.Value)
                        {
                            if (item.Value.Columns[i].DataType == typeof(int))
                            {
                                MessageBox.Show("Не все результаты введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            
                        }
                    }

                        
                }
            }

            GameService.EndStage(Stage);
            MessageBox.Show("Этап завершен, места пересчитаны", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void FillRandom()
        {

        }

        internal override GridEX GetDataTable()
        {
            return refereeTabs.SelectedTab.Controls[0] as GridEX;
        }
        internal override string GetFileName()
        {
            return Stage.Name + "-" + refereeTabs.SelectedTab.Text;
        }

        public override void ShowNames(bool showNames)
        {
              var refereeIndex = 1;

             foreach (var page in refereeTabs.TabPages.Cast<Janus.Windows.UI.Tab.UITabPage>())
            {
                var referee = page.Tag as CompetitionReferee;
                if (referee == null) continue;

                if (showNames && referee.Person != null)
                {
                    page.Text = string.Format("{0}", referee.Person.Name); 
                }
                else
                {
                    page.Text = referee.IsMainReferee ? "Гл. судья" : "Судья №" + refereeIndex.ToString();
                }
                
                    if (!referee.IsMainReferee) refereeIndex++;
            }
        }

        public Janus.Windows.UI.Tab.UITabPage CurrentReferee
        {
            get { return refereeTabs.SelectedTab; }
        }

        public override void OnClosing()
        {
            
        }
    }
}
