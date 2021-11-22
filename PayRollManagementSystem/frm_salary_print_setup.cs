using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frm_salary_print_setup : EDPComponent.FormBaseERP
    {
        int Location_ID = 0, Structure_ID = 0;
        public frm_salary_print_setup()
        {
            InitializeComponent();
        }

        private void cmbstructure_DropDown(object sender, EventArgs e)
        {
            //DataTable dt = clsDataAccess.RunQDTbl("select SalaryCategory,SlNo from tbl_Employee_SalaryStructure");
            //if (dt.Rows.Count > 0)
            //{
            //    cmbstructure.LookUpTable = dt;
            //    cmbstructure.ReturnIndex = 1;
            //}  
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {

            DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL");
            if (dt.Rows.Count > 0)
            {
                cmblocation.LookUpTable = dt;
                cmblocation.ReturnIndex = 1;
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record Found");
                cmblocation.LookUpTable = dt;
                cmblocation.ReturnIndex = 1;
            }

            //if (redlocation.Checked == false)
            //{
            //    DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID from tbl_Emp_Location where Location_ID not in (select distinct Location_ID from tbl_Employee_Link_SalaryStructure)");
            //    if (dt.Rows.Count > 0)
            //    {
            //        cmblocation.LookUpTable = dt;
            //        cmblocation.ReturnIndex = 1;
            //    }
            //    else
            //    {
            //        ERPMessageBox.ERPMessage.Show("No Record Found");
            //        cmblocation.LookUpTable = dt;
            //        cmblocation.ReturnIndex = 1;
            //    }
            //}
            //else
            //{
            //    DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID from tbl_Emp_Location ");
            //    if (dt.Rows.Count > 0)
            //    {
            //        cmblocation.LookUpTable = dt;
            //        cmblocation.ReturnIndex = 1;
            //    }
            //    else
            //    {
            //        ERPMessageBox.ERPMessage.Show("No Record Found");
            //        cmblocation.LookUpTable = dt;
            //        cmblocation.ReturnIndex = 1;
            //    }
            //}
        }

        private void cmbstructure_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Structure_ID = 0;
            //if (Information.IsNumeric(cmbstructure.ReturnValue) == true)
            //{
            //    Structure_ID = Convert.ToInt32(cmbstructure.ReturnValue);
            //    getdata();
            //}
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Location_ID = 0;
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
            {
                Location_ID = Convert.ToInt32(cmblocation.ReturnValue);
                getdata1();
            }
        }

        private void frm_salary_print_setup_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Location wise Salary Print Setup";
            //getdata();
        }

        private void btnnentry_Click(object sender, EventArgs e)
        {
            //cmbstructure.Text = "";
            cmblocation.Text = "";
            Structure_ID = 0;
            Location_ID = 0;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //DataTable dt1 = clsDataAccess.RunQDTbl("SELECT * FROM tbl_Employee_Link_SalaryStructure where Location_ID=" + Location_ID + " and SalaryStructure_ID=" + Structure_ID + "  ");
            //if (dt1.Rows.Count == 0)
            //{
            //    int Max_ID = 0;
            //    Boolean boolStatus = false;
            //    DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(Link_ID) FROM tbl_Employee_Link_SalaryStructure");
            //    if (Convert.ToString(dt.Rows[0][0]).Length > 0)
            //    {
            //        Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
            //    }
            //    else
            //    {
            //        Max_ID = 1;
            //    }

            //    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Link_SalaryStructure(Link_ID,Location_ID,SalaryStructure_ID) values('" + Max_ID + "','" + Location_ID + "','" + Structure_ID + "')");

            //    if (boolStatus == true)
            //        ERPMessageBox.ERPMessage.Show("Save Successfuly");
            //    else
            //        ERPMessageBox.ERPMessage.Show("No Record To Save");
            //}
            //else
            //    ERPMessageBox.ERPMessage.Show("Record Already Exists");

            //getdata();
            //btnnentry_Click(sender, e);


            ///////////////////////


            DataTable dt6 = new DataTable("contacts");

            dt6.Clear();
            dt6.Columns.Add("Location_id");
            dt6.Columns.Add("BankAcountNo");
           

            dt6.Columns.Add("DesignationName");
            dt6.Columns.Add("Basic");           
            dt6.Columns.Add("DaysPresent");
            dt6.Columns.Add("OT");           
            dt6.Columns.Add("TotalDays");

            dt6.Columns.Add("RefBankAcountNo");
            dt6.Columns.Add("RefDesignationName");
            dt6.Columns.Add("RefBasic");
            dt6.Columns.Add("RefDaysPresent");
            dt6.Columns.Add("RefOT");
            dt6.Columns.Add("RefTotalDays");
          
           
            for (int row = 0; row < dgvquery.Rows.Count ; row++)
            {
                DataRow dataRow = dt6.NewRow();
                dataRow["Location_id"] = dgvquery.Rows[row].Cells[0].Value;
                dataRow["BankAcountNo"] = dgvquery.Rows[row].Cells[1].Value;
                dataRow["DesignationName"] = dgvquery.Rows[row].Cells[2].Value;
                dataRow["Basic"] = dgvquery.Rows[row].Cells[3].Value;
                dataRow["DaysPresent"] = dgvquery.Rows[row].Cells[4].Value;
                dataRow["OT"] = dgvquery.Rows[row].Cells[5].Value;
                dataRow["TotalDays"] = dgvquery.Rows[row].Cells[6].Value;

                dataRow["RefBankAcountNo"] = 2;
                dataRow["RefDesignationName"] = 3;
                dataRow["RefBasic"] = 4;
                dataRow["RefDaysPresent"] = 5;
                dataRow["RefOT"] = 6;
                dataRow["RefTotalDays"] = 7;

                dt6.Rows.Add(dataRow);
            }

            dt6.AcceptChanges();

            //Boolean boolStatus = false;

            //if (dt6.Rows.Count > 0)
            //{
            //    foreach (DataRow dr6 in dt6.Rows)
            //    {
            //        boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Sal_Heads_Print (Location_id,BankAcountNo,DesignationName,Basic,DaysPresent,OT,TotalDays) values('" + Location_ID + "', '" + dr6[1] +"','" + dr6[2] +"','" + dr6[3] +"','" + dr6[4] +"','" + dr6[5] +"','" + dr6[6] +"')");

            //            if (boolStatus == true)
            //            {
            //                ERPMessageBox.ERPMessage.Show("Save Successfuly");
            //            }

            //            else
            //            {
            //                ERPMessageBox.ERPMessage.Show("No Record To Save");
            //            }
            //    }
            //}


            Boolean boolStatus = false;
            Boolean boolDelete = false;

            foreach (DataRow dr6 in dt6.Rows)
            {
                boolDelete = clsDataAccess.RunNQwithStatus("delete tbl_Sal_Heads_Print where Location_id='" + Location_ID + "'");

                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Sal_Heads_Print (Location_id,BankAcountNo,DesignationName,Basic,DaysPresent,OT,TotalDays,RefBankAcountNo,RefDesignationName,RefBasic,RefDaysPresent,RefOT,RefTotalDays) values('" + Location_ID + "', '" + dr6[1] + "','" + dr6[2] + "','" + dr6[3] + "','" + dr6[4] + "','" + dr6[5] + "','" + dr6[6] + "','" + dr6[7] + "','" + dr6[8] + "','" + dr6[9] + "','" + dr6[10] + "','" + dr6[11] + "','" + dr6[12] + "')");

            }

            if (boolStatus == true)
            {
                ERPMessageBox.ERPMessage.Show("Save Successfuly");
            }

            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save");
            }

            if (this.dgvquery.DataSource != null)
            {
                this.dgvquery.DataSource = null;
            }
            else
            {
                this.dgvquery.Rows.Clear();
            }

            dgvquery.Rows.Clear();
            dt6.Dispose();

            cmblocation.Text = "";


        }
        private void getdata1()
        {
            DataTable dt5 = clsDataAccess.RunQDTbl("SELECT (select  Location_Name from tbl_Emp_Location el where el.Location_id=e.Location_id ) as 'Location',e.BankAcountNo,e.DesignationName,e.Basic,e.DaysPresent,e.OT,e.TotalDays from tbl_Sal_Heads_Print e where e.Location_ID =" + Location_ID + "  ");
            //, e.RefBankAcountNo,e.RefDesignationName,e.RefBasic,e.RefDaysPresent,e.RefOT,e.RefTotalDays

            if (dt5.Rows.Count== 0)
            {
                DataRow dataRow5 = dt5.NewRow();
                dataRow5["Location"] = Location_ID ;
                dataRow5["BankAcountNo"] = false ;

                DataRow datarow6 = dt5.NewRow();

                dataRow5["DesignationName"] = false;
                dataRow5["Basic"] = false;
                dataRow5["DaysPresent"] = false;
                dataRow5["OT"] = false;
                dataRow5["TotalDays"] = false;

                //dataRow5["RefBankAcountNo"] =2;
                //dataRow5["RefDesignationName"] = 3;
                //dataRow5["RefBasic"] = 4;
                //dataRow5["RefDaysPresent"] = 5;
                //dataRow5["RefOT"] = 6;
                //dataRow5["RefTotalDays"] = 7;
              
                dt5.Rows.Add(dataRow5);

            }

            dt5.AcceptChanges();
            dgvquery.DataSource = dt5;


        }

        private void getdata()
        {
            //if (redstructure.Checked == true)
            //{
            //    DataTable dt = clsDataAccess.RunQDTbl(" select es.SalaryCategory ,el.Location_Name ,la.Location_ID,la.SalaryStructure_ID,la.Link_ID from tbl_Employee_Link_SalaryStructure la,tbl_Emp_Location el,tbl_Employee_SalaryStructure es where la.Location_ID = el.Location_ID and es.SlNo = la.SalaryStructure_ID and la.SalaryStructure_ID =" + Structure_ID + "  ");
            //    dgvquery.DataSource = dt;
            //}
            //else
            //{
            //    DataTable dt = clsDataAccess.RunQDTbl(" select es.SalaryCategory ,el.Location_Name ,la.Location_ID,la.SalaryStructure_ID,la.Link_ID from tbl_Employee_Link_SalaryStructure la,tbl_Emp_Location el,tbl_Employee_SalaryStructure es where la.Location_ID = el.Location_ID and es.SlNo = la.SalaryStructure_ID and la.Location_ID =" + Location_ID + "  ");
            //    dgvquery.DataSource = dt;
            //}

            DataTable dt = clsDataAccess.RunQDTbl("SELECT top 1   e.BankAcountNo,(select d.DesignationName from tbl_Employee_DesignationMaster d where d.SlNo=e.id) as 'DesignationName',(select basic from tbl_Employee_SalaryMast s where s.Emp_Id=e.id ) as 'Basic',(select DaysPresent from tbl_Employee_SalaryMast s where s.Emp_Id=e.id ) as 'DaysPresent',(select OT from tbl_Employee_SalaryMast s where s.Emp_Id=e.id ) as 'OT',(select TotalDays from tbl_Employee_SalaryMast s where s.Emp_Id=e.id ) as 'TotalDays' from tbl_Employee_Mast e where e.Location_ID =" + Location_ID + "  ");


            //dgvquery.DataSource = dt;

            // partha

            DataTable data;
            data = new DataTable("columnname");

            //DataColumn column_name = new DataColumn("Column_Name");
            //column_name.DataType = System.Type.GetType("System.String");
            //data.Columns.Add(column_name);

            //DataColumn TblColumnName = new DataColumn("Check");
            //TblColumnName.DataType = System.Type.GetType("System.String");
            //Check.ThreeState = false;
            //data.Columns.Add(TblColumnName);

            //foreach (DataColumn dc in dt.Columns)
            //{
            //    DataRow dataRow = data.NewRow();
            //    dataRow["Column_Name"] = dc.ColumnName;
            //    dataRow["Check"] = false;
            //    data.Rows.Add(dataRow);
            //}


            DataTable copyDataTable;

            copyDataTable = dt.Clone();

            copyDataTable.AcceptChanges();
            dgvquery.DataSource = copyDataTable;
            data.Dispose();
            copyDataTable.Dispose();

            //partha


            //dgvquery.Columns[2].Visible = false;
            //dgvquery.Columns[3].Visible = false;
            //dgvquery.Columns[4].Visible = false;

            //dgvquery.Columns[0].HeaderText = "Column_Name";
            //dgvquery.Columns[1].HeaderText = "Check";

            dgvquery.Columns[0].HeaderText = "BankAcountNo";
            dgvquery.Columns[1].HeaderText = "DesignationName";
            dgvquery.Columns[2].HeaderText = "Basic";
            dgvquery.Columns[3].HeaderText = "DaysPresent";
            dgvquery.Columns[4].HeaderText = "OT";
            dgvquery.Columns[5].HeaderText = "TotalDays";

            dgvquery.Columns[0].Width = 100;
            dgvquery.Columns[1].Width = 100;
            dgvquery.Columns[2].Width = 100;
            dgvquery.Columns[3].Width = 100;
            dgvquery.Columns[4].Width = 100;
            dgvquery.Columns[5].Width = 100;

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (Information.IsNumeric(dgvquery.Rows[dgvquery.CurrentRow.Index].Cells["Link_ID"].Value) == true)
            {
                int id = Convert.ToInt32(dgvquery.Rows[dgvquery.CurrentRow.Index].Cells["Link_ID"].Value);
                Boolean boolStatus = false;
                boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_Link_SalaryStructure where Link_ID=" + id + "");

                if (boolStatus)
                {
                    getdata();
                    ERPMessageBox.ERPMessage.Show("Deleted Successfully");
                }
                else
                    ERPMessageBox.ERPMessage.Show("Deleted Problem");
            }
            else
                ERPMessageBox.ERPMessage.Show("Select Currect Rows");

        }

        private void dgvquery_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvquery.Columns["BankAcountNo"].Index)
            {
                if (Convert.ToBoolean(dgvquery.Rows[e.RowIndex].Cells["BankAcountNo"].Value) == true)
                {
                    dgvquery.Rows[e.RowIndex].Cells["BankAcountNo"].Value = false;
                }
                else
                {
                    dgvquery.Rows[e.RowIndex].Cells["BankAcountNo"].Value = true;
                }
            }

            if (e.ColumnIndex == dgvquery.Columns["DesignationName"].Index)
            {
                if (Convert.ToBoolean(dgvquery.Rows[e.RowIndex].Cells["DesignationName"].Value) == true)
                {
                    dgvquery.Rows[e.RowIndex].Cells["DesignationName"].Value = false;
                }
                else
                {
                    dgvquery.Rows[e.RowIndex].Cells["DesignationName"].Value = true;
                }
            }

            if (e.ColumnIndex == dgvquery.Columns["Basic"].Index)
            {
                if (Convert.ToBoolean(dgvquery.Rows[e.RowIndex].Cells["Basic"].Value) == true)
                {
                    dgvquery.Rows[e.RowIndex].Cells["Basic"].Value = false;
                }
                else
                {
                    dgvquery.Rows[e.RowIndex].Cells["Basic"].Value = true;
                }
            }

            if (e.ColumnIndex == dgvquery.Columns["DaysPresent"].Index)
            {
                if (Convert.ToBoolean(dgvquery.Rows[e.RowIndex].Cells["DaysPresent"].Value) == true)
                {
                    dgvquery.Rows[e.RowIndex].Cells["DaysPresent"].Value = false;
                }
                else
                {
                    dgvquery.Rows[e.RowIndex].Cells["DaysPresent"].Value = true;
                }
            }

            if (e.ColumnIndex == dgvquery.Columns["OT"].Index)
            {
                if (Convert.ToBoolean(dgvquery.Rows[e.RowIndex].Cells["OT"].Value) == true)
                {
                    dgvquery.Rows[e.RowIndex].Cells["OT"].Value = false;
                }
                else
                {
                    dgvquery.Rows[e.RowIndex].Cells["OT"].Value = true;
                }
            }


            if (e.ColumnIndex == dgvquery.Columns["TotalDays"].Index)
            {
                if (Convert.ToBoolean(dgvquery.Rows[e.RowIndex].Cells["TotalDays"].Value) == true)
                {
                    dgvquery.Rows[e.RowIndex].Cells["TotalDays"].Value = false;
                }
                else
                {
                    dgvquery.Rows[e.RowIndex].Cells["TotalDays"].Value = true;
                }
            }

            dgvquery.EndEdit();  //Stop editing of cell.

           
            //if (e.ColumnIndex == dgvquery.Columns["Check"].Index)
            //{

               

            //    //if ((bool)dgvquery.Rows[e.RowIndex].Cells["Check"].Value)

            //    //    MessageBox.Show("The Value is Checked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    //else

            //    //    MessageBox.Show("UnChecked", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

        }

        private void dgvquery_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
                      
        }
    }
}
