using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Edpcom;
using Microsoft.VisualBasic;
using System.Collections;

namespace EDPComponent
{
    public partial class frmListAddRemove : EDPComponent.FormBase
    {
        
        //Edpcom.EDPConnection con = new EDPConnection();
        //Edpcom.EDPCommon edpcom = new EDPCommon();
        //SqlCommand cmd = new SqlCommand();
        //SqlDataAdapter da = new SqlDataAdapter();
        //Boolean select_flg;
        //public frmListAddRemove()
        //{
        //    InitializeComponent();
        //}

        //private void lblClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void lblMinz_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //}

        //private void frmListAddRemove_Load(object sender, EventArgs e)
        //{
        //    this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
        //    lstVmS.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
        //    AddItemList();
        //    select_flg = true;
        //}

        //public void AddItemList()
        //{
        //    if (Modual1.qry_dt == 1)
        //    {
        //        HeaderText = Modual1.Caption;
        //        lblTag.Text = Modual1.Header;
        //        lstVmS.Items.Clear();
        //        lstVmS.View = View.Details;
        //        lstVmS.Columns.Add(Modual1.ClmHeader.ToString(), 300);
        //        for (int i = 0; i <= Modual1.STCK_DS.Tables["MLOV"].Rows.Count - 1; i++)
        //        {
        //            ListViewItem lsti = new ListViewItem(Modual1.STCK_DS.Tables["MLOV"].Rows[i][0].ToString());
        //            lsti.SubItems.Add(Modual1.STCK_DS.Tables["MLOV"].Rows[i][1].ToString());
        //            lstVmS.Items.Add(lsti);
        //        }
        //    }
        //    else
        //    {
        //        if (Information.IsNothing(Modual1.STCK_DS.Tables[Modual1.StckTb]) == false)
        //        {
        //            Modual1.STCK_DS.Tables[Modual1.StckTb].Clear();
        //            Modual1.STCK_DS.Tables.Clear();
        //        }
        //        HeaderText = Modual1.Caption;
        //        lblTag.Text = Modual1.Header;
        //        lstVmS.Items.Clear();
        //        lstVmS.View = View.Details;
        //        int i;
        //        con.Open();
        //        string str = Modual1.Query;
        //        cmd = new SqlCommand(str, con.mycon);
        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //        catch
        //        {
        //            con.Close();
        //        }
        //        da.SelectCommand = cmd;
        //        da.Fill(Modual1.STCK_DS, Modual1.StckTb);
        //        if (Information.IsNothing(Modual1.STCK_DS.Tables[Modual1.StckTb]) == true)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            for (i = 0; i <= Modual1.STCK_DS.Tables[Modual1.StckTb].Columns.Count - 1; i++)
        //            {
        //                lstVmS.Columns.Add(Modual1.STCK_DS.Tables[Modual1.StckTb].Columns[i].ColumnName.ToString(), 390, HorizontalAlignment.Center);
        //            }
        //            for (i = 0; i <= Modual1.STCK_DS.Tables[Modual1.StckTb].Rows.Count - 1; i++)
        //            {
        //                ListViewItem lsti = new ListViewItem(Modual1.STCK_DS.Tables[Modual1.StckTb].Rows[i][0].ToString());
        //                lsti.SubItems.Add(Modual1.STCK_DS.Tables[Modual1.StckTb].Rows[i][1].ToString());
        //                lsti.SubItems.Add(Modual1.STCK_DS.Tables[Modual1.StckTb].Rows[i][2].ToString());
        //                lstVmS.Items.Add(lsti);
        //            }
        //        }
        //    }
        //}

        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void btnOk_Click(object sender, EventArgs e)
        //{
        //    ArrayList arrlst = new ArrayList();
        //    Hashtable lclcode = new Hashtable();
        //    int i;
        //    for (i = 0; i <= lstVmS.Items.Count - 1; i++)
        //    {
        //        if (lstVmS.Items[i].Checked == true)
        //        {
        //            arrlst.Add(lstVmS.Items[i].Text.ToString());
        //            int cnt = arrlst.Count-1;
        //            lclcode.Add(cnt, lstVmS.Items[i].SubItems[1].Text);
        //        }
        //    }
        //    if (arrlst.Count > 0)
        //    {
        //        Modual1.arr_mod = arrlst;
        //        Modual1.get_code = lclcode;
        //        this.Close();
        //    }
        //    else
        //    {                
        //        EDPMessageBox.EDPMessage.Show("Do you want to select items?", "Confirm!", EDPMessageBox.EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessageBox.EDPMessage.MessageBoxIcon.EDP_QUESTION);
        //        if (EDPMessageBox.EDPMessage.ButtonResult == "edpNO")
        //        {
        //            this.Close();
        //        }
        //    }
        //}

        //private void btn_all_Click(object sender, EventArgs e)
        //{
        //    if (select_flg == true)
        //    {                
        //        for (int i = 0; i <= lstVmS.Items.Count - 1; i++)
        //        {
        //            lstVmS.Items[i].Checked = true;
        //        }
        //        select_flg = false;
        //        btn_all.Text = "Reset";
        //    }
        //    else
        //    {
        //        for (int i = 0; i <= lstVmS.Items.Count - 1; i++)
        //        {
        //            lstVmS.Items[i].Checked = false;
        //        }
        //        select_flg =true;
        //        btn_all.Text = "Select All";
        //    }
        //}

        //private void frmListAddRemove_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        this.Close();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
    }
}