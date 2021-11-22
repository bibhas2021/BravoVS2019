using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Microsoft.VisualBasic;

namespace PayRollManagementSystem
{
    public partial class frmEmployeeSalAssignNewUI : Form
    {
        int Location_ID = 0;
        int salary_ID = 0;
        int company_ID = 0;
        Hashtable SalHead = new Hashtable();
        Hashtable SalHead1 = new Hashtable();
        Hashtable chk_fmula = new Hashtable();
        Hashtable chk_op = new Hashtable();
        Hashtable htCALDET = new Hashtable();
        bool ok = false;
        ArrayList alSelectedSalaryHead = new ArrayList();


        //INITIALIZE ALL COLUMNS IN DT IN CASE FIRST TIME ENTRY
        DataTable dtSalaryStructureTickDetails = new DataTable();

        public frmEmployeeSalAssignNewUI()
        {
            InitializeComponent();
        }

        private void frmEmployeeSalAssignNewUI_Load(object sender, EventArgs e)
        {
            //this.HeaderText = "Salary Structure Assign";
            dtSalaryStructureTickDetails = clsDataAccess.RunQDTbl("SELECT '' as [P_TYPE],'' as [SESSION],0 as [SAL_HEAD],'' as [V_FROM],'' as [V_TO],0 as [PF_PER],0 as [PF_VOL],0 as [ESI_PER],0 as [PT],'' as [ROUND_TYPE],0 as [TDSREFNO],0 as [TDS_EXEMPT],0 as [CARRY],0 as [TDS_EXTRAPOL],'' as [REMARKS],0 as [atten_day],0 as [Proxy_day],0 as [Daily_wages],0 as [Revenue_Stamp],'' as [Stamp_Amount],0 as [EMP_BASIC],0 as [chkALK],0 as [chkHide],'True' as 'FetchedFromDatabase','True' as 'Checked' FROM [tbl_Employee_Assign_SalStructure] where SAL_STRUCT = -1");
            GetSalaryHeads();
            SetDGV();
        }

        private void cmbCompany_DropDown(object sender, EventArgs e)
        {
            DataTable dt = clsDataAccess.RunQDTbl("select [CO_NAME],[CO_CODE] from [Company]");
            if (dt.Rows.Count > 0)
            {
                cmbCompany.LookUpTable = dt;
                cmbCompany.ReturnIndex = 1;
            }
        }

