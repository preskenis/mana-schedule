namespace ManaSchedule.Views
{
    partial class ZherebView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZherebView));
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.btLoadCompanies = new Janus.Windows.EditControls.UIButton();
            this.btGenerate = new Janus.Windows.EditControls.UIButton();
            this.btClearAll = new Janus.Windows.EditControls.UIButton();
            this.btRandom = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            this.SuspendLayout();
            // 
            // GridEX
            // 
            this.GridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridEX.ColumnAutoResize = true;
            this.GridEX.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.ColumnHeader;
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Location = new System.Drawing.Point(8, 37);
            this.GridEX.Name = "GridEX";
            this.GridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.GridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.GridEX.Size = new System.Drawing.Size(534, 271);
            this.GridEX.TabIndex = 0;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.VisualStyleManager = this.visualStyleManager;
            // 
            // btLoadCompanies
            // 
            this.btLoadCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btLoadCompanies.Location = new System.Drawing.Point(405, 8);
            this.btLoadCompanies.Name = "btLoadCompanies";
            this.btLoadCompanies.Size = new System.Drawing.Size(137, 23);
            this.btLoadCompanies.TabIndex = 1;
            this.btLoadCompanies.Text = "Загрузить все команды";
            this.btLoadCompanies.VisualStyleManager = this.visualStyleManager;
            this.btLoadCompanies.Click += new System.EventHandler(this.btLoadCompanies_Click);
            // 
            // btGenerate
            // 
            this.btGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGenerate.Location = new System.Drawing.Point(8, 314);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(137, 23);
            this.btGenerate.TabIndex = 2;
            this.btGenerate.Text = "Сформировать игры";
            this.btGenerate.VisualStyleManager = this.visualStyleManager;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // btClearAll
            // 
            this.btClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClearAll.Location = new System.Drawing.Point(405, 314);
            this.btClearAll.Name = "btClearAll";
            this.btClearAll.Size = new System.Drawing.Size(137, 23);
            this.btClearAll.TabIndex = 3;
            this.btClearAll.Text = "Стереть все игры";
            this.btClearAll.VisualStyleManager = this.visualStyleManager;
            this.btClearAll.Click += new System.EventHandler(this.btClearAll_Click);
            // 
            // btRandom
            // 
            this.btRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRandom.Location = new System.Drawing.Point(262, 8);
            this.btRandom.Name = "btRandom";
            this.btRandom.Size = new System.Drawing.Size(137, 23);
            this.btRandom.TabIndex = 6;
            this.btRandom.Text = "Случайная жеребьёвка";
            this.btRandom.VisualStyleManager = this.visualStyleManager;
            this.btRandom.Click += new System.EventHandler(this.btRandom_Click);
            // 
            // ZherebView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btRandom);
            this.Controls.Add(this.btClearAll);
            this.Controls.Add(this.btGenerate);
            this.Controls.Add(this.btLoadCompanies);
            this.Controls.Add(this.GridEX);
            this.Name = "ZherebView";
            this.Size = new System.Drawing.Size(545, 340);
            this.Controls.SetChildIndex(this.GridEX, 0);
            this.Controls.SetChildIndex(this.btLoadCompanies, 0);
            this.Controls.SetChildIndex(this.btGenerate, 0);
            this.Controls.SetChildIndex(this.btClearAll, 0);
            this.Controls.SetChildIndex(this.ContentCaption, 0);
            this.Controls.SetChildIndex(this.btRandom, 0);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.EditControls.UIButton btLoadCompanies;
        private Janus.Windows.EditControls.UIButton btGenerate;
        private Janus.Windows.EditControls.UIButton btClearAll;
        private Janus.Windows.EditControls.UIButton btRandom;
    }
}
