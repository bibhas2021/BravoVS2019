using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;

namespace Edpcom
{
    public  class ConfigChk
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        private static bool AliasName;
        private static bool WrngNgtvCshBlnc;
        private static double cashBlnc;
        public bool SetAliasName
        {
            get { return AliasName; }
            set { AliasName = value; }
        }
        public bool SetWrngNgtvCshBlnc
        {
            get { return WrngNgtvCshBlnc; }
            set { WrngNgtvCshBlnc = value; }
        }
        public double CashBlnc
        {
            get {return cashBlnc;}
            set { cashBlnc = value; }
        }

       public void Config_Set(string ficode,string gcode,string user_code,SqlConnection con)
        {
            try
            {
                SetAliasName = false;
                WrngNgtvCshBlnc = false;
                cashBlnc = 0.0;
                if (Information.IsNothing(ds.Tables["CONFIG"]) == false)
                {
                    ds.Tables["CONFIG"].Clear();
                    ds.Tables["CONFIG"].Clear();
                }
                string qry = "SELECT M.CNFG_CODE,C.ARTICLE_NO FROM AccordFourOPTN M INNER JOIN";
                qry = qry + " CNFGMST C ON M.CNFG_CODE = C.CNFG_CODE WHERE M.FICODE ='" + ficode + "'";
                qry = qry + " AND M.GCODE = '" + gcode + "' AND M.USER_CODE = '" + user_code + "'";
                cmd = new SqlCommand(qry, con);
                da.SelectCommand = cmd;
                da.Fill(ds, "CONFIG");
                for (int k = 0; k <= ds.Tables["CONFIG"].Rows.Count - 1; k++)
                {
                    if (ds.Tables["CONFIG"].Rows[k][1].ToString() == "1.2.1")
                        SetAliasName = true;
                    if (ds.Tables["CONFIG"].Rows[k][1].ToString() == "1.2.5")
                        WrngNgtvCshBlnc = true;
                }
            }
            catch
            {
                
            }
           
        }
        public bool  Chk_CashBlnc(int glcode,string ficode,string gcode,SqlConnection con)
        {
            int code = 0;
            cmd.Connection = con;
            cmd.CommandText = "select * from glmst where GCODE='" + gcode + "' and FICODE='" + ficode + "' and glcode=" + glcode + " and MTYPE='L'";
            da.SelectCommand = cmd;
            ds.Clear();
            Boolean Tmp_BLN = Convert.ToBoolean(da.Fill(ds, "TB1"));
            if (Tmp_BLN == true)
            {
                int sg, mg, pg, lv;
                sg = Convert.ToInt32(ds.Tables["TB1"].Rows[0][4]);
                mg = Convert.ToInt32(ds.Tables["TB1"].Rows[0][3]);
                pg = Convert.ToInt32(ds.Tables["TB1"].Rows[0][13]);
                int x1 = 0;
                //------------------------------------------------------------------------------------------ 
                if (pg != 0)
                {
                    cmd.CommandText = "select * from glmst where GCODE='" + gcode + "' and FICODE='" + ficode + "' and SGROUP=" + pg + " and MGROUP=" + mg + " and MTYPE='S'";
                    da.SelectCommand = cmd;
                    ds.Clear();
                    Boolean b1 = Convert.ToBoolean(da.Fill(ds, "tb_2"));
                    if (b1 == true)
                    {
                        lv = Convert.ToInt32(ds.Tables["tb_2"].Rows[0][12]);
                        pg = (int)(ds.Tables["tb_2"].Rows[0][13]);
                        code = Convert.ToInt32(ds.Tables["tb_2"].Rows[0][4]);
                        //string str = Convert.ToString(ds.Tables["tb_2"].Rows[0][6]);
                        //arr_up.Add(str);
                        x1 = lv;

                        for (int i = x1; i >= 0; i--)
                        {


                            if (lv != 1)
                            {
                                lv = lv - 1;
                            }

                            cmd.CommandText = "select * from glmst where GCODE='" + gcode + "' and FICODE='" + ficode + "' and SGROUP=" + pg + " and MGROUP=" + mg + " and SGRP_LEV=" + lv + " and MTYPE='S'";
                            da.SelectCommand = cmd;
                            ds.Clear();
                            Boolean b2 = Convert.ToBoolean(da.Fill(ds, "tb_2"));
                            if (b2 == true)
                            {
                                lv = Convert.ToInt32(ds.Tables["tb_2"].Rows[0][12]);
                                pg = (int)(ds.Tables["tb_2"].Rows[0][13]);
                                x1 = lv;
                                //string str1 = Convert.ToString(ds.Tables["tb_2"].Rows[0][6]);
                                //arr_up.Add(str1);
                                if (lv == 1)
                                {
                                     code = Convert.ToInt32(ds.Tables["tb_2"].Rows[0][4]);
                                    break;
                                }

                            }
                        }
                    }
                }
            }
            if (code == 14)
            {
                cmd.CommandText = "select curbal from glmst where GCODE='" + gcode + "' and FICODE='" + ficode + "' and sgroup=" + code + " and MTYPE='S'";
                da.SelectCommand = cmd;
                da.Fill(ds, "TB4");
                if (((ds.Tables["TB4"].Rows[0][0]).ToString().Substring(0, 1)) == "-")
                {
                    CashBlnc=Convert.ToDouble((ds.Tables["TB4"].Rows[0][0]).ToString());
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            
                //cmd.CommandText = "select SDESC from grp where GCODE='" + gcode + "' and FICODE='" + ficode + "' and MGROUP=" + mg + "";
                //adp.SelectCommand = cmd;
                //ds.Clear();
                //Boolean b3 = Convert.ToBoolean(adp.Fill(ds, "tb_3"));
                //if (b3 == true)
                //{
                //    string parent_group = Convert.ToString(ds.Tables["tb_3"].Rows[0][0]);
                //    arr_up.Add(parent_group);
                //}
                //treeView1.Nodes.Clear();
                //int a = arr_up.Count - 1;
                //treeView1.Nodes.Add(arr_up[a].ToString());
                //TreeNode tn1 = new TreeNode();
                //tn1 = treeView1.Nodes[0];
                //for (int a1 = (a - 1); a1 >= 0; a1--)
                //{
                //    TreeNode tn = new TreeNode();
                //    tn = tn1;
                //    TreeNode tn2 = new TreeNode(arr_up[a1].ToString());
                //    tn.Nodes.Add(tn2);
                //    tn1 = tn2;
                //    if (a1 == 0)
                //    {
                //        tn2.ImageIndex = 1;
                //    }
                //}
                //arr_up.Clear();
                //treeView1.ExpandAll();
            
        }
    }
}
