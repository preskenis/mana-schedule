using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using NPOI.HSSF.Record.Aggregates;

namespace ManaSchedule.Services
{
    public class PlayoffGameService : GameService
    {


        

        public override void GenerateGames()
        {
            Stage finalStage = null;
            ClearAll();

            Teams.ForEach(f =>
            {
                DbContext.CompetitionScoreSet.Add(
                    new CompetitionScore() { Competition = Competition, Team = f, Place = TeamsCount, Description = "Неучастие в конкурсе" });
            });



            var mainReferee = DbContext.CompetitionRefereeSet.FirstOrDefault(f => f.CompetitionId == Competition.Id && f.IsMainReferee);

            if (mainReferee == null)
                throw new NullReferenceException("Не указан главный судья");


            var pastChamnpions = DbContext.TeamCompetitionSet.Local.Where(f => f.CompetitionId == Competition.Id && f.IsPastWinner).OrderBy(f => f.PastWinnerPlace).ToList();
            var teams = DbContext.TeamCompetitionSet.Local.Where(f => f.CompetitionId == Competition.Id && !f.IsPastWinner).OrderBy(f => f.Order).ToList();

            var stageChampCount = Utils.MinPow2(pastChamnpions.Count);


            var stageChamp = DbContext.StageSet.Add(new Stage()
            {

                CompetitionId = Competition.Id,
                Name = string.Format("1/{0}", stageChampCount),
                Type = Utils.GetStageTypeByGamesCount(stageChampCount)
            });

            var indexes = new int[] {1, 8, 4, 5, 2, 7, 3, 6};
            for (var i = 0; i < indexes.Length; i++)
            {
                var game = DbContext.GameSet.Add(new Game()
                {
                    CompetitionId = Competition.Id,
                    Stage = stageChamp,
                    Team = pastChamnpions[indexes[i]-1].Team
                });

             

            }

            var parentStage = stageChamp;

            while (true)
            {
                if (parentStage.Game.Count == 2)
                {
                    var game1 = parentStage.Game.ElementAt(0);
                    var game2 = parentStage.Game.ElementAt(1);

                    var stage = DbContext.StageSet.Add(
                    new Stage()
                    {
                        CompetitionId = Competition.Id,
                        Name = "За третье место",
                        ParentStage = parentStage,
                        Type = StageType.Third

                    });

                    var game = DbContext.GameSet.Add(new Game()
                    {
                        CompetitionId = Competition.Id,
                        Stage = stage,
                        Name = "Матч за третье место",
                        ParentGame1 = game1,
                        ParentGame2 = game2,
                    });


                    stage = DbContext.StageSet.Add(
                   new Stage()
                   {
                       CompetitionId = Competition.Id,
                       Name = "Финал",
                       ParentStage = parentStage,
                       Type = StageType.Final
                   });

                    finalStage = stage;

                    game = DbContext.GameSet.Add(new Game()
                    {
                        CompetitionId = Competition.Id,
                        Stage = stage,
                        Name = "Финал",
                        ParentGame1 = game1,
                        ParentGame2 = game2,
                    });


                    break;

                }

                var stage1 = DbContext.StageSet.Add(
                    new Stage()
                    {
                        CompetitionId = Competition.Id,
                        Name = string.Format("1/{0}", parentStage.Game.Count / 2),
                        ParentStage = parentStage,
                        Type = Utils.GetStageTypeByGamesCount(parentStage.Game.Count / 2)
                    });

                for (var i = 0; i < parentStage.Game.Count; i += 2)
                {
                    var game = DbContext.GameSet.Add(new Game()
                    {
                        CompetitionId = Competition.Id,
                        Stage = stage1,
                    });

                    game.ParentGame1 = parentStage.Game.ElementAt(i);
                    game.ParentGame2 = parentStage.Game.ElementAt(i + 1);


                }

                parentStage = stage1;
            }

            var nextStage = stageChamp;


            while (true)
            {
                var stage = DbContext.StageSet.Add(
                  new Stage()
                  {
                      CompetitionId = Competition.Id,
                      Name = string.Format("1/{0}", nextStage.Game.Count * 2),
                  });
                nextStage.ParentStage = stage;

                var teamsNeeded = 2 * nextStage.Game.Select(f => 2 - f.GameTeams().Count).Sum();

                if (teams.Count >= teamsNeeded)
                {
                    stage.Type = Utils.GetStageTypeByGamesCount(nextStage.Game.Count * 2);
                    foreach (var game in nextStage.Game)
                    {
                        if (game.Team == null)
                            game.ParentGame1 = DbContext.GameSet.Add(new Game()
                            {
                                CompetitionId = Competition.Id,
                                Stage = stage,
                            });



                        if (game.Team2 == null)
                            game.ParentGame2 = DbContext.GameSet.Add(new Game()
                            {
                                CompetitionId = Competition.Id,
                                Stage = stage,
                            });
                    }

                    if (teams.Count == teamsNeeded)
                    {
                        var index = 0;
                        foreach (var game in stage.Game)
                        {
                            if (game.Team == null) game.Team = teams[index++].Team;
                            if (game.Team2 == null) game.Team2 = teams[index++].Team;
                        }
                        break;
                    }
                }
                else
                {
                    stage.Type = StageType.Otbor;

                    var otborTeams = teams.Count - nextStage.Game.Sum(f => 2 - f.GameTeams().Count);
                    var index = 0;

                    foreach (var game in nextStage.Game)
                    {
                        if (game.Team == null)
                            if (otborTeams > 0)
                            {
                                game.ParentGame1 = DbContext.GameSet.Add(new Game()
                                {
                                    CompetitionId = Competition.Id,
                                    Stage = stage,
                                    Team = teams[index++].Team,
                                    Team2 = teams[index++].Team,
                                });
                                otborTeams--;
                            }
                            else
                                game.Team = teams[index++].Team;

                        if (game.Team2 == null)
                            if (otborTeams > 0)
                            {
                                game.ParentGame2 = DbContext.GameSet.Add(new Game()
                                {
                                    CompetitionId = Competition.Id,
                                    Stage = stage,
                                    Team = teams[index++].Team,
                                    Team2 = teams[index++].Team,
                                });
                                otborTeams--;
                            }
                            else
                                game.Team2 = teams[index++].Team;


                    }

                    break;

                }

                nextStage = stage;
            }

            var allTeams = DbContext.TeamCompetitionSet.Where(f => f.CompetitionId == Competition.Id).ToList();


            allTeams.ForEach(tc =>
            {
                var score = DbContext.CompetitionScoreSet.Local.First(f => Competition == Competition && f.Team == tc.Team);
                score.Place = DbContext.TeamCompetitionSet.Local.Count;
                score.Score = 0;
                score.Description = tc.IsPastWinner ? "Победитель прошлого сезона" : "заявка на участие";
            });

            foreach (var game in DbContext.GameSet.Local.Where(f => f.CompetitionId == Competition.Id))
            {
                // add carnival data
                DbContext.GameResultSet.Add(new GameResult()
                {
                    Game = game,
                    Referee = mainReferee
                });



                if (game.Team != null) allTeams.Remove(allTeams.First(f => f.Team.Id == game.Team.Id));
                if (game.Team2 != null) allTeams.Remove(allTeams.First(f => f.Team.Id == game.Team2.Id));
            }


            foreach (var stageType in EnumHelper<StageType>.GetValues(StageType.Final))
            {
                if (stageType == StageType.Third) continue;
                if (finalStage == null) break;
                finalStage.Type = stageType;
                finalStage.Name = EnumHelper<StageType>.GetDisplayValue(stageType);
                finalStage = finalStage.ParentStage;
            }

           



        }

