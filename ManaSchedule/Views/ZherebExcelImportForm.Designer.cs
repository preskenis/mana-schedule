namespace ManaSchedule.Views
{
    partial class ZherebExcelImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZherebExcelImportForm));
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.importItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GridEX
            // 
            this.GridEX.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridEX.ColumnAutoResize = true;
            this.GridEX.DataSource = this.importItemBindingSource;
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Location = new System.Drawing.Point(12, 12);
            this.GridEX.Name = "GridEX";
            this.GridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.GridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.GridEX.Size = new System.Drawing.Size(794, 439);
            this.GridEX.TabIndex = 3;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridEX_KeyDown);
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton1.Location = new System.Drawing.Point(650, 457);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(75, 23);
            this.uiButton1.TabIndex = 4;
            this.uiButton1.Text = "Импорт";
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiButton2.Location = new System.Drawing.Point(731, 457);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(75, 23);
            this.uiButton2.TabIndex = 5;
            this.uiButton2.Text = "Отмена";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ManaSchedule.DataModels.ImportItem);
            // 
            // importItemBindingSource
            // 
            this.importItemBindingSource.DataSource = typeof(ManaSchedule.DataModels.ImportItem);
            // 
            // ZherebExcelImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 492);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.GridEX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ZherebExcelImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Импорт жеребьевки";
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource importItemBindingSource;
    }
}