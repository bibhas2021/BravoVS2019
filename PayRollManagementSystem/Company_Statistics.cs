
//ANURAG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Company_Statistics : Form
    {
        int code;
        DataTable DTResource;
        DataRow row;
        String menucode;
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        public Company_Statistics()
        {
            InitializeComponent();
        }
   
        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl("select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbCompany.LookUpTable = dt;
                cmbCompany.ReturnIndex = 1;
            }
        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            dataGridView2.Rows.Clear();
            code = Convert.ToInt32(cmbCompany.ReturnValue);
            double ps = 0, pb = 0, sl=0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = listBox1.Items[i].ToString();
                try
                {
                    String str = "SELECT isNull(COUNT(DISTINCT Location_id),0) AS structure FROM tbl_Employee_Assign_SalStructure WHERE (Company_id = '" + code + "')";
                    String str3 = "SELECT isNull(COUNT(distinct Location_id),0) AS sal FROM tbl_Employee_SalaryMast WHERE (Company_id='" + code + "') AND (Month = '" + listBox1.Items[i].ToString() + "') AND (Session = '" + cmbYear.Text + "')";
                    dataGridView2.Rows[i].Cells[1].Value = clsDataAccess.GetresultS(str) + " - " + clsDataAccess.GetresultS(str3);
                    sl =sl+ Convert.ToDouble(clsDataAccess.GetresultS(str3));
                    
                    String str1 = "SELECT isNull(COUNT(Emp_Id),0) AS ps FROM tbl_Employee_SalaryMast WHERE (Company_id = '" + code + "') AND (Month = '" + listBox1.Items[i].ToString() + "') AND (Session = '" + cmbYear.Text + "') GROUP BY Company_id";

                    string sr=(string.IsNullOrEmpty(clsDataAccess.GetresultS(str1)) ? "0" : clsDataAccess.GetresultS(str1)) ;

                    dataGridView2.Rows[i].Cells[2].Value = sr;
                    try
                    {
                        ps = ps + Convert.ToDouble(sr);
                    }
                    catch
                    {
                        ps = ps + 0;
                    }
                    String str2 = "SELECT isNull(COUNT(*),0) AS tBill FROM paybill WHERE (Month like '" + listBox1.Items[i].ToString() + "%') AND (Session ='" + cmbYear.Text + "') AND (Comany_id = '" + code + "')";
                        //"SELECT COUNT(Emp_Id) AS ps, Location_id FROM tbl_Employee_SalaryMast WHERE (Company_id = '" + code + "') AND (Month = '" + listBox1.Items[i].ToString() + "') AND (Session = '" + cmbYear.Text + "') GROUP BY Location_id";

                    string sr2 = (string.IsNullOrEmpty(clsDataAccess.GetresultS(str2)) ? "0" : clsDataAccess.GetresultS(str2));
                    dataGridView2.Rows[i].Cells[3].Value = Convert.ToDouble(sr2);

                    try
                    {
                        pb = pb + Convert.ToDouble(sr2);
                    }
                    catch
                    {
                        pb = pb + 0;
                    }
                }
                catch (Exception ex)
                {
                }


            }
           
            //for (int i = 0; i < dataGridView2.Rows.Count; i++)
            //{
            //    ps = ps +Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            //    pb = pb + Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            //}
            dataGridView2.Rows.Add();
            int inx= dataGridView2.Rows.Add();
            dataGridView2.Rows[inx].Cells[0].Value = "Total :";
            dataGridView2.Rows[inx].Cells[1].Value =sl;
            dataGridView2.Rows[inx].Cells[2].Value =ps;
            dataGridView2.Rows[inx].Cells[3].Value = pb;

        }

        private void AAA_Load(object sender, EventArgs e)
        {
            //generate year in cmbYear
            clsValidation.GenerateYear(cmbYear, 2012, System.DateTime.Now.Year, 1);

            try
            {
                if (System.DateTime.Now.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = System.DateTime.Now.Year + "-" + System.DateTime.Now.AddYears(1).Year; }
                    catch { }
                    
                }
                else
                {
                    cmbYear.SelectedItem = System.DateTime.Now.AddYears(-1).Year + "-" + System.DateTime.Now.Year;
                    
                }


                cmbCompany.PopUp();
        
            }
            catch
            { }     
        }       
      
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            String var_month = dataGridView2.Rows[index].Cells[0].Value.ToString();

            edpcon.Open();
            String str = "select distinct Location_Name as Location," +
 "isNull((select isNull(SalaryCategory,'') from tbl_Employee_SalaryStructure where SLNO in (select eas.SAL_STRUCT from  tbl_Employee_Assign_SalStructure as eas where Location_ID=el.Location_ID and Company_id='" + code + "')),'-')AS SalaryStruct," +
 "isNull((SELECT COUNT(Emp_Id) AS Ecount FROM tbl_Employee_SalaryMast WHERE (Company_id = '" + code + "') AND (Location_id = el.Location_ID) AND (Month = '" + var_month + "') AND (Session =  '" + cmbYear.Text + "') GROUP BY Location_id),0) AS Pay_Slip," +
 "isNull((SELECT COUNT(*) AS BCount FROM paybill WHERE (Month LIKE '" + var_month + "%') AND (Session= '" + cmbYear.Text + "') AND (Comany_id = '" + code + "') AND (Location_ID = el.Location_id) GROUP BY Comany_id, Location_ID), 0) AS Bill from tbl_Emp_Location as el where Cliant_ID in (select distinct Cliant_ID from tbl_Employee_CliantMaster where coid='" + code + "')";
                
                
                //"SELECT distinct (SELECT Location_Name FROM tbl_Emp_Location WHERE (Location_ID = sm.Location_id)) AS Location," +
                //        "(SELECT     SalaryCategory " +
                //            "FROM          tbl_Employee_SalaryStructure " +
                //            "WHERE      (SlNo = ea.SAL_STRUCT)) AS SalaryStruct," +
                //            "(SELECT COUNT(Emp_Id) FROM tbl_Employee_SalaryMast WHERE (Company_id = sm.Company_id) and (Location_id=sm.Location_id) AND (Month =sm.Month) AND (Session =sm.Session) GROUP BY Location_id)as Pay_Slip, " +
                //              "isnull((SELECT     COUNT(*) FROM paybill WHERE (Month like '" + var_month + "%') AND (Session =sm.Session) AND (Comany_id =sm.Company_id) and (Location_ID=sm.Location_id) GROUP BY Comany_id, Location_ID),0)as Bill " +
                //        "FROM         tbl_Employee_Assign_SalStructure AS ea INNER JOIN " +
                //      "tbl_Employee_SalaryMast AS sm ON ea.Company_id = sm.Company_id AND ea.Location_id = sm.Location_id " +
                //     "WHERE     (sm.Company_id = '" + code + "') AND (sm.Month = '" + var_month + "') AND (sm.Session = '" + cmbYear.Text + "')";

            SqlCommand cmd = new SqlCommand(str,edpcon.mycon);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            sda.Fill(dtt);
            edpcon.Close();



            DataTable table = new DataTable();
            dtt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = dtt;

        }   

    }
}
