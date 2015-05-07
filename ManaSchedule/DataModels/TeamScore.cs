using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.DataModels
{
    public class TeamScore
    {
        public Team Team { get; set; }
        public double Place { get; set; }
        public double Score { get; set; }
        public string Description { get; set; }

    }
}
