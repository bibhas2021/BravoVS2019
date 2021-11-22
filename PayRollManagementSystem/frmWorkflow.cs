using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public partial class frmWorkflow : Form
    {
        int code;
        DataTable DTResource;
        DataRow row;
        String menucode;
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();


        public frmWorkflow()
        {
            InitializeComponent();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl("select CO_NAME,CO_CODE from Company");
            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            dgv_Status.Rows.Clear();
            code = Convert.ToInt32(cmbcompany.ReturnValue);
            double ps = 0, pb = 0, sl = 0;

           // int index = dataGridView2.CurrentCell.RowIndex;
            String var_month = dateTimePicker1.Value.ToString("MMMM");
            String var_Year = dateTimePicker1.Value.ToString("yyyy");
            string bill_status = "",payslip="",atten="";
            edpcon.Open();
            String str = "select distinct Location_id, Location_Name as Location," +
         "(SELECT COUNT(*) FROM tbl_Employee_Attend WHERE (Season = '" + cmbYear.Text + "') AND (Month = '"+ dateTimePicker1.Value.ToString("M/yyyy") +"') AND (LOcation_ID =el.Location_ID)) as attcount," +
          "(SELECT distinct Status FROM tbl_Employee_Attend WHERE (Season = '" + cmbYear.Text + "') AND (Month = '" + dateTimePicker1.Value.ToString("M/yyyy") + "') AND (LOcation_ID =el.Location_ID)) as attstatus," +
 "isNull((select isNull(SalaryCategory,'') from tbl_Employee_SalaryStructure where SLNO in (select eas.SAL_STRUCT from  tbl_Employee_Assign_SalStructure as eas where Location_ID=el.Location_ID and Company_id='" + code + "')),'-')AS SalaryStruct," +
 "ISNULL((SELECT distinct (CASE WHEN status != '1' THEN 'Incomplete' else 'Complete' end)as status FROM tbl_Employee_SalaryMast WHERE (Company_id = '" + code + "') AND (Location_id = el.Location_ID) AND (Month = '" + var_month + "') AND (Session = '" + cmbYear.Text + "')),'No Salary') AS SalGen," +
 "isNull((SELECT COUNT(Emp_Id) AS Ecount FROM tbl_Employee_SalaryMast WHERE (Company_id = '" + code + "') AND (Location_id = el.Location_ID) AND (Month = '" + var_month + "') AND (Session =  '" + cmbYear.Text + "') GROUP BY Location_id),0) AS PaySlip," +
 "isNull((SELECT COUNT(*) AS BCount FROM paybill WHERE (Month LIKE '" + var_month + "%') AND (Session= '" + cmbYear.Text + 
 "') AND (Comany_id = '" + code + "') AND (Location_ID = el.Location_id) GROUP BY Comany_id, Location_ID), 0) AS Bill from tbl_Emp_Location as el where Cliant_ID in (select distinct Cliant_ID from tbl_Employee_CliantMaster where coid='" + code + "')";

            DataTable dt = clsDataAccess.RunQDTbl(str);
            if (dt.Rows.Count > 0)
            {
                btnPreview.Visible = true;
            }
            else
            {
                btnPreview.Visible = false;
            }
            for (int ind = 0; ind < dt.Rows.Count; ind++)
            {
                dgv_Status.Rows.Add();
                dgv_Status.Rows[ind].Cells["ColLocation"].Value = dt.Rows[ind]["Location"].ToString();

                if (dt.Rows[ind]["attcount"].ToString() == "0")
                {
                   atten = "No Attendence";
                }
                else
                {
                    if (dt.Rows[ind]["attstatus"].ToString() == "1")
                    {
                        atten = "Completed";
                    }
                    else
                    {
                        atten = "InCompleted";
                    }

                    
                }

                dgv_Status.Rows[ind].Cells["ColAtten"].Value = atten;
                dgv_Status.Rows[ind].Cells["ColSalStructure"].Value = dt.Rows[ind]["SalaryStruct"].ToString();
                dgv_Status.Rows[ind].Cells["colSalGen"].Value = dt.Rows[ind]["SalGen"].ToString();
                if (dt.Rows[ind]["PaySlip"].ToString() == "0")
                {
                    payslip = "No Payslip";
                }
                else
                {
                    payslip = "No. of Payslip: " + dt.Rows[ind]["PaySlip"].ToString();
                }
                dgv_Status.Rows[ind].Cells["ColPSlip"].Value =payslip ;

                if (dt.Rows[ind]["Bill"].ToString()=="0"){
                    bill_status="No Bill Generated";
                }else{
                    bill_status = " No. of Bill Gennerated : " + dt.Rows[ind]["Bill"].ToString();
                }

                dgv_Status.Rows[ind].Cells["ColBl"].Value =bill_status;
                dgv_Status.Rows[ind].Cells["colPayRec"].Value = "0";//dt.Rows[ind]["Location"].ToString();
                dgv_Status.Rows[ind].Cells["collid"].Value = dt.Rows[ind]["Location_id"].ToString();
                dgv_Status.Rows[ind].HeaderCell.Value = dt.Rows[ind]["Location_id"].ToString();
            }
            dgv_Status.AutoResizeColumns();
            dgv_Status.AutoResizeRows();
            //for (int i = 0; i < listBox1.Items.Count; i++)
            //{
            //    dataGridView1.Rows.Add();
            //    dataGridView1.Rows[i].Cells[0].Value = listBox1.Items[i].ToString();
            //    try
            //    {
            //        String str = "SELECT isNull(COUNT(DISTINCT Location_id),0) AS structure FROM tbl_Employee_Assign_SalStructure WHERE (Company_id = '" + code + "')";
            //        String str3 = "SELECT isNull(COUNT(distinct Location_id),0) AS sal FROM tbl_Employee_SalaryMast WHERE (Company_id='" + code + "') AND (Month = '" + listBox1.Items[i].ToString() + "') AND (Session = '" + cmbYear.Text + "')";
            //        dataGridView2.Rows[i].Cells[1].Value = clsDataAccess.GetresultS(str) + " - " + clsDataAccess.GetresultS(str3);
            //        sl = sl + Convert.ToDouble(clsDataAccess.GetresultS(str3));

            //        String str1 = "SELECT isNull(COUNT(Emp_Id),0) AS ps FROM tbl_Employee_SalaryMast WHERE (Company_id = '" + code + "') AND (Month = '" + listBox1.Items[i].ToString() + "') AND (Session = '" + cmbYear.Text + "') GROUP BY Company_id";

            //        string sr = (string.IsNullOrEmpty(clsDataAccess.GetresultS(str1)) ? "0" : clsDataAccess.GetresultS(str1));

            //        dataGridView2.Rows[i].Cells[2].Value = sr;
            //        try
            //        {
            //            ps = ps + Convert.ToDouble(sr);
            //        }
            //        catch
            //        {
            //            ps = ps + 0;
            //        }
            //        String str2 = "SELECT isNull(COUNT(*),0) AS tBill FROM paybill WHERE (Month like '" + listBox1.Items[i].ToString() + "%') AND (Session ='" + cmbYear.Text + "') AND (Comany_id = '" + code + "')";
            //        //"SELECT COUNT(Emp_Id) AS ps, Location_id FROM tbl_Employee_SalaryMast WHERE (Company_id = '" + code + "') AND (Month = '" + listBox1.Items[i].ToString() + "') AND (Session = '" + cmbYear.Text + "') GROUP BY Location_id";

            //        string sr2 = (string.IsNullOrEmpty(clsDataAccess.GetresultS(str2)) ? "0" : clsDataAccess.GetresultS(str2));
            //        dataGridView2.Rows[i].Cells[3].Value = Convert.ToDouble(sr2);

            //        try
            //        {
            //            pb = pb + Convert.ToDouble(sr2);
            //        }
            //        catch
            //        {
            //            pb = pb + 0;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //    }


            //}

            ////for (int i = 0; i < dataGridView2.Rows.Count; i++)
            ////{
            ////    ps = ps +Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            ////    pb = pb + Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
            ////}
            //dataGridView2.Rows.Add();
            //int inx = dataGridView2.Rows.Add();
            //dataGridView2.Rows[inx].Cells[0].Value = "Total :";
            //dataGridView2.Rows[inx].Cells[1].Value = sl;
            //dataGridView2.Rows[inx].Cells[2].Value = ps;
            //dataGridView2.Rows[inx].Cells[3].Value = pb;
        }

        private void frmWorkflow_Load(object sender, EventArgs e)
        {
            clear();
            this.WindowState = FormWindowState.Maximized;
        }

        public void clear()
        {
            clsValidation.GenerateYear(cmbYear, 2012, System.DateTime.Now.Year, 1);
            dateTimePicker1.Value = System.DateTime.Now.AddMonths(-1);
            cmbcompany.Text = "";
            dgv_status_log.Rows.Clear();
            dgv_Status.Rows.Clear();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value.Month >= 4)
                {
                    try
                    { cmbYear.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year; }
                    catch { }

                }
                else
                {
                    cmbYear.SelectedItem = dateTimePicker1.Value.AddYears(-1).Year + "-" + dateTimePicker1.Value.Year;

                }
            }
            catch
            { }   
        }

        private void dgv_Status_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string locid = "", coid = "", sql = "",job="",status="";
            int ind = 0;
            dgv_status_log.Rows.Clear();
            ind = dgv_Status.CurrentCell.RowIndex; 
              String var_month = dateTimePicker1.Value.ToString("MMM");
            String var_Year = dateTimePicker1.Value.ToString("yyyy");
            try
            {
                locid = dgv_Status.Rows[ind].Cells["collid"].Value.ToString();

            }
            catch
            {
                locid = "";
            }
            coid = cmbcompany.ReturnValue;

            DataTable dt = new DataTable();
            try
            {
                if (locid != "")
                {
                    sql = "SELECT wfid,ucode,Job,status,docno,wdate,type,node,month,year,locid,coid FROM tbl_workflow_log where locid='" + locid + "' and coid='" + coid + "' and month='" + var_month + "' and year='" + var_Year + "' order by wdate,ucode";
                    dt = clsDataAccess.RunQDTbl(sql);
                    for (int idx = 0; idx < dt.Rows.Count; idx++)
                    {
                        dgv_status_log.Rows.Add();
                        dgv_status_log.Rows[idx].Cells["col_date"].Value = dt.Rows[idx]["wdate"].ToString();
                        
                            dgv_status_log.Rows[idx].Cells["col_ucode"].Value = dt.Rows[idx]["ucode"].ToString();

                        if (dt.Rows[idx]["docno"].ToString().Trim()==""){
                            job=  dt.Rows[idx]["Job"].ToString();
                        }
                        else{
                            job= dt.Rows[idx]["Job"].ToString() +" - "+  dt.Rows[idx]["docno"].ToString();
                        }
                        if (dt.Rows[idx]["status"].ToString().Trim()=="1"){
                            status="Completed";
                        }
                        else{
                            status= "Pending / Not Done";
                        }

                                dgv_status_log.Rows[idx].Cells["col_job"].Value =job;
                                dgv_status_log.Rows[idx].Cells["col_type"].Value = dt.Rows[idx]["type"].ToString();
                                dgv_status_log.Rows[idx].Cells["col_node"].Value = dt.Rows[idx]["node"].ToString();
                                dgv_status_log.Rows[idx].Cells["col_monthyr"].Value = dt.Rows[idx]["month"].ToString() + " - " + dt.Rows[idx]["year"].ToString();





                    }
                }
            }
            catch { }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Location");
            dt.Columns.Add("Attendence");
            dt.Columns.Add("Sal.Structure");
            dt.Columns.Add("Sal.Sheet Gen");
            dt.Columns.Add("Pay Slip");
            dt.Columns.Add("Bill");
            dt.Columns.Add("month");
            dt.Columns.Add("Session");
            dt.Columns.Add("Company");
            dt.Columns.Add("Address");
            for (int ind = 0; ind < dgv_Status.Rows.Count; ind++)
            {
                dt.Rows.Add();
                dt.Rows[ind]["Location"] = dgv_Status.Rows[ind].Cells["ColLocation"].Value.ToString();
                dt.Rows[ind]["Attendence"] = dgv_Status.Rows[ind].Cells["ColAtten"].Value.ToString();
                dt.Rows[ind]["Sal.Structure"] = dgv_Status.Rows[ind].Cells["ColSalStructure"].Value.ToString();
                dt.Rows[ind]["Sal.Sheet Gen"] = dgv_Status.Rows[ind].Cells["colSalGen"].Value.ToString();
                dt.Rows[ind]["Pay Slip"] = dgv_Status.Rows[ind].Cells["ColPSlip"].Value.ToString();
                dt.Rows[ind]["Bill"] = dgv_Status.Rows[ind].Cells["ColBl"].Value.ToString();
                dt.Rows[ind]["month"] = dateTimePicker1.Value.ToString("MMMM");
                dt.Rows[ind]["Session"] = cmbYear.Text.ToString();
                dt.Rows[ind]["Company"] = cmbcompany.Text.ToString();
                //dt.Rows[ind]["SlNo"] = ind + 1;
                dt.Rows[ind]["Address"] = clsDataAccess.GetresultS(" select CO_ADD from Company where GCODE = '" + cmbcompany.ReturnValue + "' ");
            }
            MidasReport.Form1 opening = new MidasReport.Form1();
            opening.Workflow(dt);

            opening.ShowDialog();
        }

       

      
        
    }
}
