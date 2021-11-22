using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Collections;
using EDPMessageBox;

namespace Edpcom
{
    public partial class ItemSelaction : EDPComponent .FormBase
    {
        Edpcom.EDPCommon edpcom = new EDPCommon();
        EDPConnection con = new EDPConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();       
        DataTable dt = new DataTable();
        public ItemSelaction()
        {
            InitializeComponent();
        }
        DataTable dtPrvorder;
        public String[] strArrSubjects;
        
        public void SetOrderList(DataTable dt)
        {
            dtPrvorder = dt;           
        }

        private void btnmarktab_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt);
                ArrayList arrlst = new ArrayList();
                Hashtable lclcode = new Hashtable();
                for (Int32 i = 0; i < lstReorder.Items.Count; i++)
                {
                    dv.RowFilter = "col='" + lstReorder.Items[i] + "' ";
                    arrlst.Add(lstReorder.Items[i].ToString());

                    int cnt = arrlst.Count - 1;
                    lclcode.Add(i, dv[0][1]);
                }
                if (arrlst.Count > 0)
                {
                    EDPCommon.arr_mod = arrlst;
                    EDPCommon.get_code = lclcode;
                    //EDPCommon.Hsdtss = htss;
                }
                this.Close();
            }
            catch { }
        }

        private void SelectSubjectOrder_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("col", typeof(string));
            dt.Columns.Add("co2", typeof(string));
            this.Text = EDPCommon.Header;
            this.HeaderText = EDPCommon.Header;
            string str = EDPCommon.Query;
            con.Open();
            EDPCommon.ClearDataTable_EDP(ds.Tables["Existing_Item"]);
            cmd = new SqlCommand(str, con.mycon);
            da.SelectCommand = cmd;
            da.Fill(ds, "Existing_Item");
            con.Close();           
            for (Int32 i = 0; i < ds.Tables["Existing_Item"].Rows.Count; i++)
            {
                ds.Tables["Existing_Item"].Rows[i][0] = Convert.ToString(ds.Tables["Existing_Item"].Rows[i][0]).Replace("'", ""); 
                lstPrevorder.Items.Add(ds.Tables["Existing_Item"].Rows[i][0]);
                dt.Rows.Add();                
                dt.Rows[i]["col"] = ds.Tables["Existing_Item"].Rows[i][0];
                dt.Rows[i]["co2"] = ds.Tables["Existing_Item"].Rows[i][1];
            }
            txttotitem.Text = ds.Tables["Existing_Item"].Rows.Count.ToString();
            txtsarch.Focus();
            //lstPrevorder.Select();
        }


        private void btnMove_Click(object sender, EventArgs e)
        {
            int i = lstPrevorder.SelectedIndex;
            int j = lstPrevorder.Items.Count;
            if (!String.IsNullOrEmpty(Convert.ToString(lstPrevorder.SelectedItem)))
            {
                lstReorder.Items.Add(lstPrevorder.SelectedItem);
                lstPrevorder.Items.Remove(lstPrevorder.SelectedItem);
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("Please Select An Item To Move");
            }            
            txtselectitem.Text = lstReorder.Items.Count.ToString();
            txttotitem.Text = lstPrevorder.Items.Count.ToString();
            if (lstPrevorder.Items.Count > 1)
            {
                if (j > i + 1)
                {
                    lstPrevorder.Select();
                    lstPrevorder.SelectedIndex = i;
                }
                else
                {
                    lstPrevorder.Select();
                    lstPrevorder.SelectedIndex = i - 1;
                }
            }
        }

        private void btnMoveAll_Click(object sender, EventArgs e)
        {
            if (lstPrevorder.Items.Count > 0)
            {
                if (lstReorder.Items.Count <= 0)
                {
                    lstReorder.Items.Clear();
                }
                for (Int32 i = 0; i < lstPrevorder.Items.Count; i++)
                {
                    lstReorder.Items.Add(lstPrevorder.Items[i]);
                    //lstPrevorder.Items.Remove(lstPrevorder.Items[i]);
                }
                lstPrevorder.Items.Clear();
            }
            txtselectitem.Text = lstReorder.Items.Count.ToString();
            txttotitem.Text = lstPrevorder.Items.Count.ToString();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            int i = lstReorder.SelectedIndex;
            int j = lstReorder.Items.Count;
            if (!String.IsNullOrEmpty(Convert.ToString(lstReorder.SelectedItem)))
            {
                lstPrevorder.Items.Add(lstReorder.SelectedItem);
                //lstPrevorder
                lstReorder.Items.Remove(lstReorder.SelectedItem);                
            }
            else
            {
                EDPMessageBox.EDPMessage.Show("Please Select An Item To Move");
            }
            txtselectitem.Text = lstReorder.Items.Count.ToString();
            txttotitem.Text = lstPrevorder.Items.Count.ToString();

            if (lstReorder.Items.Count > 1)
            {
                if (j > i + 1)
                {
                    lstReorder.Select();
                    lstReorder.SelectedIndex = i;
                }
                else
                {
                    lstReorder.Select();
                    lstReorder.SelectedIndex = i - 1;
                }
            }           
        }

        private void btnPrevAll_Click(object sender, EventArgs e)
        {
            if (lstReorder.Items.Count > 0)
            {
                if (lstPrevorder.Items.Count <= 0)
                {
                    lstPrevorder.Items.Clear();
                }
                for (Int32 i = 0; i < lstReorder.Items.Count; i++)
                {
                    lstPrevorder.Items.Add(lstReorder.Items[i]);
                    //lstPrevorder.Items.Remove(lstPrevorder.Items[i]);
                }
                lstReorder.Items.Clear();
            }
            txtselectitem.Text = lstReorder.Items.Count.ToString();
            txttotitem.Text = lstPrevorder.Items.Count.ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ItemSelaction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.S)
                    btnMoveAll_Click(sender, e);
                if (e.KeyCode == Keys.D)
                    btnPrevAll_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5)
                btnmarktab_Click(sender, e);
        }
        private void lstPrevorder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                btnMove_Click(sender, e);
        }

        private void lstReorder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                btnPrev_Click(sender, e);
        }

        private void txtsarch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                int lst_count = Convert.ToInt32(txttotitem.Text);
                int txt_length;
                txt_length = txtsarch.Text.Length;
                if (txt_length <= -1)
                {
                    txt_length = 0;
                }
                for (int i = 0; i < lst_count; i++)
                {
                    string x1, x2;
                    x1 = lstPrevorder.Items[i].ToString();
                    x1 = x1.ToLower();
                    if (txt_length >= x1.Length)
                    {
                        int z1;
                        z1 = txt_length - (x1.Length);
                        txt_length -= z1;
                    }
                    x2 = Convert.ToString(x1.Substring(0, txt_length));
                    if (x2 == txtsarch.Text.ToLower())
                    {
                        //lsthead.Select();
                        lstPrevorder.SelectedIndex = i;
                        break;
                    }
                    txt_length = txtsarch.Text.Length;
                }
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.Message);
            }
        }

        private void txtsarch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Right)
                {
                    btnMove_Click(sender, e);
                    txtsarch.Focus();                  
                }               
            }
            catch { }
        }

        private void txtsarch1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int lst_count = Convert.ToInt32(txtselectitem.Text);
                int txt_length;
                txt_length = txtsarch1.Text.Length;
                if (txt_length <= -1)
                {
                    txt_length = 0;
                }
                for (int i = 0; i < lst_count; i++)
                {
                    string x1, x2;
                    x1 = lstReorder.Items[i].ToString();
                    x1 = x1.ToLower();
                    if (txt_length >= x1.Length)
                    {
                        int z1;
                        z1 = txt_length - (x1.Length);
                        txt_length -= z1;
                    }
                    x2 = Convert.ToString(x1.Substring(0, txt_length));
                    if (x2 == txtsarch1.Text.ToLower())
                    {
                        //lsthead.Select();
                        lstReorder.SelectedIndex = i;
                        break;
                    }
                    txt_length = txtsarch1.Text.Length;
                }
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.Message);
            }
        }

        private void txtsarch1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Left)
                {
                    btnPrev_Click(sender, e);
                    txtsarch1.Focus();
                }
            }
            catch { }
        }

       

       
       

    }
}