using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ManaSchedule.DataModels
{
    [DataContract]
    public class ScheduleTask
    {
        public string Name { get; set; }
        public int Score { get; set; } = 1;

        public int MinInterval { get; set; } = 15;

        public int MinIntervalScore { get; set; } = 2;

        public List<SchedulePlace> Places { get; set; }
        public List<int> Games { get; set; }

    }

    public class SchedulePlace
    {       
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int GamesParallel { get; set; } = 1;
        public int GameTime { get; set; }
    }
}
