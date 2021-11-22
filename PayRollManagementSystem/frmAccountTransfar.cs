using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmAccountTransfar : EDPComponent.FormBaseERP
    {
        SqlTransaction SQLT;
        Edpcom.EDPCommon EDPComm = new Edpcom.EDPCommon();
        int lequid_id = 0, loc_id = 0, ficode = 0, company_code = 0;
        string edp_id = "", month_name = "", Location_Name = "", salary_id = "", session = "";
        public frmAccountTransfar(string Emp, int loc, string month, string location,string year)
        {
            edp_id = Emp;
            loc_id = loc;
            month_name = month;
            Location_Name = location;
            session = year;
            InitializeComponent();
        }

        private void frmAccountTransfar_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Account Transfer";
            txtNarration.Text = Location_Name + " location in the month of " + month_name;
            DataTable dt = new DataTable();
            string st = " select  (select SalaryHead_Full from tbl_Employee_ErnSalaryHead where slno=SalId ) as salary_name, SalId,sum(Amount)as Amount,null as Amount2,TableName,(select glcode from tbl_Employee_ErnSalaryHead where slno=SalId ) as Glcode from tbl_Employee_SalaryDet where Location_id='" + loc_id + "' and Month='" + month_name + "' and TableName ='tbl_Employee_ErnSalaryHead' and EmpId in(" + edp_id + ") group by SalId,TableName " +
                        " union " +
                        " select (select SalaryHead_Full from tbl_Employee_DeductionSalayHead where slno=SalId ) as salary_name,SalId,null, sum(Amount)as Amount2 ,TableName,(select glcode from tbl_Employee_DeductionSalayHead where slno=SalId ) as Glcode from tbl_Employee_SalaryDet where Location_id='" + loc_id + "' and Month='" + month_name + "' and TableName ='tbl_Employee_DeductionSalayHead' and EmpId in(" + edp_id + ") group by SalId,TableName " +
                        " order by TableName desc";
            dt = clsDataAccess.RunQDTbl(st);

            double dr_amt = 0, cr_amt = 0;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                salary_id = salary_id + dt.Rows[i]["Glcode"];
                if (i < dt.Rows.Count - 1)
                    salary_id = salary_id + ",";

                if (Convert.ToString(dt.Rows[i]["TableName"]) == "tbl_Employee_ErnSalaryHead")
                {
                    if (Information.IsNumeric(dt.Rows[i][2]) == true)
                        dr_amt = dr_amt + Convert.ToDouble(dt.Rows[i][2]);
                }
                else
                {
                    if (Information.IsNumeric(dt.Rows[i][3]) == true)
                        cr_amt = cr_amt + Convert.ToDouble(dt.Rows[i][3]);
                }
            }

            if (dt.Rows.Count > 0)
            {
                cr_amt = dr_amt - cr_amt;
                int cou = dt.Rows.Count;
                dt.Rows.Add();
                dt.Rows[cou]["salary_name"] = "Bank/Cash";
                dt.Rows[cou]["SalId"] = "2477147";
                dt.Rows[cou]["Glcode"] = "2477147";
                dt.Rows[cou]["TableName"] = "tbl_Employee_DeductionSalayHead";
                dt.Rows[cou][3] = string.Format("{0:F}", cr_amt);

                dt.Rows.Add();
                cou = dt.Rows.Count;
                dt.Rows.Add();
                dt.Rows[cou]["salary_name"] = "Total ";
                dt.Rows[cou][2] = string.Format("{0:F}", dr_amt);
                dt.Rows[cou][3] = string.Format("{0:F}", dr_amt);

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["SalId"].Visible = false;
                dataGridView1.Columns["TableName"].Visible = false;
                dataGridView1.Columns["salary_name"].HeaderText = "Accounts Head ";
                dataGridView1.Columns["salary_name"].Width = 260;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns[2].HeaderText = "Amount(Dr.) ";
                dataGridView1.Columns[3].HeaderText = "Amount(Cr.) ";

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.AliceBlue;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            }
            genarate_code();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            DataTable dt = Load_Data1("select  ldesc,glcode  from glmst where ficode='1' and gcode='1' and mgroup='6' and sgroup in(14,15) and MTYPE='L' ");
            if (dt.Rows.Count > 0)
            {
                cmblocation.LookUpTable = dt;
                cmblocation.ReturnIndex = 1;
            }
        }

        private DataTable Load_Data1(string qry)
        {
            DataTable dt = new DataTable();
            Edpcom.EDPConnection EDPCon = new Edpcom.EDPConnection();
            try
            {
                dt.Clear();
                EDPComm.PDATABASE_NAME = "AccordFour";
                EDPCon.DatabaseName = "AccordFour";
                SqlDataAdapter adp = new SqlDataAdapter();
                SqlCommand cmd;
                EDPCon.Close();
                EDPCon.Open();
                cmd = new SqlCommand(qry, EDPCon.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(dt);
                EDPCon.Close();
                EDPComm.PDATABASE_NAME = "EDP_Payroll";
                EDPCon.DatabaseName = "EDP_Payroll";
            }
            catch
            {
                EDPComm.PDATABASE_NAME = "EDP_Payroll";
                EDPCon.DatabaseName = "EDP_Payroll";
            }
            return dt;
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
            {
                lequid_id = Convert.ToInt32(cmblocation.ReturnValue);
                btnTransfer.Visible = true;
            }
            else
                lequid_id = 0;

            if (lequid_id != 0)
            {
                try
                {
                    DataTable dt = Load_Data1("select  ldesc,glcode  from glmst where ficode='" + ficode + "' and gcode='" + company_code + "' and glcode in(" + salary_id + ") and MTYPE='L' ");
                    DataView dv = new DataView(dt);
                    for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                    {
                        if (Information.IsNumeric(dataGridView1.Rows[i].Cells["Glcode"].Value) == true)
                        {
                            if (Convert.ToString(dataGridView1.Rows[i].Cells["SalId"].Value) == "2477147")
                            {
                                dataGridView1.Rows[i].Cells["salary_name"].Value = cmblocation.Text;
                                dataGridView1.Rows[i].Cells["Glcode"].Value = lequid_id;
                            }
                            else
                            {
                                dv.RowFilter = " glcode = '" + dataGridView1.Rows[i].Cells["Glcode"].Value + "' ";
                                if (dv.Count > 0)
                                    dataGridView1.Rows[i].Cells["salary_name"].Value = dv[0][0];
                                else
                                    dataGridView1.Rows[i].Cells["salary_name"].Value = "";
                            }
                        }
                    }
                    
                    string user_vch = GetDocNumber(1, "3", company_code);
                    txtvoucher.Text = user_vch;
                }
                catch { }
            }
        }

        public string GetDocNumber(int Desccode, string Tentry, int gcode)
        {
            try
            {
                string docnumber = "";
                DataTable dt = Load_Data1("select method from typedoc where ficode='" + ficode + "' and gcode='" + company_code + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'");

                if (Convert.ToString(dt.Rows[0][0]).Trim() == "A")
                {
                    dt = Load_Data1("select * from docnumber where ficode='" + ficode + "' and gcode='" + company_code + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'");
                    string PREPOS = Convert.ToString(dt.Rows[0][7]);
                    string SUFPOS = Convert.ToString(dt.Rows[0][8]);
                    string padding = Convert.ToString(dt.Rows[0][9]);
                    string doc_pos = Convert.ToString(dt.Rows[0][10]);
                    string no_sep = Convert.ToString(dt.Rows[0][11]);
                    string prefix = Convert.ToString(dt.Rows[0][12]).Trim();
                    string suffix = Convert.ToString(dt.Rows[0][13]).Trim();
                    dt = Load_Data1("select * from docgen where ficode='" + ficode + "' and gcode='" + company_code + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "' and State='RUNNING'");
                    docnumber = dt.Rows[0][4].ToString();
                    string sep = "", num = ""; int i = 0;
                    Int64 newnum = 0;
                    for (i = 1; i <= Convert.ToInt16(no_sep); i++) sep = sep + "/";
                    newnum = Convert.ToInt64(docnumber) + 1;
                    string form = "";
                    for (i = 1; i <= (Convert.ToInt16(padding) - Convert.ToString(newnum).Length); i++) form = form + "0";
                    num = form + Convert.ToString(newnum);
                    switch (PREPOS.Trim())
                    {
                        case "1": if (SUFPOS.Trim() == "3") docnumber = prefix + sep + num + sep + suffix;
                            else if (SUFPOS.Trim() == "2") docnumber = prefix + sep + suffix + sep + num;
                            break;
                        case "2": if (SUFPOS.Trim() == "1") docnumber = suffix + sep + prefix + sep + num;
                            else if (SUFPOS.Trim() == "3") docnumber = num + sep + prefix + sep + suffix;
                            break;
                        case "3": if (SUFPOS.Trim() == "1") docnumber = suffix + sep + num + sep + prefix;
                            else if (SUFPOS.Trim() == "2") docnumber = num + sep + suffix + sep + prefix;
                            break;
                        default: docnumber = prefix + sep + num + sep + suffix;
                            break;
                    }
                }
                else
                {
                    dt = Load_Data1("select VOUCHERNO from docgen where ficode='"+ficode+"' and gcode='" + company_code + "' and desccode='" + Desccode + "' and t_entry='" + Tentry + "'");
                    docnumber = Convert.ToString(dt.Rows[0][0]);
                }
                return docnumber;
            }
            catch
            {
                return null;
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Edpcom.EDPConnection EDPCon = new Edpcom.EDPConnection();
            try
            {
                Boolean validation_flug = validation();
                if (validation_flug == true)
                {
                    string tentry = "3";
                    int voucher = 0, branch_code = 1;

                    DataTable dtvchr = Load_Data1("Select max(voucher) from data where   t_entry='" + tentry + "' and Gcode=" + company_code + " and ficode='" + ficode + "'");
                    if ((dtvchr.Rows.Count > 0) && (Information.IsNumeric(dtvchr.Rows[0][0])))
                        voucher = Convert.ToInt32(dtvchr.Rows[0][0]);
                    voucher++;

                    EDPComm.PDATABASE_NAME = "AccordFour";
                    EDPCon.DatabaseName = "AccordFour";
                    EDPCon.Close();
                    EDPCon.Open();
                    //SqlCommand cmd.Connection = EDPCon.mycon;
                    //sqltran = EDPCon.mycon.BeginTransaction();
                    SQLT = EDPCon.mycon.BeginTransaction();
                    string s1 = "insert into data( FICode, GCODE, T_ENTRY, VOUCHER, VCHDATE,  View_stat,user_vch,CURR_CODE,BRANCH_CODE,DESCCODE,MigratedData) values('" + ficode + "','" + company_code + "','" + tentry + "'," + voucher + ",'" + EDPComm.getSqlDateStr(dtpvoucher.Value) + "',1,'" + txtvoucher.Text + "',1," + branch_code + ",1,1)";
                    SqlCommand cmd1 = new SqlCommand(s1, EDPCon.mycon, SQLT);
                    cmd1.ExecuteNonQuery();
                    s1 = "insert into narr(Ficode,GCODE,T_ENTRY,VOUCHER,BRNCH_CODE,CURR_CODE,NTYPE,NAR1,linkvoucher,linkTentry)"
                                          + " values('" + ficode + "','" + company_code + "','" + tentry + "'," + voucher + ",'" + branch_code + "', "
                                          + " '1','N','" + txtNarration.Text + " '," + voucher + ",'" + tentry + "')";
                    cmd1 = new SqlCommand(s1, EDPCon.mycon, SQLT);
                    cmd1.ExecuteNonQuery();

                    for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                    {
                        if (Information.IsNumeric(dataGridView1.Rows[i].Cells["glcode"].Value) == true)
                        {
                            int glcode = Convert.ToInt32(dataGridView1.Rows[i].Cells["glcode"].Value);
                            double amount = 0;
                            if (Convert.ToString(dataGridView1.Rows[i].Cells["TableName"].Value) == "tbl_Employee_DeductionSalayHead")
                            {
                                amount = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                                s1 = "insert into vchr( FICODE, GCODE, T_ENTRY, VOUCHER, VCHDATE, GLCODE, CRAMT, TOBY, DBAMT,user_vch,FC_DBAMT,FC_CRAMT) values('" + ficode + "','" + company_code + "','" + tentry + "'," + voucher + ",'" + EDPComm.getSqlDateStr(dtpvoucher.Value) + "'," + glcode + "," + amount + ",'To',0,'" + txtvoucher.Text + "',0," + amount + ")";
                                cmd1 = new SqlCommand(s1, EDPCon.mycon, SQLT);
                                cmd1.ExecuteNonQuery();
                            }
                            else
                            {
                                amount = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                                s1 = "insert into vchr( FICODE, GCODE, T_ENTRY, VOUCHER, VCHDATE, GLCODE, CRAMT, TOBY, DBAMT,user_vch,FC_DBAMT,FC_CRAMT) values('" + ficode + "','" + company_code + "','" + tentry + "'," + voucher + ",'" + EDPComm.getSqlDateStr(dtpvoucher.Value) + "'," + glcode + ",0,'By'," + amount + ",'" + txtvoucher.Text + "'," + amount + ",0)";
                                cmd1 = new SqlCommand(s1, EDPCon.mycon, SQLT);
                                cmd1.ExecuteNonQuery();
                            }
                        }
                    }

                    string[] s2 = new string[] { };
                    s2 = txtvoucher.Text.Trim().Split('/');
                    if (s2.Length == 3)
                    {
                        int ss = Convert.ToInt32(s2[2]);
                        s1 = "update docgen set Voucherno ='" + ss + "' where ficode='" + ficode + "' and gcode='" + company_code + "' and desccode='1' and t_entry='" + tentry + "' and State='RUNNING'";
                        cmd1 = new SqlCommand(s1, EDPCon.mycon, SQLT);
                        cmd1.ExecuteNonQuery();
                    }
                    SQLT.Commit();
                    EDPCon.Close();

                    clsDataAccess.RunNQwithStatus("update tbl_Employee_SalaryMast set Acc_transfer ='1' where Emp_Id in(" + edp_id + ") and Month='" + month_name + "' and session='" + session + "' ");

                    EDPComm.PDATABASE_NAME = "EDP_Payroll";
                    EDPCon.DatabaseName = "EDP_Payroll";
                    ERPMessageBox.ERPMessage.Show("Succeesfully Transferred.");
                }
            }
            catch
            {
                SQLT.Rollback();
                EDPCon.Close();
                EDPComm.PDATABASE_NAME = "EDP_Payroll";
                EDPCon.DatabaseName = "EDP_Payroll";
                ERPMessageBox.ERPMessage.Show("Problem To Transferred.");
            }

        }

        private void dtpvoucher_ValueChanged(object sender, EventArgs e)
        {
            genarate_code();
        }
        private void genarate_code()
        {
            DataTable focode_genarate = clsDataAccess.RunQDTbl("select Ficode,Gcode from GenarateFicode where FromDate<='" + EDPComm.getSqlDateStr(dtpvoucher.Value) + "' and ToDate>='" + EDPComm.getSqlDateStr(dtpvoucher.Value) + "'");
            ficode = 0; company_code = 0;
            if (focode_genarate.Rows.Count > 0)
            {
                ficode = Convert.ToInt32(focode_genarate.Rows[0]["Ficode"]);
                company_code = Convert.ToInt32(focode_genarate.Rows[0]["Gcode"]);
            }
        }

        private Boolean validation()
        {
            Boolean flug_value = true;
            for (int i = 0; i <= dataGridView1.Rows.Count - 3; i++)
            {
                if (Information.IsNumeric(dataGridView1.Rows[i].Cells["glcode"].Value) == false || Convert.ToInt32(dataGridView1.Rows[i].Cells["glcode"].Value) == 0)
                {
                    flug_value = false;
                    ERPMessageBox.ERPMessage.Show("Salary Head Ledger Selection Not Properly ");
                    return false;
                }
                if (Convert.ToString(dataGridView1.Rows[i].Cells["salary_name"].Value) == "")
                {
                    flug_value = false;
                    ERPMessageBox.ERPMessage.Show("Salary Head Ledger Selection Not Properly ");
                    return false;
                }
            }

            if (ficode == 0)
            {
                ERPMessageBox.ERPMessage.Show("Financial Year Genarate Properly  ");
                return false;
            }
            if (company_code == 0)
            {
                ERPMessageBox.ERPMessage.Show("Company Financial Year Genarate Properly  ");
                return false;
            }
            if (txtvoucher.Text == "")
            {
                flug_value = false;
                ERPMessageBox.ERPMessage.Show("Voucher NO. is Blank So \n Financial Year Genarate Properly  ");
                return false;
            }

            return flug_value;
        }


    }
}
