using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FirstTimeNeed;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Edpcom;

namespace PayRollManagementSystem
{
   

    public partial class frmVendor : Form
    {
        public frmVendor()
        {
            InitializeComponent();
        }

        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();

        public void get()
        {
            DataTable dt = clsDataAccess.RunQDTbl("Select * from MstVendor");
            dgv_show.DataSource = dt;

        }
        private void frmVendor_Load(object sender, EventArgs e)
        {
            get();
        }

        public Boolean submit_det()
        {
            Boolean boolstatus = false;
            string vid, vendor, Address, City, State, ContactNo, Mob, Website, Email, Gstin, Lin, Pan;
            if (dgv_show.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgv_show.Rows.Count - 1; i++)
                {
                    vid = Convert.ToString(dgv_show.Rows[i].Cells["vid"].Value);
                    vendor = Convert.ToString(dgv_show.Rows[i].Cells["vendor"].Value);
                    Address = Convert.ToString(dgv_show.Rows[i].Cells["Address"].Value).Replace("'", "''");
                    City = Convert.ToString(dgv_show.Rows[i].Cells["City"].Value);
                    State = Convert.ToString(dgv_show.Rows[i].Cells["State"].Value);
                    ContactNo = Convert.ToString(dgv_show.Rows[i].Cells["ContactNo"].Value);
                    Mob = Convert.ToString(dgv_show.Rows[i].Cells["Mob"].Value);
                    Website = Convert.ToString(dgv_show.Rows[i].Cells["Website"].Value);
                    Email = Convert.ToString(dgv_show.Rows[i].Cells["Email"].Value);
                    Gstin = Convert.ToString(dgv_show.Rows[i].Cells["Gstin"].Value);
                    Lin = Convert.ToString(dgv_show.Rows[i].Cells["Lin"].Value);
                    Pan = Convert.ToString(dgv_show.Rows[i].Cells["Pan"].Value);

                    if (!String.IsNullOrEmpty(vendor))
                    {
                        if (!String.IsNullOrEmpty(vid))
                        {
                            DataTable dt = clsDataAccess.RunQDTbl("Select count(*) from MstVendor Where (vid='" + vid + "')");
                            if (dt.Rows.Count > 0)
                            {
                                boolstatus = clsDataAccess.RunNQwithStatus("update MstVendor set vendor='" + vendor +
                               "',Address='" + Address + "',City='" + City + "',State='" + State + "',ContactNo='" + ContactNo +
                               "',Mob='" + Mob + "',Website='" + Website + "',Email='" + Email + "',Gstin='" + Gstin + "',Lin='" + Lin + "',Pan='" + Pan + "' where (vid=" + vid + ")");
                            }
                            edpcom.InsertMidasLog(this, true, "modify", "Vendor :" + vid);
                        }
                        else
                        {
                            int Max_ID = 0;
                            DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(vid) FROM MstVendor");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }

                            vid = Max_ID.ToString();
                            boolstatus = clsDataAccess.RunNQwithStatus("insert into MstVendor(vid,vendor,Address,City,State,ContactNo,Mob,Website,Email,Gstin,Lin,Pan) values('" +
                            vid + "','" + vendor + "','" + Address + "','" + City + "','" + State + "','" + ContactNo + "','" + Mob + "','" + Website + "','" + Email + "','" + Gstin + "','" + Lin + "','" + Pan + "')");

                            edpcom.InsertMidasLog(this, true, "add", "Vendor :" + vid);
                        }

                        //edpcom.InsertMidasLog(this, true, "add", "purchase :" + pid);
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("Please Enter Vendor Name for " + i + "th Row.");
                    }

                }

            }
            return boolstatus;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (submit_det())
            {
                ERPMessageBox.ERPMessage.Show("Vendor Details Saved Successfully");
                get();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Vendor details");
            }


            
        }

        
    }
}
