using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

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
            _table = new DataTable();
            _table.Columns.Add("Команда", typeof(string));
            _table.Columns.Add("Место", typeof(int));
            _table.Columns.Add("Баллы", typeof(double));
            foreach (var c in DbContext.CompetitionSet)
            {
                _table.Columns.Add(c.Name, typeof(int));
            }

            GridEX.DataSource = _table;
            GridEX.RetrieveStructure();
        }


    }
}
