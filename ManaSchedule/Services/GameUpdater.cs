using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.Services
{
    public class GameUpdater
    {
        public Db DbContext { get; private set; }

        public GameUpdater(Db db)
        {
            DbContext = db;
        }

        public void UpdateGame(Game game)
        {
            var nextGameTeam1 = DbContext.GameSet.Local.FirstOrDefault(f => f.ParentGame1 == game);
            var nextGameTeam2 = DbContext.GameSet.Local.FirstOrDefault(f => f.ParentGame2 == game);

            if (nextGameTeam1 == null && nextGameTeam2 == null)
            {
                DbContext.SaveChanges();
                return;
            }

            if (!game.Team1Missed.HasValue || !game.Team2Missed.HasValue)
            {
                DbContext.SaveChanges();
                return;
            }

            if (game.Team1Missed.Value && game.Team2Missed.Value)
            {
                if (nextGameTeam1 != null)
                {
                    nextGameTeam1.Team1Missed = true;
                    UpdateGame(nextGameTeam1);
                }
                if (nextGameTeam2 != null)
                {
                    nextGameTeam2.Team2Missed = true;
                    UpdateGame(nextGameTeam2);
                }
            }
            else if (game.Team1Win)
            {
                if (nextGameTeam1 != null)
                {
                    nextGameTeam1.Team = game.Team;
                    UpdateGame(nextGameTeam1);
                }

                if (nextGameTeam2 != null)
                {
                    nextGameTeam2.Team2 = game.Team;
                    UpdateGame(nextGameTeam2);
                }
            }
            else if (game.Team2Win)
            {
                if (nextGameTeam1 != null)
                {
                    nextGameTeam1.Team = game.Team2;
                    UpdateGame(nextGameTeam1);
                    return;
                }

                if (nextGameTeam2 != null)
                {
                    nextGameTeam2.Team2 = game.Team2;
                    UpdateGame(nextGameTeam2);
                    return;
                }
            }
            DbContext.SaveChanges();
        }
    }
}
