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
    public partial class ScheduleView : ManaSchedule.Views.ContentView
    {
      
        public ScheduleView()
        {
            InitializeComponent();
        }

        public override void OnClosing()
        {
           
        }

        public void Init()
        {
          
        }

        public override Janus.Windows.Ribbon.Ribbon RibbonControl
        {
            get
            {
                return ribbon1;
            }
        }

    }
}
