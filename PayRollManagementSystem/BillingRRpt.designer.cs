namespace PayRollManagementSystem
{
    partial class BillingRRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingRRpt));
            this.LblSession = new System.Windows.Forms.Label();
            this.btnPreview = new EDPComponent.VistaButton();
            this.CmbSession = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbSession = new System.Windows.Forms.RadioButton();
            this.rdbBDMonth = new System.Windows.Forms.RadioButton();
            this.rdbMonth = new System.Windows.Forms.RadioButton();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTypOfTax = new System.Windows.Forms.ComboBox();
            this.rdbdtwise = new System.Windows.Forms.RadioButton();
            this.rdbmnthwise = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.chk_All_Client = new System.Windows.Forms.CheckBox();
            this.btnclient = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbdVoucher = new System.Windows.Forms.RadioButton();
            this.grp_period = new System.Windows.Forms.GroupBox();
            this.grp_month = new System.Windows.Forms.GroupBox();
            this.grp_bill = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBill_To = new EDPComponent.ComboDialog();
            this.cmbBill_from = new EDPComponent.ComboDialog();
            this.btnPrev = new EDPComponent.VistaButton();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb_ord_party = new System.Windows.Forms.RadioButton();
            this.rdb_ord_bill = new System.Windows.Forms.RadioButton();
            this.rdb_ord_Date = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkCancel = new System.Windows.Forms.CheckBox();
            this.rdbZone = new System.Windows.Forms.RadioButton();
            this.grp_zone = new System.Windows.Forms.GroupBox();
            this.cmbZone = new EDPComponent.ComboDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grp_period.SuspendLayout();
            this.grp_month.SuspendLayout();
            this.grp_bill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grp_zone.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblSession
            // 
            this.LblSession.AutoSize = true;
            this.LblSession.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSession.Location = new System.Drawing.Point(19, 17);
            this.LblSession.Name = "LblSession";
            this.LblSession.Size = new System.Drawing.Size(107, 30);
            this.LblSession.TabIndex = 296;
            this.LblSession.Text = "Select Session\r\n(Default Current)";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "Preview Report";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(250, 329);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(213, 31);
            this.btnPreview.TabIndex = 301;
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.Click += new System.EventHandler(this.FrmBillingReport_Click);
            // 
            // CmbSession
            // 
            this.CmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSession.ForeColor = System.Drawing.Color.Black;
            this.CmbSession.FormattingEnabled = true;
            this.CmbSession.Location = new System.Drawing.Point(186, 15);
            this.CmbSession.Name = "CmbSession";
            this.CmbSession.Size = new System.Drawing.Size(276, 21);
            this.CmbSession.TabIndex = 302;
            this.CmbSession.SelectedIndexChanged += new System.EventHandler(this.CmbSession_SelectedIndexChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "All",
            "April",
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
            "March"});
            this.cmbMonth.Location = new System.Drawing.Point(41, 20);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(195, 21);
            this.cmbMonth.TabIndex = 302;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSession);
            this.groupBox1.Controls.Add(this.rdbBDMonth);
            this.groupBox1.Controls.Add(this.rdbMonth);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(60, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 96);
            this.groupBox1.TabIndex = 303;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Type (Month wise)";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdbSession
            // 
            this.rdbSession.AutoSize = true;
            this.rdbSession.Location = new System.Drawing.Point(56, 65);
            this.rdbSession.Name = "rdbSession";
            this.rdbSession.Size = new System.Drawing.Size(92, 18);
            this.rdbSession.TabIndex = 0;
            this.rdbSession.TabStop = true;
            this.rdbSession.Text = "Full Session";
            this.rdbSession.UseVisualStyleBackColor = true;
            this.rdbSession.CheckedChanged += new System.EventHandler(this.rdbSession_CheckedChanged);
            // 
            // rdbBDMonth
            // 
            this.rdbBDMonth.AutoSize = true;
            this.rdbBDMonth.Location = new System.Drawing.Point(56, 42);
            this.rdbBDMonth.Name = "rdbBDMonth";
            this.rdbBDMonth.Size = new System.Drawing.Size(103, 18);
            this.rdbBDMonth.TabIndex = 0;
            this.rdbBDMonth.TabStop = true;
            this.rdbBDMonth.Text = "BillDate Month";
            this.rdbBDMonth.UseVisualStyleBackColor = true;
            this.rdbBDMonth.CheckedChanged += new System.EventHandler(this.rdbSession_CheckedChanged);
            // 
            // rdbMonth
            // 
            this.rdbMonth.AutoSize = true;
            this.rdbMonth.Location = new System.Drawing.Point(56, 19);
            this.rdbMonth.Name = "rdbMonth";
            this.rdbMonth.Size = new System.Drawing.Size(109, 18);
            this.rdbMonth.TabIndex = 0;
            this.rdbMonth.TabStop = true;
            this.rdbMonth.Text = "Context Month ";
            this.rdbMonth.UseVisualStyleBackColor = true;
            this.rdbMonth.CheckedChanged += new System.EventHandler(this.rdbSession_CheckedChanged);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(187, 56);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(276, 21);
            this.cmbcompany.TabIndex = 297;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompany.Location = new System.Drawing.Point(17, 61);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(119, 15);
            this.LblCompany.TabIndex = 298;
            this.LblCompany.Text = "1. Select Company";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 304;
            this.label2.Text = "Select Type of TAX";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbTypOfTax
            // 
            this.cbTypOfTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypOfTax.FormattingEnabled = true;
            this.cbTypOfTax.Items.AddRange(new object[] {
            "SERVICE TAX",
            "GST"});
            this.cbTypOfTax.Location = new System.Drawing.Point(137, 365);
            this.cbTypOfTax.Name = "cbTypOfTax";
            this.cbTypOfTax.Size = new System.Drawing.Size(107, 21);
            this.cbTypOfTax.TabIndex = 305;
            this.cbTypOfTax.Visible = false;
            this.cbTypOfTax.SelectedIndexChanged += new System.EventHandler(this.cbTypOfTax_SelectedIndexChanged);
            // 
            // rdbdtwise
            // 
            this.rdbdtwise.AutoSize = true;
            this.rdbdtwise.Location = new System.Drawing.Point(7, 18);
            this.rdbdtwise.Name = "rdbdtwise";
            this.rdbdtwise.Size = new System.Drawing.Size(79, 18);
            this.rdbdtwise.TabIndex = 306;
            this.rdbdtwise.Text = "Date Wise";
            this.rdbdtwise.UseVisualStyleBackColor = true;
            this.rdbdtwise.CheckedChanged += new System.EventHandler(this.rdbdtwise_CheckedChanged);
            // 
            // rdbmnthwise
            // 
            this.rdbmnthwise.AutoSize = true;
            this.rdbmnthwise.Location = new System.Drawing.Point(96, 19);
            this.rdbmnthwise.Name = "rdbmnthwise";
            this.rdbmnthwise.Size = new System.Drawing.Size(90, 18);
            this.rdbmnthwise.TabIndex = 307;
            this.rdbmnthwise.Text = "Month Wise";
            this.rdbmnthwise.UseVisualStyleBackColor = true;
            this.rdbmnthwise.CheckedChanged += new System.EventHandler(this.rdbdtwise_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 308;
            this.label3.Text = "From";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(41, 18);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker1.TabIndex = 309;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 310;
            this.label4.Text = "To";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(168, 19);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker2.TabIndex = 311;
            // 
            // chk_All_Client
            // 
            this.chk_All_Client.AutoSize = true;
            this.chk_All_Client.Location = new System.Drawing.Point(257, 236);
            this.chk_All_Client.Name = "chk_All_Client";
            this.chk_All_Client.Size = new System.Drawing.Size(71, 17);
            this.chk_All_Client.TabIndex = 312;
            this.chk_All_Client.Text = "All Clients";
            this.chk_All_Client.UseVisualStyleBackColor = true;
            this.chk_All_Client.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnclient
            // 
            this.btnclient.Location = new System.Drawing.Point(332, 232);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(131, 23);
            this.btnclient.TabIndex = 313;
            this.btnclient.Text = "Select Client";
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbdVoucher);
            this.groupBox7.Controls.Add(this.rdbZone);
            this.groupBox7.Controls.Add(this.rdbdtwise);
            this.groupBox7.Controls.Add(this.rdbmnthwise);
            this.groupBox7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(187, 83);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(276, 60);
            this.groupBox7.TabIndex = 314;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Selective Features";
            // 
            // rbdVoucher
            // 
            this.rbdVoucher.AutoSize = true;
            this.rbdVoucher.Checked = true;
            this.rbdVoucher.Location = new System.Drawing.Point(7, 38);
            this.rbdVoucher.Name = "rbdVoucher";
            this.rbdVoucher.Size = new System.Drawing.Size(85, 18);
            this.rbdVoucher.TabIndex = 1;
            this.rbdVoucher.TabStop = true;
            this.rbdVoucher.Text = "Billno Wise";
            this.rbdVoucher.UseVisualStyleBackColor = true;
            this.rbdVoucher.CheckedChanged += new System.EventHandler(this.rdbdtwise_CheckedChanged);
            // 
            // grp_period
            // 
            this.grp_period.Controls.Add(this.dateTimePicker1);
            this.grp_period.Controls.Add(this.label3);
            this.grp_period.Controls.Add(this.dateTimePicker2);
            this.grp_period.Controls.Add(this.label4);
            this.grp_period.Location = new System.Drawing.Point(187, 145);
            this.grp_period.Name = "grp_period";
            this.grp_period.Size = new System.Drawing.Size(276, 56);
            this.grp_period.TabIndex = 315;
            this.grp_period.TabStop = false;
            this.grp_period.Text = "Select Period";
            // 
            // grp_month
            // 
            this.grp_month.Controls.Add(this.cmbMonth);
            this.grp_month.Location = new System.Drawing.Point(187, 146);
            this.grp_month.Name = "grp_month";
            this.grp_month.Size = new System.Drawing.Size(276, 55);
            this.grp_month.TabIndex = 316;
            this.grp_month.TabStop = false;
            this.grp_month.Text = "Select Month";
            // 
            // grp_bill
            // 
            this.grp_bill.Controls.Add(this.label1);
            this.grp_bill.Controls.Add(this.label5);
            this.grp_bill.Controls.Add(this.cmbBill_To);
            this.grp_bill.Controls.Add(this.cmbBill_from);
            this.grp_bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_bill.Location = new System.Drawing.Point(187, 145);
            this.grp_bill.Name = "grp_bill";
            this.grp_bill.Size = new System.Drawing.Size(276, 81);
            this.grp_bill.TabIndex = 317;
            this.grp_bill.TabStop = false;
            this.grp_bill.Text = "Bill No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 311;
            this.label1.Text = "Upto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 311;
            this.label5.Text = "From";
            // 
            // cmbBill_To
            // 
            this.cmbBill_To.Connection = null;
            this.cmbBill_To.DialogResult = "";
            this.cmbBill_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBill_To.Location = new System.Drawing.Point(56, 46);
            this.cmbBill_To.LOVFlag = 0;
            this.cmbBill_To.MaxCharLength = 500;
            this.cmbBill_To.Name = "cmbBill_To";
            this.cmbBill_To.ReturnIndex = -1;
            this.cmbBill_To.ReturnValue = "";
            this.cmbBill_To.ReturnValue_3rd = "";
            this.cmbBill_To.ReturnValue_4th = "";
            this.cmbBill_To.Size = new System.Drawing.Size(200, 21);
            this.cmbBill_To.TabIndex = 298;
            this.cmbBill_To.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbBill_To_DropDown);
            this.cmbBill_To.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbBill_To_CloseUp);
            // 
            // cmbBill_from
            // 
            this.cmbBill_from.Connection = null;
            this.cmbBill_from.DialogResult = "";
            this.cmbBill_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBill_from.Location = new System.Drawing.Point(56, 19);
            this.cmbBill_from.LOVFlag = 0;
            this.cmbBill_from.MaxCharLength = 500;
            this.cmbBill_from.Name = "cmbBill_from";
            this.cmbBill_from.ReturnIndex = -1;
            this.cmbBill_from.ReturnValue = "";
            this.cmbBill_from.ReturnValue_3rd = "";
            this.cmbBill_from.ReturnValue_4th = "";
            this.cmbBill_from.Size = new System.Drawing.Size(200, 21);
            this.cmbBill_from.TabIndex = 298;
            this.cmbBill_from.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbBill_from_DropDown);
            this.cmbBill_from.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbBill_from_CloseUp);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrev.ButtonText = "Export Complete (With Receipt)";
            this.btnPrev.CornerRadius = 4;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrev.Location = new System.Drawing.Point(250, 363);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(213, 31);
            this.btnPrev.TabIndex = 301;
            this.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.AllowUserToDeleteRows = false;
            this.dgvShow.AllowUserToOrderColumns = true;
            this.dgvShow.AllowUserToResizeColumns = false;
            this.dgvShow.AllowUserToResizeRows = false;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Location = new System.Drawing.Point(34, 398);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.Size = new System.Drawing.Size(473, 10);
            this.dgvShow.TabIndex = 318;
            this.dgvShow.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb_ord_party);
            this.groupBox2.Controls.Add(this.rdb_ord_bill);
            this.groupBox2.Controls.Add(this.rdb_ord_Date);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(250, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 65);
            this.groupBox2.TabIndex = 319;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Order By Records";
            // 
            // rdb_ord_party
            // 
            this.rdb_ord_party.AutoSize = true;
            this.rdb_ord_party.Location = new System.Drawing.Point(92, 20);
            this.rdb_ord_party.Name = "rdb_ord_party";
            this.rdb_ord_party.Size = new System.Drawing.Size(114, 18);
            this.rdb_ord_party.TabIndex = 0;
            this.rdb_ord_party.Text = "Client - Location";
            this.rdb_ord_party.UseVisualStyleBackColor = true;
            // 
            // rdb_ord_bill
            // 
            this.rdb_ord_bill.AutoSize = true;
            this.rdb_ord_bill.Checked = true;
            this.rdb_ord_bill.Location = new System.Drawing.Point(11, 42);
            this.rdb_ord_bill.Name = "rdb_ord_bill";
            this.rdb_ord_bill.Size = new System.Drawing.Size(58, 18);
            this.rdb_ord_bill.TabIndex = 0;
            this.rdb_ord_bill.TabStop = true;
            this.rdb_ord_bill.Text = "Bill No";
            this.rdb_ord_bill.UseVisualStyleBackColor = true;
            // 
            // rdb_ord_Date
            // 
            this.rdb_ord_Date.AutoSize = true;
            this.rdb_ord_Date.Location = new System.Drawing.Point(11, 20);
            this.rdb_ord_Date.Name = "rdb_ord_Date";
            this.rdb_ord_Date.Size = new System.Drawing.Size(68, 18);
            this.rdb_ord_Date.TabIndex = 0;
            this.rdb_ord_Date.Text = "Bill Date";
            this.rdb_ord_Date.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 15);
            this.label6.TabIndex = 298;
            this.label6.Text = "2. Select Search Basis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 15);
            this.label7.TabIndex = 298;
            this.label7.Text = "2. Select Basis Range";
            // 
            // chkCancel
            // 
            this.chkCancel.AutoSize = true;
            this.chkCancel.Location = new System.Drawing.Point(116, 338);
            this.chkCancel.Name = "chkCancel";
            this.chkCancel.Size = new System.Drawing.Size(119, 17);
            this.chkCancel.TabIndex = 320;
            this.chkCancel.Text = "Show Cancelled Bill";
            this.chkCancel.UseVisualStyleBackColor = true;
            this.chkCancel.CheckedChanged += new System.EventHandler(this.chkCancel_CheckedChanged);
            // 
            // rdbZone
            // 
            this.rdbZone.AutoSize = true;
            this.rdbZone.Location = new System.Drawing.Point(96, 39);
            this.rdbZone.Name = "rdbZone";
            this.rdbZone.Size = new System.Drawing.Size(53, 18);
            this.rdbZone.TabIndex = 306;
            this.rdbZone.Text = "Zone";
            this.rdbZone.UseVisualStyleBackColor = true;
            this.rdbZone.CheckedChanged += new System.EventHandler(this.rdbdtwise_CheckedChanged);
            // 
            // grp_zone
            // 
            this.grp_zone.Controls.Add(this.cmbZone);
            this.grp_zone.Location = new System.Drawing.Point(185, 145);
            this.grp_zone.Name = "grp_zone";
            this.grp_zone.Size = new System.Drawing.Size(276, 55);
            this.grp_zone.TabIndex = 317;
            this.grp_zone.TabStop = false;
            this.grp_zone.Text = "Select Zone";
            // 
            // cmbZone
            // 
            this.cmbZone.Connection = null;
            this.cmbZone.DialogResult = "";
            this.cmbZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZone.Location = new System.Drawing.Point(18, 19);
            this.cmbZone.LOVFlag = 0;
            this.cmbZone.MaxCharLength = 500;
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.ReturnIndex = -1;
            this.cmbZone.ReturnValue = "";
            this.cmbZone.ReturnValue_3rd = "";
            this.cmbZone.ReturnValue_4th = "";
            this.cmbZone.Size = new System.Drawing.Size(252, 21);
            this.cmbZone.TabIndex = 298;
            this.cmbZone.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbZone_DropDown);
            // 
            // BillingRRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(545, 431);
            this.Controls.Add(this.grp_zone);
            this.Controls.Add(this.chkCancel);
            this.Controls.Add(this.grp_month);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.grp_bill);
            this.Controls.Add(this.grp_period);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnclient);
            this.Controls.Add(this.chk_All_Client);
            this.Controls.Add(this.CmbSession);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTypOfTax);
            this.Controls.Add(this.LblSession);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BillingRRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Report";
            this.Load += new System.EventHandler(this.BillingRRpt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grp_period.ResumeLayout(false);
            this.grp_period.PerformLayout();
            this.grp_month.ResumeLayout(false);
            this.grp_bill.ResumeLayout(false);
            this.grp_bill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grp_zone.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSession;
        public EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.ComboBox CmbSession;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbSession;
        private System.Windows.Forms.RadioButton rdbMonth;
        private System.Windows.Forms.RadioButton rdbBDMonth;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTypOfTax;
        private System.Windows.Forms.RadioButton rdbdtwise;
        private System.Windows.Forms.RadioButton rdbmnthwise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox chk_All_Client;
        private System.Windows.Forms.Button btnclient;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbdVoucher;
        private System.Windows.Forms.GroupBox grp_period;
        private System.Windows.Forms.GroupBox grp_month;
        private System.Windows.Forms.GroupBox grp_bill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private EDPComponent.ComboDialog cmbBill_To;
        private EDPComponent.ComboDialog cmbBill_from;
        public EDPComponent.VistaButton btnPrev;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb_ord_party;
        private System.Windows.Forms.RadioButton rdb_ord_bill;
        private System.Windows.Forms.RadioButton rdb_ord_Date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkCancel;
        private System.Windows.Forms.RadioButton rdbZone;
        private System.Windows.Forms.GroupBox grp_zone;
        private EDPComponent.ComboDialog cmbZone;
    }
}