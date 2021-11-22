using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;


namespace PayRollManagementSystem
{

    public partial class REPORTOFPF : Form
    {
        

        public REPORTOFPF()
        {
            InitializeComponent();
        }
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon con = new Edpcom.EDPCommon();
        int Location_id = 0, Company_id=0;
        //SqlConnection con = new SqlConnection("Data Source=DUTTA\\SQLEXPRESS;Initial Catalog=EDP_Payroll;Integrated Security=True;User Instance=False");
        
        
        private void REPORTOFPF_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbSession, 2015, System.DateTime.Now.Year, 1);
            if (System.DateTime.Now.Month >= 4)
            {
                cmbSession.SelectedIndex = 0;
            }
            else
            {
                cmbSession.SelectedIndex = 1;
            }
            cmbLID.Items.Clear();
            //cmbLoc.Items.Clear();
            cmbCID.Items.Clear();
            //cmbCompany.Items.Clear();
            cmbMonth.Items.Clear();
            //cmbSession.Items.Clear();
            string[] mon = new string[12];
            mon[0] = "January";
            mon[1] = "February";
            mon[2] = "march";
            mon[3] = "April";
            mon[4] = "May";
            mon[5] = "june";
            mon[6] = "july";
            mon[7] = "august";
            mon[8] = "september";
            mon[9] = "october";
            mon[10] = "November";
            mon[11] = "December";
            for (int i = 0; i < 12; i++)
            {
                cmbMonth.Items.Add(mon[i]);
            }
            edpcon.Open();
            
            DataTable dtloc  = clsDataAccess.RunQDTbl("select * from tbl_emp_Location");
            //SqlDataReader dr = CMD.ExecuteReader();
            if(dtloc.Rows.Count>0)
            {
                for (int i = 0; i < dtloc.Rows.Count; i++)
                {
                    //cmbLoc.Items.Add(dtloc.Rows[i]["location_name"].ToString());
                    cmbLID.Items.Add(dtloc.Rows[i]["Location_id"].ToString());
                }
            }
            // con.Close();
           
            DataTable dtcomp= clsDataAccess.RunQDTbl("select * from company");
        //    SqlDataReader dr1 = cmd1.ExecuteReader();
            if(dtcomp.Rows.Count>0)
            {
                for(int i=0;i<dtcomp.Rows.Count;i++)
                {
                //cmbCompany.Items.Add(dtcomp.Rows[i]["Co_Name"].ToString());
                cmbCID.Items.Add(dtcomp.Rows[i]["CO_CODE"].ToString());
                }
            }
            //dr1.Close();
            edpcon.Close();
            /* SqlCommand cmd2 = new SqlCommand("select * from Tbl_employee_salarydet", con);
             SqlDataReader dr2 = cmd2.ExecuteReader();
             while (dr2.Read())*/
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            EMPDT rd = new EMPDT();
            rd.SetDataSource(a(cmbSession.Text, cmbMonth.Text, this.cmbLID.Text, this.cmbCID.Text));
            

            PayRollManagementSystem.empr cd = new PayRollManagementSystem.empr();

            rd.SetParameterValue("month", cmbMonth.Text + " - " + YEAR() );
            rd.SetParameterValue("session", cmbSession.Text);
            rd.SetParameterValue("company", CmbCompany.Text);
            rd.SetParameterValue("LOCATION", CmbLocation.Text);
            rd.SetParameterValue("CO-ADD", ADDRESS(CmbCompany.Text));
            cd.crystalReportViewer1.ReportSource = rd;

            edpcon.Close();

