using ManaSchedule.DataModels;
using ManaSchedule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ManaSchedule.Services
{
    public class CarnivalGameService : GameService
    {
        public CarnivalGameService()
        {
            MinMaxValues = new Dictionary<StageType, Dictionary<GameValueType, Tuple<int, int>>>() 
            {
            {
                StageType.Final, new Dictionary<GameValueType, Tuple<int, int>>()
            {
               
                  {GameValueType.Flag, new Tuple<int, int>(0, 1) } ,
      
                   {GameValueType.OtkrTeamSuite, new Tuple<int, int>(0, 3) } ,
         {GameValueType.OtkrManSuite, new Tuple<int, int>(0, 5) } ,
         {GameValueType.OtkrFlag, new Tuple<int, int>(0, 2) } ,
         {GameValueType.OtkrNakl, new Tuple<int, int>(0, 3) } ,
        {GameValueType.OktrNastroi, new Tuple<int, int>(0, 3) } ,
         {GameValueType.ShowSuite, new Tuple<int, int>(0, 5) } ,
         {GameValueType.ShowZrel, new Tuple<int, int>(0, 5) } ,
         {GameValueType.ShowReact, new Tuple<int, int>(0, 3) } ,
         {GameValueType.ShowNastroi, new Tuple<int, int>(0, 3) } ,
        {GameValueType.CookSupport, new Tuple<int, int>(0, 2) } ,
         {GameValueType.CookNastroi, new Tuple<int, int>(0, 3) } ,
        {GameValueType.InKras, new Tuple<int, int>(0, 5) } ,
         {GameValueType.InZrel, new Tuple<int, int>(0, 5) } ,
         {GameValueType.InNastroi, new Tuple<int, int>(0, 3) } ,
         {GameValueType.Neadekvat, new Tuple<int, int>(-10, 0) } ,
         {GameValueType.Nenorm, new Tuple<int, int>(-10, 0) } ,
              
            }


            }

            };

        }


        public override List<GameValueType> GetValueTypes(Stage stage, CompetitionReferee referee)
        {
            switch (stage.Type)
            {
                case StageType.Final:
                    return new List<GameValueType>() 
                    {
           GameValueType.OtkrTeamSuite,
         GameValueType.OtkrManSuite,
         GameValueType.OtkrFlag,
         GameValueType.OtkrNakl,
        GameValueType.OktrNastroi,
         GameValueType.ShowSuite,
         GameValueType.ShowZrel,
         GameValueType.ShowReact,
         GameValueType.ShowNastroi,
        GameValueType.CookSupport,
         GameValueType.CookNastroi,
        GameValueType.InKras,
         GameValueType.InZrel,
         GameValueType.InNastroi,
         GameValueType.Neadekvat,
         GameValueType.Nenorm,
                    };

                default: throw new NotImplementedException();
            }

        }

        public override void GenerateGames()
        {
            ClearAll();
            var refereees = DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == Competition.Id).ToList();

            DbContext.Configuration.AutoDetectChangesEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;


            DbContext.TeamSet.Local.ToList().ForEach(f =>
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
                refereees.ForEach(f =>
                {
                    var gr = DbContext.GameResultSet.Add(new GameResult() { Game = game, Referee = f });
                    GetValueTypes(stage, f).ForEach(v => DbContext.GameResultValueSet.Local.Add(new GameResultValue()
                    {
                        GameResult = gr,
                        Type = v,
                        Value = 0
                    }));
                }
                   );

                var score = DbContext.CompetitionScoreSet.Local.First(f => Competition == Competition && f.Team == tc.Team);
                score.Place = DbContext.TeamCompetitionSet.Local.Count;
                score.Score = 0;
                score.Description = "Заявка на участие";
            };
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
                var score = GetGameScore(game).Value;
                scores.Add(new TeamScore() { Team = game.Team, Score = score });
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
                    s.Description = "Игра в финале, проверьте место";
                    s.Score = f.Score;
                });
            }

            DbContext.SaveChanges();
        }


        public override double? GetGameScore(Game game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            if (values.Any(f => f.Value.Any(v => !v.Value.HasValue))) return null;

            return SumOtsechka(GameValueType.OtkrTeamSuite, values)
         + SumOtsechka(GameValueType.OtkrManSuite, values)
         + SumOtsechka(GameValueType.OtkrFlag, values)
         + SumOtsechka(GameValueType.OtkrNakl, values)
        + SumOtsechka(GameValueType.OktrNastroi, values)
         + SumOtsechka(GameValueType.ShowSuite, values)
         + SumOtsechka(GameValueType.ShowZrel, values)
         + SumOtsechka(GameValueType.ShowReact, values)
         + SumOtsechka(GameValueType.ShowNastroi, values)
        + SumOtsechka(GameValueType.CookSupport, values)
         + SumOtsechka(GameValueType.CookNastroi, values)
        + SumOtsechka(GameValueType.InKras, values)
         + SumOtsechka(GameValueType.InZrel, values)
         + SumOtsechka(GameValueType.InNastroi, values)
         + Sum(GameValueType.Neadekvat, values)
         + Sum(GameValueType.Nenorm, values);
        }


    }
}
