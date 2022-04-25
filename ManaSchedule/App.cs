using ManaSchedule.DataModels;
using ManaSchedule.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace ManaSchedule
{
    public static class App
    {
        public static void Init()
        {
            if (File.Exists("mana.sdf"))
            {
                try 
	            {	        
                    File.Copy("mana.sdf", string.Format(@"{0}\mana_{1:yyyyMMddHHmmss}.sdf", App.DbBackupPath,DateTime.Now));
                }
	catch (Exception)
                {
		
		
	}
            }  

            Database.SetInitializer<Db>(new DbInitializer());


            //var db = new Db();
            //var teams = db.TeamSet.Where(f => f.Used).ToList();

            //foreach (var c in db.CompetitionScoreSet.Where(f=>f.Place >= teams.Count))
            //{
            //    switch ((int)c.Place)
            //    {
            //        case 70:
            //            break;
            //        case 71:
            //            break;
            //        case 72:
            //            break;
            //        case 73:
            //            c.Place = teams.Count;
            //            break;
            //        case 74:
            //            c.Place = teams.Count + 1;
            //            break;
            //        default:
            //            break;

            //    }

            //}

            //db.SaveChanges();


            MainForm = new Views.MainForm();
           
           
        }

       


        public static Views.MainForm MainForm { get; set; }

        public static Action<string> LogSplash { get; set; }
        


        public static bool AdminMode { get; set; }

        public static string HelpPath { get { return Extensions.EnsureDirectoryExist(@"{0}\Help", Path.GetDirectoryName(typeof(App).Assembly.Location)); } }

        public static string DbBackupPath { get { return Extensions.EnsureDirectoryExist(@"{0}\DbBackup", Path.GetDirectoryName(typeof(App).Assembly.Location)); } }

    }
}
