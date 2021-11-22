using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class frm_register_FORM_XII : Form
    {
        public frm_register_FORM_XII()
        {
            InitializeComponent();
        }
        ArrayList arritem = new ArrayList();
        string arrayItem = "";
        Hashtable getcode_item = new Hashtable();
        string coid = "", locid = "", empid = "";

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string sql = "Select Location_Name,Location_ID," +
          "(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName," +
          "(SELECT (select co_name from Company where CO_CODE=ec.coid) FROM  tbl_Employee_CliantMaster ec where client_id=EL.Cliant_ID)as Company  from tbl_Emp_Location EL where (Location_id in (select distinct Location_id from tbl_employee_mast where Company_id='"+CmbCompany.ReturnValue.Trim()+"'))  order by Location_Name";

            DataTable DT_Cmp = clsDataAccess.RunQDTbl(sql);
            if (DT_Cmp.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = DT_Cmp;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                CmbCompany.ReturnValue = dt.Rows[0]["co_code"].ToString();
                CmbCompany.Text = dt.Rows[0]["co_name"].ToString();
            }
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlstmnt = "SELECT Client_Name AS ClientName, Client_id AS ID, coid AS ID1  FROM tbl_Employee_CliantMaster";

                if (rdb_ic_loc.Checked == true)
                {
                    sqlstmnt = ("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID,Location_id FROM tbl_Employee_Mast em WHERE (Company_id = " +
                         CmbCompany.ReturnValue + ") AND (Location_id = " + cmbLocation.ReturnValue + ") ORDER BY ID,Location_id ");
                }
                else if (rdb_ic_emp.Checked == true)
                {
                    sqlstmnt = ("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , ID,Company_id FROM tbl_Employee_Mast em WHERE (Company_id=" + CmbCompany.ReturnValue + ") ORDER BY ID,Company_id");
                }
                else
                {
                    sqlstmnt = ("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , ID,Company_id FROM tbl_Employee_Mast em WHERE (Company_id = " +
                            CmbCompany.ReturnValue + ") ORDER BY ID,Company_id");

                }

                EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Client", "Select Client", 0, "CMPN", 0);

                arritem.Clear();
                arritem = EDPCommon.arr_mod;

                if (arritem.Count > 0)
                {
                    getcode_item.Clear();
                    arritem = EDPCommon.arr_mod;
                    getcode_item = EDPCommon.get_code;
                    
                    empid = "";
                   
                    for (int i = 0; i <= arritem.Count - 1; i++)
                    {
                        if (empid == "")
                        {
                            empid = "'" + getcode_item[i].ToString() + "'";
                        }
                        else
                        {
                            empid = empid + ",'" + getcode_item[i].ToString() + "'";
                        }

                    }
                }
            }
            catch { }
        }

        private void btnicard_prev_Click(object sender, EventArgs e)
        {
            DataTable dtemp = new DataTable();
            string sql = "", condt = "";
            try
            {
                coid = CmbCompany.ReturnValue.Trim();
            }
            catch { }
            try
            {
                locid = cmbLocation.ReturnValue.Trim();
            }
            catch { }
            if (rdb_ic_loc.Checked == true)
            {
                condt = " where (em.Location_id ='"+ cmbLocation.ReturnValue.Trim() +"')";
            }
            else if (rdb_ic_co.Checked == true)
            {
                condt = " where (em.Company_id='" + CmbCompany.ReturnValue.Trim() + "')";
            }
            else
            {
                condt = " where (em.ID in (" + empid + "))";
                if (empid.Trim() == "")
                {
                    MessageBox.Show("Please select employees first", "Bravo");
                    return;
                }
            }

          
             
             //"work_nature_location" />
             //"employer" />
             //"C1_lin" />
             //"C2_email" />
             //"C3_mob" />

            string condt1 = "isNull((select SUM(Amount)amt from tbl_Employee_SalaryGross where (TableName='tbl_Employee_ErnSalaryHead') and (SalId in (select Slno from tbl_Employee_ErnSalaryHead where (SalaryHead_Short ='BS'))) and (EmpId=em.ID) and (Company_id=em.Company_id) and (cast('01-'+month as smalldatetime) =(select max(cast('01-'+ MONTH as smalldatetime)) from tbl_Employee_SalaryGross where (EmpId=em.ID) and (Company_id=em.Company_id) ))),0)";
           

            sql = "SELECT (select CO_NAME from Company where GCODE=em.Company_id) as contractor,(select top 1 (case when (lin!='') then (case when PAN!='' then LIN + ' / ' + PAN else LIN end) else '' end)a from Branch where GCODE=em.Company_id) as A1_lin,(select top 1 Email from Branch where GCODE=em.Company_id) as A2_email,(select top 1 BRNCH_TELE1 from Branch where GCODE=em.Company_id) as A3_mob,"+
            "(SELECT Location_Name FROM tbl_Emp_Location where Location_ID=em.Location_id) as work_nature_location,"+
            "(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id) as employer,"+
            "(SELECT (select (case when (lin!='') then (case when PAN!='' then LIN + ' / ' + PAN else LIN end) else '' end)a from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id) as C1_lin,"+
            "(SELECT (select Email from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id)as C2_email,"+
            "(SELECT (select Contract_No from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id)as C3_mob,"+
            "em.code as eid,em.ID as ecode,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename,"+
            "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as desg,(case when CONVERT(VARCHAR(11),em.DateOfJoining,103)='01/01/1900' then '' else CONVERT(VARCHAR(11),em.DateOfJoining,103) end) as 'doj'," +
            "(case when (PassportNo!='') then (case when REPLACE(aadhar, ' ', '')!='' then PassportNo + ' / ' + REPLACE(aadhar, ' ', '') else REPLACE(aadhar, ' ', '') end) else '' end) as D1_uan,cast((case when (em.Mobile=0) then '' else cast(em.mobile as nvarchar(Max)) end) as nvarchar(Max)) as D2_mob," +
            "em.Permanentstreet,em.Permanentcity,em.Permanentpin,cast(convert(char(11), em.DateOfBirth, 103) as VARCHAR) as 'dob',(" + condt1 + ") as wage_rate,em.BlGrp,em.Gender,'' as remark," +
            "(select c.CO_ADD  from Company c where c.CO_CODE=em.Company_id ) as comp_address,"+
            "(select Client_ADD1 +','+ Client_City from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=em.Location_ID ))  + ', '+(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=em.Location_ID ) )) as client_address,"+
            "(case when (ltrim(rtrim(em.Presentstreet))='')then '' else em.Presentstreet + ','+ em.Presentcity+ ','+(select State_Name from StateMaster where STATE_CODE=em.Presentstate)+' - '+em.Presentpin end) as emp_address,"+
            "em.Empimage as photo,(select sign from tbl_employee_fscan where ID=em.ID)as [sign] FROM tbl_Employee_Mast AS em" + condt;

            dtemp = clsDataAccess.RunQDTbl(sql);
            MidasReport.Form1 frm1 = new MidasReport.Form1();
            frm1.show_icard(dtemp, 10,"");
            frm1.ShowDialog();
        }

        private void frm_register_FORM_XII_Load(object sender, EventArgs e)
        {
            CmbCompany.PopUp();
            cmbLocation.PopUp();
        }
    }
}
