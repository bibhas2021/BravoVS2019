using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using Edpcom;

namespace PayRollManagementSystem
{
    public partial class Assignheadsalstru : Form
    {
        public Assignheadsalstru()
        {
            InitializeComponent();
        }
       // DataRow dr;
       // string session = "";
       // DataTable dt_ass = new DataTable();
       // DataColumn dc1 = new DataColumn("PayType");
       // DataColumn dc2 = new DataColumn("SalaryHead");
       // DataColumn dc3 = new DataColumn("PrintName");
       // DataColumn dc4 = new DataColumn("ValidFrom");
       // DataColumn dc5 = new DataColumn("ValidTo");
       // DataColumn dc6 = new DataColumn("CalcBasis");
       // DataColumn dc7 = new DataColumn("CalcType");
       // DataColumn dc8 = new DataColumn("FormulaSlabLum");
       // DataColumn dc9 = new DataColumn("PF");
       // DataColumn dc10 = new DataColumn("PFPER");
       // DataColumn dc11 = new DataColumn("PFVOL");
       // DataColumn dc12 = new DataColumn("ESIPER");
       // DataColumn dc13 = new DataColumn("ESI");
       // DataColumn dc14 = new DataColumn("PT");
       // DataColumn dc15 = new DataColumn("Round Off");
       // DataColumn dc16 = new DataColumn("Round Type");
       // DataColumn dc17 = new DataColumn("TDS");
       // DataColumn dc18 = new DataColumn("TDS Exempt");
       // DataColumn dc19 = new DataColumn("TDS Exempt Max");
       // DataColumn dc20 = new DataColumn("Carry");
       // DataColumn dc21 = new DataColumn("TDS Extrapolate");
       // DataColumn dc22 = new DataColumn("Remarks");
       // DataColumn dc24 = new DataColumn("slno");
       // DataColumn dc26 = new DataColumn("AttenDay");
       // DataColumn dc27 = new DataColumn("OverTime");
       // DataColumn dc28 = new DataColumn("DailyWages");
       // DataColumn dc29 = new DataColumn("Revenue Stamp");
       // DataColumn dc30 = new DataColumn("Stamp Amount");
       // //testless
       // DataColumn dc31 = new DataColumn("Empbasic");
       // //DataColumn dc32 = new DataColumn("EmpSal");
       // //
       // Hashtable hsg_ass_head_sal_struc = new Hashtable();
       // int sl_no = 0, Locations = 0, company_Id = 0;

       // string _paytype = "";
       //public void compname()
       // {
       //     CmbCompany_id.Items.Clear();
       //     CmbCompany1.Items.Clear();
       //     //edpcon.Open();
       //     DataTable cmpdt = clsDataAccess.RunQDTbl("select distinct Co_Code,Co_Name from company,tbl_Employee_Assign_SalStructure where session='" + CmbSession.Text + "'");
       //     for (int i = 0; i < cmpdt.Rows.Count; i++)
       //     {
       //         CmbCompany1.Items.Add(cmpdt.Rows[i]["CO_NAME"].ToString());
       //         CmbCompany_id.Items.Add(cmpdt.Rows[i]["Co_Code"].ToString());
       //     }
       //     // edpcon.Close();
       // }
       // public void locname()
       // {
       //     CmbLocation1.Items.Clear();
       //     CmbLocation_id1.Items.Clear();
       //     DataTable locdt = clsDataAccess.RunQDTbl(" select distinct l.Location_Name,l.Location_ID  from tbl_Emp_Location l,tbl_Employee_Link_SalaryStructure ls ,Companywiseid_Relation r,dbo.tbl_Employee_Assign_SalStructure a where l.Location_ID = ls.Location_ID and l.Location_ID =r.Location_ID and a.session='" + CmbSession.Text + "'and a.company_id =" + Convert.ToInt32(CmbCompany_id.SelectedItem)  );
       //     for (int i = 0; i < locdt.Rows.Count; i++)
       //     {
       //         CmbLocation1.Items.Add(locdt.Rows[i]["Location_name"].ToString());
       //         CmbLocation_id1.Items.Add(locdt.Rows[i]["Location_ID"].ToString());
       //     }
       // }
       // private void CmbCompany_SelectedIndexChanged(object sender, EventArgs e)
       // {
       //     CmbCompany_id.SelectedIndex = CmbCompany1.SelectedIndex;
       //     locname();
       // }

