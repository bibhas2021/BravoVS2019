using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using Edpcom;
using EDPComponent;
using EDPMessageBox.Properties;
namespace EDPMessageBox
{    
    public sealed class EDPMessage
    {
        private static int ButtonKeydownFlag;
        private static Form frm;
        private static Label HeaderCaption;
        private static Label B3;
        private static Label B2;
        private static Label B4;
        private static Label B1;
        private static Label Picture;
        private static Label Text;
        private static Label BtnClose;
        private static Label Header;
        private static ToolTip TT;
        private static EDPComponent.VistaButton OK;
        private static EDPComponent.VistaButton CANCEL;
        private static EDPComponent.VistaButton YES;
        private static EDPComponent.VistaButton NO;
        private static EDPComponent.VistaButton ABORT;
        private static EDPComponent.VistaButton RETRY;
        private static EDPComponent.VistaButton IGNORE;
        private static CheckBox Checked;
        private static string Result, MCaption, MText, CheckResult;
        public enum MessageBoxIcon
        {
            EDP_OK,
            EDP_QUESTION,
            EDP_ERROR,
            EDP_CANCEL,
            EDP_INFORMATION,
            EDP_UNKNOWN,
            EDP_WARNING,
            EDP_SAVE,
            EDP_USB,
            EDP_PRINTER,
            EDP_SETTINGS,
            EDP_GLOBAL,
            EDP_CLEAR,
            EDP_DATABASE,
            EDP_LOCK,
            EDP_UNLOCK,
            EDP_MOUSE,
            EDP_SEARCH,
            EDP_USERS
        }
        public enum MessageBoxButton
        {
           EDP_OK,    
           EDP_OK_CANCEL,
           EDP_YES_NO,
           EDP_RETRY_CANCEL,
           EDP_ABORT_RETRY_IGNORE,
           EDP_YES_NO_CANCEL
        }       
        private static void Initialize(int flag)
        {
            ButtonKeydownFlag = 0;
            frm = new Form();
            HeaderCaption = new Label();
            B1 = new Label();
            B2 = new Label();
            B3 = new Label();
            B4 = new Label();
            Picture = new Label();
            Text = new Label();
            BtnClose = new Label();
            Header = new Label();
            TT = new ToolTip();
            Checked = new CheckBox();
            OK = new VistaButton();
            CANCEL = new VistaButton();
            YES = new VistaButton();
            NO = new VistaButton();
            ABORT = new VistaButton();
            RETRY = new VistaButton();
            IGNORE = new VistaButton();
            frm.Controls.Clear();
            frm.ShowIcon = false;
            frm.ShowInTaskbar = false;
            frm.AccessibleRole = AccessibleRole.Default;
            frm.AutoScaleMode = AutoScaleMode.Font;
            frm.AutoValidate = AutoValidate.EnablePreventFocusChange;
            frm.CausesValidation = true;
            frm.Enabled = true;
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.Text = "";
            frm.ControlBox = false;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.KeyPreview = true;            
            HeaderCaption.TextAlign = ContentAlignment.MiddleLeft;
            HeaderCaption.Name = "Caption";
            HeaderCaption.Dock = DockStyle.Top;
            HeaderCaption.AutoSize = false;
            HeaderCaption.Height = 24;
            HeaderCaption.Font = new Font("Tahoma",9, FontStyle.Bold);
            HeaderCaption.Image = Resources.TitleBar;
            //HeaderCaption.ForeColor = System.Drawing.Color.Navy;
            //HeaderCaption.Text = MessageBoxCaption;
            Header.TextAlign = ContentAlignment.MiddleLeft;
            Header.Name = "Caption1";
            Header.AutoSize = true;
            Header.Height = 24;
            Header.Font = new Font("Tahoma", 9, FontStyle.Bold);
            Header.ForeColor = System.Drawing.Color.Navy;
            Header.Text = MessageBoxCaption;
            Header.Image = Resources.TitleBar;
            Header.Location = new System.Drawing.Point(HeaderCaption.Location.X, HeaderCaption.Location.Y + 2);                       
            frm.Load += new EventHandler(Form_Load);
            frm.KeyDown += new KeyEventHandler(Form_Keydown);
            BtnClose.Click += new EventHandler(Close_msg);
            BtnClose.MouseHover += new EventHandler(BtnClose_MouseHover);
            BtnClose.MouseLeave += new EventHandler(BtnClose_MouseLeave);
            Checked.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);           
            Checked.AutoCheck = true;
            Checked.UseMnemonic = true;
            frm.Controls.Add(HeaderCaption);
            HeaderCaption.Controls.Add(Header);
            #region Border
            // 
            // B3
            //             
            B3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            B3.Dock = System.Windows.Forms.DockStyle.Bottom;
            B3.Name = "B3";
            B3.AutoSize = false;
            B3.Height = 3;
            frm.Controls.Add(B3);
            // 
            // B2
            //            
            B2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            B2.Dock = System.Windows.Forms.DockStyle.Right;
            B2.Name = "B2";
            B2.AutoSize = false;
            B2.Width = 3;
            frm.Controls.Add(B2);
            // 
            // B4
            //             
            B4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            B4.Dock = System.Windows.Forms.DockStyle.Left;
            B4.Name = "B4";
            B4.AutoSize = false;
            B4.Width = 3;
            frm.Controls.Add(B4);
            // 
            // B1
            //            
            B1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            B1.Dock = System.Windows.Forms.DockStyle.Top;
            B1.Name = "B1";
            B1.AutoSize = false;
            B1.Height = 3;
            frm.Controls.Add(B1);
            #endregion
            Picture.AutoSize = false;
            Picture.Name = "PictureBox";
            Picture.Location = new System.Drawing.Point(12, 31);
            Picture.Size = new System.Drawing.Size(46, 43);
            Picture.Text = "";
            frm.Controls.Add(Picture);
            Text.Name = "MessageText";
            Text.AutoSize = true;            
            if (flag == 0)
            {
                Text.Location = new Point(31, 40);
            }
            else
            {
                Text.Location = new System.Drawing.Point(78, 55);
            }
            Text.Font = new Font("Tahoma",8);
            Text.Text = MessageBody;            
            frm.Controls.Add(Text);
            BtnClose.Size = new System.Drawing.Size(21, 22);
            BtnClose.AutoSize = false;
            BtnClose.Text = "";
            BtnClose.Image = Resources.MinimizeIcon;            
            TT.ForeColor = Color.Blue;
            TT.SetToolTip(BtnClose, "Close");
            HeaderCaption.Controls.Add(BtnClose);
            frm.Width = Text.Width + 58;
            if (Header.Width >= Text.Width)
            {
                frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                if (flag == 0)
                {
                    Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                }
                else
                {
                    Text.Location = new System.Drawing.Point(78, 55);
                }
            }
            if (frm.Width <= 110)
            {
                frm.Width = 120;
                if (Text.Text.Length <= 2)
                {
                    if (flag == 0)
                    {
                        Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                    }
                    else
                    {
                        Text.Location = new System.Drawing.Point(58, 55);
                    }
                }
                else
                {
                    if (flag == 0)
                    {
                        Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                    }
                    else
                    {
                        Text.Location = new System.Drawing.Point(58, 55);
                    }
                }
            }                       
        }        
        public static void Show(string message)
        {
            MessageBody = message;
            MessageBoxCaption = Application.ProductName.ToString();
            Initialize(0);           
            OK.ButtonText = "OK";            
            OK.BaseColor = Color.LightGreen;
            OK.ForeColor = Color.Black;
            OK.GlowColor = Color.White;
            OK.ButtonColor = Color.CornflowerBlue;
            OK.Focus();
            TT.SetToolTip(OK, OK.ButtonText);
            OK.Size = new Size(72, 30);            
            OK.Location = new Point(frm.Width / 2 - (OK.Width / 2), Text.Location.Y + Text.Size.Height + 14);
            frm.Height = OK.Location.Y + OK.Size.Height + 15;
            OK.Click += new EventHandler(Button_OK);
            frm.Controls.Add(OK);            
            Picture.SendToBack();
            Picture.Image = null;            
            BtnClose.Location = new System.Drawing.Point(HeaderCaption.Width - 20, 2);            
            frm.ShowDialog();
            //frm.Show();
        }
        public static void Show(string message, string Title)
        {
            MessageBoxCaption = Title;
            MessageBody = message;
            Initialize(0);
            OK.ButtonText = "OK";
            OK.BaseColor = Color.LightGreen;
            OK.GlowColor = Color.White;
            OK.ForeColor = Color.Black;
            OK.ButtonColor = Color.CornflowerBlue;            
            OK.Size = new Size(72, 30);
            TT.SetToolTip(OK, OK.ButtonText);
            OK.Location = new Point(frm.Width / 2 - (OK.Width / 2), Text.Location.Y + Text.Size.Height + 14);
            frm.Height = OK.Location.Y + OK.Size.Height + 15;
            OK.Click += new EventHandler(Button_OK);
            frm.Controls.Add(OK);
            OK.Focus();
            Picture.SendToBack();
            Picture.Image = null;
            BtnClose.Location = new System.Drawing.Point(HeaderCaption.Width - 20, 2);            
            frm.ShowDialog();
            //frm.Show();
        }
        public static void Show(string message, string Title, Enum MessageboxButton)
        {
            MessageBoxCaption = Title;
            MessageBody = message;
            Initialize(0);
            ButtonGen(MessageboxButton, 0);            
            BtnClose.Location = new System.Drawing.Point(HeaderCaption.Width - 20, 2);
            Picture.SendToBack();
            Picture.Image = null;
            frm.ShowDialog();
            //frm.Show();
        }
        private static void ButtonGen(Enum MessageboxButton, int flag, bool showCheck)
        {
            try
            {
                #region EDP_OK
                if (MessageboxButton.ToString() == "EDP_OK")
                {
                    OK.ButtonText = "OK";
                    OK.BaseColor = Color.LightGreen;
                    OK.GlowColor = Color.White;
                    OK.ForeColor = Color.Black;
                    OK.ButtonColor = Color.CornflowerBlue;
                    OK.TabIndex = 0;
                    OK.Size = new Size(72, 30);
                    OK.Font = new Font("Tahoma",9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }                    
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    OK.Location = new Point(frm.Width / 2 - (OK.Width / 2), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = OK.Location.Y + OK.Size.Height + 15;
                    OK.Click += new EventHandler(Button_OK);
                    ButtonKeydownFlag = 1;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    TT.SetToolTip(OK, OK.ButtonText);
                    frm.Controls.Add(OK);                   
                    if (showCheck)
                    {
                        Checked.Text = "&Do not show this message";
                        Checked.Location = new Point(12, OK.Location.Y + OK.Height + 10);
                        Checked.TabIndex = 1;                        
                        frm.Controls.Add(Checked);
                        Checked.AutoSize = true;                        
                        frm.Height = frm.Height + Checked.Height + 2;
                        if (frm.Width <= Checked.Width)
                        {
                            if (flag == 0)
                            {
                                Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                            }
                            else
                            {
                                Text.Location = new System.Drawing.Point(78, 55);
                            }
                            frm.Width = Checked.Width + 20;
                            OK.Location = new Point(frm.Width / 2 - (OK.Width / 2), Text.Location.Y + Text.Size.Height + 14);
                        }
                        if (frm.Width <= 170)
                        {
                            if (flag == 0)
                            {
                                Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                            }
                            else
                            {
                                Text.Location = new System.Drawing.Point(78, 55);
                            }
                            frm.Width = Checked.Width + 20;
                            OK.Location = new Point(frm.Width / 2 - (OK.Width / 2), Text.Location.Y + Text.Size.Height + 14);
                        }
                    }
                }
                #endregion
                #region EDP_OK_CANCEL
                else if (MessageboxButton.ToString() == "EDP_OK_CANCEL")
                {
                    OK.ButtonText = "OK";
                    OK.BaseColor = Color.LightGreen;
                    OK.GlowColor = Color.White;
                    OK.ForeColor = Color.Black;
                    OK.ButtonColor = Color.CornflowerBlue;                   
                    OK.Size = new Size(72, 30);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    OK.Location = new Point(frm.Width / 2 - (OK.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = OK.Location.Y + OK.Size.Height + 15;
                    OK.Click += new EventHandler(Button_OK);
                    ButtonKeydownFlag = 2;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    TT.SetToolTip(OK, OK.ButtonText);
                    frm.Controls.Add(OK);
                    CANCEL.ButtonText = "Cancel";
                    CANCEL.BaseColor = Color.LightGreen;
                    CANCEL.GlowColor = Color.White;
                    CANCEL.ForeColor = Color.Black;
                    CANCEL.ButtonColor = Color.CornflowerBlue;                    
                    CANCEL.Size = new Size(72, 30);
                    TT.SetToolTip(CANCEL, CANCEL.ButtonText);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    CANCEL.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = CANCEL.Location.Y + CANCEL.Size.Height + 15;
                    int TwobuttonSize = OK.Width + 11 + CANCEL.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        OK.Location = new Point(frm.Width / 2 - (OK.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        CANCEL.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                    CANCEL.Click += new EventHandler(Button_Cancel);
                    frm.Controls.Add(CANCEL);
                    if (flag == 0)
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, OK.Location.Y + OK.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                    else
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, OK.Location.Y + OK.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                }
                #endregion
                #region EDP_YES_NO
                else if (MessageboxButton.ToString() == "EDP_YES_NO")
                {
                    YES.ButtonText = "Yes";
                    YES.BaseColor = Color.LightGreen;
                    YES.GlowColor = Color.White;
                    YES.ForeColor = Color.Black;                    
                    TT.SetToolTip(YES, YES.ButtonText);
                    YES.ButtonColor = Color.CornflowerBlue;
                    YES.Size = new Size(72, 30);
                    YES.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    YES.Location = new Point(frm.Width / 2 - (YES.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = YES.Location.Y + YES.Size.Height + 15;
                    YES.Click += new EventHandler(Button_Yes);
                    ButtonKeydownFlag = 3;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(YES);
                    NO.ButtonText = "No";
                    NO.BaseColor = Color.LightGreen;
                    NO.GlowColor = Color.White;
                    NO.ForeColor = Color.Black;
                    TT.SetToolTip(NO, NO.ButtonText);
                    NO.ButtonColor = Color.CornflowerBlue;                    
                    NO.Size = new Size(72, 30);
                    NO.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    NO.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = NO.Location.Y + NO.Size.Height + 15;
                    int TwobuttonSize = YES.Width + 11 + NO.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        YES.Location = new Point(frm.Width / 2 - (YES.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        NO.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                    NO.Click += new EventHandler(Button_No);
                    frm.Controls.Add(NO);
                    if (flag == 0)
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, YES.Location.Y + YES.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                    else
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, YES.Location.Y + YES.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                }
                #endregion
                #region EDP_RETRY_CANCEL
                else if (MessageboxButton.ToString() == "EDP_RETRY_CANCEL")
                {
                    RETRY.ButtonText = "Retry";
                    RETRY.BaseColor = Color.LightGreen;
                    RETRY.GlowColor = Color.White;
                    RETRY.ForeColor = Color.Black;
                    TT.SetToolTip(RETRY, RETRY.ButtonText);
                    RETRY.ButtonColor = Color.CornflowerBlue;
                    RETRY.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    RETRY.Size = new Size(72, 30);
                    RETRY.Location = new Point(frm.Width / 2 - (RETRY.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = RETRY.Location.Y + RETRY.Size.Height + 15;
                    RETRY.Click += new EventHandler(Button_Retry);
                    ButtonKeydownFlag = 4;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(RETRY);
                    CANCEL.ButtonText = "Cancel";
                    CANCEL.BaseColor = Color.LightGreen;
                    CANCEL.GlowColor = Color.White;
                    CANCEL.ForeColor = Color.Black;
                    TT.SetToolTip(CANCEL, CANCEL.ButtonText);
                    CANCEL.ButtonColor = Color.CornflowerBlue;                    
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    CANCEL.Size = new Size(72, 30);
                    CANCEL.Font = new Font("Tahoma", 9);
                    CANCEL.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = CANCEL.Location.Y + CANCEL.Size.Height + 15;
                    int TwobuttonSize = RETRY.Width + 11 + CANCEL.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        RETRY.Location = new Point(frm.Width / 2 - (RETRY.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        CANCEL.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                    CANCEL.Click += new EventHandler(Button_Cancel);
                    frm.Controls.Add(CANCEL);
                    if (flag == 0)
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, RETRY.Location.Y + RETRY.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                    else
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, RETRY.Location.Y + RETRY.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                }
                #endregion
                #region EDP_YES_NO_CANCEL
                else if (MessageboxButton.ToString() == "EDP_YES_NO_CANCEL")
                {
                    NO.ButtonText = "No";
                    NO.BaseColor = Color.LightGreen;
                    NO.GlowColor = Color.White;
                    NO.ForeColor = Color.Black;
                    TT.SetToolTip(NO, NO.ButtonText);
                    NO.ButtonColor = Color.CornflowerBlue;                    
                    NO.Size = new Size(72, 30);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    NO.Location = new Point(frm.Width / 2 - (NO.Width / 2), Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = NO.Location.Y + NO.Size.Height + 15;
                    NO.Click += new EventHandler(Button_No);
                    ButtonKeydownFlag = 5;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(NO);
                    CANCEL.ButtonText = "Cancel";
                    CANCEL.BaseColor = Color.LightGreen;
                    CANCEL.GlowColor = Color.White;
                    CANCEL.ForeColor = Color.Black;
                    TT.SetToolTip(CANCEL, CANCEL.ButtonText);
                    CANCEL.ButtonColor = Color.CornflowerBlue;                    
                    CANCEL.Size = new Size(72, 30);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    CANCEL.Location = new Point(NO.Location.X + NO.Width + 11, Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = CANCEL.Location.Y + CANCEL.Size.Height + 15;
                    CANCEL.Click += new EventHandler(Button_Cancel);
                    frm.Controls.Add(CANCEL);
                    YES.ButtonText = "Yes";
                    YES.BaseColor = Color.LightGreen;
                    YES.GlowColor = Color.White;
                    YES.ForeColor = Color.Black;
                    TT.SetToolTip(YES, YES.ButtonText);
                    YES.ButtonColor = Color.CornflowerBlue;                    
                    YES.Size = new Size(72, 30);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    YES.Location = new Point(NO.Location.X - (YES.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = YES.Location.Y + YES.Size.Height + 15;
                    YES.Click += new EventHandler(Button_Yes);
                    frm.Controls.Add(YES);
                    int TwobuttonSize = YES.Width + 11 + NO.Width + 11 + CANCEL.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        NO.Location = new Point(frm.Width / 2 - (NO.Width / 2), Text.Location.Y + Text.Size.Height + 14); ;
                        CANCEL.Location = new Point(NO.Location.X + NO.Width + 11, Text.Location.Y + Text.Size.Height + 14);
                        YES.Location = new Point(NO.Location.X - (YES.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                    if (flag == 0)
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, YES.Location.Y + YES.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                    else
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, YES.Location.Y + YES.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                }
                #endregion
                #region EDP_ABORT_RETRY_IGNORE
                else if (MessageboxButton.ToString() == "EDP_ABORT_RETRY_IGNORE")
                {
                    RETRY.ButtonText = "Retry";
                    RETRY.BaseColor = Color.LightGreen;
                    RETRY.GlowColor = Color.White;
                    RETRY.ForeColor = Color.Black;
                    TT.SetToolTip(RETRY, RETRY.ButtonText);
                    RETRY.ButtonColor = Color.CornflowerBlue;                    
                    RETRY.Size = new Size(72, 30);
                    RETRY.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    RETRY.Location = new Point(frm.Width / 2 - (RETRY.Width / 2), Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = RETRY.Location.Y + RETRY.Size.Height + 15;
                    RETRY.Click += new EventHandler(Button_Retry);
                    ButtonKeydownFlag = 6;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(RETRY);
                    IGNORE.ButtonText = "Ignore";
                    IGNORE.BaseColor = Color.LightGreen;
                    IGNORE.GlowColor = Color.White;
                    IGNORE.ForeColor = Color.Black;
                    TT.SetToolTip(IGNORE, IGNORE.ButtonText);
                    IGNORE.ButtonColor = Color.CornflowerBlue;                    
                    IGNORE.Size = new Size(72, 30);
                    IGNORE.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    IGNORE.Location = new Point(RETRY.Location.X + RETRY.Width + 11, Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = IGNORE.Location.Y + IGNORE.Size.Height + 15;
                    IGNORE.Click += new EventHandler(Button_Ignore);
                    frm.Controls.Add(IGNORE);
                    ABORT.ButtonText = "Abort";
                    ABORT.BaseColor = Color.LightGreen;
                    ABORT.GlowColor = Color.White;
                    ABORT.ForeColor = Color.Black;
                    TT.SetToolTip(ABORT, ABORT.ButtonText);
                    ABORT.ButtonColor = Color.CornflowerBlue;                    
                    ABORT.Size = new Size(72, 30);
                    ABORT.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    ABORT.Location = new Point(RETRY.Location.X - (ABORT.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = ABORT.Location.Y + ABORT.Size.Height + 15;
                    ABORT.Click += new EventHandler(Button_Abort);
                    frm.Controls.Add(ABORT);
                    int TwobuttonSize = ABORT.Width + 11 + RETRY.Width + 11 + IGNORE.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        RETRY.Location = new Point(frm.Width / 2 - (RETRY.Width / 2), Text.Location.Y + Text.Size.Height + 14); ;
                        IGNORE.Location = new Point(RETRY.Location.X + RETRY.Width + 11, Text.Location.Y + Text.Size.Height + 14);
                        ABORT.Location = new Point(RETRY.Location.X - (ABORT.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                    if (flag == 0)
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, ABORT.Location.Y + ABORT.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                    else
                    {
                        if (showCheck)
                        {
                            Checked.Text = "&Do not show this message";
                            Checked.Location = new Point(12, ABORT.Location.Y + ABORT.Height + 10);
                            frm.Controls.Add(Checked);
                            Checked.AutoSize = true;
                            frm.Height = frm.Height + Checked.Height + 2;
                        }
                    }
                }
                #endregion
            }
            catch
            { }
        }
        private static void ButtonGen(Enum MessageboxButton, int flag)
        {
            try
            {
                #region EDP_OK
                if (MessageboxButton.ToString() == "EDP_OK")
                {
                    OK.ButtonText = "OK";
                    OK.BaseColor = Color.LightGreen;
                    OK.GlowColor = Color.White;
                    OK.ForeColor = Color.Black;
                    OK.ButtonColor = Color.CornflowerBlue;                    
                    OK.Size = new Size(72, 30);
                    OK.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            frm.Width = frm.Width + 50;
                            Text.Location = new System.Drawing.Point(68, 55);
                        }
                    }
                    OK.Location = new Point(frm.Width / 2 - (OK.Width / 2), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = OK.Location.Y + OK.Size.Height + 15;
                    OK.Click += new EventHandler(Button_OK);
                    ButtonKeydownFlag = 1;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    TT.SetToolTip(OK, OK.ButtonText);
                    frm.Controls.Add(OK);
                }
                #endregion
                #region EDP_OK_CANCEL
                else if (MessageboxButton.ToString() == "EDP_OK_CANCEL")
                {
                    OK.ButtonText = "OK";
                    OK.BaseColor = Color.LightGreen;
                    OK.GlowColor = Color.White;
                    OK.ForeColor = Color.Black;
                    OK.ButtonColor = Color.CornflowerBlue;                    
                    OK.Size = new Size(72, 30);
                    OK.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    OK.Location = new Point(frm.Width / 2 - (OK.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = OK.Location.Y + OK.Size.Height + 15;
                    OK.Click += new EventHandler(Button_OK);
                    TT.SetToolTip(OK, OK.ButtonText);
                    frm.Controls.Add(OK);
                    CANCEL.ButtonText = "Cancel";
                    CANCEL.BaseColor = Color.LightGreen;
                    CANCEL.GlowColor = Color.White;
                    CANCEL.ForeColor = Color.Black;
                    CANCEL.ButtonColor = Color.CornflowerBlue;                    
                    CANCEL.Size = new Size(72, 30);
                    CANCEL.Font = new Font("Tahoma", 9);
                    TT.SetToolTip(CANCEL, CANCEL.ButtonText);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    CANCEL.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = CANCEL.Location.Y + CANCEL.Size.Height + 15;
                    int TwobuttonSize = OK.Width + 11 + CANCEL.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        OK.Location = new Point(frm.Width / 2 - (OK.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        CANCEL.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                    CANCEL.Click += new EventHandler(Button_Cancel);
                    ButtonKeydownFlag = 2;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(CANCEL);
                }
                #endregion
                #region EDP_YES_NO
                else if (MessageboxButton.ToString() == "EDP_YES_NO")
                {
                    YES.ButtonText = "Yes";
                    YES.BaseColor = Color.LightGreen;
                    YES.GlowColor = Color.White;
                    YES.ForeColor = Color.Black;
                    TT.SetToolTip(YES, YES.ButtonText);
                    YES.ButtonColor = Color.CornflowerBlue;                    
                    YES.Size = new Size(72, 30);
                    YES.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    YES.Location = new Point(frm.Width / 2 - (YES.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = YES.Location.Y + YES.Size.Height + 15;
                    YES.Click += new EventHandler(Button_Yes);
                    frm.Controls.Add(YES);
                    NO.ButtonText = "No";
                    NO.BaseColor = Color.LightGreen;
                    NO.GlowColor = Color.White;
                    NO.ForeColor = Color.Black;
                    TT.SetToolTip(NO, NO.ButtonText);
                    NO.ButtonColor = Color.CornflowerBlue;                    
                    NO.Size = new Size(72, 30);
                    NO.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    NO.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = NO.Location.Y + NO.Size.Height + 15;
                    int TwobuttonSize = YES.Width + 11 + NO.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        YES.Location = new Point(frm.Width / 2 - (YES.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        NO.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                    NO.Click += new EventHandler(Button_No);
                    ButtonKeydownFlag = 3;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(NO);
                }
                #endregion
                #region EDP_RETRY_CANCEL
                else if (MessageboxButton.ToString() == "EDP_RETRY_CANCEL")
                {
                    RETRY.ButtonText = "Retry";
                    RETRY.BaseColor = Color.LightGreen;
                    RETRY.GlowColor = Color.White;
                    RETRY.ForeColor = Color.Black;
                    TT.SetToolTip(RETRY, RETRY.ButtonText);
                    RETRY.ButtonColor = Color.CornflowerBlue;
                    RETRY.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    RETRY.Size = new Size(72, 30);
                    RETRY.Location = new Point(frm.Width / 2 - (RETRY.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = RETRY.Location.Y + RETRY.Size.Height + 15;
                    RETRY.Click += new EventHandler(Button_Retry);
                    frm.Controls.Add(RETRY);
                    CANCEL.ButtonText = "Cancel";
                    CANCEL.BaseColor = Color.LightGreen;
                    CANCEL.GlowColor = Color.White;
                    CANCEL.ForeColor = Color.Black;
                    TT.SetToolTip(CANCEL, CANCEL.ButtonText);
                    CANCEL.ButtonColor = Color.CornflowerBlue;                    
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 68;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    CANCEL.Size = new Size(72, 30);
                    CANCEL.Font = new Font("Tahoma", 9);
                    CANCEL.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = CANCEL.Location.Y + CANCEL.Size.Height + 15;
                    int TwobuttonSize = RETRY.Width + 11 + CANCEL.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        RETRY.Location = new Point(frm.Width / 2 - (RETRY.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        CANCEL.Location = new Point(frm.Width / 2, Text.Location.Y + Text.Size.Height + 14); ;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                    CANCEL.Click += new EventHandler(Button_Cancel);
                    ButtonKeydownFlag = 4;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(CANCEL);
                }
                #endregion
                #region EDP_YES_NO_CANCEL
                else if (MessageboxButton.ToString() == "EDP_YES_NO_CANCEL")
                {
                    NO.ButtonText = "No";
                    NO.BaseColor = Color.LightGreen;
                    NO.GlowColor = Color.White;
                    NO.ForeColor = Color.Black;
                    TT.SetToolTip(NO, NO.ButtonText);
                    NO.ButtonColor = Color.CornflowerBlue;                    
                    NO.Size = new Size(72, 30);
                    NO.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    NO.Location = new Point(frm.Width / 2 - (NO.Width / 2), Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = NO.Location.Y + NO.Size.Height + 15;
                    NO.Click += new EventHandler(Button_No);
                    frm.Controls.Add(NO);
                    CANCEL.ButtonText = "Cancel";
                    CANCEL.BaseColor = Color.LightGreen;
                    CANCEL.GlowColor = Color.White;
                    CANCEL.ForeColor = Color.Black;
                    TT.SetToolTip(CANCEL, CANCEL.ButtonText);
                    CANCEL.ButtonColor = Color.CornflowerBlue;                   
                    CANCEL.Size = new Size(72, 30);
                    CANCEL.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    CANCEL.Location = new Point(NO.Location.X + NO.Width + 11, Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = CANCEL.Location.Y + CANCEL.Size.Height + 15;
                    CANCEL.Click += new EventHandler(Button_Cancel);
                    frm.Controls.Add(CANCEL);
                    YES.ButtonText = "Yes";
                    YES.BaseColor = Color.LightGreen;
                    YES.GlowColor = Color.White;
                    YES.ForeColor = Color.Black;
                    TT.SetToolTip(YES, YES.ButtonText);
                    YES.ButtonColor = Color.CornflowerBlue;                   
                    YES.Size = new Size(72, 30);
                    YES.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    YES.Location = new Point(NO.Location.X - (YES.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = YES.Location.Y + YES.Size.Height + 15;
                    YES.Click += new EventHandler(Button_Yes);
                    ButtonKeydownFlag = 5;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(YES);
                    int TwobuttonSize = YES.Width + 11 + NO.Width + 11 + CANCEL.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        NO.Location = new Point(frm.Width / 2 - (NO.Width / 2), Text.Location.Y + Text.Size.Height + 14); ;
                        CANCEL.Location = new Point(NO.Location.X + NO.Width + 11, Text.Location.Y + Text.Size.Height + 14);
                        YES.Location = new Point(NO.Location.X - (YES.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                }
                #endregion
                #region EDP_ABORT_RETRY_IGNORE
                else if (MessageboxButton.ToString() == "EDP_ABORT_RETRY_IGNORE")
                {
                    RETRY.ButtonText = "Retry";
                    RETRY.BaseColor = Color.LightGreen;
                    RETRY.GlowColor = Color.White;
                    RETRY.ForeColor = Color.Black;
                    TT.SetToolTip(RETRY, RETRY.ButtonText);
                    RETRY.ButtonColor = Color.CornflowerBlue;                    
                    RETRY.Size = new Size(72, 30);
                    RETRY.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    RETRY.Location = new Point(frm.Width / 2 - (RETRY.Width / 2), Text.Location.Y + Text.Size.Height + 14); ;
                    frm.Height = RETRY.Location.Y + RETRY.Size.Height + 15;
                    RETRY.Click += new EventHandler(Button_Retry);
                    frm.Controls.Add(RETRY);
                    IGNORE.ButtonText = "Ignore";
                    IGNORE.BaseColor = Color.LightGreen;
                    IGNORE.GlowColor = Color.White;
                    IGNORE.ForeColor = Color.Black;
                    TT.SetToolTip(IGNORE, IGNORE.ButtonText);
                    IGNORE.ButtonColor = Color.CornflowerBlue;                    
                    IGNORE.Size = new Size(72, 30);
                    IGNORE.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    IGNORE.Location = new Point(RETRY.Location.X + RETRY.Width + 11, Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = IGNORE.Location.Y + IGNORE.Size.Height + 15;
                    IGNORE.Click += new EventHandler(Button_Ignore);
                    frm.Controls.Add(IGNORE);
                    ABORT.ButtonText = "Abort";
                    ABORT.BaseColor = Color.LightGreen;
                    ABORT.GlowColor = Color.White;
                    ABORT.ForeColor = Color.Black;
                    TT.SetToolTip(ABORT, ABORT.ButtonText);
                    ABORT.ButtonColor = Color.CornflowerBlue;                    
                    ABORT.Size = new Size(72, 30);
                    ABORT.Font = new Font("Tahoma", 9);
                    if (flag == 0)
                    {
                        frm.Width = Text.Size.Width + 58;
                    }
                    else
                    {
                        frm.Width = Text.Size.Width + 100;
                    }
                    if (Header.Width >= Text.Width)
                    {
                        frm.Width = frm.Width + (Header.Width - frm.Width) + 30;
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new System.Drawing.Point(78, 55);
                        }
                    }
                    ABORT.Location = new Point(RETRY.Location.X - (ABORT.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                    frm.Height = ABORT.Location.Y + ABORT.Size.Height + 15;
                    ABORT.Click += new EventHandler(Button_Abort);
                    ButtonKeydownFlag = 6;
                    frm.KeyDown += new KeyEventHandler(Form_Keydown);
                    frm.Controls.Add(ABORT);
                    int TwobuttonSize = ABORT.Width + 11 + RETRY.Width + 11 + IGNORE.Width + 10;
                    if (frm.Width < TwobuttonSize)
                    {
                        frm.Width = TwobuttonSize + 60;
                        RETRY.Location = new Point(frm.Width / 2 - (RETRY.Width / 2), Text.Location.Y + Text.Size.Height + 14); ;
                        IGNORE.Location = new Point(RETRY.Location.X + RETRY.Width + 11, Text.Location.Y + Text.Size.Height + 14);
                        ABORT.Location = new Point(RETRY.Location.X - (ABORT.Width + 11), Text.Location.Y + Text.Size.Height + 14);
                        if (flag == 0)
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 40);
                        }
                        else
                        {
                            Text.Location = new Point(frm.Width / 2 - (Text.Width / 2), 55);
                        }
                    }
                }
                #endregion
            }
            catch
            { }
        }
        public static void Show(string message, string Title, Enum MessageboxButton, Enum MessageboxIcon)
        {
            MessageBoxCaption = Title;
            MessageBody = message;
            Initialize(1);
            ButtonGen(MessageboxButton, 1);
            IconGen(MessageboxIcon);
            BtnClose.Location = new System.Drawing.Point(HeaderCaption.Width - 20, 2);            
            frm.ShowDialog();
            //frm.Show();
        }
        public static void Show(string message, string Title, Enum MessageboxButton,bool ShowCheckBox)
        {
            MessageBoxCaption = Title;
            MessageBody = message;
            Initialize(0);
            ButtonGen(MessageboxButton, 0, ShowCheckBox);            
            BtnClose.Location = new System.Drawing.Point(HeaderCaption.Width - 20, 2);
            Picture.SendToBack();
            Picture.Image = null;
            frm.ShowDialog();
            //frm.Show();
        }
        public static void Show(string message, string Title, Enum MessageboxButton, Enum MessageboxIcon, bool ShowCheckBox)
        {
            MessageBoxCaption = Title;
            MessageBody = message;
            Initialize(1);
            ButtonGen(MessageboxButton, 1, ShowCheckBox);
            IconGen(MessageboxIcon);
            BtnClose.Location = new System.Drawing.Point(HeaderCaption.Width - 20, 2);           
            frm.ShowDialog();
            //frm.Show();
        }
        private static void IconGen(Enum MessageboxIcon)
        {
            try
            {
                if (MessageboxIcon.ToString() == "EDP_OK")
                {
                    Picture.Image = Resources.accepted_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_QUESTION")
                {
                    Picture.Image = Resources.questionmark_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_ERROR")
                {
                    Picture.Image = Resources.cancel_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_CANCEL")
                {
                    Picture.Image = Resources.cross_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_INFORMATION")
                {
                    Picture.Image = Resources.INFORMATION;
                }
                else if (MessageboxIcon.ToString() == "EDP_UNKNOWN")
                {
                    Picture.Image = Resources.lightbulb_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_WARNING")
                {
                    Picture.Image = Resources.warning_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_SAVE")
                {
                    Picture.Image = Resources.floppy_disk_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_USB")
                {
                    Picture.Image = Resources.usb_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_PRINTER")
                {
                    Picture.Image = Resources.printer_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_SETTINGS")
                {
                    Picture.Image = Resources.spanner_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_GLOBAL")
                {
                    Picture.Image = Resources.globe_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_CLEAR")
                {
                    Picture.Image = Resources.thumbs_up_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_DATABASE")
                {
                    Picture.Image = Resources.database_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_LOCK")
                {
                    Picture.Image = Resources.lock_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_UNLOCK")
                {
                    Picture.Image = Resources.lock_open_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_MOUSE")
                {
                    Picture.Image = Resources.mouse_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_SEARCH")
                {
                    Picture.Image = Resources.search_48;
                }
                else if (MessageboxIcon.ToString() == "EDP_USERS")
                {
                    Picture.Image = Resources.users_two_48;
                }
            }
            catch
            { }
        }
        private static void Button_OK(object sender, EventArgs e)
        {
            ButtonResult = "edpOK";           
            frm.Close();
        }
        private static void Button_Cancel(object sender, EventArgs e)
        {
            ButtonResult = "edpCANCEL";
            frm.Close();
        }
        private static void Button_Yes(object sender, EventArgs e)
        {
            ButtonResult = "edpYES";
            frm.Close();
        }
        private static void Button_No(object sender, EventArgs e)
        {
            ButtonResult = "edpNO";
            frm.Close();
        }
        private static void Button_Ignore(object sender, EventArgs e)
        {
            ButtonResult = "edpIGNORE";
            frm.Close();
        }
        private static void Button_Retry(object sender, EventArgs e)
        {
            ButtonResult = "edpRETRY";
            frm.Close();
        }
        private static void Button_Abort(object sender, EventArgs e)
        {
            ButtonResult = "edpABORT";
            frm.Close();
        }
        private static void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Checked.Checked == true)
            {
                CheckBoxResult = "edpCHECKED";
            }
            else
            {
                CheckBoxResult = "edpUNCHECKED";
            }
        }
        private static void BtnClose_MouseHover(object sender, EventArgs e)
        {
            BtnClose.Image = Resources.CloseIcon;
        }
        private static void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            BtnClose.Image = Resources.MinimizeIcon;
        }
        private static void Form_Keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (ButtonKeydownFlag == 1)
                //{
                //    Button_OK(sender, new EventArgs());
                //}
                //else if (ButtonKeydownFlag == 2)
                //{
                //    Button_OK(sender, new EventArgs());
                //}
                //else if (ButtonKeydownFlag == 3)
                //{
                //    Button_Yes(sender, new EventArgs());
                //}
                //else if (ButtonKeydownFlag == 4)
                //{
                //    Button_Retry(sender, new EventArgs());
                //}
                //else if (ButtonKeydownFlag == 5)
                //{
                //    Button_Yes(sender, new EventArgs());
                //}
                //else if (ButtonKeydownFlag == 6)
                //{
                //    Button_Retry(sender, new EventArgs());
                //}               
            }
            else
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Y)
            {
                Button_Yes(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.N)
            {
                Button_No(sender, new EventArgs());
            }
        }
        private static void Close_msg(object sender, EventArgs e)
        {
            ButtonResult = "edpCLOSE";
            frm.Close();
        }
        private static void Form_Load(object sender, EventArgs e)
        {
            Edpcom.EDPCommon edpcom = new EDPCommon();
            edpcom.MaketheformMovable(HeaderCaption, frm);
            edpcom.MaketheformMovable(Header, frm);
        }
        public static string ButtonResult
        {
            get
            {
                return Result;
            }
            set
            {
                Result = value;
            }
        }
        private static string MessageBoxCaption
        {
            get
            {
                return MCaption;
            }
            set
            {
                MCaption = value;
            }
        }
        private static string MessageBody
        {
            get
            {
                return MText;
            }
            set
            {
                MText = value;
            }
        }
        public static string CheckBoxResult
        {
            get
            {
                return CheckResult;
            }
            set
            {
                CheckResult = value;
            }
        }
    }
}

