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
using Janus.Windows.GridEX;


namespace ManaSchedule.Views
{
    public partial class PersonView : ManaSchedule.Views.ContentView
    {
     
        public PersonView()
        {
            InitializeComponent();
        
            DbContext.TeamSet.Load();
            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.ToList(), "Name");
        }

        public override void OnClosing()
        {
           
        }

        public void Init()
        {
            DbContext.PersonSet.Load();
            GridEX.DataSource = DbContext.PersonSet.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
