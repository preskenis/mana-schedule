using ManaSchedule.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManaSchedule.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Explorer.Model = new ExplorerTreeModel();

        }

        private void Explorer_SelectionChanged(object sender, EventArgs e)
        {
            ContentView = null;
            ContentView view = null;
            
                if (Explorer.SelectedNode is TeamNode)
                {
                    var item = Explorer.SelectedNode as TeamNode;

                    view = new TeamView();
                    view.Init(item);
                }
                else if (Explorer.SelectedNode is PersonNode)
                {
                    var item = Explorer.SelectedNode as PersonNode;

                    view = new PersonView();
                    view.Init(item);
                }
                else if (Explorer.SelectedNode is SoccerNode)
                {
                    var item = Explorer.SelectedNode as SoccerNode;

                    view = new SoccerView();
                    view.Init(item);
                }
          

            ContentView = view;
        }

        private ContentView _contentView = null;
        public ContentView ContentView
        {
            get { return _contentView; }
            set
            {
                if (_contentView != null)
                {
                    _contentView.OnClosing();
                    uiPanel2Container.Controls.Remove(_contentView);
                    _contentView.Dispose();
                }
                _contentView = value;
                if (_contentView != null)
                {
                    _contentView.Dock = DockStyle.Fill;
                    uiPanel2Container.Controls.Add(_contentView);
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ContentView = null;
        }
    }
}
