using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;
using System.Collections;
using System.Data.SqlClient;
using Edpcom;
//using EDPComponent;

/*--------------------------------------------Created By Dwipraj Dutta-------------------------------------------------------*/

namespace PayRollManagementSystem
{
    public partial class PendingBillReport : Form//EDPComponent.FormBaseERP
    {
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        ArrayList arr = new ArrayList();
        Hashtable getcode = new Hashtable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt_header = new DataTable();
        string compname = "", compid = "";
        String mainsql = "";
        String payBill_tbl_Month = "";  //in paybill table Month format is in MONTH - YEAR format.
        String session = "";
        String SalaryMast_tbl_Month = "";   //in tbl_Employee_SalaryMast Month format is in MONTH format.

        DataRow dr;
        DataColumn dc1 = new DataColumn("Location Name");
        DataColumn dc2 = new DataColumn("Salary Amount");
        DataColumn dc3 = new DataColumn("Client Name");
        DataColumn dc4 = new DataColumn("Bill No.");
        DataColumn dc5 = new DataColumn("Bill Date");
        DataColumn dc6 = new DataColumn("Bill Amount");
        String year = "";   //for getting the year
        String month = "";

        public PendingBillReport()
        {
            InitializeComponent();
        }

        private void PendingBillReport_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.HeaderText = "Pending Bill Report";
           // this.Text = "Pending Bill Report";
            clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
            int currentMonth = System.DateTime.Now.Month;
            var months = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames;
            comboBox1.DataSource = months;
            int setMonth = currentMonth - 2;

            //For setting the previous month of current system month as default
            if (setMonth >= 0)
            {
                comboBox1.SelectedIndex = setMonth;
            }
            else
            {
                comboBox1.SelectedIndex = 12 + setMonth;
            }
            
