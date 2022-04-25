using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule
{
    public static class Extensions
    {
        public static Janus.Windows.GridEX.InheritableBoolean ToInheritableBoolean (this bool value)
        {
            return value ? Janus.Windows.GridEX.InheritableBoolean.True : Janus.Windows.GridEX.InheritableBoolean.False;
        }

        public static void SetReadonly(this Janus.Windows.GridEX.GridEX grid, bool readOnly )
        {
            var value = (!readOnly).ToInheritableBoolean();
            grid.AllowAddNew = value;
            grid.AllowDelete = value;
            grid.AllowEdit = value;
        }


        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


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

        public static string EnsureDirectoryExist(string format, params object[] args)
        {
            var path = string.Format(format,args);
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            return path;
        }


        public static string Fmt(this string text, params object[] args)
        {
            return string.Format(text, args);
        }

        public static string Fmt(this string text, object arg1)
        {
            return string.Format(text, arg1);
        }

        public static string Fmt(this string text, object arg1, object arg2)
        {
            return string.Format(text, arg1, arg2);
        }

        public static string Fmt(this string text, object arg1, object arg2, object arg3)
        {
            return string.Format(text, arg1, arg2, arg3);
        }


    }
}