       // private void CmbLocation_SelectedIndexChanged(object sender, EventArgs e)
       // {
            
       //     //DataTable locdt = clsDataAccess.RunQDTbl("select Location_name from tbl_emp_location");
       //     //string location_id = locdt.Rows[0]["location_name"].ToString();
       // }
            
       // private void Assignheadsalstru_Load(object sender, EventArgs e)
       // {
       //     clsValidation.GenerateYear(CmbSession, 1950, System.DateTime.Now.Year, 1);
       //     //DataTable dt = clsDataAccess.RunQDTbl("select salarycategory from tbl_employee_salarystructure");
       //    // get_SalStructID();
       //    // compname();

       // }
       // public string get_sal_head_name(int id, string type)
       // {
       //     string res = "";
       //     if (type == "E")
       //     {
       //         string s = "select SalaryHead_Short from tbl_Employee_ErnSalaryHead where slno=" + id;
       //         DataTable dts = new DataTable();
       //         dts = clsDataAccess.RunQDTbl(s);
       //         if (dts.Rows.Count > 0)
       //             res = dts.Rows[0][0].ToString();

       //     }
       //     else if (type == "D")
       //     {
       //         string s = "select SalaryHead_Short from tbl_Employee_DeductionSalayHead where slno=" + id;

       //         DataTable dts = new DataTable();
       //         dts = clsDataAccess.RunQDTbl(s);
       //         if (dts.Rows.Count > 0)
       //             res = dts.Rows[0][0].ToString();
       //     }

       //     return res;

       // }
       // public string sal_Head_Name(char type, string head)
       // {
       //     string res = "";
       //     if (type == 'E')
       //     {
       //         string s = "select salaryhead_full from tbl_Employee_ErnSalaryHead where salaryhead_short='" + head + "'";
       //         DataTable dts = new DataTable();
       //         dts = clsDataAccess.RunQDTbl(s);
       //         if (dts.Rows.Count > 0)
       //             res = dts.Rows[0][0].ToString();

       //     }
       //     else if (type == 'D')
       //     {
       //         string s = "select salaryhead_full from tbl_Employee_DeductionSalayHead where salaryhead_short='" + head + "'";

       //         DataTable dts = new DataTable();
       //         dts = clsDataAccess.RunQDTbl(s);
       //         if (dts.Rows.Count > 0)
       //             res = dts.Rows[0][0].ToString();
       //         //if (res == "")
       //         //{
       //         //    s = "select pfhead from tbl_Employee_Config_PFHeads where shortname='" + head + "'";
       //         //    dts = clsDataAccess.RunQDTbl(s);
       //         //    if (dts.Rows.Count > 0)
       //         //        res = dts.Rows[0][0].ToString();

       //         //}
       //     }

       //     return res;
       // }
       // public string get_OtherName(string typeName, int id)
       // {
       //     string s = ""; string ret = ""; DataTable dts = new DataTable();
       //     if (typeName == "COMPANY LUMPSUM")
       //     {
       //         s = "select amount from tbl_Employee_Lumpsum where LUMPID=" + id + " and LUMPTYPE=0";

       //         dts = clsDataAccess.RunQDTbl(s);
       //         if (dts.Rows.Count > 0)
       //             ret = dts.Rows[0][0].ToString();

       //     }
       //     else if (typeName == "SAL STRUCTURE LUMPSUM")
       //     {
       //         s = "select lumpname from tbl_Employee_Lumpsum where LUMPID=" + id + " and LUMPTYPE=1";
       //         dts = clsDataAccess.RunQDTbl(s);
       //         if (dts.Rows.Count > 0)
       //             ret = dts.Rows[0][0].ToString();
       //     }
       //     else if (typeName == "FORMULA")
       //     {
       //         s = "select fexp from tbl_Employee_Sal_Structure_Formula where fid=" + id;
       //         dts = clsDataAccess.RunQDTbl(s);
       //         if (dts.Rows.Count > 0)
       //             ret = dts.Rows[0][0].ToString();
       //     }
       //     else if (typeName == "SLAB")
       //     {
       //         s = "select slabname from tbl_Employee_Slab_Def where slabid=" + id;
       //         dts = clsDataAccess.RunQDTbl(s);
       //         if (dts.Rows.Count > 0)
       //             ret = dts.Rows[0][0].ToString();
       //     }

