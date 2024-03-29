﻿using Janus.Windows.GridEX;
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
using NPOI.HSSF.UserModel;
using System.IO;

namespace ManaSchedule.Views
{
    public partial class NextStageTeamsForm : Form
    {
        public NextStageTeamsForm()
        {
            InitializeComponent();
        }

        public NextStageTeamsForm(Db DbContext, List<TeamScore> items) : this()
        {
            DbContext.TeamSet.Where(f=>f.Used).Load();
            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.NoEdit;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.Where(f => f.Used).ToList(), "Name");

            GridEX.DataSource = items;
        }

        public List<TeamScore> SelectedTeams
        {
            get 
            {
                var result = new List<TeamScore>();

                if (GridEX.HasCheckedRows) result.AddRange(GridEX.GetCheckedRows().Select(f => f.DataRow as TeamScore));
                
                return result;
                
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (SelectedTeams.Count > 0) DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            using (var fs = new SaveFileDialog() { FileName = Text + ".xls", Filter = "Excel (*.xls)|*.xls" })

                if (fs.ShowDialog(this) == DialogResult.OK)
                {
                    var workbook = new HSSFWorkbook();
                    Utils.ExportToExcel(GridEX, workbook, Path.GetFileNameWithoutExtension(fs.FileName));
                    using (var s = File.Create(fs.FileName))
                        workbook.Write(s);
                }
        }
    }
}
