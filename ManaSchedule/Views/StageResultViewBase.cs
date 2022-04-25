using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;
using ManaSchedule.Services;

namespace ManaSchedule.Views
{
    public partial class StageResultViewBase : UserControl
    {
        public StageResultViewBase()
        {
            InitializeComponent();
        }

        public Stage Stage { get; set; }

        public GameService GameService { get; set; }

        public virtual void Init() { }

        public virtual void OnClosing() { }

        public virtual void FinishStage() { }

        public virtual void ShowNames(bool showNames)
        {
            
        }

        internal virtual Janus.Windows.GridEX.GridEX GetDataTable()
        {
            throw new NotImplementedException();
        }

        internal virtual string GetFileName()
        {
            throw new NotImplementedException();
        }

        public virtual void SetRandomValues()
        {
            
        }
    }
}
