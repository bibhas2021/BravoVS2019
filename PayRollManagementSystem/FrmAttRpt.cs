using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;

using Microsoft.VisualBasic;
using System.Collections;

namespace PayRollManagementSystem
{
    public partial class FrmAttRpt : Form
    {
        public FrmAttRpt()
        {
            InitializeComponent();
        }
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        int Company_id = 0,Location_id=0;
        string emp_id = "";
       
      
     

        private void BtnAttRpt_Click(object sender, EventArgs e)
        {

            int flag = 0;
            DataTable attdt = new DataTable();
            string qry = "";
            DataTable rw_head = new DataTable();
            if (chkWOdesg.Checked == true)
            {
               rw_head= clsDataAccess.RunQDTbl("SELECT 'Employee Id' as Code, 'Employee Name'as Name,'' AS edesg,'Working Days'as wd,'Extra Duty' as ed,'Proxy'as proxy,'Total' as Total");
            }
            else
            {
               rw_head = clsDataAccess.RunQDTbl("SELECT 'Employee Id' as Code, 'Employee Name'as Name,'Designation' AS edesg,'Working Days'as wd,'Extra Duty' as ed,'Proxy'as proxy,'Total' as Total");
            }
            DataTable rw_blnk = clsDataAccess.RunQDTbl("SELECT ' ' as Code, ' ' as Name,'' AS edesg,' ' AS wd,' ' as ed,' ' AS proxy,' ' AS Total");
            
            string head = "",Sub="", coadd="";
            if (chkLoc.Checked == true)
            {
               
                    DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Location_ID=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");
                    if (dtLid.Rows.Count > 0)
                    {
                        string id = dtLid.Rows[0]["Location_ID"].ToString();
                        string strClientName = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                         if (chkWOdesg.Checked == true)
                         {
                             qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
               "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name," +
            "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Location_ID=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
            "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id, Month ORDER BY ID";
                         }
                         else{
                             qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
                       "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
                            "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Location_ID=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                            "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid, Month ORDER BY ID";

                         }
                        DataTable dt = clsDataAccess.RunQDTbl(qry);
                        DataTable rw_cl = clsDataAccess.RunQDTbl("SELECT 'Location -' as Code, '" + dtLid.Rows[0]["Site"].ToString() + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");

                        DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS wd,' ' as ed ,'' AS Absent, '' AS proxy, '' AS TotaL " + Environment.NewLine + "SELECT 'Site -' as Code, '" + dtLid.Rows[0]["Site"].ToString() + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                        DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE  (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                        DataTable rw_smry_head = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Designation wise Summary' as Name,'' as wd,''as ed,''as Absent,''as proxy, ''as Total");
                        DataTable dt_smry = clsDataAccess.RunQDTbl(" select '' as Code, '' as Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=Desgid))as edesg,cast(sum(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total from tbl_Employee_Attend WHERE (LOcation_ID=" + id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') group by Desgid order by Desgid");
                        
                        attdt.Merge(rw_site);
                        attdt.Merge(rw_cl);
                        attdt.Merge(rw_head);
                        attdt.Merge(dt);
                        attdt.Merge(rw_total);
                        attdt.Merge(rw_blnk);
                        attdt.Merge(rw_smry_head);
                        attdt.Merge(dt_smry);
                        attdt.Merge(rw_total);
                        head = "Location : " + cmbcompany.Text;
                        Sub = "Attendance Report (Location wise) for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                        coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + 1 + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + 1 + "'");
                    }
                    //else
                    //{

                    //    MessageBox.Show("No Attendance found");
                    //    return;
                    //}
               

            else
             {
                 MessageBox.Show("No Attendance found");
                 return;
             }

          
            }
            else if (chkEmployee.Checked == true)
            {
                Sub = "Attendance Report (Employee wise) for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                head = cmbcompany.Text;
                DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");

                qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name,"+
          "(select Location_Name from tbl_Emp_Location where Location_ID=ea.LOcation_id) + ' - '+ (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id in (select Cliant_ID from tbl_Emp_Location where Location_ID=ea.LOcation_id )) 'Location',"+
          "(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
          "cast((days_wd)as varchar) AS wd,cast((days_ed)as varchar) AS ed, cast((Absent)as varchar) AS Absent, cast((days_ot)as varchar) AS proxy, cast((days_wd) + (days_ed)+(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (ID in (" + emp_id + ")) ORDER BY ID";
                DataTable dt = clsDataAccess.RunQDTbl(qry);
               // DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast((days_wd)as varchar) AS wd,cast((days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast((days_ot)as varchar) AS proxy, cast((days_wd) + (days_ed)+(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (ID in (" + emp_id + ")) AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') GROUP BY Company_id, Month");
              //  attdt.Merge(rw_head);
                attdt.Merge(dt);
                //attdt.Merge(rw_total);

                

            }
            else if (chkZone.Checked == true)
            {
                Sub = "Zone wise report for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + 1 + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + 1 + "'");
                if (chkWOdesg.Checked == true)
                {

                    if (rdbLocation.Checked == true)
                    {
                        DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Location_ID in (select Location_ID from tbl_Emp_Location where zid='" + Company_id + "')) AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");

                        head = "Zone : " + cmbcompany.Text;
                        for (int i = 0; i < dtLid.Rows.Count; i++)
                        {
                            string id = dtLid.Rows[i]["Location_ID"].ToString();


                            string strClientName = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                            qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name," +
                "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id, Month ORDER BY ID";
                            DataTable dt = clsDataAccess.RunQDTbl(qry);
                            DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL " + Environment.NewLine + "SELECT 'Site -' as Code, '" + dtLid.Rows[i]["Site"].ToString() + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                            attdt.Merge(rw_site);
                            attdt.Merge(rw_head);
                            attdt.Merge(dt);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);



                        }
                    }
                    else if (rdbCompany.Checked == true)
                    {
                        qry = "SELECT (select Location_Name from tbl_Emp_Location where Location_ID=ea.LOcation_id)'Location'," +
    "(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id in (select Cliant_ID from tbl_Emp_Location where Location_ID=ea.LOcation_id ))as 'Client'," +
    "(select co_name from Company where co_code=ea.Company_id) 'Company',ID as 'Employee Code'," +
    "(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'Ename' FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS 'Employee Name'," +
    "cast(SUM(days_wd)as varchar) AS 'Working Days',cast(SUM(days_ed)as varchar) AS 'Extra Duty', cast(SUM(Absent)as varchar) AS 'Absent',cast(SUM(days_ot)as varchar) AS 'Proxy', cast(SUM(days_wd) + SUM(days_ot)as varchar) AS 'Total Days' " +
    " FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and " +
    " (LOcation_ID in (select Location_ID from tbl_Emp_Location where zid='" + Company_id + "')) GROUP BY ID, Company_id,LOcation_ID, Month ORDER BY ID,LOcation_ID";
                        DataTable dt = clsDataAccess.RunQDTbl(qry);
                        attdt.Merge(dt);
                    }
                }
                else if (chkWdesg.Checked == true)
                {
                    if (rdbLocation.Checked == true)
                    {
                        DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Location_ID in (select Location_ID from tbl_Emp_Location where zid='" + Company_id + "')) AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");

                        head = "Zone : " + cmbcompany.Text;
                        for (int i = 0; i < dtLid.Rows.Count; i++)
                        {
                            string id = dtLid.Rows[i]["Location_ID"].ToString();


                            string strClientName = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                            qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
                "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid, Month ORDER BY ID";
                            DataTable dt = clsDataAccess.RunQDTbl(qry);
                            DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL " + Environment.NewLine + "SELECT 'Site -' as Code, '" + dtLid.Rows[i]["Site"].ToString() + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                            DataTable rw_smry_head = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Designation wise Summary' as Name,'' as wd,''as ed,''as Absent,''as proxy, ''as Total");
                            DataTable dt_smry = clsDataAccess.RunQDTbl(" select '' as Code, '' as Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=Desgid))as edesg,cast(sum(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total from tbl_Employee_Attend WHERE (LOcation_ID=" + id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') group by Desgid order by Desgid");

                            attdt.Merge(rw_site);
                            attdt.Merge(rw_head);
                            attdt.Merge(dt);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);
                            attdt.Merge(rw_smry_head);
                            attdt.Merge(dt_smry);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);
                        }
                    }
                    else if (rdbCompany.Checked == true)
                    {
                        qry = "SELECT (select Location_Name from tbl_Emp_Location where Location_ID=ea.LOcation_id)'Location'," +
    "(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id in (select Cliant_ID from tbl_Emp_Location where Location_ID=ea.LOcation_id ))as 'Client'," +
    "(select co_name from Company where co_code=ea.Company_id) 'Company',ID as 'Employee Code'," +
    "(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'Ename' FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS 'Employee Name'," +
    "(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
    "cast(SUM(days_wd)as varchar) AS 'Working Days',cast(SUM(days_ed)as varchar) AS 'Extra Duty', cast(SUM(Absent)as varchar) AS 'Absent',cast(SUM(days_ot)as varchar) AS 'Proxy', cast(SUM(days_wd) + SUM(days_ot)as varchar) AS 'Total Days' " +
    " FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and " +
    " (LOcation_ID in (select Location_ID from tbl_Emp_Location where zid='" + Company_id + "')) GROUP BY ID, Company_id,LOcation_ID,Desgid, Month ORDER BY ID,LOcation_ID";
                        DataTable dt = clsDataAccess.RunQDTbl(qry);
                        attdt.Merge(dt);
                    }

                }
            }
            else
            {
                Sub = "Attendance Report (Company wise)  for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'");
                coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                head = cmbcompany.Text;
                DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");
                if (chkWOdesg.Checked == true)
                {
                    if (rdbCompany.Checked == true)
                    {
                        qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name," +
               "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
               "') GROUP BY ID, Company_id, Month ORDER BY ID";
                        DataTable dt = clsDataAccess.RunQDTbl(qry);

                        DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') GROUP BY Company_id, Month");
                        attdt.Merge(rw_head);
                        attdt.Merge(dt);
                        attdt.Merge(rw_total);
                    }

                    else if (rdbLocation.Checked == true)
                    {


                        for (int i = 0; i < dtLid.Rows.Count; i++)
                        {
                            string id = dtLid.Rows[i]["Location_ID"].ToString();
                            string strClientName = clsDataAccess.GetresultS("select ' '+(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                            qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name," +
                "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid ,Month ORDER BY ID";
                            DataTable dt = clsDataAccess.RunQDTbl(qry);
                            DataTable rw_cl = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS wd,' ' as ed, '' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Location -' as Code, '" + dtLid.Rows[i]["Site"].ToString() + "' as Name,'' AS wd, '' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                            coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'");
                            coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");

                            attdt.Merge(rw_cl);
                            attdt.Merge(rw_site);
                            attdt.Merge(rw_head);
                            attdt.Merge(dt);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);

                        }

                    }
                }
                else if (chkWdesg.Checked == true)
                {
                    if (rdbCompany.Checked == true)
                    {
                        qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
               "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
               "') GROUP BY ID, Company_id,Desgid, Month ORDER BY ID";
                        DataTable dt = clsDataAccess.RunQDTbl(qry);

                        DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') GROUP BY Company_id, Month");
                        //DataTable rw_smry_head = clsDataAccess.RunQDTbl("SELECT '' as Code, '' as Name,'Summary' AS edesg,'' AS wd, '' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                        DataTable rw_smry_head = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Designation wise Summary' as Name,'' as wd,''as ed,''as Absent,''as proxy, ''as Total");
                        DataTable rw_smry = clsDataAccess.RunQDTbl(" select '' as Code, '' as Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=Desgid))as edesg,cast(sum(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total from tbl_Employee_Attend WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') group by Desgid order by Desgid");
                        //DataTable rw_smry_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') GROUP BY Company_id, Month");
                        attdt.Merge(rw_head);
                        attdt.Merge(dt);
                        attdt.Merge(rw_total);
                        attdt.Merge(rw_blnk);
                        attdt.Merge(rw_smry_head);
                        attdt.Merge(rw_smry);
                        attdt.Merge(rw_total);
                    }

                    else if (rdbLocation.Checked == true)
                    {


                        for (int i = 0; i < dtLid.Rows.Count; i++)
                        {
                            string id = dtLid.Rows[i]["Location_ID"].ToString();
                            string strClientName = clsDataAccess.GetresultS("select ' '+(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                            qry = "SELECT ID as Code,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
                "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid ,Month ORDER BY ID";
                            DataTable dt = clsDataAccess.RunQDTbl(qry);
                            DataTable rw_cl = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS edesg,'' AS wd,' ' as ed, '' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Location -' as Code, '" + dtLid.Rows[i]["Site"].ToString() + "' as Name,'' AS edesg,'' AS wd, '' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                            coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'");
                            coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                            DataTable rw_smry_head = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Designation wise Summary' as Name,'' as wd,''as ed,''as Absent,''as proxy, ''as Total");
                            DataTable dt_smry = clsDataAccess.RunQDTbl(" select '' as Code, '' as Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=Desgid))as edesg,cast(sum(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total from tbl_Employee_Attend WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") group by Desgid order by Desgid");
                            attdt.Merge(rw_cl);
                            attdt.Merge(rw_site);
                            attdt.Merge(rw_head);
                            attdt.Merge(dt);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);
                            attdt.Merge(rw_smry_head);
                            attdt.Merge(dt_smry);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);

                        }

                    }
                }


            }
            if (chkZone.Checked == true && rdbCompany.Checked == true)
            {
                DialogView dv = new DialogView();
                dv.sql_frm = qry;
                dv.retno = 0;
                dv.lblCo.Text = "Zone : " + cmbcompany.Text;
                dv.lblHead.Text = "Attendance Report (Zone wise) for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                dv.btnPreview.Visible = true;
                dv.WindowState = FormWindowState.Maximized;
                dv.ShowDialog();

            }
            else if (chkEmployee.Checked == true)
            {
                MidasReport.Form1 att = new MidasReport.Form1();
                att.atten_emp_rpt(head, Sub, this.dateTimePicker1.Value.ToString("MMMM"), coadd, this.dateTimePicker1.Value.Year, attdt, flag);
                edpcon.Close();
                att.Show();
            }
            else
            {
                MidasReport.Form1 att = new MidasReport.Form1();
                att.atten_rpt(head, Sub, this.dateTimePicker1.Value.ToString("MMMM"), coadd, this.dateTimePicker1.Value.Year, attdt, flag);
                edpcon.Close();
                att.Show();

            }
        }

        private string Day_count(string month)
        {
            string day = "";
            if (month == "JANUARY" || month == "MARCH" || month == "MAY" || month == "JULY" || month == "AUGUST" || month == "OCTOBER" || month == "DECEMBER")
                day = "31";

            if (month == "APRIL" || month == "JUNE" || month == "SEPTEMBER" || month == "NOVEMBER")
                day = "30";

            if (month == "FEBRUARY")
                day = "29";

            return day;
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {

            DataTable dt ;
            if (chkLoc.Checked == true)
            {
                //dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID from tbl_Emp_Location");
                dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID," +
           "(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client,el.Cliant_ID as ClientID  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Company_id + "'))) order by Location_Name");
               
            }
            else if (chkZone.Checked == true)
            {
                if (edpcom.CurrentLocation.Trim() != "")
                {
                    dt = clsDataAccess.RunQDTbl("Select distinct(select zone from tbl_Zone where zid=el.zid)Zone,zid from tbl_Emp_Location el where (Location_ID in (" + edpcom.CurrentLocation + "))");
                }
                else
                {
                    dt = clsDataAccess.RunQDTbl("Select distinct(select zone from tbl_Zone where zid=el.zid)Zone,zid from tbl_Emp_Location el");
                }
            }
            else
            {
                
                if (edpcom.CurrentLocation.Trim() != "")
                {

                    dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
                }
                else
                {
                    dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
                }


            }
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
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmAttRpt_Load(object sender, EventArgs e)
        {
            chkCompany.Checked = true;
            dateTimePicker1 .Value= DateTime.Now.AddMonths(-1);
            chkWOdesg.Checked = true;
            rdbCompany.Checked = true;
            DataTable dt_co = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt_co.Rows.Count == 1)
            {
                cmbcompany.Text = Convert.ToString(dt_co.Rows[0][0]);

                Company_id = Convert.ToInt32(dt_co.Rows[0][1]);
                cmbcompany.ReturnValue = Company_id.ToString();
             


            }
            else if (dt_co.Rows.Count > 1)
            {
                cmbcompany.PopUp();
            }
           

        }

        private void chkCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompany.Checked == true)
            {
                cmbcompany.Text = "";
                rdbCompany.Enabled = true;
                rdbLocation.Enabled = true;
                chkLoc.Checked = false;
                chkZone.Checked = false;
                //if (chkWOdesg.Checked == true)

                //    chkWdesg.Checked = false;
                //else if (chkWOdesg.Checked == false)
                //    chkWdesg.Checked = true;
                chkEmployeeMulti.Checked = false;

                cmbcompany.PopUp();                              
                 
            }
            
        }

        private void chkLoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLoc.Checked == true)
            {
                cmbcompany.Text = "";
                chkCompany.Checked = false;
                rdbCompany.Enabled = false;
                rdbLocation.Enabled = false;
                chkZone.Checked = false;
                cmbcompany.PopUp();  
            }
        }

        private void chkZone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkZone.Checked == true)
            {
                chkLoc.Checked = false;
                chkCompany.Checked = false;
                rdbCompany.Enabled = true;
                rdbLocation.Enabled = true;
                rdbLocation.Checked = true;
            }
        }

        private void rdbLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLocation.Checked == true)
            {
                chkEmployeeMulti.Checked = false;
                cmbcompany.PopUp();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkWOdesg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWOdesg.Checked == true)

                chkWdesg.Checked = false;
            //else if (chkWOdesg.Checked == false)
            //    chkWdesg.Checked = true;
        }

        private void chkWdesg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWdesg.Checked == true)

                chkWOdesg.Checked = false;
        }

        private void btnPrnt_Click(object sender, EventArgs e)
        {
            int flag = 1;
            DataTable attdt = new DataTable();
            string qry = "";
            DataTable rw_head = new DataTable();
            if (chkWOdesg.Checked == true)
            {
                rw_head = clsDataAccess.RunQDTbl("SELECT 'Employee Id'as Code, 'Employee Name'as Name,'' AS edesg,'Working Days'as wd,'Extra Duty' as ed,'Proxy'as proxy,'Total' as Total");
            }
            else
            {
                rw_head = clsDataAccess.RunQDTbl("SELECT 'Employee Id'as Code, 'Employee Name'as Name,'Designation' AS edesg,'Working Days'as wd,'Extra Duty' as ed,'Proxy'as proxy,'Total' as Total");

            }
            DataTable rw_blnk = clsDataAccess.RunQDTbl("SELECT ' ' as Code, ' ' as Name,'' AS edesg,' ' AS wd,' ' as ed,' ' AS proxy,' ' AS Total");

            string head = "", Sub = "", coadd = "";
            if (chkLoc.Checked == true)
            {

                DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Location_ID=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");
                if (dtLid.Rows.Count > 0)
                {
                    string id = dtLid.Rows[0]["Location_ID"].ToString();
                    string strClientName = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                    if (chkWOdesg.Checked == true)
                    {
                        qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name," +
            "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Location_ID=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
            "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id, Month ORDER BY ID";
                    }
                    else
                    {
                        qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
                                    "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Location_ID=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                                    "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid, Month ORDER BY ID";

                    }
                    DataTable dt = clsDataAccess.RunQDTbl(qry);
                    DataTable rw_cl = clsDataAccess.RunQDTbl("SELECT 'Location -' as Code, '" + dtLid.Rows[0]["Site"].ToString() + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");

                    DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS wd,' ' as ed ,'' AS Absent, '' AS proxy, '' AS TotaL " + Environment.NewLine + "SELECT 'Site -' as Code, '" + dtLid.Rows[0]["Site"].ToString() + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                    DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE  (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                    attdt.Merge(rw_site);
                    attdt.Merge(rw_cl);
                    attdt.Merge(rw_head);
                    attdt.Merge(dt);
                    attdt.Merge(rw_total);
                    attdt.Merge(rw_blnk);
                    head = "Location : " + cmbcompany.Text;
                    Sub = "Attendance Report (Location wise) for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                    coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + 1 + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + 1 + "'");
                }
                //else
                //{

                //    MessageBox.Show("No Attendance found");
                //    return;
                //}


                else
                {
                    MessageBox.Show("No Attendance found");
                    return;
                }


            }

            else if (chkZone.Checked == true)
            {
                Sub = "Zone wise report for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + 1 + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + 1 + "'");
                if (chkWOdesg.Checked == true)
                {

                    if (rdbLocation.Checked == true)
                    {
                        DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Location_ID in (select Location_ID from tbl_Emp_Location where zid='" + Company_id + "')) AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");

                        head = "Zone : " + cmbcompany.Text;
                        for (int i = 0; i < dtLid.Rows.Count; i++)
                        {
                            string id = dtLid.Rows[i]["Location_ID"].ToString();


                            string strClientName = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                            qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name," +
                "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id, Month ORDER BY ID";
                            DataTable dt = clsDataAccess.RunQDTbl(qry);
                            DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL " + Environment.NewLine + "SELECT 'Site -' as Code, '" + dtLid.Rows[i]["Site"].ToString() + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                            attdt.Merge(rw_site);
                            attdt.Merge(rw_head);
                            attdt.Merge(dt);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);



                        }
                    }
                    else if (rdbCompany.Checked == true)
                    {
                        qry = "SELECT (select Location_Name from tbl_Emp_Location where Location_ID=ea.LOcation_id)'Location'," +
    "(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id in (select Cliant_ID from tbl_Emp_Location where Location_ID=ea.LOcation_id ))as 'Client'," +
    "(select co_name from Company where co_code=ea.Company_id) 'Company',ID as 'Employee Code'," +
    "(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'Ename' FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS 'Employee Name'," +
    "cast(SUM(days_wd)as varchar) AS 'Working Days',cast(SUM(days_ed)as varchar) AS 'Extra Duty', cast(SUM(Absent)as varchar) AS 'Absent',cast(SUM(days_ot)as varchar) AS 'Proxy', cast(SUM(days_wd) + SUM(days_ot)as varchar) AS 'Total Days' " +
    " FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and " +
    " (LOcation_ID in (select Location_ID from tbl_Emp_Location where zid='" + Company_id + "')) GROUP BY ID, Company_id,LOcation_ID, Month ORDER BY ID,LOcation_ID";
                        DataTable dt = clsDataAccess.RunQDTbl(qry);
                        attdt.Merge(dt);
                    }
                }
                else if (chkWdesg.Checked == true)
                {
                    if (rdbLocation.Checked == true)
                    {
                        DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Location_ID in (select Location_ID from tbl_Emp_Location where zid='" + Company_id + "')) AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");

                        head = "Zone : " + cmbcompany.Text;
                        for (int i = 0; i < dtLid.Rows.Count; i++)
                        {
                            string id = dtLid.Rows[i]["Location_ID"].ToString();


                            string strClientName = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                            qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
                "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid, Month ORDER BY ID";
                            DataTable dt = clsDataAccess.RunQDTbl(qry);
                            DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL " + Environment.NewLine + "SELECT 'Site -' as Code, '" + dtLid.Rows[i]["Site"].ToString() + "' as Name,'' AS wd, ' ' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                            attdt.Merge(rw_site);
                            attdt.Merge(rw_head);
                            attdt.Merge(dt);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);



                        }
                    }
                    else if (rdbCompany.Checked == true)
                    {
                        qry = "SELECT (select Location_Name from tbl_Emp_Location where Location_ID=ea.LOcation_id)'Location'," +
    "(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id in (select Cliant_ID from tbl_Emp_Location where Location_ID=ea.LOcation_id ))as 'Client'," +
    "(select co_name from Company where co_code=ea.Company_id) 'Company',ID as 'Employee Code'," +
    "(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'Ename' FROM tbl_Employee_Mast em WHERE (ID = ea.ID)) AS 'Employee Name'," +
    "(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
    "cast(SUM(days_wd)as varchar) AS 'Working Days',cast(SUM(days_ed)as varchar) AS 'Extra Duty', cast(SUM(Absent)as varchar) AS 'Absent',cast(SUM(days_ot)as varchar) AS 'Proxy', cast(SUM(days_wd) + SUM(days_ot)as varchar) AS 'Total Days' " +
    " FROM tbl_Employee_Attend AS ea WHERE (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and " +
    " (LOcation_ID in (select Location_ID from tbl_Emp_Location where zid='" + Company_id + "')) GROUP BY ID, Company_id,LOcation_ID,Desgid, Month ORDER BY ID,LOcation_ID";
                        DataTable dt = clsDataAccess.RunQDTbl(qry);
                        attdt.Merge(dt);
                    }

                }
            }
            else
            {
                Sub = "Attendance Report (Company wise)  for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + 1 + "'");
                coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + 1 + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + 1 + "'");
                head = cmbcompany.Text;
                DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') Order BY Location_id");
                if (chkWOdesg.Checked == true)
                {
                    if (rdbCompany.Checked == true)
                    {
                        qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name," +
               "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
               "') GROUP BY ID, Company_id, Month ORDER BY ID";
                        DataTable dt = clsDataAccess.RunQDTbl(qry);

                        DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') GROUP BY Company_id, Month");
                        attdt.Merge(rw_head);
                        attdt.Merge(dt);
                        attdt.Merge(rw_total);
                    }

                    else if (rdbLocation.Checked == true)
                    {


                        for (int i = 0; i < dtLid.Rows.Count; i++)
                        {
                            string id = dtLid.Rows[i]["Location_ID"].ToString();
                            string strClientName = clsDataAccess.GetresultS("select ' '+(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                            qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name," +
                "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid ,Month ORDER BY ID";
                            DataTable dt = clsDataAccess.RunQDTbl(qry);
                            DataTable rw_cl = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS wd,' ' as ed, '' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Location -' as Code, '" + dtLid.Rows[i]["Site"].ToString() + "' as Name,'' AS wd, '' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                            coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'");
                            coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");

                            attdt.Merge(rw_cl);
                            attdt.Merge(rw_site);
                            attdt.Merge(rw_head);
                            attdt.Merge(dt);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);

                        }

                    }
                }
                else if (chkWdesg.Checked == true)
                {
                    if (rdbCompany.Checked == true)
                    {
                        qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
               "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
               "') GROUP BY ID, Company_id,Desgid, Month ORDER BY ID";
                        DataTable dt = clsDataAccess.RunQDTbl(qry);

                        DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') GROUP BY Company_id, Month");
                        attdt.Merge(rw_head);
                        attdt.Merge(dt);
                        attdt.Merge(rw_total);
                    }

                    else if (rdbLocation.Checked == true)
                    {


                        for (int i = 0; i < dtLid.Rows.Count; i++)
                        {
                            string id = dtLid.Rows[i]["Location_ID"].ToString();
                            string strClientName = clsDataAccess.GetresultS("select ' '+(select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientName' from tbl_Emp_Location lm where lm.Location_ID = " + id);
                            qry = "SELECT ID as Code,(SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = ea.ID)) AS Name,(Select distinct DesignationName from tbl_Employee_DesignationMaster where (SlNo=ea.Desgid))as edesg ," +
                "cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") +
                "') and (LOcation_ID=" + id + ") GROUP BY ID, Company_id,Desgid ,Month ORDER BY ID";
                            DataTable dt = clsDataAccess.RunQDTbl(qry);
                            DataTable rw_cl = clsDataAccess.RunQDTbl("SELECT 'Client -' as Code, '" + strClientName + "' as Name,'' AS edesg,'' AS wd,' ' as ed, '' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_site = clsDataAccess.RunQDTbl("SELECT 'Location -' as Code, '" + dtLid.Rows[i]["Site"].ToString() + "' as Name,'' AS edesg,'' AS wd, '' as ed,'' AS Absent, '' AS proxy, '' AS TotaL ");
                            DataTable rw_total = clsDataAccess.RunQDTbl("SELECT '' as Code, 'Total' as Name,cast(SUM(days_wd)as varchar) AS wd,cast(SUM(days_ed)as varchar) AS ed, cast(SUM(Absent)as varchar) AS Absent, cast(SUM(days_ot)as varchar) AS proxy, cast(SUM(days_wd) + SUM(days_ed)+SUM(days_ot)as varchar) AS Total FROM tbl_Employee_Attend AS ea WHERE (Company_id=" + Company_id + ") AND (Month='" + dateTimePicker1.Value.ToString("M/yyy") + "') and (LOcation_ID=" + id + ") GROUP BY Company_id,Location_ID, Month");
                            coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'");
                            coadd = clsDataAccess.GetresultS("SELECT CO_ADD FROM Company WHERE CO_CODE = '" + Company_id + "'") + " ," + clsDataAccess.GetresultS("SELECT CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");

                            attdt.Merge(rw_cl);
                            attdt.Merge(rw_site);
                            attdt.Merge(rw_head);
                            attdt.Merge(dt);
                            attdt.Merge(rw_total);
                            attdt.Merge(rw_blnk);

                        }

                    }
                }


            }
            if (chkZone.Checked == true && rdbCompany.Checked == true)
            {
                DialogView dv = new DialogView();
                dv.sql_frm = qry;
                dv.retno = 0;
                dv.lblCo.Text = "Zone : " + cmbcompany.Text;
                dv.lblHead.Text = "Attendance Report (Zone wise) for the month of " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                dv.btnPreview.Visible = true;
                dv.WindowState = FormWindowState.Maximized;
                dv.ShowDialog();

            }
            else
            {
                MidasReport.Form1 att = new MidasReport.Form1();
                att.atten_rpt(head, Sub, this.dateTimePicker1.Value.ToString("MMMM"), coadd, this.dateTimePicker1.Value.Year, attdt, flag);
                edpcon.Close();
               

            }

        }

        private void chkEmployeeMulti_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmployeeMulti.Checked == true)
            {
                btnEmployee.Enabled = true;
            }
            else
            {
                btnEmployee.Enabled = false;
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        { string qry = "",sub="";
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
            if (chkLoc.Checked == true)
            {
                sub = "Location";
                qry = ("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName, ID,Location_id FROM tbl_Employee_Mast em WHERE (Location_id = " + Company_id + ") ORDER BY ID,Location_id ");
            }
            else if (chkCompany.Checked==true)
            {
                sub = "Company";
                qry = ("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , ID,Company_id FROM tbl_Employee_Mast em WHERE (Company_id = " +
                        Company_id + ") ORDER BY ID,Company_id");

            }
            else if (chkEmployee.Checked == true)
            {
                sub = "Employee";
                qry = ("SELECT DISTINCT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
          "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmpName , ID,Company_id FROM tbl_Employee_Mast em WHERE (active = 1) ORDER BY ID,Company_id");
            }

            EDPCommon.MLOV_EDP(qry, "Tag Item", "Select " + sub, "Select " + sub, 0, "CMPN", 0);
               try
               {
                arritem.Clear();
                arritem = EDPCommon.arr_mod;

                if (arritem.Count > 0)
                {
                    getcode_item.Clear();
                    arritem = EDPCommon.arr_mod;
                    getcode_item = EDPCommon.get_code;
                    //lblproduct.Items.Clear();
                    emp_id = "";
                    //for (int i = 0; i <= (arritem.Count - 1); i++)
                    //{
                    //    //lblproduct.Items.Add(arritem[i].ToString());
                    //    Item_Code = Item_Code + getcode_item[i].ToString();
                    //    if (i != getcode_item.Count - 1)
                    //    {
                    //        Item_Code = "'" + Item_Code + "'" + "," + "'";
                    //    }
                    //}



                    for (int i = 0; i <= arritem.Count - 1; i++)
                    {
                        if (emp_id == "")
                        {
                            emp_id = "'" + getcode_item[i].ToString() + "'";
                        }
                        else
                        {
                            emp_id = emp_id + ",'" + getcode_item[i].ToString() + "'";
                        }

                    }

                    emp_id = emp_id;


                }


            }
            catch { }
        }

        private void chkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmployee.Checked == true)
            {
                cmbcompany.PopUp();
                chkEmployeeMulti.Checked = true;
                rdbLocation.Checked = true;
                chkWdesg.Checked = true;
                btnEmployee_Click(sender, e);
            }
            else
            {
                chkEmployeeMulti.Checked = false;
            }
        }
    }

}


