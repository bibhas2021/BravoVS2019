namespace PayRollManagementSystem
{
    partial class frm_Mst_Kit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Mst_Kit));
            this.btnSave = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.BTNdELETE = new EDPComponent.VistaButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnClStock = new EDPComponent.VistaButton();
            this.btnIssueReturn = new EDPComponent.VistaButton();
            this.btnDamage = new EDPComponent.VistaButton();
            this.btnIssue = new EDPComponent.VistaButton();
            this.btnPurReturn = new EDPComponent.VistaButton();
            this.btnPurchase = new EDPComponent.VistaButton();
            this.dgv_Kit = new System.Windows.Forms.DataGridView();
            this.KTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KTVAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpeningStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpeningValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_fine = new System.Windows.Forms.DataGridView();
            this.dgCol_fid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_fcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_freason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCol_fval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_fclose = new EDPComponent.VistaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblfid = new System.Windows.Forms.Label();
            this.txt_freason = new System.Windows.Forms.TextBox();
            this.txt_fval = new System.Windows.Forms.TextBox();
            this.txt_fcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnfClear = new EDPComponent.VistaButton();
            this.btn_fdel = new EDPComponent.VistaButton();
            this.btn_fsave = new EDPComponent.VistaButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kit)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fine)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Ivory;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(816, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 26);
            this.btnSave.TabIndex = 14;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Ivory;
            this.btnClose.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClose.Location = new System.Drawing.Point(909, 427);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 26);
            this.btnClose.TabIndex = 14;
            this.btnClose.Click += new System.EventHandler(this.img_close_Click);
            // 
            // BTNdELETE
            // 
            this.BTNdELETE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNdELETE.BackColor = System.Drawing.Color.Transparent;
            this.BTNdELETE.BaseColor = System.Drawing.Color.Ivory;
            this.BTNdELETE.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BTNdELETE.ButtonText = "Delete";
            this.BTNdELETE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNdELETE.ForeColor = System.Drawing.Color.Black;
            this.BTNdELETE.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BTNdELETE.Location = new System.Drawing.Point(723, 427);
            this.BTNdELETE.Name = "BTNdELETE";
            this.BTNdELETE.Size = new System.Drawing.Size(87, 26);
            this.BTNdELETE.TabIndex = 14;
            this.BTNdELETE.Click += new System.EventHandler(this.BTNdELETE_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 501);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.CmbCompany);
            this.tabPage1.Controls.Add(this.LblCompany);
            this.tabPage1.Controls.Add(this.AttenDtTmPkr);
            this.tabPage1.Controls.Add(this.cmbYear);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.btnClStock);
            this.tabPage1.Controls.Add(this.btnIssueReturn);
            this.tabPage1.Controls.Add(this.btnDamage);
            this.tabPage1.Controls.Add(this.btnIssue);
            this.tabPage1.Controls.Add(this.btnPurReturn);
            this.tabPage1.Controls.Add(this.btnPurchase);
            this.tabPage1.Controls.Add(this.dgv_Kit);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.BTNdELETE);
            this.tabPage1.Controls.Add(this.btnClose);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1004, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "KIT Master";
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(311, 8);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(406, 21);
            this.CmbCompany.TabIndex = 323;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(240, 8);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(58, 15);
            this.LblCompany.TabIndex = 324;
            this.LblCompany.Text = "Company";
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(737, 8);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(143, 22);
            this.AttenDtTmPkr.TabIndex = 315;
            this.AttenDtTmPkr.Visible = false;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.BackColor = System.Drawing.Color.White;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(82, 6);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(145, 23);
            this.cmbYear.TabIndex = 256;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 257;
            this.label22.Text = "Session";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // btnClStock
            // 
            this.btnClStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClStock.BackColor = System.Drawing.Color.Transparent;
            this.btnClStock.BaseColor = System.Drawing.Color.Ivory;
            this.btnClStock.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClStock.ButtonText = "CLOSING STOCK";
            this.btnClStock.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClStock.ForeColor = System.Drawing.Color.Black;
            this.btnClStock.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClStock.Location = new System.Drawing.Point(561, 427);
            this.btnClStock.Name = "btnClStock";
            this.btnClStock.Size = new System.Drawing.Size(120, 26);
            this.btnClStock.TabIndex = 19;
            this.btnClStock.Visible = false;
            this.btnClStock.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // btnIssueReturn
            // 
            this.btnIssueReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIssueReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnIssueReturn.BaseColor = System.Drawing.Color.Ivory;
            this.btnIssueReturn.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnIssueReturn.ButtonText = "ISSUE RETURN";
            this.btnIssueReturn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReturn.ForeColor = System.Drawing.Color.Black;
            this.btnIssueReturn.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnIssueReturn.Location = new System.Drawing.Point(352, 427);
            this.btnIssueReturn.Name = "btnIssueReturn";
            this.btnIssueReturn.Size = new System.Drawing.Size(109, 26);
            this.btnIssueReturn.TabIndex = 18;
            this.btnIssueReturn.Visible = false;
            this.btnIssueReturn.Click += new System.EventHandler(this.btnIssueReturn_Click);
            // 
            // btnDamage
            // 
            this.btnDamage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDamage.BackColor = System.Drawing.Color.Transparent;
            this.btnDamage.BaseColor = System.Drawing.Color.Ivory;
            this.btnDamage.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnDamage.ButtonText = "DAMAGE";
            this.btnDamage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDamage.ForeColor = System.Drawing.Color.Black;
            this.btnDamage.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnDamage.Location = new System.Drawing.Point(472, 427);
            this.btnDamage.Name = "btnDamage";
            this.btnDamage.Size = new System.Drawing.Size(80, 26);
            this.btnDamage.TabIndex = 18;
            this.btnDamage.Visible = false;
            this.btnDamage.Click += new System.EventHandler(this.btnDamage_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIssue.BackColor = System.Drawing.Color.Transparent;
            this.btnIssue.BaseColor = System.Drawing.Color.Ivory;
            this.btnIssue.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnIssue.ButtonText = "ISSUE";
            this.btnIssue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.Black;
            this.btnIssue.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnIssue.Location = new System.Drawing.Point(267, 427);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(80, 26);
            this.btnIssue.TabIndex = 18;
            this.btnIssue.Visible = false;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnPurReturn
            // 
            this.btnPurReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnPurReturn.BaseColor = System.Drawing.Color.Ivory;
            this.btnPurReturn.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnPurReturn.ButtonText = "PURCHASE RETURN";
            this.btnPurReturn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurReturn.ForeColor = System.Drawing.Color.Black;
            this.btnPurReturn.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnPurReturn.Location = new System.Drawing.Point(104, 427);
            this.btnPurReturn.Name = "btnPurReturn";
            this.btnPurReturn.Size = new System.Drawing.Size(136, 26);
            this.btnPurReturn.TabIndex = 18;
            this.btnPurReturn.Visible = false;
            this.btnPurReturn.Click += new System.EventHandler(this.btnPurReturn_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurchase.BackColor = System.Drawing.Color.Transparent;
            this.btnPurchase.BaseColor = System.Drawing.Color.Ivory;
            this.btnPurchase.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnPurchase.ButtonText = "PURCHASE";
            this.btnPurchase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchase.ForeColor = System.Drawing.Color.Black;
            this.btnPurchase.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnPurchase.Location = new System.Drawing.Point(12, 427);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(87, 26);
            this.btnPurchase.TabIndex = 18;
            this.btnPurchase.Visible = false;
            this.btnPurchase.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // dgv_Kit
            // 
            this.dgv_Kit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Kit.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Kit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Kit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KTNO,
            this.KTNAME,
            this.KTVAL,
            this.OpeningStock,
            this.Unit,
            this.Date,
            this.OpeningValue,
            this.MinStock,
            this.msUnit,
            this.roQty,
            this.roUnit});
            this.dgv_Kit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgv_Kit.GridColor = System.Drawing.Color.DarkGray;
            this.dgv_Kit.Location = new System.Drawing.Point(3, 35);
            this.dgv_Kit.Name = "dgv_Kit";
            this.dgv_Kit.Size = new System.Drawing.Size(998, 370);
            this.dgv_Kit.TabIndex = 17;
            this.dgv_Kit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Kit_CellDoubleClick);
            this.dgv_Kit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Kit_CellEndEdit);
            // 
            // KTNO
            // 
            this.KTNO.HeaderText = "KIT NO";
            this.KTNO.Name = "KTNO";
            this.KTNO.Visible = false;
            // 
            // KTNAME
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.KTNAME.DefaultCellStyle = dataGridViewCellStyle1;
            this.KTNAME.HeaderText = "KIT NAME";
            this.KTNAME.MinimumWidth = 150;
            this.KTNAME.Name = "KTNAME";
            this.KTNAME.Width = 250;
            // 
            // KTVAL
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KTVAL.DefaultCellStyle = dataGridViewCellStyle2;
            this.KTVAL.HeaderText = "RATE";
            this.KTVAL.Name = "KTVAL";
            // 
            // OpeningStock
            // 
            this.OpeningStock.DataPropertyName = "OpeningStock";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OpeningStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.OpeningStock.HeaderText = "OPENING STOCK";
            this.OpeningStock.Name = "OpeningStock";
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Unit.DefaultCellStyle = dataGridViewCellStyle4;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "OPENING DATE";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OpeningValue
            // 
            this.OpeningValue.DataPropertyName = "OpeningValue";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OpeningValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.OpeningValue.HeaderText = "OPENING VALUE";
            this.OpeningValue.Name = "OpeningValue";
            // 
            // MinStock
            // 
            this.MinStock.HeaderText = "Min Stock";
            this.MinStock.Name = "MinStock";
            // 
            // msUnit
            // 
            this.msUnit.HeaderText = "Unit";
            this.msUnit.Name = "msUnit";
            // 
            // roQty
            // 
            this.roQty.HeaderText = "Reorder Qty";
            this.roQty.Name = "roQty";
            // 
            // roUnit
            // 
            this.roUnit.HeaderText = "Unit";
            this.roUnit.Name = "roUnit";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 408);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(998, 59);
            this.splitter1.TabIndex = 15;
            this.splitter1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage2.Controls.Add(this.dgv_fine);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1004, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FINE Master";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_fine
            // 
            this.dgv_fine.AllowUserToAddRows = false;
            this.dgv_fine.AllowUserToDeleteRows = false;
            this.dgv_fine.BackgroundColor = System.Drawing.Color.White;
            this.dgv_fine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_fine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgCol_fid,
            this.dgCol_fcode,
            this.dgCol_freason,
            this.dgCol_fval});
            this.dgv_fine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_fine.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgv_fine.GridColor = System.Drawing.Color.DarkGray;
            this.dgv_fine.Location = new System.Drawing.Point(3, 122);
            this.dgv_fine.Name = "dgv_fine";
            this.dgv_fine.ReadOnly = true;
            this.dgv_fine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_fine.Size = new System.Drawing.Size(998, 303);
            this.dgv_fine.TabIndex = 22;
            this.dgv_fine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_fine_CellClick);
            // 
            // dgCol_fid
            // 
            this.dgCol_fid.HeaderText = "Fine ID";
            this.dgCol_fid.Name = "dgCol_fid";
            this.dgCol_fid.ReadOnly = true;
            this.dgCol_fid.Visible = false;
            // 
            // dgCol_fcode
            // 
            this.dgCol_fcode.HeaderText = "Fine Code";
            this.dgCol_fcode.Name = "dgCol_fcode";
            this.dgCol_fcode.ReadOnly = true;
            // 
            // dgCol_freason
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgCol_freason.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgCol_freason.HeaderText = "Reason";
            this.dgCol_freason.MinimumWidth = 150;
            this.dgCol_freason.Name = "dgCol_freason";
            this.dgCol_freason.ReadOnly = true;
            this.dgCol_freason.Width = 250;
            // 
            // dgCol_fval
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgCol_fval.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgCol_fval.HeaderText = "VALUE";
            this.dgCol_fval.Name = "dgCol_fval";
            this.dgCol_fval.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.btn_fclose);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 425);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(998, 42);
            this.panel2.TabIndex = 21;
            // 
            // btn_fclose
            // 
            this.btn_fclose.BackColor = System.Drawing.Color.Transparent;
            this.btn_fclose.BaseColor = System.Drawing.Color.Ivory;
            this.btn_fclose.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btn_fclose.ButtonText = "Close";
            this.btn_fclose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fclose.ForeColor = System.Drawing.Color.Black;
            this.btn_fclose.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_fclose.Location = new System.Drawing.Point(877, 6);
            this.btn_fclose.Name = "btn_fclose";
            this.btn_fclose.Size = new System.Drawing.Size(87, 26);
            this.btn_fclose.TabIndex = 17;
            this.btn_fclose.Click += new System.EventHandler(this.btn_fclose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblfid);
            this.panel1.Controls.Add(this.txt_freason);
            this.panel1.Controls.Add(this.txt_fval);
            this.panel1.Controls.Add(this.txt_fcode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnfClear);
            this.panel1.Controls.Add(this.btn_fdel);
            this.panel1.Controls.Add(this.btn_fsave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 119);
            this.panel1.TabIndex = 20;
            // 
            // lblfid
            // 
            this.lblfid.AutoSize = true;
            this.lblfid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblfid.Location = new System.Drawing.Point(448, 25);
            this.lblfid.Name = "lblfid";
            this.lblfid.Size = new System.Drawing.Size(2, 17);
            this.lblfid.TabIndex = 22;
            this.lblfid.Visible = false;
            // 
            // txt_freason
            // 
            this.txt_freason.Location = new System.Drawing.Point(77, 48);
            this.txt_freason.Multiline = true;
            this.txt_freason.Name = "txt_freason";
            this.txt_freason.Size = new System.Drawing.Size(332, 58);
            this.txt_freason.TabIndex = 21;
            // 
            // txt_fval
            // 
            this.txt_fval.Location = new System.Drawing.Point(274, 13);
            this.txt_fval.Name = "txt_fval";
            this.txt_fval.Size = new System.Drawing.Size(135, 22);
            this.txt_fval.TabIndex = 21;
            this.txt_fval.Text = "0";
            this.txt_fval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_fcode
            // 
            this.txt_fcode.Location = new System.Drawing.Point(77, 13);
            this.txt_fcode.Name = "txt_fcode";
            this.txt_fcode.Size = new System.Drawing.Size(135, 22);
            this.txt_fcode.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Reason";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Fine Code";
            // 
            // btnfClear
            // 
            this.btnfClear.BackColor = System.Drawing.Color.Transparent;
            this.btnfClear.BaseColor = System.Drawing.Color.Ivory;
            this.btnfClear.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnfClear.ButtonText = "Clear";
            this.btnfClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfClear.ForeColor = System.Drawing.Color.Black;
            this.btnfClear.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnfClear.Location = new System.Drawing.Point(489, 80);
            this.btnfClear.Name = "btnfClear";
            this.btnfClear.Size = new System.Drawing.Size(68, 26);
            this.btnfClear.TabIndex = 18;
            this.btnfClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btn_fdel
            // 
            this.btn_fdel.BackColor = System.Drawing.Color.Transparent;
            this.btn_fdel.BaseColor = System.Drawing.Color.Ivory;
            this.btn_fdel.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btn_fdel.ButtonText = "Delete";
            this.btn_fdel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fdel.ForeColor = System.Drawing.Color.Black;
            this.btn_fdel.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_fdel.Location = new System.Drawing.Point(415, 80);
            this.btn_fdel.Name = "btn_fdel";
            this.btn_fdel.Size = new System.Drawing.Size(68, 26);
            this.btn_fdel.TabIndex = 18;
            this.btn_fdel.Click += new System.EventHandler(this.btn_fdel_Click);
            // 
            // btn_fsave
            // 
            this.btn_fsave.BackColor = System.Drawing.Color.Transparent;
            this.btn_fsave.BaseColor = System.Drawing.Color.Ivory;
            this.btn_fsave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btn_fsave.ButtonText = "Save";
            this.btn_fsave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fsave.ForeColor = System.Drawing.Color.Black;
            this.btn_fsave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_fsave.Location = new System.Drawing.Point(563, 80);
            this.btn_fsave.Name = "btn_fsave";
            this.btn_fsave.Size = new System.Drawing.Size(80, 26);
            this.btn_fsave.TabIndex = 19;
            this.btn_fsave.Click += new System.EventHandler(this.btn_fsave_Click);
            // 
            // frm_Mst_Kit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 501);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Mst_Kit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KIT & FINE Log";
            this.Load += new System.EventHandler(this.frm_Mst_Kit_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kit)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fine)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton BTNdELETE;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv_Kit;
        private System.Windows.Forms.Panel panel1;
        private EDPComponent.VistaButton btn_fsave;
        private EDPComponent.VistaButton btn_fdel;
        private EDPComponent.VistaButton btn_fclose;
        private System.Windows.Forms.DataGridView dgv_fine;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_freason;
        private System.Windows.Forms.TextBox txt_fval;
        private System.Windows.Forms.TextBox txt_fcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_freason;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCol_fval;
        private System.Windows.Forms.Label lblfid;
        private EDPComponent.VistaButton btnfClear;
        private EDPComponent.VistaButton btnClStock;
        private EDPComponent.VistaButton btnPurchase;
        private EDPComponent.VistaButton btnIssue;
        private EDPComponent.VistaButton btnPurReturn;
        private EDPComponent.VistaButton btnIssueReturn;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private EDPComponent.VistaButton btnDamage;
        private System.Windows.Forms.DataGridViewTextBoxColumn KTNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn KTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn KTVAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpeningStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpeningValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn msUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn roQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn roUnit;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblCompany;
    }
}