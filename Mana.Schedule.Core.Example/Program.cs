using System.Collections.Generic;

namespace Mana.Schedule.Core.Example
{
    public class Program
    {
        /*
         * 1. Настраиваем все команды: указываем наименован команды, номер по жребию (если команда не участвует в этапе то ей проставляется NULL) 
         * 2. Настраиваем конвкрсы: указываем время начала этапа, время окончания этапа, длительность одной игры, количество полей
         * 3. Вызываем метод распределения  Schedule.MakeSchedule(_game, _teams) 
         * 
         * Результат: после распределения мы получим список игр Schedule.********GameMatchs для каждой игры 
         *  каждый элемент списка описывает один матч: время начала, время окончания, команды участники, номер поля 
         */
        private static List<Team> _teams;
        private static List<Game> _game;

        static void Main()
        {
            _game = InitData.SetGame();
            _teams = InitData.SetCommands();

            Schedule.MakeSchedule(_game, _teams);
        }
    }
}
