using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class PFReport1 : EDPComponent.FormBaseERP 
    {
        public PFReport1()
        {
            InitializeComponent();
            EmployeeListing();

        }

        public void EmployeeListing()
        {
            DataTable EmpDtbl = clsDataAccess.RunQDTbl("SELECT Title + ' ' + FirstName + ' ' + MiddleName + " +
            "' ' + LastName + ' - ' + ID AS EmpDetails FROM EDP_Payroll.dbo.tbl_Employee_Mast");
            int Cnt = 0;

            while (Cnt<  EmpDtbl.Rows.Count)
            {
                Employeecmb.Items.Add(EmpDtbl.Rows[Cnt][0].ToString());
                Cnt++;
            }

        }

        private void Populatecmd_Click(object sender, EventArgs e)
        {
            PopulateList();
        }

        public void PopulateList()
        {

            if (Employeecmb.SelectedIndex < 0)
            {
                MessageBox.Show("Select employee from the list...");
                Employeecmb.Focus();
                return;
            }

            if (FinacialYear.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Enter financial year...");
                FinacialYear.Focus();
                return;
            }

            string EmployeeCode = "";

            string[] EmpCode = new string[2];
            EmpCode = Employeecmb.Text.ToString().Split(new char[] { '-' });
            EmployeeCode = EmpCode[1].ToString().Trim();
            EmpCode = FinacialYear.Text.ToString().Trim().Split(new char[] { '-' });



            if (Information.IsNumeric(EmpCode[0]) == false || Information.IsNumeric(EmpCode[1]) == false)
            {
                MessageBox.Show("Enter Financial Year");
                return;
            }
          
            DataTable EmpDt = clsDataAccess.RunQDTbl("SELECT convert(varchar,PFDateMonth),EmplrOpeningBal," +
                "EmplrPFContAmount,EmplrPFClosing,EmpOpeningBal,EmpPFContAmount,EmpPFVolContAmount," +
                "EmpPFClosing,PFRefLoan,PFNonRefLoan,PFLoanRecov,PFLoanInt,PFInterest,ClosingBal " +
                "FROM tbl_Employee_PF WHERE EmpCode='" + EmployeeCode +
                "' AND PFDateMonth BETWEEN '4/1/" + EmpCode[0].ToString().Trim() +
                "' AND '3/31/" + EmpCode[1].ToString().Trim() + "' ORDER By PFDateMonth");
            PFGrid.DataSource = EmpDt;


        }

        private void Employeecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinacialYear.Focus();
        }


    }
       
}
