﻿namespace ManaSchedule.Views
{
    partial class GameEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            this.btSave = new Janus.Windows.EditControls.UIButton();
            this.btCancel = new Janus.Windows.EditControls.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTeam1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.tbTeam2 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.tbDescription = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cbTeam1Missing = new Janus.Windows.EditControls.UICheckBox();
            this.cbTeam2Missing = new Janus.Windows.EditControls.UICheckBox();
            this.rbTeam1Win = new Janus.Windows.EditControls.UIRadioButton();
            this.rbTeam2Win = new Janus.Windows.EditControls.UIRadioButton();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(239, 341);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Сохранить";
            this.btSave.VisualStyleManager = this.visualStyleManager1;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(320, 341);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Отмена";
            this.btCancel.VisualStyleManager = this.visualStyleManager1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Команда 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Команда 2:";
            // 
            // tbTeam1
            // 
            this.tbTeam1.Location = new System.Drawing.Point(15, 25);
            this.tbTeam1.Name = "tbTeam1";
            this.tbTeam1.ReadOnly = true;
            this.tbTeam1.Size = new System.Drawing.Size(167, 20);
            this.tbTeam1.TabIndex = 4;
            this.tbTeam1.VisualStyleManager = this.visualStyleManager1;
            // 
            // tbTeam2
            // 
            this.tbTeam2.Location = new System.Drawing.Point(226, 25);
            this.tbTeam2.Name = "tbTeam2";
            this.tbTeam2.ReadOnly = true;
            this.tbTeam2.Size = new System.Drawing.Size(167, 20);
            this.tbTeam2.TabIndex = 5;
            this.tbTeam2.VisualStyleManager = this.visualStyleManager1;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Location = new System.Drawing.Point(12, 124);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(381, 51);
            this.uiGroupBox1.TabIndex = 6;
            this.uiGroupBox1.Text = "Результат";
            this.uiGroupBox1.VisualStyleManager = this.visualStyleManager1;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox2.Controls.Add(this.tbDescription);
            this.uiGroupBox2.Location = new System.Drawing.Point(12, 181);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(381, 154);
            this.uiGroupBox2.TabIndex = 7;
            this.uiGroupBox2.Text = "Примечания";
            this.uiGroupBox2.VisualStyleManager = this.visualStyleManager1;
            // 
            // tbDescription
            // 
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 16);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(375, 135);
            this.tbDescription.TabIndex = 0;
            this.tbDescription.VisualStyleManager = this.visualStyleManager1;
            // 
            // cbTeam1Missing
            // 
            this.cbTeam1Missing.CheckedValue = "";
            this.cbTeam1Missing.Location = new System.Drawing.Point(15, 51);
            this.cbTeam1Missing.Name = "cbTeam1Missing";
            this.cbTeam1Missing.Size = new System.Drawing.Size(72, 23);
            this.cbTeam1Missing.TabIndex = 8;
            this.cbTeam1Missing.Text = "Неявка";
            this.cbTeam1Missing.ThreeState = true;
            this.cbTeam1Missing.VisualStyleManager = this.visualStyleManager1;
            this.cbTeam1Missing.CheckedChanged += new System.EventHandler(this.UpdateButtons);
            this.cbTeam1Missing.CheckStateChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // cbTeam2Missing
            // 
            this.cbTeam2Missing.Location = new System.Drawing.Point(226, 51);
            this.cbTeam2Missing.Name = "cbTeam2Missing";
            this.cbTeam2Missing.Size = new System.Drawing.Size(72, 23);
            this.cbTeam2Missing.TabIndex = 9;
            this.cbTeam2Missing.Text = "Неявка";
            this.cbTeam2Missing.ThreeState = true;
            this.cbTeam2Missing.VisualStyleManager = this.visualStyleManager1;
            this.cbTeam2Missing.CheckedChanged += new System.EventHandler(this.UpdateButtons);
            this.cbTeam2Missing.CheckStateChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // rbTeam1Win
            // 
            this.rbTeam1Win.Location = new System.Drawing.Point(15, 80);
            this.rbTeam1Win.Name = "rbTeam1Win";
            this.rbTeam1Win.Size = new System.Drawing.Size(104, 23);
            this.rbTeam1Win.TabIndex = 12;
            this.rbTeam1Win.Text = "Победа";
            this.rbTeam1Win.VisualStyleManager = this.visualStyleManager1;
            this.rbTeam1Win.CheckedChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // rbTeam2Win
            // 
            this.rbTeam2Win.Location = new System.Drawing.Point(226, 80);
            this.rbTeam2Win.Name = "rbTeam2Win";
            this.rbTeam2Win.Size = new System.Drawing.Size(104, 23);
            this.rbTeam2Win.TabIndex = 13;
            this.rbTeam2Win.Text = "Победа";
            this.rbTeam2Win.VisualStyleManager = this.visualStyleManager1;
            this.rbTeam2Win.CheckedChanged += new System.EventHandler(this.UpdateButtons);
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2010;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // GameEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 376);
            this.Controls.Add(this.rbTeam2Win);
            this.Controls.Add(this.rbTeam1Win);
            this.Controls.Add(this.cbTeam2Missing);
            this.Controls.Add(this.cbTeam1Missing);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.tbTeam2);
            this.Controls.Add(this.tbTeam1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование игры";
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.EditControls.UIButton btSave;
        private Janus.Windows.EditControls.UIButton btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox tbTeam1;
        private Janus.Windows.GridEX.EditControls.EditBox tbTeam2;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.GridEX.EditControls.EditBox tbDescription;
        private Janus.Windows.EditControls.UICheckBox cbTeam1Missing;
        private Janus.Windows.EditControls.UICheckBox cbTeam2Missing;
        private Janus.Windows.EditControls.UIRadioButton rbTeam1Win;
        private Janus.Windows.EditControls.UIRadioButton rbTeam2Win;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
    }
}