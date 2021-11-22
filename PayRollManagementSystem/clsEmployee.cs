using System;
//partha
using System.Collections;
//partha
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;


namespace PayRollManagementSystem
{
    public static class clsEmployee
    {
        public static string HeadName = String.Empty;
        //partha
        public static string mcode, LOVRESULT, RadioCHK, DegitWord, ChkMode, Allocvch = "";
        public static Hashtable arr = new Hashtable();
        //partha

        #region Koushik

        public static string DateChange2(int Day,int Month,int Year)
        {

            string ReturnVal = "", RegDateVal = "";
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey("Control Panel\\International", true);

            RegDateVal = reg.GetValue("sShortDate").ToString();
            switch (RegDateVal)
            {
                case "dd/MM/yyyy":
                    ReturnVal = Day.ToString() + "/" + Month.ToString() + "/" + Year.ToString();
                    break;
                case "M/d/yyyy":
                        ReturnVal = Month.ToString() + "/" + Day.ToString() + "/" + Year.ToString();
                        break;
                case "M/d/yy":
                        ReturnVal = Month.ToString() + "/" + Day.ToString() + "/" + Year.ToString();
                        break;
                case "MM/dd/yy":
                        ReturnVal = Month.ToString() + "/" + Day.ToString() + "/" + Year.ToString();
                        break;
                case "MM/dd/yyyy":
                        ReturnVal = Month.ToString() + "/" + Day.ToString() + "/" + Year.ToString();
                        break;
                case "yy/MM/dd":
                        ReturnVal = Year.ToString() + "/" + Month.ToString() + "/" + Day.ToString();
                        break;
                case "yyyy-MM-dd":
                        ReturnVal = Year.ToString() + "/" + Month.ToString() + "/" + Day.ToString();
                        break;
                case "dd-MMM-yy":
                        ReturnVal = Day.ToString() + "/" + Month.ToString() + "/" + Year.ToString();
                        break;
                default :
                    ReturnVal = Day.ToString() + "/" + Month.ToString() + "/" + Year.ToString();
                    break;                    
            }
            return ReturnVal;  
            
        }

        public static string[] TotalLeaveDetails
        {
            get { return TotalLv; }
            set { TotalLv = value; }
        }

        static string[] TotalLv ={ "", "", "", "", "", "", "", "", "", "", "" ,"",""};
        #endregion
        static string firsthalf = "", secondhalf = "", remarks = "";
        public static string FirstHalf
        {
            get { return firsthalf; }
            set { firsthalf = value; }
        }

        public static string SecondHalf
        {
            get { return secondhalf; }
            set { secondhalf = value; }
        }

        public static string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public static Int32 GetDesgId(String strDesignation)
        {
            Int32 intDesgId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_DesignationMaster where DesignationName='" + strDesignation + "'");
            if (dt.Rows.Count > 0)
            {
                intDesgId = Convert.ToInt32(dt.Rows[0]["SlNo"]);
            }
            return intDesgId;
        }

