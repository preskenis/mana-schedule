using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ManaSchedule.Services
{
    public class SoloSongGameService : GameService
    {
        public SoloSongGameService()
        {
            StageScores = new Dictionary<StageType, Dictionary<GameValueType, StageScoreSettings>>() 
            {
            {
                StageType.Final, new Dictionary<GameValueType,  StageScoreSettings>()
            {
                { GameValueType.Vocal, new StageScoreSettings(0, 10) } ,
                { GameValueType.Music, new StageScoreSettings(0, 10) } ,
                { GameValueType.RaskrTema, new StageScoreSettings(0, 10) } ,
                { GameValueType.SelfSong, new StageScoreSettings(0, 10) } ,
                { GameValueType.SelfMusic, new StageScoreSettings(0, 5) } ,
                { GameValueType.Artist, new StageScoreSettings(0, 3) } ,
                { GameValueType.FanSupport, new StageScoreSettings(0, 2) } ,
                { GameValueType.BadBehaviour, new StageScoreSettings(-10, 0) } ,
                { GameValueType.MatShtraf, new StageScoreSettings(-5, 0) } , 
            }
            }};



        }

        public override bool HasZhereb(Stage stage)
        {
            return true;
        }
        public override List<GameValueType> GetValueTypes(Stage stage, CompetitionReferee referee)
        {
            if (referee.IsMainReferee)
            {
                return new List<GameValueType>() { GameValueType.MatShtraf };
            }
            else
            {
                return new List<GameValueType>() 
                {
                    GameValueType.Vocal,
                    GameValueType.Music,
                    GameValueType.RaskrTema,
                    GameValueType.SelfSong,
                    GameValueType.SelfMusic,
                    GameValueType.Artist,
                    GameValueType.FanSupport,
                    GameValueType.BadBehaviour,
                 };

            }
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

            stageGames.Where(f => f.Team1Cancel).ToList().ForEach(f =>
            {
                var s = DbContext.CompetitionScoreSet.Local.First(v => v.Team == f.Team);
                s.Place = stageGames.Count;
                s.Description = "Отмена игры";
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


            DbContext.SaveChanges();
        }


        public override void GenerateGames()
        {
            ClearAll();
            var refereees = DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == Competition.Id).ToList();

            Teams.ForEach(f =>
            {
                DbContext.CompetitionScoreSet.Add(
                    new CompetitionScore() { Competition = Competition, Team = f, Place = TeamsCount, Description = "Неучастие в конкурсе" });
            });


            var stage = DbContext.StageSet.Add(new Stage()
            {
                Competition = Competition,
                Type = StageType.Final,
                Name = "Основной этап"
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
                refereees.ForEach(f => DbContext.GameResultSet.Add(new GameResult() { Game = game, Referee = f }));

                var score = DbContext.CompetitionScoreSet.Local.First(f => Competition == Competition && f.Team == tc.Team);
                score.Place = DbContext.TeamCompetitionSet.Local.Count;
                score.Score = 0;
                score.Description = "Заявка на участие";
            }



        }

        public override double? GetGameScore(Game game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            if (values.Any(f => f.Value.Any(v => !v.Value.HasValue))) return null;
            return SumOtsechka(GameValueType.Vocal, values, log)
                + SumOtsechka(GameValueType.Music, values, log)
                + SumOtsechka(GameValueType.RaskrTema, values, log)
                + SumOtsechka(GameValueType.SelfSong, values, log)
                + SumOtsechka(GameValueType.SelfMusic, values, log)
                + SumOtsechka(GameValueType.Artist, values, log)
                + SumOtsechka(GameValueType.FanSupport, values, log)
                + Sum(GameValueType.BadBehaviour, values, log)
                + Sum(GameValueType.MatShtraf, values, log);
        }
    }
}
