using System;
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

        private List<StageResultView> _stageView = new List<StageResultView>();

        public override void OnClosing()
        {
            _stageView.ForEach(f => f.OnClosing());
            base.OnClosing();
        }

        public override void Init(Competition content)
        {
            base.Init(content);
            ContentCaption.Text = "Результаты" + " - " + Competition.Name;
        
            

            foreach (var stage in DbContext.StageSet.Where(f => f.CompetitionId == Competition.Id))
            {

                stageTabs.TabPages.Add(
                     new Janus.Windows.UI.Tab.UITabPage(stage.Name)
                     {
                         Tag = stage
                     });

                var stageView = new StageResultView() { GameService = GameService };
                stageTabs.TabPages.Cast<Janus.Windows.UI.Tab.UITabPage>().First(f => f.Tag == stage).Controls.Add(stageView);
                stageView.Dock = DockStyle.Fill;
                stageView.Init(stage);
                _stageView.Add(stageView);
            }
        }

        private void btExportToExcel_Click(object sender, EventArgs e)
        {
            using (var fs = new SaveFileDialog() { Filter = "Excel (*.xls)|*.xls" })

                if (fs.ShowDialog(this) == DialogResult.OK)
                {
                    var workbook = new HSSFWorkbook();
                    
                    foreach (var sv in _stageView)
                    {
                        foreach (var dt in sv.Data)
                        {
                            Utils.ExportToExcel(dt.Value, workbook, string.Format("{0} - {1}", sv.Name, dt.Key.SafeName));
                        }
                    }
                    
                    using (var s = File.Create(fs.FileName))
                        workbook.Write(s);
                }
        }
    }
}
