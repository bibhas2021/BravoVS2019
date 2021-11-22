using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class subfrmEmployeeSalarySheetPFESIStatus : Form
    {
        public int intReturnValue = 0;
        int statuscode = 0;
        public subfrmEmployeeSalarySheetPFESIStatus(int Code)
        {
            statuscode = Code;
            InitializeComponent();
        }

        private void subfrmEmployeeSalarySheetPFESIStatus_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = statuscode-1;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            switch (cmbStatus.Text)
            { 
                case "w/o PF and ESI":
                    intReturnValue = 1;
                    break;
                case "w/o PF":
                    intReturnValue = 2;
                    break;
                case "w/o ESI":
                    intReturnValue = 3;
                    break;
                case "With PF and ESI":
                    intReturnValue = 4;
                    break;
            }
            this.Close();
        }
    }
}
