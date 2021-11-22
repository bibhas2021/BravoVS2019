namespace PayRollManagementSystem
{
    partial class frmEmpAdvance
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
            try
            {
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpAdvance));
            this.BtnEmp_Loan = new EDPComponent.VistaButton();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.dgv_EmpLoan = new System.Windows.Forms.DataGridView();
            this.ELID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELDt = new EDPComponent.CalendarColumn();
            this.ElAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELEMI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ELDeduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabLAK = new System.Windows.Forms.TabControl();
            this.tabLoan = new System.Windows.Forms.TabPage();
            this.lblLoanID = new System.Windows.Forms.Label();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear_Loan = new EDPComponent.VistaButton();
            this.txtLoanIntPer = new System.Windows.Forms.TextBox();
            this.txtEmpLoanEMI = new System.Windows.Forms.TextBox();
            this.txtEmpLoanDuration = new System.Windows.Forms.TextBox();
            this.comboDialog2 = new EDPComponent.ComboDialog();
            this.txtLoanECode = new System.Windows.Forms.TextBox();
            this.txtEmpLoan = new System.Windows.Forms.TextBox();
            this.dtpEmpLoanDt = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbLoanEmp = new EDPComponent.ComboDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoanDelete = new EDPComponent.VistaButton();
            this.tabAdv = new System.Windows.Forms.TabPage();
            this.txt_remarks_adv = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAdvECode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbAdvLoc = new EDPComponent.ComboDialog();
            this.txtEmpAdv = new System.Windows.Forms.TextBox();
            this.dtpEmpAdv = new System.Windows.Forms.DateTimePicker();
            this.cmbEmpAdv = new EDPComponent.ComboDialog();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dgv_EmpAdv = new System.Windows.Forms.DataGridView();
            this.EAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EAEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EAName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EADT = new EDPComponent.CalendarColumn();
            this.EAAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EADeduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear_adv = new EDPComponent.VistaButton();
            this.btnAdvDelete = new EDPComponent.VistaButton();
            this.BtnEmp_Advance = new EDPComponent.VistaButton();
            this.tabKit = new System.Windows.Forms.TabPage();
            this.txt_remarks_Kit = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtKitECode = new System.Windows.Forms.TextBox();
            this.btnClear_kit = new EDPComponent.VistaButton();
            this.lbSlno = new System.Windows.Forms.Label();
            this.cmbKIT = new EDPComponent.ComboDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKitEmi = new System.Windows.Forms.TextBox();
            this.txtEmpKitDuration = new System.Windows.Forms.TextBox();
            this.txtKitVal = new System.Windows.Forms.TextBox();
            this.dtpEmpKit = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEmpKit = new EDPComponent.ComboDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgv_EmpKit = new System.Windows.Forms.DataGridView();
            this.EKID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EKEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EKName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EKDT = new EDPComponent.CalendarColumn();
            this.EKKIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EKAMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EKDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EKEMI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EKDeduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnKitDelete = new EDPComponent.VistaButton();
            this.BtnEmp_KIT = new EDPComponent.VistaButton();
            this.tabFine = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dtp_offence = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txt_remarks_fine = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txt_Fine_ECode = new System.Windows.Forms.TextBox();
            this.btnFine_clear = new EDPComponent.VistaButton();
            this.lblfineid = new System.Windows.Forms.Label();
            this.cmb_fine_Reason = new EDPComponent.ComboDialog();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_fine_emi = new System.Windows.Forms.TextBox();
            this.txt_fine_dur = new System.Windows.Forms.TextBox();
            this.txt_fine_val = new System.Windows.Forms.TextBox();
            this.dtp_fissue = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.cmb_fine_name = new EDPComponent.ComboDialog();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.dgvFine = new System.Windows.Forms.DataGridView();
            this.dgCol_fslno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_feid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_fename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_fidate = new EDPComponent.CalendarColumn();
            this.dgCol_fcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_fval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_fdur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_femi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_fdeduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_fid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFine_delete = new EDPComponent.VistaButton();
            this.btnFine_save = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.DTP_MON = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblPid = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmpLoan)).BeginInit();
            this.tabLAK.SuspendLayout();
            this.tabLoan.SuspendLayout();
            this.tabAdv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmpAdv)).BeginInit();
            this.tabKit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmpKit)).BeginInit();
            this.tabFine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFine)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEmp_Loan
            // 
            this.BtnEmp_Loan.BackColor = System.Drawing.Color.Transparent;
            this.BtnEmp_Loan.BaseColor = System.Drawing.Color.Ivory;
            this.BtnEmp_Loan.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnEmp_Loan.ButtonText = "Save";
            this.BtnEmp_Loan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmp_Loan.ForeColor = System.Drawing.Color.Black;
            this.BtnEmp_Loan.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnEmp_Loan.Location = new System.Drawing.Point(676, 84);
            this.BtnEmp_Loan.Name = "BtnEmp_Loan";
            this.BtnEmp_Loan.Size = new System.Drawing.Size(87, 26);
            this.BtnEmp_Loan.TabIndex = 18;
            this.BtnEmp_Loan.Click += new System.EventHandler(this.BtnDisp_Bio_Click);
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(91, 12);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(356, 21);
            this.CmbCompany.TabIndex = 6;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(13, 40);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(49, 14);
            this.LblLocation.TabIndex = 8;
            this.LblLocation.Text = "Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(91, 36);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(356, 21);
            this.cmbLocation.TabIndex = 7;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(13, 16);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(52, 14);
            this.LblCompany.TabIndex = 9;
            this.LblCompany.Text = "Company";
            // 
            // dgv_EmpLoan
            // 
            this.dgv_EmpLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmpLoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ELID,
            this.ELEID,
            this.ELName,
            this.ELDt,
            this.ElAmt,
            this.ELRate,
            this.ELDuration,
            this.ELEMI,
            this.ELDeduct});
            this.dgv_EmpLoan.Location = new System.Drawing.Point(23, 130);
            this.dgv_EmpLoan.Name = "dgv_EmpLoan";
            this.dgv_EmpLoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmpLoan.Size = new System.Drawing.Size(740, 332);
            this.dgv_EmpLoan.TabIndex = 10;
            this.dgv_EmpLoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmpLoan_CellClick);
            this.dgv_EmpLoan.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmpLoan_CellEnter);
            // 
            // ELID
            // 
            this.ELID.HeaderText = "SLNo";
            this.ELID.Name = "ELID";
            this.ELID.Visible = false;
            // 
            // ELEID
            // 
            this.ELEID.HeaderText = "Emp ID";
            this.ELEID.Name = "ELEID";
            // 
            // ELName
            // 
            this.ELName.HeaderText = "Employee Name";
            this.ELName.Name = "ELName";
            // 
            // ELDt
            // 
            this.ELDt.HeaderText = "Loan Date";
            this.ELDt.Name = "ELDt";
            this.ELDt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ELDt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ElAmt
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.ElAmt.DefaultCellStyle = dataGridViewCellStyle1;
            this.ElAmt.HeaderText = "Loan Amt";
            this.ElAmt.Name = "ElAmt";
            // 
            // ELRate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.ELRate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ELRate.HeaderText = "Interest Rate";
            this.ELRate.Name = "ELRate";
            this.ELRate.Visible = false;
            // 
            // ELDuration
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.ELDuration.DefaultCellStyle = dataGridViewCellStyle3;
            this.ELDuration.HeaderText = "Duration (in months)";
            this.ELDuration.Name = "ELDuration";
            // 
            // ELEMI
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.ELEMI.DefaultCellStyle = dataGridViewCellStyle4;
            this.ELEMI.HeaderText = "EMI";
            this.ELEMI.Name = "ELEMI";
            // 
            // ELDeduct
            // 
            this.ELDeduct.HeaderText = "Deduct Amt";
            this.ELDeduct.Name = "ELDeduct";
            // 
            // tabLAK
            // 
            this.tabLAK.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabLAK.Controls.Add(this.tabLoan);
            this.tabLAK.Controls.Add(this.tabAdv);
            this.tabLAK.Controls.Add(this.tabKit);
            this.tabLAK.Controls.Add(this.tabFine);
            this.tabLAK.Location = new System.Drawing.Point(12, 81);
            this.tabLAK.Name = "tabLAK";
            this.tabLAK.SelectedIndex = 0;
            this.tabLAK.Size = new System.Drawing.Size(791, 495);
            this.tabLAK.TabIndex = 11;
            // 
            // tabLoan
            // 
            this.tabLoan.BackColor = System.Drawing.Color.White;
            this.tabLoan.Controls.Add(this.lblLoanID);
            this.tabLoan.Controls.Add(this.txtremarks);
            this.tabLoan.Controls.Add(this.label1);
            this.tabLoan.Controls.Add(this.btnClear_Loan);
            this.tabLoan.Controls.Add(this.txtLoanIntPer);
            this.tabLoan.Controls.Add(this.txtEmpLoanEMI);
            this.tabLoan.Controls.Add(this.txtEmpLoanDuration);
            this.tabLoan.Controls.Add(this.comboDialog2);
            this.tabLoan.Controls.Add(this.txtLoanECode);
            this.tabLoan.Controls.Add(this.txtEmpLoan);
            this.tabLoan.Controls.Add(this.dtpEmpLoanDt);
            this.tabLoan.Controls.Add(this.label8);
            this.tabLoan.Controls.Add(this.label7);
            this.tabLoan.Controls.Add(this.cmbLoanEmp);
            this.tabLoan.Controls.Add(this.label6);
            this.tabLoan.Controls.Add(this.label5);
            this.tabLoan.Controls.Add(this.label4);
            this.tabLoan.Controls.Add(this.label3);
            this.tabLoan.Controls.Add(this.dgv_EmpLoan);
            this.tabLoan.Controls.Add(this.btnLoanDelete);
            this.tabLoan.Controls.Add(this.BtnEmp_Loan);
            this.tabLoan.Location = new System.Drawing.Point(4, 26);
            this.tabLoan.Name = "tabLoan";
            this.tabLoan.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoan.Size = new System.Drawing.Size(783, 465);
            this.tabLoan.TabIndex = 0;
            this.tabLoan.Text = "LOAN";
            this.tabLoan.UseVisualStyleBackColor = true;
            // 
            // lblLoanID
            // 
            this.lblLoanID.AutoSize = true;
            this.lblLoanID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoanID.Location = new System.Drawing.Point(711, 59);
            this.lblLoanID.Name = "lblLoanID";
            this.lblLoanID.Size = new System.Drawing.Size(2, 16);
            this.lblLoanID.TabIndex = 19;
            this.lblLoanID.Visible = false;
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(130, 77);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(355, 47);
            this.txtremarks.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Remarks";
            // 
            // btnClear_Loan
            // 
            this.btnClear_Loan.BackColor = System.Drawing.Color.Transparent;
            this.btnClear_Loan.BaseColor = System.Drawing.Color.Ivory;
            this.btnClear_Loan.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClear_Loan.ButtonText = "Clear";
            this.btnClear_Loan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear_Loan.ForeColor = System.Drawing.Color.Black;
            this.btnClear_Loan.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClear_Loan.Location = new System.Drawing.Point(587, 84);
            this.btnClear_Loan.Name = "btnClear_Loan";
            this.btnClear_Loan.Size = new System.Drawing.Size(87, 26);
            this.btnClear_Loan.TabIndex = 15;
            this.btnClear_Loan.TabStop = false;
            this.btnClear_Loan.Click += new System.EventHandler(this.btnClear_Loan_Click);
            // 
            // txtLoanIntPer
            // 
            this.txtLoanIntPer.Location = new System.Drawing.Point(588, 51);
            this.txtLoanIntPer.Name = "txtLoanIntPer";
            this.txtLoanIntPer.Size = new System.Drawing.Size(75, 20);
            this.txtLoanIntPer.TabIndex = 14;
            this.txtLoanIntPer.Text = "0";
            this.txtLoanIntPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLoanIntPer.Visible = false;
            // 
            // txtEmpLoanEMI
            // 
            this.txtEmpLoanEMI.Location = new System.Drawing.Point(410, 48);
            this.txtEmpLoanEMI.Name = "txtEmpLoanEMI";
            this.txtEmpLoanEMI.Size = new System.Drawing.Size(75, 20);
            this.txtEmpLoanEMI.TabIndex = 16;
            this.txtEmpLoanEMI.Text = "0";
            this.txtEmpLoanEMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEmpLoanDuration
            // 
            this.txtEmpLoanDuration.Location = new System.Drawing.Point(311, 48);
            this.txtEmpLoanDuration.Name = "txtEmpLoanDuration";
            this.txtEmpLoanDuration.Size = new System.Drawing.Size(40, 20);
            this.txtEmpLoanDuration.TabIndex = 15;
            this.txtEmpLoanDuration.Text = "1";
            this.txtEmpLoanDuration.TextChanged += new System.EventHandler(this.txtEmpLoanDuration_TextChanged);
            this.txtEmpLoanDuration.Leave += new System.EventHandler(this.txtEmpLoanDuration_TextChanged);
            // 
            // comboDialog2
            // 
            this.comboDialog2.Connection = null;
            this.comboDialog2.DialogResult = "";
            this.comboDialog2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDialog2.Location = new System.Drawing.Point(130, -507);
            this.comboDialog2.LOVFlag = 0;
            this.comboDialog2.MaxCharLength = 500;
            this.comboDialog2.Name = "comboDialog2";
            this.comboDialog2.ReturnIndex = -1;
            this.comboDialog2.ReturnValue = "";
            this.comboDialog2.ReturnValue_3rd = "";
            this.comboDialog2.ReturnValue_4th = "";
            this.comboDialog2.Size = new System.Drawing.Size(356, 21);
            this.comboDialog2.TabIndex = 6;
            this.comboDialog2.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.comboDialog2.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // txtLoanECode
            // 
            this.txtLoanECode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoanECode.Location = new System.Drawing.Point(410, 17);
            this.txtLoanECode.Name = "txtLoanECode";
            this.txtLoanECode.ReadOnly = true;
            this.txtLoanECode.Size = new System.Drawing.Size(75, 20);
            this.txtLoanECode.TabIndex = 14;
            this.txtLoanECode.TabStop = false;
            // 
            // txtEmpLoan
            // 
            this.txtEmpLoan.Location = new System.Drawing.Point(130, 48);
            this.txtEmpLoan.Name = "txtEmpLoan";
            this.txtEmpLoan.Size = new System.Drawing.Size(76, 20);
            this.txtEmpLoan.TabIndex = 14;
            this.txtEmpLoan.Text = "0";
            this.txtEmpLoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEmpLoan.TextChanged += new System.EventHandler(this.txtEmpLoanDuration_TextChanged);
            // 
            // dtpEmpLoanDt
            // 
            this.dtpEmpLoanDt.CustomFormat = "dd/MM/yyyy";
            this.dtpEmpLoanDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmpLoanDt.Location = new System.Drawing.Point(588, 20);
            this.dtpEmpLoanDt.Name = "dtpEmpLoanDt";
            this.dtpEmpLoanDt.Size = new System.Drawing.Size(152, 20);
            this.dtpEmpLoanDt.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(505, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "Rate of Interest";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(376, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "EMI";
            // 
            // cmbLoanEmp
            // 
            this.cmbLoanEmp.Connection = null;
            this.cmbLoanEmp.DialogResult = "";
            this.cmbLoanEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoanEmp.Location = new System.Drawing.Point(130, 17);
            this.cmbLoanEmp.LOVFlag = 0;
            this.cmbLoanEmp.MaxCharLength = 500;
            this.cmbLoanEmp.Name = "cmbLoanEmp";
            this.cmbLoanEmp.ReturnIndex = -1;
            this.cmbLoanEmp.ReturnValue = "";
            this.cmbLoanEmp.ReturnValue_3rd = "";
            this.cmbLoanEmp.ReturnValue_4th = "";
            this.cmbLoanEmp.Size = new System.Drawing.Size(277, 21);
            this.cmbLoanEmp.TabIndex = 7;
            this.cmbLoanEmp.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLoanEmp_DropDown);
            this.cmbLoanEmp.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLoanEmp_CloseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Duration(in month)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Loan Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Loan Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Employee Name";
            // 
            // btnLoanDelete
            // 
            this.btnLoanDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnLoanDelete.BaseColor = System.Drawing.Color.Ivory;
            this.btnLoanDelete.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnLoanDelete.ButtonText = "Delete";
            this.btnLoanDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoanDelete.ForeColor = System.Drawing.Color.Black;
            this.btnLoanDelete.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnLoanDelete.Location = new System.Drawing.Point(498, 84);
            this.btnLoanDelete.Name = "btnLoanDelete";
            this.btnLoanDelete.Size = new System.Drawing.Size(87, 26);
            this.btnLoanDelete.TabIndex = 4;
            this.btnLoanDelete.TabStop = false;
            this.btnLoanDelete.Click += new System.EventHandler(this.btnLoanDelete_Click);
            // 
            // tabAdv
            // 
            this.tabAdv.BackColor = System.Drawing.Color.White;
            this.tabAdv.Controls.Add(this.txt_remarks_adv);
            this.tabAdv.Controls.Add(this.label17);
            this.tabAdv.Controls.Add(this.txtAdvECode);
            this.tabAdv.Controls.Add(this.label15);
            this.tabAdv.Controls.Add(this.cmbAdvLoc);
            this.tabAdv.Controls.Add(this.txtEmpAdv);
            this.tabAdv.Controls.Add(this.dtpEmpAdv);
            this.tabAdv.Controls.Add(this.cmbEmpAdv);
            this.tabAdv.Controls.Add(this.label18);
            this.tabAdv.Controls.Add(this.label19);
            this.tabAdv.Controls.Add(this.label20);
            this.tabAdv.Controls.Add(this.dgv_EmpAdv);
            this.tabAdv.Controls.Add(this.btnClear_adv);
            this.tabAdv.Controls.Add(this.btnAdvDelete);
            this.tabAdv.Controls.Add(this.BtnEmp_Advance);
            this.tabAdv.Location = new System.Drawing.Point(4, 26);
            this.tabAdv.Name = "tabAdv";
            this.tabAdv.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdv.Size = new System.Drawing.Size(783, 465);
            this.tabAdv.TabIndex = 1;
            this.tabAdv.Text = "ADVANCE";
            this.tabAdv.UseVisualStyleBackColor = true;
            // 
            // txt_remarks_adv
            // 
            this.txt_remarks_adv.Location = new System.Drawing.Point(119, 91);
            this.txt_remarks_adv.Multiline = true;
            this.txt_remarks_adv.Name = "txt_remarks_adv";
            this.txt_remarks_adv.Size = new System.Drawing.Size(329, 39);
            this.txt_remarks_adv.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(25, 94);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Remarks";
            // 
            // txtAdvECode
            // 
            this.txtAdvECode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdvECode.Location = new System.Drawing.Point(440, 15);
            this.txtAdvECode.Name = "txtAdvECode";
            this.txtAdvECode.ReadOnly = true;
            this.txtAdvECode.Size = new System.Drawing.Size(75, 20);
            this.txtAdvECode.TabIndex = 28;
            this.txtAdvECode.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(25, 65);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 14);
            this.label15.TabIndex = 27;
            this.label15.Text = "Location";
            // 
            // cmbAdvLoc
            // 
            this.cmbAdvLoc.Connection = null;
            this.cmbAdvLoc.DialogResult = "";
            this.cmbAdvLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAdvLoc.Location = new System.Drawing.Point(119, 64);
            this.cmbAdvLoc.LOVFlag = 0;
            this.cmbAdvLoc.MaxCharLength = 500;
            this.cmbAdvLoc.Name = "cmbAdvLoc";
            this.cmbAdvLoc.ReturnIndex = -1;
            this.cmbAdvLoc.ReturnValue = "";
            this.cmbAdvLoc.ReturnValue_3rd = "";
            this.cmbAdvLoc.ReturnValue_4th = "";
            this.cmbAdvLoc.Size = new System.Drawing.Size(395, 21);
            this.cmbAdvLoc.TabIndex = 24;
            this.cmbAdvLoc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbAdvLoc_DropDown);
            this.cmbAdvLoc.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbAdvLoc_CloseUp);
            // 
            // txtEmpAdv
            // 
            this.txtEmpAdv.Location = new System.Drawing.Point(119, 41);
            this.txtEmpAdv.Name = "txtEmpAdv";
            this.txtEmpAdv.Size = new System.Drawing.Size(76, 20);
            this.txtEmpAdv.TabIndex = 23;
            this.txtEmpAdv.Text = "0";
            this.txtEmpAdv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpEmpAdv
            // 
            this.dtpEmpAdv.CustomFormat = "dd/MM/yyyy";
            this.dtpEmpAdv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmpAdv.Location = new System.Drawing.Point(285, 41);
            this.dtpEmpAdv.Name = "dtpEmpAdv";
            this.dtpEmpAdv.Size = new System.Drawing.Size(152, 20);
            this.dtpEmpAdv.TabIndex = 22;
            // 
            // cmbEmpAdv
            // 
            this.cmbEmpAdv.Connection = null;
            this.cmbEmpAdv.DialogResult = "";
            this.cmbEmpAdv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpAdv.Location = new System.Drawing.Point(119, 15);
            this.cmbEmpAdv.LOVFlag = 0;
            this.cmbEmpAdv.MaxCharLength = 500;
            this.cmbEmpAdv.Name = "cmbEmpAdv";
            this.cmbEmpAdv.ReturnIndex = -1;
            this.cmbEmpAdv.ReturnValue = "";
            this.cmbEmpAdv.ReturnValue_3rd = "";
            this.cmbEmpAdv.ReturnValue_4th = "";
            this.cmbEmpAdv.Size = new System.Drawing.Size(319, 21);
            this.cmbEmpAdv.TabIndex = 15;
            this.cmbEmpAdv.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbEmpAdv_DropDown);
            this.cmbEmpAdv.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbEmpAdv_CloseUp);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(25, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 14);
            this.label18.TabIndex = 19;
            this.label18.Text = "Advance Amount";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(204, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 14);
            this.label19.TabIndex = 18;
            this.label19.Text = "Advance Date";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(25, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 14);
            this.label20.TabIndex = 20;
            this.label20.Text = "Employee Name";
            // 
            // dgv_EmpAdv
            // 
            this.dgv_EmpAdv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_EmpAdv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmpAdv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EAID,
            this.EAEID,
            this.EAName,
            this.EADT,
            this.EAAmt,
            this.EADeduct,
            this.LocName});
            this.dgv_EmpAdv.Location = new System.Drawing.Point(23, 136);
            this.dgv_EmpAdv.Name = "dgv_EmpAdv";
            this.dgv_EmpAdv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmpAdv.Size = new System.Drawing.Size(740, 315);
            this.dgv_EmpAdv.TabIndex = 12;
            this.dgv_EmpAdv.TabStop = false;
            this.dgv_EmpAdv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmpAdv_CellClick);
            // 
            // EAID
            // 
            this.EAID.HeaderText = "SLNO";
            this.EAID.Name = "EAID";
            this.EAID.Visible = false;
            // 
            // EAEID
            // 
            this.EAEID.HeaderText = "EMP ID";
            this.EAEID.Name = "EAEID";
            // 
            // EAName
            // 
            this.EAName.HeaderText = "EMP Name";
            this.EAName.Name = "EAName";
            // 
            // EADT
            // 
            this.EADT.HeaderText = "Adv. Date";
            this.EADT.Name = "EADT";
            // 
            // EAAmt
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.EAAmt.DefaultCellStyle = dataGridViewCellStyle5;
            this.EAAmt.HeaderText = "Adv. Amt";
            this.EAAmt.Name = "EAAmt";
            // 
            // EADeduct
            // 
            this.EADeduct.HeaderText = "Deduct Amt";
            this.EADeduct.Name = "EADeduct";
            // 
            // LocName
            // 
            this.LocName.HeaderText = "Location";
            this.LocName.Name = "LocName";
            // 
            // btnClear_adv
            // 
            this.btnClear_adv.BackColor = System.Drawing.Color.Transparent;
            this.btnClear_adv.BaseColor = System.Drawing.Color.Ivory;
            this.btnClear_adv.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClear_adv.ButtonText = "Clear";
            this.btnClear_adv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear_adv.ForeColor = System.Drawing.Color.Black;
            this.btnClear_adv.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClear_adv.Location = new System.Drawing.Point(583, 94);
            this.btnClear_adv.Name = "btnClear_adv";
            this.btnClear_adv.Size = new System.Drawing.Size(87, 26);
            this.btnClear_adv.TabIndex = 11;
            this.btnClear_adv.TabStop = false;
            this.btnClear_adv.Click += new System.EventHandler(this.btnClear_adv_Click);
            // 
            // btnAdvDelete
            // 
            this.btnAdvDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnAdvDelete.BaseColor = System.Drawing.Color.Ivory;
            this.btnAdvDelete.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnAdvDelete.ButtonText = "Delete";
            this.btnAdvDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvDelete.ForeColor = System.Drawing.Color.Black;
            this.btnAdvDelete.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnAdvDelete.Location = new System.Drawing.Point(490, 94);
            this.btnAdvDelete.Name = "btnAdvDelete";
            this.btnAdvDelete.Size = new System.Drawing.Size(87, 26);
            this.btnAdvDelete.TabIndex = 11;
            this.btnAdvDelete.TabStop = false;
            this.btnAdvDelete.Click += new System.EventHandler(this.btnAdvDelete_Click);
            // 
            // BtnEmp_Advance
            // 
            this.BtnEmp_Advance.BackColor = System.Drawing.Color.Transparent;
            this.BtnEmp_Advance.BaseColor = System.Drawing.Color.Ivory;
            this.BtnEmp_Advance.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnEmp_Advance.ButtonText = "Save";
            this.BtnEmp_Advance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmp_Advance.ForeColor = System.Drawing.Color.Black;
            this.BtnEmp_Advance.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnEmp_Advance.Location = new System.Drawing.Point(676, 94);
            this.BtnEmp_Advance.Name = "BtnEmp_Advance";
            this.BtnEmp_Advance.Size = new System.Drawing.Size(87, 26);
            this.BtnEmp_Advance.TabIndex = 26;
            this.BtnEmp_Advance.Click += new System.EventHandler(this.BtnEmp_Advance_Click);
            // 
            // tabKit
            // 
            this.tabKit.BackColor = System.Drawing.Color.White;
            this.tabKit.Controls.Add(this.lblPid);
            this.tabKit.Controls.Add(this.txt_remarks_Kit);
            this.tabKit.Controls.Add(this.label27);
            this.tabKit.Controls.Add(this.txtKitECode);
            this.tabKit.Controls.Add(this.btnClear_kit);
            this.tabKit.Controls.Add(this.lbSlno);
            this.tabKit.Controls.Add(this.cmbKIT);
            this.tabKit.Controls.Add(this.label9);
            this.tabKit.Controls.Add(this.txtKitEmi);
            this.tabKit.Controls.Add(this.txtEmpKitDuration);
            this.tabKit.Controls.Add(this.txtKitVal);
            this.tabKit.Controls.Add(this.dtpEmpKit);
            this.tabKit.Controls.Add(this.label10);
            this.tabKit.Controls.Add(this.cmbEmpKit);
            this.tabKit.Controls.Add(this.label11);
            this.tabKit.Controls.Add(this.label12);
            this.tabKit.Controls.Add(this.label13);
            this.tabKit.Controls.Add(this.label14);
            this.tabKit.Controls.Add(this.dgv_EmpKit);
            this.tabKit.Controls.Add(this.btnKitDelete);
            this.tabKit.Controls.Add(this.BtnEmp_KIT);
            this.tabKit.Location = new System.Drawing.Point(4, 26);
            this.tabKit.Name = "tabKit";
            this.tabKit.Padding = new System.Windows.Forms.Padding(3);
            this.tabKit.Size = new System.Drawing.Size(783, 465);
            this.tabKit.TabIndex = 2;
            this.tabKit.Text = "KIT";
            this.tabKit.UseVisualStyleBackColor = true;
            // 
            // txt_remarks_Kit
            // 
            this.txt_remarks_Kit.Location = new System.Drawing.Point(113, 95);
            this.txt_remarks_Kit.Multiline = true;
            this.txt_remarks_Kit.Name = "txt_remarks_Kit";
            this.txt_remarks_Kit.Size = new System.Drawing.Size(359, 39);
            this.txt_remarks_Kit.TabIndex = 27;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(28, 95);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 13);
            this.label27.TabIndex = 32;
            this.label27.Text = "Remarks";
            // 
            // txtKitECode
            // 
            this.txtKitECode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKitECode.Location = new System.Drawing.Point(394, 15);
            this.txtKitECode.Name = "txtKitECode";
            this.txtKitECode.ReadOnly = true;
            this.txtKitECode.Size = new System.Drawing.Size(75, 20);
            this.txtKitECode.TabIndex = 31;
            this.txtKitECode.TabStop = false;
            // 
            // btnClear_kit
            // 
            this.btnClear_kit.BackColor = System.Drawing.Color.Transparent;
            this.btnClear_kit.BaseColor = System.Drawing.Color.Ivory;
            this.btnClear_kit.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClear_kit.ButtonText = "Clear";
            this.btnClear_kit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear_kit.ForeColor = System.Drawing.Color.Black;
            this.btnClear_kit.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClear_kit.Location = new System.Drawing.Point(587, 104);
            this.btnClear_kit.Name = "btnClear_kit";
            this.btnClear_kit.Size = new System.Drawing.Size(87, 26);
            this.btnClear_kit.TabIndex = 30;
            this.btnClear_kit.TabStop = false;
            this.btnClear_kit.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbSlno
            // 
            this.lbSlno.AutoSize = true;
            this.lbSlno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSlno.Location = new System.Drawing.Point(25, 116);
            this.lbSlno.Name = "lbSlno";
            this.lbSlno.Size = new System.Drawing.Size(2, 16);
            this.lbSlno.TabIndex = 29;
            this.lbSlno.Visible = false;
            // 
            // cmbKIT
            // 
            this.cmbKIT.Connection = null;
            this.cmbKIT.DialogResult = "";
            this.cmbKIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKIT.Location = new System.Drawing.Point(113, 42);
            this.cmbKIT.LOVFlag = 0;
            this.cmbKIT.MaxCharLength = 500;
            this.cmbKIT.Name = "cmbKIT";
            this.cmbKIT.ReturnIndex = -1;
            this.cmbKIT.ReturnValue = "";
            this.cmbKIT.ReturnValue_3rd = "";
            this.cmbKIT.ReturnValue_4th = "";
            this.cmbKIT.Size = new System.Drawing.Size(185, 21);
            this.cmbKIT.TabIndex = 23;
            this.cmbKIT.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbKIT_DropDown);
            this.cmbKIT.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbKIT_CloseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 14);
            this.label9.TabIndex = 28;
            this.label9.Text = "KIT Name";
            // 
            // txtKitEmi
            // 
            this.txtKitEmi.Location = new System.Drawing.Point(397, 69);
            this.txtKitEmi.Name = "txtKitEmi";
            this.txtKitEmi.Size = new System.Drawing.Size(75, 20);
            this.txtKitEmi.TabIndex = 26;
            this.txtKitEmi.Text = "0";
            this.txtKitEmi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEmpKitDuration
            // 
            this.txtEmpKitDuration.Location = new System.Drawing.Point(300, 69);
            this.txtEmpKitDuration.Name = "txtEmpKitDuration";
            this.txtEmpKitDuration.Size = new System.Drawing.Size(40, 20);
            this.txtEmpKitDuration.TabIndex = 25;
            this.txtEmpKitDuration.Text = "1";
            this.txtEmpKitDuration.TextChanged += new System.EventHandler(this.txtEmpDuration_TextChanged);
            // 
            // txtKitVal
            // 
            this.txtKitVal.Location = new System.Drawing.Point(113, 69);
            this.txtKitVal.Name = "txtKitVal";
            this.txtKitVal.Size = new System.Drawing.Size(76, 20);
            this.txtKitVal.TabIndex = 24;
            this.txtKitVal.Text = "0";
            this.txtKitVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKitVal.TextChanged += new System.EventHandler(this.txtEmpDuration_TextChanged);
            // 
            // dtpEmpKit
            // 
            this.dtpEmpKit.CustomFormat = "dd/MM/yyyy";
            this.dtpEmpKit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmpKit.Location = new System.Drawing.Point(572, 15);
            this.dtpEmpKit.Name = "dtpEmpKit";
            this.dtpEmpKit.Size = new System.Drawing.Size(152, 20);
            this.dtpEmpKit.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 14);
            this.label10.TabIndex = 16;
            this.label10.Text = "EMI";
            // 
            // cmbEmpKit
            // 
            this.cmbEmpKit.Connection = null;
            this.cmbEmpKit.DialogResult = "";
            this.cmbEmpKit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpKit.Location = new System.Drawing.Point(113, 15);
            this.cmbEmpKit.LOVFlag = 0;
            this.cmbEmpKit.MaxCharLength = 500;
            this.cmbEmpKit.Name = "cmbEmpKit";
            this.cmbEmpKit.ReturnIndex = -1;
            this.cmbEmpKit.ReturnValue = "";
            this.cmbEmpKit.ReturnValue_3rd = "";
            this.cmbEmpKit.ReturnValue_4th = "";
            this.cmbEmpKit.Size = new System.Drawing.Size(279, 21);
            this.cmbEmpKit.TabIndex = 15;
            this.cmbEmpKit.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbEmpKit_DropDown);
            this.cmbEmpKit.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbEmpKit_CloseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 14);
            this.label11.TabIndex = 17;
            this.label11.Text = "Duration(in month)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "KIT Value";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(491, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 14);
            this.label13.TabIndex = 18;
            this.label13.Text = "Loan Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 14);
            this.label14.TabIndex = 20;
            this.label14.Text = "Employee Name";
            // 
            // dgv_EmpKit
            // 
            this.dgv_EmpKit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_EmpKit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EmpKit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EKID,
            this.EKEID,
            this.EKName,
            this.EKDT,
            this.EKKIT,
            this.EKAMT,
            this.EKDuration,
            this.EKEMI,
            this.EKDeduct});
            this.dgv_EmpKit.Location = new System.Drawing.Point(23, 147);
            this.dgv_EmpKit.Name = "dgv_EmpKit";
            this.dgv_EmpKit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_EmpKit.Size = new System.Drawing.Size(740, 315);
            this.dgv_EmpKit.TabIndex = 12;
            this.dgv_EmpKit.TabStop = false;
            this.dgv_EmpKit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmpKit_CellDoubleClick);
            this.dgv_EmpKit.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_EmpKit_CellEnter);
            // 
            // EKID
            // 
            this.EKID.HeaderText = "SlNo";
            this.EKID.Name = "EKID";
            // 
            // EKEID
            // 
            this.EKEID.HeaderText = "EMP ID";
            this.EKEID.Name = "EKEID";
            // 
            // EKName
            // 
            this.EKName.HeaderText = "EMP Name";
            this.EKName.Name = "EKName";
            // 
            // EKDT
            // 
            this.EKDT.HeaderText = "Issue Date";
            this.EKDT.Name = "EKDT";
            this.EKDT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EKDT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EKKIT
            // 
            this.EKKIT.HeaderText = "KIT";
            this.EKKIT.Name = "EKKIT";
            this.EKKIT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EKKIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EKAMT
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.EKAMT.DefaultCellStyle = dataGridViewCellStyle6;
            this.EKAMT.HeaderText = "VALUE";
            this.EKAMT.Name = "EKAMT";
            this.EKAMT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EKAMT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EKDuration
            // 
            dataGridViewCellStyle7.NullValue = "0";
            this.EKDuration.DefaultCellStyle = dataGridViewCellStyle7;
            this.EKDuration.HeaderText = "Duration (In Months)";
            this.EKDuration.Name = "EKDuration";
            // 
            // EKEMI
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            this.EKEMI.DefaultCellStyle = dataGridViewCellStyle8;
            this.EKEMI.HeaderText = "EMI";
            this.EKEMI.Name = "EKEMI";
            // 
            // EKDeduct
            // 
            this.EKDeduct.HeaderText = "Deduct Amt";
            this.EKDeduct.Name = "EKDeduct";
            // 
            // btnKitDelete
            // 
            this.btnKitDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnKitDelete.BaseColor = System.Drawing.Color.Ivory;
            this.btnKitDelete.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnKitDelete.ButtonText = "Delete";
            this.btnKitDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKitDelete.ForeColor = System.Drawing.Color.Black;
            this.btnKitDelete.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnKitDelete.Location = new System.Drawing.Point(497, 104);
            this.btnKitDelete.Name = "btnKitDelete";
            this.btnKitDelete.Size = new System.Drawing.Size(87, 26);
            this.btnKitDelete.TabIndex = 11;
            this.btnKitDelete.TabStop = false;
            this.btnKitDelete.Click += new System.EventHandler(this.btnKitDelete_Click);
            // 
            // BtnEmp_KIT
            // 
            this.BtnEmp_KIT.BackColor = System.Drawing.Color.Transparent;
            this.BtnEmp_KIT.BaseColor = System.Drawing.Color.Ivory;
            this.BtnEmp_KIT.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnEmp_KIT.ButtonText = "Save";
            this.BtnEmp_KIT.Enabled = false;
            this.BtnEmp_KIT.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmp_KIT.ForeColor = System.Drawing.Color.Black;
            this.BtnEmp_KIT.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnEmp_KIT.Location = new System.Drawing.Point(676, 104);
            this.BtnEmp_KIT.Name = "BtnEmp_KIT";
            this.BtnEmp_KIT.Size = new System.Drawing.Size(87, 26);
            this.BtnEmp_KIT.TabIndex = 28;
            this.BtnEmp_KIT.Click += new System.EventHandler(this.BtnEmp_KIT_Click);
            // 
            // tabFine
            // 
            this.tabFine.BackColor = System.Drawing.Color.White;
            this.tabFine.Controls.Add(this.checkBox2);
            this.tabFine.Controls.Add(this.label30);
            this.tabFine.Controls.Add(this.dtp_offence);
            this.tabFine.Controls.Add(this.textBox2);
            this.tabFine.Controls.Add(this.label29);
            this.tabFine.Controls.Add(this.textBox1);
            this.tabFine.Controls.Add(this.checkBox1);
            this.tabFine.Controls.Add(this.txt_remarks_fine);
            this.tabFine.Controls.Add(this.label28);
            this.tabFine.Controls.Add(this.txt_Fine_ECode);
            this.tabFine.Controls.Add(this.btnFine_clear);
            this.tabFine.Controls.Add(this.lblfineid);
            this.tabFine.Controls.Add(this.cmb_fine_Reason);
            this.tabFine.Controls.Add(this.label21);
            this.tabFine.Controls.Add(this.txt_fine_emi);
            this.tabFine.Controls.Add(this.txt_fine_dur);
            this.tabFine.Controls.Add(this.txt_fine_val);
            this.tabFine.Controls.Add(this.dtp_fissue);
            this.tabFine.Controls.Add(this.label22);
            this.tabFine.Controls.Add(this.cmb_fine_name);
            this.tabFine.Controls.Add(this.label23);
            this.tabFine.Controls.Add(this.label24);
            this.tabFine.Controls.Add(this.label25);
            this.tabFine.Controls.Add(this.label26);
            this.tabFine.Controls.Add(this.dgvFine);
            this.tabFine.Controls.Add(this.btnFine_delete);
            this.tabFine.Controls.Add(this.btnFine_save);
            this.tabFine.Location = new System.Drawing.Point(4, 26);
            this.tabFine.Name = "tabFine";
            this.tabFine.Padding = new System.Windows.Forms.Padding(3);
            this.tabFine.Size = new System.Drawing.Size(783, 465);
            this.tabFine.TabIndex = 3;
            this.tabFine.Text = "FINE";
            this.tabFine.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(655, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(125, 46);
            this.checkBox2.TabIndex = 57;
            this.checkBox2.Text = "Please select if fine is\r\ndue to damage of \r\nmaterial";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(468, 31);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(82, 14);
            this.label30.TabIndex = 56;
            this.label30.Text = "Date of Offence";
            // 
            // dtp_offence
            // 
            this.dtp_offence.CustomFormat = "dd/MM/yyyy";
            this.dtp_offence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_offence.Location = new System.Drawing.Point(550, 28);
            this.dtp_offence.Name = "dtp_offence";
            this.dtp_offence.Size = new System.Drawing.Size(100, 20);
            this.dtp_offence.TabIndex = 55;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(566, 88);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(191, 21);
            this.textBox2.TabIndex = 54;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(493, 90);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(71, 14);
            this.label29.TabIndex = 53;
            this.label29.Text = "WitnessName";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(566, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 33);
            this.textBox1.TabIndex = 52;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(477, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 18);
            this.checkBox1.TabIndex = 51;
            this.checkBox1.Text = "Cause Showed";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txt_remarks_fine
            // 
            this.txt_remarks_fine.Location = new System.Drawing.Point(109, 94);
            this.txt_remarks_fine.Multiline = true;
            this.txt_remarks_fine.Name = "txt_remarks_fine";
            this.txt_remarks_fine.Size = new System.Drawing.Size(359, 43);
            this.txt_remarks_fine.TabIndex = 50;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(21, 97);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(54, 13);
            this.label28.TabIndex = 49;
            this.label28.Text = "Remarks";
            // 
            // txt_Fine_ECode
            // 
            this.txt_Fine_ECode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Fine_ECode.Location = new System.Drawing.Point(390, 15);
            this.txt_Fine_ECode.Name = "txt_Fine_ECode";
            this.txt_Fine_ECode.ReadOnly = true;
            this.txt_Fine_ECode.Size = new System.Drawing.Size(75, 20);
            this.txt_Fine_ECode.TabIndex = 48;
            this.txt_Fine_ECode.TabStop = false;
            // 
            // btnFine_clear
            // 
            this.btnFine_clear.BackColor = System.Drawing.Color.Transparent;
            this.btnFine_clear.BaseColor = System.Drawing.Color.Ivory;
            this.btnFine_clear.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFine_clear.ButtonText = "Clear";
            this.btnFine_clear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFine_clear.ForeColor = System.Drawing.Color.Black;
            this.btnFine_clear.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFine_clear.Location = new System.Drawing.Point(581, 115);
            this.btnFine_clear.Name = "btnFine_clear";
            this.btnFine_clear.Size = new System.Drawing.Size(87, 26);
            this.btnFine_clear.TabIndex = 47;
            this.btnFine_clear.Click += new System.EventHandler(this.btnFine_clear_Click);
            // 
            // lblfineid
            // 
            this.lblfineid.AutoSize = true;
            this.lblfineid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblfineid.Location = new System.Drawing.Point(21, 113);
            this.lblfineid.Name = "lblfineid";
            this.lblfineid.Size = new System.Drawing.Size(2, 16);
            this.lblfineid.TabIndex = 46;
            this.lblfineid.Visible = false;
            // 
            // cmb_fine_Reason
            // 
            this.cmb_fine_Reason.Connection = null;
            this.cmb_fine_Reason.DialogResult = "";
            this.cmb_fine_Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_fine_Reason.Location = new System.Drawing.Point(109, 41);
            this.cmb_fine_Reason.LOVFlag = 0;
            this.cmb_fine_Reason.MaxCharLength = 500;
            this.cmb_fine_Reason.Name = "cmb_fine_Reason";
            this.cmb_fine_Reason.ReturnIndex = -1;
            this.cmb_fine_Reason.ReturnValue = "";
            this.cmb_fine_Reason.ReturnValue_3rd = "";
            this.cmb_fine_Reason.ReturnValue_4th = "";
            this.cmb_fine_Reason.Size = new System.Drawing.Size(359, 21);
            this.cmb_fine_Reason.TabIndex = 44;
            this.cmb_fine_Reason.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txt_frcode_DropDown);
            this.cmb_fine_Reason.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.txt_frcode_CloseUp);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(21, 44);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 14);
            this.label21.TabIndex = 45;
            this.label21.Text = "Reason";
            // 
            // txt_fine_emi
            // 
            this.txt_fine_emi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_fine_emi.Location = new System.Drawing.Point(393, 68);
            this.txt_fine_emi.Name = "txt_fine_emi";
            this.txt_fine_emi.Size = new System.Drawing.Size(75, 20);
            this.txt_fine_emi.TabIndex = 41;
            this.txt_fine_emi.Text = "0";
            this.txt_fine_emi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_fine_dur
            // 
            this.txt_fine_dur.Location = new System.Drawing.Point(296, 68);
            this.txt_fine_dur.Name = "txt_fine_dur";
            this.txt_fine_dur.Size = new System.Drawing.Size(40, 20);
            this.txt_fine_dur.TabIndex = 43;
            this.txt_fine_dur.Text = "1";
            this.txt_fine_dur.TextChanged += new System.EventHandler(this.txt_fine_dur_TextChanged);
            // 
            // txt_fine_val
            // 
            this.txt_fine_val.Location = new System.Drawing.Point(109, 68);
            this.txt_fine_val.Name = "txt_fine_val";
            this.txt_fine_val.Size = new System.Drawing.Size(76, 20);
            this.txt_fine_val.TabIndex = 42;
            this.txt_fine_val.Text = "0";
            this.txt_fine_val.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_fine_val.TextChanged += new System.EventHandler(this.txt_fine_dur_TextChanged);
            // 
            // dtp_fissue
            // 
            this.dtp_fissue.CustomFormat = "dd/MM/yyyy";
            this.dtp_fissue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fissue.Location = new System.Drawing.Point(549, 5);
            this.dtp_fissue.Name = "dtp_fissue";
            this.dtp_fissue.Size = new System.Drawing.Size(100, 20);
            this.dtp_fissue.TabIndex = 40;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(359, 70);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(28, 14);
            this.label22.TabIndex = 35;
            this.label22.Text = "EMI";
            // 
            // cmb_fine_name
            // 
            this.cmb_fine_name.Connection = null;
            this.cmb_fine_name.DialogResult = "";
            this.cmb_fine_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_fine_name.Location = new System.Drawing.Point(109, 15);
            this.cmb_fine_name.LOVFlag = 0;
            this.cmb_fine_name.MaxCharLength = 500;
            this.cmb_fine_name.Name = "cmb_fine_name";
            this.cmb_fine_name.ReturnIndex = -1;
            this.cmb_fine_name.ReturnValue = "";
            this.cmb_fine_name.ReturnValue_3rd = "";
            this.cmb_fine_name.ReturnValue_4th = "";
            this.cmb_fine_name.Size = new System.Drawing.Size(275, 21);
            this.cmb_fine_name.TabIndex = 34;
            this.cmb_fine_name.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txt_fename_DropDown);
            this.cmb_fine_name.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.txt_fename_CloseUp);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(191, 71);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(97, 14);
            this.label23.TabIndex = 36;
            this.label23.Text = "Payable (in month)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(21, 70);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 14);
            this.label24.TabIndex = 38;
            this.label24.Text = "Fine Value";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(489, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(52, 14);
            this.label25.TabIndex = 37;
            this.label25.Text = "Fine Date";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(21, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(84, 14);
            this.label26.TabIndex = 39;
            this.label26.Text = "Employee Name";
            // 
            // dgvFine
            // 
            this.dgvFine.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgCol_fslno,
            this.dgCol_feid,
            this.dgCol_fename,
            this.dgCol_fidate,
            this.dgCol_fcode,
            this.dgCol_fval,
            this.dgCol_fdur,
            this.dgCol_femi,
            this.dgCol_fdeduct,
            this.dgCol_fid});
            this.dgvFine.Location = new System.Drawing.Point(19, 147);
            this.dgvFine.Name = "dgvFine";
            this.dgvFine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFine.Size = new System.Drawing.Size(740, 315);
            this.dgvFine.TabIndex = 33;
            this.dgvFine.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFine_CellDoubleClick);
            // 
            // dgCol_fslno
            // 
            this.dgCol_fslno.HeaderText = "SlNo";
            this.dgCol_fslno.Name = "dgCol_fslno";
            // 
            // dgCol_feid
            // 
            this.dgCol_feid.HeaderText = "EMP ID";
            this.dgCol_feid.Name = "dgCol_feid";
            // 
            // dgCol_fename
            // 
            this.dgCol_fename.HeaderText = "EMP Name";
            this.dgCol_fename.Name = "dgCol_fename";
            // 
            // dgCol_fidate
            // 
            this.dgCol_fidate.HeaderText = "Issue Date";
            this.dgCol_fidate.Name = "dgCol_fidate";
            this.dgCol_fidate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCol_fidate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgCol_fcode
            // 
            this.dgCol_fcode.HeaderText = "Fine code";
            this.dgCol_fcode.Name = "dgCol_fcode";
            this.dgCol_fcode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCol_fcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgCol_fval
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0";
            this.dgCol_fval.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgCol_fval.HeaderText = "VALUE";
            this.dgCol_fval.Name = "dgCol_fval";
            this.dgCol_fval.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCol_fval.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgCol_fdur
            // 
            dataGridViewCellStyle10.NullValue = "0";
            this.dgCol_fdur.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgCol_fdur.HeaderText = "Duration (In Months)";
            this.dgCol_fdur.Name = "dgCol_fdur";
            // 
            // dgCol_femi
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.dgCol_femi.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgCol_femi.HeaderText = "EMI";
            this.dgCol_femi.Name = "dgCol_femi";
            // 
            // dgCol_fdeduct
            // 
            this.dgCol_fdeduct.HeaderText = "Deduct Amt";
            this.dgCol_fdeduct.Name = "dgCol_fdeduct";
            // 
            // dgCol_fid
            // 
            this.dgCol_fid.HeaderText = "fineid";
            this.dgCol_fid.Name = "dgCol_fid";
            this.dgCol_fid.Visible = false;
            // 
            // btnFine_delete
            // 
            this.btnFine_delete.BackColor = System.Drawing.Color.Transparent;
            this.btnFine_delete.BaseColor = System.Drawing.Color.Ivory;
            this.btnFine_delete.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFine_delete.ButtonText = "Delete";
            this.btnFine_delete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFine_delete.ForeColor = System.Drawing.Color.Black;
            this.btnFine_delete.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFine_delete.Location = new System.Drawing.Point(490, 115);
            this.btnFine_delete.Name = "btnFine_delete";
            this.btnFine_delete.Size = new System.Drawing.Size(87, 26);
            this.btnFine_delete.TabIndex = 31;
            this.btnFine_delete.Click += new System.EventHandler(this.btnFine_delete_Click);
            // 
            // btnFine_save
            // 
            this.btnFine_save.BackColor = System.Drawing.Color.Transparent;
            this.btnFine_save.BaseColor = System.Drawing.Color.Ivory;
            this.btnFine_save.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnFine_save.ButtonText = "Save";
            this.btnFine_save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFine_save.ForeColor = System.Drawing.Color.Black;
            this.btnFine_save.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnFine_save.Location = new System.Drawing.Point(672, 114);
            this.btnFine_save.Name = "btnFine_save";
            this.btnFine_save.Size = new System.Drawing.Size(87, 26);
            this.btnFine_save.TabIndex = 32;
            this.btnFine_save.Click += new System.EventHandler(this.btnFine_save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(477, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "For the month of :";
            // 
            // DTP_MON
            // 
            this.DTP_MON.CustomFormat = "MMMM/ yyyy";
            this.DTP_MON.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_MON.Location = new System.Drawing.Point(596, 23);
            this.DTP_MON.Name = "DTP_MON";
            this.DTP_MON.Size = new System.Drawing.Size(183, 20);
            this.DTP_MON.TabIndex = 13;
            this.DTP_MON.ValueChanged += new System.EventHandler(this.DTP_MON_ValueChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Red;
            this.label31.Location = new System.Drawing.Point(93, 59);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(300, 12);
            this.label31.TabIndex = 14;
            this.label31.Text = "* Only allotted base locations in Employee joining is shown";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Red;
            this.label32.Location = new System.Drawing.Point(479, 46);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(301, 12);
            this.label32.TabIndex = 14;
            this.label32.Text = "* Loan / Advance / Kit / Fine shown as per selected month";
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPid.Location = new System.Drawing.Point(322, 44);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(2, 16);
            this.lblPid.TabIndex = 33;
            // 
            // frmEmpAdvance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 591);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.DTP_MON);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabLAK);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.cmbLocation);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEmpAdvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan / Advance / Kit / Fine";
            this.Load += new System.EventHandler(this.frmEmpAdvance_Load);
            this.Activated += new System.EventHandler(this.frmEmpAdvance_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmpLoan)).EndInit();
            this.tabLAK.ResumeLayout(false);
            this.tabLoan.ResumeLayout(false);
            this.tabLoan.PerformLayout();
            this.tabAdv.ResumeLayout(false);
            this.tabAdv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmpAdv)).EndInit();
            this.tabKit.ResumeLayout(false);
            this.tabKit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EmpKit)).EndInit();
            this.tabFine.ResumeLayout(false);
            this.tabFine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.VistaButton BtnEmp_Loan;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblLocation;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.DataGridView dgv_EmpLoan;
        private System.Windows.Forms.TabControl tabLAK;
        private System.Windows.Forms.TabPage tabLoan;
        private System.Windows.Forms.TabPage tabAdv;
        private System.Windows.Forms.DataGridView dgv_EmpAdv;
        private EDPComponent.VistaButton BtnEmp_Advance;
        private System.Windows.Forms.TabPage tabKit;
        private System.Windows.Forms.DataGridView dgv_EmpKit;
        private EDPComponent.VistaButton BtnEmp_KIT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTP_MON;
        private System.Windows.Forms.DateTimePicker dtpEmpLoanDt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoanIntPer;
        private System.Windows.Forms.TextBox txtEmpLoanEMI;
        private System.Windows.Forms.TextBox txtEmpLoanDuration;
        private System.Windows.Forms.TextBox txtEmpLoan;
        private System.Windows.Forms.Label label8;
        private EDPComponent.ComboDialog cmbLoanEmp;
        private EDPComponent.ComboDialog comboDialog2;
        private System.Windows.Forms.TextBox txtKitEmi;
        private System.Windows.Forms.TextBox txtEmpKitDuration;
        private System.Windows.Forms.TextBox txtKitVal;
        private System.Windows.Forms.DateTimePicker dtpEmpKit;
        private System.Windows.Forms.Label label10;
        private EDPComponent.ComboDialog cmbEmpKit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEmpAdv;
        private System.Windows.Forms.DateTimePicker dtpEmpAdv;
        private EDPComponent.ComboDialog cmbEmpAdv;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private EDPComponent.ComboDialog cmbKIT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELName;
        private EDPComponent.CalendarColumn ELDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELEMI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ELDeduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKName;
        private EDPComponent.CalendarColumn EKDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKKIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKAMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKEMI;
        private System.Windows.Forms.DataGridViewTextBoxColumn EKDeduct;
        private EDPComponent.VistaButton btnLoanDelete;
        private EDPComponent.VistaButton btnAdvDelete;
        private EDPComponent.VistaButton btnKitDelete;
        private System.Windows.Forms.Label label15;
        private EDPComponent.ComboDialog cmbAdvLoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn EAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EAEID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EAName;
        private EDPComponent.CalendarColumn EADT;
        private System.Windows.Forms.DataGridViewTextBoxColumn EAAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn EADeduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocName;
        private System.Windows.Forms.Label lbSlno;
        private EDPComponent.VistaButton btnClear_kit;
        private System.Windows.Forms.TabPage tabFine;
        private EDPComponent.VistaButton btnFine_clear;
        private System.Windows.Forms.Label lblfineid;
        private EDPComponent.ComboDialog cmb_fine_Reason;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_fine_emi;
        private System.Windows.Forms.TextBox txt_fine_dur;
        private System.Windows.Forms.TextBox txt_fine_val;
        private System.Windows.Forms.DateTimePicker dtp_fissue;
        private System.Windows.Forms.Label label22;
        private EDPComponent.ComboDialog cmb_fine_name;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView dgvFine;
        private EDPComponent.VistaButton btnFine_delete;
        private EDPComponent.VistaButton btnFine_save;
        private System.Windows.Forms.TextBox txtLoanECode;
        private System.Windows.Forms.TextBox txtAdvECode;
        private System.Windows.Forms.TextBox txtKitECode;
        private System.Windows.Forms.TextBox txt_Fine_ECode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fslno;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_feid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fename;
        private EDPComponent.CalendarColumn dgCol_fidate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fval;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fdur;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_femi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fdeduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fid;
        private EDPComponent.VistaButton btnClear_adv;
        private EDPComponent.VistaButton btnClear_Loan;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_remarks_adv;
        private System.Windows.Forms.TextBox txt_remarks_Kit;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txt_remarks_fine;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtp_offence;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblLoanID;
        private System.Windows.Forms.Label lblPid;
    }
}