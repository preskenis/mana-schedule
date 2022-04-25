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
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("time", typeof(TimeSpan)));
            gridEX1.DataSource = dt;
            gridEX1.RetrieveStructure();
            gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
            gridEX1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            gridEX1.RootTable.Columns[0].InputMask = "00:00:00";
            gridEX1.InputMaskError += GridEX1_InputMaskError;
            gridEX1.InitCustomEdit += GridEX1_InitCustomEdit;
            dt.RowChanged += Dt_RowChanged;
            
        }

        private void Dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void GridEX1_InitCustomEdit(object sender, Janus.Windows.GridEX.InitCustomEditEventArgs e)
        {
//            throw new NotImplementedException();
        }

        private void GridEX1_InputMaskError(object sender, Janus.Windows.GridEX.InputMaskErrorEventArgs e)
        {
           
        }
    }
}
