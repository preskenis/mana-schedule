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
            this.diagram = new Crainiate.Diagramming.Forms.Diagram();
            this.SuspendLayout();
            // 
            // ContentCaption
            // 
            this.ContentCaption.Size = new System.Drawing.Size(82, 30);
            this.ContentCaption.Text = "Футбол";
            // 
            // diagram
            // 
            this.diagram.AllowDrop = true;
            this.diagram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagram.AutoScroll = true;
            this.diagram.AutoScrollMinSize = new System.Drawing.Size(834, 1163);
            this.diagram.DragElement = null;
            this.diagram.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.diagram.GridSize = new System.Drawing.Size(20, 20);
            this.diagram.Location = new System.Drawing.Point(3, 33);
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
            this.diagram.Size = new System.Drawing.Size(585, 321);
            this.diagram.TabIndex = 6;
            this.diagram.Zoom = 100F;
            this.diagram.ElementDoubleClick += new System.EventHandler(this.diagram_ElementDoubleClick);
            // 
            // GameTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.diagram);
            this.Name = "GameTableView";
            this.Size = new System.Drawing.Size(591, 357);
            this.Controls.SetChildIndex(this.ContentCaption, 0);
            this.Controls.SetChildIndex(this.diagram, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Crainiate.Diagramming.Forms.Diagram diagram;


    }
}
