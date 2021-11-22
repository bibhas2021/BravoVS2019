namespace PayRollManagementSystem
{
    partial class frmPayBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayBill));
            this.cmborderno = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.dgemployjob = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliantname = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.locationname = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdate = new EDPComponent.CalendarColumn();
            this.Designation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sacno = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Hour = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MontOfDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gst_per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gst_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Personnel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRmrks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_bmod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_reCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVoucherChallan = new EDPComponent.ComboDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.cmbsalstruc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmbclintname = new EDPComponent.ComboDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbdescription = new EDPComponent.ComboDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSTPer = new System.Windows.Forms.TextBox();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnExit = new EDPComponent.VistaButton();
            this.vistaButton2 = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgotherjob = new System.Windows.Forms.DataGridView();
            this.btnBrowse = new EDPComponent.VistaButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.nudDueDays = new System.Windows.Forms.NumericUpDown();
            this.cbDueDate = new System.Windows.Forms.CheckBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDesgName = new EDPComponent.ComboDialog();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbBillType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.sacServiceCharge = new System.Windows.Forms.ComboBox();
            this.sacSClbl = new System.Windows.Forms.Label();
            this.cgstPer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMOD = new System.Windows.Forms.Label();
            this.lblbid = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblLocid = new System.Windows.Forms.Label();
            this.lblClid = new System.Windows.Forms.Label();
            this.lblCoid = new System.Windows.Forms.Label();
            this.lblbillno = new System.Windows.Forms.Label();
            this.rdbChargeN = new System.Windows.Forms.RadioButton();
            this.rdbCharged = new System.Windows.Forms.RadioButton();
            this.ChkServiceChaerge = new System.Windows.Forms.CheckBox();
            this.TxtPer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblF10 = new System.Windows.Forms.Label();
            this.lblprevbal = new System.Windows.Forms.Label();
            this.lblEnclosure = new System.Windows.Forms.Label();
            this.chkAuthorise = new System.Windows.Forms.CheckBox();
            this.cbCancelBill = new System.Windows.Forms.CheckBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.chkRound = new System.Windows.Forms.CheckBox();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnPrint = new EDPComponent.VistaButton();
            this.btnCLear = new EDPComponent.VistaButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sacnoOC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OCAttend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OC_Gst_Per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OC_Gst_Amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncGST = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ExcSC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgemployjob)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgotherjob)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDueDays)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmborderno
            // 
            this.cmborderno.Connection = null;
            this.cmborderno.DialogResult = "";
            this.cmborderno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmborderno.Location = new System.Drawing.Point(926, 35);
            this.cmborderno.LOVFlag = 0;
            this.cmborderno.MaxCharLength = 500;
            this.cmborderno.Name = "cmborderno";
            this.cmborderno.ReturnIndex = -1;
            this.cmborderno.ReturnValue = "";
            this.cmborderno.ReturnValue_3rd = "";
            this.cmborderno.ReturnValue_4th = "";
            this.cmborderno.Size = new System.Drawing.Size(26, 21);
            this.cmborderno.TabIndex = 84;
            this.cmborderno.Visible = false;
            this.cmborderno.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmborderno_DropDown);
            this.cmborderno.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmborderno_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(886, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 85;
            this.label1.Text = "Employee Name";
            this.label1.Visible = false;
            // 
            // dgemployjob
            // 
            this.dgemployjob.AllowUserToOrderColumns = true;
            this.dgemployjob.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgemployjob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgemployjob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Cliantname,
            this.locationname,
            this.OrderNo,
            this.orderdate,
            this.Designation,
            this.sacno,
            this.Hour,
            this.MontOfDays,
            this.Attendance,
            this.Rate,
            this.Amount,
            this.gst_per,
            this.gst_amt,
            this.Personnel,
            this.colRmrks,
            this.col_bmod});
            this.dgemployjob.ContextMenuStrip = this.contextMenuStrip1;
            this.dgemployjob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgemployjob.GridColor = System.Drawing.Color.Silver;
            this.dgemployjob.Location = new System.Drawing.Point(3, 18);
            this.dgemployjob.Name = "dgemployjob";
            this.dgemployjob.RowHeadersVisible = false;
            this.dgemployjob.Size = new System.Drawing.Size(955, 197);
            this.dgemployjob.TabIndex = 83;
            this.dgemployjob.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgemployjob_CellLeave);
            this.dgemployjob.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgemployjob_CellEndEdit);
            this.dgemployjob.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgemployjob_EditingControlShowing);
            this.dgemployjob.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgemployjob_DataError);
            this.dgemployjob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgemployjob_KeyDown);
            this.dgemployjob.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgemployjob_CellEnter);
            // 
            // id
            // 
            this.id.DataPropertyName = "STATE_CODE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // Cliantname
            // 
            this.Cliantname.DataPropertyName = "STATE_Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.Cliantname.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cliantname.HeaderText = "Client Name";
            this.Cliantname.MinimumWidth = 50;
            this.Cliantname.Name = "Cliantname";
            this.Cliantname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cliantname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cliantname.Visible = false;
            this.Cliantname.Width = 50;
            // 
            // locationname
            // 
            this.locationname.DataPropertyName = "Location_Name";
            this.locationname.HeaderText = "Location Site Name";
            this.locationname.MinimumWidth = 50;
            this.locationname.Name = "locationname";
            this.locationname.Width = 200;
            // 
            // OrderNo
            // 
            this.OrderNo.HeaderText = "Order No";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            this.OrderNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // orderdate
            // 
            this.orderdate.HeaderText = "Order Date";
            this.orderdate.Name = "orderdate";
            // 
            // Designation
            // 
            this.Designation.DataPropertyName = "DesignationName";
            this.Designation.HeaderText = "Designation";
            this.Designation.Name = "Designation";
            this.Designation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Designation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Designation.Width = 125;
            // 
            // sacno
            // 
            this.sacno.HeaderText = "SAC No";
            this.sacno.Name = "sacno";
            this.sacno.Width = 150;
            // 
            // Hour
            // 
            this.Hour.HeaderText = "Hour";
            this.Hour.Items.AddRange(new object[] {
            "8",
            "12"});
            this.Hour.Name = "Hour";
            this.Hour.Width = 70;
            // 
            // MontOfDays
            // 
            this.MontOfDays.HeaderText = "MontOfDays";
            this.MontOfDays.Name = "MontOfDays";
            this.MontOfDays.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MontOfDays.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Attendance
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "0";
            this.Attendance.DefaultCellStyle = dataGridViewCellStyle4;
            this.Attendance.HeaderText = "Attendance";
            this.Attendance.Name = "Attendance";
            this.Attendance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Attendance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Rate
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.Rate.DefaultCellStyle = dataGridViewCellStyle5;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // Amount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.Amount.DefaultCellStyle = dataGridViewCellStyle6;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // gst_per
            // 
            this.gst_per.DataPropertyName = "GstPer";
            this.gst_per.HeaderText = "Gst%";
            this.gst_per.Name = "gst_per";
            // 
            // gst_amt
            // 
            this.gst_amt.DataPropertyName = "Gst";
            this.gst_amt.HeaderText = "Gst Amt";
            this.gst_amt.Name = "gst_amt";
            // 
            // Personnel
            // 
            this.Personnel.HeaderText = "NoOfPersonnel";
            this.Personnel.Name = "Personnel";
            // 
            // colRmrks
            // 
            this.colRmrks.HeaderText = "Remarks";
            this.colRmrks.Name = "colRmrks";
            // 
            // col_bmod
            // 
            this.col_bmod.HeaderText = "bmod";
            this.col_bmod.Name = "col_bmod";
            this.col_bmod.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_reCalc});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(162, 26);
            // 
            // menu_reCalc
            // 
            this.menu_reCalc.Name = "menu_reCalc";
            this.menu_reCalc.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.menu_reCalc.Size = new System.Drawing.Size(161, 22);
            this.menu_reCalc.Text = "ReCalculate";
            this.menu_reCalc.Click += new System.EventHandler(this.menu_reCalc_Click);
            // 
            // cmbmonth
            // 
            this.cmbmonth.FormattingEnabled = true;
            this.cmbmonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbmonth.Location = new System.Drawing.Point(958, 114);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(49, 24);
            this.cmbmonth.TabIndex = 93;
            this.cmbmonth.Visible = false;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(249, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 14);
            this.label2.TabIndex = 94;
            this.label2.Text = "Select Month";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(132, 47);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(112, 24);
            this.cmbYear.TabIndex = 241;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            this.cmbYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbYear_KeyDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(19, 50);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 242;
            this.label22.Text = "Session";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(615, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 243;
            this.label3.Text = "Bill No.";
            // 
            // txtVoucherChallan
            // 
            this.txtVoucherChallan.Connection = null;
            this.txtVoucherChallan.DialogResult = "";
            this.txtVoucherChallan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucherChallan.Location = new System.Drawing.Point(680, 12);
            this.txtVoucherChallan.LOVFlag = 0;
            this.txtVoucherChallan.MaxCharLength = 100;
            this.txtVoucherChallan.Name = "txtVoucherChallan";
            this.txtVoucherChallan.ReturnIndex = -1;
            this.txtVoucherChallan.ReturnValue = "";
            this.txtVoucherChallan.ReturnValue_3rd = "";
            this.txtVoucherChallan.ReturnValue_4th = "";
            this.txtVoucherChallan.Size = new System.Drawing.Size(191, 21);
            this.txtVoucherChallan.TabIndex = 244;
            this.txtVoucherChallan.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txtVoucherChallan_DropDown);
            this.txtVoucherChallan.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.txtVoucherChallan_CloseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(19, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 295;
            this.label6.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(132, 113);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(474, 21);
            this.cmbcompany.TabIndex = 294;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // cmbsalstruc
            // 
            this.cmbsalstruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsalstruc.FormattingEnabled = true;
            this.cmbsalstruc.Location = new System.Drawing.Point(958, 73);
            this.cmbsalstruc.Name = "cmbsalstruc";
            this.cmbsalstruc.Size = new System.Drawing.Size(44, 24);
            this.cmbsalstruc.TabIndex = 297;
            this.cmbsalstruc.Visible = false;
            this.cmbsalstruc.SelectedIndexChanged += new System.EventHandler(this.cmbsalstruc_SelectedIndexChanged);
            this.cmbsalstruc.DropDownClosed += new System.EventHandler(this.cmbsalstruc_DropDownClosed);
            this.cmbsalstruc.DropDown += new System.EventHandler(this.cmbsalstruc_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(889, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 14);
            this.label5.TabIndex = 296;
            this.label5.Text = "Location";
            this.label5.Visible = false;
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(132, 78);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(112, 22);
            this.dtpto.TabIndex = 300;
            this.dtpto.ValueChanged += new System.EventHandler(this.dtpto_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 301;
            this.label4.Text = "Bill Date.";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(617, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 18);
            this.checkBox1.TabIndex = 302;
            this.checkBox1.Text = "Service Tax";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmbclintname
            // 
            this.cmbclintname.BackColor = System.Drawing.Color.White;
            this.cmbclintname.Connection = null;
            this.cmbclintname.DialogResult = "";
            this.cmbclintname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclintname.Location = new System.Drawing.Point(132, 137);
            this.cmbclintname.LOVFlag = 0;
            this.cmbclintname.MaxCharLength = 500;
            this.cmbclintname.Name = "cmbclintname";
            this.cmbclintname.ReturnIndex = -1;
            this.cmbclintname.ReturnValue = "";
            this.cmbclintname.ReturnValue_3rd = "";
            this.cmbclintname.ReturnValue_4th = "";
            this.cmbclintname.Size = new System.Drawing.Size(474, 21);
            this.cmbclintname.TabIndex = 303;
            this.cmbclintname.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbclintname_DropDown);
            this.cmbclintname.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbclintname_CloseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 15);
            this.label7.TabIndex = 304;
            this.label7.Text = "Client Name";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "MMMM - yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(345, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 22);
            this.dateTimePicker1.TabIndex = 306;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // cmbdescription
            // 
            this.cmbdescription.Connection = null;
            this.cmbdescription.DialogResult = "";
            this.cmbdescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdescription.Location = new System.Drawing.Point(345, 13);
            this.cmbdescription.LOVFlag = 0;
            this.cmbdescription.MaxCharLength = 15;
            this.cmbdescription.Name = "cmbdescription";
            this.cmbdescription.ReturnIndex = -1;
            this.cmbdescription.ReturnValue = "";
            this.cmbdescription.ReturnValue_3rd = "";
            this.cmbdescription.ReturnValue_4th = "";
            this.cmbdescription.Size = new System.Drawing.Size(260, 21);
            this.cmbdescription.TabIndex = 307;
            this.cmbdescription.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbdescription_DropDown);
            this.cmbdescription.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbdescription_CloseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(249, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 14);
            this.label8.TabIndex = 308;
            this.label8.Text = "Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(707, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 14);
            this.label9.TabIndex = 295;
            this.label9.Text = "Service Tax % @";
            // 
            // txtSTPer
            // 
            this.txtSTPer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSTPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSTPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTPer.Location = new System.Drawing.Point(821, 96);
            this.txtSTPer.Name = "txtSTPer";
            this.txtSTPer.Size = new System.Drawing.Size(50, 20);
            this.txtSTPer.TabIndex = 309;
            this.txtSTPer.Text = "14.5";
            this.txtSTPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.SlateGray;
            this.btnSave.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.GlowColor = System.Drawing.Color.Aqua;
            this.btnSave.Location = new System.Drawing.Point(636, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 310;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BaseColor = System.Drawing.Color.SlateGray;
            this.btnExit.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnExit.ButtonText = "Exit";
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.GlowColor = System.Drawing.Color.Aqua;
            this.btnExit.Location = new System.Drawing.Point(878, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 31);
            this.btnExit.TabIndex = 311;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // vistaButton2
            // 
            this.vistaButton2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton2.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton2.ButtonText = "Delete";
            this.vistaButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton2.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton2.Location = new System.Drawing.Point(345, 7);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(75, 31);
            this.vistaButton2.TabIndex = 312;
            this.vistaButton2.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgotherjob);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 138);
            this.groupBox1.TabIndex = 313;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other Charges";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgotherjob
            // 
            this.dgotherjob.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgotherjob.BackgroundColor = System.Drawing.Color.White;
            this.dgotherjob.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgotherjob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OCID,
            this.OCDesc,
            this.sacnoOC,
            this.OCAttend,
            this.OCQty,
            this.OCRate,
            this.OCAmt,
            this.OC_Gst_Per,
            this.OC_Gst_Amt,
            this.IncGST,
            this.ExcSC});
            this.dgotherjob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgotherjob.GridColor = System.Drawing.Color.LightGray;
            this.dgotherjob.Location = new System.Drawing.Point(3, 18);
            this.dgotherjob.Name = "dgotherjob";
            this.dgotherjob.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgotherjob.Size = new System.Drawing.Size(955, 117);
            this.dgotherjob.TabIndex = 314;
            this.dgotherjob.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgotherjob_EditingControlShowing);
            this.dgotherjob.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgotherjob_CellEnter);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowse.BaseColor = System.Drawing.Color.SlateGray;
            this.btnBrowse.ButtonColor = System.Drawing.Color.MidnightBlue;
            this.btnBrowse.ButtonText = "Browse Order";
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.GlowColor = System.Drawing.Color.Azure;
            this.btnBrowse.HighlightColor = System.Drawing.Color.AliceBlue;
            this.btnBrowse.Location = new System.Drawing.Point(752, 168);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(119, 28);
            this.btnBrowse.TabIndex = 314;
            this.btnBrowse.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDesc);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cmbLocation);
            this.panel2.Controls.Add(this.nudDueDays);
            this.panel2.Controls.Add(this.cbDueDate);
            this.panel2.Controls.Add(this.dtpDueDate);
            this.panel2.Controls.Add(this.cmbDesgName);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.cmbBillType);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.sacServiceCharge);
            this.panel2.Controls.Add(this.sacSClbl);
            this.panel2.Controls.Add(this.cgstPer);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lblMOD);
            this.panel2.Controls.Add(this.lblbid);
            this.panel2.Controls.Add(this.lblMsg);
            this.panel2.Controls.Add(this.lblLocid);
            this.panel2.Controls.Add(this.lblClid);
            this.panel2.Controls.Add(this.lblCoid);
            this.panel2.Controls.Add(this.lblbillno);
            this.panel2.Controls.Add(this.rdbChargeN);
            this.panel2.Controls.Add(this.rdbCharged);
            this.panel2.Controls.Add(this.ChkServiceChaerge);
            this.panel2.Controls.Add(this.TxtPer);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.btnChange);
            this.panel2.Controls.Add(this.cmbdescription);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnBrowse);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtSTPer);
            this.panel2.Controls.Add(this.cmbclintname);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.dtpto);
            this.panel2.Controls.Add(this.cmbcompany);
            this.panel2.Controls.Add(this.cmbsalstruc);
            this.panel2.Controls.Add(this.cmbmonth);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmborderno);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.cmbYear);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.txtVoucherChallan);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(961, 206);
            this.panel2.TabIndex = 316;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesc.Location = new System.Drawing.Point(527, 46);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(2, 18);
            this.lblDesc.TabIndex = 337;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 15);
            this.label12.TabIndex = 304;
            this.label12.Text = "Location Name";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(132, 161);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(474, 21);
            this.cmbLocation.TabIndex = 303;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // nudDueDays
            // 
            this.nudDueDays.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDueDays.Location = new System.Drawing.Point(345, 79);
            this.nudDueDays.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDueDays.Name = "nudDueDays";
            this.nudDueDays.Size = new System.Drawing.Size(30, 22);
            this.nudDueDays.TabIndex = 336;
            this.nudDueDays.Visible = false;
            this.nudDueDays.ValueChanged += new System.EventHandler(this.nudDueDays_ValueChanged);
            // 
            // cbDueDate
            // 
            this.cbDueDate.AutoSize = true;
            this.cbDueDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDueDate.ForeColor = System.Drawing.Color.Black;
            this.cbDueDate.Location = new System.Drawing.Point(251, 81);
            this.cbDueDate.Name = "cbDueDate";
            this.cbDueDate.Size = new System.Drawing.Size(83, 18);
            this.cbDueDate.TabIndex = 335;
            this.cbDueDate.Text = "Due Date";
            this.cbDueDate.UseVisualStyleBackColor = true;
            this.cbDueDate.CheckedChanged += new System.EventHandler(this.cbDueDate_CheckedChanged);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(382, 79);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(80, 22);
            this.dtpDueDate.TabIndex = 333;
            this.dtpDueDate.Visible = false;
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dtpDueDate_ValueChanged);
            // 
            // cmbDesgName
            // 
            this.cmbDesgName.Connection = null;
            this.cmbDesgName.DialogResult = "";
            this.cmbDesgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesgName.Location = new System.Drawing.Point(132, 161);
            this.cmbDesgName.LOVFlag = 0;
            this.cmbDesgName.MaxCharLength = 500;
            this.cmbDesgName.Name = "cmbDesgName";
            this.cmbDesgName.ReturnIndex = -1;
            this.cmbDesgName.ReturnValue = "";
            this.cmbDesgName.ReturnValue_3rd = "";
            this.cmbDesgName.ReturnValue_4th = "";
            this.cmbDesgName.Size = new System.Drawing.Size(474, 21);
            this.cmbDesgName.TabIndex = 332;
            this.cmbDesgName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbDesgName_DropDown);
            this.cmbDesgName.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbDesgName_CloseUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 15);
            this.label15.TabIndex = 331;
            this.label15.Text = "Designation";
            // 
            // cmbBillType
            // 
            this.cmbBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBillType.FormattingEnabled = true;
            this.cmbBillType.Items.AddRange(new object[] {
            "Single Location",
            "Single Designation"});
            this.cmbBillType.Location = new System.Drawing.Point(132, 16);
            this.cmbBillType.Name = "cmbBillType";
            this.cmbBillType.Size = new System.Drawing.Size(112, 24);
            this.cmbBillType.TabIndex = 330;
            this.cmbBillType.SelectedIndexChanged += new System.EventHandler(this.cmbBillType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 15);
            this.label14.TabIndex = 329;
            this.label14.Text = "Bill Type";
            // 
            // sacServiceCharge
            // 
            this.sacServiceCharge.DropDownHeight = 100;
            this.sacServiceCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sacServiceCharge.DropDownWidth = 200;
            this.sacServiceCharge.FormattingEnabled = true;
            this.sacServiceCharge.IntegralHeight = false;
            this.sacServiceCharge.Location = new System.Drawing.Point(714, 65);
            this.sacServiceCharge.Name = "sacServiceCharge";
            this.sacServiceCharge.Size = new System.Drawing.Size(158, 24);
            this.sacServiceCharge.TabIndex = 328;
            this.sacServiceCharge.Visible = false;
            // 
            // sacSClbl
            // 
            this.sacSClbl.AutoSize = true;
            this.sacSClbl.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.sacSClbl.Location = new System.Drawing.Point(615, 68);
            this.sacSClbl.Name = "sacSClbl";
            this.sacSClbl.Size = new System.Drawing.Size(98, 14);
            this.sacSClbl.TabIndex = 327;
            this.sacSClbl.Text = "SAC No Of S.C.";
            this.sacSClbl.Visible = false;
            // 
            // cgstPer
            // 
            this.cgstPer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cgstPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cgstPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cgstPer.Location = new System.Drawing.Point(821, 119);
            this.cgstPer.Name = "cgstPer";
            this.cgstPer.Size = new System.Drawing.Size(50, 20);
            this.cgstPer.TabIndex = 326;
            this.cgstPer.Text = "9";
            this.cgstPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cgstPer.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(707, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 325;
            this.label13.Text = "CGST % @";
            this.label13.Visible = false;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // lblMOD
            // 
            this.lblMOD.AutoSize = true;
            this.lblMOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMOD.Location = new System.Drawing.Point(543, 83);
            this.lblMOD.Name = "lblMOD";
            this.lblMOD.Size = new System.Drawing.Size(2, 18);
            this.lblMOD.TabIndex = 324;
            this.lblMOD.Visible = false;
            // 
            // lblbid
            // 
            this.lblbid.AutoSize = true;
            this.lblbid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbid.Location = new System.Drawing.Point(502, 82);
            this.lblbid.Name = "lblbid";
            this.lblbid.Size = new System.Drawing.Size(2, 18);
            this.lblbid.TabIndex = 323;
            this.lblbid.Visible = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsg.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(557, 84);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(2, 15);
            this.lblMsg.TabIndex = 322;
            this.lblMsg.Visible = false;
            // 
            // lblLocid
            // 
            this.lblLocid.AutoSize = true;
            this.lblLocid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocid.Location = new System.Drawing.Point(493, 82);
            this.lblLocid.Name = "lblLocid";
            this.lblLocid.Size = new System.Drawing.Size(2, 18);
            this.lblLocid.TabIndex = 321;
            this.lblLocid.Visible = false;
            // 
            // lblClid
            // 
            this.lblClid.AutoSize = true;
            this.lblClid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClid.Location = new System.Drawing.Point(484, 82);
            this.lblClid.Name = "lblClid";
            this.lblClid.Size = new System.Drawing.Size(2, 18);
            this.lblClid.TabIndex = 321;
            this.lblClid.Visible = false;
            // 
            // lblCoid
            // 
            this.lblCoid.AutoSize = true;
            this.lblCoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoid.Location = new System.Drawing.Point(474, 82);
            this.lblCoid.Name = "lblCoid";
            this.lblCoid.Size = new System.Drawing.Size(2, 18);
            this.lblCoid.TabIndex = 321;
            this.lblCoid.Visible = false;
            // 
            // lblbillno
            // 
            this.lblbillno.AutoSize = true;
            this.lblbillno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbillno.Location = new System.Drawing.Point(873, 15);
            this.lblbillno.Name = "lblbillno";
            this.lblbillno.Size = new System.Drawing.Size(2, 18);
            this.lblbillno.TabIndex = 320;
            this.lblbillno.Visible = false;
            // 
            // rdbChargeN
            // 
            this.rdbChargeN.AutoSize = true;
            this.rdbChargeN.Location = new System.Drawing.Point(621, 166);
            this.rdbChargeN.Name = "rdbChargeN";
            this.rdbChargeN.Size = new System.Drawing.Size(102, 20);
            this.rdbChargeN.TabIndex = 319;
            this.rdbChargeN.TabStop = true;
            this.rdbChargeN.Text = "Not Charged";
            this.rdbChargeN.UseVisualStyleBackColor = true;
            // 
            // rdbCharged
            // 
            this.rdbCharged.AutoSize = true;
            this.rdbCharged.Checked = true;
            this.rdbCharged.Location = new System.Drawing.Point(621, 145);
            this.rdbCharged.Name = "rdbCharged";
            this.rdbCharged.Size = new System.Drawing.Size(78, 20);
            this.rdbCharged.TabIndex = 319;
            this.rdbCharged.TabStop = true;
            this.rdbCharged.Text = "Charged";
            this.rdbCharged.UseVisualStyleBackColor = true;
            // 
            // ChkServiceChaerge
            // 
            this.ChkServiceChaerge.AutoSize = true;
            this.ChkServiceChaerge.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkServiceChaerge.Location = new System.Drawing.Point(615, 41);
            this.ChkServiceChaerge.Name = "ChkServiceChaerge";
            this.ChkServiceChaerge.Size = new System.Drawing.Size(111, 19);
            this.ChkServiceChaerge.TabIndex = 318;
            this.ChkServiceChaerge.Text = "Service Charge";
            this.ChkServiceChaerge.UseVisualStyleBackColor = true;
            this.ChkServiceChaerge.CheckedChanged += new System.EventHandler(this.ChkServiceChaerge_CheckedChanged);
            // 
            // TxtPer
            // 
            this.TxtPer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtPer.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPer.Location = new System.Drawing.Point(828, 40);
            this.TxtPer.Name = "TxtPer";
            this.TxtPer.Size = new System.Drawing.Size(41, 22);
            this.TxtPer.TabIndex = 317;
            this.TxtPer.Text = "12.5";
            this.TxtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPer.TextChanged += new System.EventHandler(this.TxtPer_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(724, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 13);
            this.label11.TabIndex = 316;
            this.label11.Text = "Service Charge % @ ";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(752, 142);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(119, 25);
            this.btnChange.TabIndex = 315;
            this.btnChange.Text = "Change Percentage";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblF10);
            this.panel3.Controls.Add(this.lblprevbal);
            this.panel3.Controls.Add(this.lblEnclosure);
            this.panel3.Controls.Add(this.chkAuthorise);
            this.panel3.Controls.Add(this.cbCancelBill);
            this.panel3.Controls.Add(this.lblNote);
            this.panel3.Controls.Add(this.chkRound);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnPreview);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Controls.Add(this.btnCLear);
            this.panel3.Controls.Add(this.vistaButton2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 562);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(961, 45);
            this.panel3.TabIndex = 317;
            // 
            // lblF10
            // 
            this.lblF10.AutoSize = true;
            this.lblF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblF10.Location = new System.Drawing.Point(7, 8);
            this.lblF10.Name = "lblF10";
            this.lblF10.Size = new System.Drawing.Size(330, 12);
            this.lblF10.TabIndex = 322;
            this.lblF10.Text = "Press F10 for Recalculation if formula linked with basic charges ";
            // 
            // lblprevbal
            // 
            this.lblprevbal.AutoSize = true;
            this.lblprevbal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblprevbal.Location = new System.Drawing.Point(31, 27);
            this.lblprevbal.Name = "lblprevbal";
            this.lblprevbal.Size = new System.Drawing.Size(17, 18);
            this.lblprevbal.TabIndex = 321;
            this.lblprevbal.Text = "0";
            this.lblprevbal.Visible = false;
            // 
            // lblEnclosure
            // 
            this.lblEnclosure.AutoSize = true;
            this.lblEnclosure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnclosure.Location = new System.Drawing.Point(23, 24);
            this.lblEnclosure.Name = "lblEnclosure";
            this.lblEnclosure.Size = new System.Drawing.Size(2, 18);
            this.lblEnclosure.TabIndex = 320;
            this.lblEnclosure.Visible = false;
            // 
            // chkAuthorise
            // 
            this.chkAuthorise.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkAuthorise.AutoSize = true;
            this.chkAuthorise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAuthorise.Location = new System.Drawing.Point(441, 7);
            this.chkAuthorise.Name = "chkAuthorise";
            this.chkAuthorise.Size = new System.Drawing.Size(70, 17);
            this.chkAuthorise.TabIndex = 316;
            this.chkAuthorise.Text = "Authorise";
            this.chkAuthorise.UseVisualStyleBackColor = true;
            // 
            // cbCancelBill
            // 
            this.cbCancelBill.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbCancelBill.AutoSize = true;
            this.cbCancelBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCancelBill.Location = new System.Drawing.Point(441, 23);
            this.cbCancelBill.Name = "cbCancelBill";
            this.cbCancelBill.Size = new System.Drawing.Size(75, 17);
            this.cbCancelBill.TabIndex = 315;
            this.cbCancelBill.Text = "Cancel Bill";
            this.cbCancelBill.UseVisualStyleBackColor = true;
            this.cbCancelBill.Visible = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNote.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(5, 24);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(2, 16);
            this.lblNote.TabIndex = 314;
            this.lblNote.Visible = false;
            // 
            // chkRound
            // 
            this.chkRound.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkRound.AutoSize = true;
            this.chkRound.Checked = true;
            this.chkRound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRound.Location = new System.Drawing.Point(549, 14);
            this.chkRound.Name = "chkRound";
            this.chkRound.Size = new System.Drawing.Size(73, 17);
            this.chkRound.TabIndex = 313;
            this.chkRound.Text = "Round off";
            this.chkRound.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPreview.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPreview.ButtonText = "...";
            this.btnPreview.Enabled = false;
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.GlowColor = System.Drawing.Color.Aqua;
            this.btnPreview.Location = new System.Drawing.Point(796, 6);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 31);
            this.btnPreview.TabIndex = 310;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BaseColor = System.Drawing.Color.SlateGray;
            this.btnPrint.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.GlowColor = System.Drawing.Color.Aqua;
            this.btnPrint.Location = new System.Drawing.Point(970, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 31);
            this.btnPrint.TabIndex = 312;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCLear
            // 
            this.btnCLear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCLear.BackColor = System.Drawing.Color.Transparent;
            this.btnCLear.BaseColor = System.Drawing.Color.SlateGray;
            this.btnCLear.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnCLear.ButtonText = "Clear";
            this.btnCLear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLear.GlowColor = System.Drawing.Color.Aqua;
            this.btnCLear.Location = new System.Drawing.Point(717, 6);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(75, 31);
            this.btnCLear.TabIndex = 312;
            this.btnCLear.Click += new System.EventHandler(this.btnCLear_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 424);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(961, 138);
            this.panel4.TabIndex = 318;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 206);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(961, 218);
            this.panel5.TabIndex = 319;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgemployjob);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(961, 218);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic Charges";
            // 
            // OCID
            // 
            this.OCID.HeaderText = "ID";
            this.OCID.Name = "OCID";
            this.OCID.ReadOnly = true;
            this.OCID.Visible = false;
            this.OCID.Width = 43;
            // 
            // OCDesc
            // 
            this.OCDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OCDesc.HeaderText = "Other Description";
            this.OCDesc.MinimumWidth = 250;
            this.OCDesc.Name = "OCDesc";
            this.OCDesc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OCDesc.Width = 400;
            // 
            // sacnoOC
            // 
            this.sacnoOC.HeaderText = "SAC No";
            this.sacnoOC.Name = "sacnoOC";
            this.sacnoOC.Width = 150;
            // 
            // OCAttend
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = "0";
            this.OCAttend.DefaultCellStyle = dataGridViewCellStyle7;
            this.OCAttend.HeaderText = "Attendence";
            this.OCAttend.Name = "OCAttend";
            // 
            // OCQty
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.NullValue = "0";
            this.OCQty.DefaultCellStyle = dataGridViewCellStyle8;
            this.OCQty.HeaderText = "No of Personnel";
            this.OCQty.Name = "OCQty";
            // 
            // OCRate
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0";
            this.OCRate.DefaultCellStyle = dataGridViewCellStyle9;
            this.OCRate.HeaderText = "Rate";
            this.OCRate.Name = "OCRate";
            // 
            // OCAmt
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.OCAmt.DefaultCellStyle = dataGridViewCellStyle10;
            this.OCAmt.HeaderText = "Amount";
            this.OCAmt.Name = "OCAmt";
            // 
            // OC_Gst_Per
            // 
            this.OC_Gst_Per.HeaderText = "Gst %";
            this.OC_Gst_Per.Name = "OC_Gst_Per";
            // 
            // OC_Gst_Amt
            // 
            this.OC_Gst_Amt.HeaderText = "Gst Amt";
            this.OC_Gst_Amt.Name = "OC_Gst_Amt";
            // 
            // IncGST
            // 
            this.IncGST.HeaderText = "Exc GST";
            this.IncGST.Name = "IncGST";
            this.IncGST.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IncGST.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ExcSC
            // 
            this.ExcSC.HeaderText = "Exc SC";
            this.ExcSC.Name = "ExcSC";
            this.ExcSC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcSC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmPayBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(961, 607);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPayBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay Bill";
            this.Load += new System.EventHandler(this.FrmAllocateEmployDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgemployjob)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgotherjob)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDueDays)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EDPComponent.ComboDialog cmborderno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgemployjob;
        private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label3;
        public EDPComponent.ComboDialog txtVoucherChallan;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.ComboBox cmbsalstruc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private EDPComponent.ComboDialog cmbclintname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        public EDPComponent.ComboDialog cmbdescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSTPer;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnExit;
        private EDPComponent.VistaButton vistaButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgotherjob;
        private EDPComponent.VistaButton btnBrowse;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox2;
        private EDPComponent.VistaButton btnPrint;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.TextBox TxtPer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ChkServiceChaerge;
        private System.Windows.Forms.CheckBox chkRound;
        private System.Windows.Forms.Label label12;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.RadioButton rdbChargeN;
        private System.Windows.Forms.RadioButton rdbCharged;
        private EDPComponent.VistaButton btnCLear;
        private System.Windows.Forms.Label lblbillno;
        private System.Windows.Forms.Label lblLocid;
        private System.Windows.Forms.Label lblClid;
        private System.Windows.Forms.Label lblCoid;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblbid;
        private System.Windows.Forms.Label lblMOD;
        public System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox cgstPer;
        private System.Windows.Forms.ComboBox sacServiceCharge;
        private System.Windows.Forms.Label sacSClbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbBillType;
        private EDPComponent.ComboDialog cmbDesgName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbCancelBill;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.CheckBox cbDueDate;
        private System.Windows.Forms.NumericUpDown nudDueDays;
        private System.Windows.Forms.CheckBox chkAuthorise;
        public System.Windows.Forms.Label lblEnclosure;
        public System.Windows.Forms.Label lblprevbal;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_reCalc;
        private System.Windows.Forms.Label lblF10;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewComboBoxColumn Cliantname;
        private System.Windows.Forms.DataGridViewComboBoxColumn locationname;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private EDPComponent.CalendarColumn orderdate;
        private System.Windows.Forms.DataGridViewComboBoxColumn Designation;
        private System.Windows.Forms.DataGridViewComboBoxColumn sacno;
        private System.Windows.Forms.DataGridViewComboBoxColumn Hour;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontOfDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn gst_per;
        private System.Windows.Forms.DataGridViewTextBoxColumn gst_amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Personnel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRmrks;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bmod;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCDesc;
        private System.Windows.Forms.DataGridViewComboBoxColumn sacnoOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCAttend;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn OC_Gst_Per;
        private System.Windows.Forms.DataGridViewTextBoxColumn OC_Gst_Amt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IncGST;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ExcSC;
    }
}