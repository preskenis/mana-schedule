﻿namespace ManaSchedule.Views
{
    partial class GameListView2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameListView2));
            this.GridEX = new Janus.Windows.GridEX.GridEX();
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btEdit = new Janus.Windows.Ribbon.ButtonCommand();
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridEX
            // 
            this.GridEX.ColumnAutoResize = true;
            GridEX_DesignTimeLayout.LayoutString = resources.GetString("GridEX_DesignTimeLayout.LayoutString");
            this.GridEX.DesignTimeLayout = GridEX_DesignTimeLayout;
            this.GridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridEX.Location = new System.Drawing.Point(0, 142);
            this.GridEX.Name = "GridEX";
            this.GridEX.Size = new System.Drawing.Size(715, 364);
            this.GridEX.TabIndex = 6;
            this.GridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.GridEX.VisualStyleManager = this.visualStyleManager;
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
            this.ribbon1.Size = new System.Drawing.Size(715, 142);
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
            this.ribbonGroup1});
            this.ribbonTab1.Key = "ribbonTab1";
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Главная";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.btEdit});
            this.ribbonGroup1.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup1;
            this.ribbonGroup1.Key = "ribbonGroup1";
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Управление";
            // 
            // btEdit
            // 
            this.btEdit.Icon = ((System.Drawing.Icon)(resources.GetObject("btEdit.Icon")));
            this.btEdit.Key = "buttonCommand1";
            this.btEdit.Name = "btEdit";
            this.btEdit.Text = "Ручная правка";
            // 
            // GameListView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContentCaption = "Футбол";
            this.Controls.Add(this.GridEX);
            this.Controls.Add(this.ribbon1);
            this.Name = "GameListView2";
            this.Size = new System.Drawing.Size(715, 506);
            ((System.ComponentModel.ISupportInitialize)(this.GridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX GridEX;
        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand btEdit;


    }
}
