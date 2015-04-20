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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.GridEX.GridEXLayout GridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonView));
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            this.SuspendLayout();
            // 
            // GridEX
            // 
            this.GridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridEX.Location = new System.Drawing.Point(0, 0);
            this.GridEX.Name = "GridEX";
            this.GridEX.Size = new System.Drawing.Size(614, 366);
            this.GridEX.TabIndex = 2;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // PersonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.GridEX);
            this.Name = "PersonView";
            this.Size = new System.Drawing.Size(614, 366);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
    }
}
