using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmEmployeeSalHeadDetails : Form
    {
        public DataTable dtSalHeadDet = new DataTable();
        string SalaryHeadName = "";
        string SalaryHeadID = "";
        string SalaryHeadType = "";
        public frmEmployeeSalHeadDetails(DataTable dtFromPreviousForm,string salName,string salID,string salType)
        {
            dtSalHeadDet.Rows.Clear();
            dtSalHeadDet = dtFromPreviousForm;
            SalaryHeadID = salID;
            SalaryHeadName = salName;
            SalaryHeadType = salType;
            InitializeComponent();
        }

        private void frmEmployeeSalHeadDetails_Load(object sender, EventArgs e)
        {
            this.cmbvfrom.SelectedItem = "April";
            this.cmbvto.SelectedItem = "March";
            //this.HeaderText = "Assign Heads To Salary Structure ";

            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }

            lblSalHead.Text = SalaryHeadName;
            lblHeadType.Text = SalaryHeadType;
            lblHeadID.Text = SalaryHeadID;

            if (SalaryHeadType == "E")
            {
                chkpf.Enabled = false;
                chkesi.Enabled = false;
                chkLoan.Enabled = false;
                chkpt.Enabled = false;
                chkKit.Enabled = false;
                chkAdvance.Enabled = false;
            }
            else if (SalaryHeadType == "D")
            {
                chkpf.Enabled = true;
                chkesi.Enabled = true;
                chkLoan.Enabled = true;
                chkpt.Enabled = true;
                chkKit.Enabled = true;
                chkAdvance.Enabled = true;
            }

            for (int i = 0; i < dtSalHeadDet.Rows.Count; i++)
            {
                if (dtSalHeadDet.Rows[i]["SAL_Head"].ToString().Trim() == SalaryHeadID && dtSalHeadDet.Rows[i]["P_TYPE"].ToString().Trim()==SalaryHeadType)
                {
                    this.cmbvfrom.SelectedItem = dtSalHeadDet.Rows[i]["V_FROM"].ToString().Trim();
                    this.cmbvto.SelectedItem = dtSalHeadDet.Rows[i]["V_TO"].ToString().Trim();
                    this.cmbYear.SelectedItem = dtSalHeadDet.Rows[i]["SESSION"].ToString().Trim();

                    if (dtSalHeadDet.Rows[i]["PF_PER"].ToString().Trim() == "1")
                    {
                        chkpf.Checked = true;
                    }
                    else
                    {
                        chkpf.Checked = false;
                    }

                    if (dtSalHeadDet.Rows[i]["ESI_PER"].ToString().Trim() == "1")
                    {
                        chkesi.Checked = true;
                    }
                    else 
                    {
                        chkesi.Checked = false;
                    }

                    if (dtSalHeadDet.Rows[i]["PT"].ToString().Trim() == "1")
                    {
                        chkpt.Checked = true;
                    }
                    else
                    {
                        chkpt.Checked = false;
                    }

                    if (dtSalHeadDet.Rows[i]["chkALK"].ToString().Trim() == "1")
                    {
                        chkAdvance.Checked = true;
                    }
                    else if (dtSalHeadDet.Rows[i]["chkALK"].ToString().Trim() == "2")
                    {
                        chkLoan.Checked = true;
                    }
                    else if (dtSalHeadDet.Rows[i]["chkALK"].ToString().Trim() == "3")
                    {
                        chkKit.Checked = true;
                    }
                    else if (dtSalHeadDet.Rows[i]["chkALK"].ToString().Trim() == "6")
                    {
                        chkGrossSub.Checked = true;
                    }
                    else
                    {
                        this.chkGrossSub.Checked = false;
                        this.chkAdvance.Checked = false;
                        this.chkLoan.Checked = false;
                        this.chkKit.Checked = false;
                    }

                    if (dtSalHeadDet.Rows[i]["EMP_BASIC"].ToString().Trim() == "1")
                    {
                        ChkEmpBasic.Checked = true;
                    }
                    else if (dtSalHeadDet.Rows[i]["EMP_BASIC"].ToString().Trim() == "2")
                    {
                        chkEmpBsTs.Checked = true;
                    }
                    else if (dtSalHeadDet.Rows[i]["EMP_BASIC"].ToString().Trim() == "3")
                    {
                        ChkEmpSal.Checked = true;
                    }
                    else if (dtSalHeadDet.Rows[i]["EMP_BASIC"].ToString().Trim() == "4")
                    {
                        chkGrossAdd.Checked = true;
                    }
                    else
                    {
                        ChkEmpBasic.Checked = false;
                        ChkEmpSal.Checked = false;
                        chkEmpBsTs.Checked = false;
                        chkGrossAdd.Checked = false;
                    }

                    if (dtSalHeadDet.Rows[i]["chkHide"].ToString().Trim() == "1")
                    {
                        chkHide.Checked = true;
                    }
                    else
                    {
                        chkHide.Checked = false;
                    }

                    if (dtSalHeadDet.Rows[i]["atten_day"].ToString().Trim() == "1")
                    {
                        cheattendence.Checked = true;
                    }
                    else
                    {
                        cheattendence.Checked = false;
                    }

                    if (dtSalHeadDet.Rows[i]["Proxy_day"].ToString().Trim() == "1")
                    {
                        cheovertime.Checked = true;
                    }
                    else
                    {
                        cheovertime.Checked = false;
                    }

                    if (dtSalHeadDet.Rows[i]["Daily_wages"].ToString().Trim() == "1")
                    {
                        chedailywages.Checked = true;
                    }
                    else
                    {
                        chedailywages.Checked = false;
                    }

                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string ss = ""; bool boolHeadFound = false;

            int att_day = 0, ove_time = 0, daily_wages = 0, rev_stamp = 0, _chkbasic = 0, _chkSal = 0, _chkALK = 0, _chkHide = 0, sunday = 0, _chkpf =0,_chkesi=0,_chkpt = 0;
            if (cheattendence.Checked == true)
                att_day = 1;
            if (cheovertime.Checked == true)
                ove_time = 1;
            if (chedailywages.Checked == true)
                daily_wages = 1;
            if (chestump.Checked == true)
                rev_stamp = 1;

            if (chkSunday.Checked == true)
            {
                daily_wages = 5;
            }
            _chkbasic = 0;
            if (ChkEmpBasic.Checked == true)
                _chkbasic = 1;

            if (this.chkEmpBsTs.Checked == true)
                _chkbasic = 2;

            if (ChkEmpSal.Checked == true)
                _chkbasic = 3;

            if (chkGrossSub.Checked == true)
                _chkbasic = 4;

            if (chkAdvance.Checked == true)
                _chkALK = 1;
            else if (chkLoan.Checked == true)
                _chkALK = 2;
            else if (chkKit.Checked == true)
                _chkALK = 3;
            else if (chkGrossAdd.Checked == true)
                _chkALK = 6;
            else
                _chkALK = 0;

            if (this.chkpf.Checked == true)
                _chkpf = 1;
            else
                _chkpf = 0;

            if (this.chkesi.Checked == true)
                _chkesi = 1;
            else
                _chkesi = 0;

            if (this.chkpt.Checked == true)
                _chkpt = 1;
            else
                _chkpt = 0;

            if (this.chkHide.Checked == true)
                _chkHide = 1;
            else
                _chkHide = 0;



            for (int i = 0; i < dtSalHeadDet.Rows.Count; i++)
            {
                if (dtSalHeadDet.Rows[i]["SAL_Head"].ToString().Trim() == SalaryHeadID && dtSalHeadDet.Rows[i]["P_TYPE"].ToString().Trim() == SalaryHeadType)
                {
                    dtSalHeadDet.Rows[i]["PF_PER"] = _chkpf;
                    dtSalHeadDet.Rows[i]["ESI_PER"] = _chkesi;
                    dtSalHeadDet.Rows[i]["PT"] = _chkpt;

                    dtSalHeadDet.Rows[i]["atten_day"] = att_day;
                    dtSalHeadDet.Rows[i]["Proxy_day"] = ove_time;
                    dtSalHeadDet.Rows[i]["Daily_wages"] = daily_wages;

                    dtSalHeadDet.Rows[i]["chkHide"] = _chkHide;

                    dtSalHeadDet.Rows[i]["EMP_BASIC"] = _chkbasic;
                    dtSalHeadDet.Rows[i]["chkALK"] = _chkALK;
                    boolHeadFound = true;
                    break;
                }
            }

            if (!boolHeadFound)
            {
                int rowCount = dtSalHeadDet.Rows.Count;
                dtSalHeadDet.Rows.Add();
                dtSalHeadDet.Rows[rowCount]["PF_PER"] = _chkpf;
                dtSalHeadDet.Rows[rowCount]["ESI_PER"] = _chkesi;
                dtSalHeadDet.Rows[rowCount]["PT"] = _chkpt;

                dtSalHeadDet.Rows[rowCount]["atten_day"] = att_day;
                dtSalHeadDet.Rows[rowCount]["Proxy_day"] = ove_time;
                dtSalHeadDet.Rows[rowCount]["Daily_wages"] = daily_wages;

                dtSalHeadDet.Rows[rowCount]["chkHide"] = _chkHide;

                dtSalHeadDet.Rows[rowCount]["EMP_BASIC"] = _chkbasic;
                dtSalHeadDet.Rows[rowCount]["chkALK"] = _chkALK;

                dtSalHeadDet.Rows[rowCount]["P_TYPE"] = SalaryHeadType;
                dtSalHeadDet.Rows[rowCount]["SESSION"] = cmbYear.Text.Trim();
                dtSalHeadDet.Rows[rowCount]["SAL_HEAD"] = SalaryHeadID;
                dtSalHeadDet.Rows[rowCount]["V_FROM"] = cmbvfrom.Text.Trim(); ;
                dtSalHeadDet.Rows[rowCount]["V_TO"] = cmbvto.Text.Trim();
                dtSalHeadDet.Rows[rowCount]["PF_VOL"] = 0;
                dtSalHeadDet.Rows[rowCount]["ROUND_TYPE"] = "";
                dtSalHeadDet.Rows[rowCount]["TDSREFNO"] = 0;
                dtSalHeadDet.Rows[rowCount]["TDS_EXEMPT"] = 0;
                dtSalHeadDet.Rows[rowCount]["CARRY"] = 0;
                dtSalHeadDet.Rows[rowCount]["TDS_EXTRAPOLNO"] = 0;
                dtSalHeadDet.Rows[rowCount]["REMARKS"] = "";
                dtSalHeadDet.Rows[rowCount]["Revenue_Stamp"] = 0;
                dtSalHeadDet.Rows[rowCount]["Stamp_Amount"] = "";
            }

            this.Close();
            //frmEmployeeSalAssignNewUI parent = new frmEmployeeSalAssignNewUI();
            //parent = (frmEmployeeSalAssignNewUI)this.Owner;
            //parent.NotifyMe(dtSalHeadDet);
        }
    }
}
