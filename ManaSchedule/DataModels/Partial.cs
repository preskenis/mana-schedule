using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace ManaSchedule.DataModels
{
    public partial class Db
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<TeamCompetition>(new TeamCompetitionMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Game>()
 .HasOptional<Game>(x => x.ParentGame1).WithMany();

            modelBuilder.Entity<Game>()
 .HasOptional<Game>(x => x.ParentGame2).WithMany();



        }
    }

    public class TeamCompetitionMap : EntityTypeConfiguration<TeamCompetition>
    {
        public TeamCompetitionMap()
        {

            //HasKey(f => f.TeamId);
            //HasKey(f => f.CompetitionId);
        }
    }

    
   




}
