using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;




namespace PayRollManagementSystem
{
    public partial class Bill_SalaryForm : Form
    {
        DataTable dt_bill; DataTable dt_nett; DataTable dt_gross; DataTable dt_gec; 
        string qry = "";

        DataGridViewRow dgRowTotalCount = new DataGridViewRow();
        DataTable rpt_sal = new DataTable();
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        public Bill_SalaryForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Bill_view()
        {

            DataTable dt_bill = new DataTable();


            DataTable DTResource = new DataTable();
            DataColumn myDataColumn;
           // CultureInfo cultureInfo = new CultureInfo("en-IN");
            //myDataColumn = new DataColumn();
            //myDataColumn.DataType = Type.GetType("System.String");
            //myDataColumn.ColumnName = "Location";
            //DTResource.Columns.Add(myDataColumn);


            for (int i = 0; i < listBox1.Items.Count; i++)
            {

                myDataColumn = new DataColumn();
                myDataColumn.DataType = Type.GetType("System.String");
                myDataColumn.ColumnName = listBox1.Items[i].ToString();
                DTResource.Columns.Add(myDataColumn);

            }
            string sp = "";
            

            


            if (edpcom.CurrentLocation.Trim() != "")
            {

                rpt_sal = clsDataAccess.RunQDTbl("select  DISTINCT ltrim(rtrim(Location_Name)) as Location from tbl_Emp_Location where Location_ID in (" + edpcom.CurrentLocation + ") ");
                
            }
            else
            {
                rpt_sal = clsDataAccess.RunQDTbl("select  DISTINCT ltrim(rtrim(Location_Name)) as Location from tbl_Emp_Location ");
            }

            for (int k = 0; k < DTResource.Columns.Count; k++)
            {

                sp = DTResource.Columns[k].ToString();
                rpt_sal.Columns.Add(sp);


                // qry = "select a.Location_Name,b.TotAMT AS 'April' from paybill b,tbl_Emp_Location a where a.Location_ID=b.Location_ID AND(upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = dt)";
                //qry = "select (a.TotAMT+a.ServiceAmount)  as sp  ,a.Month,c.Location_Name as Location from paybill a, tbl_Employee_CliantMaster b,tbl_Emp_Location C  where a.Cliant_ID=b.Client_id     AND a.Location_ID=c.Location_ID AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + ch.Name + "') AND (a.Session ='" + cmbYear.Text + "') ";

                qry = " select  DISTINCT  ltrim(rtrim(Location_Name)) as Location,(b.TotAMT) AS '" + sp + "' from tbl_Emp_Location a ,paybill b where a.Location_ID=b.Location_ID AND  (DATENAME(MONTH,Cast('01-'+[Month] as datetime)) = '" + sp + "') AND (b.Session ='" + cmbYear.Text + "') and a.Location_ID in (" + edpcom.CurrentLocation + ")  order by b.TotAMT ";

                dt_bill = clsDataAccess.RunQDTbl(qry);
                for (int j = 0; j < rpt_sal.Rows.Count; j++)
                {
                    for (int m = 0; m < dt_bill.Rows.Count; m++)
                    {
                        if (rpt_sal.Rows[j]["Location"].Equals(dt_bill.Rows[m]["Location"]))
                        {
                            rpt_sal.Rows[j][sp] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(dt_bill.Rows[m][sp])))))));
                            break;
                        }
                    }
                }

            }


            rpt_sal.Columns.Add("Total");
            double rowTotal = 0;
            for (int ind = 0; ind < rpt_sal.Rows.Count; ind++)
            {
                rowTotal = 0;
                for (int cr = 1; cr < rpt_sal.Columns.Count; cr++)
                {


                    try
                    {

                        rowTotal = rowTotal + Convert.ToDouble(rpt_sal.Rows[ind][cr]);

                    }
                    catch
                    {
                        rpt_sal.Rows[ind][cr] = "0";
                        rowTotal = rowTotal + 0;
                    }


                }
                if (checkBox1.Checked == true)
                {
                    if (rowTotal == 0)
                    {
                        rpt_sal.Rows.RemoveAt(ind);
                        ind--;
                    }
                    else
                    {
                        rpt_sal.Rows[ind]["Total"] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal))));
                    }
                }
                else
                {
                    rpt_sal.Rows[ind]["Total"] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal))));

                }
            }



            DataRow totalsRow = rpt_sal.NewRow();
            totalsRow["Location"] = "Total :";
            for (int c = 1; c < rpt_sal.Columns.Count; c++)
            {
                double colTotal = 0;
                for (int r = 0; r < rpt_sal.Rows.Count; r++)
                {
                    try
                    {


                        colTotal = colTotal + Convert.ToDouble(rpt_sal.Rows[r][c]);

                    }
                    catch
                    {
                        colTotal = colTotal + 0;
                    }
                }
                totalsRow[c] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(colTotal))));
            }
            rpt_sal.Rows.Add(totalsRow);

                        
        

            dgv_show.DataSource = rpt_sal;

            
            dgv_show.Columns[0].Width = 248;
            dgv_show.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            for (int b = 1; b < dgv_show.Columns.Count; b++)
            {
                dgv_show.Columns[b].Width = 57;
                dgv_show.Columns[b].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            //dgv_show.AutoResizeColumns();
            

            DataTable dt6 = new DataTable();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Columns.Add();
            dt6.Rows.Add();

            dt6.Rows[0][0] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][0];
            dt6.Rows[0][1] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][1];
            dt6.Rows[0][2] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][2];
            dt6.Rows[0][3] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][3];
            dt6.Rows[0][4] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][4];
            dt6.Rows[0][5] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][5];
            dt6.Rows[0][6] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][6];
            dt6.Rows[0][7] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][7];
            dt6.Rows[0][8] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][8];
            dt6.Rows[0][9] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][9];
            dt6.Rows[0][10] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][10];
            dt6.Rows[0][11] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][11];
            dt6.Rows[0][12] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][12];
            dt6.Rows[0][13] = rpt_sal.Rows[rpt_sal.Rows.Count - 1][13];

            rpt_sal.Rows.RemoveAt(rpt_sal.Rows.Count - 1);
            dgv_show2.DataSource = dt6;

            dgv_show2.Columns[0].Width = 248;
            dgv_show2.Columns[1].Width = 57;
            dgv_show2.Columns[2].Width = 57;
            dgv_show2.Columns[3].Width = 57;
            dgv_show2.Columns[4].Width = 57;
            dgv_show2.Columns[5].Width = 57;
            dgv_show2.Columns[6].Width = 57;
            dgv_show2.Columns[7].Width = 57;
            dgv_show2.Columns[8].Width = 57;
            dgv_show2.Columns[9].Width = 57;
            dgv_show2.Columns[10].Width = 57;
            dgv_show2.Columns[11].Width = 57;
            dgv_show2.Columns[12].Width = 57;
            dgv_show2.Columns[13].Width = 57;

            dgv_show2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_show.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_show.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          



       }

                




        //---------------------------------------------end of bill------------------------------------------------------//
        public void Nett_view()
        {

            DataTable dt_nett = new DataTable();


            DataTable DTResource1 = new DataTable();
            DataColumn myDataColumn1;
           // CultureInfo cultureInfo = new CultureInfo("en-IN");


            for (int i = 0; i < listBox1.Items.Count; i++)
            {

                myDataColumn1 = new DataColumn();
                myDataColumn1.DataType = Type.GetType("System.String");
                myDataColumn1.ColumnName = listBox1.Items[i].ToString();
                DTResource1.Columns.Add(myDataColumn1);

            }
            string sn = "";
            DataTable rpt_nett = new DataTable();

            rpt_nett = clsDataAccess.RunQDTbl("select  DISTINCT ltrim(rtrim(Location_Name)) as Location from tbl_Emp_Location where Location_ID in (" + edpcom.CurrentLocation + ")  ");



            for (int k = 0; k < DTResource1.Columns.Count; k++)
            {

                sn = DTResource1.Columns[k].ToString();
                rpt_nett.Columns.Add(sn);


                // qry = "select a.Location_Name,b.TotAMT AS 'April' from paybill b,tbl_Emp_Location a where a.Location_ID=b.Location_ID AND(upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = dt)";
                //qry = "select (a.TotAMT+a.ServiceAmount)  as sp  ,a.Month,c.Location_Name as Location from paybill a, tbl_Employee_CliantMaster b,tbl_Emp_Location C  where a.Cliant_ID=b.Client_id     AND a.Location_ID=c.Location_ID AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + ch.Name + "') AND (a.Session ='" + cmbYear.Text + "') ";

                qry = "select  DISTINCT  ltrim(rtrim(Location_Name)) as Location,SUM(b.NetPay) AS '" + sn + "' from tbl_Emp_Location a ,tbl_Employee_SalaryMast b where a.Location_ID=b.Location_id AND  (b.Month = '" + sn + "') AND (b.Session ='" + cmbYear.Text + "') and a.Location_ID in (" + edpcom.CurrentLocation + ")  GROUP BY Location_Name,Month, Session";

                dt_nett = clsDataAccess.RunQDTbl(qry);
                for (int j = 0; j < rpt_nett.Rows.Count; j++)
                {
                    for (int m = 0; m < dt_nett.Rows.Count; m++)
                    {
                        if (rpt_nett.Rows[j]["Location"].Equals(dt_nett.Rows[m]["Location"]))
                        {
                            rpt_nett.Rows[j][sn] = string.Format("{0:n0}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(dt_nett.Rows[m][sn])))))));

                            break;
                        }
                    }
                }

            }


            rpt_nett.Columns.Add("Total");
            double rowTotal = 0;
            for (int ind = 0; ind < rpt_nett.Rows.Count; ind++)
            {
                rowTotal = 0;
                for (int cr = 1; cr < rpt_nett.Columns.Count; cr++)
                {


                    try
                    {

                        rowTotal = rowTotal + Convert.ToDouble(rpt_nett.Rows[ind][cr]);
                    }
                    catch
                    {
                        rpt_nett.Rows[ind][cr] = "0";
                        rowTotal = rowTotal + 0;
                    }

                }
                if (checkBox1.Checked == true)
                {
                    if (rowTotal == 0)
                    {
                        rpt_nett.Rows.RemoveAt(ind);
                        ind--;
                    }
                    else
                    {
                        rpt_nett.Rows[ind]["Total"] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal))));
                    }
                }
                else
                {
                    rpt_nett.Rows[ind]["Total"] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal))));

                }
                //rpt_nett.Rows[ind]["Total"] = string.Format("{0:0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal)))); 
            }


            DataRow totalsRow = rpt_nett.NewRow();
            totalsRow["Location"] = "Total :";
            for (int c = 1; c < rpt_nett.Columns.Count; c++)
            {
                double colTotal = 0;
                for (int r = 0; r < rpt_nett.Rows.Count; r++)
                {
                    try
                    {


                        colTotal = colTotal + Convert.ToDouble(rpt_nett.Rows[r][c]);

                    }
                    catch
                    {
                        colTotal = colTotal + 0;
                    }
                }
                totalsRow[c] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(colTotal))));

            }
            rpt_nett.Rows.Add(totalsRow);


            dgv_show1.DataSource = rpt_nett;

            dgv_show1.Columns[0].Width = 248;

            for (int p = 1; p < dgv_show1.Columns.Count; p++)
            {
                dgv_show1.Columns[p].Width = 57;
            }

            dgv_show1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataTable dt7 = new DataTable();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Columns.Add();
            dt7.Rows.Add();

            dt7.Rows[0][0] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][0];
            dt7.Rows[0][1] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][1];
            dt7.Rows[0][2] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][2];
            dt7.Rows[0][3] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][3];
            dt7.Rows[0][4] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][4];
            dt7.Rows[0][5] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][5];
            dt7.Rows[0][6] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][6];
            dt7.Rows[0][7] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][7];
            dt7.Rows[0][8] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][8];
            dt7.Rows[0][9] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][9];
            dt7.Rows[0][10] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][10];
            dt7.Rows[0][11] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][11];
            dt7.Rows[0][12] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][12];
            dt7.Rows[0][13] = rpt_nett.Rows[rpt_nett.Rows.Count - 1][13];

            rpt_nett.Rows.RemoveAt(rpt_nett.Rows.Count - 1);
            dgv_show3.DataSource = dt7;

            dgv_show3.Columns[0].Width = 248;
            dgv_show3.Columns[1].Width = 57;
            dgv_show3.Columns[2].Width = 57;
            dgv_show3.Columns[3].Width = 57;
            dgv_show3.Columns[4].Width = 57;
            dgv_show3.Columns[5].Width = 57;
            dgv_show3.Columns[6].Width = 57;
            dgv_show3.Columns[7].Width = 57;
            dgv_show3.Columns[8].Width = 57;
            dgv_show3.Columns[9].Width = 57;
            dgv_show3.Columns[10].Width = 57;
            dgv_show3.Columns[11].Width = 57;
            dgv_show3.Columns[12].Width = 57;
            dgv_show3.Columns[13].Width = 57;

            dgv_show3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
          



        }
        //-----------------------------------------------end of nett sal-----------------------------------------------//
        public void Gross_view()
        {

            DataTable dt_gross = new DataTable();


            DataTable DTResource2 = new DataTable();
            DataColumn myDataColumn2;

          //  CultureInfo cultureInfo = new CultureInfo("en-IN");

            for (int i = 0; i < listBox1.Items.Count; i++)
            {

                myDataColumn2 = new DataColumn();
                myDataColumn2.DataType = Type.GetType("System.String");
                myDataColumn2.ColumnName = listBox1.Items[i].ToString();
                DTResource2.Columns.Add(myDataColumn2);

            }
            string sg = "";
            DataTable rpt_gross = new DataTable();

            rpt_gross = clsDataAccess.RunQDTbl("select  DISTINCT ltrim(rtrim(Location_Name)) as Location from tbl_Emp_Location where Location_ID in (" + edpcom.CurrentLocation + ")  ");



            for (int k = 0; k < DTResource2.Columns.Count; k++)
            {

                sg = DTResource2.Columns[k].ToString();
                rpt_gross.Columns.Add(sg);


                //qry = "select (a.TotAMT+a.ServiceAmount)  as sp  ,a.Month,c.Location_Name as Location from paybill a, tbl_Employee_CliantMaster b,tbl_Emp_Location C  where a.Cliant_ID=b.Client_id     AND a.Location_ID=c.Location_ID AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + ch.Name + "') AND (a.Session ='" + cmbYear.Text + "') ";

                qry = "select  DISTINCT  ltrim(rtrim(Location_Name)) as Location,SUM(b.GrossAmount) AS '" + sg + "' from tbl_Emp_Location a ,tbl_Employee_SalaryMast b where a.Location_ID=b.Location_id AND  (b.Month = '" + sg + "') AND (b.Session ='" + cmbYear.Text + "') and a.Location_ID in (" + edpcom.CurrentLocation + ")  GROUP BY Month, Session,Location_Name";

                dt_gross = clsDataAccess.RunQDTbl(qry);
                for (int j = 0; j < rpt_gross.Rows.Count; j++)
                {
                    for (int m = 0; m < dt_gross.Rows.Count; m++)
                    {
                        if (rpt_gross.Rows[j]["Location"].Equals(dt_gross.Rows[m]["Location"]))
                        {
                            rpt_gross.Rows[j][sg] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(dt_gross.Rows[m][sg])))))));

                            break;
                        }
                    }
                }

            }


            rpt_gross.Columns.Add("Total");
            double rowTotal = 0;
            for (int ind = 0; ind < rpt_gross.Rows.Count; ind++)
            {
                rowTotal = 0;
                for (int cr = 1; cr < rpt_gross.Columns.Count; cr++)
                {


                    try
                    {

                        rowTotal = rowTotal + Convert.ToDouble(rpt_gross.Rows[ind][cr]);
                    }
                    catch
                    {
                        rpt_gross.Rows[ind][cr] = "0";
                        rowTotal = rowTotal + 0;
                    }

                }
                if (checkBox1.Checked == true)
                {
                    if (rowTotal == 0)
                    {
                        rpt_gross.Rows.RemoveAt(ind);
                        ind--;
                    }
                    else
                    {
                        rpt_gross.Rows[ind]["Total"] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal))));
                    }
                }
                else
                {
                    rpt_gross.Rows[ind]["Total"] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal))));

                }

            }


            DataRow totalsRow = rpt_gross.NewRow();
            totalsRow["Location"] = "Total :";
            for (int c = 1; c < rpt_gross.Columns.Count; c++)
            {
                double colTotal = 0;
                for (int r = 0; r < rpt_gross.Rows.Count; r++)
                {
                    try
                    {


                        colTotal = colTotal + Convert.ToDouble(rpt_gross.Rows[r][c]);

                    }
                    catch
                    {
                        colTotal = colTotal + 0;
                    }
                }
                totalsRow[c] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(colTotal))));

            }
            rpt_gross.Rows.Add(totalsRow);

            dgv_show1.DataSource = rpt_gross;


            dgv_show1.Columns[0].Width = 248;

            for (int q = 1; q < dgv_show1.Columns.Count; q++)
            {
                dgv_show1.Columns[q].Width = 57;
            }


            dgv_show1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataTable dt8 = new DataTable();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Columns.Add();
            dt8.Rows.Add();

            dt8.Rows[0][0] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][0];
            dt8.Rows[0][1] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][1];
            dt8.Rows[0][2] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][2];
            dt8.Rows[0][3] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][3];
            dt8.Rows[0][4] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][4];
            dt8.Rows[0][5] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][5];
            dt8.Rows[0][6] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][6];
            dt8.Rows[0][7] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][7];
            dt8.Rows[0][8] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][8];
            dt8.Rows[0][9] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][9];
            dt8.Rows[0][10] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][10];
            dt8.Rows[0][11] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][11];
            dt8.Rows[0][12] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][12];
            dt8.Rows[0][13] = rpt_gross.Rows[rpt_gross.Rows.Count - 1][13];

            rpt_gross.Rows.RemoveAt(rpt_gross.Rows.Count - 1);

            dgv_show3.DataSource = dt8;

            dgv_show3.Columns[0].Width = 248;
            dgv_show3.Columns[1].Width = 57;
            dgv_show3.Columns[2].Width = 57;
            dgv_show3.Columns[3].Width = 57;
            dgv_show3.Columns[4].Width = 57;
            dgv_show3.Columns[5].Width = 57;
            dgv_show3.Columns[6].Width = 57;
            dgv_show3.Columns[7].Width = 57;
            dgv_show3.Columns[8].Width = 57;
            dgv_show3.Columns[9].Width = 57;
            dgv_show3.Columns[10].Width = 57;
            dgv_show3.Columns[11].Width = 57;
            dgv_show3.Columns[12].Width = 57;
            dgv_show3.Columns[13].Width = 57;

            dgv_show3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
          



            
        }

        //----------------------------------------------end of gross sal------------------------------------------------//

        public void gec_view()
        {

            DataTable dt_gec = new DataTable();


            DataTable DTResource3 = new DataTable();
            DataColumn myDataColumn3;
            //CultureInfo cultureInfo = new CultureInfo("en-IN");


            for (int i = 0; i < listBox1.Items.Count; i++)
            {

                myDataColumn3 = new DataColumn();
                myDataColumn3.DataType = Type.GetType("System.String");
                myDataColumn3.ColumnName = listBox1.Items[i].ToString();
                DTResource3.Columns.Add(myDataColumn3);

            }
            string sc = "",mmyy="";
            DataTable rpt_gec = new DataTable();
            string[] yy=cmbYear.Text.Split('-');
            rpt_gec = clsDataAccess.RunQDTbl("select  DISTINCT ltrim(rtrim(Location_Name)) as Location from tbl_Emp_Location where Location_ID in (" + edpcom.CurrentLocation + ")  ");

            for (int k = 0; k < DTResource3.Columns.Count; k++)
            {
                sc = DTResource3.Columns[k].ToString();
                if (k >8)
                {
                    mmyy = sc.Trim() + " - " + yy[1].ToString().Trim();
                }
                else
                {
                    mmyy = sc.Trim() + " - " + yy[0].ToString().Trim();

                }
                rpt_gec.Columns.Add(sc);


                //qry = "select (a.TotAMT+a.ServiceAmount)  as sp  ,a.Month,c.Location_Name as Location from paybill a, tbl_Employee_CliantMaster b,tbl_Emp_Location C  where a.Cliant_ID=b.Client_id     AND a.Location_ID=c.Location_ID AND  (upper(DATENAME(MONTH,Cast('01-'+[Month] as datetime))) = '" + ch.Name + "') AND (a.Session ='" + cmbYear.Text + "') ";

                //qry = "select  DISTINCT  ltrim(rtrim(Location_Name)) as Location,(b.GrossAmount + c.esi_employer_cont+c.pf_employer_cont) AS '" + sc + "' from tbl_Emp_Location a ,tbl_Employee_SalaryMast b,tbl_employers_contribution c where a.Location_ID=b.Location_id AND b.Emp_Id=c.Emp_Id AND (b.Month = '" + sc + "') AND (b.Session ='" + cmbYear.Text + "')group by a.Location_Name,b.GrossAmount,c.esi_employer_cont,c.pf_employer_cont";

                qry = "select (select ltrim(rtrim(Location_Name)) as Loc from tbl_Emp_Location a where Location_ID=b.Location_id) as [Location], ISNULL( SUM(b.GrossAmount)+ isNull((select sum(c.pf+c.pf_employer_cont + c.esi_employer_cont) from tbl_employers_contribution c where (c.Month = '" + mmyy.Trim() + "') AND (c.Session ='" + cmbYear.Text + "') and (c.lid=b.Location_id)),'0' ),'0') as '" + sc.Trim() + "' from tbl_Employee_SalaryMast b where (b.Month = '" + sc + "') AND (b.Session ='" + cmbYear.Text + "') and a.Location_ID in (" + edpcom.CurrentLocation + ")  group by b.Location_id";
                
                    
                //    "select  DISTINCT  ltrim(rtrim(Location_Name)) as Location,sum(b.GrossAmount + c.pf + c.pf_employer_cont + c.esi_employer_cont+ d.Amount) AS '" + sc + "' from tbl_Emp_Location a ,tbl_Employee_SalaryMast b,tbl_employers_contribution c, tbl_Employee_SalaryDet d,tbl_Employee_SalaryStructure e where a.Location_ID=b.Location_id AND b.Emp_Id=c.Emp_Id AND e.SlNo=d.SalId AND d.TableName='tbl_Employee_DeductionSalayHead' AND d.EmpId=b.Emp_Id AND (b.Month = '" + sc + "') AND (b.Session ='" + cmbYear.Text + "')group by a.Location_Name,b.GrossAmount,c.pf_employer_cont,d.Amount,b.Month ,b.Session ";

                dt_gec = clsDataAccess.RunQDTbl(qry);
                for (int j = 0; j < rpt_gec.Rows.Count; j++)
                {
                    for (int m = 0; m < dt_gec.Rows.Count; m++)
                    {
                        if (rpt_gec.Rows[j]["Location"].Equals(dt_gec.Rows[m]["Location"]))
                        {
                            rpt_gec.Rows[j][sc] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round((((Convert.ToDouble(dt_gec.Rows[m][sc])))))));

                            break;
                        }
                    }
                }

            }


            rpt_gec.Columns.Add("Total");
            double rowTotal = 0;
            for (int ind = 0; ind < rpt_gec.Rows.Count; ind++)
            {
                rowTotal = 0;
                for (int cr = 1; cr < rpt_gec.Columns.Count; cr++)
                {
                    try
                    {
                        rowTotal = rowTotal + Convert.ToDouble(rpt_gec.Rows[ind][cr]);
                    }
                    catch
                    {
                        rpt_gec.Rows[ind][cr] = "0";
                        rowTotal = rowTotal + 0;
                    }

                }
                if (checkBox1.Checked == true)
                {
                    if (rowTotal == 0)
                    {
                        rpt_gec.Rows.RemoveAt(ind);
                        ind--;
                    }
                    else
                    {
                        rpt_gec.Rows[ind]["Total"] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal))));
                    }
                }
                else
                {
                    rpt_gec.Rows[ind]["Total"] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(rowTotal))));

                }


            }


            DataRow totalsRow = rpt_gec.NewRow();
            totalsRow["Location"] = "Total :";
            for (int c = 1; c < rpt_gec.Columns.Count; c++)
            {
                double colTotal = 0;
                for (int r = 0; r < rpt_gec.Rows.Count; r++)
                {
                    try
                    {


                        colTotal = colTotal + Convert.ToDouble(rpt_gec.Rows[r][c]);

                    }
                    catch
                    {
                        colTotal = colTotal + 0;
                    }
                }
                totalsRow[c] = string.Format( "{0:n0}", Convert.ToDouble(System.Math.Round(Convert.ToDouble(colTotal))));

            }
            rpt_gec.Rows.Add(totalsRow);


            dgv_show1.DataSource = rpt_gec;

            dgv_show1.Columns[0].Width = 248;

            for (int s = 1; s < dgv_show1.Columns.Count; s++)
            {
                dgv_show1.Columns[s].Width = 57;
            }

            dgv_show1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataTable dt9 = new DataTable();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Columns.Add();
            dt9.Rows.Add();

            dt9.Rows[0][0] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][0];
            dt9.Rows[0][1] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][1];
            dt9.Rows[0][2] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][2];
            dt9.Rows[0][3] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][3];
            dt9.Rows[0][4] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][4];
            dt9.Rows[0][5] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][5];
            dt9.Rows[0][6] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][6];
            dt9.Rows[0][7] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][7];
            dt9.Rows[0][8] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][8];
            dt9.Rows[0][9] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][9];
            dt9.Rows[0][10] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][10];
            dt9.Rows[0][11] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][11];
            dt9.Rows[0][12] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][12];
            dt9.Rows[0][13] = rpt_gec.Rows[rpt_gec.Rows.Count - 1][13];

            rpt_gec.Rows.RemoveAt(rpt_gec.Rows.Count - 1);
            dgv_show3.DataSource = dt9;

            dgv_show3.Columns[0].Width = 248;
            dgv_show3.Columns[1].Width = 57;
            dgv_show3.Columns[2].Width = 57;
            dgv_show3.Columns[3].Width = 57;
            dgv_show3.Columns[4].Width = 57;
            dgv_show3.Columns[5].Width = 57;
            dgv_show3.Columns[6].Width = 57;
            dgv_show3.Columns[7].Width = 57;
            dgv_show3.Columns[8].Width = 57;
            dgv_show3.Columns[9].Width = 57;
            dgv_show3.Columns[10].Width = 57;
            dgv_show3.Columns[11].Width = 57;
            dgv_show3.Columns[12].Width = 57;
            dgv_show3.Columns[13].Width = 57;

            dgv_show3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
          

            

        }

        //--------------------------------------------------end of gross+emp contribution-----------------------------------//

        public void profit_view()
        {
            
            int rc = 0;
           // CultureInfo cultureInfo = new CultureInfo("en-IN");
            DataTable dt4 = new DataTable();
            dt4.Columns.Add("Location");
            dt4.Columns.Add("April");
            dt4.Columns.Add("May");
            dt4.Columns.Add("June");
            dt4.Columns.Add("July");
            dt4.Columns.Add("August");
            dt4.Columns.Add("September");
            dt4.Columns.Add("October");
            dt4.Columns.Add("November");
            dt4.Columns.Add("December");
            dt4.Columns.Add("January");
            dt4.Columns.Add("February");
            dt4.Columns.Add("March");
            dt4.Columns.Add("Total");
            dt4.Rows.Add();

            dgv_show4.DataSource = dt4;

            //int rowCount= dgv_show.RowCount;
            int colCount = dgv_show.ColumnCount;
           
             rc = dgv_show.CurrentCell.RowIndex;
            // cc = dgv_show.CurrentCell.ColumnIndex;
             
             
                 string val1 = dgv_show.Rows[rc].Cells["Location"].Value.ToString();

                  

                 for (int rw = 0; rw < dgv_show1.RowCount - 1; rw++)
                 {
                     
                     
                         string val2 = dgv_show1.Rows[rw].Cells["Location"].Value.ToString();


                         //string val2 = dgv_show1.Rows[rw1].Cells[cw].Value.ToString();
                         if (val1 == val2 && (val1 != "" && val2 != ""))
                         {
                             DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                             CellStyle.BackColor = Color.SkyBlue;
                             dgv_show1.Rows[rw].Cells["Location"].Style = CellStyle;

                         }
                         else
                         {
                             
                             
                                 DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                                 CellStyle.BackColor = Color.White;
                                 dgv_show1.Rows[rw].Cells["Location"].Style = CellStyle;
                                 //MessageBox.Show("THERE IS NO SALARY FOR THE SELECTED LOCATION ");

                             
                         } 


            
             if (val1 == val2)
             {
                
                dgv_show4.Rows[0].Cells["Location"].Value = val1;

                string val3 = dgv_show.Rows[rc].Cells["April"].Value.ToString() ;
                string  val4 = dgv_show1.Rows[rw].Cells["April"].Value.ToString();
                double pop = (Convert.ToDouble(val3) - Convert.ToDouble(val4));
                dgv_show4.Rows[0].Cells["April"].Value = string.Format( "{0:n0}",pop);

                string val5 = dgv_show.Rows[rc].Cells["May"].Value.ToString();
                string val6 = dgv_show1.Rows[rw].Cells["May"].Value.ToString();
                double pop1 = (Convert.ToDouble(val5) - Convert.ToDouble(val6));
                dgv_show4.Rows[0].Cells["May"].Value = string.Format( "{0:n0}",pop1);

                string val7 = dgv_show.Rows[rc].Cells["June"].Value.ToString();
                string val8 = dgv_show1.Rows[rw].Cells["June"].Value.ToString();
                double pop2 = (Convert.ToDouble(val7) - Convert.ToDouble(val8));
                dgv_show4.Rows[0].Cells["June"].Value = string.Format( "{0:n0}",pop2);

                string val9 = dgv_show.Rows[rc].Cells["July"].Value.ToString();
                string val10 = dgv_show1.Rows[rw].Cells["July"].Value.ToString();
                double pop3 = (Convert.ToDouble(val9) - Convert.ToDouble(val10));
                dgv_show4.Rows[0].Cells["July"].Value = string.Format( "{0:n0}",pop3);

                string val11 = dgv_show.Rows[rc].Cells["August"].Value.ToString();
                string val12 = dgv_show1.Rows[rw].Cells["August"].Value.ToString();
                double pop4 = (Convert.ToDouble(val11) - Convert.ToDouble(val12));
                dgv_show4.Rows[0].Cells["August"].Value = string.Format( "{0:n0}",pop4);

                string val13 = dgv_show.Rows[rc].Cells["September"].Value.ToString();
                string val14 = dgv_show1.Rows[rw].Cells["September"].Value.ToString();
                double pop5 = (Convert.ToDouble(val13) - Convert.ToDouble(val14));
                dgv_show4.Rows[0].Cells["September"].Value = string.Format( "{0:n0}",pop5);

                string val15 = dgv_show.Rows[rc].Cells["October"].Value.ToString();
                string val16 = dgv_show1.Rows[rw].Cells["October"].Value.ToString();
                double pop6 = (Convert.ToDouble(val15) - Convert.ToDouble(val16));
                dgv_show4.Rows[0].Cells["October"].Value = string.Format( "{0:n0}",pop6);

                string val17 = dgv_show.Rows[rc].Cells["November"].Value.ToString();
                string val18 = dgv_show1.Rows[rw].Cells["November"].Value.ToString();
                double pop7 = (Convert.ToDouble(val7) - Convert.ToDouble(val18));
                dgv_show4.Rows[0].Cells["November"].Value =string.Format( "{0:n0}", pop7);

                string val19 = dgv_show.Rows[rc].Cells["December"].Value.ToString();
                string val20 = dgv_show1.Rows[rw].Cells["December"].Value.ToString();
                double pop8 = (Convert.ToDouble(val19) - Convert.ToDouble(val20));
                dgv_show4.Rows[0].Cells["December"].Value =string.Format( "{0:n0}", pop8);

                string val21 = dgv_show.Rows[rc].Cells["January"].Value.ToString();
                string val22 = dgv_show1.Rows[rw].Cells["January"].Value.ToString();
                double pop9 = (Convert.ToDouble(val21) - Convert.ToDouble(val22));
                dgv_show4.Rows[0].Cells["January"].Value = string.Format( "{0:n0}",pop9);

                string val23 = dgv_show.Rows[rc].Cells["February"].Value.ToString();
                string val24 = dgv_show1.Rows[rw].Cells["February"].Value.ToString();
                double pop10 = (Convert.ToDouble(val23) - Convert.ToDouble(val24));
                dgv_show4.Rows[0].Cells["February"].Value = string.Format( "{0:n0}",pop10);

                string val25 = dgv_show.Rows[rc].Cells["March"].Value.ToString();
                string val26 = dgv_show1.Rows[rw].Cells["March"].Value.ToString();
                double pop11 = (Convert.ToDouble(val25) - Convert.ToDouble(val26));
                dgv_show4.Rows[0].Cells["March"].Value = string.Format( "{0:n0}",pop11);


                string val27 = dgv_show.Rows[rc].Cells["Total"].Value.ToString();
                string val28 = dgv_show1.Rows[rw].Cells["Total"].Value.ToString();
                double pop12 = (Convert.ToDouble(val27) - Convert.ToDouble(val28));
                dgv_show4.Rows[0].Cells["Total"].Value =string.Format( "{0:n0}", pop12);


             }
             

            }
                 dgv_show4.Columns[0].Width = 248;
                 dgv_show4.Columns[1].Width = 57;
                 dgv_show4.Columns[2].Width = 57;
                 dgv_show4.Columns[3].Width = 57;
                 dgv_show4.Columns[4].Width = 57;
                 dgv_show4.Columns[5].Width = 57;
                 dgv_show4.Columns[6].Width = 57;
                 dgv_show4.Columns[7].Width = 57;
                 dgv_show4.Columns[8].Width = 57;
                 dgv_show4.Columns[9].Width = 57;
                 dgv_show4.Columns[10].Width = 57;
                 dgv_show4.Columns[11].Width = 57;
                 dgv_show4.Columns[12].Width = 57;
                 dgv_show4.Columns[13].Width = 57;

                 dgv_show4.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


        }

        public void p_view()
        {
            int rr = 0;
            //CultureInfo cultureInfo = new CultureInfo("en-IN");
            DataTable dt5 = new DataTable();
            dt5.Columns.Add("Location");
            dt5.Columns.Add("April");
            dt5.Columns.Add("May");
            dt5.Columns.Add("June");
            dt5.Columns.Add("July");
            dt5.Columns.Add("August");
            dt5.Columns.Add("September");
            dt5.Columns.Add("October");
            dt5.Columns.Add("November");
            dt5.Columns.Add("December");
            dt5.Columns.Add("January");
            dt5.Columns.Add("February");
            dt5.Columns.Add("March");
            dt5.Columns.Add("Total");
            dt5.Rows.Add();
            dt5.Rows.Add();
            dt5.Rows.Add();
            dt5.Rows.Add();
            dt5.Rows.Add();
            dgv_show4.DataSource = dt5;

            //int rowCount= dgv_show.RowCount;
            //int colCount = dgv_show.ColumnCount;

            rr = dgv_show1.CurrentCell.RowIndex;
            // cc = dgv_show.CurrentCell.ColumnIndex;


            string v1 = dgv_show1.Rows[rr].Cells["Location"].Value.ToString();



            for (int rk = 0; rk < dgv_show.RowCount; rk++)
            {


                string v2 = dgv_show.Rows[rk].Cells["Location"].Value.ToString();


          
                if (v1 == v2 && (v1 != "" && v2 != ""))
                {
                    DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                    CellStyle.BackColor = Color.SkyBlue;
                    dgv_show.Rows[rk].Cells["Location"].Style = CellStyle;

                }
                else 
                {
                    if (v1 != v2)
                    {
                        DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                        CellStyle.BackColor = Color.White;
                        dgv_show.Rows[rk].Cells["Location"].Style = CellStyle;
                        //MessageBox.Show("THERE IS NO BILL FOR THE SELECTED LOCATION ");
                    }
                }






                if (v1 == v2)
                {

                    dgv_show4.Rows[0].Cells["Location"].Value = v2;

                    dgv_show4.Rows[1].Cells["Location"].Value = "Billing";
                    dgv_show4.Rows[2].Cells["Location"].Value = "Salary";
                    dgv_show4.Rows[3].Cells["Location"].Value = "Profit"+Environment.NewLine+"(in Rs.)";
                    dgv_show4.Rows[4].Cells["Location"].Value = "Profit" + Environment.NewLine + "(in %)";

                    double per = 0 ;
                    string v3 = "";//dgv_show.Rows[rk].Cells["April"].Value.ToString();
                    string v4 = "";// dgv_show1.Rows[rr].Cells["April"].Value.ToString();
                    double po = 0;// (Convert.ToDouble(v3) - Convert.ToDouble(v4));
                    string vMonth = "";
                    for (int im = 1; im < 13; im++)
                    {
                        vMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(im);
                        v3 = dgv_show.Rows[rk].Cells[vMonth].Value.ToString();
                        v4 = dgv_show1.Rows[rr].Cells[vMonth].Value.ToString();
                        po = (Convert.ToDouble(v3) - Convert.ToDouble(v4));

                        try
                        {

                            per = (Convert.ToDouble(po) / Convert.ToDouble(v4)) * 100;
                            //(current / maximum) * 100
                            if (Convert.ToString(per) == "NaN")
                            {
                                per = 0.00;

                            }

                        }
                        catch
                        {
                            per = 0;
                        }
                        dgv_show4.Rows[1].Cells[vMonth].Value = string.Format( "{0:n0}", v3);
                        dgv_show4.Rows[2].Cells[vMonth].Value = string.Format( "{0:n0}", v4);
                        dgv_show4.Rows[3].Cells[vMonth].Value = string.Format( "{0:n0}", po);
                        dgv_show4.Rows[4].Cells[vMonth].Value = string.Format( "{0:n0}", per);

                    }

                    /*
                    string v5 = dgv_show.Rows[rk].Cells["May"].Value.ToString();
                    string v6 = dgv_show1.Rows[rr].Cells["May"].Value.ToString();
                    double po1 = (Convert.ToDouble(v5) - Convert.ToDouble(v6));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                    //dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", po1);

                    v5 = dgv_show.Rows[rk].Cells["June"].Value.ToString();
                    v6 = dgv_show1.Rows[rr].Cells["June"].Value.ToString();
                    po1 = (Convert.ToDouble(v5) - Convert.ToDouble(v6));
                    
                    try
                    {   per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["June"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["June"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["June"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["June"].Value = string.Format( "{0:n0}", per);


                    //dgv_show4.Rows[4].Cells["June"].Value = string.Format( "{0:n0}", po2);

                    string v9 = dgv_show.Rows[rk].Cells["July"].Value.ToString();
                    string v10 = dgv_show1.Rows[rr].Cells["July"].Value.ToString();
                    double po3 = (Convert.ToDouble(v9) - Convert.ToDouble(v10));


                    try
                    {

                        per = (Convert.ToDouble(po3) / Convert.ToDouble(v10)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);


                    //dgv_show4.Rows[4].Cells["July"].Value = string.Format( "{0:n0}", po3);

                    string v11 = dgv_show.Rows[rk].Cells["August"].Value.ToString();
                    string v12 = dgv_show1.Rows[rr].Cells["August"].Value.ToString();
                    double po4 = (Convert.ToDouble(v11) - Convert.ToDouble(v12));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                    //dgv_show4.Rows[4].Cells["August"].Value = string.Format( "{0:n0}", po4);

                    string v13 = dgv_show.Rows[rk].Cells["September"].Value.ToString();
                    string v14 = dgv_show1.Rows[rr].Cells["September"].Value.ToString();
                    double po5 = (Convert.ToDouble(v13) - Convert.ToDouble(v14));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                    //dgv_show4.Rows[4].Cells["September"].Value = string.Format( "{0:n0}", po5);

                    string v15 = dgv_show.Rows[rk].Cells["October"].Value.ToString();
                    string v16 = dgv_show1.Rows[rr].Cells["October"].Value.ToString();
                    double po6 = (Convert.ToDouble(v15) - Convert.ToDouble(v16));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                    //dgv_show4.Rows[4].Cells["October"].Value = string.Format( "{0:n0}", po6);

                    string v17 = dgv_show.Rows[rk].Cells["November"].Value.ToString();
                    string v18 = dgv_show1.Rows[rr].Cells["November"].Value.ToString();
                    double pop7 = (Convert.ToDouble(v17) - Convert.ToDouble(v18));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                   // dgv_show4.Rows[4].Cells["November"].Value = string.Format( "{0:n0}", pop7);

                    string v19 = dgv_show.Rows[rk].Cells["December"].Value.ToString();
                    string v20 = dgv_show1.Rows[rr].Cells["December"].Value.ToString();
                    double po8 = (Convert.ToDouble(v19) - Convert.ToDouble(v20));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                   // dgv_show4.Rows[4].Cells["December"].Value = string.Format( "{0:n0}", po8);

                    string v21 = dgv_show.Rows[rk].Cells["January"].Value.ToString();
                    string v22 = dgv_show1.Rows[rr].Cells["January"].Value.ToString();
                    double po9 = (Convert.ToDouble(v21) - Convert.ToDouble(v22));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                    //dgv_show4.Rows[4].Cells["January"].Value = string.Format( "{0:n0}", po9);

                    string v23 = dgv_show.Rows[rk].Cells["February"].Value.ToString();
                    string v24 = dgv_show1.Rows[rr].Cells["February"].Value.ToString();
                    double po10 = (Convert.ToDouble(v23) - Convert.ToDouble(v24));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                    //dgv_show4.Rows[4].Cells["February"].Value = string.Format( "{0:n0}", po10);

                    string v25 = dgv_show.Rows[rk].Cells["March"].Value.ToString();
                    string v26 = dgv_show1.Rows[rr].Cells["March"].Value.ToString();
                    double po11 = (Convert.ToDouble(v25) - Convert.ToDouble(v26));
                    try
                    {

                        per = (Convert.ToDouble(po1) / Convert.ToDouble(v6)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["May"].Value = string.Format( "{0:n0}", v5);
                    dgv_show4.Rows[2].Cells["May"].Value = string.Format( "{0:n0}", v6);
                    dgv_show4.Rows[3].Cells["May"].Value = string.Format( "{0:n0}", po1);
                    dgv_show4.Rows[4].Cells["May"].Value = string.Format( "{0:n0}", per);

                    //dgv_show4.Rows[4].Cells["March"].Value = string.Format( "{0:n0}", po11);


                    string v27 = dgv_show.Rows[rk].Cells["Total"].Value.ToString();
                    string v28 = dgv_show1.Rows[rr].Cells["Total"].Value.ToString();
                    double po12 = (Convert.ToDouble(v27) - Convert.ToDouble(v28));
                    try
                    {

                        per = (Convert.ToDouble(po12) / Convert.ToDouble(v28)) * 100;
                        //(current / maximum) * 100

                    }
                    catch
                    {
                        per = 0;
                    }

                    dgv_show4.Rows[1].Cells["Total"].Value = string.Format( "{0:n0}", v27);
                    dgv_show4.Rows[2].Cells["Total"].Value = string.Format( "{0:n0}", v28);
                    dgv_show4.Rows[3].Cells["Total"].Value = string.Format( "{0:n0}", po12);
                    dgv_show4.Rows[4].Cells["Total"].Value = string.Format( "{0:n0}", per);

                    dgv_show4.Rows[4].Cells["Total"].Value = string.Format( "{0:n0}", po12);

                    */
                }


            }
            dgv_show4.Columns[0].Width = 248;
            dgv_show4.Columns[1].Width = 57;
            dgv_show4.Columns[2].Width = 57;
            dgv_show4.Columns[3].Width = 57;
            dgv_show4.Columns[4].Width = 57;
            dgv_show4.Columns[5].Width = 57;
            dgv_show4.Columns[6].Width = 57;
            dgv_show4.Columns[7].Width = 57;
            dgv_show4.Columns[8].Width = 57;
            dgv_show4.Columns[9].Width = 57;
            dgv_show4.Columns[10].Width = 57;
            dgv_show4.Columns[11].Width = 57;
            dgv_show4.Columns[12].Width = 57;
            dgv_show4.Columns[13].Width = 57;

            dgv_show4.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


      
        }


        //public void calc_mon(int mon)
        //{

        //    double per = 0;
        //    string v3 = dgv_show.Rows[rk].Cells["April"].Value.ToString();
        //    string v4 = dgv_show1.Rows[rr].Cells["April"].Value.ToString();
        //    double po = (Convert.ToDouble(v3) - Convert.ToDouble(v4));

        //    try
        //    {

        //        per = (Convert.ToDouble(po) / Convert.ToDouble(v4)) * 100;
        //        //(current / maximum) * 100

        //    }
        //    catch
        //    {
        //        per = 0;
        //    }
        //    dgv_show4.Rows[1].Cells["April"].Value = string.Format( "{0:n0}", v3);
        //    dgv_show4.Rows[2].Cells["April"].Value = string.Format( "{0:n0}", v4);
        //    dgv_show4.Rows[3].Cells["April"].Value = string.Format( "{0:n0}", po);
        //    dgv_show4.Rows[4].Cells["April"].Value = string.Format( "{0:n0}", per);

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Bill_view();
            //get_total();
            if (radioButton1.Checked == true)
            {
                Nett_view();
            }
            else if (radioButton2.Checked == true)
            {
                Gross_view();
            }
            else//if (radioButton3.Checked == true)
            {
                gec_view();
            }

        }

        private void Bill_SalaryForm_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;

            clsValidation.GenerateYear(cmbYear, 2013, System.DateTime.Now.Year, 1);
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }


            Bill_view();
            gec_view();
           
           
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Nett_view();
            }
            else if (radioButton2.Checked == true)
            {
                Gross_view();
            }
            else//if (radioButton3.Checked == true)
            {
                gec_view();
            }
        }
