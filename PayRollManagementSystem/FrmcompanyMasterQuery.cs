using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class FrmcompanyMasterQuery : EDPComponent.FormBaseERP
    {
        DataTable dt = new DataTable();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public FrmcompanyMasterQuery()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
        //Following code has been added by dwipraj dutta 140820170510PM
        private void btnSave_Click(object sender, EventArgs e)
        {
            int companycount = Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*) from Company").Rows[0][0]);
            if (companycount == 0)
                CompanyAddProcess();
            else
            {
                DataTable dtCompanyLimiter = clsDataAccess.RunQDTbl("select LMTVALUE from CompanyLimiter");
                if (dtCompanyLimiter.Rows.Count > 0)
                {
                    if (companycount < Convert.ToInt32(dtCompanyLimiter.Rows[0][0]))
                        CompanyAddProcess();
                    else
                        EDPMessageBox.EDPMessage.Show("You cannot create more than "+companycount+" number of Company in this version.");
                }
                else
                {
                    EDPMessageBox.EDPMessage.Show("Your version have not the permission to add more that 1 company.");
                }
            }
        }

        private void CompanyAddProcess()
        {
            frmcompanyMaster cm = new frmcompanyMaster();
            cm.getcode(0, "C");
            cm.ShowDialog();
            GetDetails();
        }
        //end of adding
        private void FrmcompanyMasterQuery_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Company Master";
            GetDetails();
        }

        private void GetDetails()
        {

            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("SELECT Distinct c.CO_CODE,c.GCODE as 'Code', c.CO_NAME, isNull(b.BRNCH_CITY,'') AS 'CITY',isNull((SELECT State_Name FROM StateMaster WHERE (STATE_CODE = b.BRNCH_STATE)),'') AS 'STATE', isNull(b.BRNCH_TELE1,'') AS contact, isNull(b.Email,'') as Email,isNull( b.GSTINNO,'')'GSTIN' FROM Company AS c FULl OUTER JOIN Branch AS b ON c.CO_CODE = b.GCODE where co_code in (select cr.Company_ID from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ")) order by c.co_code");
                    //clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("SELECT Distinct c.CO_CODE,c.GCODE as 'Code', c.CO_NAME, isNull(b.BRNCH_CITY,'') AS 'CITY',isNull((SELECT State_Name FROM StateMaster WHERE (STATE_CODE = b.BRNCH_STATE)),'') AS 'STATE', isNull(b.BRNCH_TELE1,'') AS contact, isNull(b.Email,'') as Email,isNull( b.GSTINNO,'')'GSTIN' FROM Company AS c FULl OUTER JOIN Branch AS b ON c.CO_CODE = b.GCODE order by c.co_code");
            }
             
                
                //("Select CO_CODE,CO_NAME,BRNCH_CITY as 'CITY',(SELECT  State_Name FROM  StateMaster where state_code=BRNCH_STATE)'STATE',BRNCH_TELE1 as contact,Email,GSTINNO from Company c join Branch b on c.co_code=b.gcode where BRNCH_CODE=1");
                //("Select CO_CODE,CO_NAME from Company");
            if (dt.Rows.Count > 0)
            {
                dgCatg.DataSource = dt;
            }


            int companycount = Convert.ToInt32(clsDataAccess.RunQDTbl("select count(*) from Company").Rows[0][0]);
            if (companycount == 0)
                btnSave.Enabled = true;
            else
            {
                DataTable dtCompanyLimiter = clsDataAccess.RunQDTbl("select LMTVALUE from CompanyLimiter");
                if (dtCompanyLimiter.Rows.Count > 0)
                {
                    if (companycount <= Convert.ToInt32(dtCompanyLimiter.Rows[0][0]) || Convert.ToInt32(dtCompanyLimiter.Rows[0][0]) == 0)
                        btnSave.Enabled = true;
                    else
                    {
                        btnSave.Enabled = false; 
                        MessageBox.Show("Company Limit Reached in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or" + Environment.NewLine + "Call : 033-40003855", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    btnSave.Enabled = false;
                    MessageBox.Show("Company Limit Reached in your version right now." + Environment.NewLine + "Please contact support@edpsoft.com or" + Environment.NewLine + "Call : 033-40003855", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string mconfig = clsDataAccess.ReturnValue("select email from CompanyLimiter");
                if (mconfig == "0")
                {
                    btnMail.Visible = false;

                }
                else
                {

                    btnMail.Visible = true;
                }
            }
        }

        private void dgCatg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int co_code = 0; 
            if (Information.IsNumeric(dgCatg.Rows[e.RowIndex].Cells["Slno"].Value) == true)
            {
                co_code = Convert.ToInt32(dgCatg.Rows[e.RowIndex].Cells["Slno"].Value);
                frmcompanyMaster cm = new frmcompanyMaster();
                cm.getcode(co_code, "C");
                cm.ShowDialog();
                GetDetails();
            }
        }

        private void FrmcompanyMasterQuery_Enter(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int co_code = Convert.ToInt32(dgCatg.Rows[dgCatg.CurrentRow.Index].Cells["Slno"].Value);
            if (Information.IsNumeric(dgCatg.Rows[dgCatg.CurrentRow.Index].Cells["Slno"].Value) == true)
            {
                Boolean boolStatus = false;
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from Company where CO_CODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from Branch where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from grp where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from glmst where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from prtyms where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from Access where GCODE=" + co_code + "");
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from AccessBranch where GCODE=" + co_code + "");

                if (boolStatus)
                {
                    ERPMessageBox.ERPMessage.Show("Company Name Deleted Successfully");
                    GetDetails();
                }
            }
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            frmEmailConfig mconfig = new frmEmailConfig();
            mconfig.ShowDialog();
        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            Config cfg = new Config();
            cfg.ShowDialog();
        }

        private void btnBillConfig_Click(object sender, EventArgs e)
        {
            frmCompanyBillConfig cbc = new frmCompanyBillConfig();
            cbc.ShowDialog();
        }
    }
}
