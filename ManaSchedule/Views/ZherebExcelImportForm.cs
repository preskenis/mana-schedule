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
using System.Data.Entity.ModelConfiguration.Configuration;
using NPOI.SS.UserModel;
using ManaSchedule.Services;

namespace ManaSchedule.Views
{

   

    public partial class ZherebExcelImportForm : Form
    {
        

        public ZherebExcelImportForm()
        {
            InitializeComponent();
        }

        private Db DbContext;
        private Competition Competition;

        public ZherebExcelImportForm(Db dbContext, Competition competition)
            : this()
        {
            try
            {
                DbContext = dbContext;
                Competition = competition;

                this.Text += $" {Competition.Name}";

                DbContext.TeamSet.Load();
                this.GridEX.RootTable.Columns["Team"].HasValueList = true;
                this.GridEX.RootTable.Columns["Team"].EditType = EditType.Combo;
                this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
                this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.OrderBy(f => f.Name).ToList(), "Name");

                using (var fs = new OpenFileDialog() { Filter = "Excel (*.xl*)|*.xl*" })

                    if (fs.ShowDialog(this) == DialogResult.OK)
                    {
                        var workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(fs.OpenFile());
                        var sheet = workbook.GetSheetAt(0);
                        var nameIndex = ExcelService.GetNameColumnIndex(sheet);

                        if (nameIndex < 0)
                        {
                            MessageBox.Show("Не могу найти столбец команд");
                            return;
                        }


                        ICell zherCell = null;
                        foreach (var c in sheet.GetRow(0).Cells.Where(f => 
                                     f.CellType == CellType.String && 
                                     !string.IsNullOrEmpty(f.StringCellValue))
                                     .OrderBy(f=>Math.Abs(string.Compare(PrepareCell(Competition.Name), PrepareCell(f.StringCellValue), StringComparison.InvariantCultureIgnoreCase))))

                           // Math.Abs(string.Compare(Competition.Name.Substring(0,2), f.StringCellValue.Substring(0,2), StringComparison.InvariantCultureIgnoreCase))
                                 
                        {
                            switch (
                                MessageBox.Show(this, string.Format($"Колонка '{c.StringCellValue}' это номер жеребьевки для '{Competition.Name}'?" ), "выберите колонку", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                            {
                                case System.Windows.Forms.DialogResult.Yes:
                                    zherCell = c;

                                    break;

                                case System.Windows.Forms.DialogResult.Cancel:
                                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                    return;
                                    break;

                            }
                            if (zherCell != null) break;
                        }

                        if (zherCell == null)
                        {
                            DialogResult = System.Windows.Forms.DialogResult.Cancel;
                            return;
                        }



                        var names = new List<string>();

                        var data = new BindingList<ImportItem>();

                        foreach (var r in sheet)
                        {
                            var row = r as IRow;
                            if (row == null || row.RowNum == 0 || row.GetCell(nameIndex) == null || row.GetCell(nameIndex).CellType != CellType.String) continue;

                            var name = row.GetCell(nameIndex).StringCellValue.Trim();

                            if (string.IsNullOrEmpty(name)) continue;

                            var alt = name + ";";

                            var team = DbContext.TeamSet.Local.FirstOrDefault(f => string.Compare(f.Name, name, true) == 0 || f.AlternativeNames.Contains(alt));

                            if (team == null)
                            {
                                MessageBox.Show(this, $"Файл содержит неизвестные команду '{name}'! Импорта не будет.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                return;
                            }

                            if (!team.Used)
                            {
                                MessageBox.Show(this, $"Файл содержит команду '{name}' без аккредитации! Импорта не будет.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                return;
                            }

                            var number = row.GetCell(zherCell.ColumnIndex) != null ? row.GetCell(zherCell.ColumnIndex).ToString().Trim() : "";

                            var item = new ImportItem() { Team = team, Number = number };
                           
                            if (item.Number.Contains("1/8") || item.Number.Contains(@"1\8"))
                            {
                                item.Number = "";
                                item.IsPastWinner = true;
                            }

                            if (!string.IsNullOrEmpty(item.Number) && !int.TryParse(item.Number, out var number1))
                            {
                                MessageBox.Show(this, $"Неправильный номер жеребьевки у команды {item.Team.Name}: '{item.Number}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                return;
                            }
                           

                            data.Add(item);

                        }

                        GridEX.DataSource = data;

                    }
                    else
                        DialogResult = System.Windows.Forms.DialogResult.Cancel;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ошибка при импорте жеребьевки " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.Abort;
            }
          
        }

        private string PrepareCell(string text)
        {
            var items = text.Split(new string[] { ".", " ", "-" }, StringSplitOptions.RemoveEmptyEntries);

            var delete = new string[] { "конкурс", "песня"};

            items = items.Where(f => !delete.Contains(f, StringComparer.InvariantCultureIgnoreCase)).ToArray();

            return string.Join(" ", items);

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            (GridEX.DataSource as IList<ImportItem>).ToList().ForEach(f => f.Number = f.Number.Trim());
            int i;
            if ((GridEX.DataSource as IList<ImportItem>).Where(f => !string.IsNullOrEmpty(f.Number)).Any(f => !int.TryParse(f.Number, out i)))
            {
                MessageBox.Show(this, "Проверьте номера жеребьевок.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DbContext.TeamCompetitionSet.RemoveRange(DbContext.TeamCompetitionSet.Local.Where(f => f.CompetitionId == Competition.Id));

            foreach (var item in (GridEX.DataSource as IList<ImportItem>))
            {
                if (string.IsNullOrEmpty(item.Number.Trim()))
                {
                    if (!item.IsPastWinner) continue;
                    DbContext.TeamCompetitionSet.Add(new TeamCompetition()
            {
                CompetitionId = Competition.Id,
                TeamId = item.Team.Id,
                IsPastWinner = true,
                PastWinnerPlace = item.PastWinnerPlace
            });

                }
                else
                {
                    DbContext.TeamCompetitionSet.Add(new TeamCompetition()
                    {
                        CompetitionId = Competition.Id,
                        TeamId = item.Team.Id,
                        Order = short.Parse(item.Number.Trim())
                    });
                }

            }

            DbContext.SaveChanges();
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void GridEX_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void GridEX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(string.Join(Environment.NewLine, GridEX.SelectedItems.Cast<GridEXSelectedItem>().Select(f => (f.GetRow().DataRow as ImportItem).Team.Name)));
 
            
            }
        }

    }
}
