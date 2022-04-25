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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

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
           
        }

        public void Init()
        {
            DbContext.TeamSet.Load();
            GridEX.DataSource = DbContext.TeamSet.Local.ToBindingList();
            GridEX.SetReadonly(!App.AdminMode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public override Janus.Windows.Ribbon.Ribbon RibbonControl
        {
            get
            {
                return ribbon1;
            }
        }

        private void btImport_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
             using (var fs = new OpenFileDialog() { Filter = "Excel (*.xl*)|*.xl*" })

                if (fs.ShowDialog(this) == DialogResult.OK)
                {
                    var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(fs.OpenFile());
                    var sheet = workbook.GetSheetAt(0);
                    var naimIndex = -1;
                    var cell = sheet.GetRow(0).Cells.Where(f=>f.CellType == NPOI.SS.UserModel.CellType.String).FirstOrDefault(f => f.StringCellValue.ToLower() == "наименование");

                    var names = new List<string>();
                    foreach (var r in sheet)
                    {
                        var row = r as IRow;
                        if (row == null || row.RowNum == 0 || row.GetCell(cell.ColumnIndex).CellType != CellType.String) continue;

                        names.Add(row.GetCell(cell.ColumnIndex).StringCellValue.Trim());
                    }
                    names = names.OrderBy(f => f).ToList();

                    foreach (var name in names.ToList())
                    {
                        var alt = name + ";";
                        if (DbContext.TeamSet.Local.Any(f => string.Compare(f.Name,name,true) == 0 || f.AlternativeNames.Contains(alt)))
                            names.Remove(name);
                    }

                    using (var form = new ExcelImportForm(DbContext,names))
                        form.ShowDialog();
                }

           
            
        }

        private void btImportAkkr_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            using (var fs = new OpenFileDialog() { Filter = "Excel (*.xl*)|*.xl*" })

                if (fs.ShowDialog(this) == DialogResult.OK)
                {
                    var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(fs.OpenFile());
                    var sheet = workbook.GetSheetAt(0);
                    var naimIndex = -1;
                    var cell = sheet.GetRow(0).Cells.Where(f=>f.CellType == NPOI.SS.UserModel.CellType.String).FirstOrDefault(f => f.StringCellValue.ToLower() == "наименование");

                    var names = new List<string>();
                    foreach (var r in sheet)
                    {
                        var row = r as IRow;
                        if (row == null || row.RowNum == 0 || row.GetCell(cell.ColumnIndex).CellType != CellType.String) continue;

                        names.Add(row.GetCell(cell.ColumnIndex).StringCellValue.Trim());
                    }
                    names = names.OrderBy(f => f).ToList();

                    DbContext.TeamSet.Local.ToList().ForEach(f => f.Used = false);

                    foreach (var name in names.ToList())
                    {
                        var alt = name + ";";
                        
                        if (DbContext.TeamSet.Local.Any(f => string.Compare(f.Name,name,true) == 0 || f.AlternativeNames.Contains(alt)))
                        {
                            DbContext.TeamSet.Local.First(f => string.Compare(f.Name, name, true) == 0 || f.AlternativeNames.Contains(alt)).Used = true;
                        }
                    }

                
                }

        }

        private void btExportNoZhereb_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            DbContext.TeamCompetitionSet.Load();
            DbContext.TeamSet.Load();

            var competitions = DbContext.CompetitionSet.ToList();

            var sb = new StringBuilder();

            foreach (var g in DbContext.TeamCompetitionSet.Where(f=>f.Team.Used).GroupBy(f=>f.Team).OrderBy(f=>f.Key.Name))
            {

                var teamComp = competitions.ToList();
                g.Select(f => f.Competition).ToList().ForEach(f => teamComp.Remove(f));
                teamComp.ForEach(f => sb.AppendLine(string.Format("{0}\t{1}", g.Key.Name, f.Name)));
            }

            var ss = sb.ToString();

        }
        
    }
}
