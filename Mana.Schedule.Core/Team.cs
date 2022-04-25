using System;

namespace Mana.Schedule.Core
{
    public class Team 
    {
        public string Name { get; private set; }

        public int? DrawResultsCoock { get; private set; }
        public int? DrawResultsFootball { get; private set; }
        public int? DrawResultsVolleyball { get; private set; }
        public int? DrawResultsRugby { get; private set; }
        public int? DrawResultsTravelRelay { get; private set; }

        /// <summary>
        /// Конструктор команды
        /// </summary>
        /// <param name="name">Наименование команды</param>
        /// <param name="drawResultsCoock">Жребий по кашеварам</param>
        /// <param name="drawResultsRugby">Жребий по регби</param>
        /// <param name="drawResultsTravelRelay">Жребий по турэстафете</param>
        /// <param name="drawResultsFootball">Жребий по футболу</param>
        /// <param name="drawResultsVolleyball">Жребий по волейболу</param>
        public Team(string name,
                    int? drawResultsCoock,
                    int? drawResultsRugby,
                    int? drawResultsTravelRelay,
                    int? drawResultsFootball,
                    int? drawResultsVolleyball)
        {
            Name = name;
            DrawResultsCoock = drawResultsCoock;
            DrawResultsRugby = drawResultsRugby;
            DrawResultsTravelRelay = drawResultsTravelRelay;
            DrawResultsFootball = drawResultsFootball;
            DrawResultsVolleyball = drawResultsVolleyball;
        }
    }
}
