namespace ProductionSchedule.Forms.Report_Sub_Forms
{
    partial class subfrmFinishedGoodsDailyStockStatus
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
            this.cboWhse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboProductCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProductNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdb14Days = new System.Windows.Forms.RadioButton();
            this.rdb28Days = new System.Windows.Forms.RadioButton();
            this.cbxHighlightCustomerOrderLine = new System.Windows.Forms.CheckBox();
            this.xbxShowFGwithZeroQty = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // cboWhse
            // 
            this.cboWhse.FormattingEnabled = true;
            this.cboWhse.Location = new System.Drawing.Point(141, 6);
            this.cboWhse.Name = "cboWhse";
            this.cboWhse.Size = new System.Drawing.Size(116, 21);
            this.cboWhse.TabIndex = 10;
            this.cboWhse.SelectedIndexChanged += new System.EventHandler(this.cboWhse_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Warehouse:";
            // 
            // cboProductCode
            // 
            this.cboProductCode.FormattingEnabled = true;
            this.cboProductCode.Location = new System.Drawing.Point(141, 33);
            this.cboProductCode.Name = "cboProductCode";
            this.cboProductCode.Size = new System.Drawing.Size(116, 21);
            this.cboProductCode.TabIndex = 12;
            this.cboProductCode.SelectedIndexChanged += new System.EventHandler(this.cboProductCode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Product Code:";
            // 
            // cboProductNo
            // 
            this.cboProductNo.FormattingEnabled = true;
            this.cboProductNo.Location = new System.Drawing.Point(141, 60);
            this.cboProductNo.Name = "cboProductNo";
            this.cboProductNo.Size = new System.Drawing.Size(116, 21);
            this.cboProductNo.TabIndex = 14;
            this.cboProductNo.SelectedIndexChanged += new System.EventHandler(this.cboProductNo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Product No:";
            // 
            // rdb14Days
            // 
            this.rdb14Days.AutoSize = true;
            this.rdb14Days.Location = new System.Drawing.Point(15, 87);
            this.rdb14Days.Name = "rdb14Days";
            this.rdb14Days.Size = new System.Drawing.Size(64, 17);
            this.rdb14Days.TabIndex = 15;
            this.rdb14Days.TabStop = true;
            this.rdb14Days.Text = "14 Days";
            this.rdb14Days.UseVisualStyleBackColor = true;
            // 
            // rdb28Days
            // 
            this.rdb28Days.AutoSize = true;
            this.rdb28Days.Location = new System.Drawing.Point(141, 87);
            this.rdb28Days.Name = "rdb28Days";
            this.rdb28Days.Size = new System.Drawing.Size(64, 17);
            this.rdb28Days.TabIndex = 16;
            this.rdb28Days.TabStop = true;
            this.rdb28Days.Text = "28 Days";
            this.rdb28Days.UseVisualStyleBackColor = true;
            // 
            // cbxHighlightCustomerOrderLine
            // 
            this.cbxHighlightCustomerOrderLine.AutoSize = true;
            this.cbxHighlightCustomerOrderLine.Location = new System.Drawing.Point(15, 110);
            this.cbxHighlightCustomerOrderLine.Name = "cbxHighlightCustomerOrderLine";
            this.cbxHighlightCustomerOrderLine.Size = new System.Drawing.Size(166, 17);
            this.cbxHighlightCustomerOrderLine.TabIndex = 17;
            this.cbxHighlightCustomerOrderLine.Text = "Highlight Customer Order Line";
            this.cbxHighlightCustomerOrderLine.UseVisualStyleBackColor = true;
            // 
            // xbxShowFGwithZeroQty
            // 
            this.xbxShowFGwithZeroQty.AutoSize = true;
            this.xbxShowFGwithZeroQty.Location = new System.Drawing.Point(15, 133);
            this.xbxShowFGwithZeroQty.Name = "xbxShowFGwithZeroQty";
            this.xbxShowFGwithZeroQty.Size = new System.Drawing.Size(174, 17);
            this.xbxShowFGwithZeroQty.TabIndex = 18;
            this.xbxShowFGwithZeroQty.Text = "Show FG with zero on hand qty";
            this.xbxShowFGwithZeroQty.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(141, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 23);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRunReport
            // 
            this.btnRunReport.Location = new System.Drawing.Point(14, 166);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(116, 23);
            this.btnRunReport.TabIndex = 60;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(285, 9);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(825, 180);
            this.dgvProducts.TabIndex = 64;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 212);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1136, 469);
            this.crystalReportViewer1.TabIndex = 65;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // subfrmFinishedGoodsDailyStockStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 681);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.xbxShowFGwithZeroQty);
            this.Controls.Add(this.cbxHighlightCustomerOrderLine);
            this.Controls.Add(this.rdb28Days);
            this.Controls.Add(this.rdb14Days);
            this.Controls.Add(this.cboProductNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProductCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboWhse);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "subfrmFinishedGoodsDailyStockStatus";
            this.Text = "FG Daily Stock Status";
            this.Load += new System.EventHandler(this.subfrmFinishedGoodsDailyStockStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboWhse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProductNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdb14Days;
        private System.Windows.Forms.RadioButton rdb28Days;
        private System.Windows.Forms.CheckBox cbxHighlightCustomerOrderLine;
        private System.Windows.Forms.CheckBox xbxShowFGwithZeroQty;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.DataGridView dgvProducts;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}