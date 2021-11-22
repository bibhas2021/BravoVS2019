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
    public partial class frmALKF_Details : Form
    {
        string eid, desgid, type;
        public string ramt = "0";
        public DataTable dtVal = new DataTable();
        public int vl = 0;
        public frmALKF_Details(string EID, string Dsgid,string tp,string mn )
        {
            InitializeComponent();

            eid=EID;
            desgid = Dsgid;
            type = tp;
            DTP_MON.Value = Convert.ToDateTime(mn);
        }
        public void details()
        {
            int rw_alfk = 0;

            if (type.Trim().ToLower()=="advance")
            {
                string loan_amt = clsDataAccess.GetresultS("Select isNull(SUM(isnull(EAAMT,0)) - SUM(isnull(EADEDUCT,0)),0) from tbl_Employee_Advance where (EAEID='" + eid + "') and (cast('28/'+ EAMONTH as date) <= cast('28/" + DTP_MON.Value.ToString("MMM/yyyy") + "' as date))");
                                   
                if ((loan_amt != null) && (Information.IsNumeric(loan_amt) == true) && Convert.ToDouble(loan_amt) > 0)
                {
                    DataTable dtadv = clsDataAccess.RunQDTbl("Select eaid as tid,EAEID as eid,EANAME as ename,CONVERT(VARCHAR(11), eadt, 103)edate," +
                 "eamonth as emon,(case when (EAAMT-EADEDUCT)>0 then (EAAMT-recover) else 0 end) as amt, 'Advance' as type,'" + desgid + "' as desgID from " +
                "(select *,isNull((select SUM(ramt) from tbl_recovery where transid=ea.eaid and eid=ea.EAEID and type='Advance'),0)[recover] from tbl_Employee_Advance ea) ea where " +
                "(EAEID='" + eid + "') and (cast('28/'+ EAMONTH as date) <= cast('28/" + DTP_MON.Value.ToString("MMM/yyyy") +
                "' as date)) and (EAAMT>EADEDUCT) and  (EAAMT>[recover])");
                //(EAID not in (select transid FROM tbl_recovery where (eid='" + eid + "') and (type='Advance')))");
                    if (dtadv.Rows.Count > 0)
                    {
                        txtEmpName.Text = dtadv.Rows[0]["ename"].ToString().Trim();
                        txtDesgID.Text = desgid;

                        

                        dgvRecoveries.DataSource = dtadv;

                        txtAmt.Text = Convert.ToDouble(dtadv.Compute("SUM(amt)", string.Empty)).ToString();

                        dgvRecoveries.Columns["tid"].Visible = false;
                        dgvRecoveries.Columns["desgid"].Visible = false;
                        dgvRecoveries.Columns["eid"].Visible = false;
                        dgvRecoveries.Columns["ename"].Visible = false;

                        //for (int idx = 0; idx < dtadv.Rows.Count; idx++)
                        //{
                        //    rw_alfk = dgvRecoveries.Rows.Add();
                        //    dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = dtadv.Rows[idx]["eaid"].ToString().Trim();
                        //    dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dtadv.Rows[idx]["EAEID"].ToString().Trim();
                        //    dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = desgid.Trim();
                        //    dgvRecoveries.Rows[rw_alfk].Cells["edate"].Value = dtadv.Rows[idx]["eadt"].ToString().Trim();
                        //    dgvRecoveries.Rows[rw_alfk].Cells["emon"].Value = dtadv.Rows[idx]["eamonth"].ToString().Trim();
                        //    dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = dtadv.Rows[idx]["EAAMT"].ToString().Trim();
                        //    dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Advance";
                        //}
                    }
               }

               txtAmt.Text = string.Format("{0:F}", loan_amt);
               ramt = loan_amt;

           }
            else if (type.Trim().ToLower() == "loan")
            {

                DataTable dtln = clsDataAccess.RunQDTbl("Select ELID as tid,ELEID as eid,ELNAME as ename,CONVERT(VARCHAR(11), eldt, 103)edate," +
                 "ELMONTH as emon,(case when (ELAMT-ELDEDUCT)>=ELEMI then ELEMI else (ELAMT-ELDEDUCT) end) as amt, 'Loan' as type,'" + desgid + 
                 "' as desgID from (select *,isNull((select SUM(ramt) from tbl_recovery where transid=el.elid and eid=el.ELEID and type='Loan'),0)[recover] "+
                 " from tbl_Employee_LOAN el)el where (ELEID='" + eid + "') and (cast('28/'+ ELMONTH as date) <= cast('28/" + 
                 DTP_MON.Value.ToString("MMM/yyyy") + "' as date)) and (ELAMT>ELDEDUCT) and  (ELAMT>recover)");
                //(ELID not in (select transid FROM tbl_recovery where (eid='" + eid + "') and (type='Loan')))");
                if (dtln.Rows.Count > 0)
                {
                    txtEmpName.Text = dtln.Rows[0]["ename"].ToString().Trim();
                    txtDesgID.Text = desgid;

                    //dgvRecoveries.Columns.Add("tid", "trans id");
                    //dgvRecoveries.Columns.Add("eid", "Emp code");
                    //dgvRecoveries.Columns.Add("ename", "Emp Name");
                    //dgvRecoveries.Columns.Add("desgID", "desg id");
                    //dgvRecoveries.Columns.Add("edate", "DATE");
                    //dgvRecoveries.Columns.Add("emon", "Month");
                    //dgvRecoveries.Columns.Add("amt", "Recover");
                    //dgvRecoveries.Columns.Add("type", "Recovery");


                    dgvRecoveries.DataSource = dtln;

                    txtAmt.Text = Convert.ToDouble(dtln.Compute("SUM(amt)", string.Empty)).ToString();

                    dgvRecoveries.Columns["tid"].Visible = false;
                    dgvRecoveries.Columns["desgid"].Visible = false;
                    dgvRecoveries.Columns["eid"].Visible = false;
                    dgvRecoveries.Columns["ename"].Visible = false;

                  
                    //for (int idx = 0; idx < dtln.Rows.Count; idx++)
                    //{
                    //    rw_alfk = dgvRecoveries.Rows.Add();
                    //    dgvRecoveries.Rows[rw_alfk].Cells["tid"].Value = dtln.Rows[idx]["ELID"].ToString().Trim();
                    //    dgvRecoveries.Rows[rw_alfk].Cells["eid"].Value = dtln.Rows[idx]["ELEID"].ToString().Trim();
                    //    dgvRecoveries.Rows[rw_alfk].Cells["desgID"].Value = desgid.Trim();
                    //    dgvRecoveries.Rows[rw_alfk].Cells["edate"].Value = dtln.Rows[idx]["ELDT"].ToString().Trim();
                    //    dgvRecoveries.Rows[rw_alfk].Cells["emon"].Value = dtln.Rows[idx]["ELMONTH"].ToString().Trim();
                    //    dgvRecoveries.Rows[rw_alfk].Cells["amt"].Value = dtln.Rows[idx]["ELAMT"].ToString().Trim();
                    //    dgvRecoveries.Rows[rw_alfk].Cells["type"].Value = "Loan";
                    //}
                }
            }
            else if (type.Trim().ToLower() == "kit")
            {
                DataTable dtKit = clsDataAccess.RunQDTbl("Select EKID as tid,EKEID as eid,EKNAME as ename,EKEMI as amt,CONVERT(VARCHAR(11), ekdt, 103)edate,"+
                "'Kit' as type,'" + desgid + "' as desgID from tbl_Employee_KIT where (EKEID='" + eid + "') and [EKID] in (select ([EKID]) from tbl_Employee_KIT where (EKEID='" +
                eid + "')) and ([EKAMT]-[EKDEDUCT])>0 and (cast('28/'+ EKMONTH as date) <= cast('28/" + DTP_MON.Value.ToString("MMM/yyyy") + "' as date))");
                if (dtKit.Rows.Count > 0)
                  {

                      txtEmpName.Text = dtKit.Rows[0]["ename"].ToString().Trim();
                      txtDesgID.Text = desgid;

                      dgvRecoveries.DataSource = dtKit;

                      txtAmt.Text = Convert.ToDouble(dtKit.Compute("SUM(amt)", string.Empty)).ToString();

                      dgvRecoveries.Columns["tid"].Visible = false;
                      dgvRecoveries.Columns["desgid"].Visible = false;
                      dgvRecoveries.Columns["eid"].Visible = false;
                      dgvRecoveries.Columns["ename"].Visible = false;

                  }
            }
        }


        private void frmALKF_Details_Load(object sender, EventArgs e)
        {
            try
            {
                dgvRecoveries.Columns.Clear();
            }
            catch { }
            details();
        }

        private void BtnEmp_Advance_Click(object sender, EventArgs e)
        {
            vl = 1;
            dtVal= (DataTable)dgvRecoveries.DataSource;
            ramt = txtAmt.Text;
            
            this.Close();
        }

        public void calc()
        {
            double val=0;

            for(int ind=0;ind<dgvRecoveries.Rows.Count; ind++)
            {
                try
                {
                    val = val + Convert.ToDouble(dgvRecoveries.Rows[ind].Cells["amt"].Value);
                }
                catch 
                {
                    val= val + 0;
                MessageBox.Show("Check Recover value, Row number : "+ ind+1,"BRAVO");
                }
            }

           

            txtAmt.Text = val.ToString("0.00");

            DataTable dtln = (DataTable)dgvRecoveries.DataSource;
            txtAmt.Text = Convert.ToDouble(dtln.Compute("SUM(amt)", string.Empty)).ToString();
        }

        private void dgvRecoveries_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc();
        }

       
    }
}
