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
    
    public partial class StageGen
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Places { get; set; }
    
        public virtual Stage Stage { get; set; }
    }
}
