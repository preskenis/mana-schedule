using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;
using Janus.Windows.GridEX;
using NPOI.HSSF.UserModel;
using System.IO;


namespace ManaSchedule.Views
{
    public partial class CompetitionSummaryView : CompetitionView
    {
        public CompetitionSummaryView()
        {
            InitializeComponent();

            DbContext.TeamSet.Load();
            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.NoEdit;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.ToList(), "Name");
   
        }

        public override void OnClosing()
        {
            
        }

        public override void Init(Competition content)
        {
            base.Init(content);
            ContentCaption.Text = content.Name + " - текущий итог";
            DbContext.CompetitionScoreSet.Where(f=>f.Competition.Id == Competition.Id).Load();
            GridEX.DataSource = DbContext.CompetitionScoreSet.Local.ToBindingList();
        }

        private void btRecalc_Click(object sender, EventArgs e)
        {
           

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            using (var fs = new SaveFileDialog() { Filter = "Excel (*.xls)|*.xls" })
            
                if (fs.ShowDialog(this) == DialogResult.OK)
                {
                    var workbook = new HSSFWorkbook();
                    Utils.ExportToExcel(GridEX, workbook, ContentCaption.Text);
                    using (var s = File.Create(fs.FileName))
                        workbook.Write(s);
                }
        }
        
    }
}
