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
            MinMaxValues = new Dictionary<StageType, Dictionary<GameValueType, Tuple<int, int>>>() 
            {
            {
                StageType.Otbor, new Dictionary<GameValueType, Tuple<int, int>>()
            {
                { GameValueType.Taste, new Tuple<int, int>(0, 10) } ,
                { GameValueType.Visual, new Tuple<int, int>(0, 7) } ,
                { GameValueType.CookShow, new Tuple<int, int>(0, 3) } ,
                { GameValueType.CommandSupport, new Tuple<int, int>(0, 1) } ,
                { GameValueType.NonUsedIngredients, new Tuple<int, int>(-50, 0) } ,
                { GameValueType.UncleanTerritory, new Tuple<int, int>(-2, 0) } ,
                { GameValueType.LongCook, new Tuple<int, int>(-50, 0) } ,
                { GameValueType.FireBenzin, new Tuple<int, int>(-1, 0) } ,
                { GameValueType.CookWithCooked, new Tuple<int, int>(-1, 0) } ,
               { GameValueType.HelpOther, new Tuple<int, int>(-1, 0) } ,
               { GameValueType.Prepatstvie, new Tuple<int, int>(-1, 0) } ,
              
            }


            },

            {
                StageType.Final, new Dictionary<GameValueType, Tuple<int, int>>()
            {
                { GameValueType.Taste, new Tuple<int, int>(0, 10) } ,
                { GameValueType.CookIdea, new Tuple<int, int>(0, 7) } ,
                { GameValueType.CookVisualShow, new Tuple<int, int>(0, 7) } ,
                { GameValueType.Interactive, new Tuple<int, int>(0, 2) } ,
               
              
            }


            }
            
            };

        }


        public override List<GameValueType> GetValueTypes(Stage stage, CompetitionReferee referee)
        {
            switch (stage.Type)
            {
                case StageType.Otbor:
                    return new List<GameValueType>() 
                    {
        GameValueType.Taste,
        GameValueType.Visual,
        GameValueType.CookShow,
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
               + SumOtsechka(GameValueType.CommandSupport, values)
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

            DbContext.TeamSet.Local.ToList().ForEach(f => {
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
