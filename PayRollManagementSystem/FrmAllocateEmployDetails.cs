using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using EDPMessageBox;

namespace PayRollManagementSystem
{
    public partial class FrmAllocateEmployDetails : MstFrmDialog
    {
        string Employ_ID = "";
        public FrmAllocateEmployDetails()
        {
            InitializeComponent();
        }

        private void cmborderno_DropDown(object sender, EventArgs e)
        {
            if (cmbmonth.Text == "")
            {
                ERPMessageBox.ERPMessage.Show("Month Name Can not Blank");
                cmbmonth.DroppedDown = true;
                cmbmonth.SelectedIndex = 0;
                cmbmonth.Focus();
                return;
            }
            DataTable dt = clsDataAccess.RunQDTbl("select FirstName +' '+ MiddleName +' '+ LastName as EmployeeName,ID, (Select Location_Name from tbl_Emp_Location where Location_ID=em.Location_id) as Location from tbl_Employee_Mast em");
            if (dt.Rows.Count > 0)
            {               
                cmborderno.LookUpTable = dt;
                cmborderno.ReturnIndex = 1;
            }  
            
        }

        private void FrmAllocateEmployDetails_Load (object sender, EventArgs e)
        {
            this.lblTitle.Text = "Employee Allotment Details";
            DataTable dt = clsDataAccess.RunQDTbl("select Client_Name from tbl_Employee_CliantMaster");
            DataGridViewComboBoxColumn dgcombo = dgemployjob.Columns["Cliantname"] as DataGridViewComboBoxColumn;
            dgcombo.Items.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt.Rows[i]["Client_Name"]);
                dgcombo.Items.Add(st);
            }

