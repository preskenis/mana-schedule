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
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.buttonCommand1 = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonGroup2 = new Janus.Windows.Ribbon.RibbonGroup();
            this.buttonCommand2 = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonGroup3 = new Janus.Windows.Ribbon.RibbonGroup();
            this.ribbonGroup4 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btExportExcel = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonGroup5 = new Janus.Windows.Ribbon.RibbonGroup();
            this.buttonCommand3 = new Janus.Windows.Ribbon.ButtonCommand();
            this.buttonCommand4 = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup6 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btExport = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonGroup7 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btClearAll = new Janus.Windows.Ribbon.ButtonCommand();
            this.btLoadCompanies = new Janus.Windows.Ribbon.ButtonCommand();
            this.btImportExcel = new Janus.Windows.Ribbon.ButtonCommand();
            this.btRandom = new Janus.Windows.Ribbon.ButtonCommand();
            this.separatorCommand1 = new Janus.Windows.Ribbon.SeparatorCommand();
            this.btGenerate = new Janus.Windows.Ribbon.ButtonCommand();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridEX
            // 
            this.GridEX.ColumnAutoResize = true;
            this.GridEX.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.ColumnHeader;
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridEX.GroupByBoxVisible = false;
            this.GridEX.Location = new System.Drawing.Point(0, 142);
            this.GridEX.Name = "GridEX";
            this.GridEX.RowHeaderContent = Janus.Windows.GridEX.RowHeaderContent.RowPosition;
            this.GridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.GridEX.Size = new System.Drawing.Size(831, 371);
            this.GridEX.TabIndex = 0;
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
            this.ribbonGroup1.Text = "Group 0";
            // 
            // buttonCommand1
            // 
            this.buttonCommand1.Key = "buttonCommand1";
            this.buttonCommand1.Name = "buttonCommand1";
            this.buttonCommand1.Text = "buttonCommand1";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.buttonCommand2});
            this.ribbonGroup2.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup2;
            this.ribbonGroup2.Key = "ribbonGroup2";
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Управление";
            // 
            // buttonCommand2
            // 
            this.buttonCommand2.Key = "buttonCommand2";
            this.buttonCommand2.Name = "buttonCommand2";
            this.buttonCommand2.Text = "buttonCommand2";
            // 
            // ribbonGroup3
            // 
            this.ribbonGroup3.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup3;
            this.ribbonGroup3.Key = "ribbonGroup3";
            this.ribbonGroup3.Name = "ribbonGroup3";
            this.ribbonGroup3.Text = "Group 0";
            // 
            // ribbonGroup4
            // 
            this.ribbonGroup4.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup4;
            this.ribbonGroup4.Key = "ribbonGroup4";
            this.ribbonGroup4.Name = "ribbonGroup4";
            this.ribbonGroup4.Text = "Group 1";
            // 
            // btExportExcel
            // 
            this.btExportExcel.Icon = ((System.Drawing.Icon)(resources.GetObject("btExportExcel.Icon")));
            this.btExportExcel.Key = "buttonCommand3";
            this.btExportExcel.Name = "btExportExcel";
            this.btExportExcel.Text = "Экспорт в эксель";
            // 
            // ribbonGroup5
            // 
            this.ribbonGroup5.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.buttonCommand3,
            this.buttonCommand4});
            this.ribbonGroup5.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup5;
            this.ribbonGroup5.Key = "ribbonGroup5";
            this.ribbonGroup5.Name = "ribbonGroup5";
            this.ribbonGroup5.Text = "Управление";
            // 
            // buttonCommand3
            // 
            this.buttonCommand3.Key = "buttonCommand3";
            this.buttonCommand3.Name = "buttonCommand3";
            this.buttonCommand3.Text = "Сформировать игры";
            // 
            // buttonCommand4
            // 
            this.buttonCommand4.Key = "buttonCommand4";
            this.buttonCommand4.Name = "buttonCommand4";
            this.buttonCommand4.Text = "Стереть игры";
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
            this.ribbon1.Size = new System.Drawing.Size(831, 142);
            // 
            // 
            // 
            this.ribbon1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbon1.SuperTipComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ribbon1.SuperTipComponent.ImageList = null;
            this.ribbon1.TabIndex = 12;
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
            this.btExport});
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
            this.btClearAll,
            this.btLoadCompanies,
            this.btImportExcel,
            this.btRandom,
            this.separatorCommand1,
            this.btGenerate});
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
            this.btClearAll.Text = "Стереть все игры";
            this.btClearAll.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btClearAll_Click);
            // 
            // btLoadCompanies
            // 
            this.btLoadCompanies.Icon = ((System.Drawing.Icon)(resources.GetObject("btLoadCompanies.Icon")));
            this.btLoadCompanies.Key = "buttonCommand7";
            this.btLoadCompanies.Name = "btLoadCompanies";
            this.btLoadCompanies.Text = "Загрузить все команды";
            this.btLoadCompanies.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btLoadCompanies_Click);
            // 
            // btImportExcel
            // 
            this.btImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btImportExcel.Image")));
            this.btImportExcel.Key = "buttonCommand5";
            this.btImportExcel.Name = "btImportExcel";
            this.btImportExcel.Text = "Импорт жеребьевки из Excel";
            this.btImportExcel.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btImportExcel_Click);
            // 
            // btRandom
            // 
            this.btRandom.Icon = ((System.Drawing.Icon)(resources.GetObject("btRandom.Icon")));
            this.btRandom.Key = "buttonCommand8";
            this.btRandom.Name = "btRandom";
            this.btRandom.Text = "Случайная жеребьевка";
            this.btRandom.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btRandom_Click);
            // 
            // separatorCommand1
            // 
            this.separatorCommand1.Key = "separatorCommand1";
            this.separatorCommand1.Name = "separatorCommand1";
            // 
            // btGenerate
            // 
            this.btGenerate.Icon = ((System.Drawing.Icon)(resources.GetObject("btGenerate.Icon")));
            this.btGenerate.Key = "buttonCommand6";
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Text = "Сформировать игры";
            this.btGenerate.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btGenerate_Click);
            // 
            // ZherebView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GridEX);
            this.Controls.Add(this.ribbon1);
            this.Name = "ZherebView";
            this.Size = new System.Drawing.Size(831, 513);
            this.Load += new System.EventHandler(this.ZherebView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand buttonCommand1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup2;
        private Janus.Windows.Ribbon.ButtonCommand buttonCommand2;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup3;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup4;
        private Janus.Windows.Ribbon.ButtonCommand btExportExcel;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup5;
        private Janus.Windows.Ribbon.ButtonCommand buttonCommand3;
        private Janus.Windows.Ribbon.ButtonCommand buttonCommand4;
        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup6;
        private Janus.Windows.Ribbon.ButtonCommand btExport;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup7;
        private Janus.Windows.Ribbon.ButtonCommand btClearAll;
        private Janus.Windows.Ribbon.ButtonCommand btLoadCompanies;
        private Janus.Windows.Ribbon.ButtonCommand btRandom;
        private Janus.Windows.Ribbon.SeparatorCommand separatorCommand1;
        private Janus.Windows.Ribbon.ButtonCommand btGenerate;
        private Janus.Windows.Ribbon.ButtonCommand btImportExcel;
    }
}
