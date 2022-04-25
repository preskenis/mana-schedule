using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ManaSchedule.Views;


namespace ManaSchedule.Services
{
    public abstract class GameService
    {

        public virtual List<CompetitionReferee> GetStageReferees(Stage stage)
        {
            return DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == stage.CompetitionId).OrderBy(f=>f.Id).ToList();
        }


        public virtual StageResultViewBase GetStageView(Stage stage)
        {
            return new StageResultView() { GameService = this, Stage = stage };
        }


        public void SetTeamScore(Team team, double place, double score, string description)
        {
            if (team == null) return;

            var sc = DbContext.CompetitionScoreSet.First(f => f.CompetitionId == Competition.Id && f.TeamId == team.Id);
            sc.Score = score;
            sc.Place = place;
            sc.Description = description;
        }

        public static GameService GetGameService(Competition competition, Db dbContext)
        {
            dbContext.TeamSet.Where(f=>f.Used).Load();

            switch (competition.Type)
            {
                case GameType.Soccer: return new PlayoffGameService() { Competition = competition, DbContext = dbContext };
                case GameType.Volleyball: return new PlayoffGameService() { Competition = competition, DbContext = dbContext };
                case GameType.Rugby: return new PlayoffGameService() { Competition = competition, DbContext = dbContext };
                case GameType.Cook: return new CookGameService() { Competition = competition, DbContext = dbContext };
                case GameType.SoloSong: return new SoloSongGameService() { Competition = competition, DbContext = dbContext };
                case GameType.ShowSong: return new ShowSongGameService() { Competition = competition, DbContext = dbContext };
                case GameType.TourRelay: return new TourRelayGameService() { Competition = competition, DbContext = dbContext };
                case GameType.Lager: return new LagerGameService() { Competition = competition, DbContext = dbContext };
                case GameType.Carnival: return new CarnivalGameService() { Competition = competition, DbContext = dbContext };
            }
            throw new NotImplementedException();
        }

        public int TeamsCount { get { return DbContext.TeamSet.Local.Where(f=>f.Used).Count(); } }

        public List<Team> Teams { get { return DbContext.TeamSet.Local.Where(f => f.Used).ToList(); } }



        public Db DbContext {get;set;}
        public Competition Competition{get;set;}

        public abstract void GenerateGames();

        public virtual List<GameValueType> GetValueTypes(Stage stage, CompetitionReferee referee)
        {
            return new List<GameValueType>();
        }


        public virtual void EndStage(Stage stage)
       {

       }

