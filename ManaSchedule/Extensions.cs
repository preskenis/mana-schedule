using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule
{
    public static class Extensions
    {
        public static List<Team> GameTeams(this Game game)
        {
            var result = new List<Team>();
            if (game.Team != null) result.Add(game.Team);
            if (game.Team2 != null) result.Add(game.Team2);
            return result;
        }

        public static string Game1Name(this Game game)
        {
            if (game.Team != null) return game.Team.Name;
            return string.Empty;
        }
        public static string Game2Name(this Game game)
        {
            if (game.Team2 != null) return game.Team2.Name;
            return string.Empty;
        }

        public static GameState GetState(this Game game)
        {
            if (game.Team1Missed == true && game.Team2Missed == true) return GameState.AllMissed;
            if (!game.Team1Missed.HasValue && !game.Team2Missed.HasValue && game.Team == null && game.Team2 == null) return GameState.NoData;
            if (game.Team == null && game.Team2 == null) return GameState.NoData;
            if (!game.Team1Win && !game.Team2Win) return GameState.WaitingEnd;
            if (game.Team1Missed == true) return GameState.Team1Missed;
            if (game.Team2Missed == true) return GameState.Team2Missed;
            return GameState.Finished;
           
        }
    }
}
