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
            this.btFinishStage = new Janus.Windows.EditControls.UIButton();
            this.btRandom = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.refereeTabs)).BeginInit();
            this.SuspendLayout();
            // 
            // refereeTabs
            // 
            this.refereeTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refereeTabs.Location = new System.Drawing.Point(8, 33);
            this.refereeTabs.Name = "refereeTabs";
            this.refereeTabs.Size = new System.Drawing.Size(580, 381);
            this.refereeTabs.TabIndex = 6;
            // 
            // btFinishStage
            // 
            this.btFinishStage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btFinishStage.Location = new System.Drawing.Point(8, 420);
            this.btFinishStage.Name = "btFinishStage";
            this.btFinishStage.Size = new System.Drawing.Size(143, 23);
            this.btFinishStage.TabIndex = 7;
            this.btFinishStage.Text = "Завершить этап";
            this.btFinishStage.Click += new System.EventHandler(this.btFinishStage_Click);
            // 
            // btRandom
            // 
            this.btRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRandom.Location = new System.Drawing.Point(445, 420);
            this.btRandom.Name = "btRandom";
            this.btRandom.Size = new System.Drawing.Size(143, 23);
            this.btRandom.TabIndex = 8;
            this.btRandom.Text = "Заполнить случайными";
            this.btRandom.Click += new System.EventHandler(this.btRandom_Click);
            // 
            // StageResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btRandom);
            this.Controls.Add(this.btFinishStage);
            this.Controls.Add(this.refereeTabs);
            this.Name = "StageResultView";
            this.Size = new System.Drawing.Size(591, 446);
            ((System.ComponentModel.ISupportInitialize)(this.refereeTabs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab refereeTabs;
        private Janus.Windows.EditControls.UIButton btFinishStage;
        private Janus.Windows.EditControls.UIButton btRandom;



    }
}
