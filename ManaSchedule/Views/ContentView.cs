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
    public partial class ContentView : UserControl
    {
        public Db DbContext { get; private set; }

        public ContentView()
        {
            InitializeComponent();
            DbContext = new Db();
            this.Disposed += ContentView_Disposed;
        }

        void ContentView_Disposed(object sender, EventArgs e)
        {
            DbContext.SaveChanges();
            DbContext.Dispose();
        }

        public virtual void OnClosing()
        {
           
        }

        public virtual Janus.Windows.Ribbon.Ribbon RibbonControl
        {
            get
            {
                return null;
            }
        }

        public string ContentCaption { get; set; }
        
        
    }
}
