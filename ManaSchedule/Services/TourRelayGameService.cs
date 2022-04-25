using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ManaSchedule.Views;

namespace ManaSchedule.Services
{
    public class TourRelayGameService : GameService
    {
        public TourRelayGameService()
        {
            StageScores = new Dictionary<StageType, Dictionary<GameValueType, StageScoreSettings>>()
            {
            {
                StageType.Otbor, new Dictionary<GameValueType, StageScoreSettings>()
            {
                { GameValueType.Time, new StageScoreSettings(0, 10000)
                {
                    ViewFormat = (f) => string.Format("{0}:{1}", f / 60, f%60)
                }
                    } ,
            }


            },

            {
                StageType.Final, new Dictionary<GameValueType, StageScoreSettings>()
            {
                { GameValueType.Time, new StageScoreSettings(0, 10000)
                {
                     ViewFormat = (f) => string.Format("{0}:{1}", f / 60, f%60)
                } } ,
            }


            }};

        }



        public override List<GameValueType> GetValueTypes(Stage stage, CompetitionReferee referee)
        {
            return new List<GameValueType>() { GameValueType.Time };
        }

        public override bool HasZhereb(Stage stage)
        {
            if (stage.Type == StageType.Otbor)
            return true;
            return base.HasZhereb(stage);
        }

        public override void GenerateGames()
        {
            var refereees = DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == Competition.Id).ToList();

            Teams.ForEach(f =>
            {
                DbContext.CompetitionScoreSet.Add(
                    new CompetitionScore() { Competition = Competition, Team = f, Place = TeamsCount, Description = "Неучастие в конкурсе" });
            });


            var stage = DbContext.StageSet.Add(new Stage()
            {
                Competition = Competition,
                Type = StageType.Otbor,
                Name = "Отборочный"
            });

            foreach (var tc in DbContext.TeamCompetitionSet.Local.Where(f => f.CompetitionId == Competition.Id && !f.IsPastWinner).OrderBy(f => f.Order))
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

            stage = DbContext.StageSet.Add(new Stage()
            {
                Competition = Competition,
                Type = StageType.Final,
                Name = "Финал"
            });

            foreach (var tc in DbContext.TeamCompetitionSet.Local.Where(f => f.CompetitionId == Competition.Id && f.IsPastWinner))
            {
                var game = DbContext.GameSet.Add(new Game()
                {
                    CompetitionId = Competition.Id,
                    Stage = stage,
                    Team = tc.Team,
                    Team1Missed = false,
                    Description = "Победители прошлого года",
                });
                refereees.ForEach(f => DbContext.GameResultSet.Add(new GameResult() { Game = game, Referee = f }));

                var score = DbContext.CompetitionScoreSet.Local.First(f => Competition == Competition && f.Team == tc.Team);
                score.Place = DbContext.TeamCompetitionSet.Local.Count;
                score.Score = 0;
                score.Description = "Заявка на участие";
            }

        }

        public override void EndStage(Stage stage)
        {
            EndStage3(stage);
        }

        public override double? GetGameScore(Game game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            if (values.Any(f => f.Value.Any(v => !v.Value.HasValue))) return null;
            return SumOtsechka(GameValueType.Time, values);
        }

      
    }
}
