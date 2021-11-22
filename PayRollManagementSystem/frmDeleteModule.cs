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
    public partial class frmDeleteModule : Form
    {
        public frmDeleteModule()
        {
            InitializeComponent();
        }
        string CoID, Locid, eid,ecode,sql;
        DataTable dt = new DataTable();
        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 1)
            {
                cmbCompany.LookUpTable = dt;
                cmbCompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                cmbCompany.Text = dt.Rows[0]["CO_name"].ToString();
                cmbCompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                CoID = cmbCompany.ReturnValue.ToString().Trim();
                if (CoID.Trim() == "")
                {
                    CoID = "1";
                }
                Locid = "";
                display();

            }

        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            CoID = cmbCompany.ReturnValue.Trim();
            if (CoID.Trim() == "")
            {
                CoID = "1";
            }
            Locid = "";
            display();
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT DISTINCT EL.Location_Name,EL.Location_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName FROM tbl_Employee_Mast EM INNER JOIN tbl_Emp_Location EL ON EM.Location_id = EL.Location_ID WHERE (EM.Company_id =" + CoID + ") ORDER BY EL.Location_ID");
            if (dt.Rows.Count > 1)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                cmbLocation.Text = dt.Rows[0]["Location_Name"].ToString();
                cmbLocation.ReturnValue = dt.Rows[0]["Location_ID"].ToString();
                Locid = cmbLocation.ReturnValue.ToString();
                if (Locid.Trim() == "")
                {
                    Locid = "";
                }
                display();

            }


        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Locid = cmbLocation.ReturnValue;
            if (Locid.Trim() == "")
            {
                Locid = "";
            }
            display();
        }

        private void frmDeleteModule_Load(object sender, EventArgs e)
        {
            CoID = "1";
            Locid = "";
            cmbCompany.PopUp();
        }


        public void display()
        {
            //"SELECT DISTINCT EL.Location_Name,EL.Location_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName FROM tbl_Employee_Mast EM INNER JOIN tbl_Emp_Location EL ON EM.Location_id = EL.Location_ID WHERE (EM.Company_id =" + Co_ID + ") ORDER BY EL.Location_ID"
            if (Locid.Trim() != "")
            {

                sql = "select ID,(CASE WHEN FirstName != '' THEN FirstName + ' ' ELSE '' END) + (CASE WHEN MiddleName != '' THEN MiddleName + ' ' ELSE '' END) + (CASE WHEN LastName != '' THEN LastName + ' ' ELSE '' END) AS 'ename',(select Location_Name from tbl_Emp_Location EL where Location_ID=em.Location_id )Location,Location_id as Locid,Code,(case when em.del=1 then 0 else 1 end) as chk FROM tbl_Employee_Mast EM where (em.Company_id='" + CoID + "') and (em.Location_id='" + Locid + "') and (del=1)";
            }
            else
            {
                sql = "select ID,(CASE WHEN FirstName != '' THEN FirstName + ' ' ELSE '' END) + (CASE WHEN MiddleName != '' THEN MiddleName + ' ' ELSE '' END) + (CASE WHEN LastName != '' THEN LastName + ' ' ELSE '' END) AS 'ename',(select Location_Name from tbl_Emp_Location EL where Location_ID=em.Location_id )Location,Location_id as Locid,Code,(case when em.del=1 then 0 else 1 end) as chk FROM tbl_Employee_Mast EM where (em.Company_id='" + CoID + "') and (del=1)";
            }
            dt = clsDataAccess.RunQDTbl(sql);

            if (dt.Rows.Count > 0)
            {
                dgvView.DataSource = dt;
            }
            
        }

        private bool dRec(string eid,string ecode)
        {
            bool bl=false;

            sql = " update tbl_Employee_Mast set active=0,del=0 where "+ eid;
            bl = clsDataAccess.RunQry(sql);

            return bl;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String chk="0";
            eid = ""; ecode = "";
            for (int idx = 0; idx < dgvView.Rows.Count; idx++)
            {
                chk = Convert.ToString(dgvView.Rows[idx].Cells["colSelect"].Value);
                if (chk.ToLower() == "true" || chk.ToLower() == "1")
                {
                    if (eid.Trim() == "")
                    {
                        eid = " (id='" + Convert.ToString(dgvView.Rows[idx].Cells["colEid"].Value) + "' and Company_id='" + CoID + "' and Location_id='" + Convert.ToString(dgvView.Rows[idx].Cells["colLocid"].Value) + "')";
                        ecode = Convert.ToString(dgvView.Rows[idx].Cells["colCode"].Value);
                    }
                    else
                    {
                        eid = eid + " or (id='" + Convert.ToString(dgvView.Rows[idx].Cells["colEid"].Value) + "' and Company_id='" + CoID + "' and Location_id='" + Convert.ToString(dgvView.Rows[idx].Cells["colLocid"].Value) + "')";
                        ecode = ecode + "," + Convert.ToString(dgvView.Rows[idx].Cells["colCode"].Value);

                    }
                }

            }
            if (eid.Trim() != "")
            {
              bool bl=  dRec(eid, ecode);


              if (bl == true)
              {
                  MessageBox.Show("Selected Record cleared","Bravo");                  
              }
              else
              {
                  MessageBox.Show("Selected Record not cleared", "Bravo");
              }
            }
        }
    }
}
