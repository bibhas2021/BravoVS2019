namespace PayRollManagementSystem
{
    partial class frmEmployeeSalarySheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeSalarySheet));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_copy = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chk_os_Loan = new System.Windows.Forms.CheckBox();
            this.chk_os_Kit = new System.Windows.Forms.CheckBox();
            this.chk_os_adv = new System.Windows.Forms.CheckBox();
            this.cmbSalarySheetType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbLegal = new System.Windows.Forms.RadioButton();
            this.rdbA4 = new System.Windows.Forms.RadioButton();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnExp2 = new EDPComponent.VistaButton();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.btnExp = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdb_Co_LocConsolidate = new System.Windows.Forms.RadioButton();
            this.rdb_Co_Consolidated = new System.Windows.Forms.RadioButton();
            this.rdbCo_details = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_company = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStatusCode = new System.Windows.Forms.Label();
            this.tbStatusWindowPass = new System.Windows.Forms.TextBox();
            this.lbl_mod = new System.Windows.Forms.Label();
            this.lbl_NC = new System.Windows.Forms.Label();
            this.lbl_OT = new System.Windows.Forms.Label();
            this.lbl_ED = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_copy);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cmbSalarySheetType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(14, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 272);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dtp_copy
            // 
            this.dtp_copy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_copy.Location = new System.Drawing.Point(79, 34);
            this.dtp_copy.Name = "dtp_copy";
            this.dtp_copy.Size = new System.Drawing.Size(88, 20);
            this.dtp_copy.TabIndex = 264;
            this.dtp_copy.Visible = false;
            this.dtp_copy.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_ED);
            this.groupBox3.Controls.Add(this.lbl_OT);
            this.groupBox3.Controls.Add(this.lbl_NC);
            this.groupBox3.Controls.Add(this.chk_os_Loan);
            this.groupBox3.Controls.Add(this.chk_os_Kit);
            this.groupBox3.Controls.Add(this.chk_os_adv);
            this.groupBox3.Location = new System.Drawing.Point(290, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 79);
            this.groupBox3.TabIndex = 268;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Outstanding Balance";
            // 
            // chk_os_Loan
            // 
            this.chk_os_Loan.AutoSize = true;
            this.chk_os_Loan.Location = new System.Drawing.Point(85, 57);
            this.chk_os_Loan.Name = "chk_os_Loan";
            this.chk_os_Loan.Size = new System.Drawing.Size(81, 17);
            this.chk_os_Loan.TabIndex = 0;
            this.chk_os_Loan.Text = "Loan O/S";
            this.chk_os_Loan.UseVisualStyleBackColor = true;
            // 
            // chk_os_Kit
            // 
            this.chk_os_Kit.AutoSize = true;
            this.chk_os_Kit.Location = new System.Drawing.Point(85, 38);
            this.chk_os_Kit.Name = "chk_os_Kit";
            this.chk_os_Kit.Size = new System.Drawing.Size(68, 17);
            this.chk_os_Kit.TabIndex = 0;
            this.chk_os_Kit.Text = "Kit O/S";
            this.chk_os_Kit.UseVisualStyleBackColor = true;
            // 
            // chk_os_adv
            // 
            this.chk_os_adv.AutoSize = true;
            this.chk_os_adv.Location = new System.Drawing.Point(85, 19);
            this.chk_os_adv.Name = "chk_os_adv";
            this.chk_os_adv.Size = new System.Drawing.Size(103, 17);
            this.chk_os_adv.TabIndex = 0;
            this.chk_os_adv.Text = "Advance O/S";
            this.chk_os_adv.UseVisualStyleBackColor = true;
            // 
            // cmbSalarySheetType
            // 
            this.cmbSalarySheetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalarySheetType.FormattingEnabled = true;
            this.cmbSalarySheetType.Items.AddRange(new object[] {
            "Locationwise Salary Sheet Preview",
            "Companywise Salary Sheet Preview"});
            this.cmbSalarySheetType.Location = new System.Drawing.Point(186, 15);
            this.cmbSalarySheetType.Name = "cmbSalarySheetType";
            this.cmbSalarySheetType.Size = new System.Drawing.Size(372, 21);
            this.cmbSalarySheetType.TabIndex = 267;
            this.cmbSalarySheetType.SelectedIndexChanged += new System.EventHandler(this.cmbSalarySheetType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 15);
            this.label4.TabIndex = 266;
            this.label4.Text = "Select Salary Sheet Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rdbLegal);
            this.groupBox2.Controls.Add(this.rdbA4);
            this.groupBox2.Controls.Add(this.AttenDtTmPkr);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Location = new System.Drawing.Point(7, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 66);
            this.groupBox2.TabIndex = 265;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 266;
            this.label2.Text = "Print in";
            // 
            // rdbLegal
            // 
            this.rdbLegal.AutoSize = true;
            this.rdbLegal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbLegal.Location = new System.Drawing.Point(169, 45);
            this.rdbLegal.Name = "rdbLegal";
            this.rdbLegal.Size = new System.Drawing.Size(55, 17);
            this.rdbLegal.TabIndex = 265;
            this.rdbLegal.Text = "Legal";
            this.rdbLegal.UseVisualStyleBackColor = true;
            // 
            // rdbA4
            // 
            this.rdbA4.AutoSize = true;
            this.rdbA4.Checked = true;
            this.rdbA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbA4.Location = new System.Drawing.Point(122, 44);
            this.rdbA4.Name = "rdbA4";
            this.rdbA4.Size = new System.Drawing.Size(39, 17);
            this.rdbA4.TabIndex = 265;
            this.rdbA4.TabStop = true;
            this.rdbA4.Text = "A4";
            this.rdbA4.UseVisualStyleBackColor = true;
            this.rdbA4.CheckedChanged += new System.EventHandler(this.rdbA4_CheckedChanged);
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(122, 19);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(140, 20);
            this.AttenDtTmPkr.TabIndex = 264;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(15, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 13);
            this.label21.TabIndex = 260;
            this.label21.Text = "For The Month of";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnExp2);
            this.groupBox7.Controls.Add(this.chkClient);
            this.groupBox7.Controls.Add(this.btnExp);
            this.groupBox7.Controls.Add(this.btnPreview);
            this.groupBox7.Controls.Add(this.btnClose);
            this.groupBox7.Controls.Add(this.btnPrnt);
            this.groupBox7.Location = new System.Drawing.Point(7, 216);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(551, 50);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Print Details";
            // 
            // btnExp2
            // 
            this.btnExp2.BackColor = System.Drawing.Color.Transparent;
            this.btnExp2.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExp2.ButtonText = "Export To Excel";
            this.btnExp2.CornerRadius = 4;
            this.btnExp2.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExp2.Location = new System.Drawing.Point(161, 13);
            this.btnExp2.Name = "btnExp2";
            this.btnExp2.Size = new System.Drawing.Size(10, 30);
            this.btnExp2.TabIndex = 25;
            this.btnExp2.Visible = false;
            this.btnExp2.Click += new System.EventHandler(this.btnExp2_Click);
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.Checked = true;
            this.chkClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClient.Location = new System.Drawing.Point(10, 19);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(156, 17);
            this.chkClient.TabIndex = 24;
            this.chkClient.Text = "Display Client-Location";
            this.chkClient.UseVisualStyleBackColor = true;
            this.chkClient.Visible = false;
            // 
            // btnExp
            // 
            this.btnExp.BackColor = System.Drawing.Color.Transparent;
            this.btnExp.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExp.ButtonText = "Export To Excel";
            this.btnExp.CornerRadius = 4;
            this.btnExp.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExp.Location = new System.Drawing.Point(173, 13);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(110, 30);
            this.btnExp.TabIndex = 23;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(286, 13);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 30);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(450, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 30);
            this.btnClose.TabIndex = 18;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrnt
            // 
            this.btnPrnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrnt.ButtonText = "     Print";
            this.btnPrnt.CornerRadius = 4;
            this.btnPrnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrnt.Location = new System.Drawing.Point(365, 13);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(79, 30);
            this.btnPrnt.TabIndex = 17;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdb_Co_LocConsolidate);
            this.groupBox4.Controls.Add(this.rdb_Co_Consolidated);
            this.groupBox4.Controls.Add(this.rdbCo_details);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cmbcompany);
            this.groupBox4.Controls.Add(this.cmbLocation);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cmbYear);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.lbl_company);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Location = new System.Drawing.Point(7, 40);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(551, 98);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // rdb_Co_LocConsolidate
            // 
            this.rdb_Co_LocConsolidate.AutoSize = true;
            this.rdb_Co_LocConsolidate.Location = new System.Drawing.Point(368, 29);
            this.rdb_Co_LocConsolidate.Name = "rdb_Co_LocConsolidate";
            this.rdb_Co_LocConsolidate.Size = new System.Drawing.Size(179, 17);
            this.rdb_Co_LocConsolidate.TabIndex = 313;
            this.rdb_Co_LocConsolidate.TabStop = true;
            this.rdb_Co_LocConsolidate.Text = "LocationWise Consolidated";
            this.rdb_Co_LocConsolidate.UseVisualStyleBackColor = true;
            // 
            // rdb_Co_Consolidated
            // 
            this.rdb_Co_Consolidated.AutoSize = true;
            this.rdb_Co_Consolidated.Location = new System.Drawing.Point(432, 9);
            this.rdb_Co_Consolidated.Name = "rdb_Co_Consolidated";
            this.rdb_Co_Consolidated.Size = new System.Drawing.Size(98, 17);
            this.rdb_Co_Consolidated.TabIndex = 312;
            this.rdb_Co_Consolidated.TabStop = true;
            this.rdb_Co_Consolidated.Text = "Consolidated";
            this.rdb_Co_Consolidated.UseVisualStyleBackColor = true;
            // 
            // rdbCo_details
            // 
            this.rdbCo_details.AutoSize = true;
            this.rdbCo_details.Location = new System.Drawing.Point(368, 10);
            this.rdbCo_details.Name = "rdbCo_details";
            this.rdbCo_details.Size = new System.Drawing.Size(58, 17);
            this.rdbCo_details.TabIndex = 311;
            this.rdbCo_details.TabStop = true;
            this.rdbCo_details.Text = "Detail";
            this.rdbCo_details.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(237, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 15);
            this.label6.TabIndex = 310;
            this.label6.Text = "Salary Printing Option";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(73, 69);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(470, 21);
            this.cmbcompany.TabIndex = 309;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(73, 46);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(470, 21);
            this.cmbLocation.TabIndex = 308;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 265;
            this.label5.Text = "Location";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(73, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(137, 21);
            this.cmbYear.TabIndex = 259;
            this.cmbYear.DropDown += new System.EventHandler(this.cmbYear_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 267;
            this.label3.Text = "Company";
            this.label3.Visible = false;
            // 
            // lbl_company
            // 
            this.lbl_company.AutoSize = true;
            this.lbl_company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_company.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_company.Location = new System.Drawing.Point(543, 24);
            this.lbl_company.Name = "lbl_company";
            this.lbl_company.Size = new System.Drawing.Size(2, 16);
            this.lbl_company.TabIndex = 266;
            this.lbl_company.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 258;
            this.label22.Text = "Session";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 51);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Salary Sheet";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(539, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(592, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(10, 10);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Status Code : ";
            // 
            // lblStatusCode
            // 
            this.lblStatusCode.AutoSize = true;
            this.lblStatusCode.Location = new System.Drawing.Point(121, 319);
            this.lblStatusCode.Name = "lblStatusCode";
            this.lblStatusCode.Size = new System.Drawing.Size(41, 13);
            this.lblStatusCode.TabIndex = 19;
            this.lblStatusCode.Text = "label8";
            // 
            // tbStatusWindowPass
            // 
            this.tbStatusWindowPass.Location = new System.Drawing.Point(168, 319);
            this.tbStatusWindowPass.Name = "tbStatusWindowPass";
            this.tbStatusWindowPass.Size = new System.Drawing.Size(96, 20);
            this.tbStatusWindowPass.TabIndex = 20;
            this.tbStatusWindowPass.Visible = false;
            // 
            // lbl_mod
            // 
            this.lbl_mod.AutoSize = true;
            this.lbl_mod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_mod.Location = new System.Drawing.Point(298, 194);
            this.lbl_mod.Name = "lbl_mod";
            this.lbl_mod.Size = new System.Drawing.Size(2, 15);
            this.lbl_mod.TabIndex = 329;
            this.lbl_mod.Visible = false;
            // 
            // lbl_NC
            // 
            this.lbl_NC.AutoSize = true;
            this.lbl_NC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_NC.Location = new System.Drawing.Point(219, 23);
            this.lbl_NC.Name = "lbl_NC";
            this.lbl_NC.Size = new System.Drawing.Size(2, 15);
            this.lbl_NC.TabIndex = 1;
            this.lbl_NC.Visible = false;
            // 
            // lbl_OT
            // 
            this.lbl_OT.AutoSize = true;
            this.lbl_OT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_OT.Location = new System.Drawing.Point(219, 42);
            this.lbl_OT.Name = "lbl_OT";
            this.lbl_OT.Size = new System.Drawing.Size(2, 15);
            this.lbl_OT.TabIndex = 1;
            this.lbl_OT.Visible = false;
            // 
            // lbl_ED
            // 
            this.lbl_ED.AutoSize = true;
            this.lbl_ED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ED.Location = new System.Drawing.Point(219, 61);
            this.lbl_ED.Name = "lbl_ED";
            this.lbl_ED.Size = new System.Drawing.Size(2, 15);
            this.lbl_ED.TabIndex = 1;
            this.lbl_ED.Visible = false;
            // 
            // frmEmployeeSalarySheet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(605, 355);
            this.Controls.Add(this.lbl_mod);
            this.Controls.Add(this.tbStatusWindowPass);
            this.Controls.Add(this.lblStatusCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(605, 355);
            this.MinimumSize = new System.Drawing.Size(605, 340);
            this.Name = "frmEmployeeSalarySheet";
            this.Text = "EmployeeSalarySheet";
            this.Load += new System.EventHandler(this.frmEmployeeSalarySheet_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEmployeeSalarySheet_KeyPress);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEmployeeSalarySheet_KeyDown);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.lblStatusCode, 0);
            this.Controls.SetChildIndex(this.tbStatusWindowPass, 0);
            this.Controls.SetChildIndex(this.lbl_mod, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnPrnt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private EDPComponent.VistaButton btnExp;
        private System.Windows.Forms.Label lbl_company;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbLegal;
        private System.Windows.Forms.RadioButton rdbA4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbSalarySheetType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdb_Co_Consolidated;
        private System.Windows.Forms.RadioButton rdbCo_details;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStatusCode;
        private System.Windows.Forms.TextBox tbStatusWindowPass;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chk_os_Loan;
        private System.Windows.Forms.CheckBox chk_os_Kit;
        private System.Windows.Forms.CheckBox chk_os_adv;
        public EDPComponent.ComboDialog cmbLocation;
        public EDPComponent.ComboDialog cmbcompany;
        public System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        public System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.DateTimePicker dtp_copy;
        private System.Windows.Forms.RadioButton rdb_Co_LocConsolidate;
        private System.Windows.Forms.Label lbl_mod;
        private System.Windows.Forms.CheckBox chkClient;
        private EDPComponent.VistaButton btnExp2;
        private System.Windows.Forms.Label lbl_ED;
        private System.Windows.Forms.Label lbl_OT;
        private System.Windows.Forms.Label lbl_NC;
    }
}