using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmEnclosureList : Form
    {
        public frmEnclosureList()
        {
            InitializeComponent();
        }

        private void GetDetails()
        {
            int ind = 0;
            dgZone.Rows.Clear();
            DataTable dt = clsDataAccess.RunQDTbl("Select eid,enclosure,active from tbl_enclosure");
            if (dt.Rows.Count > 0)
            {
                // DgDesignation.DataSource = dt;
                for (int inx = 0; inx < dt.Rows.Count; inx++)
                {

                    ind = dgZone.Rows.Add();
                    dgZone.Rows[ind].Cells["slno"].Value = dt.Rows[inx]["eid"].ToString();
                    dgZone.Rows[ind].Cells["enclosure"].Value = dt.Rows[inx]["enclosure"].ToString();
                    dgZone.Rows[ind].Cells["Active"].Value = dt.Rows[inx]["active"].ToString();
                    if (Convert.ToInt32(dt.Rows[inx]["active"].ToString()) > 0)
                    {
                        dgZone.Rows[ind].DefaultCellStyle.BackColor = Color.Cyan;

                    }

                }
            }
        }
        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;

            if (dgZone.Rows.Count > 1)
            {
                String strSlno = Convert.ToString(dgZone.CurrentRow.Cells["slno"].Value);

                String strActive = Convert.ToString(dgZone.CurrentRow.Cells["active"].Value);


                if (!String.IsNullOrEmpty(strSlno) || strActive == "0")
                {
                    clsDataAccess.RunQry("Delete from tbl_enclosure where (eid=" + strSlno + ")"); boolStatus = true;
                    //MessageBox.Show("Zone Deleted");
                }
                else
                {
                    MessageBox.Show("Enclosure cannot be deleted.");
                }

            }
            else
                MessageBox.Show("No Record To Delete");

            return boolStatus;
        }

        private bool SubmitDetails()
        {

            DataTable dt = new DataTable();
            dt = (DataTable)dgZone.DataSource;

            Boolean boolStatus = false;
            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            arrListIDs.Clear();
            for (int i = 0; i < dgZone.Rows.Count - 1; i++)
            {

                string vZone = dgZone.Rows[i].Cells["enclosure"].Value.ToString().Trim();
                if (!arrListIDs.Contains(vZone))
                {
                    arrListIDs.Add(vZone);
                    //do ur code
                }
                else
                {
                    MessageBox.Show("Duplicate row! Enclosure: " + vZone + ",  Please Change");
                    boolStatus = false;
                    return boolStatus;
                }
            }



            if (dgZone.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgZone.Rows.Count - 1; i++)
                {
                    String strSlNo = Convert.ToString(dgZone.Rows[i].Cells["slno"].Value);
                    String strZone = Convert.ToString(dgZone.Rows[i].Cells["enclosure"].Value);
                    String active = Convert.ToString(dgZone.Rows[i].Cells["Active"].Value);

                    if (!String.IsNullOrEmpty(strZone))
                    {
                        //if (!String.IsNullOrEmpty(active))
                        //{
                        if (!String.IsNullOrEmpty(strSlNo))
                        {

                            clsDataAccess.RunQry("update tbl_enclosure set enclosure='" + strZone + "' where (eid=" + strSlNo + ")");
                            boolStatus = true;
                        }

                        else
                        {

                            DataTable dt33 = clsDataAccess.RunQDTbl("Select eid,enclosure,active from tbl_enclosure where (enclosure='" + strZone + "')");
                            if (dt33.Rows.Count == 0)
                            {
                                string slno = clsDataAccess.GetresultS("select isNull(max(eid),0)+1 from tbl_enclosure");
                                clsDataAccess.RunQry("insert into tbl_enclosure(eid,enclosure,active) values('" + slno + "','" + strZone + "','0')");
                                boolStatus = true;
                            }
                            else
                            {
                                MessageBox.Show("Enclosure : " + strZone + " Already Exists");
                                boolStatus = false;
                            }
                        }
                        //}
                    }
                    else
                    {
                        MessageBox.Show("Enlosure Blank in " + i + "th Row.");
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Save");
            }
            return boolStatus;
        }

        private void frmEnclosueList_Load(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                MessageBox.Show("Enclosure Deleted Successfully");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                MessageBox.Show("Enclosure Saved Successfully");
                GetDetails();
            }
            else
            {
                MessageBox.Show("Failed To Submit");
            }
        }
    }
}
