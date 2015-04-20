using ManaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ManaSchedule.DataModels
{
    public class DbInitializer
   : DropCreateDatabaseIfModelChanges<Db>
    {
        protected override void Seed(Db context)
        {
            var comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Soccer, Name = "Футбол" });

            context.PlaceSet.Add(new Place() { Competition = comp, Name = "Футбольная площадка 1" });
            context.PlaceSet.Add(new Place() { Competition = comp, Name = "Футбольная площадка 2" });



          
        }
    }
}
