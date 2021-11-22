using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.Collections;
using EDPMessageBox;

namespace PayRollManagementSystem
{
    public partial class frmUserdetails :EDPComponent.FormBase
    {
        Edpcom.EDPCommon EDPCOMM = new EDPCommon();
        Edpcom.EDPConnection con = new EDPConnection();
        SqlCommand com = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ArrayList KeepGCode = new ArrayList();
        ArrayList per_menu = new ArrayList();
        ArrayList per_company = new ArrayList();
        SqlTransaction SQLT;
        string info_user = "";
        int BlinkRate, count = 0, index = 0, infoUsr=0,hide_pfesi=0;
        Boolean flug_selection = false, flug_Type = false,flug_Type_com = false;
        string g_code, encrypt,errcompany;
        public frmUserdetails()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                textBox1.Enabled = true;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = true;
            }
        }
        private void frmUserdetails_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]);
            //tabPage1.BackColor = Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]);
            //tabPage2.BackColor = Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]);
            //tabPage3.BackColor = Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]);
            //tabPage4.BackColor = Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]);
            //tabPage5.BackColor = Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]);
            //tabPage6.BackColor = Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]);
            //tabPage7.BackColor = Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]);
            if (Convert.ToInt32(EDPCOMM.GetresultS("select count(*) from pasword")) >= Convert.ToInt32(EDPCOMM.GetresultS("select user_limit+3 from CompanyLimiter")))
            {
                MessageBox.Show("User Limit Reached", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
           
            this.Text = "   User Details";
            radioButton2.Checked = true;
            common.ArrLiFORCOMTREE.Clear();
            common.ArrLiFORMENUTREE.Clear();
            try
            {
                Tree_Gen(MENUTREE);
               
                con.Open();
                com = new SqlCommand("select USER_DESC,USER_LEV from pasword where user_code not in(2,3)", con.mycon);
                // S Dutta Cloude Base
                //com = new SqlCommand("select p.USER_DESC,p.USER_LEV from pasword p ,usercontrol u  where p.user_code not in(2,3) and p.user_code=u.user_code and u.superuser='" + EDPComm.CurrentSuperuser + "' and ficode='" + EDPComm.CurrentFicode + "'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "chk_user");
                con.Close();
                int i = Convert.ToInt32(ds.Tables["chk_user"].Rows.Count - 1), j = 0;
                string Uname;

                info_user = EDPCOMM.GetresultS("select USER_LEV from pasword where user_code ='" + EDPCOMM.PCURRENT_USER + "'");
                da.SelectCommand = com;
                da.Fill(ds, "chk_curruser");
                con.Close();
                if (EDPComm.PCURRENT_USER == "1" || info_user.Trim().ToUpper() == "Superuser".ToUpper())
                {
                    while (j <= i)
                    {
                        Uname = EDPCOMM.edpcrypt(Convert.ToString(ds.Tables["chk_user"].Rows[j][0]), false);
                        Uname = Uname + " (" + Convert.ToString(ds.Tables["chk_user"].Rows[j][1]) + ")";
                        USERTREE.Nodes.Add(Uname);
                        PROFILETREE.Nodes.Add(Uname);
                        chk_hide_PF.Visible = true;
                        j++;
                    }
                }
                else
                {
                    chk_hide_PF.Visible = false;
                    con.Open();
                    com = new SqlCommand("select USER_DESC,USER_LEV from pasword where user_code='" + EDPComm.PCURRENT_USER + "'", con.mycon);
                    da.SelectCommand = com;
                    da.Fill(ds, "chk_user_current");
                    con.Close();
                    Uname = EDPCOMM.edpcrypt(Convert.ToString(ds.Tables["chk_user_current"].Rows[0][0]), false);
                    Uname = Uname + " (" + Convert.ToString(ds.Tables["chk_user_current"].Rows[0][1]) + ")";
                    USERTREE.Nodes.Add(Uname);
                    PROFILETREE.Nodes.Add(Uname);
                }
                ds.Tables["chk_user"].Clear();
                //ds.Tables["chk_user_current"].Clear();

               
                try
                {
                    ComTree(COMPANYTREE);
                }
                catch { }
               

                //tabControl1.SelectedTab = tabControl1.TabPages[1];
                tabControl3.SelectedTab = tabControl3.TabPages[0];

                //this.tabControl3.TabPages.Remove(this.tabControl3.TabPages[1]);
                                               
                timer1.Enabled = true;
                // added by moumita on 30/08/2012
                if (EDPComm.PCURRENT_USER == "1" || info_user.Trim().ToUpper() == "Superuser".ToUpper())
                {
                    //CopyFromButton1.Visible = true;
                    //CopyToButton1.Visible = true;
                    //CopyButton.Visible = true;
                    //groupBox8.Visible = true;

                    CopyFromButton1.Visible = false ;
                    CopyToButton1.Visible = false;
                    CopyButton.Visible = false;
                    groupBox8.Visible = false;

                    btnusertransaction_Click(sender, e);
                    btncompanycheck_Click(sender, e);
                    btncheck_Click(sender, e);
                }
                else
                {

                    CopyFromButton1.Visible = false;
                    CopyToButton1.Visible = false;
                    CopyButton.Visible = false;
                    groupBox8.Visible = false;
                    user_name.Enabled = false;
                    password.Enabled = false;
                    con_pass.Enabled = false;
                    remarks.Enabled = false; 
                    MENUTREE.Nodes.Clear();//added by moumita
                    COMPANYTREE.Nodes.Clear();
                    PERMISSIONTREE.Enabled = false;
                    PERMISSIONTREE_COMPANY.Enabled = false;
                    //////PERMISSIONTREE_LOCATION.Enabled = false;
                    //this.tabControl1.TabPages[1].Controls.Add(COMPANYTREE);
                }
                // added by moumita.////////////
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.ToString());
            }
        }
        public void Tree_Gen(TreeView tv)
        {
            try
            {
                if (Information.IsNothing(ds.Tables["tree_gen"]) == false)
                {
                    ds.Tables["tree_gen"].Clear();
                }
                con.Open();
                com = new SqlCommand("select * from MENUTABLE where ENABLE_MENU='True'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "tree_gen");
                con.Close();
                common.HAST.Clear();
                common.HAST1.Clear();
                int i = 0;
                int j = 0;
                string code;
                string des;
                string perent;
                string bu;
                i = ds.Tables["tree_gen"].Rows.Count - 1;
                while (j <= i)
                {
                    code = (string)ds.Tables["tree_gen"].Rows[j][0];
                    des = (string)ds.Tables["tree_gen"].Rows[j][2];
                    perent = (string)ds.Tables["tree_gen"].Rows[j][1];
                    bu = ds.Tables["tree_gen"].Rows[j][4].ToString();
                    if (perent == "0")
                    {
                        TreeNode mm = new TreeNode(des);
                        if (bu == true.ToString())
                        {
                            tv.Nodes.Add(mm);
                        }
                        common.HAST.Add(des, mm);
                        common.HAST1.Add(des, code);
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            com = new SqlCommand("select * from " + "MENUTABLE" + " where menucode=\'" + perent + "\' and ENABLE_MENU='True'", con.mycon);
                            da.SelectCommand = com;
                            da.Fill(ds, "aa11");
                            con.Close();
                            string co;
                            string per;
                            string de;
                            if (ds.Tables["aa11"].Rows.Count > 0)
                            {
                                co = (string)ds.Tables["aa11"].Rows[0][0];
                                de = (string)ds.Tables["aa11"].Rows[0][2];
                                per = (string)ds.Tables["aa11"].Rows[0][1];
                                ds.Tables["aa11"].Clear();
                                //if (int.Parse(per) == 0)
                                if (long.Parse(per) == 0)
                                {
                                    TreeNode mm = new TreeNode();
                                    mm = (System.Windows.Forms.TreeNode)common.HAST[de];
                                    TreeNode dd = new TreeNode(des);
                                    if (bu == true.ToString())
                                    {
                                        mm.Nodes.Add(dd);
                                    }
                                    common.HAST.Add(des, dd);
                                    common.HAST1.Add(des, code);
                                }
                                else
                                {
                                    TreeNode mm = new TreeNode();
                                    mm = (System.Windows.Forms.TreeNode)common.HAST[de];
                                    TreeNode dd = new TreeNode(des);
                                    if (bu == true.ToString())
                                    {
                                        mm.Nodes.Add(dd);
                                    }
                                    try
                                    {
                                        common.HAST.Add(des, dd);
                                        common.HAST1.Add(des, code);
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                   
                    j++;
                }
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.ToString());
            }
        }


        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (info_user.Trim().ToUpper() != ("Superuser").ToUpper())//EDPComm.PCURRENT_USER != "1"
                index = tabControl1.SelectedIndex;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (info_user.Trim().ToUpper() != ("Superuser").ToUpper())//EDPComm.PCURRENT_USER != "1"
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    tabControl1.SelectedIndex = index;
                }
            }
        }
        private void MENUTREE_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Checked == true)
                {
                    common.ArrLiFORMENUTREE.Add(e.Node.Text);
                    // added by moumita on 25/08/2012

                    //int i=0;
                    TreeNode parent_node = e.Node;
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        parent_node.Nodes[i].Checked = true;
                    }
                    /// added by moumita/////////////
                }
                else
                {
                    common.ArrLiFORMENUTREE.Remove(e.Node.Text);
                    /// added by moumita on 27/08/2012
                    TreeNode parent_node = e.Node;
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        parent_node.Nodes[i].Checked = false;
                    }
                    /// added by moumita//////////////
                }
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.ToString());
            }
        }
        private void COMPANYTREE_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ////////common.ArrLiFORCOMTREE.Add("Abc");

            //if (flug_selection == true)
            //{                
            //    try
            //    {
            //        if (e.Node.Checked == true)
            //        {
            //            common.ArrLiFORCOMTREE.Add(e.Node.Text);  //block 
            //            //common.ArrLiFORCOMTREE.Add("Abc");

            //            // added by moumita on 25/08/2012

            //            //int i=0;
            //            TreeNode parent_node = e.Node;
            //            for (int i = 0; i < e.Node.Nodes.Count; i++)
            //            {
            //                parent_node.Nodes[i].Checked = true;
            //            }
            //            /// added by moumita/////////////
            //        }
            //        else
            //        {
            //            common.ArrLiFORCOMTREE.Remove(e.Node.Text);
            //            /// added by moumita on 27/08/2012
            //            TreeNode parent_node = e.Node;
            //            for (int i = 0; i < e.Node.Nodes.Count; i++)
            //            {
            //                parent_node.Nodes[i].Checked = false;
            //            }
            //            /// added by moumita//////////////
            //        }
            //        flug_selection = false;
            //    }
            //    catch (Exception ex)
            //    {
            //        EDPMessage.Show(ex.ToString());
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        if (e.Node.Checked == true)
            //        {
            //            for (int i = 0; i <= common.ArrLiFORCOMTREE.Count - 1; i++)
            //            {
            //                if (common.ArrLiFORCOMTREE[i].ToString() == e.Node.Text)
            //                {
            //                    common.ArrLiFORCOMTREE.Remove(e.Node.Text);
            //                }
            //            }
            //            //////common.ArrLiFORCOMTREE.Add("abc"); //e.Node.Text 
            //        }
            //        else
            //        {
            //            common.ArrLiFORCOMTREE.Remove(e.Node.Text);
            //        }
            //        if (e.Node.Parent != null)
            //        {
            //            e.Node.Parent.Checked = true;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        EDPMessage.Show(ex.ToString());
            //    }
            //}

            try
            {
                if (e.Node.Checked == true)
                {
                    common.ArrLiFORCOMTREE.Add(e.Node.Text);
                    // added by moumita on 25/08/2012

                    //int i=0;
                    TreeNode parent_node = e.Node;
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        parent_node.Nodes[i].Checked = true;
                    }
                    /// added by moumita/////////////
                }
                else
                {
                    common.ArrLiFORCOMTREE.Remove(e.Node.Text);
                    /// added by moumita on 27/08/2012
                    TreeNode parent_node = e.Node;
                    for (int i = 0; i < e.Node.Nodes.Count; i++)
                    {
                        parent_node.Nodes[i].Checked = false;
                    }
                    /// added by moumita//////////////
                }
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.ToString());
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(EDPCOMM.GetresultS("select count(*) from pasword")) >= Convert.ToInt32(EDPCOMM.GetresultS("select user_limit+3 from CompanyLimiter")))
            {
                MessageBox.Show("User Limit Reached", "BRAVO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }
                string pass_valid;
            KeepGCode.Clear();
            try
            {
                //string strn = EDPCOMM.edpcrypt("1001", true);
                if (user_name.Text.Length == 0)
                {
                    EDPMessage.Show("UserName can't be blank", "Information....");
                    user_name.Focus();
                    return;
                }

                //added by moumita on 8.9.2012//
                //if (Convert.ToInt32(user_name.Text) < 2000000)
                //{
                //    EDPMessage.Show("UserName can't be less than 2000000", "Information....");
                //    user_name.Text = "";
                //    password.Text = "";
                //    con_pass.Text = "";
                //    remarks.Text = "";
                //    user_name.Focus();
                //    return;
                //}
                // ended by moumita on 8.9.2012//
                if (password.Text.Length == 0)
                {
                    EDPMessage.Show("Password can't be blank", "Information....");
                    password.Focus();
                    return;
                }
                if (con_pass.Text.Length == 0)
                {
                    EDPMessage.Show("Confirmation Password can't be blank", "Information....");
                    con_pass.Focus();
                    return;
                }
                else
                {
                    if (password.Text != con_pass.Text)
                    {
                        EDPMessage.Show("Mismatch between Password and Confirm Password", "Information....");
                        password.Text = "";
                        con_pass.Text = "";
                        password.Focus();
                        return;
                    }
                }
                if (common.ArrLiFORMENUTREE.Count - 1 < 0)
                {
                    EDPMessage.Show("No permission found in Access Menu", "Information......");
                    return;
                }

                //partha

                if (common.ArrLiFORCOMTREE.Count - 1 < 0)
                {
                    EDPMessage.Show("No permission found in Access Company", "Information......");
                    return;
                }
                //partha

                //  int UCode =Convert.ToInt32(Registry.CurrentUser.OpenSubKey("PayRollManagementSystemGold").OpenSubKey("Company").GetValue("Lusercode"));
                int UCode = Convert.ToInt32(EDPCOMM.GetresultS("select isNull(max(cast(user_code as int)),0)+1 from pasword"));
                //19-03-2018 // UCode++;
                string datewise;
                int sessionwise = 0;
                if (radioButton1.Checked == true)
                {
                    if (Information.IsNumeric(textBox1.Text) == false)
                    {
                        EDPMessage.Show("Enter Session!", "Message");
                        textBox1.Focus();
                        return;
                    }
                    else
                    {
                        if (Convert.ToInt32(textBox1.Text) <= EDPCOMM.CURRENTSESSION)
                        {
                            EDPMessage.Show("Accept denied! Session must be greater than Current Session.", "Message", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_WARNING);
                            textBox1.Text = "";
                            textBox1.Focus();
                            return;
                        }
                        else
                        {
                            sessionwise = Convert.ToInt32(textBox1.Text);
                            pass_valid = "S";
                        }
                    }
                }
                else
                {
                    sessionwise = 0;
                    pass_valid = "D";
                }
                if (radioButton2.Checked == true)
                {
                    datewise = EDPCOMM.getSqlDateStr(dateTimePicker1.Value);
                    pass_valid = "D";
                }
                else
                {
                    datewise = EDPCOMM.getSqlDateStr(dateTimePicker1.Value);
                    pass_valid = "S";
                }
                string uslev = remarks.Text;
                if (uslev.Length == 0)
                {
                    uslev = "User";
                }
                /*con.Open();
                com = new SqlCommand("select * from pasword where USER_DESC='" + EDPCOMM.edpcrypt(user_name.Text, true) + "'", con.mycon);
                da.SelectCommand = com;
                bool bul = Convert.ToBoolean(da.Fill(ds, "chk_user_exist"));
                con.Close();
                ds.Tables["chk_user_exist"].Clear();*/
                string cnt_pass = clsDataAccess.GetresultS("select count(*) from pasword where (USER_DESC='" + EDPCOMM.edpcrypt(user_name.Text, true) + "')");
               // if (bul == true)
                if (cnt_pass!="0")
                {
                    EDPMessage.Show(user_name.Text + " User Already Exist", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                    user_name.Text = "";
                    user_name.Focus();
                    return;
                }
                con.Open();
                EDPCOMM.edpcrypt(user_name.Text, true);
                SQLT = con.mycon.BeginTransaction();
                // added by moumita///

                //comment by bibhas - 19/03/2018//com = new SqlCommand("select user_code from pasword", con.mycon, SQLT);
                ////da.SelectCommand = com;
                ////bool bul1 = Convert.ToBoolean(da.Fill(ds, "user_pass_chk_mou"));

                ////if (bul1 == true)
                ////{
                ////    for (int k = 0; k < ds.Tables["user_pass_chk_mou"].Rows.Count; k++)
                ////    {
                ////        if (UCode.ToString() == ds.Tables["user_pass_chk_mou"].Rows[k][0].ToString())
                ////            UCode++;
                ////        else
                ////            continue;
                ////    }
                ////}
                ////ds.Tables["user_pass_chk_mou"].Clear();
                ///added by moumita////
                com = new SqlCommand("insert into pasword values('" + UCode.ToString() + "','" + EDPCOMM.edpcrypt(user_name.Text, true) + "','" + "0" + "','" + uslev + "','" + EDPCOMM.edpcrypt(con_pass.Text, true) + "'," + 0 + ",'" + datewise + "'," + sessionwise + "," + 0 + ",'" + pass_valid + "'," + 0 + ",1)", con.mycon, SQLT);
                com.ExecuteNonQuery();
                cnt_pass = clsDataAccess.GetresultS("select count(*) from UserControl where (USER_CODE='" + UCode + "')");
                if (cnt_pass == "0")
                {
                    com = new SqlCommand("insert into UserControl(Ficode,Gcode,UGcode,USGcode,SuperUser,USER_CODE) values('1','1','" + EDPComm.CurrentUGcode + "','0','" + EDPComm.CurrentSuperuser + "','" + UCode + "')", con.mycon, SQLT); //'" + EDPComm.CurrentFicode + "','" + EDPComm.PCURRENT_GCODE + "' //partha
                    com.ExecuteNonQuery();
                }
                cnt_pass = "";
                //con.Close();
                int TUcode = UCode;
                UCode++;
                Registry.CurrentUser.CreateSubKey("PayRollManagementSystem").CreateSubKey("Company").SetValue("Lusercode", UCode.ToString());
                USERTREE.Nodes.Add(user_name.Text + " (" + uslev + ")");
                PROFILETREE.Nodes.Add(user_name.Text + " (" + uslev + ")");
                EDPCOMM.InsertMidasLog(this, true, "add", user_name.Text);

                ///

                if (per_company.Count == 0)
                {
                    for (int i = 0; i < common.ArrLiFORCOMTREE.Count; i++)
                    {
                        per_company.Add(common.ArrLiFORCOMTREE[i]);
                    }
                }

                for (int i = 0; i < per_company.Count; i++)
                {
                    for (int j = i + 1; j < per_company.Count; j++)
                    {
                        if (per_company[i].ToString() == per_company[j].ToString())
                            per_company.Remove(per_company[j]);
                    }
                }

                ///

               int count = Convert.ToInt32(common.ArrLiFORCOMTREE.Count - 1), z = 0;
             


                
                ////////////// partha
                string com_nm, b_code, temp, fi_code, m_code;
                while (z <= 1)//count)
                {
                    if (z == 280)
                    {

                    }
                    com_nm = common.ArrLiFORCOMTREE[z].ToString();
                                 
                    temp = common.HAST2[com_nm].ToString();
                    int pos = Convert.ToInt32(temp.IndexOf("/", 0) + 1);
                    g_code = temp.Substring(0, pos - 1).Trim();
                    string tt1 = temp.Substring(pos);
                    int pos12 = Convert.ToInt32(tt1.IndexOf("/", 0) + 1);
                    string brnc = tt1.Substring(0, pos12 - 1);
                    if (brnc == "0")
                    {
                        KeepGCode.Add(g_code);
                        int pos1 = Convert.ToInt32(temp.IndexOf("/", pos) + 1);
                        fi_code = temp.Substring(pos1 + 1 - 1);
                        if (fi_code.Length > 1)
                        {
                            fi_code = fi_code.Substring(0, 1);
                        }

                        //con.Open();
                        ////com = new SqlCommand("select * from access where USER_CODE='" + TUcode + "' and FICode='" + fi_code + "' and GCODE='" + g_code + "'", con.mycon, SQLT); //FICode='" + fi_code + "' and GCODE='" + g_code + "'//partha
                        ////da.SelectCommand = com;
                        ////bool bu = Convert.ToBoolean(da.Fill(ds, "AS1"));
                        //////con.Close();
                        ////ds.Tables["AS1"].Clear();
                        ////if (bu != true)

                        cnt_pass = clsDataAccess.GetresultS("select count(*) from access where (USER_CODE='" + TUcode + "') and (FICode='" + fi_code + "') and (GCODE='" + g_code + "')");
                        if (cnt_pass =="0")
                        {
                            //con.Open();
                            //com = new SqlCommand("select FICode from company where GCODE='" + g_code + "'", con.mycon);
                            //da.SelectCommand = com;
                            //da.Fill(ds, "get_ficode");                             
                            //ds.Tables["get_ficode"].Clear();
                            com = new SqlCommand("insert into access(USER_CODE,FICode,GCODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "')", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + 0 + ")", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            //con.Close();
                        }
                        ////User TranSaction Permeation Default Value
                        //////////com = new SqlCommand("insert into TransactControl(user_code,ficode,gcode,T_ENTRY,BOOL_ADD,BOOL_MODIFY,BOOL_VIEW,BOOL_DELETE,BOOL_CANCEL,Desccode)values('" + TUcode + "','" + fi_code + "','" + g_code + "','0'," + Convert.ToByte(cheadd.Checked) + "," + Convert.ToByte(chemodify.Checked) + "," + Convert.ToByte(cheview.Checked) + "," + Convert.ToByte(chedelete.Checked) + ",'0','1')", con.mycon, SQLT);
                        //////////com.ExecuteNonQuery();
                        ////
                        ///User TranSaction Permeation Transaction Wise
                        common.ClearDataTable(ds.Tables["transaction"]);
                        com = new SqlCommand("select distinct T_ENTRY,Desccode from TypeDoc_Config where (gcode='" + g_code + "') and (ficode='" + fi_code + "')", con.mycon, SQLT);
                        da.SelectCommand = com;
                        da.Fill(ds, "transaction");
                        cnt_pass = "";
                        if (ds.Tables["transaction"].Rows.Count > 0)
                        {
                            for (int t = 0; t < ds.Tables["transaction"].Rows.Count; t++)
                            {
                                if (cnt_pass == "")
                                {
                                    cnt_pass="('" + TUcode + "','" + fi_code + "','" + g_code + "','" + ds.Tables["transaction"].Rows[t]["T_ENTRY"] + "'," + Convert.ToByte(cheadd.Checked) + "," + Convert.ToByte(chemodify.Checked) + "," + Convert.ToByte(cheview.Checked) + "," + Convert.ToByte(chedelete.Checked) + ",'0','" + ds.Tables["transaction"].Rows[t]["Desccode"] + "')";
                                }
                                else
                                {
                                    cnt_pass=cnt_pass+",('" + TUcode + "','" + fi_code + "','" + g_code + "','" + ds.Tables["transaction"].Rows[t]["T_ENTRY"] + "'," + Convert.ToByte(cheadd.Checked) + "," + Convert.ToByte(chemodify.Checked) + "," + Convert.ToByte(cheview.Checked) + "," + Convert.ToByte(chedelete.Checked) + ",'0','" + ds.Tables["transaction"].Rows[t]["Desccode"] + "')";
                                }
                               
                            }

                            com = new SqlCommand("insert into TransactControl(user_code,ficode,gcode,T_ENTRY,BOOL_ADD,BOOL_MODIFY,BOOL_VIEW,BOOL_DELETE,BOOL_CANCEL,Desccode)values" + cnt_pass, con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            cnt_pass = "";
                        }
                        /////
                    }
                    else
                    {
                        KeepGCode.Add(g_code);
                        int pos1 = Convert.ToInt32(temp.IndexOf("/", pos) + 1);
                        fi_code = temp.Substring(pos1 + 1 - 1);
                        if (fi_code.Length > 1)
                        {
                            fi_code = fi_code.Substring(0, 1);
                        }
                        b_code = brnc;
                        //con.Open();
                        com = new SqlCommand("select * from access where (USER_CODE='" + TUcode + "') and (FICode='" + fi_code + "') and (GCODE='" + g_code + "')", con.mycon, SQLT);
                        da.SelectCommand = com;
                        bool bu = Convert.ToBoolean(da.Fill(ds, "AS1"));
                        //con.Close();
                        ds.Tables["AS1"].Clear();
                        if (bu == false)
                        {
                            //con.Open();
                            //    com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values ('" + TUcode + "','" + fi_code + "','" + g_code + "'," + Convert.ToInt32(b_code) + ")", con.mycon, SQLT);
                            //    com.ExecuteNonQuery();
                            //    //con.Close();
                            //}
                            //else
                            //{
                            //con.Open();
                            com = new SqlCommand("insert into access(USER_CODE,FICode,GCODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "')", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + 0 + ")", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            //partha 070915
                            ////com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + 0 +")", con.mycon, SQLT); //Convert.ToInt32(b_code)
                            ////com.ExecuteNonQuery();
                            //con.Close();
                        }
                        else
                        {
                            break;
                        }
                    }
                    //// added by moumita on 8/9/2012///
                    //com = new SqlCommand("select * from TransactControl where user_code='" + Convert.ToString(TUcode) + "' and gcode='" + g_code + "' and ficode='" + fi_code + "'", con.mycon, SQLT);
                    //da.SelectCommand = com;
                    ////ds.Tables["chk_exs_trans"].Clear();//moumita
                    //bool buTrans = Convert.ToBoolean(da.Fill(ds, "chk_exs_trans"));
                    //if (buTrans != true)
                    //{
                   
                    //}
                    //ds.Tables["chk_exs_trans"].Clear();
                    //////ended by moumita on 8/9/2012///
                    z++;
                }
                //while (z <= count)
                //{
                //com_nm = Modual1.ArrLiFORCOMTREE[z].ToString();
                //    temp = Modual1.HAST2[com_nm].ToString();
                //    int pos=Convert.ToInt32(temp.IndexOf("/",0)+1);
                //    g_code = temp.Substring(0, pos - 1);
                //    string tt = temp.Substring(pos);
                //    int pos1 = Convert.ToInt32(tt.IndexOf("/",0) + 1);                    
                //    b_code = tt.Substring(0,pos1-1);
                //    //con.Open();
                //    //com = new SqlCommand("select FICode from company where GCODE='" + g_code + "'", con.mycon);
                //    //da.SelectCommand = com;
                //    //da.Fill(ds, "get_ficode");
                //    int pos11 = Convert.ToInt32(temp.IndexOf("/", pos) + 1);
                //fi_code = temp.Substring(pos11 + 1 - 1);
                //    //ds.Tables["get_ficode"].Clear();
                //con.Close();
                //    int ii =Convert.ToInt32(has[com_nm]);
                //    if (ii != 0)
                //    {
                //        con.Open();
                //        com = new SqlCommand("insert into access(USER_CODE,FICode,GCO_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "')", con.mycon);
                //        com.ExecuteNonQuery();
                //        com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCO_CODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + 0 + ")", con.mycon);
                //        com.ExecuteNonQuery();
                //        con.Close();
                //    }
                //    if (b_code != "0")
                //    {
                //        con.Open();
                //        com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCO_CODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + Convert.ToInt32(b_code) + ")", con.mycon);
                //        com.ExecuteNonQuery();
                //        con.Close();
                //    }
                //    z++;
                //}
                count = 0;
                z = 0;
                count = Convert.ToInt32(common.ArrLiFORMENUTREE.Count - 1);
                int count1 = Convert.ToInt32(KeepGCode.Count - 1), z4 = 0;
                cnt_pass = clsDataAccess.GetresultS("select count(*) from MenuUser where (USER_CODE='" + TUcode + "')");
                if (cnt_pass == "0")
                {


                    com = new SqlCommand("INSERT INTO MenuUser(USER_CODE, GCODE, MENUCODE, ENABLE_MENU, TOOLBARBTN)" + Environment.NewLine +
          "select '" + TUcode + "','1', MENUCODE,1,0 from MenuTable where ENABLE_MENU='true'", con.mycon, SQLT);
                     com.ExecuteNonQuery();
                }
                //19/03/2018
                //while (z <= count)
                //{
                //    temp = common.ArrLiFORMENUTREE[z].ToString();
                //    m_code = Convert.ToString(common.HAST1[temp]);
                //    string mcode1 = m_code;

                //    while (true)
                //    {//19/03/2018
                //        //con.Open();
                //        ////com = new SqlCommand("select PARENTCODE from MENUTABLE where MENUCODE='" + mcode1 + "'", con.mycon, SQLT);
                //        ////da.SelectCommand = com;
                //        ////da.Fill(ds, "get_parent");
                //        //con.Close();
                //        mcode1 = clsDataAccess.GetresultS("select PARENTCODE from MENUTABLE where (MENUCODE='" + mcode1 + "')"); //ds.Tables["get_parent"].Rows[0][0].ToString();
                //        //ds.Tables["get_parent"].Clear();
                //        if (mcode1 == "0")
                //        {
                //            break;
                //        }
                //        else
                //        {
                //            while (z4 <= count1)
                //            {
                //                g_code = KeepGCode[z4].ToString();
                //                //con.Open();
                //                com = new SqlCommand("select * from MenuUser where USER_CODE='" + TUcode + "' and GCODE='" + g_code + "' and MENUCODE='" + mcode1 + "'", con.mycon, SQLT);
                //                da.SelectCommand = com;
                //                bool bu = Convert.ToBoolean(da.Fill(ds, "chk_exis"));
                //                //con.Close();
                //                ds.Tables["chk_exis"].Clear();
                //                if (bu != true)
                //                {
                //                    //con.Open();
                //                    com = new SqlCommand("insert into MenuUser values('" + TUcode + "','" + g_code + "','" + mcode1 + "'," + 1 + "," + 0 + ")", con.mycon, SQLT);
                //                    com.ExecuteNonQuery();
                //                    //con.Close();
                //                }
                //                //con.Open();
                //                com = new SqlCommand("select * from MenuUser where USER_CODE='" + TUcode + "' and GCODE='" + g_code + "' and MENUCODE='" + m_code + "'", con.mycon, SQLT);
                //                da.SelectCommand = com;
                //                bool bu1 = Convert.ToBoolean(da.Fill(ds, "chk_exis1"));
                //                //con.Close();
                //                ds.Tables["chk_exis1"].Clear();
                //                if (bu1 != true)
                //                {
                //                    //con.Open();
                //                    com = new SqlCommand("insert into MenuUser values('" + TUcode + "','" + g_code + "','" + m_code + "'," + 1 + "," + 0 + ")", con.mycon, SQLT);
                //                    com.ExecuteNonQuery();
                //                    //con.Close();
                //                }
                //                z4++;
                //            }
                //            z4 = 0;
                //        }
                //    }
                //    z++;
                //}


                EDPMessage.Show("One User Created", "Information....");


                // added by moumita on 30/08/2012// 

                SQLT.Commit();
                con.Close();
                Clear();
                /// added by moumita//////////////////
            }
            catch
            {
                //MessageBox.Show(ex.ToString());
                SQLT.Rollback();
                con.Close();
            }

        }
        private void Clear()
        {
            user_name.Text = "";
            password.Text = "";
            con_pass.Text = "";
            remarks.Text = "";
            btncompanycheck_Click(btncompanycheck, new EventArgs());
            btncheck_Click(btncheck, new EventArgs());
            user_name.Focus();
        }
        private void PROFILETREE_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                per_menu.Clear();
                per_company.Clear();
                textBox6.Text = "";
                string TEMP = PROFILETREE.SelectedNode.Text.ToString(), Username, temp1;
                int i = 0, j, Bcode;
                i = TEMP.IndexOf("(", 0) + 1;
                Username = TEMP.Substring(0, i - 1).Trim();
                temp1 = TEMP.Substring(i - 1);
                encrypt = EDPCOMM.edpcrypt(Username, true).ToString();
                con.Open();
                com = new SqlCommand("select USER_CODE,hide_pfesi from pasword where USER_DESC='" + encrypt + "'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "get_ucode");
                con.Close();
                encrypt = ds.Tables["get_ucode"].Rows[0][0].ToString();


                if (ds.Tables["get_ucode"].Rows[0][1].ToString().Trim() == "1")
                {
                    chk_hide_PF.Checked = false;
                }
                else
                {
                    chk_hide_PF.Checked = true;
                }
                ds.Tables["get_ucode"].Clear();
                msg.Text = "Selected " + Username + " User";
                infoUsr = 0;
                if (temp1.ToUpper() == "(Superuser)".ToUpper())
                {
                    infoUsr = 2;
                    //EDPMessage.Show("Can't Edit or Display SuperUser Permission", "Information.....", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                    //PERMISSIONTREE.Nodes.Clear();
                    //PERMISSIONTREE_COMPANY.Nodes.Clear();
                    //////PERMISSIONTREE_LOCATION.Nodes.Clear();
                    //remark1.Text = "";
                    ////textBox3.Text = "";// changed by moumita on 28/08/2012 
                    ////textBox4.Text = "";// changed by moumita on 28/08/2012 
                    //textBox5.Text = "";
                    //textBox5.Enabled = false;// changed by moumita on 28/08/2012 
                    //remark1.Enabled = false;// changed by moumita on 28/08/2012 
                    //textBox6.Enabled = false;// changed by moumita on 28/08/2012 
                    //dateTimePicker2.Enabled = false;// changed by moumita on 28/08/2012 
                    //radioButton3.Enabled = false;// changed by moumita on 28/08/2012 
                    //radioButton4.Enabled = false;// changed by moumita on 28/08/2012 
                    //return;

                    //Changed by Bibhas 04-04-2016
                    textBox5.Enabled = true;// changed by moumita on 28/08/2012 
                    textBox5.Enabled = true;// changed by moumita on 30/08/2012 
                    textBox4.Enabled = true;// changed by moumita on 30/08/2012 
                    textBox3.Enabled = true;// changed by moumita on 30/08/2012 
                    remark1.Enabled = true;// changed by moumita on 28/08/2012 
                    textBox6.Enabled = true;// changed by moumita on 28/08/2012 
                    dateTimePicker2.Enabled = true;// changed by moumita on 28/08/2012 
                    radioButton3.Enabled = true;// changed by moumita on 28/08/2012 
                    radioButton4.Enabled = true;
                    chk_hide_PF.Checked =false;
                    chk_hide_PF.Enabled = false;
                }
                else//added by moumita on 28/08/2012
                {
                    chk_hide_PF.Enabled = true;
                    infoUsr = 0;
                    if (encrypt == EDPComm.PCURRENT_USER)
                    {
                        textBox5.Enabled = true;// changed by moumita on 28/08/2012 
                        textBox5.Enabled = true;// changed by moumita on 30/08/2012 
                        textBox4.Enabled = true;// changed by moumita on 30/08/2012 
                        textBox3.Enabled = true;// changed by moumita on 30/08/2012 
                        remark1.Enabled = true;// changed by moumita on 28/08/2012 
                        textBox6.Enabled = true;// changed by moumita on 28/08/2012 
                        dateTimePicker2.Enabled = true;// changed by moumita on 28/08/2012 
                        radioButton3.Enabled = true;// changed by moumita on 28/08/2012 
                        radioButton4.Enabled = true;
                    }
                    else
                    {
                        if (EDPComm.PCURRENT_USER == "1" || info_user.Trim().ToUpper() == "Superuser".ToUpper())
                        {
                            textBox5.Enabled = true;// changed by moumita on 28/08/2012 
                            textBox5.Enabled = true;// changed by moumita on 30/08/2012 
                            textBox4.Enabled = true;// changed by moumita on 30/08/2012 
                            textBox3.Enabled = true;// changed by moumita on 30/08/2012 
                            remark1.Enabled = true;// changed by moumita on 28/08/2012 
                            textBox6.Enabled = true;// changed by moumita on 28/08/2012 
                            dateTimePicker2.Enabled = true;// changed by moumita on 28/08/2012 
                            radioButton3.Enabled = true;// changed by moumita on 28/08/2012 
                            radioButton4.Enabled = true;
                        }
                        else
                        {
                            //PERMISSIONTREE = false;
                            //PERMISSIONTREE_COMPANY.Visible = false;
                            EDPMessage.Show("Can't Edit or Display other User Permission", "Information.....", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
                            textBox5.Enabled = false;
                            textBox4.Enabled = false;
                            textBox3.Enabled = false;// changed by moumita on 28/08/2012 
                            remark1.Enabled = false;// changed by moumita on 28/08/2012 
                            textBox6.Enabled = false;// changed by moumita on 28/08/2012 
                            dateTimePicker2.Enabled = false;// changed by moumita on 28/08/2012 
                            radioButton3.Enabled = false;// changed by moumita on 28/08/2012 
                            radioButton4.Enabled = false;
                            return;// added by moumita
                        }
                    }
                }


                PERMISSIONTREE.Nodes.Clear();
                PERMISSIONTREE_COMPANY.Nodes.Clear();
                Tree_Gen(PERMISSIONTREE);
                ComTree(PERMISSIONTREE_COMPANY); //
               
                con.Open();
                com = new SqlCommand("select a.user_code,a.FICODE,a.gcode,a.loc_code,(select l.Location_Name from tbl_Emp_Location l where l.Location_ID=a.LOC_CODE ) as Location_Name from AccessLocation a where USER_CODE='" + encrypt + "'", con.mycon);// and LOC_CODE<>0
                da.SelectCommand = com;
                da.Fill(ds, "get_ppermission");
                con.Close();
                i = ds.Tables["get_ppermission"].Rows.Count - 1;
                for (j = 0; j <= i; j++)
                {
                    try
                    {
                        TEMP = ds.Tables["get_ppermission"].Rows[j][2].ToString();
                        Bcode = Convert.ToInt32(ds.Tables["get_ppermission"].Rows[j][3]);
                        if (ds.Tables.Contains("FIDATE"))
                        {
                            ds.Tables["FIDATE"].Rows.Clear();
                            ds.Tables["FIDATE"].Dispose();
                        }
                        if (ds.Tables.Contains("get_name"))
                        {
                            ds.Tables["get_name"].Rows.Clear();
                            ds.Tables["get_name"].Dispose();
                        }

                        con.Open();
                        com = new SqlCommand("select CO_SDATE,CO_EDATE,co_name from COMPANY where GCODE='" + TEMP + "' and FICode='" + ds.Tables["get_ppermission"].Rows[j][1].ToString() + "'", con.mycon);
                        da.SelectCommand = com;
                        da.Fill(ds, "FIDATE");
                        com = new SqlCommand("select 0,'default'," + TEMP + " ,'" + ds.Tables["FIDATE"].Rows[0][2] + "' union all select distinct t.Location_ID,t.Location_Name,c.Company_ID ,(select cm.co_name from company cm where c.Company_ID=cm.co_code) as co_name from tbl_Emp_Location t inner join Companywiseid_Relation c on t.Location_ID=c.Location_ID inner join AccessLocation loc on loc.LOC_CODE=c.Location_ID where c.Company_ID='" + TEMP + "' ", con.mycon);
                        da.SelectCommand = com;
                        da.Fill(ds, "get_name");
                        //ds.Tables["get_name"].Clear();

                        con.Close();
                        DateTime SDATE,EDATE;
                        string str = " (";
                        //SDATE = Convert.ToDateTime(ds.Tables["FIDATE"].Rows[0][0].ToString());
                        //EDATE = Convert.ToDateTime(ds.Tables["FIDATE"].Rows[0][1].ToString());
                        //str = str + SDATE.Date.ToShortDateString();
                        //str = str + " - " + EDATE.Date.ToShortDateString() + ")";
                        //
                        str = str + ds.Tables["get_ppermission"].Rows[j][4].ToString().Trim() + ")";
                        str = str + ")";
                        string cname = ds.Tables["FIDATE"].Rows[0][2].ToString();
                        string tm = ds.Tables["get_ppermission"].Rows[j][3].ToString() + ":" + TEMP.Trim() + ":" + ds.Tables["get_ppermission"].Rows[j][1].ToString().Trim();


                        //string cname = ds.Tables["get_name"].Rows[0][1].ToString();
                        //string tm = ds.Tables["get_name"].Rows[0][1].ToString();
                        //


                        //common.HAST2.Add(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + str1 + ")", ds.Tables["com_per1"].Rows[z1][1].ToString());


                        ////////////ds.Tables["get_name"].Clear();
                        //////////ds.Tables["FIDATE"].Clear();
                        if (Bcode == 0)
                        {
                            cname = cname + "" + str;
                        }
                        else
                        {
                            cname = cname + " (" + "  " + tm + ds.Tables["get_ppermission"].Rows[j][4].ToString().Trim() + ")" + "  " + tm + ds.Tables["get_ppermission"].Rows[j][4].ToString().Trim();

                            //cname = ds.Tables["get_name"].Rows[0][3].ToString() + " (" +" "+ ds.Tables["get_name"].Rows[0][1].ToString() + ")" + " " + tm;
                            //International Security Organastion ( SHREE ABIRAMI ENGG MEJA) SHREE ABIRAMI ENGG MEJA
                        }
                        TreeNode tn = new TreeNode();
                        tn = (System.Windows.Forms.TreeNode)common.HAST3[cname];

                        flug_Type_com = true;
                        tn.Checked = true;
                    }
                    catch (Exception ex)
                        {
                    }
                }
                ds.Tables["get_ppermission"].Clear();
                if (Information.IsNothing(ds.Tables["get_permission_menu"]) == false)
                {
                    ds.Tables["get_permission_menu"].Clear();
                }
                con.Open();
                //com = new SqlCommand("select distinct(MENUCODE) from MenuUser where USER_CODE='" + encrypt + "'", con.mycon);
                com = new SqlCommand("select distinct(mu.MENUCODE) from MENUTABLE m ,MenuUser mu  where m.ENABLE_MENU='True' and mu.USER_CODE='" + encrypt + "' and mu.MENUCODE=m.MENUCODE ", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "get_permission_menu");
                con.Close();
                i = ds.Tables["get_permission_menu"].Rows.Count - 1;
                for (j = 0; j <= i; j++)
                {
                    try
                    {
                        TEMP = ds.Tables["get_permission_menu"].Rows[j][0].ToString();
                        con.Open();
                        com = new SqlCommand("select MENUDESC from MENUTABLE where MENUCODE='" + TEMP + "'", con.mycon);
                        da.SelectCommand = com;
                        da.Fill(ds, "get_mcode");
                        con.Close();
                        string cname = ds.Tables["get_mcode"].Rows[0][0].ToString();
                        ds.Tables["get_mcode"].Clear();
                        TreeNode tn = new TreeNode();
                        tn = (System.Windows.Forms.TreeNode)common.HAST[cname];
                        flug_Type = true;
                        tn.Checked = true;
                    }
                    catch 
                    {
                    }

                }
                if (Information.IsNothing(ds.Tables["get_user_det"]) == false)
                {
                    ds.Tables["get_user_det"].Clear();
                }
                con.Open();
                com = new SqlCommand("SELECT USER_DESC, USER_LEV, PSWD_DESC, PSWD_VALIDTILL_DATE, PSWD_VALIDTILL_SESSION, PSWD_VALIDITY FROM  pasword WHERE USER_CODE ='" + encrypt + "'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "get_user_det");
                con.Close();
                textBox5.Text = EDPCOMM.edpcrypt(ds.Tables["get_user_det"].Rows[0][0].ToString(), false);
                textBox4.Text = EDPCOMM.edpcrypt(ds.Tables["get_user_det"].Rows[0][2].ToString(), false);
                textBox3.Text = EDPCOMM.edpcrypt(ds.Tables["get_user_det"].Rows[0][2].ToString(), false);
                remark1.Text = ds.Tables["get_user_det"].Rows[0][1].ToString();
                TEMP = ds.Tables["get_user_det"].Rows[0][5].ToString();
                if (TEMP == "S")
                {
                    radioButton4.Checked = true;
                    textBox6.Text = ds.Tables["get_user_det"].Rows[0][4].ToString();
                    dateTimePicker2.Enabled = false;
                }
                else if (TEMP == "D")
                {
                    radioButton3.Checked = true;
                    textBox6.Enabled = false;
                    dateTimePicker2.Value = Convert.ToDateTime(ds.Tables["get_user_det"].Rows[0][3]);
                }
                con.Open();
                common.ClearDataTable(ds.Tables["usertransaction"]);
                com = new SqlCommand("select BOOL_ADD,BOOL_MODIFY,BOOL_VIEW,BOOL_DELETE,BOOL_CANCEL from TransactControl where USER_CODE='" + encrypt + "' and T_ENTRY='0' and ficode='"+EDPComm.CurrentFicode+"' and gcode='"+EDPComm.PCURRENT_GCODE+"' ", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "usertransaction");
                con.Close();
                for (j = 0; j <= ds.Tables["usertransaction"].Rows.Count - 1; j++)
                {
                    cadd.Checked = Convert.ToBoolean(ds.Tables["usertransaction"].Rows[j]["BOOL_ADD"]);
                    cmodify.Checked = Convert.ToBoolean(ds.Tables["usertransaction"].Rows[j]["BOOL_MODIFY"]);
                    cview.Checked = Convert.ToBoolean(ds.Tables["usertransaction"].Rows[j]["BOOL_VIEW"]);
                    cdelete.Checked = Convert.ToBoolean(ds.Tables["usertransaction"].Rows[j]["BOOL_DELETE"]);
                }
                if (ds.Tables["usertransaction"].Rows.Count == 0)
                {

                    cadd.Checked = false;
                    cmodify.Checked = false;
                    cview.Checked = false;
                    cdelete.Checked = false;
                }
            }
            catch (Exception ex)
            {
                ds.Tables["get_ppermission"].Clear();
                EDPMessage.Show(ex.ToString());
            }
        }
        private void PERMISSIONTREE_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Checked == true)
                {
                    per_menu.Add(e.Node.Text);
                }
                else
                {
                    per_menu.Remove(e.Node.Text);
                }
                if (flug_Type == false)
                {
                    if (e.Node.Checked == true)
                    {
                        TreeNode parent_node = e.Node;
                        for (int i = 0; i < e.Node.Nodes.Count; i++)
                        {
                            parent_node.Nodes[i].Checked = true;
                        }
                    }
                    if (e.Node.Checked == false)
                    {
                        TreeNode parent_node = e.Node;
                        for (int i = 0; i < e.Node.Nodes.Count; i++)
                        {
                            parent_node.Nodes[i].Checked = false;
                        }
                    }
                }
                flug_Type = false;
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.ToString());
            }
        }
        private void PERMISSIONTREE_COMPANY_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Checked == true)
                {
                    per_company.Add(e.Node.Text);
                }
                else
                {
                    per_company.Remove(e.Node.Text);
                }

                if (flug_Type_com == false)
                {
                     if (e.Node.Checked == true)
                        {
                            TreeNode parent_node = e.Node;
                            for (int i = 0; i < e.Node.Nodes.Count; i++)
                            {
                                parent_node.Nodes[i].Checked = true;
                            }
                        }
                        if (e.Node.Checked == false)
                        {
                            TreeNode parent_node = e.Node;
                            for (int i = 0; i < e.Node.Nodes.Count; i++)
                            {
                                parent_node.Nodes[i].Checked = false;
                            }
                        }
                }

                flug_Type_com = false;

            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.ToString());
            }
        }
        //private void ComTree(TreeView trv)
        //{
        //    try
        //    {
        //        common.HAST2.Clear();
        //        common.HAST3.Clear();
        //        int i = 0, j = 0;
        //        con.Open();
        //        common.ClearDataTable(ds.Tables["com_per"]);
        //        //com = new SqlCommand("select GCODE,CO_SDATE,CO_EDATE,FICode from company", con.mycon);
        //        com = new SqlCommand("select distinct c.GCODE,c.CO_SDATE,c.CO_EDATE,c.FICode from company c , AccessLocation ab where c.ficode=ab.ficode and c.gcode=ab.gcode  and ab.user_code='" + EDPComm.PCURRENT_USER + "' and ab.LOC_CODE<>0", con.mycon);
        //        da.SelectCommand = com;
        //        da.Fill(ds, "com_per");
        //        con.Close();
        //        //int tem = 1;
        //        i = Convert.ToInt32(ds.Tables["com_per"].Rows.Count - 1); //partha
        //        while (j <= i)
        //        {
        //            con.Open();
        //            com = new SqlCommand("select BRNCH_NAME,LOC_CODE from branch where GCODE='" + ds.Tables["com_per"].Rows[j][0] + "' and FICode='" + ds.Tables["com_per"].Rows[j][3] + "' order by LOC_CODE", con.mycon);
        //            da.SelectCommand = com;
        //            da.Fill(ds, "com_per1");
        //            con.Close();
        //            int z = Convert.ToInt32(ds.Tables["com_per1"].Rows.Count - 1), z1 = 1;
        //            DateTime fyear, fyear1;
        //            string str = " (", str1;
        //            fyear = Convert.ToDateTime(ds.Tables["com_per"].Rows[j][1].ToString());
        //            fyear1 = Convert.ToDateTime(ds.Tables["com_per"].Rows[j][2].ToString());
        //            str = str + fyear.Date.ToShortDateString();
        //            str = str + " - " + fyear1.Date.ToShortDateString() + ")";
        //            TreeNode tn = new TreeNode(ds.Tables["com_per1"].Rows[0][0].ToString() + str);
        //            trv.Nodes.Add(tn);
        //            common.HAST2.Add(ds.Tables["com_per1"].Rows[0][0].ToString() + str, ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[0][1].ToString() + "/" + ds.Tables["com_per"].Rows[j][3].ToString());
        //            common.HAST3.Add(ds.Tables["com_per1"].Rows[0][0].ToString() + str, tn);
        //            while (z1 <= z)
        //            {
        //                str1 = "  " + ds.Tables["com_per1"].Rows[z1][1].ToString() + ":" + ds.Tables["com_per"].Rows[j][0].ToString().Trim() + ":" + ds.Tables["com_per"].Rows[j][3].ToString().Trim();
        //                TreeNode tn1 = new TreeNode(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + fyear.Year + "-" + fyear1.Year + str1 + ")");
        //                trv.Nodes[j].Nodes.Add(tn1);
        //                common.HAST2.Add(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + fyear.Year + "-" + fyear1.Year + str1 + ")", ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[z1][1].ToString() + "/" + ds.Tables["com_per"].Rows[j][3].ToString());
        //                str1 = "  " + ds.Tables["com_per1"].Rows[z1][1].ToString() + ":" + ds.Tables["com_per"].Rows[j][0].ToString().Trim() + ":" + ds.Tables["com_per"].Rows[j][3].ToString().Trim();
        //                common.HAST3.Add(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + fyear.Year + "-" + fyear1.Year + str1 + ")" + str1, tn1);
        //                z1++;
        //            }
        //            ds.Tables["com_per1"].Clear();
        //            j++;
        //        }
        //        ds.Tables["com_per"].Clear();
        //    }
        //    catch { }
        //}

        private void ComTree(TreeView trv)
        {
            try
            {
                common.HAST2.Clear();
                common.HAST3.Clear();
                int i = 0, j = 0;
                con.Open();
                common.ClearDataTable(ds.Tables["com_per"]);
                //com = new SqlCommand("select GCODE,CO_SDATE,CO_EDATE,FICode from company", con.mycon);

                if (EDPComm.PCURRENT_USER == "1" || info_user.Trim().ToUpper() == "Superuser".ToUpper())
                {
                    com = new SqlCommand("select distinct c.GCODE,c.CO_SDATE,c.CO_EDATE,c.FICode,c.co_name from company c order by c.GCODE ", con.mycon);
                }
                else
                {
                    com = new SqlCommand("select distinct c.GCODE,c.CO_SDATE,c.CO_EDATE,c.FICode from company c , AccessLocation ab where  c.gcode=ab.gcode and ab.user_code='" + EDPComm.PCURRENT_USER + "' and ab.LOC_CODE<>0 order by c.GCODE", con.mycon);
                }
               
                da.SelectCommand = com;
                da.Fill(ds, "com_per");
                con.Close();
                //int tem = 1;
                i = Convert.ToInt32(ds.Tables["com_per"].Rows.Count - 1); //partha
                while (j <= i)
                {
                    con.Open();
                    //com = new SqlCommand("select t.Location_ID,t.Location_Name,c.Company_ID from tbl_Emp_Location t inner join Companywiseid_Relation c on t.Location_ID=c.Location_ID  where Company_ID='" + ds.Tables["com_per"].Rows[j][0] + "' order by Location_ID", con.mycon);

                   // com = new SqlCommand("select l.Location_ID,l.Location_Name,c.Company_ID from company t inner join Companywiseid_Relation c on t.GCODE=c.Location_ID inner join tbl_Emp_Location l on l.Location_ID=c.Location_ID where c.Company_ID='" + ds.Tables["com_per"].Rows[j][0] + "'", con.mycon);

                    //com = new SqlCommand("select c.Location_ID ,l.Location_Name ,c.Company_ID  from Companywiseid_Relation c inner join tbl_Emp_Location l on l.Location_ID=c.Location_ID", con.mycon);

                    com = new SqlCommand("SELECT distinct c.CO_NAME,(select Location_Name from tbl_Emp_Location l where l.Location_ID=cr.Location_ID ) as Location_Name,cr.Location_ID  FROM       Company c INNER JOIN Companywiseid_Relation cr ON c.GCODE = cr.Company_ID  where c.GCODE  ='" + ds.Tables["com_per"].Rows[j][0] + "' order by cr.Location_ID ", con.mycon); //INNER JOIN dbo.tbl_Emp_Location l ON cr.Location_ID = l.Location_ID

                    da.SelectCommand = com;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
                    da.Fill(ds, "com_per1");
                    con.Close();
                    if (ds.Tables["com_per1"].Rows.Count > 0)
                    {
                        int z = Convert.ToInt32(ds.Tables["com_per1"].Rows.Count - 1), z1 = 0;
                        DateTime fyear, fyear1;
                        string str = " (", str1;
                        //fyear = Convert.ToDateTime(ds.Tables["com_per"].Rows[j][1].ToString());
                        //fyear1 = Convert.ToDateTime(ds.Tables["com_per"].Rows[j][2].ToString());
                        //str = str + fyear.Date.ToShortDateString();
                        //str = str + " - " + fyear1.Date.ToShortDateString() + ")";

                        str = str + ds.Tables["com_per1"].Rows[0][1].ToString ().Trim() + ")";

                        str = str + ")";
                        TreeNode tn = new TreeNode(ds.Tables["com_per1"].Rows[0][0].ToString() + str);
                        trv.Nodes.Add(tn);
                        //common.HAST2.Add(ds.Tables["com_per1"].Rows[0][0].ToString(), ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[0][1].ToString() + "/" + ds.Tables["com_per"].Rows[j][3].ToString());
                        //common.HAST3.Add(ds.Tables["com_per1"].Rows[0][0].ToString(), tn);

                        //
                        //common.HAST2.Add(ds.Tables["com_per1"].Rows[0][0].ToString(), ds.Tables["com_per1"].Rows[0][1].ToString());
                        //common.HAST3.Add(ds.Tables["com_per1"].Rows[0][1].ToString(), tn);

                        common.HAST2.Add(ds.Tables["com_per1"].Rows[0][0].ToString() + str, ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[0][2].ToString() + "/" + ds.Tables["com_per"].Rows[j][3].ToString()); //ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[0][1].ToString()
                        common.HAST3.Add(ds.Tables["com_per1"].Rows[0][0].ToString() + str, tn);

                        //

                        while (z1 <= z)
                        {
                            //str1 = "  " + ds.Tables["com_per1"].Rows[z1][1].ToString() + ":" + ds.Tables["com_per"].Rows[j][0].ToString().Trim() + ":" + ds.Tables["com_per"].Rows[j][3].ToString().Trim();
                            if (z1 == 280)
                            {

                            }
                            str1 = "  " + ds.Tables["com_per1"].Rows[z1][2].ToString() + ":" + ds.Tables["com_per"].Rows[j][0].ToString().Trim() + ":" + ds.Tables["com_per"].Rows[j][3].ToString().Trim() + ds.Tables["com_per1"].Rows[z1][1].ToString().Trim();
                            //TreeNode tn1 = new TreeNode(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + fyear.Year + "-" + fyear1.Year + str1 + ")");
                            TreeNode tn1 = new TreeNode(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + str1 + ")");
                            //////TreeNode tn1 = new TreeNode(" (" + str1 + ")");

                            trv.Nodes[j].Nodes.Add(tn1);
                            //common.HAST2.Add(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + str1 + ")", ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[z1][1].ToString() + "/" + ds.Tables["com_per"].Rows[j][3].ToString());
                            
                            //
                            //common.HAST2.Add(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + str1 + ")", ds.Tables["com_per1"].Rows[z1][1].ToString());
                            common.HAST2.Add(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + str1 + ")", ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[z1][2].ToString() + "/" + ds.Tables["com_per"].Rows[j][3].ToString()+ ds.Tables["com_per1"].Rows[z1][1].ToString().Trim());
                            
                            //


                            str1 = "  " + ds.Tables["com_per1"].Rows[z1][2].ToString() + ":" + ds.Tables["com_per"].Rows[j][0].ToString().Trim() + ":" + ds.Tables["com_per"].Rows[j][3].ToString().Trim()+ ds.Tables["com_per1"].Rows[z1][1].ToString().Trim();

                            //str1 = " " + ds.Tables["com_per1"].Rows[z1][1].ToString();

                            common.HAST3.Add(ds.Tables["com_per1"].Rows[z1][0].ToString() + " (" + str1 + ")" + str1, tn1);

                            //common.HAST2.Add(" (" + fyear.Year + "-" + fyear1.Year + str1 + ")", ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[z1][1].ToString() + "/" + ds.Tables["com_per"].Rows[j][3].ToString());
                            //str1 = "  " + ds.Tables["com_per1"].Rows[z1][1].ToString() + ":" + ds.Tables["com_per"].Rows[j][0].ToString().Trim() + ":" + ds.Tables["com_per"].Rows[j][3].ToString().Trim();
                            //common.HAST3.Add(" (" + fyear.Year + "-" + fyear1.Year + str1 + ")" + str1, tn1);

                            z1++;
                        }
                       //'''''''
                    }
                    else
                    {
                        DateTime fyear, fyear1;
                        string str = " (", str1;
                        ////////fyear = Convert.ToDateTime(ds.Tables["com_per"].Rows[j][1].ToString());
                        ////////fyear1 = Convert.ToDateTime(ds.Tables["com_per"].Rows[j][2].ToString());
                        ////////str = str + fyear.Date.ToShortDateString();
                        ////////str = str + " - " + fyear1.Date.ToShortDateString() + ")";
                        TreeNode tn = new TreeNode(ds.Tables["com_per"].Rows[j][4].ToString() + str);
                        trv.Nodes.Add(tn);

                        //common.HAST2.Add(ds.Tables["com_per"].Rows[j][4].ToString() + str, tn);
                        //common.HAST3.Add(ds.Tables["com_per"].Rows[j][4].ToString() + str, tn);

                        //str1 = "  " + ds.Tables["com_per1"].Rows[0][1].ToString() + ":" + ds.Tables["com_per"].Rows[j][0].ToString().Trim() + ":" + ds.Tables["com_per"].Rows[j][3].ToString().Trim();
                        //TreeNode tn1 = new TreeNode(ds.Tables["com_per1"].Rows[j][0].ToString() + " (" + fyear.Year + "-" + fyear1.Year + str1 + ")");
                        //trv.Nodes[j].Nodes.Add(tn1);
                        //common.HAST2.Add(ds.Tables["com_per1"].Rows[0][0].ToString() + " (" + fyear.Year + "-" + fyear1.Year + str1 + ")", ds.Tables["com_per"].Rows[j][0].ToString() + "/" + ds.Tables["com_per1"].Rows[0][1].ToString() + "/" + ds.Tables["com_per"].Rows[j][3].ToString());
                        //str1 = "  " + ds.Tables["com_per1"].Rows[0][1].ToString() + ":" + ds.Tables["com_per"].Rows[j][0].ToString().Trim() + ":" + ds.Tables["com_per"].Rows[j][3].ToString().Trim();
                        //common.HAST3.Add(ds.Tables["com_per1"].Rows[0][0].ToString() + " (" + fyear.Year + "-" + fyear1.Year + str1 + ")" + str1, tn1);

                    }
                    ds.Tables["com_per1"].Clear();
                    j++;
                    
                }
                ds.Tables["com_per"].Clear();
            }
            catch { }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                dateTimePicker2.Enabled = false;
                textBox6.Enabled = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                dateTimePicker2.Enabled = true;
                textBox6.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text.Length == 0)
                {
                    EDPMessage.Show("UserName can't be blank", "Information....");
                    textBox5.Focus();
                    return;
                }
                if (textBox4.Text.Length == 0)
                {
                    EDPMessage.Show("Password can't be blank", "Information....");
                    textBox4.Focus();
                    return;
                }
                if (textBox3.Text.Length == 0)
                {
                    EDPMessage.Show("Confirmation Password can't be blank", "Information....");
                    textBox3.Focus();
                    return;
                }
                else
                {
                    if (textBox4.Text != textBox3.Text)
                    {
                        EDPMessage.Show("Mismatch between Password and Confirm Password", "Information....");
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox4.Focus();
                        return;
                    }
                }
                if (EDPComm.PCURRENT_USER == "1" || info_user.Trim().ToUpper() == "Superuser".ToUpper())
                {
                    if (infoUsr == 0)
                    {
                        if (per_menu.Count - 1 < 0)
                        {
                            EDPMessage.Show("No permission found in Access Menu", "Information......");
                            return;
                        }
                        if (per_company.Count - 1 < 0)
                        {
                            EDPMessage.Show("No permission found in Access Company", "Information......");
                            return;
                        }
                    }
                }

                if (chk_hide_PF.Checked == true)
                {
                    hide_pfesi = 0;
                }
                else
                {
                    hide_pfesi = 1;
                }

                string Temp = "", Temp2 = "", Temp3 = "";
                int Temp1 = 0;
                if (radioButton4.Checked == true)
                {
                    if (Information.IsNumeric(textBox6.Text) == false)
                    {
                        EDPMessage.Show("Enter Session!", "Message");
                        textBox6.Focus();
                        return;
                    }
                    else
                    {
                        if (Convert.ToInt32(textBox6.Text) <= EDPCOMM.CURRENTSESSION)
                        {
                            EDPMessage.Show("Accept denied! Session must be greter than Current Session.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox6.Text = "";
                            textBox6.Focus();
                            return;
                        }
                        else
                        {
                            Temp = "S";
                            Temp1 = Convert.ToInt32(textBox6.Text);
                            Temp3 = EDPCOMM.getSqlDateStr(dateTimePicker2.Value);
                        }
                    }
                }
                if (radioButton3.Checked == true)
                {
                    Temp = "D";
                    Temp3 = EDPCOMM.getSqlDateStr(dateTimePicker2.Value);
                    Temp1 = 0;
                }
                if (remark1.Text.Length == 0)
                {
                    Temp2 = "User";
                }
                else
                {
                    Temp2 = remark1.Text;
                }
                con.Open();
                SQLT = con.mycon.BeginTransaction();
                try
                {
                    if (EDPComm.PCURRENT_USER == "1" || info_user.Trim().ToUpper() == "Superuser".ToUpper())
                    {
                        if (infoUsr == 0)
                        {
                            com = new SqlCommand("update pasword set USER_DESC='" + EDPCOMM.edpcrypt(textBox5.Text, true) + "',USER_LEV='" + Temp2 + "',PSWD_DESC='" + EDPCOMM.edpcrypt(textBox3.Text, true) + "',PSWD_VALIDTILL_DATE='" + Temp3 + "',PSWD_VALIDTILL_SESSION=" + Temp1 + ",PSWD_VALIDITY='" + Temp + "',hide_pfesi='" + hide_pfesi + "' where USER_CODE='" + encrypt + "'", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("delete from access where USER_CODE='" + encrypt + "'", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("delete from AccessLocation where USER_CODE='" + encrypt + "'", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("delete from MenuUser where USER_CODE='" + encrypt + "'", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("update TransactControl set BOOL_ADD='" + Convert.ToByte(cadd.Checked) + "',BOOL_MODIFY='" + Convert.ToByte(cmodify.Checked) + "',BOOL_VIEW='" + Convert.ToByte(cview.Checked) + "',BOOL_DELETE='" + Convert.ToByte(cdelete.Checked) + "' where USER_CODE='" + encrypt + "'", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                        }
                        else if (infoUsr == 2)
                        {
                            com = new SqlCommand("update pasword set USER_DESC='" + EDPCOMM.edpcrypt(textBox5.Text, true) + "',USER_LEV='" + Temp2 + "',PSWD_DESC='" + EDPCOMM.edpcrypt(textBox3.Text, true) + "',PSWD_VALIDTILL_DATE='" + Temp3 + "',PSWD_VALIDTILL_SESSION=" + Temp1 + ",PSWD_VALIDITY='" + Temp + "',hide_pfesi='" + hide_pfesi + "' where USER_CODE='" + encrypt + "'", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        com = new SqlCommand("update pasword set USER_DESC='" + EDPCOMM.edpcrypt(textBox5.Text, true) + "',USER_LEV='" + Temp2 + "',PSWD_DESC='" + EDPCOMM.edpcrypt(textBox3.Text, true) + "',PSWD_VALIDTILL_DATE='" + Temp3 + "',PSWD_VALIDTILL_SESSION=" + Temp1 + ",PSWD_VALIDITY='" + Temp + "',hide_pfesi='" + hide_pfesi + "' where USER_CODE='" + encrypt + "'", con.mycon, SQLT);
                        com.ExecuteNonQuery();

                    }

                    EDPCOMM.InsertMidasLog(this, true, "mod", textBox5.Text);
                }
                catch { }
                int TUcode = Convert.ToInt32(encrypt);
                KeepGCode.Clear();

                ///

                if (per_company.Count == 0)
                {
                    for (int i = 0; i < common.ArrLiFORCOMTREE.Count; i++)
                    {
                        per_company.Add(common.ArrLiFORCOMTREE[i]);
                    }
                }

                for (int i = 0; i < per_company.Count; i++)
                {
                    for (int j = i + 1; j < per_company.Count; j++)
                    {
                        if (per_company[i].ToString() == per_company[j].ToString())
                            per_company.Remove(per_company[j]);
                    }
                }

                ///
                if (infoUsr == 0)
                {
                    int count = Convert.ToInt32(per_company.Count - 1), z = 0;
                    string com_nm, b_code, temp, fi_code, m_code;
                    //while (z <= count)             

                    while (z <= count)
                    {
                        com_nm = per_company[z].ToString();
                        errcompany = per_company[z].ToString();
                        temp = common.HAST2[com_nm].ToString();
                        int pos = Convert.ToInt32(temp.IndexOf("/", 0) + 1);
                        g_code = temp.Substring(0, pos - 1);
                        string tt1 = temp.Substring(pos);
                        int pos12 = Convert.ToInt32(tt1.IndexOf("/", 0) + 1);

                        string brnc = tt1.Substring(0, pos12 - 1);

                        if (brnc == "0")
                        {
                            KeepGCode.Add(g_code);
                            int pos1 = Convert.ToInt32(temp.IndexOf("/", pos) + 1);
                            fi_code = temp.Substring(pos1 + 1 - 1);
                            if (fi_code.Length > 1)
                            {
                                fi_code = fi_code.Substring(0, 1);
                            }
                            //fi_code = "1";
                            //con.Open();
                            com = new SqlCommand("select * from access where USER_CODE='" + TUcode + "' and FICode='" + fi_code + "' and GCODE='" + g_code + "'", con.mycon, SQLT);
                            da.SelectCommand = com;
                            bool bu = Convert.ToBoolean(da.Fill(ds, "AS1"));
                            //con.Close();
                            ds.Tables["AS1"].Clear();
                            if (bu != true)
                            {
                                //con.Open();

                                ///////
                                com = new SqlCommand("insert into access(USER_CODE,FICode,GCODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "')", con.mycon, SQLT);
                                com.ExecuteNonQuery();

                                com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + 0 + ")", con.mycon, SQLT);
                                com.ExecuteNonQuery();
                                ///////
                                //con.Close();
                            }
                            //@
                            else
                            {
                                //con.Open();
                                com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + 0 + ")", con.mycon, SQLT);
                                com.ExecuteNonQuery();
                                //con.Close();
                            }
                            //@
                        }
                        else
                        {
                            KeepGCode.Add(g_code);
                            int pos1 = Convert.ToInt32(temp.IndexOf("/", pos) + 1);
                            fi_code = temp.Substring(pos1 + 1 - 1);
                            if (fi_code.Length > 1)
                            {
                                fi_code = fi_code.Substring(0, 1);
                            }

                            b_code = brnc;
                            //con.Open();
                            com = new SqlCommand("select * from access where USER_CODE='" + TUcode + "' and FICode='" + fi_code + "' and GCODE='" + g_code + "'", con.mycon, SQLT);
                            da.SelectCommand = com;
                            bool bu = Convert.ToBoolean(da.Fill(ds, "AS1"));
                            //con.Close();
                            ds.Tables["AS1"].Clear();
                            if (bu)
                            {
                                //con.Open();
                                /////////
                                com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + Convert.ToInt32(b_code) + ")", con.mycon, SQLT);
                                com.ExecuteNonQuery();
                                /////////
                                //con.Close();
                            }
                            else
                            {
                                //con.Open();
                                com = new SqlCommand("insert into access(USER_CODE,FICode,GCODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "')", con.mycon, SQLT);
                                com.ExecuteNonQuery();
                                //com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + 0 + ")", con.mycon, SQLT);
                                //com.ExecuteNonQuery();
                                com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + TUcode + "','" + fi_code + "','" + g_code + "'," + Convert.ToInt32(b_code) + ")", con.mycon, SQLT);
                                com.ExecuteNonQuery();


                                //con.Close();
                            }
                        }
                        z++;
                    }
                    count = 0;
                    z = 0;
                    count = Convert.ToInt32(per_menu.Count - 1);
                    int count1 = Convert.ToInt32(KeepGCode.Count - 1), z4 = 0;
                    while (z <= count)
                    {
                        temp = per_menu[z].ToString();
                        m_code = Convert.ToString(common.HAST1[temp]);
                        string mcode1 = m_code;
                        while (true)
                        {
                            //con.Open();
                            //19/03/2018//com = new SqlCommand("select PARENTCODE from MENUTABLE where MENUCODE='" + mcode1 + "'", con.mycon, SQLT);
                            ////da.SelectCommand = com;
                            ////da.Fill(ds, "get_parent");
                            //con.Close();
                            mcode1 = clsDataAccess.GetresultS("select PARENTCODE from MENUTABLE where (MENUCODE='" + mcode1 + "')"); 
                            //ds.Tables["get_parent"].Rows[0][0].ToString();
                            //ds.Tables["get_parent"].Clear();
                            if (mcode1 == "0")
                            {
                                break;
                            }
                            else
                            {
                                while (z4 <= count1)
                                {
                                    g_code = KeepGCode[z4].ToString();
                                    //con.Open();
                                    com = new SqlCommand("select * from MenuUser where USER_CODE='" + TUcode + "' and GCODE='" + g_code + "' and MENUCODE='" + mcode1 + "'", con.mycon, SQLT);
                                    da.SelectCommand = com;
                                    bool bu = Convert.ToBoolean(da.Fill(ds, "chk_exis"));
                                    //con.Close();
                                    ds.Tables["chk_exis"].Clear();
                                    if (bu != true)
                                    {
                                        //con.Open();
                                        com = new SqlCommand("insert into MenuUser values('" + TUcode + "','" + g_code + "','" + mcode1 + "'," + 1 + "," + 0 + ")", con.mycon, SQLT);
                                        com.ExecuteNonQuery();
                                        //con.Close();
                                    }
                                    //con.Open();
                                    com = new SqlCommand("select * from MenuUser where USER_CODE='" + TUcode + "' and GCODE='" + g_code + "' and MENUCODE='" + m_code + "'", con.mycon, SQLT);
                                    da.SelectCommand = com;
                                    bool bu1 = Convert.ToBoolean(da.Fill(ds, "chk_exis1"));
                                    //con.Close();
                                    ds.Tables["chk_exis1"].Clear();
                                    if (bu1 != true)
                                    {
                                        //con.Open();
                                        com = new SqlCommand("insert into MenuUser values('" + TUcode + "','" + g_code + "','" + m_code + "'," + 1 + "," + 0 + ")", con.mycon, SQLT);
                                        com.ExecuteNonQuery();
                                        //con.Close();
                                    }
                                    z4++;
                                }
                                z4 = 0;
                            }
                        }
                        z++;
                    }
                }
                EDPMessage.Show("Successfully Modify", "Information.....");
                SQLT.Commit();
                con.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                //EDPMessage.Show(ex.ToString());
                EDPMessage.Show("Please Untag company deault Branch '" + errcompany + "'");

                SQLT.Rollback();
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string TEMP = USERTREE.SelectedNode.Text.ToString(), Username, temp1, encr;
                int i = 0;
                i = TEMP.IndexOf("(", 0) + 1;
                Username = TEMP.Substring(0, i - 1).Trim();
                temp1 = TEMP.Substring(i - 1);
                encr = EDPCOMM.edpcrypt(Username, true).ToString();
                con.Open();
                com = new SqlCommand("select USER_CODE from pasword where USER_DESC='" + encr + "'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "get_ucode");
                con.Close();
                encr = ds.Tables["get_ucode"].Rows[0][0].ToString();
                ds.Tables["get_ucode"].Clear();
                if (temp1.ToUpper() == "(Superuser)".ToUpper())
                {
                    EDPMessage.Show("You Can't Delete SuperUser", "Information....", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_ERROR);
                    return;
                }
                // string YN=Convert.ToString(MessageBox.Show("Do You Want To Delete " + Username + " User", "Information....", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                EDPMessage.Show("Do You Want To Delete " + Username + " User", "Information", EDPMessage.MessageBoxButton.EDP_YES_NO, EDPMessage.MessageBoxIcon.EDP_QUESTION);
                if (EDPMessage.ButtonResult == "edpYES")
                {
                    con.Open();
                    com = new SqlCommand("delete from access where USER_CODE='" + encr + "'", con.mycon);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("delete from AccessLocation where USER_CODE='" + encr + "'", con.mycon);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("delete from MenuUser where USER_CODE='" + encr + "'", con.mycon);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("delete from pasword where USER_CODE='" + encr + "'", con.mycon);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("delete from UserControl where USER_CODE='" + encr + "'", con.mycon);
                    com.ExecuteNonQuery();
                    com = new SqlCommand("delete from TransactControl where USER_CODE='" + encr + "'", con.mycon);
                    com.ExecuteNonQuery();
                    con.Close();
                    EDPCOMM.InsertMidasLog(this, true, "del", user_name.Text);
                    EDPMessage.Show("Successfully Delete" + Username + "User", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_OK);
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                EDPMessage.Show(ex.ToString());
                con.Close();
            }
        }
        private void label20_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label21_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void label20_MouseHover(object sender, EventArgs e)
        {
            // label20.Font = new Font("MicrosoftSansSerif", 10, FontStyle.Bold);
        }
        private void label20_MouseLeave(object sender, EventArgs e)
        {
            //label20.Font = new Font("MicrosoftSansSerif", 8, FontStyle.Bold);
        }
        private void frmUserdetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[0])
                {
                    button1_Click(sender, e);
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BlinkRate > 250)
            {
                BlinkRate = 0;
            }
            else
            {
                if (count == 0)
                {
                    blink.Visible = true;
                    count = 1;
                }
                else if (count == 1)
                {
                    blink.Visible = false;
                    count = 0;
                }
                BlinkRate++;
                blink.ForeColor = Color.FromArgb(BlinkRate, 50, 50);
            }
        }
        private void frmUserdetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }
        private void frmUserdetails_Resize(object sender, EventArgs e)
        {
            try
            {
                //if (this.WindowState == FormWindowState.Minimized)
                //{
                //    this.Text = "User Details";
                //}
                //else if (this.WindowState == FormWindowState.Normal)
                //{
                //    this.Text = "";
                //    this.Size = new Size(625,396);
                //}
            }
            catch { }
        }
        private void user_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                password.Focus();
            }
        }
        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                con_pass.Focus();
            }
        }
        private void con_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                remarks.Focus();
            }
        }
        private void remarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.Focus();
                //button3_Click(sender, e);
            }
        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                remark1.Focus();
            }
        }
        private void remark1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            EDPCOMM.ChangeTabColor(sender, e, tabControl1, Color.LightBlue, Color.Black, Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]), Color.Black);

        }

        private void tabControl3_DrawItem(object sender, DrawItemEventArgs e)
        {
            EDPCOMM.ChangeTabColor(sender, e, tabControl3, Color.LightBlue, Color.Black, Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]), Color.Black);
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            EDPCOMM.ChangeTabColor(sender, e, tabControl2, Color.LightBlue, Color.Black, Color.FromArgb(EDPCOMM.Get_Color[0], EDPCOMM.Get_Color[1], EDPCOMM.Get_Color[2]), Color.Black);
            if (tabControl2.SelectedIndex == 0)
            {
                btncheck.Visible = true;
                btncompanycheck.Visible = false;
                btnusertransaction.Visible = false;
            }
            else if (tabControl2.SelectedIndex == 1)
            {
                btncompanycheck.Visible = true;
                btncheck.Visible = false;
                btnusertransaction.Visible = false;
            }
            else
            {
                btncompanycheck.Visible = false;
                btncheck.Visible = false;
                btnusertransaction.Visible = true;
            }

        }


        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string str1 = "";
                string uname = "", TEMP1 = "";
                int Bcode1 = 0;
                str1 = comboBox1.SelectedItem.ToString();
                encrypt = EDPCOMM.edpcrypt(str1, true).ToString();
                //if(str=="1")
                com = new SqlCommand("select USER_CODE from pasword where USER_DESC='" + encrypt + "'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "get_ucode");
                con.Close();
                encrypt = ds.Tables["get_ucode"].Rows[0][0].ToString();
                ds.Tables["get_ucode"].Clear();
                //msg.Text = "Selected " + Username + " User";
                uname = comboBox1.SelectedItem.ToString();
                MENUTREE.Nodes.Clear();
                COMPANYTREE.Nodes.Clear();
                Tree_Gen(MENUTREE);
                ComTree(COMPANYTREE);//partha
                if (uname == "1")
                {
                    int cnt1 = MENUTREE.Nodes.Count - 1;
                    int cnt2 = COMPANYTREE.Nodes.Count - 1;
                    for (int k = 0; k <= cnt1; k++)
                        MENUTREE.Nodes[k].Checked = true;
                    for (int k1 = 0; k1 <= cnt2; k1++)
                        COMPANYTREE.Nodes[k1].Checked = true;

                }
                con.Open();
                com = new SqlCommand("select * from AccessLocation where USER_CODE='" + encrypt + "'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "get_ppermission");
                con.Close();
                int i = ds.Tables["get_ppermission"].Rows.Count - 1;
                for (int j = 0; j <= i; j++)
                {
                    TEMP1 = ds.Tables["get_ppermission"].Rows[j][2].ToString();
                    Bcode1 = Convert.ToInt32(ds.Tables["get_ppermission"].Rows[j][3]);
                    con.Open();
                    com = new SqlCommand("select CO_SDATE,CO_EDATE from COMPANY where GCODE='" + TEMP1 + "' and FICode='" + ds.Tables["get_ppermission"].Rows[j][1].ToString() + "'", con.mycon);
                    da.SelectCommand = com;
                    da.Fill(ds, "FIDATE");
                    com = new SqlCommand("select BRNCH_NAME,LOC_CODE from branch where GCODE='" + TEMP1 + "' and LOC_CODE=" + Bcode1 + " and FICode='" + ds.Tables["get_ppermission"].Rows[j][1].ToString() + "'", con.mycon);
                    da.SelectCommand = com;
                    da.Fill(ds, "get_name");
                    con.Close();
                    DateTime SDATE, EDATE;
                    string str = " (";
                    SDATE = Convert.ToDateTime(ds.Tables["FIDATE"].Rows[0][0].ToString());
                    EDATE = Convert.ToDateTime(ds.Tables["FIDATE"].Rows[0][1].ToString());
                    str = str + SDATE.Date.ToShortDateString();
                    str = str + " - " + EDATE.Date.ToShortDateString() + ")";
                    string cname = ds.Tables["get_name"].Rows[0][0].ToString();
                    string tm = ds.Tables["get_name"].Rows[0][1].ToString() + ":" + TEMP1.Trim() + ":" + ds.Tables["get_ppermission"].Rows[j][1].ToString().Trim();
                    ds.Tables["get_name"].Clear();
                    ds.Tables["FIDATE"].Clear();
                    if (Bcode1 == 0)
                    {
                        cname = cname + "" + str;
                    }
                    else
                    {
                        cname = cname + " (" + SDATE.Year + "-" + EDATE.Year + "  " + tm + ")" + "  " + tm;
                    }
                    TreeNode tn = new TreeNode();
                    tn = (System.Windows.Forms.TreeNode)common.HAST3[cname];
                    tn.Checked = true;
                }
                ds.Tables["get_ppermission"].Clear();
                if (Information.IsNothing(ds.Tables["get_permission_menu"]) == false)
                {
                    ds.Tables["get_permission_menu"].Clear();
                }
                con.Open();
                //com = new SqlCommand("select distinct(MENUCODE) from MenuUser where USER_CODE='" + encrypt + "'", con.mycon);
                com = new SqlCommand("select distinct(mu.MENUCODE) from MENUTABLE m ,MenuUser mu  where m.ENABLE_MENU='True' and mu.USER_CODE='" + encrypt + "' and mu.MENUCODE=m.MENUCODE ", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "get_permission_menu");
                con.Close();
                i = ds.Tables["get_permission_menu"].Rows.Count - 1;
                string user1 = EDPComm.PCURRENT_USER;
                for (int j = 0; j <= i; j++)
                {
                    TEMP1 = ds.Tables["get_permission_menu"].Rows[j][0].ToString();
                    con.Open();
                    com = new SqlCommand("select MENUDESC from MENUTABLE where MENUCODE='" + TEMP1 + "'", con.mycon);
                    da.SelectCommand = com;
                    da.Fill(ds, "get_mcode");
                    con.Close();
                    string cname = ds.Tables["get_mcode"].Rows[0][0].ToString();
                    ds.Tables["get_mcode"].Clear();
                    TreeNode tn = new TreeNode();
                    tn = (System.Windows.Forms.TreeNode)common.HAST[cname];
                    tn.Checked = true;
                }
                /*if (Information.IsNothing(ds.Tables["get_user_det"]) == false)
                {
                    ds.Tables["get_user_det"].Clear();
                }
                con.Open();
                com = new SqlCommand("SELECT USER_DESC, USER_LEV, PSWD_DESC, PSWD_VALIDTILL_DATE, PSWD_VALIDTILL_SESSION, PSWD_VALIDITY FROM  pasword WHERE USER_CODE ='" + encrypt + "'", con.mycon);
                da.SelectCommand = com;
                da.Fill(ds, "get_user_det");
                con.Close();
                textBox5.Text = EDPCOMM.edpcrypt(ds.Tables["get_user_det"].Rows[0][0].ToString(), false);
                textBox4.Text = EDPCOMM.edpcrypt(ds.Tables["get_user_det"].Rows[0][2].ToString(), false);
                textBox3.Text = EDPCOMM.edpcrypt(ds.Tables["get_user_det"].Rows[0][2].ToString(), false);
                remark1.Text = ds.Tables["get_user_det"].Rows[0][1].ToString();
                TEMP1 = ds.Tables["get_user_det"].Rows[0][5].ToString();
                if (TEMP1 == "S")
                {
                    radioButton4.Checked = true;
                    textBox6.Text = ds.Tables["get_user_det"].Rows[0][4].ToString();
                    dateTimePicker2.Enabled = false;
                }
                else if (TEMP1 == "D")
                {
                    radioButton3.Checked = true;
                    textBox6.Enabled = false;
                    dateTimePicker2.Value = Convert.ToDateTime(ds.Tables["get_user_det"].Rows[0][3]);
                }*/
            }
            catch (Exception ex)
            {
                ds.Tables["get_ppermission"].Clear();
                //MessageBox.Show(ex.ToString());
            }
        }

        private void CopyFromButton1_Click_1(object sender, EventArgs e)
        {
            // ADDED BY MOUMITA ON 27/8/2012///////
            comboBox1.Text = " Select";

            string str1 = "";
            string uname = "", TEMP1 = "";
            int Bcode1 = 0;
            con.Open();
            com = new SqlCommand("select USER_DESC,USER_LEV from pasword", con.mycon);
            da.SelectCommand = com;
            da.Fill(ds, "chk_user1");
            int count1 = Convert.ToInt32(ds.Tables["chk_user1"].Rows.Count - 1);
            con.Close();
            int j = 0;
            while (j <= count1)
            {
                String str = EDPCOMM.edpcrypt(Convert.ToString((ds.Tables["chk_user1"].Rows[j][0])), false);
                //uname[j]=Convert.ToString(ds.Tables["chk_user1"].Rows[j][0]);
                comboBox1.Items.Add(str);
                j++;
            }
            ds.Tables["chk_user1"].Clear();
            comboBox1.Visible = true;
        }
        // DONE BY MOUMITA//////////////////////////
        private void CopyToButton1_Click(object sender, EventArgs e)
        {
            // ADDED BY MOUMITA ON 27/8/2012///////
            comboBox2.Text = "Select";
            string str1 = "";
            string uname = "", TEMP1 = "";
            int Bcode1 = 0;
            con.Open();
            com = new SqlCommand("select USER_DESC,USER_LEV from pasword", con.mycon);
            da.SelectCommand = com;
            da.Fill(ds, "chk_user1");
            int count1 = Convert.ToInt32(ds.Tables["chk_user1"].Rows.Count - 1);
            con.Close();
            int j = 0;
            while (j <= count1)
            {
                String str = EDPCOMM.edpcrypt(Convert.ToString((ds.Tables["chk_user1"].Rows[j][0])), false);
                //uname[j]=Convert.ToString(ds.Tables["chk_user1"].Rows[j][0]);
                comboBox2.Items.Add(str);
                j++;
            }
            comboBox2.Visible = true;

            // DONE BY MOUMITA//////////////////////////
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SQLT = con.mycon.BeginTransaction();
                string com_nm, b_code, temp, fi_code, m_code;
                string copyto_userCode = comboBox2.SelectedItem.ToString();
                int count = Convert.ToInt32(common.ArrLiFORCOMTREE.Count - 1), z = 0;
                com = new SqlCommand("delete from access where USER_CODE='" + copyto_userCode + "'", con.mycon, SQLT);
                com.ExecuteNonQuery();
                com = new SqlCommand("delete from AccessLocation where USER_CODE='" + copyto_userCode + "'", con.mycon, SQLT);
                com.ExecuteNonQuery();
                string com_nm1, b_code1, temp1, fi_code1, m_code1;
                while (z <= count)
                {
                    com_nm1 = common.ArrLiFORCOMTREE[z].ToString();
                    temp1 = common.HAST2[com_nm1].ToString();
                    int pos = Convert.ToInt32(temp1.IndexOf("/", 0) + 1);
                    g_code = temp1.Substring(0, pos - 1);
                    string tt1 = temp1.Substring(pos);
                    int pos12 = Convert.ToInt32(tt1.IndexOf("/", 0) + 1);
                    string brnc = tt1.Substring(0, pos12 - 1);
                    if (brnc == "0")
                    {
                        KeepGCode.Add(g_code);
                        int pos1 = Convert.ToInt32(temp1.IndexOf("/", pos) + 1);
                        fi_code1 = temp1.Substring(pos1 + 1 - 1);
                        //con.Open();
                        com = new SqlCommand("select * from access where USER_CODE='" + copyto_userCode + "' and FICode='" + fi_code1 + "' and GCODE='" + g_code + "'", con.mycon, SQLT);
                        da.SelectCommand = com;
                        bool bu = Convert.ToBoolean(da.Fill(ds, "AS1"));
                        //con.Close();
                        ds.Tables["AS1"].Clear();
                        if (bu != true)
                        {
                            //con.Open();
                            //com = new SqlCommand("select FICode from company where GCODE='" + g_code + "'", con.mycon);
                            //da.SelectCommand = com;
                            //da.Fill(ds, "get_ficode");                             
                            //ds.Tables["get_ficode"].Clear();
                            com = new SqlCommand("insert into access(USER_CODE,FICode,GCODE) values('" + copyto_userCode + "','" + fi_code1 + "','" + g_code + "')", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + copyto_userCode + "','" + fi_code1 + "','" + g_code + "'," + 0 + ")", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            //con.Close();
                        }
                    }
                    else
                    {
                        int pos1 = Convert.ToInt32(temp1.IndexOf("/", pos) + 1);
                        fi_code1 = temp1.Substring(pos1 + 1 - 1);
                        b_code1 = brnc;
                        //con.Open();
                        com = new SqlCommand("select * from access where USER_CODE='" + copyto_userCode + "' and FICode='" + fi_code1 + "' and GCODE='" + g_code + "'", con.mycon, SQLT);
                        da.SelectCommand = com;
                        bool bu = Convert.ToBoolean(da.Fill(ds, "AS1"));
                        //con.Close();
                        ds.Tables["AS1"].Clear();
                        if (bu)
                        {
                            //con.Open();
                            com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + copyto_userCode + "','" + fi_code1 + "','" + g_code + "'," + Convert.ToInt32(b_code1) + ")", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            //con.Close();
                        }
                        else
                        {
                            //con.Open();
                            com = new SqlCommand("insert into access(USER_CODE,FICode,GCODE) values('" + copyto_userCode + "','" + fi_code1 + "','" + g_code + "')", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + copyto_userCode + "','" + fi_code1 + "','" + g_code + "'," + 0 + ")", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            com = new SqlCommand("insert into AccessLocation(USER_CODE,FICode,GCODE,LOC_CODE) values('" + copyto_userCode + "','" + fi_code1 + "','" + g_code + "'," + Convert.ToInt32(b_code1) + ")", con.mycon, SQLT);
                            com.ExecuteNonQuery();
                            //con.Close();
                        }
                    }
                    z++;
                }
                com = new SqlCommand("delete from MenuUser where USER_CODE='" + copyto_userCode + "'", con.mycon, SQLT);
                com.ExecuteNonQuery();
                count = 0;
                z = 0;
                count = Convert.ToInt32(common.ArrLiFORMENUTREE.Count - 1);
                int count1 = Convert.ToInt32(KeepGCode.Count - 1), z4 = 0;
                while (z <= count)
                {
                    temp1 = common.ArrLiFORMENUTREE[z].ToString();
                    m_code1 = Convert.ToString(common.HAST1[temp1]);
                    string mcode1 = m_code1;
                    while (true)
                    {
                        //con.Open();
                        //19/03/2018//com = new SqlCommand("select PARENTCODE from MENUTABLE where MENUCODE='" + mcode1 + "'", con.mycon, SQLT);
                        ////da.SelectCommand = com;
                        ////da.Fill(ds, "get_parent");
                        //con.Close();
                        mcode1 = clsDataAccess.GetresultS("select PARENTCODE from MENUTABLE where (MENUCODE='" + mcode1 + "')"); //ds.Tables["get_parent"].Rows[0][0].ToString();
                        ////ds.Tables["get_parent"].Clear();
                        if (mcode1 == "0")
                        {
                            break;
                        }
                        else
                        {
                            while (z4 <= count1)
                            {
                                g_code = KeepGCode[z4].ToString();
                                //con.Open();
                                com = new SqlCommand("select * from MenuUser where USER_CODE='" + copyto_userCode + "' and GCODE='" + g_code + "' and MENUCODE='" + mcode1 + "'", con.mycon, SQLT);
                                da.SelectCommand = com;
                                bool bu = Convert.ToBoolean(da.Fill(ds, "chk_exis"));
                                //con.Close();
                                ds.Tables["chk_exis"].Clear();
                                if (bu != true)
                                {
                                    //con.Open();
                                    com = new SqlCommand("insert into MenuUser values('" + copyto_userCode + "','" + g_code + "','" + mcode1 + "'," + 1 + "," + 0 + ")", con.mycon, SQLT);
                                    com.ExecuteNonQuery();
                                    //con.Close();
                                }
                                //con.Open();
                                com = new SqlCommand("select * from MenuUser where USER_CODE='" + copyto_userCode + "' and GCODE='" + g_code + "' and MENUCODE='" + m_code1 + "'", con.mycon, SQLT);
                                da.SelectCommand = com;
                                bool bu1 = Convert.ToBoolean(da.Fill(ds, "chk_exis1"));
                                //con.Close();
                                ds.Tables["chk_exis1"].Clear();
                                if (bu1 != true)
                                {
                                    //con.Open();
                                    com = new SqlCommand("insert into MenuUser values('" + copyto_userCode + "','" + g_code + "','" + m_code1 + "'," + 1 + "," + 0 + ")", con.mycon, SQLT);
                                    com.ExecuteNonQuery();
                                    //con.Close();
                                }
                                z4++;
                            }
                            z4 = 0;
                        }
                    }
                    z++;
                }
                EDPMessage.Show("Selected User Modified", "Information....");
                //SQLT.Commit();
                //con.Close();
            }
            catch (Exception ex)
            {
            }
            SQLT.Commit();
            con.Close();
        }      

       

        private void btncompanycheck_Click(object sender, EventArgs e)
        {
            if (btncompanycheck.Text.Trim() == "Check All")
            {
                for (int i = 0; i <= COMPANYTREE.Nodes.Count - 1; i++)
                {
                    flug_selection = true;
                    COMPANYTREE.Nodes[i].Checked = true;                    
                }
                btncompanycheck.Text = "Uncheck All";
            }
            else if (btncompanycheck.Text.Trim() == "Uncheck All")
            {
                for (int i = 0; i <= COMPANYTREE.Nodes.Count - 1; i++)
                {
                    flug_selection = true;
                    COMPANYTREE.Nodes[i].Checked = false;
                }
                btncompanycheck.Text = "Check All";
            }
        }

        private void btncompanycheck1_Click(object sender, EventArgs e)
        {
            try
            {
                if (btncompanycheck1.Text.Trim() == "Check All")
                {
                    if (tabControl3.SelectedIndex == 0)
                    {
                        for (int i = 0; i <= PERMISSIONTREE.Nodes.Count - 1; i++)
                        {
                            flug_selection = true;
                            PERMISSIONTREE.Nodes[i].Checked = true;
                        }
                    }
                    else if (tabControl3.SelectedIndex == 1)
                    {
                        for (int i = 0; i <= PERMISSIONTREE_COMPANY.Nodes.Count - 1; i++)
                        {
                            flug_selection = true;
                            PERMISSIONTREE_COMPANY.Nodes[i].Checked = true;
                        }
                    }
                    btncompanycheck1.Text = "Uncheck All";
                }
                else if (btncompanycheck1.Text.Trim() == "Uncheck All")
                {
                    if (tabControl3.SelectedIndex == 0)
                    {
                        for (int i = 0; i <= PERMISSIONTREE.Nodes.Count - 1; i++)
                        {
                            flug_selection = true;
                            PERMISSIONTREE.Nodes[i].Checked = false;
                        }
                    }
                    else if (tabControl3.SelectedIndex == 1)
                    {
                        for (int i = 0; i <= PERMISSIONTREE_COMPANY.Nodes.Count - 1; i++)
                        {
                            flug_selection = true;
                            PERMISSIONTREE_COMPANY.Nodes[i].Checked = false;
                        }
                    }
                    btncompanycheck1.Text = "Check All";
                }
            }
            catch { }
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl3.SelectedIndex == 0)
                {
                    btncompanycheck1.Visible = true;
                }
                if (tabControl3.SelectedIndex == 1)
                {
                    btncompanycheck1.Visible = true;
                }
                if (tabControl3.SelectedIndex == 2)
                {
                    btncompanycheck1.Visible = false;
                }
            }
            catch { }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            if (btncheck.Text.Trim() == "Check All")
            {
                for (int i = 0; i <= MENUTREE.Nodes.Count - 1; i++)
                {
                    MENUTREE.Nodes[i].Checked = true;
                }
                btncheck.Text = "Uncheck All";
            }
            else if (btncheck.Text.Trim() == "Uncheck All")
            {
                for (int i = 0; i <= MENUTREE.Nodes.Count - 1; i++)
                {
                    MENUTREE.Nodes[i].Checked = false;
                }
                btncheck.Text = "Check All";
            }
        }
        private void btnusertransaction_Click(object sender, EventArgs e)
        {
            if (btnusertransaction.Text.Trim() == "Check All")
            {
                cheadd.Checked = true;
                chemodify.Checked = true;
                chedelete.Checked = true;
                cheview.Checked = true;
                btnusertransaction.Text = "Uncheck All";
            }
            else
            {
                cheadd.Checked = false;
                chemodify.Checked = false;
                chedelete.Checked = false;
                cheview.Checked = false;
                btnusertransaction.Text = "Check All";
            }
        }
        //coded by Bibhas 04-04-2016
        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
                textBox4.UseSystemPasswordChar = false;

            }
            else {
                textBox3.UseSystemPasswordChar = true;
                textBox4.UseSystemPasswordChar = true;
            }
        }

        private void chkShowPass_new_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass_new.Checked == true)
            {
                this.password.UseSystemPasswordChar = false;
                this.con_pass.UseSystemPasswordChar = false;

            }
            else
            {
                this.password.UseSystemPasswordChar = true;
                this.con_pass.UseSystemPasswordChar = true;
            }
        }
 
    }
}

