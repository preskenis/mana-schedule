namespace ManaSchedule.Views
{
    partial class SummaryScoreView
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
            this.label1 = new System.Windows.Forms.Label();
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.btExportToExcel = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentCaption
            // 
            this.ContentCaption.Size = new System.Drawing.Size(129, 30);
            this.ContentCaption.Text = "Общий итог";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общий зачёт";
            // 
            // GridEX
            // 
            this.GridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridEX.Location = new System.Drawing.Point(3, 37);
            this.GridEX.Name = "GridEX";
            this.GridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.GridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX.Size = new System.Drawing.Size(608, 471);
            this.GridEX.TabIndex = 1;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.VisualStyleManager = this.visualStyleManager;
            // 
            // btExportToExcel
            // 
            this.btExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExportToExcel.Location = new System.Drawing.Point(427, 8);
            this.btExportToExcel.Name = "btExportToExcel";
            this.btExportToExcel.Size = new System.Drawing.Size(184, 23);
            this.btExportToExcel.TabIndex = 10;
            this.btExportToExcel.Text = "Экспорт в Excel";
            this.btExportToExcel.VisualStyleManager = this.visualStyleManager;
            this.btExportToExcel.Click += new System.EventHandler(this.btExportToExcel_Click);
            // 
            // SummaryScoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btExportToExcel);
            this.Controls.Add(this.GridEX);
            this.Controls.Add(this.label1);
            this.Name = "SummaryScoreView";
            this.Size = new System.Drawing.Size(614, 511);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.GridEX, 0);
            this.Controls.SetChildIndex(this.ContentCaption, 0);
            this.Controls.SetChildIndex(this.btExportToExcel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.EditControls.UIButton btExportToExcel;
    }
}
