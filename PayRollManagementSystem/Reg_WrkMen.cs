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
    public partial class Reg_WrkMen : Form
    {
        string Locations = "";
        string Location_Name = "", CO_ADD = "", sub = "", client = "", clientadd = "",comp="";
        int Company_id = 0, Loc_id = 0;
        DataTable dty = new DataTable();

        public Reg_WrkMen()
        {
            InitializeComponent();
        }

        private void frmRegWrkMen_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            clsValidation.GenerateYear(cmbYear, 2000, System.DateTime.Now.Year, 1);
            if (DateTime.Now.Month >= 4)

                try
                {
                    if (DateTime.Now.Month >= 4)
                    {
                        try
                        { cmbYear.SelectedItem = DateTime.Now.Year + "-" + DateTime.Now.AddYears(1).Year; }
                        catch { }

                    }
                    else
                    {
                        cmbYear.SelectedItem = DateTime.Now.AddYears(-1).Year + "-" + DateTime.Now.Year;

                    }
                }
                catch
                { }

            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt.Rows[0][0]);

                Company_id = Convert.ToInt32(dt.Rows[0][1]);
                cmbcompany.Enabled = false;
            }
            else if (dt.Rows.Count > 1)
            {
                cmbcompany.Enabled = true;
            }

           cmbLocation.Enabled = false;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt;
            dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                // cmbLocation.Text = "";
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
               
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);

            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string s = "select  l.Location_Name, l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l,Companywiseid_Relation ls where l.Location_ID = ls.Location_ID";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Loc_id = Convert.ToInt32(cmbLocation.ReturnValue);
            cmbLocation.Text = cmbLocation.Text + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + Loc_id);
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getdata();
            MidasReport.Form1 rwm = new MidasReport.Form1();
            rwm.regwrkmen(comp,CO_ADD, sub, client, clientadd,dty,0);
            rwm.Show();
           
        }

        public void getdata()
        {
            
            string qry = "", cond = "",  crit = "";

            if (radioButton3.Checked == true)
            {
                crit = "order by EmployeeName";
            }
            else if (radioButton4.Checked == true)
            {
                crit = "order by DOJ";
            }
            

            if(radioButton1.Checked==true)
            {
                cond = " where (em.company_id='" + Company_id + "' and em.Session='"+cmbYear.Text+"')";

                 comp = clsDataAccess.GetresultS("select CO_NAME FROM Company WHERE CO_CODE = '" + Company_id + "'");
                 CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                 sub = "";
                 client = "";
                 clientadd = "";
            

            }
            else if(radioButton2.Checked==true)
            {


                cond = " where (em.Location_id='" + Loc_id + "' and em.company_id='" + Company_id + "' and em.Session='"+cmbYear.Text+"')";

                comp = clsDataAccess.GetresultS("select CO_NAME FROM Company WHERE CO_CODE = '" + Company_id + "'");
                 CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                 sub = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Loc_id + "') ");
                 client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Loc_id + "");
                 clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Loc_id + "");
            
            }
            qry = "select ID,"+ 
                  "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS 'EmployeeName',"+
                  "((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'FatherName',"+
                  "isNull(Gender,'MALE') as 'MS',(select JobType from tbl_Employee_JobType where SlNo=em.JobType)as 'JobType'," +
                  "(select p.DesignationName from tbl_Employee_DesignationMaster p where p.SlNo=em.DesgID) AS 'Designation',"+
                  "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.presentcountry=country_Code)) as preadd, " +
                  "(Permanentstreet +'\n\r'+ Permanentcity +'-'+ Permanentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Permanentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Permanentcountry=country_Code))as peradd ," +
                  "CONVERT(VARCHAR(11),DateOfJoining,103) as 'DOJ',(case when active='1'then CONVERT(VARCHAR(11),DateOfRetirement,103) else '' end) as 'dot',CONVERT(VARCHAR(11),DateOfBirth,103) as 'DOB'," +
                  "(select sign from tbl_employee_fscan  where ID=em.ID) as 'sign',(select lThumb from tbl_employee_fscan  where ID=em.ID) as 'thumb', 'retirement'as rft,remarks " +
                  "from tbl_Employee_Mast em  "+ cond +""+crit;
            dty = clsDataAccess.RunQDTbl(qry);

                                   
                                                                                                                                                                                                                                              
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                cmbLocation.Enabled = true;
                cmbLocation.Focus();


            }
            else if(radioButton1.Checked==true)
            {
                cmbLocation.Text = "";
                cmbLocation.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getdata();
            MidasReport.Form1 rwm = new MidasReport.Form1();
            rwm.regwrkmen(comp, CO_ADD, sub, client, clientadd, dty,1);
            
        }
    }
}
