using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace ManaSchedule.Views
{
    public partial class TeamView : ManaSchedule.Views.ContentView
    {
       
        public TeamView()
        {
            InitializeComponent();
           
        }

        public override void OnClosing()
        {
            DbContext.SaveChanges();
            
        }

        public override void Init(object content)
        {
            DbContext.TeamSet.Load();
            GridEX.DataSource = DbContext.TeamSet.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
