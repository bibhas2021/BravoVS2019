using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
 

namespace PayRollManagementSystem
{
    public partial class frmAquittance : EDPComponent.FormBaseERP
    {
        public frmAquittance()
        {
            InitializeComponent();
        }
        DataTable dtMnth = new DataTable();
        DataColumn dc1 = new DataColumn("Emp Id");
        DataColumn dc2 = new DataColumn("Emp Name");
        DataColumn dc3 = new DataColumn("Gross Total");
        DataColumn dc4 = new DataColumn("Deduction Total");
        DataColumn dc5 = new DataColumn("Net Amount");
        DataColumn dc6 = new DataColumn("PFC");
        DataColumn dc7 = new DataColumn("PFL");
        DataColumn dc8 = new DataColumn("PFLI");
        DataColumn dc9 = new DataColumn("ESI");
        DataColumn dc10 = new DataColumn("PT");
        DataColumn dc11 = new DataColumn("PF VOL");
        ArrayList sdtE = new ArrayList();
        ArrayList sdtD = new ArrayList();
        Hashtable hsh_sdtE = new Hashtable();
        Hashtable hsh_sdtD = new Hashtable();
        DataColumn[] dc_mnth, dc_mnth1;
        DataRow dr;

        private void frmAquittance_Load(object sender, EventArgs e)
        {
            try
            {
                //generate year
                clsValidation.GenerateYear(cmbsession, 1950, System.DateTime.Now.Year, 1);
                //

                //set session
                if (System.DateTime.Now.Month >= 4)
                {
                    cmbsession.SelectedIndex = 0;
                }
                else
                {
                    cmbsession.SelectedIndex = 1;
                }
            }
            catch (Exception ex) { }
        }
        public void Load_Data(string qry, ComboBox cb, int i)
        {

            DataTable dt = new DataTable();
            dt.Clear();
            dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {
                for (int d = 0; d < dt.Rows.Count; d++)
                {
                    cb.Items.Add(dt.Rows[d][0].ToString());
                }
                if (i >= 0)
                    cb.SelectedIndex = i;
            }
        }

