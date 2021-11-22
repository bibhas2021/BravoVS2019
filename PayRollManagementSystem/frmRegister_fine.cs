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
    public partial class frmRegister_fine : Form //EDPComponent.FormBaseERP
    {
        public frmRegister_fine()
        {
            InitializeComponent();
        }
        string Item_Code = "";
        ArrayList arritem = new ArrayList();
        Hashtable getcode_item = new Hashtable();
        DataTable dt = new DataTable();
        int New_CID = 0, old_CID = 0;
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        string[] ar = new string[12];
        int Location_id = 0, Company_id = 0;

        private void frmUserWorkLog_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
            try
            {
                if (dateTimePicker1.Value.Month >= 4)
                {
                    try
                    { CmbSession.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    CmbSession.SelectedItem = dateTimePicker1.Value.AddYears(-1).Year + "-" + dateTimePicker1.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
           // this.HeaderText = "Fine Register";

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                CmbCompany.Text = dta.Rows[0][0].ToString();

                Company_id = Convert.ToInt32(dta.Rows[0][1].ToString());
                CmbCompany.ReturnValue = Company_id.ToString();
                CmbCompany.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                CmbCompany.PopUp();
            }
            CmbLocation.Select();
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
        }

        private void CmbCompany_DropDown_Closeup(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(CmbCompany.ReturnValue);
        }

        private void CmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("Select EL.Location_Name,EL.Location_ID from tbl_Emp_Location EL,Companywiseid_Relation cr where cr.Location_ID=EL.Location_ID and  cr.Company_ID='" + Company_id + "'");
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
            dateTimePicker1.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (CmbLocation.Text != "")
            {
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                //string qry = "";
                //           qry = "SELECT (CASE WHEN ltrim(rtrim(FirstName)) != '' THEN FirstName ELSE '' END) + (CASE WHEN ltrim(rtrim(MiddleName)) != '' THEN ' ' + MiddleName ELSE '' END) + (CASE WHEN ltrim(rtrim(LastName)) != '' THEN ' ' + LastName ELSE '' END) AS 'Name',"+
                //"(CASE WHEN ltrim(rtrim(FathFN)) != '' THEN FathFN ELSE '' END) +(CASE WHEN ltrim(rtrim(FathMN)) != '' THEN ' ' + FathMN ELSE '' END) + (CASE WHEN ltrim(rtrim(FathLN)) != '' THEN ' ' + FathLN ELSE '' END) AS 'FatherName',"+
                //" CONVERT(char(10),a.FDT, 103) AS FDT,a.FAMT,a.LocID, e.Location_id, e.Company_id, s.Amount, s.Month,m.Month,s.Session,m.NetPay,(SELECT DesignationName FROM tbl_Employee_DesignationMaster AS m  WHERE (SlNo = e.DesgId)) AS DesignationName,"+
                //"(SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = " + Location_id + ")) AS Location_Name FROM tbl_Employee_SalaryMast AS m, tbl_fine_log AS a, tbl_Employee_Mast AS e INNER JOIN tbl_Employee_SalaryDet AS s ON e.ID = s.EmpId WHERE (e.Location_id =" + Location_id + " ) AND (e.Company_id = 1) AND (s.Session = '" + CmbSession.Text + "') AND (s.TableName = 'tbl_Employee_DeductionSalayHead') AND (s.SalId = (SELECT SAL_HEAD FROM tbl_Employee_Assign_SalStructure AS ss WHERE (Location_id = " + Location_id + ") AND (chkALK = 4))) and a.LocID = " + Location_id + " and e.Location_id = " + Location_id + " and e.ID = a.eid and m.Emp_Id = a.eid and s.Month= '" + dateTimePicker1.Value.ToString("MMMM")+ "' ";
                //DataTable dt = clsDataAccess.RunQDTbl(qry);
                get_data();
                String sub = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String month = dateTimePicker1.Text;
                String session = CmbSession.Text;

                MidasReport.Form1 att = new MidasReport.Form1();
                att.f_fine(CmbCompany.Text, CO_ADD, sub, client, clientadd, month, session, dt,0);
                edpcon.Close();
                att.Show();
                CmbLocation.Focus();
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
            CmbLocation.Focus();
        }

        
        private void get_data()
        {
            DataTable dt_fine = new DataTable();
            string month=dateTimePicker1.Value.ToString("MMMM/ yyyy");
            string mon=dateTimePicker1.Value.ToString("MMMM");
            string qry = "SELECT null as sl,fl.eid as ID,' '+FirstName+' '+MiddleName+' '+LastName as Name,' '+FathFN+' '+FathMN+' '+FathLN as FatherName," +
                "(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.DesgId)  as 'DesignationName'," +
                "(select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = fl.LocID) as 'LocationName'," +
                "cast(convert(char(11), FDT, 103) as VARCHAR) as FDT,fl.FAMT," +
                "(case when fl.cause_check='1'then cause else 'no'end)as cause,"+
                "fl.wit_name,cast(convert(char(11), dof, 103) as VARCHAR) as dof," +
                "(select REASON from tbl_FineMst where fid=fl.FID)as 'reason'," +
                "(select NetPay from tbl_Employee_SalaryMast where Emp_Id=fl.eid and Location_id='" + Location_id + "' and Month='" + mon + "')as NetPay, "+
                "(select cast(convert(char(11), Date_of_Insert, 103) as VARCHAR) from tbl_Employee_SalaryMast where Emp_Id=fl.eid and Location_id='" + Location_id + "' and Month='" + mon + "')as 'frd'" +
                "from tbl_fine_log fl, tbl_Employee_Mast em where em.ID=fl.eid  and   fl.LocID='"+Location_id+"' and fl.FMONTH='"+month+"'";

             dt = clsDataAccess.RunQDTbl(qry);
             if (dt.Rows.Count == 0)
             {
                 MessageBox.Show("There is no fine record ");
             }
             else
             { }



             //DataTable dt_copy = dt_fine.Copy();

             //for (int i = 0; i < dt_fine.Rows.Count; i++)
             //{
             //    for (int j = 0; j < dt_copy.Rows.Count; j++)
             //    {
             //        if (dt_fine.Rows[i]["ID"] == dt_copy.Rows[j]["ID"])
             //        {
             //            dt_copy.Rows[j]["FAMT"] = Convert.ToDouble(dt_fine.Rows[i]["FAMT"]) +Convert.ToDouble( dt_copy.Rows[j]["FAMT"]);
             //            dt_copy.Rows.RemoveAt(j);
             //            dt_fine.Rows.RemoveAt(i);
             //        }
             //    }
                     

                // old_CID = Convert.ToInt32(dt_fine.Rows[i]["ID"]);
          }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            if (CmbLocation.Text != "")
            {
                String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
                get_data();
                String sub = clsDataAccess.GetresultS("SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = '" + Location_id + "') ");
                String client = clsDataAccess.GetresultS("select (select cm.Client_Name from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'Client' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String clientadd = clsDataAccess.GetresultS("select (select cm.Client_ADD1 from tbl_Employee_CliantMaster cm where cm.Client_id = lm.Cliant_ID) as 'ClientAdd' from tbl_Emp_Location lm where lm.Location_ID = " + Location_id + "");
                String month = dateTimePicker1.Text;
                String session = CmbSession.Text;

                MidasReport.Form1 att = new MidasReport.Form1();
                att.f_fine(CmbCompany.Text, CO_ADD, sub, client, clientadd, month, session, dt,1);
                edpcon.Close();
                //att.Show();
            }
            else
            {
                MessageBox.Show("Please select location");
                //return;
            }
            CmbLocation.Focus();
        }
             
    
    }
}
