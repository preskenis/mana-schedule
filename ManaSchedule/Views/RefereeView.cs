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
    public partial class RefereeView : ManaSchedule.Views.ContentView
    {

        public RefereeView()
        {
            InitializeComponent();

            DbContext.PersonSet.Load();
            DbContext.CompetitionSet.Load();
            DbContext.CompetitionRefereeSet.Load();
          
            this.GridEX.RootTable.Columns["Person"].HasValueList = true;
            this.GridEX.RootTable.Columns["Person"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["Person"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Person"].ValueList.PopulateValueList(DbContext.PersonSet.Local.ToList(), "NameTeam");

            this.GridEX.RootTable.Columns["Competition"].HasValueList = true;
            this.GridEX.RootTable.Columns["Competition"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["Competition"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Competition"].ValueList.PopulateValueList(DbContext.CompetitionSet.Local.ToList(), "Name");
        }

        public override void OnClosing()
        {

        }

        public void Init()
        {
            GridEX.DataSource = DbContext.CompetitionRefereeSet.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
