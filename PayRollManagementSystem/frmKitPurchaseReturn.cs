using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmKitPurchaseReturn : Form
    {
        
        public frmKitPurchaseReturn()
        {
            InitializeComponent();
        }
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        DialogView dv = new DialogView();

        string date_Max, date_Min, CoID;
        double ct = 0;
        DateTimePicker oDateTimePicker;

        public void GetDetails()
        {
            CoID = CmbCompany.ReturnValue.Trim();
            if (CoID.Trim() == "")
            {
                CoID = "1";
            }
            DataTable dt = clsDataAccess.RunQDTbl("Select pid,CONVERT(VARCHAR(11),p_date,103) AS 'DATE',isnull((kt_nm),'UNIFORM')AS 'KIT NAME'," +
            "isnull((stk_in),0)AS'STOCK IN',isnull((unit),'pcs')as 'UNIT',isnull((amt),0)as 'AMOUNT',kid,pbill,vname," +
            "RetPBill,stk_rtn,ramt,retdt,remarks,rmonth,runit,rRate from purchase where rmonth='" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "' and (coid='"+CoID+"') order by pid");
            this.dgv_show.Rows.Clear();
            if (dt.Rows.Count > 0)
            {


                for (int ind_dgv = 0; ind_dgv < dt.Rows.Count; ind_dgv++)
                {
                    dgv_show.Rows.Add();
                    dgv_show.Rows[ind_dgv].Cells["PID"].Value = dt.Rows[ind_dgv]["pid"];
                    dgv_show.Rows[ind_dgv].Cells["dt"].Value = dt.Rows[ind_dgv]["retdt"];
                    dgv_show.Rows[ind_dgv].Cells["kt_nm"].Value = dt.Rows[ind_dgv]["KIT NAME"];
                    dgv_show.Rows[ind_dgv].Cells["stk_in"].Value = dt.Rows[ind_dgv]["stk_rtn"];
                    dgv_show.Rows[ind_dgv].Cells["unit"].Value = dt.Rows[ind_dgv]["runit"];
                    dgv_show.Rows[ind_dgv].Cells["amt"].Value = dt.Rows[ind_dgv]["ramt"];
                    dgv_show.Rows[ind_dgv].Cells["kid"].Value = dt.Rows[ind_dgv]["kid"];
                    dgv_show.Rows[ind_dgv].Cells["pbill"].Value = dt.Rows[ind_dgv]["pbill"];
                    dgv_show.Rows[ind_dgv].Cells["vname"].Value = dt.Rows[ind_dgv]["vname"];


                    dgv_show.Rows[ind_dgv].Cells["RetPBill"].Value = dt.Rows[ind_dgv]["RetPBill"];
                    dgv_show.Rows[ind_dgv].Cells["rmrks"].Value = dt.Rows[ind_dgv]["remarks"];
                    dgv_show.Rows[ind_dgv].Cells["rid"].Value = dt.Rows[ind_dgv]["pid"];

                    try
                    {
                        dgv_show.Rows[ind_dgv].Cells["rt"].Value = Convert.ToDouble(Convert.ToDouble(dgv_show.Rows[ind_dgv].Cells["amt"].Value) / Convert.ToDouble(dgv_show.Rows[ind_dgv].Cells["stk_in"].Value)).ToString("0.00");
                    }
                    catch { dgv_show.Rows[ind_dgv].Cells["rt"].Value = "0"; }

                }

            }

        }


        private void dgv_show_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==3)
                //(dgv_show.Columns[e.ColumnIndex].HeaderText.ToLower() == "ref purchase bill no")
            {
                CoID = CmbCompany.ReturnValue.Trim();
                if (CoID.Trim() == "")
                {
                    CoID = "1";
                }
                
                dv.sql_frm = "Select pid, p_date AS 'DATE', isnull((kt_nm),'UNIFORM')AS 'KIT NAME'," +
                "vname, isnull((stk_in),0)AS'STOCK IN', isnull((unit),'pcs')as 'UNIT'," +
                "isnull((amt),0)as 'AMOUNT',kid,pbill,pRate from purchase where (coid='" + CoID + "')";
                dv.retno = 10;
                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;
                dv.ShowDialog();
                try
                {
                    ct = 0;
                    int ind = Convert.ToInt32(dgv_show.CurrentRow.Index);

                    this.dgv_show.Rows[ind].Cells["PID"].Value = dv.retval.ToString();
                    this.dgv_show.Rows[ind].Cells["pbill"].Value = dv.retval8.ToString();
                    this.dgv_show.Rows[ind].Cells["vname"].Value = dv.retval3.ToString();

                    this.dgv_show.Rows[ind].Cells["kid"].Value = dv.retval7.ToString();
                    this.dgv_show.Rows[ind].Cells["kt_nm"].Value = dv.retval2.ToString();
                    this.dgv_show.Rows[ind].Cells["unit"].Value = dv.retval5.ToString();
                    dgv_show.Rows[ind].Cells["stk_in"].Value = 0;
                    try
                    {
                        this.dgv_show.Rows[ind].Cells["rt"].Value = dv.retval9.ToString();
                    }
                    catch { this.dgv_show.Rows[ind].Cells["rt"].Value = 0; }

                    try
                    {
                        ct = Convert.ToDouble(dgv_show.Rows[ind].Cells["stk_in"].Value.ToString()) * Convert.ToDouble(dgv_show.Rows[ind].Cells["rt"].Value.ToString());
                        dgv_show.Rows[ind].Cells["amt"].Value = ct.ToString("0.00");
                    }
                    catch{}
                }
                catch
                { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String pid, dt_ret, knm, kid, st_in, pbill, unit, amt, vname, RetPBill, rmrks, rid, rmonth;
            bool boolstatus = false;
            CoID = CmbCompany.ReturnValue;
            if (CoID.Trim() == "")
            {
                CoID = "1";
            }
            if (dgv_show.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgv_show.Rows.Count - 1; i++)
                {
                    pid = Convert.ToString(dgv_show.Rows[i].Cells["PID"].Value);

                    try
                    {
                        dt_ret = Convert.ToDateTime(dgv_show.Rows[i].Cells["dt"].Value).ToString("dd/MMM/yyyy");
                    }
                    catch { dt_ret = DateTime.Now.ToString("dd/MMM/yyyy"); }
                    if (dgv_show.Rows[i].Cells["dt"].Value == null || dgv_show.Rows[i].Cells["dt"].Value.ToString().Trim() == "")
                    {
                        dt_ret =  DateTime.Now.ToString("dd/MMM/yyyy");
                    }
                    else
                    {
                        dt_ret = Convert.ToDateTime(dgv_show.Rows[i].Cells["dt"].Value).ToString("dd/MMM/yyyy");
                    }
                    knm = Convert.ToString(dgv_show.Rows[i].Cells["kt_nm"].Value);
                    kid = Convert.ToString(dgv_show.Rows[i].Cells["kid"].Value);
                    st_in = Convert.ToString(dgv_show.Rows[i].Cells["stk_in"].Value);
                    pbill = Convert.ToString(dgv_show.Rows[i].Cells["pbill"].Value);
                    unit = Convert.ToString(dgv_show.Rows[i].Cells["unit"].Value);
                    amt = Convert.ToString(dgv_show.Rows[i].Cells["amt"].Value);
                    vname = Convert.ToString(dgv_show.Rows[i].Cells["vname"].Value);

                    RetPBill = Convert.ToString(dgv_show.Rows[i].Cells["RetPBill"].Value);
                    rmrks = Convert.ToString(dgv_show.Rows[i].Cells["rmrks"].Value);
                    rid = Convert.ToString(dgv_show.Rows[i].Cells["rid"].Value);
                    rmonth = AttenDtTmPkr.Value.ToString("MMMM/yyyy");

                    if (!String.IsNullOrEmpty(amt))
                    {
                        //if (!String.IsNullOrEmpty(unit))
                        //{
                        if (!String.IsNullOrEmpty(st_in))
                        {
                            if (!String.IsNullOrEmpty(knm))
                            {
                                if (!String.IsNullOrEmpty(pid))
                                {
                                    DataTable dt = clsDataAccess.RunQDTbl("Select count(*) from purchase Where (pid='" + pid + "') and (coid='"+CoID+"')");
                                    if (dt.Rows.Count > 0)
                                    {
                                        boolstatus = clsDataAccess.RunNQwithStatus("update purchase set RetPBill='" + RetPBill + "',stk_rtn='" + st_in + "', runit='" + unit +
                                            "', ramt='" + amt + "', retdt='" + dt_ret + "', remarks='" + rmrks + "',rmonth='" + rmonth + "' where (pid=" + pid + ") and (coid ='"+CoID+"')");
                                    }
                                    edpcom.InsertMidasLog(this, true, "modify", "purchase returned:" + pid);

                                }
                            }
                        }

                    }
                }



                if (boolstatus)
                {
                    ERPMessageBox.ERPMessage.Show(" Purchase returned Successfully");
                    GetDetails();
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show("Failed To Submit purchase return");
                }
            }

        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            int firstDayInCurrentMonth = 1;
            int lastDayInCurrentMonth = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);


            dt.DefaultCellStyle.NullValue = AttenDtTmPkr.Value.ToString("dd/MM/yyyy");
            date_Min = AttenDtTmPkr.Value.ToString("01/MMM/yyyy");
            date_Max = AttenDtTmPkr.Value.ToString(lastDayInCurrentMonth + "/MMM/yyyy");

            dt.DefaultCellStyle.NullValue = AttenDtTmPkr.Value.ToString("dd/MM/yyyy");

            GetDetails();
        }

        private void frmKitPurchaseReturn_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(cmbYear, 2019, System.DateTime.Now.Year, 1);
            try
            {
                if (DateTime.Now.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = DateTime.Now.Year + "-" + DateTime.Now.AddYears(1).Year; }
                    catch { }

                }
                else
                {
                    cmbYear.SelectedItem = DateTime.Now.AddYears(-1).Year + "-" + DateTime.Now.Year;

                }
            }
            catch
            { }

            CmbCompany.PopUp();
            AttenDtTmPkr.Value = DateTime.Now;

        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] yr = cmbYear.Text.Split('-');

            try
            {
                AttenDtTmPkr.MinDate = Convert.ToDateTime("01/April/" + yr[0].ToString().Trim());
            }
            catch { }
            try
            {
                AttenDtTmPkr.MaxDate = Convert.ToDateTime("31/March/" + yr[1].ToString().Trim());
            }
            catch { }
            
        }

        private void dgv_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 1)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dgv_show.Controls.Add(oDateTimePicker);
                try
                {
                    oDateTimePicker.MinDate = Convert.ToDateTime(date_Min);
                    oDateTimePicker.MaxDate = Convert.ToDateTime(date_Max);
                }
                catch { }
                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Short;
                try{ oDateTimePicker.Text = dgv_show.CurrentCell.Value.ToString(); } catch{}

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgv_show.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;
            }
        }
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgv_show.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }
        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        private void CmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {
                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE " +
                " from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("select CO_name,CO_CODE from company order by CO_CODE");
            }
            if (dt.Rows.Count > 1)
            {
                CmbCompany.LookUpTable = dt;
                CmbCompany.ReturnIndex = 1;
            }
            else if (dt.Rows.Count == 1)
            {
                CmbCompany.Text = dt.Rows[0]["CO_name"].ToString();
                CmbCompany.ReturnValue = dt.Rows[0]["CO_CODE"].ToString();
                CoID = CmbCompany.ReturnValue.ToString().Trim();
                if (CoID.Trim() == "")
                {
                    CoID = "1";
                }
                GetDetails();

            }
        }

        private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            CoID = CmbCompany.ReturnValue.Trim();
            if (CoID.Trim() == "")
            {
                CoID = "1";
            }
            GetDetails();
        }

        private void dgv_show_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int iRw = dgv_show.CurrentCell.RowIndex;
            int iCol = dgv_show.CurrentCell.ColumnIndex;
            double ct = 0;
            try
            {
                if (iCol == 6)
                {
                    if (Convert.ToDouble(dgv_show.Rows[iRw].Cells["amt"].Value.ToString()) == 0)
                    {
                        ct = Convert.ToDouble(dgv_show.Rows[iRw].Cells["RT"].Value.ToString()) * Convert.ToDouble(dgv_show.Rows[iRw].Cells["stk_in"].Value.ToString());
                        dgv_show.Rows[iRw].Cells["amt"].Value = ct.ToString("0.00");
                    }
                }
            }
            catch { dgv_show.Rows[iRw].Cells["amt"].Value = ct.ToString("0.00"); }
        }

        private void LblCompany_Click(object sender, EventArgs e)
        {

        }  

        //=====================================================================



    }
}