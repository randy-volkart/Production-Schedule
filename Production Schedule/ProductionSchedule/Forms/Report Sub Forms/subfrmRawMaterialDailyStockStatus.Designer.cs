namespace ProductionSchedule.Forms.Report_Sub_Forms
{
    partial class subfrmRawMaterialDailyStockStatus
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.cbxIgnorePOBalance = new System.Windows.Forms.CheckBox();
            this.cbxBackFGWODate = new System.Windows.Forms.CheckBox();
            this.rdb28Days = new System.Windows.Forms.RadioButton();
            this.rdb14Days = new System.Windows.Forms.RadioButton();
            this.cboProductNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProductCode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbBuy = new System.Windows.Forms.RadioButton();
            this.rdbInventory = new System.Windows.Forms.RadioButton();
            this.rdbProduction = new System.Windows.Forms.RadioButton();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(141, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 23);
            this.btnCancel.TabIndex = 74;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRunReport
            // 
            this.btnRunReport.Location = new System.Drawing.Point(14, 166);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(116, 23);
            this.btnRunReport.TabIndex = 73;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // cbxIgnorePOBalance
            // 
            this.cbxIgnorePOBalance.AutoSize = true;
            this.cbxIgnorePOBalance.Location = new System.Drawing.Point(15, 133);
            this.cbxIgnorePOBalance.Name = "cbxIgnorePOBalance";
            this.cbxIgnorePOBalance.Size = new System.Drawing.Size(198, 17);
            this.cbxIgnorePOBalance.TabIndex = 72;
            this.cbxIgnorePOBalance.Text = "Ignore PO Balance (Back Order Qty)";
            this.cbxIgnorePOBalance.UseVisualStyleBackColor = true;
            // 
            // cbxBackFGWODate
            // 
            this.cbxBackFGWODate.AutoSize = true;
            this.cbxBackFGWODate.Location = new System.Drawing.Point(15, 110);
            this.cbxBackFGWODate.Name = "cbxBackFGWODate";
            this.cbxBackFGWODate.Size = new System.Drawing.Size(216, 17);
            this.cbxBackFGWODate.TabIndex = 71;
            this.cbxBackFGWODate.Text = "Back FG WO Date based on Lead Time";
            this.cbxBackFGWODate.UseVisualStyleBackColor = true;
            // 
            // rdb28Days
            // 
            this.rdb28Days.AutoSize = true;
            this.rdb28Days.Location = new System.Drawing.Point(141, 87);
            this.rdb28Days.Name = "rdb28Days";
            this.rdb28Days.Size = new System.Drawing.Size(64, 17);
            this.rdb28Days.TabIndex = 69;
            this.rdb28Days.TabStop = true;
            this.rdb28Days.Text = "28 Days";
            this.rdb28Days.UseVisualStyleBackColor = true;
            // 
            // rdb14Days
            // 
            this.rdb14Days.AutoSize = true;
            this.rdb14Days.Location = new System.Drawing.Point(15, 87);
            this.rdb14Days.Name = "rdb14Days";
            this.rdb14Days.Size = new System.Drawing.Size(64, 17);
            this.rdb14Days.TabIndex = 68;
            this.rdb14Days.TabStop = true;
            this.rdb14Days.Text = "14 Days";
            this.rdb14Days.UseVisualStyleBackColor = true;
            // 
            // cboProductNo
            // 
            this.cboProductNo.FormattingEnabled = true;
            this.cboProductNo.Location = new System.Drawing.Point(141, 39);
            this.cboProductNo.Name = "cboProductNo";
            this.cboProductNo.Size = new System.Drawing.Size(116, 21);
            this.cboProductNo.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Product No:";
            // 
            // cboProductCode
            // 
            this.cboProductCode.FormattingEnabled = true;
            this.cboProductCode.Location = new System.Drawing.Point(141, 12);
            this.cboProductCode.Name = "cboProductCode";
            this.cboProductCode.Size = new System.Drawing.Size(116, 21);
            this.cboProductCode.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Product Code:";
            // 
            // rdbBuy
            // 
            this.rdbBuy.AutoSize = true;
            this.rdbBuy.Location = new System.Drawing.Point(107, 66);
            this.rdbBuy.Name = "rdbBuy";
            this.rdbBuy.Size = new System.Drawing.Size(43, 17);
            this.rdbBuy.TabIndex = 69;
            this.rdbBuy.TabStop = true;
            this.rdbBuy.Text = "Buy";
            this.rdbBuy.UseVisualStyleBackColor = true;
            // 
            // rdbInventory
            // 
            this.rdbInventory.AutoSize = true;
            this.rdbInventory.Location = new System.Drawing.Point(15, 66);
            this.rdbInventory.Name = "rdbInventory";
            this.rdbInventory.Size = new System.Drawing.Size(69, 17);
            this.rdbInventory.TabIndex = 68;
            this.rdbInventory.TabStop = true;
            this.rdbInventory.Text = "Inventory";
            this.rdbInventory.UseVisualStyleBackColor = true;
            // 
            // rdbProduction
            // 
            this.rdbProduction.AutoSize = true;
            this.rdbProduction.Location = new System.Drawing.Point(181, 66);
            this.rdbProduction.Name = "rdbProduction";
            this.rdbProduction.Size = new System.Drawing.Size(76, 17);
            this.rdbProduction.TabIndex = 70;
            this.rdbProduction.TabStop = true;
            this.rdbProduction.Text = "Production";
            this.rdbProduction.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(18, 195);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(243, 157);
            this.dgvResults.TabIndex = 75;
            // 
            // subfrmRawMaterialDailyStockStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 415);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.rdbProduction);
            this.Controls.Add(this.rdbBuy);
            this.Controls.Add(this.rdbInventory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.cbxIgnorePOBalance);
            this.Controls.Add(this.cbxBackFGWODate);
            this.Controls.Add(this.rdb28Days);
            this.Controls.Add(this.rdb14Days);
            this.Controls.Add(this.cboProductNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProductCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "subfrmRawMaterialDailyStockStatus";
            this.Text = "RM Daily Stock Status";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.CheckBox cbxIgnorePOBalance;
        private System.Windows.Forms.CheckBox cbxBackFGWODate;
        private System.Windows.Forms.RadioButton rdb28Days;
        private System.Windows.Forms.RadioButton rdb14Days;
        private System.Windows.Forms.ComboBox cboProductNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbBuy;
        private System.Windows.Forms.RadioButton rdbInventory;
        private System.Windows.Forms.RadioButton rdbProduction;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}