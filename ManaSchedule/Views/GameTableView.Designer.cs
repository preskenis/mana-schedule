namespace ManaSchedule.Views
{
    partial class GameTableView
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
            Crainiate.Diagramming.Forms.Paging paging1 = new Crainiate.Diagramming.Forms.Paging();
            Crainiate.Diagramming.Forms.Margin margin1 = new Crainiate.Diagramming.Forms.Margin();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameTableView));
            this.diagram = new Crainiate.Diagramming.Forms.Diagram();
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.btExportToExcel = new Janus.Windows.Ribbon.ButtonCommand();
            this.btExportToImage = new Janus.Windows.Ribbon.ButtonCommand();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // diagram
            // 
            this.diagram.AllowDrop = true;
            this.diagram.AutoScroll = true;
            this.diagram.AutoScrollMinSize = new System.Drawing.Size(834, 1163);
            this.diagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagram.DragElement = null;
            this.diagram.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.diagram.GridSize = new System.Drawing.Size(20, 20);
            this.diagram.Location = new System.Drawing.Point(0, 142);
            this.diagram.Name = "diagram";
            paging1.Enabled = true;
            margin1.Bottom = 0F;
            margin1.Left = 0F;
            margin1.Right = 0F;
            margin1.Top = 0F;
            paging1.Margin = margin1;
            paging1.Padding = new System.Drawing.SizeF(40F, 40F);
            paging1.Page = 1;
            paging1.PageSize = new System.Drawing.SizeF(793.7008F, 1122.52F);
            paging1.WorkspaceColor = System.Drawing.SystemColors.AppWorkspace;
            this.diagram.Paging = paging1;
            this.diagram.Size = new System.Drawing.Size(803, 215);
            this.diagram.TabIndex = 6;
            this.diagram.Zoom = 100F;
            this.diagram.ElementDoubleClick += new System.EventHandler(this.diagram_ElementDoubleClick);
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
            this.ribbon1.Size = new System.Drawing.Size(803, 142);
            // 
            // 
            // 
            this.ribbon1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbon1.SuperTipComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ribbon1.SuperTipComponent.ImageList = null;
            this.ribbon1.TabIndex = 11;
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
            this.btExportToExcel,
            this.btExportToImage});
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
            // btExportToImage
            // 
            this.btExportToImage.Icon = ((System.Drawing.Icon)(resources.GetObject("btExportToImage.Icon")));
            this.btExportToImage.Key = "buttonCommand2";
            this.btExportToImage.Name = "btExportToImage";
            this.btExportToImage.Text = "Экспорт изображения";
            this.btExportToImage.Click += new Janus.Windows.Ribbon.CommandEventHandler(this.btExportToImage_Click);
            // 
            // GameTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContentCaption = "Футбол";
            this.Controls.Add(this.diagram);
            this.Controls.Add(this.ribbon1);
            this.Name = "GameTableView";
            this.Size = new System.Drawing.Size(803, 357);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Crainiate.Diagramming.Forms.Diagram diagram;
        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand btExportToExcel;
        private Janus.Windows.Ribbon.ButtonCommand btExportToImage;


    }
}
