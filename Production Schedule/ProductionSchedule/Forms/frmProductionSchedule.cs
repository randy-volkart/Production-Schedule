using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProductionSchedule.Forms
{
    using Classes;
    using Globals;
    using Sub_Forms;
    
    // The main Production Schedule data entry form. Handles the bulk of the work for the project.
    // *NOTE*  Need to implement better method to get next work order number. 
    public partial class frmProductionSchedule : Form
    {
        // Used to ensure only a single instance of the form is open.
        public static frmProductionSchedule frmProductionScheduleChild;

        // ProductionSchedule form requires User ID, login date, 
        // and ODBC company name passed from main form. 
        private Session ActiveSession { get; }

        // BusinessVision object holds BV/ODBC related functions.
        private DataAccess BVConnection;

        // Global enum to track workflow.
        // enum State { Initialize, New, Active, Changed, Open, Copy, Update, Delete, Completed, Error }
        private Control.State ActiveState { get; set; }

        // Store user from login.
        private string User { get; }

        // A string to be set and passed to the Production Schedule log history record.
        private string Log { get; set; }

        // On stratup set the session values, create a BVConnection object, and start a new work order.
        // Constructor set to private, call GetChildInstance to open while ensuring only one active
        // copy exists. 
        private frmProductionSchedule(Session session)
        {
            ActiveSession = session;
            InitializeComponent();
            BVConnection = new DataAccess(ActiveSession.CompanyODBC);
            User = ActiveSession.User;

            ActiveState = ProcessStartNewWorkOrder();
            ActiveState = Control.State.New;
            SetStateDisplay(ActiveState);
            Log = "";
        }

        // Ensures that only one copy of the form can be open
        public static frmProductionSchedule GetChildInstance(Session session)
        {
            if (frmProductionScheduleChild == null)
                frmProductionScheduleChild = new frmProductionSchedule(session);
            return frmProductionScheduleChild;
        }

        // Reset fields to blank.
        private void ClearWorkOrder()
        {
            txtItemDescription.Text = "";
            txtPlannedQuantity.Text = "";
            txtPlannedShift.Text = "";
            txtProductionLineCapacity.Text = "";
            txtReOrderPoint.Text = "";
            txtBatchSize.Text = "";
            txtBatchNo.Text = "";
            txtActualManufacturedQty.Text = "";
            txtActualShift.Text = "";
            txtComments.Text = "";
            txtPlannedUOM.Text = "";

            dtpActualDate.Value = DateTime.Now;
            dtpPlannedDate.Value = DateTime.Now;
        }

        // Try to ensure that what goes into the disabled txtStatus text box is a Control.Status value.
        // This is a controlled input for the work order.
        private void SetStatusText(Control.Status status)
        {
            txtStatus.Text = status.ToString(); ;
        }

        // Try to ensure that what goes into the tool strip label is a Control.Status value. 
        // This is for display only, form interaction should use the private Control.State ActiveState value.
        private void SetStateDisplay(Control.State state)
        {
            tslState.Text = state.ToString();
        }

        // Functions to Initialize comboboxes and disabled text fields
        #region Initialize fields

        private void InitializeWorkOrderNo()
        {
            txtWorkOrderNo.Text = BVConnection.GetNewWorkOrderNo().ToString();
        }

        private void InitializeProductType()
        {
            List<string> pt = Constants.PRODUCT_TYPE_LIST;
            BindingSource bs = new BindingSource();
            bs.DataSource = pt;
            cboProductType.DataSource = bs;
            cboProductType.SelectedIndex = 0;
        }

        private void InitializeProductionLine()
        {
            List<string> productionlines = new List<string>();

            productionlines = BVConnection.GetProductionLines();

            if (productionlines.Count > 0)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = productionlines;
                cboProductionLine.DataSource = bs;
            }
        }

        private void InitializeWarehouses()
        {
            List<string> warehouses = new List<string>();

            warehouses = BVConnection.GetBVWarehouses();

            if (warehouses.Count > 0)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = warehouses;
                cboWarehouse.DataSource = bs;
            }
        }

        private void InitializeItemCode()
        {
            List<string> itemlines = new List<string>();
            string whse = cboWarehouse.SelectedItem.ToString();

            itemlines = BVConnection.GetItemLines(whse);

            if (itemlines.Count > 0)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = itemlines;
                cboItemCode.DataSource = bs;
            }
            cboItemCode.SelectedIndex = -1;
        }

        private void InitializeItemDescription()
        {
            string description = "";
            string whse = cboWarehouse.SelectedItem.ToString();
            string item = cboItemCode.SelectedItem.ToString();

            description = BVConnection.GetItemDescription(whse, item);

            if (whse != null && item != null)
            {
                if (description != null)
                    txtItemDescription.Text = description;
            }
        }

        private void InitializePlannedUOM()
        {
            string uom = "";
            string whse = cboWarehouse.SelectedItem.ToString();
            string item = cboItemCode.SelectedItem.ToString();

            if (whse != null && item != null)
            {
                uom = BVConnection.GetUOMs(whse, item);
                if (uom != null)
                    txtPlannedUOM.Text = uom;
            }
        }

        private void InitializeReOrderPoint()
        {
            decimal rop = 0;
            string whse = cboWarehouse.SelectedItem.ToString();
            string item = cboItemCode.SelectedItem.ToString();

            if (whse != null && item != null)
            {
                rop = BVConnection.GetReOrderPoint(whse, item);
                txtReOrderPoint.Text = rop.ToString();
            }
        }

        //Sent to text object Batch Size
        private void InitializeMinInvLevel()
        {
            decimal mil = 0;
            string whse = cboWarehouse.SelectedItem.ToString();
            string item = cboItemCode.SelectedItem.ToString();

            if (whse != null && item != null)
            {
                mil = BVConnection.GetReOrderPoint(whse, item);
                txtBatchSize.Text = mil.ToString();
            }
        }

        private void InitializeStatus()
        {
            //List<string> status = Constants.STATUS_LIST;
            //BindingSource bs = new BindingSource();
            //bs.DataSource = status;
            //cboStatus.DataSource = bs;
            Control.Status stat = Control.Status.Okay;
            SetStatusText(stat);
            //txtStatus.Text = Control.Status.Okay.ToString();
        }

        private void InitializeCreated()
        {
            txtCreatedUser.Text = this.User;
            txtCreatedDate.Text = DateTime.Now.ToString(Constants.BVDATEFORMAT);
        }

        private void InitializeModified()
        {
            txtLastModifiedUser.Text = this.User;
            txtLastModifiedDate.Text = DateTime.Now.ToString(Constants.BVDATEFORMAT);
        }

        #endregion

        // The Object Controls region handles the 'Changed' event of the form inputs. If the ActiveState value
        // is not Control.State.New, then on change set ActiveState = Control.State.Update. 
        // Other event handles controlling moving between work orders will check for the Update 
        // value to see whether or not a prompt to save the open work order is needed. 
        #region Object Controls

        private void cboItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.Initialize && ActiveState != Control.State.Open)
            {
                string item = cboItemCode.SelectedItem.ToString();

                if (item != "")
                {
                    InitializeItemDescription();
                    InitializePlannedUOM();
                    InitializeReOrderPoint();
                    InitializeMinInvLevel();
                }

                if (ActiveState != Control.State.New)
                {
                    ActiveState = Control.State.Update;
                    SetStateDisplay(ActiveState);
                }
            }
        }

        private void frmProductionSchedule_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmProductionScheduleChild != null)
                frmProductionScheduleChild = null;
        }

        private void cboProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.Initialize && ActiveState != Control.State.Open)
            {
                string type = cboProductType.SelectedItem.ToString().ToUpper();
                if (type == "FINISHED GOODS")
                {
                    txtPlannedShift.Text = "1";
                    cboFGWorkOrderNo.Enabled = false;
                    cboCustomerOrderNo.Enabled = true;
                }
                if (type == "IN PROCESS")
                {
                    cboFGWorkOrderNo.Enabled = true;
                    cboCustomerOrderNo.Enabled = false;
                }

                if (ActiveState != Control.State.New)
                {
                    ActiveState = Control.State.Update;
                    SetStateDisplay(ActiveState);
                }
            }
        }

        // Changing the status of the work order has an effect on the buttons enabled
        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            //Status { Okay, Issued, UnIssued, Cancelled, Completed };
            switch (txtStatus.Text)
            {
                case nameof(Control.Status.Okay):
                    tsbIssue.Image = ProductionSchedule.Properties.Resources.icon_issued;
                    tsbIssue.Text = "Issue";
                    tsbIssue.Enabled = true;

                    tsbComplete.Enabled = false;
                    tsbCanceled.Enabled = false;
                    tsbDeleteWorkOrder.Enabled = true;
                    break;
                case nameof(Control.Status.Issued):
                    tsbIssue.Image = ProductionSchedule.Properties.Resources.icon_unissued;
                    tsbIssue.Text = "UnIssue";
                    tsbIssue.Enabled = true;

                    tsbComplete.Enabled = true;
                    tsbCanceled.Enabled = false;
                    tsbDeleteWorkOrder.Enabled = false;
                    break;
                case nameof(Control.Status.UnIssued):
                    //tsbIssue.BackgroundImage = null;
                    tsbIssue.Image = ProductionSchedule.Properties.Resources.icon_issued;
                    tsbIssue.Text = "Issue";
                    tsbIssue.Enabled = true;

                    tsbComplete.Enabled = false;
                    tsbCanceled.Enabled = true;
                    tsbDeleteWorkOrder.Enabled = false;
                    break;
                case nameof(Control.Status.Cancelled):
                    tsbIssue.Enabled = false;
                    tsbComplete.Enabled = false;
                    tsbCanceled.Enabled = false;
                    tsbDeleteWorkOrder.Enabled = false;
                    break;
                case nameof(Control.Status.Completed):
                    tsbIssue.Enabled = false;
                    tsbComplete.Enabled = false;
                    tsbCanceled.Enabled = false;
                    tsbDeleteWorkOrder.Enabled = false;
                    break;
                default:

                    break;
            }
        }

        // No implementation yet, just a placeholder function
        private void tslState_TextChanged(object sender, EventArgs e)
        {
            switch (ActiveState)
            {
                case Control.State.Initialize:

                    break;
                case Control.State.New:

                    break;

                case Control.State.Active:

                    break;
                case Control.State.Changed:

                    break;
                case Control.State.Open:

                    break;
                case Control.State.Copy:

                    break;
                case Control.State.Update:

                    break;
                case Control.State.Completed:

                    break;
                case Control.State.Error:

                    break;
                default:

                    break;
            }

            //Initialize, New, Active, Changed, Open, Copy, Update, Delete, Okay, Error
        }

        private void cboProductionLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void txtPlannedQuantity_TextChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void dtpPlannedDate_ValueChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void txtPlannedShift_TextChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void txtActualManufacturedQty_TextChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void dtpActualDate_ValueChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void txtActualShift_TextChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void txtProductionLineCapacity_TextChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void txtBatchNo_TextChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void cboCustomerOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void cboFGWorkOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            if (ActiveState != Control.State.New && ActiveState != Control.State.Initialize)
            {
                ActiveState = Control.State.Update;
                SetStateDisplay(ActiveState);
            }
        }
        #endregion

        // The Button Click Functions region handles the various form buttons, running
        // a few checks before passing the work onto the Work Order Processing region. 
        // A few guidelines should be followed: 
        // *  Check ProcessLeavingWorkorders() in functions that leave the current work order
        // *  Calling Process functions should return a state to the ActiveState parameter 
        // *  Set Control.Status in buttons that update the status of a Work Order
        // *  Set Log parameter before running process function where necessary
        #region Button Click Functions

        private void tsbNewWorkOrder_Click(object sender, EventArgs e)
        {
            if (!ProcessLeavingWorkOrder(ActiveState))
                return;

            ActiveState = ProcessStartNewWorkOrder();

            SetStateDisplay(ActiveState);
        }

        private void tsbSaveWorkOrder_Click(object sender, EventArgs e)
        {
            if (ActiveState == Control.State.New)
            {
                ActiveState = ProcessAddNewWorkOrder(Control.State.New);

                if(ActiveState != Control.State.Error)
                    Log = "Work Order Created";
            }
            else if (ActiveState == Control.State.Active || ActiveState == Control.State.Update)
            {
                Log = String.Format("Work Order Updated: {0}", txtReasonForChange.Text);

                ActiveState = ProcessUpdateWorkOrder(Control.State.Update);
            }
            else
            {
                ActiveState = Control.State.Error;
            }

            SetStateDisplay(ActiveState);
        }

        private void tsbCopyWorkOrder_Click(object sender, EventArgs e) 
        {
            if (!ProcessLeavingWorkOrder(ActiveState))
                return;

            Log = string.Format("Work Order created, copied from {0}", txtWorkOrderNo.Text);

            ActiveState = ProcessCopyWorkOrder(Control.State.Copy);

            SetStateDisplay(ActiveState);
        }

        // This button is used for when BV information in a saved Work Order was changed in BV
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            InitializeItemDescription();
            InitializeMinInvLevel();
            InitializePlannedUOM();
            InitializeReOrderPoint();
        }

        // Can only delete work order if Status is Okay. 
        private void tsbDeleteWorkOrder_Click(object sender, EventArgs e)
        {
            Control.State currentState = ActiveState;

            //if (ActiveState == Control.State.Active || ActiveState == Control.State.Update)
            if (txtStatus.Text == nameof(Control.Status.Okay))
            {
                Log = string.Format("Work Order {0} Deleted", txtWorkOrderNo.Text);

                ActiveState = ProcessDeleteWorkOrder(Control.State.Delete, currentState);
                
                ProcessStartNewWorkOrder();
            }
            else if (ActiveState == Control.State.New)
            {
                ProcessStartNewWorkOrder();
            }

            SetStateDisplay(ActiveState);
        }

        private void tsbFirstWorkOrder_Click(object sender, EventArgs e)
        {
            if (!ProcessLeavingWorkOrder(ActiveState))
                return;

            ActiveState = ProcessFirstWorkOrder(Control.State.Open);

            SetStateDisplay(ActiveState);
        }

        private void tsbPreviousWorkOrder_Click(object sender, EventArgs e)
        {
            if (!ProcessLeavingWorkOrder(ActiveState))
                return;

            ActiveState = ProcessPreviousWorkOrder(Control.State.Open);
            
            SetStateDisplay(ActiveState);
        }

        private void tsbNextWorkOrder_Click(object sender, EventArgs e)
        {
            if (!ProcessLeavingWorkOrder(ActiveState))
                return;

            ActiveState = ProcessNextWorkOrder(Control.State.Open);

            SetStateDisplay(ActiveState);
        }

        private void tsbLastWorkOrder_Click(object sender, EventArgs e)
        {
            if (!ProcessLeavingWorkOrder(ActiveState))
                return;

            ActiveState = ProcessLastWorkOrder(Control.State.Open);

            SetStateDisplay(ActiveState);
        }

        // Issues button can swap between Okay/Issued/UnIssed status.
        private void tspIssue_Click(object sender, EventArgs e)
        {
            Control.State processState = ActiveState;

            if (txtStatus.Text == nameof(Control.Status.Okay))
            {
                DialogResult dr = MessageBox.Show(
                    "Issue the Work Order?",
                    "Issue", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SetStatusText(Control.Status.Issued);
                    Log = string.Format("Work Order {0} Issued", txtWorkOrderNo.Text);
                    processState = Control.State.Update;

                    ActiveState = ProcessUpdateWorkOrder(processState);
                }
                else if (dr == DialogResult.No){}
            }

            else if (txtStatus.Text == nameof(Control.Status.Issued))
            {
                DialogResult dr = MessageBox.Show(
                    "Un-issue the Work Order?",
                    "Un-issue", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SetStatusText(Control.Status.UnIssued);
                    Log = string.Format("Work Order {0} Un-Issued", txtWorkOrderNo.Text);
                    processState = Control.State.Update;

                    ActiveState = ProcessUpdateWorkOrder(processState);
                }
                else if (dr == DialogResult.No){}
            }
            else if (txtStatus.Text == nameof(Control.Status.UnIssued))
            {
                DialogResult dr = MessageBox.Show(
                    "Reissue the Work Order?",
                    "Reissue", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SetStatusText(Control.Status.Issued);
                    Log = string.Format("Work Order {0} Reissued", txtWorkOrderNo.Text);
                    processState = Control.State.Update;

                    ActiveState = ProcessUpdateWorkOrder(processState);                    
                }
                else if (dr == DialogResult.No){}
                
            }
            else{}

            SetStateDisplay(ActiveState);
        }

        // Can only be completed if status is Issued. 
        private void tspComplete_Click(object sender, EventArgs e)
        {
            Control.State processState = ActiveState;

            if (txtStatus.Text == nameof(Control.Status.Issued))
            {
                DialogResult dr = MessageBox.Show(
                    "Complete the Work Order and move it to history?",
                    "Complete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SetStatusText(Control.Status.Completed);
                    SetStateDisplay(Control.State.Completed);
                    Log = string.Format("Work Order {0} Completed", txtWorkOrderNo.Text);

                    processState = ProcessCompleteWorkOrder(Control.State.Completed);

                    if (processState != Control.State.Error)
                    {
                        ActiveState = ProcessStartNewWorkOrder();
                    }
                    else
                    {
                        SetStatusText(Control.Status.Issued);
                        ActiveState = Control.State.Active;
                    }
                    SetStateDisplay(ActiveState);

                }
                else if (dr == DialogResult.No){}
            }
            else { }
        }

        // Can only be canceled if status is UnIssued.
        private void tsbCanceled_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == nameof(Control.Status.UnIssued))
            {
                DialogResult dr = MessageBox.Show(
                    "Cancel the Work Order and move it to history?",
                    "Cancel", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SetStatusText(Control.Status.Completed);
                    Log = string.Format("Work Order {0} Canceled", txtWorkOrderNo.Text);

                    ProcessUpdateWorkOrder(ActiveState);
                }
                else if (dr == DialogResult.No){}
            }
            else { }
        }

        // This report needs to be built
        private void tsbPrintWorkOrder_Click(object sender, EventArgs e)
        {

        }

        // Exiting the form.
        private void tsbClose_Click(object sender, EventArgs e)
        {
            if (!ProcessLeavingWorkOrder(ActiveState))
                return;

            if (frmProductionScheduleChild != null)
                frmProductionScheduleChild = null;
            this.Close();
        }

        // Work order is selected through a sub form.
        private void btnOpenWorkOrder_Click(object sender, EventArgs e)
        {
            if (!ProcessLeavingWorkOrder(ActiveState))
                return;

            string currentWO = txtWorkOrderNo.Text;
            subfrmSelectWorkOrder sfsw = new subfrmSelectWorkOrder(ActiveSession, currentWO);

            sfsw.ShowDialog();
            sfsw.BringToFront();

            string wo = sfsw.ReturnWorkOrder;

            if (wo != null)
            {
                ActiveState = ProcessOpenWorkOrder(Control.State.Open, wo);
            }

            SetStateDisplay(ActiveState);
        }

        #endregion

        // All the real work on the work orders is handled in the Processing functions
        #region Work Order Processing functions

        // Clean the fields and initialize the required fields to begin a new work order.
        // Expected state return value: New
        private Control.State ProcessStartNewWorkOrder()
        {
            ClearWorkOrder();

            ActiveState = Control.State.Initialize;

            InitializeWorkOrderNo();
            InitializeProductType();
            InitializeWarehouses();
            InitializeProductionLine();
            InitializeItemCode();
            InitializeStatus();
            InitializeCreated();
            InitializeModified();

            return Control.State.New;
        }

        // Expected state return value: Active, Error.
        private Control.State ProcessOpenWorkOrder(Control.State processState, string workOrderNo)
        {
            if (processState == Control.State.Open)
            {
                DataProcess order = new DataProcess(ActiveSession.CompanyODBC);
                order.SelectOrder(workOrderNo);

                txtWorkOrderNo.Text = order.WorkOrderNo.ToString();
                Utilities.SetComboBoxSelectedIndex(ref cboProductType, order.ProductionType);
                Utilities.SetComboBoxSelectedIndex(ref cboProductionLine, order.ProductionLine);
                Utilities.SetComboBoxSelectedIndex(ref cboWarehouse, order.ProductWarehouse);
                Utilities.SetComboBoxSelectedIndex(ref cboItemCode, order.ProductNumber);
                txtItemDescription.Text = order.ProductDescription;

                txtPlannedUOM.Text = order.PlannedUOM;
                txtPlannedQuantity.Text = order.PlannedQuantity.ToString();
                dtpPlannedDate.Value = order.PlannedDate;
                txtPlannedShift.Text = order.PlannedShift.ToString();

                txtProductionLineCapacity.Text = order.ProdLineCapacity.ToString();
                txtReOrderPoint.Text = order.ReOrderPoint.ToString();
                txtBatchNo.Text = order.NoBatches.ToString();
                txtBatchSize.Text = order.BatchSize.ToString();

                Utilities.SetComboBoxSelectedIndex(ref cboCustomerOrderNo, order.CustomerOrderNo);
                Utilities.SetComboBoxSelectedIndex(ref cboFGWorkOrderNo, order.FGWorkOrderNo);

                txtStatus.Text = order.Status;
                txtActualManufacturedQty.Text = order.ActualMftQty.ToString();
                txtActualShift.Text = order.ActualShift.ToString();
                dtpActualDate.Value = (DateTime)order.ActualDate;

                txtComments.Text = order.Comments;
                txtCreatedUser.Text = order.CreationUser;
                txtCreatedDate.Text = order.CreationDate;
                txtLastModifiedUser.Text = order.LastModifiedUser;
                txtLastModifiedDate.Text = order.LastModifiedDate;

                return Control.State.Active;
            }
            else
            {
                return Control.State.Error;
            }
        }

        // Field validation is run before creating a new work order. If their are
        // invalid fields, state New is returned. If validation passes, create the work 
        // order and return state Active. 
        // Expected state return value: New, Active, Error
        private Control.State ProcessAddNewWorkOrder(Control.State processState)
        {
            Control.State result = Control.State.Error;

            if (processState == Control.State.New)
            {
                if (cboItemCode.SelectedItem == null)
                {
                    erpItemCode.SetError(cboItemCode, "An Item must be selected");
                    result = Control.State.New;
                }
                else
                {
                    erpItemCode.Clear();

                    DataProcess newOrder = new DataProcess(ActiveSession.CompanyODBC);

                    string won = txtWorkOrderNo.Text;
                    string prt = cboProductType.SelectedItem.ToString();
                    string prl = cboProductionLine.SelectedItem.ToString();

                    string whs = cboWarehouse.SelectedItem.ToString();
                    string itc = cboItemCode.SelectedItem.ToString();
                    string itd = txtItemDescription.Text;

                    string plu = txtPlannedUOM.Text;
                    string plq = txtPlannedQuantity.Text;
                    string pld = dtpPlannedDate.Text;
                    string pls = txtPlannedShift.Text;

                    string plc = txtProductionLineCapacity.Text;
                    string mil = txtReOrderPoint.Text;
                    string bas = txtBatchSize.Text;
                    string nob = txtBatchNo.Text;

                    string cun = (cboCustomerOrderNo.SelectedIndex == -1) ? "" : cboCustomerOrderNo.SelectedItem.ToString();
                    string fgo = (cboFGWorkOrderNo.SelectedIndex == -1) ? "" : cboFGWorkOrderNo.SelectedItem.ToString();
                    string sta = nameof(Control.Status.Okay);//txtStatus.Text;
                    string amq = txtActualManufacturedQty.Text;
                    string acs = txtActualShift.Text;
                    string acd = dtpActualDate.Text;

                    string com = txtComments.Text;
                    string crd = txtCreatedDate.Text;
                    string cru = txtCreatedUser.Text;
                    string lmd = txtLastModifiedDate.Text;
                    string lmu = txtLastModifiedUser.Text;

                    List<string> validateErrors = newOrder.Validate(
                        won, prt, prl,
                        whs, itc, itd,
                        plu, plq, pld, pls,
                        plc, mil, nob, bas,
                        cun, fgo, sta, amq, acs, acd,
                        com, crd, cru, lmd, lmu
                    );

                    if (validateErrors.Count > 0)
                    {
                        string errors = "The following fields did not pass data validation:\n";
                        foreach (string s in validateErrors)
                        {
                            errors = string.Format("{0}\n{1}", errors, s);
                        }
                        Utilities.ShowError(errors, "Data Validation Error");
                        result = Control.State.New;
                    }
                    else
                    {
                        newOrder.AddOrder();
                        ProcessRecordLogHistory(newOrder, Log);
                        Utilities.ShowMessage(string.Format("Work Order {0} Added.", won), "Add");
                        result = Control.State.Active;
                    }
                }
            }
            else
            {
                result = Control.State.Error;
            }

            return result;
        }

        // Expected state return value: New, Error
        private Control.State ProcessCopyWorkOrder(Control.State processState)
        {
            if (processState == Control.State.Copy)
            {
                string newWO = BVConnection.GetNewWorkOrderNo().ToString();

                txtWorkOrderNo.Text = newWO;
                SetStatusText(Control.Status.Okay);

                return ProcessAddNewWorkOrder(Control.State.New);
            }
            else
            {
                return Control.State.Error;
            }
        }

        // Field validation is run before updating the work order. If their are
        // invalid fields, state Update is returned. If validation passes, update/save 
        // the work order and return state Active. 
        // Expected state return value: Update, Active, Error
        private Control.State ProcessUpdateWorkOrder(Control.State processState)
        {
            Control.State result = processState;

            if (processState == Control.State.Update)
            {
                if (cboItemCode.SelectedItem == null)
                {
                    erpItemCode.SetError(cboItemCode, "An Item must be selected");
                    result = Control.State.Update;
                }
                else
                {
                    DataProcess updateOrder = new DataProcess(ActiveSession.CompanyODBC);

                    

                    string won = txtWorkOrderNo.Text;
                    #region Assigning fields to string variables...
                    string prt = cboProductType.SelectedItem.ToString();
                    string prl = cboProductionLine.SelectedItem.ToString();

                    string whs = cboWarehouse.SelectedItem.ToString();
                    string itc = cboItemCode.SelectedItem.ToString();
                    string itd = txtItemDescription.Text;

                    string plu = txtPlannedUOM.Text;
                    string plq = txtPlannedQuantity.Text;
                    string pld = dtpPlannedDate.Text;
                    string pls = txtPlannedShift.Text;

                    string plc = txtProductionLineCapacity.Text;
                    string mil = txtReOrderPoint.Text;
                    string bas = txtBatchSize.Text;
                    string nob = txtBatchNo.Text;

                    string cun = (cboCustomerOrderNo.SelectedIndex == -1) ? "" : cboCustomerOrderNo.SelectedItem.ToString();
                    string fgo = (cboFGWorkOrderNo.SelectedIndex == -1) ? "" : cboFGWorkOrderNo.SelectedItem.ToString();
                    string sta = txtStatus.Text;
                    string amq = txtActualManufacturedQty.Text;
                    string acs = txtActualShift.Text;
                    string acd = dtpActualDate.Text;

                    string com = txtComments.Text;
                    string crd = txtCreatedDate.Text;
                    string cru = txtCreatedUser.Text;
                    string lmd = txtLastModifiedDate.Text;
                    #endregion
                    string lmu = txtLastModifiedUser.Text;

                    List<string> validateErrors = updateOrder.Validate(
                        won, prt, prl,
                        whs, itc, itd,
                        plu, plq, pld, pls,
                        plc, mil, nob, bas,
                        cun, fgo, sta, amq, acs, acd,
                        com, crd, cru, lmd, lmu
                    );

                    if (validateErrors.Count > 0)
                    {
                        string errors = "The following fields did not pass data validation:\n";
                        foreach (string s in validateErrors)
                        {
                            errors = string.Format("{0}\n{1}", errors, s);
                        }
                        Utilities.ShowError(errors, "Data Validation Error");
                        result = Control.State.Update;
                    }
                    else
                    {
                        updateOrder.UpdateOrder();

                        ProcessRecordLogHistory(updateOrder, Log);
                        
                        Utilities.ShowMessage(string.Format("Work Order {0} Updated.", won), "Update");
                        result = Control.State.Active;
                    }
                }
            }
            else
            {
                result = Control.State.Error;
            }

            return result;
        }

        // This process requires an extra parameter currentState to return if the Delete fails
        // Expected state return value: currentState*, New, Error
        private Control.State ProcessDeleteWorkOrder(Control.State processState, Control.State currentState)
        {
            Control.State result = processState;

            if (processState == Control.State.Delete)
            {
                if (txtWorkOrderNo.Text != "")
                {
                    DataProcess order = new DataProcess(ActiveSession.CompanyODBC);
                    string status = txtStatus.Text;
                    int won;

                    if (int.TryParse(txtWorkOrderNo.Text, out won))
                        if (order.DeleteOrder(won, status) == true)
                        {
                            //***Add Log update here
                            Utilities.ShowMessage(string.Format("Work Order {0} Deleted", won), "Delete");
                            result = Control.State.New;
                        }
                        else
                        {
                            Utilities.ShowMessage(string.Format("Failed to delete Work Order {0}", won), "Delete");
                            result = currentState;
                        }

                    else
                    {
                        Utilities.ShowError("Invalid Work Order", "Delete");
                        result = currentState;
                    }
                }
            }
            else
            {
                result = Control.State.Error;
            }

            return result;
        }

        // Expected state return value: Active, Error
        private Control.State ProcessPreviousWorkOrder(Control.State processState)
        {
            if (processState == Control.State.Open)
            {
                string currentWo = txtWorkOrderNo.Text;
                string wo = BVConnection.GetPreviousWorkOrderNo(currentWo);

                // "0" will be returned when the first record is active
                if (wo != "0")
                {
                    ProcessOpenWorkOrder(Control.State.Open, wo);
                }

                return Control.State.Active;
            }
            else
            {
                return Control.State.Error;                
            }
        }

        // Expected state return value: Active, Error
        private Control.State ProcessNextWorkOrder(Control.State processState)
        {
            if (processState == Control.State.Open)
            {
                string currentWo = txtWorkOrderNo.Text;
                string wo = BVConnection.GetNextWorkOrderNo(currentWo);

                // "0" will be returned when the first record is active
                if (wo != "0")
                {
                    ProcessOpenWorkOrder(Control.State.Open, wo);
                }
                return Control.State.Active;
            }
            else
            {
                return Control.State.Error;
            }
        }

        // Expected state return value: Active, Error
        private Control.State ProcessFirstWorkOrder(Control.State processState)
        {
            if (processState == Control.State.Open)
            {
                string wo = BVConnection.GetFirstWorkOrderNo();

                // "0" will be returned when the first record is active
                if (wo != "0")
                {
                    ProcessOpenWorkOrder(Control.State.Open,wo);
                }
                return Control.State.Active;
            }
            else
            {
                return Control.State.Error;
            }
        }

        // Expected state return value: Active, Error
        private Control.State ProcessLastWorkOrder(Control.State processState)
        {
            if (processState == Control.State.Open)
            {
                string wo = BVConnection.GetLastWorkOrderNo();

                // "0" will be returned when the first record is active
                if (wo != "0")
                {
                    ProcessOpenWorkOrder(Control.State.Open, wo);
                }

                return Control.State.Active;
            }
            else
            {
                return Control.State.Error;
            }
        }

        // Field validation is checked before completing. When completed the work order is moved to the
        // work order history table.
        // Expected state return value: processState*, New, Error
        private Control.State ProcessCompleteWorkOrder(Control.State processState)
        {
            Control.State result = processState;

            if (processState == Control.State.Completed)
            {
                if (cboItemCode.SelectedItem == null)
                {
                    erpItemCode.SetError(cboItemCode, "An Item must be selected");

                    result = processState;
                }
                else
                {
                    erpItemCode.Clear();

                    DataProcess completeOrder = new DataProcess(ActiveSession.CompanyODBC);

                    string won = txtWorkOrderNo.Text;
                    string prt = cboProductType.SelectedItem.ToString();
                    string prl = cboProductionLine.SelectedItem.ToString();

                    string whs = cboWarehouse.SelectedItem.ToString();
                    string itc = cboItemCode.SelectedItem.ToString();
                    string itd = txtItemDescription.Text;

                    string plu = txtPlannedUOM.Text;
                    string plq = txtPlannedQuantity.Text;
                    string pld = dtpPlannedDate.Text;
                    string pls = txtPlannedShift.Text;

                    string plc = txtProductionLineCapacity.Text;
                    string mil = txtReOrderPoint.Text;
                    string bas = txtBatchSize.Text;
                    string nob = txtBatchNo.Text;

                    string cun = (cboCustomerOrderNo.SelectedIndex == -1) ? "" : cboCustomerOrderNo.SelectedItem.ToString();
                    string fgo = (cboFGWorkOrderNo.SelectedIndex == -1) ? "" : cboFGWorkOrderNo.SelectedItem.ToString();

                    string sta = nameof(Control.Status.Okay);
                    string amq = txtActualManufacturedQty.Text;
                    string acs = txtActualShift.Text;
                    string acd = dtpActualDate.Text;

                    string com = txtComments.Text;
                    string crd = txtCreatedDate.Text;
                    string cru = txtCreatedUser.Text;
                    string lmd = txtLastModifiedDate.Text;
                    string lmu = txtLastModifiedUser.Text;

                    List<string> validateErrors = completeOrder.Validate(
                        won, prt, prl,
                        whs, itc, itd,
                        plu, plq, pld, pls,
                        plc, mil, nob, bas,
                        cun, fgo, sta, amq, acs, acd,
                        com, crd, cru, lmd, lmu
                    );

                    if (validateErrors.Count > 0)
                    {
                        string errors = "The following fields did not pass data validation:\n";
                        foreach (string s in validateErrors)
                        {
                            errors = string.Format("{0}\n{1}", errors, s);
                        }
                        Utilities.ShowError(errors, "Data Validation Error");

                        result = processState;
                    }
                    else
                    {
                        if (completeOrder.AddHistory())
                        {
                            ProcessRecordLogHistory(completeOrder, Log);
                            Utilities.ShowMessage(string.Format("Work Order {0} completed.", won), "Add");

                            result = Control.State.New;
                        }
                        else
                        {
                            Utilities.ShowMessage(string.Format("Work Order {0} was not completed.", won), "Failed");
                            ActiveState = Control.State.Error;

                            result = processState;
                        }
                    }
                }
            }
            else
            {
                result = Control.State.Error;
            }

            return result;
        }

        // When leaving a work order need to check if changes were made and if so prompt to save.
        private bool ProcessLeavingWorkOrder(Control.State processState)
        {
            bool result = true;
            if (processState == Control.State.New)
            {
                // BV doesn't prompt to save when leaving new orders,
                // so keeping it the same here.
            }
            else if (processState == Control.State.Update)
            {
                string wo = txtWorkOrderNo.Text;
                DialogResult dr = MessageBox.Show(
                    String.Format("Do you wish to save your changes to the order details for {0}", wo),
                    "Work Order Details", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    ProcessUpdateWorkOrder(Control.State.Update);
                    result = true;
                }
                else if (dr == DialogResult.No)
                {
                    result = true;
                }
                else if (dr == DialogResult.Cancel)
                {
                    result = false;
                }
            }

            return result;
        }

        // Every time a work order is changed/processed/completed it's recorded in the Log History table
        private void ProcessRecordLogHistory(DataProcess order, string reasonForChange)
        {
            if (ActiveState != Control.State.Error)
            {
                order.RecordLog(reasonForChange);
            }
        }
        #endregion

    }
}