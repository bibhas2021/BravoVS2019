using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Data.SqlClient;
using FirstTimeNeed;
namespace PayRollManagementSystem
{
    public partial class frm_Mst_Kit : Form
    {

        public frm_Mst_Kit(int tp )
        {

            InitializeComponent();


            if (tp == 1)
            {
                
                this.Text = "Kit Master & Opening Entry";
                tabPage2.Dispose();
            }
            else if (tp == 2)
            {
                this.Text = "Fine Master";
                tabPage1.Dispose();
            }
        }

        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        EDPConnection edpcon;
        SqlCommand sqlcmd;

        string coid = "1";

        DialogView dv = new DialogView();

        DataTable dt = new DataTable();

        private Boolean SubmitDetails()
        {
            edpcon = new EDPConnection();
            Boolean boolStatus = false;
            string  SP_MK = "";
            bool a = true;
            string[] yr = cmbYear.Text.Split('-');
            string msUnit, roUnit, MinStock, roQty, strSlNo, strName, opn, unit, dat;
            double dblVal=0;
           
            if (this.dgv_Kit.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgv_Kit.Rows.Count - 1; i++)
                {
                    strSlNo = Convert.ToString(dgv_Kit.Rows[i].Cells["KTNo"].Value);
                    strName = Convert.ToString(dgv_Kit.Rows[i].Cells["KTNAME"].Value);
                    dblVal = Convert.ToDouble(dgv_Kit.Rows[i].Cells["KTVAL"].Value);
                    opn = Convert.ToString(dgv_Kit.Rows[i].Cells["OpeningStock"].Value);

                    msUnit = Convert.ToString(dgv_Kit.Rows[i].Cells["msUnit"].Value);
                    roUnit = Convert.ToString(dgv_Kit.Rows[i].Cells["roUnit"].Value);
                    MinStock = Convert.ToString(dgv_Kit.Rows[i].Cells["MinStock"].Value);
                    roQty = Convert.ToString(dgv_Kit.Rows[i].Cells["roQty"].Value);
            
                    if (opn == "")
                    { opn = "0"; }
                    unit = Convert.ToString(dgv_Kit.Rows[i].Cells["Unit"].Value);
                    dat="";
                    try
                    {
                        if (dgv_Kit.Rows[i].Cells["date"].Value == null || dgv_Kit.Rows[i].Cells["date"].Value.ToString().Trim() == "")
                        {
                            dat = Convert.ToDateTime("01/April/" + yr[0].Trim()).ToString("dd/MMM/yyyy");
                        }
                        else
                        {
                            dat = Convert.ToDateTime(dgv_Kit.Rows[i].Cells["date"].Value).ToString("dd/MMM/yyyy");
                        }
                    }
                    catch { dat =  Convert.ToDateTime("01/April/"+yr[0].Trim()).ToString("dd/MMM/yyyy"); }
                    String ov = Convert.ToString(dgv_Kit.Rows[i].Cells["OpeningValue"].Value);
                    if (ov == "")
                    { ov = "0"; }

                    edpcon.Open();
                    sqlcmd = new SqlCommand();
                    if (!String.IsNullOrEmpty(strName))
                    {
                        if (!String.IsNullOrEmpty(strSlNo))
                        {
                        //    sqlcmd = new SqlCommand("SP_MSTKIT_IU", edpcon.mycon);
                        //    sqlcmd.CommandType = CommandType.StoredProcedure;
                        //    sqlcmd.CommandTimeout = 0;
                        //    sqlcmd.Parameters.Add("@KTNO", SqlDbType.Int).Value = strSlNo;
                        //    sqlcmd.Parameters.Add("@KTNAME", SqlDbType.NVarChar).Value = strName;
                        //    sqlcmd.Parameters.Add("@KTAMT", SqlDbType.Float).Value = dblVal;
                        //    sqlcmd.Parameters.Add("@OpeningStock", SqlDbType.NVarChar).Value = opn;
                        //    sqlcmd.Parameters.Add("@Unit", SqlDbType.VarChar).Value = unit;
                        //    sqlcmd.Parameters.Add("@Date", SqlDbType.SmallDateTime).Value = dat;
                        //    sqlcmd.Parameters.Add("@OpeningValue", SqlDbType.NVarChar).Value = ov;
                        //    SP_MK = sqlcmd.ExecuteScalar().ToString();
                            if (Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from MSTKIT where (KTID='" + strSlNo + "') and (coid='" + coid + "')")) > 0)
                            {
                                //btnSave.Text = "Update";
                                boolStatus = clsDataAccess.RunNQwithStatus("update MSTKIT set KTNAME='" + strName + "',KTVAL='" + dblVal + "',opn_stock='" + opn + "',unit='" + unit + "',k_date='" + dat + "',opn_value='" + ov + "',msUnit='" + msUnit + "',roUnit='" + roUnit + "',MinStock='" + MinStock + "',roQty='" + roQty + "' where (KTID='" + strSlNo + "') and (sess='" + cmbYear.Text + "') and (coid='" + coid + "')");
                            }
                            else
                            {

                                boolStatus = clsDataAccess.RunNQwithStatus("insert into MSTKIT(KTID,KTNAME,KTVAL,opn_stock,unit,k_date,opn_value,msUnit,roUnit,MinStock,roQty,sess,clstock,clRate,cldate,coid)values('" +
                                strSlNo + "','" + strName + "','" + dblVal + "','" + opn + "','" + unit + "','" + dat + "','" + ov + "','" + msUnit + "','" + roUnit + "','" + MinStock + "','" + roQty + "','" + cmbYear.Text + "','" + opn + "','0','" + dat + "','" + coid + "')");
                            }
                            
                        }
                        else
                        {
                           // sqlcmd = new SqlCommand("SP_MSTKIT_IU", edpcon.mycon);
                           // sqlcmd.CommandType = CommandType.StoredProcedure;
                           // sqlcmd.CommandTimeout = 0;
                           // sqlcmd.Parameters.Add("@KTNO", SqlDbType.Int).Value =0;
                           // sqlcmd.Parameters.Add("@KTNAME", SqlDbType.NVarChar).Value = strName;
                           // sqlcmd.Parameters.Add("@KTAMT", SqlDbType.Float).Value = dblVal;
                           // sqlcmd.Parameters.Add("@OpeningStock", SqlDbType.NVarChar).Value = opn;
                           // sqlcmd.Parameters.Add("@Unit", SqlDbType.VarChar).Value = unit;
                           // sqlcmd.Parameters.Add("@Date", SqlDbType.SmallDateTime).Value = dat;
                           // sqlcmd.Parameters.Add("@OpeningValue", SqlDbType.NVarChar).Value = ov;
                           
                           //SP_MK=  sqlcmd.ExecuteScalar().ToString();
                            int Max_ID = 0;
                            DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(KTID) FROM MSTKIT");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }

                            boolStatus = clsDataAccess.RunNQwithStatus("insert into MSTKIT(KTID,KTNAME,KTVAL,opn_stock,unit,k_date,opn_value,msUnit,roUnit,MinStock,roQty,sess,clstock,clRate,cldate,coid)values('" + 
                            Max_ID + "','" + strName + "','" + dblVal + "','" + opn + "','" + unit + "','" + dat + "','" + ov + "','" + msUnit + "','" + roUnit + "','" + MinStock + "','" + roQty + "','" + cmbYear.Text + "','"+opn+"','0','"+dat+"','"+coid+"')");
                        }
                    //if(SP_MK=="n")
                    //    { 
                    //        ERPMessageBox.ERPMessage.Show("KIT NAME for " + i + "th Row. not added");
                    //        return false;
                    //    }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter KIT NAME for " + i + "th Row.");
                    }
                    ////edpcon.Close();
                }
               // return a;
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
            return boolStatus;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Kit Saved Successfully","BRAVO");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Kit", "BRAVO");
            }
        }

