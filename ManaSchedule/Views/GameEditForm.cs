using ManaSchedule.DataModels;
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
            Game.Team1Missed = ToNullable(cbTeam1Missing.CheckState);
            Game.Team2Missed = ToNullable(cbTeam2Missing.CheckState);
            Game.Description = tbDescription.Text;
            Game.Team1Win = rbTeam1Win.Checked;
            Game.Team2Win = rbTeam2Win.Checked;

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