        public List<Game> GetCurrentStageGames(Stage stage)
        {
            return DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id && f.Stage.Type == stage.Type).ToList();
        }

        public List<Game> GetTeamGames(Team team)
        {
            DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id).Load();

            var competitionGames = DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id).ToList();

            var result = new List<Game>();
            foreach (var game in competitionGames)
            {
                if (game.TeamId.HasValue && game.TeamId == team.Id)
                {
                    result.Add(game);
                }else if (game.Team2_Id.HasValue && game.Team2_Id == team.Id)
                {
                    result.Add(game);
                }
            }


            return result;

            
        }

        public List<Game> GetNextStageGames(Stage stage)
        {
            var result = new List<Game>();

            foreach (var stageType in EnumHelper<StageType>.GetValues(StageType.Final).Where(f => f < stage.Type).OrderByDescending(f=>f))
            {
                result.AddRange(DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id && f.Stage.Type == stageType));
            }

            return result;

        }


        public override void UpdateGame(Game game)
        {
            var placesOnCurrentStage = GetCompetitionGames().Count(f => (int)f.Stage.Type <= (int)game.Stage.Type);


            if (game.Winner != null)
            {
                var games = GetTeamGames(game.Winner);

                var nextStageGames = GetNextStageGames(game.Stage);
                SetTeamScore(game.Winner, nextStageGames.Count, nextStageGames.Count, "Победа в этапе " + game.Stage.Name);
                switch (game.Stage.Type)
                {
                    case StageType.Final: SetTeamScore(game.Winner, 1, 1, "Победа финале"); break;
                    case StageType.Third: SetTeamScore(game.Winner, 3, 3, "Победа матче за 3 место"); break;
                }

            }
            if (game.Looser != null)
            {
                switch (game.Stage.Type)
                {
                    case StageType.Final: SetTeamScore(game.Looser, 2, 2, "Проигрыш в финале"); break;
                    case StageType.Third: SetTeamScore(game.Looser, 4, 4, "Проигрыш в матче за 3 место"); break;
                    case StageType.Stage12: SetTeamScore(game.Looser, 4, 4, "Проигрыш в полуфинале"); break;
                    default:
                        var nextStageGames = GetNextStageGames(game.Stage).Count;
                        var currentStageGames = GetCurrentStageGames(game.Stage).Count;
                        double place = 0;
                        for (int i = nextStageGames +1; i <= nextStageGames+currentStageGames; i++)place+=i;
                            SetTeamScore(game.Looser, place / currentStageGames, place / currentStageGames, "Проигрыш в этапе " + game.Stage.Name);
                        break;
                }
            }



            if (game.Team != null && game.Team1Missed == true)
            {
                
                if (IsPreviousGameWinner(game.Team, game))
                {
                    double place = placesOnCurrentStage + 1;

                    SetTeamScore(game.Team, Math.Min(TeamsCount + 1, place), Math.Min(TeamsCount + 1, place), "Неявка на этап " + game.Stage.Name);
                }
                else
                {
                    SetTeamScore(game.Team, TeamsCount + 1, TeamsCount + 1, "Неявка на турнир");
                }
            }

            if (game.Team2 != null && game.Team2Missed == true)
            {
                if (IsPreviousGameWinner(game.Team2, game))
                {
                    double place = placesOnCurrentStage + 1;

                    SetTeamScore(game.Team2, Math.Min(TeamsCount + 1, place), Math.Min(TeamsCount + 1, place), "Неявка на этап " + game.Stage.Name);

                }
                else
                {
                    SetTeamScore(game.Team2, TeamsCount + 1, TeamsCount + 1, "Неявка на турнир");
                }
            }

            DbContext.SaveChanges();


            

            var nextGames = DbContext.GameSet.Local.Where(f => f.ParentGame1 == game || f.ParentGame2 == game).ToList();

            //if (nextGames.Count == 0 || !game.Team1Missed.HasValue || !game.Team2Missed.HasValue)
            //{
                
            //}
            //else
            //{
                if (game.IsMissing)
                    foreach (var nextGame in nextGames)
                    {
                        if (nextGame.ParentGame1 == game)
                        {
                            nextGame.Team1Missed = true;
                            nextGame.Team = null;
                        }

                        if (nextGame.ParentGame2 == game)
                        {
                            nextGame.Team2Missed = true;
                            nextGame.Team2 = null;
                        }
                        UpdateGame(nextGame);
                    }
                else
                {
                    //if (game.Winner != null)
                        foreach (var nextGame in nextGames)
                        {
                            if (nextGame.ParentGame1 == game && nextGame.Stage.Type != StageType.Third)
                            {
                                nextGame.Team = game.Winner;
                                UpdateGame(nextGame);
                            }

                            if (nextGame.ParentGame2 == game && nextGame.Stage.Type != StageType.Third)
                            {
                                nextGame.Team2 = game.Winner;
                                UpdateGame(nextGame);
                            }

                            if (nextGame.ParentGame1 == game && nextGame.Stage.Type == StageType.Third)
                            {
                                nextGame.Team = game.Looser;
                                nextGame.Team1Missed = game.Looser == null;
                                UpdateGame(nextGame);
                            }

                            if (nextGame.ParentGame2 == game && nextGame.Stage.Type == StageType.Third)
                            {
                                nextGame.Team2 = game.Looser;
                                nextGame.Team2Missed = game.Looser == null;
                                UpdateGame(nextGame);
                            }
                        }
                }
            //}

            DbContext.SaveChanges();



           



        }

        private List<Game> GetCompetitionGames()
        {
            return DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id).ToList();
        }

        private bool IsPreviousGameWinner(Team team, Game game)
        {
            if (game.ParentGame1 != null && game.ParentGame1.Winner != null && game.ParentGame1.Winner.Id == team.Id) return true;
            if (game.ParentGame2 != null && game.ParentGame2.Winner != null && game.ParentGame2.Winner.Id == team.Id) return true;

            return false;
        }

        private bool TeamPlayedAnyGames(Team team)
        {
           
            foreach (var game in GetTeamGames(team))
            {
                if (game.IsMissing) continue;
                if (game.Team1Missed != null && game.Team != null && game.Team.Id == team.Id && !game.Team1Missed.Value && !game.Team1Cancel)
                {
                    return true;
                }

                if (game.Team2Missed != null && game.Team2 != null && game.Team2.Id == team.Id && !game.Team2Missed.Value && !game.Team2Cancel)
                {
                    return true;
                }
            }

            return false;
        }

        public void UpdateParents(Game game)
        {
            if (game.Stage.Type == StageType.Third)
            {

            }
           


        }
    }
}
