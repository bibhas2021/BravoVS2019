using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.IO;
using EDPComponent;





namespace PayRollManagementSystem
{
    public partial class frmEmp_Verification : Form
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        String strMode = String.Empty;


        SqlTransaction sqltran;
        int Company_ID = 0, Location_ID = 0, emp_id = 0, ps_ID = 0;

        public frmEmp_Verification()
        {
            InitializeComponent();
        }
        SqlCommand cmd=new SqlCommand();


        public void clr()
        {
            dgv_show.Rows.Clear();
                dtp_from.Value=DateTime.Now;
            rdbCompany.Checked = true;

            cmbcompany.PopUp();

        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            //    string sqlstmnt = "Select distinct (select e.Title+' '+e.FirstName+' '+e.MiddleName+' '+ e.LastName from tbl_Employee_Mast e where e.ID=s.emp_id) as 'EmpName',s.emp_id as 'ID',month from tbl_Employee_SalaryMast s where s.Month='" + month + "' and s.Session ='" + cmbYear.Text + "' "; //and s.Location_id= '" + get_LocationID(cmbsalstruc.Text) + "'
            //    sqlstmnt = sqlstmnt + " AND s.emp_id IN ( select emp_id from tbl_Employee_SalaryMast group by emp_id,month having COUNT(*)>1 ) ";
            //    EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Employee", "Select Employee", 0, "CMPN", 0);

            //    arritem.Clear();
            //    arritem = EDPCommon.arr_mod;

            //    if (arritem.Count > 0)
            //    {
            //        getcode_item.Clear();
            //        arritem = EDPCommon.arr_mod;
            //        getcode_item = EDPCommon.get_code;

            //        Item_Code = null;
            //        Item_Code = "''";

            //        for (int i = 0; i <= arritem.Count - 1; i++)
            //        {
            //            Item_Code = Item_Code + "," + "'" + getcode_item[i].ToString() + "'";

            //        }

            //    }
            //}
            //catch { }

        }
  

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select CO_NAME,GCODE from Company");
            if (dt.Rows.Count >1)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                Company_ID = Convert.ToInt32(dt.Rows[0]["GCODE"]);
                cmbcompany.Text = dt.Rows[0]["CO_NAME"].ToString();
                getdetails();
                //cmbcompany.LookUpTable = dt;
                //cmbcompany.ReturnIndex = 1;
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            //cmblocation.Text = "";

