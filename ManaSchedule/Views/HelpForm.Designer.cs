namespace ManaSchedule.Views
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.ribbonStatusBar1 = new Janus.Windows.Ribbon.RibbonStatusBar();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.boxArticles = new System.Windows.Forms.ListBox();
            this.uiPanel1 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.uiPanel1Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 648);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(4);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1387, 28);
            // 
            // 
            // 
            this.ribbonStatusBar1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbonStatusBar1.SuperTipComponent.ImageList = null;
            this.ribbonStatusBar1.TabIndex = 1;
            this.ribbonStatusBar1.Text = "ribbonStatusBar1";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanel0.Id = new System.Guid("eed8a627-971a-4034-af83-a44c989dcf9d");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            this.uiPanel1.Id = new System.Guid("f14fe71f-4f4d-4e2a-8202-3a123cea8f9d");
            this.uiPanelManager1.Panels.Add(this.uiPanel1);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("eed8a627-971a-4034-af83-a44c989dcf9d"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(200, 642), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("f14fe71f-4f4d-4e2a-8202-3a123cea8f9d"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(1181, 642), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("eed8a627-971a-4034-af83-a44c989dcf9d"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f14fe71f-4f4d-4e2a-8202-3a123cea8f9d"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanel0
            // 
            this.uiPanel0.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Location = new System.Drawing.Point(3, 3);
            this.uiPanel0.Margin = new System.Windows.Forms.Padding(4);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.Size = new System.Drawing.Size(200, 642);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "Статьи";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.boxArticles);
            this.uiPanel0Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel0Container.Margin = new System.Windows.Forms.Padding(4);
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.uiPanel0Container.Size = new System.Drawing.Size(194, 618);
            this.uiPanel0Container.TabIndex = 0;
            // 
            // boxArticles
            // 
            this.boxArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxArticles.FormattingEnabled = true;
            this.boxArticles.ItemHeight = 16;
            this.boxArticles.Location = new System.Drawing.Point(0, 0);
            this.boxArticles.Margin = new System.Windows.Forms.Padding(4);
            this.boxArticles.Name = "boxArticles";
            this.boxArticles.Size = new System.Drawing.Size(194, 618);
            this.boxArticles.TabIndex = 0;
            this.boxArticles.SelectedIndexChanged += new System.EventHandler(this.boxArticles_SelectedIndexChanged);
            // 
            // uiPanel1
            // 
            this.uiPanel1.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel1.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.InnerContainer = this.uiPanel1Container;
            this.uiPanel1.Location = new System.Drawing.Point(203, 3);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1181, 642);
            this.uiPanel1.TabIndex = 4;
            this.uiPanel1.Text = "Panel 1";
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Controls.Add(this.richTextBox1);
            this.uiPanel1Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel1Container.Margin = new System.Windows.Forms.Padding(4);
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.uiPanel1Container.Size = new System.Drawing.Size(1179, 618);
            this.uiPanel1Container.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1179, 618);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 676);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.uiPanel0);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HelpForm";
            this.Text = "Справка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelpForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel1;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private Janus.Windows.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private System.Windows.Forms.ListBox boxArticles;
    }
}