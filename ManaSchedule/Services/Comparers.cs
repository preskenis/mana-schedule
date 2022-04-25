using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManaSchedule.Services
{
   
    public class CompetitionComparer : System.Collections.IComparer
    {

        public int Compare(object x, object y)
        {
            if (x == y) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return (x as Competition).Name.CompareTo((y as Competition).Name);
        }
    }
}
