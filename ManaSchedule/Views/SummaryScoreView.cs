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
using NPOI.HSSF.UserModel;
using System.IO;

namespace ManaSchedule.Views
{
    public partial class SummaryScoreView : ManaSchedule.Views.ContentView
    {
        DataTable _table = null;
        

        public SummaryScoreView()
        {
            InitializeComponent();
        }

        public override void OnClosing()
        {
           
        }

        public void Init()
        {
            //  DbContext.TeamSet.Load();
            //DbContext.CompetitionSet.Load();
            //DbContext.CompetitionScoreSet.Load();



            var teams = DbContext.TeamSet.ToList();
            var competitions = DbContext.CompetitionSet.ToList();
            var scores = DbContext.CompetitionScoreSet.ToList();


            _table = new DataTable();
            _table.Columns.Add("Команда", typeof(string));
            _table.Columns.Add("Место", typeof(int));
            _table.Columns.Add("Баллы", typeof(double));

            var data = new Dictionary<Competition,Tuple<DataColumn,DataColumn>>();

            foreach (var c in competitions)
            {
                data.Add(c,new Tuple<DataColumn, DataColumn>(
                _table.Columns.Add(c.Name + "- мeсто", typeof(double)),
                _table.Columns.Add(c.Name + "- баллы", typeof(double))));    
            }

            foreach (var team in teams)
            {
                var row = _table.NewRow();
                row["Команда"] = team.Name;
                double totalScore = 0;
                foreach (var c in competitions)
                {
                    double place = teams.Count;
                    var score = scores.FirstOrDefault(f => f.TeamId == team.Id && f.CompetitionId == c.Id);
                    if (score != null) place = score.Place;
                    double ball = place;

                    if (c.Type == GameType.TourRelay)
                    {
                        ball = place * 3;
                    }
                    else
                    {
                        ball = place * 2;
                    }
                    totalScore += ball;
                
                    row[data[c].Item1] = place;
                    row[data[c].Item2] = ball;  
                }
                row["Баллы"] = totalScore;
                _table.Rows.Add(row);
            }

            GridEX.DataSource = _table;
            GridEX.RetrieveStructure();

            foreach (var h in GridEX.RootTable.Columns.Cast<GridEXColumn>())
            {
                h.AutoSizeMode = ColumnAutoSizeMode.AllCellsAndHeader;
                h.AutoSize();
            }
        }

        private void btExportToExcel_Click(object sender, EventArgs e)
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
