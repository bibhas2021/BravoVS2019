using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Edpcom;
namespace PayRollManagementSystem
{
    public partial class frm_mst_Kit_co : Form
    {
        EDPConnection edpcon;
        SqlCommand sqlcmd;

        int ktid; string sess;
        double kcVal = 0, kcQty = 0, ktval = 0, ktqty = 0;
        string[] yr;
        DialogView dv = new DialogView();
        public frm_mst_Kit_co(int kid,string ses,string kval,string kqty)

        {
            ktid=kid; sess=ses;
            
            yr = ses.Trim().Split('-');
            
            ktval = Convert.ToDouble(kval);
            ktqty = Convert.ToDouble(kqty);

            InitializeComponent();
        }

        private void frm_mst_Kit_co_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2019, System.DateTime.Now.Year, 1);

            cmbYear.SelectedItem = sess;

            try
            {

                this.lblKVal.Text = ktval.ToString();
            }
            catch { }
            try
            {
                this.lblKQty.Text = ktqty.ToString();
            }
            catch { }

            DataTable dt = clsDataAccess.RunQDTbl("Select KTID,KTNAME,KTVAL,isnull((opn_stock),0)AS'Opn_stock',isnull((unit),'pcs')as 'unit','01/04/" + yr[0].ToString().Trim() + "' as k_date,isnull((opn_value),0)as 'opn_value',msUnit,roUnit,MinStock,roQty from MSTKIT where (sess='" + cmbYear.Text + "') and (KTID='" + ktid + "') order by KTID");
            DataTable dtCoRec = clsDataAccess.RunQDTbl("Select KTID,KTNAME,KTVAL,isnull((opn_stock),0)AS'Opn_stock',isnull((unit),'pcs')as 'unit','01/04/" + yr[0].ToString().Trim() + "' as k_date,isnull((opn_value),0)as 'opn_value',msUnit,roUnit,MinStock,roQty,coid,(select CO_NAME FROM Company where co_code=mk.coid)Company from MSTKIT_Comp mk where (sess='" + cmbYear.Text + "') and (KTID='" + ktid + "') order by KTID");
            DataTable dtCo = clsDataAccess.RunQDTbl("select KTID,KTNAME,KTVAL,(isnull((opn_stock),0)/(select COUNT(*) from Company)) AS 'Opn_stock',isnull((unit),'pcs')as 'unit','01/04/" + yr[0].ToString().Trim() + "' as k_date,(isnull((opn_value),0)/(select COUNT(*) from Company)) as 'opn_value',msUnit,roUnit,MinStock,roQty,c.co_code as coid, c.CO_NAME as Company from Company c,MSTKIT k where k.KTID='" + ktid + "' and sess='" + cmbYear.Text + "'");
            DataSet dsDataset = new DataSet();
            dsDataset.Tables.Add(dt);
            if (dtCoRec.Rows.Count == 0)
            {
                dsDataset.Tables.Add(dtCo);
                dgv_Kit.DataSource = dtCo; 
            }
            else
            {
                dsDataset.Tables.Add(dtCoRec);
                dgv_Kit.DataSource = dtCoRec; 
            }
            DataRelation Datatablerelation = new DataRelation("DetailsMarks", dsDataset.Tables[0].Columns[0], dsDataset.Tables[1].Columns[0], true);
            dsDataset.Relations.Add(Datatablerelation);

            
        //            dgv_Kit.Rows[ind_dgv].Cells["KTNO"].Value = dt.Rows[ind_dgv]["KTID"];
        //            dgv_Kit.Rows[ind_dgv].Cells["KTNAME"].Value = dt.Rows[ind_dgv]["KTNAME"];
        //            dgv_Kit.Rows[ind_dgv].Cells["KTVAL"].Value = dt.Rows[ind_dgv]["KTVAL"];
        //            dgv_Kit.Rows[ind_dgv].Cells["OpeningStock"].Value = dt.Rows[ind_dgv]["Opn_stock"];
        //            dgv_Kit.Rows[ind_dgv].Cells["Unit"].Value = dt.Rows[ind_dgv]["unit"];
        //            dgv_Kit.Rows[ind_dgv].Cells["Date"].Value = dt.Rows[ind_dgv]["k_date"];

