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
            var selectedStages = GridEX.GetCheckedRows().Select(f => f.DataRow as Stage);

            while (true)
            {
                

                List<Dictionary<int, List<Game>>> bashenki = new List<Dictionary<int, List<Game>>>();

                foreach (var stage in selectedStages.GroupBy(f => f.Competition))
                {
                    var places = new Dictionary<int, List<Game>>();
                    places.Add(1, new List<Game>());
                    places.Add(2, new List<Game>());
                    var currentPlace = 1;

                    var games = DbContext.GameSet.Local.Where(f => stage.Any(v => v == f.Stage) && f.AllTeams().Count > 1).ToList();
                    games.Shuffle();

                    foreach (var game in games)
                    {
                        if (game.Team == null || game.Team2 == null) continue;

                        var startTime = places[currentPlace].LastOrDefault() != null ? places[currentPlace].Last().To.Value : stage.First().From.Value;
                        game.From = startTime;
                        game.To = startTime.AddMinutes(game.Stage.GameTime);
                        places[currentPlace].Add(game);
                        currentPlace = currentPlace == 1 ? 2 : 1;
                    }

                    bashenki.Add(places);
                }

                var bad = false;

                foreach (var team in bashenki.SelectMany(f => f.SelectMany(v => v.Value)).SelectMany(f => f.AllTeams()).Distinct())
                {
                    if (bad) break;
                    var teamGames = bashenki.SelectMany(f => f.SelectMany(v => v.Value).Where(k => k.AllTeams().Contains(team))).OrderBy(f=>f.From).ToList();

                    for (var i = 1; i < teamGames.Count; i++)
                    {
                        
                        if (teamGames[i-1].To >= teamGames[i].From)
                        {
                            bad = true;
                            break;
                        }
                    }
                }

                if (!bad) break;

                





            }


        }


    }
}
