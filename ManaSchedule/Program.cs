﻿using ManaSchedule.DataModels;
using ManaSchedule.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ManaSchedule.Services;

namespace ManaSchedule
{
    static class Program
    {
        private static SplashForm _splash = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                var a = ExcelService.GetTableFromClipboard();


              //  File.Delete(@"h:\Mana\mana-schedule\mana-schedule\ManaSchedule\bin\Debug\mana.sdf");
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

                //using (var s = new TestForm())
                //{
                    
                //    s.ShowDialog();
                //}


                    _splash = new SplashForm();
            _splash.Show();
            App.LogSplash = new Action<string>((f) => 
            {
                try
                {
                    if (_splash == null) return;
                    if (_splash.LogLabel.InvokeRequired)
                    {
                        _splash.LogLabel.Invoke(new MethodInvoker(() => { _splash.LogLabel.Text = f; }));
                    }
                    else _splash.LogLabel.Text = f;
                }
                catch (Exception)
                {
                }
            });
            App.Init();
            
            App.AdminMode = false;

            Application.Idle += Application_Idle;
            Application.Run(App.MainForm);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        
        }

        static void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= Application_Idle;
            System.Threading.Thread.Sleep(1000);
            _splash.Dispose();
            _splash = null;
        }





      
    }
}
