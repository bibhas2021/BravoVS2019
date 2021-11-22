using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class frmInv_Rpt : Form
    {
        Edpcom.EDPCommon edpcom = new EDPCommon();
        public frmInv_Rpt( int type)
        {
            InitializeComponent();


             if (type == 1)
            {
                //this.Text = "Kit Master & Opening Entry";
                tab2.Dispose();
                cmbCompany.PopUp();
            }
            else if (type == 2)
            {
                //this.Text = "Fine Master";
                tab1.Dispose();
            }
        
        }

        string Company_id = "1";


        private void frmInv_EmpStockLedger_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2019, System.DateTime.Now.Year, 1);
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
            AttenDtTmPkr.Value = DateTime.Now;
            
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }
            if (dt.Rows.Count > 1)
            {
                cmbCompany.LookUpTable = dt;
                cmbCompany.ReturnIndex = 1;
               
            }
            else if (dt.Rows.Count == 1)
            {
                cmbCompany.Text = dt.Rows[0]["CO_Name"].ToString();
                Company_id = Convert.ToString(dt.Rows[0]["CO_Code"]);
            }
        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Company_id = Convert.ToString(cmbCompany.ReturnValue);
        }

        private void btnRptCompany_Click(object sender, EventArgs e)
        {
            Int32 intYear = 0, intYr = 0;
            String[] strArr = new String[2];
            strArr = cmbYear.Text.Split('-');
            intYear = Convert.ToInt32(strArr[0]);
            intYr = Convert.ToInt32(strArr[1]);
            string frm = "01/April/" + intYear;
            string upto = AttenDtTmPkr.Value.ToString("dd/MMMM/yyyy");

            DataTable dtStock = clsDataAccess.RunQDTbl("select CONVERT(VARCHAR(11),[EKDT],103) as [Date of Issue],"+
            "'K'+ REPLICATE('0',3-LEN(RTRIM([EKID]))) + RTRIM([EKID]) as [Transaction No],[EKEID],[EKNAME],"+
            "(Select KTNAME from MSTKIT where KTID=ek.EKKIT) as Kit,'1 '+ (select unit from MSTKIT where (KTID=ek.EKKIT)) as [Unit],"+
            "[EKAMT] as 'Value', isNull(CONVERT(VARCHAR(11),ir.retdt,103),'') as [Date of Return],isNull(ir.IssueID,'') as [Return ID] ,"+
            "isNull(RTRIM(ir.stk_rtn) + ' ' +  RTRIM(ir.runit),'0')  as [Return Unit], isNull(ramt,'0') as 'Return Value' "+
            "from tbl_Employee_KIT ek full join IssueReturn ir on ir.irid=ek.EKID  where (ek.CoID='"+cmbCompany.ReturnValue.Trim()+"') and "+
            "(ek.EKDT between '" + frm + "'and '" + upto + "') order by ek.EKDT,ek.EKEID,ek.EKKIT");

            if (dtStock.Rows.Count > 0)
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                int iCol = 0,cRow=dtStock.Rows.Count, cCol = dtStock.Columns.Count;

                excel.Cells[1, 1] = "EMPLOYEE STOCK LEDGER FROM " + Convert.ToDateTime(frm).ToString("dd/MM/yyyy") + " TO " + Convert.ToDateTime(upto).ToString("dd/MM/yyyy");
                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, cCol]);
                range.Font.Bold = true;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                excel.Cells[2, 1] = cmbCompany.Text.ToString();
                range = worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, cCol]);
                range.Font.Bold = true;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                excel.Cells[3, 1] = clsDataAccess.ReturnValue("select CO_ADD from Company where GCODE=" + cmbCompany.ReturnValue);
                range = worksheet.get_Range(worksheet.Cells[3, 1], worksheet.Cells[3, cCol]);
                range.Font.Bold = true;
                range.Merge(true);

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();
                cRow = 4;
                for (int iRow=0;iRow<dtStock.Rows.Count;iRow++)
                {
                    if (iRow == 0)
                    {
                        excel.Cells[cRow, 1] = dtStock.Columns[0].ColumnName.ToString();
                        excel.Cells[cRow, 2] = dtStock.Columns[1].ColumnName.ToString();
                        excel.Cells[cRow, 3] = dtStock.Columns[2].ColumnName.ToString();
                        excel.Cells[cRow, 4] = dtStock.Columns[3].ColumnName.ToString();
                        excel.Cells[cRow, 5] = dtStock.Columns[4].ColumnName.ToString();
                        excel.Cells[cRow, 6] = dtStock.Columns[5].ColumnName.ToString();
                        excel.Cells[cRow, 7] = dtStock.Columns[6].ColumnName.ToString();
                        excel.Cells[cRow, 8] = dtStock.Columns[7].ColumnName.ToString();
                        excel.Cells[cRow, 9] = dtStock.Columns[8].ColumnName.ToString();
                        excel.Cells[cRow, 10] = dtStock.Columns[9].ColumnName.ToString();
                        excel.Cells[cRow, 11] = dtStock.Columns[10].ColumnName.ToString();

                        range = worksheet.get_Range(worksheet.Cells[cRow, 1], worksheet.Cells[cRow, cCol]);
                        range.Font.Bold = true;
                        
                        cRow++;
                    }
                   excel.Cells[cRow, 1] = dtStock.Rows[iRow][0].ToString();
                   excel.Cells[cRow, 2] = dtStock.Rows[iRow][1].ToString();
                   excel.Cells[cRow, 3] = dtStock.Rows[iRow][2].ToString();
                   excel.Cells[cRow, 4] = dtStock.Rows[iRow][3].ToString();
                   excel.Cells[cRow, 5] = dtStock.Rows[iRow][4].ToString();
                   excel.Cells[cRow, 6] = dtStock.Rows[iRow][5].ToString();
                   excel.Cells[cRow, 7] = dtStock.Rows[iRow][6].ToString();
                   excel.Cells[cRow, 8] = dtStock.Rows[iRow][7].ToString();
                   excel.Cells[cRow, 9] = dtStock.Rows[iRow][8].ToString();
                   excel.Cells[cRow, 10] = dtStock.Rows[iRow][9].ToString();
                   excel.Cells[cRow, 11] = dtStock.Rows[iRow][10].ToString();

                   cRow++;
                }


                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[cRow, cCol]);
                range.Columns.AutoFit();
                range.Rows.AutoFit();
                range.BorderAround(Excel.XlLineStyle.xlContinuous,
        Excel.XlBorderWeight.xlThin,
        Excel.XlColorIndex.xlColorIndexNone,
        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                Excel.Borders borders = range.Borders;
                //Set the thick lines style.
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                //range.WrapText = true;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                MessageBox.Show("Export To Excel Completed!", "Export");

            }

        }



        public void get_data(DateTime ason)
        {


            Int32 intYear = 0, intYr = 0;
            String[] strArr = new String[2];
            strArr = cmbYear.Text.Split('-');
            intYear = Convert.ToInt32(strArr[0]);
            intYr = Convert.ToInt32(strArr[1]);
            string frm = "01/April/" + intYear;
            string upto = ason.ToString("dd/MMMM/yyyy");


            string qry = "";
            qry = "select KTID,KTNAME,unit as [Unit OF Measurement (UoM)],"+
            "cast(OPENING_STOCK as nvarchar) as [OPENING STOCK as on " + Convert.ToDateTime(frm).ToString("dd/MM/yyyy") + ".QTY],KTVAL as [OPENING STOCK as on " + Convert.ToDateTime(frm).ToString("dd/MM/yyyy") + ".RATE], opn_value as [OPENING STOCK as on " + Convert.ToDateTime(frm).ToString("dd/MM/yyyy") + ".AMT]," +
            "cast(PURCHASED_STOCK as nvarchar) as [PURCHASE STOCK.QTY], PURCHASED_Amt as [PURCHASE STOCK.AMT]," +
            "cast(PURCHASED_RETURN_STOCK as nvarchar) as [ISSUE STOCK RETURN.QTY], pramt as [ISSUE STOCK RETURN.AMT],"+
            
            "cast(ISSUED_STOCK as nvarchar) as [ISSUED STOCK.QTY], IssueAmt as [ISSUED STOCK.AMT]," +
            "CAST(ISSUED_RETURN_STOCK as nvarchar) as [ISSUED RETURN.QTY], Issue_Return_Amt as [ISSUED RETURN.AMT]," +
            "cast(DAMMAGED_RETURN as nvarchar) as [DAMAGED Stock.QTY], Damt as [DAMAGED Stock.AMT], " +
            "cast(((OPENING_STOCK+PURCHASED_STOCK+ISSUED_RETURN_STOCK)-(DAMMAGED_RETURN+ISSUED_STOCK+PURCHASED_RETURN_STOCK)) as nvarchar) as [CLOSING STOCK as on " + Convert.ToDateTime(upto).ToString("dd/MM/yyyy") + ".QTY], ClRate as [CLOSING STOCK as on " + Convert.ToDateTime(upto).ToString("dd/MM/yyyy") + ".RATE],"+
            "cast((((OPENING_STOCK+PURCHASED_STOCK+ISSUED_RETURN_STOCK)-(DAMMAGED_RETURN+ISSUED_STOCK+PURCHASED_RETURN_STOCK))*ClRate) as nvarchar) as [CLOSING STOCK as on " + Convert.ToDateTime(upto).ToString("dd/MM/yyyy") + ".AMT]" +

            "from (select  KTID,KTNAME,unit,opn_stock as 'OPENING_STOCK',mk.KTVAL,opn_value," +
            "isNull((select sum(stk_in) from purchase where kid=mk.KTID and p_date between '" + frm + "'and '" + upto + "'),0)as 'PURCHASED_STOCK',isNull((select sum(cast(amt as numeric(18,2))) from purchase where kid=mk.KTID and p_date between '" + frm + "'and '" + upto + "'),0)as 'PURCHASED_Amt'," +
            "isNull((select sum(stk_rtn) from purchase where kid=mk.KTID and p_date between '" + frm + "'and '" + upto + "'),0)as 'PURCHASED_RETURN_STOCK',isNull((select sum(ramt) from purchase where kid=mk.KTID and p_date between '" + frm + "'and '" + upto + "'),0)as 'pramt'," +
            "isNull((select sum(stk_rtn) from DamageReturn where kid=mk.KTID and retdt between '" + frm + "'and '" + upto + "'),0)as 'DAMMAGED_RETURN',isNull((select sum(ramt) from DamageReturn where kid=mk.KTID and retdt between '" + frm + "'and '" + upto + "'),0)as 'Damt', " +
            "(select count(EKKIT) from tbl_Employee_KIT where EKKIT=mk.KTID and  EKDT between '" + frm + "'and '" + upto + "') as 'ISSUED_STOCK',(select Sum(EKAMT) from tbl_Employee_KIT where EKKIT=mk.KTID and  EKDT between '" + frm + "'and '" + upto + "') as 'IssueAmt'," +
            "isNull((select sum(stk_rtn) from IssueReturn where kid=mk.KTID and retdt between '" + frm + "'and '" + upto + "'),0)as 'ISSUED_RETURN_STOCK',isNull((select sum(ramt) from IssueReturn where kid=mk.KTID and retdt between '" + frm + "'and '" + upto + "'),0)as 'Issue_Return_Amt',mk.clRate " +
            "from MSTKIT mk where mk.k_date between '" + frm + "'and '" + upto + "' )e";
            DataTable dtStock = clsDataAccess.RunQDTbl(qry);


            if (dtStock.Rows.Count > 0)
            {
                Excel.Application excel = new Excel.Application();
                Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
                excel.Visible = true;
                Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
                int iCol = 0, cRow = dtStock.Rows.Count, cCol = dtStock.Columns.Count;
                
                string[] cell_head = new string[] { };
                string old_head = "";
                int ind_st = 0, ind_fin = 0;

                excel.Cells[1, 1] = "PERIODIC STOCK STATEMENT FROM " + Convert.ToDateTime(frm).ToString("dd/MM/yyyy") + " TO " + Convert.ToDateTime(upto).ToString("dd/MM/yyyy");
                Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, cCol]);
                range.Font.Bold = true;
                range.Merge(true);
                
                range.Font.Size = 10;

                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                range.Columns.AutoFit();
                range.Rows.AutoFit();

                
                cRow = 2;


                for (int i = 1; i <= cCol; i++)
                {
                    cell_head = Convert.ToString(dtStock.Columns[i - 1].ColumnName).Split('.');
                    if (cell_head.Length > 1)
                    {
                        if (old_head == cell_head[0])
                        {
                            ind_fin = i;
                            try
                            {
                                range = worksheet.get_Range(worksheet.Cells[2, ind_st], worksheet.Cells[2, ind_fin]);
                                range.Merge(Type.Missing);
                                range.WrapText = true;
                                range.Font.Bold = true;
                                range.Font.Size = 8;
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;// Excel.XlHAlign.xlHAlignCenter;
                                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;


                                range = worksheet.get_Range(worksheet.Cells[3, ind_st], worksheet.Cells[3, ind_fin]);
                                //range.Merge(Type.Missing);

                                //range.WrapText = true;
                                range.Font.Bold = true;
                                range.Font.Size = 8;

                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;// Excel.XlHAlign.xlHAlignCenter;
                                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
 
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                range = worksheet.get_Range(worksheet.Cells[3, ind_st], worksheet.Cells[3, ind_fin]);
                                //range.Merge(Type.Missing);

                                range.WrapText = true;
                                range.Font.Bold = true;
                                range.Font.Size = 8;
                                
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;// Excel.XlHAlign.xlHAlignCenter;
                                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                            }
                            catch { }
                            ind_st = i;
                            excel.Cells[2, i] = cell_head[0];
                            old_head = cell_head[0];
                        }
                        excel.Cells[3, i] = cell_head[1];
                    }
                    else if (cell_head.Length > 0)
                    {


                        excel.Cells[2, i] = dtStock.Columns[i - 1].ColumnName;
                        try
                        {
                            range = worksheet.get_Range(worksheet.Cells[2, i], worksheet.Cells[3, i]);
                            range.Merge(Type.Missing);
                            //range.Height = 50;
                            //range.Cells.Width = 75;
                            range.WrapText = true;
                            range.Font.Bold = true;
                            range.Font.Size = 8;
                            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;//System.Web.UI.WebControls.HorizontalAlign.Left;
                            range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;
                        }
                        catch { }
                    }

                }

                cRow = 4;
                for (int iRow = 0; iRow < dtStock.Rows.Count; iRow++)
                {
                    for (iCol = 0; iCol < cCol; iCol++)
                    {
                        excel.Cells[cRow, iCol + 1] = dtStock.Rows[iRow][iCol].ToString();

                    }

                    cRow++;
                }


                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[cRow, cCol]);
                
                //range.Font.Size = 8;
                
                range.BorderAround(Excel.XlLineStyle.xlContinuous,
        Excel.XlBorderWeight.xlThin,
        Excel.XlColorIndex.xlColorIndexNone,
        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(178, 178, 178)));
                Excel.Borders borders = range.Borders;
                //Set the thick lines style.
                borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                //range.WrapText = true;
                range.VerticalAlignment = System.Web.UI.WebControls.VerticalAlign.Middle;

                MessageBox.Show("Export To Excel Completed!", "Export");

            }



            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dt.Rows[i]["OPENING_STOCK"] = dt.Rows[i]["OPENING_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["PURCHASED_STOCK"] = dt.Rows[i]["PURCHASED_STOCK"] + " " + clsDataAccess.GetresultS("select unit from purchase where kid='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["ISSUED_STOCK"] = dt.Rows[i]["ISSUED_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["PURCHASED_RETURN_STOCK"] = dt.Rows[i]["PURCHASED_RETURN_STOCK"] + " " + clsDataAccess.GetresultS("select unit from purchase where kid='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["ISSUED_RETURN_STOCK"] = dt.Rows[i]["ISSUED_RETURN_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["CLOSING_STOCK"] = dt.Rows[i]["CLOSING_STOCK"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");
            //    dt.Rows[i]["DAMMAGED_RETURN"] = dt.Rows[i]["DAMMAGED_RETURN"] + " " + clsDataAccess.GetresultS("select unit from MSTKIT where KTID='" + dt.Rows[i]["KTID"] + "'");

            //}

            //dgv_clstk.DataSource = dt;


            //dgv_clstk.Columns["OPENING_STOCK"].ReadOnly = true;
            //dgv_clstk.Columns["PURCHASED_STOCK"].ReadOnly = true;
            //dgv_clstk.Columns["ISSUED_STOCK"].ReadOnly = true;
            //dgv_clstk.Columns["PURCHASED_RETURN_STOCK"].ReadOnly = true;
            //dgv_clstk.Columns["ISSUED_RETURN_STOCK"].ReadOnly = true;
            //dgv_clstk.Columns["CLOSING_STOCK"].ReadOnly = true;
            //dgv_clstk.Columns["DAMMAGED_RETURN"].ReadOnly = true;

            //dgv_clstk.Columns["ClRate"].ReadOnly = false;
            //dgv_clstk.Columns["KTID"].Visible = false;
        }

        private void btnValuation_Click(object sender, EventArgs e)
        {
            get_data(AttenDtTmPkr.Value);
        }


    }
}
