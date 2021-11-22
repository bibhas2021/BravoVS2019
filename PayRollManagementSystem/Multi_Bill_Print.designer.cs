namespace PayRollManagementSystem
{
    partial class Multi_Bill_Print
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Multi_Bill_Print));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblprevbal = new System.Windows.Forms.Label();
            this.chkPrevBal = new System.Windows.Forms.CheckBox();
            this.rdbOrg = new System.Windows.Forms.RadioButton();
            this.rdbTriple = new System.Windows.Forms.RadioButton();
            this.rdbDuplicate = new System.Windows.Forms.RadioButton();
            this.bnkDtl = new EDPComponent.ComboDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkBank = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.chkBlankHead = new System.Windows.Forms.CheckBox();
            this.chkHide_BillDetails = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose2 = new EDPComponent.VistaButton();
            this.grp_sign = new System.Windows.Forms.GroupBox();
            this.rdb_sign2 = new System.Windows.Forms.RadioButton();
            this.rdb_sign = new System.Windows.Forms.RadioButton();
            this.lblEnclosure = new System.Windows.Forms.Label();
            this.lblprepby = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.cbSaveNewOtherDetails = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txt_Odetails = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Txt_TermsConditions = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrint = new EDPComponent.VistaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.rdb_type_inv = new System.Windows.Forms.RadioButton();
            this.rdb_type_bill = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_type_bos = new System.Windows.Forms.RadioButton();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grp_sign.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbYear);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Location = new System.Drawing.Point(38, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 55);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Choose Month";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(63, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(126, 21);
            this.cmbYear.TabIndex = 259;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(6, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 258;
            this.label22.Text = "Session";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM - yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(330, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(133, 20);
            this.dateTimePicker1.TabIndex = 264;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(287, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 260;
            this.label21.Text = "Month";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblprevbal);
            this.groupBox2.Controls.Add(this.chkPrevBal);
            this.groupBox2.Controls.Add(this.rdbOrg);
            this.groupBox2.Controls.Add(this.rdbTriple);
            this.groupBox2.Controls.Add(this.rdbDuplicate);
            this.groupBox2.Controls.Add(this.bnkDtl);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.chkBank);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbcompany);
            this.groupBox2.Controls.Add(this.chkBlankHead);
            this.groupBox2.Controls.Add(this.chkHide_BillDetails);
            this.groupBox2.Location = new System.Drawing.Point(38, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 135);
            this.groupBox2.TabIndex = 266;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // lblprevbal
            // 
            this.lblprevbal.AutoSize = true;
            this.lblprevbal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblprevbal.Location = new System.Drawing.Point(295, 63);
            this.lblprevbal.Name = "lblprevbal";
            this.lblprevbal.Size = new System.Drawing.Size(15, 15);
            this.lblprevbal.TabIndex = 322;
            this.lblprevbal.Text = "0";
            this.lblprevbal.Visible = false;
            // 
            // chkPrevBal
            // 
            this.chkPrevBal.AutoSize = true;
            this.chkPrevBal.Location = new System.Drawing.Point(339, 63);
            this.chkPrevBal.Name = "chkPrevBal";
            this.chkPrevBal.Size = new System.Drawing.Size(128, 17);
            this.chkPrevBal.TabIndex = 318;
            this.chkPrevBal.Text = "Include Prev Balance";
            this.chkPrevBal.UseVisualStyleBackColor = true;
            // 
            // rdbOrg
            // 
            this.rdbOrg.AutoSize = true;
            this.rdbOrg.Checked = true;
            this.rdbOrg.Location = new System.Drawing.Point(259, 39);
            this.rdbOrg.Name = "rdbOrg";
            this.rdbOrg.Size = new System.Drawing.Size(60, 17);
            this.rdbOrg.TabIndex = 317;
            this.rdbOrg.TabStop = true;
            this.rdbOrg.Text = "Original";
            this.rdbOrg.UseVisualStyleBackColor = true;
            // 
            // rdbTriple
            // 
            this.rdbTriple.AutoSize = true;
            this.rdbTriple.Location = new System.Drawing.Point(401, 40);
            this.rdbTriple.Name = "rdbTriple";
            this.rdbTriple.Size = new System.Drawing.Size(68, 17);
            this.rdbTriple.TabIndex = 317;
            this.rdbTriple.Text = "Triplicate";
            this.rdbTriple.UseVisualStyleBackColor = true;
            // 
            // rdbDuplicate
            // 
            this.rdbDuplicate.AutoSize = true;
            this.rdbDuplicate.Location = new System.Drawing.Point(326, 39);
            this.rdbDuplicate.Name = "rdbDuplicate";
            this.rdbDuplicate.Size = new System.Drawing.Size(70, 17);
            this.rdbDuplicate.TabIndex = 317;
            this.rdbDuplicate.Text = "Duplicate";
            this.rdbDuplicate.UseVisualStyleBackColor = true;
            // 
            // bnkDtl
            // 
            this.bnkDtl.Connection = null;
            this.bnkDtl.DialogResult = "";
            this.bnkDtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnkDtl.Location = new System.Drawing.Point(136, 81);
            this.bnkDtl.LOVFlag = 0;
            this.bnkDtl.MaxCharLength = 500;
            this.bnkDtl.Name = "bnkDtl";
            this.bnkDtl.ReturnIndex = -1;
            this.bnkDtl.ReturnValue = "";
            this.bnkDtl.ReturnValue_3rd = "";
            this.bnkDtl.ReturnValue_4th = "";
            this.bnkDtl.Size = new System.Drawing.Size(326, 21);
            this.bnkDtl.TabIndex = 311;
            this.bnkDtl.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.bnkDtl_DropDown);
            this.bnkDtl.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.bnkDtl_CloseUp);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.checkBox1.Location = new System.Drawing.Point(14, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 18);
            this.checkBox1.TabIndex = 309;
            this.checkBox1.Text = "Select All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // chkBank
            // 
            this.chkBank.AutoSize = true;
            this.chkBank.Location = new System.Drawing.Point(14, 85);
            this.chkBank.Name = "chkBank";
            this.chkBank.Size = new System.Drawing.Size(124, 17);
            this.chkBank.TabIndex = 310;
            this.chkBank.Text = "Include Bank Details";
            this.chkBank.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(94, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 27);
            this.button1.TabIndex = 308;
            this.button1.Text = "Select Bill No.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 293;
            this.label6.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(94, 14);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(370, 21);
            this.cmbcompany.TabIndex = 292;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // chkBlankHead
            // 
            this.chkBlankHead.AutoSize = true;
            this.chkBlankHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBlankHead.Location = new System.Drawing.Point(329, 111);
            this.chkBlankHead.Name = "chkBlankHead";
            this.chkBlankHead.Size = new System.Drawing.Size(129, 17);
            this.chkBlankHead.TabIndex = 321;
            this.chkBlankHead.Text = "Blank Letter Head";
            this.chkBlankHead.UseVisualStyleBackColor = true;
            // 
            // chkHide_BillDetails
            // 
            this.chkHide_BillDetails.AutoSize = true;
            this.chkHide_BillDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHide_BillDetails.Location = new System.Drawing.Point(207, 111);
            this.chkHide_BillDetails.Name = "chkHide_BillDetails";
            this.chkHide_BillDetails.Size = new System.Drawing.Size(116, 17);
            this.chkHide_BillDetails.TabIndex = 320;
            this.chkHide_BillDetails.Text = "Hide Bill Details";
            this.chkHide_BillDetails.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 319;
            this.label9.Text = "Narration";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(356, 596);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 323;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose2
            // 
            this.btnClose2.BackColor = System.Drawing.Color.Transparent;
            this.btnClose2.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose2.ButtonText = "Close";
            this.btnClose2.CornerRadius = 4;
            this.btnClose2.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose2.Location = new System.Drawing.Point(442, 596);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(80, 30);
            this.btnClose2.TabIndex = 322;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // grp_sign
            // 
            this.grp_sign.Controls.Add(this.rdb_sign2);
            this.grp_sign.Controls.Add(this.rdb_sign);
            this.grp_sign.Enabled = false;
            this.grp_sign.Location = new System.Drawing.Point(315, 445);
            this.grp_sign.Name = "grp_sign";
            this.grp_sign.Size = new System.Drawing.Size(205, 38);
            this.grp_sign.TabIndex = 324;
            this.grp_sign.TabStop = false;
            this.grp_sign.Text = "Authorise Signature";
            // 
            // rdb_sign2
            // 
            this.rdb_sign2.AutoSize = true;
            this.rdb_sign2.Location = new System.Drawing.Point(121, 15);
            this.rdb_sign2.Name = "rdb_sign2";
            this.rdb_sign2.Size = new System.Drawing.Size(79, 17);
            this.rdb_sign2.TabIndex = 0;
            this.rdb_sign2.Text = "2nd Person";
            this.rdb_sign2.UseVisualStyleBackColor = true;
            // 
            // rdb_sign
            // 
            this.rdb_sign.AutoSize = true;
            this.rdb_sign.Checked = true;
            this.rdb_sign.Location = new System.Drawing.Point(18, 15);
            this.rdb_sign.Name = "rdb_sign";
            this.rdb_sign.Size = new System.Drawing.Size(75, 17);
            this.rdb_sign.TabIndex = 0;
            this.rdb_sign.TabStop = true;
            this.rdb_sign.Text = "1st Person";
            this.rdb_sign.UseVisualStyleBackColor = true;
            // 
            // lblEnclosure
            // 
            this.lblEnclosure.AutoSize = true;
            this.lblEnclosure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEnclosure.Location = new System.Drawing.Point(530, 105);
            this.lblEnclosure.Name = "lblEnclosure";
            this.lblEnclosure.Size = new System.Drawing.Size(2, 15);
            this.lblEnclosure.TabIndex = 325;
            this.lblEnclosure.Visible = false;
            // 
            // lblprepby
            // 
            this.lblprepby.AutoSize = true;
            this.lblprepby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblprepby.Location = new System.Drawing.Point(530, 126);
            this.lblprepby.Name = "lblprepby";
            this.lblprepby.Size = new System.Drawing.Size(2, 15);
            this.lblprepby.TabIndex = 326;
            this.lblprepby.Visible = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNote.Location = new System.Drawing.Point(530, 146);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(2, 15);
            this.lblNote.TabIndex = 327;
            this.lblNote.Visible = false;
            // 
            // cbSaveNewOtherDetails
            // 
            this.cbSaveNewOtherDetails.AutoSize = true;
            this.cbSaveNewOtherDetails.Location = new System.Drawing.Point(246, 323);
            this.cbSaveNewOtherDetails.Name = "cbSaveNewOtherDetails";
            this.cbSaveNewOtherDetails.Size = new System.Drawing.Size(276, 17);
            this.cbSaveNewOtherDetails.TabIndex = 333;
            this.cbSaveNewOtherDetails.Text = "Save this Note, Other Details and T&&C as default text";
            this.cbSaveNewOtherDetails.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 332;
            this.label10.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.Location = new System.Drawing.Point(45, 340);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(478, 44);
            this.txtNote.TabIndex = 331;
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesc.Location = new System.Drawing.Point(45, 251);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(478, 72);
            this.txtDesc.TabIndex = 330;
            this.txtDesc.Text = "Being the amount charged for the supply of service";
            // 
            // txt_Odetails
            // 
            this.txt_Odetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Odetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Odetails.Location = new System.Drawing.Point(44, 402);
            this.txt_Odetails.Name = "txt_Odetails";
            this.txt_Odetails.Size = new System.Drawing.Size(479, 41);
            this.txt_Odetails.TabIndex = 329;
            this.txt_Odetails.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 328;
            this.label7.Text = "Other Details";
            // 
            // Txt_TermsConditions
            // 
            this.Txt_TermsConditions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Txt_TermsConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_TermsConditions.Location = new System.Drawing.Point(41, 487);
            this.Txt_TermsConditions.Name = "Txt_TermsConditions";
            this.Txt_TermsConditions.Size = new System.Drawing.Size(482, 83);
            this.Txt_TermsConditions.TabIndex = 334;
            this.Txt_TermsConditions.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 467);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 335;
            this.label8.Text = "Terms and Conditions";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrint.ButtonText = "Print";
            this.btnPrint.CornerRadius = 4;
            this.btnPrint.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrint.Location = new System.Drawing.Point(268, 596);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 30);
            this.btnPrint.TabIndex = 323;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(134, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 13);
            this.label1.TabIndex = 336;
            this.label1.Text = "Select Month for fetching bills of that month all client of selected company";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(129, 224);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(373, 21);
            this.cmbLocation.TabIndex = 323;
            this.cmbLocation.Visible = false;
            // 
            // rdb_type_inv
            // 
            this.rdb_type_inv.AutoSize = true;
            this.rdb_type_inv.Checked = true;
            this.rdb_type_inv.Location = new System.Drawing.Point(5, 18);
            this.rdb_type_inv.Name = "rdb_type_inv";
            this.rdb_type_inv.Size = new System.Drawing.Size(81, 17);
            this.rdb_type_inv.TabIndex = 338;
            this.rdb_type_inv.TabStop = true;
            this.rdb_type_inv.Text = "Tax Invoice";
            this.rdb_type_inv.UseVisualStyleBackColor = true;
            // 
            // rdb_type_bill
            // 
            this.rdb_type_bill.AutoSize = true;
            this.rdb_type_bill.Location = new System.Drawing.Point(88, 19);
            this.rdb_type_bill.Name = "rdb_type_bill";
            this.rdb_type_bill.Size = new System.Drawing.Size(38, 17);
            this.rdb_type_bill.TabIndex = 337;
            this.rdb_type_bill.Text = "Bill";
            this.rdb_type_bill.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_type_inv);
            this.groupBox1.Controls.Add(this.rdb_type_bos);
            this.groupBox1.Controls.Add(this.rdb_type_bill);
            this.groupBox1.Location = new System.Drawing.Point(38, 583);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 46);
            this.groupBox1.TabIndex = 339;
            this.groupBox1.TabStop = false;
            // 
            // rdb_type_bos
            // 
            this.rdb_type_bos.AutoSize = true;
            this.rdb_type_bos.Location = new System.Drawing.Point(130, 19);
            this.rdb_type_bos.Name = "rdb_type_bos";
            this.rdb_type_bos.Size = new System.Drawing.Size(85, 17);
            this.rdb_type_bos.TabIndex = 337;
            this.rdb_type_bos.Text = "Bill of Supply";
            this.rdb_type_bos.UseVisualStyleBackColor = true;
            // 
            // Multi_Bill_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(558, 644);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Txt_TermsConditions);
            this.Controls.Add(this.cbSaveNewOtherDetails);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txt_Odetails);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblprepby);
            this.Controls.Add(this.lblEnclosure);
            this.Controls.Add(this.grp_sign);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnClose2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Multi_Bill_Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi Bill Print";
            this.Load += new System.EventHandler(this.Multi_Bill_Print_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grp_sign.ResumeLayout(false);
            this.grp_sign.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label lblprevbal;
        private System.Windows.Forms.CheckBox chkPrevBal;
        private System.Windows.Forms.RadioButton rdbOrg;
        private System.Windows.Forms.RadioButton rdbTriple;
        private System.Windows.Forms.RadioButton rdbDuplicate;
        public EDPComponent.ComboDialog bnkDtl;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.CheckBox chkBank;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        public EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.CheckBox chkHide_BillDetails;
        private System.Windows.Forms.CheckBox chkBlankHead;
        private System.Windows.Forms.Label label9;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose2;
        private System.Windows.Forms.GroupBox grp_sign;
        private System.Windows.Forms.RadioButton rdb_sign2;
        private System.Windows.Forms.RadioButton rdb_sign;
        public System.Windows.Forms.Label lblEnclosure;
        public System.Windows.Forms.Label lblprepby;
        public System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.CheckBox cbSaveNewOtherDetails;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.RichTextBox txt_Odetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox Txt_TermsConditions;
        private System.Windows.Forms.Label label8;
        private EDPComponent.VistaButton btnPrint;
        private System.Windows.Forms.Label label1;
        public EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.RadioButton rdb_type_inv;
        private System.Windows.Forms.RadioButton rdb_type_bill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_type_bos;
    }
}