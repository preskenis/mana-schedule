using System;
using System.Collections.Generic;
using System.Linq;

namespace Mana.Schedule.Core
{
    public static class Schedule
    {
        /// <summary>
        /// Список игр конкурса кашеваров
        /// </summary>
        public static List<GameMatch> CoockGameMatchs { get; private set; }

        /// <summary>
        /// Список игр конкурса Регби
        /// </summary>
        public static List<GameMatch> RugbyGameMatchs { get; private set; }

        /// <summary>
        /// Список игр конкурса футбол
        /// </summary>
        public static List<GameMatch> FootballGameMatchs { get; private set; }

        /// <summary>
        /// Список игр конкурса футбол
        /// </summary>
        public static List<GameMatch> VolleyballGameMatchs { get; private set; }

        /// <summary>
        /// Список игр конкурса ТурЭстафета
        /// </summary>
        public static List<GameMatch> TravelRelayGameMatchs { get; private set; }


        /// <summary>
        /// Проверим что команда свободна
        /// </summary>
        private static bool CheckTeamIsFree(string teamName, DateTime dateTimeStartGame)
        {
            if (CoockGameMatchs != null)
                if (
                    CoockGameMatchs.Exists(
                        t =>
                        t.Teams.Contains(teamName) && t.DateTimeStart <= dateTimeStartGame &&
                        t.DateTimeEnd > dateTimeStartGame))
                    return false;
            if (RugbyGameMatchs != null)
                if (
                    RugbyGameMatchs.Exists(
                        t =>
                        t.Teams.Contains(teamName) && t.DateTimeStart <= dateTimeStartGame &&
                        t.DateTimeEnd > dateTimeStartGame))
                    return false;
            if (FootballGameMatchs != null)
                if (
                    FootballGameMatchs.Exists(
                        t =>
                        t.Teams.Contains(teamName) && t.DateTimeStart <= dateTimeStartGame &&
                        t.DateTimeEnd > dateTimeStartGame))
                    return false;
            if (VolleyballGameMatchs != null)
                if (
                    VolleyballGameMatchs.Exists(
                        t =>
                        t.Teams.Contains(teamName) && t.DateTimeStart <= dateTimeStartGame &&
                        t.DateTimeEnd > dateTimeStartGame))
                    return false;
            if (TravelRelayGameMatchs != null)
                if (
                    TravelRelayGameMatchs.Exists(
                        t =>
                        t.Teams.Contains(teamName) && t.DateTimeStart <= dateTimeStartGame &&
                        t.DateTimeEnd > dateTimeStartGame))
                    return false;
            return true;
        }


        /// <summary>
        /// Распределить указанный конкурс
        /// </summary>
        private static List<GameMatch> MakeScheduleContest(Game game, IEnumerable<GameMatch> contestGameMatchsLst)
        {
            var contestGameMatchs = new List<GameMatch>();
            var gameCnt = game.TimeIntervals.Sum(timeInterval => (timeInterval.TimeEnd - timeInterval.TimeStart).TotalMinutes / game.GameDuration);

            // Проверим что все игры влазят в указанное время 
            if (gameCnt < contestGameMatchsLst.Count())
                throw new Exception("Егры не влазят в указанный интервал!");

            //распределим игры по свободному времени и площадкам
            foreach (var gameMatch in contestGameMatchsLst.OrderBy(t => t.GameNum))
            {
                foreach (var timeInterval in game.TimeIntervals)
                {
                    // идем по времени шаг - длительность игры
                    for (var timeStart = timeInterval.TimeStart;
                         timeStart < timeInterval.TimeEnd;
                         timeStart = timeStart.AddMinutes(game.GameDuration))
                    {
                        // проверяем площадка свободна или нет
                        int? placeNumFree = null;
                        for (var placeNum = 0; placeNum < game.PlaygroundCnt; placeNum++)
                        {
                            // площадка занята идем к следующеё площадке
                            if (
                                contestGameMatchs.Exists(
                                    t => t.PlaygroundNum == placeNum && t.DateTimeStart == timeStart))
                                continue;

                            // команда(ы) свободна
                            placeNumFree = placeNum;
                            foreach (
                                var teamName in
                                    gameMatch.Teams.Where(
                                        teamName => !CheckTeamIsFree(teamName, timeStart)))
                                placeNumFree = null;
                        }

                        //ставим игру
                        if (!placeNumFree.HasValue) continue;
                        contestGameMatchs.Add(new GameMatch(gameMatch.GameNum, gameMatch.Teams,
                                                            placeNumFree.Value, timeStart,
                                                            timeStart.AddMinutes(game.GameDuration)));
                        break;
                    }
                }
            }
            return contestGameMatchs;
        }

