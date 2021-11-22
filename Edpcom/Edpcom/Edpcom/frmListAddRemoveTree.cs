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
    public partial class frmListAddRemoveTree : EDPComponent.FormBase
    {
        Edpcom.EDPConnection con = new EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
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
            int i;
            for (i = 0; i <= lstVmS.Items.Count - 1; i++)
            {
                if (lstVmS.Items[i].Checked == true)
                {
                    arrlst.Add(lstVmS.Items[i].Text.ToString());
                    int cnt = arrlst.Count - 1;
                    lclcode.Add(cnt, lstVmS.Items[i].SubItems[1].Text);
                }
            }
            if (arrlst.Count > 0)
            {                
                EDPCommon.arr_mod = arrlst;
                EDPCommon.get_code = lclcode;
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
            this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
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
                    HeaderText = EDPCommon.Caption;
                    lblTag.Text = EDPCommon.Header;
                    lstVmS.Items.Clear();
                    lstVmS.View = View.Details;
                    lstVmS.Columns.Add(EDPCommon.ClmHeader.ToString(), 300);
                    for (int i = 0; i <= EDPCommon.STCK_DS.Tables["MLOV"].Rows.Count - 1; i++)
                    {
                        ListViewItem lsti = new ListViewItem(EDPCommon.STCK_DS.Tables["MLOV"].Rows[i][0].ToString());
                        lsti.SubItems.Add(EDPCommon.STCK_DS.Tables["MLOV"].Rows[i][1].ToString());
                        lstVmS.Items.Add(lsti);
                    }
                }
                else
                {
                    if (Information.IsNothing(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb]) == false)
                    {
                        EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Clear();
                        EDPCommon.STCK_DS.Tables.Clear();
                    }
                    HeaderText = EDPCommon.Caption;
                    lblTag.Text = EDPCommon.Header;
                    lstVmS.Items.Clear();
                    lstVmS.View = View.Details;
                    int i;
                    con.Open();
                    string str = EDPCommon.Query;
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
                    if (Information.IsNothing(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb]) == true)
                    {
                        return;
                    }
                    else
                    {
                        for (i = 0; i <= EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Columns.Count - 1; i++)
                        {
                            lstVmS.Columns.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Columns[i].ColumnName.ToString(), 390, HorizontalAlignment.Center);
                        }
                        for (i = 0; i <= EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows.Count - 1; i++)
                        {
                            ListViewItem lsti = new ListViewItem(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][0].ToString());
                            lsti.SubItems.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][1].ToString());
                            lsti.SubItems.Add(EDPCommon.STCK_DS.Tables[EDPCommon.StckTb].Rows[i][2].ToString());
                            lstVmS.Items.Add(lsti);
                        }
                    }
                }
            }
            catch { }
        }
    }
}