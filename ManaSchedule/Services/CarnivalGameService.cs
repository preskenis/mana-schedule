using ManaSchedule.DataModels;
using ManaSchedule.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace ManaSchedule.Services
{
    public class CarnivalGameService : GameService
    {
        public static DataTable GetSportCarnivalTable(Game game, Db db)
        {
            var result = new DataTable();

            var gameResultSet = db.GameResultSet.FirstOrDefault(f => f.GameId == game.Id);
            var gameResultValues = gameResultSet.Values.ToList();


            result.Columns.Add("Параметр", typeof(string));
            result.Columns.Add("Оценка", typeof(int));

            foreach (var items in SportMinMaxValues)
            {
                var row = result.NewRow();
                row[0] = EnumHelper<GameValueType>.GetDisplayValue(items.Key);

                var value = gameResultValues.FirstOrDefault(f => f.Type == items.Key);
                if (value!= null)
                {
                    row[1] = value.Value;
                }
                result.Rows.Add(row);
            }


                

            return result;
        }

        public static HashSet<GameValueType> Team1CarnivalValues = new HashSet<GameValueType>() 
        {
        GameValueType.SportSuite1, 
        GameValueType.SportSongs1, 
        GameValueType.SportSupport1, 
        GameValueType.SportNeadekvat1 
        };

        public static HashSet<GameValueType> Team2CarnivalValues = new HashSet<GameValueType>() 
        {
        GameValueType.SportSuite2, 
        GameValueType.SportSongs2, 
        GameValueType.SportSupport2, 
        GameValueType.SportNeadekvat2 
        };


        public static Dictionary<GameValueType, StageScoreSettings> SportMinMaxValues = new Dictionary
            <GameValueType, StageScoreSettings>()
            {
                {GameValueType.SportSuite1, new StageScoreSettings(0, 1)},
                {GameValueType.SportSongs1, new StageScoreSettings(0, 2)},
                {GameValueType.SportSupport1, new StageScoreSettings(0, 1)},
                {GameValueType.SportNeadekvat1, new StageScoreSettings(-1, 0)},
                {GameValueType.SportSuite2, new StageScoreSettings(0, 1)},
                {GameValueType.SportSongs2, new StageScoreSettings(0, 2)},
                {GameValueType.SportSupport2, new StageScoreSettings(0, 1)},
                {GameValueType.SportNeadekvat2, new StageScoreSettings(-1, 0)},
            };


        public CarnivalGameService()
        {
            StageScores = new Dictionary<StageType, Dictionary<GameValueType, StageScoreSettings>>() 
            {
            {
                StageType.Final, new Dictionary<GameValueType, StageScoreSettings>()
            {
     
                // Блок 1: "Во время открытия Слета"
                { GameValueType.OtkrTeamSuite, new StageScoreSettings(0, 5) },      // Общекомандные костюмы (было до 3, стало до 5)
                { GameValueType.OtkrManSuite, new StageScoreSettings(0, 8) },       // Индивидуальные костюмы (было до 5, стало до 8)
                { GameValueType.OtkrFlag, new StageScoreSettings(0, 2) },           // Флаг или штандарт команды
                { GameValueType.OtkrNakl, new StageScoreSettings(0, 3) },           // Командные атрибуты
                { GameValueType.OtkrNastroi, new StageScoreSettings(0, 1) },        // Праздничный настрой
                
                // Блок 2: "Во время выступления на Конкурсе Шоу-песни или Открытии"
                // (оценивается одно из выступлений, критерии идентичны)
                
                // Выступление на Открытии
                { GameValueType.OtkrShowKras, new StageScoreSettings(0, 8) },       // Красочность выступления (было до 5, стало до 8)
                { GameValueType.OtkrShowZrel, new StageScoreSettings(0, 8) },       // Зрелищность выступления (было до 5, стало до 8)
                { GameValueType.OtkrShowReact, new StageScoreSettings(0, 3) },      // Реакция зрителей
                { GameValueType.OtkrShowNastroi, new StageScoreSettings(0, 1) },    // Праздничный настрой

                // Выступление на Шоу-песни
                { GameValueType.ShowKras, new StageScoreSettings(0, 8) },           // Красочность выступления (было до 5, стало до 8)
                { GameValueType.ShowZrel, new StageScoreSettings(0, 8) },           // Зрелищность выступления (было до 5, стало до 8)
                { GameValueType.ShowReact, new StageScoreSettings(0, 3) },          // Реакция зрителей
                { GameValueType.ShowNastroi, new StageScoreSettings(0, 1) },        // Праздничный настрой
                
               
                // Блок 3: "Во время проведения Манских прыжков в воду" (НОВЫЙ БЛОК)
                { GameValueType.WaterJumpCostumeOriginality, new StageScoreSettings(0, 5) }, // Оригинальность костюма
                { GameValueType.WaterJumpCostumeBeauty, new StageScoreSettings(0, 5) },      // Красочность костюма
                { GameValueType.WaterJumpShow, new StageScoreSettings(0, 5) },               // Зрелищность шоу
                { GameValueType.WaterJumpEffect, new StageScoreSettings(0, 3) },             // Эффектность прыжка
                { GameValueType.WaterJumpPenalty, new StageScoreSettings(-18, 0) },          // Штраф за неадекватное поведение и др.

                
                // Блок 4: "Народное голосование" (НОВЫЙ БЛОК)
                // Присуждаются фиксированные баллы: 6, 5 или 4. Диапазон 0-6 для валидации.
                { GameValueType.PeoplesChoiceAward, new StageScoreSettings(0, 100) },

                // Блок 5: "Во время проведения спортивных соревнований" (поддержка болельщиков)
                // Предполагается, что можно оценить до 2-х разных соревнований
                { GameValueType.SportSuite1, new StageScoreSettings(0, 1) },        // Костюмы
                { GameValueType.SportSongs1, new StageScoreSettings(0, 2) },        // Кричалки
                { GameValueType.SportSupport1, new StageScoreSettings(0, 1) },      // Активность
                { GameValueType.SportNeadekvat1, new StageScoreSettings(-2, 0) },   // Неадекватное состояние (штраф был -1, стал -2)

                { GameValueType.SportSuite2, new StageScoreSettings(0, 1) },
                { GameValueType.SportSongs2, new StageScoreSettings(0, 2) },
                { GameValueType.SportSupport2, new StageScoreSettings(0, 1) },
                { GameValueType.SportNeadekvat2, new StageScoreSettings(-2, 0) },

                {GameValueType.Neadekvat, new StageScoreSettings(-10, 0) } ,
                {GameValueType.Nenorm, new StageScoreSettings(-10, 0) } ,
                {GameValueType.Narush, new StageScoreSettings(-10, 0) } ,
            }
            }
            };

        }


        public override List<GameValueType> GetValueTypes(Stage stage, CompetitionReferee referee)
        {
            switch (stage.Type)
            {
                case StageType.Final:
                    if (referee.IsMainReferee)
                    {
                        return new List<GameValueType>()
                        {
                            // Блок 4: "Народное голосование" (НОВЫЙ БЛОК)
                            GameValueType.PeoplesChoiceAward,
                        };
                    }

                    return new List<GameValueType>()
                    {
                        // Блок 1: "Во время открытия Слета"
                        GameValueType.OtkrTeamSuite, // Общекомандные костюмы
                        GameValueType.OtkrManSuite, // Индивидуальные костюмы
                        GameValueType.OtkrFlag, // Флаг или штандарт команды
                        GameValueType.OtkrNakl, // Командные атрибуты
                        GameValueType.OtkrNastroi, // Праздничный настрой

                        // Блок 2: "Во время выступления на Конкурсе Шоу-песни или Открытии"

                        // Выступление на Открытии
                        GameValueType.OtkrShowKras, // Красочность выступления
                        GameValueType.OtkrShowZrel, // Зрелищность выступления
                        GameValueType.OtkrShowReact, // Реакция зрителей
                        GameValueType.OtkrShowNastroi, // Праздничный настрой

                        // Выступление на Шоу-песни
                        GameValueType.ShowKras, // Красочность выступления
                        GameValueType.ShowZrel, // Зрелищность выступления
                        GameValueType.ShowReact, // Реакция зрителей
                        GameValueType.ShowNastroi, // Праздничный настрой

                        // Блок 3: "Во время проведения Манских прыжков в воду" (НОВЫЙ БЛОК)
                        GameValueType.WaterJumpCostumeOriginality, // Оригинальность костюма
                        GameValueType.WaterJumpCostumeBeauty, // Красочность костюма
                        GameValueType.WaterJumpShow, // Зрелищность шоу
                        GameValueType.WaterJumpEffect, // Эффектность прыжка
                        GameValueType.WaterJumpPenalty, // Штраф за неадекватное поведение и др.

                        

                        //// Блок 5: "Во время проведения спортивных соревнований" (поддержка болельщиков)
                        //GameValueType.SportSuite1, // Костюмы
                        //GameValueType.SportSongs1, // Кричалки
                        //GameValueType.SportSupport1, // Активность
                        //GameValueType.SportNeadekvat1, // Неадекватное состояние

                        //GameValueType.SportSuite2,
                        //GameValueType.SportSongs2,
                        //GameValueType.SportSupport2,
                        //GameValueType.SportNeadekvat2,

                        // Общие штрафы
                        GameValueType.Neadekvat, // Откровенно неадекватное состояние
                        GameValueType.Nenorm, // Ненормативная лексика, грубость
                        GameValueType.Narush, // Нарушение общепринятых норм и правил
                    };

                default: throw new NotImplementedException();
            }

        }

        public override bool HasZhereb(Stage stage)
        {
           
                return true;
            
        }

        public override void GenerateGames()
        {
            ClearAll();
            var refereees = DbContext.CompetitionRefereeSet.Where(f => f.CompetitionId == Competition.Id).ToList();

            DbContext.Configuration.AutoDetectChangesEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;


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

            var peoplesAward = new Dictionary<int, int>() { };


            var scores = new List<TeamScore>();
            foreach (var game in stageGames.Where(f => f.Stage.Id == stage.Id && f.Team1Missed == false && f.Team1Cancel == false))
            {
                var log = new StringBuilder();
                var score = GetGameScore(game, log).Value;

                peoplesAward.Add(game.Team.Id,
                    GetGameResultValues(game).SelectMany(f => f.Value)
                        .Where(f => f.Key == GameValueType.PeoplesChoiceAward).Sum(f => f.Value ?? 0));

                scores.Add(new TeamScore() { Team = game.Team, Score = score, Description = log.ToString() });
            }

            var step = 1;
            foreach (var p in peoplesAward.GroupBy(f => f.Value).OrderByDescending(f => f.Key))
            {
                if (step > 3 || p.Key <= 0) break;

                foreach (var t in p)
                {
                    var score = scores.First(f => f.Team.Id == t.Key);
                    switch (step)
                    {
                        case 1:
                            score.Score += 6;
                            score.Description += "народ. голосование 1 место +6";
                            break;
                        case 2:
                            score.Score += 5;
                            score.Description += "народ. голосование 2 место +5";
                            break;
                        case 3:
                            score.Score += 4;
                            score.Description += "народ. голосование 3 место +4";
                            break;
                    }
                }
                step++;
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
                    s.Description = f.Description;
                    s.Score = f.Score;
                });
            }

            DbContext.SaveChanges();
        }



        public override double? GetGameScore(Game game, Dictionary<CompetitionReferee, Dictionary<GameValueType, int?>> values, StringBuilder log)
        {
            if (values.Any(f => f.Value.Any(v => !v.Value.HasValue))) return null;

            var vals = new Dictionary<string, double>();
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrShowKras), SumOtsechka(GameValueType.OtkrShowKras, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrShowZrel), SumOtsechka(GameValueType.OtkrShowZrel, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrShowReact), SumOtsechka(GameValueType.OtkrShowReact, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrShowNastroi), SumOtsechka(GameValueType.OtkrShowNastroi, values));


            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.ShowKras), SumOtsechka(GameValueType.ShowKras, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.ShowZrel), SumOtsechka(GameValueType.ShowZrel, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.ShowReact), SumOtsechka(GameValueType.ShowReact, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.ShowNastroi), SumOtsechka(GameValueType.ShowNastroi, values));


            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrTeamSuite), SumOtsechka(GameValueType.OtkrTeamSuite, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrManSuite), SumOtsechka(GameValueType.OtkrManSuite, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrFlag), SumOtsechka(GameValueType.OtkrFlag, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrNakl), SumOtsechka(GameValueType.OtkrNakl, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.OtkrNastroi), SumOtsechka(GameValueType.OtkrNastroi, values));


            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.WaterJumpCostumeOriginality), SumOtsechka(GameValueType.WaterJumpCostumeOriginality, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.WaterJumpCostumeBeauty), SumOtsechka(GameValueType.WaterJumpCostumeBeauty, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.WaterJumpShow), SumOtsechka(GameValueType.WaterJumpShow, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.WaterJumpEffect), SumOtsechka(GameValueType.WaterJumpEffect, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.WaterJumpPenalty), SumOtsechka(GameValueType.WaterJumpPenalty, values));

            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.Neadekvat), SumOtsechka(GameValueType.Neadekvat, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.Nenorm), SumOtsechka(GameValueType.Nenorm, values));
            vals.Add(EnumHelper<GameValueType>.GetDisplayValue(GameValueType.Narush), SumOtsechka(GameValueType.Narush, values));

            vals.Add("Футбол", GetSportCarnivalScore(GameType.Soccer, game.Team));
            vals.Add("Регби", GetSportCarnivalScore(GameType.Rugby, game.Team));
            vals.Add("Волейбол", GetSportCarnivalScore(GameType.Volleyball, game.Team));

            log.Append(string.Join("; ", vals.Select(f => string.Format("{0}:{1}", f.Key, f.Value))));


            var sumOtkr = SumOtsechka(GameValueType.OtkrShowKras, values)
                    + SumOtsechka(GameValueType.OtkrShowZrel, values)
                    + SumOtsechka(GameValueType.OtkrShowReact, values)
                    + SumOtsechka(GameValueType.OtkrShowNastroi, values);

            var sumShow = SumOtsechka(GameValueType.ShowKras, values)
                    + SumOtsechka(GameValueType.ShowZrel, values)
                    + SumOtsechka(GameValueType.ShowReact, values)
                    + SumOtsechka(GameValueType.ShowNastroi, values);

            var result = SumOtsechka(GameValueType.OtkrTeamSuite, values)
                + SumOtsechka(GameValueType.OtkrManSuite, values)
                + SumOtsechka(GameValueType.OtkrFlag, values)
                + SumOtsechka(GameValueType.OtkrNakl, values)
                + SumOtsechka(GameValueType.OtkrNastroi, values)

                + Math.Max(sumOtkr, sumShow)

                + Sum(GameValueType.Neadekvat, values)
                + Sum(GameValueType.Nenorm, values)
                + Sum(GameValueType.Narush, values);


            result += SumOtsechka(GameValueType.WaterJumpCostumeOriginality, values)
                      + SumOtsechka(GameValueType.WaterJumpCostumeBeauty, values)
                      + SumOtsechka(GameValueType.WaterJumpShow, values)
                      + SumOtsechka(GameValueType.WaterJumpEffect, values)
                      + SumOtsechka(GameValueType.WaterJumpPenalty, values);

            result += GetSportCarnivalScore(GameType.Soccer, game.Team);
            result += GetSportCarnivalScore(GameType.Rugby, game.Team);
            result += GetSportCarnivalScore(GameType.Volleyball, game.Team);



            return result;
        }

        private double GetSportCarnivalScore(GameType gameType, Team team)
        {
            var result = 0;

            if (team.Name == "Мандраж")
            {

            }

            var competition = DbContext.CompetitionSet.First(f => f.Type == gameType);
            var games = DbContext.GameSet.Where(f => f.CompetitionId == competition.Id
                && !f.Team1Cancel && f.Team1Missed == false
                && !f.Team2Cancel && f.Team2Missed == false).ToList().Where(f => f.Team == team || f.Team2 == team).ToList();



            if (games.Count == 0) return result;

            foreach (var game in games)
            {
                var values = game.GameResults.First().Values.ToList();

                if (team == game.Team)
                {
                    result += values.Where(f => Team1CarnivalValues.Contains(f.Type) && f.Value.HasValue).Sum(f => f.Value.Value);
                }

                if (team == game.Team2)
                {
                    result += values.Where(f => Team2CarnivalValues.Contains(f.Type) && f.Value.HasValue).Sum(f => f.Value.Value);
                }

            }

            return result / games.Count;
            
        }


    }
}
