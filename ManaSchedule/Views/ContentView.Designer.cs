namespace ManaSchedule.Views
{
    partial class ContentView
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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            this.ContentCaption = new System.Windows.Forms.Label();
            this.visualStyleManager = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.SuspendLayout();
            // 
            // ContentCaption
            // 
            this.ContentCaption.AutoSize = true;
            this.ContentCaption.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContentCaption.Location = new System.Drawing.Point(3, 0);
            this.ContentCaption.Name = "ContentCaption";
            this.ContentCaption.Size = new System.Drawing.Size(131, 30);
            this.ContentCaption.TabIndex = 5;
            this.ContentCaption.Text = "Жеребьёвка";
            // 
            // visualStyleManager
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2010;
            this.visualStyleManager.ColorSchemes.Add(janusColorScheme1);
            // 
            // ContentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContentCaption);
            this.Name = "ContentView";
            this.Size = new System.Drawing.Size(436, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label ContentCaption;
        protected Janus.Windows.Common.VisualStyleManager visualStyleManager;
    }
}
