namespace ManaSchedule.Views
{
    partial class PersonView
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
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            Janus.Windows.GridEX.GridEXLayout GridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonView));
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentCaption
            // 
            this.ContentCaption.Size = new System.Drawing.Size(125, 30);
            this.ContentCaption.Text = "Наши люди";
            // 
            // visualStyleManager
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2010;
            // 
            // GridEX
            // 
            this.GridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Location = new System.Drawing.Point(3, 33);
            this.GridEX.Name = "GridEX";
            this.GridEX.Size = new System.Drawing.Size(608, 330);
            this.GridEX.TabIndex = 2;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.VisualStyleManager = this.visualStyleManager;
            // 
            // PersonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.GridEX);
            this.Name = "PersonView";
            this.Size = new System.Drawing.Size(614, 366);
            this.Controls.SetChildIndex(this.GridEX, 0);
            this.Controls.SetChildIndex(this.ContentCaption, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX;
    }
}
