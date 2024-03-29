﻿using System;
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
    public partial class ZherebView : CompetitionView
    {
        public bool ShowPastWiners { get; set; }

        public ZherebView()
        {
            InitializeComponent();

            DbContext.TeamSet.Where(f=>f.Used).Load();
            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.Where(f => f.Used).ToList(), "Name");
            

        }

        public override void OnClosing()
        {

            var a = DbContext.ChangeTracker.Entries<TeamCompetition>();

            foreach (var g in a)
            {
                g.Entity.CompetitionId = Competition.Id;

            }


        }

        public bool IsCompetitionStarted { get; set; }

        public override void Init(Competition content)
        {
            base.Init(content);
            ContentCaption = Competition.Name + " - " + "Жеребьёвка"; 
            DbContext.TeamCompetitionSet.Where(f => f.CompetitionId == Competition.Id).Load();
            GridEX.DataSource = DbContext.TeamCompetitionSet.Local.ToBindingList();
            this.GridEX.RootTable.Columns["IsPastWinner"].Visible = ShowPastWiners;
            UpdateCompetition();

           
        }

        public BindingList<TeamCompetition> Data { get; set; }

     
        public void UpdateCompetition()
        {
            IsCompetitionStarted = DbContext.GameSet.Any(f => f.CompetitionId == Competition.Id);

            //var edit = IsCompetitionStarted ? InheritableBoolean.False : InheritableBoolean.True;
            var edit = InheritableBoolean.True;
            GridEX.AllowAddNew = edit;
            GridEX.AllowDelete = edit;
            GridEX.AllowEdit = edit;

            btLoadCompanies.Enabled = !IsCompetitionStarted;
            btGenerate.Enabled = !IsCompetitionStarted;
        }


        private void btLoadCompanies_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            var tc = DbContext.TeamCompetitionSet.Local.Where(f => f.Competition.Id == Competition.Id).Select(f => f.TeamId).ToList();

            foreach (var team in DbContext.TeamSet.Where(f=>f.Used).Where(f => !tc.Contains(f.Id)))
            {
                DbContext.TeamCompetitionSet.Add(new TeamCompetition()
                {
                    CompetitionId = Competition.Id,
                    TeamId = team.Id
                });
            }
        }

        private void btRandom_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            var r = new Random();
            var numbers = new List<int>();
            foreach (var tc in DbContext.TeamCompetitionSet.Local.Where(f => f.Competition.Id == Competition.Id))
            {
                tc.Order = null;
                if (!tc.IsPastWinner)
                {
                    var order = 1 + r.Next(100);
                    while (numbers.Contains(order = 1 + r.Next(100)))
                    { }
                    tc.Order = (short)order;
                    numbers.Add(order);
                }
            }
            GridEX.Refetch();
        }

        private void btGenerate_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show(this,"Уверены что хотите создать игры? Убедитесь, что количество судей правильное и жеребьевка вся забита.", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            GameService.GenerateGames();
            MessageBox.Show("Игры созданы");
            Init(Competition);
        }

        private void btClearAll_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Стереть все игры?", "Подтвердите", MessageBoxButtons.OKCancel ))
            {
                GameService.ClearAll();
                UpdateCompetition();
                Init(Competition);
            }
          
        }

        private void btExportToExcel_Click(object sender, EventArgs e)
        {
           
        }

        private void ZherebView_Load(object sender, EventArgs e)
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

        private void btImportExcel_Click(object sender, Janus.Windows.Ribbon.CommandEventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Стереть все игры?", "Подтвердите", MessageBoxButtons.OKCancel))
            {
                GameService.ClearAll();
                UpdateCompetition();
                Init(Competition);
            }
            else
                return;
         
            using (var form = new ZherebExcelImportForm(DbContext,Competition))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    Init(Competition);
                }
            }
        }
    }
}