        //            dgv_Kit.Rows[ind_dgv].Cells["msUnit"].Value = dt.Rows[ind_dgv]["msUnit"];
        //            dgv_Kit.Rows[ind_dgv].Cells["roUnit"].Value = dt.Rows[ind_dgv]["roUnit"];
        //            dgv_Kit.Rows[ind_dgv].Cells["MinStock"].Value = dt.Rows[ind_dgv]["MinStock"];
        //            dgv_Kit.Rows[ind_dgv].Cells["roQty"].Value = dt.Rows[ind_dgv]["roQty"]; 

        //                    dgv_Kit.Rows[ind_dgv].Cells["OpeningValue"].Value
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // DataTable dt
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Kit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRw = dgv_Kit.CurrentCell.RowIndex;
            int iCol = dgv_Kit.CurrentCell.ColumnIndex;


            if (dgv_Kit.Columns[iCol].HeaderText.ToLower() == "company")
            {


                dv.sql_frm = "SELECT CO_CODE,CO_NAME FROM Company";
                dv.retno = 2;
                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;
                dv.ShowDialog();
                try
                {
                    iRw = Convert.ToInt32(dgv_Kit.CurrentRow.Index);

                    this.dgv_Kit.Rows[iRw].Cells["coid"].Value = dv.retval.ToString();
                    this.dgv_Kit.Rows[iRw].Cells["Company"].Value = dv.retval1.ToString();

                }
                catch { }
            }


        }
        private Boolean SubmitDetails()
        {
            edpcon = new EDPConnection();
            Boolean boolStatus = false;
            string SP_MK = "";
            bool a = true;
            string[] yr = cmbYear.Text.Split('-');
            string msUnit, roUnit, MinStock, roQty, strSlNo, strName, opn, unit, dat, coid;
            double dblVal = 0;

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
                    coid = Convert.ToString(dgv_Kit.Rows[i].Cells["coid"].Value);
                    if (opn == "")
                    { opn = "0"; }
                    unit = Convert.ToString(dgv_Kit.Rows[i].Cells["Unit"].Value);
                    dat = "";
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
                    catch { dat = Convert.ToDateTime("01/April/" + yr[0].Trim()).ToString("dd/MMM/yyyy"); }
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
                            if (Convert.ToInt32(clsDataAccess.GetresultS("select count(*) from MSTKIT_Comp where (KTID='" + strSlNo + "') and (coid='" + coid + "')")) > 0)
                            {
                                //btnSave.Text = "Update";
                                boolStatus = clsDataAccess.RunNQwithStatus("update MSTKIT_Comp set KTNAME='" + strName + "',KTVAL='" + dblVal + "',opn_stock='" + opn + "',unit='" + unit + "',k_date='" + dat + "',opn_value='" + ov + "',msUnit='" + msUnit + "',roUnit='" + roUnit + "',MinStock='" + MinStock + "',roQty='" + roQty + "' where (KTID='" + strSlNo + "') and (sess='" + cmbYear.Text + "') and (coid='" + coid + "')");
                            }
                            else
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("insert into MSTKIT_Comp(KTID,KTNAME,KTVAL,opn_stock,unit,k_date,opn_value,msUnit,roUnit,MinStock,roQty,sess,clstock,clRate,cldate,coid)values('" +
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

                            boolStatus = clsDataAccess.RunNQwithStatus("insert into MSTKIT_Comp(KTID,KTNAME,KTVAL,opn_stock,unit,k_date,opn_value,msUnit,roUnit,MinStock,roQty,sess,clstock,clRate,cldate,coid)values('" +
                            Max_ID + "','" + strName + "','" + dblVal + "','" + opn + "','" + unit + "','" + dat + "','" + ov + "','" + msUnit + "','" + roUnit + "','" + MinStock + "','" + roQty + "','" + cmbYear.Text + "','" + opn + "','0','" + dat + "','"+coid+"')");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Kit Saved Successfully", "BRAVO");
               //GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Kit", "BRAVO");
            }
        }

        private void dgv_Kit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            kcQty=0;kcVal=0;
            for (int i = 0; i < dgv_Kit.Rows.Count-1; i++)
            {
                kcVal =kcVal+ Convert.ToDouble(dgv_Kit.Rows[i].Cells["OpeningValue"].Value);
                kcQty =kcQty+ Convert.ToDouble(dgv_Kit.Rows[i].Cells["OpeningStock"].Value);
            }

            if (kcQty != Convert.ToDouble(lblKQty.Text))
            {
                btnSave.Enabled = false;
                lblMsg.Text = ("Kit Value miss-matched");
            }
            else
            {
                btnSave.Enabled = true;
                lblMsg.Text = "Kit Value Matched";
            }
        }
    }
}
