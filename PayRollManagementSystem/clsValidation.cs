using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ERPMessageBox;
using System.Text.RegularExpressions;

namespace PayRollManagementSystem
{
    public static class clsValidation
    {
        ///<summary>
        ///validates Combobox
        ///</summary>
        ///<param name="cmb">Combobox Name</param>
        ///<param name="strDefaultText">Default text of combobox</param>
        ///<param name="strErrorMsg">Error Message</param>
        ///<returns>True or False</returns>
        ///<remarks>If Validation is Successful it returns true </remarks>
        public static Boolean ValidateComboBox(ComboBox cmb,String  strDefaultText, String strErrorMsg)
        {
            Boolean boolStatus = true;
            if (String.IsNullOrEmpty(cmb.Text.Trim()) || cmb.Text.Trim().ToLower() == strDefaultText || (cmb.Text.Trim() == strDefaultText))
            {
                //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                ERPMessage.Show(strErrorMsg, "ERROR", ERPMessage.MessageBoxButton.EDP_OK, ERPMessage.MessageBoxIcon.EDP_ERROR);
                boolStatus = false;
            }
            return boolStatus;
         }

         ///<summary>
         ///validates Textbox
         ///</summary>
         ///<param name="txt">Textbox Name</param>
         ///<param name="strDefaultText">Default text of Textbox</param>
         ///<param name="strErrorMsg">Error Message</param>
         ///<returns>True or False</returns>
         ///<remarks>If Validation is Successful it returns true </remarks>
        public static Boolean ValidateTextBox(TextBox txt, String strDefaultText, String strErrorMsg)
         {
             Boolean boolStatus = true;
             if ((String.IsNullOrEmpty(txt.Text.Trim())) || (txt.Text.Trim().ToLower() == strDefaultText) || (txt.Text.Trim() == strDefaultText))
             {
                 //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                 ERPMessage.Show(strErrorMsg, "ERROR", ERPMessage.MessageBoxButton.EDP_OK, ERPMessage.MessageBoxIcon.EDP_ERROR);
                 boolStatus = false;
             }
             return boolStatus;
         }


         ///<summary>
         ///validates RichTextbox
         ///</summary>
         ///<param name="rtxt">RichTextbox Name</param>
         ///<param name="strDefaultText">Default text of RichTextbox</param>
         ///<param name="strErrorMsg">Error Message</param>
         ///<returns>True or False</returns>
         ///<remarks>If Validation is Successful it returns true </remarks>
         public static Boolean ValidateRichTextBox(RichTextBox rtxt, String strDefaultText, String strErrorMsg)
         {
             Boolean boolStatus = true;
             if ((String.IsNullOrEmpty(rtxt.Text.Trim())) || (rtxt.Text.Trim().ToLower() == strDefaultText) || (rtxt.Text.Trim() == strDefaultText))
             {
                 //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                 ERPMessage.Show(strErrorMsg, "ERROR", ERPMessage.MessageBoxButton.EDP_OK, ERPMessage.MessageBoxIcon.EDP_ERROR);
                 boolStatus = false;
             }
             return boolStatus;
         }

         ///<summary>
         ///validates Combobox
         ///</summary>
         ///<param name="cmb">Combobox Name</param>
         ///<param name="strDefaultText">Default text of combobox</param>
         ///<param name="strErrorMsg">Error Message</param>
         ///<returns>True or False</returns>
         ///<remarks>If Validation is Successful it returns true </remarks>
         public static Boolean ValidateComboBox(ComboBox cmb, String strDefaultText)
         {
             Boolean boolStatus = true;
             if (String.IsNullOrEmpty(cmb.Text.Trim()) || cmb.Text.Trim().ToLower() == strDefaultText || (cmb.Text.Trim() == strDefaultText))
             {
                 //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                 boolStatus = false;
             }
             return boolStatus;
         }

         ///<summary>
         ///validates Textbox
         ///</summary>
         ///<param name="txt">Textbox Name</param>
         ///<param name="strDefaultText">Default text of Textbox</param>
         ///<param name="strErrorMsg">Error Message</param>
         ///<returns>True or False</returns>
         ///<remarks>If Validation is Successful it returns true </remarks>
         public static Boolean ValidateTextBox(TextBox txt, String strDefaultText)
         {
             Boolean boolStatus = true;
             if ((String.IsNullOrEmpty(txt.Text.Trim())) || (txt.Text.Trim().ToLower() == strDefaultText) || (txt.Text.Trim() == strDefaultText))
             {
                 //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                 boolStatus = false;
             }
             return boolStatus;
         }


