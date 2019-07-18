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
    // Form to launch Work Order Material Requirements report. 
    // No report created yet and form is just a placeholder.
    public partial class subfrmWorkOrderMaterialRequirements : Form
    {
        private static subfrmWorkOrderMaterialRequirements subfrmWorkOrderMaterialRequirementsChild;

        public subfrmWorkOrderMaterialRequirements()
        {
            InitializeComponent();
        }

        public static subfrmWorkOrderMaterialRequirements GetChildInstance()
        {
            if (subfrmWorkOrderMaterialRequirementsChild == null)
                subfrmWorkOrderMaterialRequirementsChild = new subfrmWorkOrderMaterialRequirements();
            return subfrmWorkOrderMaterialRequirementsChild;
        }
    }
}
