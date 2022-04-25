using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;
using System.Data.Entity;
using Janus.Windows.GridEX;
using ManaSchedule.Services;
using System.IO;
using NPOI.HSSF.UserModel;

namespace ManaSchedule.Views
{
    public partial class GameResultView : CompetitionView
    {
        public GameResultView()
        {
            InitializeComponent();
        }

        private List<StageResultViewBase> _stageView = new List<StageResultViewBase>();

        public override void OnClosing()
        {
            _stageView.ForEach(f => f.OnClosing());
            base.OnClosing();
        }

        public StageResultViewBase SelectedStage
        {
            get
            {
                return stageTabs.SelectedTab.Controls[0] as StageResultViewBase;
            }
        }

        public override void Init(Competition content)
        {
            base.Init(content);
            ContentCaption = string.Format("{0} - Результаты Игр", Competition.Name); 
        
            foreach (var stage in DbContext.StageSet.Where(f => f.CompetitionId == Competition.Id))
            {

                stageTabs.TabPages.Add(
                     new Janus.Windows.UI.Tab.UITabPage(stage.Name)
                     {
                         Tag = stage
                     });

                var stageView = GameService.GetStageView(stage);
                
                stageTabs.TabPages.Cast<Janus.Windows.UI.Tab.UITabPage>().First(f => f.Tag == stage).Controls.Add(stageView);
                stageView.Dock = DockStyle.Fill;
                stageView.Init();
                _stageView.Add(stageView);
            }
        }

        public override Janus.Windows.Ribbon.Ribbon RibbonControl
        {
            get
            {
                return ribbon1;
            }
        }

        private void btExportToExcel_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            using (var fs = new SaveFileDialog() { FileName = SelectedStage.GameService.Competition.Name +"-" + SelectedStage.GetFileName() + ".xls", Filter = "Excel (*.xls)|*.xls" })


                if (fs.ShowDialog(this) == DialogResult.OK)
                {
                    var workbook = new HSSFWorkbook();

                    Utils.ExportToExcel(SelectedStage.GetDataTable(), workbook, string.Format("{0}", SelectedStage.Stage.Name));

                    //foreach (var sv in _stageView)
                    //{


                    //    //foreach (var dt in sv.Data)
                    //    //{
                    //    //    Utils.ExportToExcel(dt.Value, workbook, string.Format("{0} - {1}", sv.Stage.Name, dt.Key.SafeName));
                    //    //}
                    //}

                    using (var s = File.Create(fs.FileName))
                        workbook.Write(s);
                }
        }

        private void btShowNames_CheckedChanged(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            foreach (var sv in _stageView)
            {
                sv.ShowNames(btShowNames.Checked);
            }

        }

