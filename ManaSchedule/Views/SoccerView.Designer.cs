namespace ManaSchedule.Views
{
    partial class SoccerView
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
            this.schedule1 = new Janus.Windows.Schedule.Schedule();
            ((System.ComponentModel.ISupportInitialize)(this.schedule1)).BeginInit();
            this.SuspendLayout();
            // 
            // schedule1
            // 
            this.schedule1.Location = new System.Drawing.Point(37, 65);
            this.schedule1.Name = "schedule1";
            this.schedule1.Size = new System.Drawing.Size(494, 385);
            this.schedule1.TabIndex = 0;
            this.schedule1.VerticalScrollPosition = 16;
            // 
            // SoccerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.schedule1);
            this.Name = "SoccerView";
            this.Size = new System.Drawing.Size(591, 506);
            ((System.ComponentModel.ISupportInitialize)(this.schedule1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Schedule.Schedule schedule1;
    }
}
