using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data.SqlClient;
using Edpcom;
using System.IO;
using ERPMessageBox;
using System.Globalization;

namespace PayRollManagementSystem
{
    public partial class frmEmployeeSalarySheet : EDPComponent.FormBaseMidium
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        string Item_Code = "", Tentry_code = "";
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        //CultureInfo cultureInfo = new CultureInfo("en-IN");
        string Frm_Type = "";
        string Location_Name = "";
        int Head_Cou = 0,prev_type=0;
        public string Locations = "", compid="";
        public DateTime sdt;
        string Odet="",Oamt="",Agent="";
        Boolean boolPFESIManipulating = false;
        int os_adv = 0, os_kit = 0, os_loan = 0, cWD_MOD = 0, SalExp=0,Woff=0;
        string month = "";
        string mn_yr="";
        ArrayList sa_col = new ArrayList();
        ArrayList sa_col2 = new ArrayList();
        public frmEmployeeSalarySheet(string type)
        {
            InitializeComponent();
            Frm_Type = type;
            //if (type == "Q")
            //{
            //    btnPrnt.Text = "      View";
            //    btnPreview.Visible = false;
            //}
            //else
            //{
            //    btnPrnt.Text = "     Print";
            //    btnPreview.Visible = true;
            //}
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


        public void view_sal(DateTime mon, string lcid,string lc,string yr,string coid,string mode)
        {
            lbl_mod.Text = mode.Trim();
            AttenDtTmPkr.Value = mon;
            dtp_copy.Value = mon;
            mn_yr = mon.ToString("MMMM - yyyy");

            cmbLocation.Text = lc + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + lcid);
                cmbLocation.ReturnValue = lcid;
                Locations = lcid;
                cmbYear.SelectedItem =yr;
                cmbcompany.ReturnValue = coid.ToString();
                string s = "SELECT CO_NAME FROM Company WHERE  (CO_CODE =" + coid.ToString() + ")";
                cmbcompany.Text = clsDataAccess.GetresultS(s);
                
        }


        public void view_sal_prev(DateTime mon, string lcid, string lc, string yr, string coid, object sender, EventArgs e)
        {

            AttenDtTmPkr.Value = mon;
            dtp_copy.Value = mon;
            mn_yr = mon.ToString("MMMM - yyyy");

            cmbLocation.Text = lc;
            cmbLocation.ReturnValue = lcid;
            Locations = lcid;
            cmbYear.SelectedItem = yr;
            cmbcompany.ReturnValue = coid.ToString();
            string s = "SELECT CO_NAME FROM Company WHERE  (CO_CODE =" + coid.ToString() + ")";
            cmbcompany.Text = clsDataAccess.GetresultS(s);
            btnPreview_Click(sender, e);
        }



