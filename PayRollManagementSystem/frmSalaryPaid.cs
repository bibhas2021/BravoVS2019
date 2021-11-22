using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Windows.Forms.VisualStyles;
using System.Web.UI.WebControls;


namespace PayRollManagementSystem
{
    public partial class frmSalaryPaid : Form
    {
        public frmSalaryPaid()
        {
            InitializeComponent();
        }
        Int32 Company_id = 0;
        string sql = "", cond="",mod="";
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (rdb_due.Checked == true)
            {
                cond = " AND (sm.Acc_transfer='False') ";
            }
            else if (rdbpaid.Checked == true)
            {
                cond = " AND (sm.Acc_transfer='True') ";
            }
            else if (rdbAll.Checked == true)
            {
                cond = "";
            }

            if (rdb_View_Cash.Checked == true) { mod = "  and ((select isNUll(pay_mod,2) FROM tbl_Employee_Mast AS e WHERE (ID=sm.Emp_Id)) = '2') "; }
            else if (rdb_View_Bank.Checked == true) { mod = " and ((select isNUll(pay_mod,2) FROM tbl_Employee_Mast AS e WHERE (ID=sm.Emp_Id)) = '1') "; }
            else if (rdb_View_Cheque.Checked == true) { mod = "  and ((select isNUll(pay_mod,2) FROM tbl_Employee_Mast AS e WHERE (ID=sm.Emp_Id)) = '3') "; } else { mod = ""; }

