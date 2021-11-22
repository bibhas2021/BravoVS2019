namespace PayRollManagementSystem
{
    partial class frmPartyLedger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartyLedger));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbYear_sal = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_sal_month = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.vistaButton2 = new EDPComponent.VistaButton();
            this.vistaButton3 = new EDPComponent.VistaButton();
            this.cmbSalhead = new EDPComponent.ComboDialog();
            this.cmbCompany_sal = new EDPComponent.ComboDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.vistaButton4 = new EDPComponent.VistaButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_sal = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkZero = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dtp_ALK_month = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.btnClose = new EDPComponent.VistaButton();
            this.btn_exp_alk = new EDPComponent.VistaButton();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.btnPreview = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkKit = new System.Windows.Forms.CheckBox();
            this.chkAdv = new System.Windows.Forms.CheckBox();
            this.chkLoan = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvALK = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sal)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvALK)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1021, 475);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1013, 449);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Salary head wise";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.vistaButton2);
            this.splitContainer2.Panel1.Controls.Add(this.vistaButton3);
            this.splitContainer2.Panel1.Controls.Add(this.cmbSalhead);
            this.splitContainer2.Panel1.Controls.Add(this.cmbCompany_sal);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.vistaButton4);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv_sal);
            this.splitContainer2.Size = new System.Drawing.Size(1005, 441);
            this.splitContainer2.SplitterDistance = 119;
            this.splitContainer2.TabIndex = 298;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbYear_sal);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtp_sal_month);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 55);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // cmbYear_sal
            // 
            this.cmbYear_sal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear_sal.FormattingEnabled = true;
            this.cmbYear_sal.Location = new System.Drawing.Point(63, 19);
            this.cmbYear_sal.Name = "cmbYear_sal";
            this.cmbYear_sal.Size = new System.Drawing.Size(126, 21);
            this.cmbYear_sal.TabIndex = 259;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 258;
            this.label1.Text = "Session";
            // 
            // dtp_sal_month
            // 
            this.dtp_sal_month.Checked = false;
            this.dtp_sal_month.CustomFormat = "MMMM - yyyy";
            this.dtp_sal_month.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_sal_month.Location = new System.Drawing.Point(333, 20);
            this.dtp_sal_month.Name = "dtp_sal_month";
            this.dtp_sal_month.Size = new System.Drawing.Size(133, 20);
            this.dtp_sal_month.TabIndex = 264;
            this.dtp_sal_month.ValueChanged += new System.EventHandler(this.dtp_sal_month_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 260;
            this.label2.Text = "Month";
            // 
            // vistaButton2
            // 
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton2.ButtonText = " Close";
            this.vistaButton2.CornerRadius = 4;
            this.vistaButton2.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton2.Location = new System.Drawing.Point(767, 74);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(80, 30);
            this.vistaButton2.TabIndex = 24;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // vistaButton3
            // 
            this.vistaButton3.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton3.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton3.ButtonText = "Export To Excel";
            this.vistaButton3.CornerRadius = 4;
            this.vistaButton3.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton3.Location = new System.Drawing.Point(555, 74);
            this.vistaButton3.Name = "vistaButton3";
            this.vistaButton3.Size = new System.Drawing.Size(120, 30);
            this.vistaButton3.TabIndex = 26;
            this.vistaButton3.Visible = false;
            this.vistaButton3.Click += new System.EventHandler(this.vistaButton3_Click);
            // 
            // cmbSalhead
            // 
            this.cmbSalhead.Connection = null;
            this.cmbSalhead.DialogResult = "";
            this.cmbSalhead.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalhead.Location = new System.Drawing.Point(622, 29);
            this.cmbSalhead.LOVFlag = 0;
            this.cmbSalhead.MaxCharLength = 500;
            this.cmbSalhead.Name = "cmbSalhead";
            this.cmbSalhead.ReturnIndex = -1;
            this.cmbSalhead.ReturnValue = "";
            this.cmbSalhead.ReturnValue_3rd = "";
            this.cmbSalhead.ReturnValue_4th = "";
            this.cmbSalhead.Size = new System.Drawing.Size(225, 21);
            this.cmbSalhead.TabIndex = 294;
            this.cmbSalhead.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbSalhead_DropDown);
            this.cmbSalhead.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbSalhead_CloseUp);
            // 
            // cmbCompany_sal
            // 
            this.cmbCompany_sal.Connection = null;
            this.cmbCompany_sal.DialogResult = "";
            this.cmbCompany_sal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany_sal.Location = new System.Drawing.Point(106, 74);
            this.cmbCompany_sal.LOVFlag = 0;
            this.cmbCompany_sal.MaxCharLength = 500;
            this.cmbCompany_sal.Name = "cmbCompany_sal";
            this.cmbCompany_sal.ReturnIndex = -1;
            this.cmbCompany_sal.ReturnValue = "";
            this.cmbCompany_sal.ReturnValue_3rd = "";
            this.cmbCompany_sal.ReturnValue_4th = "";
            this.cmbCompany_sal.Size = new System.Drawing.Size(366, 21);
            this.cmbCompany_sal.TabIndex = 294;
            this.cmbCompany_sal.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_sal_DropDown);
            this.cmbCompany_sal.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_sal_CloseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 295;
            this.label4.Text = "Select Any Salary Head";
            // 
            // vistaButton4
            // 
            this.vistaButton4.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton4.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton4.ButtonText = "  Preview";
            this.vistaButton4.CornerRadius = 4;
            this.vistaButton4.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton4.Location = new System.Drawing.Point(681, 74);
            this.vistaButton4.Name = "vistaButton4";
            this.vistaButton4.Size = new System.Drawing.Size(80, 30);
            this.vistaButton4.TabIndex = 25;
            this.vistaButton4.Click += new System.EventHandler(this.vistaButton4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 295;
            this.label3.Text = "Company Name";
            // 
            // dgv_sal
            // 
            this.dgv_sal.AllowUserToDeleteRows = false;
            this.dgv_sal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_sal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_sal.Location = new System.Drawing.Point(0, 0);
            this.dgv_sal.Name = "dgv_sal";
            this.dgv_sal.Size = new System.Drawing.Size(1005, 318);
            this.dgv_sal.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1013, 449);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advance / Loan / Kit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chkZero);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btn_exp_alk);
            this.splitContainer1.Panel1.Controls.Add(this.cmbcompany);
            this.splitContainer1.Panel1.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvALK);
            this.splitContainer1.Size = new System.Drawing.Size(1005, 441);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.TabIndex = 297;
            // 
            // chkZero
            // 
            this.chkZero.AutoSize = true;
            this.chkZero.Location = new System.Drawing.Point(702, 13);
            this.chkZero.Name = "chkZero";
            this.chkZero.Size = new System.Drawing.Size(72, 17);
            this.chkZero.TabIndex = 1;
            this.chkZero.Text = "Omit Zero";
            this.chkZero.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbYear);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.dtp_ALK_month);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Location = new System.Drawing.Point(6, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 55);
            this.groupBox4.TabIndex = 4;
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
            // dtp_ALK_month
            // 
            this.dtp_ALK_month.Checked = false;
            this.dtp_ALK_month.CustomFormat = "MMMM - yyyy";
            this.dtp_ALK_month.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ALK_month.Location = new System.Drawing.Point(333, 20);
            this.dtp_ALK_month.Name = "dtp_ALK_month";
            this.dtp_ALK_month.Size = new System.Drawing.Size(133, 20);
            this.dtp_ALK_month.TabIndex = 264;
            this.dtp_ALK_month.ValueChanged += new System.EventHandler(this.dtp_ALK_month_ValueChanged);
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
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(708, 74);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 24;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_exp_alk
            // 
            this.btn_exp_alk.BackColor = System.Drawing.Color.Transparent;
            this.btn_exp_alk.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btn_exp_alk.ButtonText = "Export To Excel";
            this.btn_exp_alk.CornerRadius = 4;
            this.btn_exp_alk.ImageSize = new System.Drawing.Size(16, 16);
            this.btn_exp_alk.Location = new System.Drawing.Point(496, 74);
            this.btn_exp_alk.Name = "btn_exp_alk";
            this.btn_exp_alk.Size = new System.Drawing.Size(120, 30);
            this.btn_exp_alk.TabIndex = 26;
            this.btn_exp_alk.Visible = false;
            this.btn_exp_alk.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(106, 74);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(366, 21);
            this.cmbcompany.TabIndex = 294;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(622, 74);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 25;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkKit);
            this.groupBox1.Controls.Add(this.chkAdv);
            this.groupBox1.Controls.Add(this.chkLoan);
            this.groupBox1.Location = new System.Drawing.Point(496, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 55);
            this.groupBox1.TabIndex = 296;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select options";
            // 
            // chkKit
            // 
            this.chkKit.AutoSize = true;
            this.chkKit.Checked = true;
            this.chkKit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKit.Location = new System.Drawing.Point(233, 28);
            this.chkKit.Name = "chkKit";
            this.chkKit.Size = new System.Drawing.Size(43, 17);
            this.chkKit.TabIndex = 0;
            this.chkKit.Text = "KIT";
            this.chkKit.UseVisualStyleBackColor = true;
            // 
            // chkAdv
            // 
            this.chkAdv.AutoSize = true;
            this.chkAdv.Checked = true;
            this.chkAdv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdv.Location = new System.Drawing.Point(151, 28);
            this.chkAdv.Name = "chkAdv";
            this.chkAdv.Size = new System.Drawing.Size(77, 17);
            this.chkAdv.TabIndex = 0;
            this.chkAdv.Text = "ADVANCE";
            this.chkAdv.UseVisualStyleBackColor = true;
            // 
            // chkLoan
            // 
            this.chkLoan.AutoSize = true;
            this.chkLoan.Checked = true;
            this.chkLoan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLoan.Location = new System.Drawing.Point(94, 29);
            this.chkLoan.Name = "chkLoan";
            this.chkLoan.Size = new System.Drawing.Size(55, 17);
            this.chkLoan.TabIndex = 0;
            this.chkLoan.Text = "LOAN";
            this.chkLoan.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 295;
            this.label6.Text = "Company Name";
            // 
            // dgvALK
            // 
            this.dgvALK.AllowUserToDeleteRows = false;
            this.dgvALK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvALK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvALK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvALK.Location = new System.Drawing.Point(0, 0);
            this.dgvALK.Name = "dgvALK";
            this.dgvALK.Size = new System.Drawing.Size(1005, 318);
            this.dgvALK.TabIndex = 0;
            // 
            // frmPartyLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1021, 475);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPartyLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Ledger";
            this.Load += new System.EventHandler(this.frmPartyLedger_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvALK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtp_ALK_month;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkKit;
        private System.Windows.Forms.CheckBox chkAdv;
        private System.Windows.Forms.CheckBox chkLoan;
        private EDPComponent.VistaButton btn_exp_alk;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvALK;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.ComboBox cmbYear_sal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_sal_month;
        internal System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton vistaButton2;
        private EDPComponent.VistaButton vistaButton3;
        private EDPComponent.ComboDialog cmbSalhead;
        private EDPComponent.ComboDialog cmbCompany_sal;
        private System.Windows.Forms.Label label4;
        private EDPComponent.VistaButton vistaButton4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_sal;
        private System.Windows.Forms.CheckBox chkZero;
    }
}