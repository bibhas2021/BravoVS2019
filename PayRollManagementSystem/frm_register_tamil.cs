using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Edpcom;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frm_register_tamil : Form
    {
        public frm_register_tamil()
        {
            InitializeComponent();
        }

        ArrayList arritem = new ArrayList();
        string arrayItem = "";
        Hashtable getcode_item = new Hashtable();
        string coid = "", locid = "", empid = "";
        DataTable dt_fine = new DataTable();
        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string sql = "Select Location_Name,Location_ID," +
          "(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName," +
          "(SELECT (select co_name from Company where CO_CODE=ec.coid) FROM  tbl_Employee_CliantMaster ec where client_id=EL.Cliant_ID)as Company  from tbl_Emp_Location EL where (Location_id in (select distinct Location_id from tbl_employee_mast where Company_id='" + CmbCompany.ReturnValue.Trim() + "'))  order by Location_Name";

            DataTable DT_Cmp = clsDataAccess.RunQDTbl(sql);
            if (DT_Cmp.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = DT_Cmp;
                cmbLocation.ReturnIndex = 1;
            }
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
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , ID,Company_id FROM tbl_Employee_Mast em ORDER BY ID,Company_id");
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
            string sign = "";
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
                condt = " where (em.Location_id ='" + cmbLocation.ReturnValue.Trim() + "')";
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
            string condt1 = "isNull((select SUM(Amount)amt from tbl_Employee_SalaryGross where (TableName='tbl_Employee_ErnSalaryHead') and (SalId in (select Slno from tbl_Employee_ErnSalaryHead where (SalaryHead_Short ='BS'))) and (EmpId=em.ID) and (Company_id=em.Company_id) and (month ='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "')),0)";
           
            sql = "SELECT (select CO_NAME from Company where GCODE=em.Company_id) as contractor,(select top 1 (case when (lin!='') then (case when PAN!='' then LIN + ' / ' + PAN else LIN end) else '' end)a from Branch where GCODE=em.Company_id) as A1_lin,(select top 1 Email from Branch where GCODE=em.Company_id) as A2_email,(select top 1 BRNCH_TELE1 from Branch where GCODE=em.Company_id) as A3_mob," +
            "(SELECT Location_Name FROM tbl_Emp_Location where Location_ID=em.Location_id) as work_nature_location," +
            "(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id) as employer," +
            "(SELECT (select (case when (lin!='') then (case when PAN!='' then LIN + ' / ' + PAN else LIN end) else '' end)a from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id) as C1_lin," +
            "(SELECT (select Email from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id)as C2_email," +
            "(SELECT (select Contract_No from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id)as C3_mob," +
            "em.code as eid,em.ID as ecode,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename," +
            "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as desg,(case when CONVERT(VARCHAR(11),em.DateOfJoining,103)='01/01/1900' then '' else CONVERT(VARCHAR(11),em.DateOfJoining,103) end) as 'doj',"+
            "(case when CONVERT(VARCHAR(11),em.DateOfJoining,103)='01/01/1900' then '' else CONVERT(VARCHAR(11),em.DateOfJoining,103) +' To '+ CONVERT(VARCHAR(11),DATEADD(YEAR,1, em.DateOfJoining-1),103)end) AS Range," +
            "(case when (PassportNo!='') then (case when REPLACE(aadhar, ' ', '')!='' then PassportNo + ' / ' + REPLACE(aadhar, ' ', '') else REPLACE(aadhar, ' ', '') end) else '' end) as D1_uan,em.Mobile as D2_mob," +
            "em.Permanentstreet,em.Permanentcity,em.Permanentpin,cast(convert(char(11), em.DateOfBirth, 103) as VARCHAR) as 'dob',("+condt1 + ") as wage_rate,em.BlGrp,em.Gender,'' as remark," +
            "(select c.CO_ADD  from Company c where c.CO_CODE=em.Company_id ) as comp_address," +
            "(select Client_ADD1 +','+ Client_City from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=em.Location_ID ))  + ', '+(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=em.Location_ID ) )) as client_address," +
            "(case when (ltrim(rtrim(em.Presentstreet))='')then '' else em.Presentstreet + ','+ em.Presentcity+ ','+(select State_Name from StateMaster where STATE_CODE=em.Presentstate)+' - '+em.Presentpin end) as emp_address,em.Empimage as photo,(select [sign] from Company where GCODE=em.Company_id)as [sign] FROM tbl_Employee_Mast AS em" + condt;

            
            dtemp = clsDataAccess.RunQDTbl(sql);
            MidasReport.Form1 frm1 = new MidasReport.Form1();
            frm1.register_tamil(dtemp, 20, "");
            frm1.ShowDialog();



        }

        private void btnWorkmen_Click(object sender, EventArgs e)
        {
            DataTable dtemp = new DataTable();
            string sql = "", condt = "";
            string sign = "";
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
                condt = " where (em.Location_id ='" + cmbLocation.ReturnValue.Trim() + "')";
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
            string condt1 = "isNull((select SUM(Amount)amt from tbl_Employee_SalaryGross where (TableName='tbl_Employee_ErnSalaryHead') and (SalId in (select Slno from tbl_Employee_ErnSalaryHead where (SalaryHead_Short ='BS'))) and (EmpId=em.ID) and (Company_id=em.Company_id) and (month ='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "')),0)";
           

            sql = "SELECT (select CO_NAME from Company where GCODE=em.Company_id) as contractor,(select top 1 (case when (lin!='') then (case when PAN!='' then LIN + ' / ' + PAN else LIN end) else '' end)a from Branch where GCODE=em.Company_id) as A1_lin,(select top 1 Email from Branch where GCODE=em.Company_id) as A2_email,(select top 1 BRNCH_TELE1 from Branch where GCODE=em.Company_id) as A3_mob," +
            "(SELECT Location_Name FROM tbl_Emp_Location where Location_ID=em.Location_id) as work_nature_location," +
            "(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id) as employer," +
            "(SELECT (select (case when (lin!='') then (case when PAN!='' then LIN + ' / ' + PAN else LIN end) else '' end)a from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id) as C1_lin," +
            "(SELECT (select Email from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id)as C2_email," +
            "(SELECT (select Contract_No from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=em.Location_id)as C3_mob," +
            "em.code as eid,em.ID as ecode,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename," +
            
            "em.Gender,((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN em.FathMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN em.FathLN+ ' ' ELSE '' END)) AS 'Father'," +
            "((CASE WHEN ltrim(rtrim(em.MothFN)) != '' THEN em.MothFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MothMN)) != '' THEN em.MothMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MothLN)) != '' THEN em.MothLN+ ' ' ELSE '' END)) AS 'MotherName'," +
            "((CASE WHEN ltrim(rtrim(em.HusFN)) != '' THEN em.HusFN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.HusMN)) != '' THEN em.HusMN + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.HusLN)) != '' THEN em.HusLN+ ' ' ELSE '' END)) AS 'Spouse'," +
            "CONVERT(VARCHAR(11),DateOfBirth,103) as 'Date Of Birth','Indian' as 'Nationality'," +

            "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as desg,(case when CONVERT(VARCHAR(11),em.DateOfJoining,103)='01/01/1900' then '' else CONVERT(VARCHAR(11),em.DateOfJoining,103) end) as 'doj'," +
            "(case when (PassportNo!='') then (case when REPLACE(aadhar, ' ', '')!='' then PassportNo + ' / ' + REPLACE(aadhar, ' ', '') else REPLACE(aadhar, ' ', '') end) else '' end) as D1_uan,em.Mobile as D2_mob," +
            "em.Permanentstreet,em.Permanentcity,em.Permanentpin,cast(convert(char(11), em.DateOfBirth, 103) as VARCHAR) as 'dob',("+condt1+" as wage_rate,em.BlGrp,em.Gender,'' as remark," +
            "(select c.CO_ADD  from Company c where c.CO_CODE=em.Company_id ) as comp_address," +
            "(select Client_ADD1 +','+ Client_City from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=em.Location_ID ))  + ', '+(select State_Name  from StateMaster where STATE_CODE =(select c.Client_State  from tbl_Employee_CliantMaster c where c.Client_id=(select l.Cliant_ID  from tbl_Emp_Location l where l.Location_ID=em.Location_ID ) )) as client_address," +
            "(case when (ltrim(rtrim(em.Presentstreet))='')then '' else em.Presentstreet + ','+ em.Presentcity+ ','+(select State_Name from StateMaster where STATE_CODE=em.Presentstate)+' - '+em.Presentpin end) as emp_address," +
             "(case when (ltrim(rtrim(em.Permanentstreet))='')then '' else em.Permanentstreet + ','+ em.Permanentcity+ ','+(select State_Name from StateMaster where STATE_CODE=em.Permanentstate)+' - '+em.Permanentpin end) as 'emp_address_per'," +
"isNull((SELECT top 1 CONVERT(VARCHAR(11),sdate,103) as sdate FROM (SELECT slid, eid,(SELECT status FROM tbl_StatusMst WHERE (sid = sl.sid)) AS Status,ucode,sdate,reason FROM tbl_statuslog AS sl) AS st WHERE (Status IN ('InActive','Resign','Leave') and eid=em.ID) order by eid,sdate),'') as 'doresign'," +
            "isNull((SELECT top 1 reason FROM (SELECT slid, eid,(SELECT status FROM tbl_StatusMst WHERE (sid = sl.sid)) AS Status,ucode,sdate,reason FROM tbl_statuslog AS sl) AS st WHERE (Status IN ('InActive','Resign','Leave') and eid=em.ID) order by eid,sdate),'') as 'Reason'," +
            "em.Empimage as photo,(select sign from tbl_employee_fscan where ID=em.ID)as [sign] FROM tbl_Employee_Mast AS em" + condt;


            dtemp = clsDataAccess.RunQDTbl(sql);
            MidasReport.Form1 frm1 = new MidasReport.Form1();
            frm1.register_tamil(dtemp, 21, "");
            frm1.ShowDialog();
        }

        private void frm_register_tamil_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2014, System.DateTime.Now.Year, 1);
            CmbCompany.PopUp();
            cmbLocation.PopUp();
            AttenDtTmPkr.Value = DateAndTime.Now.AddMonths(-1);
        }

        private void btnFine_Click(object sender, EventArgs e)
        {
            locid = cmbLocation.ReturnValue;
            coid = CmbCompany.ReturnValue;
            if (cmbLocation.Text != "")
            {
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + coid + "'");
                //string qry = "";
                //           qry = "SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS 'Name',"+
                //"(CASE WHEN ltrim(rtrim(FathFN)) != '' THEN FathFN ELSE '' END) +(CASE WHEN ltrim(rtrim(FathMN)) != '' THEN ' ' + FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(FathLN)) != '' THEN ' ' + FathLN ELSE '' END) AS 'FatherName',"+
                //" CONVERT(char(10),a.FDT, 103) AS FDT,a.FAMT,a.LocID, e.Location_id, e.Company_id, s.Amount, s.Month,m.Month,s.Session,m.NetPay,(SELECT DesignationName FROM tbl_Employee_DesignationMaster AS m  WHERE (SlNo = e.DesgId)) AS DesignationName,"+
                //"(SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = " + Location_id + ")) AS Location_Name FROM tbl_Employee_SalaryMast AS m, tbl_fine_log AS a, tbl_Employee_Mast AS e INNER JOIN tbl_Employee_SalaryDet AS s ON e.ID = s.EmpId WHERE (e.Location_id =" + Location_id + " ) AND (e.Company_id = 1) AND (s.Session = '" + CmbSession.Text + "') AND (s.TableName = 'tbl_Employee_DeductionSalayHead') AND (s.SalId = (SELECT SAL_HEAD FROM tbl_Employee_Assign_SalStructure AS ss WHERE (Location_id = " + Location_id + ") AND (chkALK = 4))) and a.LocID = " + Location_id + " and e.Location_id = " + Location_id + " and e.ID = a.eid and m.Emp_Id = a.eid and s.Month= '" + dateTimePicker1.Value.ToString("MMMM")+ "' ";
                //DataTable dt = clsDataAccess.RunQDTbl(qry);
                get_data();
                String sub = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + locid + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + locid + "");
                String clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + locid + "");
                String month = AttenDtTmPkr .Text;
                String session = CmbSession.Text;

                MidasReport.Form1 att = new MidasReport.Form1();
                att.Register_tamil_fine(CmbCompany.Text, CO_ADD, sub, client, clientadd, month, session, dt_fine, 0);
               
                att.Show();
                
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
        }

        private void get_data()
        {
           
            string month = AttenDtTmPkr.Value.ToString("MMMM/ yyyy");
            string mon = AttenDtTmPkr.Value.ToString("MMMM");
            string qry = "SELECT null as sl,fl.eid as ID,' '+FirstName+' '+MiddleName+' '+LastName as Name,' '+FathFN+' '+FathMN+' '+FathLN as FatherName," +
                "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName'," +
                "(select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = fl.LocID) as 'LocationName'," +
                "cast(convert(char(11), FDT, 103) as VARCHAR) as FDT,fl.FAMT," +
                "(case when fl.cause_check='1'then cause else 'no'end)as cause," +
                "fl.wit_name,cast(convert(char(11), dof, 103) as VARCHAR) as dof," +
                "(select REASON from tbl_FineMst where fid=fl.FID)as 'reason'," +
                "(select NetPay from tbl_Employee_SalaryMast where Emp_Id=fl.eid and Location_id='" + locid + "' and Month='" + mon + "')as NetPay, " +
                "(select cast(convert(char(11), Date_of_Insert, 103) as VARCHAR) from tbl_Employee_SalaryMast where Emp_Id=fl.eid and Location_id='" + locid + "' and Month='" + mon + "')as 'frd'" +
                "from tbl_fine_log fl, tbl_Employee_Mast em where em.ID=fl.eid  and   fl.LocID='" + locid + "' and fl.FMONTH='" + month + "'";

            dt_fine = clsDataAccess.RunQDTbl(qry);
            if (dt_fine.Rows.Count == 0)
            {
                MessageBox.Show("There is no fine record ");
               qry= "SELECT 'NIL' as sl,'NIL' as ID,'NIL' as Name,'NIL' as FatherName,'NIL' as 'DesignationName','NIL' as 'LocationName','NIL' as FDT,'NIL' as FAMT,'NIL' as cause,'NIL' wit_name,'NIL' as dof,'NIL' as 'reason','NIL' as NetPay, 'NIL' as 'frd'";
                dt_fine = clsDataAccess.RunQDTbl(qry);
            }
            else
            { }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { CmbSession.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }

                }
                else
                {
                    CmbSession.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;

                }
            }
            catch
            { }
        }

        private void btnFormD_Click(object sender, EventArgs e)
        { 
            DataTable dtemp = new DataTable();
            string month = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
            string mm=AttenDtTmPkr.Value.ToString("M/yyyy");
            string mon = AttenDtTmPkr.Value.ToString("MMMM");
            string sess=CmbSession.Text;
            string coid=CmbCompany.ReturnValue;
            string locid=cmbLocation.ReturnValue;
            string qry = "select Company,coadd,Site,'" + month + "' as mon,tot_emp,tot_male,tot_female,designation as desg,category,sum(m)as noMen,sum(fm)as noFemale,(rate) as Rate,SUM(bs)as basic,SUM(da)as DA, SUM(hra)as HRA, SUM(OA)as OA,sum(csec)as CSEC from (" +
             "SELECT (select CO_NAME from Company where GCODE=ea.Company_id) as 'Company',(select c.CO_ADD  from Company c where c.CO_CODE=ea.Company_id ) as 'coadd',(SELECT Location_Name FROM tbl_Emp_Location where Location_ID=ea.Location_id)+ ' - ' +(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=ea.LOcation_ID) as 'Site',"+
             "esm.Basic as 'Rate',(select COUNT (id) from tbl_Employee_Attend where LOcation_ID=ea.LOcation_ID and Company_id=ea.Company_id and MONTH=ea.Month)tot_emp," +
             "(select COUNT (id) from tbl_Employee_Attend,(select (case when gender='Female' then 'Female' else 'Male' end)Gender from tbl_Employee_Mast AS em where ea.ID = em.ID)x where LOcation_ID=ea.LOcation_ID and Company_id=ea.Company_id and MONTH=ea.Month and x.Gender='Male')tot_male,"+
             "(select COUNT (id) from tbl_Employee_Attend,(select (case when gender='Female' then 'Female' else 'Male' end)Gender from tbl_Employee_Mast AS em where ea.ID = em.ID)x where LOcation_ID=ea.LOcation_ID and Company_id=ea.Company_id and MONTH=ea.Month and x.Gender='Female')tot_female,"+
             "(select (case when Gender!='Female' then 1 else 0 end) from tbl_Employee_Mast where ID = ea.ID)m,(select (case when Gender='Female' then 1 else 0 end) from tbl_Employee_Mast where ID = ea.ID)fm," +
             "(select DesignationName FROM tbl_Employee_DesignationMaster where SlNo=ea.desgid) as designation,"+
             "(select (select [Type] FROM tbl_desg_type where slno=edm.type) FROM tbl_Employee_DesignationMaster edm where SlNo=ea.desgid) as category,"+
             "(select (case when gender='Female' then 'Female' else 'Male' end) from tbl_Employee_Mast AS em where ea.ID = em.ID)Gender,"+
             "(case when esm.desig_id=0 then (isNull((SELECT Amount FROM tbl_Employee_SalaryDet WHERE (EmpId=ea.ID) and (Location_id = ea.LOcation_ID) AND (Month = esm.Month) AND (Session = esm.Session) AND (TableName = 'tbl_Employee_ErnSalaryHead') AND (SalId =(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short = 'BS')))),0)) else (isNull((SELECT Amount FROM tbl_Employee_SalaryDet_MultiDesignation WHERE (EmpId=ea.ID) and (Location_id = ea.LOcation_ID) AND (Month = esm.Month) AND (Session = esm.Session) AND (TableName = 'tbl_Employee_ErnSalaryHead') AND (SalId =(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short = 'BS'))) and Designation_id=ea.Desgid),0)) end)BS,"+
             "(case when esm.desig_id=0 then (isNull((SELECT Amount FROM tbl_Employee_SalaryDet WHERE (EmpId=ea.ID) and (Location_id = ea.LOcation_ID) AND (Month = esm.Month) AND (Session = esm.Session) AND (TableName = 'tbl_Employee_ErnSalaryHead') AND (SalId =(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short = 'DA')))),0)) else (isNull((SELECT Amount FROM tbl_Employee_SalaryDet_MultiDesignation WHERE (EmpId=ea.ID) and (Location_id = ea.LOcation_ID) AND (Month = esm.Month) AND (Session = esm.Session) AND (TableName = 'tbl_Employee_ErnSalaryHead') AND (SalId =(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short = 'DA'))) and Designation_id=ea.Desgid),0)) end)DA,"+
             "(case when esm.desig_id=0 then (isNull((SELECT Amount FROM tbl_Employee_SalaryDet WHERE (EmpId=ea.ID) and (Location_id = ea.LOcation_ID) AND (Month = esm.Month) AND (Session = esm.Session) AND (TableName = 'tbl_Employee_ErnSalaryHead') AND (SalId =(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short = 'HRA')))),0)) else (isNull((SELECT Amount FROM tbl_Employee_SalaryDet_MultiDesignation WHERE (EmpId=ea.ID) and (Location_id = ea.LOcation_ID) AND (Month = esm.Month) AND (Session = esm.Session) AND (TableName = 'tbl_Employee_ErnSalaryHead') AND (SalId =(SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short = 'HRA'))) and Designation_id=ea.Desgid),0)) end)HRA,"+
             "(case when esm.desig_id=0 then (isNull((SELECT sum(Amount) FROM tbl_Employee_SalaryDet WHERE (EmpId=ea.ID) and (Location_id = ea.LOcation_ID) AND (Month = esm.Month) AND (Session = esm.Session) AND (TableName = 'tbl_Employee_ErnSalaryHead') AND (SalId in (SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short NOT IN ('BS','DA','HRA'))))),0)) else (isNull((SELECT Amount FROM tbl_Employee_SalaryDet_MultiDesignation WHERE (EmpId=ea.ID) and (Location_id = ea.LOcation_ID) AND (Month = esm.Month) AND (Session = esm.Session) AND (TableName = 'tbl_Employee_ErnSalaryHead') AND (SalId in (SELECT SlNo FROM tbl_Employee_ErnSalaryHead WHERE (SalaryHead_Short NOT IN ('BS','DA','HRA')))) and Designation_id=ea.Desgid),0)) end)OA,"+
             "0 as 'csec' FROM tbl_Employee_Attend AS ea,tbl_Employee_SalaryMast esm where esm.Emp_Id=ea.ID and esm.Company_id=ea.Company_id and esm.Location_id=ea.LOcation_ID and ea.Month='" + mm + "' and ea.Company_id=" + coid + " and ea.LOcation_ID=" + locid + " and (esm.Month = '" + mon + "') AND (esm.Session = '" + sess + "'))x group by x.designation,x.category,Company,coadd,Site,tot_emp,tot_male,tot_female,Rate";
            dtemp = clsDataAccess.RunQDTbl(qry);
            MidasReport.Form1 att = new MidasReport.Form1();
            att.Register_tamil_frmD(dtemp);

            att.Show();
        }

        private void btnForm11_Click(object sender, EventArgs e)
        {DataTable dtemp = new DataTable();
            string month = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
            string mnth = AttenDtTmPkr.Value.ToString("MMMM,yyyy");
            string mm=AttenDtTmPkr.Value.ToString("M/yyyy");
            string mon = AttenDtTmPkr.Value.ToString("MMMM");
            string sess=CmbSession.Text;
            string coid=CmbCompany.ReturnValue;
            string locid=cmbLocation.ReturnValue;
            string qry = "select (SELECT Location_Name FROM tbl_Emp_Location where Location_ID=" + locid + ")+ ' - ' +(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=" + locid + ") as 'Site','" + mnth + "' as 'mon'";
               dtemp = clsDataAccess.RunQDTbl(qry);
            MidasReport.Form1 att = new MidasReport.Form1();
            att.Register_tamil_frm11(dtemp);

            att.Show();
        }

        private void btnFormVI_Click(object sender, EventArgs e)
        {
            DataTable dtemp = new DataTable();
            string month = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
            string mm = AttenDtTmPkr.Value.ToString("M/yyyy");
            string mon = AttenDtTmPkr.Value.ToString("MMMM");
            string sess = CmbSession.Text;
            string coid = CmbCompany.ReturnValue;
            string locid = cmbLocation.ReturnValue;
            string oCondt = "";
            if (rdb_ic_emp.Checked == true)
            {
                oCondt = " where (company_id='" + coid + "') and (ID in (" + empid + ")) order by [ename]";
            }
            else if (rdb_ic_loc.Checked == true)
            {

                oCondt = " where (company_id='"+coid +"') and (Location_id='" + locid  + "')  order by [ename]";
            }
            else
            {
                oCondt = " where (company_id='" + coid + "') order by [Location],[ename]";
            }
            

            string qry = "select (SELECT Location_Name FROM tbl_Emp_Location where Location_ID=" + locid + ")+ ' - ' +(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=" + locid + ") as 'Site'";


            qry = "select ROW_NUMBER() OVER (ORDER BY em.id) AS Slno,ID," +
"(select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) from tbl_Emp_Location EL where Location_ID=em.Location_id)+' - '+(select Location_Name from tbl_Emp_Location EL where Location_ID=em.Location_id) as [Location]," +
"(CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ' ' + em.MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ' ' + em.LastName ELSE '' END) AS [ename]," +
"(CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN em.FathFN ELSE '' END)  + (CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ' ' + em.FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ' ' + em.FathLN ELSE '' END) AS [fname]  from tbl_Employee_Mast em " + oCondt;

            dtemp = clsDataAccess.RunQDTbl(qry);
            //MidasReport.Form1 att = new MidasReport.Form1();
            //att.Register_tamil_frmVI();//dtemp);

            //att.Show();
            frmVI(dtemp);
        }

        private void btnFormA_Click(object sender, EventArgs e)
        {
            DataTable dtemp = new DataTable();
            string month = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
            string mm = AttenDtTmPkr.Value.ToString("M/yyyy");
            string yy = AttenDtTmPkr.Value.ToString("yyyy");
            string mon = AttenDtTmPkr.Value.ToString("MMMM");
            string sess = CmbSession.Text;
            string coid = CmbCompany.ReturnValue;
            string locid = cmbLocation.ReturnValue;
            string qry = "select (SELECT Location_Name FROM tbl_Emp_Location where Location_ID=" + locid + ")+ ' - ' +(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=" + locid + ") as 'Site'";
            dtemp = clsDataAccess.RunQDTbl(qry);
            MidasReport.Form1 att = new MidasReport.Form1();
            att.Register_tamil_frmA(dtemp);

            att.Show();
        }
        public void frmVI(DataTable dt)
        {
            //Sl.No. வ. எண்


            DataTable dtHoliday = clsDataAccess.RunQDTbl("SELECT CONVERT (varchar(10),HolDate, 103)HolDate,HolDate as h1,HolidayName FROM tbl_Employee_Holiday where YEAR(holdate)='" + AttenDtTmPkr.Value.ToString("yyyy") + "' order by h1");
            if (dt.Rows.Count > 0)
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                int iCol = 0, irw = 0; ;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;

                iCol = dtHoliday.Rows.Count+4;
                Excel.Borders borders;
                


                excel.Cells[1, iCol / 2] = "இதை கீழ்கண்டபடி குறிப்பிட்டு பூர்த்தி செய்ய வேண்டும் ";

                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, iCol / 2], worksheet.Cells[1, iCol]);
                range.Font.Size = 8;
                range.Merge(Type.Missing);


                excel.Cells[2, 1] = "'H' for holiday allowed";
                range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, (iCol / 2) - 1]);
                range.Merge(Type.Missing);
                excel.Cells[3, 1] = "'W/D' for work on double wages";
                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, (iCol / 2) - 1]);
                range.Merge(Type.Missing);
                excel.Cells[4, 1] = "'W/H' for work with substituted holiday";
                range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, (iCol / 2) - 1]);
                range.Merge(Type.Missing);
                excel.Cells[5, 1] = "'N/E' if not eligible for the wages";
                range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, (iCol / 2) - 1]);
                range.Merge(Type.Missing);

                range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[5, (iCol/2)-1]);
                range.Font.Size = 8;
                //range.Merge(Type.Missing);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                string tm = "'எச்' விடுமுறை நாட்கள்" + Environment.NewLine +
                "'டப்ள்யூ / டி' வேலை செய்தால் இரட்டிப்பு சம்பளம்" + Environment.NewLine +
                "'டப்ள்யூ / எச்' வேலை செய்தால் மாற்று விடுமுறை" + Environment.NewLine +
                "'என் / இ' சம்பளம் பெற அறுகதையற்றவரானால்";
                excel.Cells[2, (iCol / 2)] ="'எச்' விடுமுறை நாட்கள்";
                range = worksheet.get_Range(worksheet.Cells[2, (iCol / 2)], worksheet.Cells[2, iCol]);
                range.Merge(Type.Missing);
                excel.Cells[3, (iCol / 2)] = "'டப்ள்யூ / டி' வேலை செய்தால் இரட்டிப்பு சம்பளம்";
                range = worksheet.get_Range(worksheet.Cells[3, (iCol / 2)], worksheet.Cells[3, iCol]);
                range.Merge(Type.Missing);
                excel.Cells[4, (iCol / 2)] = "'டப்ள்யூ / எச்' வேலை செய்தால் மாற்று விடுமுறை";
                range = worksheet.get_Range(worksheet.Cells[4, (iCol / 2)], worksheet.Cells[4, iCol]);
                range.Merge(Type.Missing);
                excel.Cells[5, (iCol / 2)] = "'என் / இ' சம்பளம் பெற அறுகதையற்றவரானால்";
                range = worksheet.get_Range(worksheet.Cells[5, (iCol / 2)], worksheet.Cells[5, iCol]);
                range.Merge(Type.Missing);

                range = worksheet.get_Range(worksheet.Cells[2, (iCol / 2)], worksheet.Cells[5, iCol]);
                range.Font.Size = 8;
                range.ColumnWidth = 25;
                range.RowHeight = 75;
               // range.Merge(Type.Missing);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                excel.Cells[6, 1] = "Form No. VI" +Environment.NewLine+ "[See Sub-rule(1) of Rule 7]";
                range = worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[6, iCol]);
                range.Font.Size = 12;
                range.Font.Underline = true;
                range.Merge(Type.Missing);
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


                excel.Cells[7, 1] = "Register of National & Festival Holodays for the Year "+AttenDtTmPkr.Value.ToString("yyyy");
                range = worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[7, iCol]);
                range.Merge(Type.Missing);
                range.Font.Size = 12;
                borders = range.Borders;
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;

                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                //range.RowHeight = 25.00;
                //range.Columns.AutoFit();
                //range.Rows.AutoFit();
                //cmbcompany.Text + Environment.NewLine + co_addr;
                
                int ih = 0;
                if (dtHoliday.Rows.Count > 0)
                {
                    for (ih = 0; ih < dtHoliday.Rows.Count; ih++)
                    {
                        excel.Cells[9, ih + 4] = dtHoliday.Rows[ih]["HolDate"].ToString().Trim() + Environment.NewLine + dtHoliday.Rows[ih]["HolidayName"].ToString().Trim();
                        range = worksheet.get_Range(worksheet.Cells[9, ih + 4], worksheet.Cells[9, ih + 4]);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        range.Orientation = 90;

                        excel.Cells[10, ih + 4] = ih + 1;
                        range = worksheet.get_Range(worksheet.Cells[10, ih + 4], worksheet.Cells[10, ih + 4]);
                        range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    }
                }
                excel.Cells[8, 1] = "Sl. No. வ. எண்";
                range = worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[10, 1]);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Merge(Type.Missing);
                range.Orientation = 90;
                //range.AutoFit();

                excel.Cells[8, 2] = "Name of the employee" + Environment.NewLine + "தொழிலாளியின் பெயர்";
                range = worksheet.get_Range(worksheet.Cells[8, 2], worksheet.Cells[10, 2]);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Merge(Type.Missing);
                //range.AutoFit();

                excel.Cells[8, 3] = "Ticket Number or Father’s Name";
                range = worksheet.get_Range(worksheet.Cells[8, 3], worksheet.Cells[10, 3]);
                range.WrapText = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Merge(Type.Missing);
                range.Orientation = 90;
                //range.AutoFit();

                excel.Cells[8, 4] = "Days, dates and months of the year on which National and Festival holidays are allowed under section 3 of the Tamil Nadu Industrial Establishments (National and Festival Holidays Act, 1958 (Tamil Nadu Act XXXIII of 1958).";
                range = worksheet.get_Range(worksheet.Cells[8, 4], worksheet.Cells[8, dtHoliday.Rows.Count + 3]);
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.WrapText = true;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Merge(Type.Missing);
                //range.AutoFit();

                excel.Cells[8, iCol] = "Remark    குறிப்புகள் ";
                range = worksheet.get_Range(worksheet.Cells[8, iCol], worksheet.Cells[10, iCol]);
                range.Merge(Type.Missing);
                range.Orientation = 90;

                ih = dtHoliday.Rows.Count + 5;
               

                range = worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[10, iCol]);
                range.Font.Size = 10;
                borders = range.Borders;
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;

                int st = 11, fin = 10;
                for (int idx = 0; idx < dt.Rows.Count; idx++)
                {
                    fin++;
                    excel.Cells[fin, 1] = idx + 1;//dt.Rows[idx]["Slno"].ToString();
                    excel.Cells[fin, 2] = dt.Rows[idx]["ename"].ToString();

                }
                  range = worksheet.get_Range(worksheet.Cells[st, 1], worksheet.Cells[fin, iCol]);
                borders = range.Borders;
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 1d;


                object missing = System.Reflection.Missing.Value;

                ((Excel._Worksheet)worksheet).Activate();
                worksheet.UsedRange.Select();

                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();

                
                MessageBox.Show("Export To ExcelCompleted!", "Export");
            }

        }
        private void btnFormC_Click(object sender, EventArgs e)
        { DataTable dtemp = new DataTable();
            string month = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
            string mm = AttenDtTmPkr.Value.ToString("M/yyyy");
            string mon = AttenDtTmPkr.Value.ToString("MMMM");
            string sess = CmbSession.Text;
            string coid = CmbCompany.ReturnValue;
            string locid = cmbLocation.ReturnValue;
            string qry = "select (SELECT Location_Name FROM tbl_Emp_Location where Location_ID=" + locid + ")+ ' - ' +(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=" + locid + ") as 'Site'";
            dtemp = clsDataAccess.RunQDTbl(qry);
            MidasReport.Form1 att = new MidasReport.Form1();
            att.Register_tamil_frmC(dtemp, CmbCompany.Text, AttenDtTmPkr.Value.ToString("yyyy"));

            att.Show();
        }

        private void btnFormQ_Click(object sender, EventArgs e)
        {
            DataTable dtemp = new DataTable();
            string month = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
            string mm = AttenDtTmPkr.Value.ToString("M/yyyy");
            string mon = AttenDtTmPkr.Value.ToString("MMMM");
            string sess = CmbSession.Text;
            string coid = CmbCompany.ReturnValue;
            string bon_Head="", locid = cmbLocation.ReturnValue;
            string[] bhead = "BS+DA".ToLower().Split('+');

            for (int idx = 0; idx < bhead.Length; idx++)
            {
                if (bon_Head.Trim() == "")
                {
                    bon_Head = "'" + bhead[idx].Trim() + "'";
                }
                else
                {
                    bon_Head = bon_Head + ",'" + bhead[idx].Trim() + "'";
                }

            }
            string condt1 = "select isNull((select SUM(Amount)amt from tbl_Employee_SalaryGross where (TableName='tbl_Employee_ErnSalaryHead') and (SalId in (select Slno from tbl_Employee_ErnSalaryHead where (SalaryHead_Short in (" + bon_Head + ")))) and (EmpId=ea.ID) and (Company_id=ea.Company_id) and (month ='" + AttenDtTmPkr.Value.ToString("MMMM-yyyy") + "')),0)";

            string qry = "select (SELECT Location_Name FROM tbl_Emp_Location where Location_ID=" + locid + ")+ ' - ' +(SELECT (select Client_Name from tbl_Employee_CliantMaster where Client_id = el.Cliant_ID) FROM tbl_Emp_Location el where Location_ID=" + locid + ") as 'Site',"+
"(select ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) FROM tbl_Employee_Mast AS em where em.ID=ea.ID) as ename,"+
"(select CONVERT(VARCHAR(11),DateOfJoining,103) FROM tbl_Employee_Mast AS em where em.ID=ea.ID) as doj,(select CONVERT(VARCHAR(11),DateOfBirth,103) FROM tbl_Employee_Mast AS em where em.ID=ea.ID) as dob,(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=ea.Desgid))as desg,"+
"0 as 'bmSl',(case when ea.Wday>=18 then 1.5 else 0 end ) as 'bmCl' ,0 as 'bmH',"+
"0 as 'mSl',(case when ea.Wday>=18 then 1.5 else 0 end ) as 'mCl' ,0 as 'mH',"+
"0 as 'bSl',(case when ea.Wday>=18 then 1.5 else 0 end ) as 'bCl' ,0 as 'bH',"+
"CAST(((" + condt1 + ")*(case when ea.Wday>=18 then 1.5 else 0 end )/26) AS numeric(18,0)) as actuals " +
"from tbl_Employee_Attend ea where ea.LOcation_ID=" + locid + " and ea.Month='" + mm + "' and ea.Company_id=" + coid + " ";
            dtemp = clsDataAccess.RunQDTbl(qry);
            MidasReport.Form1 att = new MidasReport.Form1();
            att.Register_tamil_frmQ(dtemp,CmbCompany.Text,AttenDtTmPkr.Value.ToString("MMMM,yyyy"));

            att.Show();
        }


    }
}
