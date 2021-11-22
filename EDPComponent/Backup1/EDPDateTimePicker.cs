using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EDPComponent
{
    [DefaultEvent("DateTime")]
    [Serializable]
    [ComVisibleAttribute(true)]

    public partial class EDPDateTimePicker : UserControl
    {
        Edpcom.EDPCommon edpcom = new Edpcom.EDPCommon();
        //int Selected_Index_ = 0;
        string Selected_Text_ = "";
        Boolean Press_Insert_Key = false;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, Int32 msg, Int32 wParam, Int32 IParam);
        const Int32 WM_lBurronDown = 0x0201;

        public new event KeyEventHandler KeyDown;
        /// <summary>
        /// If you use it by key board.
        /// </summary>
        /// <param name="sender">Pass the sender.</param>
        /// <param name="e">Pass the event arguments.</param>

        public EDPDateTimePicker()
        {
            InitializeComponent();
            txt_DateTime.Text = Convert.ToString(edpcom.GetFromRegisrty("START_DATE", "SOFTWARE\\DATARAM"));// edpcom.CURRCO_SDT.ToShortDateString();
        }

        [Localizable(true)]
        [DispId(-518)]
        [Bindable(true)]
        [Description("Set the Text."), DefaultValue("")]

        public override string Text
        {
            get
            {
                return txt_DateTime.Text;
            }
            set
            {                
                txt_DateTime.Text = value;
            }
        }

        private void txt_DateTime_KeyDown(object sender, KeyEventArgs e)
        {
            KeyEventHandler kh = KeyDown;
            if (kh != null) { kh(this, new KeyEventArgs(e.KeyCode)); }
            this.Invalidate();

            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                e.Handled = true;
            }
            try
            {
                Selected_Text_ = txt_DateTime.Text;

                if (e.KeyCode == Keys.Insert)
                {
                    Press_Insert_Key = true;
                    btn_DateTime_Click(btn_DateTime, e);
                }

                int SL2 = 0;
                if (!Press_Insert_Key)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Left:
                            if (txt_DateTime.SelectionStart == 3 || txt_DateTime.SelectionStart == 6)
                                SL2 = txt_DateTime.SelectionStart - 2;
                            else
                                SL2 = txt_DateTime.SelectionStart - 1;
                            txt_DateTime.Select(SL2, 1);
                            if (txt_DateTime.HideSelection)
                                txt_DateTime.HideSelection = false;
                            else
                                txt_DateTime.HideSelection = true;
                            break;

                        case Keys.Right:
                            if (txt_DateTime.SelectionStart == 1 || txt_DateTime.SelectionStart == 4)
                                SL2 = txt_DateTime.SelectionStart + 2;
                            else
                                SL2 = txt_DateTime.SelectionStart + 1;
                            txt_DateTime.Select(SL2, 1);
                            if (txt_DateTime.HideSelection)
                                txt_DateTime.HideSelection = false;
                            else
                                txt_DateTime.HideSelection = true;
                            break;

                        case Keys.Up:
                            if (txt_DateTime.SelectionStart == 0 || txt_DateTime.SelectionStart == 3)
                            {
                                SL2 = txt_DateTime.SelectionStart;
                                txt_DateTime.Select(SL2, 2);
                            }
                            else if (txt_DateTime.SelectionStart == 1 || txt_DateTime.SelectionStart == 4)
                            {
                                SL2 = txt_DateTime.SelectionStart - 1;
                                txt_DateTime.Select(SL2, 2);
                            }
                            else
                            {
                                SL2 = 6;
                                txt_DateTime.Select(SL2, 4);
                            }

                            if (txt_DateTime.HideSelection)
                                txt_DateTime.HideSelection = false;
                            else
                                txt_DateTime.HideSelection = true;
                            int Selected_Value = Convert.ToInt32(txt_DateTime.SelectedText);
                            Selected_Value = Selected_Value + 1;
                            string[] Str_Char = txt_DateTime.Text.Trim().Split('/');

                            if (Str_Char.Length > 1)
                            {
                                if (SL2 == 0)
                                {
                                    int Year_ = Convert.ToInt32(Str_Char[2]);
                                    int Month_ = Convert.ToInt32(Str_Char[1]);

                                    if (Month_ == 1 || Month_ == 3 || Month_ == 5 || Month_ == 7 || Month_ == 8 || Month_ == 10 || Month_ == 12)
                                    {
                                        if (Selected_Value > 31)
                                            Selected_Value = 1;
                                    }
                                    else if (Month_ == 4 || Month_ == 6 || Month_ == 9 || Month_ == 11)
                                    {
                                        if (Selected_Value > 30)
                                            Selected_Value = 1;
                                    }
                                    else
                                    {
                                        if ((Year_ % 4) == 0 || (Year_ % 100) == 0)
                                        {
                                            if (Selected_Value > 29)
                                                Selected_Value = 1;
                                        }
                                        else
                                            if (Selected_Value > 28)
                                                Selected_Value = 1;
                                    }
                                    string New_Value = "";
                                    if (Selected_Value < 10)
                                        New_Value = "0" + Selected_Value.ToString();
                                    else
                                        New_Value = Selected_Value.ToString();
                                    txt_DateTime.Text = New_Value + "/" + Str_Char[1] + "/" + Str_Char[2];
                                    txt_DateTime.Select(0, 2);
                                }
                                else if (SL2 == 3)
                                {
                                    if (Selected_Value > 12)
                                        Selected_Value = 1;
                                    string New_Value = "";
                                    if (Selected_Value < 10)
                                        New_Value = "0" + Selected_Value.ToString();
                                    else
                                        New_Value = Selected_Value.ToString();

                                    if (Selected_Value == 4 || Selected_Value == 6 || Selected_Value == 9 || Selected_Value == 11)
                                    {
                                        if (Convert.ToInt32(Str_Char[0]) == 31)
                                            txt_DateTime.Text = "30" + "/" + New_Value + "/" + Str_Char[2];
                                        else
                                            txt_DateTime.Text = Str_Char[0] + "/" + New_Value + "/" + Str_Char[2];
                                    }
                                    else if ((Selected_Value == 2) && (Convert.ToInt32(Str_Char[0]) == 30 || Convert.ToInt32(Str_Char[0]) == 31))
                                    {
                                        if ((Convert.ToInt32(Str_Char[2]) % 4) == 0 || (Convert.ToInt32(Str_Char[2]) % 100) == 0)
                                        {
                                            txt_DateTime.Text = "29" + "/" + New_Value + "/" + Str_Char[2];
                                        }
                                        else
                                        {
                                            txt_DateTime.Text = "28" + "/" + New_Value + "/" + Str_Char[2];
                                        }
                                    }
                                    else
                                        txt_DateTime.Text = Str_Char[0] + "/" + New_Value + "/" + Str_Char[2];
                                    txt_DateTime.Select(3, 2);
                                }
                                else
                                {
                                    string New_Value = "";
                                    if (Selected_Value < 10)
                                        New_Value = "0" + Selected_Value.ToString();
                                    else
                                        New_Value = Selected_Value.ToString();
                                    txt_DateTime.Text = Str_Char[0] + "/" + Str_Char[1] + "/" + New_Value;
                                    txt_DateTime.Select(6, 4);
                                }
                            }
                            break;

                        case Keys.Down:
                            if (txt_DateTime.SelectionStart == 0 || txt_DateTime.SelectionStart == 3)
                            {
                                SL2 = txt_DateTime.SelectionStart;
                                txt_DateTime.Select(SL2, 2);
                            }
                            else if (txt_DateTime.SelectionStart == 1 || txt_DateTime.SelectionStart == 4)
                            {
                                SL2 = txt_DateTime.SelectionStart - 1;
                                txt_DateTime.Select(SL2, 2);
                            }
                            else
                            {
                                SL2 = 6;
                                txt_DateTime.Select(SL2, 4);
                            }

                            if (txt_DateTime.HideSelection)
                                txt_DateTime.HideSelection = false;
                            else
                                txt_DateTime.HideSelection = true;

                            Selected_Value = Convert.ToInt32(txt_DateTime.SelectedText);
                            Selected_Value = Selected_Value - 1;
                            string New_Value_ = "";
                            if (Selected_Value < 10)
                                New_Value_ = "0" + Selected_Value.ToString();
                            else
                                New_Value_ = Selected_Value.ToString();
                            string[] Str_Char_D = txt_DateTime.Text.Trim().Split('/');

                            if (Str_Char_D.Length > 1)
                            {
                                if (SL2 == 0)
                                {
                                    int Year_ = Convert.ToInt32(Str_Char_D[2]);
                                    int Month_ = Convert.ToInt32(Str_Char_D[1]);

                                    if (Month_ == 1 || Month_ == 3 || Month_ == 5 || Month_ == 7 || Month_ == 8 || Month_ == 10 || Month_ == 12)
                                    {
                                        if (Selected_Value < 1)
                                            Selected_Value = 31;
                                    }
                                    else if (Month_ == 4 || Month_ == 6 || Month_ == 9 || Month_ == 11)
                                    {
                                        if (Selected_Value < 1)
                                            Selected_Value = 30;
                                    }
                                    else
                                    {
                                        if ((Year_ % 4) == 0 || (Year_ % 100) == 0)
                                        {
                                            if (Selected_Value < 1)
                                                Selected_Value = 29;
                                        }
                                        else
                                            if (Selected_Value < 1)
                                                Selected_Value = 28;
                                    }
                                    string New_Value = "";
                                    if (Selected_Value < 10)
                                        New_Value = "0" + Selected_Value.ToString();
                                    else
                                        New_Value = Selected_Value.ToString();
                                    txt_DateTime.Text = New_Value + "/" + Str_Char_D[1] + "/" + Str_Char_D[2];
                                    txt_DateTime.Select(0, 2);
                                }
                                else if (SL2 == 3)
                                {
                                    if (Selected_Value <= 0)
                                        Selected_Value = 12;
                                    if (Selected_Value < 10)
                                        New_Value_ = "0" + Selected_Value.ToString();
                                    else
                                        New_Value_ = Selected_Value.ToString();

                                    if (Selected_Value == 4 || Selected_Value == 6 || Selected_Value == 9 || Selected_Value == 11)
                                    {
                                        if (Convert.ToInt32(Str_Char_D[0]) == 31)
                                            txt_DateTime.Text = "30" + "/" + New_Value_ + "/" + Str_Char_D[2];
                                        else
                                            txt_DateTime.Text = Str_Char_D[0] + "/" + New_Value_ + "/" + Str_Char_D[2];
                                    }
                                    else if ((Selected_Value == 2) && (Convert.ToInt32(Str_Char_D[0]) == 30 || Convert.ToInt32(Str_Char_D[0]) == 31))
                                    {
                                        if ((Convert.ToInt32(Str_Char_D[2]) % 4) == 0 || (Convert.ToInt32(Str_Char_D[2]) % 100) == 0)
                                        {
                                            txt_DateTime.Text = "29" + "/" + New_Value_ + "/" + Str_Char_D[2];
                                        }
                                        else
                                        {
                                            txt_DateTime.Text = "28" + "/" + New_Value_ + "/" + Str_Char_D[2];
                                        }
                                    }
                                    else
                                        txt_DateTime.Text = Str_Char_D[0] + "/" + New_Value_ + "/" + Str_Char_D[2];
                                    txt_DateTime.Select(3, 2);
                                }
                                else
                                {
                                    txt_DateTime.Text = Str_Char_D[0] + "/" + Str_Char_D[1] + "/" + New_Value_;
                                    txt_DateTime.Select(6, 4);
                                }
                            }
                            break;
                    }
                }
            }
            catch { }
        }

        private void txt_DateTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool chk_Char = false;
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar.ToString() == "\b")
                {
                    e.Handled = true;
                }

                string[] Str_Char = txt_DateTime.Text.Trim().Split('/');
                if (Str_Char.Length > 1)
                {
                    txt_DateTime.MaxLength = 10;
                }
            }
            catch { }
        }

        private void txt_DateTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int SL2 = 0;
                if ((txt_DateTime.SelectionStart == 2) || (txt_DateTime.SelectionStart == 5))
                    SL2 = txt_DateTime.SelectionStart + 1;
                else
                    SL2 = txt_DateTime.SelectionStart;
                string[] Str_Char = txt_DateTime.Text.Trim().Split('/');
                if (Str_Char.Length > 2)
                {
                    if (Convert.ToInt32(Str_Char[1]) > 12)
                        txt_DateTime.Text = Selected_Text_;
                }

                if (Convert.ToInt32(Str_Char[1]) == 1 || Convert.ToInt32(Str_Char[1]) == 3 || Convert.ToInt32(Str_Char[1]) == 5 || Convert.ToInt32(Str_Char[1]) == 7 || Convert.ToInt32(Str_Char[1]) == 8 || Convert.ToInt32(Str_Char[1]) == 10 || Convert.ToInt32(Str_Char[1]) == 12)
                {
                    if(Convert.ToInt32(Str_Char[0])>31)
                        txt_DateTime.Text = Selected_Text_;
                }
                else if (Convert.ToInt32(Str_Char[1]) == 4 || Convert.ToInt32(Str_Char[1]) == 6 || Convert.ToInt32(Str_Char[1]) == 9 || Convert.ToInt32(Str_Char[1]) == 11)
                {
                    if (Convert.ToInt32(Str_Char[0]) > 30)
                        txt_DateTime.Text = Selected_Text_;
                }
                else
                {
                    if ((Convert.ToInt32(Str_Char[2]) % 4) == 0 || (Convert.ToInt32(Str_Char[2]) % 100) == 0)
                    {
                        if (Convert.ToInt32(Str_Char[0]) > 29)
                            txt_DateTime.Text = Selected_Text_;
                    }
                    else
                    {
                        if (Convert.ToInt32(Str_Char[0]) > 28)
                            txt_DateTime.Text = Selected_Text_;
                    }
                }
                if (Convert.ToInt32(Str_Char[2]) < 1900)
                    txt_DateTime.Text = Selected_Text_;              

                if (Str_Char[0].Length == 1)
                    txt_DateTime.Text = Str_Char[0] + " " + "/" + Str_Char[1] + "/" + Str_Char[2];
                if (Str_Char[1].Length == 1)
                    txt_DateTime.Text = Str_Char[0] + "/" + Str_Char[1] + " " + "/" + Str_Char[2];
                if (Str_Char[2].Length == 1)
                    txt_DateTime.Text = Str_Char[0] + "/" + Str_Char[1] + "/" + Str_Char[2] + "   ";

                txt_DateTime.Select(SL2, 1);                
            }
            catch { }
        }

        private void txt_DateTime_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int SL2 = 0;
                if (txt_DateTime.SelectionStart == 2 || txt_DateTime.SelectionStart == 5)
                    SL2 = txt_DateTime.SelectionStart + 1;
                else
                    SL2 = txt_DateTime.SelectionStart;
                txt_DateTime.Select(SL2, 1);
            }
            catch { }
        }

        private void btn_DateTime_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 x = dateTimePicker1.Width - 10;
                Int32 y = dateTimePicker1.Height / 2;
                Int32 lParam = x + y * 0x00010000;
                PostMessage(dateTimePicker1.Handle, WM_lBurronDown, 1, lParam);
                //btn_DateTime.Visible = false;
            }
            catch { }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txt_DateTime.Text = dateTimePicker1.Value.ToShortDateString();            
        }

        private void txt_DateTime_Leave(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(txt_DateTime.Text);
            }
            catch { EDPMessageBox.EDPMessage.Show("Date is not Accepted."); txt_DateTime.Text = edpcom.CURRCO_SDT.ToShortDateString(); }

            try
            {
                string[] Str_Char = txt_DateTime.Text.Trim().Split('/');
                if (Str_Char.Length > 2)
                {
                    if (Str_Char[0].Trim().Length == 1)
                        txt_DateTime.Text = "0" + Str_Char[0].Trim() + "/" + Str_Char[1] + "/" + Str_Char[2];
                    if (Str_Char[1].Trim().Length == 1)
                        txt_DateTime.Text = Str_Char[0] + "/" + "0" + Str_Char[1].Trim() + "/" + Str_Char[2];
                    if (Str_Char[2].Trim().Length == 1)
                        txt_DateTime.Text = Str_Char[0] + "/" + Str_Char[1] + "/" + "000" + Str_Char[2].Trim();
                }
            }
            catch { }

            if (Convert.ToDateTime(txt_DateTime.Text) > edpcom.CURRCO_EDT)
                txt_DateTime.Text = edpcom.CURRCO_EDT.ToShortDateString();
            if(Convert.ToDateTime(txt_DateTime.Text)<edpcom.CURRCO_SDT)
                txt_DateTime.Text = edpcom.CURRCO_SDT.ToShortDateString();

            txt_DateTime.ForeColor = Color.Maroon;
            txt_DateTime.BackColor = Color.SeaShell;
            txt_DateTime.DeselectAll();

            edpcom.SetInRegistry(txt_DateTime.Text, "START_DATE", "SOFTWARE\\DATARAM");
        }

        private void txt_DateTime_Enter(object sender, EventArgs e)
        {
            txt_DateTime.Focus();
            txt_DateTime.ForeColor = System.Drawing.SystemColors.MenuText;
            txt_DateTime.BackColor = System.Drawing.SystemColors.Window;            
        }
        
        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            Press_Insert_Key = false;           
            txt_DateTime.Focus();
        }

        private void EDPDateTimePicker_Resize(object sender, EventArgs e)
        {
            btn_DateTime.Location = new Point(this.Width - btn_DateTime.Width, 1);           
        }

        private void EDPDateTimePicker_Enter(object sender, EventArgs e)
        {
            txt_DateTime.Focus();
            txt_DateTime.Select(0, 1);
        }

    }
}
