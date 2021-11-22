using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class closing_stock : Form
    {
        DataTable dt = new DataTable();
        string CoID;
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public closing_stock()
        {
            InitializeComponent();
        }

        private void closing_stock_Load(object sender, EventArgs e)
        {
            //radioButton1.Checked = true;
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            try
            {
                if (AttenDtTmPkr.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = AttenDtTmPkr.Value.Year + "-" + AttenDtTmPkr.Value.AddYears(1).Year; }
                    catch { }

                }
                else
                {
                    cmbYear.SelectedItem = AttenDtTmPkr.Value.AddYears(-1).Year + "-" + AttenDtTmPkr.Value.Year;

                }
            }
            catch
            { }
            rdbSelect.Checked = true;
            AttenDtTmPkr.Value = DateTime.Now;
            //if (radioButton1.Checked == true)
           // get_data(AttenDtTmPkr.Value); 

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void get_data(DateTime ason)
        {
            CoID = CmbCompany.ReturnValue.Trim();
            if (CoID.Trim() == "")
            {
                CoID = "1";
            }

            Int32 intYear = 0, intYr = 0;
            String[] strArr = new String[2];
            strArr = cmbYear.Text.Split('-');
            intYear = Convert.ToInt32(strArr[0]);
            intYr = Convert.ToInt32(strArr[1]);
            string frm = "01/April/" + intYear;
            string upto = ason.ToString("dd/MMMM/yyyy");


            string qry = "";
            if (rdbAll.Checked == true)
            {
                qry = "select KTID,KTNAME,cast(OPENING_STOCK as nvarchar)as OPENING_STOCK,cast(PURCHASED_STOCK as nvarchar)as PURCHASED_STOCK," +
                "cast(PURCHASED_RETURN_STOCK as nvarchar)as PURCHASED_RETURN_STOCK,cast(DAMMAGED_RETURN as nvarchar)as  DAMMAGED_RETURN,cast(ISSUED_STOCK as nvarchar)as ISSUED_STOCK," +
                "CAST(ISSUED_RETURN_STOCK as nvarchar) as ISSUED_RETURN_STOCK,cast(((OPENING_STOCK+PURCHASED_STOCK+ISSUED_RETURN_STOCK)-(DAMMAGED_RETURN+ISSUED_STOCK+PURCHASED_RETURN_STOCK)) as nvarchar)as 'CLOSING_STOCK',ClRate " +
                "from (select  KTID,KTNAME,opn_stock as 'OPENING_STOCK'," +
                      "isNull((select sum(stk_in) from purchase where kid=mk.KTID and p_date between '" + frm + "'and '" + upto + "'),0)as 'PURCHASED_STOCK'," +
                      "isNull((select sum(stk_rtn) from purchase where kid=mk.KTID and p_date between '" + frm + "'and '" + upto + "'),0)as 'PURCHASED_RETURN_STOCK'," +
                      "isNull((select sum(stk_rtn) from DamageReturn where kid=mk.KTID and retdt between '" + frm + "'and '" + upto + "'),0)as 'DAMMAGED_RETURN', " +
                      "(select count(EKKIT) from tbl_Employee_KIT where EKKIT=mk.KTID and  EKDT between '" + frm + "'and '" + upto + "') as 'ISSUED_STOCK'," +
                      "isNull((select sum(stk_rtn) from IssueReturn where kid=mk.KTID and retdt between '" + frm + "'and '" + upto + "'),0)as 'ISSUED_RETURN_STOCK',mk.clRate " +
                      "from MSTKIT mk where mk.k_date between '" + frm + "'and '" + upto + "' )e";
            }
            else
            {

                qry = "select KTID,KTNAME,cast(OPENING_STOCK as nvarchar)as OPENING_STOCK,cast(PURCHASED_STOCK as nvarchar)as PURCHASED_STOCK," +
                "cast(PURCHASED_RETURN_STOCK as nvarchar)as PURCHASED_RETURN_STOCK,cast(DAMMAGED_RETURN as nvarchar)as  DAMMAGED_RETURN,cast(ISSUED_STOCK as nvarchar)as ISSUED_STOCK," +
                "CAST(ISSUED_RETURN_STOCK as nvarchar) as ISSUED_RETURN_STOCK,cast(((OPENING_STOCK+PURCHASED_STOCK+ISSUED_RETURN_STOCK)-(DAMMAGED_RETURN+ISSUED_STOCK+PURCHASED_RETURN_STOCK)) as nvarchar)as 'CLOSING_STOCK',ClRate " +
                "from (select  KTID,KTNAME,opn_stock as 'OPENING_STOCK'," +
                      "isNull((select sum(stk_in) from purchase where kid=mk.KTID and (coid=mk.coid) and p_date between '" + frm + "'and '" + upto + "'),0)as 'PURCHASED_STOCK'," +
                      "isNull((select sum(stk_rtn) from purchase where kid=mk.KTID and (coid=mk.coid) and p_date between '" + frm + "'and '" + upto + "'),0)as 'PURCHASED_RETURN_STOCK'," +
                      "isNull((select sum(stk_rtn) from DamageReturn where kid=mk.KTID and (coid=mk.coid) and retdt between '" + frm + "'and '" + upto + "'),0)as 'DAMMAGED_RETURN', " +
                      "(select count(EKKIT) from tbl_Employee_KIT where EKKIT=mk.KTID and (coid=mk.coid) and  EKDT between '" + frm + "'and '" + upto + "') as 'ISSUED_STOCK'," +
                      "isNull((select sum(stk_rtn) from IssueReturn where kid=mk.KTID and (coid=mk.coid) and retdt between '" + frm + "'and '" + upto + "'),0)as 'ISSUED_RETURN_STOCK',mk.clRate " +
                      "from MSTKIT mk where (mk.k_date between '" + frm + "'and '" + upto + "') and (coid='"+CoID+"') )e";
            }
            dt = clsDataAccess.RunQDTbl(qry);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["OPENING_STOCK"] = dt.Rows[i]["OPENING_STOCK"]+" "+ clsDataAccess.GetresultS("select unit from MSTKIT where KTID='"+dt.Rows[i]["KTID"]+"'");
                dt.Rows[i]["PURCHASED_STOCK"] = dt.Rows[i]["PURCHASED_STOCK"] + " " + clsDataAccess.GetresultS("select unit from purchase where kid='" + dt.Rows[i]["KTID"] + "'");
                dt.Rows[i]["ISSUED_STOCK"] = dt.Rows[i]["ISSUED_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
                dt.Rows[i]["PURCHASED_RETURN_STOCK"] = dt.Rows[i]["PURCHASED_RETURN_STOCK"] + " " + clsDataAccess.GetresultS("select unit from purchase where kid='" + dt.Rows[i]["KTID"] + "'");
                dt.Rows[i]["ISSUED_RETURN_STOCK"] = dt.Rows[i]["ISSUED_RETURN_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
                dt.Rows[i]["CLOSING_STOCK"] = dt.Rows[i]["CLOSING_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
                dt.Rows[i]["DAMMAGED_RETURN"] = dt.Rows[i]["DAMMAGED_RETURN"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
                
            }

                dgv_clstk.DataSource = dt;


                dgv_clstk.Columns["OPENING_STOCK"].ReadOnly = true;
                dgv_clstk.Columns["PURCHASED_STOCK"].ReadOnly = true;
                dgv_clstk.Columns["ISSUED_STOCK"].ReadOnly = true;
                dgv_clstk.Columns["PURCHASED_RETURN_STOCK"].ReadOnly = true;
                dgv_clstk.Columns["ISSUED_RETURN_STOCK"].ReadOnly = true;
                dgv_clstk.Columns["CLOSING_STOCK"].ReadOnly = true;
                dgv_clstk.Columns["DAMMAGED_RETURN"].ReadOnly = true;

                dgv_clstk.Columns["ClRate"].ReadOnly = false;
                dgv_clstk.Columns["KTID"].Visible = false;
        }

        private void dgv_clstk_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //Int32 intYear = 0, intYr = 0;
            //String[] strArr = new String[2];
            //strArr = cmbYear.Text.Split('-');
            //intYear = Convert.ToInt32(strArr[0]);
            //intYr = Convert.ToInt32(strArr[1]);
            //if (dgv_clstk.Columns[e.ColumnIndex].HeaderText == "ISSUED_STOCK")
            //{

            //    string ktn = dgv_clstk.Rows[e.RowIndex].Cells["KTID"].Value.ToString();//dgv_clstk.CurrentCell.RowIndex
            //    Pop_up_kit dv = new Pop_up_kit();
            //    dv.sql_frm = "select EKKIT, EKDT as 'KIT_ISSUE_DATE',EKNAME as 'Name',EKMONTH as 'ISSUE MONTH' ,EKAMT as 'KIT COST','1' as 'QUANTITY'," +
            //                 "(SELECT Location_Name FROM tbl_Emp_Location WHERE Location_ID=kt.LocID)as'LOCATION'"+
            //                 "from tbl_Employee_KIT kt WHERE EKKIT='" + ktn + "' and  EKDT between '"+intYear+"-04-01' and '"+intYr+"-03-31'"; 
                      
                
            //    dv.ShowDialog();
            //}
            //else if (dgv_clstk.Columns[e.ColumnIndex].HeaderText == "PURCHASED_STOCK")
            //{
            //    string ktn = dgv_clstk.Rows[e.RowIndex].Cells["KTID"].Value.ToString();
            //    DialogView dv = new DialogView();
            //    dv.sql_frm = "select kt_nm as 'KIT NAME',stk_in as 'STOCK PURCHASED',unit,p_date as 'PURCHASE DATE',month as 'PURCHASE MONTH' from purchase where kid='" + ktn + "' and p_date between '" + intYear + "-04-01' and '" + intYr + "-03-31' ";
            //                                //and month='" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'";
            //    dv.retno = 3;
            //    dv.lblCo.Text = "";
            //    dv.lblHead.Text = "";
            //    dv.btnPreview.Visible = false;
            //    dv.ShowDialog();
            //}

          
            int type_1, type_2;
            
            Int32 intYear = 0, intYr = 0;
            String[] strArr = new String[2];
            strArr = cmbYear.Text.Split('-');
            intYear = Convert.ToInt32(strArr[0]);
            intYr = Convert.ToInt32(strArr[1]);
            if (dgv_clstk.Columns[e.ColumnIndex].HeaderText == "ISSUED_STOCK")
            {
                type_1 = 0;

                string ktn = dgv_clstk.Rows[e.RowIndex].Cells["KTID"].Value.ToString();//dgv_clstk.CurrentCell.RowIndex
                Pop_up_kit dv = new Pop_up_kit();
                dv.show_data(type_1, intYear, intYr, ktn);
                //dv.sql_frm = "select EKKIT, EKDT as 'KIT ISSUE DATE',EKNAME as 'EMPLOYEE NAME',EKMONTH as 'ISSUE MONTH' ,EKAMT as 'KIT COST','1' as 'QUANTITY'," +
                //             "(SELECT Location_Name FROM tbl_Emp_Location WHERE Location_ID=kt.LocID)as'LOCATION'"+
                //             "from tbl_Employee_KIT kt WHERE EKKIT='" + ktn + "' and  EKDT between '"+intYear+"-04-01' and '"+intYr+"-03-31'"; 
                      
                
                dv.ShowDialog();
            }
            else if (dgv_clstk.Columns[e.ColumnIndex].HeaderText == "PURCHASED_STOCK")
            {
                type_2 = 1;
                string ktn = dgv_clstk.Rows[e.RowIndex].Cells["KTID"].Value.ToString();
                Pop_up_kit dv = new Pop_up_kit();
                dv.get_data(type_2, intYear, intYr, ktn);
                //dv.sql_frm = "select kt_nm as 'KIT NAME',stk_in as 'STOCK PURCHASED',unit as 'UNIT',p_date as 'PURCHASE DATE',month as 'PURCHASE MONTH' from purchase where kid='" + ktn + "' and p_date between '" + intYear + "-04-01' and '" + intYr + "-03-31' ";
                                            //and month='" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "'";
                
                dv.ShowDialog();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton2.Checked == true)
            //{ getdata_1(); }

            

        }

        public void getdata_1()
        {
            
            //string mnm = clsEmployee.GetMonthName(AttenDtTmPkr.Value.Month);
            //string rd = clsEmployee.GetMonth_DoubleDigit(mnm);
            //int yr = clsEmployee.GetYear(mnm.ToLower(),cmbYear.Text);
            //int dy = clsEmployee.GetTotalDaysByMonth(mnm.ToLower(),yr);

            //string qry = "";
            //qry = "select KTID,KTNAME,cast(OPENING_STOCK as nvarchar)as OPENING_STOCK,cast(PURCHASED_STOCK as nvarchar)as PURCHASED_STOCK,cast(ISSUED_STOCK as nvarchar)as ISSUED_STOCK,cast(((OPENING_STOCK+PURCHASED_STOCK)-ISSUED_STOCK) as nvarchar)as 'CLOSING_STOCK' from (select  KTID,KTNAME,opn_stock as 'OPENING_STOCK'," +
            //      "(select sum(stk_in) from purchase where kid=mk.KTID and  p_date between '2018-04-01'and '"+yr+"-"+rd+"-"+dy+"')as 'PURCHASED_STOCK'," +
            //      "(select count(EKKIT) from tbl_Employee_KIT where EKKIT=mk.KTID and  EKDT between '2018-04-01' and '"+yr+"-"+rd+"-"+dy+"')as 'ISSUED_STOCK'" +
            //      "from MSTKIT mk where mk.k_date between '04-01-2018' and '"+rd+"-"+dy+"-"+yr+"' )e";
            //dt = clsDataAccess.RunQDTbl(qry);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dt.Rows[i]["OPENING_STOCK"] = dt.Rows[i]["OPENING_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["PURCHASED_STOCK"] = dt.Rows[i]["PURCHASED_STOCK"] + " " + clsDataAccess.GetresultS("select unit from purchase where kid='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["ISSUED_STOCK"] = dt.Rows[i]["ISSUED_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["CLOSING_STOCK"] = dt.Rows[i]["CLOSING_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");

            //}

            //dgv_clstk.DataSource = dt;
            //dgv_clstk.Columns["KTID"].Visible = false;
       
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            string[] yr = cmbYear.Text.Split('-');


            try
            {
                AttenDtTmPkr.MinDate = Convert.ToDateTime("01/April/" + yr[0].ToString().Trim());
            }
            catch
            { }

            try
            {
                AttenDtTmPkr.MaxDate = Convert.ToDateTime("31/March/" + yr[1].ToString().Trim());
            }
            catch { }
            //get_data();
        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            get_data(AttenDtTmPkr.Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str = "", KTID = "",clstock="", sess = cmbYear.Text.ToString(), clRate = "", cldate=AttenDtTmPkr.Value.ToString("dd/MMM/yyyy");
            bool bl = false;
            CoID = CmbCompany.ReturnValue.Trim();
            if (CoID.Trim() == "")
            {
                CoID = "1";
            }
            //OPENING_STOCK,PURCHASED_STOCK,ISSUED_STOCK,PURCHASED_RETURN_STOCK,ISSUED_RETURN_STOCK,CLOSING_STOCK,DAMMAGED_RETURN,clRate
            for (int idx = 0; idx < dgv_clstk.Rows.Count; idx++)
            {
                KTID = dgv_clstk.Rows[idx].Cells["KTID"].Value.ToString();
                clstock = dgv_clstk.Rows[idx].Cells["CLOSING_STOCK"].Value.ToString();
                clRate = dgv_clstk.Rows[idx].Cells["clRate"].Value.ToString();

                str = "UPDATE MSTKIT SET clstock='" + clstock + "',clRate='" + clRate + "',cldate='" + cldate + "' where (KTID='" + KTID + "') and (sess ='" + sess + "')";
                bl = clsDataAccess.RunQry(str);
            }

            if (bl == true)
            {
                ERPMessageBox.ERPMessage.Show("Closing Stock  Saved Successfully", "BRAVO");
                get_data(AttenDtTmPkr.Value);
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSelect.Checked == true)
            {
                CmbCompany.Enabled = true;
                CmbCompany.PopUp();
            }
            else
            {
                CmbCompany.Enabled = false;
            }

        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE " +
                " from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            }
            if (dt.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                CmbCompany.Text = dt.Rows[0]["CO_name"].ToString();
                CmbCompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                CoID = CmbCompany.ReturnValue.ToString();
                if (CoID.Trim() == "")
                {
                    CoID = "1";
                }
                get_data(AttenDtTmPkr.Value);

            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            CoID = CmbCompany.ReturnValue.Trim();
            if (CoID.Trim() == "")
            {
                CoID = "1";
            }
            get_data(AttenDtTmPkr.Value);
        }
    }
}
