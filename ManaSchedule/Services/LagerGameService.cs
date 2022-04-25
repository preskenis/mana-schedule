using ManaSchedule.DataModels;
using ManaSchedule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ManaSchedule.Services
{
    public class LagerGameService : GameService
    {
        public LagerGameService()
        {
            StageScores = new Dictionary<StageType, Dictionary<GameValueType, StageScoreSettings>>()
            {
            {
                StageType.Otbor, new Dictionary<GameValueType, StageScoreSettings>()
            {

                  {GameValueType.Flag, new StageScoreSettings(0, 1) } ,
        {GameValueType.Territory, new StageScoreSettings(0, 2) } ,
        {GameValueType.Dezhur, new StageScoreSettings(0, 1) } ,
        {GameValueType.FireHoz, new StageScoreSettings(0, 1) } ,
        {GameValueType.FirePlace, new StageScoreSettings(0, 2) } ,
        {GameValueType.Medicine, new StageScoreSettings(0, 1) } ,
        {GameValueType.Znaki, new StageScoreSettings(0, 2) } ,
        {GameValueType.Tent, new StageScoreSettings(0, 1) } ,
        {GameValueType.DrovaZone, new StageScoreSettings(0, 2) } ,
        {GameValueType.TrashZone, new StageScoreSettings(0, 1) } ,
        {GameValueType.EatZone, new StageScoreSettings(0, 1) } ,
        {GameValueType.Clean, new StageScoreSettings(-2, 2) } ,
        {GameValueType.Oformlenie, new StageScoreSettings(0, 3) } ,
        {GameValueType.Stend, new StageScoreSettings(0, 2) } ,
        {GameValueType.Fishki, new StageScoreSettings(0, 3) } ,
        {GameValueType.Lapnik, new StageScoreSettings(-10, 0) } ,
        {GameValueType.BadPovedenie, new StageScoreSettings(-5, 0) } ,
        {GameValueType.FireDanger, new StageScoreSettings(-3, 0) } ,


            }


            },

            {
                StageType.Final, new Dictionary<GameValueType, StageScoreSettings>()
            {
                { GameValueType.FinalPlace, new StageScoreSettings(0, 20) } ,



            }


            }

            };

        }

        public override StageResultViewBase GetStageView(Stage stage)
        {
            if (stage.Type == StageType.Otbor)
                return new LagerStageResultView() { Stage = stage, GameService = this };
            return base.GetStageView(stage);
        }


        public override List<GameValueType> GetValueTypes(Stage stage, CompetitionReferee referee)
        {
            switch (stage.Type)
            {
                case StageType.Otbor:
                    return new List<GameValueType>()
                    {
          GameValueType.Flag,
        GameValueType.Territory,
        GameValueType.Dezhur,
        GameValueType.FireHoz,
        GameValueType.FirePlace,
        GameValueType.Medicine,
        GameValueType.Znaki,
        GameValueType.Tent,
        GameValueType.DrovaZone,
        GameValueType.TrashZone,
        GameValueType.EatZone,
        GameValueType.Clean,
        GameValueType.Oformlenie,
        GameValueType.Stend,
        GameValueType.Fishki,
        GameValueType.Lapnik,
        GameValueType.BadPovedenie,
        GameValueType.FireDanger,
                    };




                case StageType.Final:
                    return new List<GameValueType>()
                        {
                            GameValueType.FinalPlace,

                        };
                default: throw new NotImplementedException();
            }

        }

        public override bool HasZhereb(Stage stage)
        {
            if (stage.Type == StageType.Otbor)
                return true;
            return base.HasZhereb(stage);
        }

        public override void GenerateGames()
        {
            ClearAll();

            DbContext.Configuration.AutoDetectChangesEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;

           
            var stage = DbContext.StageSet.Add(new Stage()
            {
                Competition = Competition,
                Type = StageType.Otbor,
                Name = "Отборочный"
            });

            var refereees = GetStageReferees(stage);


            Teams.ForEach(f =>
            {
                DbContext.CompetitionScoreSet.Add(
                    new CompetitionScore() { Competition = Competition, Team = f, Place = TeamsCount, Description = "Неучастие в конкурсе" });
            });



            foreach (var tc in DbContext.TeamCompetitionSet.Local.Where(f => f.CompetitionId == Competition.Id).OrderBy(f => f.Order))
            {
                var game = DbContext.GameSet.Add(new Game()
                {
                    CompetitionId = Competition.Id,
                    Stage = stage,
                    Team = tc.Team,
                    Team1Missed = false,
                    Description = string.Format("Игра по жеребъевке №{0}", tc.Order),
                });


                refereees.ToList().ForEach(f =>
                      {
                          var gr = DbContext.GameResultSet.Add(new GameResult() { Game = game, Referee = f });
                          GetValueTypes(stage, f).ForEach(v => DbContext.GameResultValueSet.Local.Add(new GameResultValue()
                          {
                              GameResult = gr,
                              Type = v,
                              Value = null
                          }));
                      }
                    );

                var score = DbContext.CompetitionScoreSet.Local.First(f => Competition == Competition && f.Team == tc.Team);
                score.Place = DbContext.TeamCompetitionSet.Local.Count;
                score.Score = 0;
                score.Description = "Заявка на участие";
            }

            stage = DbContext.StageSet.Add(new Stage()
            {
                Competition = Competition,
                Type = StageType.Final,
                Name = "Финал"
            });
        }

        public override void EndStage(Stage stage)
        {
            DbContext.TeamCompetitionSet.Where(f => f.CompetitionId == Competition.Id).Load();
            DbContext.CompetitionScoreSet.Where(f => f.CompetitionId == Competition.Id).Load();
            DbContext.GameSet.Where(f => f.StageId == stage.Id).Load();

            var stageGames = DbContext.GameSet.Local.Where(f => f.StageId == stage.Id).ToList();

            stageGames.Where(f => f.Stage.Id == stage.Id && f.Team1Missed == true).ToList().ForEach(f =>
            {
                var s = DbContext.CompetitionScoreSet.Local.First(v => v.Team == f.Team);
                s.Place = TeamsCount + 1;
                s.Description = "Неявка";
                s.Score = -1000;
            });


            if (stage.Type == StageType.Otbor)
            {

                var scores = new List<TeamScore>();
                foreach (var game in stageGames.Where(f => f.Stage.Id == stage.Id && f.Team1Missed == false && f.Team1Cancel == false))
                {
                    var log = new StringBuilder();
                    var score = GetGameScore(game, log).Value;
                    scores.Add(new TeamScore() { Team = game.Team, Score = score });
                }

                var nextTeams = new List<Team>();

                using (var form = new NextStageTeamsForm(DbContext, scores.OrderByDescending(f => f.Score).ToList()))
                {
                    if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                    nextTeams.AddRange(form.SelectedTeams.Select(f => f.Team));
                }

                stageGames.Where(f => f.Team1Cancel).ToList().ForEach(f =>
                {
                    var s = DbContext.CompetitionScoreSet.Local.First(v => v.Team == f.Team);
                    s.Place = DbContext.TeamCompetitionSet.Local.Count;
                    s.Description = "Отмена игры";
                    s.Score = 0;
                });

                nextTeams.ForEach(f =>
                {
                    var s = DbContext.CompetitionScoreSet.Local.First(v => v.Team == f);
                    s.Place = nextTeams.Count;
                    s.Description = "Выход в финал";
                    s.Score = scores.First(v => v.Team == f).Score;
                });

                scores.Where(f => nextTeams.Any(v => v == f.Team)).ToList().ForEach(f =>
                {
                    scores.Remove(f);
                });

                var nextPlace = nextTeams.Count + 1 + DbContext.TeamCompetitionSet.Count(f => f.CompetitionId == Competition.Id && f.IsPastWinner);
                foreach (var g in scores.GroupBy(f => f.Score).OrderByDescending(f => f.Key))
                {
                    double place = 0;
                    for (int i = nextPlace; i < nextPlace + g.Count(); i++) place += i;
                    place = place / g.Count();
                    nextPlace += g.Count();

                    g.ToList().ForEach(f =>
                    {
                        var s = DbContext.CompetitionScoreSet.Local.First(v => v.Team == f.Team);
                        s.Place = place;
                        s.Description = "Игра в отборочном туре";
                        s.Score = f.Score;
                    });
                }



                var nextStage = DbContext.StageSet.FirstOrDefault(f => f.CompetitionId == Competition.Id && f.Type == StageType.Final);
                if (nextStage == null) nextStage = DbContext.StageSet.Add(new Stage()
                {
                    ParentStage = stage,
                    Type = StageType.Final,
                    CompetitionId = Competition.Id,
                    Name = EnumHelper<StageType>.GetDisplayValue(StageType.Final),
                });

                var refereees = DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == Competition.Id).ToList();

                foreach (var team in nextTeams)
                {
                    if (!nextStage.Game.Any(f => f.TeamId == team.Id))
                    {
                        var game = DbContext.GameSet.Add(new Game()
                        {
                            CompetitionId = Competition.Id,
                            Stage = nextStage,
                            Team = team,
                            Team1Missed = false,
                            Description = string.Format("Победитель отборочного тура"),
                        });
                        refereees.ForEach(f => DbContext.GameResultSet.Add(new GameResult() { Game = game, Referee = f }));
                    }

                    nextStage.Game.Where(f => !nextTeams.Any(v => v.Id == f.Team.Id)).ToList().ForEach(f =>
                    {
                        if (!DbContext.TeamCompetitionSet.First(v => v.CompetitionId == Competition.Id && v.Team.Id == f.Team.Id).IsPastWinner)
                        {
                            DbContext.GameResultValueSet.RemoveRange(DbContext.GameResultValueSet.Where(v => v.GameResult.GameId == f.Id));
                            DbContext.GameResultSet.RemoveRange(DbContext.GameResultSet.Where(v => v.GameId == f.Id));
                            DbContext.GameSet.Remove(f);
                        }
                    });


                }

            }

            if (stage.Type == StageType.Final)
            {
                stageGames.Where(f => f.Team1Cancel).ToList().ForEach(f =>
                {
                    var s = DbContext.CompetitionScoreSet.Local.First(v => v.Team == f.Team);
                    s.Place = stageGames.Count;
                    s.Description = "Отмена игры в финале";
                    s.Score = 0;
                });

                var scores = new List<TeamScore>();
                foreach (var game in stageGames.Where(f => f.Stage.Id == stage.Id && f.Team1Missed == false && f.Team1Cancel == false))
                {
                    var log = new StringBuilder();
                    var score = GetGameScore(game, log).Value;
                    scores.Add(new TeamScore() { Team = game.Team, Score = score });
                }

                var nextPlace = 1;
                foreach (var g in scores.GroupBy(f => f.Score).OrderBy(f => f.Key))
                {
                    double place = 0;
                    for (int i = nextPlace; i < nextPlace + g.Count(); i++) place += i;
                    place = place / g.Count();
                    nextPlace += g.Count();

                    g.ToList().ForEach(f =>
                    {
                        var s = DbContext.CompetitionScoreSet.Local.First(v => v.Team == f.Team);
                        s.Place = place;
                        s.Description = "Игра в финале, проверьте место";
                        s.Score = f.Score;
                    });
                }


            }

            DbContext.SaveChanges();
        }

        public override double? GetGameScore(Game game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            return GetGameScore(game, values, log, false);

        }
        public override List<CompetitionReferee> GetStageReferees(Stage stage)
        {
            if (stage.Type == StageType.Otbor)
                return DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == stage.CompetitionId).OrderBy(f => f.Id).Take(2).ToList();

            return base.GetStageReferees(stage);
        }


        public double? GetGameScore(Game game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log, bool skipErrors)
        {
            if (!skipErrors && values.Any(f => f.Value.Any(v => !v.Value.HasValue))) return null;

            switch (game.Stage.Type)
            {
                case StageType.Otbor:
                    return
        Sum(GameValueType.Flag, values)
        + Sum(GameValueType.Territory, values)
        + Sum(GameValueType.Dezhur, values)
        + Sum(GameValueType.FireHoz, values)
        + Sum(GameValueType.FirePlace, values)
        + Sum(GameValueType.Medicine, values)
        + Sum(GameValueType.Znaki, values)
        + Sum(GameValueType.Tent, values)
        + Sum(GameValueType.DrovaZone, values)
        + Sum(GameValueType.TrashZone, values)
        + Sum(GameValueType.EatZone, values)
        + Sum(GameValueType.Clean, values)
        + Sum(GameValueType.Oformlenie, values)
        + Sum(GameValueType.Stend, values)
        + Sum(GameValueType.Fishki, values)
        + Sum(GameValueType.Lapnik, values)
        + Sum(GameValueType.BadPovedenie, values)
        + Sum(GameValueType.FireDanger, values);

                case StageType.Final:
                    var vals = values.Where(f => f.Value.ContainsKey(GameValueType.FinalPlace)).Select(f => f.Value[GameValueType.FinalPlace]).Where(f => f.HasValue && f.Value > 0).ToList();

                    return vals.Count > 0 ? vals.Average(f => f.Value) : 0;

                default: throw new NotSupportedException();
            }
        }


    }
}
