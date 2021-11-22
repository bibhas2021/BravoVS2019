namespace PayRollManagementSystem
{
    partial class frmEmployee_PayAdvice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee_PayAdvice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdbLocation_multi = new System.Windows.Forms.RadioButton();
            this.rdbLocation_single = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbRegular = new System.Windows.Forms.RadioButton();
            this.rdbCms_Cash = new System.Windows.Forms.RadioButton();
            this.rdbCms_Neft = new System.Windows.Forms.RadioButton();
            this.rdbCMS_sbi = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnloc = new EDPComponent.VistaButton();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.chkAllEmp = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.lbl_cl = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkCompany = new System.Windows.Forms.CheckBox();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbReport = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.txtEmpContribut = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpForm = new System.Windows.Forms.DateTimePicker();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.raddetails = new System.Windows.Forms.RadioButton();
            this.radconsoli = new System.Windows.Forms.RadioButton();
            this.lblMsg = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CmbReport);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.txtEmpContribut);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 351);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdbLocation_multi);
            this.groupBox6.Controls.Add(this.rdbLocation_single);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 109);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(484, 38);
            this.groupBox6.TabIndex = 309;
            this.groupBox6.TabStop = false;
            // 
            // rdbLocation_multi
            // 
            this.rdbLocation_multi.AutoSize = true;
            this.rdbLocation_multi.Checked = true;
            this.rdbLocation_multi.Location = new System.Drawing.Point(44, 15);
            this.rdbLocation_multi.Name = "rdbLocation_multi";
            this.rdbLocation_multi.Size = new System.Drawing.Size(91, 17);
            this.rdbLocation_multi.TabIndex = 0;
            this.rdbLocation_multi.TabStop = true;
            this.rdbLocation_multi.Text = "Multi Location";
            this.rdbLocation_multi.UseVisualStyleBackColor = true;
            this.rdbLocation_multi.CheckedChanged += new System.EventHandler(this.rdbLocation_multi_CheckedChanged);
            // 
            // rdbLocation_single
            // 
            this.rdbLocation_single.AutoSize = true;
            this.rdbLocation_single.Location = new System.Drawing.Point(211, 15);
            this.rdbLocation_single.Name = "rdbLocation_single";
            this.rdbLocation_single.Size = new System.Drawing.Size(98, 17);
            this.rdbLocation_single.TabIndex = 0;
            this.rdbLocation_single.Text = "Single Location";
            this.rdbLocation_single.UseVisualStyleBackColor = true;
            this.rdbLocation_single.CheckedChanged += new System.EventHandler(this.rdbLocation_single_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbRegular);
            this.groupBox5.Controls.Add(this.rdbCms_Cash);
            this.groupBox5.Controls.Add(this.rdbCms_Neft);
            this.groupBox5.Controls.Add(this.rdbCMS_sbi);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 71);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(484, 38);
            this.groupBox5.TabIndex = 308;
            this.groupBox5.TabStop = false;
            // 
            // rdbRegular
            // 
            this.rdbRegular.AutoSize = true;
            this.rdbRegular.Checked = true;
            this.rdbRegular.Location = new System.Drawing.Point(44, 15);
            this.rdbRegular.Name = "rdbRegular";
            this.rdbRegular.Size = new System.Drawing.Size(62, 17);
            this.rdbRegular.TabIndex = 0;
            this.rdbRegular.TabStop = true;
            this.rdbRegular.Text = "Regular";
            this.rdbRegular.UseVisualStyleBackColor = true;
            this.rdbRegular.CheckedChanged += new System.EventHandler(this.rdbRegular_CheckedChanged);
            // 
            // rdbCms_Cash
            // 
            this.rdbCms_Cash.AutoSize = true;
            this.rdbCms_Cash.Location = new System.Drawing.Point(293, 15);
            this.rdbCms_Cash.Name = "rdbCms_Cash";
            this.rdbCms_Cash.Size = new System.Drawing.Size(49, 17);
            this.rdbCms_Cash.TabIndex = 0;
            this.rdbCms_Cash.Text = "Cash";
            this.rdbCms_Cash.UseVisualStyleBackColor = true;
            this.rdbCms_Cash.CheckedChanged += new System.EventHandler(this.rdbRegular_CheckedChanged);
            // 
            // rdbCms_Neft
            // 
            this.rdbCms_Neft.AutoSize = true;
            this.rdbCms_Neft.Location = new System.Drawing.Point(211, 15);
            this.rdbCms_Neft.Name = "rdbCms_Neft";
            this.rdbCms_Neft.Size = new System.Drawing.Size(53, 17);
            this.rdbCms_Neft.TabIndex = 0;
            this.rdbCms_Neft.Text = "NEFT";
            this.rdbCms_Neft.UseVisualStyleBackColor = true;
            this.rdbCms_Neft.CheckedChanged += new System.EventHandler(this.rdbRegular_CheckedChanged);
            // 
            // rdbCMS_sbi
            // 
            this.rdbCMS_sbi.AutoSize = true;
            this.rdbCMS_sbi.Location = new System.Drawing.Point(135, 15);
            this.rdbCMS_sbi.Name = "rdbCMS_sbi";
            this.rdbCMS_sbi.Size = new System.Drawing.Size(42, 17);
            this.rdbCMS_sbi.TabIndex = 0;
            this.rdbCMS_sbi.Text = "SBI";
            this.rdbCMS_sbi.UseVisualStyleBackColor = true;
            this.rdbCMS_sbi.CheckedChanged += new System.EventHandler(this.rdbRegular_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnloc);
            this.groupBox2.Controls.Add(this.cmbLocation);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.chkAllEmp);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbcompany);
            this.groupBox2.Controls.Add(this.lbl_cl);
            this.groupBox2.Location = new System.Drawing.Point(7, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 117);
            this.groupBox2.TabIndex = 265;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Details";
            // 
            // btnloc
            // 
            this.btnloc.BackColor = System.Drawing.Color.Transparent;
            this.btnloc.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnloc.ButtonText = "Select Location";
            this.btnloc.CornerRadius = 4;
            this.btnloc.ImageSize = new System.Drawing.Size(16, 16);
            this.btnloc.Location = new System.Drawing.Point(91, 41);
            this.btnloc.Name = "btnloc";
            this.btnloc.Size = new System.Drawing.Size(138, 28);
            this.btnloc.TabIndex = 308;
            this.btnloc.Click += new System.EventHandler(this.btnloc_Click);
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(91, 44);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(375, 21);
            this.cmbLocation.TabIndex = 307;
            this.cmbLocation.Visible = false;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(155, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 27);
            this.button1.TabIndex = 306;
            this.button1.Text = "Select Employee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkAllEmp
            // 
            this.chkAllEmp.AutoSize = true;
            this.chkAllEmp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.chkAllEmp.Location = new System.Drawing.Point(9, 84);
            this.chkAllEmp.Name = "chkAllEmp";
            this.chkAllEmp.Size = new System.Drawing.Size(144, 18);
            this.chkAllEmp.TabIndex = 303;
            this.chkAllEmp.Text = "Select All Employee";
            this.chkAllEmp.UseVisualStyleBackColor = true;
            this.chkAllEmp.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(91, 14);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(375, 21);
            this.cmbcompany.TabIndex = 292;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // lbl_cl
            // 
            this.lbl_cl.AutoSize = true;
            this.lbl_cl.Location = new System.Drawing.Point(3, 48);
            this.lbl_cl.Name = "lbl_cl";
            this.lbl_cl.Size = new System.Drawing.Size(48, 13);
            this.lbl_cl.TabIndex = 265;
            this.lbl_cl.Text = "Location";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkCompany);
            this.groupBox7.Controls.Add(this.vistaButton1);
            this.groupBox7.Controls.Add(this.btnPreview);
            this.groupBox7.Controls.Add(this.btnClose);
            this.groupBox7.Controls.Add(this.btnPrnt);
            this.groupBox7.Location = new System.Drawing.Point(7, 270);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 50);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Print Details";
            // 
            // chkCompany
            // 
            this.chkCompany.AutoSize = true;
            this.chkCompany.Location = new System.Drawing.Point(9, 24);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Size = new System.Drawing.Size(97, 17);
            this.chkCompany.TabIndex = 308;
            this.chkCompany.Text = "Company Wise";
            this.chkCompany.UseVisualStyleBackColor = true;
            this.chkCompany.CheckedChanged += new System.EventHandler(this.chkCompany_CheckedChanged);
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton1.ButtonText = "Export To Excel";
            this.vistaButton1.CornerRadius = 4;
            this.vistaButton1.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton1.Location = new System.Drawing.Point(109, 14);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(120, 30);
            this.vistaButton1.TabIndex = 22;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(232, 14);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
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
            this.btnClose.Location = new System.Drawing.Point(386, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
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
            this.btnPrnt.Location = new System.Drawing.Point(315, 13);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(66, 30);
            this.btnPrnt.TabIndex = 17;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 268;
            this.label3.Text = "PF / ESI Report";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 270;
            this.label4.Text = "Employers Contribution";
            this.label4.Visible = false;
            // 
            // CmbReport
            // 
            this.CmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbReport.FormattingEnabled = true;
            this.CmbReport.Items.AddRange(new object[] {
            "PF",
            "ESI"});
            this.CmbReport.Location = new System.Drawing.Point(404, 187);
            this.CmbReport.Name = "CmbReport";
            this.CmbReport.Size = new System.Drawing.Size(59, 21);
            this.CmbReport.TabIndex = 267;
            this.CmbReport.Visible = false;
            this.CmbReport.SelectedIndexChanged += new System.EventHandler(this.CmbReport_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbYear);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.AttenDtTmPkr);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(484, 55);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(63, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(126, 21);
            this.cmbYear.TabIndex = 259;
            this.cmbYear.DropDown += new System.EventHandler(this.cmbYear_DropDown);
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
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(332, 20);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(133, 20);
            this.AttenDtTmPkr.TabIndex = 264;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(290, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 260;
            this.label21.Text = "Month";
            // 
            // txtEmpContribut
            // 
            this.txtEmpContribut.Location = new System.Drawing.Point(404, 155);
            this.txtEmpContribut.Name = "txtEmpContribut";
            this.txtEmpContribut.Size = new System.Drawing.Size(56, 20);
            this.txtEmpContribut.TabIndex = 269;
            this.txtEmpContribut.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpto);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpForm);
            this.groupBox3.Location = new System.Drawing.Point(7, 191);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 56);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Period";
            this.groupBox3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(44, 33);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(92, 20);
            this.dtpto.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Form";
            // 
            // dtpForm
            // 
            this.dtpForm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpForm.Location = new System.Drawing.Point(44, 10);
            this.dtpForm.Name = "dtpForm";
            this.dtpForm.Size = new System.Drawing.Size(92, 20);
            this.dtpForm.TabIndex = 1;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.raddetails);
            this.groupBox9.Controls.Add(this.radconsoli);
            this.groupBox9.Location = new System.Drawing.Point(163, 201);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(152, 47);
            this.groupBox9.TabIndex = 20;
            this.groupBox9.TabStop = false;
            this.groupBox9.Visible = false;
            // 
            // raddetails
            // 
            this.raddetails.AutoSize = true;
            this.raddetails.Location = new System.Drawing.Point(11, 27);
            this.raddetails.Name = "raddetails";
            this.raddetails.Size = new System.Drawing.Size(57, 17);
            this.raddetails.TabIndex = 3;
            this.raddetails.TabStop = true;
            this.raddetails.Text = "Details";
            this.raddetails.UseVisualStyleBackColor = true;
            // 
            // radconsoli
            // 
            this.radconsoli.AutoSize = true;
            this.radconsoli.Location = new System.Drawing.Point(11, 7);
            this.radconsoli.Name = "radconsoli";
            this.radconsoli.Size = new System.Drawing.Size(86, 17);
            this.radconsoli.TabIndex = 2;
            this.radconsoli.TabStop = true;
            this.radconsoli.Text = "Consolidated";
            this.radconsoli.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMsg.Location = new System.Drawing.Point(13, 325);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 12);
            this.lblMsg.TabIndex = 2;
            // 
            // frmEmployee_PayAdvice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 363);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployee_PayAdvice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMPLOYEE PAYMENT ADVICE";
            this.Load += new System.EventHandler(this.frmEmployee_PayAdvice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnPrnt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpForm;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton raddetails;
        private System.Windows.Forms.RadioButton radconsoli;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox cmbYear;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private System.Windows.Forms.Label lbl_cl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CmbReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpContribut;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbcompany;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.CheckBox chkAllEmp;
        private System.Windows.Forms.Button button1;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.CheckBox chkCompany;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdbRegular;
        private System.Windows.Forms.RadioButton rdbCms_Cash;
        private System.Windows.Forms.RadioButton rdbCms_Neft;
        private System.Windows.Forms.RadioButton rdbCMS_sbi;
        private System.Windows.Forms.Label lblMsg;
        private EDPComponent.VistaButton btnloc;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdbLocation_multi;
        private System.Windows.Forms.RadioButton rdbLocation_single;
    }
}