       //     return ret;
       // }

       // public void get_ass()
       // {
       //     sl_no = 0;
       //     dt_ass.Clear();
       //     dt_ass.Columns.Clear();
       //     hsg_ass_head_sal_struc.Clear();

       //     DataColumn[] dc25 = new DataColumn[] { dc1, dc2, dc3, dc4, dc5, dc6, dc7, dc8, dc9, dc10, dc11, dc12, dc13, dc14, dc15, dc16, dc17, dc18, dc19, dc20, dc21, dc22, dc24, dc26, dc27, dc28, dc29, dc30, dc31 };//, dc32
       //     dt_ass.Columns.AddRange(dc25);
       //     string s = "";
       //     s = "select P_TYPE,SESSION,SAL_STRUCT,Sal_HEAD,V_FROM,V_To,C_Basis,C_Type,C_DET,PF_PER,PF_VOL,ESI_PER,PT,ROUND_TYPE,TDSREFNO,TDS_EXEMPT,CARRY,TDS_EXTRAPOL,REMARKS,SLNO,Atten_Day,Proxy_day,Daily_Wages,Revenue_Stamp,Stamp_Amount,Emp_basic from tbl_Employee_Assign_SalStructure where session='" + CmbSession.Text + "'and company_id=" + Convert.ToInt32(CmbCompany_id.SelectedItem)+ "and Location_id=" + Convert.ToInt32(CmbLocation_id1.SelectedItem);
       //     DataTable dt = new DataTable();
       //     dt = clsDataAccess.RunQDTbl(s);
       //     if (dt.Rows.Count > 0)
       //     {

       //         for (int y = 0; y < dt.Rows.Count; y++)
       //         {

       //             if (dt.Rows[y][0].ToString().Trim() == "E")
       //             {
       //                 dr = dt_ass.NewRow();
       //                 dr[0] = "Ear";
       //                 dr[1] = get_sal_head_name(Convert.ToInt32(dt.Rows[y][3]), "E");
       //                 dr[2] = sal_Head_Name('E', get_sal_head_name(Convert.ToInt32(dt.Rows[y][3]), "E"));
       //                 dr[3] = dt.Rows[y][4].ToString() + "/" + dt.Rows[y][1].ToString();
       //                 dr[4] = dt.Rows[y][5].ToString() + "/" + dt.Rows[y][1].ToString();
       //                 dr[5] = dt.Rows[y][6].ToString();
       //                 dr[6] = dt.Rows[y][7].ToString();
       //                 dr[7] = get_OtherName(dt.Rows[y][7].ToString(), Convert.ToInt32(dt.Rows[y][8]));
       //                 if (Convert.ToInt32(dt.Rows[y][9]) == 0)
       //                 {
       //                     dr[8] = "NO";
       //                     dr[9] = "";
       //                 }
       //                 else
       //                 {
       //                     dr[8] = "YES";
       //                     dr[9] = dt.Rows[y][9].ToString();
       //                 }
       //                 if (Convert.ToInt32(dt.Rows[y][10]) == 0)
       //                     dr[10] = "NO";
       //                 else
       //                     dr[10] = "YES";

       //                 if (Convert.ToInt32(dt.Rows[y][11]) == 0)
       //                 {
       //                     dr[11] = "NO";
       //                     dr[12] = "";
       //                 }
       //                 else
       //                 {
       //                     dr[11] = "YES";
       //                     dr[12] = dt.Rows[y][11].ToString();
       //                 }
       //                 if (Convert.ToInt32(dt.Rows[y][12]) == 0)
       //                     dr[13] = "NO";
       //                 else
       //                     dr[13] = "YES";
       //                 if (dt.Rows[y][13].ToString() == "")
       //                 {
       //                     dr[14] = "NO";
       //                     dr[15] = dt.Rows[y][13].ToString();
       //                 }
       //                 else
       //                 {
       //                     dr[14] = "YES";
       //                     dr[15] = dt.Rows[y][13].ToString();
       //                 }
       //                 dr[21] = dt.Rows[y][18].ToString();
       //                 dr[22] = dt.Rows[y][19].ToString();

       //                 if (Convert.ToInt32(dt.Rows[y]["atten_day"]) == 0)
       //                     dr[23] = "NO";
       //                 else
       //                     dr[23] = "YES";

