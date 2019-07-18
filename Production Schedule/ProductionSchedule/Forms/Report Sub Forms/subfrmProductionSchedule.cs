using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

// Form to launch Production Schedule Report. 
// Form and report currently in beta. 
namespace ProductionSchedule.Forms.Report_Sub_Forms
{
    using Classes;
    using Globals;
    using Reports;

    public partial class subfrmProductionSchedule : Form
    {
        private static subfrmProductionSchedule subfrmProductionScheduleReportChild;

        // ProductionSchedule form requires User ID, login date, 
        // and ODBC company name passed from main form. 
        private static Session SubSession;

        public subfrmProductionSchedule(Session session)
        {
            InitializeComponent();
            SubSession = session;

            lbxWorkOrderStatus.SelectedIndex = 0;
            lbxWorkOrderType.SelectedIndex = 0;
        }

        public static subfrmProductionSchedule GetChildInstance(Session session)
        {
            if (subfrmProductionScheduleReportChild == null)
                subfrmProductionScheduleReportChild = new subfrmProductionSchedule(session);
            return subfrmProductionScheduleReportChild;
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            Report report = new Report(SubSession.CompanyODBC);
            string type = lbxWorkOrderType.SelectedItem.ToString();
            string status = lbxWorkOrderStatus.SelectedItem.ToString();
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;

            DataTable table = report.RunProductionScheduleReport(type, status, fromDate, toDate);
            
            //dgvResults.DataSource = table;
            
            ProductionScheduleReport psReport = new ProductionScheduleReport();

            ParameterFields pFields = new ParameterFields();

            ParameterField pfCompany = new ParameterField();
            ParameterField pfStatus = new ParameterField();
            ParameterField pfType = new ParameterField();
            ParameterField pfFromDate = new ParameterField();
            ParameterField pfToDate = new ParameterField();

            ParameterDiscreteValue pfvCompany = new ParameterDiscreteValue();
            ParameterDiscreteValue pfvStatus = new ParameterDiscreteValue();
            ParameterDiscreteValue pfvType = new ParameterDiscreteValue();
            ParameterDiscreteValue pfvFromDate = new ParameterDiscreteValue();
            ParameterDiscreteValue pfvToDate = new ParameterDiscreteValue();


            pfvCompany.Value = SubSession.CompanyName;
            pfCompany.Name = "Company";
            pfCompany.CurrentValues.Add(pfvCompany);
            pFields.Add(pfCompany);

            pfvStatus.Value = status;
            pfStatus.Name = "Status";
            pfStatus.CurrentValues.Add(pfvStatus);
            pFields.Add(pfStatus);

            pfvType.Value = type;
            pfType.Name = "Type";
            pfType.CurrentValues.Add(pfvType);
            pFields.Add(pfType);

            pfvFromDate.Value = fromDate.ToString();
            pfFromDate.Name = "From Date";
            pfFromDate.CurrentValues.Add(pfvFromDate);
            pFields.Add(pfFromDate);

            pfvToDate.Value = toDate.ToString();
            pfToDate.Name = "To Date";
            pfToDate.CurrentValues.Add(pfvToDate);
            pFields.Add(pfToDate);

            psReport.SetDataSource(table);
            crystalReportViewer1.ParameterFieldInfo = pFields;
            crystalReportViewer1.ReportSource = psReport;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
