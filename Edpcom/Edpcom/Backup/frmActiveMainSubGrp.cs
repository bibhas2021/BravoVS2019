using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Edpcom;
using EDPComponent;
using System.Collections;
using EDPMessageBox;

namespace Edpcom
{
    public partial class frmActiveMainSubGrp : EDPComponent.FormBase
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        SqlCommand com = new SqlCommand();
        DataSet ds = new DataSet();
        ArrayList GroupsAdd=new ArrayList();
        SqlCommand cmd;
        DataTable dtp;
        SqlDataAdapter da = new SqlDataAdapter();
        Edpcom.EDPConnection con = new EDPConnection();
        SqlTransaction SQLT;
        Boolean flug_select = false;

        string WindowType, Desc, Desc1,OriginalDesc;
        int mcode;
        bool ac, chdata, flg, Lodetype = true;

        public frmActiveMainSubGrp()
        {
            InitializeComponent();
        }

        public frmActiveMainSubGrp(string stype)
        {
            InitializeComponent();
            WindowType = stype;
        }

        private void frmActiveMainSubGrp_Load(object sender, EventArgs e)
        {            
            //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            int state_code = EDPCommon.CurrentStateCode();
            string state = EDPCommon.CurrentStateName(state_code);
            lblstate.Text = "State Name : " + state;
            if (WindowType == "M")
            {
                this.Text = "Edit Main Group";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
            }
            else if (WindowType == "S")
            {
                this.Text = "Edit Sub Group";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
            }
            else if (WindowType == "AC")
            {
                cmbLedgerType.SelectedIndex = 0;
                this.Text = "Edit Ledger";
                dgv.Columns[2].Visible = false;
                dgv.Columns[3].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[0].Width = 700;
                label1.Visible = true;
                cmbLedgerType.Visible = true;
            }          
            else if (WindowType == "Cl")
                this.HeaderText = "Edit Classification";
            else if (WindowType == "PAC")
                this.HeaderText = "Edit Portfolio Asset Category";
            GetLoading();
          
        }

