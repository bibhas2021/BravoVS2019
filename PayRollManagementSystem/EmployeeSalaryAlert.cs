using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class EmployeeSalaryAlert : EDPComponent.FormBaseERP
    {
        public EmployeeSalaryAlert()
        {
            InitializeComponent();
        }

        private void cmbdEmpId_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select ID,FirstName+' '+MiddleName+' '+LastName as [Employee Name] from tbl_Employee_Mast");
            if (dt.Rows.Count > 0)
            {
                cmbdEmpId.LookUpTable = dt;
                cmbdEmpId.ReturnIndex = 1;
            }
        }

        private void cmbdEmpId_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            txtEmpName.Text = cmbdEmpId.ReturnValue;
        }
    }
}