            if (Information.IsNumeric(cmbcompany.ReturnValue.Trim()))
            {

                Company_ID = Convert.ToInt32(cmbcompany.ReturnValue.Trim());
                getdetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Company  must be entered");
                return;
            }
    
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string s = "select  l.Location_Name, l.Location_ID  from tbl_Emp_Location l";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            cmbcompany.Text = "";
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
            {
                Location_ID  = Convert.ToInt32(cmbLocation.ReturnValue);
                getdetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Location  must be entered");
                return;
            }
        }

        //private void btnPreview_Click(object sender, EventArgs e)
        //{
        //}

        private void getdetails()
        {
            DataTable dtc = new DataTable();

            if (rdbCompany.Checked == true)
            {
                string qry = "select  ID, ((CASE  WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + "
                  + "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS 'Ename',((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + "
                  + "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'Fathername', "
                  + "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Presentcountry=country_Code)) as 'preadd',"
                  + " Mobile,cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as 'dob',cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as 'doj',"
                  + "(Permanentstreet +'\n\r'+ Permanentcity +'-'+ Permanentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Permanentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Permanentcountry=country_Code))as 'peradd',"
                  + " Empimage,(select Emp_GunLicence AS 'ArmLicenseNo'from tbl_Employee_Other_Reff where ID=em.ID) ,(select a.verifystatus from verify_status_master a ,tbl_Emp_verifystatus b  where a.vid=b.verify_status and b.eid=em.ID) AS VerificationStatus ,'' AS 'CriminalDetails' from tbl_Employee_Mast em where Company_id='" + Company_ID + "' order by ID desc";

                dtc = clsDataAccess.RunQDTbl(qry);
            }
            else if (rdbLocation.Checked == true)
            {
                string qry = "select  ID, ((CASE  WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + "
                  + "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS 'Ename',((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + "
                  + "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'Fathername', "
                  + "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Presentcountry=country_Code)) as 'preadd',"
                  + " Mobile,cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as 'dob',cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as 'doj',"
                  + "(Permanentstreet +'\n\r'+ Permanentcity +'-'+ Permanentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Permanentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Permanentcountry=country_Code))as 'peradd',"
                  + " Empimage,(select Emp_GunLicence AS 'ArmLicenseNo'from tbl_Employee_Other_Reff where ID=em.ID) ,(select a.verifystatus from verify_status_master a ,tbl_Emp_verifystatus b  where a.vid=b.verify_status and b.eid=em.ID) AS VerificationStatus ,'' AS 'CriminalDetails' from tbl_Employee_Mast em where Location_id='" + Location_ID + "' order by ID desc";

                dtc = clsDataAccess.RunQDTbl(qry);
            }
            else if (rdbEmployee.Checked == true)
            {
                string qry = "select  ID, ((CASE  WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + "
              + "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS 'Ename',((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + "
              + "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'Fathername', "
              + "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Presentcountry=country_Code)) as 'preadd',"
              + " Mobile,cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as 'dob',cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as 'doj',"
              + "(Permanentstreet +'\n\r'+ Permanentcity +'-'+ Permanentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Permanentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Permanentcountry=country_Code))as 'peradd',"
              + " Empimage,(select Emp_GunLicence AS 'ArmLicenseNo'from tbl_Employee_Other_Reff where ID=em.ID) ,(select a.verifystatus from verify_status_master a ,tbl_Emp_verifystatus b  where a.vid=b.verify_status and b.eid=em.ID) AS VerificationStatus ,'' AS 'CriminalDetails' from tbl_Employee_Mast em where ID='" + emp_id + "' order by ID desc";

                dtc = clsDataAccess.RunQDTbl(qry);
            }

            dgv_show.DataSource = dtc;

            dgv_show.AutoResizeColumns();

        }   
        

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (submitdetails())
            {
                ERPMessageBox.ERPMessage.Show("VERIFICATION STATUS ENTERED SUCCESSFULLY");
                getdetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("VERIFICATION STATUS  NOT ENTERED SUCCESSFULLY");
            }
        }


        private Boolean submitdetails()
        {
            int j;
            Boolean boolSubmit = true;
            Boolean boolStatus = false;
            Int32 intCounter = 0;

            //string ps="insert into ps_master (Pid,PoliceStation)values()"


            if (dgv_show.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dgv_show.Rows.Count - 1; i++)
                {
                    string streid = Convert.ToString(dgv_show.Rows[i].Cells["ID"].Value);
                    string strvfs = Convert.ToString(dgv_show.Rows[i].Cells["VerificationStatus"].Value);
                    if (!string.IsNullOrEmpty(streid))
                    {
                        if (!string.IsNullOrEmpty(strvfs))
                        {
                            DataTable dt = new DataTable();
                            if (strvfs != "")
                                dt = clsDataAccess.RunQDTbl("select vid from verify_status_master where verifystatus='" + strvfs + "'");
                            if (dt.Rows.Count > 0)
                            {
                                strvfs = Convert.ToString(dt.Rows[0]["vid"]);
                            }
                            //if (!string.IsNullOrEmpty(streid) && !string.IsNullOrEmpty(strvfs))
                            //{
                            //    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Emp_verifystatus(current_status,csdate)values('" + strvfs + "','" + dtp_from.Value.ToString("dd/MM/yyyy") + "'");
                            //}
                            //else
                            //{
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Emp_verifystatus (eid,verify_status,csdate,psid)values('" + streid + "','" + strvfs + "','" + dtp_from.Value.ToString("dd/MMM/yyyy") + "','" + ps_ID + "')");
                            //}
                            if (boolStatus)
                            {
                                intCounter += 1;
                            }
                        }
                    }
                    else
                    {
                        j = i + 1;
                        ERPMessageBox.ERPMessage.Show("please enter verify status in line" + j + "");
                    }
                }
                if (intCounter == dgv_show.Rows.Count - 1)
                {
                    boolSubmit = true;
                }


            }
            return boolStatus;
        }

            //DataTable dt_pr = new DataTable();

            //string qry = "select top 5 ID, ((CASE  WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + "
            //  + "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS 'Ename',((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + "
            //  + "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'Fathername', "
            //  + "(Presentstreet +'\n\r'+ Presentcity +'-'+ Presentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Presentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Presentcountry=country_Code)) as 'preadd',"
            //  + " Mobile,cast(convert(char(11), DateOfBirth, 103) as VARCHAR) as 'dob',cast(convert(char(11), DateOfJoining, 103) as VARCHAR) as 'doj',"
            //  + "(Permanentstreet +'\n\r'+ Permanentcity +'-'+ Permanentpin +'\n\r'+ (select upper(state_name) from statemaster where em.Permanentstate=State_code)+ ','+(SELECT upper(Country_name) from Country where em.Permanentcountry=country_Code))as 'peradd',"
            //  + " Empimage,(select Emp_GunLicence from tbl_Employee_Other_Reff where ID=em.ID)AS 'ArmLicenseNo' ,(select a.verifystatus from verify_status_master a ,tbl_Emp_verifystatus b  where a.vid=b.verify_status and b.eid=em.ID)AS 'VerificationStatus' ,'' AS 'CriminalDetails' from tbl_Employee_Mast em where Company_id='" + Company_ID + "' order by ID desc";

            //dt_pr=clsDataAccess.RunQDTbl(qry);

            

            

        private void CmbEmpId_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

            DataTable dt = new DataTable();
            //if (Location_ID != 0)
            //{
                dt = clsDataAccess.RunQDTbl("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID FROM tbl_Employee_Mast em ORDER BY ID");
            //}
            //else
            //{
          //      dt = clsDataAccess.RunQDTbl("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          //"(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , ID FROM tbl_Employee_Mast em WHERE (Company_id = " +
          //              Co_ID + ") ORDER BY ID");

            //}
            if (dt.Rows.Count > 0)
            {
                CmbEmpId.LookUpTable = dt;
                CmbEmpId.ReturnIndex = 1;
            }
  
        }

        private void CmbEmpId_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            cmbcompany.Text = "";
            cmbLocation.Text = "";
            if (Information.IsNumeric(CmbEmpId.ReturnValue) == true)
            {
                emp_id = Convert.ToInt32(CmbEmpId.ReturnValue);
                getdetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Employee  must be selected");
                return;
           
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCompany.Checked == true)
            {
                cmbcompany.Enabled = true;
                cmbLocation.Text = "";
                cmbLocation.Enabled = false;
                CmbEmpId.Text = "";
                CmbEmpId.Enabled = false;
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLocation.Checked == true)
            {
                cmbLocation.Enabled = true;
                cmbcompany.Text = "";
                cmbcompany.Enabled = false;
                CmbEmpId.Text = "";
                CmbEmpId.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEmployee.Checked == true)
            {
                CmbEmpId.Enabled = true;
                cmbcompany.Text = "";
                cmbcompany.Enabled = false;
                cmbLocation.Text = "";
                cmbLocation.Enabled = false;
            }
        }

        

        private void ps_id_DropDown_1(object sender, EventArgs e)
        {
            string s = "select  PoliceStation ,psid from ps_master ";
            DataTable dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {
                ps_id.LookUpTable = dt;
                ps_id.ReturnIndex = 1;

            }
        }

        private void ps_id_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(ps_id.ReturnValue) == true)
            {
                ps_ID = Convert.ToInt32(ps_id.ReturnValue);
               
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("police station must be entered");
                return;
            }
      
        }

        private void frmEmp_Verification_Load(object sender, EventArgs e)
        {

        }

        private void dgv_show_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["VerificationStatus"].Value = "inprocess";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        

        


   }

      
}
