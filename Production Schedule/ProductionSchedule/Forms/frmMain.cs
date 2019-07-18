using System;
using System.Windows.Forms;
using ProductionSchedule.Classes;

namespace ProductionSchedule.Forms
{
    using Classes;
    using Globals;
    using Report_Sub_Forms;

    // The main form is setup to mimic Sage BusinessVision's appearance. 
    public partial class frmMain : Form
    {
        private Session ActiveSession { get;  }

        public frmMain()
        {
            InitializeComponent();

            //tspMainIcons.Margin = new Padding(0);
            ActiveSession = ShowLoginForm();

            if (ActiveSession != null)
            {
                txtCompany.Text = ActiveSession.CompanyName;
                txtUser.Text = ActiveSession.User;
                txtDate.Text = ActiveSession.SessionDate.ToShortDateString();
            }
        }

        #region Button and tool strip menu clicks

        private void tsbWorkOrder_Click(object sender, EventArgs e)
        {
            ShowWorkOrderForm();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWorkOrderForm();
        }

        private void companySelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*** To do: prompt to exit, clear open forms and go back to login screen ***/
        }

        private void finishedGoodsDailyStockStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSubFormFinishedGoodsDailyStockStatus();
        }

        private void rawMaterialDailyStockStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSubFormRawMaterialDailyStockStatus();
        }

        private void workOrderMaterialRequirementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSubFormWorkOrderMaterialRequirements();
        }

        private void productionScheduleSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSubFormProductionSchedule();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Show Forms
        
        // Login form to be run at startup, need to also implement for when selected from the file menu.
        private Session ShowLoginForm()
        {
            Session activeSession = null;

            frmLogin objfrmLogin = new frmLogin();

            var result = objfrmLogin.ShowDialog();

            if (result == DialogResult.OK)
            {
                activeSession = objfrmLogin.ReturnSession;
            }

            objfrmLogin.BringToFront();

            return activeSession;
        }

        // The main data entry form for the program.
        /*** Nearing completion ***/
        private void ShowWorkOrderForm()
        {
            frmProductionSchedule objfrmProductionSchedule = frmProductionSchedule.GetChildInstance(ActiveSession);
            objfrmProductionSchedule.MdiParent = this;

            objfrmProductionSchedule.Show();
            objfrmProductionSchedule.BringToFront();
        }

        // Report parameter selection form.
        /*** Currently in beta, has a report ***/
        private void ShowSubFormProductionSchedule()
        {
            subfrmProductionSchedule objsubfrmPS = new subfrmProductionSchedule(ActiveSession);
            objsubfrmPS.ShowDialog();
        }

        // Report parameter selection form.
        /*** Currently in beta, has a report ***/
        private void ShowSubFormFinishedGoodsDailyStockStatus()
        {
            subfrmFinishedGoodsDailyStockStatus objsubfrmFGDS = new subfrmFinishedGoodsDailyStockStatus(ActiveSession);
            objsubfrmFGDS.ShowDialog();
        }

        // Report parameter selection form.
        /*** Template form only, no implementation or report ***/
        private void ShowSubFormRawMaterialDailyStockStatus()
        {
            subfrmRawMaterialDailyStockStatus objsubfrmRMDS = new subfrmRawMaterialDailyStockStatus();
            objsubfrmRMDS.ShowDialog();
        }

        // Report parameter selection form.
        /*** Template form only, no implementation or report ***/
        private void ShowSubFormWorkOrderMaterialRequirements()
        {
            subfrmWorkOrderMaterialRequirements objsubfrmWOMR = new subfrmWorkOrderMaterialRequirements();
            objsubfrmWOMR.ShowDialog();
        }
        
        #endregion
    }
}
