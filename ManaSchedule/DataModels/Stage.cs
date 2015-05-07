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
    
    public partial class Stage
    {
        public Stage()
        {
            this.Name = "";
            this.Description = "";
            this.PlacesCount = 1;
            this.GameTime = 15;
            this.Game = new HashSet<Game>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompetitionId { get; set; }
        public ManaSchedule.DataModels.StageType Type { get; set; }
        public int PlacesCount { get; set; }
        public int GameTime { get; set; }
        public Nullable<System.DateTime> From { get; set; }
        public Nullable<System.DateTime> To { get; set; }
    
        public virtual Competition Competition { get; set; }
        public virtual Stage ParentStage { get; set; }
        public virtual ICollection<Game> Game { get; set; }
    }
}
