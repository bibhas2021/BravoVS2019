using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Edpcom;
using ERPMessageBox;
namespace PayRollManagementSystem
{
    public partial class Config_PFandESI : EDPComponent.FormBaseERP
    {
        public Config_PFandESI()
        {
            InitializeComponent();
        }
        private int slno = 0;
        private void Config_PFandESI_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 1950, System.DateTime.Now.Year, 1); 
            if (System.DateTime.Now.Month >= 4)
                cmbYear.SelectedIndex = 0;
            else
                cmbYear.SelectedIndex = 1;
            FillGrid();
        }
        private void FillGrid()
        {
            dgv.Rows.Clear();
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_PFESIRate where year='" + cmbYear.SelectedItem.ToString() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells[0].Value = dt.Rows[i][1];
                dgv.Rows[i].Cells[1].Value = dt.Rows[i][2];
                dgv.Rows[i].Cells[2].Value = dt.Rows[i][3];
                dgv.Rows[i].Cells[3].Value = dt.Rows[i][4];
                dgv.Rows[i].Cells[4].Value = dt.Rows[i][5];
                dgv.Rows[i].Cells[5].Value = dt.Rows[i][6];
                dgv.Rows[i].Cells[6].Value = dt.Rows[i][7];
                dgv.Rows[i].Cells[7].Value = dt.Rows[i][8];
                dgv.Rows[i].Cells[8].Value = dt.Rows[i][9];
                dgv.Rows[i].Cells[9].Value = dt.Rows[i][10];
                dgv.Rows[i].Cells[10].Value = dt.Rows[i][11];
                dgv.Rows[i].Cells[11].Value = dt.Rows[i][12];
                dgv.Rows[i].Cells[12].Value = dt.Rows[i]["slno"];
                dgv.Rows[i].Cells[13].Value = dt.Rows[i]["PFRate"];
            }
        }
        private void Clear()
        {
            txtCmpCut.Text = ""; txtEMPerESI.Text = "";
            txtCompAC02.Text = ""; txtEMPESI.Text = "";
            txtCompAC21.Text = ""; txtEPF.Text = "";
            txtCompAC22.Text = ""; txtEPFComp.Text = "";
            txtCompPS.Text = ""; txtESICut.Text = "";
            slno = 0; txtPfrate.Text = "";
        }

        private void FillDefault()
        {
            txtCmpCut.Text = "0000.00"; txtEMPerESI.Text = "4.75";
            txtCompAC02.Text = "1.10"; txtEMPESI.Text = "1.75";
            txtCompAC21.Text = "0.50"; txtEPF.Text = "12.00";
            txtCompAC22.Text = "0.01"; txtEPFComp.Text = "3.67";
            txtCompPS.Text = "8.33"; txtESICut.Text = "0000.00";
            txtPfrate.Text = "8";
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbMonth.SelectedIndex >= 0) && (cmbYear.SelectedIndex >= 0))
            {
                DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_PFESIRate where Month='" + cmbMonth.SelectedItem.ToString() + "' and year='" + cmbYear.SelectedItem.ToString() + "'");
                if (dt.Rows.Count > 0)
                {
                    Clear();
                    txtCmpCut.Text = dt.Rows[0]["PFCUTOFF"].ToString();
                    txtCompAC02.Text = dt.Rows[0]["PFACC2"].ToString();
                    txtCompAC21.Text = dt.Rows[0]["PFACC21"].ToString();
                    txtCompAC22.Text = dt.Rows[0]["PFACC22"].ToString();
                    txtCompPS.Text = dt.Rows[0]["PFCMPEPS"].ToString();
                    txtEMPerESI.Text = dt.Rows[0]["ESIEMP"].ToString();
                    txtEMPESI.Text = dt.Rows[0]["ESICMP"].ToString();
                    txtEPF.Text = dt.Rows[0]["PFEMP"].ToString();
                    txtEPFComp.Text = dt.Rows[0]["PFCMPEPF"].ToString();
                    txtESICut.Text = dt.Rows[0]["ESICUTOFF"].ToString();
                    txtPfrate.Text = dt.Rows[0]["PFRate"].ToString();
                    slno = Convert.ToInt32(dt.Rows[0]["SLNO"].ToString());
                }
                else
                {
                    FillDefault();
                    slno = 0;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    cmbMonth.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (slno == 0)
                {
                    bool status = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_PFESIRate(Month, Year, PFEMP, PFCMPEPS, PFCMPEPF, PFCUTOFF, PFACC2, PFACC21, PFACC22, ESIEMP, ESICMP, ESICUTOFF,PFRate) values(" +
                        "'" + cmbMonth.SelectedItem.ToString() + "','" + cmbYear.SelectedItem.ToString() + "'," + txtEPF.Text + "," + txtCompPS.Text + "," + txtEPFComp.Text + "," + txtCmpCut.Text + "," + txtCompAC02.Text + "," + txtCompAC21.Text + "," + txtCompAC22.Text + "," + txtEMPESI.Text + "," + txtEMPerESI.Text + "," + txtESICut.Text + "," + txtPfrate.Text + ")");
                    if (status)
                        ERPMessage.Show("Successfully Saved.");
                    else ERPMessage.Show("Unable to Save.");
                    FillGrid();
                }
                else
                {
                    bool status = clsDataAccess.RunNQwithStatus("update tbl_Employee_PFESIRate set PFEMP=" + txtEPF.Text + ",PFCMPEPS=" + txtCompPS.Text + ",PFCMPEPF=" + txtEPFComp.Text + ",PFCUTOFF=" + txtCmpCut.Text + ",PFACC2=" + txtCompAC02.Text +
                        ",PFACC21=" + txtCompAC21.Text + ",PFACC22=" + txtCompAC22.Text + ",ESIEMP=" + txtEMPESI.Text + ",ESICMP=" + txtEMPerESI.Text + ",ESICUTOFF=" + txtESICut.Text + ", PFRate = "+txtPfrate.Text+" where  Month='" + cmbMonth.SelectedItem.ToString() + "' and year='" + cmbYear.SelectedItem.ToString() + "'");
                    if (status)
                        ERPMessage.Show("Successfully Updated.");
                    else ERPMessage.Show("Unable to Update.");
                    FillGrid();
                }
            }
        }

        private bool Validation()
        {
            if (txtEPF.Text == "")
            {
                ERPMessage.Show("Enter EPF Percentage.");
                txtEPF.Focus();
                return false;
            }
            if (txtCompPS.Text == "")
            {
                ERPMessage.Show("Enter Pension Fund Percentage.");
                txtCompPS.Focus();
                return false;
            }
            if (txtEPFComp.Text == "")
            {
                ERPMessage.Show("Enter Employer EPF Percentage.");
                txtEPFComp.Focus();
                return false;
            }
            if (txtEMPESI.Text == "")
            {
                ERPMessage.Show("Enter Employee ESI Percentage.");
                txtEMPESI.Focus();
                return false;
            }
            if (txtEMPerESI.Text == "")
            {
                ERPMessage.Show("Enter Employer ESI Percentage.");
                txtEMPerESI.Focus();
                return false;
            }
            return true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bool status = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_PFESIRate where slno=" + slno);
            if (status)
                ERPMessage.Show("Successfully Deleted.");
            else ERPMessage.Show("Unable to Delete.");
            FillGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}