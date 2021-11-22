using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
namespace PayRollManagementSystem
{
    public partial class frmDashboard : Form
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        public frmDashboard()
        {
            InitializeComponent();
        }
        string SESS = "", MONTH = "",Comp = "";
        List<String> list = new List<String>();
        int old_CID = 0, New_CID = 0, code=1;
        int FTot = 0, ETot = 0, PTot = 0, ATot = 0;
        DataTable DTResource ; DataTable DTResource2; DataTable DTEmpCode;
  

        
        public void CLoc_view_t()
        {
            cmbCompany.Text = "";
            DTResource = new DataTable();
            DTResource2 = new DataTable();
            DataColumn myDataColumn, myDataColumn2;
            DataRow row, row2;
            string clname = "", LocName = "";
            MONTH = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            dgv_CLoc_Loc.RowHeadersVisible = false;

          //  DataGridViewColumn column = dgv_CLoc_Client.Columns[0];
           // column.Width = 60;

           // DataGridViewColumn column2 = dgv_CLoc_Client.Columns[1];
            //column2.Width = 60;

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "ClientName";
            DTResource.Columns.Add(myDataColumn);

            //myDataColumn = new DataColumn();
            //myDataColumn.DataType = Type.GetType("System.String");
            //myDataColumn.ColumnName = "Location_ID";
            //DTResource.Columns.Add(myDataColumn);
            

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "LocationName";
            DTResource.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "EmployeeStrength";
            DTResource.Columns.Add(myDataColumn);

            //=========================================================

            //myDataColumn2 = new DataColumn();
            //myDataColumn2.DataType = Type.GetType("System.String");
            //myDataColumn2.ColumnName = "Location_ID";
            //DTResource2.Columns.Add(myDataColumn2);

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "LocationName";
            DTResource2.Columns.Add(myDataColumn2);

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "EmployeeStrength";
            DTResource2.Columns.Add(myDataColumn2);

            DataTable DTClient = clsDataAccess.RunQDTbl("Select c.Client_Name as ClientName,c.Client_id as ClientId,l.Location_Name as LocName, l.Location_ID from tbl_Emp_Location L,tbl_Employee_CliantMaster c where c.Client_id = l.Cliant_ID "); ;
            for (int i = 0; i <= DTClient.Rows.Count - 1; i++)
            {
                New_CID = Convert.ToInt32(DTClient.Rows[i]["ClientId"]);
                if (New_CID == old_CID)
                {
                    clname = Convert.ToString(DTClient.Rows[i]["ClientName"]);
                    LocName = Convert.ToString(DTClient.Rows[i]["LocName"]);
                    
                    DTEmpCode = clsDataAccess.RunQDTbl("SELECT ID,LOcation_ID FROM tbl_Employee_Attend WHERE (LOcation_ID =" + DTClient.Rows[i]["Location_ID"] + ")AND Company_id = '" + code + "' AND Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "'");
                    String str = clsDataAccess.GetresultS("SELECT COUNT(*) AS Sum FROM tbl_Employee_Attend WHERE (LOcation_ID =" + DTClient.Rows[i]["Location_ID"] + ") AND Company_id = '" + code + "' AND Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "'");
                    ETot = Convert.ToInt32(str);
                    //PTot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT COUNT(*) FROM tbl_Emp_Posting WHERE (ISDATE(FromDate) >= '" + DateTime.Today.ToString("dd/MMM/yyyy") + "')) AND (ISDATE(ToDate) <= '" + DateTime.Today.ToString("dd/MMM/yyyy") + "') and (LOcation_ID=" + DTClient.Rows[i]["LOcation_ID"] + ")"));
                    //ATot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT COUNT(*) FROM tbl_Emp_Posting WHERE (ISDATE(FromDate) >= '" + DateTime.Today.ToString("dd/MMM/yyyy") + "')) AND (ISDATE(ToDate) <= '" + DateTime.Today.ToString("dd/MMM/yyyy") + "') and (LOcation_ID=" + DTClient.Rows[i]["LOcation_ID"] + ")"));
                    FTot = FTot + ETot;
                }
                else
                {
                    if (clname != "")
                    {
                        row = DTResource.NewRow();
                        row["ClientName"] = clname;
                        row["LocationName"] = LocName;
                        row["EmployeeStrength"] = FTot;

                        DTResource.Rows.Add(row);
                        FTot = 0; 
                        //PTot = 0; ATot = 0; ;
                    }
                    if (clname != "" && LocName != "")
                    {
                        row2 = DTResource2.NewRow();
                        row2["LocationName"] = LocName;
                        row2["EmployeeStrength"] = ETot;

                        DTResource2.Rows.Add(row2);
                        ETot = 0;

                    }
                    old_CID = Convert.ToInt32(DTClient.Rows[i]["ClientId"]);
                    clname = Convert.ToString(DTClient.Rows[i]["ClientName"]);
                    LocName = Convert.ToString(DTClient.Rows[i]["LocName"]);
                    DTEmpCode = clsDataAccess.RunQDTbl("SELECT ID,LOcation_ID FROM tbl_Employee_Attend WHERE (LOcation_ID =" + DTClient.Rows[i]["Location_ID"] + ")AND Company_id = '" + code + "' AND Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "'");
                    ETot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT COUNT(*) AS Sum FROM tbl_Employee_Attend WHERE (LOcation_ID =" + DTClient.Rows[i]["Location_ID"] + ") AND Company_id = '" + code + "' AND Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "'"));
                    //PTot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT COUNT(*) FROM tbl_Emp_Posting WHERE (ISDATE(FromDate) >= '" + DateTime.Today.ToString("dd/MMM/yyyy") + "')) AND (ISDATE(ToDate) <= '" + DateTime.Today.ToString("dd/MMM/yyyy") + "') and (LOcation_ID=" + DTClient.Rows[i]["LOcation_ID"] + ")"));
                    //ATot = Convert.ToInt32(clsDataAccess.GetresultS("SELECT COUNT(*) FROM tbl_Emp_Posting WHERE (ISDATE(FromDate) >= '" + DateTime.Today.ToString("dd/MMM/yyyy") + "')) AND (ISDATE(ToDate) <= '" + DateTime.Today.ToString("dd/MMM/yyyy") + "') and (LOcation_ID=" + DTClient.Rows[i]["LOcation_ID"] + ")"));
                    FTot = FTot + ETot;

                }
            }
            row = DTResource.NewRow();
            row["ClientName"] = clname;
            row["EmployeeStrength"] = FTot;

            row2 = DTResource2.NewRow();
            row2["LocationName"] = LocName;
            row2["EmployeeStrength"] = ETot;

            DTResource2.Rows.Add(row2);

            DTResource.Rows.Add(row);

            ETot = 0; PTot = 0; ATot = 0; FTot = 0;

            
        }
        

        public void CLoc_view()
        {
            //Thread Th1 = new Thread(new ThreadStart(CLoc_view_t));
            //Th1.Start();

            CLoc_view_t();
            dgv_CLoc_Client.DataSource = DTResource;
            dgv_CLoc_Loc.DataSource = DTResource2;
            dgv_CLoc_Client.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_CLoc_Loc.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_CLoc_Loc.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_CLoc_Client.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_CLoc_Client.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


        }

        //Ritesh Kumar
        public void Exp_view()
        {
            cmbCompany.Text = "";
            string FTot="",CTot="";
            double Famt = 0,Camt = 0;
            dgv_EXP_Client.ReadOnly = true;
            dgv_EXP_Mon.ReadOnly = true;
            
            DataTable DTEmpCode;

            DataTable DTResource = new DataTable();
            DataTable DTResource2 = new DataTable();
            DataTable DT3 = new DataTable();
            DataColumn myDataColumn, myDataColumn2;
            DataRow row, row2, row3;
            string clname = "", LocName = "";  

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Month";
            DTResource.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Amt";
            DTResource.Columns.Add(myDataColumn);

            //=========================================================

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Client";
            DTResource2.Columns.Add(myDataColumn2);

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Month";
            DTResource2.Columns.Add(myDataColumn2);

            //myDataColumn2 = new DataColumn();
            //myDataColumn2.DataType = Type.GetType("System.Double");
            ////myDataColumn2.ColumnName = "Amt";
            //DTResource2.Columns.Add(myDataColumn2);

            //=========================================================
           
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                row = DTResource.NewRow();

                row["Month"] =listBox1.Items[i].ToString();
                FTot = "";
                try
                {
                   // String str = "SELECT SUM(a.GrossAmount) AS aMT,a.Month,a.Session FROM tbl_Employee_SalaryMast a,tbl_employers_contribution b  WHERE b.emp_id=a.Emp_Id and  a.Month='" + listBox1.Items[i].ToString() + "' AND   a.SESSION='" + cmbYear.Text + "' AND Company_id = '" + code + "' GROUP BY a.Month, a.Session";
                    string str = "SELECT CAST(SUM(GrossAmount) AS numeric(18,2)) AS aMT,Month,Session FROM tbl_Employee_SalaryMast   WHERE  (Month='" + listBox1.Items[i].ToString() + "') AND (SESSION='" + cmbYear.Text + "') AND (Company_id = '" + code + "') GROUP BY Month, Session";
                    //String str = "SELECT SUM(GrossAmount) AS aMT,Month,Session FROM tbl_Employee_SalaryMast WHERE Month='" + listBox1.Items[i].ToString() + "' AND   SESSION='" + cmbYear.Text + "' AND Company_id = '" + code + "' GROUP BY Month, Session";
                    FTot = Convert.ToString(clsDataAccess.GetresultS(str));
                }
                catch (Exception ex)
                {
                    FTot = "0.00";
                }
                if (FTot == "" || FTot == null) { FTot = "0.00"; } 
                row["Amt"] =Convert.ToString(FTot);
                Famt = Famt + Convert.ToDouble(FTot);
                DTResource.Rows.Add(row);
               
            }

            row = DTResource.NewRow();
            row["Month"] = " ";
            DTResource.Rows.Add(row);

            row = DTResource.NewRow();
            row["Month"] = "Total : ";
            row["Amt"] = Famt.ToString("0.00");           
            DTResource.Rows.Add(row);

            //=========================================================

            DataTable DT4 = new DataTable();
                for (int i = 0; i < listBox1.Items.Count; i++)      //for Month Increment
                {
                    row2 = DTResource.NewRow();

                    row2["Month"] = listBox1.Items[i].ToString();
                    CTot = "";
                    try
                    {
                        

                        //String str = "select a.GrossAmount as Amt,a.Month,a.Session,b.Client_Name as Client from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID  and (a.Month = '" + listBox1.Items[i].ToString() + "') AND (a.Session = '" + cmbYear.Text + "') AND (a.Company_id = '" + code + "') ";

                        String str = "select CAST(SUM(a.GrossAmount) AS numeric(18,2)) as Amt,a.Month,a.Session,b.Client_Name as Client,b.Client_id from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c  where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID  and (a.Month = '" + listBox1.Items[i].ToString() + "') AND (a.Session = '" + cmbYear.Text + "') AND (a.Company_id = '" + code + "') GROUP BY a.Month, a.Session ,b.Client_Name ,b.Client_id";

                       
                        DT4 = clsDataAccess.RunQDTbl(str);


                        String str2 = "select CAST(SUM(a.GrossAmount) AS numeric(18,2)) as Amt from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c  where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID  and (a.Month = '" + listBox1.Items[i].ToString() + "') AND (a.Session = '" + cmbYear.Text + "') AND (a.Company_id = '" + code + "') GROUP BY a.Month, a.Session ";
                        CTot = Convert.ToString(clsDataAccess.GetresultS(str2));

                    }
                    catch (Exception ex)
                    {
                        CTot = "0.00";
                    }
                    if (CTot == "" || CTot == null) { CTot = "0.00"; }

                    Camt = Camt + Convert.ToDouble(CTot);
                    DTResource2.Merge(DT4);
                }

            row2 = DTResource2.NewRow();
            row2["Client"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Client"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);

            FTot="";
            dgv_EXP_Mon.DataSource = DTResource;
            dgv_EXP_Client.DataSource = DTResource2;
            dgv_EXP_Client.AutoResizeColumns();
           // dgv_EXP_Client.Columns[4].Visible = false;
            dgv_EXP_Mon.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_EXP_Client.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_EXP_Client.AllowUserToAddRows = false;
            dgv_EXP_Client.Columns["Session"].Visible = false;
            dgv_EXP_Client.Columns["Client_id"].Visible = false;
            //dgv_EXP_Client.Columns["Client_id"].Visible = false;
            dgv_EXP_Client.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;




           // dgv_EXP_Client.Rows[dgv_EXP_Client.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;


            
        }

        //Ritesh Kumar
        public void Rev_view()
        {
            
            cmbCompany.Text = "";
            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0;

            dgv_REV_Mon.ReadOnly = true;
            dgv_REV_Client.ReadOnly = true;

            

            DataTable DTResource = new DataTable();
            DataTable DTResource2 = new DataTable();
            DataTable DT3 = new DataTable();
            DataColumn myDataColumn, myDataColumn2;
            DataRow row ,row2;

           // dgv_REV_Client.Rows[dgv_REV_Client.Count - 1].Frozen = true;
           
            

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Month";
            DTResource.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Amt";
            DTResource.Columns.Add(myDataColumn);

            //=========================================================

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Client";
            DTResource2.Columns.Add(myDataColumn2);


            

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Month";
            DTResource2.Columns.Add(myDataColumn2);

           
            //myDataColumn2 = new DataColumn();
            //myDataColumn2.DataType = Type.GetType("System.Double");
            //myDataColumn2.ColumnName = "Amt";
            //DTResource2.Columns.Add(myDataColumn2);

            //=========================================================

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                row = DTResource.NewRow();

                row["Month"] = listBox1.Items[i].ToString();
                FTot = "";
                try
                {
                   // String str = "select sum(TotAMT) as aMT ,upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as  Month,Session from paybill WHERE upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime)))='" + cmbYear.Text + "' AND Session='" + cmbYear.Text + "' AND Comany_id = '" + code + "'  ";

                    String str = "select CAST(sum(TotAMT+ServiceAmount+ScAmt) AS numeric(18,2)) as aMT ,upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as  Month,Session from paybill WHERE upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime)))='" + listBox1.Items[i].ToString() + "' AND Session= '" + cmbYear.Text + "' AND Comany_id = '" + code + "' GROUP BY Month, Session";

                    //String str = "SELECT SUM(GrossAmount) AS aMT,Month,Session FROM tbl_Employee_SalaryMast WHERE Month='" + listBox1.Items[i].ToString() + "' AND SESSION='" + cmbYear.Text + "' AND Company_id = '" + code + "' GROUP BY Month, Session";
                    FTot = Convert.ToString(clsDataAccess.GetresultS(str));
                }
                catch (Exception ex)
                {
                    FTot = "0.00";
                }
                if (FTot == "" || FTot == null) { FTot = "0.00"; }
                row["Amt"] = Convert.ToString(FTot);
                Famt = Famt + Convert.ToDouble(FTot);
                DTResource.Rows.Add(row);

            }

            row = DTResource.NewRow();
            row["Month"] = " ";
            DTResource.Rows.Add(row);

            row = DTResource.NewRow();
            row["Month"] = "Total : ";
            row["Amt"] = Famt.ToString("0.00");
            DTResource.Rows.Add(row);

            //=========================================================

            DataTable DT4 = new DataTable();
            for (int i = 0; i < listBox1.Items.Count; i++)      //for Month Increment
            {
                
                CTot = "";
                try
                {



                    String str = " select b.Client_id,CAST(sum(a.TotAMT+a.ServiceAmount+a.ScAmt) AS numeric(18,2))  as Amt ,b.Client_Name as Client ,a.Session,(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as Month from paybill a, tbl_Employee_CliantMaster b  where a.Cliant_ID=b.Client_id AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + listBox1.Items[i].ToString() + "') AND (a.Session ='" + cmbYear.Text + "') AND (a.Comany_id = '" + code + "') group by b.Client_Name,a.Month,a.Session,b.Client_id ";

                   // CTot = Convert.ToString(clsDataAccess.GetresultS(str));
                    DT4 = clsDataAccess.RunQDTbl(str);

                    str = " select CAST(sum(a.TotAMT+a.ServiceAmount+a.ScAmt) AS numeric(18,2))  as Amt from paybill a, tbl_Employee_CliantMaster b  where a.Cliant_ID=b.Client_id AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + listBox1.Items[i].ToString() + "') AND (a.Session ='" + cmbYear.Text + "') AND (a.Comany_id = '" + code + "') group by a.Month,a.Session ";
                    CTot = clsDataAccess.GetresultS(str);
                }
                catch (Exception ex)
                {
                    CTot = "0.00";
                }
                if (CTot == "" || CTot == null) { CTot = "0.00"; }
               
                //row2["Amt"] = Convert.ToString(CTot);
                Camt = Camt + Convert.ToDouble(CTot);
                DTResource2.Merge(DT4);
            }

            row2 = DTResource2.NewRow();
            row2["Client"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Client"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);

            FTot = "";
            dgv_REV_Mon.DataSource = DTResource;
            dgv_REV_Client.DataSource = DTResource2;
            dgv_REV_Client.AutoResizeColumns();
           // dgv_REV_Client.Columns[3].Visible = false;
            dgv_REV_Mon.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_REV_Client.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv_REV_Client.AllowUserToAddRows = false;

            dgv_REV_Client.Columns["Session"].Visible = false;
            dgv_REV_Client.Columns["Client_id"].Visible = false;
            dgv_REV_Client.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


           // dgv_REV_Client.Rows[dgv_REV_Client.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;


            
        
        
        

}


        public void Emp_Resource()
        {

            cmbCompany.Text = "";
            DataTable DTResource = new DataTable();
            
            DataColumn myDataColumn;
            DataRow row, row2;
            string clname = "", LocName = "",DesgName="",active="";
            DataTable DTEmp;
            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Name";
            DTResource.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Location";
            DTResource.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Active";
            DTResource.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Designation";
            DTResource.Columns.Add(myDataColumn);
            string sql_res;
            if (txt_Search_Resource.Text == "")
            {
                sql_res = "SELECT em.ID, em.FirstName + ' ' + em.MiddleName  + ' ' + em.LastName as EmpName, at.Location_id, em.active, at.DesgId FROM tbl_Employee_Mast em INNER JOIN tbl_Employee_Attend at ON em.ID = at.ID where at.Month =  '" + AttenDtTmPkr2.Value.ToString("M/yyyy") + "' AND at.Company_id = '" + code + "'";

            }
            else
            {
                sql_res = "SELECT em.ID, em.FirstName + ' ' + em.MiddleName  + ' ' + em.LastName as EmpName, at.LOcation_ID, em.active, at.DesgId FROM tbl_Employee_Mast em INNER JOIN tbl_Employee_Attend at ON em.ID = at.ID where (em.FirstName + ' ' + em.MiddleName  + ' ' + em.LastName) like '%" + txt_Search_Resource.Text.Trim() + "%' AND at.Month =  '" + AttenDtTmPkr2.Value.ToString("M/yyyy") + "' AND at.Company_id = '" + code + "'";
            }
            DTEmp = clsDataAccess.RunQDTbl(sql_res);
            for (int i = 0; i <= DTEmp.Rows.Count - 1; i++)
            {
                clname =  Convert.ToString(DTEmp.Rows[i]["EmpName"]);
                LocName = clsDataAccess.GetresultS("SELECT em.Location_Name FROM tbl_Emp_Location AS em INNER JOIN tbl_Employee_Attend at ON em.Location_ID = at.LOcation_ID WHERE (em.Location_id =" + DTEmp.Rows[i]["LOcation_ID"] + ") ");
                //list.Add(LocName);
                DesgName = clsDataAccess.GetresultS("SELECT DesignationName FROM tbl_Employee_DesignationMaster  AS em WHERE (SlNo =" + DTEmp.Rows[i]["DesgId"] + ")");
                if (Convert.ToInt32(DTEmp.Rows[i]["active"]) == 1) 
                { 
                    active = "Active"; 
                } 
                else 
                { 
                    active = "Inactive"; 
                }


                row = DTResource.NewRow();
                row["Name"] = clname;
                row["Location"] = LocName;
                row["Active"]=active;
                row["Designation"]=DesgName;
                DTResource.Rows.Add(row);
               

            }
            dgv_RES_Mon.DataSource = DTResource;
            dgv_RES_Mon.AutoResizeColumns();
            
            
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            //this.WindowState = FormWindowState.Normal;
            int val_width = this.Width;
            int val_height = this.Height;

            splitContainer1.SplitterDistance = (val_width / 2);
            //splitContainer1.Panel1.Width =(val_width / 2);
            //splitContainer1.Panel2.Width = (val_width / 2);


            splitContainer2.SplitterDistance = (val_height / 2);
            //splitContainer2.Panel1.Height = (val_height / 2);
            //splitContainer2.Panel2.Height = (val_height / 2);

            splitContainer3.SplitterDistance = (val_height / 2);
            //splitContainer3.Panel1.Height = (val_height / 2);
            //splitContainer3.Panel2.Height = (val_height / 2);

           

            //Thread Th1 = new Thread(new ThreadStart(Exp_view));
            //Th1.Start();

            //Thread Th2 = new Thread(new ThreadStart(Rev_view));
            //Th2.Start();

            //Thread Th3 = new Thread(new ThreadStart(Emp_Resource));
            //Th3.Start();
            //generate year in cmbYear
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //
            //set session
            if (System.DateTime.Now.Month >= 4)
            {
               // cmbYear.SelectedIndex = 0;
            //}
            //else
           // {
                //cmbYear.SelectedIndex = 1;

                 
                  cmbYear.SelectedItem = DateTime.Now.Year + "-" + DateTime.Now.AddYears(1).Year; }
                        

                    
                    else
                  {
                        cmbYear.SelectedItem = DateTime.Now.AddYears(-1).Year + "-" + DateTime.Now.Year;

                    
            }
            //
           // radioButton1.Checked = true;

            
           // SESS =Convert.ToString( cmbYear.SelectedItem);
          //  Comp = clsDataAccess.GetresultS("select CO_NAME from Company where CO_CODE = '" + code + "'");
           // cmbCompany.Text = Comp;
            ////Thread Th = new Thread(new ThreadStart(CLoc_view));
            ////Th.Start();
            //CLoc_view();
            //Exp_view();
            //Rev_view();
            //Emp_Resource();
            cmbCompany.Enabled = false;
           
            radioButton1.Checked = true;
            button1_Click(sender,e);
            
           
        }
        public void load_Data()
        {
           // radioButton1.Checked = true;
            CLoc_view();
            Exp_view();
            Rev_view();
            Emp_Resource();
            this.Refresh();
        }

      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Search_Resource_Click(object sender, EventArgs e)
        {
            Emp_Resource();
        }

        private void txt_Search_Resource_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Emp_Resource();
            }
        }

        //RITESH
        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
                //dt = clsDataAccess.RunQDTbl("select CO_NAME,CO_CODE from Company");

              
                if (edpcom.CurrentLocation.Trim() != "")
                {

                    dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
                }
                else
                {
                    dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
                }
                if (dt.Rows.Count > 0)
                {
                    cmbCompany.LookUpTable = dt;
                    cmbCompany.ReturnIndex = 1;
                }
        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbCompany.ReturnValue.Trim()))
            code = Convert.ToInt32(cmbCompany.ReturnValue);
          //  open();
           // button1_Click(sender, e);

           
        }
       

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            CLoc_view();
        }

        private void AttenDtTmPkr_ValueChanged1_ValueChanged(object sender, EventArgs e)
        {
            Emp_Resource();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] StrLine = this.cmbYear.Text.Trim().Split('-');
            AttenDtTmPkr2.MinDate = DateTimePicker.MinimumDateTime;
            AttenDtTmPkr2.MaxDate = DateTimePicker.MaximumDateTime;

            AttenDtTmPkr.MinDate = DateTimePicker.MinimumDateTime;
            AttenDtTmPkr.MaxDate = DateTimePicker.MaximumDateTime;

            AttenDtTmPkr2.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            AttenDtTmPkr2.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            AttenDtTmPkr.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            AttenDtTmPkr.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            AttenDtTmPkr2.Value = Convert.ToDateTime("01/April/" + StrLine[0]);



            AttenDtTmPkr.Value = Convert.ToDateTime("31/March/" + StrLine[1]);

            ////////


            dateTimePicker1.MinDate = DateTimePicker.MinimumDateTime;
            dateTimePicker1.MaxDate = DateTimePicker.MaximumDateTime;

            dateTimePicker2.MinDate = DateTimePicker.MinimumDateTime;
            dateTimePicker2.MaxDate = DateTimePicker.MaximumDateTime;

            dateTimePicker1.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dateTimePicker1.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            dateTimePicker2.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dateTimePicker2.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);

            dateTimePicker1.Value = Convert.ToDateTime("01/April/" + StrLine[0]);



            dateTimePicker2.Value = Convert.ToDateTime("31/March/" + StrLine[1]);

            ///////

            dateTimePicker3.MinDate = DateTimePicker.MinimumDateTime;
            dateTimePicker3.MaxDate = DateTimePicker.MaximumDateTime;

            dateTimePicker3.MaxDate = Convert.ToDateTime("31/March/" + StrLine[1]);
            dateTimePicker3.MinDate = Convert.ToDateTime("01/April/" + StrLine[0]);
            dateTimePicker3.Value = Convert.ToDateTime("01/April/" + StrLine[0]);
            button1_Click(sender, e);





        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cmbCompany.Enabled = false;
            }
            else
                cmbCompany.Enabled = true;
        }

        

        
        ///////////////////////////////////////////////////////////////



        //Ritesh


        public void Rev_view2()
        {

            cmbCompany.Text = "";
            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0;
            dgv_REV_Mon.ReadOnly = true;
            dgv_REV_Client.ReadOnly = true;

            

            DataTable DTResource = new DataTable();
            DataTable DTResource2 = new DataTable();
            DataTable DT3 = new DataTable();
            DataColumn myDataColumn, myDataColumn2;
            DataRow row, row2;
           // dgv_REV_Client.Rows[dgv_REV_Client.Rows.Count - 1].Frozen = true;


            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Month";
            DTResource.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Amt";
            DTResource.Columns.Add(myDataColumn);

            //=========================================================

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Client";
            DTResource2.Columns.Add(myDataColumn2);


            

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Month";
            DTResource2.Columns.Add(myDataColumn2);

            //myDataColumn2 = new DataColumn();
            //myDataColumn2.DataType = Type.GetType("System.Double");
            ////myDataColumn2.ColumnName = "Amt";
            //DTResource2.Columns.Add(myDataColumn2);

            //=========================================================

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                row = DTResource.NewRow();

                row["Month"] = listBox1.Items[i].ToString();
                FTot = "";
                // string fm = MMMM;
                try
                {
                    // String str = "SELECT SUM(GrossAmount) AS aMT,Month,Session FROM tbl_Employee_SalaryMast WHERE Month='" + listBox1.Items[i].ToString() + "' AND SESSION='" + cmbYear.Text + "' GROUP BY Month, Session";
                    //String str = "select TotAMT as aMT ,upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as   Month,Session from paybill WHERE upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime)))='" + listBox1.Items[i].ToString() + "' AND Session='" + cmbYear.Text + "' GROUP BY Month, Session ";

                    //String str = "select sum(TotAMT+ServiceAmount) as aMT ,upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as  Month,Session from paybill WHERE upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime)))='" + listBox1.Items[i].ToString() + "' AND Session='" + cmbYear.Text + "'  ";
                    String str = "select CAST(sum(TotAMT+ServiceAmount+ScAmt) AS numeric(18,2)) as aMT ,upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as  Month,Session from paybill WHERE upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime)))='" + listBox1.Items[i].ToString() + "' AND Session= '" + cmbYear.Text + "'  GROUP BY Month, Session";

                    FTot = Convert.ToString(clsDataAccess.GetresultS(str));
                }
                catch (Exception ex)
                {
                    FTot = "0.00";
                }
                if (FTot == "" || FTot == null) { FTot = "0.00"; }
                row["Amt"] = Convert.ToString(FTot);
                Famt = Famt + Convert.ToDouble(FTot);
                DTResource.Rows.Add(row);

            }

            row = DTResource.NewRow();
            row["Month"] = " ";
            DTResource.Rows.Add(row);

            row = DTResource.NewRow();
            row["Month"] = "Total : ";
            row["Amt"] = Famt.ToString("0.00");
            DTResource.Rows.Add(row);

            //=========================================================

            DataTable DT4 = new DataTable();
            for (int i = 0; i < listBox1.Items.Count; i++)      //for Month Increment
            {
                row2 = DTResource.NewRow();

                row2["Month"] = listBox1.Items[i].ToString();
                CTot = "";
                try
                {
                    
                    
                    //str = str + " WHERE (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + listBox1.Items[i].ToString() + "') AND (sm.Session = '" + cmbYear.Text + "') ) as tbl group by Month,Session,Client";
                    String str = " select b.Client_id, CAST(sum(a.TotAMT+a.ServiceAmount+a.ScAmt) AS numeric(18,2))  as Amt ,a.Session,b.Client_Name as Client ,(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as Month from paybill a, tbl_Employee_CliantMaster b  where a.Cliant_ID=b.Client_id   AND (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + listBox1.Items[i].ToString() + "') AND (a.Session ='" + cmbYear.Text + "')  group by b.Client_Name,a.Month,a.Session,b.Client_id ";

                    
                    DT4 = clsDataAccess.RunQDTbl(str);

                    str = " select  CAST(sum(a.TotAMT+a.ServiceAmount+a.ScAmt) AS numeric(18,2))  as Amt from paybill a, tbl_Employee_CliantMaster b  where a.Cliant_ID=b.Client_id AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + listBox1.Items[i].ToString() + "') AND (a.Session ='" + cmbYear.Text + "') group by a.Month,a.Session ";
                    CTot = Convert.ToString(clsDataAccess.GetresultS(str));
                }

                catch (Exception ex)
                {
                    CTot = "0.00";
                }
                if (CTot == "" || CTot == null) { CTot = "0.00"; }
                row2["Amt"] = Convert.ToString(CTot);
                Camt = Camt + Convert.ToDouble(CTot);
                DTResource2.Merge(DT4);
                //DTResource.Rows.Add(row2);
            }
           // int sum = Convert.ToInt32(DT4.Compute("SUM(Amt)", string.Empty));


            row2 = DTResource2.NewRow();
            row2["Client"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Client"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);

            FTot = "";
            dgv_REV_Mon.DataSource = DTResource;
            dgv_REV_Client.DataSource = DTResource2;
            dgv_REV_Client.AutoResizeColumns();
            //dgv_REV_Client.Columns[3].Visible = false;
            dgv_REV_Mon.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_REV_Client.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgv_REV_Client.AllowUserToAddRows = false;

            dgv_REV_Client.Columns["Session"].Visible = false;
            dgv_REV_Client.Columns["Client_id"].Visible = false;
            dgv_REV_Client.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            //dgv_REV_Client.Rows[dgv_REV_Client.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;






        }
        ///////////////////////////
        ///////////////////////////




        //Ritesh
        public void Exp_view2()
        {
            cmbCompany.Text = "";
            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0;
            dgv_EXP_Mon.ReadOnly = true;
            dgv_EXP_Client.ReadOnly = true;

            

            DataTable DTResource = new DataTable();
            DataTable DTResource2 = new DataTable();
            DataTable DT3 = new DataTable();
            DataColumn myDataColumn, myDataColumn2;
            DataRow row, row2;
            

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Month";
            DTResource.Columns.Add(myDataColumn);

            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "Amt";
            DTResource.Columns.Add(myDataColumn);

            //=========================================================

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Client";
            DTResource2.Columns.Add(myDataColumn2);

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Month";
            DTResource2.Columns.Add(myDataColumn2);

            //myDataColumn2 = new DataColumn();
            //myDataColumn2.DataType = Type.GetType("System.Double");
            ////myDataColumn2.ColumnName = "Amt";
            //DTResource2.Columns.Add(myDataColumn2);

            //=========================================================

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                row = DTResource.NewRow();

                row["Month"] = listBox1.Items[i].ToString();
                FTot = "";
                try
                {

                    string str = "SELECT CAST(SUM(GrossAmount) AS numeric(18,2)) AS aMT,Month,Session FROM tbl_Employee_SalaryMast   WHERE  (Month='" + listBox1.Items[i].ToString() + "') AND (SESSION='" + cmbYear.Text + "') GROUP BY Month, Session";
                   // String str = "SELECT SUM(a.GrossAmount) AS aMT,a.Month,a.Session FROM tbl_Employee_SalaryMast a,tbl_employers_contribution b  WHERE b.emp_id=a.Emp_Id and  a.Month='" + listBox1.Items[i].ToString() + "' AND   a.SESSION='" + cmbYear.Text + "'  GROUP BY a.Month, a.Session";
                   // String str = "SELECT SUM(GrossAmount) AS aMT,Month,Session FROM tbl_Employee_SalaryMast WHERE Month='" + listBox1.Items[i].ToString() + "' AND   SESSION='" + cmbYear.Text + "'  GROUP BY Month, Session";
                    FTot = Convert.ToString(clsDataAccess.GetresultS(str));
                }
                catch (Exception ex)
                {
                    FTot = "0.00";
                }
                if (FTot == "" || FTot == null) { FTot = "0.00"; }
                row["Amt"] = Convert.ToString(FTot);
                Famt = Famt + Convert.ToDouble(FTot);
                DTResource.Rows.Add(row);

            }

            row = DTResource.NewRow();
            row["Month"] = " ";
            DTResource.Rows.Add(row);

            row = DTResource.NewRow();
            row["Month"] = "Total : ";
            row["Amt"] = Famt.ToString("0.00");
            DTResource.Rows.Add(row);

            //=========================================================

            DataTable DT4 = new DataTable();
            for (int i = 0; i < listBox1.Items.Count; i++)      //for Month Increment
            {
                row2 = DTResource.NewRow();

                row2["Month"] = listBox1.Items[i].ToString();
                CTot = "";
                try
                {
                   // String str = "Select SUM(aMT) as Amt,Month,Session,Client from (SELECT distinct(select SUM(GrossAmount) from tbl_Employee_SalaryMast where Location_id =l.Location_ID group by Location_ID) AS aMT, sm.Month, sm.Session,";


                    String str = "select CAST(SUM(a.GrossAmount) AS numeric(18,2)) as Amt,a.Month,b.Client_Name as Client,b.Client_id,a.Session from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c   where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID  and (a.Month = '" + listBox1.Items[i].ToString() + "') AND (a.Session = '" + cmbYear.Text + "') GROUP BY a.Month, a.Session ,b.Client_Name,b.Client_id ";





                   // String str = "select a.GrossAmount as Amt,a.Month,a.Session,b.Client_Name as Client from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID  and (a.Month = '" + listBox1.Items[i].ToString() + "') AND (a.Session = '" + cmbYear.Text + "')  ";
                    
                    
                    DT4 = clsDataAccess.RunQDTbl(str);

                    String str2 = "select CAST(SUM(a.GrossAmount) AS numeric(18,2)) as Amt from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID and (a.Month = '" + listBox1.Items[i].ToString() + "') AND (a.Session = '" + cmbYear.Text + "') GROUP BY a.Month, a.Session ";
                    CTot = Convert.ToString(clsDataAccess.GetresultS(str2));
                }
                catch (Exception ex)
                {
                    CTot = "0.00";
                }
                if (CTot == "" || CTot == null) { CTot = "0.00"; }
                row2["Amt"] = Convert.ToString(CTot);
                Camt = Camt + Convert.ToDouble(CTot);
                DTResource2.Merge(DT4);
            }

            row2 = DTResource2.NewRow();
            row2["Client"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Client"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);

            FTot = "";
            dgv_EXP_Mon.DataSource = DTResource;
            dgv_EXP_Client.DataSource = DTResource2;
            dgv_EXP_Client.AutoResizeColumns();
           // dgv_EXP_Client.Columns[3].Visible = false;
            dgv_EXP_Mon.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_EXP_Client.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dgv_EXP_Client.AllowUserToAddRows = false;
           // dgv_EXP_Client.Rows[dgv_EXP_Client.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;
           // dgv_EXP_Client.Rows[dgv_EXP_Client.RowCount - 1].Frozen = true;
            dgv_EXP_Client.Columns["Session"].Visible = false;
            dgv_EXP_Client.Columns["Client_id"].Visible = false;
            dgv_EXP_Client.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                CLoc_view();
                Exp_view2();
                Rev_view2();
                Emp_Resource();
                this.Refresh();


            }
            else
            {
                CLoc_view();
                Exp_view();
                Rev_view();
                Emp_Resource();
                this.Refresh();
            }
        }

        private void dgv_REV_Mon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgView_cl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_REV_Client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int RW = 0, COL = 0;

            RW = dgv_REV_Client.CurrentCell.RowIndex;
            COL = dgv_REV_Client.CurrentCell.ColumnIndex;

            string CLNAME = dgv_REV_Client.Rows[RW].Cells["Client_id"].Value.ToString();
            string month = dgv_REV_Client.Rows[RW].Cells["Month"].Value.ToString();
            string session = dgv_REV_Client.Rows[RW].Cells["Session"].Value.ToString();

            PopUpDashBoard pd = new PopUpDashBoard();
            pd.popdas(CLNAME,month,session);
            pd.ShowDialog();
        }

        private void dgv_EXP_Client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rw = 0, cl = 0;
            rw = dgv_EXP_Client.CurrentCell.RowIndex;
            cl = dgv_EXP_Client.CurrentCell.ColumnIndex;
            string clname = dgv_EXP_Client.Rows[rw].Cells["Client_id"].Value.ToString();
            string month = dgv_EXP_Client.Rows[rw].Cells["Month"].Value.ToString();
            string sess = dgv_EXP_Client.Rows[rw].Cells["Session"].Value.ToString();

             PopUpExp pp = new PopUpExp();
            pp.popdas2(clname,month,sess);
            pp.ShowDialog();

        }

        private void dgv_CLoc_Loc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rw = 0, cl = 0;
            rw = dgv_CLoc_Loc.CurrentCell.RowIndex;
            cl = dgv_CLoc_Loc.CurrentCell.ColumnIndex;
           //string loc= dgv_EXP_Client.Rows[rw].Cells["LocationName"].Value.ToString();
           //PopUpExp lp = new PopUpExp();
           //lp.emp(loc);
           //lp.ShowDialog();




        }

       

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                locmonth();
            }
            else
            {
                locmonth2();
            }
        }

        public void locmonth()
        {
            string month = "";
            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0;
            DataTable DTResource2 = new DataTable();



           
            DataColumn  myDataColumn2;
            DataRow  row2;
            // dgv_REV_Client.Rows[dgv_REV_Client.Rows.Count - 1].Frozen = true;


          
            

            //=========================================================

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Client";
            DTResource2.Columns.Add(myDataColumn2);




            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Month";
            DTResource2.Columns.Add(myDataColumn2);
            
            month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            row2 = DTResource.NewRow();

            String str;
            DataTable DT = new DataTable();
            str = "select b.Client_id,CAST(sum(a.TotAMT+a.ServiceAmount+a.ScAmt) AS numeric(18,2))  as Amt ,a.Session,b.Client_Name as Client ,(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as Month from paybill a, tbl_Employee_CliantMaster b  where a.Cliant_ID=b.Client_id   AND (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + month + "') AND (a.Session ='" + cmbYear.Text + "')  group by b.Client_Name,a.Month,a.Session,b.Client_id";
            DT = clsDataAccess.RunQDTbl(str);

            str = " select sum(a.TotAMT+a.ServiceAmount+a.ScAmt)  as Amt from paybill a, tbl_Employee_CliantMaster b  where a.Cliant_ID=b.Client_id AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + month + "') AND (a.Session ='" + cmbYear.Text + "') group by a.Month,a.Session ";
            CTot = Convert.ToString(clsDataAccess.GetresultS(str));


            if (CTot == "" || CTot == null) { CTot = "0.00"; }
            
          //  row2["Amt"] = Convert.ToString(CTot);
            Camt = Camt + Convert.ToDouble(CTot);
            DTResource2.Merge(DT);


            row2 = DTResource2.NewRow();
            row2["Client"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Client"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);



            dgv_REV_Client.DataSource = DTResource2;



          






        }
        public void clmonexp()
        {
            string month = "",str;
            DataTable DT = new DataTable();

            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0;

            

           // DataTable DTResource = new DataTable();
            DataTable DTResource2 = new DataTable();
          //  DataTable DT3 = new DataTable();
            DataColumn myDataColumn2;
            DataRow row2;
            

            
            //=========================================================

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Client";
            DTResource2.Columns.Add(myDataColumn2);

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Month";
            DTResource2.Columns.Add(myDataColumn2);

            month = clsEmployee.GetMonthName(dateTimePicker2.Value.Month);
            str = "select sum(a.GrossAmount) as Amt,a.Month,b.Client_Name as Client,b.Client_id,a.Session from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c   where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID  and (a.Month = '" + month + "') AND (a.Session = '" + cmbYear.Text + "') GROUP BY a.Month, a.Session ,b.Client_Name,b.Client_id ";
            DT = clsDataAccess.RunQDTbl(str);

            
                    String str2 = "select sum(a.GrossAmount) as Amt from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID and (a.Month = '" + month + "') AND (a.Session = '" + cmbYear.Text + "') GROUP BY a.Month, a.Session ";
                    CTot = Convert.ToString(clsDataAccess.GetresultS(str2));
                
                if (CTot == "" || CTot == null) { CTot = "0.00"; }
               // row2["Amt"] = Convert.ToString(CTot);
                Camt = Camt + Convert.ToDouble(CTot);
                DTResource2.Merge(DT);
            

            row2 = DTResource2.NewRow();
            row2["Client"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Client"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);




            dgv_EXP_Client.DataSource = DTResource2;

        }
        private void dgv_REV_Client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                clmonexp();
            }
            else
            {
                clmonexp2();
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker3.Value;
            dateTimePicker2.Value = dateTimePicker3.Value;
            AttenDtTmPkr.Value = dateTimePicker3.Value;
            AttenDtTmPkr2.Value = dateTimePicker3.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CLoc_Client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void locmonth2()
        {
            string month = "";
            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0;
            DataTable DTResource2 = new DataTable();




            DataColumn myDataColumn2;
            DataRow row2;
            // dgv_REV_Client.Rows[dgv_REV_Client.Rows.Count - 1].Frozen = true;





            //=========================================================

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Client";
            DTResource2.Columns.Add(myDataColumn2);




            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Month";
            DTResource2.Columns.Add(myDataColumn2);

            month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
            row2 = DTResource.NewRow();

            String str;
            DataTable DT = new DataTable();
            str = "select b.Client_id,CAST(sum(a.TotAMT+a.ServiceAmount+a.ScAmt) AS numeric(18,2))  as Amt ,a.Session,b.Client_Name as Client ,(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) as Month from paybill a, tbl_Employee_CliantMaster b  where a.Cliant_ID=b.Client_id   AND (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + month + "') AND (a.Session ='" + cmbYear.Text + "') AND (Comany_id = '" + code + "') group by b.Client_Name,a.Month,a.Session,b.Client_id";
            DT = clsDataAccess.RunQDTbl(str);

            str = " select sum(a.TotAMT+a.ServiceAmount+a.ScAmt)  as Amt from paybill a, tbl_Employee_CliantMaster b  where a.Cliant_ID=b.Client_id AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + month + "') AND (a.Session ='" + cmbYear.Text + "') AND (Comany_id = '" + code + "') group by a.Month,a.Session ";
            CTot = Convert.ToString(clsDataAccess.GetresultS(str));


            if (CTot == "" || CTot == null) { CTot = "0.00"; }

            //  row2["Amt"] = Convert.ToString(CTot);
            Camt = Camt + Convert.ToDouble(CTot);
            DTResource2.Merge(DT);


            row2 = DTResource2.NewRow();
            row2["Client"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Client"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);



            dgv_REV_Client.DataSource = DTResource2;










        }



        public void clmonexp2()
        {
            string month = "", str;
            DataTable DT = new DataTable();

            string FTot = "", CTot = "";
            double Famt = 0, Camt = 0;



            // DataTable DTResource = new DataTable();
            DataTable DTResource2 = new DataTable();
            //  DataTable DT3 = new DataTable();
            DataColumn myDataColumn2;
            DataRow row2;



            //=========================================================

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Client";
            DTResource2.Columns.Add(myDataColumn2);

            myDataColumn2 = new DataColumn();
            myDataColumn2.DataType = Type.GetType("System.String");
            myDataColumn2.ColumnName = "Month";
            DTResource2.Columns.Add(myDataColumn2);

            month = clsEmployee.GetMonthName(dateTimePicker2.Value.Month);
            str = "select sum(a.GrossAmount) as Amt,a.Month,b.Client_Name as Client,b.Client_id,a.Session from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c   where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID  and (a.Month = '" + month + "') AND (a.Session = '" + cmbYear.Text + "')  AND (Company_id = '" + code + "') GROUP BY a.Month, a.Session ,b.Client_Name,b.Client_id ";
            DT = clsDataAccess.RunQDTbl(str);


            String str2 = "select sum(a.GrossAmount) as Amt from tbl_Employee_SalaryMast a,tbl_Employee_CliantMaster b,tbl_Emp_Location c where c.Location_ID=a.Location_id and b.Client_id=c.Cliant_ID and (a.Month = '" + month + "') AND (a.Session = '" + cmbYear.Text + "') AND (Company_id = '" + code + "')  GROUP BY a.Month, a.Session ";
            CTot = Convert.ToString(clsDataAccess.GetresultS(str2));

            if (CTot == "" || CTot == null) { CTot = "0.00"; }
            // row2["Amt"] = Convert.ToString(CTot);
            Camt = Camt + Convert.ToDouble(CTot);
            DTResource2.Merge(DT);


            row2 = DTResource2.NewRow();
            row2["Client"] = " ";
            DTResource2.Rows.Add(row2);

            row2 = DTResource2.NewRow();
            row2["Client"] = "Total : ";
            row2["Amt"] = Camt.ToString("0.00");
            DTResource2.Rows.Add(row2);




            dgv_EXP_Client.DataSource = DTResource2;

        }
      

        

       

       

    }
}
