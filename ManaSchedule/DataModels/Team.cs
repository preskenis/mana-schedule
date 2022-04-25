//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManaSchedule.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public Team()
        {
            this.Name = "";
            this.Description = "";
            this.Used = true;
            this.AlternativeNames = "";
            this.Person = new HashSet<Person>();
            this.Competitions = new HashSet<TeamCompetition>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Used { get; set; }
        public string AlternativeNames { get; set; }
    
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<TeamCompetition> Competitions { get; set; }
    }
}
