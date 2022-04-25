using Janus.Windows.GridEX;
using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;

namespace ManaSchedule.Views
{
    public partial class ExcelImportForm : Form
    {
        public class ImportItem
        {
            public bool New { get; set; }
            public string  Name { get; set; }
            public Team Team { get; set; }
          
            

        }

        public ExcelImportForm()
        {
            InitializeComponent();
        }

        private Db DbContext;
        public ExcelImportForm(Db dbContext, List<string> names)
            : this()
        {
            DbContext = dbContext;

            DbContext.TeamSet.Where(f=>f.Used).Load();
            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.OrderBy(f=>f.Name).ToList(), "Name");
            
            
            GridEX.DataSource = new BindingList<ImportItem>(names.Select(f => new ImportItem() { New = false, Name = f}).ToList());


        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            foreach(var item in (GridEX.DataSource as IList<ImportItem>))
            {
                if (item.New)
                {
                    DbContext.TeamSet.Add(new Team() { Name = item.Name });
                }
                else if (item.Team != null)
                {
                    DbContext.TeamSet.First(f => f.Id == item.Team.Id).AlternativeNames += item.Name + ";";
                }


            }
            DbContext.SaveChanges();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