        public virtual void ClearAll()
        {
            DbContext.CompetitionScoreSet.RemoveRange(DbContext.CompetitionScoreSet.Where(f => f.CompetitionId == Competition.Id));
            DbContext.GameResultValueSet.RemoveRange(DbContext.GameResultValueSet.Where(f => f.GameResult.Game.CompetitionId == Competition.Id));
            DbContext.GameResultSet.RemoveRange(DbContext.GameResultSet.Where(f => f.Game.CompetitionId == Competition.Id));
            DbContext.GameSet.RemoveRange(DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id));
            DbContext.StageSet.RemoveRange(DbContext.StageSet.Where(f => f.CompetitionId == Competition.Id));
            DbContext.SaveChanges();
        }

        public virtual void CleanStage(Stage stage)
        {
        
        }

        public virtual void UpdateGame(Game game)
        {
        
        }

        public virtual bool HasZhereb(Stage stage)
        {
            return false;
        }



        public Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> GetGameResultValues(Game game)
        {
            var result = new Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>>();

            var allValues = DbContext.GameResultValueSet.Where(f => f.GameResult.GameId == game.Id).ToList();
            foreach (var referee in GetStageReferees(game.Stage))
            {
                var values = GetValueTypes(game.Stage, referee);
                result.Add(referee, values.ToDictionary(f => f, f => new int?()));

                allValues.Where(f => f.GameResult.CompetitionRefereeId == referee.Id).ToList().ForEach(f =>
                  {
                      if (result[referee].ContainsKey(f.Type)) result[referee][f.Type] = f.Value;
                  });

            }

            return result;
        }

        public  double? GetGameScore (Game game, StringBuilder log)
        {
            return GetGameScore(game, GetGameResultValues(game), log);
        }
        public virtual double? GetGameScore(Game game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            return 0;
        }

        public static List<int> RemoveUpDown(IEnumerable<int> values)
        {
            if (values.Count() < 4) 
                return values.ToList();
            var v = values.OrderBy(f => f).ToList();
            return v.Skip(1).Take(v.Count - 2).ToList();
        }

        public List<int> GetValues(GameValueType valueType, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values)
        {
            return values.Where(f => f.Value.ContainsKey(valueType)).Select(f => f.Value[valueType].Value).ToList();
        }

        public double SumOtsechka(GameValueType valueType, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values)
        {
            return SumOtsechka(valueType, values, new StringBuilder());
        }

        public double SumOtsechka(GameValueType valueType, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            var balls = values.Where(f => f.Value.ContainsKey(valueType)).Select(f => f.Value[valueType].Value).ToList();
            var ballsStr = balls.Select(f => f.ToString()).ToList();
            var otsechka = RemoveUpDown(balls).ToList();

            var ballsOts = new List<int>(balls);
            otsechka.ForEach(f => ballsOts.Remove(f));

            foreach (var o in ballsOts)
            {
                for (int i = 0; i < ballsStr.Count; i++)
                {
                    if (ballsStr[i] == o.ToString())
                    {
                        ballsStr[i] = "\"" + o.ToString() + "\"";
                        break;
                    }
                }
            }

            var resultString = string.Format("[{1} - {0}]", string.Join(" + ", ballsStr), EnumHelper<GameValueType>.GetDisplayValue(valueType));
            log.Append(resultString);
            return otsechka.Sum();
        }

        public int Sum(GameValueType valueType, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            return values.Where(f => f.Value.ContainsKey(valueType)).Select(f => f.Value[valueType].Value).Sum();
        }

        public int Sum(GameValueType valueType, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values)
        {
            return Sum(valueType, values, new StringBuilder());
        }

        public virtual int MinValue(Stage stage, GameValueType valueType)
        {
            return StageScores[stage.Type][valueType].Min;
        }
        public virtual int MaxValue(Stage stage, GameValueType valueType)
        {
            return StageScores[stage.Type][valueType].Max;
        }
        
        protected Dictionary<StageType, Dictionary<GameValueType, StageScoreSettings>> StageScores = null;

        protected void EndStage3(Stage stage)
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
                s.Score = 10000;
            });


            if (stage.Type == StageType.Otbor)
            {

                var scores = new List<TeamScore>();
                foreach (var game in stageGames.Where(f => f.Stage.Id == stage.Id && f.Team1Missed == false && f.Team1Cancel == false))
                {
                    var log = new StringBuilder();
                    var score = GetGameScore(game, log).Value;
                    scores.Add(new TeamScore() { Team = game.Team, Score = score, Description = log.ToString() });
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
                    scores.Add(new TeamScore() { Team = game.Team, Score = score, Description = log.ToString() });
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
                        s.Description = string.IsNullOrEmpty(f.Description) ? "Игра в финале, проверьте место" : f.Description;
                        s.Score = f.Score;
                    });
                }


            }

            DbContext.SaveChanges();
        
        }

        public virtual List<Game> GetStageGames(Stage stage)
        {
            DbContext.GameSet.Where(f => f.StageId == stage.Id).Load();
            return DbContext.GameSet.Local.Where(f => f.StageId == stage.Id).ToList();
        }

        protected void EndStage2(Stage stage)
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
                    scores.Add(new TeamScore() { Team = game.Team, Score = score, Description = log.ToString() });
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
                        if (!DbContext.TeamCompetitionSet.First(v=>v.CompetitionId == Competition.Id && v.Team.Id == f.Team.Id).IsPastWinner)
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
                    scores.Add(new TeamScore() { Team = game.Team, Score = score, Description = log.ToString() });
                }

                var nextPlace = 1;
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
                        s.Description = string.IsNullOrEmpty(f.Description) ? "Игра в финале, проверьте место" : f.Description;
                        s.Score = f.Score;
                    });
                }


            }

            DbContext.SaveChanges();
            
        
        }
        
    }
}
