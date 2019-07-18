namespace ProductionSchedule.Forms
{
    partial class frmProductionSchedule
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWorkOrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.cboItemCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.cboProductionLine = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlannedQuantity = new System.Windows.Forms.TextBox();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProductionLineCapacity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtReOrderPoint = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpPlannedDate = new System.Windows.Forms.DateTimePicker();
            this.txtPlannedShift = new System.Windows.Forms.TextBox();
            this.cboCustomerOrderNo = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboFGWorkOrderNo = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtActualManufacturedQty = new System.Windows.Forms.TextBox();
            this.dtpActualDate = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCreatedDate = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCreatedUser = new System.Windows.Forms.TextBox();
            this.txtLastModifiedDate = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tspMainIcons = new System.Windows.Forms.ToolStrip();
            this.tsbNewWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbCopyWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFirstWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbPreviousWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbNextWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbLastWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbIssue = new System.Windows.Forms.ToolStripButton();
            this.tsbComplete = new System.Windows.Forms.ToolStripButton();
            this.tsbCanceled = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrintWorkOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtActualShift = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPlannedUOM = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslState = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtReasonForChange = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLastModifiedUser = new System.Windows.Forms.TextBox();
            this.erpItemCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.bgwState = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnOpenWorkOrder = new System.Windows.Forms.Button();
            this.tspMainIcons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpItemCode)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Work Order No:";
            // 
            // txtWorkOrderNo
            // 
            this.txtWorkOrderNo.Enabled = false;
            this.txtWorkOrderNo.Location = new System.Drawing.Point(138, 16);
            this.txtWorkOrderNo.Name = "txtWorkOrderNo";
            this.txtWorkOrderNo.Size = new System.Drawing.Size(116, 20);
            this.txtWorkOrderNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Production Type:";
            // 
            // cboProductType
            // 
            this.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Items.AddRange(new object[] {
            "In Process",
            "Finished Goods"});
            this.cboProductType.Location = new System.Drawing.Point(138, 42);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(116, 21);
            this.cboProductType.TabIndex = 4;
            this.cboProductType.SelectedIndexChanged += new System.EventHandler(this.cboProductType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Warehouse:";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(138, 19);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(116, 21);
            this.cboWarehouse.TabIndex = 8;
            this.cboWarehouse.SelectedIndexChanged += new System.EventHandler(this.cboWarehouse_SelectedIndexChanged);
            // 
            // cboItemCode
            // 
            this.cboItemCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemCode.FormattingEnabled = true;
            this.cboItemCode.Location = new System.Drawing.Point(399, 19);
            this.cboItemCode.Name = "cboItemCode";
            this.cboItemCode.Size = new System.Drawing.Size(116, 21);
            this.cboItemCode.TabIndex = 10;
            this.cboItemCode.SelectedIndexChanged += new System.EventHandler(this.cboItemCode_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Item Code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Item Description:";
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Enabled = false;
            this.txtItemDescription.Location = new System.Drawing.Point(138, 46);
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.Size = new System.Drawing.Size(377, 20);
            this.txtItemDescription.TabIndex = 12;
            this.txtItemDescription.TabStop = false;
            // 
            // cboProductionLine
            // 
            this.cboProductionLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductionLine.FormattingEnabled = true;
            this.cboProductionLine.Location = new System.Drawing.Point(399, 42);
            this.cboProductionLine.Name = "cboProductionLine";
            this.cboProductionLine.Size = new System.Drawing.Size(116, 21);
            this.cboProductionLine.TabIndex = 6;
            this.cboProductionLine.SelectedIndexChanged += new System.EventHandler(this.cboProductionLine_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Production Line:";
            // 
            // txtPlannedQuantity
            // 
            this.txtPlannedQuantity.Location = new System.Drawing.Point(138, 56);
            this.txtPlannedQuantity.Name = "txtPlannedQuantity";
            this.txtPlannedQuantity.Size = new System.Drawing.Size(116, 20);
            this.txtPlannedQuantity.TabIndex = 16;
            this.txtPlannedQuantity.TextChanged += new System.EventHandler(this.txtPlannedQuantity_TextChanged);
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Enabled = false;
            this.txtBatchSize.Location = new System.Drawing.Point(399, 42);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(116, 20);
            this.txtBatchSize.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Batch Size:";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(138, 42);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(116, 20);
            this.txtBatchNo.TabIndex = 27;
            this.txtBatchNo.TextChanged += new System.EventHandler(this.txtBatchNo_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Batch No:";
            // 
            // txtProductionLineCapacity
            // 
            this.txtProductionLineCapacity.Location = new System.Drawing.Point(138, 16);
            this.txtProductionLineCapacity.Name = "txtProductionLineCapacity";
            this.txtProductionLineCapacity.Size = new System.Drawing.Size(116, 20);
            this.txtProductionLineCapacity.TabIndex = 23;
            this.txtProductionLineCapacity.TextChanged += new System.EventHandler(this.txtProductionLineCapacity_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Production Line Capacity:";
            // 
            // txtReOrderPoint
            // 
            this.txtReOrderPoint.Enabled = false;
            this.txtReOrderPoint.Location = new System.Drawing.Point(399, 16);
            this.txtReOrderPoint.Name = "txtReOrderPoint";
            this.txtReOrderPoint.Size = new System.Drawing.Size(116, 20);
            this.txtReOrderPoint.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(293, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Re-Order Point:";
            // 
            // dtpPlannedDate
            // 
            this.dtpPlannedDate.CustomFormat = "MM/dd/yyyy";
            this.dtpPlannedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlannedDate.Location = new System.Drawing.Point(138, 82);
            this.dtpPlannedDate.Name = "dtpPlannedDate";
            this.dtpPlannedDate.Size = new System.Drawing.Size(116, 20);
            this.dtpPlannedDate.TabIndex = 18;
            this.dtpPlannedDate.ValueChanged += new System.EventHandler(this.dtpPlannedDate_ValueChanged);
            // 
            // txtPlannedShift
            // 
            this.txtPlannedShift.Location = new System.Drawing.Point(138, 108);
            this.txtPlannedShift.Name = "txtPlannedShift";
            this.txtPlannedShift.Size = new System.Drawing.Size(116, 20);
            this.txtPlannedShift.TabIndex = 20;
            this.txtPlannedShift.TextChanged += new System.EventHandler(this.txtPlannedShift_TextChanged);
            // 
            // cboCustomerOrderNo
            // 
            this.cboCustomerOrderNo.FormattingEnabled = true;
            this.cboCustomerOrderNo.Location = new System.Drawing.Point(138, 68);
            this.cboCustomerOrderNo.Name = "cboCustomerOrderNo";
            this.cboCustomerOrderNo.Size = new System.Drawing.Size(116, 21);
            this.cboCustomerOrderNo.TabIndex = 31;
            this.cboCustomerOrderNo.SelectedIndexChanged += new System.EventHandler(this.cboCustomerOrderNo_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "Customer Order No:";
            // 
            // cboFGWorkOrderNo
            // 
            this.cboFGWorkOrderNo.FormattingEnabled = true;
            this.cboFGWorkOrderNo.Location = new System.Drawing.Point(399, 68);
            this.cboFGWorkOrderNo.Name = "cboFGWorkOrderNo";
            this.cboFGWorkOrderNo.Size = new System.Drawing.Size(116, 21);
            this.cboFGWorkOrderNo.TabIndex = 33;
            this.cboFGWorkOrderNo.SelectedIndexChanged += new System.EventHandler(this.cboFGWorkOrderNo_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(293, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "FG Work Order No:";
            // 
            // txtActualManufacturedQty
            // 
            this.txtActualManufacturedQty.Location = new System.Drawing.Point(130, 60);
            this.txtActualManufacturedQty.Name = "txtActualManufacturedQty";
            this.txtActualManufacturedQty.Size = new System.Drawing.Size(116, 20);
            this.txtActualManufacturedQty.TabIndex = 37;
            this.txtActualManufacturedQty.TextChanged += new System.EventHandler(this.txtActualManufacturedQty_TextChanged);
            // 
            // dtpActualDate
            // 
            this.dtpActualDate.CustomFormat = "MM/dd/yyyy";
            this.dtpActualDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActualDate.Location = new System.Drawing.Point(130, 86);
            this.dtpActualDate.Name = "dtpActualDate";
            this.dtpActualDate.Size = new System.Drawing.Size(116, 20);
            this.dtpActualDate.TabIndex = 41;
            this.dtpActualDate.ValueChanged += new System.EventHandler(this.dtpActualDate_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(293, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 40;
            this.label20.Text = "Status:";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(138, 19);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(377, 51);
            this.txtComments.TabIndex = 43;
            this.txtComments.TextChanged += new System.EventHandler(this.txtComments_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 42;
            this.label21.Text = "Comments:";
            // 
            // txtCreatedDate
            // 
            this.txtCreatedDate.Enabled = false;
            this.txtCreatedDate.Location = new System.Drawing.Point(138, 102);
            this.txtCreatedDate.Name = "txtCreatedDate";
            this.txtCreatedDate.Size = new System.Drawing.Size(55, 20);
            this.txtCreatedDate.TabIndex = 45;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 105);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 44;
            this.label22.Text = "Created:";
            // 
            // txtCreatedUser
            // 
            this.txtCreatedUser.Enabled = false;
            this.txtCreatedUser.Location = new System.Drawing.Point(199, 102);
            this.txtCreatedUser.Name = "txtCreatedUser";
            this.txtCreatedUser.Size = new System.Drawing.Size(55, 20);
            this.txtCreatedUser.TabIndex = 47;
            // 
            // txtLastModifiedDate
            // 
            this.txtLastModifiedDate.Enabled = false;
            this.txtLastModifiedDate.Location = new System.Drawing.Point(399, 102);
            this.txtLastModifiedDate.Name = "txtLastModifiedDate";
            this.txtLastModifiedDate.Size = new System.Drawing.Size(55, 20);
            this.txtLastModifiedDate.TabIndex = 49;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(293, 105);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 13);
            this.label25.TabIndex = 48;
            this.label25.Text = "Last Modified:";
            // 
            // tspMainIcons
            // 
            this.tspMainIcons.AutoSize = false;
            this.tspMainIcons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewWorkOrder,
            this.tsbSaveWorkOrder,
            this.tsbCopyWorkOrder,
            this.tsbRefresh,
            this.tsbDeleteWorkOrder,
            this.toolStripSeparator6,
            this.tsbFirstWorkOrder,
            this.tsbPreviousWorkOrder,
            this.tsbNextWorkOrder,
            this.tsbLastWorkOrder,
            this.toolStripSeparator5,
            this.tsbIssue,
            this.tsbComplete,
            this.tsbCanceled,
            this.toolStripSeparator7,
            this.tsbPrintWorkOrder,
            this.toolStripSeparator1,
            this.tsbClose});
            this.tspMainIcons.Location = new System.Drawing.Point(0, 0);
            this.tspMainIcons.Name = "tspMainIcons";
            this.tspMainIcons.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tspMainIcons.Size = new System.Drawing.Size(536, 40);
            this.tspMainIcons.TabIndex = 57;
            // 
            // tsbNewWorkOrder
            // 
            this.tsbNewWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_new;
            this.tsbNewWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNewWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewWorkOrder.Name = "tsbNewWorkOrder";
            this.tsbNewWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbNewWorkOrder.Text = "New";
            this.tsbNewWorkOrder.Click += new System.EventHandler(this.tsbNewWorkOrder_Click);
            // 
            // tsbSaveWorkOrder
            // 
            this.tsbSaveWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_save;
            this.tsbSaveWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSaveWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveWorkOrder.Name = "tsbSaveWorkOrder";
            this.tsbSaveWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbSaveWorkOrder.Text = "Save";
            this.tsbSaveWorkOrder.Click += new System.EventHandler(this.tsbSaveWorkOrder_Click);
            // 
            // tsbCopyWorkOrder
            // 
            this.tsbCopyWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopyWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_copy;
            this.tsbCopyWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCopyWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopyWorkOrder.Name = "tsbCopyWorkOrder";
            this.tsbCopyWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbCopyWorkOrder.Text = "Copy";
            this.tsbCopyWorkOrder.Click += new System.EventHandler(this.tsbCopyWorkOrder_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::ProductionSchedule.Properties.Resources.icon_refresh;
            this.tsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(36, 37);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbDeleteWorkOrder
            // 
            this.tsbDeleteWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_delete;
            this.tsbDeleteWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDeleteWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteWorkOrder.Name = "tsbDeleteWorkOrder";
            this.tsbDeleteWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbDeleteWorkOrder.Text = "Delete";
            this.tsbDeleteWorkOrder.Click += new System.EventHandler(this.tsbDeleteWorkOrder_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbFirstWorkOrder
            // 
            this.tsbFirstWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFirstWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_first;
            this.tsbFirstWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFirstWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirstWorkOrder.Name = "tsbFirstWorkOrder";
            this.tsbFirstWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbFirstWorkOrder.Text = "First Work Order";
            this.tsbFirstWorkOrder.Click += new System.EventHandler(this.tsbFirstWorkOrder_Click);
            // 
            // tsbPreviousWorkOrder
            // 
            this.tsbPreviousWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreviousWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_left;
            this.tsbPreviousWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPreviousWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreviousWorkOrder.Name = "tsbPreviousWorkOrder";
            this.tsbPreviousWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbPreviousWorkOrder.Text = "Previous Work Order";
            this.tsbPreviousWorkOrder.Click += new System.EventHandler(this.tsbPreviousWorkOrder_Click);
            // 
            // tsbNextWorkOrder
            // 
            this.tsbNextWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNextWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_right;
            this.tsbNextWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNextWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNextWorkOrder.Name = "tsbNextWorkOrder";
            this.tsbNextWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbNextWorkOrder.Text = "Next Work Order";
            this.tsbNextWorkOrder.Click += new System.EventHandler(this.tsbNextWorkOrder_Click);
            // 
            // tsbLastWorkOrder
            // 
            this.tsbLastWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLastWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_last;
            this.tsbLastWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLastWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLastWorkOrder.Name = "tsbLastWorkOrder";
            this.tsbLastWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbLastWorkOrder.Text = "Last Work Order";
            this.tsbLastWorkOrder.Click += new System.EventHandler(this.tsbLastWorkOrder_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbIssue
            // 
            this.tsbIssue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbIssue.Image = global::ProductionSchedule.Properties.Resources.icon_issued;
            this.tsbIssue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbIssue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIssue.Name = "tsbIssue";
            this.tsbIssue.Size = new System.Drawing.Size(36, 37);
            this.tsbIssue.Text = "Issue";
            this.tsbIssue.Click += new System.EventHandler(this.tspIssue_Click);
            // 
            // tsbComplete
            // 
            this.tsbComplete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbComplete.Enabled = false;
            this.tsbComplete.Image = global::ProductionSchedule.Properties.Resources.icon_completed;
            this.tsbComplete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbComplete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbComplete.Name = "tsbComplete";
            this.tsbComplete.Size = new System.Drawing.Size(36, 37);
            this.tsbComplete.Text = "Completed";
            this.tsbComplete.Click += new System.EventHandler(this.tspComplete_Click);
            // 
            // tsbCanceled
            // 
            this.tsbCanceled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCanceled.Enabled = false;
            this.tsbCanceled.Image = global::ProductionSchedule.Properties.Resources.icon_canceled;
            this.tsbCanceled.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCanceled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCanceled.Name = "tsbCanceled";
            this.tsbCanceled.Size = new System.Drawing.Size(36, 37);
            this.tsbCanceled.Text = "Canceled";
            this.tsbCanceled.Click += new System.EventHandler(this.tsbCanceled_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbPrintWorkOrder
            // 
            this.tsbPrintWorkOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintWorkOrder.Image = global::ProductionSchedule.Properties.Resources.icon_print;
            this.tsbPrintWorkOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrintWorkOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintWorkOrder.Name = "tsbPrintWorkOrder";
            this.tsbPrintWorkOrder.Size = new System.Drawing.Size(36, 37);
            this.tsbPrintWorkOrder.Text = "Print";
            this.tsbPrintWorkOrder.Click += new System.EventHandler(this.tsbPrintWorkOrder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = global::ProductionSchedule.Properties.Resources.icon_close;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(36, 37);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 530);
            this.panel1.TabIndex = 58;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboWarehouse);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboItemCode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtItemDescription);
            this.groupBox2.Location = new System.Drawing.Point(0, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 79);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.txtActualManufacturedQty);
            this.groupBox4.Controls.Add(this.txtActualShift);
            this.groupBox4.Controls.Add(this.dtpActualDate);
            this.groupBox4.Location = new System.Drawing.Point(269, 139);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 144);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Quantity:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "Date:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 115);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 45;
            this.label14.Text = "Shift:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(127, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(106, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "Actual Manufactured";
            // 
            // txtActualShift
            // 
            this.txtActualShift.Location = new System.Drawing.Point(130, 112);
            this.txtActualShift.Name = "txtActualShift";
            this.txtActualShift.Size = new System.Drawing.Size(116, 20);
            this.txtActualShift.TabIndex = 39;
            this.txtActualShift.TextChanged += new System.EventHandler(this.txtActualShift_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtPlannedUOM);
            this.groupBox3.Controls.Add(this.txtPlannedQuantity);
            this.groupBox3.Controls.Add(this.dtpPlannedDate);
            this.groupBox3.Controls.Add(this.txtPlannedShift);
            this.groupBox3.Location = new System.Drawing.Point(0, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 140);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "UOM:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(8, 56);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 31;
            this.label30.Text = "Quantity:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(8, 82);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(33, 13);
            this.label31.TabIndex = 32;
            this.label31.Text = "Date:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(8, 108);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(31, 13);
            this.label32.TabIndex = 33;
            this.label32.Text = "Shift:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(135, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 29;
            this.label23.Text = "Planned";
            // 
            // txtPlannedUOM
            // 
            this.txtPlannedUOM.Enabled = false;
            this.txtPlannedUOM.Location = new System.Drawing.Point(138, 30);
            this.txtPlannedUOM.Name = "txtPlannedUOM";
            this.txtPlannedUOM.Size = new System.Drawing.Size(116, 20);
            this.txtPlannedUOM.TabIndex = 14;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(536, 22);
            this.statusStrip1.TabIndex = 54;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslState
            // 
            this.tslState.Name = "tslState";
            this.tslState.Size = new System.Drawing.Size(33, 17);
            this.tslState.Text = "State";
            this.tslState.TextChanged += new System.EventHandler(this.tslState_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtProductionLineCapacity);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtReOrderPoint);
            this.groupBox5.Controls.Add(this.txtBatchNo);
            this.groupBox5.Controls.Add(this.txtBatchSize);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.cboCustomerOrderNo);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.cboFGWorkOrderNo);
            this.groupBox5.Location = new System.Drawing.Point(0, 277);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(538, 106);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtReasonForChange);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txtComments);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.txtLastModifiedUser);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.txtCreatedDate);
            this.groupBox6.Controls.Add(this.txtLastModifiedDate);
            this.groupBox6.Controls.Add(this.txtCreatedUser);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Location = new System.Drawing.Point(0, 377);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(538, 131);
            this.groupBox6.TabIndex = 59;
            this.groupBox6.TabStop = false;
            // 
            // txtReasonForChange
            // 
            this.txtReasonForChange.Location = new System.Drawing.Point(138, 76);
            this.txtReasonForChange.Multiline = true;
            this.txtReasonForChange.Name = "txtReasonForChange";
            this.txtReasonForChange.Size = new System.Drawing.Size(377, 20);
            this.txtReasonForChange.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Reason for change:";
            // 
            // txtLastModifiedUser
            // 
            this.txtLastModifiedUser.Enabled = false;
            this.txtLastModifiedUser.Location = new System.Drawing.Point(460, 102);
            this.txtLastModifiedUser.Name = "txtLastModifiedUser";
            this.txtLastModifiedUser.Size = new System.Drawing.Size(55, 20);
            this.txtLastModifiedUser.TabIndex = 53;
            // 
            // erpItemCode
            // 
            this.erpItemCode.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboProductionLine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.cboProductType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtWorkOrderNo);
            this.groupBox1.Controls.Add(this.btnOpenWorkOrder);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 76);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(399, 16);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(116, 20);
            this.txtStatus.TabIndex = 41;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // btnOpenWorkOrder
            // 
            this.btnOpenWorkOrder.BackgroundImage = global::ProductionSchedule.Properties.Resources.icon_search_18;
            this.btnOpenWorkOrder.Location = new System.Drawing.Point(260, 16);
            this.btnOpenWorkOrder.Name = "btnOpenWorkOrder";
            this.btnOpenWorkOrder.Size = new System.Drawing.Size(20, 20);
            this.btnOpenWorkOrder.TabIndex = 2;
            this.btnOpenWorkOrder.UseVisualStyleBackColor = true;
            this.btnOpenWorkOrder.Click += new System.EventHandler(this.btnOpenWorkOrder_Click);
            // 
            // frmProductionSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 570);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tspMainIcons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProductionSchedule";
            this.Text = "Production Schedule Data Entry";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductionSchedule_FormClosed);
            this.tspMainIcons.ResumeLayout(false);
            this.tspMainIcons.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpItemCode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorkOrderNo;
        private System.Windows.Forms.Button btnOpenWorkOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.ComboBox cboItemCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.ComboBox cboProductionLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPlannedQuantity;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProductionLineCapacity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtReOrderPoint;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpPlannedDate;
        private System.Windows.Forms.TextBox txtPlannedShift;
        private System.Windows.Forms.ComboBox cboCustomerOrderNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboFGWorkOrderNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtActualManufacturedQty;
        private System.Windows.Forms.DateTimePicker dtpActualDate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCreatedDate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtCreatedUser;
        private System.Windows.Forms.TextBox txtLastModifiedDate;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.ToolStrip tspMainIcons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider erpItemCode;
        private System.Windows.Forms.TextBox txtActualShift;
        private System.Windows.Forms.TextBox txtPlannedUOM;
        private System.Windows.Forms.ToolStripButton tsbNewWorkOrder;
        private System.Windows.Forms.ToolStripButton tsbSaveWorkOrder;
        private System.Windows.Forms.ToolStripButton tsbCopyWorkOrder;
        private System.Windows.Forms.ToolStripButton tsbDeleteWorkOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbPrintWorkOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbFirstWorkOrder;
        private System.Windows.Forms.ToolStripButton tsbPreviousWorkOrder;
        private System.Windows.Forms.ToolStripButton tsbNextWorkOrder;
        private System.Windows.Forms.ToolStripButton tsbLastWorkOrder;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.ComponentModel.BackgroundWorker bgwState;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ToolStripButton tsbIssue;
        private System.Windows.Forms.ToolStripButton tsbComplete;
        private System.Windows.Forms.TextBox txtLastModifiedUser;
        private System.Windows.Forms.ToolStripButton tsbCanceled;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtReasonForChange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripStatusLabel tslState;
    }
}