       //                 if (Convert.ToInt32(dt.Rows[y]["Proxy_day"]) == 0)
       //                     dr[24] = "NO";
       //                 else
       //                     dr[24] = "YES";

       //                 if (Convert.ToInt32(dt.Rows[y]["Daily_wages"]) == 0)
       //                     dr[25] = "NO";
       //                 else
       //                     dr[25] = "YES";

       //                 if (Convert.ToInt32(dt.Rows[y]["EMP_BASIC"]) == 0)
       //                     dr[28] = "NO";
       //                 else
       //                     dr[28] = "YES";
       //                 //if (Convert.ToInt32(dt.Rows[y]["EMP_SAL"]) == 0)
       //                 //    dr[29] = "NO";
       //                 //else
       //                 //    dr[29] = "YES";

       //                 dt_ass.Rows.Add(dr);
       //                 if (!hsg_ass_head_sal_struc.ContainsKey(dt.Rows[y][0].ToString().Trim() + "/" + dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString()))
       //                     //time
       //                     /////////hsg_ass_head_sal_struc.Add(dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString(),dt.Rows[y]["SLNO"].ToString());
       //                     hsg_ass_head_sal_struc.Add(dt.Rows[y][0].ToString().Trim() + "/" + dt.Rows[y][1].ToString() + "/" + dt.Rows[y][2].ToString() + "/" + dt.Rows[y][3].ToString() + "/" + dt.Rows[y][4].ToString() + "/" + dt.Rows[y][5].ToString(), dt.Rows[y]["SLNO"].ToString());


       //             }
       //         }
       //         dr = dt_ass.NewRow();
       //         dt_ass.Rows.Add(dr);
       //         for (int z = 0; z < dt.Rows.Count; z++)
       //         {

       //             if (dt.Rows[z][0].ToString().Trim() == "D")
       //             {
       //                 dr = dt_ass.NewRow();
       //                 dr[0] = "Ded";
       //                 dr[1] = get_sal_head_name(Convert.ToInt32(dt.Rows[z][3]), "D");//dt.Rows[z][3].ToString();
       //                 dr[2] = sal_Head_Name('D', get_sal_head_name(Convert.ToInt32(dt.Rows[z][3]), "D"));
       //                 dr[3] = dt.Rows[z][4].ToString() + "/" + dt.Rows[z][1].ToString();
       //                 dr[4] = dt.Rows[z][5].ToString() + "/" + dt.Rows[z][1].ToString();
       //                 dr[5] = dt.Rows[z][6].ToString();
       //                 dr[6] = dt.Rows[z][7].ToString();
       //                 dr[7] = get_OtherName(dt.Rows[z][7].ToString(), Convert.ToInt32(dt.Rows[z][8]));//dt.Rows[z][8].ToString();
       //                 if (Convert.ToInt32(dt.Rows[z][9]) == 0)
       //                 {
       //                     dr[8] = "NO";
       //                     dr[9] = "";
       //                 }
       //                 else
       //                 {
       //                     dr[8] = "YES";
       //                     dr[9] = dt.Rows[z][9].ToString();
       //                 }
       //                 if (Convert.ToInt32(dt.Rows[z][10]) == 0)
       //                     dr[10] = "NO";
       //                 else
       //                     dr[10] = "YES";

       //                 if (Convert.ToInt32(dt.Rows[z][11]) == 0)
       //                 {
       //                     dr[11] = "NO";
       //                     dr[12] = "";
       //                 }
       //                 else
       //                 {
       //                     dr[11] = "YES";
       //                     dr[12] = dt.Rows[z][11].ToString();
       //                 }
       //                 if (Convert.ToInt32(dt.Rows[z][12]) == 0)
       //                     dr[13] = "NO";
       //                 else
       //                     dr[13] = "YES";
       //                 if (dt.Rows[z][13].ToString() == "")
       //                 {
       //                     dr[14] = "NO";
       //                     dr[15] = dt.Rows[z][13].ToString();
       //                 }
       //                 else
       //                 {
       //                     dr[14] = "YES";
       //                     dr[15] = dt.Rows[z][13].ToString();
       //                 }

       //                 dr[21] = dt.Rows[z][18].ToString();
       //                 dr[22] = dt.Rows[z][19].ToString();

       //                 if (Convert.ToInt32(dt.Rows[z]["atten_day"]) == 0)
       //                     dr[23] = "NO";
       //                 else
       //                     dr[23] = "YES";

