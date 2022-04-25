using ManaSchedule.DataModels;
using ManaSchedule.Views;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ManaSchedule.Services
{
    public class CookGameService : GameService
    {
        public CookGameService()
        {
            StageScores = new Dictionary<StageType, Dictionary<GameValueType, StageScoreSettings>>() 
            {
            {
                StageType.Otbor, new Dictionary<GameValueType, StageScoreSettings>()
            {
                { GameValueType.Taste, new StageScoreSettings(0, 10) } ,
                { GameValueType.Visual, new StageScoreSettings(0, 7) } ,
                { GameValueType.CookShow, new StageScoreSettings(0, 3) } ,
                { GameValueType.CommandSupport, new StageScoreSettings(0, 1) } ,
                { GameValueType.NonUsedIngredients, new StageScoreSettings(-50, 0) } ,
                { GameValueType.UncleanTerritory, new StageScoreSettings(-2, 0) } ,
                { GameValueType.LongCook, new StageScoreSettings(-50, 0) } ,
                { GameValueType.FireBenzin, new StageScoreSettings(-1, 0) } ,
                { GameValueType.CookWithCooked, new StageScoreSettings(-1, 0) } ,
               { GameValueType.HelpOther, new StageScoreSettings(-1, 0) } ,
               { GameValueType.Prepatstvie, new StageScoreSettings(-1, 0) } ,
              
            }


            },

            {
                StageType.Final, new Dictionary<GameValueType, StageScoreSettings>()
            {
                { GameValueType.Taste, new StageScoreSettings(0, 10) } ,
                { GameValueType.CookIdea, new StageScoreSettings(0, 7) } ,
                { GameValueType.CookVisualShow, new StageScoreSettings(0, 7) } ,
                { GameValueType.Interactive, new StageScoreSettings(0, 3) } ,
               
              
            }


            }
            
            };

        }

        public override StageResultViewBase GetStageView(Stage stage)
        {
            if (stage.Type == StageType.Otbor)
                return new CookStageResultView() { GameService = this, Stage = stage };
            return base.GetStageView(stage);
        }


        public override List<GameValueType> GetValueTypes(Stage stage, CompetitionReferee referee)
        {
            switch (stage.Type)
            {
                case StageType.Otbor:
                    if (!referee.IsMainReferee)
                        return new List<GameValueType>() 
                    {
        GameValueType.Taste,
        GameValueType.Visual,
        GameValueType.CookShow,
                     };
                    else
                        return new List<GameValueType>() 
                    {
        GameValueType.CommandSupport,
        GameValueType.NonUsedIngredients,
        GameValueType.UncleanTerritory,
        GameValueType.LongCook,
        GameValueType.FireBenzin,
        GameValueType.CookWithCooked,
        GameValueType.HelpOther,
        GameValueType.Prepatstvie,
                     };
                case StageType.Final:
                    return new List<GameValueType>()
                        {
                             GameValueType.Taste,
                             GameValueType.CookIdea,
                              GameValueType.CookVisualShow,
                              GameValueType.Interactive,
                            
                        };
                default: throw new NotImplementedException();
            }
        }

        public override void EndStage(Stage stage)
        {
            EndStage2(stage);

        }

        public override double? GetGameScore(Game game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            if (values.Any(f => f.Value.Any(v => !v.Value.HasValue))) return null;

            switch (game.Stage.Type)
            {
                case StageType.Otbor:
                    return SumOtsechka(GameValueType.Taste, values)
               + SumOtsechka(GameValueType.Visual, values)
               + SumOtsechka(GameValueType.CookShow, values)
               + Sum(GameValueType.CommandSupport, values)
               + Sum(GameValueType.NonUsedIngredients, values)
               + Sum(GameValueType.UncleanTerritory, values)
               + Sum(GameValueType.LongCook, values)
               + Sum(GameValueType.FireBenzin, values)
               + Sum(GameValueType.CookWithCooked, values)
               + Sum(GameValueType.HelpOther, values)
               + Sum(GameValueType.Prepatstvie, values);
                case StageType.Final: return SumOtsechka(GameValueType.Taste, values)
               + SumOtsechka(GameValueType.CookIdea, values)
               + SumOtsechka(GameValueType.CookVisualShow, values)
               + SumOtsechka(GameValueType.Interactive, values);
                default: throw new NotSupportedException();
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
            var refereees = DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == Competition.Id).ToList();

            var stage = DbContext.StageSet.Add(new Stage()
            {
                Competition = Competition,
                Type = StageType.Otbor,
                Name = EnumHelper<StageType>.GetDisplayValue(StageType.Otbor),
            });

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




        }

      
        
    }
}
