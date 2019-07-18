using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionSchedule.Forms.Report_Sub_Forms
{
    // Form to launch Raw Material Daily Stock Status report. 
    // No report created yet and form is just a placeholder.
    public partial class subfrmRawMaterialDailyStockStatus : Form
    {
        private static subfrmRawMaterialDailyStockStatus subfrmRawMaterialDailyStockStatusChild;

        public subfrmRawMaterialDailyStockStatus()
        {
            InitializeComponent();
        }

        public static subfrmRawMaterialDailyStockStatus GetChildInstance()
        {
            if (subfrmRawMaterialDailyStockStatusChild == null)
                subfrmRawMaterialDailyStockStatusChild = new subfrmRawMaterialDailyStockStatus();
            return subfrmRawMaterialDailyStockStatusChild;
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
