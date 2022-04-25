using System;
using System.Collections.Generic;

namespace Mana.Schedule.Core
{
    /// <summary>
    /// Тип игры
    /// </summary>
    public enum GameType
    {
        Football    = 1,
        Volleyball  = 2,
        Rugby       = 3,
        TravelRelay = 4,
        Cooks       = 5,

        ShowSong    = 6, 
        SoloSong    = 7
    }

    public class TimeInterval
    {
        /// <summary>
        /// дата начала 
        /// </summary>
        public DateTime TimeStart { get; private set; }

        /// <summary>
        /// дата окончания 
        /// </summary>
        public DateTime TimeEnd { get; private set; }

        public TimeInterval(DateTime timeStart,
                            DateTime timeEnd)
        {
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }
    }

    /// <summary>
    /// Игра
    /// </summary>
    public class Game
    {
        /// <summary>
        /// тип игры
        /// </summary>
        public GameType GameType { get; private set; }

        /// <summary>
        /// Список доступныз интервалов
        /// </summary>
        public List<TimeInterval> TimeIntervals { get; private set; }

        /// <summary>
        /// продолжительность одной игры в минутах
        /// </summary>
        public int GameDuration { get; private set; }

        /// <summary>
        /// количество площадок
        /// </summary>
        public int PlaygroundCnt { get; private set; }

        /// <summary>
        /// Количество команд на площадке
        /// </summary>
        public int TeamCntOnPlace { get; private set; }

        /// <summary>
        /// Конструктор - описывает этап игры
        /// </summary>
        /// <param name="gameType">Тип игры</param>
        /// <param name="timeStart">Время начала этапа</param>
        /// <param name="timeEnd">Время окончания этапа</param>
        /// <param name="playgroundCnt">Количество игровых площадок на этап</param>
        /// <param name="gameDuration">Продолжительность игры</param>
        /// <param name="teamCntOnPlace">Количество команд на площадке</param>
        public Game(GameType gameType, 
                    List<TimeInterval> timeIntervals,
                    int playgroundCnt, 
                    int gameDuration, 
                    int teamCntOnPlace)
        {
            GameType = gameType;
            TimeIntervals = timeIntervals;
            TeamCntOnPlace = teamCntOnPlace;
            GameDuration = gameDuration;
            PlaygroundCnt = playgroundCnt;
        }
    }

    /// <summary>
    /// Игры этапа
    /// </summary>
    public class GameMatch
    {
        public int GameNum { get; private set; }

        /// <summary>
        /// команды которые участвуют в игре 
        /// </summary>
        public IList<String> Teams { get; private set; }

        /// <summary>
        /// номер игровой площадки
        /// </summary>
        public int PlaygroundNum { get; private set; }

        /// <summary>
        /// Время начала игры
        /// </summary>
        public DateTime DateTimeStart { get; private set; }

        /// <summary>
        /// Время окончания игры
        /// </summary>
        public DateTime DateTimeEnd { get; private set; }


        /// <summary>
        /// Конструктор для одной игры этапа
        /// </summary>
        /// <param name="gameNum">порядковый номер игры используем в распределении</param>
        /// <param name="teams">Список команд участников</param>
        /// <param name="playgroundNum">Номер площадки</param>
        /// <param name="dateTimeStart">Дата и время начала этапа</param>
        /// <param name="dateTimeEnd">Дата и время окончания игры</param>
        public GameMatch(int gameNum,
                         IList<string> teams,
                         int playgroundNum,
                         DateTime dateTimeStart, 
                         DateTime dateTimeEnd)
        {
            GameNum = gameNum;
            Teams = teams;
            PlaygroundNum = playgroundNum;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
        }
    }
}