        private void cmbCompany_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbCompany.ReturnValue))
            {
                company_ID = Convert.ToInt32(cmbCompany.ReturnValue);
            }
        }

        private void cmbLocation_DropDown(object sender, EventArgs e)
        {
            if (company_ID != 0)
            {
                DataTable dtLocationFetch = clsDataAccess.RunQDTbl("select Location_Name,Location_ID from tbl_Emp_Location");
                if (dtLocationFetch.Rows.Count > 0)
                {
                    cmbLocation.LookUpTable = dtLocationFetch;
                    cmbLocation.ReturnIndex = 1;
                }
            }
            else
                EDPMessageBox.EDPMessage.Show("Please select company first");
        }

        private void cmbLocation_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(cmbLocation.ReturnValue))
            {
                Location_ID = Convert.ToInt32(cmbLocation.ReturnValue);
                DataTable dtCheckSalStructureExistsForLocation = clsDataAccess.RunQDTbl("select (select ss.SalaryCategory from tbl_Employee_SalaryStructure ss where ss.[SlNo] = lss.SalaryStructure_ID) as SalStruct,lss.SalaryStructure_ID from tbl_Employee_Link_SalaryStructure lss where lss.Location_ID = " + Location_ID);
                if (dtCheckSalStructureExistsForLocation.Rows.Count > 0)
                {
                    CmbSalStructure.Text = dtCheckSalStructureExistsForLocation.Rows[0]["SalStruct"].ToString();
                    salary_ID = Convert.ToInt32(dtCheckSalStructureExistsForLocation.Rows[0]["SalaryStructure_ID"].ToString());
                    GetSalaryStructureDetails(salary_ID);
                }
            }
        }

        private void CmbSalStructure_DropDown(object sender, EventArgs e)
        {
            DataTable dtSalaryStructureFetch = clsDataAccess.RunQDTbl("select SalaryCategory,SlNo from tbl_Employee_SalaryStructure");
            if (dtSalaryStructureFetch.Rows.Count > 0)
            {
                CmbSalStructure.LookUpTable = dtSalaryStructureFetch;
                CmbSalStructure.ReturnIndex = 1;
            }
        }

        private void CmbSalStructure_CloseUp(object sender, EDPComponent.ComboDialog.CloseUpEventArgs e)
        {
            if (Information.IsNumeric(CmbSalStructure.ReturnValue))
            {
                salary_ID = Convert.ToInt32(CmbSalStructure.ReturnValue);
                GetSalaryStructureDetails(salary_ID);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean boolStatus = false;
            if (salary_ID == 0&&CmbSalStructure.Text.Trim()!="")
            {
                /*
                 * 1. At first insert salary structure.
                 * 1.1  Only Salary structure.[DONE]
                 * 1.2. Salary structure with location link.[NOTE: In this case possible scenarios are][DONE BOTH]
                 * 1.2.1. Salary structure assigned to new location.
                 * 1.2.2. Salary structure has already been assigned to the location now updating that salary structure id.
                 * 1.3. Salary structure with it's details.[]
                 */

                /*===================If the salary structure is new then at first we have to insert it into tbl_Employee_SalaryStructure===================*/
                string strCategory = CmbSalStructure.Text; 
                DataTable dt = clsDataAccess.RunQDTbl("Select SlNo,SalaryCategory from tbl_Employee_SalaryStructure where SalaryCategory='" + strCategory + "'");
                if (dt.Rows.Count == 0)
                    boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_SalaryStructure(SalaryCategory) values('" + strCategory + "')");
                else
                {
                    ERPMessageBox.ERPMessage.Show("Salary Structure Name " + strCategory + " Already Exists");
                    return;
                }
                /*======================================================End of Salary Structure insertion==================================================*/

                if (boolStatus)
                {
                    int Structure_ID = 0;
                    DataTable dtGetSalaryStructureID = clsDataAccess.RunQDTbl("Select SlNo from tbl_Employee_SalaryStructure where SalaryCategory='" + strCategory + "'");
                    if (dtGetSalaryStructureID.Rows.Count > 0)
                    {
                        Structure_ID = Convert.ToInt32(dtGetSalaryStructureID.Rows[0][0]);
                    }
                    if (Location_ID != 0)
                    {
                        DataTable dtAlreadySalStructDefined = clsDataAccess.RunQDTbl("select [Link_ID],[Location_ID],[SalaryStructure_ID] from tbl_Employee_Link_SalaryStructure where Location_ID = " + Location_ID);
                        if (dtAlreadySalStructDefined.Rows.Count > 0)
                        {
                            if (dtAlreadySalStructDefined.Rows[0]["SalaryStructure_ID"].ToString().Trim() != salary_ID.ToString())
                            {
                                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Link_SalaryStructure set SalaryStructure_ID = " + salary_ID + " where Link_ID = " + dtAlreadySalStructDefined.Rows[0]["Link_ID"].ToString().Trim() + "");
                            }
                            else
                            {
                                //Havent got logic for this part... :(
                            }

                        }
                        else
                        {
                            int Max_ID = 0;
                            DataTable dtGetMaxLinkID = clsDataAccess.RunQDTbl("SELECT Max(Link_ID) FROM tbl_Employee_Link_SalaryStructure");
                            if (Convert.ToString(dtGetMaxLinkID.Rows[0][0]).Length > 0)
                            {
                                Max_ID = Convert.ToInt32(dtGetMaxLinkID.Rows[0][0]) + 1;
                            }
                            else
                            {
                                Max_ID = 1;
                            }
                            boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Link_SalaryStructure(Link_ID,Location_ID,SalaryStructure_ID) values('" + Max_ID + "','" + Location_ID + "','" + Structure_ID + "')");
                        }
                    }

                    alSelectedSalaryHead.Clear();
                    for (int i = 1; i < dgvAssignHeads.Columns.Count; i++)
                    {
                        if (Convert.ToInt32(dgvAssignHeads.Rows[0].Cells[i].Value) == 1)
                        {
                            //This is the list in which all selected salary head's id will be saved
                            alSelectedSalaryHead.Add(dgvAssignHeads.Columns[i].Name);
                        }
                    }

                    if (dgvAssignHeads.Rows.Count <= 2)
                    {
                        //IN THIS CASE JUST SALARY HEADS IN alAssignHeads WILL BE ADDED INTO THE DATABASE
                        //AND ALSO A FALG WILL BE ADDED IN DATABASE IF THAT SALARY STRUCTURE CAN BE CALCULATED OR NOT
                        for (int i = 0; i < alSelectedSalaryHead.Count; i++)
                        {
                            string P_TYPE = alSelectedSalaryHead[i].ToString().Substring(0, 1);
                            string SAL_HEAD = alSelectedSalaryHead[i].ToString().Substring(1);
                            //HERE I HAVE TO LINK THE MAIN TABLE WITH DETAILS TABLE.
                            string strInsert = "insert into [tbl_Employee_Assign_SalStructure] ([P_TYPE],[SESSION],[SAL_STRUCT],[SAL_HEAD],[V_FROM],[V_TO],[Location_id],[Company_id],[PF_PER],[PF_VOL],[ESI_PER],[PT],[ROUND_TYPE],[TDSREFNO],[TDS_EXEMPT],[CARRY],[TDS_EXTRAPOL],[REMARKS],[atten_day],[Proxy_day],[Daily_wages],[Revenue_Stamp],[Stamp_Amount],[EMP_BASIC],[chkALK],[chkHide]) values ('" + P_TYPE + "','" + CurrentSession() + "'," + Structure_ID + "," + SAL_HEAD + ",'April','March','" + Location_ID + "','" + company_ID + "',0,0,0,0,'',0,0,0,0,'',0,0,0,0,'',0,0,0)";
                            boolStatus = clsDataAccess.RunNQwithStatus(strInsert);
                            string strUpdateQry = "update tbl_Employee_SalaryStructure set [status] = 0 where [SlNo] = " + Structure_ID;
                            boolStatus = clsDataAccess.RunNQwithStatus(strUpdateQry);
                        }
                    }
                    else
                    {
                        Boolean boolUsableStructureOrNot = true;
                        for (int i = 0; i < alSelectedSalaryHead.Count; i++)
                        {
                            Boolean boolFormula = false;
                            Boolean boolLumpsum = false;
                            string P_TYPE = alSelectedSalaryHead[i].ToString().Substring(0, 1);
                            string SAL_HEAD = alSelectedSalaryHead[i].ToString().Substring(1);
                            string C_TYPE = "";
                            string C_DET = "";

                            /*LUMPSUM INSERT DETAILS*/
                            int lid = 0;
                            string s = "Select max(LUMPID) from tbl_Employee_Lumpsum";
                            DataTable max_No = clsDataAccess.RunQDTbl(s);
                            if (Information.IsNumeric(max_No.Rows[0][0]) == true)
                                lid = Convert.ToInt32(max_No.Rows[0][0]) + 1;
                            else
                                lid = 1;

                            string txtlumname = CmbSalStructure.Text + "_lumpsum_" + dgvAssignHeads.Columns[alSelectedSalaryHead[i].ToString()].HeaderText;
                            /*END OF LUMPSUM DETAILS*/


                            for (int j = 1; j < dgvAssignHeads.Rows.Count - 1; j++)
                            { 
                                DataGridViewComboBoxCell cell1 = new DataGridViewComboBoxCell();
                                cell1 = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[j].Cells[0];
                                string strSalHeadCellValue = "";
                                try
                                {
                                    strSalHeadCellValue = dgvAssignHeads.Rows[j].Cells[alSelectedSalaryHead[i].ToString()].Value.ToString();
                                }
                                catch
                                {
                                    strSalHeadCellValue = "";
                                }
                                
                                if (Information.IsNumeric(strSalHeadCellValue))
                                {
                                    boolLumpsum = true;
                                    s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,AMOUNT,Pf_Amt,GRADE) values(" + lid + ", '" + txtlumname + "', 0, " + Convert.ToDouble(strSalHeadCellValue) + ",'0.00','"+cell1.Value.ToString().Trim()+"')";
                                    boolStatus = clsDataAccess.RunNQwithStatus(s);
                                }
                                else if (!Information.IsNumeric(strSalHeadCellValue)&&strSalHeadCellValue.Trim()!="")
                                {
                                    //This is for formula
                                    SaveFormula(CmbSalStructure.Text + "_formula_" + dgvAssignHeads.Columns[alSelectedSalaryHead[i].ToString()].HeaderText, strSalHeadCellValue);
                                    boolFormula = true;
                                    break;
                                }
                                
                                
                            }

                            if (boolLumpsum)
                            {
                                C_TYPE = "COMPANY LUMPSUM";
                                C_DET = lid.ToString();
                            }
                            else if (boolFormula)
                            {
                                C_TYPE = "FORMULA";
                                C_DET = clsDataAccess.GetresultS("Select max(FID) from tbl_Employee_Sal_Structure_Formula");
                            }

                            //HERE I HAVE TO LINK THE MAIN TABLE WITH DETAILS TABLE.
                            if (boolFormula || boolLumpsum)
                            {
                                string strValuesFromTickDetails = "";
                                for (int k = 0; k < dtSalaryStructureTickDetails.Rows.Count; k++)
                                {
                                    if (dtSalaryStructureTickDetails.Rows[k]["P_TYPE"].ToString() == P_TYPE && dtSalaryStructureTickDetails.Rows[k]["SAL_HEAD"].ToString() == SAL_HEAD)
                                    {
                                        for (int l = 0; l < dtSalaryStructureTickDetails.Columns.Count; l++)
                                        {
                                            if (dtSalaryStructureTickDetails.Columns[l].ColumnName == "P_TYPE" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "SAL_HEAD" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "FetchedFromDatabase" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "Checked")
                                                continue;
                                            else if (dtSalaryStructureTickDetails.Columns[l].ColumnName == "SESSION" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "ROUND_TYPE" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "REMARKS" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "Stamp_Amount" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "V_FROM" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "V_TO")
                                                strValuesFromTickDetails = strValuesFromTickDetails + ",'" + dtSalaryStructureTickDetails.Rows[k][l] + "'";
                                            else
                                                strValuesFromTickDetails = strValuesFromTickDetails + "," + dtSalaryStructureTickDetails.Rows[k][l];
                                        }
                                    }
                                }
                                string strInsert = "insert into [tbl_Employee_Assign_SalStructure] ([P_TYPE],[SAL_STRUCT],[SAL_HEAD],[Location_id],[Company_id],[C_BASIS],[C_TYPE],[C_DET],[SESSION],[V_FROM],[V_TO],[PF_PER],[PF_VOL],[ESI_PER],[PT],[ROUND_TYPE],[TDSREFNO],[TDS_EXEMPT],[CARRY],[TDS_EXTRAPOL],[REMARKS],[atten_day],[Proxy_day],[Daily_wages],[Revenue_Stamp],[Stamp_Amount],[EMP_BASIC],[chkALK],[chkHide]) values ('" + P_TYPE + "'," + Structure_ID + "," + SAL_HEAD + ",'" + Location_ID + "','" + company_ID + "','Independent','" + C_TYPE + "'," + C_DET + strValuesFromTickDetails + ")";
                                boolStatus = clsDataAccess.RunNQwithStatus(strInsert);
                            }
                            else
                            {
                                string strValuesFromTickDetails = "";
                                for (int k = 0; k < dtSalaryStructureTickDetails.Rows.Count; k++)
                                {
                                    if (dtSalaryStructureTickDetails.Rows[k]["P_TYPE"].ToString() == P_TYPE && dtSalaryStructureTickDetails.Rows[k]["SAL_HEAD"].ToString() == SAL_HEAD)
                                    {
                                        for (int l = 0; l < dtSalaryStructureTickDetails.Columns.Count; l++)
                                        {
                                            if (dtSalaryStructureTickDetails.Columns[l].ColumnName == "P_TYPE" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "SAL_HEAD" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "FetchedFromDatabase" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "Checked")
                                                continue;
                                            else if (dtSalaryStructureTickDetails.Columns[l].ColumnName == "SESSION" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "ROUND_TYPE" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "REMARKS" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "Stamp_Amount" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "V_FROM" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "V_TO")
                                                strValuesFromTickDetails = strValuesFromTickDetails + ",'" + dtSalaryStructureTickDetails.Rows[k][l] + "'";
                                            else
                                                strValuesFromTickDetails = strValuesFromTickDetails + "," + dtSalaryStructureTickDetails.Rows[k][l];
                                        }
                                    }
                                }
                                string strInsert = "insert into [tbl_Employee_Assign_SalStructure] ([P_TYPE],[SAL_STRUCT],[SAL_HEAD],[Location_id],[Company_id],[SESSION],[V_FROM],[V_TO],[PF_PER],[PF_VOL],[ESI_PER],[PT],[ROUND_TYPE],[TDSREFNO],[TDS_EXEMPT],[CARRY],[TDS_EXTRAPOL],[REMARKS],[atten_day],[Proxy_day],[Daily_wages],[Revenue_Stamp],[Stamp_Amount],[EMP_BASIC],[chkALK],[chkHide]) values ('" + P_TYPE + "'," + Structure_ID + "," + SAL_HEAD + ",'" + Location_ID + "','" + company_ID + "'," + strValuesFromTickDetails + ")";
                                boolStatus = clsDataAccess.RunNQwithStatus(strInsert);
                            }
                            if (!boolFormula && !boolLumpsum)
                                boolUsableStructureOrNot = false;
                        }

                        //here status will be added
                        if (!boolUsableStructureOrNot)
                        {
                            string strUpdateQry = "update tbl_Employee_SalaryStructure set [status] = 0 where [SlNo] = " + Structure_ID;
                            boolStatus = clsDataAccess.RunNQwithStatus(strUpdateQry);
                        }

                    }
                }

            }
            else if (salary_ID != 0)
            { 
                /*In this case the cases can happens are 
                 * 1. Salary structure assigned to the location.
                 * 1. Location has been updated w.r.t. salary structure.
                 * 2. Salary structure details has been updated.
                 * 3. Both happens.
                 */

                if (Location_ID != 0)
                {
                    DataTable dtAlreadySalStructDefined = clsDataAccess.RunQDTbl("select [Link_ID],[Location_ID],[SalaryStructure_ID] from tbl_Employee_Link_SalaryStructure where Location_ID = " + Location_ID);
                    if (dtAlreadySalStructDefined.Rows.Count > 0)
                    {
                        if (dtAlreadySalStructDefined.Rows[0]["SalaryStructure_ID"].ToString().Trim() != salary_ID.ToString())
                        {
                            boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Link_SalaryStructure set SalaryStructure_ID = " + salary_ID + " where Link_ID = " + dtAlreadySalStructDefined.Rows[0]["Link_ID"].ToString().Trim() + "");
                        }
                        else
                        {
                            //Havent got logic for this part... :(
                        }

                    }
                    else
                    {
                        int Max_ID = 0;
                        DataTable dtGetMaxLinkID = clsDataAccess.RunQDTbl("SELECT Max(Link_ID) FROM tbl_Employee_Link_SalaryStructure");
                        if (Convert.ToString(dtGetMaxLinkID.Rows[0][0]).Length > 0)
                        {
                            Max_ID = Convert.ToInt32(dtGetMaxLinkID.Rows[0][0]) + 1;
                        }
                        else
                        {
                            Max_ID = 1;
                        }
                        boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Link_SalaryStructure(Link_ID,Location_ID,SalaryStructure_ID) values('" + Max_ID + "','" + Location_ID + "','" + salary_ID + "')");
                    }
                }

                alSelectedSalaryHead.Clear();
                for (int i = 1; i < dgvAssignHeads.Columns.Count; i++)
                {
                    if (Convert.ToInt32(dgvAssignHeads.Rows[0].Cells[i].Value) == 1)
                    {
                        //This is the list in which all selected salary head's id will be saved
                        alSelectedSalaryHead.Add(dgvAssignHeads.Columns[i].Name);
                    }
                }

                if (dgvAssignHeads.Rows.Count <= 2)
                {
                    //IN THIS CASE JUST SALARY HEADS IN alAssignHeads WILL BE ADDED INTO THE DATABASE
                    //AND ALSO A FALG WILL BE ADDED IN DATABASE IF THAT SALARY STRUCTURE CAN BE CALCULATED OR NOT

                }
                else
                {
                    Boolean boolUsableStructureOrNot = true;
                    for (int i = 0; i < alSelectedSalaryHead.Count; i++)
                    {
                        Boolean boolFormula = false;
                        Boolean boolLumpsum = false;
                        Boolean boolLumpsumExists = false;
                        Boolean boolFormulaExists = false;
                        string P_TYPE = alSelectedSalaryHead[i].ToString().Substring(0, 1);
                        string SAL_HEAD = alSelectedSalaryHead[i].ToString().Substring(1);
                        string C_TYPE = "";
                        string C_DET = "";

                        /*LUMPSUM INSERT DETAILS*/
                        int intExistingFormulaId = 0;
                        int intExistingLid = 0;
                        int lid = 0;
                        string strFormulaNameFromExistingStructure = "";
                        string strExistingLumpsumName = "";
                        foreach (string key in htCALDET.Keys)
                        {
                            if (key == alSelectedSalaryHead[i].ToString().Trim())
                            {
                                if (htCALDET[key].ToString().Substring(0, 1) == "L")
                                {
                                    //LUMPSUM WILL BE UPDATED ON BASIS OF LUMPSUMID
                                    intExistingLid = Convert.ToInt32(htCALDET[key].ToString().Substring(1));
                                    strExistingLumpsumName = clsDataAccess.GetresultS("select distinct LUMPNAME from tbl_Employee_Lumpsum where LUMPID = " + intExistingLid);
                                    boolLumpsumExists = true;
                                }
                                else if (htCALDET[key].ToString().Substring(0, 1) == "F")
                                {
                                    //FORMULA WILL BE UPDATED ON BASIS OF FORMULA NAME... SO HAVE TO FETCH THE FORMULA NAME FROM IT'S ID
                                    string fid = htCALDET[key].ToString().Substring(1);
                                    intExistingFormulaId = Convert.ToInt32(fid);
                                    strFormulaNameFromExistingStructure = clsDataAccess.GetresultS("select FName from tbl_Employee_Sal_Structure_Formula where FID = " + fid);
                                    boolFormulaExists = true;
                                }
                                break;
                            }
                        }
                        string s = "Select max(LUMPID) from tbl_Employee_Lumpsum";
                        DataTable max_No = clsDataAccess.RunQDTbl(s);
                        if (Information.IsNumeric(max_No.Rows[0][0]) == true)
                            lid = Convert.ToInt32(max_No.Rows[0][0]) + 1;
                        else
                            lid = 1;

                        string txtlumname = CmbSalStructure.Text + "_lumpsum_" + dgvAssignHeads.Columns[alSelectedSalaryHead[i].ToString()].HeaderText;
                        /*END OF LUMPSUM DETAILS*/
                        Boolean boolDeleted = false;
                        for (int j = 1; j < dgvAssignHeads.Rows.Count - 1; j++)
                        {
                            DataGridViewComboBoxCell cell1 = new DataGridViewComboBoxCell();
                            cell1 = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[j].Cells[0];
                            string strSalHeadCellValue = "";
                            try
                            {
                                strSalHeadCellValue = dgvAssignHeads.Rows[j].Cells[alSelectedSalaryHead[i].ToString()].Value.ToString();
                            }
                            catch
                            {
                                strSalHeadCellValue = "";
                            }

                            if (Information.IsNumeric(strSalHeadCellValue))
                            {
                                boolLumpsum = true;
                                if (boolLumpsumExists)
                                {
                                    if (!boolDeleted)
                                    {
                                        boolDeleted = clsDataAccess.RunNQwithStatus("delete tbl_Employee_Lumpsum where LUMPID = "+intExistingLid);
                                    }
                                    s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,AMOUNT,Pf_Amt,GRADE) values(" + intExistingLid + ", '" + strExistingLumpsumName + "', 0, " + Convert.ToDouble(strSalHeadCellValue) + ",'0.00','" + cell1.Value.ToString().Trim() + "')";
                                    boolStatus = clsDataAccess.RunNQwithStatus(s);
                                }
                                else
                                {
                                    s = "insert into tbl_Employee_Lumpsum(LUMPID,LUMPNAME,LUMPTYPE,AMOUNT,Pf_Amt,GRADE) values(" + lid + ", '" + txtlumname + "', 0, " + Convert.ToDouble(strSalHeadCellValue) + ",'0.00','" + cell1.Value.ToString().Trim() + "')";
                                    boolStatus = clsDataAccess.RunNQwithStatus(s);
                                }
                            }
                            else if (!Information.IsNumeric(strSalHeadCellValue) && strSalHeadCellValue.Trim() != "")
                            {
                                //This is for formula
                                if (boolFormulaExists)
                                {
                                    SaveFormula(strFormulaNameFromExistingStructure, strSalHeadCellValue);
                                    boolFormula = true;
                                }
                                else
                                {
                                    SaveFormula(CmbSalStructure.Text + "_formula_" + dgvAssignHeads.Columns[alSelectedSalaryHead[i].ToString()].HeaderText, strSalHeadCellValue);
                                    boolFormula = true;
                                }
                                break;
                            }


                        }

                        if (boolFormula)
                        {
                            C_TYPE = "FORMULA";
                            if (boolFormulaExists)
                            {
                                C_DET = intExistingFormulaId.ToString();
                            }
                            else
                            {
                                C_DET = clsDataAccess.GetresultS("Select max(FID) from tbl_Employee_Sal_Structure_Formula");
                            }
                        }
                        else if (boolLumpsum)
                        {
                            C_TYPE = "COMPANY LUMPSUM";
                            if (boolLumpsumExists)
                                C_DET = intExistingLid.ToString();
                            else
                                C_DET = lid.ToString();
                        }

                        string strValuesFromTickDetails = "";
                        for (int k = 0; k < dtSalaryStructureTickDetails.Rows.Count; k++)
                        {
                            if (dtSalaryStructureTickDetails.Rows[k]["P_TYPE"].ToString() == P_TYPE && dtSalaryStructureTickDetails.Rows[k]["SAL_HEAD"].ToString() == SAL_HEAD)
                            {
                                if (dtSalaryStructureTickDetails.Rows[k]["FetchedFromDatabase"].ToString() == "True" && dtSalaryStructureTickDetails.Rows[k]["Checked"].ToString() == "True")
                                {
                                    string strUpdate = "update tbl_Employee_Assign_SalStructure set SESSION = '" + dtSalaryStructureTickDetails.Rows[k]["SESSION"].ToString() + "',V_FROM = '" + dtSalaryStructureTickDetails.Rows[k]["V_FROM"].ToString() + "',V_TO = '" + dtSalaryStructureTickDetails.Rows[k]["V_TO"].ToString() + "',C_TYPE='" + C_TYPE + "'," +
                                        "C_DET=" + C_DET + ",C_BASIS='Independent',PF_PER=" + dtSalaryStructureTickDetails.Rows[k]["PF_PER"].ToString() + ",ESI_PER=" + dtSalaryStructureTickDetails.Rows[k]["ESI_PER"].ToString() + ",PT=" + dtSalaryStructureTickDetails.Rows[k]["PT"].ToString() + "," +
                                        "atten_day=" + dtSalaryStructureTickDetails.Rows[k]["atten_day"].ToString() + ",Proxy_day=" + dtSalaryStructureTickDetails.Rows[k]["Proxy_day"].ToString() + ",Daily_wages=" + dtSalaryStructureTickDetails.Rows[k]["Daily_wages"].ToString() + "," +
                                        "EMP_BASIC=" + dtSalaryStructureTickDetails.Rows[k]["EMP_BASIC"].ToString() + ",chkALk=" + dtSalaryStructureTickDetails.Rows[k]["chkALk"].ToString() + ",chkHide=" + dtSalaryStructureTickDetails.Rows[k]["chkHide"].ToString() +
                                        " where P_TYPE = '"+P_TYPE+"' and SAL_HEAD = "+SAL_HEAD+" and SAL_STRUCT = " + salary_ID;
                                    boolStatus = clsDataAccess.RunNQwithStatus(strUpdate);
                                }
                                else if (dtSalaryStructureTickDetails.Rows[k]["FetchedFromDatabase"].ToString() != "True" && dtSalaryStructureTickDetails.Rows[k]["Checked"].ToString() == "True")
                                {
                                    DataTable dtGetLocationAndCompany = clsDataAccess.RunQDTbl("select distinct Location_id,Company_id from tbl_Employee_Assign_SalStructure where SAL_STRUCT = " + salary_ID);
                                    for (int locCount = 0; locCount < dtGetLocationAndCompany.Rows.Count; locCount++)
                                    {
                                        Location_ID = Convert.ToInt32(dtGetLocationAndCompany.Rows[locCount]["Location_id"].ToString());
                                        company_ID = Convert.ToInt32(dtGetLocationAndCompany.Rows[locCount]["Company_id"].ToString());
                                        for (int l = 0; l < dtSalaryStructureTickDetails.Columns.Count; l++)
                                        {
                                            if (dtSalaryStructureTickDetails.Columns[l].ColumnName == "P_TYPE" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "SAL_HEAD" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "FetchedFromDatabase" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "Checked")
                                                continue;
                                            else if (dtSalaryStructureTickDetails.Columns[l].ColumnName == "SESSION" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "ROUND_TYPE" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "REMARKS" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "Stamp_Amount" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "V_FROM" || dtSalaryStructureTickDetails.Columns[l].ColumnName == "V_TO")
                                                strValuesFromTickDetails = strValuesFromTickDetails + ",'" + dtSalaryStructureTickDetails.Rows[k][l] + "'";
                                            else
                                                strValuesFromTickDetails = strValuesFromTickDetails + "," + dtSalaryStructureTickDetails.Rows[k][l];
                                        }
                                        string strInsert = "insert into [tbl_Employee_Assign_SalStructure] ([P_TYPE],[SAL_STRUCT],[SAL_HEAD],[Location_id],[Company_id],[C_BASIS],[C_TYPE],[C_DET],[SESSION],[V_FROM],[V_TO],[PF_PER],[PF_VOL],[ESI_PER],[PT],[ROUND_TYPE],[TDSREFNO],[TDS_EXEMPT],[CARRY],[TDS_EXTRAPOL],[REMARKS],[atten_day],[Proxy_day],[Daily_wages],[Revenue_Stamp],[Stamp_Amount],[EMP_BASIC],[chkALK],[chkHide]) values ('" + P_TYPE + "'," + salary_ID + "," + SAL_HEAD + ",'" + Location_ID + "','" + company_ID + "','Independent','" + C_TYPE + "'," + C_DET + strValuesFromTickDetails + ")";
                                        boolStatus = clsDataAccess.RunNQwithStatus(strInsert);
                                    }
                                }
                                break;
                            }
                        }
                        /*string strInsert = "insert into [tbl_Employee_Assign_SalStructure] ([P_TYPE],[SAL_STRUCT],[SAL_HEAD],[Location_id],[Company_id],[C_BASIS],[C_TYPE],[C_DET],[SESSION],[V_FROM],[V_TO],[PF_PER],[PF_VOL],[ESI_PER],[PT],[ROUND_TYPE],[TDSREFNO],[TDS_EXEMPT],[CARRY],[TDS_EXTRAPOL],[REMARKS],[atten_day],[Proxy_day],[Daily_wages],[Revenue_Stamp],[Stamp_Amount],[EMP_BASIC],[chkALK],[chkHide]) values ('" + P_TYPE + "'," + Structure_ID + "," + SAL_HEAD + ",'" + Location_ID + "','" + company_ID + "','Independent','" + C_TYPE + "'," + C_DET + strValuesFromTickDetails + ")";
                        boolStatus = clsDataAccess.RunNQwithStatus(strInsert);*/
                        if (!boolFormula && !boolLumpsum)
                        {
                            boolUsableStructureOrNot = false;
                        }


                    }
                    if (!boolUsableStructureOrNot)
                    {
                        string strUpdateQry = "update tbl_Employee_SalaryStructure set [status] = 0 where [SlNo] = " + salary_ID;
                        boolStatus = clsDataAccess.RunNQwithStatus(strUpdateQry);
                    }
                    else
                    {
                        string strUpdateQry = "update tbl_Employee_SalaryStructure set [status] = 1 where [SlNo] = " + salary_ID;
                        boolStatus = clsDataAccess.RunNQwithStatus(strUpdateQry);
                    }
                    for (int rowCountTick = 0; rowCountTick < dtSalaryStructureTickDetails.Rows.Count; rowCountTick++)
                    {
                        if (dtSalaryStructureTickDetails.Rows[rowCountTick]["FetchedFromDatabase"].ToString() == "True" && dtSalaryStructureTickDetails.Rows[rowCountTick]["Checked"].ToString() != "True")
                        {
                            Boolean boolDeleteFromExistingStructure = clsDataAccess.RunNQwithStatus("delete from tbl_Employee_Assign_SalStructure where SAL_STRUCT = " + salary_ID + " and SAL_HEAD = " + dtSalaryStructureTickDetails.Rows[rowCountTick]["SAL_HEAD"] + " and P_TYPE = '" + dtSalaryStructureTickDetails.Rows[rowCountTick]["P_TYPE"] + "'");
                        }
                    }
                }


            }
            if (boolStatus)
                EDPMessageBox.EDPMessage.Show("Record inserted successfully");
            else
                EDPMessageBox.EDPMessage.Show("Error occured");

            //RESET ALL VALUE
            Location_ID = 0;
            cmbLocation.Text = "";
            salary_ID = 0;
            CmbSalStructure.Text = "";
            company_ID = 0;
            cmbCompany.Text = "";
            chk_fmula.Clear();
            chk_op.Clear();
            htCALDET.Clear();
            ok = false;
            alSelectedSalaryHead.Clear();
            dtSalaryStructureTickDetails.Rows.Clear();

            /*========================================================Resetting datagridview=============================================================*/
            dgvAssignHeads.Rows.Clear();
            dgvAssignHeads.Refresh();
            dgvAssignHeads.Rows.Add();
            for (int i = 0; i < dgvAssignHeads.Columns.Count; i++)
            {
                if (i == 0)
                {
                    DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                    dgvAssignHeads.Rows[0].Cells[i] = cell1;
                    dgvAssignHeads.Rows[0].Cells[i].ReadOnly = true;
                    continue;
                }
                DataGridViewCell cell2 = new DataGridViewCheckBoxCell();
                dgvAssignHeads.Rows[0].Cells[i] = cell2;
            }
            /*==========================================================End of Resetting==================================================================*/
        }

        private void SetDGV()
        {
            //dgvAssignHeads.Rows.Add();
            var col1 = new DataGridViewComboBoxColumn();
            col1.HeaderText = "Designation";
            col1.Name = "Designation";
            //col1.Items.Add("Everyone");
            DataTable dtDesignation = clsDataAccess.RunQDTbl("select [ShortForm],[SlNo] from [tbl_Employee_DesignationMaster]");
            dtDesignation.Rows.Add("Everyone",0);
            col1.DataSource = dtDesignation;
            col1.DisplayMember = "ShortForm";
            col1.ValueMember = "Slno";
            /*for (int i = 0; i < dtDesignation.Rows.Count; i++)
            {
                col1.Items.Add(dtDesignation.Rows[i]["ShortForm"].ToString());
            }*/
            dgvAssignHeads.Columns.Add(col1);

            DataTable dtGettingEarnColumnName = clsDataAccess.RunQDTbl("select [SlNo],[SalaryHead_Short] from [tbl_Employee_ErnSalaryHead]");
            for (int i = 0; i < dtGettingEarnColumnName.Rows.Count; i++)
            {
                var col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = dtGettingEarnColumnName.Rows[i]["SalaryHead_Short"].ToString();
                col2.Name = "E"+dtGettingEarnColumnName.Rows[i]["SlNo"].ToString();
                dgvAssignHeads.Columns.Add(col2);
            }

            DataTable dtGettingDedcColumnName = clsDataAccess.RunQDTbl("select [SlNo],[SalaryHead_Short] from [tbl_Employee_DeductionSalayHead]");
            for (int i = 0; i < dtGettingDedcColumnName.Rows.Count; i++)
            {
                var col2 = new DataGridViewTextBoxColumn();
                col2.HeaderText = dtGettingDedcColumnName.Rows[i]["SalaryHead_Short"].ToString();
                col2.Name = "D"+dtGettingDedcColumnName.Rows[i]["SlNo"].ToString();
                dgvAssignHeads.Columns.Add(col2);
            }

            dgvAssignHeads.Rows.Add();
            //DataGridViewCell cell1 = new DataGridViewCheckBoxCell();
            for (int i = 0; i < dgvAssignHeads.Columns.Count; i++)
            {
                if(i==0)
                {
                    DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                    dgvAssignHeads.Rows[0].Cells[i] = cell1;
                    dgvAssignHeads.Rows[0].Cells[i].ReadOnly = true;
                    continue;
                }
                DataGridViewCell cell2 = new DataGridViewCheckBoxCell();
                dgvAssignHeads.Rows[0].Cells[i] = cell2;
            }
            
            //The skeleton of the datagridview is ready.. Now have to add code for make it look better..


            foreach (DataGridViewColumn dgvc in dgvAssignHeads.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        public void GetSalaryStructureDetails(int SalaryStructureID)
        {
            /*========================================================Resetting datagridview=============================================================*/
            dgvAssignHeads.Rows.Clear();
            dgvAssignHeads.Refresh();
            dgvAssignHeads.Rows.Add();
            for (int i = 0; i < dgvAssignHeads.Columns.Count; i++)
            {
                if (i == 0)
                {
                    DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                    dgvAssignHeads.Rows[0].Cells[i] = cell1;
                    dgvAssignHeads.Rows[0].Cells[i].ReadOnly = true;
                    continue;
                }
                DataGridViewCell cell2 = new DataGridViewCheckBoxCell();
                dgvAssignHeads.Rows[0].Cells[i] = cell2;
            }
            /*==========================================================End of Resetting==================================================================*/
            dtSalaryStructureTickDetails.Rows.Clear();
            dtSalaryStructureTickDetails = clsDataAccess.RunQDTbl("SELECT distinct [P_TYPE],[SESSION],[SAL_HEAD],[V_FROM],[V_TO],[PF_PER],[PF_VOL],[ESI_PER],[PT],[ROUND_TYPE],[TDSREFNO],[TDS_EXEMPT],[CARRY],[TDS_EXTRAPOL],[REMARKS],[atten_day],[Proxy_day],[Daily_wages],[Revenue_Stamp],[Stamp_Amount],[EMP_BASIC],[chkALK],[chkHide],'True' as 'FetchedFromDatabase','True' as 'Checked' FROM [tbl_Employee_Assign_SalStructure] where SAL_STRUCT = "+SalaryStructureID);
            DataTable dtGetSalHead = clsDataAccess.RunQDTbl("select distinct [SAL_HEAD],[P_TYPE],[C_TYPE],[C_DET] from [tbl_Employee_Assign_SalStructure] where SAL_STRUCT = " + SalaryStructureID + " order by C_TYPE asc");
            for (int i = 0; i < dtGetSalHead.Rows.Count ; i++)
            {
                if (dtGetSalHead.Rows[i]["P_TYPE"].ToString() == "E")
                {
                    dgvAssignHeads.Rows[0].Cells["E" + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = 1;
                    if (dtGetSalHead.Rows[i]["C_TYPE"].ToString() == "COMPANY LUMPSUM")
                        htCALDET["E" + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()] = "L"+dtGetSalHead.Rows[i]["C_DET"].ToString();
                    else if (dtGetSalHead.Rows[i]["C_TYPE"].ToString() == "FORMULA")
                        htCALDET["E" + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()] = "F" + dtGetSalHead.Rows[i]["C_DET"].ToString();
                }
                else if (dtGetSalHead.Rows[i]["P_TYPE"].ToString() == "D")
                {
                    dgvAssignHeads.Rows[0].Cells["D" + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = 1;
                    if (dtGetSalHead.Rows[i]["C_TYPE"].ToString() == "COMPANY LUMPSUM")
                        htCALDET["E" + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()] = "L" + dtGetSalHead.Rows[i]["C_DET"].ToString();
                    else if (dtGetSalHead.Rows[i]["C_TYPE"].ToString() == "FORMULA")
                        htCALDET["E" + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()] = "F" + dtGetSalHead.Rows[i]["C_DET"].ToString();
                }

                if (dtGetSalHead.Rows[i]["C_TYPE"].ToString() == "COMPANY LUMPSUM")
                {
                    DataTable dtLumpsumDetails = clsDataAccess.RunQDTbl("select [GRADE],[AMOUNT] from [tbl_Employee_Lumpsum] where [LUMPID] = " + dtGetSalHead.Rows[i]["C_DET"].ToString());
                    if(dtLumpsumDetails.Rows.Count>0)
                    {
                        /*
                         * 1. If GRADE in lumnsumn table is 0 then the else part's logic will be applied just amount will be changed
                         * 2. 
                         */
                        for (int j = 0; j < dtLumpsumDetails.Rows.Count; j++)
                        {
                            if (dtLumpsumDetails.Rows[j]["GRADE"].ToString().Trim() == "0")
                            {
                                //IF LUMPSUM IS DEFINED FOR EVERYONE
                                if (dgvAssignHeads.Rows.Count <= 2)
                                {
                                    dgvAssignHeads.Rows.Add();
                                    DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[1].Cells["Designation"];
                                    cbc.Value = 0;
                                    dgvAssignHeads.Rows[1].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = dtLumpsumDetails.Rows[j]["AMOUNT"].ToString();
                                }
                                else
                                {
                                    Boolean flagDesgRowExists = false;
                                    for (int k = 1; k < dgvAssignHeads.Rows.Count - 1; k++)
                                    {
                                        if (dgvAssignHeads.Rows[k].Cells["Designation"].Value == "0")
                                        {
                                            dgvAssignHeads.Rows[1].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = dtLumpsumDetails.Rows[j]["AMOUNT"].ToString();
                                            flagDesgRowExists = true;
                                            break;
                                        }
                                    }
                                    if (!flagDesgRowExists)
                                    {
                                        DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells["Designation"];
                                        cbc.Value = 0;
                                        dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = dtLumpsumDetails.Rows[j]["AMOUNT"].ToString();
                                    }
                                }
                            }
                            else
                            { 
                                //IF LUMNSUM IS DEFINED DESIGNATION WISE
                                string strDesignationSF = clsDataAccess.GetresultS("select [ShortForm] from [tbl_Employee_DesignationMaster] where SlNo = " + dtLumpsumDetails.Rows[j]["GRADE"].ToString().Trim());
                                if (dgvAssignHeads.Rows.Count <= 2)
                                {
                                    dgvAssignHeads.Rows.Add();
                                    DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[1].Cells["Designation"];
                                    cbc.Value = Convert.ToInt32(dtLumpsumDetails.Rows[j]["GRADE"]);
                                    dgvAssignHeads.Rows[1].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = dtLumpsumDetails.Rows[j]["AMOUNT"].ToString();
                                }
                                else
                                {
                                    Boolean flagDesgRowExists = false;
                                    for (int k = 1; k < dgvAssignHeads.Rows.Count - 1; k++)
                                    {
                                        if (dgvAssignHeads.Rows[k].Cells["Designation"].Value == dtLumpsumDetails.Rows[j]["GRADE"].ToString())
                                        {
                                            dgvAssignHeads.Rows[1].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = dtLumpsumDetails.Rows[j]["AMOUNT"].ToString();
                                            flagDesgRowExists = true;
                                            break;
                                        }
                                    }
                                    if (!flagDesgRowExists)
                                    {
                                        dgvAssignHeads.Rows.Add();
                                        DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells["Designation"];
                                        cbc.Value = Convert.ToInt32(dtLumpsumDetails.Rows[j]["GRADE"]);
                                        //dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells["Designation"].Value = strDesignationSF;
                                        dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = dtLumpsumDetails.Rows[j]["AMOUNT"].ToString();
                                    }
                                }
                            }
                        }


                    }
                    else
                    {
                        //If no row exists then 0 will be added in Everyone designation
                        if (dgvAssignHeads.Rows.Count <= 2)
                        {
                            dgvAssignHeads.Rows.Add();
                            DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[1].Cells["Designation"];
                            cbc.Value = 0;
                            //dgvAssignHeads.Rows[1].Cells["Designation"].Value = "Everyone";
                            dgvAssignHeads.Rows[1].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = "0";
                        }
                        else
                        {
                            Boolean flagDesgRowExists = false;
                            for (int j = 1; j < dgvAssignHeads.Rows.Count - 1; j++)
                            {
                                if (dgvAssignHeads.Rows[j].Cells["Designation"].Value == "Everyone")
                                {
                                    dgvAssignHeads.Rows[1].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = "0";
                                    flagDesgRowExists = true;
                                    break;
                                }
                            }
                            if (!flagDesgRowExists)
                            {
                                dgvAssignHeads.Rows.Add();
                                DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells["Designation"];
                                cbc.Value = 0;
                                //dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells["Designation"].Value = "Everyone";
                                dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = "0";
                            }
                        }
                    }
                    
                    //if(dgvAssignHeads.Rows.Count)
                }
                else if (dtGetSalHead.Rows[i]["C_TYPE"].ToString() == "FORMULA")
                {
                    DataTable dtFormulaDetails = clsDataAccess.RunQDTbl("select [FName],[FExp] from [tbl_Employee_Sal_Structure_Formula] where [FID] = " + dtGetSalHead.Rows[i]["C_DET"].ToString());
                    if (dtFormulaDetails.Rows.Count > 0)
                    {
                        Boolean flagDesgRowExists = false;
                        for (int k = 1; k < dgvAssignHeads.Rows.Count - 1; k++)
                        {
                            if (dgvAssignHeads.Rows[k].Cells["Designation"].Value == "0")
                            {
                                dgvAssignHeads.Rows[k].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = GetFormula(dtFormulaDetails.Rows[0]["FName"].ToString(),dtFormulaDetails.Rows[0]["FExp"].ToString());
                                flagDesgRowExists = true;
                                break;
                            }
                        }
                        if (!flagDesgRowExists)
                        {
                            dgvAssignHeads.Rows.Add();
                            DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells["Designation"];
                            cbc.Value = 0;
                            dgvAssignHeads.Rows[dgvAssignHeads.Rows.Count - 2].Cells[dtGetSalHead.Rows[i]["P_TYPE"].ToString().Trim() + dtGetSalHead.Rows[i]["SAL_HEAD"].ToString()].Value = GetFormula(dtFormulaDetails.Rows[0]["FName"].ToString(), dtFormulaDetails.Rows[0]["FExp"].ToString());
                        }
                    }
                }
            }


        }

        private void GetSalaryHeads()
        {
            DataTable dtErn = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_ErnSalaryHead");
            DataTable dtDeduction = clsDataAccess.RunQDTbl("SELECT SalaryHead_Short,SlNo FROM tbl_Employee_DeductionSalayHead");
            
            for (Int32 i = 0; i < dtErn.Rows.Count; i++)
            {
                if (!SalHead.ContainsKey(dtErn.Rows[i][0].ToString()))
                    SalHead.Add(dtErn.Rows[i][0].ToString(), Gen_ID("S", dtErn.Rows[i][1].ToString()));
                if (!SalHead1.ContainsKey(Gen_ID("S", dtErn.Rows[i][1].ToString())))
                    SalHead1.Add(Gen_ID("S", dtErn.Rows[i][1].ToString()), dtErn.Rows[i][0].ToString());
            }
            for (Int32 i = 0; i < dtDeduction.Rows.Count; i++)
            {
                if (!SalHead.ContainsKey(dtDeduction.Rows[i][0].ToString()))
                    SalHead.Add(dtDeduction.Rows[i][0].ToString(), Gen_ID("D", dtDeduction.Rows[i][1].ToString()));
                if (!SalHead1.ContainsKey(Gen_ID("D", dtDeduction.Rows[i][1].ToString())))
                    SalHead1.Add(Gen_ID("D", dtDeduction.Rows[i][1].ToString()), dtDeduction.Rows[i][0].ToString());
            }
        }
        public string Gen_ID(string h_type, string s)
        {
            string res = "";
            switch (s.Length)
            {
                case 1: res = h_type + "00" + s; break;
                case 2: res = h_type + "0" + s; break;
                case 3: res = h_type + s; break;
            }
            return res;
        }

        public string Encode(int i1, string str)
        {
            int g = 0, i = 0;
            string fmula = "";
            if (i1 == 1)
            {
                for (int f = 0; f < str.Length; f++)
                {

                    if (str.Substring(f, 1) == "=" || str.Substring(f, 1) == "*" || str.Substring(f, 1) == "+" || str.Substring(f, 1) == "-" || str.Substring(f, 1) == "/" || str.Substring(f, 1) == "%" || str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")")
                    {
                        if (SalHead.ContainsKey(str.Substring(g, i)))
                            fmula += SalHead[str.Substring(g, i)] + str.Substring(f, 1);
                        else
                            fmula += str.Substring(g, i) + str.Substring(f, 1);
                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                fmula += str.Substring(g, i);
                return fmula;
            }
            else
            {
                for (int f = 0; f < str.Length; f++)
                {

                    if (str.Substring(f, 1) == "=" || str.Substring(f, 1) == "*" || str.Substring(f, 1) == "+" || str.Substring(f, 1) == "-" || str.Substring(f, 1) == "/" || str.Substring(f, 1) == "%" || str.Substring(f, 1) == "(" || str.Substring(f, 1) == ")")
                    {
                        if (SalHead1.ContainsKey(str.Substring(g, i)))
                            fmula += SalHead1[str.Substring(g, i)] + str.Substring(f, 1);
                        else
                            fmula += str.Substring(g, i) + str.Substring(f, 1);
                        i = 0;
                        g = f + 1;
                    }
                    else
                        i++;
                }
                fmula += str.Substring(g, i);
                return fmula;
            }
        }

        private string GetFormula(string fname,string fexp)
        {
            string actualExp = "";
            actualExp = Encode(2, fexp);
            if (!chk_fmula.ContainsKey(fname))
                chk_fmula.Add(fname,actualExp);
            return actualExp;
        }

        private void SaveFormula(string txtfname, string txtFormula)
        {
            Boolean boolStatus = false;
            int hb = 0;
            string s = "";
            s = "Select max(FID) from tbl_Employee_Sal_Structure_Formula";
            DataTable max_No = clsDataAccess.RunQDTbl(s);
            if (Information.IsNumeric(max_No.Rows[0][0]) == true)
                hb = Convert.ToInt32(max_No.Rows[0][0]) + 1;
            else
                hb = 1;
            int intMatchCounter = 0;
            if (chk_fmula.ContainsKey(txtfname))
                boolStatus = clsDataAccess.RunNQwithStatus("update tbl_Employee_Sal_Structure_Formula set fexp='" + Encode(1, txtFormula) + "' where fname='" + txtfname + "'" + "");
            else
                boolStatus = clsDataAccess.RunNQwithStatus("insert into tbl_Employee_Sal_Structure_Formula values(" + hb + ",'" + txtfname + "','" + Encode(1, txtFormula) + "')" + "");
            
            
        }

        private string CurrentSession()
        {
            string strSession = "";
            int intYear = DateTime.Now.Year;
            int intMonth = DateTime.Now.Month;
            if (intMonth > 3)
            {
                strSession = intYear + "-" + (intYear + 1);
            }
            else
            {
                strSession = (intYear - 1) + "-" + intYear;
            }
            return strSession;
        }

        private void dgvAssignHeads_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvAssignHeads_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strSalHeadName = dgvAssignHeads.Columns[e.ColumnIndex].HeaderText;
            string strSalHeadType = dgvAssignHeads.Columns[e.ColumnIndex].Name.Substring(0,1);
            string strSalHeadID = dgvAssignHeads.Columns[e.ColumnIndex].Name.Substring(1);
            string strColumnCheckedCheck = "";
            try
            {
                strColumnCheckedCheck = dgvAssignHeads.Rows[0].Cells[e.ColumnIndex].Value.ToString();
            }
            catch
            {
                strColumnCheckedCheck = "0";
            }
            if (strColumnCheckedCheck == "1" || strColumnCheckedCheck == "True")
            {
                /*using (frmEmployeeSalHeadDetails shf = new frmEmployeeSalHeadDetails(dtSalaryStructureTickDetails, strSalHeadName, strSalHeadID, strSalHeadType))
                {
                    shf.TopMost = true;
                    shf.ShowDialog();
                }*/
                frmEmployeeSalHeadDetails shf = new frmEmployeeSalHeadDetails(dtSalaryStructureTickDetails, strSalHeadName, strSalHeadID, strSalHeadType);
                shf.ShowDialog();
                dtSalaryStructureTickDetails = shf.dtSalHeadDet;


            }
        }

        private void dgvAssignHeads_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                string OldValue = "";
                string NewValue = "";
                try
                {
                    OldValue = dgvAssignHeads.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                catch
                {
                    OldValue = "";
                }
                dgvAssignHeads.CommitEdit(DataGridViewDataErrorContexts.Commit);
                try
                {
                    NewValue = dgvAssignHeads.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                catch
                {
                    NewValue = "";
                }
                //This is just check change event for checkbox cell 
                if(NewValue!=OldValue)
                {
                    if (NewValue == "True" || NewValue == "1")
                    {
                        Boolean boolSalIdMatched = false;
                        string strHeadID = dgvAssignHeads.Columns[e.ColumnIndex].Name.Substring(1);
                        string strHeadType = dgvAssignHeads.Columns[e.ColumnIndex].Name.Substring(0,1);
                        for (int i = 0; i < dtSalaryStructureTickDetails.Rows.Count; i++)
                        {
                            if (dtSalaryStructureTickDetails.Rows[i]["P_TYPE"].ToString() == strHeadType && dtSalaryStructureTickDetails.Rows[i]["SAL_HEAD"].ToString() == strHeadType)
                            {
                                dtSalaryStructureTickDetails.Rows[i]["Checked"] = "True";
                                boolSalIdMatched = true;
                                break;
                            }
                        }

                        if (!boolSalIdMatched)
                        {
                            dtSalaryStructureTickDetails.Rows.Add();
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["P_TYPE"] = strHeadType;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["SESSION"] = CurrentSession();
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["SAL_HEAD"] = Convert.ToInt32(strHeadID);
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["V_FROM"] = "April";
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["V_TO"] = "March";
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["PF_PER"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["PF_VOL"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["ESI_PER"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["PT"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["ROUND_TYPE"] = "";
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["TDSREFNO"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["TDS_EXEMPT"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["CARRY"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["TDS_EXTRAPOL"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["REMARKS"] = "";
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["atten_day"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["Proxy_day"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["Daily_wages"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["Revenue_Stamp"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["Stamp_Amount"] = "";
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["EMP_BASIC"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["chkALK"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["chkHide"] = 0;
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["FetchedFromDatabase"] = "False";
                            dtSalaryStructureTickDetails.Rows[dtSalaryStructureTickDetails.Rows.Count-1]["Checked"] = "True";
                        }
                    }
                    else if (NewValue == "False" || NewValue == "0")
                    {
                        Boolean boolSalIdMatched = false;
                        string strHeadID = dgvAssignHeads.Columns[e.ColumnIndex].Name.Substring(1);
                        string strHeadType = dgvAssignHeads.Columns[e.ColumnIndex].Name.Substring(0, 1);
                        for (int i = 0; i < dtSalaryStructureTickDetails.Rows.Count; i++)
                        {
                            if (dtSalaryStructureTickDetails.Rows[i]["P_TYPE"].ToString() == strHeadType && dtSalaryStructureTickDetails.Rows[i]["SAL_HEAD"].ToString() == strHeadType)
                            {
                                dtSalaryStructureTickDetails.Rows[i]["Checked"] = "False";
                                if (dtSalaryStructureTickDetails.Rows[i]["FetchedFromDatabase"].ToString() == "False")
                                    dtSalaryStructureTickDetails.Rows.RemoveAt(i);
                                boolSalIdMatched = true;
                                break;
                            }
                        }
                    }
                
                }
            }
        }

        public void NotifyMe(DataTable dtChildReturnData)
        {
            //dtSalaryStructureTickDetails = dtChildReturnData;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Location_ID = 0;
            cmbLocation.Text = "";
            salary_ID = 0;
            CmbSalStructure.Text = "";
            company_ID = 0;
            cmbCompany.Text = "";
            SalHead.Clear();
            SalHead1.Clear();
            chk_fmula.Clear();
            chk_op.Clear();
            htCALDET.Clear();
            ok = false;
            alSelectedSalaryHead.Clear();
            dtSalaryStructureTickDetails.Rows.Clear();

            /*========================================================Resetting datagridview=============================================================*/
            dgvAssignHeads.Rows.Clear();
            dgvAssignHeads.Refresh();
            dgvAssignHeads.Rows.Add();
            for (int i = 0; i < dgvAssignHeads.Columns.Count; i++)
            {
                if (i == 0)
                {
                    DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                    dgvAssignHeads.Rows[0].Cells[i] = cell1;
                    dgvAssignHeads.Rows[0].Cells[i].ReadOnly = true;
                    continue;
                }
                DataGridViewCell cell2 = new DataGridViewCheckBoxCell();
                dgvAssignHeads.Rows[0].Cells[i] = cell2;
            }
            /*==========================================================End of Resetting==================================================================*/
        }

        private void dgvAssignHeads_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAssignHeads.CurrentCell.RowIndex != 0)
            {
                if (this.dgvAssignHeads.IsCurrentCellDirty)
                {
                    // This fires the cell value changed handler below
                    dgvAssignHeads.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void dgvAssignHeads_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != 0)
            {
                Boolean boolAlreadyFound = false;
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvAssignHeads.Rows[e.RowIndex].Cells[0];
                for (int i = 1; i < dgvAssignHeads.Rows.Count - 1; i++)
                {
                    if (e.RowIndex == i && boolAlreadyFound && cb.Value == dgvAssignHeads.Rows[i].Cells[0].Value)
                    {
                        DataGridViewRow dgvr = dgvAssignHeads.Rows[e.RowIndex];
                        dgvAssignHeads.Rows.Remove(dgvr);
                        break;
                    }
                      
                    if (cb.Value.ToString() == dgvAssignHeads.Rows[i].Cells[0].Value.ToString())
                    {
                        boolAlreadyFound = true;
                    }
                }
            }
        }

    }
}