        /// <summary>
        /// Распределить конкурс КАШЕВАРОВ
        /// Распределяется равное количество команд на два этапа
        /// </summary>
        private static void MakeScheduleCooks(Game game, List<Team> teams)
        {
            CoockGameMatchs = new List<GameMatch>();
            DateTime nextGame;

            var gameCnt = game.TimeIntervals.Sum(timeInterval => (timeInterval.TimeEnd - timeInterval.TimeStart).TotalMinutes / game.GameDuration);

            // Проверим что все игры влазят в указанное время 
            if (gameCnt*game.TeamCntOnPlace < teams.Count(t => t.DrawResultsCoock != null))
                throw new Exception("Егры не влазят в указанный интервал!");

            int i = 0;
            // Создадим игры 
            foreach (var timeInterval in game.TimeIntervals)
            {
                nextGame = timeInterval.TimeStart;
                for (i = 0; i < gameCnt; i++)
                {
                    CoockGameMatchs.Add(new GameMatch(i + 1, (from t in teams
                                                              where t.DrawResultsCoock.HasValue
                                                              orderby t.DrawResultsCoock
                                                              select t.Name).Skip(Convert.ToInt32(game.TeamCntOnPlace)*i)
                                                                            .Take(Convert.ToInt32(game.TeamCntOnPlace))
                                                                            .ToList(),
                                                      game.PlaygroundCnt,
                                                      nextGame,
                                                      nextGame.AddMinutes(game.GameDuration)));
                    nextGame = nextGame.AddMinutes(game.GameDuration);
                }
            }
        }

        /// <summary>
        /// Распределить конкурс РЕГБИ
        /// </summary>
        private static void MakeScheduleRugby(Game game, IEnumerable<Team> teams)
        {
            string nameTeam1 = null;
            var gameNum = 0;

            //создадим игры которые дальше будем расставлять 
            var contestGameMatchsLst = new List<GameMatch>();
            foreach (var team in (from t in teams
                                  where t.DrawResultsRugby.HasValue
                                  orderby t.DrawResultsRugby
                                  select t.Name))
            {
                if (game.TeamCntOnPlace > 1)
                    if (String.IsNullOrEmpty(nameTeam1))
                    {
                        nameTeam1 = team;
                        continue;
                    }

                contestGameMatchsLst.Add(new GameMatch(gameNum++, new List<string> {nameTeam1, team}, 0,
                                                       DateTime.MinValue, DateTime.MinValue));
                nameTeam1 = null;
            }
            RugbyGameMatchs = MakeScheduleContest(game, contestGameMatchsLst);
        }

