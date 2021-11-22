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
    public partial class frmEmpAdvance : Form
    {
        public frmEmpAdvance()
        {
            InitializeComponent();
        }
        EDPConnection edpcon;
        int Co_ID = 0, Location_ID = 0;
        string Emp_ID = "0";
        string EKKT="0",EKVal="0";
        string fnid = "0", fnval = "0";
        DataTable dt = new DataTable();
        DialogView dv = new DialogView();

        private void img_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE "+
                " from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by CO_CODE");
            }
            //dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count >1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                CmbCompany.Text = dt.Rows[0]["CO_name"].ToString();
                CmbCompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                Co_ID = Convert.ToInt32(CmbCompany.ReturnValue);
                cmbLocation.Focus();
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            //Extractcmd.Visible = true;
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Co_ID = Convert.ToInt32(CmbCompany.ReturnValue);

            
            cmbLocation.Focus();
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

           // dgv_EmpAdv.Rows.Clear();
           // dgv_EmpKit.Rows.Clear();
           //// DataTable dtkit = clsDataAccess.RunQDTbl("Select KTNAME,KTID,KTVAL from MSTKIT");
          
           // DataTable dt = clsDataAccess.RunQDTbl("SELECT DISTINCT FirstName + ' ' + MiddleName + ' ' + LastName AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
           //  Co_ID + ") AND (Location_id = " + Location_ID + ") ORDER BY ID");
           // for (int ind_emp = 0; ind_emp < dt.Rows.Count; ind_emp++ )
           // {
           //     dgv_EmpAdv.Rows.Add();
           //     dgv_EmpKit.Rows.Add();

           //     dgv_EmpAdv.Rows[ind_emp].Cells["EAID"].Value = ind_emp + 1;
           //     dgv_EmpAdv.Rows[ind_emp].Cells["EAEID"].Value = dt.Rows[ind_emp]["ID"];
           //     dgv_EmpAdv.Rows[ind_emp].Cells["EAName"].Value = dt.Rows[ind_emp]["EmpName"];
           //     dgv_EmpAdv.Rows[ind_emp].Cells["EADT"].Value = DateTime.Today;
           //     dgv_EmpAdv.Rows[ind_emp].Cells["EAAmt"].Value = 0;

           //     dgv_EmpKit.Rows[ind_emp].Cells["EKID"].Value = ind_emp + 1;
           //     dgv_EmpKit.Rows[ind_emp].Cells["EKEID"].Value = dt.Rows[ind_emp]["ID"];
           //     dgv_EmpKit.Rows[ind_emp].Cells["EKName"].Value = dt.Rows[ind_emp]["EmpName"];
           //     dgv_EmpKit.Rows[ind_emp].Cells["EKDT"].Value = DateTime.Today;
           //     dgv_EmpKit.Rows[ind_emp].Cells["EKDuration"].Value = 0;
           //     //dgv_EmpKit.Rows[ind_emp].Cells["EKKIT"].Value = dtkit.Columns["KTNAME"];
                
           // }
        }

        private void BtnDisp_Bio_Click(object sender, EventArgs e)
        {
            if (txtEmpLoanEMI.Text.Trim() == "0" && txtEmpLoanEMI.Text.Trim() == "")
            {

                MessageBox.Show("Loan Emi value not found", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int rcNo = 0,count_E=0;

            int ELID = rcNo;
            //Convert.ToInt32(dgv_EmpLoan.Rows[ind_dg].Cells["ELID"].Value);
            string ELEID = Emp_ID;
            //Convert.ToString(dgv_EmpLoan.Rows[ind_dg].Cells["ELEID"].Value);
            string ELNAME = cmbLoanEmp.Text;
            //Convert.ToString(dgv_EmpLoan.Rows[ind_dg].Cells["ELNAME"].Value);
            string ELDT = dtpEmpLoanDt.Text;//(dgv_EmpLoan.Rows[ind_dg].Cells["ELDT"].Value.ToString());
            string ELMONTH = DTP_MON.Text;

            double ELAMT = 0;      //Convert.ToString(dgv_EmpLoan.Rows[ind_dg].Cells["ELKIT"].Value);


            try
            {
                count_E = Convert.ToInt32(clsDataAccess.GetresultS("Select count (ELID) from [tbl_Employee_LOAN] where ([ELEID]='" + ELEID + "') and ([ELMONTH]='" + ELMONTH + "')"));
            }
            catch
            {
                count_E = 0;
            }

            try
            {
                if (count_E == 0 || lblLoanID.Text.Trim()=="")
                {

                    rcNo = Convert.ToInt32(clsDataAccess.GetresultS("Select max(ELID) from [tbl_Employee_LOAN]"));
                    rcNo = rcNo + 1;
                }
                else
                {
                    count_E = Convert.ToInt32(clsDataAccess.GetresultS("Select ELID from [tbl_Employee_LOAN] where ([ELEID]='" + ELEID + "') and ([ELMONTH]='" + ELMONTH + "')"));
                    bool bool_E = clsDataAccess.RunNQwithStatus("delete [tbl_Employee_LOAN] where ([ELEID]='" + ELEID + "') and ([ELMONTH]='" + ELMONTH + "') and (elid="+lblLoanID.Text+")");
                    rcNo = count_E;
                }
            }

            catch { rcNo = 0;
             rcNo = rcNo + 1;
            }

           
            //for (int ind_dg = 0; ind_dg < dgv_EmpLoan.Rows.Count - 1; ind_dg++)
            //{

           
            try
            { ELAMT = Convert.ToDouble(txtEmpLoan.Text); }       //Convert.ToDouble(dgv_EmpLoan.Rows[ind_dg].Cells["ELAMT"].Value);
            catch{ ELAMT= 0;}

            double ELDuration = Convert.ToDouble(txtEmpLoanDuration.Text);
                    //dgv_EmpLoan.Rows[ind_dg].Cells["ELDuration"].Value);
            double ELEMI = Convert.ToDouble(txtEmpLoanEMI.Text);
                    //dgv_EmpLoan.Rows[ind_dg].Cells["ELEMI"].Value);
                double ELDEDUCT = Convert.ToInt32(0);
                string ELDEDUCTDT = Convert.ToString("");
                if (Co_ID == 0)
                {
                     DataTable dt = clsDataAccess.RunQDTbl("SELECT Company_id FROM tbl_Employee_Mast where (ID='"+ Emp_ID +"')");
                    if (dt.Rows.Count>0)
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

                bool dg_adv = clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_LOAN] " +
          "([ELID],[ELEID],[ELNAME],[ELDT],[ELMONTH],[ELAMT],[ELDuration],[ELEMI],[ELDEDUCT],[ELDEDUCTDT],[SLNO],[CoID],[LocID],[ELRate],[ELRtAmt]) VALUES ( " +
          rcNo + ",'" + ELEID + "','" + ELNAME + "',cast(convert(datetime,'" + ELDT + "',103) as datetime),'" + ELMONTH + "','" +
          ELAMT + "','" + ELDuration + "','" + ELEMI + "','" + ELDEDUCT + "',cast(convert(datetime,'" + ELDEDUCTDT + "',103) as datetime)," + ELID + "," + Co_ID + "," + Location_ID + ",0,0)");


           // }
                if (dg_adv==true)
                {
                    MessageBox.Show("Record Inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Co_ID = 0;
                    Location_ID = 0;
                    disp_Emp_Loan();
                    btnClear_Loan_Click(sender, e);
                    if (CmbCompany.Text == "")
                    {
                        Co_ID = 0;
                    }
                    if (cmbLocation.Text == "")
                    {
                        Location_ID = 0;
                    }
                    cmbLoanEmp.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Record not inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

        }
        public void loanDet(string month)
        {
            DataTable dtLoan = clsDataAccess.RunQDTbl("");
        }

        private void cmbLoanEmp_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Emp_ID = cmbLoanEmp.ReturnValue.ToString();
            txtLoanECode.Text = Emp_ID;

            alk_val(Emp_ID);
            txtEmpLoan.Focus();
            cmbLoanEmp.Enabled = false;
        }

        private void disp_Emp_Adv()
        {
            string qry = "";
            string month = DTP_MON.Text;
            if (Co_ID > 0 && Location_ID > 0)
                qry = "select * from [tbl_Employee_Advance] where [CoID]='" + Co_ID + "' and [LocID]='" + Location_ID + "' and [EAMONTH]='" + month + "' order by EAID,EADT";
            else if (Co_ID > 0)
                qry = "select * from [tbl_Employee_Advance] where [CoID]='" + Co_ID + "' and [EAMONTH]='" + month + "' order by EAID,EADT";
            else
                qry = "select * from [tbl_Employee_Advance] where [EAMONTH]='" + month + "' order by EAID,EADT";

            int rw_ind_dg = 0;

            this.dgv_EmpAdv.Rows.Clear();
            DataTable dt = clsDataAccess.RunQDTbl(qry);
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                rw_ind_dg = dgv_EmpAdv.Rows.Add();
                dgv_EmpAdv.Rows[0].HeaderCell.Value = rw_ind_dg + 1;
                dgv_EmpAdv.Rows[rw_ind_dg].Cells["EAID"].Value = dt.Rows[ind]["EAID"].ToString();
                dgv_EmpAdv.Rows[rw_ind_dg].Cells["EAEID"].Value = dt.Rows[ind]["EAEID"].ToString();
                dgv_EmpAdv.Rows[rw_ind_dg].Cells["EAName"].Value = dt.Rows[ind]["EAName"].ToString();
                dgv_EmpAdv.Rows[rw_ind_dg].Cells["EADt"].Value = dt.Rows[ind]["EADt"];
                dgv_EmpAdv.Rows[rw_ind_dg].Cells["EAAmt"].Value = dt.Rows[ind]["EAAmt"].ToString();
                dgv_EmpAdv.Rows[rw_ind_dg].Cells["EADeduct"].Value = dt.Rows[ind]["EADEDUCT"].ToString();
                dgv_EmpAdv.Rows[rw_ind_dg].Cells["LocName"].Value = dt.Rows[ind]["LocName"].ToString();
                //dgv_EmpAdv.Rows[rw_ind_dg].Cells["ELDuration"].Value = dt.Rows[ind]["ELDuration"].ToString();
                //dgv_EmpAdv.Rows[rw_ind_dg].Cells["ELEMI"].Value = dt.Rows[ind]["ELEMI"].ToString();
            }


        }

        private void disp_Emp_Kit()
        {
            string qry = "";

            //string strsql = "Select KTNAME,KTID,KTVAL from MSTKIT";
            //DataTable dt3 = clsDataAccess.RunQDTbl(strsql);
            //DataGridViewComboBoxColumn dgcombo6 = dgv_EmpKit.Columns["EKKIT"] as DataGridViewComboBoxColumn;
            //dgcombo6.Items.Clear();
            //try
            //{
            //    int rc = dt3.Rows.Count;
            //    if (rc > 0)
            //    {
            //        dgcombo6.DisplayMember = "KTNAME";
            //        dgcombo6.ValueMember = "KTID";
            //        dgcombo6.DataSource = dt3;
            //    }

            //}
            //catch { }


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

        private void disp_Emp_Loan()
        {
              string qry = "";
              string month = DTP_MON.Text;
            if (Co_ID >0 && Location_ID >0)
                qry = "select * from [tbl_Employee_LOAN] where [CoID]='" + Co_ID + "' and [LocID]='" + Location_ID + "' and [ELMONTH]='" + month + "' order by ELID,ELDT";
            else if (Co_ID > 0)
                qry = "select * from [tbl_Employee_LOAN] where [CoID]='" + Co_ID + "' and [ELMONTH]='" + month + "' order by ELID,ELDT";
            else
                qry = "select * from [tbl_Employee_LOAN] where [ELMONTH]='" + month + "' order by ELID,ELDT";
            
            
            int rw_ind_dg = 0;

            dgv_EmpLoan.Rows.Clear();
                DataTable dt = clsDataAccess.RunQDTbl(qry);
                for (int ind = 0; ind < dt.Rows.Count; ind++)
                {
                    rw_ind_dg = dgv_EmpLoan.Rows.Add();

                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELID"].Value=dt.Rows[ind]["ELID"].ToString();
                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELEID"].Value=dt.Rows[ind]["ELEID"].ToString();
                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELName"].Value=dt.Rows[ind]["ELName"].ToString();
                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELDt"].Value=dt.Rows[ind]["ELDt"];
                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELAmt"].Value=dt.Rows[ind]["ELAmt"].ToString();
                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELRate"].Value=dt.Rows[ind]["ELRate"].ToString();
                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELDuration"].Value=dt.Rows[ind]["ELDuration"].ToString();
                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELEMI"].Value = dt.Rows[ind]["ELEMI"].ToString();
                    dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELDeduct"].Value = dt.Rows[ind]["ELDEDUCT"].ToString();
                }
               
        }

        public void alk_val(string eid)
        {

            DataTable emp = clsDataAccess.RunQDTbl("select ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
         "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'Ename'," +
         "(select isnull(SUM(EAAMT)-SUM(EADEDUCT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)< convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvOp," +
         "(select isnull(SUM(EAAMT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvDr," +
         "(select isnull(SUM(EADEDUCT),0)OPa from tbl_Employee_Advance where Company_id=em.Company_id  and convert(datetime,'01/'+eamonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and (EAEID=em.id))AdvCr," +

         "(select isnull(SUM(ELAMT)-SUM(ElDEDUCT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)< convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanOp," +
         "(select isnull(SUM(ELAMT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanDr," +
         "(select isnull(SUM(ElDEDUCT),0)opl from tbl_Employee_LOAN where Company_id=em.Company_id  and convert(datetime,'01/'+elmonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and ElEID=em.id)LoanCr," +

         "(select isnull(SUM(EkAMT)-SUM(EkDEDUCT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)< convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitOp," +
         "(select isnull(SUM(EkAMT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitDr," +
         "(select isnull(SUM(EkDEDUCT),0)opk from tbl_Employee_KIT where Company_id=em.Company_id  and convert(datetime,'01/'+ekmonth,101)=convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and EkEID=em.id)KitCr,"+

          "(select isnull(SUM(FAMT)-SUM(FDEDUCT),0)opf from tbl_fine_log where CoID=em.Company_id  and convert(datetime,'01/'+FMONTH,101)< convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and eid=em.id)FineOp," +
         "(select isnull(SUM(FAMT),0)opf from tbl_fine_log where CoID=em.Company_id  and convert(datetime,'01/'+FMONTH,101)= convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and eid=em.id)FineDr," +
         "(select isnull(SUM(FDEDUCT),0)opf from tbl_fine_log where CoID=em.Company_id  and convert(datetime,'01/'+FMONTH,101)=convert(datetime,'01/" + DTP_MON.Value.ToString("MMMM/yyyy") + "',101) and eid=em.id)FineCr from tbl_Employee_Mast em where (ID='" + eid + "') and (active=1)");
         

         if (emp.Rows.Count>0)
                MessageBox.Show("Balance Summary of "+ emp.Rows[0]["Ename"].ToString() + Environment.NewLine + 
                "Advance Prev Balance : " + emp.Rows[0]["AdvOp"].ToString() +" | Advance taken this month : " + emp.Rows[0]["AdvDr"].ToString() + " | Advance deducted this month : " + emp.Rows[0]["AdvCr"].ToString() +Environment.NewLine +
                "Loan Prev Balance : " + emp.Rows[0]["LoanOp"].ToString() +" | Loan taken this month : " + emp.Rows[0]["LoanDr"].ToString() + " | Loan deducted this month : " + emp.Rows[0]["LoanCr"].ToString() +Environment.NewLine +
                "Kit Prev Balance : " + emp.Rows[0]["KitOp"].ToString() +" | Kit taken this month : " + emp.Rows[0]["KitDr"].ToString() + " | Kit deducted this month : " + emp.Rows[0]["KitCr"].ToString() +Environment.NewLine+
                "Fine Prev Balance : " + emp.Rows[0]["FineOp"].ToString() +" | Fine taken this month : " + emp.Rows[0]["FineDr"].ToString() + " | Fine deducted this month : " + emp.Rows[0]["FineCr"].ToString() +Environment.NewLine,"BRAVO");
        }

        private void cmbLoanEmp_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string qry = "";
            if (Co_ID >0 && Location_ID >0){
            qry = "SELECT DISTINCT FirstName + ' ' + MiddleName + ' ' + LastName AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
                Co_ID + ") AND (Location_id = " + Location_ID + ") and (active=1) ORDER BY ID";
            }
            else if (Co_ID > 0)
            {
                qry = "SELECT DISTINCT FirstName + ' ' + MiddleName + ' ' + LastName AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
               Co_ID + ") and (active=1) ORDER BY ID";
            }
            else
            {
                qry = "SELECT DISTINCT FirstName + ' ' + MiddleName + ' ' + LastName AS EmpName, ID FROM tbl_Employee_Mast where (active=1) ORDER BY ID";
            }

            DataTable dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                cmbLoanEmp.LookUpTable = dt;
                cmbLoanEmp.ReturnIndex = 1;
            }
        }

        private void frmEmpAdvance_Load(object sender, EventArgs e)
        {
            //DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            //if (dta.Rows.Count == 1)
            //{
            //    CmbCompany.Text = dta.Rows[0][0].ToString();

            //    Co_ID = Convert.ToInt32(dta.Rows[0][1].ToString());
            //    CmbCompany.ReturnValue = Co_ID.ToString();

            //}
            //else if (dta.Rows.Count > 1)
            //{
            //    CmbCompany.PopUp();
            //}

            DTP_MON.Value = DTP_MON.Value.AddMonths(-1);
            CmbCompany.PopUp();


            clsfirsttime obj_CFT = new clsfirsttime();
            bool result;
            edpcon = new EDPConnection();

            int var_mstcount = Convert.ToInt32(clsDataAccess.GetresultIT("tbl_Employee_Advance"));
            if (var_mstcount == 0)
            {
                edpcon.Open();
                result = obj_CFT.create_EmpAdv(edpcon.mycon);

               // result = obj_CFT.create_KIT_Trigger(edpcon.mycon);
                edpcon.Close();
            }
            else if (var_mstcount > 0)
            {
                if (var_mstcount < 8)
                {

                }
            }
            int mn = Convert.ToInt32(clsDataAccess.GetresultI("tbl_Employee_Advance", "LocName"));
            if (mn == 0)
            {
                string str = "ALTER TABLE tbl_Employee_Advance ADD [LocName] [nvarchar](150) NULL";
                bool rs = clsDataAccess.RunNQwithStatus(str);

                str = "update tbl_Employee_Advance SET [LocName]=''";
                rs = clsDataAccess.RunNQwithStatus(str);
            }

            var_mstcount = Convert.ToInt32(clsDataAccess.GetresultIT("tbl_Employee_Kit"));
            if (var_mstcount == 0)
            {
                edpcon.Open();
                result = obj_CFT.create_EmpKIT(edpcon.mycon);
                    // result = obj_CFT.create_KIT_Trigger(edpcon.mycon);
                edpcon.Close();
            }
            else if (var_mstcount > 0)
            {
                if (var_mstcount < 8)
                {

                }
            }

            var_mstcount = Convert.ToInt32(clsDataAccess.GetresultIT("tbl_Employee_Loan"));
            if (var_mstcount == 0)
            {
                edpcon.Open();
                result = obj_CFT.create_EmpLoan(edpcon.mycon);
                // result = obj_CFT.create_KIT_Trigger(edpcon.mycon);
                edpcon.Close();
            }
            else if (var_mstcount > 0)
            {
                if (var_mstcount < 8)
                {

                }
            }

            disp_Emp_Loan();
            disp_Emp_Adv();
            disp_Emp_Kit();
            disp_Emp_Fine();

            txtEmpLoan.Focus();
            cmbLocation.Focus();
            
        }

        private void dgv_EmpKit_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string dtn = Convert.ToString(dgv_EmpKit.Rows[e.RowIndex].Cells["EKEID"].Value);

                    string kitval = clsDataAccess.GetresultS("Select KTVAL from MSTKIT where (KTID='" + (dtn)+"')");
                    
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

        private void BtnEmp_Advance_Click(object sender, EventArgs e)
        {
            if (txtEmpAdv.Text.Trim() == "0" && txtEmpAdv.Text.Trim() == "")
            {

                MessageBox.Show("Advance value not found", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            double EADEDUCT=Convert.ToInt32(0);
                string EADEDUCTDT=Convert.ToString("");

            //    dg_adv = SubmitAdvDetails(rcNo, EAEID, EANAME, EADT, EAMONTH, EAAMT, EADEDUCT, EADEDUCTDT, EAID);
           
            int rcNo = 0, count_E = 0;

            int EAID = 0;
            try
            {
                EAID = Convert.ToInt32(clsDataAccess.GetresultS("Select Max(EAID) from [tbl_Employee_Advance]")) + 1;
            }
            catch
            {
                EAID = 1;
            }

            string EAEID = Emp_ID;
           
            string EANAME = cmbEmpAdv.Text;
           
            string EADT = dtpEmpAdv.Text;
            string EAMONTH = DTP_MON.Text;

            double EAAMT = Convert.ToDouble(txtEmpAdv.Text);
            double slno = 0;
            string remarks = "";

            if (BtnEmp_Advance.Text == "Update")
            {
                bool dg_adv_M = clsDataAccess.RunNQwithStatus("Update [tbl_Employee_Advance] Set [EADT]=cast(convert(datetime,'" + EADT + "',103) as datetime),[EAAMT]='" + EAAMT + "',[LocName]='" + cmbAdvLoc.Text + "',[remarks]='"+txt_remarks_adv.Text+"' where [EAEID]='" + Emp_ID + "' and [EAMONTH]='" + EAMONTH + "' and [EAID]='" + EAID_M + "'");

                if (dg_adv_M == true)
                {
                    MessageBox.Show("Record Updated", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    disp_Emp_Adv();
                    if (CmbCompany.Text == "")
                    {
                        Co_ID = 0;
                    }
                    if (cmbLocation.Text == "")
                    {
                        Location_ID = 0;
                    }
                    txt_remarks_adv.Text = "";

                }
                else
                {
                    MessageBox.Show("Record not Updated", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                BtnEmp_Advance.Text = "Save";
            }
            else
            {
                try
                {
                    count_E = Convert.ToInt32(clsDataAccess.GetresultS("Select count (EAID) from [tbl_Employee_Advance] ([EAEID]='" + EAEID + "') and ([EAMONTH]='" + EAMONTH + "')"));

                }
                catch
                {
                    count_E = 0;
                }
                slno = Convert.ToDouble(count_E) + 1;
                try
                {
                    if (count_E == 0)
                    {

                        rcNo = Convert.ToInt32(clsDataAccess.GetresultS("Select max(EAID) from [tbl_Employee_Advance]"));
                        rcNo = rcNo + 1;
                    }
                    else
                    {
                        count_E = Convert.ToInt32(clsDataAccess.GetresultS("Select EAID from [tbl_Employee_Advance] where ([EAEID]='" + EAEID + "') and ([EAMONTH]='" + EAMONTH + "')"));
                        bool bool_E = clsDataAccess.RunNQwithStatus("delete [tbl_Employee_Advance] where ([EAEID]='" + EAEID + "') and ([EAMONTH]='" + EAMONTH + "')");
                        rcNo = count_E;
                    }
                }

                catch
                {
                    rcNo = 0;
                    rcNo = rcNo + 1;
                }


                //for (int ind_dg = 0; ind_dg < dgv_EmpLoan.Rows.Count - 1; ind_dg++)
                //{


                try
                { EAAMT = Convert.ToDouble(txtEmpAdv.Text); }       //Convert.ToDouble(dgv_EmpLoan.Rows[ind_dg].Cells["ELAMT"].Value);
                catch { EAAMT = 0; }

                 remarks = this.txt_remarks_adv.Text;

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

                bool dg_adv = clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_Advance] " +
               "([EAID],[EAEID],[EANAME],[EADT],[EAMONTH],[EAAMT],[EADEDUCT],[EADEDUCTDT],[SLNO],[CoID],[LocID],[LocName],[remarks]) VALUES ( " +
               EAID + ",'" + EAEID + "','" + EANAME + "',cast(convert(datetime,'" + EADT + "',103) as datetime),'" + EAMONTH + "','" +
               EAAMT + "','" + EADEDUCT + "',cast(convert(datetime,'" + EADEDUCTDT + "',103) as datetime)," + slno + "," + Co_ID + "," + Location_ID + ",'" + cmbAdvLoc.Text + "','"+remarks+"')");


                // }
                if (dg_adv == true)
                {
                    MessageBox.Show("Record Inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                  
                    if (CmbCompany.Text == "")
                    {
                        Co_ID = 0;
                    }
                    if (cmbLocation.Text == "")
                    {
                        Location_ID = 0;
                    }

                    disp_Emp_Adv();
                    btnClear_adv_Click(sender, e);

                    txt_remarks_adv.Text = "";
                }
                else
                {
                    MessageBox.Show("Record not inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            BtnEmp_Advance.Text = "Save";

            cmbEmpAdv.Enabled = true;
        }

        public Boolean SubmitAdvDetails(int EAID, string EAEID, string EANAME, string EADT, string EAMONTH, double EAAMT, double EADEDUCT, string EADEDUCTDT,int slno)
        {
            bool dg_adv = clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_Advance] " +
           "([EAID],[EAEID],[EANAME],[EADT],[EAMONTH],[EAAMT],[EADEDUCT],[EADEDUCTDT],[SLNO],[CoID],[LocID]) VALUES ( " +
           EAID + ",'" + EAEID + "','" + EANAME + "',cast(convert(datetime,'" + EADT + "',103) as datetime),'" + EAMONTH + "','" +
           EAAMT + "','" + EADEDUCT + "',cast(convert(datetime,'" + EADEDUCTDT + "',103) as datetime)," + slno + ","+ Co_ID +","+ Location_ID +")");


            return dg_adv;
        }

        private void dgv_EmpLoan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    double KITMONTH = 0;
                    try
                    {
                        KITMONTH = Convert.ToDouble(dgv_EmpLoan.Rows[e.RowIndex].Cells["ELDuration"].Value);
                    }
                    catch { KITMONTH = 0; }

                    double KITVAL = 0;
                    try
                    {
                        KITVAL = Convert.ToDouble(dgv_EmpLoan.Rows[e.RowIndex].Cells["ELAMT"].Value);
                    }
                    catch { KITVAL = 0; }

                    double KITEMI = Convert.ToDouble(KITVAL) / Convert.ToDouble(KITMONTH);
                    dgv_EmpLoan.Rows[e.RowIndex].Cells["ELEMI"].Value = KITEMI;
                }
             }
            catch { dgv_EmpLoan.Rows[e.RowIndex].Cells["ELEMI"].Value = 0; }
        }

        private void BtnEmp_KIT_Click(object sender, EventArgs e)
        {
            if (txtKitEmi.Text.Trim() == "0" && txtKitEmi.Text.Trim() == "")
            {

                MessageBox.Show("Kit Emi value not found", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
                if (lbSlno.Text.Trim() == "")
                {

                    rcNo =  Convert.ToInt32(clsDataAccess.GetresultS("Select max(EKID) from [tbl_Employee_KIT]"));

                    rcNo = rcNo + 1;
                }
                else
                {

                    count_E = Convert.ToInt32(lbSlno.Text);
                    bool bool_E = clsDataAccess.RunNQwithStatus("delete [tbl_Employee_KIT] where ([EKID]='" + lbSlno.Text + "')");
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

          //  bool bl_st = clsDataAccess.RunQry("UPDATE purchase SET stk_issue='" + ekqty + "'," +
          //"iunit =unit,iamt='" + EKVAL + "',iRate='0',iDate=cast(convert(datetime,'" + EKDT + "',103) as datetime) where (kid='" + EKKT + "') and (pid='"+lblPid.Text+"')");
            // }
            if (dg_adv == true)
            {
                MessageBox.Show("Record Inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                
             
                if (CmbCompany.Text == "")
                {
                    Co_ID = 0;
                }
                if (cmbLocation.Text == "")
                {
                    Location_ID = 0;
                }

                disp_Emp_Kit();

                cmbEmpKit.Text = "";
                Emp_ID = "";
                cmbKIT.Text = "";
                txtKitECode.Text = "";
                EKKT = "";
                EKVal = "";
                txtKitVal.Text = "0";
                txtEmpKitDuration.Text = "0";
                txtKitEmi.Text = "0";
                //dtpEmpKit.Value = DateTime.Now;
                txt_remarks_Kit.Text = "";
                cmbEmpKit.Enabled = true;
                BtnEmp_KIT.Enabled = false;
                cmbKIT.Enabled = true;
                lblPid.Text = "0";
            }
            else
            {
                MessageBox.Show("Record not inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtEmpLoanDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtEmpLoanEMI.Text = Convert.ToString(Convert.ToDouble(txtEmpLoan.Text) / Convert.ToDouble(txtEmpLoanDuration.Text));
            }
            catch { txtEmpLoanEMI.Text = "0"; }
        }

        private void cmbEmpAdv_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string qry = "";
            if (Co_ID > 0 && Location_ID > 0)
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
                    Co_ID + ") AND (Location_id = " + Location_ID + ") and (active=1) ORDER BY ID";
            }
            else if (Co_ID > 0)
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
               Co_ID + ") and (active=1) ORDER BY ID";
            }
            else
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast where (active=1) ORDER BY ID";
            }

            DataTable dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                cmbEmpAdv.LookUpTable = dt;
                cmbEmpAdv.ReturnIndex = 1;
            }
        }

        private void cmbEmpKit_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string qry = "";
            if (Co_ID > 0 && Location_ID > 0)
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
                    Co_ID + ") AND (Location_id = " + Location_ID + ") and (active=1) ORDER BY ID";
            }
            else if (Co_ID > 0)
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
               Co_ID + ") and (active=1) ORDER BY ID";
            }
            else
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID,(select CO_name from company where CO_CODE= em.company_id)Company FROM tbl_Employee_Mast em where (active=1) ORDER BY ID";
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

        private void DTP_MON_ValueChanged(object sender, EventArgs e)
        {
            int daysInMonth = DateTime.DaysInMonth(DTP_MON.Value.Year, DTP_MON.Value.Month);
            
            dtpEmpAdv.MinDate = Convert.ToDateTime(DTP_MON.Value.AddMonths(-1).ToString("01/MMM/yyyy"));
            dtpEmpLoanDt.MinDate = Convert.ToDateTime(DTP_MON.Value.AddMonths(-1).ToString("01/MMM/yyyy"));
            dtpEmpKit.MinDate = Convert.ToDateTime(DTP_MON.Value.AddMonths(-1).ToString("01/MMM/yyyy"));
            dtp_fissue.MinDate = Convert.ToDateTime(DTP_MON.Value.AddMonths(-1).ToString("01/MMM/yyyy"));
            dtp_offence.MinDate = Convert.ToDateTime(DTP_MON.Value.AddMonths(-1).ToString("01/MMM/yyyy"));


            dtpEmpAdv.MaxDate = Convert.ToDateTime(DTP_MON.Value.ToString(daysInMonth.ToString("00")+"/MMM/yyyy"));
            dtpEmpLoanDt.MaxDate = Convert.ToDateTime(DTP_MON.Value.ToString(daysInMonth.ToString("00") + "/MMM/yyyy"));
            dtpEmpKit.MaxDate = Convert.ToDateTime(DTP_MON.Value.ToString(daysInMonth.ToString("00") + "/MMM/yyyy"));

            dtp_fissue.MaxDate = Convert.ToDateTime(DTP_MON.Value.ToString(daysInMonth.ToString("00") + "/MMM/yyyy"));
            dtp_offence.MaxDate = Convert.ToDateTime(DTP_MON.Value.ToString(daysInMonth.ToString("00") + "/MMM/yyyy"));

            dtpEmpAdv.Value = Convert.ToDateTime(DTP_MON.Value.ToString("01/MMM/yyyy"));
            dtpEmpLoanDt.Value = Convert.ToDateTime(DTP_MON.Value.ToString("01/MMM/yyyy"));
            dtpEmpKit.Value = Convert.ToDateTime(DTP_MON.Value.ToString("01/MMM/yyyy"));
            dtp_fissue.Value = Convert.ToDateTime(DTP_MON.Value.ToString("01/MMM/yyyy"));
            dtp_offence.Value = Convert.ToDateTime(DTP_MON.Value.ToString("01/MMM/yyyy"));

            disp_Emp_Loan();
            disp_Emp_Kit();
            disp_Emp_Adv();
            disp_Emp_Fine();
        }
        private void disp_Emp_Fine()
        {
            string qry = "";
            //  FLID, eid, FID, FDT, FMONTH, FAMT, FDuration, FEMI, FDEDUCT, CoID, LocID FROM         tbl_fine_log


            string month = DTP_MON.Text;
            if (Co_ID > 0 && Location_ID > 0)
                qry = "Select FLID,eid,FID,FDT,FMONTH,FAMT,FDuration,FEMI,FDEDUCT,CoID,LocID,(SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName FROM tbl_Employee_Mast WHERE ID=fl.eid)as EName,(Select REASON from tbl_FineMst where fid=fl.FID)fine from [tbl_fine_log] fl where ([CoID]='" + Co_ID + "') and ([LocID]='" + Location_ID + "') and ([FMONTH]='" + month + "') order by FLID,FDT";
            else if (Co_ID > 0)
                qry = "Select FLID,eid,FID,FDT,FMONTH,FAMT,FDuration,FEMI,FDEDUCT,CoID,LocID,(SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName FROM tbl_Employee_Mast WHERE ID=fl.eid)as EName,(Select REASON from tbl_FineMst where fid=fl.FID)fine from [tbl_fine_log] fl where ([CoID]='" + Co_ID + "') and ([FMONTH]='" + month + "') order by FLID,FDT";
            else
                qry = "Select FLID,eid,FID,FDT,FMONTH,FAMT,FDuration,FEMI,FDEDUCT,CoID,LocID,(SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName FROM tbl_Employee_Mast WHERE ID=fl.eid)as EName,(Select REASON from tbl_FineMst where fid=fl.FID)fine from [tbl_fine_log] fl where ([FMONTH]='" + month + "') order by FLID,FDT";

            int rw_ind_dg = 0;

            this.dgvFine.Rows.Clear();
            DataTable dt = clsDataAccess.RunQDTbl(qry);
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                rw_ind_dg = dgvFine.Rows.Add();
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_fslno"].Value = dt.Rows[ind]["FLID"].ToString();
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_fid"].Value = dt.Rows[ind]["FID"].ToString();
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_feid"].Value = dt.Rows[ind]["eid"].ToString();
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_fename"].Value = dt.Rows[ind]["EName"].ToString();
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_fidate"].Value = dt.Rows[ind]["FDT"];
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_fcode"].Value = dt.Rows[ind]["fine"];
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_fval"].Value = dt.Rows[ind]["FAMT"].ToString();
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_fdeduct"].Value = dt.Rows[ind]["FDEDUCT"].ToString();
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_fdur"].Value = dt.Rows[ind]["FDuration"].ToString();
                dgvFine.Rows[rw_ind_dg].Cells["dgCol_femi"].Value = dt.Rows[ind]["FEMI"].ToString();
            }


        }

        private void dgv_EmpLoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Int32 rw_ind_dg = e.RowIndex;
            try
            {
                if (Convert.ToDouble(dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELAmt"].Value)>0)
                {
                Emp_ID = dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELEID"].Value.ToString();

                   txtLoanECode.Text = Emp_ID;

                   lblLoanID.Text = dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELID"].Value.ToString();
                cmbLoanEmp.Text = dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELName"].Value.ToString();
                txtEmpLoan.Text = dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELAmt"].Value.ToString();
                txtEmpLoanDuration.Text = dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELDuration"].Value.ToString();

                txtEmpLoanEMI.Text = dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELEMI"].Value.ToString();
                dtpEmpLoanDt.Text = dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELDt"].Value.ToString();
                txtLoanIntPer.Text = "0";//dgv_EmpLoan.Rows[rw_ind_dg].Cells["ELRate"].Value

                cmbLoanEmp.Enabled = false;
                 }
            else
            {
                MessageBox.Show("Adjustment entries can be edited from Salary Allotement");
            }
            }
            catch {
                MessageBox.Show("Select proper row","BRAVO",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void cmbEmpAdv_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Emp_ID = cmbEmpAdv.ReturnValue.ToString();
            txtAdvECode.Text = Emp_ID;

            alk_val(Emp_ID);
            txtEmpAdv.Focus();
        }

        private void cmbEmpKit_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Emp_ID = cmbEmpKit.ReturnValue.ToString();
            txtKitECode.Text = Emp_ID;
            EKKT = "";
            cmbKIT.Text = "";
            txtKitVal.Text = "0";
            txtEmpKitDuration.Text = "1";
            txtKitEmi.Text = "1";

            alk_val(Emp_ID);
            cmbKIT.Focus();

            cmbEmpKit.Enabled = false;
        }

        private void cmbKIT_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            EKKT = cmbKIT.ReturnValue.ToString();
            txtKitEmi.Text = "0";
            txtEmpKitDuration.Text = "1";
           // cmbKIT.ReturnIndex = 2;
            EKVal = Convert.ToString(clsDataAccess.GetresultS("Select KTVAL from MSTKIT where ([KTID]='" + EKKT + "')"));
            txtKitVal.Text = EKVal;
            BtnEmp_KIT.Enabled = true;

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
            
            txtKitEmi.Focus();
            
        }

        private void txtEmpDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtKitEmi.Text = Convert.ToString(Convert.ToDouble(txtKitVal.Text) / Convert.ToDouble(txtEmpKitDuration.Text));

            }
            catch{
                txtKitEmi.Text = "0";
            }
        }

        private void btnAdvDelete_Click(object sender, EventArgs e)
        {
            int rwind = dgv_EmpAdv.CurrentCell.RowIndex;
            string empid =Convert.ToString( dgv_EmpAdv.Rows[rwind].Cells["EAEID"].Value);
            string month= DTP_MON.Text;
            if (MessageBox.Show("Want to Delete?? ","BRAVO",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes) 
            {
                 clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Advance where [EAEID]='"+ empid +"' and [EAMONTH]='" + month + "'");
                 disp_Emp_Adv();
                 btnClear_adv_Click(sender,e);
            }

        }

        private void btnKitDelete_Click(object sender, EventArgs e)
        {
            int rwind = this.dgv_EmpKit.CurrentCell.RowIndex ;
            string empid = Convert.ToString(this.dgv_EmpKit.Rows[rwind].Cells["EKEID"].Value);
            EKKT = cmbEmpKit.ReturnValue;
            string ekqty = clsDataAccess.ReturnValue("select isNull(stk_issue,0) from purchase where (kid='" + EKKT + "')");
            if (ekqty != "0")
            {
                ekqty = (Convert.ToDouble(ekqty) - 1).ToString();

            }
            string month = DTP_MON.Text;
            if (MessageBox.Show("Want to Delete?? ", "BRAVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsDataAccess.RunNQwithStatus("delete from tbl_Employee_KIT where [EKEID]='" + empid + "' and [EKMONTH]='" + month + "'");

                //bool bl_st = clsDataAccess.RunQry("UPDATE purchase SET stk_issue='" + ekqty + "' where (kid='" + EKKT + "') and (pid='" + lblPid.Text + "')");
                disp_Emp_Kit();
                btnClear_Click(sender, e);
            }
        }

        private void btnLoanDelete_Click(object sender, EventArgs e)
        {
            int rwind = this.dgv_EmpLoan.CurrentCell.RowIndex;
            string empid = Convert.ToString(this.dgv_EmpLoan.Rows[rwind].Cells["ELEID"].Value);
            string month = DTP_MON.Text;
            if (MessageBox.Show("Want to Delete?? ", "BRAVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Loan where [ELEID]='" + empid + "' and [ELMONTH]='" + month + "'");
                disp_Emp_Loan();
                btnClear_Loan_Click(sender, e);
            }
        }

        private void cmbAdvLoc_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("SELECT DISTINCT EL.Location_Name,EL.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName FROM tbl_Employee_Mast EM INNER JOIN tbl_Emp_Location EL ON EM.Location_id = EL.Location_ID ORDER BY EL.Location_ID");
            if (dt.Rows.Count > 0)
            {
                cmbAdvLoc.LookUpTable = dt;
                cmbAdvLoc.ReturnIndex = 1;
            }
        }
        String EAID_M="0";
        private void dgv_EmpAdv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rwind = dgv_EmpAdv.CurrentCell.RowIndex;
            if (Convert.ToDouble(dgv_EmpAdv.Rows[rwind].Cells["EAAmt"].Value) > 0)
            {
                EAID_M = Convert.ToString(dgv_EmpAdv.Rows[rwind].Cells["EAID"].Value);
                Emp_ID = Convert.ToString(dgv_EmpAdv.Rows[rwind].Cells["EAEID"].Value);
                txtAdvECode.Text = Emp_ID;
                cmbEmpAdv.Text = Convert.ToString(dgv_EmpAdv.Rows[rwind].Cells["EAName"].Value);
                cmbAdvLoc.Text = Convert.ToString(dgv_EmpAdv.Rows[rwind].Cells["LocName"].Value);
                txtEmpAdv.Text = Convert.ToString(dgv_EmpAdv.Rows[rwind].Cells["EAAmt"].Value);
                dtpEmpAdv.Text = Convert.ToString(dgv_EmpAdv.Rows[rwind].Cells["EADT"].Value);
                txt_remarks_adv.Text = clsDataAccess.GetresultS("select remarks from tbl_Employee_Advance where EAID='" + EAID_M + "'");
                BtnEmp_Advance.Text = "Update";
                cmbEmpAdv.Enabled = false;
            }
            else
            {
                MessageBox.Show("Adjustment entries can be edited from Salary Allotement");
            }
        }

        private void dgv_EmpKit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lbSlno.Text = dgv_EmpKit.Rows[e.RowIndex].Cells["EKID"].Value.ToString();
                String str = dgv_EmpKit.Rows[e.RowIndex].Cells["EKID"].ToString();
                DataTable dtKitData = clsDataAccess.RunQDTbl("select * from [tbl_Employee_KIT] where [EKID] = " + lbSlno.Text.Trim());
                if (dtKitData.Rows.Count > 0)
                {
                    cmbEmpKit.Text = dtKitData.Rows[0]["EKNAME"].ToString();
                    Emp_ID = dtKitData.Rows[0]["EKEID"].ToString();
                    txtKitECode.Text= Emp_ID;
                    EKKT = dtKitData.Rows[0]["EKKIT"].ToString();
                    cmbKIT.Text = clsDataAccess.RunQDTbl("select [KTNAME] from [MSTKIT] where [KTID] = " + EKKT).Rows[0][0].ToString();
                    EKVal = dtKitData.Rows[0]["EKAMT"].ToString();
                    txtKitVal.Text = EKVal;
                    txtEmpKitDuration.Text = dtKitData.Rows[0]["EKDuration"].ToString();
                    txtKitEmi.Text = dtKitData.Rows[0]["EKEMI"].ToString();
                    dtpEmpKit.Value = Convert.ToDateTime(dtKitData.Rows[0]["EKDT"]);
                    txt_remarks_Kit.Text = dtKitData.Rows[0]["remarks"].ToString();
                    lblPid.Text = dtKitData.Rows[0]["SLNO"].ToString();
                    BtnEmp_KIT.Enabled = true;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbSlno.Text = "";
            Emp_ID = "";
            cmbEmpKit.Text = "";
            txtKitECode.Text = "";
            EKKT = "";
            cmbKIT.Text = "";
           
            EKVal = "";

            cmbKIT.Enabled = true;
            BtnEmp_KIT.Enabled = false;
            cmbEmpKit.Enabled = true;
            txtKitVal.Text = "0";
            txtEmpKitDuration.Text = "0";
            txtKitEmi.Text = "0";
           // dtpEmpKit.Value = DateTime.Now;
            lblPid.Text = "0";
        }

        private void txt_fename_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Emp_ID = cmb_fine_name.ReturnValue.ToString();
            txt_Fine_ECode.Text = Emp_ID;
            cmb_fine_Reason.Text = "";
            txt_fine_val.Text = "0";
            txt_fine_dur.Text = "1";
            txt_fine_emi.Text = "0";

            alk_val(Emp_ID);
            cmb_fine_Reason.Focus();
        }

        private void txt_fename_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string qry = "";
            if (Co_ID > 0 && Location_ID > 0)
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
                    Co_ID + ") AND (Location_id = " + Location_ID + ") and (active=1) ORDER BY ID";
            }
            else if (Co_ID > 0)
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast WHERE (Company_id = " +
               Co_ID + ") and (active=1) ORDER BY ID";
            }
            else
            {
                qry = "SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName, ID FROM tbl_Employee_Mast where (active=1) ORDER BY ID";
            }

            DataTable dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                cmb_fine_name.LookUpTable = dt;
                cmb_fine_name.ReturnIndex = 1;
                

            }
        }

        private void btnFine_save_Click(object sender, EventArgs e)
        {


            if (txt_fine_emi.Text.Trim() == "0" && txt_fine_emi.Text.Trim() == "")
            
            {

                MessageBox.Show("Fine value not found","Bravo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
          int FLID=0,  FID=0, CoID=0, LocID=0;
          string FDT = "", FMONTH = "", FDuration = "0", FEMI = "0", FDEDUCT = "0", FAMT = "0", remarks="",cause="",w_name="",dof="";
          bool c_check = false, cc_chk = false;

            
            try
            {
                if (lblfineid.Text.Trim() == "")
                {

                    FLID = Convert.ToInt32(clsDataAccess.GetresultS("Select isnull(max(FLID),0)+1 from [tbl_fine_log]"));

                    //FID = rcNo + 1;
                }
                else
                {

                    FLID = Convert.ToInt32(lblfineid.Text);
                    bool bool_E = clsDataAccess.RunNQwithStatus("delete from [tbl_fine_log] where ([FLID]='" + lblfineid.Text + "')");
                    //rcNo = count_E;

                }
            }

            catch
            {
                FLID = 0;
                FLID = FLID + 1;
            }



            try
            { FAMT = (this.txt_fine_val.Text); }       //Convert.ToDouble(dgv_EmpLoan.Rows[ind_dg].Cells["ELAMT"].Value);
            catch { FAMT = "0"; }

             FDuration = (txt_fine_dur.Text);

             FEMI =(this.txt_fine_emi.Text);

             if (Co_ID == 0)
             {
                 DataTable dt = clsDataAccess.RunQDTbl("SELECT Company_id FROM tbl_Employee_Mast where (ID='" + Emp_ID + "')");
                 if (dt.Rows.Count > 0)
                 {
                     CoID = Convert.ToInt32(dt.Rows[0][0]);
                 }
             }
             else
             {
                 CoID = Co_ID;
             }
             if (Location_ID == 0)
             {
                 DataTable dt = clsDataAccess.RunQDTbl("SELECT Location_id FROM tbl_Employee_Mast where (ID='" + Emp_ID + "')");
                 if (dt.Rows.Count > 0)
                 {
                     LocID = Convert.ToInt32(dt.Rows[0][0]);
                 }
             }
             else
             {
                 LocID = Location_ID;
             }
            // FID = fnid;

            FDT = dtp_fissue.Value.ToString("dd/MMM/yyyy");
            FMONTH = DTP_MON.Value.ToString("MMMM/ yyyy");
            FDEDUCT = "0";
            remarks = this.txt_remarks_fine.Text;
            if (checkBox1.Checked == true)
            {
                c_check = checkBox1.Checked;
                
            }
            else
            { c_check = false; }
            if (checkBox2.Checked == true)
            {
                cc_chk = checkBox2.Checked;
            }
            else
            { cc_chk = false; }
            cause = textBox1.Text;
            w_name = textBox2.Text;
            dof = dtp_offence.Value.ToString("dd/MMM/yyyy");
            bool dg_adv = clsDataAccess.RunNQwithStatus("INSERT INTO tbl_fine_log(FLID,eid,FID,FDT,FMONTH,FAMT,FDuration,FEMI,FDEDUCT,CoID,LocID,remarks,cause_check,cause,wit_name,dof,d_chk)VALUES ('"+
            FLID + "','" + Emp_ID + "','" + fnid + "',cast(convert(datetime,'" + FDT + "',103) as datetime),'" + FMONTH + "','" + FAMT + "','" + FDuration +
            "','" + FEMI + "','" + FDEDUCT + "','" + CoID + "','" + LocID + "','" + txt_remarks_fine.Text + "','" + c_check + "','" + cause + "','" + w_name + "',cast(convert(datetime,'" + dof + "',103) as datetime),'"+cc_chk+"')");


            
            if (dg_adv == true)
            {
                MessageBox.Show("Record Inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                if (CmbCompany.Text == "")
                {
                    Co_ID = 0;
                }
                if (cmbLocation.Text == "")
                {
                    Location_ID = 0;
                }

                disp_Emp_Fine();
                cmb_fine_name.Text = "";
                cmb_fine_Reason.Text = "";
                Emp_ID = "";
                txt_fine_emi.Text = "0";
                txt_fine_val.Text = "0";
                txt_fine_dur.Text = "0";
                txt_Fine_ECode.Text = "";
                txt_remarks_fine.Text = "";
                checkBox1.Checked = false;
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox2.Checked = false;

            }
            else
            {
                MessageBox.Show("Record not inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txt_frcode_DropDown(object sender, EventArgs e)
        {
            string qry = "";

            qry = "Select REASON,CODE,val,fid from tbl_FineMst";

            DataTable dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                cmb_fine_Reason.LookUpTable = dt;
                cmb_fine_Reason.ReturnIndex = 3;
                
            }
        }
        
        private void txt_frcode_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
           fnid = cmb_fine_Reason.ReturnValue.ToString();
            // cmbKIT.ReturnIndex = 2;
           try
           {
               fnval = Convert.ToString(clsDataAccess.GetresultS("Select val from tbl_FineMst where ([fid]='" + fnid + "')"));
           }
           catch
           {
               fnval = "0";
           }
           txt_fine_dur.Text = "1";
            txt_fine_emi.Text = "0";
            txt_fine_val.Text = fnval;
          
            
            txt_fine_dur.Focus();
            
        }

        private void txt_fine_dur_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_fine_emi.Text = Convert.ToString(Convert.ToDouble(txt_fine_val.Text) / Convert.ToDouble(txt_fine_dur.Text));

            }
            catch
            {
                txtKitEmi.Text = "0";
            }
        }

        private void btnFine_clear_Click(object sender, EventArgs e)
        {
            lblfineid.Text = "";
            Emp_ID = "";
            cmb_fine_name.Text = "";
            txt_Fine_ECode.Text = "";
            cmb_fine_Reason.Text = "";
            txt_fine_val.Text = "0";
            txt_fine_dur.Text = "0";
            txt_fine_emi.Text = "0";
            //dtp_fissue.Value = DateTime.Now;
            textBox1.Text = "";
            textBox2.Text = "";
            //dtp_offence.Value = DateAndTime.Now;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void btnFine_delete_Click(object sender, EventArgs e)
        {
            int rwind = this.dgvFine.CurrentCell.RowIndex;
            string empid = Convert.ToString(this.dgvFine.Rows[rwind].Cells["dgCol_feid"].Value);
            string fid = Convert.ToString(this.dgvFine.Rows[rwind].Cells["dgCol_fslno"].Value);
            string month = DTP_MON.Value.ToString("MMMM/ yyyy");
            if (MessageBox.Show("Want to Delete?? ", "BRAVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsDataAccess.RunNQwithStatus("delete from tbl_fine_log where (FLID='"+ fid +"') and ([eid]='" + empid + "') and ([FMONTH]='" + month + "')");
                btnFine_clear_Click(sender, e);
                disp_Emp_Fine();
            }
        }

        private void btnClear_adv_Click(object sender, EventArgs e)
        {
            EAID_M = "";
            Emp_ID = "";
            txtAdvECode.Text ="";
            cmbEmpAdv.Text = "";
            cmbAdvLoc.Text = "";
            txtEmpAdv.Text = "0";
            txt_remarks_adv.Text = "";
            cmbEmpAdv.Enabled = true;
            //dtpEmpAdv.Value= DateAndTime.Now;
            BtnEmp_Advance.Text = "Save";
        }

        private void btnClear_Loan_Click(object sender, EventArgs e)
        {
            Emp_ID = "";

            txtLoanECode.Text = "";
            cmbLoanEmp.Text = "";
            txtEmpLoan.Text ="0";
            txtEmpLoanDuration.Text = "0";
            lblLoanID.Text = "";
            txtEmpLoanEMI.Text = "0";
            //dtpEmpLoanDt.Value = DateAndTime.Now;
            txtLoanIntPer.Text = "0";

            cmbLoanEmp.Enabled = true;
        }

        private void dgvFine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lblfineid.Text = dgvFine.Rows[e.RowIndex].Cells["dgCol_fslno"].Value.ToString();
                String str = dgvFine.Rows[e.RowIndex].Cells["dgCol_fslno"].ToString();
                DataTable dtFine = clsDataAccess.RunQDTbl("select * from [tbl_fine_log] where [FLID] = " + lblfineid.Text.Trim());
                if (dtFine.Rows.Count > 0)
                {
                    Emp_ID = dtFine.Rows[0]["eid"].ToString();
                cmb_fine_name.Text = clsDataAccess.GetresultS("SELECT DISTINCT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS EmpName FROM tbl_Employee_Mast WHERE (ID='" + Emp_ID + "')");

                txt_Fine_ECode.Text = Emp_ID;
                EKKT = dtFine.Rows[0]["fid"].ToString();
                fnid = dtFine.Rows[0]["fid"].ToString();
                cmb_fine_Reason.ReturnValue = EKKT;
                cmb_fine_Reason.Text = clsDataAccess.GetresultS("select [REASON] from [tbl_FineMst] where [fid]=" + EKKT).ToString();

                  
                    EKVal = dtFine.Rows[0]["famt"].ToString();
                    txt_fine_val.Text = EKVal;
                    txt_fine_dur.Text = dtFine.Rows[0]["fduration"].ToString();
                    txt_fine_emi.Text = dtFine.Rows[0]["femi"].ToString();
                    dtp_fissue.Value = Convert.ToDateTime(dtFine.Rows[0]["fdt"]);
                    txt_remarks_fine.Text = dtFine.Rows[0]["remarks"].ToString();
                    textBox1.Text = dtFine.Rows[0]["cause"].ToString();
                    textBox2.Text = dtFine.Rows[0]["wit_name"].ToString();
                    checkBox1.Checked = Convert.ToBoolean(dtFine.Rows[0]["cause_check"]);
                    dtp_offence.Value = Convert.ToDateTime(dtFine.Rows[0]["dof"]);
                    checkBox2.Checked = Convert.ToBoolean(dtFine.Rows[0]["d_chk"]);
                }
            }
        }

        private void cmbAdvLoc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            txt_remarks_adv.Focus();
        }

        private void frmEmpAdvance_Activated(object sender, EventArgs e)
        {
            try
            {
                CmbCompany.PopUp();
            }
            catch { }
        }

                           
      
    }
}
