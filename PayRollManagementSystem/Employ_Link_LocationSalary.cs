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
    public partial class Employ_Link_LocationSalary : EDPComponent.FormBaseERP
    {
        int Location_ID = 0, Structure_ID = 0;
        public Employ_Link_LocationSalary()
        {
            InitializeComponent();
        }

        private void cmbstructure_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select SalaryCategory,SlNo from tbl_Employee_SalaryStructure");
            if (dt.Rows.Count > 0)
            {
                cmbstructure.LookUpTable = dt;
                cmbstructure.ReturnIndex = 1;
            }  
        }

        private void cmblocation_DropDown(object sender, EventArgs e)
        {
            if (redlocation.Checked == false)
            {
                DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM  tbl_Employee_CliantMaster where client_id=EL.Cliant_ID)as ClientName from tbl_Emp_Location EL where Location_ID not in (select distinct Location_ID from tbl_Employee_Link_SalaryStructure ) order by Location_Name");
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
            }
            else
            {
                DataTable dt = clsDataAccess.RunQDTbl("select Location_Name,Location_ID,(SELECT Client_Name FROM tbl_Employee_CliantMaster where client_id=EL.Cliant_ID) as ClientName from tbl_Emp_Location EL");
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
            }
        }

        private void cmbstructure_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Structure_ID = 0;
            if (Information.IsNumeric(cmbstructure.ReturnValue) == true)
            {
                Structure_ID = Convert.ToInt32(cmbstructure.ReturnValue);
                getdata();
            }
        }

        private void cmblocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            Location_ID = 0;
            if (Information.IsNumeric(cmblocation.ReturnValue) == true)
            {
                Location_ID = Convert.ToInt32(cmblocation.ReturnValue);
                getdata();
            }
        }

        private void Employ_Link_LocationSalary_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Link Location wise Salary Structure";           
        }

        private void btnnentry_Click(object sender, EventArgs e)
        {
            cmbstructure.Text = "";
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
            DataTable dt1 = clsDataAccess.RunQDTbl("SELECT * FROM tbl_Employee_Link_SalaryStructure where Location_ID=" + Location_ID + " and SalaryStructure_ID=" + Structure_ID + "  ");
            if (dt1.Rows.Count == 0)
            {
                int Max_ID = 0;
                Boolean boolStatus = false;
                DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(Link_ID) FROM tbl_Employee_Link_SalaryStructure");
                if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                {
                    Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                }
                else
                {
                    Max_ID = 1;
                }

                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Link_SalaryStructure(Link_ID,Location_ID,SalaryStructure_ID) values('" + Max_ID + "','" + Location_ID + "','" + Structure_ID + "')");

                if (boolStatus == true)
                    ERPMessageBox.ERPMessage.Show("Save Successfuly");
                else
                    ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
            else
                ERPMessageBox.ERPMessage.Show("Record Already Exists");

            getdata();
            btnnentry_Click(sender, e);
        }

        private void getdata()
        {
            if (redstructure.Checked == true)
            {
                DataTable dt = clsDataAccess.RunQDTbl(" select es.SalaryCategory ,el.Location_Name ,la.Location_ID,la.SalaryStructure_ID,la.Link_ID from tbl_Employee_Link_SalaryStructure la,tbl_Emp_Location el,tbl_Employee_SalaryStructure es where la.Location_ID = el.Location_ID and es.SlNo = la.SalaryStructure_ID and la.SalaryStructure_ID =" + Structure_ID + "  ");
                dgvquery.DataSource = dt;
            }
            else
            {
                DataTable dt = clsDataAccess.RunQDTbl(" select es.SalaryCategory ,el.Location_Name ,la.Location_ID,la.SalaryStructure_ID,la.Link_ID from tbl_Employee_Link_SalaryStructure la,tbl_Emp_Location el,tbl_Employee_SalaryStructure es where la.Location_ID = el.Location_ID and es.SlNo = la.SalaryStructure_ID and la.Location_ID =" + Location_ID + "  ");
                dgvquery.DataSource = dt;
            }
           
            dgvquery.Columns[2].Visible = false;
            dgvquery.Columns[3].Visible = false;
            dgvquery.Columns[4].Visible = false;

            dgvquery.Columns[0].HeaderText = "Salary Structure";
            dgvquery.Columns[1].HeaderText = "Location Name";
            dgvquery.Columns[0].Width = 255;
            dgvquery.Columns[1].Width = 250;

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (Information.IsNumeric(dgvquery.Rows[dgvquery.CurrentRow.Index].Cells["Link_ID"].Value) == true)
            {
                int id = Convert.ToInt32(dgvquery.Rows[dgvquery.CurrentRow.Index].Cells["Link_ID"].Value);
                string strSalStructureID = dgvquery.Rows[dgvquery.CurrentRow.Index].Cells["SalaryStructure_ID"].Value.ToString();
                int lid = Location_ID;
                Boolean boolStatus = false;

                if (!String.IsNullOrEmpty(strSalStructureID))
                {
                    DataTable dtAlreadyLinkedOrNot = clsDataAccess.RunQDTbl("select * from tbl_Employee_Assign_SalStructure where SAL_STRUCT = " + strSalStructureID);
                    if (dtAlreadyLinkedOrNot.Rows.Count == 0)
                        boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_Link_SalaryStructure where Link_ID='" + id + "'");//Link_ID=" + id + "");
                    else
                        EDPMessageBox.EDPMessage.Show("Cannot be deleted because this salary structure already have some salary heads assigned.");
                }
                //boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_Link_SalaryStructure where Location_ID='"+ lid +"'");//Link_ID=" + id + "");

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

        private void btnSalStruct_Click(object sender, EventArgs e)
        {
            Employee_Salary_Structure ess = new Employee_Salary_Structure();
            ess.ShowDialog();
        }
    }
}
