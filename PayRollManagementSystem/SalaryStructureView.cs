using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class SalaryStructureView : Form
    {

        DataRow dr;
        string year = "";
        DataTable dt_ass = new DataTable();
        DataColumn dc1 = new DataColumn("Pay Type");
        DataColumn dc2 = new DataColumn("Salary Head");
        DataColumn dc3 = new DataColumn("Print Name");
        DataColumn dc4 = new DataColumn("Valid From");
        DataColumn dc5 = new DataColumn("Valid To");
        DataColumn dc6 = new DataColumn("Calc Basis");
        DataColumn dc7 = new DataColumn("Calc Type");
        DataColumn dc8 = new DataColumn("Formula/Slab/Lum");
        DataColumn dc9 = new DataColumn("PF");
        DataColumn dc10 = new DataColumn("PF %");
        DataColumn dc11 = new DataColumn("PF VOL");
        DataColumn dc12 = new DataColumn("ESI");
        DataColumn dc13 = new DataColumn("ESI %");
        DataColumn dc14 = new DataColumn("PT");
        DataColumn dc15 = new DataColumn("Round Off");
        DataColumn dc16 = new DataColumn("Round Type");
        DataColumn dc17 = new DataColumn("TDS");
        DataColumn dc18 = new DataColumn("TDS Exempt");
        DataColumn dc19 = new DataColumn("TDS Exempt Max");
        DataColumn dc20 = new DataColumn("Carry");
        DataColumn dc21 = new DataColumn("TDS Extrapolate");
        DataColumn dc22 = new DataColumn("Remarks");

        DataColumn dc24 = new DataColumn("slno");
        DataColumn dc26 = new DataColumn("Atten Day");
        DataColumn dc27 = new DataColumn("Over Time");
        DataColumn dc28 = new DataColumn("Daily Wages");
        DataColumn dc29 = new DataColumn("Revenue Stamp");
        DataColumn dc30 = new DataColumn("Stamp Amount");

        //testless
        DataColumn dc31 = new DataColumn("Empbasic");

        DataColumn dc32 = new DataColumn("wd");
        //================================================
        DataColumn dc23 = new DataColumn("PT_basis");


        //
        DataColumn dc33 = new DataColumn("chkALK");
        DataColumn dc34 = new DataColumn("chkHide");
        DataColumn dc35 = new DataColumn("mod");
        //--------------------------------------------------
        DataColumn dc36 = new DataColumn("no_round");
        DataColumn dc37 = new DataColumn("limit_day");
        DataColumn dc38 = new DataColumn("ldays");
        DataColumn dc39 = new DataColumn("alt_mon");
        DataColumn dc40 = new DataColumn("lvless");
        DataColumn dc41 = new DataColumn("GS");
        //[no_round]=0, [limit_day]=0, [ldays]=0
        //--------------------------------------------------
        Hashtable hsg_ass_head_sal_struc = new Hashtable();

        Hashtable hsh_lumpid = new Hashtable();
        Hashtable hsh_lumpname = new Hashtable();

        int sl_no = 0;
        int lid = 0, lumid = 0;

        string lcid, mon_yr, eid, Sal_head,ctype;

        public SalaryStructureView(string locid, string loc, string mon, string empid, string emp, string head,string type)
        {
            InitializeComponent();

            this.Text = "Structure for " +loc+ "    Head : " + head;

            lcid=locid;
            mon_yr=mon;
            eid=empid;
            Sal_head = head;
            ctype = type;
        }

        public string get_sal_head_name(int id, string type)
        {
            string res = "";
            if (type == "E")
            {
                string s = "select SalaryHead_Short from tbl_Employee_ErnSalaryHead where slno=" + id;
                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();

            }
            else if (type == "D")
            {
                string s = "select SalaryHead_Short from tbl_Employee_DeductionSalayHead where slno=" + id;

                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();
            }

            return res;

        }

        public string get_sal_head_ID(string type, string head)
        {
            string res = "";
            if (type == "E")
            {
                string s = "select slno from tbl_Employee_ErnSalaryHead where (SalaryHead_Short='" + head+"')";
                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();

            }
            else if (type == "D")
            {
                string s = "select slno from tbl_Employee_DeductionSalayHead where (SalaryHead_Short='" + head + "')";

                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();
            }

            return res;

        }

        public string sal_Head_Name(string type, string head)
        {
            string res = "";
            if (type == "E")
            {
               // chkGrossAs.Enabled = true;
                string s = "select salaryhead_full,gs from tbl_Employee_ErnSalaryHead where (salaryhead_short='" + head + "')";
                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                {
                    res = dts.Rows[0][0].ToString();


                    //if (dts.Rows[0][0].ToString().Trim() == "0")
                    //    chkGrossAs.Checked = false;
                    //else chkGrossAs.Checked = true;

                }
            }
            else if (type == "D")
            {
                string s = "select salaryhead_full from tbl_Employee_DeductionSalayHead where (salaryhead_short='" + head + "')";

                DataTable dts = new DataTable();
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    res = dts.Rows[0][0].ToString();

                //chkGrossAs.Enabled = false;
                //chkGrossAs.Checked = false;
               
                
                //if (res == "")
                //{
                //    s = "select pfhead from tbl_Employee_Config_PFHeads where shortname='" + head + "'";
                //    dts = clsDataAccess.RunQDTbl(s);
                //    if (dts.Rows.Count > 0)
                //        res = dts.Rows[0][0].ToString();

                //}
            }

            return res;
        }

        public string get_OtherName(string typeName, int id)
        {
            string s = ""; string ret = ""; DataTable dts = new DataTable();
            if (typeName == "COMPANY LUMPSUM")
            {
                s = "select LUMPNAME from tbl_Employee_Lumpsum where LUMPID=" + id + " and LUMPTYPE=0";

                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = dts.Rows[0][0].ToString();

            }
            else if (typeName == "SAL STRUCTURE LUMPSUM")
            {
                s = "select LUMPNAME from tbl_Employee_Lumpsum where LUMPID=" + id + " and LUMPTYPE=1";
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = dts.Rows[0][0].ToString();
            }
            else if (typeName == "FORMULA")
            {
                s = "select fname from tbl_Employee_Sal_Structure_Formula where fid=" + id;
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = dts.Rows[0][0].ToString();
            }
            else if (typeName == "SLAB")
            {
                s = "select slabname from tbl_Employee_Slab_Def where slabid=" + id;
                dts = clsDataAccess.RunQDTbl(s);
                if (dts.Rows.Count > 0)
                    ret = dts.Rows[0][0].ToString();
            }

            return ret;
        }



        public void get_ass()
        {
            sl_no = 0;
            dt_ass.Clear();
            dt_ass.Columns.Clear();
            hsg_ass_head_sal_struc.Clear();

            DataColumn[] dc25 = new DataColumn[] { dc1, dc2, dc3, dc4, dc5, dc6, dc7, dc8, dc9, dc10, dc11, dc12, dc13, dc14, dc15, dc16, dc17, dc18, dc19, dc20, dc21, dc22, dc24, dc26, dc27, dc28, dc29, dc30, dc31, dc33, dc34, dc35, dc32, dc23, dc36, dc37, dc38, dc39, dc40, dc41 };//, dc32
            dt_ass.Columns.AddRange(dc25);
            string s = "";
            s = "select P_TYPE,SESSION,SAL_STRUCT,SAL_HEAD,V_FROM,V_TO,C_BASIS,C_TYPE,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,SLNO,atten_day,Proxy_day,Daily_wages,Revenue_Stamp,Stamp_Amount,EMP_BASIC,chkALK,chkHide,mod,wd,pt_basis,[no_round],[limit_day],[ldays],[alt_mon],[lvless],[GS] from tbl_Employee_Assign_SalStructure where (Location_id='" + lcid + "') and (SAL_HEAD='" + get_sal_head_ID(ctype, Sal_head) + "') and (P_Type='" + ctype + "')";// and session='" + cmbYear.Text.Trim() + "'";
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(s);
            if (dt.Rows.Count > 0)
            {

                for (int y = 0; y < dt.Rows.Count; y++)
                {

                    if (dt.Rows[y][0].ToString().Trim() == "E")
                    {
                        dr = dt_ass.NewRow();
                        dr[0] = "Earnings";
                        dr[1] = get_sal_head_name(Convert.ToInt32(dt.Rows[y][3]), "E");
                        dr[2] = sal_Head_Name(ctype, get_sal_head_name(Convert.ToInt32(dt.Rows[y][3]), ctype));
                        dr[3] = dt.Rows[y][4].ToString() + "/" + dt.Rows[y][1].ToString();
                        dr[4] = dt.Rows[y][5].ToString() + "/" + dt.Rows[y][1].ToString();
                        dr[5] = dt.Rows[y][6].ToString();
                        dr[6] = dt.Rows[y][7].ToString();
                        dr[7] = get_OtherName(dt.Rows[y][7].ToString(), Convert.ToInt32(dt.Rows[y][8]));
                        if (Convert.ToInt32(dt.Rows[y][9]) == 0)
                        {
                            dr[8] = "NO";
                            dr[9] = "";
                        }
                        else
                        {
                            dr[8] = "YES";
                            dr[9] = dt.Rows[y][9].ToString();
                        }

                        if (Convert.ToInt32(dt.Rows[y][10]) == 0)
                            dr[10] = "NO";
                        else
                            dr[10] = "YES";



                        if (Convert.ToInt32(dt.Rows[y][11]) == 0)
                        {
                            dr[11] = "NO";
                            dr[12] = "";
                        }
                        else
                        {
                            dr[11] = "YES";
                            dr[12] = dt.Rows[y][11].ToString();
                        }
                        if (Convert.ToInt32(dt.Rows[y][12]) == 0)
                            dr[13] = "NO";
                        else
                            dr[13] = "YES";
                        if (dt.Rows[y][13].ToString() == "")
                        {
                            dr[14] = "NO";
                            dr[15] = dt.Rows[y][13].ToString();
                        }
                        else
                        {
                            dr[14] = "YES";
                            dr[15] = dt.Rows[y][13].ToString();
                        }
                        dr[21] = dt.Rows[y][18].ToString();
                        dr[22] = dt.Rows[y][19].ToString();

                        if (Convert.ToInt32(dt.Rows[y]["atten_day"]) == 0)
                            dr[23] = "NO";
                        else
                            dr[23] = "YES";

                        if (Convert.ToInt32(dt.Rows[y]["Proxy_day"]) == 0)
                            dr[24] = "NO";
                        else if (Convert.ToInt32(dt.Rows[y]["Proxy_day"]) == 2)
                            dr[24] = "ED";
                        else
                            dr[24] = "YES";

                        if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 0)
                            dr[25] = "NO";
                        else if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 2)
                            dr[25] = "HR";
                        else
                            dr[25] = "YES";

                        if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 0)
                            dr[28] = "0";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 1)
                            dr[28] = "1";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 2)
                            dr[28] = "2";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 3)
                            dr[28] = "3";
                        else if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 4)
                            dr[28] = "4";
                        //if (Convert.ToInt32(dt.Rows[y]["EMP_SAL"]) == 0)
                        //    dr[29] = "NO";
                        //else
                        //    dr[29] = "YES";

                        if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 0)
                            dr[29] = "0";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 1)
                            dr[29] = "1";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 2)
                            dr[29] = "2";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 3)
                            dr[29] = "3";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 6)
                            dr[29] = "6";
                        else if (Convert.ToInt32(dt.Rows[y]["chkALK"]) == 7)
                            dr[29] = "7";

                        if (Convert.ToInt32(dt.Rows[y]["chkHide"]) == 1)
                            dr[30] = "1";
                        else
                            dr[30] = "0";

                        dr[31] = dt.Rows[y]["mod"].ToString().Trim();
                        dr[32] = dt.Rows[y]["wd"].ToString().Trim();
                        dr[33] = dt.Rows[y]["pt_basis"].ToString().Trim();

                        //no_round],[limit_day],[ldays
                        dr[34] = dt.Rows[y]["no_round"].ToString().Trim();
                        dr[35] = dt.Rows[y]["limit_day"].ToString().Trim();
                        dr[36] = dt.Rows[y]["ldays"].ToString().Trim();
                        dr[37] = dt.Rows[y]["alt_mon"].ToString().Trim();
                        dr[38] = dt.Rows[y]["lvless"].ToString().Trim();
                        dr[39] = dt.Rows[y]["GS"].ToString().Trim();
                        dt_ass.Rows.Add(dr);
                        if (!hsg_ass_head_sal_struc.ContainsKey(dt.Rows[y][0].ToString().Trim() + "/" + dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString()))
                            //time
                            /////////hsg_ass_head_sal_struc.Add(dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString(),dt.Rows[y]["SLNO"].ToString());
                            hsg_ass_head_sal_struc.Add(dt.Rows[y][0].ToString().Trim() + "/" + dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString(), dt.Rows[y]["SLNO"].ToString());


                    }
                }
                //dr = dt_ass.NewRow();
                //dt_ass.Rows.Add(dr);
                for (int z = 0; z < dt.Rows.Count; z++)
                {

                    if (dt.Rows[z][0].ToString().Trim() == "D")
                    {
                        dr = dt_ass.NewRow();
                        dr[0] = "Deductions";
                        dr[1] = get_sal_head_name(Convert.ToInt32(dt.Rows[z][3]), "D");//dt.Rows[z][3].ToString();
                        dr[2] = sal_Head_Name(ctype, get_sal_head_name(Convert.ToInt32(dt.Rows[z][3]), ctype));
                        dr[3] = dt.Rows[z][4].ToString() + "/" + dt.Rows[z][1].ToString();
                        dr[4] = dt.Rows[z][5].ToString() + "/" + dt.Rows[z][1].ToString();
                        dr[5] = dt.Rows[z][6].ToString();
                        dr[6] = dt.Rows[z][7].ToString();
                        dr[7] = get_OtherName(dt.Rows[z][7].ToString(), Convert.ToInt32(dt.Rows[z][8]));//dt.Rows[z][8].ToString();
                        if (Convert.ToInt32(dt.Rows[z][9]) == 0)
                        {
                            dr[8] = "NO";
                            dr[9] = "";
                        }
                        else
                        {
                            dr[8] = "YES";
                            dr[9] = dt.Rows[z][9].ToString();
                        }
                        if (Convert.ToInt32(dt.Rows[z][10]) == 0)
                            dr[10] = "NO";
                        else
                            dr[10] = "YES";

                        if (Convert.ToInt32(dt.Rows[z][11]) == 0)
                        {
                            dr[11] = "NO";
                            dr[12] = "";
                        }
                        else
                        {
                            dr[11] = "YES";
                            dr[12] = dt.Rows[z][11].ToString();
                        }
                        if (Convert.ToInt32(dt.Rows[z][12]) == 0)
                            dr[13] = "NO";
                        else
                            dr[13] = "YES";
                        if (dt.Rows[z][13].ToString() == "")
                        {
                            dr[14] = "NO";
                            dr[15] = dt.Rows[z][13].ToString();
                        }
                        else
                        {
                            dr[14] = "YES";
                            dr[15] = dt.Rows[z][13].ToString();
                        }

                        dr[21] = dt.Rows[z][18].ToString();
                        dr[22] = dt.Rows[z][19].ToString();

                        if (Convert.ToInt32(dt.Rows[z]["atten_day"]) == 0)
                            dr[23] = "NO";
                        else
                            dr[23] = "YES";

                        if (Convert.ToInt32(dt.Rows[z]["Proxy_day"]) == 0)
                            dr[24] = "NO";
                        else
                            dr[24] = "YES";

                        if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 0)
                            dr[25] = "NO";
                        else if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 2)
                            dr[25] = "HR";
                        else
                            dr[25] = "YES";

                        if (Convert.ToInt32(dt.Rows[z]["Revenue_Stamp"]) == 0)
                            dr[26] = "NO";
                        else
                            dr[26] = "YES";

                        dr[27] = Convert.ToString(dt.Rows[z]["Stamp_Amount"]);

                        if (Convert.ToInt32(dt.Rows[z]["chkALK"]) == 0)
                            dr[29] = "0";
                        else if (Convert.ToInt32(dt.Rows[z]["chkALK"]) == 1)
                            dr[29] = "1";
                        else if (Convert.ToInt32(dt.Rows[z]["chkALK"]) == 2)
                            dr[29] = "2";
                        else if (Convert.ToInt32(dt.Rows[z]["chkALK"]) == 3)
                            dr[29] = "3";

                        if (Convert.ToInt32(dt.Rows[z]["chkHide"]) == 1)
                            dr[30] = "1";
                        else
                            dr[30] = "0";

                        dr[31] = dt.Rows[z]["mod"].ToString().Trim();
                        dr[32] = dt.Rows[z]["wd"].ToString().Trim();
                        dr[33] = dt.Rows[z]["pt_basis"].ToString().Trim();

                        dr[34] = dt.Rows[z]["no_round"].ToString().Trim();
                        dr[35] = dt.Rows[z]["limit_day"].ToString().Trim();
                        dr[36] = dt.Rows[z]["ldays"].ToString().Trim();

                        dr[37] = dt.Rows[z]["alt_mon"].ToString().Trim();
                        dr[38] = dt.Rows[z]["lvless"].ToString().Trim();
                        dr[39] = dt.Rows[z]["GS"].ToString().Trim();
                        dt_ass.Rows.Add(dr);
                        if (!hsg_ass_head_sal_struc.ContainsKey(dt.Rows[z][0].ToString().Trim() + "/" + dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString()))
                            //time
                            /////////hsg_ass_head_sal_struc.Add(dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString(), dt.Rows[z]["SLNO"].ToString());
                            hsg_ass_head_sal_struc.Add(dt.Rows[z][0].ToString().Trim() + "/" + dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString(), dt.Rows[z]["SLNO"].ToString());



                    }

                }
                dgvStructure.DataSource = "";
                dgvStructure.DataSource = dt_ass;
                string calcType = "", calc = "";
                if (dt_ass.Rows.Count > 0)
                {
                    calcType = dt_ass.Rows[0][6].ToString().Trim();
                    calc = dt_ass.Rows[0][7].ToString().Trim();

                    if (calcType.ToUpper() == "FORMULA")
                    {


                    }
                    else if (calcType.ToUpper() == "COMPANY LUMPSUM" || calcType.ToUpper() == "LUMPSUM")
                    {

                        get_Lumpsum(calc, 0);
                    }
                }

                for (int col_ind = 0; col_ind < dgvStructure.Columns.Count; col_ind++)
                {
                    if (col_ind >= 8)
                    {
                        dgvStructure.Columns[col_ind].Visible = false;
                    }
                }

            }

        }

        //-------------------------------------------------------------------------------------------
        public string Get_SalName(int t)
        {
            string res = "", sss = "";
            DataTable dt5 = new DataTable();
            sss = "select salarycategory from tbl_Employee_SalaryStructure where slno=" + t;
            dt5 = clsDataAccess.RunQDTbl(sss);
            res = dt5.Rows[0][0].ToString();
            return res;
        }
        public int Get_SalID(string sname)
        {
            int res = 0; string sss = "";
            DataTable dt5 = new DataTable();
            sss = "select slno from tbl_Employee_SalaryStructure where salarycategory='" + sname + "'";
            dt5 = clsDataAccess.RunQDTbl(sss);
            res = Convert.ToInt32(dt5.Rows[0][0]);
            return res;
        }

        public void get_Lumpsum(string str, int ltype)
        {
           DataTable dt_lm=new DataTable();

           DataColumn dc1 = new DataColumn("Sal Structure");
           DataColumn dc2 = new DataColumn("Name");
           DataColumn dc3 = new DataColumn("Type");
           DataColumn dc4 = new DataColumn("Grade");
           DataColumn dc5 = new DataColumn("Amount");  
            dt_lm.Columns.Clear();
            DataTable dt = new DataTable();
            string s1 = "";
            
                if (ltype == 1)
                    s1 = "select LUMPNAME,LUMPTYPE,GRADE,STRUCID,AMOUNT,LUMPID from tbl_Employee_Lumpsum where LUMPNAME='" + str + "' order by LUMPNAME ";
                else
                    s1 = "select LUMPNAME,LUMPTYPE,GRADE,STRUCID,AMOUNT,LUMPID from tbl_Employee_Lumpsum where LUMPNAME='" + str + "' order by LUMPNAME ";
          
            dt = clsDataAccess.RunQDTbl(s1);
            if (dt.Rows.Count > 0)
            {
                if (ltype == 1)
                {
                    dt_lm.Columns.Add(dc1);
                    dt_lm.Columns.Add(dc2);
                    dt_lm.Columns.Add(dc3);
                    dt_lm.Columns.Add(dc4);
                    dt_lm.Columns.Add(dc5);

                    for (int c = 0; c < dt.Rows.Count; c++)
                    {

                        dr = dt_lm.NewRow();
                        dr[0] = Get_SalName(Convert.ToInt32(dt.Rows[c][3]));
                        dr[1] = dt.Rows[c][0].ToString();
                        if (dt.Rows[c][2].ToString() != "")
                        {
                            dr[2] = "Designation";
                            dr[3] = Get_Section(Convert.ToInt32(dt.Rows[c][2]));// dt.Rows[c][2].ToString();
                        }
                        else
                        {
                            dr[2] = "Everyone";
                            dr[3] = " ";
                        }
                        //dr[4] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[c][4]));
                        dr[4] = Convert.ToDouble(dt.Rows[c][4]).ToString(EDPCommon.SetDecimalPlace(2));
                        dt_lm.Rows.Add(dr);
                        if (!hsh_lumpid.ContainsKey(dt.Rows[c][5].ToString() + "/" + dt.Rows[c][1].ToString()))
                            hsh_lumpid.Add(dt.Rows[c][5].ToString() + "/" + dt.Rows[c][1].ToString(), dt.Rows[c][0].ToString());
                        if (!hsh_lumpname.ContainsKey(dt.Rows[c][0].ToString() + "/" + dt.Rows[c][1].ToString()))
                            hsh_lumpname.Add(dt.Rows[c][0].ToString() + "/" + dt.Rows[c][1].ToString(), dt.Rows[c][0].ToString());

                    }
                }
                else
                {
                    dt_lm.Columns.Add(dc2);
                    dt_lm.Columns.Add(dc3);
                    dt_lm.Columns.Add(dc4);
                    dt_lm.Columns.Add(dc5);

                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        dr = dt_lm.NewRow();
                        dr[0] = dt.Rows[k][0].ToString();
                        if (dt.Rows[k][2].ToString() != "")
                        {
                            if (dt.Rows[k][2].ToString() != "0")
                            {
                                dr[1] = "Designation";
                                dr[2] = Get_Section(Convert.ToInt32(dt.Rows[k][2]));
                            }
                            else
                            {
                                dr[1] = "Everyone";
                                dr[2] = Get_Section(Convert.ToInt32(dt.Rows[k][2]));
                            }
                        }
                        else
                        {
                            dr[1] = "Everyone";
                            dr[2] = " ";
                        }
                        //dr[3] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[k][4]));
                        dr[3] = Convert.ToDouble(dt.Rows[k][4]).ToString(EDPCommon.SetDecimalPlace(2));

                        dt_lm.Rows.Add(dr);
                        if (!hsh_lumpid.ContainsKey(dt.Rows[k][5].ToString() + "/" + dt.Rows[k][1].ToString()))
                            hsh_lumpid.Add(dt.Rows[k][5].ToString() + "/" + dt.Rows[k][1].ToString(), dt.Rows[k][0].ToString());
                        if (!hsh_lumpname.ContainsKey(dt.Rows[k][0].ToString() + "/" + dt.Rows[k][1].ToString()))
                            hsh_lumpname.Add(dt.Rows[k][0].ToString() + "/" + dt.Rows[k][1].ToString(), dt.Rows[k][0].ToString());
                    }
                }
                dgvCalculation.DataSource = "";
                dgvCalculation.DataSource = dt_lm;
                lid = dt.Rows.Count + 1;

            }
        }

        public string Get_Section(int SecId)
        {
            string qry = ""; string res = "";
            //qry = "select section from tbl_Employee_Sectionmaster where slno=" + SecId;
            qry = "select DesignationName from tbl_Employee_DesignationMaster where SlNo='" + SecId + "'";
            DataTable dtqry = new DataTable();
            dtqry = clsDataAccess.RunQDTbl(qry);
            if (dtqry.Rows.Count > 0)
            {
                res = dtqry.Rows[0][0].ToString();
            }
            return res;
        }

        //------------------------------------------------------------------------------------
        private void SalaryStructureView_Load(object sender, EventArgs e)
        {
            get_ass();
        }

        private void dgvStructure_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvStructure.DataSource = dt_ass;
            string calcType = "", calc = "";
            if (dgvStructure.Rows.Count > 0)
            {
                calcType = dgvStructure.Rows[0].Cells[6].Value.ToString().Trim();
                calc = dgvStructure.Rows[0].Cells[7].Value.ToString().Trim();

                if (calcType.ToUpper() == "FORMULA")
                {
                    Config_SalaryStructure_Formula cs = new Config_SalaryStructure_Formula();
                    cs.txtSearch.Text = calc;
                    cs.StartPosition = FormStartPosition.CenterScreen;
                    cs.ShowDialog();

                }
                else if (calcType.ToUpper() == "COMPANY LUMPSUM" || calcType.ToUpper() == "LUMPSUM")
                {
                    Lumpsum_definer ld = new Lumpsum_definer();
                    ld.get_Lumpsum(0, 0);
                        //Sal_ID(calc), 0);
                    ld.txtSearch.Text = calc;

                    ld.ShowDialog();
                    //get_Lumpsum(calc, 0);
                }
            }
        }

        public int Sal_ID(string sc)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select SlNo from tbl_Employee_SalaryStructure where (SalaryCategory='" + sc + "')";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}
