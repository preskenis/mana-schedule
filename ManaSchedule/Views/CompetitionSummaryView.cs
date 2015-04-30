using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;

namespace ManaSchedule.Views
{
    public partial class CompetitionSummaryView : CompetitionView
    {
        public CompetitionSummaryView()
        {
            InitializeComponent();
        }

        public override void OnClosing()
        { }

        public override void Init(Competition content)
        {
            base.Init(content);
            ContentCaption.Text = content.Name + " - текущий итог";

        }
        
    }
}
