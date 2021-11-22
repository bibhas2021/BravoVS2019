using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirstTimeNeed;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class KIT_ISSUE : Form
    {
        public KIT_ISSUE()
        {
            InitializeComponent();
        }
        EDPConnection edpcon;
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        int Co_ID = 0, Location_ID = 0;
        string Emp_ID = "0";
        string EKKT = "0", EKVal = "0";
        string fnid = "0", fnval = "0";
        DialogView dv = new DialogView();

        string date_Max, date_Min;

        DateTimePicker oDateTimePicker;

        private void KIT_ISSUE_Load(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                dta = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE " +
                " from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            }
            if (dta.Rows.Count == 1)
            {
                CmbCompany.Text = dta.Rows[0][0].ToString();

                Co_ID = Convert.ToInt32(dta.Rows[0][1].ToString());
                CmbCompany.ReturnValue = Co_ID.ToString();

            }
            else if (dta.Rows.Count > 1)
            {
                CmbCompany.PopUp();
            }


            clsValidation.GenerateYear(cmbYear, 2019, System.DateTime.Now.Year, 1);
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

            DTP_MON.Value = DateTime.Now;


            disp_Emp_Kit();
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE " +
                " from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            }
            if (dt.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Co_ID = Convert.ToInt32(CmbCompany.ReturnValue);
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("SELECT DISTINCT EL.Location_Name,EL.Location_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName FROM tbl_Employee_Mast EM INNER JOIN tbl_Emp_Location EL ON EM.Location_id = EL.Location_ID WHERE (EM.Company_id =" + Co_ID + ") ORDER BY EL.Location_ID");
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Location_ID = Convert.ToInt32(cmbLocation.ReturnValue);
        }

        private void disp_Emp_Kit()
        {
            string qry = "";




            string month = DTP_MON.Text;
            if (Co_ID > 0 && Location_ID > 0)
                qry = "select [EKID],[EKEID],[EKNAME],[EKDT],[EKMONTH],[EKKIT],[EKAMT],[EKDuration]" +
      ",[EKEMI],[EKDEDUCT],[EKDEDUCTDT],[SLNO],[CoID],[LocID],(Select KTNAME from MSTKIT where KTID=ek.EKKIT) as Kit from [tbl_Employee_KIT] ek where [CoID]='" + Co_ID + "' and [LocID]='" + Location_ID + "' and [EKMONTH]='" + month + "' order by EKID,EKDT";
            else if (Co_ID > 0)
                qry = "select [EKID],[EKEID],[EKNAME],[EKDT],[EKMONTH],[EKKIT],[EKAMT],[EKDuration]" +
      ",[EKEMI],[EKDEDUCT],[EKDEDUCTDT],[SLNO],[CoID],[LocID],(Select KTNAME from MSTKIT where KTID=ek.EKKIT) as Kit from [tbl_Employee_KIT] ek where [CoID]='" + Co_ID + "' and [EKMONTH]='" + month + "' order by EKID,EKDT";
            else
                qry = "select [EKID],[EKEID],[EKNAME],[EKDT],[EKMONTH],[EKKIT],[EKAMT],[EKDuration]" +
      ",[EKEMI],[EKDEDUCT],[EKDEDUCTDT],[SLNO],[CoID],[LocID],(Select KTNAME from MSTKIT where KTID=ek.EKKIT) as Kit from [tbl_Employee_KIT] ek where [EKMONTH]='" + month + "' order by EKID,EKDT";

            int rw_ind_dg = 0;

            this.dgv_EmpKit.Rows.Clear();
            DataTable dt = clsDataAccess.RunQDTbl(qry);
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                rw_ind_dg = dgv_EmpKit.Rows.Add();

                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKID"].Value = dt.Rows[ind]["EKID"].ToString();
                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKEID"].Value = dt.Rows[ind]["EKEID"].ToString();
                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKName"].Value = dt.Rows[ind]["EKName"].ToString();
                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKDt"].Value = dt.Rows[ind]["EKDt"];
                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKKIT"].Value = dt.Rows[ind]["Kit"];
                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKAmt"].Value = dt.Rows[ind]["EKAmt"].ToString();
                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKDeduct"].Value = dt.Rows[ind]["EKDEDUCT"].ToString();
                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKDuration"].Value = dt.Rows[ind]["EKDuration"].ToString();
                dgv_EmpKit.Rows[rw_ind_dg].Cells["EKEMI"].Value = dt.Rows[ind]["EKEMI"].ToString();
            }


        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {

            int rcNo = 0, count_E = 0;

            int EKID = rcNo;
            //Convert.ToInt32(dgv_EmpLoan.Rows[ind_dg].Cells["ELID"].Value);
            string EKEID = Emp_ID;
            //Convert.ToString(dgv_EmpLoan.Rows[ind_dg].Cells["ELEID"].Value);
            string EKNAME = this.cmbEmpKit.Text;
            //Convert.ToString(dgv_EmpLoan.Rows[ind_dg].Cells["ELNAME"].Value);
            string EKDT = dtpEmpKit.Text;
            string EKMONTH = DTP_MON.Text;
            //string EKKIT =
            double EKVAL = 0;

            EKKT = cmbKIT.ReturnValue;
            string ekqty = clsDataAccess.ReturnValue("select isNull(stk_issue,0) from purchase where (kid='" + EKKT + "')");
            if (ekqty != "0")
            {
                // ekqty = (Convert.ToDouble(ekqty) + 1).ToString();
                ekqty = "1";

            }
            else
            {
                ekqty = "1";

            }

            try
            {
                count_E = Convert.ToInt32(clsDataAccess.GetresultS("Select count (EKID) from [tbl_Employee_KIT] where ([EKEID]='" + EKEID + "') and ([EKMONTH]='" + EKMONTH + "')"));
            }
            catch
            {
                count_E = 0;
            }

            try
            {
                if (label16.Text.Trim() == "")
                {

                    rcNo = Convert.ToInt32(clsDataAccess.GetresultS("Select max(EKID) from [tbl_Employee_KIT]"));

                    rcNo = rcNo + 1;
                }
                else
                {

                    count_E = Convert.ToInt32(label16.Text);
                    bool bool_E = clsDataAccess.RunNQwithStatus("delete [tbl_Employee_KIT] where ([EKID]='" + label16.Text + "')");
                    rcNo = count_E;

                }
            }

            catch
            {
                rcNo = 0;
                rcNo = rcNo + 1;
            }



            try
            { EKVAL = Convert.ToDouble(this.txtKitVal.Text); }       //Convert.ToDouble(dgv_EmpLoan.Rows[ind_dg].Cells["ELAMT"].Value);
            catch { EKVAL = 0; }

            double EKDuration = Convert.ToDouble(txtEmpKitDuration.Text);
            //dgv_EmpLoan.Rows[ind_dg].Cells["ELDuration"].Value);
            double EKEMI = Convert.ToDouble(this.txtKitEmi.Text);
            string remarks = this.txt_remarks_Kit.Text;
            //dgv_EmpLoan.Rows[ind_dg].Cells["ELEMI"].Value);
            double EKDEDUCT = Convert.ToInt32(0);
            string EKDEDUCTDT = Convert.ToString("");
            if (Co_ID == 0)
            {
                DataTable dt = clsDataAccess.RunQDTbl("SELECT Company_id FROM tbl_Employee_Mast where (ID='" + Emp_ID + "')");
                if (dt.Rows.Count > 0)
                {
                    Co_ID = Convert.ToInt32(dt.Rows[0][0]);
                }
            }
            if (Location_ID == 0)
            {
                DataTable dt = clsDataAccess.RunQDTbl("SELECT Location_id FROM tbl_Employee_Mast where (ID='" + Emp_ID + "')");
                if (dt.Rows.Count > 0)
                {
                    Location_ID = Convert.ToInt32(dt.Rows[0][0]);
                }
            }

            bool dg_adv = clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_KIT] " +
          "([EKID],[EKEID],[EKNAME],[EKDT],[EKMONTH],[EKKIT],[EKAMT],[EKDuration],[EKEMI],[EKDEDUCT],[EKDEDUCTDT],[SLNO],[CoID],[LocID],[remarks]) VALUES ( " +
          rcNo + ",'" + EKEID + "','" + EKNAME + "',cast(convert(datetime,'" + EKDT + "',103) as datetime),'" + EKMONTH + "','" +
          EKKT + "','" + EKVAL + "','" + EKDuration + "','" + EKEMI + "','" + EKDEDUCT + "',cast(convert(datetime,'" + EKDEDUCTDT + "',103) as datetime),'0'," + Co_ID + "," + Location_ID + ",'" + remarks + "')");

        //    bool bl_st = clsDataAccess.RunQry("UPDATE purchase SET stk_issue='" + ekqty + "'," +
        //"iunit =unit,iamt='" + EKVAL + "',iRate='0',iDate=cast(convert(datetime,'" + EKDT + "',103) as datetime) where (kid='" + EKKT + "') and (pid='" + lblPid.Text + "')");
            // }
            if (dg_adv == true)
            {
                MessageBox.Show("Record Inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                disp_Emp_Kit();
                if (CmbCompany.Text == "")
                {
                    Co_ID = 0;
                }
                if (cmbLocation.Text == "")
                {
                    Location_ID = 0;
                }
                cmbEmpKit.Text = "";
                Emp_ID = "";
                cmbKIT.Text = "";
                EKKT = "";
                EKVal = "";
                txtKitVal.Text = "0";
                txtEmpKitDuration.Text = "0";
                txtKitEmi.Text = "0";
                dtpEmpKit.Value = DateTime.Now;
                txt_remarks_Kit.Text = "";
            }
            else
            {
                MessageBox.Show("Record not inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cmbEmpKit_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string qry = "";
            if (Co_ID > 0 && Location_ID > 0)
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
                    Co_ID + ") AND (Location_id = " + Location_ID + ") ORDER BY ID";
            }
            else if (Co_ID > 0)
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
               Co_ID + ") ORDER BY ID";
            }
            else
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast ORDER BY ID";
            }

            DataTable dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                cmbEmpKit.LookUpTable = dt;
                cmbEmpKit.ReturnIndex = 1;
            }

        }

        private void cmbKIT_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string qry = "";

            qry = "Select KTNAME,KTID,KTVAL from MSTKIT";

            DataTable dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                cmbKIT.LookUpTable = dt;
                cmbKIT.ReturnIndex = 1;
                //cmbKIT.ReturnIndex = 2;
            }
        }

        private void cmbKIT_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            EKKT = cmbKIT.ReturnValue.ToString();
            // cmbKIT.ReturnIndex = 2;
            EKVal = Convert.ToString(clsDataAccess.GetresultS("Select KTVAL from MSTKIT where ([KTID]='" + EKKT + "')"));
            txtKitVal.Text = EKVal;
            txtEmpKitDuration.Text = "0";
            txtKitEmi.Text = "0";
            lblPid.Text = "0";
            /*
            dv.sql_frm = "Select pid, p_date AS 'DATE', isnull((kt_nm),'UNIFORM')AS 'KIT NAME'," +
               "vname, isnull((stk_in),0)AS'STOCK IN', isnull((unit),'pcs')as 'UNIT'," +
               "isnull((amt),0)as 'AMOUNT',kid,pbill from purchase";
            dv.retno = 9;
            dv.lblCo.Text = "";
            dv.lblHead.Text = "";
            dv.btnPreview.Visible = false;
            dv.ShowDialog();

            lblPid.Text = dv.retval.ToString();*/

        }

        private void cmbEmpKit_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Emp_ID = cmbEmpKit.ReturnValue.ToString();
            txtKitECode.Text = Emp_ID;
            EKKT = "";
            cmbKIT.Text = "";
            txtKitVal.Text = "0";
            txtEmpKitDuration.Text = "0";
            txtKitEmi.Text = "0";

            alk_val(Emp_ID);

        }

        public void alk_val(string eid)
        {

            DataTable emp = clsDataAccess.RunQDTbl("select ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
         "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'Ename'," +
                //"(select isnull(SUM(EAAMT)-SUM(EADEDUCT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)< convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvOp," +
                //"(select isnull(SUM(EAAMT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvDr," +
                //"(select isnull(SUM(EADEDUCT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvCr," +

         //"(select isnull(SUM(ELAMT)-SUM(ElDEDUCT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)< convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanOp," +
                //"(select isnull(SUM(ELAMT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanDr," +
                //"(select isnull(SUM(ElDEDUCT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanCr," +

         "(select isnull(SUM(EkAMT)-SUM(EkDEDUCT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)< convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitOp," +
         "(select isnull(SUM(EkAMT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitDr," +
         "(select isnull(SUM(EkDEDUCT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)=convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitCr" +

         // "(select isnull(SUM(FAMT)-SUM(FDEDUCT),0)opf from tbl_fine_log where CoID=em.Company_id  and convert(datetime,'01/'+FMONTH,101)< convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and eid=em.id)FineOp," +
                //"(select isnull(SUM(FAMT),0)opf from tbl_fine_log where CoID=em.Company_id  and convert(datetime,'01/'+FMONTH,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and eid=em.id)FineDr," +
                //"(select isnull(SUM(FDEDUCT),0)opf from tbl_fine_log where CoID=em.Company_id  and convert(datetime,'01/'+FMONTH,101)=convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and eid=em.id)FineCr"+
            " from tbl_Employee_Mast em where (ID='" + eid + "')");



            MessageBox.Show("Balance Summary of " + emp.Rows[0]["Ename"].ToString() + Environment.NewLine +
                //"Advance Prev Balance : " + emp.Rows[0]["AdvOp"].ToString() + " | Advance taken this month : " + emp.Rows[0]["AdvDr"].ToString() + " | Advance deducted this month : " + emp.Rows[0]["AdvCr"].ToString() + Environment.NewLine +
                //"Loan Prev Balance : " + emp.Rows[0]["LoanOp"].ToString() + " | Loan taken this month : " + emp.Rows[0]["LoanDr"].ToString() + " | Loan deducted this month : " + emp.Rows[0]["LoanCr"].ToString() + Environment.NewLine +
                "Kit Prev Balance : " + emp.Rows[0]["KitOp"].ToString() + " | Kit taken this month : " + emp.Rows[0]["KitDr"].ToString() + " | Kit deducted this month : " + emp.Rows[0]["KitCr"].ToString() + Environment.NewLine, "BRAVO");
            //"Fine Prev Balance : " + emp.Rows[0]["FineOp"].ToString() + " | Fine taken this month : " + emp.Rows[0]["FineDr"].ToString() + " | Fine deducted this month : " + emp.Rows[0]["FineCr"].ToString() + Environment.NewLine, "BRAVO");
        }

        private void DTP_MON_ValueChanged(object sender, EventArgs e)
        {
            int firstDayInCurrentMonth = 1;
            int lastDayInCurrentMonth = DateTime.DaysInMonth(DTP_MON.Value.Year, DTP_MON.Value.Month);


            EKDT.DefaultCellStyle.NullValue = DTP_MON.Value.ToString("dd/MM/yyyy");
            date_Min = DTP_MON.Value.ToString("01/MMM/yyyy");
            date_Max = DTP_MON.Value.ToString(lastDayInCurrentMonth + "/MMM/yyyy");

            EKDT.DefaultCellStyle.NullValue = DTP_MON.Value.ToString("dd/MM/yyyy");

            try
            {
                dtpEmpKit.MinDate = Convert.ToDateTime(date_Min);
                dtpEmpKit.MaxDate = Convert.ToDateTime(date_Max);
            }
            catch { }

            dtpEmpKit.Value = DTP_MON.Value;
            disp_Emp_Kit();

        }    

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            label16.Text = "";
            Emp_ID = "";
            cmbEmpKit.Text = "";
            txtKitECode.Text = "";
            EKKT = "";
            cmbKIT.Text = "";
            EKVal = "";
            txtKitVal.Text = "0";
            txtEmpKitDuration.Text = "0";
            txtKitEmi.Text = "0";
            dtpEmpKit.Value = DateTime.Now;
       
        }

        private void BTNdELETE_Click(object sender, EventArgs e)
        {
            int rwind = this.dgv_EmpKit.CurrentCell.RowIndex;
            string empid = Convert.ToString(this.dgv_EmpKit.Rows[rwind].Cells["EKEID"].Value);
            string month = DTP_MON.Text;

            string ekqty = clsDataAccess.ReturnValue("select isNull(stk_issue,0) from purchase where (kid='" + EKKT + "')");
            if (ekqty != "0")
            {
                ekqty = (Convert.ToDouble(ekqty) - 1).ToString();

            }

            if (MessageBox.Show("Want to Delete?? ", "BRAVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsDataAccess.RunNQwithStatus("delete from tbl_Employee_KIT where [EKEID]='" + empid + "' and [EKMONTH]='" + month + "'");
                //bool bl_st = clsDataAccess.RunQry("UPDATE purchase SET stk_issue='" + ekqty + "' where (kid='" + EKKT + "') and (pid='" + lblPid.Text + "')");
                
                disp_Emp_Kit();
                vistaButton2_Click(sender, e);
            }
       
        }

        private void dgv_EmpKit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                label16.Text = dgv_EmpKit.Rows[e.RowIndex].Cells["EKID"].Value.ToString();
                String str = dgv_EmpKit.Rows[e.RowIndex].Cells["EKID"].ToString();
                DataTable dtKitData = clsDataAccess.RunQDTbl("select * from [tbl_Employee_KIT] where [EKID] = " + label16.Text.Trim());
                if (dtKitData.Rows.Count > 0)
                {
                    cmbEmpKit.Text = dtKitData.Rows[0]["EKNAME"].ToString();
                    Emp_ID = dtKitData.Rows[0]["EKEID"].ToString();
                    txtKitECode.Text = Emp_ID;
                    EKKT = dtKitData.Rows[0]["EKKIT"].ToString();
                    cmbKIT.Text = clsDataAccess.RunQDTbl("select [KTNAME] from [MSTKIT] where [KTID] = " + EKKT).Rows[0][0].ToString();
                    EKVal = dtKitData.Rows[0]["EKAMT"].ToString();
                    txtKitVal.Text = EKVal;
                    txtEmpKitDuration.Text = dtKitData.Rows[0]["EKDuration"].ToString();
                    txtKitEmi.Text = dtKitData.Rows[0]["EKEMI"].ToString();
                    dtpEmpKit.Value = Convert.ToDateTime(dtKitData.Rows[0]["EKDT"]);
                    txt_remarks_Kit.Text = dtKitData.Rows[0]["remarks"].ToString();

                    lblPid.Text = dtKitData.Rows[0]["SLNO"].ToString();
                }
            }
       
        }

        private void dgv_EmpKit_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string dtn = Convert.ToString(dgv_EmpKit.Rows[e.RowIndex].Cells["EKEID"].Value);
                    string kitval = clsDataAccess.GetresultS("Select KTVAL from MSTKIT where (KTID='" + (dtn) + "')");
                    dgv_EmpKit.Rows[e.RowIndex].Cells["EKAMT"].Value = Convert.ToString(kitval);
                }
            }
            catch { dgv_EmpKit.Rows[e.RowIndex].Cells["EKAMT"].Value = 0; }
            try
            {
                if (e.ColumnIndex == 7)
                {
                    double KITMONTH = 0;
                    try
                    {
                        KITMONTH = Convert.ToDouble(dgv_EmpKit.Rows[e.RowIndex].Cells["EKDuration"].Value);
                    }
                    catch { KITMONTH = 0; }

                    double KITVAL = 0;
                    try
                    {
                        KITVAL = Convert.ToDouble(dgv_EmpKit.Rows[e.RowIndex].Cells["EKAMT"].Value);
                    }
                    catch { KITVAL = 0; }

                    double KITEMI = Convert.ToDouble(KITVAL) / Convert.ToDouble(KITMONTH);
                    dgv_EmpKit.Rows[e.RowIndex].Cells["EKEMI"].Value = KITEMI;
                }
            }
            catch { dgv_EmpKit.Rows[e.RowIndex].Cells["EKEMI"].Value = 0; }
      
        }

        private void txtEmpKitDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtKitEmi.Text = Convert.ToString(Convert.ToDouble(txtKitVal.Text) / Convert.ToDouble(txtEmpKitDuration.Text));

            }
            catch
            {
                txtKitEmi.Text = "0";
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] yr = cmbYear.Text.Split('-');

            try
            {
                DTP_MON.MinDate = Convert.ToDateTime("01/April/" + yr[0].ToString().Trim());
            }
            catch { }
            try
            {
                DTP_MON.MaxDate = Convert.ToDateTime("31/March/" + yr[1].ToString().Trim());
            }
            catch { }
        }

        private void dgv_EmpKit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 3)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dgv_EmpKit.Controls.Add(oDateTimePicker);
                try
                {
                    oDateTimePicker.MinDate = Convert.ToDateTime(date_Min);
                    oDateTimePicker.MaxDate = Convert.ToDateTime(date_Max);
                }
                catch { }
                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Short;
                try
                {
                    oDateTimePicker.Text = dgv_EmpKit.CurrentCell.Value.ToString();
                }
                catch { }
                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgv_EmpKit.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;
            }
        }
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgv_EmpKit.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }
        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }  

    }
}
