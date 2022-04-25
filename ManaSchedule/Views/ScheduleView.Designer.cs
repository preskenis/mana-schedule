namespace ManaSchedule.Views
{
    partial class ScheduleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleView));
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.schedule = new Janus.Windows.Schedule.Schedule();
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
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
            this.uiTab1.Size = new System.Drawing.Size(653, 373);
            this.uiTab1.TabIndex = 6;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1,
            this.uiTabPage2});
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(649, 349);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Список";
            // 
            // uiTabPage2
            // 
            this.uiTabPage2.Controls.Add(this.schedule);
            this.uiTabPage2.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage2.Name = "uiTabPage2";
            this.uiTabPage2.Size = new System.Drawing.Size(649, 349);
            this.uiTabPage2.TabStop = true;
            this.uiTabPage2.Text = "Календарь";
            // 
            // schedule
            // 
            this.schedule.Date = new System.DateTime(2015, 5, 9, 0, 0, 0, 0);
            this.schedule.Dates.Add(new System.DateTime(2015, 5, 9, 0, 0, 0, 0));
            this.schedule.Dates.Add(new System.DateTime(2015, 5, 10, 0, 0, 0, 0));
            this.schedule.Dates.Add(new System.DateTime(2015, 5, 11, 0, 0, 0, 0));
            this.schedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedule.Location = new System.Drawing.Point(0, 0);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(649, 349);
            this.schedule.TabIndex = 0;
            this.schedule.TimeFormat = Janus.Windows.Schedule.TimeFormat.TwentyFourHours;
            this.schedule.VerticalScrollPosition = 16;
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
            this.ribbon1.Size = new System.Drawing.Size(653, 142);
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
            // ScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ContentCaption = "Расписание";
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.ribbon1);
            this.Name = "ScheduleView";
            this.Size = new System.Drawing.Size(653, 515);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
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
        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
    }
}