       //                 if (Convert.ToInt32(dt.Rows[z]["Proxy_day"]) == 0)
       //                     dr[24] = "NO";
       //                 else
       //                     dr[24] = "YES";

       //                 if (Convert.ToInt32(dt.Rows[z]["Daily_wages"]) == 0)
       //                     dr[25] = "NO";
       //                 else
       //                     dr[25] = "YES";

       //                 if (Convert.ToInt32(dt.Rows[z]["Revenue_Stamp"]) == 0)
       //                     dr[26] = "NO";
       //                 else
       //                     dr[26] = "YES";

       //                 dr[27] = Convert.ToString(dt.Rows[z]["Stamp_Amount"]);

       //                 dt_ass.Rows.Add(dr);
       //                 if (!hsg_ass_head_sal_struc.ContainsKey(dt.Rows[z][0].ToString().Trim() + "/" + dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString()))
       //                     //time
       //                     /////////hsg_ass_head_sal_struc.Add(dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString(), dt.Rows[z]["SLNO"].ToString());
       //                     hsg_ass_head_sal_struc.Add(dt.Rows[z][0].ToString().Trim() + "/" + dt.Rows[z][1].ToString() + "/" + dt.Rows[z][2].ToString() + "/" + dt.Rows[z][3].ToString() + "/" + dt.Rows[z][4].ToString() + "/" + dt.Rows[z][5].ToString(), dt.Rows[z]["SLNO"].ToString());



       //             }

       //         }
       //     }
       // }
       // public void get_SalStructID()
       // {
       //     Cmbstructureid.Items.Clear();
       //     CmbStructure.Items.Clear();
       //     DataTable dt = new DataTable();

       //     string s = "select distinct c.SlNo,c.salarycategory from tbl_Employee_SalaryStructure c,tbl_Employee_Assign_SalStructure s where s.session='" + CmbSession.Text + "'and s.company_id=" + Convert.ToInt32(CmbCompany_id.SelectedItem) + "and s.Location_id=" + Convert.ToInt32(CmbLocation_id1.SelectedItem);
       //     dt = clsDataAccess.RunQDTbl(s);
       //     for(int i=0;i<dt.Rows.Count;i++)
       //     {
       //         CmbStructure.Items.Add(dt.Rows[i]["salarycategory"].ToString());
       //         Cmbstructureid.Items.Add(dt.Rows[i]["slno"].ToString());
       //     }
       // }

       // private void button1_Click(object sender, EventArgs e)
       // {
       //     get_ass();
       //     MidasReport.Form1 strucrpt = new MidasReport.Form1();
       //     strucrpt.SalStructure(CmbCompany1.Text,CmbLocation1.Text,CmbSession.Text, dt_ass);
       //     strucrpt.Show();
           
       // }

       // private void CmbStructure_SelectedIndexChanged(object sender, EventArgs e)
       // {
       //     Cmbstructureid.SelectedIndex = CmbStructure.SelectedIndex;
       // }

       // private void CmbStrucyureid_selectedIndexChanged(object sender, EventArgs e)
       // {

       // }

       // private void CmbSession_SelectedIndexChanged(object sender, EventArgs e)
       // {
       //     compname();
       // }

       // private void CmbLocation_selectedindexchange(object sender, EventArgs e)
       // {
       //     CmbLocation_id1.SelectedIndex = CmbLocation1.SelectedIndex;
       //     //get_SalStructID();
       // }
        Edpcom.EDPConnection edpcon = new Edpcom.EDPConnection();
        Edpcom.EDPCommon edpcom = new EDPCommon();
        int Company_id = 0, Location_id = 0;
        string sub;
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbcompany_DropDown(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            if (edpcom.CurrentLocation.Trim() != "")
            {

                dt = clsDataAccess.RunQDTbl("select distinct (SELECT CO_NAME FROM Company where co_code=cr.Company_ID)CO_NAME,Company_ID as CO_CODE from Companywiseid_Relation cr where Location_ID in (" + edpcom.CurrentLocation + ") ");
            }
            else
            {
                dt = clsDataAccess.RunQDTbl("Select CO_NAME,CO_CODE from Company");
            }


            if (dt.Rows.Count > 0)
            {
                cmbcompany.LookUpTable = dt;
                cmbcompany.ReturnIndex = 1;
                // cmbLocation.Text = "";
            }
        }

