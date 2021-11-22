using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EDPComponent;
using ERPMessageBox;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace PayRollManagementSystem
{
    public partial class frmficodegenarate : FormBaseERP
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        int Company_code = 0;
        public frmficodegenarate()
        {
            InitializeComponent();
        }

        private void frmficodegenarate_Load(object sender, EventArgs e)
        {
            try
            {
                clsValidation.GenerateYear(cmbYear, 2015, System.DateTime.Now.Year, 1);
                if (System.DateTime.Now.Month >= 0)
                {
                    cmbYear.SelectedIndex = 0;
                }
                else
                {
                    cmbYear.SelectedIndex = 1;
                }

                DataTable dt = clsDataAccess.RunQDTbl("select Session from tbl_Session");
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    cmbYear.Items.Add(dt.Rows[i]["Session"]);
                }
                DataTable digcode = Load_Data1("select distinct CO_NAME from company order by CO_NAME");
                for (int i = 0; i < digcode.Rows.Count; i++)
                {
                    cmbcompany.Items.Add(digcode.Rows[i]["CO_NAME"].ToString());
                    //cmbcompany.SelectedIndex = 0;
                }
                cmbYear.SelectedIndex = 0;

                this.HeaderText = "Financial Year Genarate";
                DataTable dtfromdate = clsDataAccess.RunQDTbl("Select max(todate) from tbl_Session where session='" + cmbYear.Text + "'");
                DataTable dtfromdate1 = clsDataAccess.RunQDTbl("Select max(FromDate) from tbl_Session where session='" + cmbYear.Text + "'");
                DateTime fromda = Convert.ToDateTime(dtfromdate1.Rows[0][0]);
                dtpfrom.Value = fromda;
                fromda = Convert.ToDateTime(dtfromdate.Rows[0][0]);
                dtpto.Value = fromda;
                fillgrid();
                //dgvfinancial.Rows.Add();               
                //dgvfinancial.Rows[0].Cells["FromDate"].Value = dtpfrom.Value;
                //dgvfinancial.Rows[0].Cells["ToDate"].Value = dtpto.Value;
                //load();
                //dgGrd.Rows[0].Cells["RangeFrom"].Value = dtpfrom.Value;
                //dgGrd.Rows[0].Cells["RangeTo"].Value = dtpto.Value;

            }
            catch { }


        }

        public void fillgrid()
        {
            dgGrd.Rows.Clear();
            DataTable checkficode = clsDataAccess.RunQDTbl("Select * from GenarateFicode where session='" + cmbYear.Text + "'");
            for (int i = 0; i <= checkficode.Rows.Count - 1; i++)
            {
                btnSubmit.Text = "Close";
                DataTable dtgcode = Load_Data1("Select CO_NAME from company where gcode ='" + checkficode.Rows[i]["Gcode"] + "' ");
                if (i == 0)
                    cmbcompany.Text = Convert.ToString(dtgcode.Rows[0]["CO_NAME"]);
                dgGrd.Rows.Add();
                dgGrd.Rows[i].Cells["ficode1"].Value = checkficode.Rows[i]["Ficode"];
                dgGrd.Rows[i].Cells["RangeFrom"].Value = Convert.ToDateTime(checkficode.Rows[i]["FromDate"]).ToShortDateString();
                dgGrd.Rows[i].Cells["RangeTo"].Value = Convert.ToDateTime(checkficode.Rows[i]["ToDate"]).ToShortDateString();
                //addcompany(i);
                dgGrd.Rows[i].Cells["gcode1"].Value = dtgcode.Rows[0]["CO_NAME"];
                Company_code = Convert.ToInt32(checkficode.Rows[i]["Gcode"]);
                dgGrd.Rows[i].ReadOnly = true;
            }

            DataTable dt = clsDataAccess.RunQDTbl("Select  ReceiptNo,SubmissionDate as Date , RegNo, TotalFees,AmountPaid ,DueFees from tbl_Student_Feesmast where Session='" + cmbYear.Text + "' and (voucher is null or voucher =0)");
            if (dt.Rows.Count > 0)
                btnupdate.Visible = true;
            else
                btnupdate.Visible = false;
        }
        public void load()
        {
            if (btnSubmit.Text != "Close" || btnupdate.Visible==true)
            {
                try
                {
                    int cou = 0;
                    DataTable year = Load_Data1("select * from company where (CO_SDATE between '" + dtpfrom.Value.ToString("MM/dd/yyyy") + "' and '" + dtpto.Value.ToString("MM/dd/yyyy") + "' OR CO_EDATE between '" + dtpfrom.Value.ToString("MM/dd/yyyy") + "' and '" + dtpto.Value.ToString("MM/dd/yyyy") + "') and CO_CODE=" + Company_code + " order by CO_SDATE ");

                    if (year.Rows.Count > 0)
                    {

                        for (int i = 0; i <= year.Rows.Count - 1; i++)
                        {
                            if (i == 0)
                                dgGrd.Rows.Clear();
                            dgGrd.Rows.Add();
                            cou = dgGrd.Rows.Count - 1;
                            dgGrd.Rows[i].Cells["gcode1"].Value = cmbcompany.Text;
                            dgGrd.Rows[i].Cells["ficode1"].Value = year.Rows[i]["FICode"].ToString();
                            if (Convert.ToDateTime(year.Rows[i]["CO_SDATE"]) >= Convert.ToDateTime(dtpfrom.Value))
                                dgGrd.Rows[i].Cells["RangeFrom"].Value = Convert.ToDateTime(year.Rows[i]["CO_SDATE"]).ToShortDateString();
                            else
                                dgGrd.Rows[i].Cells["RangeFrom"].Value = Convert.ToDateTime(dtpfrom.Value).ToShortDateString();

                            if (Convert.ToDateTime(year.Rows[i]["CO_EDATE"]) >= Convert.ToDateTime(dtpto.Value))
                                dgGrd.Rows[i].Cells["RangeTo"].Value = Convert.ToDateTime(dtpto.Value).ToShortDateString();
                            else
                                dgGrd.Rows[i].Cells["RangeTo"].Value = Convert.ToDateTime(year.Rows[i]["CO_EDATE"]).ToShortDateString();

                        }
                        btnSubmit.Enabled = true;
                    }
                    else
                    {

                        btnSubmit.Enabled = false;
                    }
                }
                catch { }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Close")
            {
                this.Close();
            }
            else
            {
                try
                {
                    DataTable checkficode = clsDataAccess.RunQDTbl("Select * from GenarateFicode where session='" + cmbYear.Text + "'");
                    if (checkficode.Rows.Count > 0)
                    {
                        ERPMessage.Show("Financial Year Already Exit");
                        return;
                    }

                    //DataTable dtsficode = clsDataAccess.RunQDTbl("Select Session from tbl_session where SFICode = (select max(SFIcode)from tbl_session)");

                    for (int i = 0; i < dgGrd.Rows.Count - 1; i++)
                    {
                        int fi = i + 1;
                        if (!String.IsNullOrEmpty(Convert.ToString(dgGrd.Rows[i].Cells["gcode1"].Value)))
                        {
                            if (String.IsNullOrEmpty(Convert.ToString(dgGrd.Rows[i].Cells["RangeFrom"].Value)))
                            {
                                ERPMessage.Show("Form Date Missing");
                                bool ret2 = clsDataAccess.RunNQwithStatus("Delete from GenarateFicode where Session='" + cmbYear.Text + "'");
                                return;
                            }
                            if (String.IsNullOrEmpty(Convert.ToString(dgGrd.Rows[i].Cells["RangeTO"].Value)))
                            {
                                ERPMessage.Show("To Date Missing");
                                bool ret2 = clsDataAccess.RunNQwithStatus("Delete from GenarateFicode where Session='" + cmbYear.Text + "'");
                                return;
                            }
                        }
                        //                        
                        //DataTable dtficode = clsDataAccess.RunQDTbl2("Select ficode from company where CO_SDATE>='" + edpcom.getSqlDateStr(Convert.ToDateTime(dgGrd.Rows[i].Cells["RangeFrom"].Value)) + "'and  CO_EDATE <='" + edpcom.getSqlDateStr(Convert.ToDateTime(dgGrd.Rows[i].Cells["RangeTO"].Value)) + "' and gcode=" + Company_code + " ");
                        //if (dtficode.Rows.Count > 0)
                        //{
                        bool ret = clsDataAccess.RunNQwithStatus("insert into GenarateFicode( FromDate, ToDate, Ficode, Gcode, Session) values('" + edpcom.getSqlDateStr(Convert.ToDateTime(dgGrd.Rows[i].Cells["RangeFrom"].Value)) + "','" + edpcom.getSqlDateStr(Convert.ToDateTime(dgGrd.Rows[i].Cells["RangeTO"].Value)) + "','" + dgGrd.Rows[i].Cells["ficode1"].Value + "'," + Company_code + ",'" + cmbYear.Text + "')");
                        //}
                        //else
                        //{
                        //    ERPMessage.Show("Financial Year Create Problem \n Date Range Not Wright");
                        //    return;
                        //}
                    }
                    ERPMessage.Show("Financial Year Create Successfuly");
                }
                catch 
                {
                    ERPMessage.Show("Financial Year Create Problem ");
                }
            }
        }
        private void cmbsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSubmit.Text = "Save";
            DataTable dtfromdate = clsDataAccess.RunQDTbl("Select max(todate) from tbl_Session where session='" + cmbYear.Text + "'");
            DataTable dtfromdate1 = clsDataAccess.RunQDTbl("Select max(FromDate) from tbl_Session where session='" + cmbYear.Text + "'");
            DateTime fromda = Convert.ToDateTime(dtfromdate1.Rows[0][0]);
            dtpfrom.Value = fromda;
            fromda = Convert.ToDateTime(dtfromdate.Rows[0][0]);
            dtpto.Value = fromda;
            //fillgrid();
            //load();
        }

        private void dgGrd_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //int cou = 0;
                //DataTable digcode = clsDataAccess.RunQDTbl2("select distinct CO_NAME from company order by CO_NAME");
                //cou = dgGrd.Rows.Count - 1;
                //DataGridViewComboBoxCell combobox1 = new DataGridViewComboBoxCell();
                //if (dgGrd.Rows.Count - 1 > 0)
                //    cou = dgGrd.Rows.Count - 1;
                //for (int j = 0; j < digcode.Rows.Count; j++)
                //    combobox1.Items.Add(digcode.Rows[j][0].ToString());
                ////int a = dgGrd.CurrentRow.Index;
                //this.dgGrd[1, cou] = combobox1;
            }
            catch { }
        }

        private void dgGrd_Enter(object sender, EventArgs e)
        {

        }
        public void addcompany(int i)
        {
            try
            {
                if (dgGrd.Columns[0].HeaderText == "Financial Create")
                {
                    int cou = 0;
                    DataTable digcode = Load_Data1("select distinct CO_NAME from company order by CO_NAME");
                    cou = dgGrd.Rows.Count - 1;
                    DataGridViewComboBoxCell combobox1 = new DataGridViewComboBoxCell();
                    if (dgGrd.Rows.Count - 1 > 0)
                        cou = dgGrd.Rows.Count - 1;
                    for (int j = 0; j < digcode.Rows.Count; j++)
                        combobox1.Items.Add(digcode.Rows[j][0].ToString());
                    //int a = dgGrd.CurrentRow.Index;
                    this.dgGrd[1, i] = combobox1;
                }
            }
            catch { }
        }

        private void cmbcompany_Leave(object sender, EventArgs e)
        {
            
        }

        private void cmbcompany_DropDownClosed(object sender, EventArgs e)
        {
           
        }

        private void cmbcompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Company_code = 0;
                DataTable digcode =Load_Data1("select  CO_CODE from company where CO_NAME='" + cmbcompany.Text + "' ");
                if (digcode.Rows.Count > 0)
                    if (Information.IsNumeric(digcode.Rows[0]["CO_CODE"]) == true)
                        Company_code = Convert.ToInt32(digcode.Rows[0]["CO_CODE"]);

                load();
            }
            catch { }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgGrd.Rows.Count - 1; i++)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(dgGrd.Rows[i].Cells["gcode1"].Value)))
                    {
                        if (String.IsNullOrEmpty(Convert.ToString(dgGrd.Rows[i].Cells["RangeFrom"].Value)))
                        {
                            ERPMessage.Show("Form Date Missing");
                            bool ret2 = clsDataAccess.RunNQwithStatus("Delete from GenarateFicode where Session='" + cmbYear.Text + "'");
                            return;
                        }
                        if (String.IsNullOrEmpty(Convert.ToString(dgGrd.Rows[i].Cells["RangeTO"].Value)))
                        {
                            ERPMessage.Show("To Date Missing");
                            bool ret2 = clsDataAccess.RunNQwithStatus("Delete from GenarateFicode where Session='" + cmbYear.Text + "'");
                            return;
                        }
                    }
                    if (i == 0)
                    {
                        bool ret1 = clsDataAccess.RunNQwithStatus("Delete From GenarateFicode where Session ='" + cmbYear.Text + "' ");
                    }
                    //bool ret = clsDataAccess.RunNQwithStatus("update GenarateFicode set FromDate='" + edpcom.getSqlDateStr(Convert.ToDateTime(dgGrd.Rows[i].Cells["RangeFrom"].Value)) + "', ToDate='" + edpcom.getSqlDateStr(Convert.ToDateTime(dgGrd.Rows[i].Cells["RangeTO"].Value)) + "', Ficode='" + dgGrd.Rows[i].Cells["ficode1"].Value + "', Gcode=" + Company_code + " where Session = '" + cmbsession.Text + "' ");
                    bool ret = clsDataAccess.RunNQwithStatus("insert into GenarateFicode( FromDate, ToDate, Ficode, Gcode, Session) values('" + edpcom.getSqlDateStr(Convert.ToDateTime(dgGrd.Rows[i].Cells["RangeFrom"].Value)) + "','" + edpcom.getSqlDateStr(Convert.ToDateTime(dgGrd.Rows[i].Cells["RangeTO"].Value)) + "','" + dgGrd.Rows[i].Cells["ficode1"].Value + "'," + Company_code + ",'" + cmbYear.Text + "')");
                }
                ERPMessage.Show("Financial Year Update Successfuly");
            }
            catch 
            {
                ERPMessage.Show("Financial Year Update Problem");
            }
        }

        private DataTable Load_Data1(string qry)
        {
            DataTable dt = new DataTable();
            Edpcom.EDPConnection EDPCon = new Edpcom.EDPConnection();
            string db_name = EDPCon.DatabaseName.Trim();
            try
            {
                dt.Clear();
              
                edpcom.PDATABASE_NAME = "AccordFour";
                EDPCon.DatabaseName = "AccordFour";
                SqlDataAdapter adp = new SqlDataAdapter();
                SqlCommand cmd;
                EDPCon.Close();
                EDPCon.Open();
                cmd = new SqlCommand(qry, EDPCon.mycon);
                adp.SelectCommand = cmd;
                adp.Fill(dt);
                EDPCon.Close();
                edpcom.PDATABASE_NAME = db_name;
                EDPCon.DatabaseName = db_name;
            }
            catch
            {
                edpcom.PDATABASE_NAME = db_name;
                EDPCon.DatabaseName = db_name;
            }
            return dt;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] ses = cmbYear.Text.Split('-');

                dtpfrom.Value = Convert.ToDateTime("01/April/" + ses[0].ToString());
                dtpto.Value = Convert.ToDateTime("31/March/" + ses[1].ToString());

            if (Company_code!=0)
                load();

            }
            catch { }
        }

      
    }
}