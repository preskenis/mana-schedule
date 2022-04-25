using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Janus.Windows.GridEX;

namespace ManaSchedule.Views
{
    public partial class ScheduleGeneratorView : ManaSchedule.Views.ContentView
    {
   

        public ScheduleGeneratorView()
        {
            InitializeComponent();

            DbContext.CompetitionSet.Load();
            this.GridEX.RootTable.Columns["Competition"].HasValueList = true;
            this.GridEX.RootTable.Columns["Competition"].EditType = EditType.NoEdit;
            this.GridEX.RootTable.Columns["Competition"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Competition"].ValueList.PopulateValueList(DbContext.CompetitionSet.Local.ToList(), "Name");

        }

        public override void OnClosing()
        {
           
        }

        public void Init()
        {

            DbContext.StageSet.Load();
            DbContext.GameSet.Load();
            DbContext.TeamSet.Load();
            

            GridEX.DataSource = DbContext.StageSet.Local.ToBindingList();


        }

        private void btGenerate_Click(object sender, EventArgs e)
        {

        }

        private void PopulateSchedule(List<Game> list)
        {
            schedule.DataSource = null;

            if (list.Count == 0) return;

            schedule.StartTimeMember = "From";
            schedule.EndTimeMember = "To";

            schedule.TextMember = "Text";

            schedule.Dates.Clear();
            schedule.DayEndHour = 24;
            schedule.DayStartHour = list.Min(f => f.From.Value.Hour);
            schedule.DayEndHour = list.Max(f => f.To.Value.Hour);

            list.Select(f => f.From.Value.Date).Distinct().ToList().ForEach(f => schedule.Dates.Add(f));


            list.Select(f => f.From.Value.Date).Distinct().ToList().ForEach(f => schedule.Dates.Add(f));

            schedule.DataSource = new BindingList<GameInfo>(list.Select(f => new GameInfo() { Game = f }).ToList());

            uiTabPage2.Selected = true;
        }

        public override Janus.Windows.Ribbon.Ribbon RibbonControl
        {
            get
            {
                
                return ribbon1;
            }
        }
        
        public class GameInfo 
        {
            public Game Game { get;set;}

            public DateTime From { get {return Game.From.Value;} set{Game.From = value;}}
            public DateTime To { get { return Game.To.Value; } set { Game.To = value; } }

            public string Text
            {
                get
                {
                    var sb = new StringBuilder();
                    if (Game.Team != null) sb.Append(Game.Team.Name + "-");
                    if (Game.Team2 != null) sb.Append(Game.Team2.Name);
                    sb.AppendLine();
                    sb.Append(Game.Competition.Name);


                    return sb.ToString();
                }
            }
        

        
        }


    }
}