            cd.ShowDialog();           

            
        }
        public DataTable a(string session, string month, string cmbLID, string cmbCID)
        {
            //int i;
            edpcon.Open();
           /* SqlCommand cmd1 = new SqlCommand("select  tbl_employee_salarydet.amount from tbl_employee_salarydet,tbl_employee_assign_salstructure,tbl_employee_mast where tbl_employee_assign_salstructure.pf_per=1 and tbl_employee_assign_salstructure.sal_head=tbl_employee_salarydet.salid and tbl_employee_salarydet.empid=tbl_employee_mast.id and tbl_employee_salarydet.tablename='tbl_employee_deductionsalayhead'", con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            //ArrayList ar = new ArrayList();
            String ar = "";
            for (i = 0; i<dt1.Rows.Count; i++)
            {
              //  ar.Add(dt1.Rows[i]["amount"].ToString());
                if (ar=="")
                {
                ar= dt1.Rows[i]["amount"].ToString() ; 
                }
                else{
                    ar = ar + "," + dt1.Rows[i]["amount"].ToString();
                }
            }
            cmd1.Cancel();*/
            //string a = "select tbl_employee_mast.code,tbl_employee_mast.id,tbl_employee_mast.Firstname,tbl_employee_mast.lastname,tbl_employee_mast.dateofjoining,tbl_employee_designationmaster.designationname,tbl_employee_mast.pf,tbl_employee_salaryDet.amount from tbl_employee_assign_salstructure,tbl_employee_mast,tbl_employee_designationmaster,tbl_emp_location,tbl_employee_salarydet,Company where tbl_employee_salarydet.amount in (select tbl_employee_salarydet.amount from tbl_employee_salarydet,tbl_employee_assign_salstructure,tbl_employee_mast where tbl_employee_assign_salstructure.pf_per=1 and tbl_employee_assign_salstructure.sal_head=tbl_employee_salarydet.salid and tbl_employee_salarydet.empid=tbl_employee_mast.id and tbl_employee_salarydet.tablename='tbl_employee_deductionsalayhead') and tbl_employee_salarydet.Session='" + session + "'and tbl_employee_salarydet.month='" + month + "'and tbl_emp_location.location_name='" + location + "' and company.Co_name='" + company + "'and  tbl_employee_salarydet.salid=tbl_employee_assign_salstructure.sal_head " + " and tbl_employee_salarydet.empid=tbl_employee_mast.id" + "and tbl_employee_salarydet.location_id=tbl_employee_mast.location_id";
            string a = "SELECT     e.ID, e.FirstName + ' ' + e.LastName AS 'FirstName', e.DateOfJoining, e.PF, e.Location_id, e.Company_id, s.Amount, s.Month, s.Session, (SELECT     DesignationName FROM          tbl_Employee_DesignationMaster AS m  WHERE      (SlNo = e.DesgId)) AS DesignationName, (SELECT     Location_Name FROM          tbl_Emp_Location WHERE      (Location_ID = " + cmbLID + ")) AS Location_Name FROM         tbl_Employee_Mast AS e INNER JOIN tbl_Employee_SalaryDet AS s  ON e.ID = s.EmpId WHERE (e.Location_id = " + cmbLID + ") AND (e.Company_id = " + cmbCID + ") AND (s.Month = '" + month + "') AND (s.Session = '" + session + "') AND (s.TableName = 'tbl_Employee_DeductionSalayHead') AND (s.SalId = (SELECT     SAL_HEAD FROM          tbl_Employee_Assign_SalStructure AS ss WHERE  (Location_id = " + cmbLID + ") AND (PF_PER = 1)))";
            DataTable dt = clsDataAccess.RunQDTbl(a);
            //SqlCommand cmd1=new SqlCommand("select tbl_employee_salarydet.amount from tbl_employee_salarydet,tbl_employee_assign_salstructure where tbl_employee_assign_salstructure.pf_per=1 and tbl_employee_assign_salstructure.salhead=tbl_employee_salarydet.salid and tbl_employee_salarydet.emp_id=tbl_employee.mast.id and tbl_employee_salarydet.tablename=tbl_employee_salarydet.tbl_employee_deductionsalaryhead",con); 
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            // SqlDataReader dr = cmd1.ExecuteReader();
            // ArrayList ar = new ArrayList();
            //DataTable dt = new DataTable();
           // da.Fill(dt);
            edpcon.Close();
            return dt;
            




        }

        //private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
        //}

        //private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //         cmbLID.SelectedIndex=cmbLoc.SelectedIndex;
        //    }
        //    catch { }
        //}

        private void EmpListEsi_Click(object sender, EventArgs e)
        {
            Employeelist_Esi rd1 = new Employeelist_Esi();
           // rd.setda(retrieve(cmbSession.Text, cmbMonth.Text, this.cmbLID.Text, this.cmbCID.Text));

            rd1.SetDataSource(retrieve(cmbSession.Text, cmbMonth.Text, this.cmbLID.Text, this.cmbCID.Text));
            PayRollManagementSystem.EMPLOYEE_ESI cd = new PayRollManagementSystem.EMPLOYEE_ESI();
            rd1.SetParameterValue("COMPANY", CmbCompany.Text);
            rd1.SetParameterValue("MONTH", cmbMonth.Text +" - " + YEAR());
            rd1.SetParameterValue("SESSION", cmbSession.Text);
            rd1.SetParameterValue("LOCATION", CmbLocation.Text);
            rd1.SetParameterValue("CO_ADD", ADDRESS(CmbCompany.Text));

            //rd1.SetParameterValue("year", "");
            cd.crystalReportViewer1.ReportSource = rd1;

            edpcon.Close();

            cd.ShowDialog();           
        }

        public DataTable retrieve(string session, string month, string cmbLID, string cmbCID)
        {
            //int i;
            edpcon.Open();
            /* SqlCommand cmd1 = new SqlCommand("select  tbl_employee_salarydet.amount from tbl_employee_salarydet,tbl_employee_assign_salstructure,tbl_employee_mast where tbl_employee_assign_salstructure.pf_per=1 and tbl_employee_assign_salstructure.sal_head=tbl_employee_salarydet.salid and tbl_employee_salarydet.empid=tbl_employee_mast.id and tbl_employee_salarydet.tablename='tbl_employee_deductionsalayhead'", con);
             SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
             DataTable dt1 = new DataTable();
             da1.Fill(dt1);
             //ArrayList ar = new ArrayList();
             String ar = "";
             for (i = 0; i<dt1.Rows.Count; i++)
             {
               //  ar.Add(dt1.Rows[i]["amount"].ToString());
                 if (ar=="")
                 {
                 ar= dt1.Rows[i]["amount"].ToString() ; 
                 }
                 else{
                     ar = ar + "," + dt1.Rows[i]["amount"].ToString();
                 }
             }
             cmd1.Cancel();*/
            //employee listing with esi
            //string a = "select tbl_employee_mast.code,tbl_employee_mast.id,tbl_employee_mast.Firstname,tbl_employee_mast.lastname,tbl_employee_mast.dateofjoining,tbl_employee_designationmaster.designationname,tbl_employee_mast.pf,tbl_employee_salaryDet.amount from tbl_employee_assign_salstructure,tbl_employee_mast,tbl_employee_designationmaster,tbl_emp_location,tbl_employee_salarydet,Company where tbl_employee_salarydet.amount in (select tbl_employee_salarydet.amount from tbl_employee_salarydet,tbl_employee_assign_salstructure,tbl_employee_mast where tbl_employee_assign_salstructure.pf_per=1 and tbl_employee_assign_salstructure.sal_head=tbl_employee_salarydet.salid and tbl_employee_salarydet.empid=tbl_employee_mast.id and tbl_employee_salarydet.tablename='tbl_employee_deductionsalayhead') and tbl_employee_salarydet.Session='" + session + "'and tbl_employee_salarydet.month='" + month + "'and tbl_emp_location.location_name='" + location + "' and company.Co_name='" + company + "'and  tbl_employee_salarydet.salid=tbl_employee_assign_salstructure.sal_head " + " and tbl_employee_salarydet.empid=tbl_employee_mast.id" + "and tbl_employee_salarydet.location_id=tbl_employee_mast.location_id";
            string sql_query = "SELECT     e.ID, e.FirstName + ' ' + e.LastName AS 'FirstName', e.DateOfJoining, e.ESIno, e.Location_id, e.Company_id, s.Amount, s.Month, s.Session, (SELECT     DesignationName FROM          tbl_Employee_DesignationMaster AS m  WHERE      (SlNo = e.DesgId)) AS DesignationName, (SELECT     Location_Name FROM          tbl_Emp_Location WHERE      (Location_ID = " + cmbLID + ")) AS Location_Name FROM         tbl_Employee_Mast AS e INNER JOIN tbl_Employee_SalaryDet AS s  ON e.ID = s.EmpId WHERE (e.Location_id = " + cmbLID + ") AND (e.Company_id = " + cmbCID + ") AND (s.Month = '" + month + "') AND (s.Session = '" + session + "') AND (s.TableName = 'tbl_Employee_DeductionSalayHead') AND (s.SalId = (SELECT     SAL_HEAD FROM          tbl_Employee_Assign_SalStructure AS ss WHERE  (Location_id = " + cmbLID + ") AND (PF_PER = 1)))";  //SqlCommand cmd = new SqlCommand(sql_query, con);
            //SqlCommand cmd1=new SqlCommand("select tbl_employee_salarydet.amount from tbl_employee_salarydet,tbl_employee_assign_salstructure where tbl_employee_assign_salstructure.esi_per=1 and tbl_employee_assign_salstructure.salhead=tbl_employee_salarydet.salid and tbl_employee_salarydet.emp_id=tbl_employee.mast.id and tbl_employee_salarydet.tablename=tbl_employee_salarydet.tbl_employee_deductionsalaryhead",con); 
           // SqlDataAdapter da = new SqlDataAdapter(cmd);
            // SqlDataReader dr = cmd1.ExecuteReader();
            // ArrayList ar = new ArrayList();
            DataTable dtesi = clsDataAccess.RunQDTbl(sql_query);
            //da.Fill(dt);
            edpcon.Close();
            return dtesi;





        }
        public int YEAR()
        {
           
            string session=cmbSession.Text;
            int a= int.Parse(session.Substring(0,4));
            if (cmbMonth.Text == "january" || cmbMonth.Text == "february" || cmbMonth.Text == "march") 
            {
              a=a+1;
            }
            else
            {
                a = int.Parse(session.Substring(0, 4));
            }
            return a;
        }
        public string ADDRESS(string COMPANY)
        {
            edpcon.Close();
            edpcon.Open();
            DataTable dtcompadd =clsDataAccess.RunQDTbl ("SELECT CO_ADD FROM COMPANY WHERE CO_NAME='" + COMPANY + "'");
           // SqlDataAdapter DA = new SqlDataAdapter(CMD);
            //DataTable DT = new DataTable();
            //DA.Fill(DT);
            int I;
            //int COUNT=DT.Rows.Count;
            string CO_ADD = "";
            
            for (I = 0; I < dtcompadd.Rows.Count; I++)
            {
                CO_ADD = dtcompadd.Rows[0][0].ToString(); ;
                //CO_ADD1 = DT.Rows[0][0].ToString(); ;
            }
            edpcon.Close();
            return CO_ADD;
         
            
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {

            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = new DataTable();
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
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;

            }
        }

        private void CmbCompany_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
            {
                Company_id = Convert.ToInt32(CmbCompany.ReturnValue);
                cmbCID.Text = Company_id.ToString();
            }
        }


        private void CmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = new DataTable();//clsDataAccess.RunQDTbl("select Location_Name,Location_ID from tbl_Emp_Location");
            dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID," +
           "(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client,el.Cliant_ID as ClientID  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + "'))) order by Location_Name");
               

            if (dt.Rows.Count > 0)
            {
                CmbLocation.LookUpTable = dt;
                CmbLocation.ReturnIndex = 1;
            }
        }

        private void CmbLocation_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(CmbLocation.ReturnValue);
                cmbLID.Text = Location_id.ToString();
        }

    }
}
        
    

