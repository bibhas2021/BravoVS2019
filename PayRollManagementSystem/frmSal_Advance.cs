using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmSal_Advance : Form
    {
        public frmSal_Advance()
        {
            InitializeComponent();
        }
        public string empcode, empname, eval, emonth,ecoid,elocid,eloc,tid;


        private void BtnEmp_Advance_Click(object sender, EventArgs e)
        {
            double EADEDUCT = Convert.ToInt32(0);
            string EADEDUCTDT = Convert.ToString(""), Emp_ID="0";

            //    dg_adv = SubmitAdvDetails(rcNo, EAEID, EANAME, EADT, EAMONTH, EAAMT, EADEDUCT, EADEDUCTDT, EAID);

            int rcNo = 0, count_E = 0;

            int EAID = 0, Co_ID = Convert.ToInt32(lbl_coid.Text.ToString()), location_id = Convert.ToInt32(lbl_locid.Text.ToString());
            try
            {
                EAID = Convert.ToInt32(clsDataAccess.GetresultS("Select Max(EAID) from [tbl_Employee_Advance]")) + 1;
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
            Emp_ID = clsDataAccess.GetresultS("SELECT code FROM tbl_Employee_Mast where ID='" + EAEID + "'");
            if (BtnEmp_Advance.Text == "Update")
            {
                bool dg_adv_M = clsDataAccess.RunNQwithStatus("Update [tbl_Employee_Advance] Set [EADT]=cast(convert(datetime,'" + EADT + "',103) as datetime),[EAAMT]='" + EAAMT + "',[LocName]='" + cmbAdvLoc.Text + "' where ([EAEID]='" + Emp_ID + "') and ([EAMONTH]='" + EAMONTH + "') and ([EAID]='" + Emp_ID + "')");

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





                    bool dg_adv = clsDataAccess.RunNQwithStatus("INSERT INTO [tbl_Employee_Advance] " +
                   "([EAID],[EAEID],[EANAME],[EADT],[EAMONTH],[EAAMT],[EADEDUCT],[EADEDUCTDT],[SLNO],[CoID],[LocID],[LocName]) VALUES ( " +
                   EAID + ",'" + EAEID + "','" + EANAME + "',cast(convert(datetime,'" + EADT + "',103) as datetime),'" + EAMONTH + "','" +
                   EAAMT + "','" + EADEDUCT + "',cast(convert(datetime,'" + EADEDUCTDT + "',103) as datetime)," + slno + "," + Co_ID + "," + location_id + ",'" + cmbAdvLoc.Text + "')");

                    tid = EAID.ToString();
                    // }
                    if (dg_adv == true)
                    {
                        MessageBox.Show("Record Inserted", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        eval = EAAMT.ToString();
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

        private void frmSal_Advance_Load(object sender, EventArgs e)
        {
            lbl_locid.Text = elocid.Trim();
            cmbAdvLoc.Text = eloc.Trim();
            DTP_MON.Text = emonth;
            cmbEmpAdv.Text = empname;
            txtAdvECode.Text = empcode;
            lbl_coid.Text = ecoid;
            
            txtEmpAdv.Text = eval;

            if (Convert.ToDouble(eval) > 0)
            {

                BtnEmp_Advance.Text = "Change";
            }
            else
            {

                BtnEmp_Advance.Text = "Save";
            }


        }
    }
}
