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
    public partial class GameListView : CompetitionView, System.Collections.IComparer
    {

        public GameListView()
        {
            InitializeComponent();

         
        }

        public override void OnClosing()
        { 
        
            var a = DbContext.ChangeTracker.Entries<Game>();
            
            foreach(var g in a)
            {
                g.Entity.CompetitionId = Competition.Id;
                


            }

        
        }

        public override void Init(Competition content)
        {
            base.Init(content);

            ContentCaption.Text = Competition.Name + "- Список Игр";

            var teams = DbContext.TeamCompetitionSet.Where(f => f.CompetitionId == Competition.Id).Select(f => f.TeamId).ToList();
            var stages = DbContext.StageSet.Where(f => f.CompetitionId == Competition.Id).Select(f => f.Id).ToList();
            
            DbContext.GameSet.Where(f => f.CompetitionId == Competition.Id).Load();
            
            DbContext.TeamSet.Where(f=>teams.Contains(f.Id)).Load();

            this.GridEX.RootTable.Columns["Team"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["Team"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team"].ValueList.PopulateValueList(DbContext.TeamSet.Local.ToList(), "Name");
            
            this.GridEX.RootTable.Columns["Team2"].HasValueList = true;
            this.GridEX.RootTable.Columns["Team2"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["Team2"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Team2"].ValueList.PopulateValueList(DbContext.TeamSet.Local.ToList(), "Name");
            
            this.GridEX.RootTable.Columns["Winner"].HasValueList = true;
            this.GridEX.RootTable.Columns["Winner"].EditType = EditType.NoEdit;
            this.GridEX.RootTable.Columns["Winner"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Winner"].ValueList.PopulateValueList(DbContext.TeamSet.Local.ToList(), "Name");

            DbContext.StageSet.Where(f => stages.Contains(f.Id)).Load();
            this.GridEX.RootTable.Columns["Stage"].HasValueList = true;
            this.GridEX.RootTable.Columns["Stage"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["Stage"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["Stage"].ValueList.PopulateValueList(DbContext.StageSet.Local.ToList(), "Name");
            this.GridEX.RootTable.Columns["Stage"].GroupComparer = this;
            this.GridEX.RootTable.Columns["Stage"].SortComparer = this;

            this.GridEX.RootTable.Columns["ParentGame1"].HasValueList = true;
            this.GridEX.RootTable.Columns["ParentGame1"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["ParentGame1"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["ParentGame1"].ValueList.PopulateValueList(DbContext.GameSet.Local.ToList(), "Name2");
            this.GridEX.RootTable.Columns["ParentGame2"].HasValueList = true;
            this.GridEX.RootTable.Columns["ParentGame2"].EditType = EditType.Combo;
            this.GridEX.RootTable.Columns["ParentGame2"].ColumnType = ColumnType.Text;
            this.GridEX.RootTable.Columns["ParentGame2"].ValueList.PopulateValueList(DbContext.GameSet.Local.ToList(), "Name2");



            GridEX.DataSource = DbContext.GameSet.Local.ToBindingList();

        }


        public int Compare(object x, object y)
        {
            if (x == y) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return (x as Stage).Type.CompareTo((y as Stage).Type);
        }

        private void GridEX_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            var game = e.Row.DataRow as Game;
            using (var form = new GameEditForm(game, DbContext))
            {
                if (form.ShowDialog(this) == DialogResult.OK )
                {
                    GameService.UpdateGame(game);
                    GridEX.Refetch();
                }
            }
          
        }
    }
}
