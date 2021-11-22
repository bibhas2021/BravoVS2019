using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDPComponent;

namespace PayRollManagementSystem
{
    public partial class frmKitIssueReturn : Form
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        DialogView dv = new DialogView();
        string date_Max, date_Min;

        DateTimePicker oDateTimePicker;

        string coid = "1";

        public frmKitIssueReturn()
        {
            InitializeComponent();
        }

        private void dgv_show_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // PID; dt; RetPBill; vname; kt_nm; stk_in; unit; amt; rmrks; kid; rid;
            if (dgv_show.Columns[e.ColumnIndex].HeaderText.ToLower() == "issue return inv no")
            {
                dv.sql_frm = "select [EKID],[EKEID],[EKNAME],[EKDT],[EKMONTH],[EKAMT],"+
                "(Select KTNAME from MSTKIT where KTID=ek.EKKIT and coid=ek.CoID) as Kit,EKKIT,[SLNO] as pid from tbl_Employee_KIT ek WHERE (COID='" + coid + "')";
                dv.retno = 8;
                dv.lblCo.Text = "";
                dv.lblHead.Text = "";
                dv.btnPreview.Visible = false;
                dv.ShowDialog();
                try
                {
                    int ind = Convert.ToInt32(dgv_show.CurrentRow.Index);

                    this.dgv_show.Rows[ind].Cells["rid"].Value = dv.retval.ToString();
                    this.dgv_show.Rows[ind].Cells["pid"].Value = dv.retval1.ToString();
                    this.dgv_show.Rows[ind].Cells["RetPBill"].Value = "IR/" + Convert.ToDateTime("01/"+dv.retval4).ToString("MMM/yyyy") + "/" + Convert.ToDouble(dv.retval).ToString("0000");
                    this.dgv_show.Rows[ind].Cells["stk_in"].Value = "1";
                    this.dgv_show.Rows[ind].Cells["amt"].Value = dv.retval5.ToString();
                    this.dgv_show.Rows[ind].Cells["vname"].Value = dv.retval2.ToString();
                    this.dgv_show.Rows[ind].Cells["kid"].Value = dv.retval7.ToString();
                    this.dgv_show.Rows[ind].Cells["kt_nm"].Value = dv.retval6.ToString();
                    this.dgv_show.Rows[ind].Cells["unit"].Value = clsDataAccess.ReturnValue("select unit from MSTKIT where (KTID='" + dv.retval7.ToString() + "')");
                    //this.dgv_show.Rows.Add();
                }
                catch
                { }


            }
        }

        public Boolean submit_det()
        {
            Boolean boolstatus = false;
            string irid="1",rid, IssueID, kid, stk_rtn, runit, ramt, retdt, remarks, empid, mon;
            //PID; dt; RetPBill; vname; kt_nm; stk_in; unit; amt; rmrks; kid; rid;
            if (dgv_show.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_show.Rows.Count ; i++)
                {
                    mon = AttenDtTmPkr.Value.ToString("MMMM/yyyy");
                    rid = Convert.ToString(dgv_show.Rows[i].Cells["rid"].Value);
                    IssueID = Convert.ToString(dgv_show.Rows[i].Cells["RetPBill"].Value);
                    kid = Convert.ToString(dgv_show.Rows[i].Cells["kid"].Value);
                    stk_rtn = Convert.ToString(dgv_show.Rows[i].Cells["stk_in"].Value);
                    runit = Convert.ToString(dgv_show.Rows[i].Cells["unit"].Value);
                    ramt = Convert.ToString(dgv_show.Rows[i].Cells["amt"].Value);
                    
                    retdt = Convert.ToString(dgv_show.Rows[i].Cells["dt"].Value);
                    

                    if (dgv_show.Rows[i].Cells["dt"].Value == null || dgv_show.Rows[i].Cells["dt"].Value.ToString().Trim() == "")
                    {
                        retdt = Convert.ToDateTime("01/" + AttenDtTmPkr.Value.ToString("MMM/yyyy")).ToString("dd/MMM/yyyy");
                    }
                    else
                    {
                        retdt = Convert.ToDateTime(dgv_show.Rows[i].Cells["dt"].Value).ToString("dd/MMM/yyyy");
                    }

                    remarks = Convert.ToString(dgv_show.Rows[i].Cells["rmrks"].Value);
                    empid = Convert.ToString(dgv_show.Rows[i].Cells["pid"].Value);
                    try
                    {
                        irid = Convert.ToString(dgv_show.Rows[i].Cells["irid"].Value);
                    }
                    catch { }

                    if (!String.IsNullOrEmpty(IssueID) || !String.IsNullOrEmpty(remarks))
                    {
                        if (!String.IsNullOrEmpty(irid.ToString()))
                        {
                            DataTable dt = clsDataAccess.RunQDTbl("Select count(*) from IssueReturn Where (irid='" + irid + "') and (coid='"+coid+"')");
                            if (dt.Rows.Count > 0)
                            {
                                boolstatus = clsDataAccess.RunNQwithStatus("update IssueReturn set rid='" + rid + "', IssueID='" + IssueID + 
                           "', kid='" + kid + "', stk_rtn='" + stk_rtn + "', runit='" + runit + "', ramt='" + ramt + "', retdt='" + retdt +
                           "', remarks='" + remarks + "', empid='" + empid + "' where (irid=" + irid + ") and (mon='" + mon + "') and (coid='"+coid+"')");
                            }
                            edpcom.InsertMidasLog(this, true, "modify", "Issue Return :" + irid);
                        }
                        else
                        {
                            int Max_ID = 0;
                            DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(rid) FROM IssueReturn");
                            if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }


                            irid = Max_ID.ToString();
                            boolstatus = clsDataAccess.RunNQwithStatus("insert into IssueReturn(irid,rid, IssueID, kid, stk_rtn, runit, ramt, retdt, remarks, empid,mon,coid) values('" +
                            irid + "','" + rid + "','" + IssueID + "','" + kid + "','" + stk_rtn + "','" + runit + "','" + ramt + "','" + retdt + "','" + remarks + "','" + empid + "','" + mon + "','"+coid+"')");

                            edpcom.InsertMidasLog(this, true, "add", "Issue Return :" + irid);
                        }

                        //edpcom.InsertMidasLog(this, true, "add", "purchase :" + pid);
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show(" " + i + "th Row not accepted.");
                    }

                }

            }
            return boolstatus;

        }

        public void get()
        {//PID; dt; RetPBill; vname; kt_nm; stk_in; unit; amt; rmrks; kid; rid;
            try
            {
                dgv_show.Rows.Clear();
            }
            catch { }
            DataTable dtIR = clsDataAccess.RunQDTbl("select irid,rid, IssueID," +
             "(Select KTNAME from MSTKIT where KTID=ir.kid and coid=ir.CoID) as Kit, kid,stk_rtn, runit, ramt,CONVERT(VARCHAR(11),retdt,103)retdt , remarks, empid," +
            "(Select distinct [EKNAME] from tbl_Employee_KIT e where [EKEID]=ir.empid and coid=ir.CoID)ename from IssueReturn ir where (mon='" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "') and (coid='" + coid + "')");
                  
            for (int ind=0;ind<dtIR.Rows.Count;ind++)
            {
            dgv_show.Rows.Add();
            this.dgv_show.Rows[ind].Cells["irid"].Value = dtIR.Rows[ind]["irid"];
            this.dgv_show.Rows[ind].Cells["rid"].Value = dtIR.Rows[ind]["rid"];
            this.dgv_show.Rows[ind].Cells["pid"].Value = dtIR.Rows[ind]["empid"];
            this.dgv_show.Rows[ind].Cells["RetPBill"].Value = dtIR.Rows[ind]["IssueID"];
            this.dgv_show.Rows[ind].Cells["stk_in"].Value = dtIR.Rows[ind]["stk_rtn"];
            this.dgv_show.Rows[ind].Cells["dt"].Value = dtIR.Rows[ind]["retdt"];
            this.dgv_show.Rows[ind].Cells["amt"].Value = dtIR.Rows[ind]["ramt"];
                    this.dgv_show.Rows[ind].Cells["vname"].Value = dtIR.Rows[ind]["ename"];
            this.dgv_show.Rows[ind].Cells["kid"].Value = dtIR.Rows[ind]["kid"];
            this.dgv_show.Rows[ind].Cells["kt_nm"].Value = dtIR.Rows[ind]["Kit"];
            this.dgv_show.Rows[ind].Cells["unit"].Value = dtIR.Rows[ind]["runit"];

            }
        }
        private void dgv_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmKitIssueReturn_Load(object sender, EventArgs e)
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

            AttenDtTmPkr.Value = DateTime.Now;
            CmbCompany.PopUp();
        }

        private void AttenDtTmPkr_ValueChanged(object sender, EventArgs e)
        {
            int firstDayInCurrentMonth = 1;
            int lastDayInCurrentMonth = DateTime.DaysInMonth(AttenDtTmPkr.Value.Year, AttenDtTmPkr.Value.Month);


            dt.DefaultCellStyle.NullValue = AttenDtTmPkr.Value.ToString("dd/MM/yyyy");
            date_Min = AttenDtTmPkr.Value.ToString("01/MMM/yyyy");
            date_Max = AttenDtTmPkr.Value.ToString(lastDayInCurrentMonth+"/MMM/yyyy");


            get();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (submit_det())
            {
                ERPMessageBox.ERPMessage.Show(" Issue Return Saved Successfully");
                get();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit Issue Return");
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] yr = cmbYear.Text.Split('-');

            
            AttenDtTmPkr.MinDate = Convert.ToDateTime("01/April/" + yr[0].ToString().Trim());
            AttenDtTmPkr.MaxDate = Convert.ToDateTime("31/March/" + yr[1].ToString().Trim());
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
                coid = CmbCompany.ReturnValue.ToString().Trim();
                if (coid.Trim() == "")
                {
                    coid = "1";
                }
                get();

            }
        }

        private void CmbCompany_CloseUp(object sender, ComboDialog.CloseUpEventArgs e)
        {
            coid = CmbCompany.ReturnValue.Trim();
            if (coid.Trim() == "")
            {
                coid = "1";
            }
            get();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }  


    }
}
