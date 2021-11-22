namespace PayRollManagementSystem
{
    partial class Config_PFandESI
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
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnNew = new EDPComponent.VistaButton();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnDel = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPfrate = new TextBoxX.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCompAC22 = new TextBoxX.TextBoxX();
            this.txtCompAC21 = new TextBoxX.TextBoxX();
            this.txtCompAC02 = new TextBoxX.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCmpCut = new TextBoxX.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEPFComp = new TextBoxX.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCompPS = new TextBoxX.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEPF = new TextBoxX.TextBoxX();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtESICut = new TextBoxX.TextBoxX();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEMPerESI = new TextBoxX.TextBoxX();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEMPESI = new TextBoxX.TextBoxX();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
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
            this.cmbMonth.Location = new System.Drawing.Point(289, 34);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(93, 21);
            this.cmbMonth.TabIndex = 1;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(199, 39);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "For The Month of";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(62, 35);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(131, 21);
            this.cmbYear.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(10, 38);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 4;
            this.label22.Text = "Session";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.ButtonText = "New";
            this.btnNew.Location = new System.Drawing.Point(8, 267);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 32);
            this.btnNew.TabIndex = 42;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Location = new System.Drawing.Point(133, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 32);
            this.btnSave.TabIndex = 43;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.ButtonText = "Delete";
            this.btnDel.Location = new System.Drawing.Point(258, 267);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(112, 32);
            this.btnDel.TabIndex = 44;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Location = new System.Drawing.Point(384, 267);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 32);
            this.btnClose.TabIndex = 45;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            this.dgv.Location = new System.Drawing.Point(12, 305);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(487, 176);
            this.dgv.TabIndex = 46;
            this.dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RowEnter);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Month";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Session";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "EPF (A) (%)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Pension Fund(B)";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "EPF (A-B)";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "PF Cut Off";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "A/C No. 02";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "A/C No. 21";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "A/C No. 22";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Employee ESI (%)";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Employer ESI (%)";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "ESI Cut Off";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "slno";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "PF Rate Of Interest";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 150;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 62);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(487, 194);
            this.tabControl1.TabIndex = 47;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(479, 168);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Provident Fund";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(461, 168);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ESI Rate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPfrate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCompAC22);
            this.groupBox1.Controls.Add(this.txtCompAC21);
            this.groupBox1.Controls.Add(this.txtCompAC02);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCmpCut);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEPFComp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCompPS);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEPF);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 155);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Provident Fund";
            // 
            // txtPfrate
            // 
            this.txtPfrate.FocussedColor = System.Drawing.Color.Silver;
            this.txtPfrate.Location = new System.Drawing.Point(116, 115);
            this.txtPfrate.Name = "txtPfrate";
            this.txtPfrate.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtPfrate.Size = new System.Drawing.Size(78, 21);
            this.txtPfrate.TabIndex = 15;
            this.txtPfrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "PF Rate of Interest";
            // 
            // txtCompAC22
            // 
            this.txtCompAC22.FocussedColor = System.Drawing.Color.Silver;
            this.txtCompAC22.Location = new System.Drawing.Point(322, 90);
            this.txtCompAC22.Name = "txtCompAC22";
            this.txtCompAC22.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtCompAC22.Size = new System.Drawing.Size(114, 21);
            this.txtCompAC22.TabIndex = 6;
            this.txtCompAC22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCompAC21
            // 
            this.txtCompAC21.FocussedColor = System.Drawing.Color.Silver;
            this.txtCompAC21.Location = new System.Drawing.Point(322, 67);
            this.txtCompAC21.Name = "txtCompAC21";
            this.txtCompAC21.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtCompAC21.Size = new System.Drawing.Size(114, 21);
            this.txtCompAC21.TabIndex = 5;
            this.txtCompAC21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCompAC02
            // 
            this.txtCompAC02.FocussedColor = System.Drawing.Color.Silver;
            this.txtCompAC02.Location = new System.Drawing.Point(323, 43);
            this.txtCompAC02.Name = "txtCompAC02";
            this.txtCompAC02.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtCompAC02.Size = new System.Drawing.Size(114, 21);
            this.txtCompAC02.TabIndex = 4;
            this.txtCompAC02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(217, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "A/C No. 22 - (%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(217, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "A/C No. 21 - (%)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(218, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "A/C No. 02 - (%)";
            // 
            // txtCmpCut
            // 
            this.txtCmpCut.FocussedColor = System.Drawing.Color.Silver;
            this.txtCmpCut.Location = new System.Drawing.Point(323, 19);
            this.txtCmpCut.Name = "txtCmpCut";
            this.txtCmpCut.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtCmpCut.Size = new System.Drawing.Size(114, 21);
            this.txtCmpCut.TabIndex = 3;
            this.txtCmpCut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(218, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cut Off";
            // 
            // txtEPFComp
            // 
            this.txtEPFComp.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEPFComp.FocussedColor = System.Drawing.Color.Silver;
            this.txtEPFComp.Location = new System.Drawing.Point(116, 91);
            this.txtEPFComp.Name = "txtEPFComp";
            this.txtEPFComp.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtEPFComp.Size = new System.Drawing.Size(78, 21);
            this.txtEPFComp.TabIndex = 2;
            this.txtEPFComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "EPF(A-B) - (%)";
            // 
            // txtCompPS
            // 
            this.txtCompPS.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCompPS.FocussedColor = System.Drawing.Color.Silver;
            this.txtCompPS.Location = new System.Drawing.Point(116, 65);
            this.txtCompPS.Name = "txtCompPS";
            this.txtCompPS.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtCompPS.Size = new System.Drawing.Size(78, 21);
            this.txtCompPS.TabIndex = 1;
            this.txtCompPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pension Fund(B)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Employer\'s Share(%)";
            // 
            // txtEPF
            // 
            this.txtEPF.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEPF.FocussedColor = System.Drawing.Color.Silver;
            this.txtEPF.Location = new System.Drawing.Point(116, 20);
            this.txtEPF.Name = "txtEPF";
            this.txtEPF.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtEPF.Size = new System.Drawing.Size(78, 21);
            this.txtEPF.TabIndex = 0;
            this.txtEPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "EPF(A) - (%)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtESICut);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtEMPerESI);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtEMPESI);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(7, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 148);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee State Insurance";
            // 
            // txtESICut
            // 
            this.txtESICut.FocussedColor = System.Drawing.Color.Silver;
            this.txtESICut.Location = new System.Drawing.Point(217, 94);
            this.txtESICut.Name = "txtESICut";
            this.txtESICut.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtESICut.Size = new System.Drawing.Size(110, 21);
            this.txtESICut.TabIndex = 2;
            this.txtESICut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(114, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 5;
            this.label13.Text = "Cut Off";
            // 
            // txtEMPerESI
            // 
            this.txtEMPerESI.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEMPerESI.FocussedColor = System.Drawing.Color.Silver;
            this.txtEMPerESI.Location = new System.Drawing.Point(219, 67);
            this.txtEMPerESI.Name = "txtEMPerESI";
            this.txtEMPerESI.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtEMPerESI.Size = new System.Drawing.Size(107, 21);
            this.txtEMPerESI.TabIndex = 1;
            this.txtEMPerESI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(114, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Employer (%)";
            // 
            // txtEMPESI
            // 
            this.txtEMPESI.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEMPESI.FocussedColor = System.Drawing.Color.Silver;
            this.txtEMPESI.Location = new System.Drawing.Point(219, 41);
            this.txtEMPESI.Name = "txtEMPESI";
            this.txtEMPESI.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtEMPESI.Size = new System.Drawing.Size(107, 21);
            this.txtEMPESI.TabIndex = 0;
            this.txtEMPESI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(114, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "Employee (%)";
            // 
            // Config_PFandESI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 493);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "PF/ESI Rate Editor";
            this.Name = "Config_PFandESI";
            this.Load += new System.EventHandler(this.Config_PFandESI_Load);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.cmbMonth, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMonth;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private EDPComponent.VistaButton btnNew;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnDel;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private TextBoxX.TextBoxX txtPfrate;
        private System.Windows.Forms.Label label9;
        private TextBoxX.TextBoxX txtCompAC22;
        private TextBoxX.TextBoxX txtCompAC21;
        private TextBoxX.TextBoxX txtCompAC02;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private TextBoxX.TextBoxX txtCmpCut;
        private System.Windows.Forms.Label label5;
        private TextBoxX.TextBoxX txtEPFComp;
        private System.Windows.Forms.Label label4;
        private TextBoxX.TextBoxX txtCompPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private TextBoxX.TextBoxX txtEPF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private TextBoxX.TextBoxX txtESICut;
        private System.Windows.Forms.Label label13;
        private TextBoxX.TextBoxX txtEMPerESI;
        private System.Windows.Forms.Label label14;
        private TextBoxX.TextBoxX txtEMPESI;
        private System.Windows.Forms.Label label16;
    }
}