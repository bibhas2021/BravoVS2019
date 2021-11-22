using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frm_Register_Recovery : Form
    {
        public frm_Register_Recovery()
        {
            InitializeComponent();
        }
        int Location_id = 0, Company_id = 0;


        private void frm_Register_Recovery_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);

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

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value.Month >= 4)
                {
                    try
                    {
                        CmbSession.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year;
                    }
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

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
            {
                Company_id = Convert.ToInt32(CmbCompany.ReturnValue);               
            }


        }

        private void CmbLocation_DropDown(object sender, EventArgs e)
        {

        }

        private void CmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string month = dateTimePicker1.Value.ToString("MMMM/ yyyy");
            string mon = dateTimePicker1.Value.ToString("MMM-yyyy");

            lblLIN.Text = clsDataAccess.GetresultS("SELECT LIN FROM Branch where (ficode=1) and (gcode=" + Company_id + ") and (brnch_code=1)");

            MidasReport.Form1 f1 = new MidasReport.Form1();

            DataTable dtRec = clsDataAccess.RunQDTbl("select * from " +
 "(select EAID as 'rid',EAEID as 'eid',(select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) from tbl_Employee_Mast em where em.ID=a.EAEID)'ename','' as 'doloss',EAMONTH as 'rmon','Advance' as 'type',EAAMT as 'amt',1 as 'noinstalment','' as 'showcause','' as 'explaination', '' as 'particulars',remarks,CoID,EAMONTH as 'firstmonth',DATENAME(month,convert(NVARCHAR,DATEADD(MONTH, 0, '01/'+EAMONTH), 106)) +'/ '+ DATENAME(YEAR,convert(NVARCHAR,DATEADD(MONTH, 0, '01/'+EAMONTH), 106))  as 'lastmonth',(case when EAAMT = (select SUM(ramt) from tbl_recovery where transid=a.eaid) then (select MAX(mon) from tbl_recovery where transid=a.eaid) else '' end) as 'docomplete' from tbl_Employee_Advance a where EaAmt<>0 " +
 "UNION select ELID as 'rid',ELEID as 'eid',(select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) from tbl_Employee_Mast em where em.ID=l.ELEID)'ename', '' as 'doloss',ELMONTH as 'rmon','Loan' as 'type',ELAMT as 'amt',ELDuration as 'noinstalment', '' as 'showcause','' as 'explaination','' as 'particulars','' as 'remarks',CoID,ELMONTH as 'firstmonth',DATENAME(month,convert(NVARCHAR,(DATEADD(MONTH, ELDuration-1, '20/'+ELMONTH)), 106)) +'/ '+ DATENAME(YEAR,convert(NVARCHAR,(DATEADD(MONTH, ELDuration-1, '20/'+ELMONTH)), 106)) as 'lastmonth',(case when ELAMT=ELDEDUCT then CONVERT(varchar,ELDEDUCTDT,103) else '' end) as 'docomplete' from tbl_Employee_LOAN l " +
 "UNION select FLID as 'rid',eid,(select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) from tbl_Employee_Mast em where em.ID=f.eid)'ename',(case when (d_chk = 1) then CONVERT(varchar,dof,103) else '' end) as 'doloss',FMONTH as 'rmon','Fine' as 'type',FAMT as 'amt',FDuration as 'noinstalment',cause as 'showcause',wit_name as 'explaination',(SELECT REASON FROM tbl_FineMst where fid=f.FID) as 'particulars',remarks,CoID,FMONTH as 'firstmonth',DATENAME(month,convert(NVARCHAR,DATEADD(MONTH, FDuration-1, '01/'+FMONTH), 106)) +'/ '+ DATENAME(YEAR,convert(NVARCHAR,DATEADD(MONTH, FDuration-1, '01/'+FMONTH), 106)) as 'lastmonth',(case when fAMT=fDEDUCT then CONVERT(varchar,FDT,103) else '' end) as 'docomplete' from tbl_fine_log f) recovery " +
 "where recovery.rmon='" + month + "' and recovery.CoID=" + Company_id + " order by recovery.eid,recovery.type");
            if (dtRec.Rows.Count > 0)
            {
                f1.Recover(dtRec, CmbCompany.Text, mon, lblLIN.Text.Trim(), "");
                f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Record Present","BRAVO");
            }

        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            string month = dateTimePicker1.Value.ToString("MMMM/ yyyy");
            string mon = dateTimePicker1.Value.ToString("MMM-yyyy");

            lblLIN.Text = clsDataAccess.GetresultS("SELECT LIN FROM Branch where (ficode=1) and (gcode=" + Company_id + ") and (brnch_code=1)");

            MidasReport.Form1 f1 = new MidasReport.Form1();

            DataTable dtRec = clsDataAccess.RunQDTbl("select * from " +
 "(select EAID as 'rid',EAEID as 'eid',(select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) from tbl_Employee_Mast em where em.ID=a.EAEID)'ename','' as 'doloss',EAMONTH as 'rmon','Advance' as 'type',EAAMT as 'amt',1 as 'noinstalment','' as 'showcause','' as 'explaination', '' as 'particulars',remarks,CoID,EAMONTH as 'firstmonth',DATENAME(month,convert(NVARCHAR,DATEADD(MONTH, 0, '01/'+EAMONTH), 106)) +'/ '+ DATENAME(YEAR,convert(NVARCHAR,DATEADD(MONTH, 0, '01/'+EAMONTH), 106))  as 'lastmonth',(case when EAAMT = (select SUM(ramt) from tbl_recovery where transid=a.eaid) then (select MAX(mon) from tbl_recovery where transid=a.eaid) else '' end) as 'docomplete' from tbl_Employee_Advance a where EaAmt<>0 " +
 "UNION select ELID as 'rid',ELEID as 'eid',(select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) from tbl_Employee_Mast em where em.ID=l.ELEID)'ename', '' as 'doloss',ELMONTH as 'rmon','Loan' as 'type',ELAMT as 'amt',ELDuration as 'noinstalment', '' as 'showcause','' as 'explaination','' as 'particulars','' as 'remarks',CoID,ELMONTH as 'firstmonth',DATENAME(month,convert(NVARCHAR,(DATEADD(MONTH, ELDuration-1, '20/'+ELMONTH)), 106)) +'/ '+ DATENAME(YEAR,convert(NVARCHAR,(DATEADD(MONTH, ELDuration-1, '20/'+ELMONTH)), 106)) as 'lastmonth',(case when ELAMT=ELDEDUCT then CONVERT(varchar,ELDEDUCTDT,103) else '' end) as 'docomplete' from tbl_Employee_LOAN l " +
 "UNION select FLID as 'rid',eid,(select ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) from tbl_Employee_Mast em where em.ID=f.eid)'ename',(case when (d_chk = 1) then CONVERT(varchar,FDT,103) else '' end) as 'doloss',FMONTH as 'rmon','Fine' as 'type',FAMT as 'amt',FDuration as 'noinstalment',cause as 'showcause',wit_name as 'explaination',(SELECT REASON FROM tbl_FineMst where fid=f.FID) as 'particulars',remarks,CoID,FMONTH as 'firstmonth',DATENAME(month,convert(NVARCHAR,DATEADD(MONTH, FDuration-1, '01/'+FMONTH), 106)) +'/ '+ DATENAME(YEAR,convert(NVARCHAR,DATEADD(MONTH, FDuration-1, '01/'+FMONTH), 106)) as 'lastmonth',(case when fAMT=fDEDUCT then CONVERT(varchar,FDT,103) else '' end) as 'docomplete' from tbl_fine_log f) recovery " +
 "where recovery.rmon='" + month + "' and recovery.CoID=" + Company_id + " order by recovery.eid,recovery.type");
            if (dtRec.Rows.Count > 0)
            {
                f1.Recover(dtRec, CmbCompany.Text, mon, lblLIN.Text.Trim(), "1");
               // f1.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Record Present", "BRAVO");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
