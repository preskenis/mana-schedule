namespace ManaSchedule.Views
{
    partial class MainForm
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
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            this.Explorer = new ManaSchedule.Views.ExplorerTree();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.uiPanel1 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiPanel2 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel2Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.uiPanel1Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Explorer
            // 
            this.Explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Explorer.Location = new System.Drawing.Point(0, 0);
            this.Explorer.Model = null;
            this.Explorer.Name = "Explorer";
            this.Explorer.Size = new System.Drawing.Size(255, 391);
            this.Explorer.TabIndex = 0;
            this.Explorer.SelectionChanged += new System.EventHandler(this.Explorer_SelectionChanged);
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.OfficeCustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Standard;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.VisualStyleManager = this.visualStyleManager1;
            this.uiPanel0.Id = new System.Guid("82aba20f-8daf-4869-af3c-baccafb80858");
            this.uiPanel0.StaticGroup = true;
            this.uiPanel1.Id = new System.Guid("b9007d65-66c8-4bc9-91fd-286e51c3269b");
            this.uiPanel0.Panels.Add(this.uiPanel1);
            this.uiPanel2.Id = new System.Guid("037333bc-7259-44ac-9d50-a1dcb790245a");
            this.uiPanel0.Panels.Add(this.uiPanel2);
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("da0b2f7d-8407-4832-8134-eaeb56fcca44"), Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Left, true, new System.Drawing.Size(504, 370), false);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("82aba20f-8daf-4869-af3c-baccafb80858"), Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(815, 415), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("b9007d65-66c8-4bc9-91fd-286e51c3269b"), new System.Guid("82aba20f-8daf-4869-af3c-baccafb80858"), 257, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("037333bc-7259-44ac-9d50-a1dcb790245a"), new System.Guid("82aba20f-8daf-4869-af3c-baccafb80858"), 554, true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("82aba20f-8daf-4869-af3c-baccafb80858"), Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b9007d65-66c8-4bc9-91fd-286e51c3269b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("037333bc-7259-44ac-9d50-a1dcb790245a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanel0
            // 
            this.uiPanel0.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.VerticalTiles;
            this.uiPanel0.Location = new System.Drawing.Point(3, 3);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.Size = new System.Drawing.Size(815, 415);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "Panel 0";
            // 
            // uiPanel1
            // 
            this.uiPanel1.InnerContainer = this.uiPanel1Container;
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(257, 415);
            this.uiPanel1.TabIndex = 4;
            this.uiPanel1.Text = "Мана";
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Controls.Add(this.Explorer);
            this.uiPanel1Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.uiPanel1Container.Size = new System.Drawing.Size(255, 391);
            this.uiPanel1Container.TabIndex = 0;
            // 
            // uiPanel2
            // 
            this.uiPanel2.InnerContainer = this.uiPanel2Container;
            this.uiPanel2.Location = new System.Drawing.Point(261, 0);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(554, 415);
            this.uiPanel2.TabIndex = 4;
            this.uiPanel2.Text = "Panel 2";
            // 
            // uiPanel2Container
            // 
            this.uiPanel2Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel2Container.Name = "uiPanel2Container";
            this.uiPanel2Container.Size = new System.Drawing.Size(552, 391);
            this.uiPanel2Container.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 421);
            this.Controls.Add(this.uiPanel0);
            this.Name = "MainForm";
            this.Text = "Мана 2015";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ExplorerTree Explorer;
        private Janus.Windows.UI.Dock.UIPanelGroup uiPanel0;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel1;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        private Janus.Windows.UI.Dock.UIPanel uiPanel2;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel2Container;
    }
}

