using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class PopUpExp : Form
    {
        public PopUpExp()
        {
            InitializeComponent();
        }

        public void popdas2(string cl,string mon,string ss)
        {
            DataTable DTResource = new DataTable();
            DataColumn myDataColumn;
            this.popexp.AllowUserToAddRows = false;
            popexp.RowHeadersVisible = false;
           // popexp.ColumnHeadersVisible = false;


            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0;

            DataTable DTResource2 = new DataTable();
            //  DataTable DT3 = new DataTable();
            DataColumn myDataColumn2;
            DataRow row2;
            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Location_Name";
            DTResource2.Columns.Add(myDataColumn2);

            String str;
            DataTable DT = new DataTable();
            //str = "select a.Location_Name as Location,b.Month as Month,b.GrossAmount as Amt from tbl_Emp_Location a,tbl_Employee_SalaryMast b ,tbl_Employee_CliantMaster c where b.Location_id=a.Location_ID and c.Client_id=a.Cliant_ID";
            //str = "select a.Location_Name as Location,b.Month as Month,b.GrossAmount as Amt,b.Session from tbl_Emp_Location a,tbl_Employee_SalaryMast b ,tbl_Employee_CliantMaster c where b.Location_id=a.Location_ID and c.Client_id=a.Cliant_ID";
            //str = "select c.Location_Name, sum(a.GrossAmount+d.pf_employer_cont+d.esi_employer_cont) as Amt,a.Month,a.Session from tbl_Employee_SalaryMast a,tbl_Emp_Location c , tbl_employers_contribution d where c.Location_ID=a.Location_id  and d.emp_id=a.Emp_Id and (a.Month = '" + mon + "') AND (a.Session ='" + cl + "') and (c.Cliant_ID='"+cl+"') GROUP BY a.Month, a.Session ,c.Location_Name";
            str = "select c.Location_Name as Location_Name,c.Location_ID, sum(a.GrossAmount) as Amt,a.Month,a.Session from tbl_Employee_SalaryMast a,tbl_Emp_Location c  where c.Location_ID=a.Location_id   and (a.Month ='" + mon + "') AND (a.Session ='" + ss + "') and (c.Cliant_ID='" + cl + "') GROUP BY a.Month, a.Session ,c.Location_Name,c.Location_ID";

            DT = clsDataAccess.RunQDTbl(str);
            int sum = 0;
            foreach (DataRow dr in DT.Rows)
            {
                sum += Convert.ToInt32(dr["Amt"]);
            }
            label2.Text = Convert.ToString(sum);

            String str2 = "select sum(GrossAmount) as Amt  from tbl_Employee_SalaryMast a, tbl_Emp_Location c  where c.Location_ID=a.Location_id and  (c.Cliant_ID='" + cl + "') and (a.Month ='" + mon + "') and (a.Session='" + ss + "')  group by a.Month,a.Session";
            CTot = Convert.ToString(clsDataAccess.GetresultS(str2));

            if (CTot == "" || CTot == null) { CTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Camt = Camt + Convert.ToDouble(CTot);
            DTResource2.Merge(DT);


            row2 = DTResource2.NewRow();
            row2["Location_Name"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Location_Name"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);

            popexp.DataSource = DTResource2;

        }

        //public void emp(string loc)
        //{
        //    String str;
        //    DataTable DT = new DataTable();
        //    str = "select ((CASE WHEN ltrim(rtrim(a.FirstName)) != '' THEN a.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(a.MiddleName)) != '' THEN a.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(a.LastName)) != '' THEN a.LastName + ' ' ELSE '' END)) AS 'Ename' from tbl_Employee_Mast a,tbl_Employee_Attend b,tbl_Emp_Location c where a.ID=b.ID and b.LOcation_ID=c.Location_ID and (c.Location_Name='" + loc + "')";
        //    DT = clsDataAccess.RunQDTbl(str);
        //    popexp.DataSource = DT;
        //}

        private void popexp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rw = 0, cl = 0;
            rw = popexp.CurrentCell.RowIndex;
            cl = popexp.CurrentCell.ColumnIndex;
            string lo = popexp.Rows[rw].Cells["Location_ID"].Value.ToString();
            string mon = popexp.Rows[rw].Cells["Month"].Value.ToString();
           string ss = popexp.Rows[rw].Cells["Session"].Value.ToString();
            EmpExp ee = new EmpExp();
            ee.popdas4(lo,mon,ss);
            ee.ShowDialog();
        }
    }
}
