using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class PFLoanRegister : EDPComponent.FormBaseERP 
    {
        public PFLoanRegister()
        {
            InitializeComponent();
        }

        private void PFLoanRegister_Load(object sender, EventArgs e)
        {

        }

        private void gridPrint1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PFGrid.LoadDataTable("SELECT (SELECT LoanDate FROM tbl_Employee_PF_Loan WHERE EmpCode=Emptbl.ID) As 'Date'," +
            "Title + ' ' + FirstName + ' ' + MiddleName + ' ' + LastName  'Name Of Employee'," +
            "PF As 'P.F. Account',(SELECT LoanAmount FROM tbl_Employee_PF_Loan WHERE EmpCode=Emptbl.ID) AS 'Opening Loan Balance'," +
            "(SELECT LoanRepaid FROM tbl_Employee_PF_Loan WHERE EmpCode=Emptbl.ID) AS 'Loan recovered'," +
            "(SELECT ((LoanAmount-LoanRepaid)*InterestRate/100) FROM tbl_Employee_PF_Loan WHERE EmpCode=Emptbl.ID) As 'Loan Interest'," +
            "(SELECT (LoanAmount-LoanRepaid) FROM tbl_Employee_PF_Loan WHERE EmpCode=Emptbl.ID) AS 'Due balance amount' FROM tbl_Employee_Mast As Emptbl ORDER By 'Name Of Employee'");
            PFGrid.Columns[1].Width = 200;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PFGrid.Print();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    printGridView1.LoadDataTable("SELECT Code,Title,FirstName,MiddleName," +
        //        "LastName FROM tbl_Employee_Mast ORDER By FirstName");
        //    //DataPreviewGrid.DataSource = EDPFuncMeth.
        //}

          
  
    }
}