        public void view_alk()
        {
            int next_month = 0;
            if (AttenDtTmPkr.Value.Month == 12)
                next_month = 1;
            else
                next_month = AttenDtTmPkr.Value.Month + 1;

            string n_month = clsEmployee.GetMonthName(next_month);
            string sess=cmbYear.Text.Trim();
            if (n_month.Trim() == "" || sess == "" || Locations.Trim() == "")
            {
                return;

            }
            DataTable tot_employ1 = new DataTable();
            if (cmbSalarySheetType.SelectedIndex == 1)
            {
                tot_employ1 = clsDataAccess.RunQDTbl("SELECT * FROM tbl_Employee_SalaryMast sm where (Session='" + cmbYear.Text + "') and (Month ='" + n_month + "') and (Location_id in " + Locations + ")");
            }
            else
            {
                tot_employ1 = clsDataAccess.RunQDTbl("SELECT * FROM tbl_Employee_SalaryMast sm where (Session='" + cmbYear.Text + "') and (Month ='" + n_month + "') and (Location_id = '" + Locations + "')");
            }
            if (tot_employ1.Rows.Count > 0)
            {
                chk_os_adv.Checked = false;
                chk_os_Kit.Checked = false;
                chk_os_Loan.Checked = false;
                groupBox3.Enabled = false;
            }
            else
            {
                groupBox3.Enabled = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            //txtitem.Text = "0";
            //if (radAlphabetically.Checked == true)
            //{
            //    string sqlstmnt = "select PDESC,PCODE,PALIAS from iglmst where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "' ";
            //    EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item", "Select Item Name", "List of Item Name", 0, "CMPN", 0);
            //}
            //else if (radGroupwise.Checked == true)
            //{
            //    string sqlstmnt = "select CC_DESC,CC_CODE,CC_ALIAS from CCMAST where ficode='" + edpcom.CurrentFicode + "' and gcode='" + edpcom.PCURRENT_GCODE + "'and PLV_CODE='0' ";
            //    EDPCommon.MLOV_EDP(sqlstmnt, "Tag Item Group", "Select Item Group Name", "List of Group Name", 0, "CMPN", 0);
            //}
            //arr.Clear();
            //arr = EDPCommon.arr_mod;
            //lblItem.Items.Clear();
            //if (arr.Count > 0)
            //{
            //    getcode.Clear();
            //    arr = EDPCommon.arr_mod;
            //    getcode = EDPCommon.get_code;
            //    lblItem.Items.Clear();
            //    Item_Code = null;
            //    for (int i = 0; i <= (arr.Count - 1); i++)
            //    {
            //        lblItem.Items.Add(arr[i].ToString());
            //        Item_Code = Item_Code + getcode[i].ToString();
            //        if (i != getcode.Count - 1)
            //        {
            //            Item_Code = Item_Code + ",";
            //        }
            //    }
            //}
            //txtitem.Text = Convert.ToString(arr.Count);
        }
        private void btnTransaction_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    txttransaction.Text = "0";
            //    Program.Tentry.Clear();
            //    SelectItemOrder ss = new SelectItemOrder();
            //    ss.ShowDialog();
            //    lblTransaction.Items.Clear();
            //    Tentry_code = null;
            //    string temp_tentry = "";             
            //    for (int i = 0; i <= (Program.Tentry.Count - 1); i++)
            //    {
            //        Tentry_code = Tentry_code + Program.Tentry[i].ToString().Trim();
            //        temp_tentry = "'" + Program.Tentry[i].ToString().Trim() + "'";
            //        if (i != Program.Tentry.Count - 1)
            //        {
            //            Tentry_code = Tentry_code + ",";
            //        }
            //        DataTable dt1 = Program.GetTentryName(Convert.ToString(temp_tentry));
            //        if (dt1.Rows.Count > 0)
            //        {
            //            lblTransaction.Items.Add(dt1.Rows[0]["TRAN_HEAD"]);
            //        }
            //    }
            //    //Program.Tentry.Clear();
            //    txttransaction.Text = Convert.ToString(Program.Tentry.Count);
            //}
            //catch { }
        }
        private void frmEmployeeSalarySheet_Load(object sender, EventArgs e)
        {


            cWD_MOD = 0;

            try
            {
                cWD_MOD = Convert.ToInt32(Convert.ToDouble(clsDataAccess.GetresultS("select desgday from CompanyLimiter")));
            }
            catch
            {
                cWD_MOD = 0;
            }


            try
            {
                btnExp2.Visible = false;
                if (clsDataAccess.GetresultS("Select SalExc2 from CompanyLimiter") == "1")
                {
                    btnExp2.Visible = true;

                }
                
            }
            catch { }


            this.KeyPreview = true;
            this.Text = "Payment Sheet";
            //dtpForm.Text = Convert.ToString(edpcom.CURRCO_SDT);
            //dtpto.Text = Convert.ToString(edpcom.CURRCO_EDT);
            //cheDescription.Checked = true;
            //raddetails.Checked = true;
            //radAlphabetically.Checked = true;
            //this.Text = "Stock Statement";
            //txttransaction.Text = "0";
            //txtitem.Text = "0";
            cmbSalarySheetType.SelectedIndex = 0;
            PFESIManipulationChecking();
            if (boolPFESIManipulating)
            {
                lblStatusCode.Text = "1";
                label7.Visible = true;
                lblStatusCode.Visible = true;
                this.Size = this.MaximumSize;
            }
            else
            {
                lblStatusCode.Text = "4";
                label7.Visible = false;
                lblStatusCode.Visible = false;
                this.Size = this.MinimumSize;
            }
            //dtpidate.Value = System.DateTime.Now;
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            //set session
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }
            if (Frm_Type == "P")
            {
                AttenDtTmPkr.CustomFormat = "MMMM - yyyy";

                dtp_copy.CustomFormat = "MMMM - yyyy";
                dtp_copy.Value = Convert.ToDateTime(mn_yr);
                AttenDtTmPkr.Value = Convert.ToDateTime(mn_yr);
                AttenDtTmPkr.Text = mn_yr;
            }
            else
            {
                AttenDtTmPkr.Value = DateTime.Now.AddMonths(-1);
            }

           
            string s = "SELECT CO_NAME, GCODE  FROM Company";
            dt = clsDataAccess.RunQDTbl(s);
            try
            {
                if (dt.Rows.Count > 1)
                {

                    cmbcompany.LookUpTable = dt;
                    cmbcompany.ReturnIndex = 1;
                    lbl_company.Text = "";

                }
                if (dt.Rows.Count == 1)
                {
                    cmbcompany.Text = Convert.ToString(dt.Rows[0][0]);
                    lbl_company.Text = Convert.ToString(dt.Rows[0][0]);
                    compid = Convert.ToString(dt.Rows[0][1]);
                }
                if (dt.Rows.Count == 0)
                {
                    lbl_company.Text = "";
                    compid = "";
                    cmbcompany.Visible = false;
                    MessageBox.Show("No Company linked with Location");
                }
                label3.Visible = true;
                lbl_company.Visible = false;
                cmbcompany.Visible = true;

            }
            catch{}
        }
        public void LoadDataTable()
        {
            //dt.Columns.Clear();

            DataTable dt7 = clsDataAccess.RunQDTbl("select  e.RefBankAcountNo,e.RefDesignationName,e.RefBasic,e.RefDaysPresent,e.RefOT,e.RefTotalDays from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");
            
            DataTable data;
            data = new DataTable("columnname");
            DataColumn column_name = new DataColumn("Column_Name");
            DataColumn Ref_Column_slno = new DataColumn("Ref_Column_slno");
            data.Columns.Add(column_name);
            data.Columns.Add(Ref_Column_slno);
            if (dt7.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dt7.Columns.Count; i++)
                {
                    DataRow dataRow = data.NewRow();
                    dataRow["Column_Name"] = dt7.Columns[i].ColumnName;
                    dataRow["Ref_Column_slno"] = dt7.Rows[0][i].ToString();
                    data.Rows.Add(dataRow);
                }

            }


            data.AcceptChanges();

            //DataTable dt8 = clsDataAccess.RunQDTbl("select  e.BankAcountNo,e.DesignationName,e.Basic,e.DaysPresent,e.OT,e.TotalDays  from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");
            DataTable dt8 = clsDataAccess.RunQDTbl("select  e.BankAcountNo as BankAcountNo,e.DesignationName as Rank,e.Basic as Salary,e.DaysPresent as WDay,e.OT as OT,e.TotalDays as TotalDays  from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");

            //e.BankAcountNo as BankAcountNo,e.DesignationName as Rank,e.Basic as Salary,e.DaysPresent as W_Day,e.OT as O_T,e.TotalDays as Tot_Day
            DataTable data1;
            data1 = new DataTable("columnname1");

            DataColumn ColumnName = new DataColumn("ColumnName");
            DataColumn Check = new DataColumn("Check");

            data1.Columns.Add(ColumnName);
            data1.Columns.Add(Check);

            if (dt8.Rows.Count > 0)
            {
                for (Int32 i1 = 0; i1 < dt8.Columns.Count; i1++)
                {
                    DataRow dataRow = data1.NewRow();
                    dataRow["ColumnName"] = dt8.Columns[i1].ColumnName;
                    dataRow["Check"] = dt8.Rows[0][i1];
                    data1.Rows.Add(dataRow);
                }
            }
 
            data1.AcceptChanges();

            data.Columns.Add("ColumnName");
            data.Columns.Add("Check");

            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["ColumnName"] = data1.Rows[i]["ColumnName"];
                data.Rows[i]["Check"] = data1.Rows[i]["Check"];
            }

            data.Columns.Remove(data.Columns[0]);
            data.AcceptChanges();
            Head_Cou = 0;
            DataRow[] result = data.Select("Check = 'false'");
            DataRow[] result1 = data.Select("Check = 'True'");
            Head_Cou = result1.Length;
            if (SalExp == 0 || SalExp == 2)
            {
                Retrive_Data();
            }
            else
            {
                Retrive_Data_cgfm();
            }
            if (Convert.ToInt32(lbl_NC.Text) > 0)
            {
                dt.Columns.Add("EXTRA PAY", typeof(string));
                dt.Columns.Add("GROSS PAY", typeof(string));

                DataTable nc_Col = clsDataAccess.RunQDTbl("select (select SalaryHead_Short from tbl_Employee_ErnSalaryHead where slno=eas.SAL_HEAD) HEAD,SAL_HEAD from tbl_Employee_Assign_SalStructure eas where Location_id="+Locations+" and NCompliance=1");
                if (nc_Col.Rows.Count > 0)
                {
                    for (int ix = 0; ix < dt.Rows.Count; ix++)
                    {
                        if (dt.Rows[ix]["EmployName"].ToString().Trim() != "")
                        {
                            dt.Rows[ix]["EXTRA PAY"] = "0";
                            for (int idx = 0; idx < nc_Col.Rows.Count; idx++)
                            {
                                try
                                {
                                    dt.Rows[ix]["EXTRA PAY"] = Convert.ToString(Convert.ToDouble(dt.Rows[ix][nc_Col.Rows[idx]["HEAD"].ToString()].ToString()) + Convert.ToDouble(dt.Rows[ix]["EXTRA PAY"]));
                                }
                                catch { }
                            }

                            dt.Rows[ix]["GROSS PAY"] = (Convert.ToDouble(dt.Rows[ix]["EXTRA PAY"]) + Convert.ToDouble(dt.Rows[ix]["NetPay"])).ToString();
                        }
                    }
                }

            }


            if (prev_type == 1)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    string y = result[i].ItemArray[1].ToString();
                    //y = dt.Columns[Convert.ToInt32(result[i].ItemArray[0])].ColumnName.ToString();
                    dt.Columns.Remove(y);
                }
            }

            


           dt.Columns.Add("Signature", typeof(string));

            dt.AcceptChanges();
            Odet = "";
            Oamt = "";
            Agent = "";
            try
            {
                if (SalExp == 1)
                {
                    dt.Columns["UAN No."].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["Member ID"].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["ESIC No."].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["Email ID"].SetOrdinal(dt.Columns.Count - 1);

                    dt.Columns["Bank - Branch"].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["BankA/C No"].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["IFSC"].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["Signature"].SetOrdinal(dt.Columns.Count - 1);
                }
            }
            catch { }
            DataTable salary_Odetails = clsDataAccess.RunQDTbl("SELECT [Slno],[OCId],[OCName],[Amount]," +
     "[Company_id],[ODName],[AcNo],[Bank],[Branch],[IFSC] FROM [tbl_Employee_Sal_OCharges] where Session='" +
     cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' order by Slno");
            if (salary_Odetails.Rows.Count > 0)
            {
                for (int Odet_ind = 0; Odet_ind < salary_Odetails.Rows.Count; Odet_ind++)
                {
                 if (Odet=="" && Oamt=="")
                  {
                   Odet = salary_Odetails.Rows[Odet_ind]["OCName"].ToString();
                   Oamt = salary_Odetails.Rows[Odet_ind]["Amount"].ToString();
                   Agent = "Name : " + salary_Odetails.Rows[0]["ODName"].ToString() + " " + "Bank : " + salary_Odetails.Rows[0]["Bank"].ToString() + "(" + salary_Odetails.Rows[0]["Branch"].ToString() + ") " + "A/C No. : " + salary_Odetails.Rows[0]["AcNo"].ToString() + " " + "IFSC : " + salary_Odetails.Rows[0]["IFSC"].ToString();
                  }
                 else
                 {
                  Odet = Odet + "\n\r" + salary_Odetails.Rows[Odet_ind]["OCName"].ToString();
                  Oamt = Oamt + "\n\r" + salary_Odetails.Rows[Odet_ind]["Amount"].ToString();
                  Agent = Agent + "\n\r" + "Name : " + salary_Odetails.Rows[0]["ODName"].ToString() + " " + "Bank : " + salary_Odetails.Rows[0]["Bank"].ToString() + "(" + salary_Odetails.Rows[0]["Branch"].ToString() + ") " + "A/C No. : " + salary_Odetails.Rows[0]["AcNo"].ToString() + " " + "IFSC : " + salary_Odetails.Rows[0]["IFSC"].ToString();
                 }
                }
            }

      //      DataTable salary_Odet = clsDataAccess.RunQDTbl("SELECT [ODName],[AcNo],[Bank] FROM [tbl_Employee_Sal_ODet] where Session='" +
      //cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' order by Slno");
      //      if (salary_Odetails.Rows.Count > 0)
      //      {
      //        Agent = "Name : " + salary_Odet.Rows[0]["ODName"].ToString() + "\n\r" + "Bank : " + salary_Odet.Rows[0]["Bank"].ToString() + "\n\r" + "A/C No. : " + salary_Odet.Rows[0]["AcNo"].ToString();
      //      }
            //if (cheDescription.Checked == true)           
            //    dt.Columns.Add("Description", typeof(string));        
            //if (cheAlias.Checked == true)           
            //    dt.Columns.Add("Alias", typeof(string));          
            //if (raddetails.Checked == true)            
            //    dt.Columns.Add("Date", typeof(string));                
            //    dt.Columns.Add("VoucherNo", typeof(string));         
            //dt.Columns.Add("Unit", typeof(string));            
            //dt.Columns.Add("OpeningQty", typeof(string));            
            //for (int i = 0; i <= lblTransaction.Items.Count - 1; i++)
            //{
            //    string Pur = lblTransaction.Items[i].ToString();
            //    dt.Columns.Add("" + Pur + "", typeof(string));                
            //}
            //dt.Columns.Add("TotalIncoming   Qty", typeof(string));           
            //dt.Columns.Add("TotalOutgoing   Qty", typeof(string));           
            //dt.Columns.Add("ClosingQty");           
        }

        public void LoadDatatableMultiLoc()
        {
            DataTable dtLocations = clsDataAccess.RunQDTbl("select [Location_ID] from [Companywiseid_Relation] where [Company_ID] = "+compid+" and Location_ID <> 0");
            Locations = "";
            for (int i = 0; i < dtLocations.Rows.Count; i++)
            {
                if(i==0)
                    Locations = Locations + "('" + dtLocations.Rows[i][0] + "'";
                else
                    Locations = Locations + ",'" + dtLocations.Rows[i][0] + "'";
            }
            Locations = Locations + ")";

            DataTable dt7 = clsDataAccess.RunQDTbl("select  e.RefBankAcountNo,e.RefDesignationName,e.RefBasic,e.RefDaysPresent,e.RefOT,e.RefTotalDays from tbl_Sal_Heads_Print e where e.Location_ID in" + Locations + "  ");

            DataTable data;
            data = new DataTable("columnname");
            DataColumn column_name = new DataColumn("Column_Name");
            DataColumn Ref_Column_slno = new DataColumn("Ref_Column_slno");
            data.Columns.Add(column_name);
            data.Columns.Add(Ref_Column_slno);
            if (dt7.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dt7.Columns.Count; i++)
                {
                    DataRow dataRow = data.NewRow();
                    dataRow["Column_Name"] = dt7.Columns[i].ColumnName;
                    dataRow["Ref_Column_slno"] = dt7.Rows[0][i].ToString();
                    data.Rows.Add(dataRow);
                }

            }

            data.AcceptChanges();
            DataTable dt8 = clsDataAccess.RunQDTbl("select e.BankAcountNo as BankAcountNo,e.DesignationName as Rank,e.Basic as Salary,e.DaysPresent as WDay,e.OT as OT,e.TotalDays as TotalDays  from tbl_Sal_Heads_Print e where e.Location_ID in " + Locations + "  ");

            //e.BankAcountNo as BankAcountNo,e.DesignationName as Rank,e.Basic as Salary,e.DaysPresent as W_Day,e.OT as O_T,e.TotalDays as Tot_Day
            DataTable data1;
            data1 = new DataTable("columnname1");

            DataColumn ColumnName = new DataColumn("ColumnName");
            DataColumn Check = new DataColumn("Check");

            data1.Columns.Add(ColumnName);
            data1.Columns.Add(Check);

            if (dt8.Rows.Count > 0)
            {
                for (Int32 i1 = 0; i1 < dt8.Columns.Count; i1++)
                {
                    DataRow dataRow = data1.NewRow();
                    dataRow["ColumnName"] = dt8.Columns[i1].ColumnName;
                    dataRow["Check"] = dt8.Rows[0][i1];
                    data1.Rows.Add(dataRow);
                }
            }

            data1.AcceptChanges();

            data.Columns.Add("ColumnName");
            data.Columns.Add("Check");

            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["ColumnName"] = data1.Rows[i]["ColumnName"];
                data.Rows[i]["Check"] = data1.Rows[i]["Check"];
            }

            data.Columns.Remove(data.Columns[0]);
            data.AcceptChanges();
            Head_Cou = 0;
            DataRow[] result = data.Select("Check = 'false'");
            DataRow[] result1 = data.Select("Check = 'True'");
            Head_Cou = result1.Length;
            if (rdb_Co_LocConsolidate.Checked == true)
            {
                getLoc_data();
            }
            else
            {
                Retrive_Data_MultiLocation();

                //for (int i = 0; i < result.Length; i++)
                //{
                //    string y = result[i].ItemArray[1].ToString();
                //    //y = dt.Columns[Convert.ToInt32(result[i].ItemArray[0])].ColumnName.ToString();
                //    dt.Columns.Remove(y);
                //}

                dt.Columns.Add("Signature", typeof(string));

                dt.AcceptChanges();
                Odet = "";
                Oamt = "";
                Agent = "";
                DataTable salary_Odetails = clsDataAccess.RunQDTbl("SELECT [Slno],[OCId],[OCName],[Amount]," +
         "[Company_id],[ODName],[AcNo],[Bank],[Branch],[IFSC] FROM [tbl_Employee_Sal_OCharges] where Session='" +
         cmbYear.Text + "' and Month ='" + month + "' and Location_id in " + Locations + " order by Slno");
                if (salary_Odetails.Rows.Count > 0)
                {
                    for (int Odet_ind = 0; Odet_ind < salary_Odetails.Rows.Count; Odet_ind++)
                    {
                        if (Odet == "" && Oamt == "")
                        {
                            Odet = salary_Odetails.Rows[Odet_ind]["OCName"].ToString();
                            Oamt = salary_Odetails.Rows[Odet_ind]["Amount"].ToString();
                            Agent = "Name : " + salary_Odetails.Rows[0]["ODName"].ToString() + " " + "Bank : " + salary_Odetails.Rows[0]["Bank"].ToString() + "(" + salary_Odetails.Rows[0]["Branch"].ToString() + ") " + "A/C No. : " + salary_Odetails.Rows[0]["AcNo"].ToString() + " " + "IFSC : " + salary_Odetails.Rows[0]["IFSC"].ToString();
                        }
                        else
                        {
                            Odet = Odet + "\n\r" + salary_Odetails.Rows[Odet_ind]["OCName"].ToString();
                            Oamt = Oamt + "\n\r" + salary_Odetails.Rows[Odet_ind]["Amount"].ToString();
                            Agent = Agent + "\n\r" + "Name : " + salary_Odetails.Rows[0]["ODName"].ToString() + " " + "Bank : " + salary_Odetails.Rows[0]["Bank"].ToString() + "(" + salary_Odetails.Rows[0]["Branch"].ToString() + ") " + "A/C No. : " + salary_Odetails.Rows[0]["AcNo"].ToString() + " " + "IFSC : " + salary_Odetails.Rows[0]["IFSC"].ToString();
                        }
                    }
                }
            }
        }

        public void StockTransaction()
        {
            //try
            //{
            //    dt.Rows.Clear();
            //    DataTable temp_dt = new DataTable();
            //    for (int a = 0; a <= dt.Columns.Count - 1; a++)
            //    {
            //        temp_dt.Columns.Add("" + a + "", typeof(string));
            //    }
            //    int cou_colum = temp_dt.Columns.Count - 1;
            //    int cou = 0;
            //    for (int i = 0; i <= getcode.Count - 1; i++) //Retrive Item Name & Details
            //    {
            //        temp_dt.Rows.Add();
            //        double temp_qty = 0, bal = 0;
            //        edpcon.Open();
            //        EDPCommon.ClearDataTable_EDP(ds.Tables["Product"]);
            //        cmd = new SqlCommand("select ig.PDESC,ig.PALIAS,ig.OP_QTY,ig.EXP_Date,u.UDESC,ig.PCODE from iglmst ig,Unit u where  ig.ficode=" + edpcom.CurrentFicode + " and ig.gcode=" + edpcom.PCURRENT_GCODE + " and ig.pcode=" + getcode[i] + " and ig.ficode=u.ficode and ig.gcode=u.gcode and ig.ucode=u.ucode", edpcon.mycon);
            //        adp.SelectCommand = cmd;
            //        adp.Fill(ds, "Product");
            //        cou = dt.Rows.Count;
            //        //Item Details Insert Datatable
            //        dt.Rows.Add();
            //        if (cheDescription.Checked == true)
            //            dt.Rows[cou]["Description"] = ds.Tables["Product"].Rows[0]["PDESC"];
            //        if (cheAlias.Checked == true)
            //            dt.Rows[cou]["Alias"] = ds.Tables["Product"].Rows[0]["PALIAS"];
            //        if (radconsoli.Checked == false)
            //        {
            //            dt.Rows[cou]["Date"] = Convert.ToDateTime(ds.Tables["Product"].Rows[0]["EXP_Date"]).ToShortDateString();
            //            dt.Rows[cou]["VoucherNo"] = "Op Bal";
            //        }                 
            //        dt.Rows[cou]["Unit"] = ds.Tables["Product"].Rows[0]["UDESC"];
            //        dt.Rows[cou]["OpeningQty"] = ds.Tables["Product"].Rows[0]["OP_QTY"];
            //        int col_cou = 0;
            //        if (radconsoli.Checked == true)
            //            col_cou = 1 + 1;
            //        else
            //            col_cou = 3 + 1;

            //        if (cheDescription.Checked == true)
            //            col_cou = col_cou + 1;
            //        if (cheAlias.Checked == true)
            //            col_cou = col_cou + 1;
            //        if (Information.IsNumeric(ds.Tables["Product"].Rows[0]["OP_QTY"]) == true)
            //        {
            //            temp_dt.Rows[0][col_cou - 1] = Convert.ToDouble(ds.Tables["Product"].Rows[0]["OP_QTY"]);
            //            bal = Convert.ToDouble(ds.Tables["Product"].Rows[0]["OP_QTY"]);
            //        }


            //        for (int j = 0; j <= Program.Tentry.Count - 1; j++)
            //        {
            //            //string st_tentry = "'" + Program.Tentry[j].ToString().Trim() + "'";
            //            EDPCommon.ClearDataTable_EDP(ds.Tables["Pro_Details"]);  //Retrive Total Transaction
            //            if (radconsoli.Checked == true) // CosoliDated Query
            //                cmd = new SqlCommand("select sum(it.baseqty) as qty ,it.t_entry from itran it,idata id where it.ficode=" + edpcom.CurrentFicode + " and it.gcode=" + edpcom.PCURRENT_GCODE + " and it.pcode=" + getcode[i] + " and it.ficode=id.ficode and it.gcode=id.gcode and it.voucher=id.voucher and it.t_entry=id.t_entry and it.t_entry='" + Program.Tentry[j] + "' group by it.t_entry", edpcon.mycon);
            //            else
            //                cmd = new SqlCommand("select id.user_vch,id.vch_date,it.qty,it.voucher,it.t_entry from itran it,idata id where it.ficode=" + edpcom.CurrentFicode + " and it.gcode=" + edpcom.PCURRENT_GCODE + " and it.pcode=" + getcode[i] + " and it.ficode=id.ficode and it.gcode=id.gcode and it.voucher=id.voucher and it.t_entry=id.t_entry and it.t_entry='" + Program.Tentry[j] + "'", edpcon.mycon);
            //            adp.SelectCommand = cmd;
            //            adp.Fill(ds, "Pro_Details");
            //            //Transaction Details Insert Datatable
            //            for (int k = 0; k <= ds.Tables["Pro_Details"].Rows.Count - 1; k++)
            //            {
            //                if (radconsoli.Checked == true)
            //                {
            //                    cou = dt.Rows.Count - 1;
            //                    dt.Rows[cou][col_cou] = Convert.ToDouble(ds.Tables["Pro_Details"].Rows[k]["qty"]).ToString(EDPCommon.SetDecimalPlace(0));
            //                    temp_qty = temp_qty + Convert.ToDouble(ds.Tables["Pro_Details"].Rows[k]["qty"]);
            //                }
            //                else
            //                {
            //                    cou = dt.Rows.Count;
            //                    dt.Rows.Add();
            //                    dt.Rows[cou]["Date"] = Convert.ToDateTime(ds.Tables["Pro_Details"].Rows[k]["vch_date"]).ToShortDateString();
            //                    dt.Rows[cou]["VoucherNo"] = ds.Tables["Pro_Details"].Rows[k]["user_vch"];
            //                    dt.Rows[cou]["Unit"] = ds.Tables["Product"].Rows[0]["UDESC"];

            //                    dt.Rows[cou][col_cou] = ds.Tables["Pro_Details"].Rows[k]["qty"];
            //                    temp_qty = temp_qty + Convert.ToDouble(ds.Tables["Pro_Details"].Rows[k]["qty"]);
            //                }
            //                //Transaction Details Insert into Datable
            //                if (k == ds.Tables["Pro_Details"].Rows.Count - 1)
            //                {
            //                    if ((ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "a") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "SI") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "SC") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "FG") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "MR") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "NM"))
            //                        if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 2]) == true)
            //                            temp_dt.Rows[0][cou_colum - 2] = Convert.ToDouble(temp_dt.Rows[0][cou_colum - 2]) + temp_qty;
            //                        else
            //                            temp_dt.Rows[0][cou_colum - 2] = temp_qty;

            //                    else if ((ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "n") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "SO") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "PC") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "MI") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "NM") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "GR"))
            //                        if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 1]) == true)
            //                            temp_dt.Rows[0][cou_colum - 1] = Convert.ToDouble(temp_dt.Rows[0][cou_colum - 1]) + temp_qty;
            //                        else
            //                            temp_dt.Rows[0][cou_colum - 1] = temp_qty;
            //                }

            //            }
            //            temp_dt.Rows[0][col_cou] = temp_qty;
            //            temp_qty = 0;
            //            col_cou = col_cou + 1;
            //        }

            //        if (raddetails.Checked == true)
            //        {
            //            cou = dt.Rows.Count;
            //            dt.Rows.Add();
            //            dt.Rows[cou]["Unit"] = "Total";
            //        }
            //        //Calculate Total Transaction Details & insert into DataTable 
            //        for (int l = 0; l < temp_dt.Columns.Count - 1; l++)
            //        {
            //            if (Information.IsNumeric(temp_dt.Rows[0][l]) == true)
            //                dt.Rows[cou][l] = temp_dt.Rows[0][l];
            //        }

            //        if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 2]) == true)
            //        {
            //            bal = bal + Convert.ToDouble(temp_dt.Rows[0][cou_colum - 2]);
            //            if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 1]) == true)
            //                bal = bal - Convert.ToDouble(temp_dt.Rows[0][cou_colum - 1]);
            //        }
            //        else
            //        {
            //            if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 1]) == true)
            //                bal = bal - Convert.ToDouble(temp_dt.Rows[0][cou_colum - 1]);
            //        }
            //        dt.Rows[cou]["ClosingQty"] = Convert.ToDouble(bal).ToString(EDPCommon.SetDecimalPlace(2));
            //        bal = 0;
            //        temp_dt.Rows.Clear();                   
            //    }               
            //}
            //catch { }
        }

        public void GroupWiseStock()//GroupWise Stock Statement
        {
            //try
            //{
            //    dt.Rows.Clear();
            //    Boolean flug_Subgroup = false;
            //    Boolean Flag_group = false;
            //    DataTable temp_dt = new DataTable();
            //    for (int a = 0; a <= dt.Columns.Count - 1; a++)
            //    {
            //        temp_dt.Columns.Add("" + a + "", typeof(string));
            //    }
            //    int cou_colum = temp_dt.Columns.Count - 1;
            //    int cou = 0;
            //    for (int ij = 0; ij <= getcode.Count - 1; ij++)
            //    {
            //        Flag_group = true;
            //        edpcon.Open();
            //        EDPCommon.ClearDataTable_EDP(ds.Tables["SGroup"]);
            //        cmd = new SqlCommand("select CC_DESC,CC_CODE from CCMAST where  ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and PLV_CODE=" + getcode[ij] + "", edpcon.mycon);
            //        adp.SelectCommand = cmd;
            //        adp.Fill(ds, "SGroup");
            //        for (int ii = 0; ii <= ds.Tables["SGroup"].Rows.Count - 1; ii++) // Retrive Subgroup
            //        {
            //            EDPCommon.ClearDataTable_EDP(ds.Tables["ItemGroup"]);
            //            cmd = new SqlCommand("select PCODE,PDESC from IGROUP where  ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and SGROUP=" + ds.Tables["SGroup"].Rows[ii]["CC_CODE"] + "", edpcon.mycon);
            //            adp.SelectCommand = cmd;
            //            adp.Fill(ds, "ItemGroup");
            //            if (ds.Tables["ItemGroup"].Rows.Count == 0)
            //            {
            //                cmd = new SqlCommand("select PCODE,PDESC from IGROUP where  ficode=" + edpcom.CurrentFicode + " and gcode=" + edpcom.PCURRENT_GCODE + " and SGROUP=" + getcode[ij] + "", edpcon.mycon);
            //                adp.SelectCommand = cmd;
            //                adp.Fill(ds, "ItemGroup");
            //                flug_Subgroup = true;
            //            }
            //            for (int i = 0; i <= ds.Tables["ItemGroup"].Rows.Count - 1; i++) // Retrive Item
            //            {
            //                if (Flag_group == true)
            //                {
            //                    Flag_group = false;
            //                    cou = dt.Rows.Count;
            //                    dt.Rows.Add();
            //                    if (cheDescription.Checked == true)
            //                        dt.Rows[cou]["Description"] = arr[ij];
            //                    else
            //                        dt.Rows[cou]["Alias"] = arr[ij];
            //                }
            //                if (flug_Subgroup == false && i == 0)
            //                {
            //                    cou = dt.Rows.Count;
            //                    dt.Rows.Add();
            //                    if (cheDescription.Checked == true)
            //                        dt.Rows[cou]["Description"] = ds.Tables["SGroup"].Rows[ii]["CC_DESC"];
            //                    else
            //                        dt.Rows[cou]["Alias"] = ds.Tables["SGroup"].Rows[ii]["CC_DESC"];
            //                }

            //                flug_Subgroup = false;
            //                temp_dt.Rows.Add();
            //                double temp_qty = 0, bal = 0;
            //                EDPCommon.ClearDataTable_EDP(ds.Tables["Product"]);  //Retrive Item Name & Details
            //                cmd = new SqlCommand("select ig.PDESC,ig.PALIAS,ig.OP_QTY,ig.EXP_Date,u.UDESC,ig.PCODE from iglmst ig,Unit u where  ig.ficode=" + edpcom.CurrentFicode + " and ig.gcode=" + edpcom.PCURRENT_GCODE + " and ig.pcode=" + ds.Tables["ItemGroup"].Rows[i]["PCODE"] + " and ig.ficode=u.ficode and ig.gcode=u.gcode and ig.ucode=u.ucode", edpcon.mycon);
            //                adp.SelectCommand = cmd;
            //                adp.Fill(ds, "Product");
            //                cou = dt.Rows.Count;
            //                edpcon.Open();
            //                //Item Details Insert Datatable
            //                dt.Rows.Add();
            //                if (cheDescription.Checked == true)
            //                    dt.Rows[cou]["Description"] = ds.Tables["Product"].Rows[0]["PDESC"];
            //                if (cheAlias.Checked == true)
            //                    dt.Rows[cou]["Alias"] = ds.Tables["Product"].Rows[0]["PALIAS"];

            //                if (radconsoli.Checked == false)
            //                {
            //                    dt.Rows[cou]["Date"] = Convert.ToDateTime(ds.Tables["Product"].Rows[0]["EXP_Date"]).ToShortDateString();
            //                    dt.Rows[cou]["VoucherNo"] = "Op Bal";
            //                }
            //                dt.Rows[cou]["Unit"] = ds.Tables["Product"].Rows[0]["UDESC"];
            //                dt.Rows[cou]["OpeningQty"] = ds.Tables["Product"].Rows[0]["OP_QTY"];
            //                int col_cou = 0;
            //                if (radconsoli.Checked == true)
            //                    col_cou = 1 + 1;
            //                else
            //                    col_cou = 3 + 1;
            //                //dt.Rows[cou]["Date"] = Convert.ToDateTime(ds.Tables["Product"].Rows[0]["EXP_Date"]).ToShortDateString();
            //                //dt.Rows[cou]["VoucherNo"] = "Op Bal";
            //                //dt.Rows[cou]["Unit"] = ds.Tables["Product"].Rows[0]["UDESC"];
            //                //dt.Rows[cou]["OpeningQty"] = ds.Tables["Product"].Rows[0]["OP_QTY"];
            //                //int col_cou = 3 + 1;
            //                if (cheDescription.Checked == true)
            //                    col_cou = col_cou + 1;
            //                if (cheAlias.Checked == true)
            //                    col_cou = col_cou + 1;
            //                if (Information.IsNumeric(ds.Tables["Product"].Rows[0]["OP_QTY"]) == true)
            //                {
            //                    temp_dt.Rows[0][col_cou - 1] = Convert.ToDouble(ds.Tables["Product"].Rows[0]["OP_QTY"]);
            //                    bal = Convert.ToDouble(ds.Tables["Product"].Rows[0]["OP_QTY"]);
            //                }

            //                for (int j = 0; j <= Program.Tentry.Count - 1; j++)
            //                {
            //                    EDPCommon.ClearDataTable_EDP(ds.Tables["Pro_Details"]); 
            //                    //string st_tentry = "'" + Program.Tentry[j].ToString().Trim() + "'";
            //                    if (radconsoli.Checked == true) // CosoliDated Query
            //                        cmd = new SqlCommand("select sum(it.baseqty) as qty ,it.t_entry from itran it,idata id where it.ficode=" + edpcom.CurrentFicode + " and it.gcode=" + edpcom.PCURRENT_GCODE + " and it.pcode=" + ds.Tables["ItemGroup"].Rows[i]["PCODE"] + " and it.ficode=id.ficode and it.gcode=id.gcode and it.voucher=id.voucher and it.t_entry=id.t_entry and it.t_entry='" + Program.Tentry[j] + "' group by it.t_entry", edpcon.mycon);
            //                    else
            //                       //Retrive Total Transaction
            //                    cmd = new SqlCommand("select id.user_vch,id.vch_date,it.qty,it.voucher,it.t_entry from itran it,idata id where it.ficode=" + edpcom.CurrentFicode + " and it.gcode=" + edpcom.PCURRENT_GCODE + " and it.pcode=" + ds.Tables["ItemGroup"].Rows[i]["PCODE"] + " and id.Vch_Date BETWEEN '" + edpcom.getSqlDateStr(dtpForm.Value) + "' AND '" + edpcom.getSqlDateStr(Convert.ToDateTime(dtpto.Value)) + "' and it.ficode=id.ficode and it.gcode=id.gcode and it.voucher=id.voucher and it.t_entry=id.t_entry and it.t_entry='" + Program.Tentry[j] + "'", edpcon.mycon);
            //                    adp.SelectCommand = cmd;
            //                    adp.Fill(ds, "Pro_Details");

            //                    for (int k = 0; k <= ds.Tables["Pro_Details"].Rows.Count - 1; k++)
            //                    {
            //                        //Transaction Details Insert into Datable
            //                        if (radconsoli.Checked == true)
            //                        {
            //                            cou = dt.Rows.Count - 1;
            //                            dt.Rows[cou]["Unit"] = ds.Tables["Product"].Rows[k]["UDESC"];
            //                            dt.Rows[cou][col_cou] = Convert.ToDouble(ds.Tables["Pro_Details"].Rows[k]["qty"]).ToString(EDPCommon.SetDecimalPlace(0));
            //                            temp_qty = temp_qty + Convert.ToDouble(ds.Tables["Pro_Details"].Rows[k]["qty"]);
            //                        }
            //                        else
            //                        {
            //                            cou = dt.Rows.Count;
            //                            dt.Rows.Add();
            //                            dt.Rows[cou]["Date"] = Convert.ToDateTime(ds.Tables["Pro_Details"].Rows[k]["vch_date"]).ToShortDateString();
            //                            dt.Rows[cou]["VoucherNo"] = ds.Tables["Pro_Details"].Rows[k]["user_vch"];
            //                            dt.Rows[cou]["Unit"] = ds.Tables["Product"].Rows[0]["UDESC"];

            //                            dt.Rows[cou][col_cou] = ds.Tables["Pro_Details"].Rows[k]["qty"];
            //                            temp_qty = temp_qty + Convert.ToDouble(ds.Tables["Pro_Details"].Rows[k]["qty"]);
            //                        }
            //                        if (k == ds.Tables["Pro_Details"].Rows.Count - 1)
            //                        {
            //                            if ((ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "a") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "SI") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "SRC") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "FG") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "MIR") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "NMR"))
            //                                if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 2]) == true)
            //                                    temp_dt.Rows[0][cou_colum - 2] = Convert.ToDouble(temp_dt.Rows[0][cou_colum - 2]) + temp_qty;
            //                                else
            //                                    temp_dt.Rows[0][cou_colum - 2] = temp_qty;

            //                            else if ((ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "n") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "SO") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "PRC") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "MI") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "NMI") || (ds.Tables["Pro_Details"].Rows[0]["t_entry"].ToString().Trim() == "FGR"))
            //                                if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 1]) == true)
            //                                    temp_dt.Rows[0][cou_colum - 1] = Convert.ToDouble(temp_dt.Rows[0][cou_colum - 1]) + temp_qty;
            //                                else
            //                                    temp_dt.Rows[0][cou_colum - 1] = temp_qty;

            //                        }
            //                    }
            //                    temp_dt.Rows[0][col_cou] = temp_qty;
            //                    temp_qty = 0;
            //                    col_cou = col_cou + 1;
            //                }
            //                //Calculate Total Transaction Details & insert into DataTable 
            //                if (raddetails.Checked == true)
            //                {
            //                    cou = dt.Rows.Count;
            //                    dt.Rows.Add();
            //                    dt.Rows[cou]["Unit"] = "Total";
            //                }
            //                for (int l = 0; l < temp_dt.Columns.Count - 1; l++)
            //                {
            //                    if (Information.IsNumeric(temp_dt.Rows[0][l]) == true)
            //                        dt.Rows[cou][l] = temp_dt.Rows[0][l];
            //                }

            //                if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 2]) == true)
            //                {
            //                    bal = bal + Convert.ToDouble(temp_dt.Rows[0][cou_colum - 2]);
            //                    if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 1]) == true)
            //                        bal = bal - Convert.ToDouble(temp_dt.Rows[0][cou_colum - 1]);
            //                }
            //                else
            //                {
            //                    if (Information.IsNumeric(temp_dt.Rows[0][cou_colum - 1]) == true)
            //                        bal = bal - Convert.ToDouble(temp_dt.Rows[0][cou_colum - 1]);
            //                }
            //                dt.Rows[cou]["ClosingQty"] = Convert.ToDouble(bal).ToString(EDPCommon.SetDecimalPlace(2));
            //                bal = 0;
            //                temp_dt.Rows.Clear();
            //            }
            //        }
            //    }
            //}
            //catch { }
        }


        public void nc()
        {

            lbl_NC.Text = clsDataAccess.ReturnValue("select COUNT(*) from tbl_Employee_Assign_SalStructure where (Location_id="+Locations+") and NCompliance=1");

            lbl_OT.Text = clsDataAccess.ReturnValue("select count(SAL_HEAD) from tbl_Employee_Assign_SalStructure eas where (Location_id=" + Locations + ") and NCompliance=1 and Proxy_day=1");  // OTA

            lbl_ED.Text = clsDataAccess.ReturnValue("select count(SAL_HEAD) from tbl_Employee_Assign_SalStructure eas where (Location_id=" + Locations + ") and NCompliance=1 and Proxy_day=2");  // ED
        

        }

        int CAR_L = 0;
        private void btnPreview_Click(object sender, EventArgs e)
        {
            os_adv = 0; os_kit = 0; os_loan = 0; SalExp = 0;

            try
            {
                Woff = Convert.ToInt32(clsDataAccess.GetresultS("select loc_initial from Companywiseid_Relation where (Location_ID='" + Locations + "')"));// location wise wo
            }
            catch { Woff = 0; }

            prev_type = 1;
            view_alk();

            nc();

        if (chk_os_adv.Checked == true)
        {
            os_adv = 1;
        } 
            if (chk_os_Kit.Checked == true)
        {
            os_kit = 1;
        }
        if (chk_os_Loan.Checked == true)
        {
            os_loan = 1;
        }

            if (cmbSalarySheetType.SelectedIndex == 1)
            {
                LoadDatatableMultiLoc();
            }
            else if (cmbSalarySheetType.SelectedIndex == 0)
            {
                LoadDataTable();
            }
            if (rdbA4.Checked == true)
            {
                CAR_L = 1;
            }
            else if (rdbLegal.Checked == true)
            {
                CAR_L = 2;
            }
       
            string str="";

            if (cmbSalarySheetType.SelectedIndex==1){
                str="select (SELECT SalaryHead_Short FROM tbl_Employee_DeductionSalayHead where SlNo=eas.SAL_HEAD)Short_name,sal_head,chkALK from tbl_Employee_Assign_SalStructure as eas where (Location_id in "+ Locations +") and (chkALK in (1,2,3)) and (p_type='D')";

            }else{
                str="select (SELECT SalaryHead_Short FROM tbl_Employee_DeductionSalayHead where SlNo=eas.SAL_HEAD)Short_name,sal_head,chkALK from tbl_Employee_Assign_SalStructure as eas where (Location_id='"+ Locations +"') and (chkALK in (1,2,3)) and (p_type='D')";
            }
            
            DataTable os_head =clsDataAccess.RunQDTbl(str);
            string cell_val = "";
            DataRow[] filteredRows =
  os_head.Select(string.Format("{0} = '{1}'", "chkALK", 1));

            if (os_adv > 0 && filteredRows.Length>0)
            {
                for (int ind = 0; ind < dt.Rows.Count-3; ind++)
                {
                    cell_val = "";
                    if (dt.Rows[ind]["ID"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[ind][filteredRows[0][0].ToString().Trim()].ToString().Trim())>0)
                    {
                        cell_val = clsDataAccess.GetresultS("SELECT ISNULL(SUM(EAAMT) - SUM(EADEDUCT), 0) AS balance FROM tbl_Employee_Advance WHERE (EAEID = '" + dt.Rows[ind]["ID"].ToString().Trim() + "')");
                        if (cell_val.Trim() != "0")
                        {
                            dt.Rows[ind][filteredRows[0][0].ToString().Trim()] = dt.Rows[ind][filteredRows[0][0].ToString().Trim()].ToString() + Environment.NewLine + "[O/S : " + cell_val.Trim()+ " ]";
                        }

                    }

                }
            }


           filteredRows =
 os_head.Select(string.Format("{0} = '{1}'", "chkALK", 2));

            if (os_adv > 0 && filteredRows.Length > 0)
            {
                for (int ind = 0; ind < dt.Rows.Count - 3; ind++)
                {
                    cell_val = "";
                    if (dt.Rows[ind]["ID"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[ind][filteredRows[0][0].ToString().Trim()].ToString().Trim()) > 0)
                    {
                        cell_val = clsDataAccess.GetresultS("SELECT ISNULL(SUM(ELAMT) - SUM(ELDEDUCT), 0) AS blance FROM tbl_Employee_LOAN WHERE (ELEID = '" + dt.Rows[ind]["ID"].ToString().Trim() + "')");
                        if (cell_val.Trim() != "0")
                        {
                            dt.Rows[ind][filteredRows[0][0].ToString().Trim()] = dt.Rows[ind][filteredRows[0][0].ToString().Trim()].ToString() + Environment.NewLine + "[O/S : " + cell_val.Trim() + " ]";
                        }

                    }

                }
            }


            filteredRows =
os_head.Select(string.Format("{0} = '{1}'", "chkALK",3));

            if (os_adv > 0 && filteredRows.Length > 0)
            {
                for (int ind = 0; ind < dt.Rows.Count - 3; ind++)
                {
                    cell_val = "";
                    if (dt.Rows[ind]["ID"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[ind][filteredRows[0][0].ToString().Trim()].ToString().Trim()) > 0)
                    {
                        cell_val = clsDataAccess.GetresultS("SELECT isNull(sum(EKAMT)-sum(EKDEDUCT),0) as blnce FROM tbl_Employee_KIT where (EKEID= '" + dt.Rows[ind]["ID"].ToString().Trim() + "')");
                        if (cell_val.Trim() != "0")
                        {
                            dt.Rows[ind][filteredRows[0][0].ToString().Trim()] = dt.Rows[ind][filteredRows[0][0].ToString().Trim()].ToString() + Environment.NewLine + "[O/S : " + cell_val.Trim() + " ]";
                        }

                    }

                }
            }


            if (dt.Columns.Count < 21)
            {
                if (CAR_L == 1)
                {
                    PrintDetails_L(1);
                }
                else
                {
                    PrintDetails(1);
                }
            }
            else
            {
                //ERPMessageBox.ERPMessage.Show("No Of Columns Not More then 20");
                ERPMessage.Show("No Of Columns Not More then 20! Do you want to merge ?", "Confirm", ERPMessage.MessageBoxButton.EDP_YES_NO, ERPMessage.MessageBoxIcon.EDP_QUESTION);
                        //if (dr == DialogResult.Yes)
                        //{
                if (ERPMessage.ButtonResult == "edpYES")
                   {
                       DataTable dtCloned = dt.Clone();
                       dtCloned.Columns["TotalDays"].DataType = typeof(String);
                       foreach (DataRow row in dt.Rows)
                       {
                           dtCloned.ImportRow(row);
                       }
                       for (int indx = 0; indx < dt.Rows.Count-3; indx++)
                       {
                           dt.Rows[indx]["EmployName"] = dt.Rows[indx]["ID"].ToString().Trim() + Environment.NewLine + dt.Rows[indx]["EmployName"].ToString().Trim() + Environment.NewLine + dt.Rows[indx]["Rank"].ToString() + Environment.NewLine + dt.Rows[indx]["BankAcountNo"].ToString() + Environment.NewLine + "Salary : "+ dt.Rows[indx]["Salary"].ToString();
                           //DataColumn myDC = new DataColumn(dt.Columns["TotalDays"].ColumnName, System.Type.GetType("System.String"));
                          DataColumn myDC = new
DataColumn(dt.Columns["TotalDays"].ColumnName, System.Type.GetType("System.String"));



                          if (dt.Rows[indx]["EmployName"].ToString().Trim().ToLower() != "total")
                          {
                              //if (Woff == 1)
                              //{
                              //    dt.Rows[indx]["TotalDays"] = dt.Rows[indx]["TotalDays"].ToString().Trim() + Environment.NewLine + "WD : " + dt.Rows[indx]["WDay"].ToString().Trim() + Environment.NewLine + "OT : " + dt.Rows[indx]["OT"].ToString() + Environment.NewLine + "Woff : " + dt.Rows[indx]["Woff"].ToString();
                              //}
                              //else
                              {
                                  dt.Rows[indx]["TotalDays"] = dt.Rows[indx]["TotalDays"].ToString().Trim() + Environment.NewLine + "WD : " + dt.Rows[indx]["WDay"].ToString().Trim() + Environment.NewLine + "OT : " + dt.Rows[indx]["OT"].ToString();
                              }
                          }

                       }
                       dt.Columns.Remove("ID");
                       dt.Columns.Remove("Rank");
                       dt.Columns.Remove("BankAcountNo");
                       dt.Columns.Remove("Salary");
                       dt.Columns.Remove("WDay");
                       dt.Columns.Remove("OT");

                       dt.Columns["EmployName"].ColumnName = "Employee";
                       //dt.Columns["EmployName"].ColumnName = "Employee";
                       if (CAR_L == 1)
                       {
                           PrintDetails_L(1);
                       }
                       else
                       {
                           PrintDetails(1);
                       }
                   }
                   else
                   {
                       dataGridView1.DataSource = dt;
                       return;
                   }
            }

            dt.Dispose();
            dt.Clear();
            groupBox3.Enabled = true;
           
        }

        private void radGroupwise_CheckedChanged(object sender, EventArgs e)
        {
            //if (radGroupwise.Checked == true)
            //    btnItem.Text = "Select Item Group";
            //else
            //    btnItem.Text = "Select Item";
        }

        private void btnPrnt_Click(object sender, EventArgs e)
        {
            if (cmbSalarySheetType.SelectedIndex == 1)
            {
                LoadDatatableMultiLoc();
            }
            else if (cmbSalarySheetType.SelectedIndex == 0)
            {
                LoadDataTable();
            }
            PrintDetails(2);
        }

        public void PrintDetails(int flug)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = dt.Copy();               
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    int s = i + 1;
                    dt.Columns[i].ColumnName = "col" + s;
                }
                 //dt1 = dt.Copy();
                MidasReport.Form1 MR = new MidasReport.Form1();
                DataTable dt_Sal_Pur_Reg_Final = dt;

                //string[] Report_Columns_Header = new string[6];

                //============================Report Header============================================
                string[] Report_Header = new string[4];
                string[] Report_Header_FontName = new string[4];
                string[] Report_Header_FontSize = new string[4];
                string[] Report_Header_FontStyle = new string[4];

                string TopVal = "1,0,0,0";
                string WidthVal = "1150,1150,1150,1150";
                string HeightVal = "6,5,4,5";// "226,226,226,226";
                string HeightVal_T = "4,4,4,4";
                string LeftVal = "0,0,0,0";
                string AlignVal = "M,M,M,M";

                Report_Header[0] = lbl_company.Text; //edpcom.CURRENT_COMPANY;
                Report_Header[1] = "Payment Sheet for the location : " + Location_Name;
                Report_Header[2] = "Session " + cmbYear.SelectedItem;//" ";
                Report_Header[3] = " For the month of  " + AttenDtTmPkr.Text;//+ Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();

                //Report_Header[3] = "Form " + Convert.ToDateTime(dtpForm.Value).ToShortDateString() + " TO " + Convert.ToDateTime(dtpto.Value).ToShortDateString();
                

                //Report_Header[4] = ""; //"Periodical Stock Transaction";

                for (int i = 0; i <= Report_Header.Length - 1; i++)
                {
                    Report_Header_FontName[i] = "Arial";
                    Report_Header_FontSize[i] = "10";
                    Report_Header_FontStyle[i] = "B";
                }
               
                if (rdbA4.Checked==true)
                {
                    CAR_L=1;
                }
                else if (rdbLegal.Checked == true)
                {
                    CAR_L = 2;
                }
                MR.opt = CAR_L;
                if (CAR_L==1){
                    MR.ReportHeaderArrenge_L( Report_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle,"L");
                }else{
                MR.ReportHeaderArrenge( Report_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle,"L");
                }
                //=================================End===========================================

                //============================Report Page Header============================================
                string[] Report_Page_Header = new string[2];
                string[] Report_PageHeader_FontName = new string[2];
                string[] Report_PageHeader_FontSize = new string[2];
                string[] Report_PageHeader_FontStyle = new string[2];

                TopVal = "2,0";
                WidthVal = "200,200";
                //HeightVal = "6,6";// "226,226,226,226";
                HeightVal = "0,0";// "226,226,226,226";
                LeftVal = "2,2";
                AlignVal = "L,L";  //L for Left,R for Right,M for center

                Report_Page_Header[0] = "Payment Sheet for the location : " + Location_Name;
                Report_Page_Header[1] = "Session " + cmbYear.SelectedItem + " For the month of  " + AttenDtTmPkr.Text;

                Report_PageHeader_FontName[0] = "Arial";
                Report_PageHeader_FontName[1] = "Arial";
                Report_PageHeader_FontSize[0] = "8";
                Report_PageHeader_FontSize[1] = "8";
                Report_PageHeader_FontStyle[0] = "B";
                Report_PageHeader_FontStyle[1] = "B";
                if (CAR_L == 1)
                {
                    MR.ReportPageHeaderArrenge_L(Report_Page_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle, "L");
                }
                else
                {
                    MR.ReportPageHeaderArrenge(Report_Page_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle, "L");
                }
                //====================================End===========================================

                //============================Report Page Footer============================================
                string[] Report_PageFooter = new string[1];
                string[] Report_PageFooter_FontName = new string[1];
                string[] Report_PageFooter_FontSize = new string[1];
                string[] Report_PageFooter_FontStyle = new string[1];

                TopVal = "1";
                WidthVal = "33";
                HeightVal = "2";// "226,226,226,226";
                LeftVal = "2";
                AlignVal = "R";

                Report_PageFooter[0] = " ";               
                Report_PageFooter_FontName[0] = "Arial";               
                Report_PageFooter_FontName[0] = "8";               
                Report_PageFooter_FontStyle[0] = "B";
                if (CAR_L == 1)
                {
                    MR.ReportPageFooterArrenge_L(Report_PageFooter, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontName, Report_PageFooter_FontStyle, "L");
                }
                else
                {
                    MR.ReportPageFooterArrenge(Report_PageFooter, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontName, Report_PageFooter_FontStyle, "L");
                }
                ////====================================End===========================================

                ////============================Report Footer============================================
                string[] Report_Footer = new string[1];
                string[] Report_Footer_FontName = new string[1];
                string[] Report_Footer_FontSize = new string[1];
                string[] Report_Footer_FontStyle = new string[1];

                TopVal = "2";
                WidthVal = "155";
                HeightVal = "2";// "226,226,226,226";
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
                if (CAR_L == 1)
                {
                    MR.ReportFooterArrenge_L(Report_Footer, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle, "L");
                }
                else
                {
                    MR.ReportFooterArrenge(Report_Footer, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle, "L");
                }
                //====================================End===========================================

                //============================Details Columns Header============================================
                int Col_Count = dt1.Columns.Count;
                string[] Report_Columns_Header = new string[Col_Count];
                string[] Report_Columns_Header_FontName = new string[Col_Count];
                string[] Report_Columns_Header_FontSize = new string[Col_Count];
                string[] Report_Columns_Header_FontStyle = new string[Col_Count];

                for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                {
                    string ao = dt1.Columns[i].ToString();
                    Report_Columns_Header[i] = ao;
                    
                }               
                for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                {
                    Report_Columns_Header_FontName[i] = "Times New Roman";
                    Report_Columns_Header_FontSize[i] = "8";
                    Report_Columns_Header_FontStyle[i] = "L";
                }

                int Head_width = 0;
                if (Head_Cou == 0)
                {
                    TopVal = "1,1,1";
                    WidthVal = "6,40,10";
                    HeightVal = "20,20,20";//"4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4";
                    LeftVal = "2,0,0";
                    AlignVal = "L,L,L";
                    Head_width = 274;

                }
                else if (Head_Cou == 1)
                {
                    TopVal = "1,1,1,1";
                    WidthVal = "6,40,10,14";
                    HeightVal = "20,20,20,20";//"4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4";
                    LeftVal = "2,0,0,0";
                    AlignVal = "L,L,L,L";
                    Head_width = 260;
                }
                else if (Head_Cou == 2)
                {
                    TopVal = "1,1,1,1,1";
                    WidthVal = "6,40,10,14,14";
                    HeightVal = "20,20,20,20,20";//"4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4";
                    LeftVal = "2,0,0,0,0";
                    AlignVal = "L,L,L,L,L";
                    Head_width = 246;
                }
                else if (Head_Cou == 3)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "6,40,10,14,14,14";
                    HeightVal = "20,20,20,20,20,20";//"4,4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4,4";
                    LeftVal = "2,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L";
                    Head_width = 232;

                }
                else if (Head_Cou == 4)
                {
                    TopVal = "1,1,1,1,1,1,1";
                    WidthVal = "6,40,10,20,14,14,14";
                    HeightVal = "20,20,20,20,20,20,20";//"4,4,4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4,4,4";
                    LeftVal = "2,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L";
                    Head_width = 218;
                }
                else if (Head_Cou == 5)
                {
                    TopVal = "1,1,1,1,1,1,1,1";
                    WidthVal = "6,37,10,20,14,14,14,10";
                    HeightVal = "20,20,20,20,20,20,20,20";//"4,4,4,4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4,4,4,4";
                    LeftVal = "2,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L";
                    Head_width = 210;
                }
                else if (Head_Cou == 6)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,37,10,20,14,14,14,10,10";
                    HeightVal = "20,20,20,20,20,20,20,20,20";//"4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4,4,4,4,4";
                    LeftVal = "2,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L";
                    Head_width = 200;
                }

                    int a = dt.Columns.Count;
                    a = a - (Head_Cou + 5);
                    int ab = Head_width / a;
                    Head_Cou = Head_Cou + 3;
                    for (int i = Head_Cou; i <= dt.Columns.Count - 1; i++)
                    {
                        TopVal = TopVal + "," + 1;
                        WidthVal = WidthVal + "," +ab;
                      
                        HeightVal = HeightVal + "," + 8;
                        LeftVal = LeftVal + "," + 0;
                        AlignVal = AlignVal + "," + "R";
                    }
                    if (CAR_L == 1)
                    {
                        MR.DetailsColumnsHeaderArrenge_L(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle, "L");
                        MR.DetailsColumnsArrenge_L(TopVal, WidthVal, HeightVal, LeftVal, AlignVal, "L");
                    }
                    else
                    {
                        MR.DetailsColumnsHeaderArrenge(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle, "L");
                        MR.DetailsColumnsArrenge(TopVal, WidthVal, HeightVal, LeftVal, AlignVal, "L");
                    }
                //===================================End====================================================
                if (flug == 1)
                {
                    if (CAR_L == 1)
                    {
                        MR.Graphic_Preview_L(dt_Sal_Pur_Reg_Final, "L", Odet, Oamt, Agent);
                    }
                    else
                    {
                        MR.Graphic_Preview(dt_Sal_Pur_Reg_Final, "L", Odet, Oamt, Agent);
                    }
                    MR.Show();
                }
                else
                    if (CAR_L == 1)
                    {
                        MR.Graphic_Print_L(dt_Sal_Pur_Reg_Final, "L", Odet, Oamt, Agent);
                    }
                    else
                    {
                        MR.Graphic_Print(dt_Sal_Pur_Reg_Final, "L", Odet, Oamt, Agent);
                    }
            }
            catch { }
        }


        public void PrintDetails_L(int flug)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = dt.Copy();
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    int s = i + 1;
                    dt.Columns[i].ColumnName = "col" + s;
                }
                //dt1 = dt.Copy();
                MidasReport.Form1 MR = new MidasReport.Form1();
                DataTable dt_Sal_Pur_Reg_Final = dt;

                //string[] Report_Columns_Header = new string[6];

                //============================Report Header============================================
                string[] Report_Header = new string[4];
                string[] Report_Header_FontName = new string[4];
                string[] Report_Header_FontSize = new string[4];
                string[] Report_Header_FontStyle = new string[4];

                string TopVal = "1,0,0,0";
                string WidthVal = "1150,1150,1150,1150";
                string HeightVal = "6,5,4,5";// "226,226,226,226";
                string HeightVal_T = "4,4,4,4";
                string LeftVal = "0,0,0,0";
                string AlignVal = "M,M,M,M";
                //Locations = Convert.ToString(cmbLocation.ReturnValue);
                lbl_company.Text = cmbcompany.Text;
                Location_Name = Convert.ToString(cmbLocation.Text);
                
                Report_Header[0] = lbl_company.Text; //edpcom.CURRENT_COMPANY;
                if (cmbSalarySheetType.SelectedIndex == 0)
                {
                    Report_Header[1] = "PaymentSheet for the Location : " + cmbLocation.Text;
                }
                else if (cmbSalarySheetType.SelectedIndex == 1 && rdbCo_details.Checked==true)
                {
                    Report_Header[1] = "Detailed Locationwise PaymentSheet (Company Based)";
                }
                else if (cmbSalarySheetType.SelectedIndex == 1 && rdb_Co_Consolidated.Checked == true)
                { Report_Header[1] = "Employee Consolidate Locationwise PaymentSheet (Company Based)"; }
                else if (cmbSalarySheetType.SelectedIndex == 1 && rdb_Co_LocConsolidate.Checked == true)
                { Report_Header[1] = "Locationwise  Consolidated PaymentSheet (Company Based)"; }
                
                Report_Header[2] = "Session " + cmbYear.SelectedItem;//" ";
                Report_Header[3] = " For the month of  " + AttenDtTmPkr.Text;//+ Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();

                //Report_Header[3] = "Form " + Convert.ToDateTime(dtpForm.Value).ToShortDateString() + " TO " + Convert.ToDateTime(dtpto.Value).ToShortDateString();


                //Report_Header[4] = ""; //"Periodical Stock Transaction";

                for (int i = 0; i <= Report_Header.Length - 1; i++)
                {
                    Report_Header_FontName[i] = "Arial";
                    Report_Header_FontSize[i] = "10";
                    Report_Header_FontStyle[i] = "B";
                }
                MR.ReportHeaderArrenge_L(Report_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Header_FontName, Report_Header_FontSize, Report_Header_FontStyle, "L");
                //=================================End===========================================

                //============================Report Page Header============================================
                string[] Report_Page_Header = new string[2];
                string[] Report_PageHeader_FontName = new string[2];
                string[] Report_PageHeader_FontSize = new string[2];
                string[] Report_PageHeader_FontStyle = new string[2];

                TopVal = "2,0";
                WidthVal = "200,200";
                //HeightVal = "6,6";// "226,226,226,226";
                HeightVal = "0,0";// "226,226,226,226";
                LeftVal = "2,2";
                AlignVal = "L,L";  //L for Left,R for Right,M for center

                Report_Page_Header[0] = "Consolidated LocationWise Payment Sheet ";
                Report_Page_Header[1] = "Session " + cmbYear.SelectedItem + " For the month of  " + AttenDtTmPkr.Text;

                Report_PageHeader_FontName[0] = "Arial";
                Report_PageHeader_FontName[1] = "Arial";
                Report_PageHeader_FontSize[0] = "8";
                Report_PageHeader_FontSize[1] = "8";
                Report_PageHeader_FontStyle[0] = "B";
                Report_PageHeader_FontStyle[1] = "B";
                MR.ReportPageHeaderArrenge_L(Report_Page_Header, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageHeader_FontName, Report_PageHeader_FontSize, Report_PageHeader_FontStyle, "L");
                //====================================End===========================================

                //============================Report Page Footer============================================
                string[] Report_PageFooter = new string[1];
                string[] Report_PageFooter_FontName = new string[1];
                string[] Report_PageFooter_FontSize = new string[1];
                string[] Report_PageFooter_FontStyle = new string[1];

                TopVal = "1";
                WidthVal = "33";
                HeightVal = "2";// "226,226,226,226";
                LeftVal = "2";
                AlignVal = "R";

                Report_PageFooter[0] = " ";
                Report_PageFooter_FontName[0] = "Arial";
                Report_PageFooter_FontName[0] = "8";
                Report_PageFooter_FontStyle[0] = "B";
                MR.ReportPageFooterArrenge_L(Report_PageFooter, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_PageFooter_FontName, Report_PageFooter_FontName, Report_PageFooter_FontStyle, "L");
                ////====================================End===========================================

                ////============================Report Footer============================================
                string[] Report_Footer = new string[1];
                string[] Report_Footer_FontName = new string[1];
                string[] Report_Footer_FontSize = new string[1];
                string[] Report_Footer_FontStyle = new string[1];

                TopVal = "2";
                WidthVal = "155";
                HeightVal = "2";// "226,226,226,226";
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
                MR.ReportFooterArrenge_L(Report_Footer, TopVal, WidthVal, HeightVal, LeftVal, AlignVal, Report_Footer_FontName, Report_Footer_FontSize, Report_Footer_FontStyle, "L");
                //====================================End===========================================

                //============================Details Columns Header============================================
                int Col_Count = dt1.Columns.Count;
                string[] Report_Columns_Header = new string[Col_Count];
                string[] Report_Columns_Header_FontName = new string[Col_Count];
                string[] Report_Columns_Header_FontSize = new string[Col_Count];
                string[] Report_Columns_Header_FontStyle = new string[Col_Count];

                for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                {
                    string ao = dt1.Columns[i].ToString();
                    Report_Columns_Header[i] = ao;

                }
                for (int i = 0; i <= dt1.Columns.Count - 1; i++)
                {
                    Report_Columns_Header_FontName[i] = "Times New Roman";
                    Report_Columns_Header_FontSize[i] = "8";
                    Report_Columns_Header_FontStyle[i] = "L";
                }

                int Head_width = 0;
                if (Head_Cou == 0)
                {
                    TopVal = "1,1,1";
                    WidthVal = "6,40,15";
                    HeightVal = "20,20,20";//"4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4";
                    LeftVal = "2,0,0";
                    AlignVal = "L,L,L";
                    Head_width = 274;

                }
                else if (Head_Cou == 1)
                {
                    TopVal = "1,1,1,1";
                    WidthVal = "6,40,15,14";
                    HeightVal = "20,20,20,20";//"4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4";
                    LeftVal = "2,0,0,0";
                    AlignVal = "L,L,L,L";
                    Head_width = 260;
                }
                else if (Head_Cou == 2)
                {
                    TopVal = "1,1,1,1,1";
                    WidthVal = "6,40,15,14,14";
                    HeightVal = "20,20,20,20,20";//"4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4";
                    LeftVal = "2,0,0,0,0";
                    AlignVal = "L,L,L,L,L";
                    Head_width = 246;
                }
                else if (Head_Cou == 3)
                {
                    TopVal = "1,1,1,1,1,1";
                    WidthVal = "6,40,15,14,14,14";
                    HeightVal = "20,20,20,20,20,20";//"4,4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4,4";
                    LeftVal = "2,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L";
                    Head_width = 232;

                }
                else if (Head_Cou == 4)
                {
                    TopVal = "1,1,1,1,1,1,1";
                    WidthVal = "6,40,15,20,14,14,14";
                    HeightVal = "20,20,20,20,20,20,20";//"4,4,4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4,4,4";
                    LeftVal = "2,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L";
                    Head_width = 218;
                }
                else if (Head_Cou == 5)
                {
                    TopVal = "1,1,1,1,1,1,1,1";
                    WidthVal = "6,37,15,20,14,14,14,10";
                    HeightVal = "20,20,20,20,20,20,20,20";//"4,4,4,4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4,4,4,4";
                    LeftVal = "2,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L";
                    Head_width = 210;
                }
                else if (Head_Cou == 6)
                {
                    TopVal = "1,1,1,1,1,1,1,1,1";
                    WidthVal = "6,37,15,20,14,14,14,10,10";
                    HeightVal = "20,20,20,20,20,20,20,20,20";//"4,4,4,4,4,4,4,4,4";// "226,226,226,226";
                    HeightVal_T = "4,4,4,4,4,4,4,4,4";
                    LeftVal = "2,0,0,0,0,0,0,0,0";
                    AlignVal = "L,L,L,L,L,L,L,L,L";
                    Head_width = 200;
                }

                int a = dt.Columns.Count;
                a = a - (Head_Cou + 3);
                int ab = Head_width / a;
                Head_Cou = Head_Cou + 3;
                for (int i = Head_Cou; i <= dt.Columns.Count - 1; i++)
                {
                    TopVal = TopVal + "," + 1;
                    WidthVal = WidthVal + "," + ab;

                    HeightVal = HeightVal + "," + 8;
                    LeftVal = LeftVal + "," + 0;
                    AlignVal = AlignVal + "," + "R";
                }

                MR.DetailsColumnsHeaderArrenge_L(Report_Columns_Header, Report_Columns_Header_FontName, Report_Columns_Header_FontSize, Report_Columns_Header_FontStyle, "L");
                MR.DetailsColumnsArrenge_L(TopVal, WidthVal, HeightVal, LeftVal, AlignVal, "L");

                //===================================End====================================================
                if (flug == 1)
                {
                    MR.Graphic_Preview_L(dt_Sal_Pur_Reg_Final, "L", Odet, Oamt, Agent);
                    MR.Show();
                }
                else
                    MR.Graphic_Print_L(dt_Sal_Pur_Reg_Final, "L", Odet, Oamt, Agent);
            }
            catch { }
        }
        private void cmbYear_DropDown(object sender, EventArgs e)
        {
            //try
            //{
            //    clear_txt();
            //}
            //catch (Exception x) { }
        }

        public void Load_Data1(string qry, ComboBox cb,ComboBox cb1, int i)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    cb.Items.Add(dt.Rows[d][0].ToString());
                    cb1.Items.Add(dt.Rows[d][1].ToString());
                }
                if (i >= 0)
                {
                    cb.SelectedIndex = i;
                    cb1.SelectedIndex = i;
                }
            }
        }


        
        public int get_LocationID(string name)
        {
            
            DataTable dt = new DataTable();
            dt.Clear();
            string s = "select Location_ID from tbl_Emp_Location where Location_Name='" + name + "'";
            dt = clsDataAccess.RunQDTbl(s);
            return Convert.ToInt32(dt.Rows[0][0]);
        }



        //private void Retrive_Data()
        //{
        //    Boolean flug_deduction = false;
        //    //string month = cmbMonth.Text = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);
        //    string month  = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);


        //    DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=em.id)  as Rank,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");

        //    DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' order by Slno");
        //    DataView dv = new DataView(salary_details);
        //    int table_count = tot_employ.Columns.Count;
        //    for (int i = 0; i <= tot_employ.Rows.Count - 1; i++)
        //    {
        //        dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";
        //        for (int j = 0; j <= dv.Count - 1; j++)
        //        {
        //            if (i == 0)
        //            {
        //                if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
        //                {
        //                    table_count = tot_employ.Columns.Count;
        //                    flug_deduction = true;
        //                }
        //                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
        //                tot_employ.Columns.Add(Salary_Head, typeof(string));
        //                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
        //            }
        //            else
        //            {
        //                tot_employ.Rows[i][j + 11] = dv[j]["Amount"];
        //            }

        //        }
        //    }

        //    tot_employ.Columns["Total_Earning"].SetOrdinal(table_count - 1);
        //    tot_employ.Columns["Total_Deduction"].SetOrdinal(tot_employ.Columns.Count - 1);
        //    tot_employ.Columns["Net_Pay"].SetOrdinal(tot_employ.Columns.Count - 1);

        //    tot_employ.AcceptChanges();

        //    dt = tot_employ.Copy();
           
        //}
        private void Retrive_Data_cgfm()
        {
            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            int intConditionCase = 0;
            intConditionCase = Convert.ToInt32(lblStatusCode.Text);
            string strConditions = "";
            switch (intConditionCase)
            {
                case 2:
                    strConditions = " and em.PF_Deduction = 0 "; //Employee with pf deduction not elegible wont show 
                    break;
                case 3:
                    strConditions = " and em.ESI_Deduction = 0 "; //Employee with esi deduction not elegible wont show 
                    break;
                case 1:
                    strConditions = " and em.PF_Deduction = 0 and em.ESI_Deduction = 0 "; //Employee with pf and esi deduction not elegible wont show[THIS WILL BE THE DEFAULT CASE]
                    break;

            }

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            DataTable tot_employ = new DataTable();
            if (prev_type == 1)
            {
                if (cWD_MOD == 0)
                {

    //                tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName,sm.Emp_Id as ID,"+
    //"(case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end) as Rank," +
    //"REPLACE(CONVERT(VARCHAR(11), em.DateOfJoining, 106), ' ', '-') as 'DOJ',em.Gender,sm.Basic as Salary," +
    //"(sm.DaysPresent-(select woff from tbl_Employee_Attend ea where (Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) ))  as WDay," +
    //"(select woff from tbl_Employee_Attend ea where  (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) ) WOFF," +
    //"(select lv_adj from tbl_Employee_Attend ea where  (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) ) [PL Days] ," +
    //"(case when sm.ed>0 then (CAST( sm.OT as nvarchar)+ CHAR(13)+CHAR(10) + 'ED : '+ CAST(sm.ed as nvarchar) ) else CAST(sm.OT as nvarchar) end) as OT," +
    //"cast(sm.TotalDays +(select lv_adj from tbl_Employee_Attend ea where (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid)) as nvarchar(Max)) as TotalDays," +
    //"cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay," +
    //"PassportNo as 'UAN No.',PF as 'Member ID',esino as 'ESIC No.',em.EmailId as 'Email ID',em.Bank_Name +' - '+ em.Branch_Name as 'Bank - Branch' ,em.BankAcountNo as 'BankA/C No',em.GMIno as 'IFSC',sm.desig_id as 'DesgID' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                    tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName,sm.Emp_Id as ID," +
    "(case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end) as Rank," +
    "REPLACE(CONVERT(VARCHAR(11), em.DateOfJoining, 106), ' ', '-') as 'DOJ',em.Gender,sm.Basic as Salary," +
    "(sm.DaysPresent-isNull((select woff from tbl_Employee_Attend ea where (Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) and (ea.ID=sm.Emp_Id) ),0))  as WDay," +
    "isNull((select woff from tbl_Employee_Attend ea where  (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) and (ea.ID=sm.Emp_Id) ),) WOFF," +
    "isNull((select lv_adj from tbl_Employee_Attend ea where  (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) and (ea.ID=sm.Emp_Id) ),0) [PL Days] ," +
    "(case when sm.ed>0 then (CAST( (case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar)+ CHAR(13)+CHAR(10) + 'ED : '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar) ) else CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar) end) as OT," +
    "cast((sm.TotalDays-(case when " + lbl_OT.Text.Trim() + "='0' then 0 else sm.OT end)-(case when " + lbl_ED.Text.Trim() + "='0' then 0 else sm.ed end)) +isNUll((select lv_adj from tbl_Employee_Attend ea where (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) and (ea.ID=sm.Emp_Id)),0) as nvarchar(Max)) as TotalDays," +
    "cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay,sm.desig_id as 'DesgID'," +
    "PassportNo as 'UAN No.',PF as 'Member ID',esino as 'ESIC No.',em.EmailId as 'Email ID',em.Bank_Name +' - '+ em.Branch_Name as 'Bank - Branch' ,em.BankAcountNo as 'BankA/C No',em.GMIno as 'IFSC' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                }
                else if (cWD_MOD == 1)
                {

                    tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl," +
              "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName ," +
              "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank," +
              "sm.Basic as Salary,(select (case when '" + lbl_mod.Text.Trim() + "'='MOD-EWO' then CAST(Wday as nvarchar(max)) + CHAR(13)+CHAR(10) + '(W.Off : '+ cast(woff as nvarchar(max))+ ')' else (Case when isNUll(cWD,0)!=0 then CAST(cWD AS nvarchar(max)) else cast(Wday as nvarchar(max)) end) end) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end) )) as WDay," +
              "(case when sm.ed>0 then (CAST( (case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar)+ CHAR(13)+CHAR(10) + 'ED : '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar) ) else CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar) end) as OT," +
              "cast(isNull((select CAST((Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end)+ days_ot AS numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end) )),0) as nvarchar(Max)) as TotalDays ,cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay,sm.desig_id as 'DesgID' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                }

            }
            else
            {
                if (cWD_MOD == 0)
                {
                    tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName,sm.Emp_Id as ID," +
    "(case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end) as Rank," +
    "REPLACE(CONVERT(VARCHAR(11), em.DateOfJoining, 106), ' ', '-') as 'DOJ',em.Gender,sm.Basic as Salary,"+
    "(sm.DaysPresent-isNull((select woff from tbl_Employee_Attend ea where (Month='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) and (ea.ID=sm.Emp_Id) ),0))  as WDay," +
    "isNull((select woff from tbl_Employee_Attend ea where  (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) and (ea.ID=sm.Emp_Id) ),0) WOFF," +
    "isNull((select lv_adj from tbl_Employee_Attend ea where  (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) and (ea.ID=sm.Emp_Id) ),0) [PL Days] ," +
    "(case when sm.ed>0 then (CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar)+ CHAR(13)+CHAR(10) + 'ED : '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar) ) else CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar) end) as OT," +
    "cast((sm.TotalDays-(case when " + lbl_OT.Text.Trim() + "='0' then 0 else sm.OT end)-(case when " + lbl_ED.Text.Trim() + "='0' then 0 else sm.ed end)) +isNUll((select lv_adj from tbl_Employee_Attend ea where (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (Company_id=sm.Company_id) and (ea.Desgid =sm.desgid) and (ea.ID=sm.Emp_Id)),0) as nvarchar(Max)) as TotalDays," +
    "cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay,sm.desig_id as 'DesgID'," +
    "PassportNo as 'UAN No.',PF as 'Member ID',esino as 'ESIC No.',em.EmailId as 'Email ID',em.Bank_Name +' - '+ em.Branch_Name as 'Bank - Branch' ,em.BankAcountNo as 'BankA/C No',em.GMIno as 'IFSC' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
    //                tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName ,sm.Emp_Id as ID,"+
    //"em.BankAcountNo as BankAcountNo,em.GMIno as 'IFSC',case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank," +
    //"sm.Basic as Salary,sm.DaysPresent as WDay,sm.OT as OT ,sm.ed as EDuty,cast(sm.TotalDays as nvarchar(Max)) as TotalDays ,cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as nvarchar(Max)) NetPay,sm.desig_id as 'DesgID' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                }
                else if (cWD_MOD == 1)
                {

                    tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl," +
              "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName ," +
              "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,em.GMIno as 'IFSC',case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank," +
              "sm.Basic as Salary,(select (Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end) )) as WDay," +
              "(case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as OT ," +
    "(case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as EDuty," +
              "cast(isNull((select CAST((Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end)+ (case when " + lbl_OT.Text.Trim() + "='0' then days_ot else 0 end) AS numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end) )),0) as nvarchar(Max)) as TotalDays ,cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay,sm.desig_id as 'DesgID' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                }

            }
            //(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end)


            DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM  tbl_Employee_SalaryDetails where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution' order by Slno");


            DataTable salary_details_MultiDesignation = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution' order by Slno");


            DataView dv = new DataView(salary_details);
            int table_count = tot_employ.Columns.Count;

            //tot_employ.Rows.Add();  ///

            tot_employ.Rows.Add();
            int dt_count = tot_employ.Rows.Count;
            tot_employ.Rows.Add();
            tot_employ.Rows.Add();

            //
            //int dt_countT = tot_employ.Rows.Count;

            ////tot_employ.Rows[dt_count][0] = "===============";

            //for (int l = 0; l <= tot_employ.Columns.Count; l++)
            //{
            //    //tot_employ.Rows[dt_count][1] = "-------------";
            //    if (Information.IsNumeric(tot_employ.Rows[0][l]) == true)
            //    {
            //        if (l == tot_employ.Columns.Count - 1)
            //        {
            //            tot_employ.Rows[dt_count - 2][1] = "-------------";
            //        }
            //        else
            //        {
            //            tot_employ.Rows[dt_count - 1][0] = "--";
            //        }
            //    }
            //}

            //


            int counter = 0;
            Boolean flagEndOfSingleDesignation = false;

            for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
            {
                Boolean boolOnlyMultiDesg = true;
                if (tot_employ.Rows[i]["DesgID"].ToString().Trim() == "0")
                {
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";

                    //Boolean _basic = true;

                    for (int j = 0; j <= dv.Count - 1; j++)
                    {
                        if (i == 0)
                        {
                            boolOnlyMultiDesg = false;

                            if (j == 0)
                                tot_employ.Rows[dt_count][1] = "                Total :";

                            if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                            {
                                table_count = tot_employ.Columns.Count;
                                flug_deduction = true;
                                counter = j;
                            }

                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                            tot_employ.Columns.Add(Salary_Head, typeof(string));
                            tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];


                            tot_employ.Rows[dt_count - 1][Salary_Head] = "      ";//"----------";

                            tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                            tot_employ.Rows[dt_count + 1][Salary_Head] = "      ";// "========";

                        }
                        else
                        {
                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where (SlNo ='" + dv[j]["SalId"] + "')");

                            if (prev_type == 1)
                            {//[j + 13]
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[j]["Amount"]));

                            }
                            else
                            {//[j + 15]
                                tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[j]["Amount"]));

                            }
                        }
                    }

                    tot_employ.Rows[dt_count - 1]["TotalEarning"] = "      ";//"----------";
                    tot_employ.Rows[dt_count - 1]["TotalDeduction"] = "      ";//"----------";
                    tot_employ.Rows[dt_count - 1]["NetPay"] = "      ";//"----------";

                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalEarning"]) == false)
                        tot_employ.Rows[dt_count]["TotalEarning"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalDeduction"]) == false)
                        tot_employ.Rows[dt_count]["TotalDeduction"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["NetPay"]) == false)
                        tot_employ.Rows[dt_count]["NetPay"] = 0;

                    tot_employ.Rows[dt_count + 1]["TotalEarning"] = "      ";//"========";
                    tot_employ.Rows[dt_count + 1]["TotalDeduction"] = "      ";// "========";
                    tot_employ.Rows[dt_count + 1]["NetPay"] = "      ";//"========";


                    tot_employ.Rows[i]["sl"] = i + 1;

                    tot_employ.Rows[dt_count]["TotalEarning"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalEarning"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalEarning"]));
                    tot_employ.Rows[dt_count]["TotalDeduction"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalDeduction"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalDeduction"]));
                    tot_employ.Rows[dt_count]["NetPay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["NetPay"]) + Convert.ToDouble(tot_employ.Rows[i]["NetPay"]));
                    continue;
                }

                if (!flagEndOfSingleDesignation)
                {
                    dv = new DataView(salary_details_MultiDesignation);
                    flagEndOfSingleDesignation = true;
                }


                dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["DesgID"] + "'";

                for (int j = 0; j <= dv.Count - 1; j++)
                {
                    if (i == 0)
                    {
                        boolOnlyMultiDesg = false;

                        if (j == 0)
                            tot_employ.Rows[dt_count][1] = "                Total :";

                        if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                        {
                            table_count = tot_employ.Columns.Count;
                            flug_deduction = true;
                            counter = j;
                        }

                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                        tot_employ.Columns.Add(Salary_Head, typeof(string));
                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];


                        tot_employ.Rows[dt_count - 1][Salary_Head] = "      ";//"----------";

                        tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                        tot_employ.Rows[dt_count + 1][Salary_Head] = "      ";// "========";

                    }
                    else
                    {
                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where (SlNo ='" + dv[j]["SalId"] + "')");
                        if (prev_type == 1)
                        {//j + 13
                            tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                            tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[j]["Amount"]));

                        }
                        else
                        {
                            //j + 15
                            tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                            tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[j]["Amount"]));

                        }
                    }
                }

                tot_employ.Rows[dt_count - 1]["TotalEarning"] = "      ";//"----------";
                tot_employ.Rows[dt_count - 1]["TotalDeduction"] = "      ";//"----------";
                tot_employ.Rows[dt_count - 1]["NetPay"] = "      ";//"----------";

                if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalEarning"]) == false)
                    tot_employ.Rows[dt_count]["TotalEarning"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalDeduction"]) == false)
                    tot_employ.Rows[dt_count]["TotalDeduction"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["NetPay"]) == false)
                    tot_employ.Rows[dt_count]["NetPay"] = 0;

                tot_employ.Rows[dt_count + 1]["TotalEarning"] = "      ";//"========";
                tot_employ.Rows[dt_count + 1]["TotalDeduction"] = "      ";// "========";
                tot_employ.Rows[dt_count + 1]["NetPay"] = "      ";//"========";


                tot_employ.Rows[i]["sl"] = i + 1;

                tot_employ.Rows[dt_count]["TotalEarning"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalEarning"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalEarning"]));
                tot_employ.Rows[dt_count]["TotalDeduction"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalDeduction"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalDeduction"]));
                tot_employ.Rows[dt_count]["NetPay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["NetPay"]) + Convert.ToDouble(tot_employ.Rows[i]["NetPay"]));

            }

            tot_employ.Columns["TotalEarning"].SetOrdinal(table_count - 1);
            tot_employ.Columns["TotalDeduction"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["NetPay"].SetOrdinal(tot_employ.Columns.Count - 1);
            int salary_structure = 0;
            DataTable SalaryLocation = clsDataAccess.RunQDTbl("select SalaryStructure_ID from tbl_Employee_Link_SalaryStructure where Location_ID=" + Locations + " ");
            if (SalaryLocation.Rows.Count > 0)
            {
                salary_structure = Convert.ToInt32(SalaryLocation.Rows[0]["SalaryStructure_ID"]);

            }
            string sql = "select sal_head, p_type from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and chkHide=2";
            DataTable dt_hide = new DataTable();
            dt_hide = clsDataAccess.RunQDTbl(sql);
            sa_col.Clear();

            for (int ind = 0; ind < dt_hide.Rows.Count; ind++)
            {
                sa_col.Add(0);
                sa_col[ind] = get_sal_head_name(Convert.ToInt32(dt_hide.Rows[ind]["sal_head"]), dt_hide.Rows[ind]["p_type"].ToString());
            }

            //--------------31/07/" + yr[0].Trim() + "---------------------------------------------
            int ixd = Convert.ToInt32(tot_employ.Columns["NETPAY"].Ordinal) - 1;
            try
            {
                for (int ind = 0; ind < sa_col.Count; ind++)
                {
                    ixd = ixd + 1;
                    tot_employ.Columns[sa_col[ind].ToString()].SetOrdinal(ixd);
                    ixd--;
                }
            }
            catch { }
            //---------------------------------------------------------------------

            //earn_count.Text = Convert.ToString(table_count - 3);
            //dataGridView1.DataSource = tot_employ;

            //for (int i = 0; i <= tot_employ.Columns.Count - 1; i++)
            //{
            //    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;
            //}

            tot_employ.Columns.Remove("DesgID");

            tot_employ.AcceptChanges();

            dt = tot_employ.Copy();

        }
        private void Retrive_Data()
        {
            Boolean flug_deduction = false;
            //string month = clsEmployee.GetMonthName(dateTimePicker1.Value.Month);

            month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            int intConditionCase = 0;
            intConditionCase = Convert.ToInt32(lblStatusCode.Text);
            string strConditions = "";
            switch (intConditionCase)
            { 
                case 2:
                    strConditions = " and em.PF_Deduction = 0 "; //Employee with pf deduction not elegible wont show 
                    break;
                case 3:
                    strConditions = " and em.ESI_Deduction = 0 "; //Employee with esi deduction not elegible wont show 
                    break;
                case 1:
                    strConditions = " and em.PF_Deduction = 0 and em.ESI_Deduction = 0 "; //Employee with pf and esi deduction not elegible wont show[THIS WILL BE THE DEFAULT CASE]
                    break;
            
            }

            //DataTable tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,em.Title+' '+em.FirstName+' '+em.MiddleName+' '+em.LastName as EmployName ,sm.Emp_Id as ID,sm.Basic as Salary,sm.DaysPresent as W_Day,sm.OT as O_T,sm.TotalDays as Tot_Day ,sm.TotalSal as Total_Earning,TotalDec as Total_Deduction,sm.NetPay as Net_Pay FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + get_LocationID(cmbsalstruc.Text) + "' and em.ID = sm.Emp_Id");
            DataTable tot_employ = new DataTable();
            if (prev_type == 1)
            {
                if (cWD_MOD == 0)
                {

                    tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl," +
    "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
    "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName ," +
    "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank," +
    "sm.Basic as Salary,sm.DaysPresent as WDay,(case when sm.ed>0 then (CAST( (case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar)+ CHAR(13)+CHAR(10) + 'ED : '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar) ) else CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar) end) as OT,cast(sm.TotalDays as nvarchar(Max)) as TotalDays ,cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay,sm.desig_id as 'DesgID' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                }
                else if (cWD_MOD == 1)
                {

                    tot_employ = clsDataAccess.RunQDTbl("SELECT Distinct null as sl," +
              "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName ," +
              "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank," +
              "sm.Basic as Salary,Cast((select (case when '" + lbl_mod.Text.Trim() + "'='MOD-EWO' then CAST(Wday as nvarchar(max)) + CHAR(13)+CHAR(10) + '(W.Off : '+ cast(woff as nvarchar(max))+ ')' else (Case when isNUll(cWD,0)!=0 then CAST(cWD AS nvarchar(max)) else cast(Wday as nvarchar(max)) end)+ (case when " + Woff + "='1' then CHAR(13)+CHAR(10) + '(W.Off : '+ cast(woff as nvarchar(max))+ ')' else '' end) end) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end) )) as nvarchar) +  CHAR(13)+CHAR(10) + cast((case when " + Woff + "='1' then 'Woff : '+ (select cast(woff as nvarchar) FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and desgid=(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end)) else '' end) as nvarchar) as WDay," +             
              "(case when sm.ed>0 then (CAST( (case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar)+ CHAR(13)+CHAR(10) + 'ED : '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar) ) else CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar) end) as OT," +
              "cast(isNull((select CAST((Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end)+ (case when " + lbl_OT.Text.Trim() + "='0' then days_ot else 0 end) AS numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end) )),0) as nvarchar(Max)) as TotalDays ,cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay,sm.desig_id as 'DesgID' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                }

            }
            else
            {
                if (cWD_MOD == 0)
                {

                    tot_employ = clsDataAccess.RunQDTbl("SELECT distinct null as sl," +
    "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
    "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName ," +
    "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,em.GMIno as 'IFSC',case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank," +
    "sm.Basic as Salary,sm.DaysPresent as WDay,"+
    "(case when "+lbl_OT.Text.Trim()+"='0' then sm.OT else 0 end) as OT ,"+
    "(case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as EDuty," +
    "cast((sm.TotalDays-(case when " + lbl_OT.Text.Trim() + "='0' then 0 else sm.OT end)-(case when " + lbl_ED.Text.Trim() + "='0' then 0 else sm.ed end)) as nvarchar(Max)) as TotalDays ,cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as nvarchar(Max)) NetPay,sm.desig_id as 'DesgID' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                }
                else if (cWD_MOD == 1)
                {

                    tot_employ = clsDataAccess.RunQDTbl("SELECT Distinct null as sl," +
              "((CASE WHEN ltrim(rtrim(em.FirstName)) != '' THEN em.FirstName + ' ' ELSE '' END) + (CASE WHEN ltrim(rtrim(em.MiddleName)) != '' THEN em.MiddleName + ' ' ELSE '' END) + " +
              "(CASE WHEN ltrim(rtrim(em.LastName)) != '' THEN em.LastName + ' ' ELSE '' END)) AS EmployName ," +
              "sm.Emp_Id as ID,em.BankAcountNo as BankAcountNo,em.GMIno as 'IFSC',case when sm.desig_id =0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID))) when sm.desig_id != 0 then (select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=sm.desig_id) end as Rank," +
              "sm.Basic as Salary,Cast((select (Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end)) ) as nvarchar) +  CHAR(13)+CHAR(10) + cast((case when " + Woff + "='1' then 'Woff : '+ (select cast(woff as nvarchar) FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and desgid=(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end)) else '' end) as nvarchar) as WDay," +             
    "(case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as OT ,(case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as EDuty," +
    "cast(isNull((select CAST((Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end)+ (case when " + lbl_OT.Text.Trim() + "='0' then days_ot else 0 end) AS numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end) )),0) as nvarchar(Max)) as TotalDays ,cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay, sm.desig_id as 'DesgID' FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id = '" + Locations + "' and em.ID COLLATE DATABASE_DEFAULT= sm.Emp_Id COLLATE DATABASE_DEFAULT" + strConditions + " order by sm.desig_id asc");
                }

            }
            //(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID=em.ID)) else sm.desig_id end)


            DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount FROM tbl_Employee_SalaryDetails where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution' order by Slno");


            DataTable salary_details_MultiDesignation = clsDataAccess.RunQDTbl("SELECT EmpId,SalId,TableName,Slno,Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' and TableName<>'tbl_Employer_Contribution' order by Slno");


            DataView dv = new DataView(salary_details);
            int table_count = tot_employ.Columns.Count;

            //tot_employ.Rows.Add();  ///

            tot_employ.Rows.Add();
            int dt_count = tot_employ.Rows.Count;
            tot_employ.Rows.Add();
            tot_employ.Rows.Add();

            //
            //int dt_countT = tot_employ.Rows.Count;
           
            ////tot_employ.Rows[dt_count][0] = "===============";

            //for (int l = 0; l <= tot_employ.Columns.Count; l++)
            //{
            //    //tot_employ.Rows[dt_count][1] = "-------------";
            //    if (Information.IsNumeric(tot_employ.Rows[0][l]) == true)
            //    {
            //        if (l == tot_employ.Columns.Count - 1)
            //        {
            //            tot_employ.Rows[dt_count - 2][1] = "-------------";
            //        }
            //        else
            //        {
            //            tot_employ.Rows[dt_count - 1][0] = "--";
            //        }
            //    }
            //}

            //


            int counter = 0;
            Boolean flagEndOfSingleDesignation = false;

            for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
            {
                Boolean boolOnlyMultiDesg = true;
                if (tot_employ.Rows[i]["DesgID"].ToString().Trim() == "0")
                {
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' ";

                    //Boolean _basic = true;

                    for (int j = 0; j <= dv.Count - 1; j++)
                    {
                        if (i == 0)
                        {
                            boolOnlyMultiDesg = false;

                            if (j == 0)
                                tot_employ.Rows[dt_count][1] = "                Total :";

                            if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                            {
                                table_count = tot_employ.Columns.Count;
                                flug_deduction = true;
                                counter = j;
                            }

                            string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                            tot_employ.Columns.Add(Salary_Head, typeof(string));
                            tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];


                            tot_employ.Rows[dt_count - 1][Salary_Head] = "      ";//"----------";

                            tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                            tot_employ.Rows[dt_count + 1][Salary_Head] = "      ";// "========";


                            //if (_basic == true)
                            //{
                            //    tot_employ.Columns.Add("A/C 01 refers to Employer (3.67% of BASIC)", typeof(string));
                            //    tot_employ.Columns.Add("A/C 02 refers to Admin Charges on A/C 01 (0.85% of Basic)", typeof(string));
                            //    tot_employ.Columns.Add("A/C 10 refers to EDLI by Employer (0.5% of BASIC)", typeof(string));
                            //    tot_employ.Columns.Add("A/C 22 refers to A/C 21 (0.01% of BASIC)", typeof(string));

                            //    tot_employ.Rows[i]["A/C 01 refers to Employer (3.67% of BASIC)"] = string.Format("{0:F}", (Convert.ToDouble(dv[j]["Amount"]) * Convert.ToDouble(3.67)) / 100);
                            //    tot_employ.Rows[i]["A/C 02 refers to Admin Charges on A/C 01 (0.85% of Basic)"] = string.Format("{0:F}", (Convert.ToDouble(dv[j]["Amount"]) * Convert.ToDouble(0.85)) / 100);
                            //    tot_employ.Rows[i]["A/C 10 refers to EDLI by Employer (0.5% of BASIC)"] = string.Format("{0:F}", (Convert.ToDouble(dv[j]["Amount"]) * Convert.ToDouble(0.5)) / 100);
                            //    tot_employ.Rows[i]["A/C 22 refers to A/C 21 (0.01% of BASIC)"] = string.Format("{0:F}", (Convert.ToDouble(dv[j]["Amount"]) * Convert.ToDouble(0.01)) / 100);

                            //    _basic = false;
                            //}


                            //if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead")
                            //{
                            //    lbd[j - counter].Text = Salary_Head;
                            //}
                            //else
                            //{
                            //    lbe[j].Text = Salary_Head;

                            //}

                        }
                        else
                        {
                            if (prev_type == 1)
                            {
                                tot_employ.Rows[i][j + 13] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count][j + 13] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 13]) + Convert.ToDouble(dv[j]["Amount"]));

                            }
                            else
                            {
                                tot_employ.Rows[i][j + 15] = dv[j]["Amount"];
                                tot_employ.Rows[dt_count][j + 15] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 15]) + Convert.ToDouble(dv[j]["Amount"]));

                            }
                        }
                    }

                    tot_employ.Rows[dt_count - 1]["TotalEarning"] = "      ";//"----------";
                    tot_employ.Rows[dt_count - 1]["TotalDeduction"] = "      ";//"----------";
                    tot_employ.Rows[dt_count - 1]["NetPay"] = "      ";//"----------";

                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalEarning"]) == false)
                        tot_employ.Rows[dt_count]["TotalEarning"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalDeduction"]) == false)
                        tot_employ.Rows[dt_count]["TotalDeduction"] = 0;
                    if (Information.IsNumeric(tot_employ.Rows[dt_count]["NetPay"]) == false)
                        tot_employ.Rows[dt_count]["NetPay"] = 0;

                    tot_employ.Rows[dt_count + 1]["TotalEarning"] = "      ";//"========";
                    tot_employ.Rows[dt_count + 1]["TotalDeduction"] = "      ";// "========";
                    tot_employ.Rows[dt_count + 1]["NetPay"] = "      ";//"========";


                    tot_employ.Rows[i]["sl"] = i + 1;

                    tot_employ.Rows[dt_count]["TotalEarning"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalEarning"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalEarning"]));
                    tot_employ.Rows[dt_count]["TotalDeduction"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalDeduction"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalDeduction"]));
                    tot_employ.Rows[dt_count]["NetPay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["NetPay"]) + Convert.ToDouble(tot_employ.Rows[i]["NetPay"]));
                    continue;
                }

                if (!flagEndOfSingleDesignation)
                {
                    dv = new DataView(salary_details_MultiDesignation);
                    flagEndOfSingleDesignation = true;
                }


                dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Designation_id = '" + tot_employ.Rows[i]["DesgID"] + "'";

                for (int j = 0; j <= dv.Count - 1; j++)
                {
                    if (i == 0)
                    {
                        boolOnlyMultiDesg = false;

                        if (j == 0)
                            tot_employ.Rows[dt_count][1] = "                Total :";

                        if (Convert.ToString(dv[j]["TableName"]) == "tbl_Employee_DeductionSalayHead" && flug_deduction == false)
                        {
                            table_count = tot_employ.Columns.Count;
                            flug_deduction = true;
                            counter = j;
                        }

                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                        tot_employ.Columns.Add(Salary_Head, typeof(string));
                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];


                        tot_employ.Rows[dt_count - 1][Salary_Head] = "      ";//"----------";

                        tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                        tot_employ.Rows[dt_count + 1][Salary_Head] = "      ";// "========";

                    }
                    else
                    {
                        if (prev_type == 1)
                        {
                            tot_employ.Rows[i][j + 13] = dv[j]["Amount"];
                            tot_employ.Rows[dt_count][j + 13] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 13]) + Convert.ToDouble(dv[j]["Amount"]));

                        }
                        else
                        {
                            tot_employ.Rows[i][j + 15] = dv[j]["Amount"];
                            tot_employ.Rows[dt_count][j + 15] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][j + 15]) + Convert.ToDouble(dv[j]["Amount"]));

                        }
                    }
                }

                tot_employ.Rows[dt_count - 1]["TotalEarning"] = "      ";//"----------";
                tot_employ.Rows[dt_count - 1]["TotalDeduction"] = "      ";//"----------";
                tot_employ.Rows[dt_count - 1]["NetPay"] = "      ";//"----------";

                if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalEarning"]) == false)
                    tot_employ.Rows[dt_count]["TotalEarning"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalDeduction"]) == false)
                    tot_employ.Rows[dt_count]["TotalDeduction"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["NetPay"]) == false)
                    tot_employ.Rows[dt_count]["NetPay"] = 0;

                tot_employ.Rows[dt_count + 1]["TotalEarning"] = "      ";//"========";
                tot_employ.Rows[dt_count + 1]["TotalDeduction"] = "      ";// "========";
                tot_employ.Rows[dt_count + 1]["NetPay"] = "      ";//"========";


                tot_employ.Rows[i]["sl"] = i + 1;

                tot_employ.Rows[dt_count]["TotalEarning"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalEarning"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalEarning"]));
                tot_employ.Rows[dt_count]["TotalDeduction"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalDeduction"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalDeduction"]));
                tot_employ.Rows[dt_count]["NetPay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["NetPay"]) + Convert.ToDouble(tot_employ.Rows[i]["NetPay"]));

            }

            tot_employ.Columns["TotalEarning"].SetOrdinal(table_count - 1);
            tot_employ.Columns["TotalDeduction"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns["NetPay"].SetOrdinal(tot_employ.Columns.Count - 1);
            int salary_structure =0;
            DataTable SalaryLocation = clsDataAccess.RunQDTbl("select SalaryStructure_ID from tbl_Employee_Link_SalaryStructure where Location_ID=" + Locations + " ");
            if (SalaryLocation.Rows.Count > 0)
            {
                salary_structure = Convert.ToInt32(SalaryLocation.Rows[0]["SalaryStructure_ID"]);

            }
            string sql = "select sal_head, p_type from tbl_Employee_Assign_SalStructure where (sal_struct=" + salary_structure + ") and chkHide=2";
            DataTable dt_hide = new DataTable();
            dt_hide = clsDataAccess.RunQDTbl(sql);
            sa_col.Clear();
           
            for (int ind = 0; ind < dt_hide.Rows.Count; ind++)
            {
                sa_col.Add(0);
                sa_col[ind] = get_sal_head_name(Convert.ToInt32(dt_hide.Rows[ind]["sal_head"]), dt_hide.Rows[ind]["p_type"].ToString());
            }

            //--------------31/07/" + yr[0].Trim() + "---------------------------------------------
            int ixd = Convert.ToInt32(tot_employ.Columns["NETPAY"].Ordinal)-1;
            try
            {
                for (int ind = 0; ind < sa_col.Count; ind++)
                {
                    ixd = ixd + 1;
                    tot_employ.Columns[sa_col[ind].ToString()].SetOrdinal(ixd);
                    ixd--;
                }


                if (Convert.ToInt32(lbl_NC.Text) == 0 && sa_col.Count > 0)
                {
                    tot_employ.Columns.Add("EXTRA PAY", typeof(string));
                    tot_employ.Columns.Add("GROSS PAY", typeof(string));


                    for (int ix = 0; ix < tot_employ.Rows.Count; ix++)
                        {
                            if (tot_employ.Rows[ix]["EmployName"].ToString().Trim() != "")
                            {
                                tot_employ.Rows[ix]["EXTRA PAY"] = "0";
                                for (int idx = 0; idx < sa_col.Count; idx++)
                                {
                                    try
                                    {
                                        tot_employ.Rows[ix]["EXTRA PAY"] = Convert.ToString(Convert.ToDouble(tot_employ.Rows[ix][sa_col[idx].ToString()].ToString()) + Convert.ToDouble(tot_employ.Rows[ix]["EXTRA PAY"]));
                                    }
                                    catch { }
                                }

                                tot_employ.Rows[ix]["GROSS PAY"] = (Convert.ToDouble(tot_employ.Rows[ix]["EXTRA PAY"]) + Convert.ToDouble(tot_employ.Rows[ix]["NetPay"])).ToString();
                            }
                        }
                }
            }
            catch { }


            if (SalExp == 2)
            {
                sa_col2.Clear();
               /* sa_col2.Add("EarnedGross");
                sa_col2.Add("EPF");
                sa_col2.Add("ESIC");
                sa_col2.Add("Pf Maintenance Charges");*/
                sa_col2.Add("KIT");
                sa_col2.Add("Uniform");
                sa_col2.Add("LWF");
                sa_col2.Add("Bonus");
                sa_col2.Add("Bon");


                ixd = Convert.ToInt32(tot_employ.Columns["NETPAY"].Ordinal) - 1;
                tot_employ.Columns.Add("EarnedGross");
                tot_employ.Columns.Add("EPF");
                tot_employ.Columns.Add("ESIC");
                tot_employ.Columns.Add("Pf Maintenance Charges");
                ixd = Convert.ToInt32(tot_employ.Columns["Pf Maintenance Charges"].Ordinal) - 1;
                try
                {
                    for (int ind = 0; ind < sa_col2.Count; ind++)
                    {
                        
                        if (tot_employ.Columns.Contains(sa_col2[ind].ToString()))
                        {
                            ixd = ixd + 1;

                            tot_employ.Columns[sa_col2[ind].ToString()].SetOrdinal(ixd);

                            ixd--;
                        }
                    }
                }
                catch { }
                Double vGE = 0, vTD = 0, vNE = 0, ctc = 0, vSC = 0, vScRate = 0;
                string vID = "";
                compid = cmbcompany.ReturnValue;
                vScRate = Convert.ToDouble(clsDataAccess.GetresultS("select Sc_Rate from Companywiseid_Relation where (Location_ID='" + Locations + "') and (company_id='" + compid + "')"));

                tot_employ.Columns.Add("CTC");
                tot_employ.Columns.Add("SC@" + vScRate + "%");
                tot_employ.Columns.Add("GrossTotal");
                int iBS = Convert.ToInt32(tot_employ.Columns["BS"].Ordinal), iTE = Convert.ToInt32(tot_employ.Columns["TotalEarning"].Ordinal);
                int iPF = Convert.ToInt32(tot_employ.Columns["PF"].Ordinal), iTD = Convert.ToInt32(tot_employ.Columns["TotalDeduction"].Ordinal), iNP = Convert.ToInt32(tot_employ.Columns["NetPay"].Ordinal);
                int iCtc = Convert.ToInt32(tot_employ.Columns["CTC"].Ordinal), ieg = Convert.ToInt32(tot_employ.Columns["EarnedGross"].Ordinal), igt = Convert.ToInt32(tot_employ.Columns["GrossTotal"].Ordinal);
                
                int iCl = 0;
                
                
                DataTable dtCont = new DataTable();
                for (int iRw = 0; iRw < tot_employ.Rows.Count; iRw++)
                {
                    vGE = 0; vTD = 0; vNE = 0; ctc = 0; vSC = 0;
                    iCl = iBS;
                    if (tot_employ.Rows[iRw]["EmployName"].ToString().Trim() != "")
                    {

                        if (tot_employ.Rows[iRw]["EmployName"].ToString().Trim() != "Total :")
                        {
                            vID = tot_employ.Rows[iRw]["ID"].ToString().Trim();
                            dtCont = clsDataAccess.RunQDTbl("select (pf_employer_cont+pf)PfCont,esi_employer_cont from tbl_employers_contribution where emp_id='" +
                            vID + "' and month='" + AttenDtTmPkr.Value.ToString("MMMM - yyyy") + "' and lid='" + Locations +
                            "' and (desgid in ((case when " + tot_employ.Rows[iRw]["DesgID"].ToString().Trim() + "='0' then (select distinct Desgid FROM tbl_Employee_Attend WHERE (Month ='" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID ='" + Locations + "') and (ID='" + vID + "')) else " + tot_employ.Rows[iRw]["DesgID"].ToString().Trim() + " end)))");
                            if (dtCont.Rows.Count > 0)
                            {
                                tot_employ.Rows[iRw]["EPF"] = dtCont.Rows[0]["PfCont"].ToString();
                                tot_employ.Rows[iRw]["ESIC"] = dtCont.Rows[0]["esi_employer_cont"].ToString();
                                tot_employ.Rows[iRw]["Pf Maintenance Charges"]="0";


                            }

                        }

                        while (iCl < iTE)
                        {
                            vGE = vGE + Convert.ToDouble(tot_employ.Rows[iRw][iCl].ToString());

                            iCl++;
                        }
                        iCl = iTE + 1;
                        while (iCl < iTD)
                        {
                            vTD = vTD + Convert.ToDouble(tot_employ.Rows[iRw][iCl].ToString());

                            iCl++;
                        }
                        iCl = ieg+1;
                        if (vGE > 0)
                        {
                            ctc = 0;
                            tot_employ.Rows[iRw]["TotalEarning"] = vGE;
                            tot_employ.Rows[iRw]["EarnedGross"] = vGE;
                            ctc = vGE;
                            if (vTD > 0)
                            {
                                tot_employ.Rows[iRw]["TotalDeduction"] = vTD;
                                tot_employ.Rows[iRw]["NetPay"] = (vGE - vTD).ToString("0.00");
                            }
                            while (iCl < iCtc)
                            {
                                if (tot_employ.Rows[iRw]["EmployName"].ToString().Trim() != "Total :")
                                {
                                    ctc = ctc + Convert.ToDouble(tot_employ.Rows[iRw][iCl].ToString());
                                }
                                else
                                {
                                    double tX = 0;
                                    int ix = 0;
                                    try
                                    {
                                        while (ix < (iRw - 1))
                                        {
                                            tX = tX + Convert.ToDouble(tot_employ.Rows[ix][iCl].ToString());

                                            ix++;
                                        }
                                        

                                    }
                                    catch { }


                                    tot_employ.Rows[iRw][iCl] = tX;

                                    ctc = ctc + Convert.ToDouble(tot_employ.Rows[iRw][iCl].ToString());

                                }
                                iCl++;
                            }
                            if (ctc > 0)
                            {
                                tot_employ.Rows[iRw]["CTC"] = ctc;

                                tot_employ.Rows[iRw]["SC@" + vScRate + "%"] = (ctc * vScRate / 100).ToString("0.00");

                                tot_employ.Rows[iRw]["GrossTotal"] = (ctc + (ctc * vScRate / 100)).ToString("0.00");
                            }

                           // tot_employ.Columns["EPF"].ColumnName = "PF @ 13%";
                           // tot_employ.Columns["ESIC"].ColumnName = "ESI @ 3.25%";

                        }


                        
                    }

                }

            }

            //---------------------------------------------------------------------

            //earn_count.Text = Convert.ToString(table_count - 3);
            //dataGridView1.DataSource = tot_employ;

            //for (int i = 0; i <= tot_employ.Columns.Count - 1; i++)
            //{
            //    dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[i].Style.BackColor = Color.SkyBlue;
            //}

            tot_employ.Columns.Remove("DesgID");
          
            tot_employ.AcceptChanges();

            dt = tot_employ.Copy();

        }

        private void Retrive_Data_MultiLocation()
        {
            Boolean flug_deduction = false;
            int ernHeadPso = 0,dedHeadPos = 0;

            month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            int intConditionCase = 0;
            intConditionCase = Convert.ToInt32(lblStatusCode.Text);
            string strConditions = "";
            switch (intConditionCase)
            {
                case 2:
                    strConditions = " and em.PF_Deduction = 0 "; //Employee with pf deduction not elegible wont show 
                    break;
                case 3:
                    strConditions = " and em.ESI_Deduction = 0 "; //Employee with esi deduction not elegible wont show 
                    break;
                case 1:
                    strConditions = " and em.PF_Deduction = 0 and em.ESI_Deduction = 0 "; //Employee with pf and esi deduction not elegible wont show[THIS WILL BE THE DEFAULT CASE]
                    break;

            }

            DataTable tot_employ = new DataTable();
            if (cWD_MOD == 0)
            {
                tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,(select (case when em.FirstName!='' then em.FirstName + ' '  else '' End)+(case when em.MiddleName!='' then em.MiddleName + ' '  else '' End)+(case when em.LastName!='' then em.LastName + ' '  else '' End) from tbl_Employee_Mast em where ID=sm.Emp_Id) as EmployName,"+
             "sm.Emp_Id as ID,sm.Location_id,"+
             "(case when '" + (chkClient.Checked == true) + "'='True' then "+
             "((select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = sm.Location_id) +' - '+ (select (select Client_Name from tbl_Employee_CliantMaster where Client_id=lm.[Cliant_ID]) from [tbl_Emp_Location] lm where lm.[Location_ID] = sm.Location_id)) "+
             "else (select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = sm.Location_id) end) as 'LocationName'," +
             
             "(select em.BankAcountNo from tbl_Employee_Mast em where ID=sm.Emp_Id) as BankAcountNo,"+
             "(select(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(case when sm.desig_id=0 then em.DesgId else sm.desig_id end)) from tbl_Employee_Mast em where ID=sm.Emp_Id) as Rank," +
             "sm.Basic as Salary,sm.DaysPresent as WDay,(case when sm.ed>0 then (CAST( (case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar)+ CHAR(13)+CHAR(10) + 'ED - '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar) ) else CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar) end) as OT,"+
             "cast(sm.TotalDays as nvarchar(Max)) as TotalDays ,cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,"+
             "cast(sm.NetPay as varchar(50)) NetPay,sm.desig_id as DesgID  FROM tbl_Employee_SalaryMast sm where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id in " + Locations + " " + strConditions + " order by sm.Emp_Id");
            }
             else if (cWD_MOD == 1)
            {
                tot_employ = clsDataAccess.RunQDTbl("SELECT null as sl,((case when em.FirstName!='' then em.FirstName + ' '  else '' End)+(case when em.MiddleName!='' then em.MiddleName + ' '  else '' End)+(case when em.LastName!='' then em.LastName + ' '  else '' End)) as EmployName ," +
          "sm.Emp_Id as ID,sm.Location_id,"+
          "(case when '" + (chkClient.Checked == true) + "'='True' then ((select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = sm.Location_id) +' - '+ (select (select Client_Name from tbl_Employee_CliantMaster where Client_id=lm.[Cliant_ID]) from [tbl_Emp_Location] lm where lm.[Location_ID] = sm.Location_id)) else (select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = sm.Location_id) end) as 'LocationName'," +
          "em.BankAcountNo as BankAcountNo,(select(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=(case when sm.desig_id=0 then em.DesgId else sm.desig_id end)) from tbl_Employee_Mast em where ID=sm.Emp_Id)  as Rank,sm.Basic as Salary," +
          "isNull((select (Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0) as WDay,"+
          "(case when sm.ed>0 then (CAST( (case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar)+ CHAR(13)+CHAR(10) + 'ED - '+ CAST((case when " + lbl_ED.Text.Trim() + "='0' then sm.ed else 0 end) as nvarchar) ) else CAST((case when " + lbl_OT.Text.Trim() + "='0' then sm.OT else 0 end) as nvarchar) end) as OT,"+
          "cast(isNull((select CAST((Case when isNUll(cWD,0)!=0 then CAST(cWD AS numeric(18,2)) else Wday end)+ days_ot AS numeric(18,2)) from tbl_employee_attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID) and (Desgid =(case when sm.desig_id=0 then (select Desgid FROM tbl_Employee_Attend WHERE (Month = '" + AttenDtTmPkr.Value.ToString("M/yyyy") + "') AND (LOcation_ID =sm.Location_id) and (ID=em.ID)) else sm.desig_id end) )),0) as nvarchar(Max)) as TotalDays ," +
          "cast(sm.TotalSal as varchar(50)) TotalEarning,cast(sm.TotalDec as varchar(50)) TotalDeduction,cast(sm.NetPay as varchar(50)) NetPay,sm.desig_id as DesgID FROM tbl_Employee_SalaryMast sm,tbl_Employee_Mast em where sm.Session='" + cmbYear.Text + "' and sm.Month ='" + month + "' and sm.Location_id in " + Locations + " and em.ID = sm.Emp_Id" + strConditions + " order by sm.Emp_Id");           


            }
            DataTable salary_details = clsDataAccess.RunQDTbl("SELECT EmpId,sd.[Location_id],(select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = sd.Location_id) as 'LocationName',SalId,TableName,Slno,(case when (select chkhide from tbl_Employee_Assign_SalStructure where SAL_HEAD=sd.SalId and Location_id=sd.Location_id and P_TYPE=(case when (sd.TableName='tbl_Employee_ErnSalaryHead') then 'E' else 'D' end))=2 then 0 else Amount end)Amount FROM tbl_Employee_SalaryDet sd where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id in " + Locations + " and TableName<>'tbl_Employer_Contribution' order by Slno");
            DataTable salary_details_MultiDesignation = clsDataAccess.RunQDTbl("SELECT EmpId,[Location_id],(select lm.[Location_Name] from [tbl_Emp_Location] lm where lm.[Location_ID] = sd.Location_id) as 'LocationName',SalId,TableName,Slno,(case when (select chkhide from tbl_Employee_Assign_SalStructure where SAL_HEAD=sd.SalId and Location_id=sd.Location_id and P_TYPE=(case when (sd.TableName='tbl_Employee_ErnSalaryHead') then 'E' else 'D' end))=2 then 0 else Amount end)Amount,Designation_id FROM tbl_Employee_SalaryDet_MultiDesignation sd where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id in " + Locations + " and TableName<>'tbl_Employer_Contribution' order by Slno");

            DataTable salary_heads_earning = clsDataAccess.RunQDTbl("SELECT distinct SalId FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id in " + Locations + " and TableName='tbl_Employee_ErnSalaryHead' order by SalId");
            for (int i = 0; i < salary_heads_earning.Rows.Count; i++)
            {
                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from tbl_Employee_ErnSalaryHead where SlNo ='" + salary_heads_earning.Rows[i][0] + "'  ");
                tot_employ.Columns.Add(Salary_Head, typeof(string));
            }
            ernHeadPso = tot_employ.Columns.Count;

            DataTable salary_heads_deduction = clsDataAccess.RunQDTbl("SELECT distinct SalId FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id in " + Locations + " and TableName='tbl_Employee_DeductionSalayHead'");
            for (int i = 0; i < salary_heads_deduction.Rows.Count; i++)
            {
                //Changed 03112017
                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from tbl_Employee_DeductionSalayHead where SlNo ='" + salary_heads_deduction.Rows[i][0] + "'  ");
                tot_employ.Columns.Add(Salary_Head, typeof(string));
            }
            dedHeadPos = tot_employ.Columns.Count;

            DataView dv = new DataView(salary_details);
            int table_count = tot_employ.Columns.Count;

            tot_employ.Rows.Add();
            int dt_count = tot_employ.Rows.Count;
            tot_employ.Rows.Add();
            tot_employ.Rows.Add();

            int orginalEmpIdPos = 0;
            string empid = "";
            Boolean boolDuplicateEmpIdFlag = false ,flagEndOfSingleDesignation = false;

            for (int i = 0; i <= tot_employ.Rows.Count - 4; i++)
            {
                if (tot_employ.Rows[i]["DesgID"].ToString().Trim() == "0")
                {
                    flagEndOfSingleDesignation = false;
                    dv = new DataView(salary_details);
                    dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Location_id  = '" + tot_employ.Rows[i]["Location_id"] + "'";
                }
                else
                {
                    if (!flagEndOfSingleDesignation)
                    {
                        dv = new DataView(salary_details_MultiDesignation);

                        dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Location_id  = '" + tot_employ.Rows[i]["Location_id"] + "' and Designation_id = '" + tot_employ.Rows[i]["DesgID"] + "'";
                        flagEndOfSingleDesignation = true;
                    }
                    else
                    {
                        dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "' and Location_id  = '" + tot_employ.Rows[i]["Location_id"] + "' and Designation_id = '" + tot_employ.Rows[i]["DesgID"] + "'";
                    }
                }
                //dv.RowFilter = "EmpId = '" + tot_employ.Rows[i]["ID"] + "'";

                for (int j = 0; j <= dv.Count - 1; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                            tot_employ.Rows[dt_count][1] = "                Total :";
                        
                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");
                        
                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];

                        tot_employ.Rows[dt_count - 1][Salary_Head] = "      ";//"----------";

                        tot_employ.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                        tot_employ.Rows[dt_count + 1][Salary_Head] = "      ";// "========";

                    }
                    else
                    {
                      //For Detailed part
                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                        tot_employ.Rows[i][Salary_Head] = dv[j]["Amount"];
                        //Commented by dwipraj dutta 03112017
                        //tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]) + Convert.ToDouble(dv[j]["Amount"]));
                        double head = 0;
                        try
                        {
                            head = Convert.ToDouble(tot_employ.Rows[dt_count][Salary_Head]);
                        }
                        catch
                        {
                            head = 0;
                        }

                        tot_employ.Rows[dt_count][Salary_Head] = string.Format("{0:F}", head + Convert.ToDouble(dv[j]["Amount"]));
                        //For Compact part


                    }
                }

                tot_employ.Rows[dt_count - 1]["TotalEarning"] = "      ";//"----------";
                tot_employ.Rows[dt_count - 1]["TotalDeduction"] = "      ";//"----------";
                tot_employ.Rows[dt_count - 1]["NetPay"] = "      ";//"----------";

                if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalEarning"]) == false)
                    tot_employ.Rows[dt_count]["TotalEarning"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["TotalDeduction"]) == false)
                    tot_employ.Rows[dt_count]["TotalDeduction"] = 0;
                if (Information.IsNumeric(tot_employ.Rows[dt_count]["NetPay"]) == false)
                    tot_employ.Rows[dt_count]["NetPay"] = 0;

                tot_employ.Rows[dt_count + 1]["TotalEarning"] = "      ";//"========";
                tot_employ.Rows[dt_count + 1]["TotalDeduction"] = "      ";// "========";
                tot_employ.Rows[dt_count + 1]["NetPay"] = "      ";//"========";

                if(boolDuplicateEmpIdFlag)
                    tot_employ.Rows[i]["sl"] = orginalEmpIdPos + 2;
                else
                    tot_employ.Rows[i]["sl"] = i + 1;

                tot_employ.Rows[dt_count]["TotalEarning"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalEarning"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalEarning"]));
                tot_employ.Rows[dt_count]["TotalDeduction"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["TotalDeduction"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalDeduction"]));
                tot_employ.Rows[dt_count]["NetPay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[dt_count]["NetPay"]) + Convert.ToDouble(tot_employ.Rows[i]["NetPay"]));

                ///IF CONSOLATED SELECTED THEN THIS BLOCK WILL RUN DWIPRAJ DUTTA 220920170344pm
                if (rdb_Co_Consolidated.Checked)
                {
                    if (i == 0)
                    {
                        empid = tot_employ.Rows[i]["ID"].ToString();
                        orginalEmpIdPos = i;
                    }
                    else
                    {
                        if (empid == tot_employ.Rows[i]["ID"].ToString())
                        {
                            tot_employ.Rows[orginalEmpIdPos]["WDay"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[orginalEmpIdPos]["WDay"]) + Convert.ToDouble(tot_employ.Rows[i]["WDay"]));
                            tot_employ.Rows[orginalEmpIdPos]["OT"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[orginalEmpIdPos]["OT"]) + Convert.ToDouble(tot_employ.Rows[i]["OT"]));
                            tot_employ.Rows[orginalEmpIdPos]["TotalDays"] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[orginalEmpIdPos]["TotalDays"]) + Convert.ToDouble(tot_employ.Rows[i]["TotalDays"]));
                            for (int j = 11; j < tot_employ.Columns.Count; j++)
                            {
                                if (tot_employ.Rows[i][j].ToString().Trim() == "")
                                    tot_employ.Rows[i][j] = 0;
                                if (tot_employ.Rows[orginalEmpIdPos][j].ToString().Trim() == "")
                                    tot_employ.Rows[orginalEmpIdPos][j] = 0;

                                tot_employ.Rows[orginalEmpIdPos][j] = string.Format("{0:F}", Convert.ToDouble(tot_employ.Rows[orginalEmpIdPos][j]) + Convert.ToDouble(tot_employ.Rows[i][j]));

                            }
                            tot_employ.Rows[orginalEmpIdPos]["LocationName"] = tot_employ.Rows[orginalEmpIdPos]["LocationName"].ToString() + ", " + tot_employ.Rows[i]["LocationName"].ToString();

                            DataRow drDuplicateEmpId = tot_employ.Rows[i];
                            drDuplicateEmpId.Delete();
                            //i--;

                        }
                        else
                        {
                            empid = tot_employ.Rows[i]["ID"].ToString();
                            orginalEmpIdPos = i;
                            boolDuplicateEmpIdFlag = true;
                        }
                    }
                }
                ///220920170344AM ENDS HERE....

            }

            tot_employ.Columns["TotalEarning"].SetOrdinal(ernHeadPso - 1);
            tot_employ.Columns["TotalDeduction"].SetOrdinal(dedHeadPos - 1);
            tot_employ.Columns["NetPay"].SetOrdinal(tot_employ.Columns.Count - 1);
            tot_employ.Columns.Remove("Location_id");
            tot_employ.Columns.Remove("DesgID");
            tot_employ.AcceptChanges();
           // tot_employ.Columns["TotalDays"].DataType = typeof(string);
                //typeof(string);
            dt = tot_employ.Copy();
            DataColumn myDC = new
