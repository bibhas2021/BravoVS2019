using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class Reg_Icard : Form
    {
        int Location_id = 0, company_id = 0;
        string sub = "", client = "", clientadd = "", CO_ADD = "";
        DataTable dt = new DataTable();
 
        public Reg_Icard()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }

        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                company_id = Convert.ToInt32(cmbcompany.ReturnValue);
      
        }

        private void CmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("Select EL.Location_Name,EL.Location_ID from tbl_Emp_Location EL,Companywiseid_Relation cr where cr.Location_ID=EL.Location_ID and  cr.Company_ID='" + company_id + "'");
            if (dt.Rows.Count > 0)
            {
                CmbLocation.LookUpTable = dt;
                CmbLocation.ReturnIndex = 1;
            }
       
        }

        private void CmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbLocation.ReturnValue) == true)
                Location_id = Convert.ToInt32(CmbLocation.ReturnValue);
      
        }

        private void Icard_Reg_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            clsValidation.GenerateYear(cmbYear, 2000, System.DateTime.Now.Year, 1);
            try
            {
                if (dateTimePicker1.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = dateTimePicker1.Value.AddYears(-1).Year + "-" + dateTimePicker1.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            
            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = company_id.ToString();
                cmbcompany.Enabled = false;
                CmbLocation.Enabled = false;


            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
                CmbLocation.Enabled = false;
            }


        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            string cond = "";
            if (radioButton3.Checked == true)
            {
                cond = "ORDER BY EmpName ";
            }
            else if (radioButton4.Checked == true)
            {
                cond = "ORDER BY doj";
            }

            if(radioButton2.Checked==true)        
            
            {
                dt = clsDataAccess.RunQDTbl("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName',remarks, "+
          "cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as dob,cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as doj,Empimage,issuedate ,(select f.sign from tbl_employee_fscan  f where em.ID=f.ID)as sign," +
          "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.presentcountry=country_Code)) as preadd, "+
          "(select (case when sign!=''then sign else (case when sign2!='' then sign2 else (case when sign3!='' then sign3 end)end)end)from Company where CO_CODE='1')as 'a_sign'" +
          "FROM tbl_Employee_Mast em WHERE (Company_id = " + company_id + ") AND (Location_id = " + Location_id + ") "+cond);

                 sub = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                 client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD  FROM Company WHERE CO_CODE = '" + company_id + "'");

            }
            else if(radioButton1.Checked==true)
            {
                dt = clsDataAccess.RunQDTbl("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName',remarks, "+
          "cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as dob,cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as doj,Empimage,issuedate ,(select f.sign from tbl_employee_fscan  f where em.ID=f.ID)as sign," +
          "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.presentcountry=country_Code)) as preadd, "+
          "(select (case when sign!=''then sign else (case when sign2!='' then sign2 else (case when sign3!='' then sign3 end)end)end)from Company where CO_CODE='1')as 'a_sign'" +
          "FROM tbl_Employee_Mast em WHERE (Company_id = " + company_id + ")"+cond);
            
            }
                 CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD  FROM Company WHERE CO_CODE = '" + company_id + "'");
                 sub = "";
                 client = "";
                 clientadd = "";
            
            MidasReport.Form1 ic = new MidasReport.Form1();
            ic.i_card(cmbcompany.Text,CO_ADD,sub,client,clientadd,dt,0);
            ic.Show();
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            string cond = "";
            if (radioButton3.Checked == true)
            {
                cond = "ORDER BY EmpName ";
            }
            else if (radioButton4.Checked == true)
            {
                cond = "ORDER BY doj";
            }

            if (radioButton2.Checked == true)
            {
                dt = clsDataAccess.RunQDTbl("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName',remarks, " +
          "cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as dob,cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as doj,Empimage,issuedate ,(select f.sign from tbl_employee_fscan  f where em.ID=f.ID)as sign," +
          "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.presentcountry=country_Code)) as preadd, " +
          "(select (case when sign!=''then sign else (case when sign2!='' then sign2 else (case when sign3!='' then sign3 end)end)end)from Company where CO_CODE='1')as 'a_sign'" +
          "FROM tbl_Employee_Mast em WHERE (Company_id = " + company_id + ") AND (Location_id = " + Location_id + ") " + cond);

                sub = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD  FROM Company WHERE CO_CODE = '" + company_id + "'");

            }
            else if (radioButton1.Checked == true)
            {
                dt = clsDataAccess.RunQDTbl("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName',remarks, " +
          "cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as dob,cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as doj,Empimage,issuedate ,(select f.sign from tbl_employee_fscan  f where em.ID=f.ID)as sign," +
          "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.presentcountry=country_Code)) as preadd, " +
          "(select (case when sign!=''then sign else (case when sign2!='' then sign2 else (case when sign3!='' then sign3 end)end)end)from Company where CO_CODE='1')as 'a_sign'" +
          "FROM tbl_Employee_Mast em WHERE (Company_id = " + company_id + ")" + cond);

            }
            CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD  FROM Company WHERE CO_CODE = '" + company_id + "'");
            sub = "";
            client = "";
            clientadd = "";

            MidasReport.Form1 ic = new MidasReport.Form1();
            ic.i_card(cmbcompany.Text, CO_ADD, sub, client, clientadd, dt,1);
            //ic.Show();
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                 DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
                 if (dta.Rows.Count == 1)
                 {
                     cmbcompany.Enabled = false;
                     CmbLocation.Enabled = true;
                     CmbLocation.Focus();
           
                 }
                 else if (dta.Rows.Count > 1)
                 {
                     cmbcompany.Enabled = true;
                     CmbLocation.Enabled = true;
                     CmbLocation.Focus();
           
                 }

           
             }
            else
                if (radioButton1.Checked == true)
                {
                    DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
                    if (dta.Rows.Count == 1)
                    {
                        cmbcompany.Enabled = false;
                        CmbLocation.Text = "";
                        CmbLocation.Enabled = false;
                        //CmbLocation.Focus();

                    }
                    else if (dta.Rows.Count > 1)
                    {
                        cmbcompany.Enabled = true;
                        cmbcompany.Focus();
                        CmbLocation.Text = "";
                        CmbLocation.Enabled = false;
                        //CmbLocation.Focus();

                    }

                }
        }
    }
}
