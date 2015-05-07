using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManaSchedule.DataModels;
using System.Data.Entity;
using Janus.Windows.GridEX;

namespace ManaSchedule.Views
{
    public partial class GameListView2 : CompetitionView, System.Collections.IComparer
    {

        public GameListView2()
        {
            InitializeComponent();

         
        }

        public override void OnClosing()
        {
           
        }

        public override void Init(Competition content)
        {
            base.Init(content);

            ContentCaption.Text = Competition.Name + "- Список Игр";

            var teams = DbContext.TeamCompetitionSet.Where(f => f.CompetitionId == Competition.Id).Select(f => f.TeamId).ToList();
            var stages = DbContext.StageSet.Where(f => f.CompetitionId == Competition.Id).Select(f => f.Id).ToList();

            DbContext.TeamSet.Where(f=>teams.Contains(f.Id)).Load();
            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.NoEdit;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.ToList(), "Name");
            
            DbContext.StageSet.Where(f => stages.Contains(f.Id)).Load();
            this.GridEX.RootTable.Columns["Stage"].HasValueList = true;
            this.GridEX.RootTable.Columns["Stage"].EditType = EditType.NoEdit;
            this.GridEX.RootTable.Columns["Stage"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Stage"].ValueList.PopulateValueList(DbContext.StageSet.Local.ToList(), "Name");
            this.GridEX.RootTable.Columns["Stage"].GroupComparer = this;
            this.GridEX.RootTable.Columns["Stage"].SortComparer = this;


            DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id).Load();
            GridEX.DataSource = DbContext.GameSet.Local.ToBindingList();

            GridEX.AllowEdit = InheritableBoolean.True;
            GridEX.AllowDelete = InheritableBoolean.False;
            GridEX.AllowAddNew = InheritableBoolean.False;
        }


        public int Compare(object x, object y)
        {
            if (x == y) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return (x as Stage).Type.CompareTo((y as Stage).Type);
        }
    }
}