        private void GetLoading()
        {
            if (WindowType == "M")
            {
                #region Edit Main Group

                try
                {
                    dtp = new DataTable("DTLP");
                    DataRow dro;

                    dtp.Clear();
                    DataColumn dtp_GrpName = new DataColumn("Group Name");
                    DataColumn dtp_Active = new DataColumn("Active");
                    DataColumn dtp_OrgGrpName = new DataColumn("Org Grp Name");
                    DataColumn FLAG_ON = new DataColumn("FLAG");
                    DataColumn Bl_Details = new DataColumn("Bl Details");

                    dtp.Columns.Add(dtp_GrpName);
                    dtp.Columns.Add(dtp_Active);
                    dtp.Columns.Add(dtp_OrgGrpName);
                    dtp.Columns.Add(FLAG_ON);
                    dtp.Columns.Add(Bl_Details);

                    GroupsAdd.Add("Capital Account");                               // 1
                    GroupsAdd.Add("Loan Funds");                                    // 2               
                    GroupsAdd.Add("Current Liabilities & Provisions");              // 3
                    GroupsAdd.Add("Fixed Assets");                                  // 4    
                    GroupsAdd.Add("Investments");                                   // 5
                    GroupsAdd.Add("Current Assets,Loans & Advances");               // 6
                    GroupsAdd.Add("Miscellaneous Expenditure");                     // 7
                    GroupsAdd.Add("Direct Expenses");                               // 8 
                    GroupsAdd.Add("Sales");                                         // 9
                    GroupsAdd.Add("Indirect Expenses");                             // 10    
                    GroupsAdd.Add("Indirect Income");                               // 11
                    GroupsAdd.Add("Profit & Loss");                                 // 12
                    GroupsAdd.Add("UnExchanged Foreign Currency Gain/Loss");        // 13
                    GroupsAdd.Add("Realized Foreign Currency Gain/Loss");           // 14

                    EDPCommon.ClearDataTable_EDP(ds.Tables["MainGrp"]);
                    //string qry = "SELECT SDESC,MGROUP,ACTV_FLG,CONS_FLG,Details FROM GRP WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' ORDER BY MGROUP";
                    string qry = "SELECT SDESC,MGROUP,ACTV_FLG,CONS_FLG,Details FROM GRP WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' ORDER BY MGROUP";
                    edpcon.Open();
                    cmd = new SqlCommand(qry, edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "MainGrp");

                    for (int i = 0; i <= GroupsAdd.Count - 1; i++)
                    {
                        dro = dtp.NewRow();
                        dro[0] = ds.Tables["MainGrp"].Rows[i][0].ToString();
                        dro[1] = ds.Tables["MainGrp"].Rows[i][2].ToString();
                        dro[2] = GroupsAdd[i];
                        dro[3] = ds.Tables["MainGrp"].Rows[i][3].ToString();
                        dro[4] = ds.Tables["MainGrp"].Rows[i]["Details"].ToString();
                        dtp.Rows.Add(dro);
                    }

                    for (int k = 0; k <= dtp.Rows.Count - 1; k++)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dgv.Rows.Add(dr1);
                        dgv.Rows[k].Cells[0].Value = dtp.Rows[k][0].ToString();
                        dgv.Rows[k].Cells[1].Value = Convert.ToBoolean(dtp.Rows[k][1].ToString());
                        dgv.Rows[k].Cells[2].Value = dtp.Rows[k][2].ToString();
                        dgv.Rows[k].Cells[4].Value = dtp.Rows[k]["Bl Details"].ToString();
                        if (dtp.Rows[k][3].ToString() == "0")
                        {
                            dgv.Rows[k].Cells[3].Value = false;
                        }
                        else
                        {
                            dgv.Rows[k].Cells[3].Value = true;
                        }
                    }
                }
                catch { }

                #endregion
            }
            else if (WindowType == "S")
            {
                #region Edit Sub Group
                try
                {
                    dtp = new DataTable("DTLP");
                    DataRow dro;

                    dtp.Clear();
                    DataColumn dtp_SGrpName = new DataColumn("SGroup Name");
                    DataColumn dtp_Active = new DataColumn("Active");
                    DataColumn dtp_SOrgGrpName = new DataColumn("Org SGrp Name");
                    DataColumn FLAG_ON = new DataColumn("FLAG");
                    DataColumn Bl_Details = new DataColumn("Bl Details");

                    dtp.Columns.Add(dtp_SGrpName);
                    dtp.Columns.Add(dtp_Active);
                    dtp.Columns.Add(dtp_SOrgGrpName);
                    dtp.Columns.Add(FLAG_ON);
                    dtp.Columns.Add(Bl_Details);

                    EDPCommon.ClearDataTable_EDP(ds.Tables["SubGrp"]);
                    //string qry = "SELECT LDESC,SGROUP,ACTV_FLG,MLDESC,CONS_FLG,Details FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='S' ORDER BY LDESC";
                    string qry = "SELECT LDESC,SGROUP,ACTV_FLG,MLDESC,CONS_FLG,Details FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='S' ORDER BY LDESC";
                    edpcon.Open();
                    cmd = new SqlCommand(qry, edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "SubGrp");

                    for (int i = 0; i <= ds.Tables["SubGrp"].Rows.Count - 1; i++)
                    {
                        dro = dtp.NewRow();
                        dro[0] = ds.Tables["SubGrp"].Rows[i][0].ToString();
                        dro[1] = ds.Tables["SubGrp"].Rows[i][2].ToString();
                        dro[2] = ds.Tables["SubGrp"].Rows[i][3].ToString();
                        dro[3] = ds.Tables["SubGrp"].Rows[i][4].ToString();
                        dro[4] = ds.Tables["SubGrp"].Rows[i][5].ToString();
                        //dro[5] = ds.Tables["SubGrp"].Rows[i][6].ToString();
                        dtp.Rows.Add(dro);
                    }

                    for (int k = 0; k <= dtp.Rows.Count - 1; k++)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dgv.Rows.Add(dr1);
                        dgv.Rows[k].Cells[0].Value = dtp.Rows[k][0].ToString();
                        dgv.Rows[k].Cells[1].Value = Convert.ToBoolean(dtp.Rows[k][1].ToString());
                        dgv.Rows[k].Cells[2].Value = dtp.Rows[k][2].ToString();
                        dgv.Rows[k].Cells[4].Value = dtp.Rows[k][4].ToString();
                        if (dtp.Rows[k][3].ToString() == "0")
                        {
                            dgv.Rows[k].Cells[3].Value = false;
                        }
                        else
                        {
                            dgv.Rows[k].Cells[3].Value = true;
                        }
                    }

                }
                catch { }
                #endregion
            }
            else if (WindowType == "AC")
            {
                #region Edit Asset Class
                try
                {
                    dtp = new DataTable("DTLP");
                    DataRow dro;

                    dtp.Clear();
                    DataColumn dtp_ACName = new DataColumn("Asset Class Name");
                    DataColumn dtp_Active = new DataColumn("Active");
                    DataColumn dtp_ACOrgName = new DataColumn("Org Asset Class Name");

                    dtp.Columns.Add(dtp_ACName);
                    dtp.Columns.Add(dtp_Active);
                    dtp.Columns.Add(dtp_ACOrgName);

                    string TA = Edpcom.frmConfigarationVariable.TotalNOofAsset;

                    EDPCommon.ClearDataTable_EDP(ds.Tables["AssetClass"]);
                    string qry = "SELECT LDESC,glcode,ACTV_FLG,MLDESC,CONS_FLG FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='L' ORDER BY LDESC";
                    edpcon.Open();
                    cmd = new SqlCommand(qry, edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "AssetClass");

                    for (int i = 0; i <= ds.Tables["AssetClass"].Rows.Count - 1; i++)
                    {
                        dro = dtp.NewRow();
                        dro[0] = ds.Tables["AssetClass"].Rows[i][0].ToString();
                        dro[1] = ds.Tables["AssetClass"].Rows[i][2].ToString();
                        dro[2] = ds.Tables["AssetClass"].Rows[i][1].ToString();
                        dtp.Rows.Add(dro);
                    }

                    if (dgv.Rows.Count > 0)
                    {
                        dgv.Rows.Clear();
                    }

                    for (int k = 0; k <= dtp.Rows.Count - 1; k++)
                    {
                        if (Lodetype)
                        {
                            DataGridViewRow dr1 = new DataGridViewRow();
                            dgv.Rows.Add(dr1);
                        }
                        dgv.Rows[k].Cells[0].Value = dtp.Rows[k][0].ToString();
                        if (dtp.Rows[k][1] != null)
                            if (dtp.Rows[k][1].ToString() != "")
                                dgv.Rows[k].Cells[1].Value = Convert.ToBoolean(dtp.Rows[k][1].ToString());
                        dgv.Rows[k].Cells[2].Value = dtp.Rows[k][2].ToString();

                    }
                }
                catch { }
                #endregion
            }
            else if (WindowType == "Cl")
            {
                #region Edit Classification
                try
                {
                    dtp = new DataTable("DTLP");
                    DataRow dro;

                    dtp.Clear();
                    DataColumn dtp_CCName = new DataColumn("Classification Name");
                    DataColumn dtp_CActive = new DataColumn("Active");
                    DataColumn dtp_COrgName = new DataColumn("Org Classification Name");

                    dtp.Columns.Add(dtp_CCName);
                    dtp.Columns.Add(dtp_CActive);
                    dtp.Columns.Add(dtp_COrgName);
                    string TA = Edpcom.frmConfigarationVariable.TotalNOofAsset;

                    EDPCommon.ClearDataTable_EDP(ds.Tables["Classification"]);
                    string qry = "SELECT Idesc,Icode,Actv_Val,OrgnIdesc FROM InvMst WHERE FICODE='" + edpcom.CurrentFicode + "' AND Itype='C' AND Iparent in(" + TA + ") ORDER BY OrgnIdesc";
                    edpcon.Open();
                    cmd = new SqlCommand(qry, edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "Classification");

                    for (int i = 0; i <= ds.Tables["Classification"].Rows.Count - 1; i++)
                    {
                        dro = dtp.NewRow();
                        dro[0] = ds.Tables["Classification"].Rows[i][0].ToString();
                        dro[1] = ds.Tables["Classification"].Rows[i][2].ToString();
                        dro[2] = ds.Tables["Classification"].Rows[i][3].ToString();
                        dtp.Rows.Add(dro);
                    }

                    for (int k = 0; k <= dtp.Rows.Count - 1; k++)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dgv.Rows.Add(dr1);
                        dgv.Rows[k].Cells[0].Value = dtp.Rows[k][0].ToString();
                        dgv.Rows[k].Cells[1].Value = Convert.ToBoolean(dtp.Rows[k][1].ToString());
                        dgv.Rows[k].Cells[2].Value = dtp.Rows[k][2].ToString();
                    }

                }
                catch { }
                #endregion
            }
            else if (WindowType == "PAC")
            {
                #region Edit Portfolio Asset Category
                try
                {
                    dtp = new DataTable("DTLP");
                    DataRow dro;

                    dtp.Clear();
                    DataColumn dtp_PAC = new DataColumn("Portfolio Asset Category");
                    DataColumn dtp_CActive = new DataColumn("Active");
                    DataColumn dtp_OPAC = new DataColumn("Org Portfolio Asset Category");

                    dtp.Columns.Add(dtp_PAC);
                    dtp.Columns.Add(dtp_CActive);
                    dtp.Columns.Add(dtp_OPAC);

                    EDPCommon.ClearDataTable_EDP(ds.Tables["dtPAC"]);
                    string qry = "SELECT AC_ID,AC_Name,AC_Changable_Name,AC_Flag FROM AssetCategoryMaster";
                    edpcon.Open();
                    cmd = new SqlCommand(qry, edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "dtPAC");

                    for (int i = 0; i <= ds.Tables["dtPAC"].Rows.Count - 1; i++)
                    {
                        dro = dtp.NewRow();
                        dro[0] = ds.Tables["dtPAC"].Rows[i][2].ToString();
                        dro[1] = ds.Tables["dtPAC"].Rows[i][3].ToString();
                        dro[2] = ds.Tables["dtPAC"].Rows[i][1].ToString();
                        dtp.Rows.Add(dro);
                    }

                    for (int k = 0; k <= dtp.Rows.Count - 1; k++)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dgv.Rows.Add(dr1);
                        dgv.Rows[k].Cells[0].Value = dtp.Rows[k][0].ToString();
                        dgv.Rows[k].Cells[1].Value = Convert.ToBoolean(dtp.Rows[k][1].ToString());
                        dgv.Rows[k].Cells[2].Value = dtp.Rows[k][2].ToString();
                    }
                }
                catch { }
                #endregion
            }
            else if (WindowType == "A")
                WindowType = "AC";
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {     
            if (WindowType == "M")
            {
                #region Edit Main Group
                try
                {
                    if (e.ColumnIndex == 0 && dgv.Columns[0].HeaderText == "Description")
                    {
                        Desc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value);
                        mcode = dgv.CurrentCell.RowIndex + 1;

                        con.Open();
                        SQLT = con.mycon.BeginTransaction();
                        com = new SqlCommand("Update grp set SDESC='" + Desc + "' Where Ficode='" + edpcom.CurrentFicode + "' and Gcode='" + edpcom.PCURRENT_GCODE + "' and MGROUP=" + mcode + "", con.mycon, SQLT);
                        com.ExecuteNonQuery();
                        SQLT.Commit();                        
                    }

                    if (e.ColumnIndex == 1 && dgv.Columns[1].HeaderText == "Active")
                    {                        

                        ac = Convert.ToBoolean(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value);
                        mcode = dgv.CurrentCell.RowIndex + 1;
                        if (!GetTransactionCheck(mcode))
                        {
                            con.Open();
                            SQLT = con.mycon.BeginTransaction();
                            com = new SqlCommand("Update grp set ACTV_FLG='" + Convert.ToInt32(ac) + "' Where Ficode='" + edpcom.CurrentFicode + "' and Gcode='" + edpcom.PCURRENT_GCODE + "' and MGROUP=" + mcode + "", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            SQLT.Commit();
                        }
                    }
                        if (e.ColumnIndex == 3 && dgv.Columns[3].HeaderText == "Consolidated")
                        {

                            flg = Convert.ToBoolean(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value);
                            mcode = dgv.CurrentCell.RowIndex + 1;
                            
                                con.Open();
                                SQLT = con.mycon.BeginTransaction();
                                com = new SqlCommand("Update grp set CONS_FLG='" + Convert.ToInt32(flg) + "' Where Ficode='" + edpcom.CurrentFicode + "' and Gcode='" + edpcom.PCURRENT_GCODE + "' and MGROUP=" + mcode + "", con.mycon, SQLT);
                                com.ExecuteNonQuery();
                                SQLT.Commit();
                           
                        }
                        if (e.ColumnIndex == 4 && dgv.Columns[4].HeaderText == "BL_Detail")
                        {

                            Desc1 = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[4].Value);
                            mcode = dgv.CurrentCell.RowIndex + 1;

                            con.Open();
                            SQLT = con.mycon.BeginTransaction();
                            com = new SqlCommand("Update grp set Details='" + Desc1 + "' Where Ficode='" + edpcom.CurrentFicode + "' and Gcode='" + edpcom.PCURRENT_GCODE + "' and MGROUP=" + mcode + "", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            SQLT.Commit();

                        }
                        else
                        {
                            //if (ac == false)
                            //{
                            //    dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = true;
                            //}
                            //else
                            //{
                            //    dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = false;
                            //}
                            //EDPMessage.Show("Transaction already exists. Can not modify it.", "Information...");
                            //return;
                        }
                    }
              
                catch
                {
                    SQLT.Rollback();
                    con.Close();
                    return;
                }
                #endregion
            }
            if (WindowType == "S")
            {
                #region Edit Sub Group
                try
                {
                    if (e.ColumnIndex == 0 && dgv.Columns[0].HeaderText == "Description")
                    {
                        Desc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value);
                        OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);

                        con.Open();
                        SQLT = con.mycon.BeginTransaction();
                        com = new SqlCommand("Update Glmst set LDESC='" + Desc + "' Where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='S' AND MLDESC='" + OriginalDesc + "' ", con.mycon, SQLT);
                        com.ExecuteNonQuery();
                        SQLT.Commit();
                    }

                    if (e.ColumnIndex == 1 && dgv.Columns[1].HeaderText == "Active")
                    {
                        ac = Convert.ToBoolean(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value);                        
                        OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);
                        
                        if (!GetTransactionCheckSub(OriginalDesc))
                        {
                            con.Open();
                            SQLT = con.mycon.BeginTransaction();
                            com = new SqlCommand("Update Glmst set ACTV_FLG='" + Convert.ToInt32(ac) + "' Where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='S' AND MLDESC='" + OriginalDesc + "' ", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            SQLT.Commit();
                        }
                    }
                    if (e.ColumnIndex == 3 && dgv.Columns[3].HeaderText == "Consolidated")
                        {
                            flg = Convert.ToBoolean(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value);
                            OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);
                                                       
                                con.Open();
                                SQLT = con.mycon.BeginTransaction();
                                com = new SqlCommand("Update Glmst set CONS_FLG='" + Convert.ToInt32(flg) + "' Where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='S' AND MLDESC='" + OriginalDesc + "' ", con.mycon, SQLT);
                                com.ExecuteNonQuery();
                                SQLT.Commit();
                           
                        }
                        if (e.ColumnIndex == 4 && dgv.Columns[4].HeaderText == "BL_Detail")
                        {                            
                            Desc1 = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[4].Value);
                            OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);

                            con.Open();
                            SQLT = con.mycon.BeginTransaction();
                            com = new SqlCommand("Update Glmst set Details='" + Desc1 + "' Where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='S' AND MLDESC='" + OriginalDesc + "' ", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            SQLT.Commit();
                        }
                        //else
                        //{
                        //    if (ac == false)
                        //    {
                        //        dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = true;
                        //    }
                        //    else
                        //    {
                        //        dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = false;
                        //    }
                        //    EDPMessage.Show("Transaction already exists. Can not modify it.", "Information...");
                        //    return;
                        //}
                    }
              
                catch
                {
                    SQLT.Rollback();
                    con.Close();
                    return;
                }
                #endregion
            }
            if (WindowType == "AC")
            {
                #region Edit Asset Class
                try
                {
                    if (e.ColumnIndex == 0 && dgv.Columns[0].HeaderText == "Description")
                    {
                        Desc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value);
                        OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);

                        con.Open();
                        SQLT = con.mycon.BeginTransaction();
                        com = new SqlCommand("Update InvMst set Idesc='" + Desc + "' Where FICODE='" + edpcom.CurrentFicode + "' AND Itype='I' AND OrgnIdesc='" + OriginalDesc + "' ", con.mycon, SQLT);
                        com.ExecuteNonQuery();
                        SQLT.Commit();
                    }

                    if (e.ColumnIndex == 1 && dgv.Columns[1].HeaderText == "Active")
                    {
                        ac = Convert.ToBoolean(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value);
                        OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);

                        if (!GetTransactionCheckAC(OriginalDesc))
                        {
                            con.Open();
                            SQLT = con.mycon.BeginTransaction();
                            com = new SqlCommand("Update Glmst set ACTV_FLG='" + Convert.ToInt32(ac) + "' Where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='L' AND glcode='" + OriginalDesc + "' ", con.mycon,SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("Update Glmst set ACTV_FLG='" + Convert.ToInt32(ac) + "' Where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='L' AND glcode in (select Vat_code from LinkVATGLMST where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND glcode='" + OriginalDesc + "')", con.mycon, SQLT);
                            //com = new SqlCommand("Update InvMst set Actv_Val='" + Convert.ToInt32(ac) + "' Where FICODE='" + edpcom.CurrentFicode + "' AND Itype='I' AND OrgnIdesc='" + OriginalDesc + "'", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("Update Glmst set ACTV_FLG='" + Convert.ToInt32(ac) + "' Where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='L' AND glcode in (select glcode from LinkVATGLMST where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND Vat_code='" + OriginalDesc + "')", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            SQLT.Commit();
                        }
                        else
                        {
                            if (ac == false)
                            {
                                dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = true;
                            }
                            else
                            {
                                dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = false;
                            }
                            EDPMessage.Show("Transaction already exists. Can not modify it.", "Information...");
                            return;
                        }
                    }
                    //Lodetype = false;
                    //GetLoading();
                    cmbLedgerType_SelectedIndexChanged(sender, e);
                }
                catch
                {
                    SQLT.Rollback();
                    con.Close();
                    return;
                }
                #endregion
            }
            if (WindowType == "Cl")
            {
                #region Edit Classification
                try
                {
                    if (e.ColumnIndex == 0 && dgv.Columns[0].HeaderText == "Description")
                    {
                        Desc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value);
                        OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);

                        con.Open();
                        SQLT = con.mycon.BeginTransaction();
                        com = new SqlCommand("Update InvMst set Idesc='" + Desc + "' Where FICODE='" + edpcom.CurrentFicode + "' AND Itype='C' AND OrgnIdesc='" + OriginalDesc + "' ", con.mycon, SQLT);
                        com.ExecuteNonQuery();
                        SQLT.Commit();
                    }

                    if (e.ColumnIndex == 1 && dgv.Columns[1].HeaderText == "Active")
                    {
                        ac = Convert.ToBoolean(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value);
                        OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);

                        if (!GetTransactionCheckClassi(OriginalDesc))
                        {
                            con.Open();
                            SQLT = con.mycon.BeginTransaction();
                            com = new SqlCommand("Update InvMst set Actv_Val='" + Convert.ToInt32(ac) + "' Where FICODE='" + edpcom.CurrentFicode + "' AND Itype='C' AND OrgnIdesc='" + OriginalDesc + "' ", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            SQLT.Commit();
                        }
                        else
                        {
                            if (ac == false)
                            {
                                dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = true;
                            }
                            else
                            {
                                dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = false;
                            }
                            EDPMessage.Show("Transaction already exists. Can not modify it.", "Information...");
                            return;
                        }
                    }
                }
                catch
                {
                    SQLT.Rollback();
                    con.Close();
                    return;
                }
                #endregion
            }
            if (WindowType == "PAC")
            {
                #region Edit Portfolio Asset Category
                try
                {
                    if (e.ColumnIndex == 0 && dgv.Columns[0].HeaderText == "Description")
                    {
                        Desc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value);
                        OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);

                        con.Open();
                        SQLT = con.mycon.BeginTransaction();
                        com = new SqlCommand("Update AssetCategoryMaster set AC_Changable_Name='" + Desc + "' Where AC_Name='" + OriginalDesc + "' ", con.mycon, SQLT);
                        com.ExecuteNonQuery();
                        SQLT.Commit();
                    }

                    if (e.ColumnIndex == 1 && dgv.Columns[1].HeaderText == "Active")
                    {
                        ac = Convert.ToBoolean(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value);
                        OriginalDesc = Convert.ToString(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value);

                        //if (!GetTransactionCheckClassi(OriginalDesc))
                        //{
                            con.Open();
                            SQLT = con.mycon.BeginTransaction();
                            com = new SqlCommand("Update AssetCategoryMaster set AC_Flag='" + Convert.ToInt32(ac) + "' Where AC_Name='" + OriginalDesc + "' ", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            SQLT.Commit();
                        //}
                        //else
                        //{
                        //    if (ac == false)
                        //    {
                        //        dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = true;
                        //    }
                        //    else
                        //    {
                        //        dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Value = false;
                        //    }
                        //    EDPMessage.Show("Transaction already exists. Can not modify it.", "Information...");
                        //    return;
                        //}
                    }
                }
                catch
                {
                    SQLT.Rollback();
                    con.Close();
                    return;
                }
                #endregion
            }
           
        }

        bool GetTransactionCheck(Int32 mg)
        {
            try
            {
                EDPCommon.ClearDataTable_EDP(ds.Tables["MainGrpTrans"]);
                string qry = "SELECT COUNT(V.AUTOINCRE) [RC] FROM GRP GR,GLMST GL,VCHR V WHERE GR.FICODE='" + edpcom.CurrentFicode + "' AND GR.GCODE='" + edpcom.PCURRENT_GCODE + "' AND GR.MGROUP=" + mg + "";
                qry = qry + " AND GR.FICODE=GL.FICODE AND GR.GCODE=GL.GCODE AND GR.MGROUP=GL.MGROUP AND GL.MTYPE='L' AND";
                qry = qry + " GL.FICODE=V.FICODE AND GL.GCODE=V.GCODE AND GL.GLCODE=V.GLCODE";

                edpcon.Open();
                cmd = new SqlCommand(qry, edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "MainGrpTrans");

                chdata = false;
                if (Convert.ToInt32(ds.Tables["MainGrpTrans"].Rows[0][0].ToString()) > 0)
                {
                    chdata = true;
                }
                else
                    chdata = false;
            }
            catch { }
               return chdata;
        }

        bool GetTransactionCheckSub(string  subg)
        {
            try
            {
                EDPCommon.ClearDataTable_EDP(ds.Tables["SubGrpTrans"]);
                string qry = "SELECT COUNT(V.AUTOINCRE) FROM GLMST GS,GLMST GL,VCHR V WHERE GS.FICODE='" + edpcom.CurrentFicode + "' AND GS.GCODE='" + edpcom.PCURRENT_GCODE + "' AND";
                       qry = qry + " GS.MLDESC='" + subg + "' AND GS.SGROUP=GL.PREV_GROUP AND GS.FICODE=GL.FICODE AND GS.GCODE=GL.GCODE AND";
                       qry = qry + " GL.FICODE=V.FICODE AND GL.GCODE=V.FICODE AND GL.GLCODE=V.GLCODE";

                edpcon.Open();
                cmd = new SqlCommand(qry, edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "SubGrpTrans");

                chdata = false;
                if (Convert.ToInt32(ds.Tables["SubGrpTrans"].Rows[0][0].ToString()) > 0)
                {
                    chdata = true;
                }
                else
                    chdata = false;
            }
            catch { }
            return chdata;
        }

        bool GetTransactionCheckAC(string subg)
        {
            try
            {
                EDPCommon.ClearDataTable_EDP(ds.Tables["ACTrans"]);
                string qry = "SELECT COUNT(IT.AUTOINCRE) FROM itran IT,InvMst INV,IGLMST IG WHERE INV.FICODE='" + edpcom.CurrentFicode + "' AND";
                qry = qry + " INV.Itype='I' AND INV.OrgnIdesc='" + subg + "' AND INV.FICODE=IG.FICODE AND IG.GCODE='" + edpcom.PCURRENT_GCODE + "'";
                qry = qry + " AND INV.ICODE=IG.INV_TYPECODE AND IG.PCODE=IT.PCODE AND IG.FICODE=IT.FICODE AND IG.GCODE=IT.GCODE";
                
                edpcon.Open();
                cmd = new SqlCommand(qry, edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "ACTrans");

                chdata = false;
                if (Convert.ToInt32(ds.Tables["ACTrans"].Rows[0][0].ToString()) > 0)
                {
                    chdata = true;
                }
                else
                    chdata = false;
            }
            catch { }
            return chdata;
        }

        bool GetTransactionCheckClassi(string subg)
        {
            try
            {
                EDPCommon.ClearDataTable_EDP(ds.Tables["ClassiTrans"]);
                string qry = "SELECT COUNT(IT.AUTOINCRE) FROM itran IT,InvMst INV,IGLMST IG WHERE INV.FICODE='" + edpcom.CurrentFicode + "' AND";
                qry = qry + " INV.Itype='C' AND INV.OrgnIdesc='" + subg + "' AND INV.FICODE=IG.FICODE AND IG.GCODE='" + edpcom.PCURRENT_GCODE + "'";
                qry = qry + " AND INV.ICODE=IG.CLASSCODE AND IG.PCODE=IT.PCODE AND IG.FICODE=IT.FICODE AND IG.GCODE=IT.GCODE";

                edpcon.Open();
                cmd = new SqlCommand(qry, edpcon.mycon);
                da.SelectCommand = cmd;
                da.Fill(ds, "ClassiTrans");

                chdata = false;
                if (Convert.ToInt32(ds.Tables["ClassiTrans"].Rows[0][0].ToString()) > 0)
                {
                    chdata = true;
                }
                else
                    chdata = false;
            }
            catch { }
            return chdata;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbLedgerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                string qry = "";
                if (cmbLedgerType.SelectedIndex < 0)
                {
                }
                else
                {
                    if (cmbLedgerType.SelectedIndex == 0)
                    {
                        qry = "SELECT LDESC,glcode,ACTV_FLG,MLDESC,CONS_FLG FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='L' ORDER BY LDESC";
                    }

                    if (cmbLedgerType.SelectedIndex == 1)
                    {
                        //qry = "SELECT LDESC,glcode,ACTV_FLG,MLDESC,CONS_FLG FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='L' ORDER BY LDESC";
                        qry = "SELECT distinct G.LDESC,G.glcode,G.ACTV_FLG,G.MLDESC,G.CONS_FLG FROM GLMST G WHERE" +
                              " G.FICODE='" + edpcom.CurrentFicode + "' AND G.GCODE='" + edpcom.PCURRENT_GCODE + "'  AND (G.MGROUP=8 AND G.SGROUP=18 AND G.MTYPE='L' AND G.FICODE='" + edpcom.CurrentFicode + "' AND G.GCODE='" + edpcom.PCURRENT_GCODE + "') OR" +
                              " (G.MGROUP IN(3,30,31) AND T_FILTER IN (31,32)AND G.MTYPE='L' AND G.FICODE='" + edpcom.CurrentFicode + "' AND G.GCODE='" + edpcom.PCURRENT_GCODE + "')";
                    }
                    if (cmbLedgerType.SelectedIndex == 2)
                    {
                        qry = "SELECT distinct G.LDESC,G.glcode,G.ACTV_FLG,G.MLDESC,G.CONS_FLG FROM GLMST G WHERE" +
                        " G.FICODE='" + edpcom.CurrentFicode + "' AND G.GCODE='" + edpcom.PCURRENT_GCODE + "'  AND (G.MGROUP=9 AND G.SGROUP=0 AND G.MTYPE='L') OR  G.FICODE='" + edpcom.CurrentFicode + "' AND G.GCODE='" + edpcom.PCURRENT_GCODE + "' and" +
                        " (G.MGROUP IN(3,30,31) AND T_FILTER IN (33,34)AND G.MTYPE='L')";
                    }
                    if (cmbLedgerType.SelectedIndex == 3)
                    {
                        qry = "SELECT  distinct G.LDESC,G.glcode,G.ACTV_FLG,G.MLDESC,G.CONS_FLG FROM GLMST G WHERE" +
                        " G.FICODE='" + edpcom.CurrentFicode + "' AND G.GCODE='" + edpcom.PCURRENT_GCODE + "' AND G.MTYPE='L' AND T_FILTER NOT IN (31,32,33,34,50,60)";
                    }

                    #region Edit Asset Class
                    try
                    {
                        dgv.Rows.Clear();
                        dtp = new DataTable("DTLP");
                        DataRow dro;

                        dtp.Clear();
                        DataColumn dtp_ACName = new DataColumn("Asset Class Name");
                        DataColumn dtp_Active = new DataColumn("Active");
                        DataColumn dtp_ACOrgName = new DataColumn("Org Asset Class Name");

                        dtp.Columns.Add(dtp_ACName);
                        dtp.Columns.Add(dtp_Active);
                        dtp.Columns.Add(dtp_ACOrgName);

                        string TA = Edpcom.frmConfigarationVariable.TotalNOofAsset;

                        EDPCommon.ClearDataTable_EDP(ds.Tables["AssetClass"]);

                        edpcon.Open();
                        cmd = new SqlCommand(qry, edpcon.mycon);
                        da.SelectCommand = cmd;
                        da.Fill(ds, "AssetClass");

                        for (int i = 0; i <= ds.Tables["AssetClass"].Rows.Count - 1; i++)
                        {
                            dro = dtp.NewRow();
                            dro[0] = ds.Tables["AssetClass"].Rows[i][0].ToString();
                            dro[1] = ds.Tables["AssetClass"].Rows[i][2].ToString();
                            dro[2] = ds.Tables["AssetClass"].Rows[i][1].ToString();
                            dtp.Rows.Add(dro);
                        }

                        for (int k = 0; k <= dtp.Rows.Count - 1; k++)
                        {
                            if (Lodetype)
                            {
                                DataGridViewRow dr1 = new DataGridViewRow();
                                dgv.Rows.Add(dr1);
                            }
                            dgv.Rows[k].Cells[0].Value = dtp.Rows[k][0].ToString();
                            if (dtp.Rows[k][1] != null)
                                if (dtp.Rows[k][1].ToString() != "")
                                    dgv.Rows[k].Cells[1].Value = Convert.ToBoolean(dtp.Rows[k][1].ToString());
                            dgv.Rows[k].Cells[2].Value = dtp.Rows[k][2].ToString();
                        }

                        //btnSave_Click(sender, e);
                    }
                    catch { }
                    #endregion

                }
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //dgv_CellEndEdit(sender, new DataGridViewCellEventArgs(1, dgv.CurrentCell.RowIndex));
            dgv.Focus();
            dgv.ClearSelection();
            dgv.Rows[0].Cells[0].Selected = true;
            dgv.CurrentCell = dgv[0, 0];

            if (flug_select == true)
            {
                try
                {
                    con.Close();
                    con.Open();
                    SQLT = con.mycon.BeginTransaction();
                    for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                    {
                        ac = Convert.ToBoolean(dgv.Rows[i].Cells[1].Value);
                        OriginalDesc = Convert.ToString(dgv.Rows[i].Cells[2].Value);                        
                        com = new SqlCommand("Update Glmst set ACTV_FLG='" + Convert.ToInt32(ac) + "' Where FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='L' AND glcode='" + OriginalDesc + "' ", con.mycon, SQLT);
                        com.ExecuteNonQuery();
                      
                    }
                    SQLT.Commit();
                    con.Close();
                }
                catch
                {
                    SQLT.Rollback();
                    edpcon.Close();
                    EDPMessage.Show("Description Save Problame." , "Information");
                }
            }
            EDPMessage.Show("Description Save Successfully.", "Information");
            this.Close();
        }

        public void ledgeropen(string ledgercode)
        {
            try
            {
                this.HeaderText = "Edit Ledger";
                dgv.Columns[2].Visible = false;
                dgv.Columns[3].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[0].Width = 700;
                //label1.Visible = true;
                //cmbLedgerType.Visible = true;

                dgv.Rows.Clear();
                string qry = "";
                qry = "SELECT LDESC,glcode,ACTV_FLG,MLDESC,CONS_FLG FROM GLMST WHERE FICODE='" + edpcom.CurrentFicode + "' AND GCODE='" + edpcom.PCURRENT_GCODE + "' AND MType='L' and glcode in(" + ledgercode + ") ORDER BY LDESC";
               
                 #region Edit Asset Class
                try
                {
                    dtp = new DataTable("DTLP");
                    DataRow dro;

                    dtp.Clear();
                    DataColumn dtp_ACName = new DataColumn("Asset Class Name");
                    DataColumn dtp_Active = new DataColumn("Active");
                    DataColumn dtp_ACOrgName = new DataColumn("Org Asset Class Name");

                    dtp.Columns.Add(dtp_ACName);
                    dtp.Columns.Add(dtp_Active);
                    dtp.Columns.Add(dtp_ACOrgName);

                    string TA = Edpcom.frmConfigarationVariable.TotalNOofAsset;

                    EDPCommon.ClearDataTable_EDP(ds.Tables["AssetClass"]);

                    edpcon.Open();
                    cmd = new SqlCommand(qry, edpcon.mycon);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "AssetClass");

                    for (int i = 0; i <= ds.Tables["AssetClass"].Rows.Count - 1; i++)
                    {
                        dro = dtp.NewRow();
                        dro[0] = ds.Tables["AssetClass"].Rows[i][0].ToString();
                        dro[1] = ds.Tables["AssetClass"].Rows[i][2].ToString();
                        dro[2] = ds.Tables["AssetClass"].Rows[i][1].ToString();
                        dtp.Rows.Add(dro);
                    }

                    for (int k = 0; k <= dtp.Rows.Count - 1; k++)
                    {
                        if (Lodetype)
                        {
                            DataGridViewRow dr1 = new DataGridViewRow();
                            dgv.Rows.Add(dr1);
                        }
                        dgv.Rows[k].Cells[0].Value = dtp.Rows[k][0].ToString();
                        if (dtp.Rows[k][1] != null)
                            if (dtp.Rows[k][1].ToString() != "")
                                dgv.Rows[k].Cells[1].Value = Convert.ToBoolean(dtp.Rows[k][1].ToString());
                        dgv.Rows[k].Cells[2].Value = dtp.Rows[k][2].ToString();
                    }
                    //WindowType = "AC";
                    //btnSave_Click(sender, e);
                }
                catch { }
                #endregion

                dgv.Focus();
                dgv.ClearSelection();
                dgv.Rows[dgv.CurrentCell.RowIndex].Cells[1].Selected = true;
                dgv.CurrentCell = dgv[1, dgv.CurrentCell.RowIndex];  
            }
            catch { }
        }

        private void frmActiveMainSubGrp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                btnSave_Click(sender, e);
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                {
                    flug_select = true;
                    for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                        dgv.Rows[i].Cells[1].Value = true;
                }

            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5)
            //    btnSave_Click(sender, e);
        }

    }
}