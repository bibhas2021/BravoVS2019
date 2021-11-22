using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PayRollManagementSystem
{
    public partial class EmpExp : Form
    {
        public EmpExp()
        {
            InitializeComponent();
        }
        public void popdas4(string lo,string mon,string ss)
        {
            //DataTable DTResource = new DataTable();
            //DataColumn myDataColumn;

            string FTot = "", CTot = "",GTot = "",DTot = "",BTot = "";
            double Famt = 0, Camt = 0, Gamt = 0, Damt = 0,Bamt = 0;

           // empEr.CurrentCell.Selected = false;
            this.empEr.AllowUserToAddRows = false;
           empEr.RowHeadersVisible = false;

           DataTable DTResource2 = new DataTable();
           //  DataTable DT3 = new DataTable();
           DataColumn myDataColumn2;
           DataRow row2;
           myDataColumn2 = new DataColumn();
           myDataColumn2.DataType = Type.GetType("System.String");
           myDataColumn2.ColumnName = "Ename";
           DTResource2.Columns.Add(myDataColumn2);

           

            String str;
            DataTable DT = new DataTable();
            //str = "select a.Location_Name as Location,b.Month as Month,b.GrossAmount as Amt from tbl_Emp_Location a,tbl_Employee_SalaryMast b ,tbl_Employee_CliantMaster c where b.Location_id=a.Location_ID and c.Client_id=a.Cliant_ID";
          // str = "select a.Location_Name as Location,b.Month as Month,b.GrossAmount as Amt from tbl_Emp_Location a,tbl_Employee_SalaryMast b ,tbl_Employee_CliantMaster c where b.Location_id=a.Location_ID and c.Client_id=a.Cliant_ID";
           // str = "select a.FirstName,a.MiddleName,a.LastName,b.Month,b.GrossAmount from tbl_Employee_Mast a,tbl_Employee_SalaryMast b where a.ID=b.Emp_Id and (b.Location_id='" + lo + "') and (b.Month='" + mon + "') and (b.Session='" + ss + "')";

            str = "select ((CASE WHEN ltrim(rtrim(a.FirstName)) != '' THEN a.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(a.MiddleName)) != '' THEN a.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(a.LastName)) != '' THEN a.LastName + ' ' ELSE '' END)) AS 'Ename',b.Emp_Id,b.Month,b.DaysPresent,b.OT,b.Basic,b.GrossAmount,b.TotalSal,b.TotalDec,b.NetPay as NetPay from tbl_Employee_Mast a,tbl_Employee_SalaryMast b where a.ID=b.Emp_Id  and (b.Location_id='" + lo + "') and (b.Month='" + mon + "') and (b.Session='" + ss + "')";

           // str = "select ((CASE WHEN ltrim(rtrim(a.FirstName)) != '' THEN a.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(a.MiddleName)) != '' THEN a.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(a.LastName)) != '' THEN a.LastName + ' ' ELSE '' END)) AS 'Ename',b.Emp_Id,b.Month,b.DaysPresent,b.Basic,b.GrossAmount,b.TotalSal,c.EAAMT as 'ADVANCE',b.TotalDec,b.NetPay from tbl_Employee_Mast a,tbl_Employee_SalaryMast b,tbl_Employee_Advance c where a.ID=c.EAEID and a.ID=b.Emp_Id and (b.Location_id='" + lo + "') and (b.Month='" + mon + "') and (b.Session='" + ss + "')";
            DT = clsDataAccess.RunQDTbl(str);
            int sum = 0;
            foreach (DataRow dr in DT.Rows)
            {
                sum += Convert.ToInt32(dr["GrossAmount"]);
            }
            label2.Text = Convert.ToString(sum);
            
           /// empEr.FooterRow.Cells[0].Text = "Total";
            ///empEr.FooterRow.Cells[1].Font.Bold = true; 
            ///
            String str2 = "select sum(NetPay) from tbl_Employee_SalaryMast  where  (Location_id='" + lo + "') and (Month='" + mon + "') and (Session='" + ss + "') group by Month,Session";
            CTot = Convert.ToString(clsDataAccess.GetresultS(str2));

            if (CTot == "" || CTot == null) { CTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Camt = Camt + Convert.ToDouble(CTot);
            DTResource2.Merge(DT);


            String str3 = "select sum(TotalSal) from tbl_Employee_SalaryMast  where  (Location_id='" + lo + "') and (Month='" + mon + "') and (Session='" + ss + "') group by Month,Session";
            FTot = Convert.ToString(clsDataAccess.GetresultS(str3));

            if (FTot == "" || FTot == null) { FTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Famt = Famt + Convert.ToDouble(FTot);
            //DTResource2.Merge(DT);

            String str4 = "select sum(GrossAmount) from tbl_Employee_SalaryMast  where  (Location_id='" + lo + "') and (Month='" + mon + "') and (Session='" + ss + "') group by Month,Session";
            GTot = Convert.ToString(clsDataAccess.GetresultS(str4));

            if (GTot == "" || GTot == null) { GTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Gamt = Gamt + Convert.ToDouble(GTot);
           // DTResource2.Merge(DT);


            String str5 = "select sum(TotalDec) from tbl_Employee_SalaryMast  where  (Location_id='" + lo + "') and (Month='" + mon + "') and (Session='" + ss + "') group by Month,Session";
            DTot = Convert.ToString(clsDataAccess.GetresultS(str5));

            if (DTot == "" || DTot == null) { DTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Damt = Damt + Convert.ToDouble(DTot);
           // DTResource2.Merge(DT);

            String str6 = "select sum(Basic) from tbl_Employee_SalaryMast  where  (Location_id='" + lo + "') and (Month='" + mon + "') and (Session='" + ss + "') group by Month,Session";
            BTot = Convert.ToString(clsDataAccess.GetresultS(str6));

            if (BTot == "" || BTot == null) { BTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Bamt = Bamt + Convert.ToDouble(BTot);

            row2 = DTResource2.NewRow();
            row2["Ename"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Ename"] = "Total : ";
            row2["NetPay"] = Camt.ToString("0.00");
            row2["TotalSal"] = Famt.ToString("0.00");
            row2["GrossAmount"] = Gamt.ToString("0.00");
            row2["TotalDec"] = Damt.ToString("0.00");
            row2["Basic"] = Bamt.ToString("0.00");
            DTResource2.Rows.Add(row2);


            empEr.DataSource = DTResource2;

        }

        private void empEr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
