using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmEmpMirroring : Form
    {
        public frmEmpMirroring()
        {
            InitializeComponent();
        }

        string Coid,locid, MCoid, MLocid,MLoc,msg="",eid="",ename="",chk="";
        DataTable dt;
        DialogView dv = new DialogView();
        private void frmEmpMirroring_Load(object sender, EventArgs e)
        {
            CmbCompany.PopUp();
            cmbMComp.PopUp();
            cmbMLoc.PopUp();
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;

            }
            else if (dt.Rows.Count == 1)
            {
                CmbCompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                CmbCompany.Text = dt.Rows[0]["CO_NAME"].ToString();
                Coid = (CmbCompany.ReturnValue);
            }
            else
            {
                MessageBox.Show("No Company Record Found", "BRAVO");
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
           
            Coid = (CmbCompany.ReturnValue.Trim());
        }

        private void cmbMComp_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company where (co_code<>'"+Coid+"')");
            if (dt.Rows.Count > 1)
            {
                cmbMComp.LookUpTable = dt;
                cmbMComp.ReturnIndex = 1;

            }
            else if (dt.Rows.Count == 1)
            {
                cmbMComp.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                cmbMComp.Text = dt.Rows[0]["CO_NAME"].ToString();
                MCoid = (cmbMComp.ReturnValue);
            }
            else
            {
                MessageBox.Show("No Company Record Found", "BRAVO");
            }
        }

        private void cmbMComp_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {            
            MCoid = (cmbMComp.ReturnValue.Trim());
        }

        private void cmbMLoc_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + MCoid + "'))) order by Location_Name");
            if (dt.Rows.Count > 1)
            {
                cmbMLoc.LookUpTable = dt;
                cmbMLoc.ReturnIndex = 1;

            }
            else if (dt.Rows.Count == 1)
            {
                cmbMLoc.ReturnValue = dt.Rows[0]["Location_ID"].ToString();
                cmbMLoc.Text = dt.Rows[0]["Location_Name"].ToString();
                MLoc = cmbMLoc.Text;
                MLocid = (cmbMLoc.ReturnValue);
            }
            else
            {
                MessageBox.Show("No Location Record Found", "BRAVO");
            }
        }

        private void cmbMLoc_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            MLoc = cmbMLoc.Text;
            MLocid = (cmbMLoc.ReturnValue.Trim());
            btnView_Click(sender,e);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("select Code, ID,((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) as 'Name','"+
           MLoc.Trim() + "' as 'Location','" + MLocid.Trim() + "' as 'Locid',1 as 'Check' FROM tbl_Employee_Mast where (Company_id='" + Coid + "') and (Location_id='"+locid+"') order by ID");
            if (dt.Rows.Count > 0)
            {
                dgvEmp.DataSource = dt;
                
                dgvEmp.Columns["Locid"].Visible = false;
                dgvEmp.Columns["Code"].Visible = false;
                dgvEmp.AutoResizeRows();
                dgvEmp.AutoResizeColumns();
            }
            else
            {
                MessageBox.Show("No Employee Record Found", "BRAVO");
            }
        }

        private void btnclose_frm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MLoc = cmbMComp.Text.Trim();
            bool bl = false;
            
            msg = "";
            for (int idx = 0; idx < dgvEmp.Rows.Count; idx++)
            {
                chk = (dgvEmp.Rows[idx].Cells["Check"].Value.ToString().Trim());
                if (chk == "1")
                {
                    MLocid = dgvEmp.Rows[idx].Cells["Locid"].Value.ToString().Trim();
                    eid = dgvEmp.Rows[idx].Cells["ID"].Value.ToString().Trim();
                    ename = dgvEmp.Rows[idx].Cells["Name"].Value.ToString().Trim();
                    try
                    {
                        if (clsDataAccess.ReturnValue("Select count(*) FROM tbl_Employee_Mast WHERE (ID = '" + eid + "') and (Company_id='" + MCoid + "')") == "0")
                        {
                            bl = clsDataAccess.RunQry("INSERT INTO tbl_Employee_Mast (ID,Title,FirstName,MiddleName,LastName,FathTitle,FathFN,FathMN,FathLN,MothTitle,MothFN,MothMN,MothLN,HusTitle,HusFN,HusMN,HusLN,DateOfBirth,Cast,MaritalStatus,Gender,DesgId,JobType,PresentAddress,PermanentAddress,STD,Phone,Mobile,PANno,PassportNo,PF,PenssionNo,EDLI,ESIno,BankAcountNo,DateOfJoining,DateOfRetirement,InsertionDate,Session,GMIno,PenssionDate,EmailId,salid,SecId,EmpWorkingStatus,Empimage,Empdocimage,Empdocimage2,Empdocimage3,Presentbuilding,Presentstreet,Presentareia,Presentcity,Presentpin,Presentstate,Presentcountry,Permanentbuilding,Permanentstreet,Permanentareia,Permanentcity,Permanentpin,Permanentstate,Permanentcountry,Religion,Weight,Height,Language_Bengali,Language_Hindi,Language_English,Language_Other,Language_Name,Document_Titel,Document_Titel2,Document_Titel3,PF_Deduction,EMPBASIC,active,EMPSAL,Bank_Name,Branch_Name,Bank_AC_Type,pf_name,esi_name,bankAc_name,ESI_Deduction,issuedate,valid,[identity],econtact,other,remarks,oRemarks,status,pay_mod,ifFound,chest,complexion,haircolor,eyecolor,aadhar,icard,dept,blgrp,psid,mode_cwd,Language_Other2,Language_Name2,pass,active_usr,edate,Location_id, Company_id,del,memp) " +
                                                   "SELECT ID,Title,FirstName,MiddleName,LastName,FathTitle,FathFN,FathMN,FathLN,MothTitle,MothFN,MothMN,MothLN,HusTitle,HusFN,HusMN,HusLN,DateOfBirth,Cast,MaritalStatus,Gender,DesgId,JobType,PresentAddress,PermanentAddress,STD,Phone,Mobile,PANno,PassportNo,PF,PenssionNo,EDLI,ESIno,BankAcountNo,DateOfJoining,DateOfRetirement,InsertionDate,Session,GMIno,PenssionDate,EmailId,salid,SecId,EmpWorkingStatus,Empimage,Empdocimage,Empdocimage2,Empdocimage3,Presentbuilding,Presentstreet,Presentareia,Presentcity,Presentpin,Presentstate,Presentcountry,Permanentbuilding,Permanentstreet,Permanentareia,Permanentcity,Permanentpin,Permanentstate,Permanentcountry,Religion,Weight,Height,Language_Bengali,Language_Hindi,Language_English,Language_Other,Language_Name,Document_Titel,Document_Titel2,Document_Titel3,PF_Deduction,EMPBASIC,active,EMPSAL,Bank_Name,Branch_Name,Bank_AC_Type,pf_name,esi_name,bankAc_name,ESI_Deduction,issuedate,valid,[identity],econtact,other,remarks,oRemarks,status,pay_mod,ifFound,chest,complexion,haircolor,eyecolor,aadhar,icard,dept,blgrp,psid,mode_cwd,Language_Other2,Language_Name2,pass,active_usr,edate,'" + MLocid.Trim() + "', '" + MCoid.Trim() + "','1','1' FROM tbl_Employee_Mast WHERE (Company_id='" + Coid + "') and (Location_id='"+locid+"') AND (ID='" + eid.Trim() + "')");
                        }
                        else
                        {

                            bl = true;
                        }

                    }
                    catch { }
                }
                else
                {

                    bl = true;
                }

                if (bl == false)
                {
                    if (msg.Trim() == "")
                    {
                        msg = eid+" - " + ename;
                    }
                    else
                    {
                        msg = msg + Environment.NewLine + eid + " - " + ename;
                    }
                }
            }


            if (msg.Trim() != "")
            {
                msg = "Following Record update failed :" + Environment.NewLine + msg.Trim();
            }
            else
            {
                msg="Employee Record updated";
            }


            MessageBox.Show(msg.Trim(), "BRAVO");



        }

        private void dgvEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgvEmp.CurrentCell.ColumnIndex == dgvEmp.Columns["Location"].Index) || (dgvEmp.CurrentCell.ColumnIndex == dgvEmp.Columns["Locid"].Index))
            {
                DialogView dv = new DialogView();
                dv.sql_frm = "Select Location_ID,Location_Name,(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + MCoid + "'))) order by Location_Name";
                dv.retno = 2;
                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;
                dv.ShowDialog();
                try
                {
                    int ind = Convert.ToInt32(dgvEmp.CurrentRow.Index);

                    this.dgvEmp.Rows[ind].Cells["Location"].Value = dv.retval1.ToString();
                    this.dgvEmp.Rows[ind].Cells["Locid"].Value = dv.retval.ToString();

                }
                catch { }

            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            dt = clsDataAccess.RunQDTbl("Select Location_Name,Location_ID,(select client_name from tbl_Employee_CliantMaster where Client_id= el.Cliant_ID) as Client  from tbl_Emp_Location el where (Location_ID IN (select Location_ID from Companywiseid_Relation where (Company_ID='" + Coid + "'))) order by Location_Name");
            if (dt.Rows.Count > 1)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }
            else if (dt.Rows.Count == 1)
            {
                cmbLocation.ReturnValue = dt.Rows[0]["Location_ID"].ToString();
                cmbLocation.Text = dt.Rows[0]["Location_Name"].ToString();

                locid = (cmbLocation.ReturnValue);
            }
            else
            {
                MessageBox.Show("No Location Record Found", "BRAVO");
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            locid = (cmbLocation.ReturnValue);
        }



    }
}
