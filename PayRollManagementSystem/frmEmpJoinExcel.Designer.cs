namespace PayRollManagementSystem
{
    partial class frmEmpJoinExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpJoinExcel));
            this.txt_filepath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgView_Emp = new System.Windows.Forms.DataGridView();
            this.btn_Upload = new EDPComponent.VistaButton();
            this.btn_Proc = new EDPComponent.VistaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnProccess_Bank = new EDPComponent.VistaButton();
            this.pbEmployeeInsertion = new System.Windows.Forms.ProgressBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lstDesignation = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnReChk = new EDPComponent.VistaButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Create_file = new EDPComponent.VistaButton();
            this.btn_Create_File_data = new EDPComponent.VistaButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblLocation = new System.Windows.Forms.Label();
            this.txt_LstNo = new System.Windows.Forms.TextBox();
            this.lblLstNo = new System.Windows.Forms.Label();
            this.rdbManual = new System.Windows.Forms.RadioButton();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgView_Emp)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_filepath
            // 
            this.txt_filepath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_filepath.Location = new System.Drawing.Point(13, 27);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.Size = new System.Drawing.Size(228, 22);
            this.txt_filepath.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // dgView_Emp
            // 
            this.dgView_Emp.AllowUserToAddRows = false;
            this.dgView_Emp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgView_Emp.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgView_Emp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView_Emp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgView_Emp.GridColor = System.Drawing.Color.Black;
            this.dgView_Emp.Location = new System.Drawing.Point(14, 389);
            this.dgView_Emp.Name = "dgView_Emp";
            this.dgView_Emp.Size = new System.Drawing.Size(872, 196);
            this.dgView_Emp.TabIndex = 2;
            this.dgView_Emp.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgView_Emp_RowPrePaint);
            // 
            // btn_Upload
            // 
            this.btn_Upload.BackColor = System.Drawing.Color.Transparent;
            this.btn_Upload.BaseColor = System.Drawing.Color.Ivory;
            this.btn_Upload.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btn_Upload.ButtonText = "Fetch File";
            this.btn_Upload.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Upload.ForeColor = System.Drawing.Color.Black;
            this.btn_Upload.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_Upload.Location = new System.Drawing.Point(246, 24);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(84, 26);
            this.btn_Upload.TabIndex = 43;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // btn_Proc
            // 
            this.btn_Proc.BackColor = System.Drawing.Color.Transparent;
            this.btn_Proc.BaseColor = System.Drawing.Color.Ivory;
            this.btn_Proc.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btn_Proc.ButtonText = "Process";
            this.btn_Proc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Proc.ForeColor = System.Drawing.Color.Black;
            this.btn_Proc.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_Proc.Location = new System.Drawing.Point(809, 588);
            this.btn_Proc.Name = "btn_Proc";
            this.btn_Proc.Size = new System.Drawing.Size(82, 26);
            this.btn_Proc.TabIndex = 43;
            this.btn_Proc.Click += new System.EventHandler(this.btn_Proc_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnProccess_Bank);
            this.panel1.Controls.Add(this.btn_Proc);
            this.panel1.Controls.Add(this.pbEmployeeInsertion);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.dgView_Emp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 625);
            this.panel1.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(332, 598);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(293, 13);
            this.label7.TabIndex = 246;
            this.label7.Text = "Just a warning, Date of Joining / Birth invalid date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 598);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 13);
            this.label6.TabIndex = 245;
            this.label6.Text = "Rows wil not be accepted, Missing Location / Client ";
            // 
            // btnProccess_Bank
            // 
            this.btnProccess_Bank.BackColor = System.Drawing.Color.Transparent;
            this.btnProccess_Bank.BaseColor = System.Drawing.Color.Ivory;
            this.btnProccess_Bank.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnProccess_Bank.ButtonText = "Bank Process";
            this.btnProccess_Bank.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProccess_Bank.ForeColor = System.Drawing.Color.Black;
            this.btnProccess_Bank.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnProccess_Bank.Location = new System.Drawing.Point(701, 588);
            this.btnProccess_Bank.Name = "btnProccess_Bank";
            this.btnProccess_Bank.Size = new System.Drawing.Size(105, 26);
            this.btnProccess_Bank.TabIndex = 43;
            this.btnProccess_Bank.Click += new System.EventHandler(this.btnProccess_Bank_Click);
            // 
            // pbEmployeeInsertion
            // 
            this.pbEmployeeInsertion.Location = new System.Drawing.Point(14, 586);
            this.pbEmployeeInsertion.Name = "pbEmployeeInsertion";
            this.pbEmployeeInsertion.Size = new System.Drawing.Size(678, 10);
            this.pbEmployeeInsertion.TabIndex = 243;
            this.pbEmployeeInsertion.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lstDesignation);
            this.groupBox5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(631, 177);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 139);
            this.groupBox5.TabIndex = 242;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Use these Designation or ShortForm";
            // 
            // lstDesignation
            // 
            this.lstDesignation.BackColor = System.Drawing.Color.White;
            this.lstDesignation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDesignation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDesignation.FormattingEnabled = true;
            this.lstDesignation.ItemHeight = 14;
            this.lstDesignation.Location = new System.Drawing.Point(3, 16);
            this.lstDesignation.Name = "lstDesignation";
            this.lstDesignation.Size = new System.Drawing.Size(249, 112);
            this.lstDesignation.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnReChk);
            this.groupBox4.Controls.Add(this.btn_Upload);
            this.groupBox4.Controls.Add(this.txt_filepath);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(476, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(410, 61);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Import the file";
            // 
            // btnReChk
            // 
            this.btnReChk.BackColor = System.Drawing.Color.Transparent;
            this.btnReChk.BaseColor = System.Drawing.Color.Ivory;
            this.btnReChk.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnReChk.ButtonText = "Recheck";
            this.btnReChk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReChk.ForeColor = System.Drawing.Color.Black;
            this.btnReChk.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnReChk.Location = new System.Drawing.Point(333, 24);
            this.btnReChk.Name = "btnReChk";
            this.btnReChk.Size = new System.Drawing.Size(70, 26);
            this.btnReChk.TabIndex = 43;
            this.btnReChk.Click += new System.EventHandler(this.btnReChk_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Create_file);
            this.groupBox3.Controls.Add(this.btn_Create_File_data);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(14, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 58);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create an excel file :  (Save in 97-2003 format)";
            // 
            // btn_Create_file
            // 
            this.btn_Create_file.BackColor = System.Drawing.Color.Transparent;
            this.btn_Create_file.BaseColor = System.Drawing.Color.Ivory;
            this.btn_Create_file.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btn_Create_file.ButtonText = "Create File without data";
            this.btn_Create_file.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Create_file.ForeColor = System.Drawing.Color.Black;
            this.btn_Create_file.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_Create_file.Location = new System.Drawing.Point(223, 21);
            this.btn_Create_file.Name = "btn_Create_file";
            this.btn_Create_file.Size = new System.Drawing.Size(190, 26);
            this.btn_Create_file.TabIndex = 45;
            this.btn_Create_file.Click += new System.EventHandler(this.btn_Create_file_Click);
            // 
            // btn_Create_File_data
            // 
            this.btn_Create_File_data.BackColor = System.Drawing.Color.Transparent;
            this.btn_Create_File_data.BaseColor = System.Drawing.Color.Ivory;
            this.btn_Create_File_data.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btn_Create_File_data.ButtonText = "Create File with data";
            this.btn_Create_File_data.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Create_File_data.ForeColor = System.Drawing.Color.Black;
            this.btn_Create_File_data.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_Create_File_data.Location = new System.Drawing.Point(26, 21);
            this.btn_Create_File_data.Name = "btn_Create_File_data";
            this.btn_Create_File_data.Size = new System.Drawing.Size(190, 26);
            this.btn_Create_File_data.TabIndex = 44;
            this.btn_Create_File_data.Visible = false;
            this.btn_Create_File_data.Click += new System.EventHandler(this.btn_Create_File_data_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 139);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "We are expecting the column heads in excel be :    * compulsory required data";
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "EmployeeID*",
            "Name*",
            "Gender*",
            "DateOfJoining*",
            "Designation *",
            "DateOfBirth*",
            "JobType",
            "",
            "FatherName",
            "Father_Age",
            "MotherName",
            "Mother_Age",
            "Spouse",
            "Religion",
            "Cast",
            "MaritalStatus",
            "Mobile",
            "Padd_Road",
            "Padd_State",
            "Padd_City",
            "Padd_Country",
            "Padd_Pin",
            "Qualification",
            "Board_University",
            "YearOfPassing",
            "Percentage",
            "PF_No",
            "ESI_No",
            "Bank",
            "Branch",
            "AcNo",
            "IFSC",
            "AcType"});
            this.listBox1.Location = new System.Drawing.Point(3, 18);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(605, 112);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightBlue;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CmbCompany);
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.LblCompany);
            this.groupBox1.Controls.Add(this.LblLocation);
            this.groupBox1.Controls.Add(this.txt_LstNo);
            this.groupBox1.Controls.Add(this.lblLstNo);
            this.groupBox1.Controls.Add(this.rdbManual);
            this.groupBox1.Controls.Add(this.rdbAuto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 169);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(67, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(632, 14);
            this.label8.TabIndex = 245;
            this.label8.Text = "Select Company, Employee will be added under the selected company with Employee c" +
                "ode as per company setup";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(629, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 14);
            this.label5.TabIndex = 244;
            this.label5.Text = "Date format should be - dd/MM/yyyy\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 243;
            this.label4.Text = "Others";
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Items.AddRange(new object[] {
            "Bank Ac Type :    Savings / S",
            "\t           Current / C",
            "Marital Stauts :   Married / M",
            "\t           Unmarried / U"});
            this.listBox2.Location = new System.Drawing.Point(77, 90);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox2.Size = new System.Drawing.Size(368, 68);
            this.listBox2.TabIndex = 242;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(614, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 241;
            this.label22.Text = "Session";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(678, 18);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(171, 24);
            this.cmbYear.TabIndex = 94;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(348, 16);
            this.label3.TabIndex = 93;
            this.label3.Text = "Please tag the Company and Location with employee";
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(77, 39);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(509, 21);
            this.CmbCompany.TabIndex = 92;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(567, 61);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(19, 21);
            this.cmbLocation.TabIndex = 91;
            this.cmbLocation.Visible = false;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompany.Location = new System.Drawing.Point(23, 39);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(52, 14);
            this.LblCompany.TabIndex = 90;
            this.LblCompany.Text = "Company";
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLocation.Location = new System.Drawing.Point(513, 63);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 14);
            this.LblLocation.TabIndex = 89;
            this.LblLocation.Text = "Location";
            this.LblLocation.Visible = false;
            // 
            // txt_LstNo
            // 
            this.txt_LstNo.BackColor = System.Drawing.Color.White;
            this.txt_LstNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LstNo.Location = new System.Drawing.Point(643, 130);
            this.txt_LstNo.Name = "txt_LstNo";
            this.txt_LstNo.ReadOnly = true;
            this.txt_LstNo.Size = new System.Drawing.Size(206, 22);
            this.txt_LstNo.TabIndex = 3;
            this.txt_LstNo.Text = "0";
            // 
            // lblLstNo
            // 
            this.lblLstNo.AutoSize = true;
            this.lblLstNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLstNo.Location = new System.Drawing.Point(640, 113);
            this.lblLstNo.Name = "lblLstNo";
            this.lblLstNo.Size = new System.Drawing.Size(78, 14);
            this.lblLstNo.TabIndex = 2;
            this.lblLstNo.Text = "Last Number";
            // 
            // rdbManual
            // 
            this.rdbManual.AutoSize = true;
            this.rdbManual.Checked = true;
            this.rdbManual.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbManual.Location = new System.Drawing.Point(475, 134);
            this.rdbManual.Name = "rdbManual";
            this.rdbManual.Size = new System.Drawing.Size(59, 18);
            this.rdbManual.TabIndex = 1;
            this.rdbManual.TabStop = true;
            this.rdbManual.Text = "Manual";
            this.rdbManual.UseVisualStyleBackColor = true;
            this.rdbManual.CheckedChanged += new System.EventHandler(this.rdbManual_CheckedChanged);
            // 
            // rdbAuto
            // 
            this.rdbAuto.AutoSize = true;
            this.rdbAuto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAuto.Location = new System.Drawing.Point(475, 111);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(73, 18);
            this.rdbAuto.TabIndex = 1;
            this.rdbAuto.Text = "Automatic";
            this.rdbAuto.UseVisualStyleBackColor = true;
            this.rdbAuto.CheckedChanged += new System.EventHandler(this.rdbAuto_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "How do you want to process your Employee IDs.?";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btn_close);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(902, 10);
            this.panel3.TabIndex = 44;
            this.panel3.Visible = false;
            // 
            // btn_close
            // 
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.Location = new System.Drawing.Point(868, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(34, 10);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_close.TabIndex = 94;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 10);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 94;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(47, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import From Excel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEmpJoinExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(904, 625);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpJoinExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import From Excel";
            this.Load += new System.EventHandler(this.frmEmpJoinExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgView_Emp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txt_filepath;
        private System.Windows.Forms.DataGridView dgView_Emp;
        private EDPComponent.VistaButton btn_Upload;
        private EDPComponent.VistaButton btn_Proc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_LstNo;
        private System.Windows.Forms.Label lblLstNo;
        private System.Windows.Forms.RadioButton rdbManual;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.Label label3;
        private EDPComponent.ComboDialog CmbCompany;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private EDPComponent.VistaButton btn_Create_file;
        private EDPComponent.VistaButton btn_Create_File_data;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btn_close;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lstDesignation;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pbEmployeeInsertion;
        private System.Windows.Forms.Label label5;
        private EDPComponent.VistaButton btnReChk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private EDPComponent.VistaButton btnProccess_Bank;
    }
}