//---------------------------------------------------------------------------------------------------------
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}


        //private void dgv_show_Sorted(object sender, EventArgs e)
        //{
           
        //}

        //private void dgv_show_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        //{

        //}

        //private void dgv_show_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
            
        //}

        //private void dgv_show_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //}

        //private void dgv_show_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
           
        //}

        //private void dgv_show1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

       // private void dgv_show1_Sorted(object sender, EventArgs e)
       // {
          
       //}
        //private void radioButton4_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton4.Checked == true)
        //    {
        //        dgv_show1.Visible = false;
        //        dgv_show3.Visible = false;
        //        label4.Visible = false;
        //        radioButton1.Visible = false;
        //        radioButton2.Visible = false;
        //        radioButton3.Visible = false;
        //        dgv_show.Visible = true;
        //        dgv_show2.Visible = true;
        //        label1.Visible = true;
        //        button1.Visible = true;
        //        dgv_show4.Visible = false;
        //    }
        //}

        //private void radioButton5_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton5.Checked == true)
        //    {
        //        dgv_show.Visible = false;
        //        dgv_show2.Visible = false;
        //        label1.Visible = false;
        //        button1.Visible = false;
        //        dgv_show1.Visible = true;
        //        dgv_show3.Visible = true;
        //        label4.Visible = true;
        //        radioButton1.Visible = true;
        //        radioButton2.Visible = true;
        //        radioButton3.Visible = true;
        //        dgv_show4.Visible = false;
        //    }
        //}

        //private void radioButton6_CheckedChanged(object sender, EventArgs e)
        //{
        //    dgv_show.Visible = true;
        //    dgv_show2.Visible = true;
        //    label1.Visible = true;
        //    button1.Visible = true;
        //    dgv_show1.Visible = true;
        //    dgv_show3.Visible = true;
        //    label4.Visible = true;
        //    radioButton1.Visible = true;
        //    radioButton2.Visible = true;
        //    radioButton3.Visible = true;
        //    dgv_show4.Visible = true;
        //}

