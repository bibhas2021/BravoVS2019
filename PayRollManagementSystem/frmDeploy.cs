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
    
    public partial class frmDeploy : Form
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        public frmDeploy()
        {
            InitializeComponent();
        }
        public void clear()
        {
            cmb_reason.Text = "";
            lbl_reason.Text = "0";
            
            CmbEmpId.Text = "";
            lbl_eid.Text = "0";
            
            cmbemp_against.Text = "";
            txt_againstFather.Text = "";
            txt_againstRank.Text = "";
            lbl_eid_from.Text = "0";

            cmbLocation.Text = "";
            lbl_loc.Text = "0";

            txtClient.Text = "";lbl_clid.Text="0";lbl_cl_add.Text="";
            lbl_coid.Text="0";lbl_co_add.Text="";lblcomp.Text="";
            cmbMemo.Text = vno().ToString("000");

            dtpDOI.Value = System.DateTime.Today;
            dtp_wef.Value = System.DateTime.Today;

            txtDesg.Text = "";
            txtFather.Text = "";
            txtPan.Text = "";
            txtEsi.Text = "";
            txtPf.Text = "";
            txtUan.Text = "";
            txtAadhar.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;

            cmbAuthName.Text = "";
            txtAuthContact.Text = "";
            txtAuthCode.Text = "";

            
        }


        public void print_v2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("memo", typeof(System.String));
            dt.Columns.Add("comp", typeof(System.String));
            dt.Columns.Add("comp_add", typeof(System.String));
            dt.Columns.Add("client", typeof(System.String));
            dt.Columns.Add("cl_add", typeof(System.String));
            dt.Columns.Add("location", typeof(System.String));
            dt.Columns.Add("ecode", typeof(System.String));
            dt.Columns.Add("ename", typeof(System.String));
            dt.Columns.Add("fname", typeof(System.String));
            dt.Columns.Add("pf", typeof(System.String));
            dt.Columns.Add("esi", typeof(System.String));
            dt.Columns.Add("uan", typeof(System.String));
            dt.Columns.Add("aadhar", typeof(System.String));
            dt.Columns.Add("pan", typeof(System.String));
            dt.Columns.Add("edate", typeof(System.String));
            dt.Columns.Add("wef", typeof(System.String));
            dt.Columns.Add("inplace", typeof(System.String));
            dt.Columns.Add("reason", typeof(System.String));
            dt.Columns.Add("designation", typeof(System.String));
            dt.Columns.Add("emcod", typeof(System.String));
            dt.Columns.Add("Designation", typeof(System.String));
            dt.Columns.Add("fN", typeof(System.String));
            dt.Columns.Add("eaucod", typeof(System.String));
            dt.Columns.Add("contact", typeof(System.String));
            dt.Columns.Add("eauname", typeof(System.String));
            dt.Columns.Add("Desig", typeof(System.String));

            dt.Columns.Add("ena", typeof(System.String));

            dt.Columns.Add("Empsign", typeof(System.Byte[]));
            dt.Columns.Add("Authsign", typeof(System.Byte[]));


            int ind = 0;
            dt.Rows.Add();

            dt.Rows[ind]["memo"] = cmbMemo.Text.Trim();
            dt.Rows[ind]["comp"] = lblcomp.Text.Trim();
            dt.Rows[ind]["comp_add"] = lbl_co_add.Text.Trim();
            dt.Rows[ind]["client"] = txtClient.Text.Trim();
            dt.Rows[ind]["cl_add"] = lbl_cl_add.Text.Trim();
            dt.Rows[ind]["location"] = cmbLocation.Text.Trim();
            dt.Rows[ind]["ecode"] = lbl_eid.Text.Trim();
            dt.Rows[ind]["ename"] = CmbEmpId.Text.Trim();
            dt.Rows[ind]["fname"] = txtFather.Text.Trim();
            dt.Rows[ind]["pf"] = txtPf.Text.Trim();
            dt.Rows[ind]["esi"] = txtEsi.Text.Trim();
            dt.Rows[ind]["uan"] = txtUan.Text.Trim();
            dt.Rows[ind]["aadhar"] = txtAadhar.Text.Trim();
            dt.Rows[ind]["pan"] = txtPan.Text.Trim();
            dt.Rows[ind]["edate"] = dtpDOI.Value.ToString("dd/MM/yyyy");
            dt.Rows[ind]["wef"] = dtp_wef.Value.ToString("dd/MM/yyyy");
            dt.Rows[ind]["inplace"] = cmbemp_against.Text.Trim();
            dt.Rows[ind]["reason"] = cmb_reason.Text.Trim();
            dt.Rows[ind]["Designation"] = txtDesg.Text.Trim();
            dt.Rows[ind]["emcod"] = lbl_eid_from.Text.Trim();
            dt.Rows[ind]["Desig"] = txt_againstRank.Text.Trim();
            dt.Rows[ind]["fN"] = txt_againstFather.Text.Trim();
            dt.Rows[ind]["eaucod"] = txtAuthCode.Text.Trim();
            dt.Rows[ind]["eauname"] = cmbAuthName.Text.Trim();
            dt.Rows[ind]["contact"] = txtAuthContact.Text.Trim();
            dt.Rows[ind]["ena"] = cmbemp_against.Text.Trim();
            DataTable dtimg= clsDataAccess.RunQDTbl("SELECT sign FROM tbl_employee_fscan where (ID='"+ lbl_eid.Text.Trim()  +"')");
            try
            {
                dt.Rows[ind]["Empsign"] = dtimg.Rows[0]["sign"];
            }
            catch { }
            dtimg = clsDataAccess.RunQDTbl("SELECT sign FROM tbl_employee_fscan where (ID='" + txtAuthCode.Text.Trim() + "')");

            try
            {
                dt.Rows[ind]["Authsign"] = dtimg.Rows[0]["sign"];
            }
            catch
            {

            }

            string lblprepb = edpcom.UserDesc;
            MidasReport.Form1 f1 = new MidasReport.Form1();
            f1.md_lis1(dt, lblprepb, 0);
            f1.ShowDialog();


        }

        public void print()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("memo", typeof(System.String));
            dt.Columns.Add("comp", typeof(System.String));
            dt.Columns.Add("comp_add", typeof(System.String));
            dt.Columns.Add("client", typeof(System.String));
            dt.Columns.Add("cl_add", typeof(System.String));
            dt.Columns.Add("location", typeof(System.String));
            dt.Columns.Add("ecode", typeof(System.String));
            dt.Columns.Add("ename", typeof(System.String));
            dt.Columns.Add("fname", typeof(System.String));
            dt.Columns.Add("pf", typeof(System.String));
            dt.Columns.Add("esi", typeof(System.String));
            dt.Columns.Add("uan", typeof(System.String));
            dt.Columns.Add("aadhar", typeof(System.String));
            dt.Columns.Add("pan", typeof(System.String));
            dt.Columns.Add("edate", typeof(System.String));
            dt.Columns.Add("wef", typeof(System.String));
            dt.Columns.Add("inplace", typeof(System.String));
            dt.Columns.Add("reason", typeof(System.String));
            dt.Columns.Add("designation", typeof(System.String));


            int ind = 0;
            dt.Rows.Add();

            dt.Rows[ind]["memo"]= cmbMemo.Text.Trim();
                          dt.Rows[ind]["comp"]= lblcomp.Text.Trim();
                          dt.Rows[ind]["comp_add"]= lbl_co_add.Text.Trim();
                         dt.Rows[ind]["client"]= txtClient.Text.Trim();
                         dt.Rows[ind]["cl_add"]= lbl_cl_add.Text.Trim();
                        dt.Rows[ind]["location"]= cmbLocation.Text.Trim();
                         dt.Rows[ind]["ecode"]= lbl_eid.Text.Trim();
                         dt.Rows[ind]["ename"]= CmbEmpId.Text.Trim();
                         dt.Rows[ind]["fname"]= txtFather.Text.Trim();
                          dt.Rows[ind]["pf"]= txtPf.Text.Trim();
                         dt.Rows[ind]["esi"]= txtEsi.Text.Trim();
                         dt.Rows[ind]["uan"]= txtUan.Text.Trim();
                         dt.Rows[ind]["aadhar"]= txtAadhar.Text.Trim();
                          dt.Rows[ind]["pan"]= txtPan.Text.Trim();
                          dt.Rows[ind]["edate"]= dtpDOI.Value.ToString("dd/MM/yyyy");
                          dt.Rows[ind]["wef"] = dtp_wef.Value.ToString("dd/MM/yyyy");
                         dt.Rows[ind]["inplace"]= cmbemp_against.Text.Trim();
                         dt.Rows[ind]["reason"] = cmb_reason.Text.Trim();
                         dt.Rows[ind]["designation"] = txtDesg.Text.Trim();
                  //------------------------------------------------------------------------------       
            ind ++;
                         dt.Rows.Add();

                         dt.Rows[ind]["memo"] = cmbMemo.Text.Trim();
                         dt.Rows[ind]["comp"] = lblcomp.Text.Trim();
                         dt.Rows[ind]["comp_add"] = lbl_co_add.Text.Trim();
                         dt.Rows[ind]["client"] = txtClient.Text.Trim();
                         dt.Rows[ind]["cl_add"] = lbl_cl_add.Text.Trim();
                         dt.Rows[ind]["location"] = cmbLocation.Text.Trim();
                         dt.Rows[ind]["ecode"] = lbl_eid.Text.Trim();
                         dt.Rows[ind]["ename"] = CmbEmpId.Text.Trim();
                         dt.Rows[ind]["fname"] = txtFather.Text.Trim();
                         dt.Rows[ind]["pf"] = txtPf.Text.Trim();
                         dt.Rows[ind]["esi"] = txtEsi.Text.Trim();
                         dt.Rows[ind]["uan"] = txtUan.Text.Trim();
                         dt.Rows[ind]["aadhar"] = txtAadhar.Text.Trim();
                         dt.Rows[ind]["pan"] = txtPan.Text.Trim();
                         dt.Rows[ind]["edate"] = dtpDOI.Value.ToString("dd/MM/yyyy");
                         dt.Rows[ind]["wef"] = dtp_wef.Value.ToString("dd/MM/yyyy");
                         dt.Rows[ind]["inplace"] = cmbemp_against.Text.Trim();
                         dt.Rows[ind]["reason"] = cmb_reason.Text.Trim();
                         dt.Rows[ind]["designation"] = txtDesg.Text.Trim();


                         MidasReport.Form1 f1 = new MidasReport.Form1();
                         f1.md_lis(dt, 0);
                         f1.ShowDialog();



        }

        public int vno()
        {

            return Convert.ToInt32(clsDataAccess.GetresultS("select isnull(max(oid),0)+1 from tbl_allotement_order"));

        }
        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
            string sql = "";
            if (chkAllLocation.Checked == true)
            {
                sql = "select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ") and (zid='" + cmbZone.ReturnValue.Trim() + "')";
            }
            else
            {
                sql = "select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID in (" + edpcom.CurrentLocation + ")";
            }
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;
            }
            else
            {
                cmbLocation.LookUpTable = dt;
                cmbLocation.ReturnIndex = 1;

            }
        }
        string Locations, company_Id;
        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
                Locations = Convert.ToString(cmbLocation.ReturnValue);
            
            if (Information.IsNumeric(Locations) == false)
                Locations = "0";

            lbl_loc.Text = Locations;
            company_Id = clsEmployee.GetCompany_ID(Convert.ToInt32(Locations)).ToString();
            DataTable dt=  clsDataAccess.RunQDTbl("SELECT Client_Name,client_id,isNull(coid,1)coid FROM tbl_Employee_CliantMaster where client_id=(select distinct Cliant_ID from tbl_Emp_Location where Location_ID='" + Locations + "')");
            cmbLocation.Text = clsDataAccess.GetresultS("select Location_Name from tbl_Emp_Location where (Location_ID='" + Locations + "')");
            if (dt.Rows.Count>0){
            txtClient.Text = dt.Rows[0]["Client_Name"].ToString();
            lbl_clid.Text = dt.Rows[0]["client_id"].ToString();
            lbl_coid.Text = dt.Rows[0]["coid"].ToString();

            lbl_cl_add.Text = clsDataAccess.GetresultS("select c.Client_ADD1  from tbl_Employee_CliantMaster c where (c.Client_id='"+ lbl_clid.Text +"')");
            lbl_co_add.Text = clsDataAccess.GetresultS("select c.CO_ADD+'\n\r'+c.CO_ADD1  from Company c where (c.CO_CODE='" + lbl_coid.Text + "')");
            lblcomp.Text = clsDataAccess.GetresultS("select c.co_name  from Company c where (c.CO_CODE='" + lbl_coid.Text + "')");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDeploy_Load(object sender, EventArgs e)
        {
            clsGeneralShow genralshow = new clsGeneralShow();
            clear();
            genralshow.getCurLocID();
        }
        //"SELECT ID as eid,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
        //    "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
        //    "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename," +
        //    "(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as edesg," +
        //    "((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN ltrim(rtrim(em.FathFN)) + ' ' ELSE '' END)+" +
        //    "(CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ltrim(rtrim(em.FathMN)) + ' ' ELSE '' END) +" +
        //    "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ltrim(rtrim(em.FathLN)) + ' ' ELSE '' END)) as fname," +
        private void CmbEmpId_DropDown(object sender, EventArgs e)
        {
            string sql = "SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
            "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename,ID as eid " +
            " FROM tbl_Employee_Mast em where status=1";
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                CmbEmpId.LookUpTable = dt;
                CmbEmpId.ReturnIndex = 1;
            }
        }

        private void cmbemp_against_DropDown(object sender, EventArgs e)
        {
            string sql = "SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
            "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename,ID as eid " +
            " FROM tbl_Employee_Mast em where (status=1) and (id!='" + lbl_eid.Text + "') and (Location_id='"+ lbl_loc.Text +"')";
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                cmbemp_against.LookUpTable = dt;
                cmbemp_against.ReturnIndex = 1;
            }
        }

        private void cmb_reason_DropDown(object sender, EventArgs e)
        {
            string sql = "select reason,rid from tbl_allotement_reason";
                 DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                cmb_reason.LookUpTable = dt;
                cmb_reason.ReturnIndex = 1;
            }
        }

        private void CmbEmpId_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            lbl_eid.Text = CmbEmpId.ReturnValue;

            string str = "select ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
            "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename,(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as 'designation'," +
            "((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN ltrim(rtrim(em.FathFN)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ltrim(rtrim(em.FathMN)) + ' ' ELSE '' END) +" +
            "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ltrim(rtrim(em.FathLN)) + ' ' ELSE '' END)) as 'fname'," +
            "PANno,aadhar,PF, ESIno, PassportNo as 'Uan' from tbl_Employee_Mast em WHERE (ID ='"+ lbl_eid.Text +"')";

            DataTable dt = clsDataAccess.RunQDTbl(str);

            if (dt.Rows.Count > 0)
            {
                txtAadhar.Text = dt.Rows[0]["aadhar"].ToString();
                txtEsi.Text = dt.Rows[0]["ESIno"].ToString();
                txtPf.Text = dt.Rows[0]["PF"].ToString();
                txtUan.Text = dt.Rows[0]["Uan"].ToString();
                    txtPan.Text = dt.Rows[0]["PANno"].ToString();
                    txtFather.Text = dt.Rows[0]["fname"].ToString();
                    txtDesg.Text = dt.Rows[0]["designation"].ToString();

                    CmbEmpId.Text = dt.Rows[0]["ename"].ToString();

            }

        }

        private void cmbemp_against_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            lbl_eid_from.Text = cmbemp_against.ReturnValue;

            if (lbl_eid_from.Text.Trim() == "")
            { }
            else
            {
                string str = "select ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
             "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
             "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename,(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as 'designation'," +
             "((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN ltrim(rtrim(em.FathFN)) + ' ' ELSE '' END)+" +
             "(CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ltrim(rtrim(em.FathMN)) + ' ' ELSE '' END) +" +
             "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ltrim(rtrim(em.FathLN)) + ' ' ELSE '' END)) as 'fname'," +
             "PANno,aadhar,PF, ESIno, PassportNo as 'Uan',phone,mobile from tbl_Employee_Mast em WHERE (ID ='" + lbl_eid_from.Text + "')";

                DataTable dt = clsDataAccess.RunQDTbl(str);
                if (dt.Rows.Count > 0)
                {
                    cmbemp_against.Text = dt.Rows[0]["ename"].ToString();
                    txt_againstFather.Text = dt.Rows[0]["fname"].ToString();
                    txt_againstRank.Text = dt.Rows[0]["designation"].ToString();


                }
            }
        }

        private void cmbMemo_DropDown(object sender, EventArgs e)
        {
            string str = "select oid,cdate,(SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
            "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
            "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename" +
            " FROM tbl_Employee_Mast em where (id=tao.eaid))as 'Assigned Employee', (select Location_Name from tbl_Emp_location where Location_ID=tao.locid) as Location from tbl_allotement_order tao";
            DataTable dt = clsDataAccess.RunQDTbl(str);
            if (dt.Rows.Count > 0)
            {
                cmbMemo.LookUpTable = dt;
                cmbMemo.ReturnIndex = 0;
            }
        }

        private void cmb_reason_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            lbl_reason.Text = cmb_reason.ReturnValue;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = "INSERT INTO tbl_allotement_order" +
                         "(oid, eaid, erid, wef, reason, locid, clid, coid, cdate, cmonth,authcode)" +
                       " VALUES ('" + Convert.ToInt32(cmbMemo.Text) + "','" + lbl_eid.Text.Trim() + "','" + 
                       lbl_eid_from.Text.Trim() + "','" + dtp_wef.Value.ToString("dd/MMM/yyyy") +
                       "','" + cmb_reason.Text + "','" + lbl_loc.Text + "','" + lbl_clid.Text + "','" + 
                       lbl_coid.Text + "','" + dtpDOI.Value.ToString("dd/MMM/yyyy") + "','" + dtpDOI.Value.ToString("MMMM,yyyy") + "','"+ txtAuthCode.Text.Trim() +"')";

          bool bl=  clsDataAccess.RunQry(str);
          if (bl == true)
          {
              MessageBox.Show("Details Submitted Successfully.", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Information);
              print_v2();
              //print();
              clear();
          }
          else
          {
              ERPMessageBox.ERPMessage.Show("Please Check details.","BRAVO",MessageBoxButtons.OK, MessageBoxIcon.Information);
          }

        }

        private void cmbMemo_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            string memo = cmbMemo.ReturnValue;
            try
            {
            //  memo=Convert.ToInt32(cmbMemo.ReturnValue).ToString("000");
            }
            catch { memo = ""; }
            
            if (memo.Trim() == "") { }
            else
            {
                string qry = "SELECT oid, eaid, erid, wef, reason, locid, clid, coid, cdate, cmonth,authcode FROM tbl_allotement_order where (oid='" + memo + "')";

                DataTable dt = clsDataAccess.RunQDTbl(qry);

                if (dt.Rows.Count > 0)
                {
                    cmbMemo.Text = Convert.ToInt32(dt.Rows[0]["oid"].ToString()).ToString("000");
                    lbl_loc.Text= dt.Rows[0]["locid"].ToString();
                    lbl_clid.Text = dt.Rows[0]["clid"].ToString();
                    cmbLocation.ReturnValue= lbl_loc.Text;
                    lbl_coid.Text = dt.Rows[0]["coid"].ToString();
                    cmb_reason.Text = dt.Rows[0]["reason"].ToString();
                    lbl_eid_from.Text = dt.Rows[0]["erid"].ToString();
                    
                    dtp_wef.Value =Convert.ToDateTime(dt.Rows[0]["wef"]);
                    dtpDOI.Value = Convert.ToDateTime(dt.Rows[0]["cdate"]);
                    lbl_eid.Text = dt.Rows[0]["eaid"].ToString();
                    txtAuthCode.Text = dt.Rows[0]["authcode"].ToString();


                    cmbAuthName.ReturnValue = txtAuthCode.Text;
                    cmbLocation.ReturnValue = lbl_loc.Text;
                    cmbemp_against.ReturnValue = lbl_eid_from.Text;
                    CmbEmpId.ReturnValue = lbl_eid.Text;
                    
                    cmbLocation_CloseUp(sender, e);
                    CmbEmpId_CloseUp(sender, e);
                    cmbemp_against_CloseUp(sender, e);
                    cmbAuthName_CloseUp(sender, e);
                    btnSave.Enabled = false;
                    btnDelete.Enabled = true;
                    btnDelete.Visible = true;
                }
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //print();
            print_v2();
        }

        private void cmbAuthName_DropDown(object sender, EventArgs e)
        {
            string sql = "SELECT ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
           "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
           "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename,ID as eid " +
           " FROM tbl_Employee_Mast em where (status=1) and (id!='" + lbl_eid.Text + "')";
            DataTable dt = clsDataAccess.RunQDTbl(sql);
            if (dt.Rows.Count > 0)
            {
                cmbAuthName.LookUpTable = dt;
                cmbAuthName.ReturnIndex = 1;
            }
        }

        private void cmbAuthName_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            txtAuthCode.Text = cmbemp_against.ReturnValue;
            txtAuthContact.Text = "";
            if (txtAuthCode.Text.Trim() == "")
            { }
            else
            {
                string str = "select ((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN ltrim(rtrim(em.FirstName)) + ' ' ELSE '' END)+" +
             "(CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN ltrim(rtrim(em.MiddleName)) + ' ' ELSE '' END) +" +
             "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN ltrim(rtrim(em.LastName)) + ' ' ELSE '' END)) as ename,(Select distinct([DesignationName]) from [tbl_Employee_DesignationMaster] where ([SlNo]=em.Desgid))as 'designation'," +
             "((CASE WHEN ltrim(rtrim(em.FathFN)) != '' THEN ltrim(rtrim(em.FathFN)) + ' ' ELSE '' END)+" +
             "(CASE WHEN ltrim(rtrim(em.FathMN)) != '' THEN ltrim(rtrim(em.FathMN)) + ' ' ELSE '' END) +" +
             "(CASE WHEN ltrim(rtrim(em.FathLN)) != '' THEN ltrim(rtrim(em.FathLN)) + ' ' ELSE '' END)) as 'fname'," +
             "PANno,aadhar,PF, ESIno, PassportNo as 'Uan',phone,Mobile from tbl_Employee_Mast em WHERE (ID ='" + txtAuthCode.Text + "')";

                DataTable dt = clsDataAccess.RunQDTbl(str);
                if (dt.Rows.Count > 0)
                {
                   cmbAuthName.Text = dt.Rows[0]["ename"].ToString();
                   
                    if (dt.Rows[0]["phone"].ToString().Trim() != "0" && dt.Rows[0]["phone"].ToString().Trim() != "")
                    {
                        txtAuthContact.Text = dt.Rows[0]["phone"].ToString().Trim();
                    }
                    if (dt.Rows[0]["Mobile"].ToString().Trim() != "0" && dt.Rows[0]["Mobile"].ToString().Trim() != "")
                    {
                        if (txtAuthContact.Text.Trim() != "")
                        {
                            txtAuthContact.Text = txtAuthContact.Text + " / ";
                        }
                        txtAuthContact.Text = txtAuthContact.Text + dt.Rows[0]["Mobile"].ToString().Trim();
                    }


                }
            }
        }
    }
}
