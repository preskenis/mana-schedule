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

            DbContext.TeamSet.Where(f=>f.Used).Load();
             

            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.NoEdit;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.Where(f=>f.Used).ToList(), "Name");

            GridEX.AllowEdit = btEdit.Checked.ToInheritableBoolean();
            GridEX.AllowDelete = btEdit.Checked.ToInheritableBoolean(); ;
            GridEX.AllowAddNew = btEdit.Checked.ToInheritableBoolean();
        }

        public override void OnClosing()
        {
            
        }

        public override void Init(Competition content)
        {
            base.Init(content);
            ContentCaption = string.Format("{0} - Текущий Итог", content.Name);
            var ids = DbContext.TeamSet.Local.Select(f => f.Id).ToList(); 
            DbContext.CompetitionScoreSet.Where(f => ids.Contains(f.TeamId) && f.CompetitionId == content.Id).Load();
            GridEX.DataSource = DbContext.CompetitionScoreSet.Local.ToBindingList();
        }

        private void btRecalc_Click(object sender, EventArgs e)
        {
           

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void btExport_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            using (var fs = new SaveFileDialog() { FileName = ContentCaption + ".xls", Filter = "Excel (*.xls)|*.xls" })

                if (fs.ShowDialog(this) == DialogResult.OK)
                {
                    var workbook = new HSSFWorkbook();
                    Utils.ExportToExcel(GridEX, workbook, ContentCaption);
                    using (var s = File.Create(fs.FileName))
                        workbook.Write(s);
                }
        }
        public override Janus.Windows.Ribbon.Ribbon RibbonControl
        {
            get
            {
                return ribbon1;
            }
        }

        private void btEdit_CheckedChanged(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            GridEX.AllowEdit = btEdit.Checked.ToInheritableBoolean();
            GridEX.AllowDelete = btEdit.Checked.ToInheritableBoolean(); ;
            GridEX.AllowAddNew = btEdit.Checked.ToInheritableBoolean();
        }
        
    }
}
