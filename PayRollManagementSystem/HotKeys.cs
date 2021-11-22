using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EDPMessageBox;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Edpcom;
using System.Collections;
namespace PayRollManagementSystem
{
    public partial class HotKeys : EDPComponent.FormBaseLarge 
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection con = new Edpcom.EDPConnection();
        SqlCommand com = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Hashtable link = new Hashtable();
        SqlCommandBuilder cb;
        DataTable keys = new DataTable();    
        int flag;
       
        public HotKeys()
        {
            InitializeComponent();            
        }

        void Fill()
        {
            try
            {
                if (Information.IsNothing(ds.Tables["fillmeu"]) == false)
                {
                    ds.Tables["fillmeu"].Clear();
                }
                dgv.DataSource = null;
                con.Open();
                com = new SqlCommand("select * from MenuTable where parentcode<>'0'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "fillmeu");
                cb = new SqlCommandBuilder(da);
                con.Close();
                dgv.DataSource = ds.Tables["fillmeu"];
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Visible = false;
                dgv.Columns[3].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[5].Visible = false;
                dgv.Columns[7].Visible = false;
                dgv.Columns[2].HeaderText = "Menu Description";
                dgv.Columns[6].HeaderText = "Shortcut";
                comboBox1.SelectedIndex = 0;
                link.Clear();
                for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                {
                    if (dgv.Rows[i].Cells[6].Value.ToString().Trim().Length != 0)
                    {
                        link.Add(dgv.Rows[i].Cells[6].Value, i);
                    }
                }
            }
            catch { con.Close(); }
        }

        private void HotKeys_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Setting Hotkeys";
                edpcom.UpdateMidasLog(this, true);
                edpcom.setFormPosition(this);
                common.FormX = this.Location.X;
                common.FormY = this.Location.Y;
                //this.BackColor = Color.FromArgb(edpcom.Get_Color[0], edpcom.Get_Color[1], edpcom.Get_Color[2]);
                Fill();
            }
            catch { }
        }

        private void HotKeys_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void HotKeys_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                edpcom.UpdateMidasLog(this, false);
                edpcom.saveFormPosition(this.Name, this.Location);
            }
            catch { }
        }

        private void dgv_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo Dhit;
                Dhit = dgv.HitTest(e.X, e.Y);
                if (e.Button == MouseButtons.Right)
                {
                    if (Dhit.ColumnIndex == 6)
                    {
                        dgv.ClearSelection();
                        assing.Show(dgv, new Point(e.X, e.Y));
                        dgv.Rows[Dhit.RowIndex].Selected = true;
                        dgv.CurrentCell = dgv[Dhit.ColumnIndex, Dhit.RowIndex];
                    }
                }
            }
            catch { }
        }

        private void setSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool bu = IsSystemDefine(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value.ToString());
                if (bu)
                {
                    if (((!chbAlt.Checked) && (!chbShift.Checked) && (!chbCtrl.Checked)) || (comboBox1.SelectedIndex==-1))
                    {
                        if (comboBox1.Text.Length <= 1)
                        {
                            EDPMessage.Show("Invalid Short Cut Key.");
                            return;
                        }
                    }
                    string key = "";
                    if (chbAlt.Checked)
                        key = "Alt+";
                    if (chbShift.Checked)
                        key = key + "Shift+";
                    if (chbCtrl.Checked)
                        key = key + "Ctrl+";
                    key = key + comboBox1.Text;

                    if (Information.IsNothing(link[key]) == false)
                    {
                        int row = Convert.ToInt32(link[key]);
                        EDPMessage.Show("Already assign on " + dgv.Rows[row].Cells[2].Value.ToString(), "Information");
                        return;
                    }
                    dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value = key;
                    link.Add(key, dgv.CurrentCell.RowIndex);
                }
                else
                {
                    EDPMessage.Show("Can't set shortcut key on this menu," + Environment.NewLine + "this key is system define.", "Information");
                }
            }
            catch { }
        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool bu = IsSystemDefine(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value.ToString());
                if (bu)
                {
                    link.Remove(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value);
                    dgv.Rows[dgv.CurrentCell.RowIndex].Cells[6].Value = " ";                    
                }
                else
                {
                    EDPMessage.Show("Can't set shortcut key on this menu," + Environment.NewLine + "this key is system define.", "Information");
                }
            }
            catch { }
        }

        bool IsSystemDefine(string key)
        {
            try
            {
                if (key.Trim().Length == 0)
                {
                    return true;
                }
                int i = key.IndexOf("+");
                if (i < 0)
                {
                    string s = key.Substring(0, 1);
                    if (s.ToUpper() == "F")
                    {
                        return false;
                    }
                }
                else
                {
                    string s = key.Substring(i + 1);
                    string s1 = s.Substring(0, 1);
                    if (s1.ToUpper() == "F")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                return true;
            }
            catch { return false; }
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.CurrentCell = dgv[2, 0];
                con.Open();
                da.Update(ds.Tables["fillmeu"]);
                con.Close();
                EDPMessage.Show("Successfully Saved", "Message");
                Fill();
                common.Flug_Save = true;
                this.Close();              
            }
            catch { con.Close(); }
        }       

        public void hkprint()
        {
            con.Open();
            com = new SqlCommand("select DETAILDESC[col1],SHORTCUT_KEY[col2] from MenuTable where parentcode<>'0'", con.mycon);
            da.SelectCommand = com;
            da.Fill(keys);
            cb = new SqlCommandBuilder(da);
            con.Close();

            edpcom.Printheader();
            string company = edpcom.Branch_Name;
            string Address = edpcom.Branch_Address;
            string Address1 = edpcom.Branch_Address2;
            string Heading = "Details of Hotkeys";
            /*  hotkeysview hkview = new hotkeysview();
              hkview.hotkeyshow(keys,1);
              hkview.ShowDialog();        */
            //int flag = 0;
            //============================Report Header============================================
            ////////////MidasReport.Form1 MR = new MidasReport.Form1();

            string[] Report_Header = new string[5];
            string[] Report_Header_FontName = new string[5];
            string[] Report_Header_FontSize = new string[5];
            string[] Report_Header_FontStyle = new string[5];

            string TopVal = "2,0,0,0,0";
            string Widt1hVal = "1150,1150,1150,1150,1150";
            string HeightVal = "6,6,6,6,6";// "226,226,226,226";
            string LeftVal = "0,0,0,0,0";
            string AlignVal = "M,M,M,M,M";
            Report_Header[0] = edpcom.Branch_Name;
            Report_Header[1] = edpcom.Branch_Address;
            Report_Header[2] = edpcom.Branch_Address2;
            Report_Header[3] = "";
            Report_Header[4] = "Details of Hotkeys";
            for (int i = 0; i < Report_Header.Length; i++)
            {
                Report_Header_FontName[i] = "Arial";
                Report_Header_FontSize[i] = "10";
                Report_Header_FontStyle[i] = "B";
            }
            //////////////MR.ReportHeaderArrenge(Report_Header, TopVal, Widt1hVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle);
            //=================================End===========================================
            //============================Report Page Header============================================
            string[] Report_Page_Header = new string[2];
            string[] Report_PageHeader_FontName = new string[2];
            string[] Report_PageHeader_FontSize = new string[2];
            string[] Report_PageHeader_FontStyle = new string[2];

            TopVal = "2,0";
            Widt1hVal = "200,200";
            HeightVal = "6,6";// "226,226,226,226";
            LeftVal = "2,2";
            AlignVal = "L,L";  //L for Left,R for Right,M for center

            Report_Page_Header[0] = edpcom.Branch_Name;
            Report_Page_Header[1] = "Details of Hotkeys";

            Report_PageHeader_FontName[0] = "Arial";
            Report_PageHeader_FontName[1] = "Arial";
            Report_PageHeader_FontSize[0] = "8";
            Report_PageHeader_FontSize[1] = "8";
            Report_PageHeader_FontStyle[0] = "B";
            Report_PageHeader_FontStyle[1] = "B";
            //////////////MR.ReportPageHeaderArrenge(Report_Page_Header, TopVal, Widt1hVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle);
            //====================================End===========================================
            //============================Report Page Footer============================================
            string[] Report_PageFooter = new string[2];
            string[] Report_PageFooter_FontName = new string[2];
            string[] Report_PageFooter_FontSize = new string[2];
            string[] Report_PageFooter_FontStyle = new string[2];

            TopVal = "1,0";
            Widt1hVal = "190,35";
            HeightVal = "6,6";// "226,226,226,226";
            LeftVal = "2,160";
            AlignVal = "R,R";

            Report_PageFooter[0] = "";
            Report_PageFooter_FontName[0] = "Arial";
            Report_PageFooter_FontName[1] = "Times New Roman";
            Report_PageFooter_FontSize[0] = "8";
            Report_PageFooter_FontSize[1] = "8";
            Report_PageFooter_FontStyle[0] = "B";
            ////////////////Report_PageFooter_FontStyle[1] = "B";
            ////////////////MR.ReportPageFooterArrenge(Report_PageFooter, TopVal, Widt1hVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontSize, Report_PageFooter_FontStyle);
            ////====================================End===========================================

            ////============================Report Footer============================================
            string[] Report_Footer = new string[1];
            string[] Report_Footer_FontName = new string[1];
            string[] Report_Footer_FontSize = new string[1];
            string[] Report_Footer_FontStyle = new string[1];

            TopVal = "2";
            Widt1hVal = "155";
            HeightVal = "8";// "226,226,226,226";
            LeftVal = "2";
            AlignVal = "L";

            Report_Footer[0] = " ";
            //Report_Footer[1] = Convert.ToString(total_Qty);
            Report_Footer_FontName[0] = "Times New Roman";
            //Report_Footer_FontName[1] = "Times New Roman";
            Report_Footer_FontSize[0] = "10";
            //Report_Footer_FontSize[1] = "10";
            Report_Footer_FontStyle[0] = "B";
            //Report_Footer_FontStyle[1] = "B";
            ////////////MR.ReportFooterArrenge(Report_Footer, TopVal, Widt1hVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle);
            //====================================End===========================================
            //============================Details Columns Header============================================
            int Col_Count = keys.Columns.Count;
            string[] Report_Columns_Header = new string[Col_Count];
            string[] Report_Columns_Header_FontName = new string[Col_Count];
            string[] Report_Columns_Header_FontSize = new string[Col_Count];
            string[] Report_Columns_Header_FontStyle = new string[Col_Count];

            //if (chk_Product.Checked)
            //{
            //}
            Report_Columns_Header[0] = "Detail Description";
            Report_Columns_Header[1] = "Shortcut Keys";




            for (int i = 0; i < keys.Columns.Count; i++)
            {
                Report_Columns_Header_FontName[i] = "Times New Roman";
                Report_Columns_Header_FontSize[i] = "8";
                Report_Columns_Header_FontStyle[i] = "B";
            }

            Widt1hVal = "130,90";
            LeftVal = "8,0";
            HeightVal = "1,1";
            AlignVal = "L,M";

            int LC = 140;
            int Ledg_Count = 0;

            //////////////MR.DetailsColumnsHeaderArrenge(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle);
            //////////////MR.DetailsColumnsArrenge(TopVal, Widt1hVal, HeightVal, LeftVal, AlignVal);
            //===================================End====================================================
            if (flag == 0)
            {
                ////////////MR.Graphic_Preview(keys);
            }
            else if (flag == 1)
            {
                ////////////MR.Graphic_Print(keys);
            }
            ////////////MR.ShowDialog();
        }
        
        private void vistaButton2_Click(object sender, EventArgs e)
        {
            flag = 0;
            hkprint();
            keys.Clear();
        }

        private void vistaButton3_Click(object sender, EventArgs e)
        {
            flag = 1;
            hkprint();
            keys.Clear();
        }

        private void txtsrch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int lst_count = 0;
                lst_count = dgv.Rows.Count - 1;

                int txt_length;
                txt_length = txtsrch.Text.Length;
                if (txt_length <= -1)
                {
                    txt_length = 0;
                }
                for (int i = 0; i <= lst_count; i++)
                {
                    string x1 = "", x2 = "";
                    x1 = Convert.ToString(dgv.Rows[i].Cells[2].Value);
                    x1 = x1.ToLower();
                    if (txt_length >= x1.Length)
                    {
                        int z1;
                        z1 = txt_length - (x1.Length);
                        txt_length -= z1;
                    }
                    x2 = Convert.ToString(x1.Substring(0, txt_length));
                    if (x2 == txtsrch.Text.ToLower())
                    {
                        dgv.Rows[i].Cells[2].Selected = true;
                        dgv.CurrentCell = dgv[2, i];
                        break;
                    }
                    txt_length = txtsrch.Text.Length;
                }
            }
            catch { }
        }
    }
}
      
