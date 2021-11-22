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
    public partial class frmStatusLog : Form
    {
        public frmStatusLog()
        {
            InitializeComponent();
        }
        string eid = "", opt = "", coid = "", locid = "", _active="";
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();

        private void cmbEmp_DropDown(object sender, EventArgs e)
        {
            opt = ""; coid = ""; locid = "";
            if (cmbcompany.ReturnValue.Trim() != "")
                coid = Convert.ToString(cmbcompany.ReturnValue);

            if (cmbLoc.ReturnValue.Trim() != "")
                locid = Convert.ToString(cmbLoc.ReturnValue);

            if (coid.Trim() != "" && locid.Trim() != "")
            {
                opt = " where (Company_id='" + coid + "') and (Location_id='"+ locid +"')";
            }
            else if (coid.Trim() != "")
            {
                opt = " where (Company_id='" + coid + "') ";
            }
            else if (locid.Trim() != "")
            {
                opt = " where Location_id='" + locid + "')";
            }
            else
            {
                opt = "";
            }


            String str = "SELECT ((case when FirstName!='' then FirstName + ' '  else '' End)+(case when MiddleName!='' then MiddleName + ' '  else '' End)+(case when LastName!='' then LastName + ' '  else '' End)) AS [Employee Name],ID," +
            "(SELECT DesignationName FROM tbl_Employee_DesignationMaster AS Desg WHERE (SlNo = emp.DesgId)) AS DesignationName,"+
            "(SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = emp.Location_id)) AS Location FROM tbl_Employee_Mast AS emp " + opt + " ORDER BY ID";
            DataTable dt = clsDataAccess.RunQDTbl(str);
             
             if (dt.Rows.Count > 0)
             {
                 cmbEmp.LookUpTable = dt;
                 cmbEmp.ReturnIndex = 1;
             }              
        
        }
        private void load(string eid)
        {
            
            DataTable dt = clsDataAccess.RunQDTbl("SELECT * FROM tbl_Employee_Mast AS emp WHERE (ID ='" + eid + "')");

            if (dt.Rows.Count > 0)
            {
                cmbStaus.SelectedItem = dt.Rows[0]["status"];
                lblStatus_old.Text = dt.Rows[0]["status"].ToString();
            }
            DataTable dt1 = clsDataAccess.RunQDTbl("select sid,sdate,ucode,reason from [tbl_statuslog] where eid='" + eid + "' order by slid");
            dgvEmployee.DataSource = dt1;
        }

        private void cmbEmp_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            eid = "";
           
            if (cmbEmp.ReturnValue.Trim() != "")
            {
                eid = Convert.ToString(cmbEmp.ReturnValue);

                load(eid);
            }
        }
        
        private void frmStatusLog_Load(object sender, EventArgs e)
        {
            DataTable dt_status = clsDataAccess.RunQDTbl("SELECT sid,status FROM tbl_StatusMst");
            cmbStaus.DataSource = dt_status;
            cmbStaus.DisplayMember = "status";
            cmbStaus.ValueMember = "sid";

            DataTable dta = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code ");
            if (dta.Rows.Count == 1)
            {
                cmbcompany.Text = dta.Rows[0][0].ToString();

                coid = Convert.ToString(dta.Rows[0][1].ToString());
                cmbcompany.ReturnValue = coid;
                cmbcompany.Enabled = false;

            }
            else if (dta.Rows.Count > 1)
            {
                cmbcompany.PopUp();
            }
           
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
        }

        private void cmbLoc_DropDown(object sender, EventArgs e)
        {
            opt = ""; coid = ""; locid = "";
            if (cmbcompany.ReturnValue.Trim() != "")
                coid = Convert.ToString(cmbcompany.ReturnValue);

            if (coid.Trim() != "")
            {
                opt = "Select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in(select Location_ID from Companywiseid_Relation where Company_ID='" + coid + "' )";
            }
          
            else
            {
                opt = "Select Location_Name,Location_ID from tbl_Emp_Location ";
            }

            DataTable dt = clsDataAccess.RunQDTbl(opt);
            if (dt.Rows.Count > 0)
            {
                cmbLoc.LookUpTable = dt;
                cmbLoc.ReturnIndex = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblStatus_old.Text.Trim() != cmbStaus.SelectedValue.ToString().Trim())
            {
                _active = "0";
                //edpcon.Open();
                opt = "insert into [tbl_statuslog](slid,eid,sid,sdate,ucode,reason) values ((select max(slid)+1 from tbl_statuslog),'" + eid.Trim() +
                         "','" + cmbStaus.SelectedValue.ToString().Trim() + "','" + dtpStatus.Value.ToString("dd/MMM/yyyy") + "','" + edpcom.UserDesc + "','"+ txtRemarks.Text.Trim() +"')";
                clsDataAccess.RunQry(opt);
                opt = "";
                if (cmbStaus.SelectedValue.ToString().Trim() != "1")
                {
                    _active = "0";
                }

                opt = "update tbl_Employee_Mast set active ='" + _active + "',status='" + cmbStaus.SelectedValue.ToString() + "' where (ID='" + eid.Trim() + "')";
                clsDataAccess.RunQry(opt);
                opt = "";
                MessageBox.Show("Employee Status Changed.", "BRAVO");
                load(eid);
            }
            else
            {
                MessageBox.Show("Status is same.No Changes Made.", "BRAVO");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            load("0");
            txtRemarks.Text = "";
            //cmbcompany.ReturnValue = "";
            //cmbcompany.Text = "";
            cmbStaus.SelectedValue = 1;
            lblStatus_old.Text = "";
            cmbLoc.Text = "";
            cmbLoc.ReturnValue = "";
            cmbEmp.Text = "";
            cmbEmp.ReturnValue = "";
        }
    }
}