        private void GetDetails()
        {

            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }

                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;

                }
            }
            catch
            { }

            if (this.Text.Trim().ToLower() == "kit master & opening entry")
            {

                string[] yr = cmbYear.Text.Split('-');
                DataTable dt = clsDataAccess.RunQDTbl("Select KTID,KTNAME,KTVAL,isnull((opn_stock),0)AS'Opn_stock'," +
                "isnull((unit),'pcs')as 'unit','01/04/" + yr[0].ToString().Trim() + "' as k_date,isnull((opn_value),0)as 'opn_value'," +
                "msUnit,roUnit,MinStock,roQty from MSTKIT where (sess='" + cmbYear.Text + "') and (coid='" + coid + "') order by KTID");
                try
                {
                    this.dgv_Kit.Rows.Clear();
                }
                catch { }
                if (dt.Rows.Count == 0)
                {
                    dt = clsDataAccess.RunQDTbl("Select distinct KTID,KTNAME,0 as KTVAL,0 AS 'Opn_stock'," +
                "isnull((unit),'pcs')as unit,'01/04/" + yr[0].ToString().Trim() + "' as k_date,0 as 'opn_value'," +
                "isnull((msUnit),'pcs')as msUnit,isnull((roUnit),'pcs') as roUnit,MinStock,roQty from MSTKIT where (sess='" + cmbYear.Text + "') and (coid='1') order by KTID");

                }

                if (dt.Rows.Count > 0)
                {
                    try
                    {

                        for (int ind_dgv = 0; ind_dgv < dt.Rows.Count; ind_dgv++)
                        {
                            dgv_Kit.Rows.Add();

                            dgv_Kit.Rows[ind_dgv].Cells["KTNO"].Value = dt.Rows[ind_dgv]["KTID"];
                            dgv_Kit.Rows[ind_dgv].Cells["KTNAME"].Value = dt.Rows[ind_dgv]["KTNAME"];
                            dgv_Kit.Rows[ind_dgv].Cells["KTVAL"].Value = dt.Rows[ind_dgv]["KTVAL"];
                            dgv_Kit.Rows[ind_dgv].Cells["OpeningStock"].Value = dt.Rows[ind_dgv]["Opn_stock"];
                            dgv_Kit.Rows[ind_dgv].Cells["Unit"].Value = dt.Rows[ind_dgv]["unit"];
                            dgv_Kit.Rows[ind_dgv].Cells["Date"].Value = dt.Rows[ind_dgv]["k_date"];

                            dgv_Kit.Rows[ind_dgv].Cells["msUnit"].Value = dt.Rows[ind_dgv]["msUnit"];
                            dgv_Kit.Rows[ind_dgv].Cells["roUnit"].Value = dt.Rows[ind_dgv]["roUnit"];
                            dgv_Kit.Rows[ind_dgv].Cells["MinStock"].Value = dt.Rows[ind_dgv]["MinStock"];
                            dgv_Kit.Rows[ind_dgv].Cells["roQty"].Value = dt.Rows[ind_dgv]["roQty"];


                            try
                            {
                                if (Convert.ToDouble(dt.Rows[ind_dgv]["opn_value"]) == 0)
                                {
                                    dgv_Kit.Rows[ind_dgv].Cells["OpeningValue"].Value = (Convert.ToDouble(dt.Rows[ind_dgv]["Opn_stock"]) * Convert.ToDouble(dt.Rows[ind_dgv]["KTVAL"])).ToString("0.00");
                                }
                                else
                                {
                                    dgv_Kit.Rows[ind_dgv].Cells["OpeningValue"].Value = dt.Rows[ind_dgv]["opn_value"];
                                }
                            }

                            catch
                            {
                                dgv_Kit.Rows[ind_dgv].Cells["OpeningValue"].Value = (Convert.ToDouble(dt.Rows[ind_dgv]["Opn_stock"]) * Convert.ToDouble(dt.Rows[ind_dgv]["KTVAL"])).ToString("0.00");
                            }
                        }
                    }
                    catch { }

                }
            }
            if (this.Text.Trim().ToLower() == "fine master")
            {
                try
                {
                    this.dgv_fine.Rows.Clear();
                }
                catch { }
                DataTable dt_fine = clsDataAccess.RunQDTbl("Select fid,REASON,CODE,val from tbl_FineMst");
                if (dt_fine.Rows.Count > 0)
                {
                    try
                    {
                        for (int ind_dgv = 0; ind_dgv < dt_fine.Rows.Count; ind_dgv++)
                        {
                            dgv_fine.Rows.Add();
                            dgv_fine.Rows[ind_dgv].Cells["dgCol_freason"].Value = dt_fine.Rows[ind_dgv]["REASON"];
                            dgv_fine.Rows[ind_dgv].Cells["dgCol_fcode"].Value = dt_fine.Rows[ind_dgv]["CODE"];
                            dgv_fine.Rows[ind_dgv].Cells["dgCol_fval"].Value = dt_fine.Rows[ind_dgv]["val"];
                            dgv_fine.Rows[ind_dgv].Cells["dgCol_fid"].Value = dt_fine.Rows[ind_dgv]["fid"];
                        }
                    }
                    catch { }

                }
            }
        }

        private void frm_Mst_Kit_Load(object sender, EventArgs e)
        {
            clsfirsttime obj_CFT = new clsfirsttime();
            bool result;
             edpcon = new EDPConnection();
             clsValidation.GenerateYear(cmbYear, 2019, System.DateTime.Now.Year, 1);

             string inv = clsDataAccess.ReturnValue("select inv from CompanyLimiter");


             


           int var_mstcount = Convert.ToInt32(clsDataAccess.GetresultIT("MSTKIT"));
           if (var_mstcount == 0)
           {
               edpcon.Open();
               result = obj_CFT.create_KIT(edpcon.mycon);
               
               result = obj_CFT.create_KIT_Trigger(edpcon.mycon);
               
           }
           else if (var_mstcount > 0)
           {
               if (var_mstcount < 3)
               {

               }
           }



           try
           {
               if (AttenDtTmPkr.Value.Month >= 4)
               {
                   try
                   { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                   catch { }

               }
               else
               {
                   cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;

               }
           }
           catch
           { }
           AttenDtTmPkr.Value = DateTime.Now;
           string[] yr = cmbYear.Text.Split('-');
          
           if (this.Text.Trim() == "Kit Master & Opening Entry")
           {
               CmbCompany.PopUp();
           }


           

            if (inv.Trim() == "0")
            {
                btnClStock.Visible = false;
                btnPurchase.Visible = false;
                btnPurReturn.Visible = false;
                btnIssueReturn.Visible = false;
                btnDamage.Visible = false;

                dgv_fine.Columns["OpeningStock"].Visible = false;
                dgv_fine.Columns["Unit"].Visible = false;
                dgv_fine.Columns["OpeningValue"].Visible = false;
            }
            else
            {
                //btnClStock.Visible = true;
                //btnPurchase.Visible = true;
                //btnPurReturn.Visible = true;
                //btnIssueReturn.Visible = true;
                //btnDamage.Visible = true;

                dgv_fine.Columns["OpeningValue"].Visible = true;
                dgv_fine.Columns["OpeningStock"].Visible = true;
                dgv_fine.Columns["Unit"].Visible = true;
            }



            

            

        }

        private void BTNdELETE_Click(object sender, EventArgs e)
        {
            int ind_dg = -1;

            ind_dg = dgv_Kit.CurrentRow.Index;

            ERPMessageBox.ERPMessage.Show("Do U Want to Delete " + dgv_Kit.Rows[ind_dg].Cells[1].Value, "Question ?", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
            if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
            {
                if (ind_dg < 0)
                {
                    ERPMessageBox.ERPMessage.Show("Please select a Kit to delete", "BRAVO");

                }

                int KTID = Convert.ToInt32(dgv_Kit.Rows[ind_dg].Cells[0].Value);
                bool Status = clsDataAccess.RunNQwithStatus("Delete from MSTKIT where (KTID=" + KTID + ")");
                if (Status == true)
                {
                    ERPMessageBox.ERPMessage.Show("Kit Deleted", "BRAVO");
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Failed To Delete Kit", "BRAVO");
                }
                GetDetails();
            }
        }

        private void dgv_fine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indx = 0;
            try
            {
                indx = dgv_fine.CurrentRow.Index;

               txt_freason.Text= dgv_fine.Rows[indx].Cells["dgCol_freason"].Value.ToString();
               txt_fcode.Text = dgv_fine.Rows[indx].Cells["dgCol_fcode"].Value.ToString();
               txt_fval.Text = dgv_fine.Rows[indx].Cells["dgCol_fval"].Value.ToString();
               lblfid.Text = dgv_fine.Rows[indx].Cells["dgCol_fid"].Value.ToString();

               btn_fdel.Enabled = true;
               btn_fsave.Text = "Modify";
            }
            catch{}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_fval.Text = "0";
            txt_freason.Text = "";
            txt_fcode.Text = "";
            lblfid.Text = "";
            GetDetails();
            btn_fsave.Text = "Save";
            btn_fdel.Enabled = false;
        }

        private void btn_fdel_Click(object sender, EventArgs e)
        {
            string sql = ""; bool sta = false;
             ERPMessageBox.ERPMessage.Show("Do U Want to Delete Fine Log : " + txt_fcode.Text.Trim(), "Question ?", ERPMessageBox.ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessageBox.ERPMessage.MessageBoxIcon.EDP_QUESTION);
             if (ERPMessageBox.ERPMessage.ButtonResult == "edpYES")
             {


                  sta = clsDataAccess.RunNQwithStatus("delete from tbl_FineMst where (fid='" + lblfid.Text.Trim() + "')");
                  if (sta == true)
                  {
                      ERPMessageBox.ERPMessage.Show("Fine log Deleted", "BRAVO");
                  }
                  else
                  {
                      ERPMessageBox.ERPMessage.Show("Failed To Delete Fine log", "BRAVO");
                  }

                 btnClear_Click(sender, e);
             }
        }

        private void btn_fsave_Click(object sender, EventArgs e)
        {
            string REASON = "", CODE = "", val = "", fid = "", sql = "";

            REASON = txt_freason.Text.Trim();
            CODE = txt_fcode.Text.Trim(); val = txt_fval.Text.Trim();
            fid = lblfid.Text;
            if (lblfid.Text.Trim() == "")
            {


                sql = "INSERT INTO tbl_FineMst (REASON, CODE, val,fid) VALUES ('" + REASON + "','" + CODE + "','" + val + "',(select isNull(max(fid),0)+1 from tbl_FineMst))";
            }
            else
            {
              sql=  "UPDATE tbl_FineMst SET REASON='" + REASON + "',CODE='" + CODE + "',val='" + val + "' where (fid='" + fid + "')";
            }

           bool bl= clsDataAccess.RunQry(sql);

           if (bl == true)
           {
                btnClear_Click(sender, e);
                ERPMessageBox.ERPMessage.Show("Saved Successfully","BRAVO");
               
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit", "BRAVO");
            }
        }

        private void btn_fclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            frmKitPurchase ejs = new frmKitPurchase();
            ejs.ShowDialog();
            
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            closing_stock cs = new closing_stock();
            cs.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            KIT_ISSUE ki = new KIT_ISSUE();
            ki.ShowDialog();
        }

        private void btnPurReturn_Click(object sender, EventArgs e)
        {
            frmKitPurchaseReturn ejs = new frmKitPurchaseReturn();
            ejs.ShowDialog();
        }

        private void btnIssueReturn_Click(object sender, EventArgs e)
        {
            frmKitIssueReturn ejs = new frmKitIssueReturn();
            ejs.ShowDialog();

        }

        private void dgv_Kit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDamage_Click(object sender, EventArgs e)
        {
            frmDamage fd = new frmDamage();
            fd.ShowDialog();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] yr = cmbYear.Text.Split('-');
            
            try
            {
                AttenDtTmPkr.MinDate = Convert.ToDateTime("01/April/" + yr[0].ToString().Trim());
            }
            catch { }
            try
            {
                AttenDtTmPkr.MaxDate = Convert.ToDateTime("31/March/" + yr[1].ToString().Trim());
            }
            catch { }

            GetDetails();
        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            Date.DefaultCellStyle.NullValue = AttenDtTmPkr.Value.ToString("dd/MM/yyyy");
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frm_mst_Kit_co mkc = new frm_mst_Kit_co();
            //mkc.ShowDialog();
        }

        private void dgv_Kit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Kit.CurrentCell.RowIndex < dgv_Kit.Rows.Count - 1)
            {
                int iCol = dgv_Kit.CurrentCell.ColumnIndex;
                if (dgv_Kit.Columns[iCol].HeaderText.ToLower() == "kit name")
                {
                    int idx = 0;
                    try { idx = Convert.ToInt32(dgv_Kit.Rows[dgv_Kit.CurrentCell.RowIndex].Cells["KTNo"].Value); }

                    catch { idx = 0; }

                    string ktval = dgv_Kit.Rows[dgv_Kit.CurrentCell.RowIndex].Cells["OpeningValue"].Value.ToString();
                    string ktqty = dgv_Kit.Rows[dgv_Kit.CurrentCell.RowIndex].Cells["OpeningStock"].Value.ToString();

                    frm_mst_Kit_co mkc = new frm_mst_Kit_co(idx, cmbYear.Text.Trim(), ktval, ktqty);
                    mkc.ShowDialog();
                }
            }
           /* int iCol = dgv_Kit.CurrentCell.ColumnIndex;
            if (dgv_Kit.Columns[iCol].HeaderText.ToLower() == "kit name")
            {
                dv.sql_frm = "Select distinct KTNAME from MSTKIT";
                dv.retno = 8;
                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;
                dv.ShowDialog();
                try
                {
                    int ind = Convert.ToInt32(dgv_show.CurrentRow.Index);

                    this.dgv_show.Rows[ind].Cells["rid"].Value = dv.retval.ToString();
                    this.dgv_show.Rows[ind].Cells["pid"].Value = dv.retval1.ToString();
            }*/
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            if (edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE " +
                " from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company order by CO_CODE");
            }
            //DataTable dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            if (dt.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                CmbCompany.Text=dt.Rows[0]["Co_name"].ToString();
                CmbCompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                coid = CmbCompany.ReturnValue.ToString();
                GetDetails();
            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
           coid = CmbCompany.ReturnValue.ToString();
           GetDetails();
        }

        private void dgv_Kit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int iRw = dgv_Kit.CurrentCell.RowIndex;
            int iCol = dgv_Kit.CurrentCell.ColumnIndex;

            try
            {
                double ct = Convert.ToDouble(dgv_Kit.Rows[iRw].Cells["OpeningStock"].Value.ToString()) * Convert.ToDouble(dgv_Kit.Rows[iRw].Cells["KTVAL"].Value.ToString());
                dgv_Kit.Rows[iRw].Cells["OpeningValue"].Value = ct.ToString("0.00");
            }
            catch { }

        }

    }
}
