using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class Designation_Master : EDPComponent.FormBaseERP 
    {
        public Designation_Master()
        {
            InitializeComponent();
        }
        #region Functions

        private void GetDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select SlNo,DesignationName,ShortForm,(select type from tbl_desg_type where slno=edm.type)dtype, type as dstype from tbl_Employee_DesignationMaster edm");
            if (dt.Rows.Count > 0)
            {
                DgDesignation.DataSource = dt;
            }
        }
        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;

            if (DgDesignation.Rows.Count > 1)
            {
                String strSlno = Convert.ToString(DgDesignation.CurrentRow.Cells["SerialNo"].Value);

                DataTable dt = clsDataAccess.RunQDTbl("Select Code from tbl_Employee_Mast where DesgId='" + strSlno + "' ");
                if (dt.Rows.Count == 0)
                {
                    if (!String.IsNullOrEmpty(strSlno))
                    {
                        boolStatus = clsDataAccess.RunNQwithStatus("Delete from tbl_Employee_DesignationMaster where SlNo=" + strSlno + "");
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Designation Details Does Not Exists. Cannot Delete Selected Designation Details.");
                    }
                }
                else
                    ERPMessageBox.ERPMessage.Show("Designation Name Already Use");                    
            }
            else
                ERPMessageBox.ERPMessage.Show("No Record To Delete");

            return boolStatus;
        }


        private bool HasDuplicates(System.Data.DataTable dataTable)
        {
            System.Data.DataTable duplicateTable = dataTable.Copy();
            duplicateTable.Columns.RemoveAt(0);
            duplicateTable.AcceptChanges();
            System.Data.DataColumn[] primaryKey = new System.Data.DataColumn[duplicateTable.Columns.Count];
            duplicateTable.Columns.CopyTo(primaryKey, 0);

            try
            {
 duplicateTable.PrimaryKey = primaryKey;
 return true;
            }
            catch {
                //ERPMessageBox.ERPMessage.Show("Please Remove Duplicate Designation !");
                return false;
            }

        }

        private bool SubmitDetails()
        {

            DataTable dt = new DataTable();
            dt = (DataTable)DgDesignation.DataSource;
            //HasDuplicates(dt);

            //dt.Columns.Add("DesignationName");
            //dt.Columns.Add("menu_title");
            //dt.Columns.Add("menu_target");
            //dt.Columns.Add("menu_url");
            //dt.Columns.Add("sub_menuof");
            //dt.PrimaryKey = new DataColumn[] { dt.Columns["menu_id"] };

            int rw = DgDesignation.Rows.Count;
            Boolean boolStatus = false;
            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            
            //arrListIDs.Clear();
            for (int i = 0; i < DgDesignation.Rows.Count - 1; i++)
            {
                //int empID = int.Parse(DgJobType.Rows[0].Cells["JobType"].Value.ToString());
                string empID = DgDesignation.Rows[i].Cells["DesignationName"].Value.ToString().Trim();
                string dtype = DgDesignation.Rows[i].Cells["dstype"].Value.ToString().Trim();
                try
                {
                    if (!arrListIDs.Contains(empID) )
                    {
                        arrListIDs.Add(empID);
                        //arrListIDs[i, 1].Add(dtype);
                        //do ur code
                    }
                    else
                    {
                        MessageBox.Show("Duplicate row! No Record To Save");
                        boolStatus = false;
                        return boolStatus;
                    }
                }
                catch
                {

                }
            }

            //if (HasDuplicates(dt))
            //{


            //}
            //else
            //{
            //    ERPMessageBox.ERPMessage.Show("Please Remove Duplicate Designation !");
            //}
            //return boolStatus;

            if (DgDesignation.Rows.Count > 1)
            {
                for (Int32 i = 0; i < DgDesignation.Rows.Count - 1; i++)
                {
                    String strSlNo = Convert.ToString(DgDesignation.Rows[i].Cells["SerialNo"].Value).Trim();
                    String strDesignationName = Convert.ToString(DgDesignation.Rows[i].Cells["DesignationName"].Value).Trim();
                    String ShortForm = Convert.ToString(DgDesignation.Rows[i].Cells["ShortName"].Value).Trim();
                    string type = DgDesignation.Rows[i].Cells["dstype"].Value.ToString().Trim();
                    if (!String.IsNullOrEmpty(strDesignationName))
                    {
                        if (!String.IsNullOrEmpty(ShortForm))
                        {
                            if (!String.IsNullOrEmpty(strSlNo))
                            {

                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_DesignationMaster set DesignationName='" + strDesignationName + "',ShortForm='" + ShortForm + "',type='"+type+"' where (SlNo=" + strSlNo + ")");
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(type))
                                {

                                    type = "0";
                                }
                                //boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_DesignationMaster(DesignationName,ShortForm) values('" + strDesignationName + "','" + ShortForm + "')");

                                DataTable dt33 = clsDataAccess.RunQDTbl("Select SlNo,DesignationName from tbl_Employee_DesignationMaster where (DesignationName='" + strDesignationName + "')");
                                if (dt33.Rows.Count == 0)
                                {
                                    
                                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_DesignationMaster(DesignationName,ShortForm,type) values('" + strDesignationName + "','" + ShortForm + "','"+type+"')");
                                }
                                else
                                {
                                    ERPMessageBox.ERPMessage.Show("DesignationName " + strDesignationName + " Already Exists");
                                    boolStatus = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Designation Details for " + i + "th Row.");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
            return boolStatus;
        }
        #endregion


        #region PageEvents

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show("Designation Details Saved Successfully");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Designation Details");
            }
        }

        private void Designation_Master_Load(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("Designation Details Deleted Successfully");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void DgDesignation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((DgDesignation.CurrentCell.ColumnIndex == DgDesignation.Columns["dtype"].Index) || (DgDesignation.CurrentCell.ColumnIndex == DgDesignation.Columns["dstype"].Index))
            {
                DialogView dv = new DialogView();
                dv.sql_frm = "SELECT slno,Type,type_short FROM tbl_desg_type";
                dv.retno = 2;
                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;
                dv.ShowDialog();

                try
                {
                    int ind = Convert.ToInt32(DgDesignation.CurrentRow.Index);

                    this.DgDesignation.Rows[ind].Cells["dtype"].Value = dv.retval1.ToString();
                    this.DgDesignation.Rows[ind].Cells["dstype"].Value = dv.retval.ToString();

                }
                catch { }
            }

        }


    }


}