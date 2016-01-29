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

    public partial class Person
    {
        public string NameTeam
        {
            get {
                if (Team != null)
                    return string.Format("{0} - {1}", Team.Name, Name);
                return Name;
            }
        }
    }

    public partial class  CompetitionReferee

    {
        public string SafeName
        {
            get {
                return Person == null ? Name : Person.Name;
               
            }
        }
    }


    public partial class Game
    {
        public Team Winner
        {
            get
            {
                if (Team1Win) return Team;
                if (Team2Win) return Team2;
                return null;
            }
        }
        public Team Looser
        {
            get
            {
                if (Team1Win) return Team2Missed == false ? Team2 : null;
                if (Team2Win) return Team1Missed == false ? Team : null;
                return null;
            }
        }

        public List<Team> AllTeams()
        {
                    var result = new List<Team>();
                    if (Team != null) result.Add(Team);
                    if (Team2 != null) result.Add(Team2);
                    return result;
        
        }




        public bool IsMissing
        {
            get { return Team1Missed == true && Team2Missed == true; }
        }


        public string Name2
        {
            get
            {
                return string.Format("{0} - {1}", Team != null ? Team.Name : "[-]", Team2 != null ? Team2.Name : "[-]");
            }
        }
    }



}
