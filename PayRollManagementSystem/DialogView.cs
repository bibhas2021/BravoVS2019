using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using System.Web.UI.WebControls;

namespace PayRollManagementSystem
{
    public partial class DialogView : Form
    {
        public DialogView()
        {
            InitializeComponent();
        }
        DataTable dt_val;
        EDPConnection edpcon;
        Edpcom.EDPCommon edpcom = new EDPCommon();

        public string sql_frm = "";
          public int colid=0, retval=0,retno=0;
          string qry = "";
          public object retval1, retval2, retval3, retval4, retval5, retval6, retval7, retval8, retval9, retval10;
          string columnName = "";
          public DataTable show_dr;

        public void show_data()
        {
            DataGridViewImageColumn imgc = new DataGridViewImageColumn();
            //int columnIndex = dgview.CurrentCell.ColumnIndex;

            dt_val = clsDataAccess.RunQDTbl(sql_frm);
            
           
           dgview.DataSource = dt_val;
           dgview.Columns[0].Selected = true;
           if (dt_val.Columns.Contains("IMAGE"))
            {
                dgview.Columns["IMAGE"].Width = 50;
           imgc = (DataGridViewImageColumn)dgview.Columns["IMAGE"];
           imgc.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
           dgview.AutoResizeColumns();
        }

        public void Show_D()
        {
           
            if (txtSearch.Text != "")
            {
                
                //DataRow[] dt = dt_val.Select(columnName + " like '%" + txtSearch.Text + "%'");
                dt_val.DefaultView.RowFilter = (columnName + " Like '%" + txtSearch.Text + "%'");
                // qry = sql_frm + " where (" + columnName + "='" + txtSearch.Text + "')";
            }
            else
            {
                dt_val.DefaultView.RowFilter="";
                //qry = sql_frm + " order by " + columnName;
            }
        }
        private void DialogView_Load(object sender, EventArgs e)
        {
            
            show_data();
            dgview.Columns[colid].Selected = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Show_D();
        }
        // Show_D();
        private void dgview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                columnName = dt_val.Columns[dgview.CurrentCell.ColumnIndex].ColumnName;
            }
            catch
            {
                columnName = dt_val.Columns[0].ColumnName; 
            }
        }
        public void show_data(int rw)
        {
            try
            {
                int col = 0;
                try
                {
                    retval = Convert.ToInt32(this.dgview.Rows[rw].Cells[0].Value.ToString());
                }
                catch
                {
                    retval = Convert.ToInt32(this.dgview.Rows[rw].Cells[0].Value.ToString());
                }
                for (col = 1; col < retno; col++)
                {
                    if (col == 1)
                    {
                        retval1 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 2)
                    {
                        retval2 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 3)
                    {
                        retval3 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 4)
                    {
                        retval4 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 5)
                    {
                        retval5 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 6)
                    {
                        retval6 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 7)
                    {
                        retval7 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 8)
                    {
                        retval8 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 9)
                    {
                        retval9 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                    if (col == 10)
                    {
                        retval10 = (this.dgview.Rows[rw].Cells[col].Value.ToString());
                    }
                }
                this.Close();
            }
            catch
            {

            }
        }
        private void dgview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int ind =Convert.ToInt32(dgview.CurrentCell.RowIndex);
                show_data(ind);
            }
        }

       

        private void dgview_DoubleClick(object sender, EventArgs e)
        {
            int ind = Convert.ToInt32(dgview.CurrentCell.RowIndex);
            show_data(ind);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string head = "", val_range = "";

            //excel

            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Application.Workbooks.Add(true);
            excel.Visible = true;
            int iCol = 0, irw = 0; ;
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            iCol = dgview.Columns.Count;
            head = lblCo.Text;
            val_range = lblHead.Text;

          

            excel.Cells[1, 1] = head;

            Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, iCol]);
            range.Merge(true);
            range.Font.Bold = true;


            range.HorizontalAlignment = HorizontalAlign.Center;
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

            for (int i = 1; i <= dgview.Columns.Count; i++)
            {
                cell_head = Convert.ToString(dgview.Columns[i - 1].HeaderText).Split('.');
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
                            range.HorizontalAlignment = HorizontalAlign.Center;
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


                    excel.Cells[4, i] = dgview.Columns[i - 1].HeaderText;
                    try
                    {
                        range = worksheet.get_Range(worksheet.Cells[4, i], worksheet.Cells[5, i]);
                        range.Merge(Type.Missing);
                        range.HorizontalAlignment = HorizontalAlign.Left;
                        range.VerticalAlignment = VerticalAlign.Top;
                    }
                    catch { }
                }

            }
            range = worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[5, iCol]);
            range.Font.Bold = true;

            for (int i = 0; i < dgview.Rows.Count; i++)
            {
                for (int j = 1; j <= dgview.Columns.Count; j++)
                {
                    try
                    {
                        irw = i + 6;
                        excel.Cells[i + 6, j] = dgview.Rows[i].Cells[j - 1].Value.ToString();
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

            ((Excel._Application)excel).Quit();

            MessageBox.Show("Export To Excel Completed!", "Export");


        }

       
    }
}
