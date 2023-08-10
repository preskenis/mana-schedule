using Janus.Windows.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;

namespace ManaSchedule.Views
{
    public partial class MainForm : Form
    {
       
        public static void PrepareRibbonKeys(Ribbon ribbon)
        {
            foreach (var tab in ribbon.Tabs.Cast<RibbonTab>())
            {
                tab.Key = tab.Text;
               

                foreach (var g in ribbon.Tabs[tab.Key].Groups.Cast<RibbonGroup>())
                {
                    if (g.Text == "Управление")
                    {
                        g.Enabled = App.AdminMode;
                    }
                    g.Key = string.Format("{0}-{1}", tab.Key, g.Text);
                }
            }
        }


        public MainForm()
        {
            InitializeComponent();
            Explorer.Model = new ExplorerTreeModel();
            PrepareRibbonKeys(this.MainRibbon);
            Explorer.treeViewAdv1.AllNodes.First().IsSelected = true;
            uiPanel3.AutoHide = true;
            btAdmin.Checked = false;
        }

        private void Explorer_SelectionChanged(object sender, EventArgs e)
        {
            ContentView = null;
            if (Explorer.SelectedNode != null)
                ContentView = Explorer.SelectedNode.GetView();
        }

        private ContentView _contentView = null;
        public ContentView ContentView
        {
            get { return _contentView; }
            set
            {
                var oldView = _contentView;
                if (oldView != null)
                {
                    MainRibbon.UnmergeRibbon();
                }

                _contentView = value;
                if (_contentView != null)
                {
                   
                    _contentView.Dock = DockStyle.Fill;
                    _contentView.Bounds = this.uiPanel2Container.ClientRectangle;
                    _contentView.Visible = false;
                    uiPanel2Container.Controls.Add(_contentView);
                    uiPanel2.Text = _contentView.ContentCaption;      
                    visualStyleManager1.AddControl(_contentView,true);
                    if (_contentView.RibbonControl!=null)
                    {
                        PrepareRibbonKeys(_contentView.RibbonControl);
                        MainRibbon.MergeRibbon(_contentView.RibbonControl);
                    }
                    _contentView.Visible = true;

                    Text = string.Format("Мана 2022 - {0}", _contentView.ContentCaption);

                    LoadHelp();
                   

                    Application.DoEvents();
     
                }

                if (oldView != null)
                {
                    oldView.OnClosing();
                    uiPanel2Container.Controls.Remove(oldView);
                    oldView.Dispose();
                }

            }
        }

        private void LoadHelp()
        {
            if (_contentView != null)
            {
                rtfHelp.Clear();
                if (System.IO.File.Exists(HelpForm.GetHelpFilePath(_contentView.ContentCaption)))
                {
                    try
                    {
                        rtfHelp.LoadFile(HelpForm.GetHelpFilePath(_contentView.ContentCaption));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
                   
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ContentView = null;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            uiPanel1.Width = 200;
        }

        private void btAdmin_CheckedChanged(object sender, CommandEventArgs e)
        {
            if (btAdmin.Checked)
            {
                using (var form = new AdminMode())
                    btAdmin.Checked = form.ShowDialog(this) == DialogResult.OK;
            }
            else
            {
               
            }
            App.AdminMode = btAdmin.Checked;
            PrepareRibbonKeys(MainRibbon);
        }

        private void btHelp_Click(object sender, CommandEventArgs e)
        {
            using( var helpForm = new HelpForm(ContentView.ContentCaption))
            {
                helpForm.ShowDialog(this);
                LoadHelp();
            }
         
        }
    }
}
