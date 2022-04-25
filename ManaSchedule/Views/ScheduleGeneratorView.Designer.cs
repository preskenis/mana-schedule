namespace ManaSchedule.Views
{
    partial class ScheduleGeneratorView
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
            Janus.Windows.GridEX.GridEXLayout GridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleGeneratorView));
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiGroupBox2 = new Janus.Windows.EditControls.UIGroupBox();
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.btGenerate = new Janus.Windows.EditControls.UIButton();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.schedule = new Janus.Windows.Schedule.Schedule();
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // uiTab1
            // 
            this.uiTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTab1.Location = new System.Drawing.Point(0, 142);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(1041, 418);
            this.uiTab1.TabIndex = 6;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1,
            this.uiTabPage2});
            this.uiTab1.VisualStyleManager = this.visualStyleManager;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.uiButton1);
            this.uiTabPage1.Controls.Add(this.uiGroupBox2);
            this.uiTabPage1.Controls.Add(this.uiGroupBox1);
            this.uiTabPage1.Controls.Add(this.btGenerate);
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(1039, 396);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Список этапов";
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(271, 109);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(66, 23);
            this.uiButton1.TabIndex = 5;
            this.uiButton1.Text = "-->";
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox2.Controls.Add(this.GridEX);
            this.uiGroupBox2.Location = new System.Drawing.Point(3, 3);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Size = new System.Drawing.Size(262, 358);
            this.uiGroupBox2.TabIndex = 4;
            this.uiGroupBox2.Text = "Доступные этапы";
            // 
            // GridEX
            // 
            this.GridEX.ColumnAutoResize = true;
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridEX.GroupByBoxVisible = false;
            this.GridEX.Location = new System.Drawing.Point(3, 16);
            this.GridEX.Name = "GridEX";
            this.GridEX.Size = new System.Drawing.Size(256, 339);
            this.GridEX.TabIndex = 0;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.VisualStyleManager = this.visualStyleManager;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.gridEX1);
            this.uiGroupBox1.Location = new System.Drawing.Point(343, 3);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Size = new System.Drawing.Size(693, 355);
            this.uiGroupBox1.TabIndex = 3;
            this.uiGroupBox1.Text = "Набор для генерации";
            // 
            // gridEX1
            // 
            this.gridEX1.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.ColumnAutoResize = true;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(3, 16);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.Size = new System.Drawing.Size(687, 336);
            this.gridEX1.TabIndex = 2;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridEX1.VisualStyleManager = this.visualStyleManager;
            // 
            // btGenerate
            // 
            this.btGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGenerate.Location = new System.Drawing.Point(3, 370);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(159, 23);
            this.btGenerate.TabIndex = 1;
            this.btGenerate.Text = "Распределить";
            this.btGenerate.VisualStyleManager = this.visualStyleManager;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // uiTabPage2
            // 
            this.uiTabPage2.Controls.Add(this.schedule);
            this.uiTabPage2.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage2.Name = "uiTabPage2";
            this.uiTabPage2.Size = new System.Drawing.Size(640, 365);
            this.uiTabPage2.TabStop = true;
            this.uiTabPage2.Text = "Календарь";
            // 
            // schedule
            // 
            this.schedule.Date = new System.DateTime(2015, 5, 9, 0, 0, 0, 0);
            this.schedule.Dates.Add(new System.DateTime(2015, 5, 9, 0, 0, 0, 0));
            this.schedule.Dates.Add(new System.DateTime(2015, 5, 10, 0, 0, 0, 0));
            this.schedule.Dates.Add(new System.DateTime(2015, 5, 11, 0, 0, 0, 0));
            this.schedule.DayEndHour = 13;
            this.schedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedule.Location = new System.Drawing.Point(0, 0);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(640, 365);
            this.schedule.TabIndex = 0;
            this.schedule.TimeFormat = Janus.Windows.Schedule.TimeFormat.TwentyFourHours;
            this.schedule.VerticalScrollPosition = 11;
            this.schedule.VisualStyleManager = this.visualStyleManager;
            this.schedule.WorkEndTime = System.TimeSpan.Parse("24.00:00:00");
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
            this.ribbon1.Size = new System.Drawing.Size(1041, 142);
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
            this.ribbonTab1.Key = "ribbonTab1";
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Главная";
            // 
            // ScheduleGeneratorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ContentCaption = "Распределение игр";
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.ribbon1);
            this.Name = "ScheduleGeneratorView";
            this.Size = new System.Drawing.Size(1041, 560);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox2)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.uiTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.Schedule.Schedule schedule;
        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.EditControls.UIButton btGenerate;
        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox2;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.GridEX.GridEX gridEX1;
    }
}