        private void cmbcompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbcompany.ReturnValue) == true)
                Company_id = Convert.ToInt32(cmbcompany.ReturnValue);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DataTable attdt = new DataTable();
            DataTable dtLid = clsDataAccess.RunQDTbl("SELECT Distinct Location_ID,(Select Location_Name from tbl_Emp_Location where Location_ID=ea.Location_ID)as Site FROM tbl_Employee_SalaryMast AS ea WHERE (Company_id=" + Company_id + ") AND (Session='" + this.CmbSession.Text + "') and (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') Order BY Location_id");
           
            //DataTable rw_head = clsDataAccess.RunQDTbl("SELECT 'Code' as code, 'Name'as Name,'WDay'as wd,'OT' as OT,'TotalDays' as TotalDays,'Rate'as rate,'Basic'as basic,'Gross' as gross,'Tot. Dedn.'as tdedn,'Other\r\n Dedn.' as odedn,'PF' as pf,'ESI' as esi,'Loan' as loan,'Adv' as adv,'KIT' as kit,'Net\r\n Payable' as net,'Remarks' as remark");
            //DataTable rw_blnk = clsDataAccess.RunQDTbl("SELECT ' ' as Code, ' ' as Name,' ' AS wd,' 'as rate,' ' as gross,' 'as tdedn,' ' as odedn,' ' as pf,' ' as esi,' ' as loan,' ' as adv,' ' as kit,' ' as net");
            string qry = "",qry_tot="";
            if (rdbCompany.Checked==true)
            {
                qry = "SELECT (SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = sm.Emp_Id)) AS Name,sm.Emp_Id as code, cast(SUM(sm.Basic)as numeric(18,2)) as basic, cast(SUM(sm.TotalDays)as varchar) as wd ,cast(SUM(sm.OT)as varchar) as OT ,cast(SUM(sm.TotalDays) as varchar) as TotalDays, cast(SUM(sm.Basic)/" + Convert.ToDouble(lblDOM.Text) + " as numeric(18,2)) as rate, cast(SUM(sm.TotalSal)as numeric(18,2)) as gross, cast(SUM(TotalDec)as numeric(18,2)) as tdedn," +
               "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'PF'))) GROUP BY EmpId, Month, Company_id)as numeric(18,2)) as pf," +
               "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'ESI'))) GROUP BY EmpId, Month, Company_id)as numeric(18,2)) as esi," +
               "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Loan'))) GROUP BY EmpId, Month, Company_id)as varchar) as loan," +
               "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Adv'))) GROUP BY EmpId, Month, Company_id)as varchar) as adv," +
               "cast((SELECT SUM(Amount) AS pf FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Kit') or (SalaryHead_Short = 'unf'))) GROUP BY EmpId, Month, Company_id)as varchar) as kit," +
               " cast(SUM(sm.NetPay)as numeric(18,2)) as net FROM tbl_Employee_SalaryMast sm where sm.Session='" + this.CmbSession.Text + "' and (sm.Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') and (sm.Company_id='" + Company_id + "') GROUP BY sm.Emp_Id, sm.Company_id, sm.Month ORDER BY sm.Emp_Id";
                DataTable tot_employ = clsDataAccess.RunQDTbl(qry);
                //object sumObject;
                //sumObject = tot_employ.Compute("Sum(Cast(net) as double)","");
                //attdt.Merge(rw_site);
               // attdt.Merge(rw_blnk);
                //attdt.Merge(rw_head);
                attdt.Merge(tot_employ);
                qry = "SELECT 'Total' AS Name,'' as code, cast(SUM(sm.Basic)as numeric(18,2)) as basic, cast(SUM(sm.TotalDays)as varchar) as wd , cast(SUM(sm.Basic)/" + Convert.ToDouble(lblDOM.Text) + " as numeric(18,2)) as rate,cast(SUM(sm.OT)as varchar) as OT ,cast(SUM(sm.TotalDays) as varchar) as TotalDays, cast(SUM(sm.TotalSal)as numeric(18,2)) as gross, cast(SUM(TotalDec)as numeric(18,2)) as tdedn," +
                "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'PF'))) GROUP BY Month, Company_id)as numeric(18,2)) as pf," +
                "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'ESI'))) GROUP BY Month, Company_id)as numeric(18,2)) as esi," +
                "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Loan'))) GROUP BY Month, Company_id)as varchar) as loan," +
                "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Adv'))) GROUP BY Month, Company_id)as varchar) as adv," +
                "cast((SELECT SUM(Amount) AS pf FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Kit') or (SalaryHead_Short = 'unf'))) GROUP BY Month, Company_id)as varchar) as kit," +
                " cast(SUM(sm.NetPay)as numeric(18,2)) as net FROM tbl_Employee_SalaryMast sm where sm.Session='" + this.CmbSession.Text + "' and (sm.Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') and (sm.Company_id='" + Company_id + "') GROUP BY sm.Company_id, sm.Month";
                DataTable rw_total = clsDataAccess.RunQDTbl(qry);
                //attdt.Merge(rw_blnk);
                attdt.Merge(rw_total);
                //                    attdt.Merge(rw_total);
                sub = "Company Wise Attendance And Salary Summary For The Month Of - " + dateTimePicker1.Value.ToString("MMMM,yyyy");
            }
            else if (rdbLocation.Checked == true)
            {


                for (int i = 0; i < dtLid.Rows.Count; i++)
                {
                    string id = dtLid.Rows[i]["Location_ID"].ToString();
                    string name = dtLid.Rows[i]["Site"].ToString();
                    DataTable rw_Site = clsDataAccess.RunQDTbl("SELECT 'Site :' as Code, '" + name + "' as Name");
                    //' ' AS wd,' 'as rate,' 'as basic,' ' as gross,' ' as OT,' ' as TotalDays,' 'as tdedn,' ' as pf,' ' as esi,' ' as loan,' ' as adv,' ' as kit,' ' as net");
                    qry = "SELECT (SELECT FirstName + ' ' + MiddleName + ' ' + LastName FROM tbl_Employee_Mast WHERE (ID = sm.Emp_Id)) AS Name,sm.Emp_Id as code, cast(SUM(sm.Basic)as numeric(18,2)) as basic, cast(SUM(sm.OT)as varchar) as OT ,cast(SUM(sm.TotalDays) as varchar) as TotalDays,cast(SUM(sm.TotalDays)as varchar) as wd , cast(SUM(sm.Basic)/" + Convert.ToDouble(lblDOM.Text) + "as numeric(18,2)) as rate, cast(SUM(sm.TotalSal)as varchar) as gross, cast(SUM(TotalDec)as varchar) as tdedn," +
                     "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'PF'))) GROUP BY EmpId, Month, Company_id)as varchar) as pf," +
                     "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'ESI'))) GROUP BY EmpId, Month, Company_id)as varchar) as esi," +
                     "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Loan'))) GROUP BY EmpId, Month, Company_id)as varchar) as loan," +
                     "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Adv'))) GROUP BY EmpId, Month, Company_id)as varchar) as adv," +
                     "cast((SELECT SUM(Amount) AS pf FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (EmpId=sm.Emp_Id) AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Kit') or (SalaryHead_Short = 'unf'))) GROUP BY EmpId, Month, Company_id)as varchar) as kit," +
                     " cast(SUM(sm.NetPay)as varchar) as net FROM tbl_Employee_SalaryMast sm where sm.Session='" + this.CmbSession.Text + "' and (sm.Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') and (sm.Company_id='" + Company_id + "') and (sm.Location_ID='" + id + "') GROUP BY sm.Emp_Id, sm.Company_id,sm.Location_ID, sm.Month, sm.TotalDays, sm.OT ORDER BY sm.Emp_Id";
                    DataTable tot_employ = clsDataAccess.RunQDTbl(qry);
                    //object sumObject;
                    //sumObject = tot_employ.Compute("Sum(Cast(net) as double)","");
                    //attdt.Merge(rw_site);
                    //attdt.Merge(rw_blnk);
                    attdt.Merge(rw_Site);
                    //attdt.Merge(rw_head);
                    attdt.Merge(tot_employ);
                    qry = "SELECT 'Total' AS Name,' ' as code, cast(SUM(sm.Basic)as numeric(18,2)) as basic, cast(SUM(sm.TotalDays)as varchar) as wd , cast(SUM(sm.Basic)/" + Convert.ToDouble(lblDOM.Text) + "as numeric(18,2)) as rate,cast(SUM(sm.OT)as varchar) as OT ,cast(SUM(sm.TotalDays) as varchar) as TotalDays, cast(SUM(sm.TotalSal)as varchar) as gross, cast(SUM(TotalDec)as varchar) as tdedn," +
                    "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'PF'))) GROUP BY Month, Company_id)as varchar) as pf," +
                    "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'ESI'))) GROUP BY Month, Company_id)as varchar) as esi," +
                    "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Loan'))) GROUP BY Month, Company_id)as varchar) as loan," +
                    "cast((SELECT SUM(Amount) FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Adv'))) GROUP BY Month, Company_id)as varchar) as adv," +
                    "cast((SELECT SUM(Amount) AS pf FROM tbl_Employee_SalaryDet AS SD WHERE (TableName = 'tbl_Employee_DeductionSalayHead') AND (Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') AND (Session ='" + this.CmbSession.Text + "') AND (Company_id ='" + Company_id + "') AND (SalId =(SELECT SlNo FROM tbl_Employee_DeductionSalayHead WHERE (SalaryHead_Short = 'Kit') or (SalaryHead_Short = 'unf'))) GROUP BY Month, Company_id)as varchar) as kit," +
                    " cast(SUM(sm.NetPay)as varchar) as net FROM tbl_Employee_SalaryMast sm where sm.Session='" + this.CmbSession.Text + "' and (sm.Month ='" + this.dateTimePicker1.Value.ToString("MMMM") + "') and (sm.Company_id='" + Company_id + "')and (sm.Location_ID='" + id + "') GROUP BY sm.Company_id, sm.Month";
                    DataTable rw_total = clsDataAccess.RunQDTbl(qry);
                    //attdt.Merge(rw_blnk);
                    attdt.Merge(rw_total);
                    //attdt.Merge(rw_blnk);
                    sub = "Location Wise Attendance And Salary Summary For The Month Of - " + dateTimePicker1.Value.ToString("MMMM,yyyy");
                }
            }


            //MidasReport.Form1 att = new MidasReport.Form1();
            //string com = cmbcompany.Text;
            String CO_ADD = clsDataAccess.GetresultS("SELECT CO_ADD + ' ' + CO_ADD1 FROM Company WHERE CO_CODE = '" + Company_id + "'");
            //sub = "Company Wise Attendance And Salary Summary For The Month Of - " + dateTimePicker1.Value.ToString("MMMM,YYYY");
            //att.Salcomp(com, CO_ADD, sub, attdt);
            ////att.atten_rpt(this.cmbcompany.Text, "", this.dateTimePicker1.Value.ToString("MMMM"), "", this.dateTimePicker1.Value.Year, attdt);
            //edpcon.Close();
            //att.Show();




            MidasReport.Form1 att = new MidasReport.Form1();
            //sub = "Company Wise Attendance And Salary Summary For The Month Of - " + dateTimePicker1.Value.ToString("MMMM,yyyy");
            att.Salcomp(cmbcompany.Text, CO_ADD, sub, attdt);
            //att.atten_rpt(this.cmbcompany.Text, "", this.dateTimePicker1.Value.ToString("MMMM"), "", this.dateTimePicker1.Value.Year, attdt);
            edpcon.Close();
            att.Show();
        }

        private void Assignheadsalstru_Load(object sender, EventArgs e)
        {
            clsValidation.GenerateYear(CmbSession, 2015, System.DateTime.Now.Year, 1);
            dateTimePicker1.Value = DateAndTime.Now;
            this.lblDOM.Text = Convert.ToString(clsEmployee.GetTotalDaysByMonth(dateTimePicker1.Value.ToString("MMMM"), dateTimePicker1.Value.Year));

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value.Month >= 4)
                {
                    try
                    { CmbSession.SelectedItem = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.AddYears(1).Year; }
                    catch { }
                    // cmbYear.SelectedIndex = 0;
                }
                else
                {
                    CmbSession.SelectedItem = dateTimePicker1.Value.AddYears(-1).Year + "-" + dateTimePicker1.Value.Year;
                    // cmbYear.SelectedIndex = 1;
                }
            }
            catch
            { }
            this.lblDOM.Text = Convert.ToString(clsEmployee.GetTotalDaysByMonth(dateTimePicker1.Value.ToString("MMMM"), dateTimePicker1.Value.Year));

            //if (dateTimePicker1.Value.Month >= 4)
            //{
            //    cmbYear.SelectedIndex = 0;
            //}
            //else
            //{
            //    cmbYear.SelectedIndex = 1;
            //}
        }
    }
}
