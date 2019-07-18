namespace ProductionSchedule.Forms.Sub_Forms
{
    partial class subfrmSelectWorkOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.lsvWorkOrders = new System.Windows.Forms.ListView();
            this.chWorkOrderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductWhse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProductionLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBatchNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPlannedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPlannedShift = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkFilterStatus = new System.Windows.Forms.CheckBox();
            this.lbxStatus = new System.Windows.Forms.ListBox();
            this.lbxProductType = new System.Windows.Forms.ListBox();
            this.chkFilterProductType = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Double click to select Work Order";
            // 
            // lsvWorkOrders
            // 
            this.lsvWorkOrders.AllowColumnReorder = true;
            this.lsvWorkOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWorkOrderNo,
            this.chProductType,
            this.chProductWhse,
            this.chProductNo,
            this.chProductionLine,
            this.chStatus,
            this.chBatchNo,
            this.chPlannedDate,
            this.chPlannedShift});
            this.lsvWorkOrders.FullRowSelect = true;
            this.lsvWorkOrders.GridLines = true;
            this.lsvWorkOrders.Location = new System.Drawing.Point(15, 25);
            this.lsvWorkOrders.Name = "lsvWorkOrders";
            this.lsvWorkOrders.Size = new System.Drawing.Size(694, 430);
            this.lsvWorkOrders.TabIndex = 2;
            this.lsvWorkOrders.UseCompatibleStateImageBehavior = false;
            this.lsvWorkOrders.View = System.Windows.Forms.View.Details;
            this.lsvWorkOrders.SelectedIndexChanged += new System.EventHandler(this.lsvWorkOrders_SelectedIndexChanged);
            this.lsvWorkOrders.DoubleClick += new System.EventHandler(this.lsvWorkOrders_DoubleClick);
            // 
            // chWorkOrderNo
            // 
            this.chWorkOrderNo.Text = "Work Order No";
            this.chWorkOrderNo.Width = 85;
            // 
            // chProductType
            // 
            this.chProductType.Text = "Prod. Type";
            this.chProductType.Width = 85;
            // 
            // chProductWhse
            // 
            this.chProductWhse.Text = "Whse";
            this.chProductWhse.Width = 45;
            // 
            // chProductNo
            // 
            this.chProductNo.Text = "Product No";
            this.chProductNo.Width = 150;
            // 
            // chProductionLine
            // 
            this.chProductionLine.Text = "Prod. Line";
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            // 
            // chBatchNo
            // 
            this.chBatchNo.Text = "Batch No.";
            // 
            // chPlannedDate
            // 
            this.chPlannedDate.Text = "Planned Date";
            this.chPlannedDate.Width = 85;
            // 
            // chPlannedShift
            // 
            this.chPlannedShift.Text = "Pl. Shift";
            // 
            // chkFilterStatus
            // 
            this.chkFilterStatus.AutoSize = true;
            this.chkFilterStatus.Location = new System.Drawing.Point(74, 461);
            this.chkFilterStatus.Name = "chkFilterStatus";
            this.chkFilterStatus.Size = new System.Drawing.Size(95, 17);
            this.chkFilterStatus.TabIndex = 3;
            this.chkFilterStatus.Text = "Filter by Status";
            this.chkFilterStatus.UseVisualStyleBackColor = true;
            this.chkFilterStatus.CheckedChanged += new System.EventHandler(this.chkFilterStatus_CheckedChanged);
            // 
            // lbxStatus
            // 
            this.lbxStatus.FormattingEnabled = true;
            this.lbxStatus.Location = new System.Drawing.Point(175, 461);
            this.lbxStatus.Name = "lbxStatus";
            this.lbxStatus.Size = new System.Drawing.Size(128, 69);
            this.lbxStatus.TabIndex = 4;
            this.lbxStatus.SelectedIndexChanged += new System.EventHandler(this.lstStatus_SelectedIndexChanged);
            // 
            // lbxProductType
            // 
            this.lbxProductType.FormattingEnabled = true;
            this.lbxProductType.Location = new System.Drawing.Point(461, 461);
            this.lbxProductType.Name = "lbxProductType";
            this.lbxProductType.Size = new System.Drawing.Size(128, 69);
            this.lbxProductType.TabIndex = 6;
            this.lbxProductType.SelectedIndexChanged += new System.EventHandler(this.lstProductType_SelectedIndexChanged);
            // 
            // chkFilterProductType
            // 
            this.chkFilterProductType.AutoSize = true;
            this.chkFilterProductType.Location = new System.Drawing.Point(338, 461);
            this.chkFilterProductType.Name = "chkFilterProductType";
            this.chkFilterProductType.Size = new System.Drawing.Size(117, 17);
            this.chkFilterProductType.TabIndex = 5;
            this.chkFilterProductType.Text = "Filter by Proct Type";
            this.chkFilterProductType.UseVisualStyleBackColor = true;
            this.chkFilterProductType.CheckedChanged += new System.EventHandler(this.chkFilterProductType_CheckedChanged);
            // 
            // subfrmSelectWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 542);
            this.Controls.Add(this.lbxProductType);
            this.Controls.Add(this.chkFilterProductType);
            this.Controls.Add(this.lbxStatus);
            this.Controls.Add(this.chkFilterStatus);
            this.Controls.Add(this.lsvWorkOrders);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "subfrmSelectWorkOrder";
            this.Text = "subfrmSelectWorkOrder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.subfrmSelectWorkOrder_FormClosing);
            this.Load += new System.EventHandler(this.subfrmSelectWorkOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvWorkOrders;
        private System.Windows.Forms.ColumnHeader chWorkOrderNo;
        private System.Windows.Forms.ColumnHeader chProductType;
        private System.Windows.Forms.ColumnHeader chProductNo;
        private System.Windows.Forms.ColumnHeader chProductionLine;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chBatchNo;
        private System.Windows.Forms.ColumnHeader chPlannedDate;
        private System.Windows.Forms.ColumnHeader chPlannedShift;
        private System.Windows.Forms.ColumnHeader chProductWhse;
        private System.Windows.Forms.CheckBox chkFilterStatus;
        private System.Windows.Forms.ListBox lbxStatus;
        private System.Windows.Forms.ListBox lbxProductType;
        private System.Windows.Forms.CheckBox chkFilterProductType;
    }
}