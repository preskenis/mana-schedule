using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.DataModels
{
    public class StageScoreSettings
    {
        public StageScoreSettings()
        {
            ViewFormat = (f) => f.ToString();
            ReadFormat = (f) => int.Parse(f);
        }

        public StageScoreSettings(int min, int max) : this()
        {
            Min = min;
            Max = max;
        }


        public int Min { get; set; }
        public int Max { get; set; }

        public Func<int, string> ViewFormat { get; set; }
        public Func<string,int> ReadFormat { get; set; }
    }
}