        public static Int32 GetSalID(string strSalname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select slno from tbl_Employee_SalaryStructure where SalaryCategory='" + strSalname + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["slno"]);
            }
            return salid;
        }
        public static String GetSalName(Int32 SalID)
        {
            string salname= "";
            DataTable dt = clsDataAccess.RunQDTbl("select SalaryCategory from tbl_Employee_SalaryStructure where slno=" + SalID );
            if (dt.Rows.Count > 0)
            {
                salname = dt.Rows[0]["SalaryCategory"].ToString();
            }
            return salname;
        }
         public static Int32 GetSecID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select slno from tbl_Employee_SectionMaster where section='" + strSecname + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["slno"]);
            }
            return salid;
        }

         public static Int32 GetStatID(string strSecname)
         {
             Int32 salid = 0;
             DataTable dt = clsDataAccess.RunQDTbl("select STATE_CODE from StateMaster where STATE_Name='" + strSecname + "'");
             if (dt.Rows.Count > 0)
             {
                 salid = Convert.ToInt32(dt.Rows[0]["STATE_CODE"]);
             }
             return salid;
         }

         public static Int32 GetCountryID(string strSecname)
         {
             Int32 salid = 0;
             DataTable dt = clsDataAccess.RunQDTbl("select Country_CODE from Country where Country_Name='" + strSecname + "'");
             if (dt.Rows.Count > 0)
             {
                 salid = Convert.ToInt32(dt.Rows[0]["Country_CODE"]);
             }
             return salid;
         }

        public static String GetSecName(Int32 SecID)
        {
            string salname= "";
            DataTable dt = clsDataAccess.RunQDTbl("select section from tbl_Employee_SectionMaster where slno=" + SecID);
            if (dt.Rows.Count > 0)
            {
                salname = dt.Rows[0]["section"].ToString();
            }
            return salname;
        }

        public static Int32 GetClintID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select Client_id from tbl_Employee_CliantMaster where Client_Name='" + strSecname + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["Client_id"]);
            }
            return salid;
        }

        public static Int32 GetlocID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select Location_ID from tbl_Emp_Location where Location_Name='" + strSecname + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["Location_ID"]);
            }
            return salid;
        }




        public static Int32 GethrID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select Hour_CODE from HourMaster where Hour_Name='" + strSecname + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["Hour_CODE"]);
            }
            return salid;
        }

        public static Int32 GetmnthID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select MONTH_CODE from MonthOfDays where MONTH_Name='" + strSecname + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["MONTH_CODE"]);
            }
            return salid;
        }

        public static Int32 GetCompanyID(string strSecname)
        {
            Int32 salid = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select CO_CODE from Company where CO_NAME='" + strSecname + "'");
            if (dt.Rows.Count > 0)
            {
                salid = Convert.ToInt32(dt.Rows[0]["CO_CODE"]);
            }
            return salid;
        }

        
        public static Int32 GetYear(String strFullMonthNameMonth, String strSession)
        {
            Int32 intYear = 0;
            String[] strArr = new String[2];
            strArr = strSession.Split('-');
            if (!String.IsNullOrEmpty(strFullMonthNameMonth))
            {
                if (strFullMonthNameMonth.ToLower() == "april" || strFullMonthNameMonth.ToLower() == "may" || strFullMonthNameMonth.ToLower() == "june" || strFullMonthNameMonth.ToLower() == "july" || strFullMonthNameMonth.ToLower() == "august" || strFullMonthNameMonth.ToLower() == "september" || strFullMonthNameMonth.ToLower() == "october" || strFullMonthNameMonth.ToLower() == "november" || strFullMonthNameMonth.ToLower() == "december")
                {
                    intYear = Convert.ToInt32(strArr[0]);
                }
                else if (strFullMonthNameMonth.ToLower() == "january" || strFullMonthNameMonth.ToLower() == "february" || strFullMonthNameMonth.ToLower() == "march")
                {
                    intYear = Convert.ToInt32(strArr[1]);
                }
            }
            return intYear;
        }

        public static Int32 GetTotalDaysByMonth(String strFullMonthName, Int32 intYear)
        {
            Int32 intDays = 0;
            if (Convert.ToString(intYear).Length == 4)
            {
                if (!String.IsNullOrEmpty(strFullMonthName))
                {
                    if (strFullMonthName.ToLower() == "february")
                    {
                        if ((intYear > 0) && (intYear % 4 == 0))
                        {
                            intDays = 29;
                        }
                        else
                        {
                            intDays = 28;
                        }
                    }
                    else if (strFullMonthName.ToLower() == "january" || strFullMonthName.ToLower() == "march" || strFullMonthName.ToLower() == "may" || strFullMonthName.ToLower() == "july" || strFullMonthName.ToLower() == "august" || strFullMonthName.ToLower() == "october" || strFullMonthName.ToLower() == "december")
                    {
                        intDays = 31;
                    }
                    else if (strFullMonthName.ToLower() == "april" || strFullMonthName.ToLower() == "june" || strFullMonthName.ToLower() == "september" || strFullMonthName.ToLower() == "november")
                    {
                        intDays = 30;
                    }
                    else
                    {
                        ERPMessageBox.ERPMessage.Show("No Such Month Exists");
                    }
                }
            }
            else
            {
                ERPMessageBox.ERPMessage.Show("Please Enter Valid Year.");
            }
            return intDays;
        }

        public static Int32 GetMonth_SingleDigit(String strMonth)
        {
            Int32 i = 0;
            if (strMonth.Trim().ToLower() == "january")
            {
                i = 1;
            }
            else if (strMonth.Trim().ToLower() == "february")
            {
                i = 2;
            }
            else if (strMonth.Trim().ToLower() == "march")
            {
                i = 3;
            }
            else if (strMonth.Trim().ToLower() == "april")
            {
                i = 4;
            }
            else if (strMonth.Trim().ToLower() == "may")
            {
                i = 5;
            }

            else if (strMonth.Trim().ToLower() == "june")
            {
                i = 6;
            }
            else if (strMonth.Trim().ToLower() == "july")
            {
                i = 7;
            }
            else if (strMonth.Trim().ToLower() == "august")
            {
                i = 8;
            }
            else if (strMonth.Trim().ToLower() == "september")
            {
                i = 9;
            }
            else if (strMonth.Trim().ToLower() == "october")
            {
                i = 10;
            }
            else if (strMonth.Trim().ToLower() == "november")
            {
                i = 11;

            }
            else if (strMonth.Trim().ToLower() == "december")
            {
                i = 12;
            }
            
            return i;
        }

        public static String GetMonth_DoubleDigit(String strMonth)
        {
            String i = String.Empty;
            if (strMonth.Trim().ToLower() == "january")
            {
                i = "01";
            }
            else if (strMonth.Trim().ToLower() == "february")
            {
                i = "02";
            }
            else if (strMonth.Trim().ToLower() == "march")
            {
                i = "03";
            }
            else if (strMonth.Trim().ToLower() == "april")
            {
                i = "04";
            }
            else if (strMonth.Trim().ToLower() == "may")
            {
                i = "05";
            }

            else if (strMonth.Trim().ToLower() == "june")
            {
                i = "06";
            }
            else if (strMonth.Trim().ToLower() == "july")
            {
                i = "07";
            }
            else if (strMonth.Trim().ToLower() == "august")
            {
                i = "08";
            }
            else if (strMonth.Trim().ToLower() == "september")
            {
                i = "09";
            }
            else if (strMonth.Trim().ToLower() == "october")
            {
                i = "10";
            }
            else if (strMonth.Trim().ToLower() == "november")
            {
                i = "11";

            }
            else if (strMonth.Trim().ToLower() == "december")
            {
                i = "12";
            }
            return i;
        }

        public static String GetMonthName(Int32 intMonthNo)
        {
            String strMonthName = String.Empty;
            if (intMonthNo > 0)
            {
                switch (intMonthNo)
                {
                    case 1: strMonthName = "January";
                        break;
                    case 2: strMonthName = "February";
                        break;
                    case 3: strMonthName = "March";
                        break;
                    case 4: strMonthName = "April";
                        break;
                    case 5: strMonthName = "May";
                        break;
                    case 6: strMonthName = "June";
                        break;
                    case 7: strMonthName = "July";
                        break;
                    case 8: strMonthName = "August";
                        break;
                    case 9: strMonthName = "September";
                        break;
                    case 10: strMonthName = "October";
                        break;
                    case 11: strMonthName = "November";
                        break;
                    case 12: strMonthName = "December";
                        break;
                    default: strMonthName = String.Empty;
                        break;
                }
            }
            return strMonthName;
            
        }

        public static Int32 GetJobTypeId(String strJobType)
        {
            Int32 intJobId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select SlNo from tbl_Employee_JobType where JobType='" + strJobType + "'");
            if (dt.Rows.Count > 0)
            {
                intJobId = Convert.ToInt32(dt.Rows[0]["SlNo"]);
            }
            return intJobId;
        }

        public static Int32 GetLeaveId(String strLeaveName)
        {
            Int32 intLeaveId = 0;

            DataTable dt = clsDataAccess.RunQDTbl("select LeaveId from tbl_Employee_Config_LeaveDetails where ShortName='" + strLeaveName.Trim().ToUpper() + "'");
            if (dt.Rows.Count > 0)
            {
                intLeaveId = Convert.ToInt32(dt.Rows[0]["LeaveId"]);
            }

            return intLeaveId;
        }

        public static String GetLeaveShortName(Int32 intLeaveId)
        {
            String strLeaveName = String.Empty;
            DataTable dt = clsDataAccess.RunQDTbl("select * from tbl_Employee_Config_LeaveDetails where LeaveId="+intLeaveId+"");
            if (dt.Rows.Count > 0)
            {
                strLeaveName = Convert.ToString(dt.Rows[0]["ShortName"]);
            }
            return strLeaveName;
        }
        
        public static String GetSessionByDate(Int32 intMonth,Int32 intYear)
        {
            String strSession = String.Empty;

            if (intMonth >= 4 && intMonth <= 12)
            {
                strSession = Convert.ToString(intYear) + "-" + Convert.ToString(intYear + 1);
            }
            else if (intMonth >= 1 && intMonth <= 3)
            {
                strSession = Convert.ToString(intYear-1) + "-" + Convert.ToString(intYear);
            }

            return strSession;
        }

        public static void PopulateYear(ComboBox cmb, Int32 intStartYear, Int32 intEndYear, Int32 intIncrement)
        {
            cmb.Items.Clear();
            for (Int32 i = intEndYear; i >= intStartYear; i -= intIncrement)
            {
                cmb.Items.Add(i.ToString());
            }
        }

        public static void GenerateYear(ComboBox cmb)
        {
            for (Int32 i = System.DateTime.Now.Year; i > 1950; i--)
            {
                cmb.Items.Add(i);
            }
            cmb.SelectedIndex = 0;
        }

        public static Int32 GetCompany_ID(int location)
        {
            Int32 intLeaveId = 0;
            DataTable dt = clsDataAccess.RunQDTbl("select Company_ID from Companywiseid_Relation where Location_ID='" + location + "'");
            if (dt.Rows.Count > 0)
            {
                intLeaveId = Convert.ToInt32(dt.Rows[0]["Company_ID"]);
            }
            return intLeaveId;
        }


        public static void PopulateMonthByName(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.Items.Add("January");
            cmb.Items.Add("February");
            cmb.Items.Add("March");
            cmb.Items.Add("April");
            cmb.Items.Add("May");
            cmb.Items.Add("June");
            cmb.Items.Add("July");
            cmb.Items.Add("August");
            cmb.Items.Add("Sepetember");
            cmb.Items.Add("October");
            cmb.Items.Add("November");
            cmb.Items.Add("December");
        }
        
    }
}
