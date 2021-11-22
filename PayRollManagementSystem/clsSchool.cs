using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PayRollManagementSystem
{
    public static class clsSchool
    {
        public static Int32 intYearCode = 0;

        public static String strCashFrom;

        public static String GetYearCode()
        {
            String strYearCode = String.Empty;
            DataTable dtYearCode = clsDataAccess.RunQDTbl("select SFiCode from tbl_Session where FromDate<'" + Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")) + "' and ToDate>'" + Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")) + "'");
            if (dtYearCode.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dtYearCode.Rows[0]["SFiCode"].ToString()))
                {
                    strYearCode = dtYearCode.Rows[0]["SFiCode"].ToString();
                }
            }
            return strYearCode;
        }
        
        public static void GetClassesAccordingToSession(ref ComboBox cmbClass, ref ComboBox cmbYear)
        {
            DataTable dtClass = clsDataAccess.RunQDTbl("select ClassName from tbl_Config_Class where Year='" + cmbYear.Text.Trim() + "' order by ClassId");
            if (dtClass.Rows.Count > 0)
            {
                foreach (DataRow drClass in dtClass.Rows)
                {
                    // cmbFees_Class.Items.Add(drClass["ClassName"].ToString());
                    cmbClass.Items.Add(drClass["ClassName"].ToString());
                }
            }
        }

        public static String GetSession(Int32 intSFiCode)
        {
            String strSession = String.Empty;
            DataTable dtSession = clsDataAccess.RunQDTbl("select Session from tbl_Session where SFiCode='" + intSFiCode + "'");
            if (dtSession.Rows.Count > 0)
            {
                if (!String.IsNullOrEmpty(dtSession.Rows[0]["Session"].ToString()))
                {
                    strSession = dtSession.Rows[0]["Session"].ToString();
                }
            }
            return strSession;
        }

        public static Int32 GetClassId(String strClassName, String strSession)
        {
            Int32 intCLassId = 0;
            if (!String.IsNullOrEmpty(strClassName) && !String.IsNullOrEmpty(strSession))
            {
                DataTable dtClassId = clsDataAccess.RunQDTbl("select ClassId from tbl_Config_Class where ClassName='" + strClassName + "' and Year='" + strSession + "'");
                if (dtClassId.Rows.Count > 0)
                {
                    intCLassId = Convert.ToInt32(dtClassId.Rows[0]["ClassId"]);
                }
            }
            return intCLassId;
        }

        public static String GetClassName(Int32 intClassId)
        {
            String strClassName = String.Empty;
            DataTable dtClass = clsDataAccess.RunQDTbl("select ClassName from tbl_Config_Class where ClassId=" + intClassId + "");
            if (dtClass.Rows.Count > 0)
            {
                if(!String.IsNullOrEmpty(dtClass.Rows[0]["ClassName"].ToString()))
                strClassName = dtClass.Rows[0]["ClassName"].ToString();
            }
            return strClassName;
        }

        public static String FirstLetterCap(String strText)
        {
            String str = String.Empty;
            for (Int32 i = 0; i < strText.Length; i++)
            {
                if (i == 0)
                {
                    str = strText[0].ToString().ToUpper();
                }
                else
                {
                    str += strText[i];
                }
            }
            return str;
        }

        public static Boolean IsNumeric(object objValue)
        {
            Double dummy = new Double();
            String strVal = Convert.ToString(objValue);

            Boolean boolNumeric = Double.TryParse(strVal, System.Globalization.NumberStyles.Any, null, out dummy);
            return boolNumeric;
        }

        public static String GetSection(String strRegNo)
        {
            String strSection = String.Empty;
            DataTable dt = clsDataAccess.RunQDTbl("select Section from tbl_Admission_StudentDetails where RegNo ='" + strRegNo + "'");
            if (dt.Rows.Count > 0)
            {
                strSection = Convert.ToString(dt.Rows[0]["Section"]);
            }
            return strSection;
        }

        public static String[] GetClassSession(Int32 intClassId)
        {
            String[] strArr = new String[2];
            DataTable dt = clsDataAccess.RunQDTbl("select ClassName,Year from tbl_Config_Class where ClassId=" + intClassId + "");
            if (dt.Rows.Count > 0)
            {
                strArr[0] = Convert.ToString(dt.Rows[0]["ClassName"]);
                strArr[1] = Convert.ToString(dt.Rows[0]["Year"]);
            }
            return strArr;
        }

        public static Decimal MakeStringDecZero(String strString)
        {
            Decimal decValue = 0.00m;
            if (!String.IsNullOrEmpty(strString))
            {
                try
                {
                    decValue = Convert.ToDecimal(strString);
                }
                catch
                {
                    ERPMessageBox.ERPMessage.Show("Please Insert Decimal Value");
                }
            }
            return decValue;
        }

        public static Int32 MakeStringIntZero(String strString)
        {
            Int32 intValue = 0;
            if (!String.IsNullOrEmpty(strString))
            {
                if (IsNumeric(strString))
                {
                    try
                    {
                        intValue = Convert.ToInt32(strString);
                    }
                    catch
                    {
                        ERPMessageBox.ERPMessage.Show("Please Insert Integer Value");
                    }
                }
                //try
                //{
                //    decValue = Convert.ToDecimal(strString);
                //}
                //catch
                //{
                //    ERPMessageBox.ERPMessage.Show("Please Insert Decimal Value");
                //}
            }
            return intValue;
        }

        //public static Int32 GetSubjectId(Int32 strClassName, String strSession)
        //{
        //    Int32 intCLassId = 0;
        //    if (!String.IsNullOrEmpty(strClassName) && !String.IsNullOrEmpty(strSession))
        //    {
        //        DataTable dtClassId = clsDataAccess.RunQDTbl("select ClassId from tbl_Config_Class where ClassName='" + strClassName + "' and Year='" + strSession + "'");
        //        if (dtClassId.Rows.Count > 0)
        //        {
        //            intCLassId = Convert.ToInt32(dtClassId.Rows[0]["ClassId"]);
        //        }
        //    }
        //    return intCLassId;
        //}
    }
}
