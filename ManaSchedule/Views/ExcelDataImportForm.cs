using Janus.Windows.GridEX;
using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity;
using NPOI.HSSF.UserModel;

namespace ManaSchedule.Views
{
    public partial class ExcelDataImportForm : Form
    {
        private readonly GridEX _destinationGrid;
        private readonly HSSFSheet _sheet;

        public ExcelDataImportForm()
        {
            InitializeComponent();
        }

        
        public ExcelDataImportForm(GridEX destinationGrid, HSSFSheet sheet)
            : this()
        {
            _destinationGrid = destinationGrid;
            _sheet = sheet;

            
            
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

        }

    }
}
