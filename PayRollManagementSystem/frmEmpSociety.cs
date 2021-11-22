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
    public partial class frmEmpSociety : Form
    {
        int Co_ID=0, Location_ID=0;
        string sql = "";
        //bool bl = false;
        public frmEmpSociety()
        {
            InitializeComponent();
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            //Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 0)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbCompany.ReturnValue) == true)
                Co_ID = Convert.ToInt32(CmbCompany.ReturnValue);
       
        }

        private void btnClear_Loan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("SELECT  Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL");
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Location_ID = Convert.ToInt32(cmbLocation.ReturnValue);

           
            getdata();
            cmbLocation.Text = cmbLocation.Text + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + Location_ID);
        }


        public void getdata()
        {
            string qry = "";
            DataTable dt_soc = new DataTable();
            qry = "select em.ID,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + "+
         "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END))'ename',ISnULL((select (case when soc_amt>0 then soc_amt else 200 end ) from society where eid=em.ID),200) as societyemi,"+
           "ISnULL((select (case when opn_bal>0 then opn_bal else 0 end ) from society where eid=em.ID),0) as opn_bal,"+
           "ISnULL((select (case when curr_bal>0 then curr_bal else 0 end ) from society where eid=em.ID),0) as curr_bal,"+
           "ISnULL((select acc_no from society where eid=em.ID),'') as acc_no  "+
            "from tbl_Employee_Mast  em where (em.Location_id='" + Location_ID + "') and (em.Company_id='" + Co_ID + "')";
            dt_soc = clsDataAccess.RunQDTbl(qry);

            dgv_show.DataSource = dt_soc;
            
           
            dgv_show.Columns["ID"].ReadOnly = true;
            dgv_show.Columns["EmployeeName"].ReadOnly = true;
        }

        private void BtnEmp_Loan_Click(object sender, EventArgs e)
        {
            string eid = "", ename = "", sdate = "",pre_dt="", acc = "";

            int cid = 0, lid = 0;
            double soc = 0, opb = 0, cb = 0;
            bool bl = false;


            for (int ind = 0; ind < dgv_show.Rows.Count; ind++)
            {
                eid = dgv_show.Rows[ind].Cells["ID"].Value.ToString();
                ename = dgv_show.Rows[ind].Cells["EmployeeName"].Value.ToString();
                cid = Co_ID;
                lid = Location_ID;
                soc = Convert.ToDouble(dgv_show.Rows[ind].Cells["societyemi"].Value);
                opb = Convert.ToDouble(dgv_show.Rows[ind].Cells["opn_bal"].Value);
                cb = Convert.ToDouble(dgv_show.Rows[ind].Cells["curr_bal"].Value);
                sdate = dtmMonthSelect.Value.ToString("dd/MMM/yyyy");
                acc = dgv_show.Rows[ind].Cells["acc_no"].Value.ToString();
                try
                {
                    pre_dt = clsDataAccess.GetresultS("select max(eff_date) from society where eid='" + eid + "'");

                    if (pre_dt.Trim() == "")
                    {

                        pre_dt = "01/01/1900";
                    }
                }
                catch
                {
                    pre_dt = "01/01/1900";
                }
                if (Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from society where eid='" + eid + "'and eff_date='" + sdate + "'")) > 0)
                {

                    sql = "update society set soc_amt='" + soc + "',opn_bal='" + opb + "',curr_bal='" + cb + "' where eid='" + eid + "' and loc_id='" + lid + "'and co_id='" + cid + "'";
                    bl = clsDataAccess.RunNQwithStatus(sql);

                }

                else if (Convert.ToDateTime(sdate) > Convert.ToDateTime(pre_dt))
                {

                    sql = "insert into society(eid,soc_amt,loc_id,co_id,opn_bal,curr_bal,eff_date,acc_no)values('" + eid + "','" + soc + "','" + lid + "','" + cid + "','" + opb + "','" + cb + "','" + sdate + "','" + acc + "')";
                    bl = clsDataAccess.RunNQwithStatus(sql);
                }

                //if ((bl == true) && (soc != 200))
                //{
                //    sql = "update society set soc_amt='"+soc+"'where eid='"+eid+"'and loc_id='"+lid+"'and co_id='"+cid+"'";
                //    bl = clsDataAccess.RunQry(sql);
                //}


            }
            if (bl == false)
            {
                MessageBox.Show("record not inserted...","BRAVO",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(bl==true)
            {
                MessageBox.Show("Record inserted successfully", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Boolean SubmitDetails( string eid, string ename, int cid, int lid, double soc )
        {
            bool bl = clsDataAccess.RunNQwithStatus("insert into society(eid,ename,soc_amt,loc_id,co_id)values('" + eid + "','" + ename + "','" + soc + "','" + lid + "','" + cid + "'");

            return bl;
        }

        private void dgv_show_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //BtnEmp_Loan.Text = "update";
            
        }
    }
}
