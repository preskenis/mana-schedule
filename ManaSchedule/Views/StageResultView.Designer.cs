namespace ManaSchedule.Views
{
    partial class StageResultView
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
            this.refereeTabs = new Janus.Windows.UI.Tab.UITab();
            ((System.ComponentModel.ISupportInitialize)(this.refereeTabs)).BeginInit();
            this.SuspendLayout();
            // 
            // refereeTabs
            // 
            this.refereeTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refereeTabs.Location = new System.Drawing.Point(0, 0);
            this.refereeTabs.Name = "refereeTabs";
            this.refereeTabs.Size = new System.Drawing.Size(601, 490);
            this.refereeTabs.TabIndex = 6;
            // 
            // StageResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.refereeTabs);
            this.Name = "StageResultView";
            this.Size = new System.Drawing.Size(601, 490);
            ((System.ComponentModel.ISupportInitialize)(this.refereeTabs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab refereeTabs;



    }
}
