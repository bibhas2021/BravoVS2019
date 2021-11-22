using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using EDPMessageBox;
using System.Runtime.InteropServices;

namespace EDPComponent
{    
    public partial class DateTimePickerEDP : System.Windows.Forms.DateTimePicker
    {
        public static  DateTime  currentdate;
        bool ChTime = false;
        bool ontime = true;
        int ChkFlagVal = 0;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, Int32 msg, Int32 wParam, Int32 IParam);
        const Int32 WM_lBurronDown = 0x0201;

        public DateTimePickerEDP()
        {
            InitializeComponent();
            try
            {               
                this.Leave += new EventHandler(DateTimePickerEDP_Leave);
                this.Enter += new EventHandler(DateTimePickerEDP_Enter);               
            }
            catch { }
        }       
       
        void DateTimePickerEDP_Leave(object sender, EventArgs e)
        {
            //dt = this.Value;
        }
        void DateTimePickerEDP_Enter(object sender, EventArgs e)
        {
            DateTimePickerEDP_Leave(sender, e);
        }

        public DateTimePickerEDP(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            if (ontime)
            {
                ondate();
            }
            this.Leave += new EventHandler(DateTimePickerEDP_Leave);
            this.Enter += new EventHandler(DateTimePickerEDP_Enter);            
        }        

        //public new DateTime Value
        //{
        //    //get
        //    //{
        //    //    if ((this.Value < new Edpcom.EDPCommon().CURRCO_SDT) || (this.Value > new Edpcom.EDPCommon().CURRCO_EDT))
        //    //        return new Edpcom.EDPCommon().CURRCO_SDT;
        //    //    else return this.Value;
        //    //}
        //    //set
        //    //{
        //    //    if ((this.Value < value) || (this.Value > value))
        //    //        this.Value = new Edpcom.EDPCommon().CURRCO_SDT;
        //    //    else this.Value = value;
        //    //}
        //}
        //protected override void OnLeave(EventArgs e)
        //{
        //    base.OnLeave(e);
        //    if (new Edpcom.EDPCommon().CURRCO_SDT != Convert.ToDateTime("01/01/0001"))
        //    {
        //        if ((this.Value < new Edpcom.EDPCommon().CURRCO_SDT) || (this.Value > new Edpcom.EDPCommon().CURRCO_EDT))
        //        {
        //            this.Value = new Edpcom.EDPCommon().CURRCO_SDT;
        //        }
        //    }
        //}

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {            
            base.OnKeyDown(e);            
            if (e.KeyCode == System.Windows.Forms.Keys.Insert)
            {
                Int32 x = this.Width - 10;
                Int32 y = this.Height / 2;
                Int32 lParam = x + y * 0x00010000;               
                PostMessage(this.Handle, WM_lBurronDown, 1, lParam);
            }
        }

        protected override void OnLeave(EventArgs eventargs)
        {
            base.OnLeave(eventargs);
            Edpcom.frmConfigarationVariable.LEGACY_ALLOWED = true;
            if (new Edpcom.frmConfigarationVariable().ActionType == "ADD")
            {               
                if (!ChTime)
                {
                    DateTime dt  = System.DateTime.Today;
                    if (dt < new Edpcom.EDPCommon().CURRCO_SDT)
                    {
                        this.Value   = new Edpcom.EDPCommon().CURRCO_SDT;                       
                    }
                    else if (dt >= new Edpcom.EDPCommon().CURRCO_EDT)
                    {                      
                        this.Value  = new Edpcom.EDPCommon().CURRCO_EDT;                     
                    }
                    else
                        this.Value  = dt;                   
                }
            }
            if (ChTime)
            {                
                if (Edpcom.frmConfigarationVariable.LEGACY_ALLOWED)
                {
                    if (this.Value < new Edpcom.EDPCommon().CURRCO_SDT)
                    {
                        EDPMessage.Show("Transaction Date must be grater than the Financial Date", "Information...");
                        this.Value = new Edpcom.EDPCommon().CURRCO_SDT;
                    }
                    else if (this.Value > new Edpcom.EDPCommon().CURRCO_EDT)
                    {
                        EDPMessage.Show("Transaction Date must be lower than the Financial Date", "Information...");
                        this.Value = new Edpcom.EDPCommon().CURRCO_EDT;
                    }
                }               
            }
            ChTime = true;
            ontime = false;
        }

        public void ondate()
        {           
            Edpcom.frmConfigarationVariable.LEGACY_ALLOWED = true;          
            {                
                if (!ChTime)
                {
                    DateTime dt = System.DateTime.Today;
                    if (dt < new Edpcom.EDPCommon().CURRCO_SDT)
                    {
                        this.Value = new Edpcom.EDPCommon().CURRCO_SDT;                       
                    }
                    else if (dt >= new Edpcom.EDPCommon().CURRCO_EDT)
                    {
                        this.Value = new Edpcom.EDPCommon().CURRCO_EDT;                      
                    }
                    else
                        this.Value = dt;                 
                }
                if (ChTime)
                {
                    if (Edpcom.frmConfigarationVariable.LEGACY_ALLOWED)
                    {
                        if (this.Value < new Edpcom.EDPCommon().CURRCO_SDT)
                        {
                            EDPMessage.Show("Transaction Date must be grater than the Financial Date", "Information...");
                            this.Value = new Edpcom.EDPCommon().CURRCO_SDT;
                        }
                        else if (this.Value > new Edpcom.EDPCommon().CURRCO_EDT)
                        {
                            EDPMessage.Show("Transaction Date must be lower than the Financial Date", "Information...");
                            this.Value = new Edpcom.EDPCommon().CURRCO_EDT;
                        }
                    }
                }
                ChTime = true;
                ontime = false;
            }
        }
    }
}