        /// <summary>
        /// Распределить конкурс ВОЛЕЙБОЛ
        /// </summary>
        private static void MakeScheduleVolleyball(Game game, IEnumerable<Team> teams)
        {
            string nameTeam1 = null;
            var gameNum = 0;

            //создадим игры которые дальше будем расставлять 
            var contestGameMatchsLst = new List<GameMatch>();
            foreach (var team in (from t in teams
                                  where t.DrawResultsVolleyball.HasValue
                                  orderby t.DrawResultsRugby
                                  select t.Name))
            {
                if (game.TeamCntOnPlace > 1)
                    if (String.IsNullOrEmpty(nameTeam1))
                    {
                        nameTeam1 = team;
                        continue;
                    }

                contestGameMatchsLst.Add(new GameMatch(gameNum++, new List<string> { nameTeam1, team }, 0,
                                                       DateTime.MinValue, DateTime.MinValue));
                nameTeam1 = null;
            }
            VolleyballGameMatchs = MakeScheduleContest(game, contestGameMatchsLst);
        }

        /// <summary>
        /// Распределить конкурс ФУТБОЛ
        /// </summary>
        private static void MakeScheduleFootball(Game game, IEnumerable<Team> teams)
        {
            string nameTeam1 = null;
            var gameNum = 0;

            //создадим игры которые дальше будем расставлять 
            var contestGameMatchsLst = new List<GameMatch>();
            foreach (var team in (from t in teams
                                  where t.DrawResultsFootball.HasValue
                                  orderby t.DrawResultsRugby
                                  select t.Name))
            {
                if (game.TeamCntOnPlace > 1)
                    if (String.IsNullOrEmpty(nameTeam1))
                    {
                        nameTeam1 = team;
                        continue;
                    }

                contestGameMatchsLst.Add(new GameMatch(gameNum++, new List<string> { nameTeam1, team }, 0,
                                                       DateTime.MinValue, DateTime.MinValue));
                nameTeam1 = null;
            }
            RugbyGameMatchs = MakeScheduleContest(game, contestGameMatchsLst);
        }

        /// <summary>
        /// Распределить указанный конкурс ТУРЭСТАФЕТУ
        /// </summary>
        private static void MakeScheduleTravelRelay(Game game, IEnumerable<Team> teams)
        {
            var gameNum = 0;
            //создадим игры 
            var contestGameMatchsLst = (from t in teams
                                        where t.DrawResultsTravelRelay.HasValue
                                        orderby t.DrawResultsTravelRelay
                                        select t.Name).Select(
                                            team =>
                                            new GameMatch(gameNum++, new List<string> {team}, 0, DateTime.MinValue,
                                                          DateTime.MinValue)).ToList();

            TravelRelayGameMatchs = MakeScheduleContest(game, contestGameMatchsLst);
        }


        /// <summary>
        /// Цикл распределения всех конкурсов
        /// </summary>
        /// <param name="games">Список игр этапа</param>
        /// <param name="teams">Список всех команд</param>
        public static void MakeSchedule(List<Game> games, List<Team> teams)
        {
            VolleyballGameMatchs = FootballGameMatchs = RugbyGameMatchs = TravelRelayGameMatchs = CoockGameMatchs = null;

            //-----------------------------------КАШЕВАРЫ
            if (games.Exists(g => g.GameType == GameType.Cooks))
                MakeScheduleCooks(games.Find(g => g.GameType == GameType.Cooks), teams);

            //----------------------------------- РЕГБИ
            if (games.Exists(g => g.GameType == GameType.Rugby))
                MakeScheduleRugby(games.Find(g => g.GameType == GameType.Rugby), teams);

            //----------------------------------- ВОЛЕЙБОЛ
            if (games.Exists(g => g.GameType == GameType.Rugby))
                MakeScheduleVolleyball(games.Find(g => g.GameType == GameType.Volleyball), teams);

            //----------------------------------- ФУТБОЛ
            if (games.Exists(g => g.GameType == GameType.Rugby))
                MakeScheduleFootball(games.Find(g => g.GameType == GameType.Football), teams);

            //----------------------------------- ТУРЭСТАФЕТА
            if (games.Exists(g => g.GameType == GameType.TravelRelay))
                MakeScheduleTravelRelay(games.Find(g => g.GameType == GameType.TravelRelay), teams);
        }
    }
}