        private void btEndStage_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            if (CurrentStageView != null)
                CurrentStageView.FinishStage();
        }

        private void btRandom_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            if (CurrentStageView != null)
                CurrentStageView.SetRandomValues();
        }

        public StageResultViewBase CurrentStageView
        {
            get
            {
                try
                {
                    return stageTabs.SelectedTab.Controls[0] as StageResultViewBase;
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        private void btImportToExcel_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
//            if (CurrentStageView == null) return;

//            var referee = CurrentStageView.CurrentReferee.Tag as CompetitionReferee;
//            var grid = CurrentStageView.CurrentReferee.Controls.Find("gridReferee", false).First() as GridEX;
//            var dt = grid.DataSource as DataTable;
            
//            try
//            {




//                if (DialogResult.Yes != MessageBox.Show(this, string.Format(@"Импорт данных судьи {0} для этапа {1}?
//1. Файл должен содержать ТОЛЬКО один лист.
//2. Файл должен содержать ВСЕ команды которые учавствовали.
//3. Файл должен быть ЗАКРЫТ в Excel",
//                        CurrentStageView.CurrentReferee.Text,
//                        CurrentStageView.Stage.Name), "Импорт данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
//                    return;

//                using (
//                    var fs = new OpenFileDialog() {FileName = ContentCaption + ".xls", Filter = "Excel (*.xls)|*.xls"})

//                    if (fs.ShowDialog(this) == DialogResult.OK)
//                    {
//                        var workbook = new HSSFWorkbook(fs.OpenFile());
//                        if (workbook.NumberOfSheets != 1)
//                        {
//                            MessageBox.Show(this, string.Format("Книга содержит {0} листов", workbook.NumberOfSheets),
//                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                            return;
//                        }

//                        var teamIndexes = new Dictionary<string, List<Size>>();

//                        var sheet = workbook.GetSheetAt(0) as NPOI.HSSF.UserModel.HSSFSheet;


//                        foreach (
//                            var teamName in dt.Rows.OfType<DataRow>().Select(f => f[dt.Columns["Команда"]] as string))
//                        {
//                            foreach (var r in sheet)
//                            {
//                                var sheetRow = r as HSSFRow;
//                                foreach (var c in sheetRow)
//                                {
//                                    var sheetCell = c as HSSFCell;
//                                    if (string.IsNullOrEmpty(sheetCell.ToString())) continue;
//                                    if (string.Compare(sheetCell.ToString(), teamName, true) == 0)
//                                    {
//                                        if (teamIndexes.ContainsKey(teamName))
//                                            teamIndexes[teamName].Add(new Size(sheetCell.ColumnIndex, sheetCell.RowIndex));
//                                        else
//                                        {
//                                            teamIndexes.Add(teamName,
//                                                new List<Size>() {new Size(sheetCell.ColumnIndex, sheetCell.RowIndex)});
//                                        }

//                                    }



//                                }
//                            }
//                            if (!teamIndexes.ContainsKey(teamName))
//                                throw new Exception(string.Format("Не найдена команда {0}", teamName));
//                        }


//                        if (teamIndexes.Any(f => f.Value.Count > 1))
//                        {
//                            throw new Exception(
//                                string.Format("Названия следующих команд встречаются в таблице больше одного раза: {0}",
//                                    string.Join(", ", teamIndexes.Where(f => f.Value.Count > 1).Select(f => f.Key))));

//                        }

//                        foreach (
//                            var teamRow in dt.Rows.OfType<DataRow>())
//                        {
                            
//                            var teamName = teamRow[dt.Columns["Команда"]] as string;
//                            try
//                            {
//                                CurrentStageView.SkipRowChange = true;
//                                var point = teamIndexes[teamName][0];
//                                var rr = sheet.GetRow(point.Height);

//                                for (var i = 1; i < dt.Columns.Count; i++)
//                                {
//                                    var dataValue = rr.GetCell(point.Width + i);
//                                    if (dt.Columns[i].DataType == typeof(int))
//                                    {
//                                        teamRow[i] = int.Parse(dataValue.ToString());
//                                    }
//                                    else if (dt.Columns[i].DataType == typeof(string))
//                                    {
//                                        teamRow[i] = dataValue.ToString();
//                                    }
//                                    else if (dt.Columns[i].DataType == typeof(double))
//                                    {
//                                        teamRow[i] = double.Parse(dataValue.ToString());
//                                    }
//                                    else
//                                    {
//                                        throw new Exception("Unknown type {0}".Fmt(dt.Columns[i].DataType));
//                                    }
//                                }
//                                CurrentStageView.SkipRowChange = false;
//                                CurrentStageView.dt_RowChanged(this,
//                                    new DataRowChangeEventArgs(teamRow, DataRowAction.Change));
//                            }
//                            catch (Exception ex)
//                            {
//                                throw new Exception("Ошибка вставки данных команды {0} : {1}".Fmt(teamName, ex.Message));
//                            }
//                            finally
//                            {
//                                CurrentStageView.SkipRowChange = false;
//                            }

//                        }





//                        //foreach (var sv in _stageView)
//                        //{
//                        //    foreach (var dt in sv.Data)
//                        //    {
//                        //        Utils.ExportToExcel(dt.Value, workbook, string.Format("{0} - {1}", sv.Stage.Name, dt.Key.SafeName));
//                        //    }
//                        //}

//                        //using (var s = File.Create(fs.FileName))
//                        //    workbook.Write(s);
//                    }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(this, string.Format("Ошибка при импорте. {0}", ex.Message),
//                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                CurrentStageView.SkipRowChange = false;
//            }
          
        }
    }
}
