using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class PopUpDashBoard : Form
    {
        public string clname = "";
        public PopUpDashBoard()
        {
            InitializeComponent();
        }

        private void Loc_pop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        public void popdas(string cl,string mon,string ss)
        {
            
            this.Loc_pop.AllowUserToAddRows = false;
            Loc_pop.RowHeadersVisible = false;

            string FTot = "", CTot = "",ATot ="";
            double Famt = 0, Camt = 0,Aamt = 0;

            DataTable DTResource2 = new DataTable();
            //  DataTable DT3 = new DataTable();
            DataColumn myDataColumn2;
            DataRow row2;
            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "BILLNO";
            DTResource2.Columns.Add(myDataColumn2);



          

            String str;
            DataTable DT = new DataTable();
            //str = "select a.Location_Name as Location,b.Month as Month,b.GrossAmount as Amt from tbl_Emp_Location a,tbl_Employee_SalaryMast b ,tbl_Employee_CliantMaster c where b.Location_id=a.Location_ID and c.Client_id=a.Cliant_ID";
            
            //str = "select a.Location_Name as Location,b.GrossAmount,b.Month,b.Session as Amt from tbl_Emp_Location a,tbl_Employee_SalaryMast b ,tbl_Employee_CliantMaster c where b.Location_id=a.Location_ID and c.Client_id=a.Cliant_ID";

            str = "select a.BILLNO as BILLNO ,b.Location_Name,CAST(sum(a.TotAMT) AS numeric(18,2)) as Amt,CAST(a.ServiceAmount AS numeric(18,2)) as ServiceAmount ,CAST(a.ScAmt AS numeric(18,2)) as ScAmt,b.Location_ID,a.Session,(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as Month from paybill a ,tbl_Emp_Location b where a.Location_ID=b.Location_ID and (a.Cliant_ID='" + cl + "') and ((DATENAME(MONTH,Cast('01-'+[Month] as datetime))) ='" + mon + "') and (Session='" + ss + "')  group by a.BILLNO,b.Location_Name,a.Month,a.Session,a.ServiceAmount,b.Location_ID,a.ScAmt";
            DT = clsDataAccess.RunQDTbl(str);

            int sum = 0;
            foreach (DataRow dr in DT.Rows)
            {
                sum += Convert.ToInt32(dr["Amt"]) + Convert.ToInt32(dr["ServiceAmount"]) + Convert.ToInt32(dr["ScAmt"]);
            }
            label2.Text = Convert.ToString(sum);

            String str2 = "select sum(TotAMT) as Amt  from paybill  where  (Cliant_ID='" + cl + "') and ((DATENAME(MONTH,Cast('01-'+[Month] as datetime))) ='" + mon + "') and (Session='" + ss + "')  group by Month,Session";
            CTot = Convert.ToString(clsDataAccess.GetresultS(str2));

            if (CTot == "" || CTot == null) { CTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Camt = Camt + Convert.ToDouble(CTot);
            DTResource2.Merge(DT);


            String str3 = "select sum(ServiceAmount) as Amt  from paybill  where  (Cliant_ID='" + cl + "') and ((DATENAME(MONTH,Cast('01-'+[Month] as datetime))) ='" + mon + "') and (Session='" + ss + "')  group by Month,Session";
            FTot = Convert.ToString(clsDataAccess.GetresultS(str3));

            if (FTot == "" || FTot == null) { FTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Famt = Famt + Convert.ToDouble(FTot);
           // DTResource2.Merge(DT);


            String str4 = "select sum(ScAmt) as Amt  from paybill  where  (Cliant_ID='" + cl + "') and ((DATENAME(MONTH,Cast('01-'+[Month] as datetime))) ='" + mon + "') and (Session='" + ss + "')  group by Month,Session";
            ATot = Convert.ToString(clsDataAccess.GetresultS(str4));

            if (ATot == "" || ATot == null) { ATot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Aamt = Aamt + Convert.ToDouble(ATot);





            row2 = DTResource2.NewRow();
            row2["BILLNO"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["BILLNO"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            row2["ServiceAmount"] = Famt.ToString("0.00");
            row2["ScAmt"] = Aamt.ToString("0.00");
            DTResource2.Rows.Add(row2);


            Loc_pop.DataSource = DTResource2;

        }

        private void PopUpDashBoard_Load(object sender, EventArgs e)
        {
           // popdas();
        }

        private void popdas(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Loc_pop_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rw = 0, cl = 0;
            rw = Loc_pop.CurrentCell.RowIndex;
            cl = Loc_pop.CurrentCell.ColumnIndex;
            string lo = Loc_pop.Rows[rw].Cells["Location_ID"].Value.ToString();
            string mon = Loc_pop.Rows[rw].Cells["Month"].Value.ToString();
            string ss = Loc_pop.Rows[rw].Cells["Session"].Value.ToString();
            string bl = Loc_pop.Rows[rw].Cells["BILLNO"].Value.ToString();
            EmpRev er = new EmpRev();
            er.popdas3(lo,mon,ss,bl);
            er.ShowDialog();
        }
    }
}
