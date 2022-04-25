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
    public partial class StageRefereeResultView : UserControl
    {

        public StageRefereeResultView()
        {
            InitializeComponent();
        }


        public void OnClosing()
        {
            
        }

        public Stage Stage { get; set; }

        public CompetitionReferee Referee { get; set; }

        public GameService GameService { get; set; }


        public DataTable Data { get; set; }


        public void Init(Stage content)
        {
           
            //GameService.DbContext.GameResultValueSet.Where(f => f.GameResult.Game.StageId == content.Id).Load();

            //Stage = content;
            //Data = new Dictionary<CompetitionReferee, DataTable>();

            //var refereeIndex = 1;

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

        public void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            //if (SkipRowChange) return;
            //var referee = Data.First(f => f.Value == e.Row.Table).Key;
            //var valueTypes = GameService.GetValueTypes(Stage, referee);
            //var team = e.Row.Field<string>(0);

            //var gameResult = GameService.DbContext.GameResultSet.Local.First(f => f.Game.Stage.Id == Stage.Id && f.Referee.Id == referee.Id && f.Game.Team.Name == team);

            //foreach (var valueType in valueTypes)
            //{
            //    var value = GameService.DbContext.GameResultValueSet.Local.FirstOrDefault(f => f.GameResult == gameResult && f.Type == valueType);
            //    var val = e.Row.Field<int?>(e.Row.Table.Columns[EnumHelper<GameValueType>.GetDisplayValue(valueType)]);

            //    if (val.HasValue)
            //    {
            //        if (val.Value > GameService.MaxValue(gameResult.Game.Stage, valueType)
            //            || val.Value < GameService.MinValue(gameResult.Game.Stage, valueType) 
            //            )
            //        {
            //            e.Row.SetField<int?>(e.Row.Table.Columns[EnumHelper<GameValueType>.GetDisplayValue(valueType)], null);
            //        }
            //        else
            //        {
            //            if (value == null) GameService.DbContext.GameResultValueSet.Add(new GameResultValue()
            //            {
            //                GameResult = gameResult,
            //                Type = valueType,
            //                Value = val.Value,
            //            });
            //            else
            //            {
            //                if (value.Value != val.Value)
            //                    value.Value = val.Value;
                           
            //            }
            //        }

                   
            //    }
            //    else
            //    {
            //        if (value != null)
            //        {
            //            GameService.DbContext.GameResultValueSet.Remove(value);
            //        }
            //    }
            //}
            //gameResult.Description = e.Row.Field<string>("Примечание");

        }

        public void UpdateValue( CompetitionReferee referee, GameValueType type, int? value)
        {

        }



        public void FinishStage()
        {
            //if (DialogResult.Yes != 
            //    MessageBox.Show(this, string.Format("Завершить этап {0}:{1}?", Stage.Competition.Name, Stage.Name), "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //    return;

            //foreach (var item in Data)
            //{
            //    foreach (var row in item.Value.Rows.Cast<DataRow>())
            //    {
            //        if (row.ItemArray.Skip(1).Take(row.ItemArray.Length - 2).Any(f => f == DBNull.Value))
            //        {
            //            MessageBox.Show("Не все результаты введены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //    }
            //}

            //GameService.EndStage(Stage);
            //MessageBox.Show("Этап завершен, места пересчитаны", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void FillRandom()
        {

        }
 



        internal void ShowNames(bool showNames)
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

        public Janus.Windows.UI.Tab.UITabPage CurrentReferee
        {
            get { return refereeTabs.SelectedTab; }
        }
    }
}
