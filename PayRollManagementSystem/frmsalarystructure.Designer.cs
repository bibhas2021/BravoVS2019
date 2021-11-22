namespace PayRollManagementSystem
{
    partial class frmsalarystructure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsalarystructure));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSalary = new System.Windows.Forms.DataGridView();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.lblidate = new System.Windows.Forms.Label();
            this.dtpidate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_payslip = new System.Windows.Forms.Label();
            this.lbl_limit_gross_esi = new System.Windows.Forms.Label();
            this.lbl_limit_gross = new System.Windows.Forms.Label();
            this.lbl_Accpt_ed_hrs = new System.Windows.Forms.Label();
            this.lbl_Accpt_wd_hrs = new System.Windows.Forms.Label();
            this.lbl_Accpt_ot_hrs = new System.Windows.Forms.Label();
            this.lbl_mod = new System.Windows.Forms.Label();
            this.lblEsi_empl = new System.Windows.Forms.Label();
            this.lbl_time_to = new System.Windows.Forms.Label();
            this.lbl_Time_from = new System.Windows.Forms.Label();
            this.lbl_ot_hrs = new System.Windows.Forms.Label();
            this.lbl_ed_hrs = new System.Windows.Forms.Label();
            this.lbl_wd_hrs = new System.Windows.Forms.Label();
            this.lbl_WO = new System.Windows.Forms.Label();
            this.lblClid = new System.Windows.Forms.Label();
            this.Lbl_pf_head = new System.Windows.Forms.Label();
            this.lbl_pt_formula = new System.Windows.Forms.Label();
            this.lbl_esi_formula = new System.Windows.Forms.Label();
            this.lbl_Pf_formula = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkAllLocation = new System.Windows.Forms.CheckBox();
            this.cmbZone = new EDPComponent.ComboDialog();
            this.dtp_copy = new System.Windows.Forms.DateTimePicker();
            this.lblEsi_limit = new System.Windows.Forms.Label();
            this.lblpf_limit = new System.Windows.Forms.Label();
            this.lbl_Chk_K = new System.Windows.Forms.Label();
            this.lbl_Chk_L = new System.Windows.Forms.Label();
            this.lbl_Chk_A = new System.Windows.Forms.Label();
            this.lblEarning = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.txtcalculated_days = new System.Windows.Forms.TextBox();
            this.dtp_DOE = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvGross = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvRecoveries = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgPfEsi = new System.Windows.Forms.DataGridView();
            this.eid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desgid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pf_bs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esi_bs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pf_contribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esi_contribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_esi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_OT_act = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.txtattendence = new System.Windows.Forms.TextBox();
            this.earn_count = new System.Windows.Forms.TextBox();
            this.ded_count = new System.Windows.Forms.TextBox();
            this.btnclose_frm = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.btnDeleteSal = new EDPComponent.VistaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAuthorise = new System.Windows.Forms.CheckBox();
            this.lblStatusCode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOCP = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAgentName = new EDPComponent.ComboDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAgentBank = new System.Windows.Forms.TextBox();
            this.txtAgentAcno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbltot = new System.Windows.Forms.Label();
            this.grpOCP = new System.Windows.Forms.GroupBox();
            this.dgvOtherCharges = new System.Windows.Forms.DataGridView();
            this.dgColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOAc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgColOIfsc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnCalc = new EDPComponent.VistaButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnl_load = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_load_msg = new System.Windows.Forms.Label();
            this.lblPayslip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGross)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecoveries)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPfEsi)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpOCP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherCharges)).BeginInit();
            this.pnl_load.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalary
            // 
            this.dgvSalary.AllowUserToAddRows = false;
            this.dgvSalary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSalary.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvSalary.Location = new System.Drawing.Point(3, 3);
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSalary.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalary.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvSalary.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSalary.Size = new System.Drawing.Size(1117, 316);
            this.dgvSalary.TabIndex = 0;
            this.dgvSalary.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            this.dgvSalary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dgvSalary.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dgvSalary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgvSalary.SelectionChanged += new System.EventHandler(this.dgvSalary_SelectionChanged);
            this.dgvSalary.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(326, 17);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(143, 20);
            this.AttenDtTmPkr.TabIndex = 263;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblidate
            // 
            this.lblidate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblidate.AutoSize = true;
            this.lblidate.Location = new System.Drawing.Point(488, 17);
            this.lblidate.Name = "lblidate";
            this.lblidate.Size = new System.Drawing.Size(103, 14);
            this.lblidate.TabIndex = 262;
            this.lblidate.Text = "Days of Calculation ";
            // 
            // dtpidate
            // 
            this.dtpidate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpidate.Location = new System.Drawing.Point(914, 294);
            this.dtpidate.Name = "dtpidate";
            this.dtpidate.Size = new System.Drawing.Size(100, 20);
            this.dtpidate.TabIndex = 261;
            this.dtpidate.Value = new System.DateTime(2015, 4, 28, 0, 0, 0, 0);
            this.dtpidate.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 14);
            this.label2.TabIndex = 259;
            this.label2.Text = "Location";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 14);
            this.label22.TabIndex = 257;
            this.label22.Text = "Session";
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(107, 15);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(118, 22);
            this.cmbYear.TabIndex = 256;
            this.cmbYear.DropDown += new System.EventHandler(this.cmbYear_DropDown);
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(231, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 14);
            this.label21.TabIndex = 258;
            this.label21.Text = "For The Month of";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblPayslip);
            this.groupBox1.Controls.Add(this.lbl_payslip);
            this.groupBox1.Controls.Add(this.lbl_limit_gross_esi);
            this.groupBox1.Controls.Add(this.lbl_limit_gross);
            this.groupBox1.Controls.Add(this.lbl_Accpt_ed_hrs);
            this.groupBox1.Controls.Add(this.lbl_Accpt_wd_hrs);
            this.groupBox1.Controls.Add(this.lbl_Accpt_ot_hrs);
            this.groupBox1.Controls.Add(this.lbl_mod);
            this.groupBox1.Controls.Add(this.lblEsi_empl);
            this.groupBox1.Controls.Add(this.lbl_time_to);
            this.groupBox1.Controls.Add(this.lbl_Time_from);
            this.groupBox1.Controls.Add(this.lbl_ot_hrs);
            this.groupBox1.Controls.Add(this.lbl_ed_hrs);
            this.groupBox1.Controls.Add(this.lbl_wd_hrs);
            this.groupBox1.Controls.Add(this.lbl_WO);
            this.groupBox1.Controls.Add(this.lblClid);
            this.groupBox1.Controls.Add(this.Lbl_pf_head);
            this.groupBox1.Controls.Add(this.lbl_pt_formula);
            this.groupBox1.Controls.Add(this.lbl_esi_formula);
            this.groupBox1.Controls.Add(this.lbl_Pf_formula);
            this.groupBox1.Controls.Add(this.txtClient);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.chkAllLocation);
            this.groupBox1.Controls.Add(this.cmbZone);
            this.groupBox1.Controls.Add(this.dtp_copy);
            this.groupBox1.Controls.Add(this.lblEsi_limit);
            this.groupBox1.Controls.Add(this.lblpf_limit);
            this.groupBox1.Controls.Add(this.lbl_Chk_K);
            this.groupBox1.Controls.Add(this.lbl_Chk_L);
            this.groupBox1.Controls.Add(this.lbl_Chk_A);
            this.groupBox1.Controls.Add(this.lblEarning);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.txtcalculated_days);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.dtp_DOE);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.AttenDtTmPkr);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.lblidate);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1137, 116);
            this.groupBox1.TabIndex = 264;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // lbl_payslip
            // 
            this.lbl_payslip.AutoSize = true;
            this.lbl_payslip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_payslip.Location = new System.Drawing.Point(901, 93);
            this.lbl_payslip.Name = "lbl_payslip";
            this.lbl_payslip.Size = new System.Drawing.Size(2, 16);
            this.lbl_payslip.TabIndex = 332;
            this.lbl_payslip.Visible = false;
            // 
            // lbl_limit_gross_esi
            // 
            this.lbl_limit_gross_esi.AutoSize = true;
            this.lbl_limit_gross_esi.Location = new System.Drawing.Point(1085, 36);
            this.lbl_limit_gross_esi.Name = "lbl_limit_gross_esi";
            this.lbl_limit_gross_esi.Size = new System.Drawing.Size(40, 14);
            this.lbl_limit_gross_esi.TabIndex = 331;
            this.lbl_limit_gross_esi.Text = "label11";
            this.lbl_limit_gross_esi.Visible = false;
            // 
            // lbl_limit_gross
            // 
            this.lbl_limit_gross.AutoSize = true;
            this.lbl_limit_gross.Location = new System.Drawing.Point(1085, 17);
            this.lbl_limit_gross.Name = "lbl_limit_gross";
            this.lbl_limit_gross.Size = new System.Drawing.Size(40, 14);
            this.lbl_limit_gross.TabIndex = 331;
            this.lbl_limit_gross.Text = "label11";
            this.lbl_limit_gross.Visible = false;
            // 
            // lbl_Accpt_ed_hrs
            // 
            this.lbl_Accpt_ed_hrs.AutoSize = true;
            this.lbl_Accpt_ed_hrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Accpt_ed_hrs.ForeColor = System.Drawing.Color.Black;
            this.lbl_Accpt_ed_hrs.Location = new System.Drawing.Point(844, 89);
            this.lbl_Accpt_ed_hrs.Name = "lbl_Accpt_ed_hrs";
            this.lbl_Accpt_ed_hrs.Size = new System.Drawing.Size(2, 16);
            this.lbl_Accpt_ed_hrs.TabIndex = 329;
            this.lbl_Accpt_ed_hrs.Visible = false;
            // 
            // lbl_Accpt_wd_hrs
            // 
            this.lbl_Accpt_wd_hrs.AutoSize = true;
            this.lbl_Accpt_wd_hrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Accpt_wd_hrs.ForeColor = System.Drawing.Color.Black;
            this.lbl_Accpt_wd_hrs.Location = new System.Drawing.Point(833, 88);
            this.lbl_Accpt_wd_hrs.Name = "lbl_Accpt_wd_hrs";
            this.lbl_Accpt_wd_hrs.Size = new System.Drawing.Size(2, 16);
            this.lbl_Accpt_wd_hrs.TabIndex = 330;
            this.lbl_Accpt_wd_hrs.Visible = false;
            // 
            // lbl_Accpt_ot_hrs
            // 
            this.lbl_Accpt_ot_hrs.AutoSize = true;
            this.lbl_Accpt_ot_hrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Accpt_ot_hrs.ForeColor = System.Drawing.Color.Black;
            this.lbl_Accpt_ot_hrs.Location = new System.Drawing.Point(824, 88);
            this.lbl_Accpt_ot_hrs.Name = "lbl_Accpt_ot_hrs";
            this.lbl_Accpt_ot_hrs.Size = new System.Drawing.Size(2, 16);
            this.lbl_Accpt_ot_hrs.TabIndex = 329;
            this.lbl_Accpt_ot_hrs.Visible = false;
            // 
            // lbl_mod
            // 
            this.lbl_mod.AutoSize = true;
            this.lbl_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_mod.Location = new System.Drawing.Point(666, 67);
            this.lbl_mod.Name = "lbl_mod";
            this.lbl_mod.Size = new System.Drawing.Size(2, 16);
            this.lbl_mod.TabIndex = 328;
            this.lbl_mod.Visible = false;
            // 
            // lblEsi_empl
            // 
            this.lblEsi_empl.AutoSize = true;
            this.lblEsi_empl.Location = new System.Drawing.Point(1085, 72);
            this.lblEsi_empl.Name = "lblEsi_empl";
            this.lblEsi_empl.Size = new System.Drawing.Size(40, 14);
            this.lblEsi_empl.TabIndex = 327;
            this.lblEsi_empl.Text = "label11";
            // 
            // lbl_time_to
            // 
            this.lbl_time_to.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_time_to.AutoSize = true;
            this.lbl_time_to.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_time_to.Location = new System.Drawing.Point(692, 91);
            this.lbl_time_to.Name = "lbl_time_to";
            this.lbl_time_to.Size = new System.Drawing.Size(2, 16);
            this.lbl_time_to.TabIndex = 326;
            // 
            // lbl_Time_from
            // 
            this.lbl_Time_from.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Time_from.AutoSize = true;
            this.lbl_Time_from.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Time_from.Location = new System.Drawing.Point(692, 69);
            this.lbl_Time_from.Name = "lbl_Time_from";
            this.lbl_Time_from.Size = new System.Drawing.Size(2, 16);
            this.lbl_Time_from.TabIndex = 325;
            // 
            // lbl_ot_hrs
            // 
            this.lbl_ot_hrs.AutoSize = true;
            this.lbl_ot_hrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ot_hrs.Location = new System.Drawing.Point(928, 46);
            this.lbl_ot_hrs.Name = "lbl_ot_hrs";
            this.lbl_ot_hrs.Size = new System.Drawing.Size(15, 16);
            this.lbl_ot_hrs.TabIndex = 324;
            this.lbl_ot_hrs.Text = "0";
            this.lbl_ot_hrs.Visible = false;
            // 
            // lbl_ed_hrs
            // 
            this.lbl_ed_hrs.AutoSize = true;
            this.lbl_ed_hrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ed_hrs.Location = new System.Drawing.Point(888, 69);
            this.lbl_ed_hrs.Name = "lbl_ed_hrs";
            this.lbl_ed_hrs.Size = new System.Drawing.Size(15, 16);
            this.lbl_ed_hrs.TabIndex = 324;
            this.lbl_ed_hrs.Text = "0";
            this.lbl_ed_hrs.Visible = false;
            // 
            // lbl_wd_hrs
            // 
            this.lbl_wd_hrs.AutoSize = true;
            this.lbl_wd_hrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_wd_hrs.Location = new System.Drawing.Point(888, 46);
            this.lbl_wd_hrs.Name = "lbl_wd_hrs";
            this.lbl_wd_hrs.Size = new System.Drawing.Size(15, 16);
            this.lbl_wd_hrs.TabIndex = 324;
            this.lbl_wd_hrs.Text = "0";
            this.lbl_wd_hrs.Visible = false;
            // 
            // lbl_WO
            // 
            this.lbl_WO.AutoSize = true;
            this.lbl_WO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_WO.Location = new System.Drawing.Point(888, 23);
            this.lbl_WO.Name = "lbl_WO";
            this.lbl_WO.Size = new System.Drawing.Size(15, 16);
            this.lbl_WO.TabIndex = 324;
            this.lbl_WO.Text = "0";
            this.lbl_WO.Visible = false;
            // 
            // lblClid
            // 
            this.lblClid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblClid.AutoSize = true;
            this.lblClid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClid.Location = new System.Drawing.Point(675, 91);
            this.lblClid.Name = "lblClid";
            this.lblClid.Size = new System.Drawing.Size(2, 16);
            this.lblClid.TabIndex = 323;
            this.lblClid.Visible = false;
            // 
            // Lbl_pf_head
            // 
            this.Lbl_pf_head.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Lbl_pf_head.AutoSize = true;
            this.Lbl_pf_head.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_pf_head.Location = new System.Drawing.Point(664, 43);
            this.Lbl_pf_head.Name = "Lbl_pf_head";
            this.Lbl_pf_head.Size = new System.Drawing.Size(2, 16);
            this.Lbl_pf_head.TabIndex = 322;
            this.Lbl_pf_head.Visible = false;
            // 
            // lbl_pt_formula
            // 
            this.lbl_pt_formula.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_pt_formula.AutoSize = true;
            this.lbl_pt_formula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_pt_formula.Location = new System.Drawing.Point(823, 57);
            this.lbl_pt_formula.Name = "lbl_pt_formula";
            this.lbl_pt_formula.Size = new System.Drawing.Size(2, 16);
            this.lbl_pt_formula.TabIndex = 321;
            // 
            // lbl_esi_formula
            // 
            this.lbl_esi_formula.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_esi_formula.AutoSize = true;
            this.lbl_esi_formula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_esi_formula.Location = new System.Drawing.Point(823, 34);
            this.lbl_esi_formula.Name = "lbl_esi_formula";
            this.lbl_esi_formula.Size = new System.Drawing.Size(2, 16);
            this.lbl_esi_formula.TabIndex = 320;
            // 
            // lbl_Pf_formula
            // 
            this.lbl_Pf_formula.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Pf_formula.AutoSize = true;
            this.lbl_Pf_formula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Pf_formula.Location = new System.Drawing.Point(822, 12);
            this.lbl_Pf_formula.Name = "lbl_Pf_formula";
            this.lbl_Pf_formula.Size = new System.Drawing.Size(2, 16);
            this.lbl_Pf_formula.TabIndex = 319;
            // 
            // txtClient
            // 
            this.txtClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClient.Enabled = false;
            this.txtClient.ForeColor = System.Drawing.Color.Black;
            this.txtClient.Location = new System.Drawing.Point(107, 88);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(549, 20);
            this.txtClient.TabIndex = 318;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 317;
            this.label8.Text = "Client Name";
            // 
            // chkAllLocation
            // 
            this.chkAllLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAllLocation.AutoSize = true;
            this.chkAllLocation.Location = new System.Drawing.Point(17, 43);
            this.chkAllLocation.Name = "chkAllLocation";
            this.chkAllLocation.Size = new System.Drawing.Size(84, 18);
            this.chkAllLocation.TabIndex = 316;
            this.chkAllLocation.Text = "Select Zone";
            this.chkAllLocation.UseVisualStyleBackColor = true;
            this.chkAllLocation.CheckedChanged += new System.EventHandler(this.chkAllLocation_CheckedChanged);
            // 
            // cmbZone
            // 
            this.cmbZone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbZone.Connection = null;
            this.cmbZone.DialogResult = "";
            this.cmbZone.Location = new System.Drawing.Point(107, 41);
            this.cmbZone.LOVFlag = 0;
            this.cmbZone.MaxCharLength = 500;
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.ReturnIndex = -1;
            this.cmbZone.ReturnValue = "";
            this.cmbZone.ReturnValue_3rd = "";
            this.cmbZone.ReturnValue_4th = "";
            this.cmbZone.Size = new System.Drawing.Size(362, 21);
            this.cmbZone.TabIndex = 315;
            this.cmbZone.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbZone_DropDown);
            // 
            // dtp_copy
            // 
            this.dtp_copy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_copy.CustomFormat = "MMMM - yyyy";
            this.dtp_copy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_copy.Location = new System.Drawing.Point(662, 15);
            this.dtp_copy.Name = "dtp_copy";
            this.dtp_copy.Size = new System.Drawing.Size(139, 20);
            this.dtp_copy.TabIndex = 287;
            this.dtp_copy.Visible = false;
            // 
            // lblEsi_limit
            // 
            this.lblEsi_limit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEsi_limit.AutoSize = true;
            this.lblEsi_limit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEsi_limit.Location = new System.Drawing.Point(750, 94);
            this.lblEsi_limit.Name = "lblEsi_limit";
            this.lblEsi_limit.Size = new System.Drawing.Size(2, 16);
            this.lblEsi_limit.TabIndex = 286;
            this.lblEsi_limit.Visible = false;
            // 
            // lblpf_limit
            // 
            this.lblpf_limit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblpf_limit.AutoSize = true;
            this.lblpf_limit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblpf_limit.Location = new System.Drawing.Point(750, 72);
            this.lblpf_limit.Name = "lblpf_limit";
            this.lblpf_limit.Size = new System.Drawing.Size(2, 16);
            this.lblpf_limit.TabIndex = 286;
            this.lblpf_limit.Visible = false;
            // 
            // lbl_Chk_K
            // 
            this.lbl_Chk_K.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Chk_K.AutoSize = true;
            this.lbl_Chk_K.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Chk_K.Location = new System.Drawing.Point(750, 42);
            this.lbl_Chk_K.Name = "lbl_Chk_K";
            this.lbl_Chk_K.Size = new System.Drawing.Size(2, 16);
            this.lbl_Chk_K.TabIndex = 286;
            this.lbl_Chk_K.Visible = false;
            // 
            // lbl_Chk_L
            // 
            this.lbl_Chk_L.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Chk_L.AutoSize = true;
            this.lbl_Chk_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Chk_L.Location = new System.Drawing.Point(732, 43);
            this.lbl_Chk_L.Name = "lbl_Chk_L";
            this.lbl_Chk_L.Size = new System.Drawing.Size(2, 16);
            this.lbl_Chk_L.TabIndex = 286;
            this.lbl_Chk_L.Visible = false;
            // 
            // lbl_Chk_A
            // 
            this.lbl_Chk_A.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Chk_A.AutoSize = true;
            this.lbl_Chk_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Chk_A.Location = new System.Drawing.Point(710, 43);
            this.lbl_Chk_A.Name = "lbl_Chk_A";
            this.lbl_Chk_A.Size = new System.Drawing.Size(2, 16);
            this.lbl_Chk_A.TabIndex = 286;
            this.lbl_Chk_A.Visible = false;
            // 
            // lblEarning
            // 
            this.lblEarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEarning.AutoSize = true;
            this.lblEarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEarning.Location = new System.Drawing.Point(679, 43);
            this.lblEarning.Name = "lblEarning";
            this.lblEarning.Size = new System.Drawing.Size(2, 16);
            this.lblEarning.TabIndex = 285;
            this.lblEarning.Visible = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Location = new System.Drawing.Point(107, 65);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(549, 21);
            this.cmbLocation.TabIndex = 284;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // txtcalculated_days
            // 
            this.txtcalculated_days.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtcalculated_days.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcalculated_days.Location = new System.Drawing.Point(602, 16);
            this.txtcalculated_days.Name = "txtcalculated_days";
            this.txtcalculated_days.Size = new System.Drawing.Size(54, 20);
            this.txtcalculated_days.TabIndex = 276;
            // 
            // dtp_DOE
            // 
            this.dtp_DOE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtp_DOE.Checked = false;
            this.dtp_DOE.CustomFormat = "dd/MM/yyyy";
            this.dtp_DOE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DOE.Location = new System.Drawing.Point(554, 40);
            this.dtp_DOE.Name = "dtp_DOE";
            this.dtp_DOE.Size = new System.Drawing.Size(102, 20);
            this.dtp_DOE.TabIndex = 263;
            this.dtp_DOE.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(476, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 14);
            this.label9.TabIndex = 258;
            this.label9.Text = "Date of Salary";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(0, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1137, 368);
            this.groupBox2.TabIndex = 265;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1131, 349);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSalary);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1123, 322);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Salary Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvGross);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1123, 322);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Actual Gross";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvGross
            // 
            this.dgvGross.AllowUserToAddRows = false;
            this.dgvGross.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGross.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGross.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGross.Location = new System.Drawing.Point(3, 3);
            this.dgvGross.Name = "dgvGross";
            this.dgvGross.Size = new System.Drawing.Size(1117, 316);
            this.dgvGross.TabIndex = 285;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvRecoveries);
            this.tabPage3.ForeColor = System.Drawing.Color.Black;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1123, 322);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Recoveries";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvRecoveries
            // 
            this.dgvRecoveries.AllowUserToAddRows = false;
            this.dgvRecoveries.AllowUserToDeleteRows = false;
            this.dgvRecoveries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRecoveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecoveries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecoveries.Location = new System.Drawing.Point(3, 3);
            this.dgvRecoveries.Name = "dgvRecoveries";
            this.dgvRecoveries.Size = new System.Drawing.Size(1117, 316);
            this.dgvRecoveries.TabIndex = 286;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgPfEsi);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1123, 322);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "PF - ESI - OT";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgPfEsi
            // 
            this.dgPfEsi.AllowUserToAddRows = false;
            this.dgPfEsi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPfEsi.BackgroundColor = System.Drawing.Color.White;
            this.dgPfEsi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPfEsi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPfEsi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eid,
            this.col_desgid,
            this.pf_bs,
            this.esi_bs,
            this.pf_contribution,
            this.esi_contribution,
            this.col_pf,
            this.col_esi,
            this.col_OT_act});
            this.dgPfEsi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPfEsi.Location = new System.Drawing.Point(3, 3);
            this.dgPfEsi.Name = "dgPfEsi";
            this.dgPfEsi.Size = new System.Drawing.Size(1117, 316);
            this.dgPfEsi.TabIndex = 309;
            // 
            // eid
            // 
            this.eid.DataPropertyName = "eid";
            this.eid.HeaderText = "eid";
            this.eid.Name = "eid";
            this.eid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_desgid
            // 
            this.col_desgid.DataPropertyName = "desgid";
            this.col_desgid.HeaderText = "Desg ID";
            this.col_desgid.Name = "col_desgid";
            // 
            // pf_bs
            // 
            this.pf_bs.DataPropertyName = "pf_bs";
            this.pf_bs.HeaderText = "pf_bs";
            this.pf_bs.Name = "pf_bs";
            this.pf_bs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // esi_bs
            // 
            this.esi_bs.DataPropertyName = "esi_bs";
            this.esi_bs.HeaderText = "esi_bs";
            this.esi_bs.Name = "esi_bs";
            this.esi_bs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pf_contribution
            // 
            this.pf_contribution.DataPropertyName = "pf_contribution";
            this.pf_contribution.HeaderText = "pf_contribution";
            this.pf_contribution.Name = "pf_contribution";
            this.pf_contribution.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // esi_contribution
            // 
            this.esi_contribution.DataPropertyName = "esi_contribution";
            this.esi_contribution.HeaderText = "esi_contribution";
            this.esi_contribution.Name = "esi_contribution";
            this.esi_contribution.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_pf
            // 
            this.col_pf.DataPropertyName = "pf";
            this.col_pf.HeaderText = "pf";
            this.col_pf.Name = "col_pf";
            // 
            // col_esi
            // 
            this.col_esi.DataPropertyName = "esi";
            this.col_esi.HeaderText = "esi";
            this.col_esi.Name = "col_esi";
            // 
            // col_OT_act
            // 
            this.col_OT_act.DataPropertyName = "OT";
            this.col_OT_act.HeaderText = "OT";
            this.col_OT_act.Name = "col_OT_act";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December",
            "January",
            "February",
            "March",
            "April"});
            this.cmbMonth.Location = new System.Drawing.Point(792, 265);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(118, 22);
            this.cmbMonth.TabIndex = 244;
            this.cmbMonth.Visible = false;
            this.cmbMonth.DropDownClosed += new System.EventHandler(this.cmbMonth_DropDownClosed);
            this.cmbMonth.DropDown += new System.EventHandler(this.cmbMonth_DropDown);
            // 
            // txtattendence
            // 
            this.txtattendence.Location = new System.Drawing.Point(916, 266);
            this.txtattendence.Name = "txtattendence";
            this.txtattendence.Size = new System.Drawing.Size(100, 20);
            this.txtattendence.TabIndex = 266;
            this.txtattendence.Visible = false;
            // 
            // earn_count
            // 
            this.earn_count.Location = new System.Drawing.Point(794, 294);
            this.earn_count.Name = "earn_count";
            this.earn_count.Size = new System.Drawing.Size(54, 20);
            this.earn_count.TabIndex = 267;
            this.earn_count.Visible = false;
            // 
            // ded_count
            // 
            this.ded_count.Location = new System.Drawing.Point(854, 294);
            this.ded_count.Name = "ded_count";
            this.ded_count.Size = new System.Drawing.Size(54, 20);
            this.ded_count.TabIndex = 268;
            this.ded_count.Visible = false;
            // 
            // btnclose_frm
            // 
            this.btnclose_frm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose_frm.BackColor = System.Drawing.Color.Transparent;
            this.btnclose_frm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose_frm.BackgroundImage")));
            this.btnclose_frm.ButtonText = "Close";
            this.btnclose_frm.Location = new System.Drawing.Point(1047, 112);
            this.btnclose_frm.Name = "btnclose_frm";
            this.btnclose_frm.Size = new System.Drawing.Size(80, 31);
            this.btnclose_frm.TabIndex = 275;
            this.btnclose_frm.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(881, 112);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 31);
            this.btnSubmit.TabIndex = 274;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnDeleteSal
            // 
            this.btnDeleteSal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSal.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteSal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteSal.BackgroundImage")));
            this.btnDeleteSal.ButtonText = "Delete";
            this.btnDeleteSal.Location = new System.Drawing.Point(964, 112);
            this.btnDeleteSal.Name = "btnDeleteSal";
            this.btnDeleteSal.Size = new System.Drawing.Size(80, 31);
            this.btnDeleteSal.TabIndex = 276;
            this.btnDeleteSal.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chkAuthorise);
            this.panel1.Controls.Add(this.lblStatusCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblOCP);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbltot);
            this.panel1.Controls.Add(this.grpOCP);
            this.panel1.Controls.Add(this.dtpidate);
            this.panel1.Controls.Add(this.btnDeleteSal);
            this.panel1.Controls.Add(this.cmbMonth);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.btnCalc);
            this.panel1.Controls.Add(this.btnclose_frm);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.txtattendence);
            this.panel1.Controls.Add(this.earn_count);
            this.panel1.Controls.Add(this.ded_count);
            this.panel1.Location = new System.Drawing.Point(0, 484);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 150);
            this.panel1.TabIndex = 277;
            // 
            // chkAuthorise
            // 
            this.chkAuthorise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAuthorise.AutoSize = true;
            this.chkAuthorise.Location = new System.Drawing.Point(796, 120);
            this.chkAuthorise.Name = "chkAuthorise";
            this.chkAuthorise.Size = new System.Drawing.Size(73, 18);
            this.chkAuthorise.TabIndex = 284;
            this.chkAuthorise.Text = "Authorise";
            this.chkAuthorise.UseVisualStyleBackColor = true;
            // 
            // lblStatusCode
            // 
            this.lblStatusCode.AutoSize = true;
            this.lblStatusCode.Location = new System.Drawing.Point(108, 215);
            this.lblStatusCode.Name = "lblStatusCode";
            this.lblStatusCode.Size = new System.Drawing.Size(35, 14);
            this.lblStatusCode.TabIndex = 283;
            this.lblStatusCode.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 14);
            this.label7.TabIndex = 282;
            this.label7.Text = "Status Code : ";
            // 
            // lblOCP
            // 
            this.lblOCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOCP.AutoSize = true;
            this.lblOCP.ForeColor = System.Drawing.Color.DarkRed;
            this.lblOCP.Location = new System.Drawing.Point(803, 40);
            this.lblOCP.Name = "lblOCP";
            this.lblOCP.Size = new System.Drawing.Size(253, 28);
            this.lblOCP.TabIndex = 281;
            this.lblOCP.Text = "** To add existing name press F2  in other charges \r\n     section else type in ot" +
                "her details";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtAgentName);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtAgentBank);
            this.groupBox4.Controls.Add(this.txtAgentAcno);
            this.groupBox4.Location = new System.Drawing.Point(792, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 35);
            this.groupBox4.TabIndex = 280;
            this.groupBox4.TabStop = false;
            this.groupBox4.Visible = false;
            // 
            // txtAgentName
            // 
            this.txtAgentName.Connection = null;
            this.txtAgentName.DialogResult = "";
            this.txtAgentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgentName.Location = new System.Drawing.Point(115, 33);
            this.txtAgentName.LOVFlag = 0;
            this.txtAgentName.MaxCharLength = 500;
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.ReturnIndex = -1;
            this.txtAgentName.ReturnValue = "";
            this.txtAgentName.ReturnValue_3rd = "";
            this.txtAgentName.ReturnValue_4th = "";
            this.txtAgentName.Size = new System.Drawing.Size(235, 21);
            this.txtAgentName.TabIndex = 284;
            this.txtAgentName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txtAgentName_DropDown);
            this.txtAgentName.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.txtAgentName_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Bank :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "A/C No. :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name : ";
            // 
            // txtAgentBank
            // 
            this.txtAgentBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgentBank.Location = new System.Drawing.Point(115, 90);
            this.txtAgentBank.Multiline = true;
            this.txtAgentBank.Name = "txtAgentBank";
            this.txtAgentBank.Size = new System.Drawing.Size(235, 46);
            this.txtAgentBank.TabIndex = 0;
            // 
            // txtAgentAcno
            // 
            this.txtAgentAcno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgentAcno.Location = new System.Drawing.Point(115, 62);
            this.txtAgentAcno.Name = "txtAgentAcno";
            this.txtAgentAcno.Size = new System.Drawing.Size(235, 20);
            this.txtAgentAcno.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(950, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 14);
            this.label1.TabIndex = 279;
            this.label1.Text = "Total : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbltot
            // 
            this.lbltot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltot.Location = new System.Drawing.Point(995, 7);
            this.lbltot.Name = "lbltot";
            this.lbltot.Size = new System.Drawing.Size(106, 14);
            this.lbltot.TabIndex = 278;
            this.lbltot.Text = "0";
            this.lbltot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpOCP
            // 
            this.grpOCP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grpOCP.Controls.Add(this.dgvOtherCharges);
            this.grpOCP.Location = new System.Drawing.Point(17, 6);
            this.grpOCP.Name = "grpOCP";
            this.grpOCP.Size = new System.Drawing.Size(769, 138);
            this.grpOCP.TabIndex = 277;
            this.grpOCP.TabStop = false;
            this.grpOCP.Text = "Other Charges paid";
            // 
            // dgvOtherCharges
            // 
            this.dgvOtherCharges.BackgroundColor = System.Drawing.Color.White;
            this.dgvOtherCharges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOtherCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherCharges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgColID,
            this.dgColOCharge,
            this.dgColVal,
            this.dgColOName,
            this.dgColOBank,
            this.dgColOBranch,
            this.dgColOAc,
            this.dgColOIfsc});
            this.dgvOtherCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOtherCharges.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvOtherCharges.GridColor = System.Drawing.Color.Silver;
            this.dgvOtherCharges.Location = new System.Drawing.Point(3, 16);
            this.dgvOtherCharges.Name = "dgvOtherCharges";
            this.dgvOtherCharges.Size = new System.Drawing.Size(763, 119);
            this.dgvOtherCharges.TabIndex = 0;
            this.dgvOtherCharges.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOtherCharges_KeyDown);
            // 
            // dgColID
            // 
            this.dgColID.HeaderText = "ID";
            this.dgColID.Name = "dgColID";
            this.dgColID.Visible = false;
            // 
            // dgColOCharge
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgColOCharge.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgColOCharge.FillWeight = 250F;
            this.dgColOCharge.HeaderText = "Other Charges Head";
            this.dgColOCharge.Name = "dgColOCharge";
            this.dgColOCharge.Width = 250;
            // 
            // dgColVal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.dgColVal.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgColVal.HeaderText = "Charges";
            this.dgColVal.Name = "dgColVal";
            // 
            // dgColOName
            // 
            this.dgColOName.HeaderText = "Name";
            this.dgColOName.Name = "dgColOName";
            // 
            // dgColOBank
            // 
            this.dgColOBank.HeaderText = "Bank";
            this.dgColOBank.Name = "dgColOBank";
            // 
            // dgColOBranch
            // 
            this.dgColOBranch.HeaderText = "Branch";
            this.dgColOBranch.Name = "dgColOBranch";
            // 
            // dgColOAc
            // 
            this.dgColOAc.HeaderText = "Ac No";
            this.dgColOAc.Name = "dgColOAc";
            // 
            // dgColOIfsc
            // 
            this.dgColOIfsc.HeaderText = "IFSC";
            this.dgColOIfsc.Name = "dgColOIfsc";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPreview.BackgroundImage")));
            this.btnPreview.ButtonText = "Preview";
            this.btnPreview.Location = new System.Drawing.Point(962, 78);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(70, 31);
            this.btnPreview.TabIndex = 275;
            this.btnPreview.Visible = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.BackColor = System.Drawing.Color.Transparent;
            this.btnCalc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalc.BackgroundImage")));
            this.btnCalc.ButtonText = "ReCalculate";
            this.btnCalc.Location = new System.Drawing.Point(1034, 78);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(93, 31);
            this.btnCalc.TabIndex = 275;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // pnl_load
            // 
            this.pnl_load.BackColor = System.Drawing.Color.White;
            this.pnl_load.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_load.Controls.Add(this.label10);
            this.pnl_load.Controls.Add(this.lbl_load_msg);
            this.pnl_load.Location = new System.Drawing.Point(411, 226);
            this.pnl_load.Name = "pnl_load";
            this.pnl_load.Size = new System.Drawing.Size(314, 182);
            this.pnl_load.TabIndex = 278;
            this.pnl_load.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(78, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 29);
            this.label10.TabIndex = 267;
            this.label10.Text = "Please wait... ";
            // 
            // lbl_load_msg
            // 
            this.lbl_load_msg.AutoSize = true;
            this.lbl_load_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_load_msg.ForeColor = System.Drawing.Color.Black;
            this.lbl_load_msg.Location = new System.Drawing.Point(107, 92);
            this.lbl_load_msg.Name = "lbl_load_msg";
            this.lbl_load_msg.Size = new System.Drawing.Size(104, 16);
            this.lbl_load_msg.TabIndex = 267;
            this.lbl_load_msg.Text = "Please wait... ";
            // 
            // lblPayslip
            // 
            this.lblPayslip.AutoSize = true;
            this.lblPayslip.Location = new System.Drawing.Point(1085, 90);
            this.lblPayslip.Name = "lblPayslip";
            this.lblPayslip.Size = new System.Drawing.Size(0, 14);
            this.lblPayslip.TabIndex = 333;
            this.lblPayslip.Visible = false;
            // 
            // frmsalarystructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1137, 634);
            this.Controls.Add(this.pnl_load);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmsalarystructure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Sheet";
            this.Load += new System.EventHandler(this.frmsalarystructure_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmsalarystructure_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmsalarystructure_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGross)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecoveries)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPfEsi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpOCP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherCharges)).EndInit();
            this.pnl_load.ResumeLayout(false);
            this.pnl_load.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalary;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private System.Windows.Forms.Label lblidate;
        private System.Windows.Forms.DateTimePicker dtpidate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox cmbYear;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.TextBox txtattendence;
        private System.Windows.Forms.TextBox earn_count;
        private System.Windows.Forms.TextBox ded_count;
        private EDPComponent.VistaButton btnclose_frm;
        private EDPComponent.VistaButton btnSubmit;
        private System.Windows.Forms.TextBox txtcalculated_days;
        private EDPComponent.VistaButton btnDeleteSal;
        private System.Windows.Forms.Panel panel1;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.GroupBox grpOCP;
        private System.Windows.Forms.DataGridView dgvOtherCharges;
        private System.Windows.Forms.Label lbltot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAgentBank;
        private System.Windows.Forms.TextBox txtAgentAcno;
        private EDPComponent.ComboDialog txtAgentName;
        private System.Windows.Forms.Label lblEarning;
        private System.Windows.Forms.Label lbl_Chk_K;
        private System.Windows.Forms.Label lbl_Chk_L;
        private System.Windows.Forms.Label lbl_Chk_A;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOAc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgColOIfsc;
        private System.Windows.Forms.Label lblOCP;
        private System.Windows.Forms.Label lblStatusCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkAuthorise;
        private System.Windows.Forms.DateTimePicker dtp_copy;
        private System.Windows.Forms.DataGridView dgPfEsi;
        private System.Windows.Forms.CheckBox chkAllLocation;
        private EDPComponent.ComboDialog cmbZone;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtp_DOE;
        internal System.Windows.Forms.Label label9;
        private EDPComponent.VistaButton btnCalc;
        private System.Windows.Forms.Label lbl_Pf_formula;
        private System.Windows.Forms.Label lbl_pt_formula;
        private System.Windows.Forms.Label lbl_esi_formula;
        private System.Windows.Forms.Label Lbl_pf_head;
        private System.Windows.Forms.Label lblEsi_limit;
        private System.Windows.Forms.Label lblpf_limit;
        private System.Windows.Forms.DataGridView dgvGross;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblClid;
        private System.Windows.Forms.Label lbl_WO;
        private System.Windows.Forms.Label lbl_ot_hrs;
        private System.Windows.Forms.Label lbl_wd_hrs;
        private System.Windows.Forms.Label lbl_ed_hrs;
        private EDPComponent.VistaButton btnPreview;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnl_load;
        private System.Windows.Forms.Label lbl_load_msg;
        private System.Windows.Forms.Label lbl_time_to;
        private System.Windows.Forms.Label lbl_Time_from;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblEsi_empl;
        private System.Windows.Forms.Label lbl_mod;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvRecoveries;
        private System.Windows.Forms.DataGridViewTextBoxColumn eid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desgid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pf_bs;
        private System.Windows.Forms.DataGridViewTextBoxColumn esi_bs;
        private System.Windows.Forms.DataGridViewTextBoxColumn pf_contribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn esi_contribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pf;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_esi;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_OT_act;
        private System.Windows.Forms.Label lbl_Accpt_wd_hrs;
        private System.Windows.Forms.Label lbl_Accpt_ot_hrs;
        private System.Windows.Forms.Label lbl_Accpt_ed_hrs;
        private System.Windows.Forms.Label lbl_limit_gross;
        private System.Windows.Forms.Label lbl_limit_gross_esi;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lbl_payslip;
        private System.Windows.Forms.Label lblPayslip;
    }
}