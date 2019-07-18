namespace ProductionSchedule.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnsFile = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tspMainIcons = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companySelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedGoodsDailyStockStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawMaterialDailyStockStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workOrderMaterialRequirementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productionScheduleSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsFile.SuspendLayout();
            this.tspMainIcons.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsFile
            // 
            this.mnsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.printToolStripMenuItem});
            this.mnsFile.Location = new System.Drawing.Point(0, 0);
            this.mnsFile.Name = "mnsFile";
            this.mnsFile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mnsFile.Size = new System.Drawing.Size(912, 24);
            this.mnsFile.TabIndex = 5;
            this.mnsFile.Text = "&File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.companySelectionToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem2.Text = "E&xit";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(53, 20);
            this.toolStripMenuItem3.Text = "&Utilities";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.customerToolStripMenuItem.Text = "&Work Order";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // tspMainIcons
            // 
            this.tspMainIcons.AutoSize = false;
            this.tspMainIcons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.tsbWorkOrder,
            this.toolStripSeparator1});
            this.tspMainIcons.Location = new System.Drawing.Point(0, 24);
            this.tspMainIcons.Name = "tspMainIcons";
            this.tspMainIcons.Padding = new System.Windows.Forms.Padding(0);
            this.tspMainIcons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspMainIcons.Size = new System.Drawing.Size(912, 40);
            this.tspMainIcons.TabIndex = 6;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbWorkOrder
            // 
            this.tsbWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWorkOrder.Image = ((System.Drawing.Image)(resources.GetObject("tsbWorkOrder.Image")));
            this.tsbWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWorkOrder.Name = "tsbWorkOrder";
            this.tsbWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbWorkOrder.Text = "Work Order";
            this.tsbWorkOrder.ToolTipText = "Work Order";
            this.tsbWorkOrder.Click += new System.EventHandler(this.tsbWorkOrder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // txtCompany
            // 
            this.txtCompany.Enabled = false;
            this.txtCompany.Location = new System.Drawing.Point(712, 24);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(200, 20);
            this.txtCompany.TabIndex = 8;
            // 
            // txtUser
            // 
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(712, 44);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 12;
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Location = new System.Drawing.Point(812, 44);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(664, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Session:";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finishedGoodsDailyStockStatusToolStripMenuItem,
            this.rawMaterialDailyStockStatusToolStripMenuItem,
            this.workOrderMaterialRequirementsToolStripMenuItem,
            this.productionScheduleSummaryToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // companySelectionToolStripMenuItem
            // 
            this.companySelectionToolStripMenuItem.Name = "companySelectionToolStripMenuItem";
            this.companySelectionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.companySelectionToolStripMenuItem.Text = "&Company Selection";
            this.companySelectionToolStripMenuItem.Click += new System.EventHandler(this.companySelectionToolStripMenuItem_Click);
            // 
            // finishedGoodsDailyStockStatusToolStripMenuItem
            // 
            this.finishedGoodsDailyStockStatusToolStripMenuItem.Name = "finishedGoodsDailyStockStatusToolStripMenuItem";
            this.finishedGoodsDailyStockStatusToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.finishedGoodsDailyStockStatusToolStripMenuItem.Text = "&Finished Goods Daily Stock Status";
            this.finishedGoodsDailyStockStatusToolStripMenuItem.Click += new System.EventHandler(this.finishedGoodsDailyStockStatusToolStripMenuItem_Click);
            // 
            // rawMaterialDailyStockStatusToolStripMenuItem
            // 
            this.rawMaterialDailyStockStatusToolStripMenuItem.Name = "rawMaterialDailyStockStatusToolStripMenuItem";
            this.rawMaterialDailyStockStatusToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.rawMaterialDailyStockStatusToolStripMenuItem.Text = "&Raw Material Daily Stock Status";
            this.rawMaterialDailyStockStatusToolStripMenuItem.Click += new System.EventHandler(this.rawMaterialDailyStockStatusToolStripMenuItem_Click);
            // 
            // workOrderMaterialRequirementsToolStripMenuItem
            // 
            this.workOrderMaterialRequirementsToolStripMenuItem.Name = "workOrderMaterialRequirementsToolStripMenuItem";
            this.workOrderMaterialRequirementsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.workOrderMaterialRequirementsToolStripMenuItem.Text = "Work Order &Material Requirements";
            this.workOrderMaterialRequirementsToolStripMenuItem.Click += new System.EventHandler(this.workOrderMaterialRequirementsToolStripMenuItem_Click);
            // 
            // productionScheduleSummaryToolStripMenuItem
            // 
            this.productionScheduleSummaryToolStripMenuItem.Name = "productionScheduleSummaryToolStripMenuItem";
            this.productionScheduleSummaryToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.productionScheduleSummaryToolStripMenuItem.Text = "&Production Schedule Summary";
            this.productionScheduleSummaryToolStripMenuItem.Click += new System.EventHandler(this.productionScheduleSummaryToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 730);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.tspMainIcons);
            this.Controls.Add(this.mnsFile);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsFile;
            this.Name = "frmMain";
            this.Text = "Production Schedule";
            this.mnsFile.ResumeLayout(false);
            this.mnsFile.PerformLayout();
            this.tspMainIcons.ResumeLayout(false);
            this.tspMainIcons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        public System.Windows.Forms.ToolStrip tspMainIcons;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbWorkOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companySelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishedGoodsDailyStockStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawMaterialDailyStockStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workOrderMaterialRequirementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productionScheduleSummaryToolStripMenuItem;
    }
}