            sql = "SELECT sm.Emp_Id,sm.NetPay,sm.Month,sm.Session,sm.Location_id,sm.Company_id,sm.desig_id," +
            "(SELECT (CASE WHEN ltrim(rtrim(e.FirstName)) != '' THEN e.FirstName ELSE '' END)+"+
            "(CASE WHEN ltrim(rtrim(e.MiddleName))!= '' THEN ' ' + e.MiddleName ELSE '' END)+"+
            "(CASE WHEN ltrim(rtrim(e.LastName)) != '' THEN ' ' + e.LastName ELSE '' END) AS 'EName' FROM tbl_Employee_Mast AS e WHERE (ID=sm.Emp_Id)) AS 'EName'," +
            "(select (case when pay_mod=1 then 'Bank Tansfer' else (case when  pay_mod=3 then 'Cheque' else 'Cash' end) end) FROM tbl_Employee_Mast AS e WHERE (ID=sm.Emp_Id)) AS 'MOD',"+
            "loc.Client_Name,loc.Location_Name,loc.Cliant_ID,loc.Location_ID AS lid,sm.Acc_transfer FROM tbl_Employee_SalaryMast AS sm INNER JOIN " +
            "(SELECT el.Location_ID,el.Location_Name,el.Cliant_ID,ec.Client_Name FROM tbl_Emp_Location AS el INNER JOIN " +
            "tbl_Employee_CliantMaster AS ec ON el.Cliant_ID =ec.Client_id AND ec.coid='" + Company_id + 
            "') AS loc ON sm.Location_id=loc.Location_ID WHERE (sm.Month='" + dtpMonth.Value.ToString("MMMM") + 
            "') AND (sm.Session='" + cmbYear.Text + "') AND (sm.Company_id='" + Company_id + "') "+ cond + mod + " ORDER BY sm.Emp_Id,sm.Location_id"; 
            DataTable dtsal = clsDataAccess.RunQDTbl(sql);
            DataTable dtpay = new DataTable();
            try { dgvRow.Rows.Clear(); }
            catch { }
            for (int ind = 0; ind < dtsal.Rows.Count; ind++)
            {
                dgvRow.Rows.Add();
                dgvRow.Rows[ind].Cells["col_eid"].Value=dtsal.Rows[ind]["Emp_Id"].ToString();
                                       
                dgvRow.Rows[ind].Cells["col_name"].Value=dtsal.Rows[ind]["EName"].ToString();
                dgvRow.Rows[ind].Cells["col_locid"].Value=dtsal.Rows[ind]["Location_id"].ToString();
                dgvRow.Rows[ind].Cells["col_clid"].Value=dtsal.Rows[ind]["Cliant_ID"].ToString();
                dgvRow.Rows[ind].Cells["col_Client_Loc"].Value = dtsal.Rows[ind]["Client_Name"].ToString() + Environment.NewLine + "(" + dtsal.Rows[ind]["Location_Name"].ToString() + ")";
                dgvRow.Rows[ind].Cells["col_net"].Value = dtsal.Rows[ind]["NetPay"].ToString();
                if (dtsal.Rows[ind]["Acc_transfer"].ToString().ToLower() == "false")
                {
                    dgvRow.Rows[ind].Cells["col_mod"].Value = dtsal.Rows[ind]["MOD"].ToString().Trim();
                    dgvRow.Rows[ind].Cells["col_remarks"].Value = "";
                    dgvRow.Rows[ind].Cells["col_status"].Value = "False";
                    dgvRow.Rows[ind].Cells["col_pdate"].Value = DateAndTime.Now.Date;
                    dgvRow.Rows[ind].Cells["col_instrument_date"].Value = DateAndTime.Now.Date;
                    dgvRow.Rows[ind].Cells["col_bank"].Value = "";
                    dgvRow.Rows[ind].Cells["col_InstrumentNo"].Value = "";
                    dgvRow.Rows[ind].Cells["col_lock"].Value = "False";
                    dgvRow.Rows[ind].Cells["col_slno"].Value = 0;
                    dgvRow.Rows[ind].Cells["col_curst"].Value = "ISSUED"; 
                    dgvRow.Rows[ind].Cells["col_bank"].ReadOnly = true;
                   // dgvRow.Rows[ind].Cells["col_instrument"].ReadOnly = true;
                    dtpay = clsDataAccess.RunQDTbl("select status,remarks,paidby,instrumentno,bank,pdate,lock,instrumentdate,vid,adhok,cur_stat from tbl_Salary_Payment where (eid='" + dtsal.Rows[ind]["Emp_Id"].ToString() +
                    "') and (locid ='"+dtsal.Rows[ind]["Location_id"].ToString()+"') and (clid='"+dtsal.Rows[ind]["Cliant_ID"].ToString()+
                    "') and (coid='" + Company_id + "') and (month='" + dtpMonth.Value.ToString("MMM/yyyy") + "') and (session='"+ cmbYear.Text +"')");
                    if (dtpay.Rows.Count > 0)
                    {
                        dgvRow.Rows[ind].Cells["col_remarks"].Value = dtpay.Rows[0]["remarks"].ToString();
                        dgvRow.Rows[ind].Cells["col_lock"].Value = dtpay.Rows[0]["lock"].ToString();
                        dgvRow.Rows[ind].Cells["col_InstrumentNo"].Value = dtpay.Rows[0]["instrumentno"].ToString().Trim();
                        
                        dgvRow.Rows[ind].Cells["col_instrument_Date"].Value = dtpay.Rows[0]["instrumentdate"];

                        dgvRow.Rows[ind].Cells["col_bank"].Value = dtpay.Rows[0]["bank"].ToString().Trim();

                        dgvRow.Rows[ind].Cells["col_pdate"].Value = dtpay.Rows[0]["pdate"];

                        dgvRow.Rows[ind].Cells["col_adhok"].Value = dtpay.Rows[0]["adhok"];
                        dgvRow.Rows[ind].Cells["col_curst"].Value = dtpay.Rows[0]["cur_stat"];

                        dgvRow.Rows[ind].Cells["col_status"].Value = dtpay.Rows[0]["status"].ToString();
                        if (dtpay.Rows[0]["remarks"].ToString().ToLower() == "true")
                        {
                            dgvRow.Rows[ind].Cells["col_status"].ReadOnly = true;
                            dgvRow.Rows[ind].Cells["col_pdate"].ReadOnly = true;
                            dgvRow.Rows[ind].Cells["col_instrumentNo"].ReadOnly = true;
                            dgvRow.Rows[ind].Cells["col_instrument_Date"].ReadOnly = true;
                            dgvRow.Rows[ind].Cells["col_bank"].ReadOnly = true;
                        }
                        else
                        {
                            dgvRow.Rows[ind].Cells["col_status"].ReadOnly = false;
                            dgvRow.Rows[ind].Cells["col_pdate"].ReadOnly = false;
                            dgvRow.Rows[ind].Cells["col_instrumentNo"].ReadOnly = false;
                            dgvRow.Rows[ind].Cells["col_instrument_Date"].ReadOnly = false;
                            dgvRow.Rows[ind].Cells["col_bank"].ReadOnly = false;
                        }

                        if (dgvRow.Rows[ind].Cells["col_mod"].Value.ToString().ToLower() == "cheque" || dgvRow.Rows[ind].Cells["col_mod"].Value.ToString().ToLower() == "bank transfer")
                        {
                            dgvRow.Rows[ind].Cells["col_bank"].ReadOnly = false;
                            dgvRow.Rows[ind].Cells["col_instrument"].ReadOnly = false;
                        }
                        else
                        {
                            dgvRow.Rows[ind].Cells["col_bank"].ReadOnly = true;
                            dgvRow.Rows[ind].Cells["col_instrumentNo"].ReadOnly = true;
                        }
                    }
                    else
                    {
                        dgvRow.Rows[ind].Cells["col_status"].ReadOnly = false;
                        dgvRow.Rows[ind].Cells["col_pdate"].ReadOnly = false;
                        dgvRow.Rows[ind].Cells["col_instrumentNo"].ReadOnly = false;
                        dgvRow.Rows[ind].Cells["col_instrument_Date"].ReadOnly = false;
                        dgvRow.Rows[ind].Cells["col_bank"].ReadOnly = false;
                    }
                }
                else if (dtsal.Rows[ind]["Acc_transfer"].ToString().ToLower() == "true")
                {
                    dtpay = clsDataAccess.RunQDTbl("select status,remarks,paidby,instrumentno,bank,pdate,lock,vid,adhok,cur_stat from tbl_Salary_Payment where (eid='" + dtsal.Rows[ind]["Emp_Id"].ToString() +
                    "') and (locid ='"+dtsal.Rows[ind]["Location_id"].ToString()+"') and (clid='"+dtsal.Rows[ind]["Cliant_ID"].ToString()+
                    "') and (coid='" + Company_id + "') and (month='" + dtpMonth.Value.ToString("MMM/yyyy") + "') and (session='"+ cmbYear.Text +"')");
                    if (dtpay.Rows.Count > 0)
                    {
                        dgvRow.Rows[ind].Cells["col_mod"].Value = dtpay.Rows[0]["paidby"].ToString();
                        dgvRow.Rows[ind].Cells["col_remarks"].Value = dtpay.Rows[0]["remarks"].ToString();
                        dgvRow.Rows[ind].Cells["col_status"].Value = dtpay.Rows[0]["status"].ToString();
                        dgvRow.Rows[ind].Cells["col_pdate"].Value = dtpay.Rows[0]["pdate"];
                        dgvRow.Rows[ind].Cells["col_InstrumentNo"].Value = dtpay.Rows[0]["instrumentno"].ToString().Trim();
                        dgvRow.Rows[ind].Cells["col_bank"].Value = dtpay.Rows[0]["bank"].ToString().Trim();

                        dgvRow.Rows[ind].Cells["col_adhok"].Value = dtpay.Rows[0]["adhok"];
                        dgvRow.Rows[ind].Cells["col_curst"].Value = dtpay.Rows[0]["cur_stat"];

                        //dgvRow.Rows[ind].Cells["col_vno"].Value = dtpay.Rows[0]["vchr"].ToString();
                        dgvRow.Rows[ind].Cells["col_lock"].Value = dtpay.Rows[0]["lock"].ToString();
                        dgvRow.Rows[ind].Cells["col_slno"].Value = dtpay.Rows[0]["vid"].ToString();
                        dgvRow.Rows[ind].Cells["col_curst"].Value = "Transferred"; 
                        if (dgvRow.Rows[ind].Cells["col_mod"].Value.ToString().ToLower() == "cheque" || dgvRow.Rows[ind].Cells["col_mod"].Value.ToString().ToLower() == "bank transfer")
                        {
                            dgvRow.Rows[ind].Cells["col_bank"].ReadOnly = false;
                            dgvRow.Rows[ind].Cells["col_instrument"].ReadOnly = false;
                        }
                        else
                        {
                            dgvRow.Rows[ind].Cells["col_bank"].ReadOnly = true;
                            dgvRow.Rows[ind].Cells["col_instrumentNo"].ReadOnly = true;
                        }
                    }
                }

            }
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 1)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                cmbcompany.ReturnValue=dt.Rows[0]["CO_CODE"].ToString();
                cmbcompany.Text = dt.Rows[0]["CO_NAME"].ToString();
                Company_id = Convert.ToInt32(dt.Rows[0]["CO_CODE"].ToString());
            }

        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpMonth.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = dtpMonth.Value.Year + "-" + dtpMonth.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedItem = dtpMonth.Value.AddYears(-1).Year + "-" + dtpMonth.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }
        }

        private void frmSalaryPaid_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);

            this.WindowState = FormWindowState.Maximized;

            dtpMonth.Value = DateAndTime.Now.AddMonths(-1);

            cmbcompany.PopUp();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            string eid="",adhok="0",cur_stat="",locid="",clid="",coid="",vmonth="",vsession="",status="",remarks="",paidby="",instrumentno="",bank="",pdate="",vlock="",vchr="";
            int vid=0;
            double netpay=0;
            bool bl=false;
             for (int ind = 0; ind < dgvRow.Rows.Count; ind++)
            {
                eid=dgvRow.Rows[ind].Cells["col_eid"].Value.ToString();
                locid=dgvRow.Rows[ind].Cells["col_locid"].Value.ToString();
                clid=dgvRow.Rows[ind].Cells["col_clid"].Value.ToString();
                coid=Company_id.ToString();
                vmonth=dtpMonth.Value.ToString("MMM/yyyy");
                 vsession=cmbYear.Text;
                 status=dgvRow.Rows[ind].Cells["col_status"].Value.ToString();
                 remarks=dgvRow.Rows[ind].Cells["col_remarks"].Value.ToString();
                 paidby=dgvRow.Rows[ind].Cells["col_mod"].Value.ToString();
                 instrumentno = dgvRow.Rows[ind].Cells["col_InstrumentNo"].Value.ToString().Trim();
                 bank=dgvRow.Rows[ind].Cells["col_bank"].Value.ToString().Trim();
                 pdate=Convert.ToDateTime(dgvRow.Rows[ind].Cells["col_pdate"].Value).ToString("dd/MMM/yyyy");
                 vlock=dgvRow.Rows[ind].Cells["col_lock"].Value.ToString();
                 vchr = Convert.ToDateTime(dgvRow.Rows[ind].Cells["col_instrument_date"].Value).ToString("dd/MMM/yyyy");
                 netpay=Convert.ToDouble(dgvRow.Rows[ind].Cells["col_net"].Value);
                 
                 adhok=dgvRow.Rows[ind].Cells["col_adhok"].Value.ToString();
                 cur_stat=dgvRow.Rows[ind].Cells["col_curst"].Value.ToString();

                 try { vid = Convert.ToInt32(dgvRow.Rows[ind].Cells["col_slno"].Value); }
                 catch { vid = 0; }


                 try
                 {
                     sql = "delete from tbl_Salary_Payment where (eid='" + eid + "') and (locid='" + locid + "') and (clid='" + clid + "') and (coid='" + coid + "') and (month='" + vmonth + "')";
                     clsDataAccess.RunQry(sql);
                 }
                 catch { }

                 if (status.ToLower() == "true" || status.ToLower() == "1")
                 {
                     if (vid == 0)
                     {
                         sql = "insert into tbl_Salary_Payment(eid,locid,clid,coid,month,session,status,remarks,paidby,instrumentno,bank,pdate,lock,instrumentdate,vid,netval,adhok,cur_stat) values ('" +
                             eid + "','" + locid + "','" + clid + "','" + coid + "','" + vmonth + "','" + vsession + "','" + status + "','" + remarks + "','" + paidby + "','" +
                             instrumentno + "','" + bank + "','" + pdate + "','" + vlock + "','" + vchr +
                             "',(select count(*)+1 from tbl_Salary_Payment where (locid ='" + locid + "') and (clid='" + clid + "') and (coid='" + coid + "') and (month='" + vmonth + "') and (session='" + vsession + "')),'" + netpay + "','"+adhok+"','"+cur_stat+"')";
                        bl= clsDataAccess.RunQry(sql);
                        if ((bl == true) && (vlock.Trim().ToLower()=="false"))
                        {
                            sql="update tbl_Employee_SalaryMast set Acc_transfer='True' WHERE (Month='" + dtpMonth.Value.ToString("MMMM") + 
            "') AND (Session='" + cmbYear.Text + "') AND (Company_id='" + Company_id + "') and (Emp_Id='"+eid+"') and (Location_id='"+locid+"')";
                            clsDataAccess.RunQry(sql);
                        }
                     }
                 }
                 else if (vlock.ToLower() == "true")
                 {
                     sql = "insert into tbl_Salary_Payment(eid,locid,clid,coid,month,session,status,remarks,paidby,instrumentno,bank,pdate,lock,instrumentdate,vid,netval,adhok,cur_stat) values ('" +
                            eid + "','" + locid + "','" + clid + "','" + coid + "','" + vmonth + "','" + vsession + "','" + status + "','" + remarks + "','" + paidby + "','" +
                            instrumentno + "','" + bank + "','" + pdate + "','" + vlock + "','" + vchr +
                            "',(select count(*)+1 from tbl_Salary_Payment where (locid ='" + locid + "') and (clid='" + clid + "') and (coid='" + coid + "') and (month='" + vmonth + "') and (session='" + vsession + "')),'" + netpay + "','" + adhok + "','" + cur_stat + "')";
                     bl = clsDataAccess.RunQry(sql);

                 }
             }
             MessageBox.Show("Process Completed..", "BRAVO",MessageBoxButtons.OK,MessageBoxIcon.Information);
             btnPreview_Click(sender, e);
                
        }

        private void dgvRow_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int ri = e.RowIndex; try
            {
                if (dgvRow.Rows[ri].Cells["col_mod"].Value.ToString().ToLower() == "cheque" || dgvRow.Rows[ri].Cells["col_mod"].Value.ToString().ToLower() == "bank")
                {
                    dgvRow.Rows[ri].Cells["col_bank"].ReadOnly = false;
                    dgvRow.Rows[ri].Cells["col_instrument"].ReadOnly = false;
                }
                else
                {
                    dgvRow.Rows[ri].Cells["col_bank"].ReadOnly = true;
                    dgvRow.Rows[ri].Cells["col_instrument"].ReadOnly = true;
                }


                if (dgvRow.Rows[ri].Cells["col_lock"].Value.ToString().ToLower() == "true")
                {

                    dgvRow.Rows[ri].Cells["col_status"].ReadOnly = true;
                    dgvRow.Rows[ri].Cells["col_pdate"].ReadOnly = true;
                    dgvRow.Rows[ri].Cells["col_instrument"].ReadOnly = true;
                    dgvRow.Rows[ri].Cells["col_bank"].ReadOnly = true;
                    }
                    else
                    {
                        dgvRow.Rows[ri].Cells["col_status"].ReadOnly = false;
                        dgvRow.Rows[ri].Cells["col_pdate"].ReadOnly = false;
                        dgvRow.Rows[ri].Cells["col_instrument"].ReadOnly = false;
                        dgvRow.Rows[ri].Cells["col_bank"].ReadOnly = false;
                    }
            }
            catch { }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string head = "", val_range = "";

            //excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgvRow.Columns.Count-1;
            head = cmbcompany.Text;
            val_range = "Paid Unpaid Report for month of "+ dtpMonth.Value.ToString("MMMM-yyyy");



            excel.Cells[1, 1] = head;

            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();


            excel.Cells[2, 1] = val_range;

            range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

            range.Columns.AutoFit();
            range.Rows.AutoFit();

            excel.Cells[3, 1] = "";
            range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, iCol]);
            range.Merge(true);
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
            range.Columns.AutoFit();
            range.Rows.AutoFit();

            string[] cell_head = new string[] { };
            string old_head = "";
            int ind_st = 0, ind_fin = 0;

            for (int i = 1; i <= dgvRow.Columns.Count-1; i++)
            {
                cell_head = Convert.ToString(dgvRow.Columns[i - 1].HeaderText).Split('_');
                if (cell_head.Length > 1)
                {
                    if (old_head == cell_head[0])
                    {
                        ind_fin = i;
                        range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                        range.Merge(Type.Missing);
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = VerticalAlign.Top;
                        }
                        catch { }
                        ind_st = i;
                        excel.Cells[4, i] = cell_head[0];
                        old_head = cell_head[0];
                    }
                    excel.Cells[5, i] = cell_head[1];
                }
                else if (cell_head.Length > 0)
                {


                    excel.Cells[4, i] = dgvRow.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                        range.Merge(Type.Missing);
                        range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = VerticalAlign.Top;
                    }
                    catch { }
                }

            }
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;

            for (int i = 0; i < dgvRow.Rows.Count; i++)
            {
                for (int j = 1; j <= dgvRow.Columns.Count-1; j++)
                {
                    try
                    {
                        irw = i + 6;
                        excel.Cells[i + 6, j] = dgvRow.Rows[i].Cells[j - 1].Value.ToString();
                    }
                    catch { }
                }
            }

            object missing = System.Reflection.Missing.Value;



            range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[irw, iCol]);
            Excel.Borders borders = range.Borders;
            //Set the thick lines style.
            borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Weight = 2d;
            range.WrapText = true;

            ((Excel._Worksheet)worksheet).Activate();
            worksheet.UsedRange.Select();

            worksheet.Columns.AutoFit();

            //((Excel._Application)excel).Quit();

            MessageBox.Show("Export To Excel Completed!", "Export");
        }

        private void dgvRow_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