         ///<summary>
         ///validates RichTextbox
         ///</summary>
         ///<param name="rtxt">RichTextbox Name</param>
         ///<param name="strDefaultText">Default text of RichTextbox</param>
         ///<param name="strErrorMsg">Error Message</param>
         ///<returns>True or False</returns>
         ///<remarks>If Validation is Successful it returns true </remarks>
         public static Boolean ValidateRichTextBox(RichTextBox rtxt, String strDefaultText)
         {
             Boolean boolStatus = true;
             if ((String.IsNullOrEmpty(rtxt.Text.Trim())) || (rtxt.Text.Trim().ToLower() == strDefaultText) || (rtxt.Text.Trim() == strDefaultText))
             {
                 //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                 boolStatus = false;
             }
             return boolStatus;
         }

         ///<summary>
         ///validates Label
         ///</summary>
         ///<param name="lbl">Label Name</param>
         ///<param name="strDefaultText">Default text of Label</param>
         ///<param name="strErrorMsg">Error Message</param>
         ///<returns>True or False</returns>
         ///<remarks>If Validation is Successful it returns true </remarks>
         public static Boolean ValidateLabel(Label lbl, String strDefaultText)
         {
             Boolean boolStatus = true;
             if ((String.IsNullOrEmpty(lbl.Text.Trim())) || (lbl.Text.Trim().ToLower() == strDefaultText) || (lbl.Text.Trim() == strDefaultText))
             {
                 //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                 boolStatus = false;
             }
             return boolStatus;
         }

         ///<summary>
         ///validates Label
         ///</summary>
         ///<param name="lbl">Label Name</param>
         ///<param name="strDefaultText">Default text of Label</param>
         ///<param name="strErrorMsg">Error Message</param>
         ///<returns>True or False</returns>
         ///<remarks>If Validation is Successful it returns true </remarks>
         public static Boolean ValidateLabel(Label lbl, String strDefaultText, String strErrorMsg)
         {
             Boolean boolStatus = true;
             if ((String.IsNullOrEmpty(lbl.Text.Trim())) || (lbl.Text.Trim().ToLower() == strDefaultText) || (lbl.Text.Trim() == strDefaultText))
             {
                 //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                 ERPMessage.Show(strErrorMsg, "ERROR", ERPMessage.MessageBoxButton.EDP_OK, ERPMessage.MessageBoxIcon.EDP_ERROR);
                 boolStatus = false;
             }
             return boolStatus;
         }


        ///<summary>
        ///Generate AutoIncreament Id
        ///</summary>
        ///<param name="rtxt">RichTextbox Name</param>
        ///<param name="strDefaultText">Default text of RichTextbox</param>
        ///<param name="strErrorMsg">Error Message</param>
        ///<returns>True or False</returns>
        ///<remarks>If Validation is Successful it returns true </remarks>
        //private Int32 GenerateAutoIncreamenID(String strIDName,)
        //connection()
        //adp = New SqlDataAdapter("select max(Student_ID) from tbl_StudentDetails_Addmission", con)
        //ds = New DataSet
        //adp.Fill(ds, "FillID")
        //Dim i As String
        //i = Convert.ToString(ds.Tables("FillID").Rows(0).Item(0))
        //If i = "" Then
        //    txtID.Text = 1001
        //Else
        //    txtID.Text = ds.Tables("FillID").Rows(0).Item(0) + 1
        //End If


        /// <summary>
        /// Generate Year in a combobox with the limit of intStartYear to intEndYear, increase by intIncrement
        /// </summary>
        /// <param name="cmbYear">Name of the combobox</param>
        /// <param name="intStartYear">Starting year</param>
        /// <param name="intEndYear">Ending year</param>
        /// <param name="intIncrement">Increase by</param>
        //public static void GenerateYear(ComboBox cmbYear,Int32 intStartYear, Int32 intEndYear, Int32 intIncrement)
        //{
        //    for (Int32 i = intStartYear; i <= intEndYear; i = i + intIncrement)
        //    {
        //        cmbYear.Items.Add(i + "-" + (i + 1));
        //    }
        //}
        public static void GenerateYear(ComboBox cmbYear, Int32 intStartYear, Int32 intEndYear, Int32 intDecrement)
        {
            for (Int32 i = intEndYear; i >= intStartYear; i = i - intDecrement)
            {
                cmbYear.Items.Add(i + "-" + (i + 1));
            }

            //DataTable dt = clsDataAccess.RunQDTbl("select Session from tbl_Session");
            //for (int i = 0; i <= dt.Rows.Count - 1; i++)
            //{
            //    cmbYear.Items.Add(dt.Rows[i]["Session"]);
            //}
        }

        public static Boolean CompareFromDateToDate(DateTime dtFrom, DateTime dtTo)
        {
            Boolean boolStatus = true;

            if (dtFrom > dtTo)
            {
                boolStatus = false;
            }
            return boolStatus;
        }