DataColumn(dt.Columns["TotalDays"].ColumnName, System.Type.GetType("System.String"));
        }

        private void getLoc_data()
        {
            Boolean flug_deduction = false;
            int ernHeadPso = 0, dedHeadPos = 0;

            month = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);

            DataTable dt_loc = clsDataAccess.RunQDTbl("select * from (select null as Sl, ltrim(rtrim(Location_Name)) +' - '+ (select Client_Name from tbl_Employee_CliantMaster where Client_id =a.Cliant_ID) as 'Location-Client',a.Location_ID," +
            //"(select Client_Name from tbl_Employee_CliantMaster where Client_id =a.Cliant_ID)as 'Loc-Client name'," +
            "(select COUNT(Emp_Id)from tbl_Employee_SalaryMast where Location_id=a.Location_ID and Month='" + month + "' AND Session ='" + cmbYear.Text + "')as'No. Emp'," +
            "isnull((select SUM(NetPay)  from tbl_Employee_SalaryMast  where a.Location_ID=Location_id AND  Month = '" + month + "' AND Session ='" + cmbYear.Text + "'),0)as'NetPay'," +
            "isnull((select SUM(TotalSal)  from tbl_Employee_SalaryMast  where a.Location_ID=Location_id AND  Month = '" + month + "' AND Session ='" + cmbYear.Text + "'),0)as'Ttl_Earn'," +
            "isnull((select SUM(TotalDec)  from tbl_Employee_SalaryMast  where a.Location_ID=Location_id AND  Month = '" + month + "' AND Session ='" + cmbYear.Text + "'),0)as'Ttl_Deduct' " +
            "from tbl_Emp_Location  a where a.Location_ID in " + Locations + ") tbl where tbl.NetPay>0 or tbl.Ttl_Deduct>0 or tbl.Ttl_Earn>0");

            DataTable dt_SalDet = clsDataAccess.RunQDTbl("select sd.Location_id,(select [Location_Name] from [tbl_Emp_Location]  where [Location_ID] = sd.Location_id) as 'LocationName',sd.Location_id,sd.SalId,sd.TableName ,sum(sd.Amount)as Amount from  tbl_Employee_SalaryDet sd where sd.Session='" + cmbYear.Text + "' and sd.Month ='" + month + "' and sd.Location_id in " + Locations + " and sd.TableName<>'tbl_Employer_Contribution' group by sd.Location_id,sd.SalId,sd.TableName");

            DataTable dt_SalDet_multi = clsDataAccess.RunQDTbl("select sd.Location_id,(select [Location_Name] from [tbl_Emp_Location]  where [Location_ID] = sd.Location_id) as 'LocationName',sd.Location_id,sd.SalId,sd.TableName ,sum(sd.Amount)as Amount from tbl_Employee_SalaryDet_MultiDesignation sd where sd.Session='" + cmbYear.Text + "' and sd.Month ='" + month + "' and sd.Location_id in " + Locations + " and sd.TableName<>'tbl_Employer_Contribution' group by sd.Location_id,sd.SalId,sd.TableName");

            //dt_SalDet.Merge(dt_SalDet_multi);
            for (int idx = 0; idx < dt_SalDet_multi.Rows.Count; idx++)
            {
                for (int idy = 0; idy < dt_SalDet.Rows.Count; idy++)
                {
                    if (dt_SalDet.Rows[idy]["location_id"].ToString().Trim() == dt_SalDet_multi.Rows[idx]["location_id"].ToString().Trim() && dt_SalDet.Rows[idy]["Salid"].ToString().Trim() == dt_SalDet_multi.Rows[idx]["Salid"].ToString().Trim() && dt_SalDet.Rows[idy]["tableName"].ToString().Trim() == dt_SalDet_multi.Rows[idx]["tableName"].ToString().Trim())
                    {
                        dt_SalDet.Rows[idy]["Amount"] = Convert.ToDouble(dt_SalDet.Rows[idy]["Amount"].ToString()) + Convert.ToDouble(dt_SalDet_multi.Rows[idx]["Amount"].ToString());
                        
                    }

                }
                //dt.Compute("SUM(Salary)", "EmployeeId > 2");
            }
            
            DataTable salary_heads_earning = clsDataAccess.RunQDTbl("SELECT distinct SalId FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id in " + Locations + " and TableName='tbl_Employee_ErnSalaryHead'");
            for (int i = 0; i < salary_heads_earning.Rows.Count; i++)
            {
                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from tbl_Employee_ErnSalaryHead where SlNo ='" + salary_heads_earning.Rows[i][0] + "'  ");
                dt_loc.Columns.Add(Salary_Head, typeof(string));
            }
            ernHeadPso = dt_loc.Columns.Count;

            DataTable salary_heads_deduction = clsDataAccess.RunQDTbl("SELECT distinct SalId FROM tbl_Employee_SalaryDet where Session='" + cmbYear.Text + "' and Month ='" + month + "' and Location_id in " + Locations + " and TableName='tbl_Employee_DeductionSalayHead'");
            for (int i = 0; i < salary_heads_deduction.Rows.Count; i++)
            {
                
                string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from tbl_Employee_DeductionSalayHead where SlNo ='" + salary_heads_deduction.Rows[i][0] + "'  ");
                dt_loc.Columns.Add(Salary_Head, typeof(string));
            }
            dedHeadPos = dt_loc.Columns.Count;

            DataView dv = new DataView(dt_SalDet);
           // dv.AddNew(dt_SalDet_multi);

            int table_count = dt_loc.Columns.Count;
            bool flagEndOfSingleDesignation = false;
            dt_loc.Rows.Add();
            int dt_count = dt_loc.Rows.Count;
            dt_loc.Rows.Add();
            dt_loc.Rows.Add();

            for (int i = 0; i <= dt_loc.Rows.Count - 4; i++)
            {
                dv.RowFilter = " Location_ID  = '" + dt_loc.Rows[i]["Location_ID"] + "'";
                //

                ////if (dt_loc.Rows[i]["DesgID"].ToString().Trim() == "0")
                ////{
                ////    flagEndOfSingleDesignation = false;
                ////    dv = new DataView(dt_SalDet);
                ////    dv.RowFilter = "EmpId = '" + dt_loc.Rows[i]["ID"] + "' and Location_id  = '" + dt_loc.Rows[i]["Location_id"] + "'";
                ////}
                ////else
                ////{
                ////    if (!flagEndOfSingleDesignation)
                ////    {
                ////        dv = new DataView(salary_details_MultiDesignation);

                ////        dv.RowFilter = "EmpId = '" + dt_loc.Rows[i]["ID"] + "' and Location_id  = '" + dt_loc.Rows[i]["Location_id"] + "' and Designation_id = '" + dt_loc.Rows[i]["DesgID"] + "'";
                ////        flagEndOfSingleDesignation = true;
                ////    }
                ////    else
                ////    {
                ////        dv.RowFilter = "EmpId = '" + dt_loc.Rows[i]["ID"] + "' and Location_id  = '" + dt_loc.Rows[i]["Location_id"] + "' and Designation_id = '" + dt_loc.Rows[i]["DesgID"] + "'";
                ////    }
                ////}

                for (int j = 0; j <= dv.Count - 1; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                            dt_loc.Rows[dt_count][1] = "                Total :";

                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                        dt_loc.Rows[i][Salary_Head] = dv[j]["Amount"];

                        dt_loc.Rows[dt_count - 1][Salary_Head] = "      ";//"----------";

                        dt_loc.Rows[dt_count][Salary_Head] = dv[j]["Amount"];
                        dt_loc.Rows[dt_count + 1][Salary_Head] = "      ";// "========";

                    }
                    else
                    {
                        //For Detailed part
                        string Salary_Head = clsDataAccess.GetresultS("select SalaryHead_Short from " + dv[j]["TableName"] + " where SlNo ='" + dv[j]["SalId"] + "'  ");

                        dt_loc.Rows[i][Salary_Head] = dv[j]["Amount"];
                        
                        
                        double head = 0;
                        try
                        {
                            head = Convert.ToDouble(dt_loc.Rows[dt_count][Salary_Head]);
                        }
                        catch
                        {
                            head = 0;
                        }

                        dt_loc.Rows[dt_count][Salary_Head] = string.Format("{0:F}", head + Convert.ToDouble(dv[j]["Amount"]));
                        //For Compact part


                    }
                }

                //dt_loc.Rows[dt_count - 1]["TotalEarning"] = " 0";//"----------";
                //dt_loc.Rows[dt_count - 1]["TotalDeduction"] = "   0   ";//"----------";
                //dt_loc.Rows[dt_count - 1]["NetPay"] = "  0    ";//"----------";

                if (Information.IsNumeric(dt_loc.Rows[dt_count]["Ttl_Earn"]) == false)
                    dt_loc.Rows[dt_count]["Ttl_Earn"] = 0;
                if (Information.IsNumeric(dt_loc.Rows[dt_count]["Ttl_Deduct"]) == false)
                    dt_loc.Rows[dt_count]["Ttl_Deduct"] = 0;
                if (Information.IsNumeric(dt_loc.Rows[dt_count]["NetPay"]) == false)
                    dt_loc.Rows[dt_count]["NetPay"] = 0;

                //dt_loc.Rows[dt_count + 1]["TotalEarning"] = "      ";//"========";
                //dt_loc.Rows[dt_count + 1]["TotalDeduction"] = "      ";// "========";
                //dt_loc.Rows[dt_count + 1]["NetPay"] = "      ";//"========";

                dt_loc.Rows[i]["Sl"] = i + 1;

                dt_loc.Rows[dt_count]["Ttl_Earn"] = string.Format("{0:F}", Convert.ToDouble(dt_loc.Rows[dt_count]["Ttl_Earn"]) + Convert.ToDouble(dt_loc.Rows[i]["Ttl_Earn"]));
                dt_loc.Rows[dt_count]["Ttl_Deduct"] = string.Format("{0:F}", Convert.ToDouble(dt_loc.Rows[dt_count]["Ttl_Deduct"]) + Convert.ToDouble(dt_loc.Rows[i]["Ttl_Deduct"]));
                dt_loc.Rows[dt_count]["NetPay"] = string.Format("{0:F}", Convert.ToDouble(dt_loc.Rows[dt_count]["NetPay"]) + Convert.ToDouble(dt_loc.Rows[i]["NetPay"]));


            }
            dt_loc.Columns["Ttl_Earn"].SetOrdinal(ernHeadPso - 1);
            dt_loc.Columns["Ttl_Deduct"].SetOrdinal(dedHeadPos - 1);
            dt_loc.Columns["NetPay"].SetOrdinal(dt_loc.Columns.Count - 1);
            dt_loc.Columns.Remove("Location_id");
            dt_loc.AcceptChanges();

            dt = dt_loc.Copy();

           
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            prev_type = 0;

            nc();
            try
            {
                SalExp = Convert.ToInt32(clsDataAccess.GetresultS("select SalExp from CompanyLimiter"));// CompanyLimiter SET SalExp
            }
            catch
            {
                SalExp = 0;
            }

            try
            {
                Woff = Convert.ToInt32(clsDataAccess.GetresultS("select loc_initial from Companywiseid_Relation where (Location_ID='" + Locations + "')"));// location wise wo
            }
            catch { Woff = 0; }

            if (cmbSalarySheetType.SelectedIndex == 1)
            {
                LoadDatatableMultiLoc();
            }
            else if (cmbSalarySheetType.SelectedIndex == 0)
            {
                LoadDataTable();
            }

            if (dt.Rows.Count > 3)
            {
                System.Data.DataTable dtCloned = dt.Clone();

                dtCloned.AcceptChanges();

                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                dtCloned.AcceptChanges();


                //excel

                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                int iCol = 0,cCol=dtCloned.Columns.Count;

                excel.Cells[1, 1] = cmbcompany.Text.ToString().Trim();
                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, cCol]);
                range.Font.Bold = true;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();
                if (cmbSalarySheetType.SelectedIndex == 1)
                {
                    excel.Cells[2, 1] = "Payment Sheet for all Locations of : " + cmbcompany.Text.ToString().Trim();
                }
                else
                {
                    excel.Cells[2, 1] = "Payment Sheet for the Location : " + cmbLocation.Text.ToString().Trim();
                }
                range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, cCol]);
                range.Font.Bold = true;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Font.Bold = true;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                excel.Cells[3, 1] = "Session : " + cmbYear.Text.ToString().Trim();
                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, cCol]);
                range.Font.Bold = true;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                excel.Cells[4, 1] = "For the month of " + AttenDtTmPkr.Value.ToString("MMMM - yyyy");
                range = worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[4, cCol]);
                range.Font.Bold = true;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                iCol = 0;
                foreach (DataColumn c in dtCloned.Columns)
                {
                    iCol++;
                    excel.Cells[5, iCol] = c.ColumnName;
                }
                range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, cCol]);
                range.Font.Bold = true;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                int iRow = 5;
                foreach (DataRow r in dtCloned.Rows)
                {
                    iRow++;
                    iCol = 0;
                    foreach (DataColumn c in dtCloned.Columns)
                    {
                        try
                        {
                            iCol++;
                            if (c.ColumnName != "ESIC No." && c.ColumnName != "BankA/C No" && c.ColumnName != "UAN No." && c.ColumnName != "Member ID")
                            {
                                excel.Cells[iRow, iCol] = r[c.ColumnName];
                            }
                            else
                            {
                                excel.Cells[iRow, iCol] = "'"+ r[c.ColumnName];
                            }
                            try
                            {
                                if (iCol > 5 && c.ColumnName != "ESIC No." && c.ColumnName != "BankA/C No" && c.ColumnName != "UAN No." && c.ColumnName != "Member ID")
                                {
                                    range = worksheet.get_Range(worksheet.Cells[iRow, 6], worksheet.Cells[iRow, cCol - 1]);
                                    range.NumberFormat = "0.00";
                                }
                                else
                                {

                                    range = worksheet.get_Range(worksheet.Cells[iRow, 1], worksheet.Cells[iRow, 5]);

                                    range.NumberFormat = "@";
                                }
                            }
                            catch
                            {
                                range = worksheet.get_Range(worksheet.Cells[iRow, 1], worksheet.Cells[iRow, 5]);

                                range.NumberFormat = "@";
                            }

                        }
                        catch
                        {

                        }
                    }
                }
                object missing = System.Reflection.Missing.Value;
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[iRow - 1, cCol]);
                
                range.BorderAround(Excel.XlLineStyle.xlContinuous,
        Excel.XlBorderWeight.xlThin,
        Excel.XlColorIndex.xlColorIndexNone,
        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                Excel.Borders borders = range.Borders;
                //Set the thick lines style.
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                //range.WrapText = true;

                worksheet = (Excel.Worksheet)excel.ActiveSheet;

                ((Excel._Worksheet)worksheet).Activate();

                worksheet.UsedRange.Select();
                worksheet.UsedRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexNone, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                worksheet.Columns.AutoFit();

                ((Excel._Application)excel).Quit();

                MessageBox.Show("Export To ExcelCompleted!", "Export");

                // excel
            }
            else
            {
                MessageBox.Show("There is no Record to export to excel!", "Export");
            }

            dt.Dispose();
            dt.Clear();
        }

        public void cmbLocationid()
        {
            DataTable dt = new DataTable();
            lbl_company.Text = "";
            cmbcompany.Text = "";
            compid = "";
            dt.Clear();
            string s = "SELECT CO_NAME, GCODE  FROM Company WHERE  (CO_CODE IN " + 
            "(SELECT Company_ID FROM Companywiseid_Relation WHERE (Location_ID ="+ Locations +")))";
            dt = clsDataAccess.RunQDTbl(s);
            try
            {
                if (dt.Rows.Count > 1)
                {
                   
                     cmbcompany.LookUpTable = dt;
                        cmbcompany.ReturnIndex = 1;
                        lbl_company.Text = "";

                }
                if (dt.Rows.Count == 1)
                {
                    cmbcompany.Text = Convert.ToString(dt.Rows[0][0]);
                    lbl_company.Text = Convert.ToString(dt.Rows[0][0]);
                    compid = Convert.ToString(dt.Rows[0][1]);
                }
                if (dt.Rows.Count ==0)
                {
                    lbl_company.Text = "";
                    compid = "";
                    cmbcompany.Visible = false;
                    MessageBox.Show("No Company linked with Location");
                }
                label3.Visible = true;
                lbl_company.Visible = false;
                cmbcompany.Visible = true;
            }
            catch
            {
                lbl_company.Text = "No Company linked with Location";
                MessageBox.Show("No Company linked with Location");
                label3.Visible = false;
                lbl_company.Visible = false;
                cmbcompany.Visible = false;
            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            string s ="";
            if (edpcom.CurrentLocation.Trim() != "")
            {
                s = "select  l.Location_Name, l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID where (l.Location_ID in (" + edpcom.CurrentLocation.Trim() + "))";
            }
            else
            {
                s = "select  l.Location_Name, l.Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location AS l INNER JOIN tbl_Employee_Link_SalaryStructure AS ls ON l.Location_ID = ls.Location_ID where l.Location_ID = ls.Location_ID";
            }
         DataTable dt = clsDataAccess.RunQDTbl(s);
         if (dt.Rows.Count > 0)
         {
             cmbLocation.LookUpTable = dt;
             cmbLocation.ReturnIndex = 1;
             
         }
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue) == true)
            {
                Locations = Convert.ToString(cmbLocation.ReturnValue);
                Location_Name = Convert.ToString(cmbLocation.Text);
                cmbLocationid();
                cmbLocation.Text = cmbLocation.Text + " - " + clsDataAccess.ReturnValue("select (SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=l.Cliant_ID)as ClientName  from tbl_Emp_Location l where l.Location_ID =" + Locations);
            }
            else
            {
                //ERPMessageBox.ERPMessage.Show("Location  must be entered");
                Locations = "";
                return;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            string qryCompanyGet = "";
                
            if (edpcom.CurrentLocation.Trim() != "")
            {

                qryCompanyGet = ("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                qryCompanyGet = ("Select CO_NAME,CO_CODE from Company");
            }
            DataTable dtCompanyGet = clsDataAccess.RunQDTbl(qryCompanyGet);
            if (dtCompanyGet.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dtCompanyGet;
                cmbcompany.ReturnIndex = 1;
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
            {
                compid = Convert.ToString(cmbcompany.ReturnValue).Trim();
                lbl_company.Text = cmbcompany.Text;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }

            view_alk();
        }

        private void rdbA4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbSalarySheetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSalarySheetType.SelectedIndex)
            { 
                case 0:
                    label5.Visible = true;
                    cmbLocation.Visible = true;
                    label3.Visible = false;
                    label6.Visible = false;
                    rdbCo_details.Visible = false;
                    rdb_Co_Consolidated.Visible = false;
                    rdb_Co_LocConsolidate.Visible = false;
                    chkClient.Visible = false;
                    break;
                case 1:
                    label5.Visible = false;
                    cmbLocation.Visible = false;
                    Locations = "";
                    label3.Visible = true;
                    label6.Visible = true;
                    rdbCo_details.Visible = true;
                    rdb_Co_Consolidated.Visible = true;
                    rdb_Co_LocConsolidate.Visible = true;
                    rdbCo_details.Checked = true;
                    chkClient.Checked = true;
                    chkClient.Visible = true;
                    break;
            }
        }

        private void frmEmployeeSalarySheet_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (boolPFESIManipulating)
            {
                string q = Convert.ToString(e.KeyChar);
                if (e.KeyChar == 'r')
                    tbStatusWindowPass.Text = "";
                else
                    tbStatusWindowPass.Text = tbStatusWindowPass.Text + q;
                if (tbStatusWindowPass.Text == "hidden")
                {
                    tbStatusWindowPass.Text = "";
                    subfrmEmployeeSalarySheetPFESIStatus fda = new subfrmEmployeeSalarySheetPFESIStatus(Convert.ToInt32(lblStatusCode.Text));
                    fda.ShowDialog();
                    try
                    {
                        lblStatusCode.Text = fda.intReturnValue.ToString();
                    }
                    catch
                    {
                        lblStatusCode.Text = "1";
                    }
                }
            }*/
        }

        public void PFESIManipulationChecking()
        {
            string filePath = "";
            filePath = @Environment.CurrentDirectory + "\\CONFIGURATION_SETTINGS.txt";
            string lineForConfigSetting;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    if (file.ReadLine() != null)
                    {
                        int chk_str = 0;
                        while ((lineForConfigSetting = file.ReadLine()) != null)
                        {
                            string[] StrSTAR = lineForConfigSetting.Trim().Split('*');
                            if (StrSTAR.Length == 2)
                            {
                                if (StrSTAR[0].Trim() == "")
                                    continue;
                            }

                            string[] StrLine = lineForConfigSetting.Trim().Split('[');
                            if (StrLine.Length == 2)
                            {
                                string str = lineForConfigSetting.Substring(1, lineForConfigSetting.Length - 2);
                                if (str.ToUpper() == "PFESI_MANIPULATION")
                                    chk_str = 1;
                            }

                            string[] StrLine_WACC = lineForConfigSetting.Trim().Split(';');
                            if ((chk_str == 1) && (StrLine_WACC.Length > 1))
                            {
                                if (StrLine_WACC[0] == "ON")
                                    boolPFESIManipulating = true;
                                else if (StrLine_WACC[0] == "OFF")
                                    boolPFESIManipulating = false;
                                chk_str = 0;
                            }
                        }
                    }

                }
                catch
                { }
            }
        }

        private void frmEmployeeSalarySheet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.H)
            {
                subfrmEmployeeSalarySheetPFESIStatus fda = new subfrmEmployeeSalarySheetPFESIStatus(Convert.ToInt32(lblStatusCode.Text));
                fda.ShowDialog();
                try
                {
                    lblStatusCode.Text = fda.intReturnValue.ToString();
                }
                catch
                {
                    lblStatusCode.Text = "1";
                }
                e.SuppressKeyPress = true;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        public void LoadSal()
        {
            //dt.Columns.Clear();

            DataTable dt7 = clsDataAccess.RunQDTbl("select  e.RefBankAcountNo,e.RefDesignationName,e.RefBasic,e.RefDaysPresent,e.RefOT,e.RefTotalDays from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");

            DataTable data;
            data = new DataTable("columnname");
            DataColumn column_name = new DataColumn("Column_Name");
            DataColumn Ref_Column_slno = new DataColumn("Ref_Column_slno");
            data.Columns.Add(column_name);
            data.Columns.Add(Ref_Column_slno);
            if (dt7.Rows.Count > 0)
            {
                for (Int32 i = 0; i < dt7.Columns.Count; i++)
                {
                    DataRow dataRow = data.NewRow();
                    dataRow["Column_Name"] = dt7.Columns[i].ColumnName;
                    dataRow["Ref_Column_slno"] = dt7.Rows[0][i].ToString();
                    data.Rows.Add(dataRow);
                }

            }


            data.AcceptChanges();

            //DataTable dt8 = clsDataAccess.RunQDTbl("select  e.BankAcountNo,e.DesignationName,e.Basic,e.DaysPresent,e.OT,e.TotalDays  from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");
            DataTable dt8 = clsDataAccess.RunQDTbl("select  e.BankAcountNo as BankAcountNo,e.DesignationName as Rank,e.Basic as Salary,e.DaysPresent as WDay,e.OT as OT,e.TotalDays as TotalDays  from tbl_Sal_Heads_Print e where e.Location_ID =" + Locations + "  ");

            //e.BankAcountNo as BankAcountNo,e.DesignationName as Rank,e.Basic as Salary,e.DaysPresent as W_Day,e.OT as O_T,e.TotalDays as Tot_Day
            DataTable data1;
            data1 = new DataTable("columnname1");

            DataColumn ColumnName = new DataColumn("ColumnName");
            DataColumn Check = new DataColumn("Check");

            data1.Columns.Add(ColumnName);
            data1.Columns.Add(Check);

            if (dt8.Rows.Count > 0)
            {
                for (Int32 i1 = 0; i1 < dt8.Columns.Count; i1++)
                {
                    DataRow dataRow = data1.NewRow();
                    dataRow["ColumnName"] = dt8.Columns[i1].ColumnName;
                    dataRow["Check"] = dt8.Rows[0][i1];
                    data1.Rows.Add(dataRow);
                }
            }

            data1.AcceptChanges();

            data.Columns.Add("ColumnName");
            data.Columns.Add("Check");

            for (int i = 0; i < data.Rows.Count; i++)
            {
                data.Rows[i]["ColumnName"] = data1.Rows[i]["ColumnName"];
                data.Rows[i]["Check"] = data1.Rows[i]["Check"];
            }

            data.Columns.Remove(data.Columns[0]);
            data.AcceptChanges();
            Head_Cou = 0;
            DataRow[] result = data.Select("Check = 'false'");
            DataRow[] result1 = data.Select("Check = 'True'");
            Head_Cou = result1.Length;
            if (SalExp == 0 || SalExp == 2)
            {
                Retrive_Data();
            }
            else
            {
                Retrive_Data_cgfm();
            }
            if (prev_type == 1)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    string y = result[i].ItemArray[1].ToString();
                    //y = dt.Columns[Convert.ToInt32(result[i].ItemArray[0])].ColumnName.ToString();
                    dt.Columns.Remove(y);
                }
            }

            dt.Columns.Add("Signature", typeof(string));

            dt.AcceptChanges();
            Odet = "";
            Oamt = "";
            Agent = "";
            try
            {
                if (SalExp == 1)
                {
                    dt.Columns["UAN No."].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["Member ID"].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["ESIC No."].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["Email ID"].SetOrdinal(dt.Columns.Count - 1);

                    dt.Columns["Bank - Branch"].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["BankA/C No"].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["IFSC"].SetOrdinal(dt.Columns.Count - 1);
                    dt.Columns["Signature"].SetOrdinal(dt.Columns.Count - 1);
                }
            }
            catch { }
            DataTable salary_Odetails = clsDataAccess.RunQDTbl("SELECT [Slno],[OCId],[OCName],[Amount]," +
     "[Company_id],[ODName],[AcNo],[Bank],[Branch],[IFSC] FROM [tbl_Employee_Sal_OCharges] where Session='" +
     cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' order by Slno");
            if (salary_Odetails.Rows.Count > 0)
            {
                for (int Odet_ind = 0; Odet_ind < salary_Odetails.Rows.Count; Odet_ind++)
                {
                    if (Odet == "" && Oamt == "")
                    {
                        Odet = salary_Odetails.Rows[Odet_ind]["OCName"].ToString();
                        Oamt = salary_Odetails.Rows[Odet_ind]["Amount"].ToString();
                        Agent = "Name : " + salary_Odetails.Rows[0]["ODName"].ToString() + " " + "Bank : " + salary_Odetails.Rows[0]["Bank"].ToString() + "(" + salary_Odetails.Rows[0]["Branch"].ToString() + ") " + "A/C No. : " + salary_Odetails.Rows[0]["AcNo"].ToString() + " " + "IFSC : " + salary_Odetails.Rows[0]["IFSC"].ToString();
                    }
                    else
                    {
                        Odet = Odet + "\n\r" + salary_Odetails.Rows[Odet_ind]["OCName"].ToString();
                        Oamt = Oamt + "\n\r" + salary_Odetails.Rows[Odet_ind]["Amount"].ToString();
                        Agent = Agent + "\n\r" + "Name : " + salary_Odetails.Rows[0]["ODName"].ToString() + " " + "Bank : " + salary_Odetails.Rows[0]["Bank"].ToString() + "(" + salary_Odetails.Rows[0]["Branch"].ToString() + ") " + "A/C No. : " + salary_Odetails.Rows[0]["AcNo"].ToString() + " " + "IFSC : " + salary_Odetails.Rows[0]["IFSC"].ToString();
                    }
                }
            }

            //      DataTable salary_Odet = clsDataAccess.RunQDTbl("SELECT [ODName],[AcNo],[Bank] FROM [tbl_Employee_Sal_ODet] where Session='" +
            //cmbYear.Text + "' and Month ='" + month + "' and Location_id = '" + Locations + "' order by Slno");
            //      if (salary_Odetails.Rows.Count > 0)
            //      {
            //        Agent = "Name : " + salary_Odet.Rows[0]["ODName"].ToString() + "\n\r" + "Bank : " + salary_Odet.Rows[0]["Bank"].ToString() + "\n\r" + "A/C No. : " + salary_Odet.Rows[0]["AcNo"].ToString();
            //      }
            //if (cheDescription.Checked == true)           
            //    dt.Columns.Add("Description", typeof(string));        
            //if (cheAlias.Checked == true)           
            //    dt.Columns.Add("Alias", typeof(string));          
            //if (raddetails.Checked == true)            
            //    dt.Columns.Add("Date", typeof(string));                
            //    dt.Columns.Add("VoucherNo", typeof(string));         
            //dt.Columns.Add("Unit", typeof(string));            
            //dt.Columns.Add("OpeningQty", typeof(string));            
            //for (int i = 0; i <= lblTransaction.Items.Count - 1; i++)
            //{
            //    string Pur = lblTransaction.Items[i].ToString();
            //    dt.Columns.Add("" + Pur + "", typeof(string));                
            //}
            //dt.Columns.Add("TotalIncoming   Qty", typeof(string));           
            //dt.Columns.Add("TotalOutgoing   Qty", typeof(string));           
            //dt.Columns.Add("ClosingQty");           
        }
        private void btnExp2_Click(object sender, EventArgs e)
        {

        }
    }
}