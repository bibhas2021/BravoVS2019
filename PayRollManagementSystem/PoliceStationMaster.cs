using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class PoliceStationMaster : Form
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public PoliceStationMaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SubmitDetails())
            {
                ERPMessageBox.ERPMessage.Show(" PoliceStation details Saved Successfully");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit PoliceStation details");
            }
       

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteDetails())
            {
                GetDetails();
                ERPMessageBox.ERPMessage.Show("PoliceStation details Deleted Successfully");
            }
            else
            {

            }
       
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Boolean SubmitDetails()
        {
            Boolean boolstatus = false;

            System.Collections.ArrayList arrListIDs = new System.Collections.ArrayList();
            arrListIDs.Clear();
            for (int i = 0; i < dgv_ps.Rows.Count - 1; i++)
            {
                
                string empID = dgv_ps.Rows[i].Cells["col_PS"].Value.ToString().Trim();
                if (!arrListIDs.Contains(empID))
                {
                    arrListIDs.Add(empID);
                    
                }
                else
                {
                    MessageBox.Show("Duplicate row! No Record To Save");
                    boolstatus = false;
                    return boolstatus;
                }
            }
            if (dgv_ps.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgv_ps.Rows.Count - 1; i++)
                {
                    String strSlNo = Convert.ToString(dgv_ps.Rows[i].Cells["col_psid"].Value);
                    String strCategory = Convert.ToString(dgv_ps.Rows[i].Cells["col_PS"].Value);
                    String stradd = Convert.ToString(dgv_ps.Rows[i].Cells["col_add"].Value);
                    String strdist = Convert.ToString(dgv_ps.Rows[i].Cells["col_dist"].Value);
                    String strstate = Convert.ToString(dgv_ps.Rows[i].Cells["col_state"].Value);
                    String strzip = Convert.ToString(dgv_ps.Rows[i].Cells["col_zip"].Value);
                    String strjur = Convert.ToString(dgv_ps.Rows[i].Cells["col_pin"].Value);

                    if (!String.IsNullOrEmpty(strjur)) 
                    {
                        if (!String.IsNullOrEmpty(stradd))
                        {
                            if (!String.IsNullOrEmpty(strCategory))
                            {
                                if (!String.IsNullOrEmpty(strSlNo))
                                {
                                    DataTable dt = clsDataAccess.RunQDTbl("Select psid from tbl_Emp_verifystatus Where (psid='" + strSlNo + "')");
                                    if (dt.Rows.Count == 0)
                                    {
                                        boolstatus = clsDataAccess.RunNQwithStatus("update PS_Master set PoliceStation='" + strCategory + "',address='" + stradd + "',dist='"+strdist+"',state='"+strstate+"',zip='"+strzip+"',jurisdiction='" + strjur + "' where (psid=" + strSlNo + ")");
                                    }
                                    else if (dt.Rows.Count > 0)
                                    {
                                        boolstatus = clsDataAccess.RunNQwithStatus("update PS_Master set address='" + stradd + "',dist='" + strdist + "',state='" + strstate + "',zip='" + strzip + "',jurisdiction='" + strjur + "' where (psid=" + strSlNo + ")");
                                    }
                                }
                                else
                                {
                                    int Max_ID = 0;
                                    DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(psid) FROM PS_Master");
                                    if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                                    {
                                        Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                                    }
                                    else
                                    {
                                        Max_ID = 1;
                                    }

                                    boolstatus = clsDataAccess.RunNQwithStatus("insert into PS_Master(PoliceStation,address,dist,state,zip,jurisdiction,psid) values('" + strCategory + "','" + stradd + "','" + strdist + "','" + strstate + "','"+ strzip + "','" + strjur + "','" + Max_ID + "')");

                                }

                                edpcom.InsertMidasLog(this, true, "add", "policestation :" + strSlNo);
                            }
                            else
                            {
                                ERPMessageBox.ERPMessage.Show("Please Enter policestation name for " + i + "th Row.");
                            }

                        }
                        else
                        {
                            ERPMessageBox.ERPMessage.Show("Please Enter policestation address for " + i + "th Row.");
                        }

                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter policestation jurisdiction for " + i + "th Row.");
                    }

                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Save");
            }
         
            return boolstatus;
            
        }

        private void GetDetails()
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select psid,PoliceStation,address,jurisdiction as pin,dist, state, zip from PS_Master");
            if (dt.Rows.Count > 0)
            {
                dgv_ps.DataSource = dt;
            }
        }

        private void PoliceStationMaster_Load(object sender, EventArgs e)
        {
            //this.HeaderText = " Master";
            GetDetails();
        }
        private Boolean DeleteDetails()
        {
            Boolean boolStatus = false;
            if (dgv_ps.Rows.Count > 1)
            {
                String strSlno = Convert.ToString(dgv_ps.CurrentRow.Cells["col_psid"].Value);
                String strCatg = Convert.ToString(dgv_ps.CurrentRow.Cells["col_PS"].Value);

                if (!String.IsNullOrEmpty(strSlno))
                {
                    DataTable dt = clsDataAccess.RunQDTbl("Select  psid from tbl_Emp_verifystatus Where psid='" + strSlno + "'");
                    if (dt.Rows.Count > 0)
                    {
                        ERPMessageBox.ERPMessage.Show("PoliceStation Name Used So Delete Not Possible");
                    }
                    else
                        boolStatus = clsDataAccess.RunNQwithStatus("Delete from PS_Master where psid=" + strSlno + "");

                    edpcom.InsertMidasLog(this, true, "del", "policestation :" + strCatg);
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Section Does Not Exists. Cannot Delete Selected policestation name.");
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("No Record To Delete");
            }
            return boolStatus;
        }

  
    }
}
