using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;


namespace PayRollManagementSystem
{
    public partial class PFReport2 : EDPComponent.FormBaseERP 
    {
        public PFReport2()
        {
            InitializeComponent();
        }
                  

     
        //public void SectionList()
        //{
        //    DataTable SecDatatbl = clsDataAccess.RunQDTbl("select Section,Slno FROM tbl_Employee_Sectionmaster");

        //    Int32 Cnt = 0;

        //    for (Cnt = 0; Cnt < SecDatatbl.Rows.Count; Cnt++)
        //    {
        //        SectionID.Items.Add(SecDatatbl.Rows[Cnt][0].ToString());

        //    }
                

        //}

            
        //private void PFReport2_Load(object sender, EventArgs e)
        //{
        //    SectionList();            
        //}
        public void ListEmpConsolPF()
        { 
            //ConsolMonthdttmpkr

            DataTable ConsolDtTbl = clsDataAccess.RunQDTbl("SELECT convert(varchar,PFDateMonth)," +
                " Section,PFDateMonth,max(PFDueAmt),sum(EmpPFContAmount),sum(PFPension)," +
                "sum(EmplrPFContAmount),sum(PFAcc2),sum(PFAcc21),sum(PFAcc22),sum(PFInterest)," +
                "sum(ClosingBal) FROM (tbl_Employee_Mast INNER JOIN tbl_Employee_Sectionmaster ON " +
                "tbl_Employee_Mast.SecId = tbl_Employee_Sectionmaster.Slno) INNER JOIN tbl_Employee_PF ON  " +
                "tbl_Employee_PF.EmpCode = tbl_Employee_Mast.ID WHERE MONTH(PFDateMonth )=" + 
                ConsolMonthdttmpkr.Value.Month.ToString() + " AND YEAR(PFDateMonth)=" +
               ConsolMonthdttmpkr.Value.Year.ToString() + " GROUP By Section,PFDateMonth,PFPension," +
               "EmplrPFContAmount,PFAcc2,PFAcc21,PFAcc22,PFInterest,ClosingBal ORDER By PFDateMonth ");

            ConsolGrid.DataSource = ConsolDtTbl;

        }
        
        private void SaveCmd_Click(object sender, EventArgs e)
        {
            ListEmpConsolPF();
        }
    }
}