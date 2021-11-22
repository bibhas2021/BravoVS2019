using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Collections;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmPf_locWise : Form
    {
        public frmPf_locWise()
        {
            InitializeComponent();
        }

        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        string sql = "", Item_Code = "", Locations = "";
        Int32 Company_id=1;

        public void pf()
        {
            dgPfContribution.Rows.Clear();
            if (dgPfContribution.Rows.Count > 1)
            {
                dgPfContribution.Columns["CSlNo"].Visible = false;

            }
            else
            {
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows.Add();
                dgPfContribution.Rows[0].Cells["Cfull"].Value = "A/C 01";
                dgPfContribution.Rows[1].Cells["Cfull"].Value = "A/C 02";
                dgPfContribution.Rows[2].Cells["Cfull"].Value = "A/C 10";
                dgPfContribution.Rows[3].Cells["Cfull"].Value = "A/C 21";
                dgPfContribution.Rows[4].Cells["Cfull"].Value = "A/C 22";

                dgPfContribution.Rows[0].Cells["CAmount"].Value = "3.67";
                dgPfContribution.Rows[1].Cells["CAmount"].Value = "0.50";
                dgPfContribution.Rows[2].Cells["CAmount"].Value = "8.33";
                dgPfContribution.Rows[3].Cells["CAmount"].Value = "0.50";
                dgPfContribution.Rows[4].Cells["CAmount"].Value = "0.00";


                dgPfContribution.Rows[0].Cells["CGlcode"].Value = "1";
                dgPfContribution.Rows[1].Cells["CGlcode"].Value = "2";
                dgPfContribution.Rows[2].Cells["CGlcode"].Value = "1";
                dgPfContribution.Rows[3].Cells["CGlcode"].Value = "2";
                dgPfContribution.Rows[4].Cells["CGlcode"].Value = "2";

            }
        }
        public void clr()
        {
            DataTable dt = clsDataAccess.RunQDTbl("select distinct l.Location_ID,l.Location_Name +' - '+ (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l ,Companywiseid_Relation r where  (l.Location_ID in (select distinct locid from tbl_loc_contribution)) order by l.Location_ID");

            dgvLocation.DataSource = dt;


            lstLog.Items.Clear();
        }
        private void frmPf_locWise_Load(object sender, EventArgs e)
        {
            cmbcompany.PopUp();

            clr();
        }

        private void btnloc_Click(object sender, EventArgs e)
        {
            sql = "select l.Location_Name,l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l ,Companywiseid_Relation r where  l.Location_ID =r.Location_ID and (company_ID='" + cmbcompany.ReturnValue + "') and (isNUll(r.remit_pfesi,0)=0)";
            EDPCommon.MLOV_EDP(sql, "Tag Item", "Select Location", "Select Location", 0, "CMPN", 0);
            arr.Clear();
            arr = EDPCommon.arr_mod;
            lstLog.Items.Clear();
            if (arr.Count > 0)
            {
                getcode.Clear();
                arr = EDPCommon.arr_mod;
                getcode = EDPCommon.get_code;
                
                Item_Code = "";

                for (int i = 0; i <= (arr.Count - 1); i++)
                {
                    lstLog.Items.Add(getcode[i].ToString()); 
                    Item_Code = Item_Code + getcode[i].ToString();
                    if (i != getcode.Count - 1)
                    {
                        Item_Code = Item_Code + ",";
                    }
                }
                Locations = Item_Code;
                btnContributeSave.Enabled=true;
            }
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by co_code");
            if (dt.Rows.Count == 1)
            {
                Company_id=Convert.ToInt32(dt.Rows[0]["co_code"].ToString());
                cmbcompany.Text=dt.Rows[0]["co_name"].ToString();
                if (rdbPf.Checked == true)
                {
                    pf();
                }
            }
            else if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                
            }

        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
                if (rdbPf.Checked == true)
                {
                    pf();
                }
            }
        }

        private void btnContributeSave_Click(object sender, EventArgs e)
        {
            if (lstLog.Items.Count>0)
            {
              if (dgPfContribution.Rows.Count > 1)
                {
                    String strSlNo = "", strFull = "", strShort = "", strAmount="",qry="";
                    int locid = 0;
                    bool bl = false;

                for (int ind = 0; ind < lstLog.Items.Count; ind++)
                {
                    locid = 0;
                   
                    locid = Convert.ToInt32(lstLog.Items[ind].ToString());

                    qry = "delete from tbl_loc_contribution where (locid='" + locid + "')";
                    clsDataAccess.RunNQwithStatus(qry);
                    strSlNo = ""; strFull = ""; strShort = ""; strAmount = "";

                        for (Int32 i = 0; i <= dgPfContribution.Rows.Count - 1; i++)
                        {   
                             strSlNo = Convert.ToString(dgPfContribution.Rows[i].Cells["CGlcode"].Value);
                             strFull = Convert.ToString(dgPfContribution.Rows[i].Cells["Cfull"].Value);
                             //strShort = Convert.ToString(dgPfContribution.Rows[i].Cells["ecshort"].Value);
                             if (strAmount.Trim() == "")
                             {
                                 strAmount = Convert.ToString(dgPfContribution.Rows[i].Cells["CAmount"].Value);
                             }
                             else
                             {
                                 strAmount = strAmount + "," + Convert.ToString(dgPfContribution.Rows[i].Cells["CAmount"].Value);
                             }
                        }
                         qry = "insert into tbl_loc_contribution(locid,type ,ecdt,ac01,ac02,ac10 ,ac21,ac22)values " +
                                    "(" + locid + "," + strSlNo + ",'" + dtpDate.Value.ToString("dd/MMM/yyyy") + "'," + strAmount + ")";
                       bl= clsDataAccess.RunNQwithStatus(qry);

                    }

                if (bl == true)
                {
                    MessageBox.Show("Record Inserted", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    btnContributeSave.Enabled = false;
                    clr();
                }
                else
                {
                    MessageBox.Show("Record Failed", "Bravo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btnContributeSave.Enabled = true;
                }
                }
            }
        }
    }
}
