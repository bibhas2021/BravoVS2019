using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using Microsoft.VisualBasic;
using System.IO;

namespace PayRollManagementSystem
{
    public partial class frmOrderDetails_AD : Form
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        string itmid, itm, sacname="",sacno="",sacid = "";
        int TagID = 0,SalaryStructure = 0;  //0 if Fixed | 1 if Formula-Order Head |2 if Formula-Salary Head
        Boolean boolSalHeadApplicable = false;


        public frmOrderDetails_AD()
        {
            InitializeComponent();
        }

        private void frmOrderDetails_AD_Load(object sender, EventArgs e)
        {
            string filePath = "";
            filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            string lineForConfigSetting;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    if (file.ReadLine() != null)
                    {
                        int chk_str = 0;
                        while ((lineForConfigSetting = file.ReadLine()) != null)
                        {
                            string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
                            if (StrSTAR.Length == 2)
                            {
                                if (StrSTAR[0].Trim() == "")
                                    continue;
                            }

                            string[] StrLine = lineForConfigSetting.Trim().Split('[');
                            if (StrLine.Length == 2)
                            {
                                string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
                                if (str == "ORDER_SAL_HEAD_APPLICABLE")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (StrLine_WACC[0] == "TRUE")
                                    boolSalHeadApplicable = true;
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
            if (!boolSalHeadApplicable)
                rbSalaryHead.Visible = false;


            lst();
            clr();
        }


        public void list()
        {


            clr();

        }

        private void cmbItems_DropDown(object sender, EventArgs e)
        {
            String sql = "Select Htext,Hid from tbl_order_head_detail"; //(Hid, Hname, Htext)
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                cmbItems.LookUpTable = dt;
                cmbItems.ReturnIndex = 1;
            }
        }

        private void cmbItems_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            itmid = cmbItems.ReturnValue;

            txtFullName.Text = clsDataAccess.GetresultS("Select Hname from tbl_order_head_detail where (Hid='"+ itmid +"')");
        }

        private void vistaButton3_Click(object sender, EventArgs e)
        {
            frmOrderHeadMaster fohm = new frmOrderHeadMaster();
            fohm.ShowDialog();
        }

        private void cmbctype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbctype.SelectedIndex == 0)
            {
                if (!rbOrderHead.Checked && !rbSalaryHead.Checked)
                {
                    TagID = 1;
                    rbOrderHead.Checked = true;
                }
                grpFormula.Visible = true;
                grpFixed.Visible = false;
            }
            else
            {
                TagID = 0;
                grpFormula.Visible = false;
                grpFixed.Visible = true;
                
            }
        }

        private void grpFixed_Enter(object sender, EventArgs e)
        {

        }

        private void lstSalaryHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFormula.TextLength == 0)
            {
                txtFormula.Text = lstSalaryHead.SelectedItem.ToString();
            }
            else if (txtFormula.TextLength > 0)
            {
                txtFormula.Text = txtFormula.Text + lstSalaryHead.SelectedItem.ToString();
 
            }
        }
        public void lst()
        {
            lstSalaryHead.Items.Clear();

            DataTable dt = clsDataAccess.RunQDTbl("select Htext from tbl_order_head_detail order by Hid");
                
                //"select Fexpr from tbl_order_FB_detail where (Fname='" + lblContractNo.Text + "')");
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                lstSalaryHead.Items.Add(dt.Rows[ind][0].ToString());
            }


        }

        public void lstSalHead()
        {
            lstSalaryHead.Items.Clear();

            DataTable dt = clsDataAccess.RunQDTbl("select SalaryStructure_ID from tbl_Employee_Link_SalaryStructure where Location_ID=" + lbllocid.Text + " ");
            if (dt.Rows.Count > 0)
            {
                SalaryStructure = Convert.ToInt32(dt.Rows[0]["SalaryStructure_ID"]);
                DataTable dtSalaryHeadShow = clsDataAccess.RunQDTbl("select ss.SAL_HEAD,(case ss.P_TYPE when 'E' then (select eh.SalaryHead_Short from tbl_Employee_ErnSalaryHead eh where eh.SlNo = ss.SAL_HEAD) else (select eh.SalaryHead_Short from tbl_Employee_DeductionSalayHead eh where eh.SlNo = ss.SAL_HEAD) end) as 'SalHead' from tbl_Employee_Assign_SalStructure ss where ss.SAL_STRUCT =" + SalaryStructure + " order by ss.P_TYPE desc");
                for(int ind = 0;ind < dtSalaryHeadShow.Rows.Count; ind++)
                {
                    lstSalaryHead.Items.Add(dtSalaryHeadShow.Rows[ind]["SalHead"].ToString());
                }
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("This location has no salary structure defined.");
                rbOrderHead.Checked = true;
            }
        }

        public void clr()
        {
            txtFixedNote.Text = "";
            txtFormula.Text = "";
            txtFixed.Text = "0";
            txtPer.Text = "0";
            txtfull_name.Text = "";
            cmbItems.Text = "";
            lblFID.Text = "";
            cmbSAC.Text = "";
            txtFullName.Text = "";

            DataTable dt = clsDataAccess.RunQDTbl("SELECT Fid,htext,position,basis,Fexpr,fper,vnote as note,(select serviceName+':'+sacNo as 'SAC' from CompanySACMaster where slno = fbd.SAC) as 'SACDET',SAC,case [tagging] when 1 then 'Order Head' when 2 then 'Salary Head' else 'Fixed' end as 'Tagged With', tagging FROM tbl_order_FB_detail fbd where (Fname='" + lblContractNo.Text + "') order by fid");
            dgvOther.DataSource = dt;
            dgvOther.Columns["Fid"].Visible = false;
            dgvOther.Columns["SAC"].Visible = false;
            dgvOther.Columns["tagging"].Visible = false;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //tbl_order_FB_detail -   Fid int,Fname nvarchar(Max),position int,basis nvarchar(Max), Fexpr nvarchar(Max),fper numeric (18,2),vnote nvarchar(Max)

           int Fid=0,position=0;
            double fper=0;
            string Fname=lblContractNo.Text, vnote=txtFixedNote.Text, basis="",htext=cmbItems.Text, Fexpr="",sql="";

            try
            {
                basis = cmbctype.SelectedItem.ToString();
            }
            catch
            { basis = "Fixed"; }


            try
            {
                if (basis.ToLower().Trim() == "formula")
                {
                    Fexpr = txtFormula.Text;
                    fper = 0;
                }

                else{
                    Fexpr = "";
                    fper = Convert.ToDouble(txtFixed.Text);
                }
                
            }
            catch
            { 
            
            }

            try
            {
                sacid = Convert.ToString(clsDataAccess.RunQDTbl("select slno from CompanySACMaster where sacNo = '" + cmbSAC.Text + "'").Rows[0][0]);
            }
            catch
            { }
            try
            {
                Fid = Convert.ToInt32(clsDataAccess.GetresultS("select MAX(fid) from tbl_order_FB_detail")) + 1;
            }
            catch
            {
                Fid = 1;
            }

            position = Convert.ToInt32(Convert.ToInt32(clsDataAccess.GetresultS("select count(position) from tbl_order_FB_detail where (Fname='"+ Fname +"')"))+1);

            if (lblFID.Text.Trim() == "" && !Information.IsNumeric(lblFID.Text.Trim()))
            {
                if (sacid == "")
                    sql = "INSERT INTO tbl_order_FB_detail(Fid,Fname,position,basis,Fexpr,fper,vnote,htext,[tagging]) VALUES (" + Fid + ",'" + Fname + "'," + position + ",'" + basis + "','" + Fexpr + "'," + fper + ",'" + vnote + "','" + htext + "'," + TagID + ")";
                else
                    sql = "INSERT INTO tbl_order_FB_detail(Fid,Fname,position,basis,Fexpr,fper,vnote,htext,SAC,[tagging]) VALUES (" + Fid + ",'" + Fname + "'," + position + ",'" + basis + "','" + Fexpr + "'," + fper + ",'" + vnote + "','" + htext + "','" + sacid + "'," + TagID + ")";
            }
            else if (Information.IsNumeric(lblFID.Text.Trim()))
            {
                if (sacid == "")
                    sql = "update tbl_order_FB_detail set Fname = '" + Fname + "',position = " + position + ",basis = '" + basis + "',Fexpr = '" + Fexpr + "',fper = '" + fper + "',vnote = '" + vnote + "',htext = '" + htext + "',[tagging] = " + TagID + " where Fid = " + lblFID.Text.Trim();
                else
                    sql = "update tbl_order_FB_detail set Fname = '" + Fname + "',position = " + position + ",basis = '" + basis + "',Fexpr = '" + Fexpr + "',fper = '" + fper + "',vnote = '" + vnote + "',htext = '" + htext + "',[tagging] = " + TagID + ",SAC = '"+sacid+"' where Fid = " + lblFID.Text.Trim();
            }

          bool  boolStatus = clsDataAccess.RunNQwithStatus(sql);

          if (boolStatus == true)
          {
              clr();
          }
        }

        private void cmdSAC_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select sacNo,serviceName from CompanySACMaster");
            if (dt.Rows.Count > 0)
            {
                cmbSAC.LookUpTable = dt;
                cmbSAC.ReturnIndex = 0;
            }
        }

        private void cmbSAC_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            sacno = cmbSAC.ReturnValue;
        }

        private void rbOrderHead_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOrderHead.Checked)
            {
                TagID = 1;
                lst();
            }
        }

        private void rbSalaryHead_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSalaryHead.Checked)
            {
                TagID = 2;
                lstSalHead();
            }
        }

        private void dgvOther_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lblFID.Text = dgvOther.Rows[e.RowIndex].Cells["Fid"].Value.ToString();
                //lblSAC.Text = dgvOther.Rows[e.RowIndex].Cells["SACDET"].ToString().Substring(dgvOther.Rows[e.RowIndex].Cells["SACDET"].ToString().IndexOf(':'));
                cmbItems.Text = dgvOther.Rows[e.RowIndex].Cells["htext"].Value.ToString();
                txtFullName.Text = clsDataAccess.GetresultS("Select Hname from tbl_order_head_detail where ([Htext]='" + cmbItems.Text + "')");
                txtFixedNote.Text = dgvOther.Rows[e.RowIndex].Cells["note"].Value.ToString();
                if (dgvOther.Rows[e.RowIndex].Cells["SACDET"].Value.ToString().Trim() != "")
                {
                    cmbSAC.Text = dgvOther.Rows[e.RowIndex].Cells["SACDET"].Value.ToString().Substring(dgvOther.Rows[e.RowIndex].Cells["SACDET"].Value.ToString().IndexOf(':'));
                }
                cmbctype.SelectedItem = dgvOther.Rows[e.RowIndex].Cells["basis"].Value.ToString().ToUpper();
                switch(cmbctype.SelectedItem.ToString())
                {
                    case "FIXED":
                        TagID = 0;
                        txtFixed.Text = dgvOther.Rows[e.RowIndex].Cells["fper"].Value.ToString();
                        break;
                    case "FORMULA":
                        txtFormula.Text = dgvOther.Rows[e.RowIndex].Cells["Fexpr"].Value.ToString();
                        if (dgvOther.Rows[e.RowIndex].Cells["tagging"].Value.ToString() == "1")
                        {
                            rbOrderHead.Checked = true;

                        }
                        else
                        {
                            rbSalaryHead.Checked = true;
                        }
                        break;
                }
            }
        }

        private void numPosition_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lblFID.Text.Trim() != "" && Information.IsNumeric(lblFID.Text.Trim()))
            {
                bool boolstatus = clsDataAccess.RunNQwithStatus("delete tbl_order_FB_detail where Fid = " + lblFID.Text.Trim());
                clr();
                EDPMessageBox.EDPMessage.Show("Record deleted successfully");
            }
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void dgvOther_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblFID.Text = dgvOther.Rows[e.RowIndex].Cells["Fid"].Value.ToString();
            //lblSAC.Text = dgvOther.Rows[e.RowIndex].Cells["SACDET"].ToString().Substring(dgvOther.Rows[e.RowIndex].Cells["SACDET"].ToString().IndexOf(':'));
            cmbItems.Text = dgvOther.Rows[e.RowIndex].Cells["htext"].Value.ToString();
            txtFullName.Text = clsDataAccess.GetresultS("Select Hname from tbl_order_head_detail where ([Htext]='" + cmbItems.Text + "')");
            txtFixedNote.Text = dgvOther.Rows[e.RowIndex].Cells["note"].Value.ToString();
            if (dgvOther.Rows[e.RowIndex].Cells["SACDET"].Value.ToString().Trim() != "")
            {
                cmbSAC.Text = dgvOther.Rows[e.RowIndex].Cells["SACDET"].Value.ToString().Substring(dgvOther.Rows[e.RowIndex].Cells["SACDET"].Value.ToString().IndexOf(':'));
            }
            cmbctype.SelectedItem = dgvOther.Rows[e.RowIndex].Cells["basis"].Value.ToString().ToUpper();
            switch (cmbctype.SelectedItem.ToString())
            {
                case "FIXED":
                    TagID = 0;
                    txtFixed.Text = dgvOther.Rows[e.RowIndex].Cells["fper"].Value.ToString();
                    break;
                case "FORMULA":
                    txtFormula.Text = dgvOther.Rows[e.RowIndex].Cells["Fexpr"].Value.ToString();
                    if (dgvOther.Rows[e.RowIndex].Cells["tagging"].Value.ToString() == "1")
                    {
                        rbOrderHead.Checked = true;

                    }
                    else
                    {
                        rbSalaryHead.Checked = true;
                    }
                    break;
            }
        }

        
    }
}