            DataTable dt1 = clsDataAccess.RunQDTbl("select Location_Name from tbl_Emp_Location");
            DataGridViewComboBoxColumn dgcombo1 = dgemployjob.Columns["locationname"] as DataGridViewComboBoxColumn;
            dgcombo1.Items.Clear();
            for (int i = 0; i <= dt1.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt1.Rows[i]["Location_Name"]);
                dgcombo1.Items.Add(st);
            }

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("DesignationName", typeof(string));
            dt3.Columns.Add("SlNo", typeof(string));
          dt3= clsDataAccess.RunQDTbl("select DesignationName,SlNo from tbl_Employee_DesignationMaster");
            DataGridViewComboBoxColumn dgcombo3 = dgemployjob.Columns["Designation"] as DataGridViewComboBoxColumn;
            dgcombo3.Items.Clear();
            comboBox1.Items.Clear();
            //for (int i = 0; i <= dt3.Rows.Count - 1; i++)
            //{
            //    string st = Convert.ToString(dt3.Rows[i]["DesignationName"]);
            //    dgcombo3.Items.Add(st);
            //}
            dgcombo3.DataSource = dt3;
            dgcombo3.DisplayMember = dt3.Columns[0].ToString();
            dgcombo3.ValueMember = dt3.Columns[1].ToString();
            comboBox1.DataSource = dt3;
            comboBox1.DisplayMember=dt3.Columns[0].ToString();
            comboBox1.ValueMember = dt3.Columns[1].ToString();

            DataTable dt2 = clsDataAccess.RunQDTbl("select Order_Name from tbl_Employee_OrderDetails");
            DataGridViewComboBoxColumn dgcombo2 = dgemployjob.Columns["OrderNo"] as DataGridViewComboBoxColumn;
            dgcombo2.Items.Clear();
            for (int i = 0; i <= dt2.Rows.Count - 1; i++)
            {
                string st = Convert.ToString(dt2.Rows[i]["Order_Name"]);
                dgcombo2.Items.Add(st);
            }


            //generate year
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //

            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }
            //

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Allocate Employ Details Saved Successfully");
                dgemployjob.Rows.Clear();
                cmborderno.Text = "";
                Employ_ID = "";
                //this.Close();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Allocate Employ Details");
            }
        }

        private Boolean SubmitDetails()
        {
            Boolean flug = true;
            Boolean boolStatus = false;
           DateTime d1, d2;
            int dtdiff = 0;
            if (dgemployjob.Rows.Count > 1)
              {
                for (int i = 0; i < dgemployjob.Rows.Count - 1; i++)
                {
                    int mon = Convert.ToDateTime(dgemployjob.Rows[i].Cells["fromdate"].Value).Month;
                    string month = clsEmployee.GetMonthName(mon);
                    if (cmbmonth.Text != month)
                    {
                        int roecount = i + 1;
                        ERPMessageBox.ERPMessage.Show("From Date Out Of The Range, For " + roecount + " th Row. ");
                        flug = false;
                        break;
                    }

                    if (Information.IsNothing(dgemployjob.Rows[i].Cells["transaction"].Value) == true)
                    {
                        int roecount = i + 1;
                        ERPMessageBox.ERPMessage.Show("Transaction No. Cannot Blank , For " + roecount + " th Row. ");
                        flug = false;
                        break;
                    }
                }
                if (flug == true)
                {
                    for (Int32 i = 0; i < dgemployjob.Rows.Count - 1; i++)
                    {
                        string ID = Convert.ToString(dgemployjob.Rows[i].Cells["id"].Value);
                        string strCliantName = Convert.ToString(dgemployjob.Rows[i].Cells["Cliantname"].Value);
                        string strlocname = Convert.ToString(dgemployjob.Rows[i].Cells["locationname"].Value);
                        string degn = Convert.ToString(dgemployjob.Rows[i].Cells["Designation"].Value);
                        //if (i > 0)
                        //{
                        //    DataTable dt = clsDataAccess.RunQDTbl("Select ID from tbl_Emp_Posting where Employ_ID = '" + Employ_ID + "' and FromDate  between '" + dgemployjob.Rows[i].Cells["fromdate"].Value + "' and '" + dgemployjob.Rows[i].Cells["fromdate"].Value + "' ");
                        //    if (dt.Rows.Count > 0)
                        //    {
                        //        ERPMessageBox.ERPMessage.Show("This Date Already Allocate for " + i + "th Row.");
                        //        break;
                        //    }
                        //}
                       if (Information.IsNumeric(degn) == false)
                    {
                        if (degn == "")
                        {
                            degn = clsDataAccess.GetresultS("select DesgId from tbl_Employee_Mast where ID='" + Employ_ID + "'");
                        }
                        else
                        {
                            degn = clsDataAccess.GetresultS("Select SlNo from tbl_Employee_DesignationMaster where (DesignationName='" + degn + "')");
                        }
                       
                    }
                        if (strCliantName != "")
                        {
                            DataTable dt = clsDataAccess.RunQDTbl("select Client_id from tbl_Employee_CliantMaster where Client_Name = '" + strCliantName + "'");
                            if (dt.Rows.Count > 0)
                                strCliantName = Convert.ToString(dt.Rows[0]["Client_id"]);
                        }

                        if (strlocname != "")
                        {
                            DataTable dt = clsDataAccess.RunQDTbl("select Location_ID from tbl_Emp_Location where Location_Name = '" + strlocname + "'");
                            if (dt.Rows.Count > 0)
                                strlocname = Convert.ToString(dt.Rows[0]["Location_ID"]);
                        }
                        //if (degn != "")
                        //{
                        //    DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_DesignationMaster where (DesignationName='" + degn + "')");
                        //    if (dt.Rows.Count > 0)
                        //        degn = Convert.ToString(dt.Rows[0]["SlNo"]);

                        //    else
                        //        degn = "0";

                        //}
                        //else
                        //{
                        //    degn = "0";
                        //}

                        try
                        {
                            d1 = Convert.ToDateTime(dgemployjob.Rows[i].Cells["fromdate"].Value);
                        }
                        catch{}
                        try
                        {
                            d2 = Convert.ToDateTime(dgemployjob.Rows[i].Cells["todate"].Value);
                        }
                        catch { }
                        dtdiff = Convert.ToInt32((Convert.ToDateTime(dgemployjob.Rows[i].Cells["fromdate"].Value).Day - Convert.ToDateTime(dgemployjob.Rows[i].Cells["todate"].Value).Day) + 1);

                        if (!String.IsNullOrEmpty(strCliantName))
                        {
                            if (!String.IsNullOrEmpty(ID))
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Emp_Posting set Cliant_ID='" + 
strCliantName + "',LOcation_ID='" + strlocname + "',FromDate='" + dgemployjob.Rows[i].Cells["fromdate"].Value + 
"',ToDate='" + dgemployjob.Rows[i].Cells["todate"].Value + "' , Order_Person = '" + dgemployjob.Rows[i].Cells["personName"].Value + 
"',Order_Date = '" + dgemployjob.Rows[i].Cells["orderdate"].Value + "',UserName = '" + dgemployjob.Rows[i].Cells["username"].Value + 
"',Transaction_ID = '" + dgemployjob.Rows[i].Cells["transaction"].Value + "',Order_No='" + dgemployjob.Rows[i].Cells["OrderNo"].Value + 
"', Session = '" + cmbYear.Text + "', DesgId='" + degn + "', TDay="+ dtdiff +" where ID =" + ID + " and Posting_Month='" + cmbmonth.Text + "' ");
                            }
                            else
                            {
                                int Max_ID = 0;
                                DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(ID) FROM tbl_Emp_Posting");
                                if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                                {
                                    Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                                }
                                else
                                {
                                    Max_ID = 1;
                                }

                                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Emp_Posting" +
"(ID,Employ_ID,Cliant_ID,LOcation_ID,FromDate,ToDate,Posting_Month,Order_Person,Order_Date,UserName,Transaction_ID,Order_No,Session,DesgId,TDay) values('" + 
Max_ID + "','" + Employ_ID + "','" + strCliantName + "','" + strlocname + "','" + dgemployjob.Rows[i].Cells["fromdate"].Value + "','" + 
dgemployjob.Rows[i].Cells["todate"].Value + "','" + cmbmonth.Text + "','" + dgemployjob.Rows[i].Cells["personName"].Value + "','" + 
dgemployjob.Rows[i].Cells["orderdate"].Value + "','" + dgemployjob.Rows[i].Cells["username"].Value + "','" + 
dgemployjob.Rows[i].Cells["transaction"].Value + "','" + dgemployjob.Rows[i].Cells["OrderNo"].Value + "','" + 
cmbYear.Text + "','" + degn + "',"+ dtdiff +")");
                            }
                        }
                        else
                        {
                            ERPMessageBox.ERPMessage.Show("Please Enter Cliant Name for " + i + " th Row.");
                        }
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
            return boolStatus;
        }

        private void cmborderno_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Employ_ID = cmborderno.ReturnValue;
            GetDetails();
        }

        private void GetDetails()
        {
            if (Employ_ID !="")
            {
                if(dgemployjob.Rows.Count > 1)
                dgemployjob.Rows.Clear();
                DataTable dt = clsDataAccess.RunQDTbl("Select ID,Employ_ID,Cliant_ID,LOcation_ID,FromDate,ToDate,Order_Person,Order_Date,UserName,Transaction_ID,Order_No,Session,DesgId from tbl_Emp_Posting where Employ_ID = '" + Employ_ID + "' and Posting_Month = '" + cmbmonth.Text + "' and Session = '" + cmbYear.Text + "'");
                for (int i = 0; i <= dt.Rows.Count - 1;i++)
                {
                    dgemployjob.Rows.Add();
                    dgemployjob.Rows[i].Cells["id"].Value = Convert.ToString(dt.Rows[i]["ID"]);
                    dgemployjob.Rows[i].Cells["fromdate"].Value = Convert.ToDateTime(dt.Rows[i]["FromDate"]).ToShortDateString();
                    dgemployjob.Rows[i].Cells["todate"].Value = Convert.ToDateTime(dt.Rows[i]["ToDate"]).ToShortDateString();        

                   
                    if (Information.IsNumeric(dt.Rows[0]["Cliant_ID"]) == true)
                    {
                        DataTable dt_Clint = clsDataAccess.RunQDTbl("Select Client_Name from tbl_Employee_CliantMaster where Client_id = '" + dt.Rows[i]["Cliant_ID"] + "'");
                        if (dt_Clint.Rows.Count > 0)
                            dgemployjob.Rows[i].Cells["Cliantname"].Value = Convert.ToString(dt_Clint.Rows[0]["Client_Name"]);
                    }
                    if (Information.IsNumeric(dt.Rows[0]["LOcation_ID"]) == true)
                    {
                        DataTable dt_company = clsDataAccess.RunQDTbl("Select Location_Name from tbl_Emp_Location where Location_ID = '" + dt.Rows[i]["LOcation_ID"] + "'");
                        if (dt_company.Rows.Count > 0)
                            dgemployjob.Rows[i].Cells["locationname"].Value = Convert.ToString(dt_company.Rows[0]["Location_Name"]);
                    }
                    if (Information.IsNumeric(dt.Rows[0]["DesgId"]) == true)
                    {
                        DataTable dt_Desg = clsDataAccess.RunQDTbl("Select DesignationName from tbl_Employee_DesignationMaster where (SlNo=" + dt.Rows[i]["DesgId"] + ")");
                        if (dt_Desg.Rows.Count > 0)
                        dgemployjob.Rows[i].Cells["Designation"].Value = dt_Desg.Rows[0]["DesignationName"].ToString();
                        dt_Desg.Clear();
                    }
                    dgemployjob.Rows[i].Cells["orderdate"].Value = Convert.ToDateTime(dt.Rows[i]["Order_Date"]).ToShortDateString();
                    dgemployjob.Rows[i].Cells["personName"].Value = Convert.ToString(dt.Rows[i]["Order_Person"]);
                    dgemployjob.Rows[i].Cells["username"].Value = Convert.ToString(dt.Rows[i]["UserName"]);
                    dgemployjob.Rows[i].Cells["transaction"].Value = Convert.ToString(dt.Rows[i]["Transaction_ID"]);
                    dgemployjob.Rows[i].Cells["OrderNo"].Value = Convert.ToString(dt.Rows[i]["Order_No"]);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int Allocate_ID = Convert.ToInt32(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["id"].Value);
            if (Information.IsNumeric(dgemployjob.Rows[dgemployjob.CurrentRow.Index].Cells["id"].Value) == true)
            {
                Boolean boolStatus = false;
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Emp_Posting where ID=" + Allocate_ID + "");

                if (boolStatus)
                {
                    ERPMessageBox.ERPMessage.Show("Deleted Successfully");
                    GetDetails();
                }
            }
        }

        private void cmbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void dgemployjob_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "From Date")
            {
                if (cmbmonth.Text != clsEmployee.GetMonthName(Convert.ToDateTime(dgemployjob.Rows[e.RowIndex].Cells["fromdate"].Value).Month))
                {
                    ERPMessageBox.ERPMessage.Show("From Date not inside the Selected Month");
                    //dgemployjob.Rows[e].Cells["fromdate"].Value = "s";                    
                }
            }
        }

        private void dgemployjob_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Cliant Name")
            {
                dgemployjob.Rows[e.RowIndex].Cells["OrderNo"].Value = "";
                dgemployjob.Rows[e.RowIndex].Cells["locationname"].Value = "";
                if (cmborderno.Text == "")
                {

                    ERPMessageBox.ERPMessage.Show("Employ Name Can not Blank");
                    cmborderno.PopUp();
                }
            }
            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Order Person")
            {
                string val_ono = Convert.ToString(dgemployjob.Rows[e.RowIndex].Cells["OrderNo"].Value);
                if (val_ono != "")
                {
                    DataTable dt8 = clsDataAccess.RunQDTbl("select FromDate,ToDate from tbl_Employee_OrderDetails where (Order_Name='" + val_ono + "')");
                    string comid = "";
                    if (dt8.Rows.Count > 0)
                    {
                        this.dgemployjob["fromdate", e.RowIndex].Value = Convert.ToDateTime(dt8.Rows[0][0]).ToShortDateString();
                        this.dgemployjob["todate", e.RowIndex].Value = Convert.ToDateTime(dt8.Rows[0][1]).ToShortDateString();
                    }

                }

            }
            if (dgemployjob.Columns[e.ColumnIndex].HeaderText == "Location Site Name")
            {               
                string strCliantName = Convert.ToString(dgemployjob.Rows[e.RowIndex].Cells["Cliantname"].Value);
                if (strCliantName != "")
                {
                    //string Employ_Location = clsDataAccess.GetresultS("select Location_id from tbl_Employee_Mast where ID ='" + Employ_ID + "'  ");
                    DataTable dt = clsDataAccess.RunQDTbl("select Client_id from tbl_Employee_CliantMaster where Client_Name = '" + strCliantName + "'");
                    if (dt.Rows.Count > 0)
                        strCliantName = Convert.ToString(dt.Rows[0]["Client_id"]);
                    //if (Employ_Location == null)
                    //    Employ_Location = "0";

                    DataTable dt1 = clsDataAccess.RunQDTbl("select Location_Name from tbl_Emp_Location where Cliant_ID='" + strCliantName + "' ");
                    DataGridViewComboBoxCell dgcombo1 = new DataGridViewComboBoxCell();
                    dgcombo1.Items.Clear();
                    for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                    {
                        string st = Convert.ToString(dt1.Rows[i]["Location_Name"]);
                        dgcombo1.Items.Add(st);
                    }
                    this.dgemployjob["locationname", e.RowIndex] = dgcombo1;



                    DataTable dt2 = clsDataAccess.RunQDTbl("select Order_Name from tbl_Employee_OrderDetails where Cliant_ID = '" + strCliantName + "' ");
                    DataGridViewComboBoxCell dgcombo2 = new DataGridViewComboBoxCell();                    
                    dgcombo2.Items.Clear();
                    for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                    {
                        string st = Convert.ToString(dt2.Rows[i]["Order_Name"]);
                        dgcombo2.Items.Add(st);
                    }
                    this.dgemployjob["OrderNo", e.RowIndex] = dgcombo2;
                }
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clsValidation.ValidateComboBox(cmbYear, "", "Please Select Session"))
            {
               
            }
        }

        private void dgemployjob_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void FrmAllocateEmployDetails_Shown(object sender, EventArgs e)
        {
            EDPMessage.Show("Bravo can build allotment scheduling logic  that works with your business" + Environment.NewLine +
            "Industries face challenges  every time they create a new shift schedule." + Environment.NewLine +
            "'Bravo employee allotment' software built as additionally modules simplifies complex employee scheduling to reduce overtime costs, while  regulatory rules are met." + Environment.NewLine +
            "So You can efficiently manage employee rosters according to how your business operates." + Environment.NewLine +
            "Contact us at support@edpsoft.com for more info .", "Information", EDPMessage.MessageBoxButton.EDP_OK, EDPMessage.MessageBoxIcon.EDP_INFORMATION);
            String aa = EDPMessageBox.EDPMessage.ButtonResult;
            if (aa == "edpOK")
            {
                this.Close();

            }
        }

       


       

    }
}
