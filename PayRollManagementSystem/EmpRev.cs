using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class EmpRev : Form
    {
        public EmpRev()
        {
            InitializeComponent();
        }
        public void popdas3(string lo,string mon,string ss,string bl)
        {
            DataTable DTResource = new DataTable();
            DataColumn myDataColumn;
            this.dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;

            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0,Oamt = 0;

            DataTable DTResource2 = new DataTable();
            //  DataTable DT3 = new DataTable();
            DataColumn myDataColumn2;
            DataRow row2;
            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "DesignationName";
            DTResource2.Columns.Add(myDataColumn2);
           
            String str;
            DataTable DT = new DataTable();
            DataTable DT2 = new DataTable();
            //str = "select a.Location_Name as Location,b.Month as Month,b.GrossAmount as Amt from tbl_Emp_Location a,tbl_Employee_SalaryMast b ,tbl_Employee_CliantMaster c where b.Location_id=a.Location_ID and c.Client_id=a.Cliant_ID";
            
           //str = "select a.Location_Name as Location,b.Month as Month,b.GrossAmount as Amt from tbl_Emp_Location a,tbl_Employee_SalaryMast b ,tbl_Employee_CliantMaster c where b.Location_id=a.Location_ID and c.Client_id=a.Cliant_ID";

            str = "select a.DesignationName as DesignationName,b.NoOfPersonnel as NoOfPersonnel,b.Attendance as Attendance,b.Hour as Hour,CAST(b.RATE AS numeric(18,2)) as RATE,CAST(b.BILLAMT AS numeric(18,2)) as BILLAMT from tbl_Employee_DesignationMaster a,paybillD b where a.SlNo=b.desig_ID and (b.BILLNO='" + bl + "')";
    
            DT = clsDataAccess.RunQDTbl(str);

            string str4 = "select OCHARGES as DesignationName,0 as NoOfPersonnel ,OQty as Attendance,' ' as Hour,ORate as RATE,OAMT as BILLAMT from paybillO where (BILLNO='" + bl + "')";
            DT2 = clsDataAccess.RunQDTbl(str4);
            if (DT2.Rows.Count > 0)
            {

                DT.Merge(DT2,true, MissingSchemaAction.Ignore);
            }
            int sum = 0;
            foreach (DataRow dr in DT.Rows)
            {
                sum += Convert.ToInt32(dr["BILLAMT"]);
            }
            label2.Text = Convert.ToString(sum);

            String str2 = "select sum(BILLAMT)  from paybillD    where  (BILLNO='" + bl + "') ";
            CTot = Convert.ToString(clsDataAccess.GetresultS(str2));

            if (CTot == "" || CTot == null) { CTot = "0.00"; }
            // row2["NetPay"] = Convert.ToString(CTot);
            Camt = Camt + Convert.ToDouble(CTot);
            DTResource2.Merge(DT);

            string str6 = "select isNUll(sum(OAMT),0) as BILLAMT from paybillO where (BILLNO='" + bl + "') ";
            string OTot = "";
            OTot = Convert.ToString(clsDataAccess.GetresultS(str6));
            Camt = Camt + Convert.ToDouble(OTot);





            row2 = DTResource2.NewRow();
            row2["DesignationName"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["DesignationName"] = "Total : ";
            row2["BILLAMT"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);

            dgv.DataSource = DTResource2;

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EmpRev_Load(object sender, EventArgs e)
        {

        }
    }
}
