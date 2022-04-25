namespace ManaSchedule.Views
{
    partial class SummaryScoreView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryScoreView));
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.buttonCommand1 = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup6 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btExport = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonGroup7 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btClearAll = new Janus.Windows.Ribbon.ButtonCommand();
            this.btExportZhereb = new Janus.Windows.Ribbon.ButtonCommand();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridEX
            // 
            this.GridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.GridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridEX.Location = new System.Drawing.Point(0, 142);
            this.GridEX.Name = "GridEX";
            this.GridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowIndex;
            this.GridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX.Size = new System.Drawing.Size(614, 369);
            this.GridEX.TabIndex = 1;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.VisualStyleManager = this.visualStyleManager;
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.buttonCommand1});
            this.ribbonGroup1.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup1;
            this.ribbonGroup1.Key = "ribbonGroup1";
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Данные";
            // 
            // buttonCommand1
            // 
            this.buttonCommand1.Icon = ((System.Drawing.Icon)(resources.GetObject("buttonCommand1.Icon")));
            this.buttonCommand1.Key = "buttonCommand1";
            this.buttonCommand1.Name = "buttonCommand1";
            this.buttonCommand1.Text = "Экспорт в Excel";
            // 
            // ribbon1
            // 
            this.ribbon1.BackstageMenuData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><BackstageMenu><ImageKey /><Key /><Text>Fil" +
    "e</Text></BackstageMenu>";
            // 
            // 
            // 
            this.ribbon1.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("ribbon1.HelpButton.Image")));
            this.ribbon1.HelpButton.Key = "HelpButton";
            this.ribbon1.LayoutStream = ((System.IO.Stream)(resources.GetObject("ribbon1.LayoutStream")));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Name = "ribbon1";
            this.ribbon1.Size = new System.Drawing.Size(614, 142);
            // 
            // 
            // 
            this.ribbon1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbon1.SuperTipComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ribbon1.SuperTipComponent.ImageList = null;
            this.ribbon1.TabIndex = 2;
            this.ribbon1.Tabs.AddRange(new Janus.Windows.Ribbon.RibbonTab[] {
            this.ribbonTab1});
            this.ribbon1.Text = "";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.AddRange(new Janus.Windows.Ribbon.RibbonGroup[] {
            this.ribbonGroup6,
            this.ribbonGroup7});
            this.ribbonTab1.Key = "Main";
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Главная";
            // 
            // ribbonGroup6
            // 
            this.ribbonGroup6.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.btExport,
            this.btExportZhereb});
            this.ribbonGroup6.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup6;
            this.ribbonGroup6.ImageKey = "";
            this.ribbonGroup6.Key = "Данные";
            this.ribbonGroup6.Name = "ribbonGroup6";
            this.ribbonGroup6.Text = "Данные";
            // 
            // btExport
            // 
            this.btExport.Icon = ((System.Drawing.Icon)(resources.GetObject("btExport.Icon")));
            this.btExport.Key = "buttonCommand5";
            this.btExport.Name = "btExport";
            this.btExport.Text = "Экспорт в Excel";
            this.btExport.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btExport_Click);
            // 
            // ribbonGroup7
            // 
            this.ribbonGroup7.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.btClearAll});
            this.ribbonGroup7.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup7;
            this.ribbonGroup7.ImageKey = "";
            this.ribbonGroup7.Key = "Управление";
            this.ribbonGroup7.Name = "ribbonGroup7";
            this.ribbonGroup7.Text = "Управление";
            // 
            // btClearAll
            // 
            this.btClearAll.Icon = ((System.Drawing.Icon)(resources.GetObject("btClearAll.Icon")));
            this.btClearAll.Key = "buttonCommand5";
            this.btClearAll.Name = "btClearAll";
            this.btClearAll.Text = "Стереть все игры турнира";
            this.btClearAll.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btClearAll_Click);
            // 
            // btExportZhereb
            // 
            this.btExportZhereb.Icon = ((System.Drawing.Icon)(resources.GetObject("btExportZhereb.Icon")));
            this.btExportZhereb.Key = "buttonCommand2";
            this.btExportZhereb.Name = "btExportZhereb";
            this.btExportZhereb.Text = "Экспорт общей жеребьевки в Excel";
            this.btExportZhereb.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btExportZhereb_Click);
            // 
            // SummaryScoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ContentCaption = "Общий итог";
            this.Controls.Add(this.GridEX);
            this.Controls.Add(this.ribbon1);
            this.Name = "SummaryScoreView";
            this.Size = new System.Drawing.Size(614, 511);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand buttonCommand1;
        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup6;
        private Janus.Windows.Ribbon.ButtonCommand btExport;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup7;
        private Janus.Windows.Ribbon.ButtonCommand btClearAll;
        private Janus.Windows.Ribbon.ButtonCommand btExportZhereb;
    }
}