//------------------------------------------------------------------------------------------------------------
        private void dgv_show1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_show2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void dgv_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
//********************************** first grid view*****************************
        private void dgv_show_Sorted_1(object sender, EventArgs e)
        {
            DataTable dtDGVCopy = new DataTable();
            foreach (DataGridViewColumn col in dgv_show.Columns)
            {
                dtDGVCopy.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dgv_show.Rows)
            {
                DataRow dRow = dtDGVCopy.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                // if (dRow[0].ToString().Trim().ToLower()!="total :" || dRow[0].ToString().Trim().ToLower()!="")
                dtDGVCopy.Rows.Add(dRow);
            }
            dtDGVCopy.Rows.Add();
            for (int i = 0; i < dgRowTotalCount.Cells.Count - 1; i++)
            {
                dtDGVCopy.Rows[dtDGVCopy.Rows.Count - 1][i] = dgRowTotalCount.Cells[i].Value;
            }
            dgv_show.DataSource = null;
            dgv_show.DataSource = dtDGVCopy;
            for (int i = 0; i <= dgv_show.Columns.Count - 1; i++)
            {
                if (i == 0)
                {
                    dgv_show.Columns["Location"].Width = 248;
                    dgv_show.Columns["April"].Width = 57;
                    dgv_show.Columns["May"].Width = 57;
                    dgv_show.Columns["June"].Width = 57;
                    dgv_show.Columns["July"].Width = 57;
                    dgv_show.Columns["August"].Width = 57;
                    dgv_show.Columns["September"].Width = 57;
                    dgv_show.Columns["October"].Width = 57;
                    dgv_show.Columns["November"].Width = 57;
                    dgv_show.Columns["December"].Width = 57;
                    dgv_show.Columns["January"].Width = 57;
                    dgv_show.Columns["February"].Width = 57;
                    dgv_show.Columns["March"].Width = 57;
                    dgv_show.Columns["Total"].Width = 57;

                    dgv_show.Columns["Location"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private void dgv_show_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                dgRowTotalCount = (DataGridViewRow)dgv_show.Rows[((DataGridView)sender).Rows.Count - 1].Clone();
                for (Int32 index = 0; index < ((DataGridView)sender).Rows[((DataGridView)sender).Rows.Count - 1].Cells.Count; index++)
                {
                    dgRowTotalCount.Cells[index].Value = ((DataGridView)sender).Rows[((DataGridView)sender).Rows.Count - 1].Cells[index].Value;
                }
                ((DataGridView)sender).Rows.RemoveAt(((DataGridView)sender).Rows.Count - 1);
            }
       
        }
//************************************ second grid view ************************************
        private void dgv_show1_Sorted_1(object sender, EventArgs e)
        {
            DataTable dtDGV1Copy = new DataTable();
            foreach (DataGridViewColumn col in dgv_show1.Columns)
            {
                dtDGV1Copy.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dgv_show1.Rows)
            {
                DataRow dRow = dtDGV1Copy.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }

                dtDGV1Copy.Rows.Add(dRow);
            }
            dtDGV1Copy.Rows.Add();
            for (int i = 0; i < dgRowTotalCount.Cells.Count - 1; i++)
            {
                dtDGV1Copy.Rows[dtDGV1Copy.Rows.Count - 1][i] = dgRowTotalCount.Cells[i].Value;
            }
            dgv_show1.DataSource = null;
            dgv_show1.DataSource = dtDGV1Copy;
            for (int i = 0; i <= dgv_show1.Columns.Count - 1; i++)
            {
                if (i == 0)
                {
                    dgv_show1.Columns["Location"].Width = 248;
                    dgv_show1.Columns["April"].Width = 57;
                    dgv_show1.Columns["May"].Width = 57;
                    dgv_show1.Columns["June"].Width = 57;
                    dgv_show1.Columns["July"].Width = 57;
                    dgv_show1.Columns["August"].Width = 57;
                    dgv_show1.Columns["September"].Width = 57;
                    dgv_show1.Columns["October"].Width = 57;
                    dgv_show1.Columns["November"].Width = 57;
                    dgv_show1.Columns["December"].Width = 57;
                    dgv_show1.Columns["January"].Width = 57;
                    dgv_show1.Columns["February"].Width = 57;
                    dgv_show1.Columns["March"].Width = 57;
                    dgv_show1.Columns["Total"].Width = 57;

                    dgv_show1.Columns["Location"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }

        private void dgv_show1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                dgRowTotalCount = (DataGridViewRow)dgv_show1.Rows[((DataGridView)sender).Rows.Count - 1].Clone();
                for (Int32 index = 0; index < ((DataGridView)sender).Rows[((DataGridView)sender).Rows.Count - 1].Cells.Count; index++)
                {
                    dgRowTotalCount.Cells[index].Value = ((DataGridView)sender).Rows[((DataGridView)sender).Rows.Count - 1].Cells[index].Value;
                }
                ((DataGridView)sender).Rows.RemoveAt(((DataGridView)sender).Rows.Count - 1);
            }
       
        }

       
        private void dgv_show_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                profit_view();
                this.Refresh();
            }
        }

       

        private void dgv_show1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                p_view();
                this.Refresh();
            }
       
        }

       
    }
            

}
