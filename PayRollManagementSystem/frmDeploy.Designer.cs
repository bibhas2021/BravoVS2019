namespace PayRollManagementSystem
{
    partial class frmDeploy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeploy));
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAllLocation = new System.Windows.Forms.CheckBox();
            this.cmbZone = new EDPComponent.ComboDialog();
            this.CmbEmpId = new EDPComponent.ComboDialog();
            this.cmbemp_against = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_wef = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDOI = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnDelete = new EDPComponent.VistaButton();
            this.btnExit = new EDPComponent.VistaButton();
            this.cmbMemo = new EDPComponent.ComboDialog();
            this.lbl_loc = new System.Windows.Forms.Label();
            this.lbl_eid = new System.Windows.Forms.Label();
            this.lbl_eid_from = new System.Windows.Forms.Label();
            this.cmb_reason = new EDPComponent.ComboDialog();
            this.lbl_reason = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFather = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDesg = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPf = new System.Windows.Forms.Label();
            this.txtEsi = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtUan = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAadhar = new System.Windows.Forms.Label();
            this.txtPan = new System.Windows.Forms.Label();
            this.btnclear = new EDPComponent.VistaButton();
            this.lbl_clid = new System.Windows.Forms.Label();
            this.lbl_coid = new System.Windows.Forms.Label();
            this.lblcomp = new System.Windows.Forms.Label();
            this.lbl_cl_add = new System.Windows.Forms.Label();
            this.lbl_co_add = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbAuthName = new EDPComponent.ComboDialog();
            this.txtAuthCode = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAuthContact = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_againstFather = new System.Windows.Forms.Label();
            this.txt_againstRank = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtClient
            // 
            this.txtClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClient.Enabled = false;
            this.txtClient.ForeColor = System.Drawing.Color.Black;
            this.txtClient.Location = new System.Drawing.Point(100, 34);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(673, 20);
            this.txtClient.TabIndex = 322;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 321;
            this.label8.Text = "Client Name";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(100, 12);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(673, 21);
            this.cmbLocation.TabIndex = 320;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 319;
            this.label2.Text = "Location";
            // 
            // chkAllLocation
            // 
            this.chkAllLocation.AutoSize = true;
            this.chkAllLocation.Location = new System.Drawing.Point(809, 37);
            this.chkAllLocation.Name = "chkAllLocation";
            this.chkAllLocation.Size = new System.Drawing.Size(84, 17);
            this.chkAllLocation.TabIndex = 324;
            this.chkAllLocation.Text = "Select Zone";
            this.chkAllLocation.Visible = false;
            // 
            // cmbZone
            // 
            this.cmbZone.Connection = null;
            this.cmbZone.DialogResult = "";
            this.cmbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.Location = new System.Drawing.Point(809, 12);
            this.cmbZone.LOVFlag = 0;
            this.cmbZone.MaxCharLength = 500;
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.ReturnIndex = -1;
            this.cmbZone.ReturnValue = "";
            this.cmbZone.ReturnValue_3rd = "";
            this.cmbZone.ReturnValue_4th = "";
            this.cmbZone.Size = new System.Drawing.Size(77, 21);
            this.cmbZone.TabIndex = 323;
            this.cmbZone.Visible = false;
            // 
            // CmbEmpId
            // 
            this.CmbEmpId.Connection = null;
            this.CmbEmpId.DialogResult = "";
            this.CmbEmpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEmpId.Location = new System.Drawing.Point(167, 135);
            this.CmbEmpId.LOVFlag = 0;
            this.CmbEmpId.MaxCharLength = 500;
            this.CmbEmpId.Name = "CmbEmpId";
            this.CmbEmpId.ReturnIndex = -1;
            this.CmbEmpId.ReturnValue = "";
            this.CmbEmpId.ReturnValue_3rd = "";
            this.CmbEmpId.ReturnValue_4th = "";
            this.CmbEmpId.Size = new System.Drawing.Size(215, 21);
            this.CmbEmpId.TabIndex = 325;
            this.CmbEmpId.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbEmpId_DropDown);
            this.CmbEmpId.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbEmpId_CloseUp);
            // 
            // cmbemp_against
            // 
            this.cmbemp_against.Connection = null;
            this.cmbemp_against.DialogResult = "";
            this.cmbemp_against.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbemp_against.Location = new System.Drawing.Point(547, 135);
            this.cmbemp_against.LOVFlag = 0;
            this.cmbemp_against.MaxCharLength = 500;
            this.cmbemp_against.Name = "cmbemp_against";
            this.cmbemp_against.ReturnIndex = -1;
            this.cmbemp_against.ReturnValue = "";
            this.cmbemp_against.ReturnValue_3rd = "";
            this.cmbemp_against.ReturnValue_4th = "";
            this.cmbemp_against.Size = new System.Drawing.Size(243, 21);
            this.cmbemp_against.TabIndex = 326;
            this.cmbemp_against.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbemp_against_DropDown);
            this.cmbemp_against.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbemp_against_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 321;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 321;
            this.label3.Text = "In Place of";
            // 
            // dtp_wef
            // 
            this.dtp_wef.CustomFormat = "dd /MMMM /yyyy";
            this.dtp_wef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_wef.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_wef.Location = new System.Drawing.Point(479, 107);
            this.dtp_wef.Name = "dtp_wef";
            this.dtp_wef.Size = new System.Drawing.Size(114, 20);
            this.dtp_wef.TabIndex = 329;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(397, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 328;
            this.label4.Text = "W.E.F";
            // 
            // dtpDOI
            // 
            this.dtpDOI.CustomFormat = "dd /MMMM /yyyy";
            this.dtpDOI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOI.Location = new System.Drawing.Point(274, 107);
            this.dtpDOI.Name = "dtpDOI";
            this.dtpDOI.Size = new System.Drawing.Size(108, 20);
            this.dtpDOI.TabIndex = 330;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(221, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 327;
            this.label7.Text = "Dated";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 321;
            this.label5.Text = "Memo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(388, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 321;
            this.label6.Text = "Reason";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Ivory;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(692, 308);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 26);
            this.btnSave.TabIndex = 332;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BaseColor = System.Drawing.Color.Ivory;
            this.btnDelete.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnDelete.ButtonText = "Preview";
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnDelete.Location = new System.Drawing.Point(515, 308);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(81, 26);
            this.btnDelete.TabIndex = 332;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BaseColor = System.Drawing.Color.Ivory;
            this.btnExit.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnExit.ButtonText = "Exit";
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnExit.Location = new System.Drawing.Point(424, 308);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 26);
            this.btnExit.TabIndex = 332;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbMemo
            // 
            this.cmbMemo.Connection = null;
            this.cmbMemo.DialogResult = "";
            this.cmbMemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMemo.Location = new System.Drawing.Point(99, 106);
            this.cmbMemo.LOVFlag = 0;
            this.cmbMemo.MaxCharLength = 500;
            this.cmbMemo.Name = "cmbMemo";
            this.cmbMemo.ReturnIndex = -1;
            this.cmbMemo.ReturnValue = "";
            this.cmbMemo.ReturnValue_3rd = "";
            this.cmbMemo.ReturnValue_4th = "";
            this.cmbMemo.Size = new System.Drawing.Size(109, 21);
            this.cmbMemo.TabIndex = 325;
            this.cmbMemo.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbMemo_DropDown);
            this.cmbMemo.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbMemo_CloseUp);
            // 
            // lbl_loc
            // 
            this.lbl_loc.AutoSize = true;
            this.lbl_loc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_loc.Location = new System.Drawing.Point(779, 12);
            this.lbl_loc.Name = "lbl_loc";
            this.lbl_loc.Size = new System.Drawing.Size(15, 15);
            this.lbl_loc.TabIndex = 333;
            this.lbl_loc.Text = "0";
            this.lbl_loc.Visible = false;
            // 
            // lbl_eid
            // 
            this.lbl_eid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_eid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_eid.Location = new System.Drawing.Point(100, 135);
            this.lbl_eid.Name = "lbl_eid";
            this.lbl_eid.Size = new System.Drawing.Size(61, 21);
            this.lbl_eid.TabIndex = 333;
            // 
            // lbl_eid_from
            // 
            this.lbl_eid_from.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_eid_from.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_eid_from.Location = new System.Drawing.Point(479, 135);
            this.lbl_eid_from.Name = "lbl_eid_from";
            this.lbl_eid_from.Size = new System.Drawing.Size(62, 21);
            this.lbl_eid_from.TabIndex = 333;
            // 
            // cmb_reason
            // 
            this.cmb_reason.Connection = null;
            this.cmb_reason.DialogResult = "";
            this.cmb_reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_reason.Location = new System.Drawing.Point(479, 208);
            this.cmb_reason.LOVFlag = 0;
            this.cmb_reason.MaxCharLength = 500;
            this.cmb_reason.Name = "cmb_reason";
            this.cmb_reason.ReturnIndex = -1;
            this.cmb_reason.ReturnValue = "";
            this.cmb_reason.ReturnValue_3rd = "";
            this.cmb_reason.ReturnValue_4th = "";
            this.cmb_reason.Size = new System.Drawing.Size(311, 21);
            this.cmb_reason.TabIndex = 326;
            this.cmb_reason.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmb_reason_DropDown);
            this.cmb_reason.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmb_reason_CloseUp);
            // 
            // lbl_reason
            // 
            this.lbl_reason.AutoSize = true;
            this.lbl_reason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_reason.Location = new System.Drawing.Point(796, 211);
            this.lbl_reason.Name = "lbl_reason";
            this.lbl_reason.Size = new System.Drawing.Size(15, 15);
            this.lbl_reason.TabIndex = 333;
            this.lbl_reason.Text = "0";
            this.lbl_reason.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 321;
            this.label9.Text = "Father\'s Name";
            // 
            // txtFather
            // 
            this.txtFather.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFather.Location = new System.Drawing.Point(100, 162);
            this.txtFather.Name = "txtFather";
            this.txtFather.Size = new System.Drawing.Size(282, 21);
            this.txtFather.TabIndex = 333;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 321;
            this.label10.Text = "Designation";
            // 
            // txtDesg
            // 
            this.txtDesg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDesg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesg.Location = new System.Drawing.Point(100, 185);
            this.txtDesg.Name = "txtDesg";
            this.txtDesg.Size = new System.Drawing.Size(282, 21);
            this.txtDesg.TabIndex = 333;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 321;
            this.label12.Text = "PF No";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 237);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 321;
            this.label13.Text = "ESI No";
            // 
            // txtPf
            // 
            this.txtPf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPf.Location = new System.Drawing.Point(100, 210);
            this.txtPf.Name = "txtPf";
            this.txtPf.Size = new System.Drawing.Size(281, 21);
            this.txtPf.TabIndex = 333;
            // 
            // txtEsi
            // 
            this.txtEsi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEsi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEsi.Location = new System.Drawing.Point(100, 233);
            this.txtEsi.Name = "txtEsi";
            this.txtEsi.Size = new System.Drawing.Size(281, 21);
            this.txtEsi.TabIndex = 333;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 259);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 321;
            this.label16.Text = "UAN No";
            // 
            // txtUan
            // 
            this.txtUan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUan.Location = new System.Drawing.Point(101, 255);
            this.txtUan.Name = "txtUan";
            this.txtUan.Size = new System.Drawing.Size(280, 21);
            this.txtUan.TabIndex = 333;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(10, 284);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(67, 13);
            this.label18.TabIndex = 321;
            this.label18.Text = "Aadhar No";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(10, 306);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 321;
            this.label19.Text = "PAN No";
            // 
            // txtAadhar
            // 
            this.txtAadhar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAadhar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAadhar.Location = new System.Drawing.Point(101, 280);
            this.txtAadhar.Name = "txtAadhar";
            this.txtAadhar.Size = new System.Drawing.Size(281, 21);
            this.txtAadhar.TabIndex = 333;
            // 
            // txtPan
            // 
            this.txtPan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPan.Location = new System.Drawing.Point(101, 302);
            this.txtPan.Name = "txtPan";
            this.txtPan.Size = new System.Drawing.Size(281, 21);
            this.txtPan.TabIndex = 333;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.Transparent;
            this.btnclear.BaseColor = System.Drawing.Color.Ivory;
            this.btnclear.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnclear.ButtonText = "Clear";
            this.btnclear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.Color.Black;
            this.btnclear.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnclear.Location = new System.Drawing.Point(605, 308);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(81, 26);
            this.btnclear.TabIndex = 332;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // lbl_clid
            // 
            this.lbl_clid.AutoSize = true;
            this.lbl_clid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_clid.Location = new System.Drawing.Point(779, 38);
            this.lbl_clid.Name = "lbl_clid";
            this.lbl_clid.Size = new System.Drawing.Size(15, 15);
            this.lbl_clid.TabIndex = 333;
            this.lbl_clid.Text = "0";
            this.lbl_clid.Visible = false;
            // 
            // lbl_coid
            // 
            this.lbl_coid.AutoSize = true;
            this.lbl_coid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_coid.Location = new System.Drawing.Point(779, 63);
            this.lbl_coid.Name = "lbl_coid";
            this.lbl_coid.Size = new System.Drawing.Size(15, 15);
            this.lbl_coid.TabIndex = 333;
            this.lbl_coid.Text = "0";
            this.lbl_coid.Visible = false;
            // 
            // lblcomp
            // 
            this.lblcomp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblcomp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblcomp.Location = new System.Drawing.Point(99, 57);
            this.lblcomp.Name = "lblcomp";
            this.lblcomp.Size = new System.Drawing.Size(674, 21);
            this.lblcomp.TabIndex = 333;
            this.lblcomp.Visible = true;
            // 
            // lbl_cl_add
            // 
            this.lbl_cl_add.AutoSize = true;
            this.lbl_cl_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cl_add.Location = new System.Drawing.Point(809, 78);
            this.lbl_cl_add.Name = "lbl_cl_add";
            this.lbl_cl_add.Size = new System.Drawing.Size(15, 15);
            this.lbl_cl_add.TabIndex = 333;
            this.lbl_cl_add.Text = "0";
            this.lbl_cl_add.Visible = false;
            // 
            // lbl_co_add
            // 
            this.lbl_co_add.AutoSize = true;
            this.lbl_co_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_co_add.Location = new System.Drawing.Point(809, 63);
            this.lbl_co_add.Name = "lbl_co_add";
            this.lbl_co_add.Size = new System.Drawing.Size(15, 15);
            this.lbl_co_add.TabIndex = 333;
            this.lbl_co_add.Text = "0";
            this.lbl_co_add.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 321;
            this.label11.Text = "Company";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(390, 255);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 321;
            this.label14.Text = "Name";
            // 
            // cmbAuthName
            // 
            this.cmbAuthName.Connection = null;
            this.cmbAuthName.DialogResult = "";
            this.cmbAuthName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAuthName.Location = new System.Drawing.Point(547, 255);
            this.cmbAuthName.LOVFlag = 0;
            this.cmbAuthName.MaxCharLength = 500;
            this.cmbAuthName.Name = "cmbAuthName";
            this.cmbAuthName.ReturnIndex = -1;
            this.cmbAuthName.ReturnValue = "";
            this.cmbAuthName.ReturnValue_3rd = "";
            this.cmbAuthName.ReturnValue_4th = "";
            this.cmbAuthName.Size = new System.Drawing.Size(243, 21);
            this.cmbAuthName.TabIndex = 325;
            this.cmbAuthName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbAuthName_DropDown);
            this.cmbAuthName.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbAuthName_CloseUp);
            // 
            // txtAuthCode
            // 
            this.txtAuthCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAuthCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthCode.Location = new System.Drawing.Point(480, 255);
            this.txtAuthCode.Name = "txtAuthCode";
            this.txtAuthCode.Size = new System.Drawing.Size(61, 21);
            this.txtAuthCode.TabIndex = 333;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(388, 233);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(169, 16);
            this.label17.TabIndex = 334;
            this.label17.Text = "Authorized Field Officer";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(390, 284);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 321;
            this.label15.Text = "Contact No";
            // 
            // txtAuthContact
            // 
            this.txtAuthContact.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAuthContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthContact.Location = new System.Drawing.Point(480, 279);
            this.txtAuthContact.Name = "txtAuthContact";
            this.txtAuthContact.Size = new System.Drawing.Size(310, 21);
            this.txtAuthContact.TabIndex = 333;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(387, 162);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 13);
            this.label20.TabIndex = 321;
            this.label20.Text = "Father\'s Name";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(387, 180);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 13);
            this.label21.TabIndex = 321;
            this.label21.Text = "Designation";
            // 
            // txt_againstFather
            // 
            this.txt_againstFather.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_againstFather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_againstFather.Location = new System.Drawing.Point(479, 158);
            this.txt_againstFather.Name = "txt_againstFather";
            this.txt_againstFather.Size = new System.Drawing.Size(311, 21);
            this.txt_againstFather.TabIndex = 333;
            // 
            // txt_againstRank
            // 
            this.txt_againstRank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_againstRank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_againstRank.Location = new System.Drawing.Point(479, 180);
            this.txt_againstRank.Name = "txt_againstRank";
            this.txt_againstRank.Size = new System.Drawing.Size(311, 21);
            this.txt_againstRank.TabIndex = 333;
            // 
            // frmDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(898, 356);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lbl_reason);
            this.Controls.Add(this.lbl_eid_from);
            this.Controls.Add(this.txtPan);
            this.Controls.Add(this.txtUan);
            this.Controls.Add(this.txtAadhar);
            this.Controls.Add(this.txtEsi);
            this.Controls.Add(this.txtPf);
            this.Controls.Add(this.txtAuthContact);
            this.Controls.Add(this.txt_againstRank);
            this.Controls.Add(this.txtDesg);
            this.Controls.Add(this.txt_againstFather);
            this.Controls.Add(this.txtFather);
            this.Controls.Add(this.txtAuthCode);
            this.Controls.Add(this.lbl_eid);
            this.Controls.Add(this.lbl_co_add);
            this.Controls.Add(this.lbl_cl_add);
            this.Controls.Add(this.lblcomp);
            this.Controls.Add(this.lbl_coid);
            this.Controls.Add(this.lbl_clid);
            this.Controls.Add(this.lbl_loc);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtp_wef);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDOI);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_reason);
            this.Controls.Add(this.cmbemp_against);
            this.Controls.Add(this.cmbMemo);
            this.Controls.Add(this.cmbAuthName);
            this.Controls.Add(this.CmbEmpId);
            this.Controls.Add(this.chkAllLocation);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDeploy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movement / Deployment";
            this.Load += new System.EventHandler(this.frmDeploy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label8;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAllLocation;
        private EDPComponent.ComboDialog cmbZone;
        private EDPComponent.ComboDialog CmbEmpId;
        private EDPComponent.ComboDialog cmbemp_against;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_wef;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDOI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnDelete;
        private EDPComponent.VistaButton btnExit;
        private EDPComponent.ComboDialog cmbMemo;
        private System.Windows.Forms.Label lbl_loc;
        private System.Windows.Forms.Label lbl_eid;
        private System.Windows.Forms.Label lbl_eid_from;
        private EDPComponent.ComboDialog cmb_reason;
        private System.Windows.Forms.Label lbl_reason;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtFather;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtDesg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtPf;
        private System.Windows.Forms.Label txtEsi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label txtUan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label txtAadhar;
        private System.Windows.Forms.Label txtPan;
        private EDPComponent.VistaButton btnclear;
        private System.Windows.Forms.Label lbl_clid;
        private System.Windows.Forms.Label lbl_coid;
        private System.Windows.Forms.Label lblcomp;
        private System.Windows.Forms.Label lbl_cl_add;
        private System.Windows.Forms.Label lbl_co_add;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private EDPComponent.ComboDialog cmbAuthName;
        private System.Windows.Forms.Label txtAuthCode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label txtAuthContact;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label txt_againstFather;
        private System.Windows.Forms.Label txt_againstRank;
    }
}