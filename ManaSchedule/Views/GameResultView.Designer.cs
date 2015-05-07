namespace ManaSchedule.Views
{
    partial class GameResultView
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
            this.stageTabs = new Janus.Windows.UI.Tab.UITab();
            this.btExportToExcel = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.stageTabs)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentCaption
            // 
            this.ContentCaption.Size = new System.Drawing.Size(82, 30);
            this.ContentCaption.Text = "Футбол";
            // 
            // stageTabs
            // 
            this.stageTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stageTabs.Location = new System.Drawing.Point(8, 33);
            this.stageTabs.Name = "stageTabs";
            this.stageTabs.Size = new System.Drawing.Size(580, 410);
            this.stageTabs.TabIndex = 6;
            this.stageTabs.VisualStyleManager = this.visualStyleManager;
            // 
            // btExportToExcel
            // 
            this.btExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExportToExcel.Location = new System.Drawing.Point(404, 8);
            this.btExportToExcel.Name = "btExportToExcel";
            this.btExportToExcel.Size = new System.Drawing.Size(184, 23);
            this.btExportToExcel.TabIndex = 9;
            this.btExportToExcel.Text = "Экспорт в Excel";
            this.btExportToExcel.VisualStyleManager = this.visualStyleManager;
            this.btExportToExcel.Click += new System.EventHandler(this.btExportToExcel_Click);
            // 
            // GameResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btExportToExcel);
            this.Controls.Add(this.stageTabs);
            this.Name = "GameResultView";
            this.Size = new System.Drawing.Size(591, 446);
            this.Controls.SetChildIndex(this.ContentCaption, 0);
            this.Controls.SetChildIndex(this.stageTabs, 0);
            this.Controls.SetChildIndex(this.btExportToExcel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.stageTabs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab stageTabs;
        private Janus.Windows.EditControls.UIButton btExportToExcel;



    }
}
