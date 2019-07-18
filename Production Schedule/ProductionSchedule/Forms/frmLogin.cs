using System;
using System.Windows.Forms;

namespace ProductionSchedule.Forms
{
    using Classes;
    using Globals;

    // Basic login form which verifies login creditials before allowing access to the program.
    // Designed to mimic the appearance of the Sage BusinessVision login window. 
    /*** An Add User button is added here, need to properly implement that within the program.  ***/
    /*** Need to create a way for the program to get back to the login screen and select another company or user. ***/
    public partial class frmLogin : Form
    {
        private static int attempt = 3;

        public Session ReturnSession { get; set; }

        public frmLogin()
        {
            InitializeComponent();

            // Setup the company selection list set in Constants.COMPANIES.
            foreach (Constants.CompanyList company in Constants.COMPANIES)
            {
                lsvCompanies.Items.Add(new ListViewItem(new[]{
                    company.CompanyName,
                    company.OdbcName
                }));
            }

            // Select the first company if companies exist.
            if (lsvCompanies.Items.Count > 0)
            {
                lsvCompanies.Items[0].Selected = true;
                lsvCompanies.HideSelection = false;
                lsvCompanies.Select();
            }
        }

        // Add a new user to the company selected.
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = lsvCompanies.SelectedItems[0];
            var name = selectedItem.SubItems[0].Text;
            var odbc = selectedItem.SubItems[1].Text;
            var conn = Constants.GETODBCCONNECTIONSTRING(odbc);

            Login login = new Login(odbc, txtUserName.Text, txtPassword.Text);
            bool added = login.CreateUser();

            if (added)
                MessageBox.Show("Created new user.", "Add User",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("Failed to create new user", "Add User",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        // Take the entered user name and password and attempt to log in. 
        // 3 Attempts are allowed before shutting down the program.
        // A permission level is checked but permissions are not yet implemented
        private void btnOkay_Click(object sender, EventArgs e)
        {
            //Get company info
            ListViewItem selectedItem = lsvCompanies.SelectedItems[0];
            string company = selectedItem.SubItems[0].Text;
            string odbc = selectedItem.SubItems[1].Text;
            string conn = Constants.GETODBCCONNECTIONSTRING(odbc); 
            
            Login login = new Login(odbc, txtUserName.Text, txtPassword.Text);

            //returns -1 if login not valid, otherwise permission value should be 1-9
            int permissionLevel = login.Validate(); 

            attempt--;

            if (permissionLevel > 0 )
            {
                attempt = 3;
                this.ReturnSession = new Session(txtUserName.Text, DateTime.Now, permissionLevel, company, odbc);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (attempt > 0)
            {
                MessageBox.Show("Invalid user I.D. or password.  Please re-enter.",
                    "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("A valid User I.D. and Password is required to log-on. This session will be terminated!",
                    "Invalid User Log-on", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleExit();
            }
        }

        private void HandleExit()
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HandleExit();
        }

    }
}
