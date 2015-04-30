using ManaSchedule.DataModels;
using ManaSchedule.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ManaSchedule
{
    public static class App
    {
        public static void Init()
        {
            Database.SetInitializer<Db>(new DbInitializer());
            using (var db = new Db())
            {
                db.TeamSet.ToList();
            }
            MainForm = new Views.MainForm();
        }

        public static Views.MainForm MainForm { get; set; }

        public static Action<string> LogSplash { get; set; }

        
    }
}