        private void cmbsalstruc_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbsalstruc.Items.Clear();
                string s = "select salarycategory from tbl_Employee_SalaryStructure";
                Load_Data(s, cmbsalstruc, -1);
            }
            catch (Exception ex) { }
        }
        public void get_Aquittance_Dtl()
        {
            int x = 0; //pgmsr.Minimum = 0; pgmsr.Step = 1;

            dtMnth.Columns.Clear();
            dtMnth.Clear();
            dc_mnth = new DataColumn[] { dc1, dc2 };
            dc_mnth1 = new DataColumn[] { dc6, dc7, dc8, dc9, dc10, dc11 };
            dtMnth.Columns.AddRange(dc_mnth);
            get_ErnSalHead_frm_Saldet();
            dtMnth.Columns.Add(dc3);
            get_DedSalHead_frm_Saldet();
            dtMnth.Columns.Add(dc4);
            dtMnth.Columns.AddRange(dc_mnth1);
            dtMnth.Columns.Add(dc5);

            string qry = "select emp_id,Title,FirstName,MiddleName,LastName,totalsal,totaldec,";
            qry += " netpay from tbl_Employee_SalaryMast as esm inner join tbl_Employee_Mast";
            qry += " as em on emp_id=id where esm.session='" + cmbsession.Text.Trim() + "'";
            qry += " and month='" + cmbmonth.Text.Trim() + "' and emp_id in(select id from";
            qry += "  tbl_Employee_Mast where salid in(select slno from tbl_Employee_SalaryStructure";
            qry += " where salarycategory='" + cmbsalstruc.Text.Trim() + "'))";

            DataTable dt = new DataTable();
            dt = clsDataAccess.RunQDTbl(qry);
            if (dt.Rows.Count > 0)
            {

                //pgmsr.Maximum = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dtMnth.NewRow();

                    dr[0] = dt.Rows[i][0].ToString().Trim();
                    dr[1] = dt.Rows[i][1].ToString().Trim() + " " + dt.Rows[i][2].ToString().Trim() + " " + dt.Rows[i][3].ToString().Trim() + " " + dt.Rows[i][4].ToString().Trim();

                    dr[sdtE.Count + 2] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[i][5]));
                    dr[sdtE.Count + 3 + sdtD.Count] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[i][6]));

                    dr[sdtE.Count + 2 + 6 + sdtD.Count + 1 + 1] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[i][7]));

                    dtMnth.Rows.Add(dr);

                    string qry1 = "select distinct emp_id,Title,FirstName,MiddleName,LastName,totalsal,totaldec,";
                    qry1 += " netpay,esd.salid,tablename,amount from tbl_Employee_SalaryMast as esm";
                    qry1 += " inner join tbl_Employee_SalaryDet as esd on emp_id=esd.empid and esm.month=esd.month";
                    qry1 += " and esm.session=esd.session inner join tbl_Employee_Mast as em";
                    qry1 += " on emp_id=id where esm.session='" + cmbsession.Text.Trim() + "' and esm.month='" + cmbmonth.Text.Trim() + "'";
                    //qry1 += " and emp_id ='" + dtMnth.Rows[i][0].ToString().Trim() + "'";

                    DataTable dt1 = new DataTable();
                    dt1 = clsDataAccess.RunQDTbl(qry1);
                    if (dt1.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt1.Rows.Count; j++)
                        {

                            if (dt1.Rows[j][9].ToString() == "tbl_Employee_ErnSalaryHead" && sdtE.Contains(Convert.ToInt32(dt1.Rows[j][8])))

                                dr[sdtE.IndexOf(Convert.ToInt32(dt1.Rows[j][8]), 0) + 2] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));

                            else if (dt1.Rows[j][9].ToString() == "tbl_Employee_DeductionSalayHead" && sdtD.Contains(Convert.ToInt32(dt1.Rows[j][8])))
                                dr[sdtE.Count + sdtD.IndexOf(Convert.ToInt32(dt1.Rows[j][8]), 0) + 3] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));

                            else if (dt1.Rows[j][9].ToString() == "tbl_Employee_Config_PFHeads")
                            {
                                if (Convert.ToInt32(dt1.Rows[j][8]) == 1)
                                    dr[sdtE.Count + sdtD.Count + 4] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                else if (Convert.ToInt32(dt1.Rows[j][8]) == 2)
                                    dr[sdtE.Count + sdtD.Count + 5] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                else if (Convert.ToInt32(dt1.Rows[j][8]) == 3)
                                    dr[sdtE.Count + sdtD.Count + 6] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                else if (Convert.ToInt32(dt1.Rows[j][8]) == 4)
                                    dr[sdtE.Count + sdtD.Count + 7] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                else if (Convert.ToInt32(dt1.Rows[j][8]) == 5)
                                {
                                    if (PT_Cal(Convert.ToDouble(dr[sdtE.Count + 2])))
                                        dr[sdtE.Count + sdtD.Count + 8] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                }
                                else if (Convert.ToInt32(dt1.Rows[j][8]) == 6)
                                    dr[sdtE.Count + sdtD.Count + 9] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                            }

                        }
                    }

                    //pgmsr.PerformStep();
                }


                //dgvmnthsalrate.DataTable = dtMnth;


                //for (int d = 0; d <= dgvmnthsalrate.Columns.Count; d++)
                //{
                //    dgvmnthsalrate.Columns[d].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //    if (d < 2)
                //        dgvmnthsalrate.Columns[d].Frozen = true;
                //    if (d >= 2)
                //        dgvmnthsalrate.Columns[d].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //}



            }
            else
            {
                qry = "select emp_id,Title,FirstName,MiddleName,LastName,totalsal,totaldec,";
                qry += " netpay,esm.month from tbl_Employee_SalaryMast as esm inner join tbl_Employee_Mast";
                qry += " as em on emp_id=id where esm.session='" + cmbsession.Text.Trim() + "'";
                qry += " and emp_id in(select id from  tbl_Employee_Mast where salid in(select";
                qry += " slno from tbl_Employee_SalaryStructure where salarycategory='" + cmbsalstruc.Text.Trim();
                qry += " ')) and esm.month in (select month from tbl_Employee_SalaryMast where session = '" + cmbsession.Text.Trim();
                qry += " ' and emp_id=esm.emp_id and slno in(select max(slno) from tbl_Employee_SalaryMast";
                qry += " where emp_id=esm.emp_id))";

                //DataTable dt = new DataTable();
                dt = clsDataAccess.RunQDTbl(qry);

                if (dt.Rows.Count > 0)
                {

                    //pgmsr.Maximum = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dtMnth.NewRow();

                        dr[0] = dt.Rows[i][0].ToString().Trim();
                        dr[1] = dt.Rows[i][1].ToString().Trim() + " " + dt.Rows[i][2].ToString().Trim() + " " + dt.Rows[i][3].ToString().Trim() + " " + dt.Rows[i][4].ToString().Trim();

                        dr[sdtE.Count + 2] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[i][5]));
                        dr[sdtE.Count + 3 + sdtD.Count] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[i][6]));

                        dr[sdtE.Count + 2 + 6 + sdtD.Count + 1 + 1] = string.Format("{0:N}", Convert.ToDouble(dt.Rows[i][7]));

                        dtMnth.Rows.Add(dr);

                        string qry1 = "select distinct emp_id,Title,FirstName,MiddleName,LastName,totalsal,totaldec,";
                        qry1 += " netpay,esd.salid,tablename,amount from tbl_Employee_SalaryMast as esm";
                        qry1 += " inner join tbl_Employee_SalaryDet as esd on emp_id=esd.empid and esm.month=esd.month";
                        qry1 += " and esm.session=esd.session inner join tbl_Employee_Mast as em";
                        qry1 += " on emp_id=id where esm.session='" + cmbsession.Text.Trim() + "' and esm.month='" + dt.Rows[i][8].ToString().Trim() + "'";
                        qry1 += " and emp_id ='" + dtMnth.Rows[i][0].ToString().Trim() + "'";

                        DataTable dt1 = new DataTable();
                        dt1 = clsDataAccess.RunQDTbl(qry1);
                        if (dt1.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt1.Rows.Count; j++)
                            {

                                if (dt1.Rows[j][9].ToString() == "tbl_Employee_ErnSalaryHead" && sdtE.Contains(Convert.ToInt32(dt1.Rows[j][8])))

                                    dr[sdtE.IndexOf(Convert.ToInt32(dt1.Rows[j][8]), 0) + 2] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));

                                else if (dt1.Rows[j][9].ToString() == "tbl_Employee_DeductionSalayHead" && sdtD.Contains(Convert.ToInt32(dt1.Rows[j][8])))
                                    dr[sdtE.Count + sdtD.IndexOf(Convert.ToInt32(dt1.Rows[j][8]), 0) + 3] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));

                                else if (dt1.Rows[j][9].ToString() == "tbl_Employee_Config_PFHeads")
                                {
                                    if (Convert.ToInt32(dt1.Rows[j][8]) == 1)
                                        dr[sdtE.Count + sdtD.Count + 4] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                    else if (Convert.ToInt32(dt1.Rows[j][8]) == 2)
                                        dr[sdtE.Count + sdtD.Count + 5] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                    else if (Convert.ToInt32(dt1.Rows[j][8]) == 3)
                                        dr[sdtE.Count + sdtD.Count + 6] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                    else if (Convert.ToInt32(dt1.Rows[j][8]) == 4)
                                        dr[sdtE.Count + sdtD.Count + 7] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                    else if (Convert.ToInt32(dt1.Rows[j][8]) == 5)
                                    {
                                        if (PT_Cal(Convert.ToDouble(dr[sdtE.Count + 2])))
                                            dr[sdtE.Count + sdtD.Count + 8] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                    }
                                    else if (Convert.ToInt32(dt1.Rows[j][8]) == 6)
                                        dr[sdtE.Count + sdtD.Count + 9] = string.Format("{0:N}", Convert.ToDouble(dt1.Rows[j][10]));
                                }

                            }
                        }

                        //pgmsr.PerformStep();
                    }


                    //dgvmnthsalrate.DataTable  = dtMnth;


                    //for (int d = 0; d <= dgvmnthsalrate.Columns.Count; d++)
                    //{
                    //    dgvmnthsalrate.Columns[d].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //    if (d < 2)
                    //        dgvmnthsalrate.Columns[d].Frozen = true;
                    //    if (d >= 2)
                    //        dgvmnthsalrate.Columns[d].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    //}

                }

            }

            //pgmsr.Visible = false;

        }

        private void cmbsalstruc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                get_Aquittance_Dtl();
            }
            catch (Exception ex) { }
        }
        public void get_ErnSalHead_frm_Saldet()
        {
            sdtE.Clear();
            string qry = "select P_TYPE,SAL_HEAD,V_FROM,V_TO from tbl_Employee_Assign_SalStructure where session='" + cmbsession.Text.Trim() + "' and sal_struct in(select slno from tbl_Employee_SalaryStructure where salarycategory='" + cmbsalstruc.Text.Trim() + "')";
            DataTable dt_temp = new DataTable();
            dt_temp = clsDataAccess.RunQDTbl(qry);
            if (dt_temp.Rows.Count > 0)
            {
                for (int k = 0; k < dt_temp.Rows.Count; k++)
                {
                    if (clsEmployee.GetMonth_SingleDigit(cmbmonth.Text.Trim()) >= clsEmployee.GetMonth_SingleDigit(dt_temp.Rows[k][2].ToString()) && clsEmployee.GetMonth_SingleDigit(cmbmonth.Text.Trim()) <= clsEmployee.GetMonth_SingleDigit(dt_temp.Rows[k][3].ToString()))
                    {
                        if (dt_temp.Rows[k][0].ToString() == "E")
                        {
                            qry = "select salaryhead_short from tbl_Employee_ErnSalaryHead where slno=" + Convert.ToInt32(dt_temp.Rows[k][1]);
                            DataTable dte = new DataTable();
                            dte = clsDataAccess.RunQDTbl(qry);
                            if (dte.Rows.Count > 0)
                            {
                                DataColumn dc = new DataColumn(dte.Rows[0][0].ToString());
                                dtMnth.Columns.Add(dc);
                                sdtE.Add(Convert.ToInt32(dt_temp.Rows[k][1]));

                            }
                        }
                    }
                }

            }

        }
        public void get_DedSalHead_frm_Saldet()
        {
            sdtD.Clear();
            string qry = "select P_TYPE,SAL_HEAD,V_FROM,V_TO from tbl_Employee_Assign_SalStructure where session='" + cmbsession.Text.Trim() + "' and sal_struct in(select slno from tbl_Employee_SalaryStructure where salarycategory='" + cmbsalstruc.Text.Trim() + "')";
            DataTable dt_temp = new DataTable();
            dt_temp = clsDataAccess.RunQDTbl(qry);
            if (dt_temp.Rows.Count > 0)
            {

                for (int l = 0; l < dt_temp.Rows.Count; l++)
                {
                    if (clsEmployee.GetMonth_SingleDigit(cmbmonth.Text.Trim()) >= clsEmployee.GetMonth_SingleDigit(dt_temp.Rows[l][2].ToString()) && clsEmployee.GetMonth_SingleDigit(cmbmonth.Text.Trim()) <= clsEmployee.GetMonth_SingleDigit(dt_temp.Rows[l][3].ToString()))
                    {

                        if (dt_temp.Rows[l][0].ToString() == "D")
                        {
                            qry = "select salaryhead_short from tbl_Employee_DeductionSalayHead where slno=" + Convert.ToInt32(dt_temp.Rows[l][1]);
                            DataTable dte = new DataTable();
                            dte = clsDataAccess.RunQDTbl(qry);
                            if (dte.Rows.Count > 0)
                            {
                                DataColumn dc = new DataColumn(dte.Rows[0][0].ToString());
                                dtMnth.Columns.Add(dc);
                                sdtD.Add(Convert.ToInt32(dt_temp.Rows[l][1]));

                            }
                        }
                    }
                }

            }

        }
        public bool PT_Cal(double rate)
        {
            bool status = false;
            string s = "";
            //s = "select pt,wfrom,wto from tbl_Employee_PTRate where Session='" + cmbYear.Text.Trim() + "' and monthof='" + cmbMonth.Text.Trim() + "'";
            s = "select pt,wfrom,wto from tbl_Employee_PTRate where Session='" + cmbsession.Text.Trim() + "' and ptgroup='" + cmbsalstruc.Text.Trim() + "'";
            DataTable dtpt = new DataTable();
            dtpt = clsDataAccess.RunQDTbl(s);
            if (dtpt.Rows.Count > 0)
            {
                for (int t = 0; t < dtpt.Rows.Count; t++)
                {
                    if (dtpt.Rows[t][2].ToString() != "Max.Value")
                    {
                        if (rate >= Convert.ToDouble(dtpt.Rows[t][1]) && rate <= Convert.ToDouble(dtpt.Rows[t][2]))
                        {

                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    else
                    {
                        if (rate >= Convert.ToDouble(dtpt.Rows[t][1]) && Convert.ToString(dtpt.Rows[t][2]) == "Max.Value")
                        {

                            status = true;
                        }
                        else
                        {

                            status = false;
                        }

                    }
                }
            }

            return status;
        }
    }
}