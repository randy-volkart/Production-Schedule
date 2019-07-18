using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProductionSchedule.Forms.Sub_Forms
{
    using Classes;
    using Globals;

    public partial class subfrmSelectWorkOrder : Form
    {
        private DataAccess BVConnection;
        private bool Initalizating = false;

        private string StatusFilter { get; set; }
        private string ProductTypeFilter { get; set; }

        public string ReturnWorkOrder { get; set; }

        public subfrmSelectWorkOrder(Session session, string CurrentWorkOrder)
        {
            Initalizating = true;

            InitializeComponent();

            this.BVConnection = new DataAccess(session.CompanyODBC);

            lbxStatus.DataSource = Constants.STATUS_LIST;
            chkFilterStatus.Checked = false;
            lbxStatus.Enabled = false;
            StatusFilter = "%"; //Pervasive SQL wildcared

            lbxProductType.DataSource = Constants.PRODUCT_TYPE_LIST;
            chkFilterProductType.Checked = false;
            lbxProductType.Enabled = false;
            ProductTypeFilter = "%"; //Pervasive SQL wildcared

            Initalizating = false;

            ReturnWorkOrder = null;// CurrentWorkOrder;
        }

        private void subfrmSelectWorkOrder_Load(object sender, EventArgs e)
        {
            RefreshWorkOrdersList();

        }

        private void chkFilterStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterStatus.Checked)
            {
                lbxStatus.Enabled = true;
                StatusFilter = lbxStatus.SelectedItem.ToString();
            }
            else
            {
                lbxStatus.Enabled = false;
                StatusFilter = "%";
            }

            RefreshWorkOrdersList();
        }

        private void chkFilterProductType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFilterProductType.Checked)
            {
                lbxProductType.Enabled = true;
                ProductTypeFilter = lbxProductType.SelectedItem.ToString();
            }
            else
            {
                lbxProductType.Enabled = false;
                ProductTypeFilter = "%";
            }

            RefreshWorkOrdersList();
        }

        private void lstStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initalizating)
            {
                StatusFilter = lbxStatus.SelectedItem.ToString();

                if (lbxProductType.Enabled)
                    ProductTypeFilter = lbxProductType.SelectedItem.ToString();
                else
                    ProductTypeFilter = "%"; //Pervasive SQL wildcard

                RefreshWorkOrdersList();
            }
        }

        private void lstProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initalizating) { 
                ProductTypeFilter = lbxProductType.SelectedItem.ToString();

                if (lbxStatus.Enabled)
                    StatusFilter = lbxStatus.SelectedItem.ToString();
                else
                    StatusFilter = "%"; // Pervasive SQL wildcard

                RefreshWorkOrdersList();
            }
        }

        private void RefreshWorkOrdersList()
        {
            lsvWorkOrders.Items.Clear();

            List<ListViewItem> workorders = BVConnection.GetWorkOrdersForSelectListView(StatusFilter, ProductTypeFilter);
            foreach (ListViewItem item in workorders)
            {
                lsvWorkOrders.Items.Add(item);
            }
        }

        private void SetWorkOrderReturn()
        {
            if (lsvWorkOrders.SelectedItems.Count == 0)
                return;

            ListViewItem item = lsvWorkOrders.SelectedItems[0];
            
            ReturnWorkOrder = item.SubItems[0].Text;
        }

        private void lsvWorkOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetWorkOrderReturn();

        }

        private void lsvWorkOrders_DoubleClick(object sender, EventArgs e)
        {
            SetWorkOrderReturn();
            this.Close();
        }

        private void subfrmSelectWorkOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            //string test = (sender as ListView).Name;
            //if (string.Equals((sender as ListView).Name, @"lsvWorkOrders"))
            //Do something proper to CloseButton.
            //else
                //assume that X has been clicked and act accordingly.

            if (this.DialogResult == DialogResult.Cancel)
            {
                //ReturnWorkOrder = null;
            }
        }
    }
}
