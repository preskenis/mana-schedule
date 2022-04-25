using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aga.Controls.Tree;

namespace ManaSchedule.Views
{
    public partial class GameTree : UserControl
    {
        public event EventHandler SelectionChanged;

        public GameTree()
        {
            InitializeComponent();
        }

        public ITreeModel Model 
        {
            get { return treeViewAdv1.Model; }
            set { treeViewAdv1.Model = value; }
        }

        public ExplorerTreeNode SelectedNode
        {
            get
            {
                return treeViewAdv1.SelectedNode != null ? treeViewAdv1.SelectedNode.Tag as ExplorerTreeNode : null;
            }
        }

        private void treeViewAdv1_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }
    }
}
