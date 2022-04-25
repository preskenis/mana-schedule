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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel1 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.Explorer = new ManaSchedule.Views.ExplorerTree();
            this.uiPanel3 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel3Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.rtfHelp = new System.Windows.Forms.RichTextBox();
            this.uiPanel2 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel2Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.officeFormAdorner1 = new Janus.Windows.Ribbon.OfficeFormAdorner(this.components);
            this.MainRibbon = new Janus.Windows.Ribbon.Ribbon();
            this.rtMain = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btAdmin = new Janus.Windows.Ribbon.ButtonCommand();
            this.btHelp = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonStatusBar1 = new Janus.Windows.Ribbon.RibbonStatusBar();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.uiPanel1Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel3)).BeginInit();
            this.uiPanel3.SuspendLayout();
            this.uiPanel3Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).BeginInit();
            this.uiPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).BeginInit();
            this.SuspendLayout();
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
            this.uiPanel1.Id = new System.Guid("63dc40c2-d4b2-4ddd-83e0-e88625addc58");
            this.uiPanelManager1.Panels.Add(this.uiPanel1);
            this.uiPanel3.Id = new System.Guid("9e72db4a-8475-4359-ada8-cc5348174d31");
            this.uiPanelManager1.Panels.Add(this.uiPanel3);
            this.uiPanel2.Id = new System.Guid("c1b7d686-bfcd-4319-b2f4-6720029833eb");
            this.uiPanelManager1.Panels.Add(this.uiPanel2);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("63dc40c2-d4b2-4ddd-83e0-e88625addc58"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(200, 200), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("c1b7d686-bfcd-4319-b2f4-6720029833eb"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(415, 200), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("9e72db4a-8475-4359-ada8-cc5348174d31"), Janus.Windows.UI.Dock.PanelDockStyle.Right, new System.Drawing.Size(200, 200), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("63dc40c2-d4b2-4ddd-83e0-e88625addc58"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("9e72db4a-8475-4359-ada8-cc5348174d31"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c1b7d686-bfcd-4319-b2f4-6720029833eb"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanel1
            // 
            this.uiPanel1.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.InnerContainer = this.uiPanel1Container;
            this.uiPanel1.Location = new System.Drawing.Point(3, 147);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(200, 200);
            this.uiPanel1.TabIndex = 4;
            this.uiPanel1.Text = "Игры";
            // 
            // uiPanel1Container
            // 
            this.uiPanel1Container.Controls.Add(this.Explorer);
            this.uiPanel1Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.uiPanel1Container.Size = new System.Drawing.Size(194, 176);
            this.uiPanel1Container.TabIndex = 0;
            // 
            // Explorer
            // 
            this.Explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Explorer.Location = new System.Drawing.Point(0, 0);
            this.Explorer.Model = null;
            this.Explorer.Name = "Explorer";
            this.Explorer.Size = new System.Drawing.Size(194, 176);
            this.Explorer.TabIndex = 0;
            this.Explorer.SelectionChanged += new System.EventHandler(this.Explorer_SelectionChanged);
            // 
            // uiPanel3
            // 
            this.uiPanel3.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel3.Icon = ((System.Drawing.Icon)(resources.GetObject("uiPanel3.Icon")));
            this.uiPanel3.InnerContainer = this.uiPanel3Container;
            this.uiPanel3.Location = new System.Drawing.Point(618, 147);
            this.uiPanel3.Name = "uiPanel3";
            this.uiPanel3.Size = new System.Drawing.Size(200, 200);
            this.uiPanel3.TabIndex = 4;
            this.uiPanel3.Text = "Справка";
            // 
            // uiPanel3Container
            // 
            this.uiPanel3Container.Controls.Add(this.rtfHelp);
            this.uiPanel3Container.Location = new System.Drawing.Point(5, 23);
            this.uiPanel3Container.Name = "uiPanel3Container";
            this.uiPanel3Container.Size = new System.Drawing.Size(194, 176);
            this.uiPanel3Container.TabIndex = 0;
            // 
            // rtfHelp
            // 
            this.rtfHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfHelp.Location = new System.Drawing.Point(0, 0);
            this.rtfHelp.Name = "rtfHelp";
            this.rtfHelp.Size = new System.Drawing.Size(194, 176);
            this.rtfHelp.TabIndex = 0;
            this.rtfHelp.Text = "";
            // 
            // uiPanel2
            // 
            this.uiPanel2.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel2.InnerContainer = this.uiPanel2Container;
            this.uiPanel2.Location = new System.Drawing.Point(203, 147);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(415, 200);
            this.uiPanel2.TabIndex = 4;
            this.uiPanel2.Text = "Panel 2";
            // 
            // uiPanel2Container
            // 
            this.uiPanel2Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel2Container.Name = "uiPanel2Container";
            this.uiPanel2Container.Size = new System.Drawing.Size(413, 176);
            this.uiPanel2Container.TabIndex = 0;
            // 
            // officeFormAdorner1
            // 
            this.officeFormAdorner1.Form = this;
            // 
            // MainRibbon
            // 
            this.MainRibbon.BackstageMenuData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><BackstageMenu><ImageKey /><Key /><Text>Fil" +
    "e</Text><Visible>False</Visible></BackstageMenu>";
            // 
            // 
            // 
            this.MainRibbon.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("MainRibbon.HelpButton.Image")));
            this.MainRibbon.HelpButton.Key = "HelpButton";
            this.MainRibbon.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.Name = "MainRibbon";
            this.MainRibbon.ShowCustomizeButton = false;
            this.MainRibbon.ShowQuickCustomizeMenu = false;
            this.MainRibbon.Size = new System.Drawing.Size(821, 144);
            // 
            // 
            // 
            this.MainRibbon.SuperTipComponent.AutoPopDelay = 2000;
            this.MainRibbon.SuperTipComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainRibbon.SuperTipComponent.ImageList = null;
            this.MainRibbon.TabIndex = 5;
            this.MainRibbon.Tabs.AddRange(new Janus.Windows.Ribbon.RibbonTab[] {
            this.rtMain});
            this.MainRibbon.Text = "";
            this.MainRibbon.VisualStyle = Janus.Windows.Ribbon.VisualStyle.Office2010;
            // 
            // rtMain
            // 
            this.rtMain.Groups.AddRange(new Janus.Windows.Ribbon.RibbonGroup[] {
            this.ribbonGroup1});
            this.rtMain.Key = "Main";
            this.rtMain.Name = "rtMain";
            this.rtMain.Text = "Главная";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.btAdmin,
            this.btHelp});
            this.ribbonGroup1.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup1;
            this.ribbonGroup1.Key = "ribbonGroup1";
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Настройки";
            // 
            // btAdmin
            // 
            this.btAdmin.Checked = true;
            this.btAdmin.CheckOnClick = true;
            this.btAdmin.Icon = ((System.Drawing.Icon)(resources.GetObject("btAdmin.Icon")));
            this.btAdmin.Key = "buttonCommand1";
            this.btAdmin.Name = "btAdmin";
            this.btAdmin.Text = "Режим Администратора";
            this.btAdmin.CheckedChanged += new Janus.Windows.Ribbon.CommandEventHandler(this.btAdmin_CheckedChanged);
            // 
            // btHelp
            // 
            this.btHelp.Image = ((System.Drawing.Image)(resources.GetObject("btHelp.Image")));
            this.btHelp.Key = "buttonCommand1";
            this.btHelp.Name = "btHelp";
            this.btHelp.Text = "Редактировать справку об экране";
            this.btHelp.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btHelp_Click);
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 350);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Size = new System.Drawing.Size(821, 23);
            // 
            // 
            // 
            this.ribbonStatusBar1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbonStatusBar1.SuperTipComponent.ImageList = null;
            this.ribbonStatusBar1.TabIndex = 6;
            this.ribbonStatusBar1.Text = "ribbonStatusBar1";
            this.ribbonStatusBar1.VisualStyle = Janus.Windows.Ribbon.VisualStyle.Office2010;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 373);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel3);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.MainRibbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Мана 2016";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel3)).EndInit();
            this.uiPanel3.ResumeLayout(false);
            this.uiPanel3Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officeFormAdorner1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ExplorerTree Explorer;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private Janus.Windows.Ribbon.Ribbon MainRibbon;
        private Janus.Windows.Ribbon.RibbonTab rtMain;
        private Janus.Windows.Ribbon.OfficeFormAdorner officeFormAdorner1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand btAdmin;
        private Janus.Windows.Ribbon.ButtonCommand btHelp;
        private Janus.Windows.UI.Dock.UIPanel uiPanel1;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        private System.Windows.Forms.Button button1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel2;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel2Container;
        private Janus.Windows.UI.Dock.UIPanel uiPanel3;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel3Container;
        private System.Windows.Forms.RichTextBox rtfHelp;
       
        
    }
}

