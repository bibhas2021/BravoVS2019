using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;

namespace Edpcom
{
    public partial class frmListAddRemoveTree : Form//EDPComponent.FormBase//RptSmall
    {
        Edpcom.EDPConnection con = new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        Edpcom.EDPCommon EDPComm =new EDPCommon();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        Boolean select_flg;

        public frmListAddRemoveTree()
        {
            InitializeComponent();
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            if (select_flg == true)
            {
                for (int i = 0; i <= lstVmS.Items.Count - 1; i++)
                {
                    lstVmS.Items[i].Checked = true;
                }
                select_flg = false;
                btn_all.Text = "Reset";
            }
            else
            {
                for (int i = 0; i <= lstVmS.Items.Count - 1; i++)
                {
                    lstVmS.Items[i].Checked = false;
                }
                select_flg = true;
                btn_all.Text = "Select All";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ArrayList arrlst = new ArrayList();
            Hashtable lclcode = new Hashtable();
            Hashtable htss = new Hashtable();
            int i;
            string str_Checked_Item = ""; bool First_Checked_Item = false;
            for (i = 0; i <= lstVmS.Items.Count - 1; i++)
            {
                if (lstVmS.Items[i].Checked == true)
                {
                    arrlst.Add(lstVmS.Items[i].Text.ToString());
                    int cnt = arrlst.Count - 1;
                    lclcode.Add(cnt, lstVmS.Items[i].SubItems[EDPCommon.columnindex + 1].Text);
                    htss.Add(cnt, lstVmS.Items[i].SubItems[2].Text);
                    if (EDPCommon.FormName_EDPC != "" && EDPCommon.ComponentName_EDPC != "")
                    {
                        if (!First_Checked_Item)
                        {
                            str_Checked_Item = i.ToString();
                            First_Checked_Item = true;
                        }
                        else
                            str_Checked_Item = str_Checked_Item + "," + i.ToString();
                    }
                }
            }
            if (arrlst.Count > 0)
            {
                if (EDPCommon.FormName_EDPC != "" && EDPCommon.ComponentName_EDPC != "")
                {
                    EDPComm.writeToIni(Application.StartupPath + "\\ControlSettings.edp", EDPCommon.FormName_EDPC, EDPCommon.ComponentName_EDPC, str_Checked_Item);
                }


                EDPCommon.arr_mod = arrlst;
                EDPCommon.get_code = lclcode;
                EDPCommon.Hsdtss = htss;
                this.Close();
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("Do you want to select items?", "Confirm!", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_QUESTION);
                if (EDPMessageBox.EDPMessage.ButtonResult == "edpNO")
                {
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListAddRemoveTree_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            lstVmS.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
            AddItemList();
            select_flg = true;
        }

        private void frmListAddRemoveTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
        public void AddItemList()
        {
            try
            {
                if (EDPCommon.qry_dt == 1)
                {
                    int wid = 0;
                    this.Text = EDPCommon.Caption;
                    lblTag.Text = EDPCommon.Header;
                    lstVmS.Items.Clear();
                    lstVmS.View = View.Details;                   
                    //lstVmS.Columns.Add(EDPCommon.ClmHeader.ToString(), 300);
                    for (int i = 0; i <= EDPCommon.dtss.Columns.Count - 1; i++)
                    {
                        if (i == 0)
                        {
                            lstVmS.Columns.Add(EDPCommon.dtss.Columns[i].ColumnName.ToString(), 150, HorizontalAlignment.Center);
                            wid = 150;
                        }
                        else
                        {
                            lstVmS.Columns.Add(EDPCommon.dtss.Columns[i].ColumnName.ToString(), 100, HorizontalAlignment.Center);
                            wid = wid + 100;
                        }
                        
                    }
                    wid = wid - 100;
                    
                    for (int i = 0; i <= EDPCommon.dtss.Rows.Count - 1; i++)
                    {
                        ListViewItem lsti = new ListViewItem(EDPCommon.dtss.Rows[i][0].ToString());
                        lsti.SubItems.Add(EDPCommon.dtss.Rows[i][1].ToString());
                        lsti.SubItems.Add(EDPCommon.dtss.Rows[i][2].ToString());
                        lsti.SubItems.Add(EDPCommon.dtss.Rows[i][3].ToString());
                        lsti.SubItems.Add(EDPCommon.dtss.Rows[i][4].ToString());
                        lsti.SubItems.Add(EDPCommon.dtss.Rows[i][5].ToString());
                        //lsti.SubItems.Add(EDPCommon.dtss.Rows[i][6].ToString());                       
                        lstVmS.Items.Add(lsti);
                    }
                    this.Width = wid + 30;
                    lstVmS.Width = wid + 5;
                    lblTag.Width = wid + 5;
                    groupBox1.Width = wid + 5;
                    btnClose.Left = wid - 80;
                    btnOk.Left = wid - 165;
                    btn_all.Left = wid - 250;
                }
                else
                {
                    if (Information.IsNothing(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb]) == false)
                    {
                        EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Clear();
                        EDPCommon.STCK_DS.Tables.Clear();
                    }
                    this.Text = EDPCommon.Caption;
                    lblTag.Text = EDPCommon.Header;
                    lstVmS.Items.Clear();
                    lstVmS.View = View.Details;
//change Subrata 
                    //change Subrata 210711
                    //string assetclass = "";
                    //ArrayList araset = new ArrayList();
                    //araset.Clear();
                    //if (Edpcom.frmConfigarationVariable.EQLISTED_ON == false)
                    //{
                    //    araset.Add(1);
                    //}
                    //if (Edpcom.frmConfigarationVariable.EQUNLISTED_ON == false)
                    //{
                    //    araset.Add(2);
                    //}
                    //if (Edpcom.frmConfigarationVariable.DEBENTURES_ON == false)
                    //{
                    //    araset.Add(3);
                    //}
                    //if (Edpcom.frmConfigarationVariable.DERIVATIVE_FUTURES_ON == false)
                    //{
                    //    araset.Add(4);
                    //}
                    //if (Edpcom.frmConfigarationVariable.FIXED_DEPOSITS_ON == false)
                    //{
                    //    araset.Add(5);
                    //}
                    //if (Edpcom.frmConfigarationVariable.MUTUALFUND_ON == false)
                    //{
                    //    araset.Add(6);
                    //}
                    //if (Edpcom.frmConfigarationVariable.BONDS_ON == false)
                    //{
                    //    araset.Add(7);
                    //}
                    //if (Edpcom.frmConfigarationVariable.COMMODITYFUTURES_ON == false)
                    //{
                    //    araset.Add(9);
                    //}
                    //if (Edpcom.frmConfigarationVariable.BULLION_ON == false)
                    //{
                    //    araset.Add(10);
                    //}

                    //if (Edpcom.frmConfigarationVariable.INSURANCE_ON == false)
                    //{
                    //    araset.Add(11);
                    //}

                    //if (Edpcom.frmConfigarationVariable.CASH_ON == false)
                    //{
                    //    araset.Add(17);
                    //}
                    //if (Edpcom.frmConfigarationVariable.PROPERTIES_IMMOVABLE_ON == false)
                    //{
                    //    araset.Add(12);
                    //}
                    //if (Edpcom.frmConfigarationVariable.PUBLIC_PROVIDEND_FUND_ON == false)
                    //{
                    //    araset.Add(35);
                    //}
                    //if (araset.Count > 0)
                    //{
                    //    for (int s = 0; s < araset.Count; s++)
                    //    {
                    //        assetclass = assetclass + araset[s];
                    //        if (s != araset.Count - 1)
                    //        {
                    //            assetclass = assetclass + ",";
                    //        }
                    //    }
                    //}                  
                    string str = EDPCommon.Query;
                    //if ((EDPCommon.AssetBlock == 1) && (assetclass.Length > 0))
                    //{" + assetclass + ")";
                    //}           
                    int i;
                    //    str = str + " and icode not in (
                    con.Open();                 
                    cmd = new SqlCommand(str, con.mycon);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch
                    {
                        con.Close();
                    }
                    da.SelectCommand = cmd;
                    da.Fill(EDPCommon.STCK_DS, EDPCommon.StckTb);

                    //============== Pradipta For Retriving Existing Item 12-06-2013 =========
                    EDPCommon.ClearDataTable_EDP(EDPCommon.STCK_DS.Tables["Existing_Item"]);
                    str = EDPCommon.Query_Existing_Item;
                    con.Open();
                    if (str != null)
                    {
                        cmd = new SqlCommand(str, con.mycon);
                        da.SelectCommand = cmd;
                        da.Fill(EDPCommon.STCK_DS, "Existing_Item");
                    }
                    //================================ End ===================================

                    if (Information.IsNothing(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb]) == true)
                    {
                        return;
                    }
                    else
                    {
                        for (i = 0; i < EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Columns.Count; i++)
                        {
                            lstVmS.Columns.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Columns[i].ColumnName.ToString(), 150, HorizontalAlignment.Center);
                        }
                        bool flgval = false; int Start_Index = 0;
                        for (i = 0; i < EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows.Count; i++)
                        {
                            //ListViewItem lsti = new ListViewItem(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][0].ToString());
                            //lsti.SubItems.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][1].ToString());
                            //lsti.SubItems.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][2].ToString());
                            //lstVmS.Items.Add(lsti);

                            ListViewItem lsti = new ListViewItem(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][0].ToString());
                            lsti.SubItems.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][1].ToString());
                            lsti.SubItems.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][2].ToString());
                            try
                            {
                                if (EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Columns.Count > 3)
                                {
                                    for (int ind = 3; ind < EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Columns.Count; ind++)
                                    {
                                        lsti.SubItems.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][ind].ToString());
                                    }
                                }
                            }
                            catch
                            {                            }
                            try
                            {
                                if (EDPCommon.FormName_EDPC != "" && EDPCommon.ComponentName_EDPC != "")
                                {
                                    string str_val = Convert.ToString(EDPComm.readFromIni(Application.StartupPath + "\\ControlSettings.edp", EDPCommon.FormName_EDPC, EDPCommon.ComponentName_EDPC));
                                    string[] StrIndex = str_val.Trim().Split(',');
                                    if (StrIndex.Length > 0)
                                    {
                                        if (Convert.ToInt32(StrIndex[Start_Index]) == i)
                                        {
                                            lsti.Checked = true;
                                            //lstVmS.Items.Add(lsti);
                                            Start_Index++;
                                        }
                                    }
                                }
                            }
                            catch { }

                            if (!flgval)
                            {
                                DataView dv1 = new DataView(EDPCommon.STCK_DS.Tables["Existing_Item"]);
                                if (dv1.Count > 0)
                                {
                                    try
                                    {
                                        string SSSSS = "" + EDPCommon.STCK_DS.Tables["Existing_Item"].Columns[0].ColumnName.ToString() + "='" + EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][1].ToString() + "'";
                                        dv1.RowFilter = SSSSS;
                                        //dv1.RowFilter = "" + common.STCK_DS.Tables[common.StckTb].Columns[1].ColumnName.ToString() + "='" + common.STCK_DS.Tables[common.StckTb].Rows[i][1].ToString() + "'";

                                        if (dv1.Count > 0)
                                            lsti.Checked = true;
                                    }
                                    catch { }
                                }
                                else
                                    flgval = true;
                            }
                            lstVmS.Items.Add(lsti);
                        }
                    }
                }
            }
            catch { }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int lastItm = 0, col=0;
                bool find = false;
                //lstVmS.Items. = false;
                int colCount = lstVmS.Columns.Count;
                for (int colAll = col; colAll < colCount; colAll++)
                {
                    for (int lst12 = lastItm; lst12 < lstVmS.Items.Count; lst12++)
                    {
                        if (lstVmS.Items[lst12].SubItems[colAll].Text.IndexOf(txtSearch.Text) > -1 |
                            lstVmS.Items[lst12].SubItems[colAll].Text.ToUpper().IndexOf(txtSearch.Text.ToUpper()) > -1)
                        {
                            lstVmS.TopItem = lstVmS.Items[lst12];
                            lstVmS.Items[lst12].Focused= true;
                            lstVmS.Items[lst12].BackColor = Color.AliceBlue;
                            //lstVmS.Items[lst12].Checked = true;
                            //if (checkBox2.Checked)
                            //{
                            //    if (lastItm > 0) lstVmS.Items[lastItm - 1].BackColor = Color.Empty;
                            //    lstVmS.Items[lst12].BackColor = Color.Aqua;
                            //}
                            lastItm = lst12 + 1;
                            find = true;
                            break;
                        }

                    }
                   
                }

                //ListViewItem foundItem = lstVmS.Items[1].Text.Contains(txtSearch.Text);

                //if (foundItem != null)
                //{
                //    lstVmS.TopItem = foundItem;

                //}
            }
            catch { }
        }
    }
}