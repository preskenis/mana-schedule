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
            this.label1 = new System.Windows.Forms.Label();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.btGenerate = new Janus.Windows.EditControls.UIButton();
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.schedule = new Janus.Windows.Schedule.Schedule();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentCaption
            // 
            this.ContentCaption.Size = new System.Drawing.Size(198, 30);
            this.ContentCaption.Text = "Распределение игр";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Общий зачёт";
            // 
            // uiTab1
            // 
            this.uiTab1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTab1.Location = new System.Drawing.Point(8, 33);
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.Size = new System.Drawing.Size(642, 387);
            this.uiTab1.TabIndex = 6;
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1,
            this.uiTabPage2});
            this.uiTab1.VisualStyleManager = this.visualStyleManager;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.btGenerate);
            this.uiTabPage1.Controls.Add(this.GridEX);
            this.uiTabPage1.Location = new System.Drawing.Point(1, 21);
            this.uiTabPage1.Name = "uiTabPage1";
            this.uiTabPage1.Size = new System.Drawing.Size(640, 365);
            this.uiTabPage1.TabStop = true;
            this.uiTabPage1.Text = "Список этапов";
            // 
            // btGenerate
            // 
            this.btGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btGenerate.Location = new System.Drawing.Point(3, 339);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(159, 23);
            this.btGenerate.TabIndex = 1;
            this.btGenerate.Text = "Распределить";
            this.btGenerate.VisualStyleManager = this.visualStyleManager;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // GridEX
            // 
            this.GridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridEX.ColumnAutoResize = true;
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Location = new System.Drawing.Point(3, 3);
            this.GridEX.Name = "GridEX";
            this.GridEX.Size = new System.Drawing.Size(634, 330);
            this.GridEX.TabIndex = 0;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.VisualStyleManager = this.visualStyleManager;
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
            // ScheduleGeneratorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.uiTab1);
            this.Controls.Add(this.label1);
            this.Name = "ScheduleGeneratorView";
            this.Size = new System.Drawing.Size(653, 423);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ContentCaption, 0);
            this.Controls.SetChildIndex(this.uiTab1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            this.uiTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.Schedule.Schedule schedule;
        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.EditControls.UIButton btGenerate;
    }
}