            //If current month is less than April then the previous or secoend indexed session will be selected automatically as default
            if(currentMonth>=4)
                cmbYear.SelectedIndex = 0;
            else
                cmbYear.SelectedIndex = 1;
        }

        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            //String qryForRetrivingCompany = "SELECT CO_NAME, GCODE  FROM Company";

            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }
           // DataTable dt = clsDataAccess.RunQDTbl(qryForRetrivingCompany);

            if (dt.Rows.Count > 0)
            {
                cmbCompany.LookUpTable = dt;
                cmbCompany.ReturnIndex = 1;
            }
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (Information.IsNumeric(cmbCompany.ReturnValue) == true)
            {
                compid = Convert.ToString(cmbCompany.ReturnValue);
                compname = Convert.ToString(cmbCompany.Text);
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Company Must be Entered");
                return;
            }
            LoadDataTable(1);
        }

        public void LoadDataTable(int ptype)
        {
            int monthVal = comboBox1.SelectedIndex + 1;
            month = comboBox1.Text;
            session = cmbYear.Text;
            if(monthVal >= 4)
            {
                year = session.Substring(0,4);
            }
            else
            {
                year = session.Substring(session.Length-4);
            }

            payBill_tbl_Month = comboBox1.Text + " - " + year;
            SalaryMast_tbl_Month = comboBox1.Text;
            mainsql = "(select m.[Location Name],m.[Salary Ammount],cm.Client_Name as 'Client Name',m.[Bill No.],m.Date,m.[Total Amount] from"+
" ("+
	" select l.Location_Name as 'Location Name',m.Total_sal as 'Salary Ammount',m.Cliant_ID,m.BILLNO as 'Bill No.',CONVERT(varchar(10), m.BILLDATE,110) as 'Date',m.TotAMT as 'Total Amount' from"+
	" ("+
		" (select m.Location_ID,m.BILLNO,m.BILLDATE,m.TotAMT,m.Cliant_ID,l.Total_sal from"+
                " (select BILLNO,BILLDATE,(TotAMT+ServiceAmount+ScAmt) as 'TotAMT',Location_ID,Cliant_ID from paybill WHERE Month = '" + payBill_tbl_Month + "' AND Comany_id = " + compid + " and BillStatus = 'ACTIVE') as m" +
				" left join"+
                " (select SUM(TotalSal) as 'Total_sal',Location_id from tbl_Employee_SalaryMast WHERE Session = '"+session+"' AND Month = '"+month+ "' AND Company_id = " + compid + " GROUP BY Location_id) as l" +
			" on m.Location_ID = l.Location_id)"+
		" union"+
		" (select l.Location_ID,m.BILLNO,m.BILLDATE,m.TotAMT,m.Cliant_ID,l.Total_sal from"+
                " (select BILLNO,BILLDATE,(TotAMT+ServiceAmount+ScAmt) as 'TotAMT',Location_ID,Cliant_ID from paybill WHERE Month = '" + payBill_tbl_Month + "' AND Comany_id = " + compid + " and BillStatus = 'ACTIVE') as m" +
				" right join"+
				" (select SUM(TotalSal) as 'Total_sal',Location_id from tbl_Employee_SalaryMast WHERE Session = '"+session+"' AND Month = '"+month+"' AND Company_id = "+compid+" GROUP BY Location_id) as l"+
			" on m.Location_ID = l.Location_id)"+
	" )m,tbl_Emp_Location l"+
	" where m.Location_ID=l.Location_ID"+
") m"+
" left join"+
" tbl_Employee_CliantMaster cm"+
" on cm.Client_id=m.Cliant_ID)";

            if (checkBox1.Checked)
                mainsql = "select * from " + mainsql + "m where m.[Bill No.] is null";

            dt.Clear();
            dt = clsDataAccess.RunQDTbl(mainsql);

            dt_header.Clear();
            dt_header.Columns.Clear();
            dt_header.Columns.Add(dc1);
            dt_header.Columns.Add(dc2);
            dt_header.Columns.Add(dc3);
            dt_header.Columns.Add(dc4);
            dt_header.Columns.Add(dc5);
            dt_header.Columns.Add(dc6);
            if (dt.Rows.Count > 0)
            {
                for (int y = 0; y < dt.Rows.Count; y++)
                {
                    dr = dt_header.NewRow();
                    dr[0] = dt.Rows[y][0].ToString();
                    dr[1] = dt.Rows[y][1].ToString();
                    dr[2] = dt.Rows[y][2].ToString();
                    dr[3] = dt.Rows[y][3].ToString();
                    dr[4] = dt.Rows[y][4].ToString();
                    dr[5] = dt.Rows[y][5].ToString();
                    dt_header.Rows.Add(dr);
                }
            }
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = dt_header;
            
            //for setting datagridview coloumn width
            dataGridView1.Columns[0].Width = 300;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 330;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            
            //for setting price related coloumn allignment to the right
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Boolean chk = validationCompanyInfo();
            if (chk)
                LoadDataTable(1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Boolean chk = validationCompanyInfo();
            if (chk)
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Location Name] LIKE '%{0}%' or [Client Name] LIKE '%{1}%'", textBox1.Text, textBox1.Text);
            else
            {
                this.textBox1.TextChanged -= this.textBox1_TextChanged;
                textBox1.Text = "";
            }
        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Boolean chk = validationCompanyInfo();
            if (chk)
            {
                LoadDataTable(1);
            }
        }

        private void cmbYear_DropDownClosed(object sender, EventArgs e)
        {
            Boolean chk = validationCompanyInfo();
            if (chk)
            {
                LoadDataTable(1);
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            Boolean chk = validationCompanyInfo();
            if (chk)
                LoadDataTable(1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /*
         * Description of validationCompanyInfo() method : When this form loads it automatically sets the session and month by using current system time.
         * So there is one input field left that must be selected in order to get the results and that is Company Name field. 
         * So whenever the user to fetch the result it must be checked if the company nname has been selected or not so 
         * this method will validate if company name has been given or not and if given then it will get the 
         * company id and name from given company name...
         */
        public Boolean validationCompanyInfo()
        {
            if (Information.IsNumeric(cmbCompany.ReturnValue) == true)
            {
                compid = Convert.ToString(cmbCompany.ReturnValue);
                compname = Convert.ToString(cmbCompany.Text);
                return true;
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Company Must be Entered");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalaryAgainstBillRpt prf = new SalaryAgainstBillRpt();
            prf.Show();
        }      

    }
}
