namespace ManaSchedule.Views
{
    partial class GameResultView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameResultView));
            this.stageTabs = new Janus.Windows.UI.Tab.UITab();
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btExportToExcel = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonGroup2 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btShowNames = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonGroup3 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btEndStage = new Janus.Windows.Ribbon.ButtonCommand();
            this.btRandom = new Janus.Windows.Ribbon.ButtonCommand();
            this.btImportToExcel = new Janus.Windows.Ribbon.ButtonCommand();
            ((System.ComponentModel.ISupportInitialize)(this.stageTabs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // stageTabs
            // 
            this.stageTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stageTabs.Location = new System.Drawing.Point(0, 142);
            this.stageTabs.Name = "stageTabs";
            this.stageTabs.Size = new System.Drawing.Size(591, 304);
            this.stageTabs.TabIndex = 6;
            this.stageTabs.VisualStyleManager = this.visualStyleManager;
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
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Name = "ribbon1";
            this.ribbon1.Size = new System.Drawing.Size(591, 142);
            // 
            // 
            // 
            this.ribbon1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbon1.SuperTipComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ribbon1.SuperTipComponent.ImageList = null;
            this.ribbon1.TabIndex = 7;
            this.ribbon1.Tabs.AddRange(new Janus.Windows.Ribbon.RibbonTab[] {
            this.ribbonTab1});
            this.ribbon1.Text = "";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.AddRange(new Janus.Windows.Ribbon.RibbonGroup[] {
            this.ribbonGroup1,
            this.ribbonGroup2,
            this.ribbonGroup3});
            this.ribbonTab1.Key = "ribbonTab1";
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Главная";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.btExportToExcel,
            this.btImportToExcel});
            this.ribbonGroup1.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup1;
            this.ribbonGroup1.Key = "ribbonGroup1";
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Данные";
            // 
            // btExportToExcel
            // 
            this.btExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btExportToExcel.Image")));
            this.btExportToExcel.Key = "buttonCommand1";
            this.btExportToExcel.Name = "btExportToExcel";
            this.btExportToExcel.Text = "Экспорт в Excel";
            this.btExportToExcel.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btExportToExcel_Click);
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.btShowNames});
            this.ribbonGroup2.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup2;
            this.ribbonGroup2.Key = "ribbonGroup2";
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Управление";
            // 
            // btShowNames
            // 
            this.btShowNames.CheckOnClick = true;
            this.btShowNames.Icon = ((System.Drawing.Icon)(resources.GetObject("btShowNames.Icon")));
            this.btShowNames.Key = "buttonCommand1";
            this.btShowNames.Name = "btShowNames";
            this.btShowNames.Text = "Показать судей";
            this.btShowNames.CheckedChanged += new Janus.Windows.Ribbon.CommandEventHandler(this.btShowNames_CheckedChanged);
            // 
            // ribbonGroup3
            // 
            this.ribbonGroup3.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.btEndStage,
            this.btRandom});
            this.ribbonGroup3.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup3;
            this.ribbonGroup3.Key = "ribbonGroup3";
            this.ribbonGroup3.Name = "ribbonGroup3";
            this.ribbonGroup3.Text = "Этап";
            // 
            // btEndStage
            // 
            this.btEndStage.Icon = ((System.Drawing.Icon)(resources.GetObject("btEndStage.Icon")));
            this.btEndStage.Key = "buttonCommand1";
            this.btEndStage.Name = "btEndStage";
            this.btEndStage.Text = "Завершить этап";
            this.btEndStage.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btEndStage_Click);
            // 
            // btRandom
            // 
            this.btRandom.Icon = ((System.Drawing.Icon)(resources.GetObject("btRandom.Icon")));
            this.btRandom.Key = "buttonCommand2";
            this.btRandom.Name = "btRandom";
            this.btRandom.Text = "Заполнить результаты случаныйми";
            this.btRandom.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btRandom_Click);
            // 
            // btImportToExcel
            // 
            this.btImportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btImportToExcel.Image")));
            this.btImportToExcel.Key = "buttonCommand1";
            this.btImportToExcel.Name = "btImportToExcel";
            this.btImportToExcel.Text = "Импорт оценок из Excel";
            this.btImportToExcel.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btImportToExcel_Click);
            // 
            // GameResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContentCaption = "Футбол";
            this.Controls.Add(this.stageTabs);
            this.Controls.Add(this.ribbon1);
            this.Name = "GameResultView";
            this.Size = new System.Drawing.Size(591, 446);
            ((System.ComponentModel.ISupportInitialize)(this.stageTabs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab stageTabs;
        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand btExportToExcel;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup2;
        private Janus.Windows.Ribbon.ButtonCommand btShowNames;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup3;
        private Janus.Windows.Ribbon.ButtonCommand btEndStage;
        private Janus.Windows.Ribbon.ButtonCommand btRandom;
        private Janus.Windows.Ribbon.ButtonCommand btImportToExcel;



    }
}
