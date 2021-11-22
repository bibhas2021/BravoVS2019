namespace PayRollManagementSystem
{
    partial class EmpBio_Icard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpBio_Icard));
            this.LblEmpId = new System.Windows.Forms.Label();
            this.LblLocation = new System.Windows.Forms.Label();
            this.LblCompany = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.CmbEmpId = new EDPComponent.ComboDialog();
            this.BtnDisp_Bio = new EDPComponent.VistaButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.chkVerification_Type = new System.Windows.Forms.CheckBox();
            this.chk_ti_sign = new System.Windows.Forms.CheckBox();
            this.btnVerifyLetter = new EDPComponent.VistaButton();
            this.btnclient = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdb_sign2 = new System.Windows.Forms.RadioButton();
            this.rdb_noSign = new System.Windows.Forms.RadioButton();
            this.rdb_sign = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbType3 = new System.Windows.Forms.RadioButton();
            this.rdbType2 = new System.Windows.Forms.RadioButton();
            this.rdbType1B = new System.Windows.Forms.RadioButton();
            this.rdbType1 = new System.Windows.Forms.RadioButton();
            this.lbl_iffound = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtp_DOV = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDOI = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.txt_eidentityMark = new System.Windows.Forms.TextBox();
            this.txt_eContact = new System.Windows.Forms.TextBox();
            this.btnicard_prev = new EDPComponent.VistaButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfound = new System.Windows.Forms.RichTextBox();
            this.txtOther = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_ic_selective = new System.Windows.Forms.RadioButton();
            this.rdb_ic_emp = new System.Windows.Forms.RadioButton();
            this.rdb_ic_loc = new System.Windows.Forms.RadioButton();
            this.rdb_ic_co = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btn_download = new EDPComponent.VistaButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // LblEmpId
            // 
            this.LblEmpId.AutoSize = true;
            this.LblEmpId.Location = new System.Drawing.Point(17, 299);
            this.LblEmpId.Name = "LblEmpId";
            this.LblEmpId.Size = new System.Drawing.Size(120, 13);
            this.LblEmpId.TabIndex = 0;
            this.LblEmpId.Text = "Individual Employee";
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(21, 56);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(56, 13);
            this.LblLocation.TabIndex = 4;
            this.LblLocation.Text = "Location";
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(21, 28);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(58, 13);
            this.LblCompany.TabIndex = 5;
            this.LblCompany.Text = "Company";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(92, 52);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(325, 21);
            this.cmbLocation.TabIndex = 1;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(92, 24);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(325, 21);
            this.CmbCompany.TabIndex = 0;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // CmbEmpId
            // 
            this.CmbEmpId.Connection = null;
            this.CmbEmpId.DialogResult = "";
            this.CmbEmpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEmpId.Location = new System.Drawing.Point(63, 318);
            this.CmbEmpId.LOVFlag = 0;
            this.CmbEmpId.MaxCharLength = 500;
            this.CmbEmpId.Name = "CmbEmpId";
            this.CmbEmpId.ReturnIndex = -1;
            this.CmbEmpId.ReturnValue = "";
            this.CmbEmpId.ReturnValue_3rd = "";
            this.CmbEmpId.ReturnValue_4th = "";
            this.CmbEmpId.Size = new System.Drawing.Size(354, 21);
            this.CmbEmpId.TabIndex = 2;
            this.CmbEmpId.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbEmpId_DropDown);
            this.CmbEmpId.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbEmpId_CloseUp);
            // 
            // BtnDisp_Bio
            // 
            this.BtnDisp_Bio.BackColor = System.Drawing.Color.Transparent;
            this.BtnDisp_Bio.BaseColor = System.Drawing.Color.Ivory;
            this.BtnDisp_Bio.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnDisp_Bio.ButtonText = "Employee Biodata";
            this.BtnDisp_Bio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDisp_Bio.ForeColor = System.Drawing.Color.Black;
            this.BtnDisp_Bio.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnDisp_Bio.Location = new System.Drawing.Point(243, 342);
            this.BtnDisp_Bio.Name = "BtnDisp_Bio";
            this.BtnDisp_Bio.Size = new System.Drawing.Size(174, 26);
            this.BtnDisp_Bio.TabIndex = 3;
            this.BtnDisp_Bio.Click += new System.EventHandler(this.BtnDisp_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblWebsite);
            this.panel2.Controls.Add(this.chkVerification_Type);
            this.panel2.Controls.Add(this.chk_ti_sign);
            this.panel2.Controls.Add(this.btnVerifyLetter);
            this.panel2.Controls.Add(this.btnclient);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.lbl_iffound);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dtp_DOV);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpDOI);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btn_download);
            this.panel2.Controls.Add(this.vistaButton1);
            this.panel2.Controls.Add(this.BtnDisp_Bio);
            this.panel2.Controls.Add(this.CmbCompany);
            this.panel2.Controls.Add(this.txt_eidentityMark);
            this.panel2.Controls.Add(this.txt_eContact);
            this.panel2.Controls.Add(this.btnicard_prev);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.LblCompany);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cmbLocation);
            this.panel2.Controls.Add(this.txtfound);
            this.panel2.Controls.Add(this.txtOther);
            this.panel2.Controls.Add(this.LblLocation);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.LblEmpId);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.CmbEmpId);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 456);
            this.panel2.TabIndex = 91;
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Location = new System.Drawing.Point(444, 430);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(0, 13);
            this.lblWebsite.TabIndex = 317;
            this.lblWebsite.Visible = false;
            // 
            // chkVerification_Type
            // 
            this.chkVerification_Type.AutoSize = true;
            this.chkVerification_Type.Location = new System.Drawing.Point(125, 380);
            this.chkVerification_Type.Name = "chkVerification_Type";
            this.chkVerification_Type.Size = new System.Drawing.Size(103, 17);
            this.chkVerification_Type.TabIndex = 316;
            this.chkVerification_Type.Text = "Blank Header";
            this.chkVerification_Type.UseVisualStyleBackColor = true;
            // 
            // chk_ti_sign
            // 
            this.chk_ti_sign.AutoSize = true;
            this.chk_ti_sign.Location = new System.Drawing.Point(275, 235);
            this.chk_ti_sign.Name = "chk_ti_sign";
            this.chk_ti_sign.Size = new System.Drawing.Size(112, 17);
            this.chk_ti_sign.TabIndex = 316;
            this.chk_ti_sign.Text = "Thumb Imprints";
            this.chk_ti_sign.UseVisualStyleBackColor = true;
            // 
            // btnVerifyLetter
            // 
            this.btnVerifyLetter.BackColor = System.Drawing.Color.Transparent;
            this.btnVerifyLetter.BaseColor = System.Drawing.Color.Ivory;
            this.btnVerifyLetter.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnVerifyLetter.ButtonText = "Verification Letter";
            this.btnVerifyLetter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerifyLetter.ForeColor = System.Drawing.Color.Black;
            this.btnVerifyLetter.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnVerifyLetter.Location = new System.Drawing.Point(243, 374);
            this.btnVerifyLetter.Name = "btnVerifyLetter";
            this.btnVerifyLetter.Size = new System.Drawing.Size(174, 26);
            this.btnVerifyLetter.TabIndex = 315;
            this.btnVerifyLetter.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // btnclient
            // 
            this.btnclient.Location = new System.Drawing.Point(137, 316);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(148, 23);
            this.btnclient.TabIndex = 314;
            this.btnclient.Text = "Select Employee";
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdb_sign2);
            this.groupBox3.Controls.Add(this.rdb_noSign);
            this.groupBox3.Controls.Add(this.rdb_sign);
            this.groupBox3.Location = new System.Drawing.Point(444, 374);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(329, 46);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Authorise Signature";
            // 
            // rdb_sign2
            // 
            this.rdb_sign2.AutoSize = true;
            this.rdb_sign2.Location = new System.Drawing.Point(218, 19);
            this.rdb_sign2.Name = "rdb_sign2";
            this.rdb_sign2.Size = new System.Drawing.Size(89, 17);
            this.rdb_sign2.TabIndex = 0;
            this.rdb_sign2.Text = "2nd Person";
            this.rdb_sign2.UseVisualStyleBackColor = true;
            // 
            // rdb_noSign
            // 
            this.rdb_noSign.AutoSize = true;
            this.rdb_noSign.Checked = true;
            this.rdb_noSign.Location = new System.Drawing.Point(22, 19);
            this.rdb_noSign.Name = "rdb_noSign";
            this.rdb_noSign.Size = new System.Drawing.Size(99, 17);
            this.rdb_noSign.TabIndex = 0;
            this.rdb_noSign.TabStop = true;
            this.rdb_noSign.Text = "No Signature";
            this.rdb_noSign.UseVisualStyleBackColor = true;
            // 
            // rdb_sign
            // 
            this.rdb_sign.AutoSize = true;
            this.rdb_sign.Location = new System.Drawing.Point(129, 19);
            this.rdb_sign.Name = "rdb_sign";
            this.rdb_sign.Size = new System.Drawing.Size(85, 17);
            this.rdb_sign.TabIndex = 0;
            this.rdb_sign.Text = "1st Person";
            this.rdb_sign.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbType3);
            this.groupBox2.Controls.Add(this.rdbType2);
            this.groupBox2.Controls.Add(this.rdbType1B);
            this.groupBox2.Controls.Add(this.rdbType1);
            this.groupBox2.Location = new System.Drawing.Point(11, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 74);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Icard Type";
            // 
            // rdbType3
            // 
            this.rdbType3.AutoSize = true;
            this.rdbType3.Location = new System.Drawing.Point(234, 42);
            this.rdbType3.Name = "rdbType3";
            this.rdbType3.Size = new System.Drawing.Size(115, 17);
            this.rdbType3.TabIndex = 1;
            this.rdbType3.Text = "Type 3 - Form X";
            this.rdbType3.UseVisualStyleBackColor = true;
            // 
            // rdbType2
            // 
            this.rdbType2.AutoSize = true;
            this.rdbType2.Checked = true;
            this.rdbType2.Location = new System.Drawing.Point(19, 42);
            this.rdbType2.Name = "rdbType2";
            this.rdbType2.Size = new System.Drawing.Size(133, 17);
            this.rdbType2.TabIndex = 0;
            this.rdbType2.TabStop = true;
            this.rdbType2.Text = "Type 2 - Horizontal";
            this.rdbType2.UseVisualStyleBackColor = true;
            this.rdbType2.CheckedChanged += new System.EventHandler(this.rdbType2_CheckedChanged);
            // 
            // rdbType1B
            // 
            this.rdbType1B.AutoSize = true;
            this.rdbType1B.Location = new System.Drawing.Point(233, 19);
            this.rdbType1B.Name = "rdbType1B";
            this.rdbType1B.Size = new System.Drawing.Size(135, 17);
            this.rdbType1B.TabIndex = 0;
            this.rdbType1B.Text = "Type 1- Vertical - B";
            this.rdbType1B.UseVisualStyleBackColor = true;
            this.rdbType1B.CheckedChanged += new System.EventHandler(this.rdbType1_CheckedChanged);
            // 
            // rdbType1
            // 
            this.rdbType1.AutoSize = true;
            this.rdbType1.Location = new System.Drawing.Point(19, 19);
            this.rdbType1.Name = "rdbType1";
            this.rdbType1.Size = new System.Drawing.Size(135, 17);
            this.rdbType1.TabIndex = 0;
            this.rdbType1.Text = "Type 1- Vertical - A";
            this.rdbType1.UseVisualStyleBackColor = true;
            this.rdbType1.CheckedChanged += new System.EventHandler(this.rdbType1_CheckedChanged);
            // 
            // lbl_iffound
            // 
            this.lbl_iffound.AutoSize = true;
            this.lbl_iffound.Location = new System.Drawing.Point(444, 267);
            this.lbl_iffound.Name = "lbl_iffound";
            this.lbl_iffound.Size = new System.Drawing.Size(115, 13);
            this.lbl_iffound.TabIndex = 22;
            this.lbl_iffound.Text = "If Found Return to:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(428, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 379);
            this.panel3.TabIndex = 21;
            // 
            // dtp_DOV
            // 
            this.dtp_DOV.CustomFormat = "dd /MMMM /yyyy";
            this.dtp_DOV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DOV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DOV.Location = new System.Drawing.Point(827, 99);
            this.dtp_DOV.Name = "dtp_DOV";
            this.dtp_DOV.Size = new System.Drawing.Size(108, 20);
            this.dtp_DOV.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(685, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Valid Upto";
            // 
            // dtpDOI
            // 
            this.dtpDOI.CustomFormat = "dd /MMMM /yyyy";
            this.dtpDOI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOI.Location = new System.Drawing.Point(562, 96);
            this.dtpDOI.Name = "dtpDOI";
            this.dtpDOI.Size = new System.Drawing.Size(108, 20);
            this.dtpDOI.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(444, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Date Of Issue";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.Ivory;
            this.vistaButton1.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.vistaButton1.ButtonText = "Personal Information";
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.ForeColor = System.Drawing.Color.Black;
            this.vistaButton1.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.vistaButton1.Location = new System.Drawing.Point(63, 345);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(174, 26);
            this.vistaButton1.TabIndex = 3;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // txt_eidentityMark
            // 
            this.txt_eidentityMark.Location = new System.Drawing.Point(685, 58);
            this.txt_eidentityMark.Name = "txt_eidentityMark";
            this.txt_eidentityMark.Size = new System.Drawing.Size(250, 20);
            this.txt_eidentityMark.TabIndex = 10;
            // 
            // txt_eContact
            // 
            this.txt_eContact.Location = new System.Drawing.Point(444, 58);
            this.txt_eContact.Name = "txt_eContact";
            this.txt_eContact.Size = new System.Drawing.Size(226, 20);
            this.txt_eContact.TabIndex = 10;
            // 
            // btnicard_prev
            // 
            this.btnicard_prev.BackColor = System.Drawing.Color.Transparent;
            this.btnicard_prev.BaseColor = System.Drawing.Color.Ivory;
            this.btnicard_prev.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnicard_prev.ButtonText = "I-card";
            this.btnicard_prev.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnicard_prev.ForeColor = System.Drawing.Color.Black;
            this.btnicard_prev.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnicard_prev.Location = new System.Drawing.Point(812, 383);
            this.btnicard_prev.Name = "btnicard_prev";
            this.btnicard_prev.Size = new System.Drawing.Size(120, 26);
            this.btnicard_prev.TabIndex = 3;
            this.btnicard_prev.Click += new System.EventHandler(this.btnicard_prev_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Identity Mark";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Emergency Contact Number";
            // 
            // txtfound
            // 
            this.txtfound.Location = new System.Drawing.Point(444, 287);
            this.txtfound.Name = "txtfound";
            this.txtfound.Size = new System.Drawing.Size(488, 81);
            this.txtfound.TabIndex = 12;
            this.txtfound.Text = "";
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(447, 145);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(488, 110);
            this.txtOther.TabIndex = 12;
            this.txtOther.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Others";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_ic_selective);
            this.groupBox1.Controls.Add(this.rdb_ic_emp);
            this.groupBox1.Controls.Add(this.rdb_ic_loc);
            this.groupBox1.Controls.Add(this.rdb_ic_co);
            this.groupBox1.Location = new System.Drawing.Point(25, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 104);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print icard";
            // 
            // rdb_ic_selective
            // 
            this.rdb_ic_selective.AutoSize = true;
            this.rdb_ic_selective.Location = new System.Drawing.Point(20, 82);
            this.rdb_ic_selective.Name = "rdb_ic_selective";
            this.rdb_ic_selective.Size = new System.Drawing.Size(136, 17);
            this.rdb_ic_selective.TabIndex = 4;
            this.rdb_ic_selective.Text = "Selective Employee";
            this.rdb_ic_selective.UseVisualStyleBackColor = true;
            this.rdb_ic_selective.CheckedChanged += new System.EventHandler(this.rdb_ic_emp_CheckedChanged);
            // 
            // rdb_ic_emp
            // 
            this.rdb_ic_emp.AutoSize = true;
            this.rdb_ic_emp.Checked = true;
            this.rdb_ic_emp.Location = new System.Drawing.Point(20, 59);
            this.rdb_ic_emp.Name = "rdb_ic_emp";
            this.rdb_ic_emp.Size = new System.Drawing.Size(138, 17);
            this.rdb_ic_emp.TabIndex = 4;
            this.rdb_ic_emp.TabStop = true;
            this.rdb_ic_emp.Text = "Individual Employee";
            this.rdb_ic_emp.UseVisualStyleBackColor = true;
            this.rdb_ic_emp.CheckedChanged += new System.EventHandler(this.rdb_ic_emp_CheckedChanged);
            // 
            // rdb_ic_loc
            // 
            this.rdb_ic_loc.AutoSize = true;
            this.rdb_ic_loc.Location = new System.Drawing.Point(20, 38);
            this.rdb_ic_loc.Name = "rdb_ic_loc";
            this.rdb_ic_loc.Size = new System.Drawing.Size(103, 17);
            this.rdb_ic_loc.TabIndex = 4;
            this.rdb_ic_loc.Text = "Location wise";
            this.rdb_ic_loc.UseVisualStyleBackColor = true;
            this.rdb_ic_loc.CheckedChanged += new System.EventHandler(this.rdb_ic_emp_CheckedChanged);
            // 
            // rdb_ic_co
            // 
            this.rdb_ic_co.AutoSize = true;
            this.rdb_ic_co.Location = new System.Drawing.Point(19, 18);
            this.rdb_ic_co.Name = "rdb_ic_co";
            this.rdb_ic_co.Size = new System.Drawing.Size(108, 17);
            this.rdb_ic_co.TabIndex = 4;
            this.rdb_ic_co.Text = "Company Wise";
            this.rdb_ic_co.UseVisualStyleBackColor = true;
            this.rdb_ic_co.Visible = false;
            this.rdb_ic_co.CheckedChanged += new System.EventHandler(this.rdb_ic_emp_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 10);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Employee Records";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(916, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 10);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_download
            // 
            this.btn_download.BackColor = System.Drawing.Color.Transparent;
            this.btn_download.BaseColor = System.Drawing.Color.Ivory;
            this.btn_download.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btn_download.ButtonText = "Download Employee Image Company wise";
            this.btn_download.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_download.ForeColor = System.Drawing.Color.Black;
            this.btn_download.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_download.Location = new System.Drawing.Point(63, 403);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(354, 30);
            this.btn_download.TabIndex = 3;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // EmpBio_Icard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(956, 456);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmpBio_Icard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Icard & Biodata";
            this.Load += new System.EventHandler(this.frmEmpJoining_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblEmpId;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Label LblCompany;
        private EDPComponent.ComboDialog cmbLocation;
        private EDPComponent.ComboDialog CmbCompany;
        private EDPComponent.ComboDialog CmbEmpId;
        private EDPComponent.VistaButton BtnDisp_Bio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_ic_emp;
        private System.Windows.Forms.RadioButton rdb_ic_loc;
        private System.Windows.Forms.RadioButton rdb_ic_co;
        private EDPComponent.VistaButton btnicard_prev;
        private System.Windows.Forms.RichTextBox txtOther;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_eContact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_DOV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDOI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_eidentityMark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_iffound;
        private System.Windows.Forms.RichTextBox txtfound;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbType2;
        private System.Windows.Forms.RadioButton rdbType1;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdb_sign2;
        private System.Windows.Forms.RadioButton rdb_sign;
        private System.Windows.Forms.RadioButton rdbType3;
        private System.Windows.Forms.RadioButton rdb_ic_selective;
        private System.Windows.Forms.Button btnclient;
        private EDPComponent.VistaButton btnVerifyLetter;
        private System.Windows.Forms.CheckBox chk_ti_sign;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.RadioButton rdbType1B;
        private System.Windows.Forms.CheckBox chkVerification_Type;
        private System.Windows.Forms.RadioButton rdb_noSign;
        private EDPComponent.VistaButton btn_download;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}