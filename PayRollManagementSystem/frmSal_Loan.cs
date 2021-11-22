using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmSal_Loan : Form
    {
        public frmSal_Loan()
        {
            InitializeComponent();
        }
        public string empcode, empname, eval, emonth, ecoid, elocid, eloc,tid;

        private void BtnEmp_Advance_Click(object sender, EventArgs e)
        {
            double EADEDUCT = Convert.ToInt32(0);
            string EADEDUCTDT = Convert.ToString(""), Emp_ID = "0";

            //    dg_adv = SubmitAdvDetails(rcNo, EAEID, EANAME, EADT, EAMONTH, EAAMT, EADEDUCT, EADEDUCTDT, EAID);

            int rcNo = 0, count_E = 0;

            int EAID = 0, Co_ID = Convert.ToInt32(lbl_coid.Text.ToString()), location_id = Convert.ToInt32(lbl_locid.Text.ToString());
            try
            {
                EAID = Convert.ToInt32(clsDataAccess.GetresultS("Select Max(ELID) from [tbl_Employee_LOAN]")) + 1;
            }
            catch
            {
                EAID = 1;
            }

            string EAEID = txtAdvECode.Text.Trim();
            string EANAME = cmbEmpAdv.Text.Trim();

            string EADT = dtpEmpAdv.Text;
            string EAMONTH = DTP_MON.Text;

            double EAAMT = Convert.ToDouble(txtEmpAdv.Text);
            double slno = 0;

            double ELDuration = Convert.ToDouble(txtDuration.Text);
           
            double ELEMI = Convert.ToDouble(txtEMI.Text);

            Emp_ID = clsDataAccess.GetresultS("SELECT code FROM tbl_Employee_Mast where ID='" + EAEID + "'");
            if (BtnEmp_Advance.Text == "Update")
            {
                bool dg_adv_M = clsDataAccess.RunNQwithStatus("Update [tbl_Employee_LOAN] Set [ELDT]=cast(convert(datetime,'" + EADT + "',103) as datetime),[ELAMT]='" + EAAMT + "',[LocName]='" + cmbAdvLoc.Text + "' where ([ELEID]='" + Emp_ID + "') and ([ELMONTH]='" + EAMONTH + "') and ([ELID]='" + Emp_ID + "')");

                if (dg_adv_M == true)
                {
                    MessageBox.Show("Record Updated", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Co_ID = 0;

                    location_id = 0;


                }
                else
                {
                    MessageBox.Show("Record not Updated", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                BtnEmp_Advance.Text = "Save";
            }
            else if (BtnEmp_Advance.Text == "Change")
            {

                eval = txtEmpAdv.Text;
                this.Close();
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("Do you want to Save?", "Confirm!", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_QUESTION);
                if (EDPMessageBox.EDPMessage.ButtonResult == "edpNO")
                {
                }
                else
                {
                    try
                    {
                        count_E = Convert.ToInt32(clsDataAccess.GetresultS("Select count (ELID) from [tbl_Employee_LOAN] ([ELEID]='" + EAEID + "') and ([ELMONTH]='" + EAMONTH + "')"));

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

                            rcNo = Convert.ToInt32(clsDataAccess.GetresultS("Select max(ELID) from [tbl_Employee_LOAN]"));
                            rcNo = rcNo + 1;
                        }
                        else
                        {
                            count_E = Convert.ToInt32(clsDataAccess.GetresultS("Select ELID from [tbl_Employee_LOAN] where ([ELEID]='" + EAEID + "') and ([ELMONTH]='" + EAMONTH + "')"));
                            bool bool_E = clsDataAccess.RunNQwithStatus("delete [tbl_Employee_LOAN] where ([ELEID]='" + EAEID + "') and ([ELMONTH]='" + EAMONTH + "')");
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



                    tid = rcNo.ToString();

                    bool dg_adv = clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_LOAN] " +
          "([ELID],[ELEID],[ELNAME],[ELDT],[ELMONTH],[ELAMT],[ELDuration],[ELEMI],[ELDEDUCT],[ELDEDUCTDT],[SLNO],[CoID],[LocID],[ELRate],[ELRtAmt]) VALUES ( " +
          rcNo + ",'" + EAEID + "','" + EANAME + "',cast(convert(datetime,'" + EADT + "',103) as datetime),'" + EAMONTH + "','" +
          EAAMT + "','" + ELDuration + "','" + ELEMI + "','" + EADEDUCT + "',cast(convert(datetime,'" + EADEDUCTDT + "',103) as datetime)," + EAID + "," + Co_ID + "," + location_id + ",0,0)");

                    // }
                    if (dg_adv == true)
                    {
                        MessageBox.Show("Record Inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        eval = ELEMI.ToString();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Record not inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

            }
            BtnEmp_Advance.Text = "Save";
        }

        private void frmSal_Loan_Load(object sender, EventArgs e)
        {
            lbl_locid.Text = elocid.Trim();
            cmbAdvLoc.Text = eloc.Trim();
            DTP_MON.Text = emonth;
            cmbEmpAdv.Text = empname;
            txtAdvECode.Text = empcode;
            lbl_coid.Text = ecoid;

            txtEmpAdv.Text = eval;
            txtDuration.Text = "1";

            if (Convert.ToDouble(eval) > 0)
            {

                BtnEmp_Advance.Text = "Change";
            }
            else
            {

                BtnEmp_Advance.Text = "Save";
            }
        }

        private void txtDuration_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        public void calc()
        {
            try
            {
                txtEMI.Text = Convert.ToString(Convert.ToDouble(txtEmpAdv.Text) / Convert.ToDouble(txtDuration.Text));
            }
            catch { txtEMI.Text = "0"; }
        }

        private void txtEmpAdv_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

    }
}
