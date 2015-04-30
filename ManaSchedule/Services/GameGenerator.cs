using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.Services
{
    public class GameGenerator
    {
        public Competition Competition { get; private set; }
        public Db DbContext { get; private set; }

        public GameGenerator(Competition competition, Db db)
        {
            Competition = competition;
            DbContext = db;
        }

        public void GenerateGames()
        {
            switch (Competition.Type)
            {
                case GameType.Soccer:
                    GeneratePlayoffGames();
                    break;
                case GameType.Volleyball:
                    GeneratePlayoffGames();
                    break;
                case GameType.Rugby:
                    GeneratePlayoffGames();
                    break;
            }

        }

        private void GeneratePlayoffGames()
        {
            DbContext.SaveChanges();

            DbContext.GameSet.RemoveRange(DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id));
            DbContext.StageSet.RemoveRange(DbContext.StageSet.Where(f => f.CompetitionId == Competition.Id));

            var pastChamnpions = DbContext.TeamCompetitionSet.Local.Where(f => f.CompetitionId == Competition.Id && f.IsPastWinner).OrderBy(f => f.Team.Name).ToList();
            var teams = DbContext.TeamCompetitionSet.Local.Where(f => f.CompetitionId == Competition.Id && !f.IsPastWinner).OrderBy(f => f.Order).ToList();

            var stageChampCount = Utils.MinPow2(pastChamnpions.Count);


            var stageChamp = DbContext.StageSet.Add(new Stage()
            {

                CompetitionId = Competition.Id,
                Name = string.Format("1/{0}", stageChampCount),
                Type = Utils.GetStageTypeByGamesCount(stageChampCount)
            });

            for (var i = 0; i < stageChampCount; i++)
            {
                var game = DbContext.GameSet.Add(new Game()
                {
                    CompetitionId = Competition.Id,
                    Stage = stageChamp,
                    Team = i < pastChamnpions.Count ? pastChamnpions[i].Team : null
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
                    game.ParentGame2 = parentStage.Game.ElementAt(i+1);

                   
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


            foreach (var game in DbContext.GameSet.Local.Where(f=>f.CompetitionId == Competition.Id))
            {
                if (game.Team != null) allTeams.Remove(allTeams.First(f => f.Team.Id == game.Team.Id));
                if (game.Team2 != null) allTeams.Remove(allTeams.First(f => f.Team.Id == game.Team2.Id));
            }
        }



    }
}
