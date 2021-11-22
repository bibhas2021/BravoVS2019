namespace PayRollManagementSystem
{
    partial class frmBankPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankPayment));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkCompany = new System.Windows.Forms.CheckBox();
            this.btnMultiLocation = new System.Windows.Forms.Button();
            this.chk_multiSelect = new System.Windows.Forms.CheckBox();
            this.rdbLoan = new System.Windows.Forms.RadioButton();
            this.rdbAdvance = new System.Windows.Forms.RadioButton();
            this.rdbSalary = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDesignation = new System.Windows.Forms.TextBox();
            this.LblDesignation = new System.Windows.Forms.Label();
            this.txtTagline = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtAccountNo = new System.Windows.Forms.TextBox();
            this.LblAccountNo = new System.Windows.Forms.Label();
            this.LblBankName = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.TxtBankName = new EDPComponent.ComboDialog();
            this.CmbLocation = new EDPComponent.ComboDialog();
            this.chk_All_Emp = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnExport = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.img_close = new System.Windows.Forms.PictureBox();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBr = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbBankLetter = new System.Windows.Forms.RadioButton();
            this.rdbCMS = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbXL3 = new System.Windows.Forms.RadioButton();
            this.rdbKVB = new System.Windows.Forms.RadioButton();
            this.rdbHDFC = new System.Windows.Forms.RadioButton();
            this.rdbXL2 = new System.Windows.Forms.RadioButton();
            this.rdbXL1 = new System.Windows.Forms.RadioButton();
            this.rdbBob = new System.Windows.Forms.RadioButton();
            this.rdbBL = new System.Windows.Forms.RadioButton();
            this.lbl_ifsc = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblBnkCode = new System.Windows.Forms.Label();
            this.chkNC = new System.Windows.Forms.CheckBox();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.CmbYear);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.AttenDtTmPkr);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(22, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 46);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            // 
            // CmbYear
            // 
            this.CmbYear.BackColor = System.Drawing.Color.White;
            this.CmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbYear.FormattingEnabled = true;
            this.CmbYear.Location = new System.Drawing.Point(91, 14);
            this.CmbYear.Name = "CmbYear";
            this.CmbYear.Size = new System.Drawing.Size(161, 21);
            this.CmbYear.TabIndex = 259;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(6, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 258;
            this.label22.Text = "Session";
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(333, 14);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(133, 20);
            this.AttenDtTmPkr.TabIndex = 264;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(290, 19);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 260;
            this.label21.Text = "Month";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.chkCompany);
            this.groupBox2.Controls.Add(this.btnMultiLocation);
            this.groupBox2.Controls.Add(this.chk_multiSelect);
            this.groupBox2.Controls.Add(this.rdbLoan);
            this.groupBox2.Controls.Add(this.rdbAdvance);
            this.groupBox2.Controls.Add(this.rdbSalary);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtDesignation);
            this.groupBox2.Controls.Add(this.LblDesignation);
            this.groupBox2.Controls.Add(this.txtTagline);
            this.groupBox2.Controls.Add(this.txtCity);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TxtAccountNo);
            this.groupBox2.Controls.Add(this.LblAccountNo);
            this.groupBox2.Controls.Add(this.LblBankName);
            this.groupBox2.Controls.Add(this.Button1);
            this.groupBox2.Controls.Add(this.TxtBankName);
            this.groupBox2.Controls.Add(this.CmbLocation);
            this.groupBox2.Controls.Add(this.chk_All_Emp);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CmbCompany);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(22, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 312);
            this.groupBox2.TabIndex = 266;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Details";
            // 
            // chkCompany
            // 
            this.chkCompany.AutoSize = true;
            this.chkCompany.Location = new System.Drawing.Point(9, 37);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Size = new System.Drawing.Size(97, 17);
            this.chkCompany.TabIndex = 321;
            this.chkCompany.Text = "Company Wise";
            this.chkCompany.UseVisualStyleBackColor = true;
            this.chkCompany.CheckedChanged += new System.EventHandler(this.chkCompany_CheckedChanged);
            // 
            // btnMultiLocation
            // 
            this.btnMultiLocation.Location = new System.Drawing.Point(91, 80);
            this.btnMultiLocation.Name = "btnMultiLocation";
            this.btnMultiLocation.Size = new System.Drawing.Size(161, 22);
            this.btnMultiLocation.TabIndex = 320;
            this.btnMultiLocation.Text = "Select";
            this.btnMultiLocation.UseVisualStyleBackColor = true;
            this.btnMultiLocation.Click += new System.EventHandler(this.btnMultiLocation_Click);
            // 
            // chk_multiSelect
            // 
            this.chk_multiSelect.AutoSize = true;
            this.chk_multiSelect.Location = new System.Drawing.Point(7, 83);
            this.chk_multiSelect.Name = "chk_multiSelect";
            this.chk_multiSelect.Size = new System.Drawing.Size(81, 17);
            this.chk_multiSelect.TabIndex = 319;
            this.chk_multiSelect.Text = "Multi Select";
            this.chk_multiSelect.UseVisualStyleBackColor = true;
            this.chk_multiSelect.CheckedChanged += new System.EventHandler(this.chk_multiSelect_CheckedChanged);
            // 
            // rdbLoan
            // 
            this.rdbLoan.AutoSize = true;
            this.rdbLoan.Location = new System.Drawing.Point(91, 292);
            this.rdbLoan.Name = "rdbLoan";
            this.rdbLoan.Size = new System.Drawing.Size(49, 17);
            this.rdbLoan.TabIndex = 318;
            this.rdbLoan.TabStop = true;
            this.rdbLoan.Text = "Loan";
            this.rdbLoan.UseVisualStyleBackColor = true;
            this.rdbLoan.Visible = false;
            this.rdbLoan.CheckedChanged += new System.EventHandler(this.rdbSalary_CheckedChanged);
            // 
            // rdbAdvance
            // 
            this.rdbAdvance.AutoSize = true;
            this.rdbAdvance.Location = new System.Drawing.Point(91, 277);
            this.rdbAdvance.Name = "rdbAdvance";
            this.rdbAdvance.Size = new System.Drawing.Size(68, 17);
            this.rdbAdvance.TabIndex = 318;
            this.rdbAdvance.TabStop = true;
            this.rdbAdvance.Text = "Advance";
            this.rdbAdvance.UseVisualStyleBackColor = true;
            this.rdbAdvance.Visible = false;
            // 
            // rdbSalary
            // 
            this.rdbSalary.AutoSize = true;
            this.rdbSalary.Checked = true;
            this.rdbSalary.Location = new System.Drawing.Point(91, 262);
            this.rdbSalary.Name = "rdbSalary";
            this.rdbSalary.Size = new System.Drawing.Size(54, 17);
            this.rdbSalary.TabIndex = 318;
            this.rdbSalary.TabStop = true;
            this.rdbSalary.Text = "Salary";
            this.rdbSalary.UseVisualStyleBackColor = true;
            this.rdbSalary.CheckedChanged += new System.EventHandler(this.rdbSalary_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 317;
            this.label4.Text = "Pay for";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 316;
            this.label3.Text = "Tag Line";
            // 
            // TxtDesignation
            // 
            this.TxtDesignation.Location = new System.Drawing.Point(91, 164);
            this.TxtDesignation.Multiline = true;
            this.TxtDesignation.Name = "TxtDesignation";
            this.TxtDesignation.Size = new System.Drawing.Size(375, 44);
            this.TxtDesignation.TabIndex = 314;
            // 
            // LblDesignation
            // 
            this.LblDesignation.AutoSize = true;
            this.LblDesignation.Location = new System.Drawing.Point(6, 167);
            this.LblDesignation.Name = "LblDesignation";
            this.LblDesignation.Size = new System.Drawing.Size(83, 26);
            this.LblDesignation.TabIndex = 313;
            this.LblDesignation.Text = "Issued By\r\nwith designation";
            // 
            // txtTagline
            // 
            this.txtTagline.Location = new System.Drawing.Point(91, 214);
            this.txtTagline.Multiline = true;
            this.txtTagline.Name = "txtTagline";
            this.txtTagline.Size = new System.Drawing.Size(375, 43);
            this.txtTagline.TabIndex = 315;
            // 
            // txtCity
            // 
            this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCity.Location = new System.Drawing.Point(333, 133);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(133, 20);
            this.txtCity.TabIndex = 312;
            this.txtCity.Text = "KOLKATA";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 311;
            this.label1.Text = "City";
            // 
            // TxtAccountNo
            // 
            this.TxtAccountNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtAccountNo.Location = new System.Drawing.Point(91, 133);
            this.TxtAccountNo.Name = "TxtAccountNo";
            this.TxtAccountNo.Size = new System.Drawing.Size(200, 20);
            this.TxtAccountNo.TabIndex = 312;
            // 
            // LblAccountNo
            // 
            this.LblAccountNo.AccessibleDescription = "";
            this.LblAccountNo.AutoSize = true;
            this.LblAccountNo.Location = new System.Drawing.Point(6, 137);
            this.LblAccountNo.Name = "LblAccountNo";
            this.LblAccountNo.Size = new System.Drawing.Size(67, 13);
            this.LblAccountNo.TabIndex = 311;
            this.LblAccountNo.Text = "Account No.";
            // 
            // LblBankName
            // 
            this.LblBankName.AutoSize = true;
            this.LblBankName.Location = new System.Drawing.Point(6, 113);
            this.LblBankName.Name = "LblBankName";
            this.LblBankName.Size = new System.Drawing.Size(63, 13);
            this.LblBankName.TabIndex = 308;
            this.LblBankName.Text = "Bank Name";
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(353, 273);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(113, 27);
            this.Button1.TabIndex = 306;
            this.Button1.Text = "Select Employee";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // TxtBankName
            // 
            this.TxtBankName.BackColor = System.Drawing.Color.White;
            this.TxtBankName.Connection = null;
            this.TxtBankName.DialogResult = "";
            this.TxtBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBankName.Location = new System.Drawing.Point(91, 108);
            this.TxtBankName.LOVFlag = 0;
            this.TxtBankName.MaxCharLength = 500;
            this.TxtBankName.Name = "TxtBankName";
            this.TxtBankName.ReturnIndex = -1;
            this.TxtBankName.ReturnValue = "";
            this.TxtBankName.ReturnValue_3rd = "";
            this.TxtBankName.ReturnValue_4th = "";
            this.TxtBankName.Size = new System.Drawing.Size(375, 21);
            this.TxtBankName.TabIndex = 307;
            this.TxtBankName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.TxtBankName_DropDown);
            this.TxtBankName.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.TxtBankName_CloseUp);
            // 
            // CmbLocation
            // 
            this.CmbLocation.BackColor = System.Drawing.Color.White;
            this.CmbLocation.Connection = null;
            this.CmbLocation.DialogResult = "";
            this.CmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLocation.Location = new System.Drawing.Point(91, 56);
            this.CmbLocation.LOVFlag = 0;
            this.CmbLocation.MaxCharLength = 500;
            this.CmbLocation.Name = "CmbLocation";
            this.CmbLocation.ReturnIndex = -1;
            this.CmbLocation.ReturnValue = "";
            this.CmbLocation.ReturnValue_3rd = "";
            this.CmbLocation.ReturnValue_4th = "";
            this.CmbLocation.Size = new System.Drawing.Size(375, 21);
            this.CmbLocation.TabIndex = 307;
            this.CmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.CmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // chk_All_Emp
            // 
            this.chk_All_Emp.AutoSize = true;
            this.chk_All_Emp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chk_All_Emp.Location = new System.Drawing.Point(206, 278);
            this.chk_All_Emp.Name = "chk_All_Emp";
            this.chk_All_Emp.Size = new System.Drawing.Size(144, 18);
            this.chk_All_Emp.TabIndex = 303;
            this.chk_All_Emp.Text = "Select All Employee";
            this.chk_All_Emp.UseVisualStyleBackColor = true;
            this.chk_All_Emp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 293;
            this.label6.Text = "Company Name";
            // 
            // CmbCompany
            // 
            this.CmbCompany.BackColor = System.Drawing.Color.White;
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(91, 14);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(375, 21);
            this.CmbCompany.TabIndex = 292;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 265;
            this.label5.Text = "Location";
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.White;
            this.groupBox7.Controls.Add(this.chkNC);
            this.groupBox7.Controls.Add(this.btnExport);
            this.groupBox7.Controls.Add(this.btnPreview);
            this.groupBox7.Controls.Add(this.btnClose);
            this.groupBox7.Controls.Add(this.btnPrnt);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(22, 448);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 47);
            this.groupBox7.TabIndex = 267;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Print Details";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.ButtonText = "Click to Preview / Export";
            this.btnExport.CornerRadius = 4;
            this.btnExport.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExport.Location = new System.Drawing.Point(214, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(166, 31);
            this.btnExport.TabIndex = 22;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.Click += new System.EventHandler(this.vistaButton1_Click_1);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.Enabled = false;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(214, 10);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(386, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 18;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Click += new System.EventHandler(this.img_close_Click);
            // 
            // btnPrnt
            // 
            this.btnPrnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrnt.ButtonText = "     Print";
            this.btnPrnt.CornerRadius = 4;
            this.btnPrnt.Enabled = false;
            this.btnPrnt.Image = ((System.Drawing.Image)(resources.GetObject("btnPrnt.Image")));
            this.btnPrnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrnt.Location = new System.Drawing.Point(300, 9);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(80, 30);
            this.btnPrnt.TabIndex = 17;
            this.btnPrnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.img_close);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 10);
            this.panel1.TabIndex = 268;
            this.panel1.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 47);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bank Payment Letter";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // img_close
            // 
            this.img_close.Image = ((System.Drawing.Image)(resources.GetObject("img_close.Image")));
            this.img_close.Location = new System.Drawing.Point(560, 3);
            this.img_close.Name = "img_close";
            this.img_close.Size = new System.Drawing.Size(35, 33);
            this.img_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_close.TabIndex = 0;
            this.img_close.TabStop = false;
            this.img_close.Visible = false;
            this.img_close.Click += new System.EventHandler(this.img_close_Click);
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAdd.Location = new System.Drawing.Point(508, 337);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(2, 15);
            this.lblAdd.TabIndex = 269;
            this.lblAdd.Visible = false;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContact.Location = new System.Drawing.Point(508, 442);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(2, 15);
            this.lblContact.TabIndex = 269;
            this.lblContact.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(35, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(449, 12);
            this.label7.TabIndex = 270;
            this.label7.Text = "Employee Records with no Bank Ac No / IFSC Code / PayMode : Bank will not be show" +
                "n";
            // 
            // lblBr
            // 
            this.lblBr.AutoSize = true;
            this.lblBr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBr.Location = new System.Drawing.Point(505, 238);
            this.lblBr.Name = "lblBr";
            this.lblBr.Size = new System.Drawing.Size(2, 15);
            this.lblBr.TabIndex = 271;
            this.lblBr.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbBankLetter);
            this.groupBox1.Location = new System.Drawing.Point(22, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 38);
            this.groupBox1.TabIndex = 272;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rdbBankLetter
            // 
            this.rdbBankLetter.AutoSize = true;
            this.rdbBankLetter.Checked = true;
            this.rdbBankLetter.Location = new System.Drawing.Point(214, 14);
            this.rdbBankLetter.Name = "rdbBankLetter";
            this.rdbBankLetter.Size = new System.Drawing.Size(80, 17);
            this.rdbBankLetter.TabIndex = 0;
            this.rdbBankLetter.TabStop = true;
            this.rdbBankLetter.Text = "Bank Letter";
            this.rdbBankLetter.UseVisualStyleBackColor = true;
            this.rdbBankLetter.CheckedChanged += new System.EventHandler(this.rdbBankLetter_CheckedChanged);
            // 
            // rdbCMS
            // 
            this.rdbCMS.AutoSize = true;
            this.rdbCMS.Location = new System.Drawing.Point(12, 34);
            this.rdbCMS.Name = "rdbCMS";
            this.rdbCMS.Size = new System.Drawing.Size(114, 17);
            this.rdbCMS.TabIndex = 0;
            this.rdbCMS.Text = "CMS (For SBI only)";
            this.rdbCMS.UseVisualStyleBackColor = true;
            this.rdbCMS.CheckedChanged += new System.EventHandler(this.rdbCMS_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbXL3);
            this.groupBox3.Controls.Add(this.rdbCMS);
            this.groupBox3.Controls.Add(this.rdbKVB);
            this.groupBox3.Controls.Add(this.rdbHDFC);
            this.groupBox3.Controls.Add(this.rdbXL2);
            this.groupBox3.Controls.Add(this.rdbXL1);
            this.groupBox3.Controls.Add(this.rdbBob);
            this.groupBox3.Controls.Add(this.rdbBL);
            this.groupBox3.Location = new System.Drawing.Point(22, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(472, 54);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // rdbXL3
            // 
            this.rdbXL3.AutoSize = true;
            this.rdbXL3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbXL3.Location = new System.Drawing.Point(354, 32);
            this.rdbXL3.Name = "rdbXL3";
            this.rdbXL3.Size = new System.Drawing.Size(117, 16);
            this.rdbXL3.TabIndex = 0;
            this.rdbXL3.Text = "Excel - ICICI Bank";
            this.rdbXL3.UseVisualStyleBackColor = true;
            // 
            // rdbKVB
            // 
            this.rdbKVB.AutoSize = true;
            this.rdbKVB.Location = new System.Drawing.Point(353, 14);
            this.rdbKVB.Name = "rdbKVB";
            this.rdbKVB.Size = new System.Drawing.Size(109, 17);
            this.rdbKVB.TabIndex = 0;
            this.rdbKVB.Text = "Karur Vysya Bank";
            this.rdbKVB.UseVisualStyleBackColor = true;
            // 
            // rdbHDFC
            // 
            this.rdbHDFC.AutoSize = true;
            this.rdbHDFC.Location = new System.Drawing.Point(252, 14);
            this.rdbHDFC.Name = "rdbHDFC";
            this.rdbHDFC.Size = new System.Drawing.Size(54, 17);
            this.rdbHDFC.TabIndex = 0;
            this.rdbHDFC.Text = "HDFC";
            this.rdbHDFC.UseVisualStyleBackColor = true;
            // 
            // rdbXL2
            // 
            this.rdbXL2.AutoSize = true;
            this.rdbXL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbXL2.Location = new System.Drawing.Point(229, 32);
            this.rdbXL2.Name = "rdbXL2";
            this.rdbXL2.Size = new System.Drawing.Size(125, 16);
            this.rdbXL2.TabIndex = 0;
            this.rdbXL2.Text = "Excel - Indsind bank";
            this.rdbXL2.UseVisualStyleBackColor = true;
            // 
            // rdbXL1
            // 
            this.rdbXL1.AutoSize = true;
            this.rdbXL1.Checked = true;
            this.rdbXL1.Location = new System.Drawing.Point(136, 33);
            this.rdbXL1.Name = "rdbXL1";
            this.rdbXL1.Size = new System.Drawing.Size(84, 17);
            this.rdbXL1.TabIndex = 0;
            this.rdbXL1.TabStop = true;
            this.rdbXL1.Text = "Excel Type I";
            this.rdbXL1.UseVisualStyleBackColor = true;
            // 
            // rdbBob
            // 
            this.rdbBob.AutoSize = true;
            this.rdbBob.Location = new System.Drawing.Point(100, 14);
            this.rdbBob.Name = "rdbBob";
            this.rdbBob.Size = new System.Drawing.Size(108, 17);
            this.rdbBob.TabIndex = 0;
            this.rdbBob.Text = "NEFT (For B.O.B)";
            this.rdbBob.UseVisualStyleBackColor = true;
            // 
            // rdbBL
            // 
            this.rdbBL.AutoSize = true;
            this.rdbBL.Location = new System.Drawing.Point(12, 14);
            this.rdbBL.Name = "rdbBL";
            this.rdbBL.Size = new System.Drawing.Size(52, 17);
            this.rdbBL.TabIndex = 0;
            this.rdbBL.Text = "Letter";
            this.rdbBL.UseVisualStyleBackColor = true;
            // 
            // lbl_ifsc
            // 
            this.lbl_ifsc.AutoSize = true;
            this.lbl_ifsc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ifsc.Location = new System.Drawing.Point(500, 296);
            this.lbl_ifsc.Name = "lbl_ifsc";
            this.lbl_ifsc.Size = new System.Drawing.Size(2, 15);
            this.lbl_ifsc.TabIndex = 273;
            this.lbl_ifsc.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // lblBnkCode
            // 
            this.lblBnkCode.AutoSize = true;
            this.lblBnkCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBnkCode.Location = new System.Drawing.Point(503, 209);
            this.lblBnkCode.Name = "lblBnkCode";
            this.lblBnkCode.Size = new System.Drawing.Size(2, 15);
            this.lblBnkCode.TabIndex = 274;
            this.lblBnkCode.Visible = false;
            // 
            // chkNC
            // 
            this.chkNC.AutoSize = true;
            this.chkNC.Location = new System.Drawing.Point(74, 17);
            this.chkNC.Name = "chkNC";
            this.chkNC.Size = new System.Drawing.Size(104, 17);
            this.chkNC.TabIndex = 23;
            this.chkNC.Text = "Non Compliance";
            this.chkNC.UseVisualStyleBackColor = true;
            // 
            // frmBankPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(520, 502);
            this.Controls.Add(this.lblBnkCode);
            this.Controls.Add(this.lbl_ifsc);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblBr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 550);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmBankPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Payment Letter";
            this.Load += new System.EventHandler(this.frmBankPayment_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_close)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox CmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Button1;
        private EDPComponent.ComboDialog CmbLocation;
        private System.Windows.Forms.CheckBox chk_All_Emp;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox7;
        private EDPComponent.VistaButton btnExport;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnPrnt;
        private System.Windows.Forms.Label LblBankName;
        private System.Windows.Forms.TextBox TxtAccountNo;
        private System.Windows.Forms.Label LblAccountNo;
        private System.Windows.Forms.TextBox TxtDesignation;
        private System.Windows.Forms.Label LblDesignation;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox img_close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTagline;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbLoan;
        private System.Windows.Forms.RadioButton rdbAdvance;
        private System.Windows.Forms.RadioButton rdbSalary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMultiLocation;
        private System.Windows.Forms.CheckBox chk_multiSelect;
        private EDPComponent.ComboDialog TxtBankName;
        private System.Windows.Forms.Label lblBr;
        private System.Windows.Forms.CheckBox chkCompany;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbBankLetter;
        private System.Windows.Forms.RadioButton rdbCMS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbXL3;
        private System.Windows.Forms.RadioButton rdbXL2;
        private System.Windows.Forms.RadioButton rdbXL1;
        private System.Windows.Forms.RadioButton rdbBL;
        private System.Windows.Forms.Label lbl_ifsc;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton rdbBob;
        private System.Windows.Forms.Label lblBnkCode;
        private System.Windows.Forms.RadioButton rdbHDFC;
        private System.Windows.Forms.RadioButton rdbKVB;
        private System.Windows.Forms.CheckBox chkNC;
    }
}