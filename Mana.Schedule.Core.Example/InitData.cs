using System;
using System.Collections.Generic;

namespace Mana.Schedule.Core.Example
{
    public static class InitData
    {
        /// <summary>
        /// инициализация списка команд
        /// </summary>
        /// <returns></returns>
        public static List<Team> SetCommands()
        { 
            return new List<Team> 
            {
                new Team("Азимут",                  18,     53,     35,     null,   null),
                new Team("Апилки",                  6,      63,     5,      null,   null),
                new Team("Баня",                    29,     64,     30,     null,   null),
                new Team("Бардак",                  2,      null,   7,      null,   null),
                new Team("Безопасный кекс",         36,     null,   1,      null,   null),
                new Team("Беларусь",                70,     null,   null,   null,   null),
                new Team("Бомболюк",                69,     14,     65,     null,   null),
                new Team("Бояне",                   68,     15,     31,     null,   null),
                new Team("Бух-Та",                  1,      null,   null,   null,   null),
                new Team("В дрова",                 45,     26,     67,     null,   null),
                new Team("Вумники",                 null,   null,   null,   null,   null),
                new Team("губы бабы Любы",          55,     null,   12,     null,   null),
                new Team("Держи Глаза",             null,   48,     61,     null,   null),
                new Team("Джа",                     61,     68,     58,     null,   null),
                new Team("Джем",                    21,     null,   8,      null,   null),
                new Team("Дикие Колобки",           27,     16,     27,     null,   null),
                new Team("Дубль W",                 28,     32,     null,   null,   null),
                new Team("Живой уголок",            54,     null,   null,   null,   null),
                new Team("ЗАО Гондурас",            7,      13,     null,   null,   null),
                new Team("Звездолет",               66,     12,     15,     null,   null),
                new Team("Зоопарк",                 24,     null,   9,      null,   null),
                new Team("Кайф",                    51,     null,   64,     null,   null),
                new Team("Клещи",                   null,   19,     null,   null,   null),
                new Team("Колхоз ДД",               50,     null,   49,     null,   null),
                new Team("Коротконосые буратины",   22,     null,   null,   null,   null),
                new Team("Корсары",                 20,     2,      11,     null,   null),
                new Team("Кряки",                   37,     null,   2,      null,   null),
                new Team("Куркули",                 23,     null,   null,   null,   null),
                new Team("Лапти",                   57,     65,     null,   null,   null),
                new Team("Легион",                  9,      null,   62,     null,   null),
                new Team("Лихо",                    43,     69,     59,     null,   null),
                new Team("Лупцовщики",              48,     61,     63,     null,   null),
                new Team("Лучшие друзья",           12,     55,     20,     null,   null),
                new Team("Людмила Петрова",         17,     null,   66,     null,   null),
                new Team("Мандраж",                 42,     17,     60,     null,   null),
                new Team("Мания",                   53,     23,     null,   null,   null),
                new Team("Манская мафия",           3,      62,     36,     null,   null),
                new Team("Манты",                   35,     47,     23,     null,   null),
                new Team("Мухоморы",                null,   null,   null,   null,   null),
                new Team("Намана",                  47,     null,   null,   null,   null),
                new Team("Негодяи",                 38,     null,   57,     null,   null),
                new Team("Недробя",                 59,     null,   null,   null,   null),
                new Team("Некстати",                19,     3,      28,     null,   null),
                new Team("Нечисть",                 65,     11,     32,     null,   null),
                new Team("Ноли",                    null,   null,   null,   null,   null),
                new Team("Ночные Гоблины",          null,   null,   null,   null,   null),
                new Team("Обманеные",               30,     null,   29,     null,   null),
                new Team("Опасная зона",            15,     null,   null,   null,   null),
                new Team("Пионеры Остапа Бендера",  46,     28,     18,     null,   null),
                new Team("Санта-Мана",              null,   null,   null,   null,   null),
                new Team("Сенаторы",                56,     null,   3,      null,   null),
                new Team("Сибирские зебры",         44,     31,     38,     null,   null),
                new Team("Сибирский горностай",     null,   1,      null,   null,   null),
                new Team("Синема",                  16,     null,   null,   null,   null),
                new Team("Синие Лебеди",            11,     18,     25,     null,   null),
                new Team("Сокол",                   null,   null,   39,     null,   null),
                new Team("Телевтузики",             60,     66,     56,     null,   null),
                new Team("ТрикоМАНА",               39,     22,     17,     null,   null),
                new Team("УжЕ",                     34,     25,     null,   null,   null),
                new Team("ФигВам",                  32,     null,   null,   null,   null),
                new Team("Хвосты",                  52,     null,   68,     null,   null),
                new Team("Хреновые спортсмены",     5,      24,     24,     null,   null),
                new Team("ЧЕ",                      40,     null,   null,   null,   null),
                new Team("Чегеварнутые строители",  10,     67,     10,     null,   null),
                new Team("Черемана",                58,     null,   null,   null,   null),
                new Team("Чума",                    31,     29,     26,     null,   null)
            };
        }

        /// <summary>
        /// Инициализация списка игр
        /// </summary>
        /// <returns></returns>
        public static List<Game> SetGame()
        {
            return new List<Game>
                {   
                    new Game(GameType.Cooks,        new List<TimeInterval> {new TimeInterval(new DateTime(2016, 5, 7, 16, 00, 00), new DateTime(2016, 5, 7, 20, 00, 00))}, 1, 120, 30),
                    new Game(GameType.Football,     new List<TimeInterval> {new TimeInterval(new DateTime(2016, 5, 7, 13, 00, 00), new DateTime(2016, 5, 7, 19, 00, 00))}, 2, 30,  2),
                    new Game(GameType.Volleyball,   new List<TimeInterval> {new TimeInterval(new DateTime(2016, 5, 7, 13, 00, 00), new DateTime(2016, 5, 7, 19, 00, 00))}, 2, 30,  2),
                    new Game(GameType.Rugby,        new List<TimeInterval> {new TimeInterval(new DateTime(2016, 5, 7, 13, 00, 00), new DateTime(2016, 5, 7, 19, 00, 00)),
                                                                            new TimeInterval(new DateTime(2016, 5, 8, 13, 00, 00), new DateTime(2016, 5, 8, 19, 00, 00))}, 1, 30, 2),
                    new Game(GameType.TravelRelay,  new List<TimeInterval> {new TimeInterval(new DateTime(2016, 5, 7, 13, 00, 00), new DateTime(2016, 5, 7, 19, 00, 00))}, 2, 15,  1)
                };
        }
    }
}
