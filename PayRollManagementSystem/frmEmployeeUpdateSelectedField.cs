using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace PayRollManagementSystem
{
    public partial class frmEmployeeUpdateSelectedField : EDPComponent.FormBaseERP
    {
        int CurrentTopRowIndex = 0;
        Hashtable htFailedInsertion = new Hashtable();
        Boolean ErrorOccured = false;

        public frmEmployeeUpdateSelectedField()
        {
            InitializeComponent();
        }

        private void frmEmployeeUpdateSelectedField_Load(object sender, EventArgs e)
        {
            this.HeaderText = "Update Employee related Single Field";

        }

        private void cmbNameOfRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbNameOfRecord.Text.Trim())
            { 
                case "Date Of Birth":
                    CurrentTopRowIndex = 0;
                    EmployeeDOBFetch();
                    break;
                case "Date Of Joining":
                    CurrentTopRowIndex = 0;
                    EmployeeDOJFetch();
                    break;
                case "UAN":
                    CurrentTopRowIndex = 0;
                    EmployeeUANFetch();
                    break;

            }
        }

        private void EmployeeDOBFetch()
        {
            DataTable dtEmployeeDateOfBirth = clsDataAccess.RunQDTbl("select ID,[Title]+' ' +[FirstName]+' ' +[MiddleName]+' ' +[LastName] as 'EmployeeName',convert(varchar,DateOfBirth,103) as 'DateOfBirth' from tbl_Employee_Mast");
            dgvUpdateEmployee.DataSource = dtEmployeeDateOfBirth;
            dgvUpdateEmployee.Columns["ID"].ReadOnly = true;
            dgvUpdateEmployee.Columns["EmployeeName"].ReadOnly = true;
        }

        public void EmployeeDOJFetch()
        {
            DataTable dtEmployeeDateOfBirth = clsDataAccess.RunQDTbl("select ID,[Title]+' ' +[FirstName]+' ' +[MiddleName]+' ' +[LastName] as 'EmployeeName',convert(varchar,DateOfJoining,103) as 'DateOfJoining' from tbl_Employee_Mast");
            dgvUpdateEmployee.DataSource = dtEmployeeDateOfBirth;
            dgvUpdateEmployee.Columns["ID"].ReadOnly = true;
            dgvUpdateEmployee.Columns["EmployeeName"].ReadOnly = true;
        }

        public void EmployeeUANFetch()
        {
            DataTable dtEmployeeDateOfBirth = clsDataAccess.RunQDTbl("select ID,[Title]+' ' +[FirstName]+' ' +[MiddleName]+' ' +[LastName] as 'EmployeeName',PassportNo as 'UAN' from tbl_Employee_Mast");
            dgvUpdateEmployee.DataSource = dtEmployeeDateOfBirth;
            dgvUpdateEmployee.Columns["ID"].ReadOnly = true;
            dgvUpdateEmployee.Columns["EmployeeName"].ReadOnly = true;
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        private void FindNext()
        {
            if (dgvUpdateEmployee.Rows.Count > 0 && !String.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                CurrentTopRowIndex = dgvUpdateEmployee.FirstDisplayedCell.RowIndex;
                for (int i = CurrentTopRowIndex; i < dgvUpdateEmployee.Rows.Count; i++)
                {
                    if (dgvUpdateEmployee.Rows[i].Cells["ID"].Value.ToString().ToLower().Contains(txtSearch.Text.ToString().Trim().ToLower()))
                    {
                        dgvUpdateEmployee.FirstDisplayedScrollingRowIndex = i;
                        if (dgvUpdateEmployee.CurrentCell != dgvUpdateEmployee.Rows[i].Cells["ID"])
                        {
                            dgvUpdateEmployee.CurrentCell = dgvUpdateEmployee.Rows[i].Cells["ID"];
                            break;
                        }
                        else
                            continue;
                    }
                    else if (dgvUpdateEmployee.Rows[i].Cells["EmployeeName"].Value.ToString().ToLower().Contains(txtSearch.Text.Trim().ToLower()))
                    {
                        dgvUpdateEmployee.FirstDisplayedScrollingRowIndex = i;
                        if (dgvUpdateEmployee.CurrentCell != dgvUpdateEmployee.Rows[i].Cells["EmployeeName"])
                        {
                            dgvUpdateEmployee.CurrentCell = dgvUpdateEmployee.Rows[i].Cells["EmployeeName"];
                            break;
                        }
                        else
                            continue;
                    }
                }
            }
        }

        private void btnFindPrevious_Click(object sender, EventArgs e)
        {
            FindPrevious();
        }

        private void FindPrevious()
        {
            if (dgvUpdateEmployee.Rows.Count > 0 && !String.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                CurrentTopRowIndex = dgvUpdateEmployee.FirstDisplayedCell.RowIndex+dgvUpdateEmployee.DisplayedRowCount(false);
                for (int i = CurrentTopRowIndex; i > 0; i--)
                {
                    if (dgvUpdateEmployee.Rows[i].Cells["ID"].Value.ToString().ToLower().Contains(txtSearch.Text.ToString().Trim().ToLower()))
                    {
                        dgvUpdateEmployee.FirstDisplayedScrollingRowIndex = i;
                        if (dgvUpdateEmployee.CurrentCell != dgvUpdateEmployee.Rows[i].Cells["ID"])
                        {
                            dgvUpdateEmployee.CurrentCell = dgvUpdateEmployee.Rows[i].Cells["ID"];
                            break;
                        }
                        else
                            continue;
                    }
                    else if (dgvUpdateEmployee.Rows[i].Cells["EmployeeName"].Value.ToString().ToLower().Contains(txtSearch.Text.Trim().ToLower()))
                    {
                        dgvUpdateEmployee.FirstDisplayedScrollingRowIndex = i;
                        if (dgvUpdateEmployee.CurrentCell != dgvUpdateEmployee.Rows[i].Cells["EmployeeName"])
                        {
                            dgvUpdateEmployee.CurrentCell = dgvUpdateEmployee.Rows[i].Cells["EmployeeName"];
                            break;
                        }
                        else
                            continue;
                    }
                }
            }
        }

        private string func_dt(string vdt, string eid, string datetype)
        {
            string[] dateonly = vdt.Split(' ');
            vdt = dateonly[0];
            String[] strArr_Name = new String[2];
            strArr_Name = vdt.Split('/', '.', '-');
            //Edited by dwipraj dutta 080820170627PM
            try
            {
                DateTime dttt;

                Int32 mn_val = Convert.ToInt32(strArr_Name[1]);
                string mnthvalue = mn_val.ToString();
                if (mnthvalue.Length < 2)
                    mnthvalue = 0 + mnthvalue;
                string rtn = strArr_Name[0] + "/" + (mnthvalue) + "/" + strArr_Name[2];
                dttt = DateTime.ParseExact(rtn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                rtn = dttt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                return rtn;
            }
            catch
            {
                string typ = "";
                if (datetype == "dob")
                    typ = "Date Of Birth";
                else if (datetype == "doj")
                    typ = "Date Of joining";
                htFailedInsertion["Record"] = htFailedInsertion["Record"] + typ + " error | ";
                htFailedInsertion["Reason"] = htFailedInsertion["Reason"] + "Wrong Date format | ";
                ErrorOccured = true;
                //ERPMessageBox.ERPMessage.Show("We have encountered a problem while inserting " + typ + " of " + eid + " employee, no such date exists. Please change the " + typ + " of the employee from Master->Employee Master->Employee Joining after insertion of all records." + Environment.NewLine + "By Default the date will be saved as 01/01/1900.");
                return null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (cmbNameOfRecord.Text.Trim())
            {
                case "Date Of Birth":
                    CurrentTopRowIndex = 0;
                    for (int i = 0; i < dgvUpdateEmployee.Rows.Count; i++)
                    {
                        string EID = dgvUpdateEmployee.Rows[i].Cells["ID"].Value.ToString();
                        string EDOB = dgvUpdateEmployee.Rows[i].Cells["DateOfBirth"].Value.ToString();
                        string strUpdateDOB = "update tbl_Employee_Mast set DateOfBirth = '" + func_dt(EDOB, EID, "dob") + "' where ID = '" + EID + "'";
                        Boolean boolStatus = clsDataAccess.RunNQwithStatus(strUpdateDOB);
                    }
                    cmbNameOfRecord.SelectedIndex = 0;
                    break;
                case "Date Of Joining":
                    CurrentTopRowIndex = 0;
                    for (int i = 0; i < dgvUpdateEmployee.Rows.Count; i++)
                    {
                        string EID = dgvUpdateEmployee.Rows[i].Cells["ID"].Value.ToString();
                        string EDOJ = dgvUpdateEmployee.Rows[i].Cells["DateOfJoining"].Value.ToString();
                        string strUpdateDOB = "update tbl_Employee_Mast set DateOfJoining = '" + func_dt(EDOJ, EID, "doj") + "' where ID = '" + EID + "'";
                        Boolean boolStatus = clsDataAccess.RunNQwithStatus(strUpdateDOB);
                    }
                    cmbNameOfRecord.SelectedIndex = 1;
                    break;
                case "UAN":
                    for (int i = 0; i < dgvUpdateEmployee.Rows.Count; i++)
                    {
                        string EID = dgvUpdateEmployee.Rows[i].Cells["ID"].Value.ToString();
                        string EUAN = dgvUpdateEmployee.Rows[i].Cells["UAN"].Value.ToString();
                        string strUpdateDOB = "update tbl_Employee_Mast set PassportNo = '" + EUAN + "' where ID = '" + EID + "'";
                        Boolean boolStatus = clsDataAccess.RunNQwithStatus(strUpdateDOB);
                    }
                    cmbNameOfRecord.SelectedIndex = 2;
                    break;

            }
        }

    }
}