        public static Boolean CompareFromDateToDate(DateTime dtFrom, DateTime dtTo, String strErrorMessage)
        {
            Boolean boolStatus = true;

            if (dtFrom > dtTo)
            {
                boolStatus = false;
                //ERPMessageBox.ERPMessage.Show(strErrorMessage);
                ERPMessage.Show(strErrorMessage, "ERROR", ERPMessage.MessageBoxButton.EDP_OK, ERPMessage.MessageBoxIcon.EDP_ERROR);
            }
            return boolStatus;
        }

        ///<summary>
        ///validates EdpCombo
        ///</summary>
        ///<param name="lbl">Edp Combobox Name</param>
        ///<param name="strDefaultText">Default text of Label</param>
        ///<param name="strErrorMsg">Error Message</param>
        ///<returns>True or False</returns>
        ///<remarks>If Validation is Successful it returns true </remarks>
        public static Boolean ValidateEdpCombo(EDPComponent.ComboDialog edpcmb, String strDefaultText, String strErrorMsg)
        {
            Boolean boolStatus = true;
            if ((String.IsNullOrEmpty(edpcmb.Text.Trim())) || (edpcmb.Text.Trim().ToLower() == strDefaultText) || (edpcmb.Text.Trim() == strDefaultText))
            {
                //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                ERPMessage.Show(strErrorMsg, "ERROR", ERPMessage.MessageBoxButton.EDP_OK, ERPMessage.MessageBoxIcon.EDP_ERROR);
                boolStatus = false;
            }
            return boolStatus;
        }



        ///<summary>
        ///validates EdpCombo
        ///</summary>
        ///<param name="lbl">Edp Combobox Name</param>
        ///<param name="strDefaultText">Default text of Label</param>
        ///<param name="strErrorMsg">Error Message</param>
        ///<returns>True or False</returns>
        ///<remarks>If Validation is Successful it returns true </remarks>
        public static Boolean ValidateEdpCombo(EDPComponent.ComboDialog edpcmb, String strDefaultText)
        {
            Boolean boolStatus = true;
            if ((String.IsNullOrEmpty(edpcmb.Text.Trim())) || (edpcmb.Text.Trim().ToLower() == strDefaultText) || (edpcmb.Text.Trim() == strDefaultText))
            {
                //ERPMessageBox.ERPMessage.Show(strErrorMsg);
                //ERPMessage.Show(strErrorMsg, "ERROR", ERPMessage.MessageBoxButton.EDP_OK, ERPMessage.MessageBoxIcon.EDP_ERROR);
                boolStatus = false;
            }
            return boolStatus;
        }

        //public static Boolean IsValidEmail(String email)
        //{
        //    string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";

        //    Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);

        //    bool valid = false;
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        valid = false;
        //    }
        //    else
        //    {

        //        valid = check.IsMatch(email);
        //    }

        //    return valid;
        //}
        public static Boolean AlphabetsOnly(TextBox txt, String strErrMsg,KeyPressEventArgs e)
        {            
            string value = txt.Text;         
              if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar)|| (char.IsWhiteSpace(e.KeyChar))))
                    e.Handled = true;
                else
                    e.Handled = false;
                if (e.Handled)
                {
                    txt.Text = value.Substring(0, value.Length); 
                }
                return e.Handled;
        }

        public static Boolean NumberOnly(TextBox txt, String strErrMsg, KeyPressEventArgs e)
        {
            string value=txt.Text ;
            if (!(Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar)))
                e.Handled = true;
            else
                e.Handled = false;
            if (e.Handled)
            {
                txt.Text =value.Substring (0,value.Length) ;
            }
            return e.Handled;
        }

        public static Boolean NumberOnly(String strText, String strErrMsg, KeyPressEventArgs e)
        {
            string value = strText;
            if (!(Char.IsNumber(e.KeyChar) || Char.IsControl(e.KeyChar)))
                e.Handled = true;
            else
                e.Handled = false;
            if (e.Handled)
            {
                ERPMessage.Show(strErrMsg);
                //txt.Text = value.Substring(0, value.Length);
            }
            return e.Handled;
        }


        public static Boolean OnlyAlphabets(TextBox txt,String strErrmsg)
        {
            Boolean boolMatch = true;

            Regex objAlphaPattern = new Regex("[A-Za-z]+");
            if (!objAlphaPattern.IsMatch(txt.Text))
            {
                ERPMessage.Show(strErrmsg, "ERROR", ERPMessage.MessageBoxButton.EDP_OK, ERPMessage.MessageBoxIcon.EDP_ERROR);
            }
            boolMatch = false;
            return boolMatch;

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

        public static bool IsValidEmail(TextBox txtEmail,String strMsg)
        {
            Boolean boolStatus = false;
            if (clsValidation.ValidateTextBox(txtEmail, ""))
            {
                String inputEmail = txtEmail.Text;
                String strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(inputEmail))
                {
                    boolStatus = true;
                }
                else
                {
                    ERPMessageBox.ERPMessage.Show(strMsg);

                }
            }
            else
            {
                boolStatus = true;
            }
            return boolStatus;
        }        

    }
    
}

