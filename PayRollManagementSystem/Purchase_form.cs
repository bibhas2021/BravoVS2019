using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmKitPurchase : Form
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        DialogView dv = new DialogView();

        string date_Max, date_Min;

        DateTimePicker oDateTimePicker;
        string CoID = "1";

        public frmKitPurchase()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Purchase_form_Load(object sender, EventArgs e)
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
            GetDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (submit_det())
            {
                ERPMessageBox.ERPMessage.Show(" Purchase details Saved Successfully");
                GetDetails();
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Failed To Submit purchase details");
            }
            
        }
        public Boolean submit_det()
        {
            Boolean boolstatus = false;
            CoID = CmbCompany.ReturnValue;
            if (dgv_show.Rows.Count > 1)
            {
                for (Int32 i = 0; i < dgv_show.Rows.Count - 1; i++)
                {
                    String pid = Convert.ToString(dgv_show.Rows[i].Cells["PID"].Value);
                    string dat;
                    try
                    {
                        dat = Convert.ToDateTime(dgv_show.Rows[i].Cells["dt"].Value).ToString("dd/MMM/yyyy");
                    }
                    catch { dat = DateTime.Now.ToString("dd/MMM/yyyy"); }
                    if (dgv_show.Rows[i].Cells["dt"].Value == null || dgv_show.Rows[i].Cells["dt"].Value.ToString().Trim() == "")
                    {
                        dat =  DateTime.Now.ToString("dd/MMM/yyyy");
                    }
                    else
                    {
                        dat = Convert.ToDateTime(dgv_show.Rows[i].Cells["dt"].Value).ToString("dd/MMM/yyyy");
                    }
                    String knm = Convert.ToString(dgv_show.Rows[i].Cells["kt_nm"].Value);
                    String kid = Convert.ToString(dgv_show.Rows[i].Cells["kid"].Value);
                    String st_in = Convert.ToString(dgv_show.Rows[i].Cells["stk_in"].Value);
                    String pbill = Convert.ToString(dgv_show.Rows[i].Cells["pbill"].Value);
                    String unit = Convert.ToString(dgv_show.Rows[i].Cells["unit"].Value);
                    String amt = Convert.ToString(dgv_show.Rows[i].Cells["amt"].Value);
                    string vname = Convert.ToString(dgv_show.Rows[i].Cells["vname"].Value);
                    string pRate = Convert.ToString(dgv_show.Rows[i].Cells["RT"].Value);

                   
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
                                        DataTable dt = clsDataAccess.RunQDTbl("Select count(*) from purchase Where pid='" + pid + "' and (coid='"+CoID+"')");
                                        if (dt.Rows.Count > 0)
                                        {
                                            boolstatus = clsDataAccess.RunNQwithStatus("update purchase set vname='" + vname + "',pbill='" + pbill + "',p_date='" + dat + "',kt_nm='" + knm + "',stk_in='" + st_in + "',unit='" + unit + "',pRate='" + pRate + "',amt='" + amt + "',kid='" + kid + "',month='" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "' where (pid=" + pid + ") and (coid='"+CoID+"')");
                                        }
                                        edpcom.InsertMidasLog(this, true, "modify", "purchase :" + pid);
                                    }
                                    else
                                    {
                                        int Max_ID = 0;
                                        DataTable dt = clsDataAccess.RunQDTbl("SELECT Max(pid) FROM purchase");
                                        if (Convert.ToString(dt.Rows[0][0]).Length > 0)
                                        {
                                            Max_ID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                                        }
                                        else
                                        {
                                            Max_ID = 1;
                                        }

                                        boolstatus = clsDataAccess.RunNQwithStatus("insert into purchase(pid,p_date,kt_nm,stk_in,unit,amt,kid,month,pbill,vname,stk_rtn,ramt,retdt,remarks,runit,RetPBill,rmonth,pRate,coid) values('" +
                                        Max_ID + "','" + dat + "','" + knm + "','" + st_in + "','" + unit + "','" + amt + "','" + kid + "','" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "','" + pbill + "','" + vname + "','0','0','" + dat + "','','" + unit + "','','','" + pRate + "','"+CoID+"')");

                                        edpcom.InsertMidasLog(this, true, "add", "purchase :" + pid);
                                    }

                                    //edpcom.InsertMidasLog(this, true, "add", "purchase :" + pid);
                                }
                                else
                                {
                                    ERPMessageBox.ERPMessage.Show("Please Enter kit name for " + i + "th Row.");
                                }
                            }
                            else
                            { ERPMessageBox.ERPMessage.Show("Please Enter stock in for " + i + "th Row."); }

                        //}
                        //else
                        //{ ERPMessageBox.ERPMessage.Show("Please Enter unit for " + i + "th Row."); }

                    }
                    else
                    { ERPMessageBox.ERPMessage.Show("Please Enter amount for " + i + "th Row."); }
                }
            
              }
                 else
                 {
                    ERPMessageBox.ERPMessage.Show("No Record To Save");
                 }
            return boolstatus;

        }

           public void GetDetails()
           {
               CoID = CmbCompany.ReturnValue.Trim();
               if (CoID.Trim() == "")
               {
                   CoID = "1";
               }
               DataTable dt = clsDataAccess.RunQDTbl("Select pid,CONVERT(VARCHAR(11),p_date,103) AS 'DATE',isnull((kt_nm),'UNIFORM')AS 'KIT NAME',isnull((stk_in),0)AS'STOCK IN'," +
                "isnull((unit),'pcs')as 'UNIT',isnull((amt),0)as 'AMOUNT',kid,pbill,vname,pRate from purchase where month='" + AttenDtTmPkr.Value.ToString("MMMM/yyyy") + "' and (coid='"+CoID+"') order by pid");
               this.dgv_show.Rows.Clear();
               if (dt.Rows.Count > 0)
               {


                   for (int ind_dgv = 0; ind_dgv < dt.Rows.Count; ind_dgv++)
                   {
                       dgv_show.Rows.Add();
                       dgv_show.Rows[ind_dgv].Cells["PID"].Value = dt.Rows[ind_dgv]["pid"];
                       dgv_show.Rows[ind_dgv].Cells["dt"].Value = dt.Rows[ind_dgv]["DATE"];
                       dgv_show.Rows[ind_dgv].Cells["kt_nm"].Value = dt.Rows[ind_dgv]["KIT NAME"];
                       dgv_show.Rows[ind_dgv].Cells["stk_in"].Value = dt.Rows[ind_dgv]["STOCK IN"];
                       dgv_show.Rows[ind_dgv].Cells["unit"].Value = dt.Rows[ind_dgv]["UNIT"];
                       dgv_show.Rows[ind_dgv].Cells["amt"].Value = dt.Rows[ind_dgv]["AMOUNT"];
                       dgv_show.Rows[ind_dgv].Cells["kid"].Value = dt.Rows[ind_dgv]["kid"];
                       dgv_show.Rows[ind_dgv].Cells["pbill"].Value = dt.Rows[ind_dgv]["pbill"];
                       dgv_show.Rows[ind_dgv].Cells["vname"].Value = dt.Rows[ind_dgv]["vname"];
                       dgv_show.Rows[ind_dgv].Cells["RT"].Value = dt.Rows[ind_dgv]["pRate"];
                       
                   }

               }

           }

           private void dgv_show_CellValueChanged(object sender, DataGridViewCellEventArgs e)
           {
               

           }

           private void dgv_show_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
           {
               //ComboBox comboCell = e.Control as ComboBox;
               //if (comboCell != null)
               //{
               //    comboCell.SelectedIndexChanged += new EventHandler(comboCell_SelectedIndexChanged);
               //}
           }
           // void comboCell_SelectedIndexChanged(object sender, EventArgs e)
            //{
                  //string cellText = dgv_show.CurrentRow.Cells[2].Value.ToString();
                  //    //retrieve data from database using this cellText
                  //dgv_show.CurrentRow.Cells[4].Value = clsDataAccess.GetresultS("select   unit   from MSTKIT where  KTNAME='" + cellText + "'");
           // }

            

            private void dgv_show_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                //if (dgv_show.Columns[e.ColumnIndex].HeaderText == "KIT NAME")
                //{
                //    string ct = dgv_show.Rows[e.RowIndex].Cells[2].Value.ToString();
                //    dgv_show.CurrentRow.Cells[4].Value = clsDataAccess.GetresultS("select   unit   from MSTKIT where  KTNAME='" + ct + "'");
                //}

                double ct = 0;

                if (dgv_show.Columns[e.ColumnIndex].HeaderText.ToLower() == "amount")
                {
                    try
                    {
                        if (e.RowIndex < (dgv_show.Rows.Count - 1))
                        {
                            ct = Convert.ToDouble(dgv_show.Rows[e.RowIndex].Cells["stk_in"].Value.ToString()) * Convert.ToDouble(dgv_show.Rows[e.RowIndex].Cells["RT"].Value.ToString());
                            dgv_show.CurrentRow.Cells["amt"].Value = ct.ToString("0.00");
                        }
                    }
                    catch { }
                }
              
            }

            private void dgv_show_CellLeave(object sender, DataGridViewCellEventArgs e)
            {
                //if (dgv_show.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == dgv_show.Columns["kt_nm"].Index)
                //{
                //    string ct = dgv_show.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //    dgv_show.CurrentRow.Cells[dgv_show.Columns["unit"].Index].Value = clsDataAccess.GetresultS("select   unit   from MSTKIT where  KTNAME='" + ct + "'");
                //}
            }

            private void dgv_show_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                if (dgv_show.Columns[e.ColumnIndex].HeaderText.ToUpper() == "KIT NAME")
                {

                    dv.sql_frm = "SELECT [KTID],KTNAME, unit,KTVAL FROM MSTKIT where (coid='" + CoID + "')";
                    dv.retno = 4;
                    dv.lblCo.Text = "";
                    dv.lblHead.Text = "";
                    dv.btnPreview.Visible = false;
                    dv.ShowDialog();
                    try
                    {
                        int ind = Convert.ToInt32(dgv_show.CurrentRow.Index);
                        this.dgv_show.Rows[ind].Cells["kid"].Value = dv.retval.ToString();
                        this.dgv_show.Rows[ind].Cells["kt_nm"].Value = dv.retval1.ToString();
                        this.dgv_show.Rows[ind].Cells["unit"].Value = dv.retval2.ToString();
                        this.dgv_show.Rows[ind].Cells["RT"].Value = dv.retval3.ToString();
                        this.dgv_show.Rows[ind].Cells["stk_in"].Value = "0";
                        this.dgv_show.Rows[ind].Cells["amt"].Value = "0";
                    }
                    catch
                    { }

                }

                if (dgv_show.Columns[e.ColumnIndex].HeaderText.ToUpper() == "VENDOR NAME")
                {

                    dv.sql_frm = "Select * from MstVendor";
                    dv.retno = 2;
                    dv.lblCo.Text = "";
                    dv.lblHead.Text = "";
                    dv.btnPreview.Visible = false;
                    dv.ShowDialog();
                    try
                    {
                        int ind = Convert.ToInt32(dgv_show.CurrentRow.Index);
                        this.dgv_show.Rows[ind].Cells["vid"].Value = dv.retval.ToString();
                        this.dgv_show.Rows[ind].Cells["vname"].Value = dv.retval1.ToString();
                        
                    }
                    catch
                    { }

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



                //dgv_show.Rows.Clear();
                GetDetails();
            }

            private void button2_Click(object sender, EventArgs e)
            {

            }

            private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
            {
                string[] yr = cmbYear.Text.Split('-');

                
                try
                {
                    AttenDtTmPkr.MinDate = Convert.ToDateTime("01/April/" + yr[0].ToString().Trim());
                }
                catch 
                { }

                try
                {
                    AttenDtTmPkr.MaxDate = Convert.ToDateTime("31/March/" + yr[1].ToString().Trim());
                }
                catch { }
                
            }

            private void label22_Click(object sender, EventArgs e)
            {

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

            private void CmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
            {
                CoID = CmbCompany.ReturnValue;
                if (CoID.Trim() == "")
                {
                    CoID = "1";
                }
                GetDetails();
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
                    CoID = CmbCompany.ReturnValue.ToString();
                    if (CoID.Trim() == "")
                    {
                        CoID = "1";
                    }
                    GetDetails();

                }
            }

            private void dgv_show_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                int iRw = dgv_show.CurrentCell.RowIndex;
                int iCol = dgv_show.CurrentCell.ColumnIndex;
                double ct = 0;
                try
                {
                    if (iCol == 5)
                    {
                        ct = Convert.ToDouble(dgv_show.Rows[iRw].Cells["RT"].Value.ToString()) * Convert.ToDouble(dgv_show.Rows[iRw].Cells["stk_in"].Value.ToString());
                        dgv_show.Rows[iRw].Cells["amt"].Value = ct.ToString("0.00");
                    }
                }
                catch { dgv_show.Rows[iRw].Cells["amt"].Value = ct.ToString("0.00"); }
            }  

        }
    
}
