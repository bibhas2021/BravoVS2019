namespace PayRollManagementSystem
{
    partial class frmOrderDetails_AD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderDetails_AD));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvOther = new System.Windows.Forms.DataGridView();
            this.lblContractID = new System.Windows.Forms.Label();
            this.lblContractNo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCoid = new System.Windows.Forms.Label();
            this.lbllocid = new System.Windows.Forms.Label();
            this.lblClid = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEpf = new System.Windows.Forms.TabPage();
            this.lblSAC = new System.Windows.Forms.Label();
            this.lblFID = new System.Windows.Forms.Label();
            this.cmbSAC = new EDPComponent.ComboDialog();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFixedNote = new System.Windows.Forms.TextBox();
            this.cmbItems = new EDPComponent.ComboDialog();
            this.numPosition = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.grpFormula = new System.Windows.Forms.GroupBox();
            this.rbSalaryHead = new System.Windows.Forms.RadioButton();
            this.rbOrderHead = new System.Windows.Forms.RadioButton();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lstSalaryHead = new System.Windows.Forms.ListBox();
            this.lstOperators = new System.Windows.Forms.ListBox();
            this.grpFixed = new System.Windows.Forms.GroupBox();
            this.txtFixed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbctype = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblctype = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.vistaButton3 = new EDPComponent.VistaButton();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClr = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lblPos = new System.Windows.Forms.Label();
            this.txtfull_name = new System.Windows.Forms.TextBox();
            this.lblfull_name = new System.Windows.Forms.Label();
            this.btnsals = new EDPComponent.VistaButton();
            this.cmbsalstruc = new System.Windows.Forms.ComboBox();
            this.lblsalstruc = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.vistaButton2 = new EDPComponent.VistaButton();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOther)).BeginInit();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabEpf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).BeginInit();
            this.grpFormula.SuspendLayout();
            this.grpFixed.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvOther);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 274);
            this.panel1.TabIndex = 1;
            // 
            // dgvOther
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOther.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOther.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOther.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOther.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOther.Location = new System.Drawing.Point(0, 0);
            this.dgvOther.Name = "dgvOther";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOther.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOther.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOther.Size = new System.Drawing.Size(919, 274);
            this.dgvOther.TabIndex = 0;
            this.dgvOther.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOther_CellClick);
            this.dgvOther.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOther_CellContentClick);
            // 
            // lblContractID
            // 
            this.lblContractID.AutoSize = true;
            this.lblContractID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContractID.Location = new System.Drawing.Point(248, 9);
            this.lblContractID.Name = "lblContractID";
            this.lblContractID.Size = new System.Drawing.Size(2, 15);
            this.lblContractID.TabIndex = 26;
            // 
            // lblContractNo
            // 
            this.lblContractNo.AutoSize = true;
            this.lblContractNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContractNo.Location = new System.Drawing.Point(60, 9);
            this.lblContractNo.Name = "lblContractNo";
            this.lblContractNo.Size = new System.Drawing.Size(2, 15);
            this.lblContractNo.TabIndex = 25;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(682, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblCoid);
            this.panel2.Controls.Add(this.lbllocid);
            this.panel2.Controls.Add(this.lblClid);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblLocation);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblClient);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(919, 61);
            this.panel2.TabIndex = 2;
            // 
            // lblCoid
            // 
            this.lblCoid.AutoSize = true;
            this.lblCoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoid.Location = new System.Drawing.Point(880, 21);
            this.lblCoid.Name = "lblCoid";
            this.lblCoid.Size = new System.Drawing.Size(2, 15);
            this.lblCoid.TabIndex = 3;
            this.lblCoid.Visible = false;
            // 
            // lbllocid
            // 
            this.lbllocid.AutoSize = true;
            this.lbllocid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbllocid.Location = new System.Drawing.Point(831, 37);
            this.lbllocid.Name = "lbllocid";
            this.lbllocid.Size = new System.Drawing.Size(2, 15);
            this.lbllocid.TabIndex = 3;
            this.lbllocid.Visible = false;
            // 
            // lblClid
            // 
            this.lblClid.AutoSize = true;
            this.lblClid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClid.Location = new System.Drawing.Point(831, 8);
            this.lblClid.Name = "lblClid";
            this.lblClid.Size = new System.Drawing.Size(2, 15);
            this.lblClid.TabIndex = 2;
            this.lblClid.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Location";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocation.Location = new System.Drawing.Point(64, 37);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(2, 15);
            this.lblLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClient.Location = new System.Drawing.Point(64, 8);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(2, 15);
            this.lblClient.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 61);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClr);
            this.splitContainer1.Panel2.Controls.Add(this.btnDel);
            this.splitContainer1.Panel2.Controls.Add(this.lblPos);
            this.splitContainer1.Panel2.Controls.Add(this.lblContractID);
            this.splitContainer1.Panel2.Controls.Add(this.lblContractNo);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(919, 354);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabEpf);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(919, 325);
            this.tabControl1.TabIndex = 0;
            // 
            // tabEpf
            // 
            this.tabEpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEpf.Controls.Add(this.lblSAC);
            this.tabEpf.Controls.Add(this.lblFID);
            this.tabEpf.Controls.Add(this.cmbSAC);
            this.tabEpf.Controls.Add(this.label16);
            this.tabEpf.Controls.Add(this.txtFixedNote);
            this.tabEpf.Controls.Add(this.cmbItems);
            this.tabEpf.Controls.Add(this.numPosition);
            this.tabEpf.Controls.Add(this.label10);
            this.tabEpf.Controls.Add(this.grpFormula);
            this.tabEpf.Controls.Add(this.grpFixed);
            this.tabEpf.Controls.Add(this.cmbctype);
            this.tabEpf.Controls.Add(this.label14);
            this.tabEpf.Controls.Add(this.lblctype);
            this.tabEpf.Controls.Add(this.txtFullName);
            this.tabEpf.Controls.Add(this.label7);
            this.tabEpf.Controls.Add(this.vistaButton3);
            this.tabEpf.Controls.Add(this.label8);
            this.tabEpf.Location = new System.Drawing.Point(4, 22);
            this.tabEpf.Name = "tabEpf";
            this.tabEpf.Padding = new System.Windows.Forms.Padding(3);
            this.tabEpf.Size = new System.Drawing.Size(911, 299);
            this.tabEpf.TabIndex = 2;
            this.tabEpf.Text = "Additional Details";
            this.tabEpf.UseVisualStyleBackColor = true;
            // 
            // lblSAC
            // 
            this.lblSAC.AutoSize = true;
            this.lblSAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSAC.Location = new System.Drawing.Point(21, 269);
            this.lblSAC.Name = "lblSAC";
            this.lblSAC.Size = new System.Drawing.Size(2, 15);
            this.lblSAC.TabIndex = 285;
            this.lblSAC.Visible = false;
            // 
            // lblFID
            // 
            this.lblFID.AutoSize = true;
            this.lblFID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFID.Location = new System.Drawing.Point(21, 239);
            this.lblFID.Name = "lblFID";
            this.lblFID.Size = new System.Drawing.Size(2, 15);
            this.lblFID.TabIndex = 4;
            this.lblFID.Visible = false;
            // 
            // cmbSAC
            // 
            this.cmbSAC.Connection = null;
            this.cmbSAC.DialogResult = "";
            this.cmbSAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSAC.Location = new System.Drawing.Point(184, 144);
            this.cmbSAC.LOVFlag = 0;
            this.cmbSAC.MaxCharLength = 500;
            this.cmbSAC.Name = "cmbSAC";
            this.cmbSAC.ReturnIndex = -1;
            this.cmbSAC.ReturnValue = "";
            this.cmbSAC.ReturnValue_3rd = "";
            this.cmbSAC.ReturnValue_4th = "";
            this.cmbSAC.Size = new System.Drawing.Size(262, 21);
            this.cmbSAC.TabIndex = 284;
            this.cmbSAC.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmdSAC_DropDown);
            this.cmbSAC.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbSAC_CloseUp);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 144);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 283;
            this.label16.Text = "SAC No.";
            // 
            // txtFixedNote
            // 
            this.txtFixedNote.Location = new System.Drawing.Point(184, 100);
            this.txtFixedNote.Multiline = true;
            this.txtFixedNote.Name = "txtFixedNote";
            this.txtFixedNote.Size = new System.Drawing.Size(262, 38);
            this.txtFixedNote.TabIndex = 0;
            // 
            // cmbItems
            // 
            this.cmbItems.Connection = null;
            this.cmbItems.DialogResult = "";
            this.cmbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItems.Location = new System.Drawing.Point(184, 14);
            this.cmbItems.LOVFlag = 0;
            this.cmbItems.MaxCharLength = 500;
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.ReturnIndex = -1;
            this.cmbItems.ReturnValue = "";
            this.cmbItems.ReturnValue_3rd = "";
            this.cmbItems.ReturnValue_4th = "";
            this.cmbItems.Size = new System.Drawing.Size(225, 21);
            this.cmbItems.TabIndex = 282;
            this.cmbItems.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbItems_DropDown);
            this.cmbItems.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbItems_CloseUp);
            // 
            // numPosition
            // 
            this.numPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPosition.Location = new System.Drawing.Point(185, 194);
            this.numPosition.Margin = new System.Windows.Forms.Padding(4);
            this.numPosition.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numPosition.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPosition.Name = "numPosition";
            this.numPosition.Size = new System.Drawing.Size(261, 20);
            this.numPosition.TabIndex = 281;
            this.numPosition.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numPosition.Visible = false;
            this.numPosition.ValueChanged += new System.EventHandler(this.numPosition_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 278;
            this.label10.Text = "Note";
            // 
            // grpFormula
            // 
            this.grpFormula.Controls.Add(this.rbSalaryHead);
            this.grpFormula.Controls.Add(this.rbOrderHead);
            this.grpFormula.Controls.Add(this.label17);
            this.grpFormula.Controls.Add(this.label15);
            this.grpFormula.Controls.Add(this.txtPer);
            this.grpFormula.Controls.Add(this.label11);
            this.grpFormula.Controls.Add(this.txtFormula);
            this.grpFormula.Controls.Add(this.label12);
            this.grpFormula.Controls.Add(this.label13);
            this.grpFormula.Controls.Add(this.lstSalaryHead);
            this.grpFormula.Controls.Add(this.lstOperators);
            this.grpFormula.Location = new System.Drawing.Point(468, 6);
            this.grpFormula.Name = "grpFormula";
            this.grpFormula.Size = new System.Drawing.Size(434, 208);
            this.grpFormula.TabIndex = 280;
            this.grpFormula.TabStop = false;
            this.grpFormula.Text = "Formula";
            this.grpFormula.Visible = false;
            // 
            // rbSalaryHead
            // 
            this.rbSalaryHead.AutoSize = true;
            this.rbSalaryHead.Location = new System.Drawing.Point(147, 65);
            this.rbSalaryHead.Name = "rbSalaryHead";
            this.rbSalaryHead.Size = new System.Drawing.Size(83, 17);
            this.rbSalaryHead.TabIndex = 270;
            this.rbSalaryHead.TabStop = true;
            this.rbSalaryHead.Text = "Salary Head";
            this.rbSalaryHead.UseVisualStyleBackColor = true;
            this.rbSalaryHead.CheckedChanged += new System.EventHandler(this.rbSalaryHead_CheckedChanged);
            // 
            // rbOrderHead
            // 
            this.rbOrderHead.AutoSize = true;
            this.rbOrderHead.Location = new System.Drawing.Point(65, 63);
            this.rbOrderHead.Name = "rbOrderHead";
            this.rbOrderHead.Size = new System.Drawing.Size(80, 17);
            this.rbOrderHead.TabIndex = 269;
            this.rbOrderHead.TabStop = true;
            this.rbOrderHead.Text = "Order Head";
            this.rbOrderHead.UseVisualStyleBackColor = true;
            this.rbOrderHead.CheckedChanged += new System.EventHandler(this.rbOrderHead_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 13);
            this.label17.TabIndex = 268;
            this.label17.Text = "Tagging";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(287, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 267;
            this.label15.Text = "Percentage";
            this.label15.Visible = false;
            // 
            // txtPer
            // 
            this.txtPer.Location = new System.Drawing.Point(276, 117);
            this.txtPer.Name = "txtPer";
            this.txtPer.Size = new System.Drawing.Size(86, 20);
            this.txtPer.TabIndex = 0;
            this.txtPer.Text = "0";
            this.txtPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPer.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 267;
            this.label11.Text = "Calculate on";
            // 
            // txtFormula
            // 
            this.txtFormula.Location = new System.Drawing.Point(93, 14);
            this.txtFormula.Multiline = true;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(335, 35);
            this.txtFormula.TabIndex = 262;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(365, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 266;
            this.label12.Text = "Operators";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 265;
            this.label13.Text = "Heads";
            // 
            // lstSalaryHead
            // 
            this.lstSalaryHead.FormattingEnabled = true;
            this.lstSalaryHead.Location = new System.Drawing.Point(93, 94);
            this.lstSalaryHead.Name = "lstSalaryHead";
            this.lstSalaryHead.Size = new System.Drawing.Size(134, 108);
            this.lstSalaryHead.TabIndex = 263;
            this.lstSalaryHead.SelectedIndexChanged += new System.EventHandler(this.lstSalaryHead_SelectedIndexChanged);
            // 
            // lstOperators
            // 
            this.lstOperators.AllowDrop = true;
            this.lstOperators.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lstOperators.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOperators.FormattingEnabled = true;
            this.lstOperators.ItemHeight = 16;
            this.lstOperators.Location = new System.Drawing.Point(368, 72);
            this.lstOperators.Name = "lstOperators";
            this.lstOperators.Size = new System.Drawing.Size(59, 116);
            this.lstOperators.TabIndex = 264;
            this.lstOperators.Visible = false;
            // 
            // grpFixed
            // 
            this.grpFixed.Controls.Add(this.txtFixed);
            this.grpFixed.Controls.Add(this.label9);
            this.grpFixed.Location = new System.Drawing.Point(469, 220);
            this.grpFixed.Name = "grpFixed";
            this.grpFixed.Size = new System.Drawing.Size(434, 64);
            this.grpFixed.TabIndex = 280;
            this.grpFixed.TabStop = false;
            this.grpFixed.Text = "Fixed Amount";
            this.grpFixed.Visible = false;
            // 
            // txtFixed
            // 
            this.txtFixed.Location = new System.Drawing.Point(172, 19);
            this.txtFixed.Name = "txtFixed";
            this.txtFixed.Size = new System.Drawing.Size(255, 20);
            this.txtFixed.TabIndex = 0;
            this.txtFixed.Text = "0";
            this.txtFixed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 278;
            this.label9.Text = "Amount";
            // 
            // cmbctype
            // 
            this.cmbctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbctype.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbctype.Items.AddRange(new object[] {
            "FORMULA",
            "FIXED"});
            this.cmbctype.Location = new System.Drawing.Point(185, 68);
            this.cmbctype.Name = "cmbctype";
            this.cmbctype.Size = new System.Drawing.Size(261, 21);
            this.cmbctype.TabIndex = 279;
            this.cmbctype.SelectedIndexChanged += new System.EventHandler(this.cmbctype_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 196);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 278;
            this.label14.Text = "Position";
            this.label14.Visible = false;
            // 
            // lblctype
            // 
            this.lblctype.AutoSize = true;
            this.lblctype.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblctype.Location = new System.Drawing.Point(9, 71);
            this.lblctype.Name = "lblctype";
            this.lblctype.Size = new System.Drawing.Size(101, 13);
            this.lblctype.TabIndex = 278;
            this.lblctype.Text = "Calculation Basis";
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFullName.Enabled = false;
            this.txtFullName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(185, 41);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(261, 21);
            this.txtFullName.TabIndex = 277;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 276;
            this.label7.Text = "Full Name";
            // 
            // vistaButton3
            // 
            this.vistaButton3.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton3.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton3.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton3.ButtonText = "--";
            this.vistaButton3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton3.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton3.Location = new System.Drawing.Point(420, 13);
            this.vistaButton3.Name = "vistaButton3";
            this.vistaButton3.Size = new System.Drawing.Size(26, 22);
            this.vistaButton3.TabIndex = 274;
            this.vistaButton3.Click += new System.EventHandler(this.vistaButton3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 272;
            this.label8.Text = "Additional Item Head";
            // 
            // btnClr
            // 
            this.btnClr.BackColor = System.Drawing.Color.Black;
            this.btnClr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClr.ForeColor = System.Drawing.Color.White;
            this.btnClr.Location = new System.Drawing.Point(844, 0);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(75, 24);
            this.btnClr.TabIndex = 28;
            this.btnClr.Text = "Clear";
            this.btnClr.UseVisualStyleBackColor = false;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Black;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(763, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 24);
            this.btnDel.TabIndex = 27;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPos.Location = new System.Drawing.Point(277, 9);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(2, 15);
            this.lblPos.TabIndex = 26;
            // 
            // txtfull_name
            // 
            this.txtfull_name.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtfull_name.Enabled = false;
            this.txtfull_name.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfull_name.Location = new System.Drawing.Point(185, 41);
            this.txtfull_name.Name = "txtfull_name";
            this.txtfull_name.ReadOnly = true;
            this.txtfull_name.Size = new System.Drawing.Size(261, 21);
            this.txtfull_name.TabIndex = 277;
            // 
            // lblfull_name
            // 
            this.lblfull_name.AutoSize = true;
            this.lblfull_name.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfull_name.Location = new System.Drawing.Point(9, 41);
            this.lblfull_name.Name = "lblfull_name";
            this.lblfull_name.Size = new System.Drawing.Size(61, 13);
            this.lblfull_name.TabIndex = 276;
            this.lblfull_name.Text = "Full Name";
            // 
            // btnsals
            // 
            this.btnsals.BackColor = System.Drawing.Color.Transparent;
            this.btnsals.BaseColor = System.Drawing.Color.SlateGray;
            this.btnsals.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnsals.ButtonText = "--";
            this.btnsals.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsals.GlowColor = System.Drawing.Color.Aqua;
            this.btnsals.Location = new System.Drawing.Point(420, 13);
            this.btnsals.Name = "btnsals";
            this.btnsals.Size = new System.Drawing.Size(26, 22);
            this.btnsals.TabIndex = 274;
            // 
            // cmbsalstruc
            // 
            this.cmbsalstruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsalstruc.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbsalstruc.FormattingEnabled = true;
            this.cmbsalstruc.Location = new System.Drawing.Point(185, 14);
            this.cmbsalstruc.Name = "cmbsalstruc";
            this.cmbsalstruc.Size = new System.Drawing.Size(229, 21);
            this.cmbsalstruc.TabIndex = 273;
            // 
            // lblsalstruc
            // 
            this.lblsalstruc.AutoSize = true;
            this.lblsalstruc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsalstruc.Location = new System.Drawing.Point(9, 17);
            this.lblsalstruc.Name = "lblsalstruc";
            this.lblsalstruc.Size = new System.Drawing.Size(127, 13);
            this.lblsalstruc.TabIndex = 272;
            this.lblsalstruc.Text = "Additional Item Head";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(185, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(261, 21);
            this.textBox1.TabIndex = 277;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 276;
            this.label2.Text = "Full Name";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton1.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton1.ButtonText = "--";
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton1.Location = new System.Drawing.Point(420, 13);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(26, 22);
            this.vistaButton1.TabIndex = 274;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(185, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 21);
            this.comboBox1.TabIndex = 273;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 272;
            this.label4.Text = "Additional Item Head";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(185, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(261, 21);
            this.textBox2.TabIndex = 277;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 276;
            this.label5.Text = "Full Name";
            // 
            // vistaButton2
            // 
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton2.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton2.ButtonText = "--";
            this.vistaButton2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton2.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton2.Location = new System.Drawing.Point(420, 13);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(26, 22);
            this.vistaButton2.TabIndex = 274;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(185, 14);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(229, 21);
            this.comboBox2.TabIndex = 273;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 272;
            this.label6.Text = "Additional Item Head";
            // 
            // frmOrderDetails_AD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(919, 689);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrderDetails_AD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Additional Charge Details";
            this.Load += new System.EventHandler(this.frmOrderDetails_AD_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOther)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabEpf.ResumeLayout(false);
            this.tabEpf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPosition)).EndInit();
            this.grpFormula.ResumeLayout(false);
            this.grpFormula.PerformLayout();
            this.grpFixed.ResumeLayout(false);
            this.grpFixed.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Label lbllocid;
        public System.Windows.Forms.Label lblClid;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblClient;
        public System.Windows.Forms.Label lblCoid;
        public System.Windows.Forms.Label lblContractID;
        public System.Windows.Forms.Label lblContractNo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEpf;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label7;
        private EDPComponent.VistaButton vistaButton3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtfull_name;
        private System.Windows.Forms.Label lblfull_name;
        private EDPComponent.VistaButton btnsals;
        public System.Windows.Forms.ComboBox cmbsalstruc;
        private System.Windows.Forms.Label lblsalstruc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton vistaButton1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private EDPComponent.VistaButton vistaButton2;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cmbctype;
        private System.Windows.Forms.Label lblctype;
        private System.Windows.Forms.GroupBox grpFixed;
        private System.Windows.Forms.TextBox txtFixed;
        private System.Windows.Forms.GroupBox grpFormula;
        private System.Windows.Forms.TextBox txtFixedNote;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lstSalaryHead;
        private System.Windows.Forms.ListBox lstOperators;
        private System.Windows.Forms.NumericUpDown numPosition;
        private System.Windows.Forms.Label label14;
        private EDPComponent.ComboDialog cmbItems;
        private System.Windows.Forms.DataGridView dgvOther;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPer;
        public System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label label16;
        private EDPComponent.ComboDialog cmbSAC;
        private System.Windows.Forms.RadioButton rbOrderHead;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton rbSalaryHead;
        public System.Windows.Forms.Label lblSAC;
        public System.Windows.Forms.Label lblFID;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClr;

    }
}