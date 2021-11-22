using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using EDPMessageBox;

namespace EDPComponent
{
    
    public partial class DateTimePickerEDP : System.Windows.Forms.DateTimePicker
    {
        public static  DateTime  currentdate;
        bool ChTime = false;
        bool ontime = true;
        public DateTimePickerEDP()
        {
            InitializeComponent();
            try
            {
                //if (new Edpcom.EDPCommon().CURRCO_SDT != Convert.ToDateTime("01/01/0001"))
                //{
                //    MinDate = new Edpcom.EDPCommon().CURRCO_SDT;
                //    MaxDate = new Edpcom.EDPCommon().CURRCO_EDT;
                //}
                this.Leave += new EventHandler(DateTimePickerEDP_Leave);
                this.Enter += new EventHandler(DateTimePickerEDP_Enter);
                //   this.Enter += new EventHandler(DateTimePickerEDP_Enter, DateTimePickerEDP_Leave);

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
        protected override void OnLeave(EventArgs eventargs)
        {
            base.OnLeave(eventargs);
            Edpcom.frmConfigarationVariable.LEGACY_ALLOWED = true;
            if (new Edpcom.frmConfigarationVariable().ActionType == "ADD")
            {
                //bool LEGACY_ALLOWED = true;
                if (!ChTime)
                {
                    DateTime dt  = System.DateTime.Today;
                    if (dt < new Edpcom.EDPCommon().CURRCO_SDT)
                    {
                        this.Value   = new Edpcom.EDPCommon().CURRCO_SDT;
                        // goto pp;
                    }
                    else if (dt >= new Edpcom.EDPCommon().CURRCO_EDT)
                    {
                       //currentdate  = new Edpcom.EDPCommon().CURRCO_EDT;
                        this.Value  = new Edpcom.EDPCommon().CURRCO_EDT;
                        // goto pp;
                    }
                    else
                        this.Value  = dt;

                  
                    //if ((dt >= new Edpcom.EDPCommon().CURRCO_SDT) && (dt <= new Edpcom.EDPCommon().CURRCO_EDT))
                    //{
                    //    //dt = new Edpcom.EDPCommon().CURRCO_SDT;
                    //    goto pp;
                    //}
                    //pp:
                    //    {
                    //        this.Value = dt;
                    //    }
                }
            }
            if (ChTime)
            {
                //if ((this.Value < new Edpcom.EDPCommon().CURRCO_SDT) || (this.Value > new Edpcom.EDPCommon().CURRCO_EDT))
                //{
                //    EDPMessage.Show("");
                //    this.Value = new Edpcom.EDPCommon().CURRCO_SDT;
                //}
                //if (new Edpcom.frmConfigarationVariable().ActionType == "ADD")
                //{
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
                //}
            }
            ChTime = true;
            ontime = false;
        }


        public void ondate()
        {
            // base.OnLeave(eventargs);
            Edpcom.frmConfigarationVariable.LEGACY_ALLOWED = true;
           // if (new Edpcom.frmConfigarationVariable().ActionType == "ADD")
            {
                //bool LEGACY_ALLOWED = true;
                if (!ChTime)
                {
                    DateTime dt = System.DateTime.Today;
                    if (dt < new Edpcom.EDPCommon().CURRCO_SDT)
                    {
                        this.Value = new Edpcom.EDPCommon().CURRCO_SDT;
                        //  goto pp;
                    }
                    else if (dt >= new Edpcom.EDPCommon().CURRCO_EDT)
                    {
                        this.Value = new Edpcom.EDPCommon().CURRCO_EDT;
                        //  goto pp;
                    }
                    else
                        this.Value = dt;
                 
                    //pp:
                    //    {
                    //        this.Value = dt;
                    //    }
                    //}
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
