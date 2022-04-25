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
    public partial class AdminMode : Form
    {
        public AdminMode()
        {
            InitializeComponent();
            
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "2018123") DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void AdminMode_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
