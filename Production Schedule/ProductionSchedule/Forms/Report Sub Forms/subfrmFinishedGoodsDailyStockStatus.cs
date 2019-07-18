using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace ProductionSchedule.Forms.Report_Sub_Forms
{
    using Classes;
    using Globals;
    using Reports;

    // Form to launch Finished Goods Daily Stock Status report. 
    // Form and report Currently in beta. 
    public partial class subfrmFinishedGoodsDailyStockStatus : Form
    {
        private static subfrmFinishedGoodsDailyStockStatus subfrmFinishedGoodsDailyStockStatusChild;
        private static Session SubSession;
        private Report FGReport;
        private string Warehouse;
        private string ProductCode;
        private string ItemCode;

        public subfrmFinishedGoodsDailyStockStatus(Session session)
        {
            InitializeComponent();
            SubSession = session;
            FGReport = new Report(SubSession.CompanyODBC);

            InitializeWarehouse();
            Warehouse = cboWhse.SelectedValue.ToString();
            InitializeProductCode();
            ProductCode = cboProductCode.SelectedValue.ToString();            
            InitializeItemList(Warehouse, ProductCode);
            ItemCode = cboProductNo.SelectedValue.ToString();

            InitializeProductList(Warehouse, ProductCode, ItemCode);

            rdb14Days.Checked = true;
            rdb28Days.Checked = false;
        }

        private void InitializeProductList(string warehouse, string productCode, string itemCode)
        {
            DataTable productList = FGReport.GetDailyProductListReport(warehouse, productCode, itemCode); 
            dgvProducts.DataSource = productList;
            dgvProducts.Refresh();
        }

        private void InitializeWarehouse()
        {
            List<string> warehouses = FGReport.GetWarehousesList();
            cboWhse.DataSource = warehouses;
        }

        private void InitializeProductCode()
        {
            List<string> products = FGReport.GetProductsList();
            cboProductCode.DataSource = products;
        }

        private void InitializeItemList(string warehouse, string productCode)
        {
            List<string> items = FGReport.GetItemsList(warehouse, productCode);
            cboProductNo.DataSource = items;
        }

        public static subfrmFinishedGoodsDailyStockStatus GetChildInstance(Session session)
        {
            if (subfrmFinishedGoodsDailyStockStatusChild == null)
                subfrmFinishedGoodsDailyStockStatusChild = new subfrmFinishedGoodsDailyStockStatus(session);
            return subfrmFinishedGoodsDailyStockStatusChild;
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            // Count item rows from datagridview.
            int rows = 0;
            // Count days to run.
            int days = 0; 

            List<FinishedGoodsData> fgData = new List<FinishedGoodsData>();

           // FGReport.ClearTempFGReportData();
            
            rows = dgvProducts.RowCount;

            if (rdb14Days.Checked)
                days = 14;
            else
                days = 28;

            for (int x = 0; x < rows - 1; x++)
            {
                string whse, whseDesc, prod, item, itemDesc = "";
                decimal rop = 0;
                
                whse = dgvProducts["WHSE", x].Value.ToString();
                whseDesc = dgvProducts["WHSE_DESCRIPTION", x].Value.ToString();
                prod = dgvProducts["PROD", x].Value.ToString();
                item = dgvProducts["CODE", x].Value.ToString();
                itemDesc = dgvProducts["INV_DESCRIPTION", x].Value.ToString();
                rop = (decimal)dgvProducts["ROP", x].Value;

                fgData.Add(new FinishedGoodsData(whse, whseDesc, prod, item, itemDesc, rop));

            }
            
            //This function prepares the data into a temporay PSQL table
            FGReport.PrepareFGReport(fgData, days);

            //This report runs off the above mentioned temporary PSQL table
            DataTable table = FGReport.RunFinishedGoodsDailyStockStatusReport(DateTime.Now, 14);
            FinishedGoodsDailyStockStatusReport fgReport = new FinishedGoodsDailyStockStatusReport();
            ParameterFields pFields = new ParameterFields();

            ParameterField pfCompany = new ParameterField();
            ParameterField pfDays = new ParameterField();
            ParameterField pfDate = new ParameterField();
            ParameterDiscreteValue pfvCompany = new ParameterDiscreteValue();
            ParameterDiscreteValue pfvDays = new ParameterDiscreteValue();
            ParameterDiscreteValue pfvDate = new ParameterDiscreteValue();

            pfvCompany.Value = SubSession.CompanyName;
            pfCompany.Name = "Company";
            pfCompany.CurrentValues.Add(pfvCompany);
            pFields.Add(pfCompany);

            // Value from form should be 14 or 28.
            pfvDays.Value = days; 
            pfDays.Name = "Days";
            pfDays.CurrentValues.Add(pfvDays);
            pFields.Add(pfDays);

            /*** Replace this with datetime.now or a date selection box. ***/
            DateTime useDate = new DateTime(2019, 05, 30); 

            pfvDate.Value = useDate.ToString();
            pfDate.Name = "Date";
            pfDate.CurrentValues.Add(pfvDate);
            pFields.Add(pfDate);
            
            fgReport.SetDataSource(table);
            crystalReportViewer1.ParameterFieldInfo = pFields;
            crystalReportViewer1.ReportSource = fgReport;
            
            //Utilities.ShowMessage("Report Processing Completed", "Finished Goods Daily Stock Status Report");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void subfrmFinishedGoodsDailyStockStatus_Load(object sender, EventArgs e)
        {

        }

        private void cboWhse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWhse.SelectedValue != null)
            {
                Warehouse = cboWhse.SelectedValue.ToString();
                InitializeItemList(Warehouse, ProductCode);
                InitializeProductList(Warehouse, ProductCode, ItemCode);
            }
        }

        private void cboProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductCode.SelectedValue != null)
            {
                ProductCode = cboProductCode.SelectedValue.ToString();
                InitializeItemList(Warehouse, ProductCode);
                InitializeProductList(Warehouse, ProductCode, ItemCode);
            }
        }

        private void cboProductNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboProductNo.SelectedValue != null)
            {
                ItemCode = cboProductNo.SelectedValue.ToString();
                InitializeProductList(Warehouse, ProductCode, ItemCode);
            }
        }
    }
}
