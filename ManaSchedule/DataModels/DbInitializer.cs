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
            foreach (var team in Properties.Resources.Teams.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                context.TeamSet.Add(new Team() { Name = team });
            }

            var comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Soccer, Name = "Футбол" });

            context.PlaceSet.Add(new Place() { Competition = comp, Name = "Футбольная площадка 1" });
            context.PlaceSet.Add(new Place() { Competition = comp, Name = "Футбольная площадка 2" });


            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Volleyball, Name = "Волейбол" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Rugby, Name = "Рэгби" });

            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.TourRelay, Name = "Тур-Эстафета" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.ShowSong, Name = "Шоу-Песня" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.SoloSong, Name = "Соло-песня" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Lager, Name = "Конкурс лагерей" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Carnival, Name = "Конкурс карнавальности" });
            comp = context.CompetitionSet.Add(new Competition() { Type = GameType.Cook, Name = "Конкурс кашеваров" });


        }
    }
}
