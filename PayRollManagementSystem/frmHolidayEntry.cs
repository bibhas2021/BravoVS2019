using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmHolidayEntry :Form // EDPComponent.FormBaseERP 
    {
        public frmHolidayEntry()
        {
            InitializeComponent();
        }

        private void frmHolidayEntry_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1);
            //set session
            if (System.DateTime.Now.Month >= 4)
            {
                cmbYear.SelectedIndex = 0;
            }
            else
            {
                cmbYear.SelectedIndex = 1;
            }

            LoadHoliday();
            HolidayFrmdtpkr.Value = DateTime.Today;
            HolidayTodtpkr.Value = DateTime.Today;
        }

        public void LoadHoliday()
        {

            DataTable HolidayDt = clsDataAccess.RunQDTbl("SELECT SrlNo,HolDate As 'Date',HolidayName As " +
            "'Purpose Of Day',NationFlag As 'National Holiday',HolRemarks As Remarks FROM " +
            "tbl_Employee_Holiday where HolSession='" + cmbYear.Text + "' Order By HolDate");
            if (HolidayDt.Rows.Count <= 0)
            {
                return;
            }

            HolidayGrid.DataSource = HolidayDt;
            HolidayGrid.Columns[0].Visible = false;
            HolidayGrid.Columns[2].Width = 130;
            HolidayGrid.Columns[3].Width = 130;
            HolidayGrid.Columns[4].Width = 250;

            //DataGridViewLinkColumn DeleteCell;
            //DeleteCell = new DataGridViewLinkColumn();
            //HolidayGrid.Columns.Add(DeleteCell);
            //Int32 Cnt;
            //for (Cnt = 0; Cnt < HolidayGrid.Rows.Count; Cnt++)
            //{
            //    HolidayGrid.Rows[Cnt].Cells[5].Value = "Delete";
            //}

        }

       

        private void Savecmd_Click(object sender, EventArgs e)
        {
            
            if (PurposeOfDaytxt.Text.Trim() == "")
            {
                ERPMessageBox.ERPMessage.Show("Enter Purpose of the day...");
                PurposeOfDaytxt.Focus();
                return;
            }

            if (Remarkstxt.Text.Trim() == "")
            {
                Remarkstxt.Text = "-";
            }

            string NatFlag = "No";

            if (NationalChkbx.Checked == true)
            {
                NatFlag = "Yes";
            }

            if (MessageBox.Show("Would you like to save the Data? ", "Remove Leave Recoed", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (Savetag.Tag.ToString() == "0")
            {
                //string DateVal = "";
                DateTime Dt = new DateTime(HolidayFrmdtpkr.Value.Year, HolidayFrmdtpkr.Value.Month, HolidayFrmdtpkr.Value.Day);
                Dt = Dt.AddDays(-1);

                while (Dt < HolidayTodtpkr.Value.Date)
                {
                    Dt = Dt.AddDays(1);
                    //DateVal = Dt.Month + "/" + Dt.Day + "/" + Dt.Year;
                    //MessageBox.Show(DateVal.ToString());
                    clsDataAccess.RunNQwithStatus("INSERT INTO tbl_Employee_Holiday(HolidayName," +
                    "HolDate,NationFlag,HolRemarks,HolSession) VALUES('" + PurposeOfDaytxt.Text.Trim() +
                    "','" + Dt.Date.ToString("MM/dd/yyyy") + "','" + NatFlag +
                    "','" + Remarkstxt.Text.Trim() + "','" + cmbYear.Text + "')");
                }
            }
            else
            {
                clsDataAccess.RunNQwithStatus("UPDATE tbl_Employee_Holiday SET HolidayName='" +
                PurposeOfDaytxt.Text.Trim() + "',HolDate='" + HolidayFrmdtpkr.Value.Date.ToString("MM/dd/yyyy") +
                "',NationFlag='" + NatFlag + "',HolRemarks='" + Remarkstxt.Text.Trim() +
                "' WHERE SrlNo=" + Savetag.Tag.ToString());
            }
            ERPMessageBox.ERPMessage.Show("Process competed successfully...", "Holiday");
            Clear();
            LoadHoliday();
        }

        private void HolidayGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Savetag.Tag = HolidayGrid.Rows[HolidayGrid.CurrentRow.Index].Cells[0].Value.ToString();
            HolidayFrmdtpkr.Value = Convert.ToDateTime(HolidayGrid.Rows[HolidayGrid.CurrentRow.Index].Cells[1].Value.ToString());
            HolidayTodtpkr.Value = Convert.ToDateTime(HolidayGrid.Rows[HolidayGrid.CurrentRow.Index].Cells[1].Value.ToString());
            PurposeOfDaytxt.Text = HolidayGrid.Rows[HolidayGrid.CurrentRow.Index].Cells[2].Value.ToString();
            Remarkstxt.Text = HolidayGrid.Rows[HolidayGrid.CurrentRow.Index].Cells[4].Value.ToString();

            if (HolidayGrid.Rows[HolidayGrid.CurrentRow.Index].Cells[3].Value.ToString() == "Yes")
            {
                NationalChkbx.Checked = true;
            }
        }

        private void Clearcmd_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            Savetag.Tag = "0";
            HolidayFrmdtpkr.Value = DateTime.Today;
            HolidayTodtpkr.Value = DateTime.Today;
            PurposeOfDaytxt.Text = "";
            Remarkstxt.Text = "";
            NationalChkbx.Checked = false;
        }

        private void Closecmd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Deletecmd_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("Would you like to delete " + HolidayGrid.Rows[HolidayGrid.CurrentRow.Index].Cells[2].Value.ToString() + " ? ", "Holiday", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    clsDataAccess.RunNQwithStatus("DELETE FROM tbl_Employee_Holiday " +
                    " WHERE SrlNo=" + Savetag.Tag.ToString().Trim());
                    LoadHoliday();
                    Clear();
                }
        }

        private void HolidayFrmdtpkr_ValueChanged(object sender, EventArgs e)
        {
            HolidayTodtpkr.Value = HolidayFrmdtpkr.Value;
        }      
       
    }
}