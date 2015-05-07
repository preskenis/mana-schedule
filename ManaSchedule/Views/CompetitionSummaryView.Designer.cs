namespace ManaSchedule.Views
{
    partial class CompetitionSummaryView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Janus.Windows.GridEX.GridEXLayout GridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompetitionSummaryView));
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentCaption
            // 
            this.ContentCaption.Size = new System.Drawing.Size(82, 30);
            this.ContentCaption.Text = "Футбол";
            // 
            // GridEX
            // 
            this.GridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridEX.ColumnAutoResize = true;
            this.GridEX.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.ColumnHeader;
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Location = new System.Drawing.Point(8, 33);
            this.GridEX.Name = "GridEX";
            this.GridEX.Size = new System.Drawing.Size(586, 425);
            this.GridEX.TabIndex = 6;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.VisualStyleManager = this.visualStyleManager;
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton1.Location = new System.Drawing.Point(410, 3);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(184, 23);
            this.uiButton1.TabIndex = 8;
            this.uiButton1.Text = "Экспорт в Excel";
            this.uiButton1.VisualStyleManager = this.visualStyleManager;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // CompetitionSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.GridEX);
            this.Name = "CompetitionSummaryView";
            this.Size = new System.Drawing.Size(597, 461);
            this.Controls.SetChildIndex(this.ContentCaption, 0);
            this.Controls.SetChildIndex(this.GridEX, 0);
            this.Controls.SetChildIndex(this.uiButton1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.EditControls.UIButton uiButton1;

    }
}
