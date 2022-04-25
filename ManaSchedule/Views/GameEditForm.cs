using ManaSchedule.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using ManaSchedule.Services;

namespace ManaSchedule.Views
{
    public partial class GameEditForm : Form
    {
        public GameEditForm()
        {
            InitializeComponent();
        }

       

        public GameEditForm(Game game, Db db)
        {
            Game = game;
            DbContext = db;
            InitializeComponent();
            Text += " " + Game.Competition.Name;

            tbTeam1.Text = game.Game1Name();
            tbTeam2.Text = game.Game2Name();

            cbTeam1Missing.CheckState = FromNullable(Game.Team1Missed);
            cbTeam2Missing.CheckState = FromNullable(Game.Team2Missed);
            UpdateButtons(this, EventArgs.Empty);

            if (Game.Team1Win) rbTeam1Win.Checked = true;
            if (Game.Team2Win) rbTeam2Win.Checked = true;
            tbDescription.Text = game.Description;

            listReferee.Items.AddRange(db.CompetitionRefereeSet.Where(f => f.CompetitionId == game.CompetitionId).ToArray());
            listReferee.SelectedIndex = -1;

            if (Game.CompetitionRefereeId.HasValue)
            {
                listReferee.SelectedItem = db.CompetitionRefereeSet.FirstOrDefault(f => f.Id == Game.CompetitionRefereeId);
            }

            var dt = CarnivalGameService.GetSportCarnivalTable(Game, DbContext);

            gridCarnival.DataSource = dt;
            gridCarnival.FrozenColumns = 1;
            gridCarnival.RetrieveStructure();

            gridCarnival.RootTable.Columns["Параметр"].EditType = EditType.NoEdit;
            gridCarnival.RootTable.SortKeys.Add(gridCarnival.RootTable.Columns["Параметр"]);
            gridCarnival.GroupByBoxVisible = false;


            gridCarnival.ColumnAutoSizeMode = ColumnAutoSizeMode.ColumnHeader;
            gridCarnival.ColumnAutoResize = true;

            dt.RowChanged += dt_RowChanged;

        }

        void dt_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            var gameValueType = EnumHelper<GameValueType>.GetValueByDisplayValue(e.Row[0] as string);

           

            if (e.Row[1] != System.DBNull.Value)
            {
                var val = (int)e.Row[1];

                var range = CarnivalGameService.SportMinMaxValues[gameValueType];
                if (val < range.Min   || val > range.Max )
                    e.Row[1] = DBNull.Value;
            }
            UpdateButtons(sender, e);
        }

        

        protected void UpdateButtons(object sender, EventArgs e)
        {
            if (Game.Team != null)
            {
                switch (cbTeam1Missing.CheckState)
                {
                    case CheckState.Checked:
                        rbTeam1Win.Checked = false;
                        rbTeam1Win.Enabled = false; break;
                    case CheckState.Unchecked:
                        rbTeam1Win.Enabled = true; break;
                    case CheckState.Indeterminate:
                        rbTeam1Win.Checked = false;
                        rbTeam1Win.Enabled = false; break;
                }
            }
            else
            {
                cbTeam1Missing.Enabled = false;
                rbTeam1Win.Checked = false;
                rbTeam1Win.Enabled = false;
            }

            if (Game.Team2 != null)
            {
                switch (cbTeam2Missing.CheckState)
                {
                    case CheckState.Checked:
                        rbTeam2Win.Checked = false;
                        rbTeam2Win.Enabled = false; break;
                    case CheckState.Unchecked:
                        rbTeam2Win.Enabled = true; break;
                    case CheckState.Indeterminate:
                        rbTeam2Win.Checked = false;
                        rbTeam2Win.Enabled = false; break;
                }
            }
            else
            {
                cbTeam2Missing.Enabled = false;
                rbTeam2Win.Checked = false;
                rbTeam2Win.Enabled = false;
            }

            btSave.Enabled = true;


            if ((rbTeam1Win.Enabled || rbTeam2Win.Enabled) && !rbTeam1Win.Checked && !rbTeam2Win.Checked)
                btSave.Enabled = false;
           if ((cbTeam1Missing.CheckState != cbTeam2Missing.CheckState) && (cbTeam1Missing.CheckState == CheckState.Indeterminate || cbTeam2Missing.CheckState == CheckState.Indeterminate) )
               btSave.Enabled = false;

           if (btSave.Enabled && (cbTeam1Missing.CheckState == cbTeam2Missing.CheckState) && cbTeam1Missing.CheckState == CheckState.Unchecked && gridCarnival.DataSource != null)
           {

               if ((gridCarnival.DataSource as DataTable).Rows.Cast<DataRow>().Any(f=>f[1] == DBNull.Value))
               {
                   btSave.Enabled = false;
               }
           }

           }

        public Game Game { get; set; }

        public Db DbContext { get; set; }

        public CheckState FromNullable(bool? value)
        {
            if (!value.HasValue) return CheckState.Indeterminate;
            return value.Value ? CheckState.Checked : CheckState.Unchecked;

        }

        public bool? ToNullable(CheckState state)
        {
            switch (state)
            {
                case CheckState.Checked: return true;
                case CheckState.Unchecked: return false;
                default: return null;
            }
                        
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (listReferee.SelectedIndex < 0 && DialogResult.Yes != MessageBox.Show(this, "Не указан судья, продолжить?", "Не достаточно данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            if (listReferee.SelectedIndex >= 0)
            {
                Game.CompetitionRefereeId = (listReferee.SelectedItem as CompetitionReferee).Id;
            }

            


            Game.Team1Missed = ToNullable(cbTeam1Missing.CheckState);
            Game.Team2Missed = ToNullable(cbTeam2Missing.CheckState);
            Game.Description = tbDescription.Text;
            Game.Team1Win = rbTeam1Win.Checked;
            Game.Team2Win = rbTeam2Win.Checked;
            
            if (Game.Team1Missed==false && Game.Team2Missed == false)
            {
                var dataValues = (gridCarnival.DataSource as DataTable).Rows.Cast<DataRow>().ToDictionary(f=>EnumHelper<GameValueType>.GetValueByDisplayValue(f[0] as string), f=>(int)f[1]);
                var gameResult = DbContext.GameResultSet.FirstOrDefault(f => f.GameId == Game.Id);
                foreach (var value in dataValues)
                {
                    var v = gameResult.Values.FirstOrDefault(f=>f.Type == value.Key);
                    if (v != null)
                    {
                        v.Value = value.Value;
                    }
                    else
                    {
                        gameResult.Values.Add(new GameResultValue()
                        {
                            Type = value.Key,
                            Value = value.Value,
                            GameResult = gameResult
                        });
                    }

                }
                
                

            }
            else
            {
                var gameResult = DbContext.GameResultSet.FirstOrDefault(f => f.GameId == Game.Id);
                DbContext.GameResultValueSet.Where(f => f.GameResultId == gameResult.Id).ToList().ForEach(f => DbContext.GameResultValueSet.Remove(f));

            }


            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
