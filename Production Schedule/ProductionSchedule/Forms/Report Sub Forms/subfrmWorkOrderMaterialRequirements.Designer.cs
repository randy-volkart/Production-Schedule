namespace ProductionSchedule.Forms.Report_Sub_Forms
{
    partial class subfrmWorkOrderMaterialRequirements
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
            this.txtWorkOrder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxUseScrapYield = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWorkOrder
            // 
            this.txtWorkOrder.Location = new System.Drawing.Point(142, 12);
            this.txtWorkOrder.Name = "txtWorkOrder";
            this.txtWorkOrder.Size = new System.Drawing.Size(116, 20);
            this.txtWorkOrder.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Work Order:";
            // 
            // cbxUseScrapYield
            // 
            this.cbxUseScrapYield.AutoSize = true;
            this.cbxUseScrapYield.Location = new System.Drawing.Point(143, 38);
            this.cbxUseScrapYield.Name = "cbxUseScrapYield";
            this.cbxUseScrapYield.Size = new System.Drawing.Size(115, 17);
            this.cbxUseScrapYield.TabIndex = 17;
            this.cbxUseScrapYield.Text = "Use Scrap/Yield %";
            this.cbxUseScrapYield.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(142, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 23);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRunReport
            // 
            this.btnRunReport.Location = new System.Drawing.Point(15, 61);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(116, 23);
            this.btnRunReport.TabIndex = 58;
            this.btnRunReport.Text = "Run Report";
            this.btnRunReport.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(19, 108);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(243, 157);
            this.dgvResults.TabIndex = 60;
            // 
            // subfrmWorkOrderMaterialRequirements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 372);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.cbxUseScrapYield);
            this.Controls.Add(this.txtWorkOrder);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "subfrmWorkOrderMaterialRequirements";
            this.Text = "Work Order Material Requirements";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWorkOrder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbxUseScrapYield;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}