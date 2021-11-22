using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmBillOpening : Form
    {
        public frmBillOpening()
        {
            InitializeComponent();
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

        private void frmBillOpening_Load(object sender, EventArgs e)
        {
           
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);


            if (dtpMonth.Value.Month>=4)
                dtpMonth.Value = Convert.ToDateTime("01/April/" + dtpMonth.Value.Year);
            else
                dtpMonth.Value = Convert.ToDateTime("01/April/" + dtpMonth.Value.AddYears(-1));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int opid = 0, clid=0, locid=0,coid=1;string month="", sess="",values="",sql="",op_id=""; double opBill=0, opPay=0, opTds=0, opOth=0, opNetLedger=0;

            coid = Convert.ToInt32(cmbcompany.ReturnValue);

            month = dtpMonth.Text; sess = cmbYear.Text;
            if (dgvOpening.Rows.Count > 0)
            {
                for (int idx = 0; idx < dgvOpening.Rows.Count; idx++)
                {
                    opid = 0; clid=0; locid=0;
                    opBill=0; opPay=0; opTds=0; opOth=0; opNetLedger=0;

                       clid=Convert.ToInt32(dgvOpening.Rows[idx].Cells["col_clid"].Value);
                       locid= Convert.ToInt32(dgvOpening.Rows[idx].Cells["col_locid"].Value);
                       opBill=Convert.ToDouble( dgvOpening.Rows[idx].Cells["col_op_Bill"].Value);
                       opPay= Convert.ToDouble(dgvOpening.Rows[idx].Cells["col_op_Pay"].Value);
                       opTds= Convert.ToDouble(dgvOpening.Rows[idx].Cells["col_op_Tds"].Value);
                       opOth= Convert.ToDouble(dgvOpening.Rows[idx].Cells["col_op_Oth"].Value);
                       opNetLedger = Convert.ToDouble(dgvOpening.Rows[idx].Cells["col_op_net_ledger"].Value);
                       opid =  Convert.ToInt32(dgvOpening.Rows[idx].Cells["col_opid"].Value);
                       if (opid == 0)
                       {
                           try
                           {
                               opid = idx + 1;//Convert.ToInt32(clsDataAccess.ReturnValue("select ISNULL(max(opid),0)+1 from tbl_op_balance"));
                               op_id = "(select ISNULL(max(opid),0)+1 from tbl_op_balance)";
                           }
                           catch { opid = 1; }
                       }
                       //if  (opBill>0 || opPay>0 || opTds>0 || opOth>0 || opNetLedger>0)
                       //{
                           if (values == "")
                           {
                               values="("+opid+",'"+month+"','"+sess+"','"+clid+"','"+locid+"','"+coid+"','"+opBill+"','"+opPay+"','"+opTds+"','"+opOth+"','"+opNetLedger+"')";
                           }
                           else
                           {
                               values = values + ",(" + opid + ",'" + month + "','" + sess + "','" + clid + "','" + locid + "','"+ coid +"','" + opBill + "','" + opPay + "','" + opTds + "','" + opOth + "','" + opNetLedger + "')";
                           }
                       //}

                }

            }
            
            if (values.Trim() != "")
            {
                sql = "delete from tbl_op_balance where  (sess='" + sess + "') and (coid='"+coid+"')";
                bool bl = clsDataAccess.RunQry(sql);
                //if (bl == true)
                //{
                    sql = "INSERT INTO tbl_op_balance(opid,month,sess,clid,locid,coid,opBill,opPay,opTds,opOth,opNetLedger) VALUES " + values;
                  bl=  clsDataAccess.RunQry(sql);

                  if (bl == true)
                  {
                      ERPMessageBox.ERPMessage.Show("Balance Saved Successfully.");
                      chk_val();
                  }
            }
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }

        }

        public void chk_val()
        {
            string sql = "";
            int idx = 0, coid = 1;

            coid = Convert.ToInt32(cmbcompany.ReturnValue);
            DataTable dt_amt = new DataTable();

            DataTable dt = clsDataAccess.RunQDTbl("SELECT ec.Client_Name + CHAR(13) + CHAR(10) + '['+ el.Location_Name + ']' as 'client_location', el.Cliant_ID as 'clid',el.Location_ID as 'locid',ec.GSTINNO as 'gstin',ec.Client_State as 'stcode'," +
            " 0 AS 'opBill',0 as 'opPay', 0 AS 'opTds', 0 AS 'opOth', 0 AS 'opLedger',0 as 'opid' FROM tbl_Employee_CliantMaster AS ec INNER JOIN tbl_Emp_Location AS el ON ec.Client_id = el.Cliant_ID WHERE (ec.coid = " + coid + ") order by client_location");
            while (idx < dt.Rows.Count)
            {

                sql = "SELECT opid,isNull(opBill,0)opBill,isNull(opPay,0)opPay,isNull(opTds,0)opTds,isNull(opOth,0)opOth,isNull(opNetLedger,0)opLedger FROM tbl_op_balance where (clid=" + dt.Rows[idx]["clid"].ToString() + ") and (locid=" + dt.Rows[idx]["locid"].ToString() + ") and (coid='" + coid + "') and (month='" + dtpMonth.Text + "') and (sess='" + cmbYear.Text + "')";
                dt_amt = clsDataAccess.RunQDTbl(sql);

                if (dt_amt.Rows.Count > 0)
                {
                    dt.Rows[idx]["opBill"] = dt_amt.Rows[0]["opBill"];
                    dt.Rows[idx]["opPay"] = dt_amt.Rows[0]["opPay"];
                    dt.Rows[idx]["opTds"] = dt_amt.Rows[0]["opTds"];
                    dt.Rows[idx]["opOth"] = dt_amt.Rows[0]["opOth"];
                    dt.Rows[idx]["opLedger"] = dt_amt.Rows[0]["opLedger"];
                    dt.Rows[idx]["opid"] = dt_amt.Rows[0]["opid"];
                }

                idx++;
            }
            dgvOpening.DataSource = dt;
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            chk_val();
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
            iCol = dgvOpening.Columns.Count - 1;
            head = cmbcompany.Text;
            val_range = "Opening Unadjusted Balance for the session : "+ cmbYear.Text;



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

            for (int i = 1; i <= dgvOpening.Columns.Count - 1; i++)
            {
                cell_head = Convert.ToString(dgvOpening.Columns[i - 1].HeaderText).Split('_');
                if (cell_head.Length > 1)
                {
                    if (old_head == cell_head[0])
                    {
                        ind_fin = i;
                    }
                    else
                    {
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[4, ind_st], worksheet.Cells[4, ind_fin]);
                            range.Merge(Type.Missing);
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
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


                    excel.Cells[4, i] = dgvOpening.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                        range.Merge(Type.Missing);
                        range.HorizontalAlignment = System.Web.UI.WebControls.HorizontalAlign.Left;
                        range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                    }
                    catch { }
                }

            }
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;

            for (int i = 0; i < dgvOpening.Rows.Count; i++)
            {
                for (int j = 1; j <= dgvOpening.Columns.Count - 1; j++)
                {
                    try
                    {
                        irw = i + 6;
                        excel.Cells[i + 6, j] = dgvOpening.Rows[i].Cells[j - 1].Value.ToString();
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

        private void dgvOpening_KeyUp(object sender, KeyEventArgs e)
        {
            int cl = dgvOpening.CurrentCell.ColumnIndex;
            int rw = dgvOpening.CurrentCell.RowIndex;


            if ((cl == dgvOpening.Columns["col_op_bill"].Index) || (cl == dgvOpening.Columns["col_op_pay"].Index) ||
                (cl == dgvOpening.Columns["col_op_tds"].Index) || (cl == dgvOpening.Columns["col_op_oth"].Index) || (cl == dgvOpening.Columns["col_op_net_ledger"].Index))
            {
                try
                {
                    dgvOpening.Rows[rw].Cells["col_op_net_ledger"].Value = Convert.ToDouble(dgvOpening.Rows[rw].Cells["col_op_bill"].Value) - 
                        (Convert.ToDouble(dgvOpening.Rows[rw].Cells["col_op_pay"].Value )+ Convert.ToDouble(dgvOpening.Rows[rw].Cells["col_op_tds"].Value ) + Convert.ToDouble(dgvOpening.Rows[rw].Cells["col_op_oth"].Value ));
                }
                catch{dgvOpening.Rows[rw].Cells["col_op_net_ledger"].Value = "0";}
                    //col_op_bill

                    //col_op_pay
                    //col_op_tds
                    //col_op_oth


                    //col_op_net_ledger
            }
        }
    }
}
