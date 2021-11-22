namespace PayRollManagementSystem
{
    partial class frmEmployeePaySlipRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeePaySlipRpt));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnl_load = new System.Windows.Forms.Panel();
            this.lbl_load_msg = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cmbLoc = new EDPComponent.ComboDialog();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnWS = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnEmail_prev = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_Eid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_offMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_nomail = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lbl_path = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbLocation = new System.Windows.Forms.RadioButton();
            this.rdbCompany = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpForm = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.pnlMail = new System.Windows.Forms.Panel();
            this.chk_enableSsl = new System.Windows.Forms.CheckBox();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txthost = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblStructureID = new System.Windows.Forms.Label();
            this.lbl_ED = new System.Windows.Forms.Label();
            this.lbl_OT = new System.Windows.Forms.Label();
            this.lbl_NC = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnl_load.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnl_load);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.pnlMail);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 284);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // pnl_load
            // 
            this.pnl_load.BackColor = System.Drawing.Color.White;
            this.pnl_load.Controls.Add(this.lbl_load_msg);
            this.pnl_load.Controls.Add(this.pictureBox1);
            this.pnl_load.Location = new System.Drawing.Point(106, 87);
            this.pnl_load.Name = "pnl_load";
            this.pnl_load.Size = new System.Drawing.Size(314, 182);
            this.pnl_load.TabIndex = 267;
            this.pnl_load.Visible = false;
            // 
            // lbl_load_msg
            // 
            this.lbl_load_msg.AutoSize = true;
            this.lbl_load_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_load_msg.ForeColor = System.Drawing.Color.Black;
            this.lbl_load_msg.Location = new System.Drawing.Point(39, 15);
            this.lbl_load_msg.Name = "lbl_load_msg";
            this.lbl_load_msg.Size = new System.Drawing.Size(104, 16);
            this.lbl_load_msg.TabIndex = 267;
            this.lbl_load_msg.Text = "Please wait... ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(96, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 266;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(11, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(466, 12);
            this.label11.TabIndex = 295;
            this.label11.Text = "If Company Name is not displayed in payslip, please goto Company master and click" +
                " update";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDept);
            this.groupBox2.Controls.Add(this.lblCompany);
            this.groupBox2.Controls.Add(this.cmbLoc);
            this.groupBox2.Controls.Add(this.cmbcompany);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblLoc);
            this.groupBox2.Location = new System.Drawing.Point(6, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 111);
            this.groupBox2.TabIndex = 265;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Details";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(106, 81);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(360, 20);
            this.txtDept.TabIndex = 294;
            this.txtDept.Text = "Manpower Security Services";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(7, 27);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(82, 13);
            this.lblCompany.TabIndex = 293;
            this.lblCompany.Text = "Company Name";
            // 
            // cmbLoc
            // 
            this.cmbLoc.Connection = null;
            this.cmbLoc.DialogResult = "";
            this.cmbLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbLoc.Location = new System.Drawing.Point(106, 50);
            this.cmbLoc.LOVFlag = 0;
            this.cmbLoc.MaxCharLength = 500;
            this.cmbLoc.Name = "cmbLoc";
            this.cmbLoc.ReturnIndex = -1;
            this.cmbLoc.ReturnValue = "";
            this.cmbLoc.ReturnValue_3rd = "";
            this.cmbLoc.ReturnValue_4th = "";
            this.cmbLoc.Size = new System.Drawing.Size(360, 21);
            this.cmbLoc.TabIndex = 292;
            this.cmbLoc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLoc_DropDown);
            this.cmbLoc.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLoc_CloseUp);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbcompany.Location = new System.Drawing.Point(106, 24);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(360, 21);
            this.cmbcompany.TabIndex = 292;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(7, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 265;
            this.label4.Text = "Department";
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.Location = new System.Drawing.Point(7, 54);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(48, 13);
            this.lblLoc.TabIndex = 265;
            this.lblLoc.Text = "Location";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnWS);
            this.groupBox7.Controls.Add(this.btnPreview);
            this.groupBox7.Controls.Add(this.btnEmail_prev);
            this.groupBox7.Controls.Add(this.btnClose);
            this.groupBox7.Controls.Add(this.btnPrnt);
            this.groupBox7.Location = new System.Drawing.Point(6, 196);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 50);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Print Details";
            // 
            // btnWS
            // 
            this.btnWS.BackColor = System.Drawing.Color.Transparent;
            this.btnWS.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnWS.ButtonText = "Wage Slip";
            this.btnWS.CornerRadius = 4;
            this.btnWS.ImageSize = new System.Drawing.Size(16, 16);
            this.btnWS.Location = new System.Drawing.Point(254, 13);
            this.btnWS.Name = "btnWS";
            this.btnWS.Size = new System.Drawing.Size(80, 30);
            this.btnWS.TabIndex = 19;
            this.btnWS.Click += new System.EventHandler(this.btnWS_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(167, 13);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnEmail_prev
            // 
            this.btnEmail_prev.BackColor = System.Drawing.Color.Transparent;
            this.btnEmail_prev.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnEmail_prev.ButtonText = "Email";
            this.btnEmail_prev.CornerRadius = 4;
            this.btnEmail_prev.ImageSize = new System.Drawing.Size(16, 16);
            this.btnEmail_prev.Location = new System.Drawing.Point(73, 13);
            this.btnEmail_prev.Name = "btnEmail_prev";
            this.btnEmail_prev.Size = new System.Drawing.Size(88, 30);
            this.btnEmail_prev.TabIndex = 19;
            this.btnEmail_prev.Click += new System.EventHandler(this.btnEmail_prev_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(408, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 30);
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
            this.btnPrnt.Location = new System.Drawing.Point(341, 13);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(61, 30);
            this.btnPrnt.TabIndex = 17;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Eid,
            this.col_ecode,
            this.col_ename,
            this.col_offMail,
            this.col_gender,
            this.col_status,
            this.col_nomail});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.GridColor = System.Drawing.Color.Gray;
            this.dataGridView1.Location = new System.Drawing.Point(3, 245);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(475, 34);
            this.dataGridView1.TabIndex = 266;
            this.dataGridView1.Visible = false;
            // 
            // col_Eid
            // 
            this.col_Eid.DataPropertyName = "eid";
            this.col_Eid.HeaderText = "EID";
            this.col_Eid.Name = "col_Eid";
            this.col_Eid.Visible = false;
            // 
            // col_ecode
            // 
            this.col_ecode.DataPropertyName = "ecode";
            this.col_ecode.FillWeight = 50F;
            this.col_ecode.HeaderText = "ECode";
            this.col_ecode.Name = "col_ecode";
            // 
            // col_ename
            // 
            this.col_ename.DataPropertyName = "ename";
            this.col_ename.FillWeight = 150F;
            this.col_ename.HeaderText = "Name";
            this.col_ename.Name = "col_ename";
            // 
            // col_offMail
            // 
            this.col_offMail.DataPropertyName = "email2";
            this.col_offMail.HeaderText = "Mail Id";
            this.col_offMail.Name = "col_offMail";
            // 
            // col_gender
            // 
            this.col_gender.DataPropertyName = "gender";
            this.col_gender.FillWeight = 75F;
            this.col_gender.HeaderText = "Gender - Status";
            this.col_gender.Name = "col_gender";
            // 
            // col_status
            // 
            this.col_status.DataPropertyName = "status";
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            // 
            // col_nomail
            // 
            this.col_nomail.DataPropertyName = "nomail";
            this.col_nomail.FillWeight = 50F;
            this.col_nomail.HeaderText = "Send Mail";
            this.col_nomail.Name = "col_nomail";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lbl_path);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.rdbLocation);
            this.groupBox9.Controls.Add(this.rdbCompany);
            this.groupBox9.Location = new System.Drawing.Point(6, 45);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(472, 36);
            this.groupBox9.TabIndex = 20;
            this.groupBox9.TabStop = false;
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_path.Location = new System.Drawing.Point(415, 13);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(2, 15);
            this.lbl_path.TabIndex = 294;
            this.lbl_path.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 293;
            this.label3.Text = "Company Name";
            // 
            // rdbLocation
            // 
            this.rdbLocation.AutoSize = true;
            this.rdbLocation.Location = new System.Drawing.Point(207, 13);
            this.rdbLocation.Name = "rdbLocation";
            this.rdbLocation.Size = new System.Drawing.Size(66, 17);
            this.rdbLocation.TabIndex = 3;
            this.rdbLocation.Text = "Location";
            this.rdbLocation.UseVisualStyleBackColor = true;
            this.rdbLocation.CheckedChanged += new System.EventHandler(this.rdbLocation_CheckedChanged);
            // 
            // rdbCompany
            // 
            this.rdbCompany.AutoSize = true;
            this.rdbCompany.Checked = true;
            this.rdbCompany.Location = new System.Drawing.Point(106, 13);
            this.rdbCompany.Name = "rdbCompany";
            this.rdbCompany.Size = new System.Drawing.Size(69, 17);
            this.rdbCompany.TabIndex = 2;
            this.rdbCompany.TabStop = true;
            this.rdbCompany.Text = "Company";
            this.rdbCompany.UseVisualStyleBackColor = true;
            this.rdbCompany.CheckedChanged += new System.EventHandler(this.rdbCompany_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpto);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpForm);
            this.groupBox3.Location = new System.Drawing.Point(6, 155);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbYear);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.AttenDtTmPkr);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Location = new System.Drawing.Point(6, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 42);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(63, 14);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(126, 21);
            this.cmbYear.TabIndex = 259;
            this.cmbYear.DropDown += new System.EventHandler(this.cmbYear_DropDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label22.Location = new System.Drawing.Point(6, 17);
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
            this.AttenDtTmPkr.Location = new System.Drawing.Point(333, 15);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(133, 20);
            this.AttenDtTmPkr.TabIndex = 264;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(290, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 260;
            this.label21.Text = "Month";
            // 
            // pnlMail
            // 
            this.pnlMail.Controls.Add(this.chk_enableSsl);
            this.pnlMail.Controls.Add(this.chkShowPass);
            this.pnlMail.Controls.Add(this.txtPassword);
            this.pnlMail.Controls.Add(this.label5);
            this.pnlMail.Controls.Add(this.txtPort);
            this.pnlMail.Controls.Add(this.txthost);
            this.pnlMail.Controls.Add(this.TxtEmail);
            this.pnlMail.Controls.Add(this.LblEmail);
            this.pnlMail.Controls.Add(this.label6);
            this.pnlMail.Controls.Add(this.label7);
            this.pnlMail.Controls.Add(this.label8);
            this.pnlMail.Controls.Add(this.label9);
            this.pnlMail.Controls.Add(this.label10);
            this.pnlMail.Controls.Add(this.txtSignature);
            this.pnlMail.Location = new System.Drawing.Point(328, 3);
            this.pnlMail.Name = "pnlMail";
            this.pnlMail.Size = new System.Drawing.Size(162, 281);
            this.pnlMail.TabIndex = 265;
            this.pnlMail.Visible = false;
            // 
            // chk_enableSsl
            // 
            this.chk_enableSsl.AutoSize = true;
            this.chk_enableSsl.Location = new System.Drawing.Point(170, 223);
            this.chk_enableSsl.Name = "chk_enableSsl";
            this.chk_enableSsl.Size = new System.Drawing.Size(44, 17);
            this.chk_enableSsl.TabIndex = 108;
            this.chk_enableSsl.Text = "Yes";
            this.chk_enableSsl.UseVisualStyleBackColor = true;
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Location = new System.Drawing.Point(224, 176);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(102, 17);
            this.chkShowPass.TabIndex = 106;
            this.chkShowPass.Text = "Show Password";
            this.chkShowPass.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(124, 150);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(202, 20);
            this.txtPassword.TabIndex = 105;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = "Password";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.White;
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(249, 248);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(77, 20);
            this.txtPort.TabIndex = 109;
            // 
            // txthost
            // 
            this.txthost.BackColor = System.Drawing.Color.White;
            this.txthost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txthost.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txthost.Location = new System.Drawing.Point(170, 195);
            this.txthost.Name = "txthost";
            this.txthost.Size = new System.Drawing.Size(156, 20);
            this.txthost.TabIndex = 107;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.White;
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.TxtEmail.Location = new System.Drawing.Point(124, 115);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(202, 20);
            this.TxtEmail.TabIndex = 104;
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmail.Location = new System.Drawing.Point(53, 117);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(69, 26);
            this.LblEmail.TabIndex = 110;
            this.LblEmail.Text = "Username\r\n(Full Email)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 100;
            this.label6.Text = "Smtp Host";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 99;
            this.label7.Text = "Smtp Port";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 16);
            this.label8.TabIndex = 101;
            this.label8.Text = "Smtp EnableSsl";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(50, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 16);
            this.label9.TabIndex = 103;
            this.label9.Text = " Network Credential";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(47, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 16);
            this.label10.TabIndex = 102;
            this.label10.Text = "Mail Signature";
            // 
            // txtSignature
            // 
            this.txtSignature.BackColor = System.Drawing.Color.White;
            this.txtSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSignature.Location = new System.Drawing.Point(50, 20);
            this.txtSignature.Multiline = true;
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(276, 59);
            this.txtSignature.TabIndex = 98;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // lblStructureID
            // 
            this.lblStructureID.AutoSize = true;
            this.lblStructureID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStructureID.Location = new System.Drawing.Point(507, 53);
            this.lblStructureID.Name = "lblStructureID";
            this.lblStructureID.Size = new System.Drawing.Size(2, 15);
            this.lblStructureID.TabIndex = 268;
            // 
            // lbl_ED
            // 
            this.lbl_ED.AutoSize = true;
            this.lbl_ED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ED.Location = new System.Drawing.Point(510, 168);
            this.lbl_ED.Name = "lbl_ED";
            this.lbl_ED.Size = new System.Drawing.Size(2, 15);
            this.lbl_ED.TabIndex = 271;
            this.lbl_ED.Visible = false;
            // 
            // lbl_OT
            // 
            this.lbl_OT.AutoSize = true;
            this.lbl_OT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_OT.Location = new System.Drawing.Point(510, 149);
            this.lbl_OT.Name = "lbl_OT";
            this.lbl_OT.Size = new System.Drawing.Size(2, 15);
            this.lbl_OT.TabIndex = 270;
            this.lbl_OT.Visible = false;
            // 
            // lbl_NC
            // 
            this.lbl_NC.AutoSize = true;
            this.lbl_NC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_NC.Location = new System.Drawing.Point(510, 130);
            this.lbl_NC.Name = "lbl_NC";
            this.lbl_NC.Size = new System.Drawing.Size(2, 15);
            this.lbl_NC.TabIndex = 269;
            this.lbl_NC.Visible = false;
            // 
            // frmEmployeePaySlipRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 312);
            this.Controls.Add(this.lbl_ED);
            this.Controls.Add(this.lbl_OT);
            this.Controls.Add(this.lbl_NC);
            this.Controls.Add(this.lblStructureID);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployeePaySlipRpt";
            this.Text = "Payslip";
            this.Load += new System.EventHandler(this.frmEmployeeSalarySheet_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblStructureID, 0);
            this.Controls.SetChildIndex(this.lbl_NC, 0);
            this.Controls.SetChildIndex(this.lbl_OT, 0);
            this.Controls.SetChildIndex(this.lbl_ED, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnl_load.ResumeLayout(false);
            this.pnl_load.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.pnlMail.ResumeLayout(false);
            this.pnlMail.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpForm;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rdbLocation;
        private System.Windows.Forms.RadioButton rdbCompany;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox cmbYear;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCompany;
        private EDPComponent.ComboDialog cmbcompany;
        private EDPComponent.ComboDialog cmbLoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDept;
        private EDPComponent.VistaButton btnEmail_prev;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Eid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ename;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_offMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_nomail;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel pnl_load;
        private System.Windows.Forms.Label lbl_load_msg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_path;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnlMail;
        private System.Windows.Forms.CheckBox chk_enableSsl;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txthost;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Label lblStructureID;
        private System.Windows.Forms.Label label11;
        private EDPComponent.VistaButton btnWS;
        private System.Windows.Forms.Label lbl_ED;
        private System.Windows.Forms.Label lbl_OT;
        private System.Windows.Forms.Label lbl_NC;
    }
}