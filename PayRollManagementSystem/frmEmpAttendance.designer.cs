namespace PayRollManagementSystem
{
    partial class frmEmpAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpAttendance));
            this.AttendanceGrid = new System.Windows.Forms.DataGridView();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Extractcmd = new EDPComponent.VistaButton();
            this.DeleteSelcmd = new EDPComponent.VistaButton();
            this.Closecmd = new EDPComponent.VistaButton();
            this.cmblocation = new EDPComponent.ComboDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new EDPComponent.VistaButton();
            this.lblClientID = new System.Windows.Forms.Label();
            this.lblCoid = new System.Windows.Forms.Label();
            this.LblClient = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMOD = new System.Windows.Forms.Label();
            this.lblWO = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTdays = new System.Windows.Forms.Label();
            this.btnExcel = new EDPComponent.VistaButton();
            this.btnRecheck = new EDPComponent.VistaButton();
            this.lbl_Log = new System.Windows.Forms.Label();
            this.btnImport = new EDPComponent.VistaButton();
            this.btnExport = new EDPComponent.VistaButton();
            this.cmbOption = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbl_path = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AttendanceGrid
            // 
            this.AttendanceGrid.AllowUserToAddRows = false;
            this.AttendanceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AttendanceGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.AttendanceGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AttendanceGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AttendanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AttendanceGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.AttendanceGrid.Location = new System.Drawing.Point(9, 67);
            this.AttendanceGrid.MultiSelect = false;
            this.AttendanceGrid.Name = "AttendanceGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AttendanceGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AttendanceGrid.RowHeadersVisible = false;
            this.AttendanceGrid.ShowCellToolTips = false;
            this.AttendanceGrid.Size = new System.Drawing.Size(1184, 484);
            this.AttendanceGrid.TabIndex = 0;
            this.AttendanceGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.AttendanceGrid_CellLeave);
            this.AttendanceGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AttendanceGrid_CellDoubleClick);
            this.AttendanceGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.AttendanceGrid_CellEndEdit);
            this.AttendanceGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AttendanceGrid_CellContentClick);
            this.AttendanceGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AttendanceGrid_KeyDown);
            this.AttendanceGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.AttendanceGrid_CellEnter);
            this.AttendanceGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AttendanceGrid_CellContentClick);
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.CalendarFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM, yyyy";
            this.AttenDtTmPkr.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(91, 7);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(148, 22);
            this.AttenDtTmPkr.TabIndex = 2;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1142, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sunday";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.OldLace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1142, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Holiday";
            // 
            // Extractcmd
            // 
            this.Extractcmd.BackColor = System.Drawing.Color.Transparent;
            this.Extractcmd.BaseColor = System.Drawing.Color.Ivory;
            this.Extractcmd.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.Extractcmd.ButtonText = "Fetch";
            this.Extractcmd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Extractcmd.ForeColor = System.Drawing.Color.Black;
            this.Extractcmd.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.Extractcmd.Location = new System.Drawing.Point(721, 34);
            this.Extractcmd.Name = "Extractcmd";
            this.Extractcmd.Size = new System.Drawing.Size(68, 26);
            this.Extractcmd.TabIndex = 42;
            this.Extractcmd.Click += new System.EventHandler(this.Extractcmd_Click);
            // 
            // DeleteSelcmd
            // 
            this.DeleteSelcmd.BackColor = System.Drawing.Color.Transparent;
            this.DeleteSelcmd.BaseColor = System.Drawing.Color.Ivory;
            this.DeleteSelcmd.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.DeleteSelcmd.ButtonText = "Delete";
            this.DeleteSelcmd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSelcmd.ForeColor = System.Drawing.Color.Black;
            this.DeleteSelcmd.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.DeleteSelcmd.Location = new System.Drawing.Point(792, 34);
            this.DeleteSelcmd.Name = "DeleteSelcmd";
            this.DeleteSelcmd.Size = new System.Drawing.Size(68, 26);
            this.DeleteSelcmd.TabIndex = 43;
            this.DeleteSelcmd.Visible = false;
            this.DeleteSelcmd.Click += new System.EventHandler(this.DeleteSelcmd_Click);
            // 
            // Closecmd
            // 
            this.Closecmd.BackColor = System.Drawing.Color.Transparent;
            this.Closecmd.BaseColor = System.Drawing.Color.Ivory;
            this.Closecmd.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.Closecmd.ButtonText = "Close";
            this.Closecmd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closecmd.ForeColor = System.Drawing.Color.Black;
            this.Closecmd.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.Closecmd.Location = new System.Drawing.Point(864, 34);
            this.Closecmd.Name = "Closecmd";
            this.Closecmd.Size = new System.Drawing.Size(68, 26);
            this.Closecmd.TabIndex = 44;
            this.Closecmd.Click += new System.EventHandler(this.Closecmd_Click);
            // 
            // cmblocation
            // 
            this.cmblocation.Connection = null;
            this.cmblocation.DialogResult = "";
            this.cmblocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.Location = new System.Drawing.Point(91, 38);
            this.cmblocation.LOVFlag = 0;
            this.cmblocation.MaxCharLength = 500;
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.ReturnIndex = -1;
            this.cmblocation.ReturnValue = "";
            this.cmblocation.ReturnValue_3rd = "";
            this.cmblocation.ReturnValue_4th = "";
            this.cmblocation.Size = new System.Drawing.Size(624, 21);
            this.cmblocation.TabIndex = 86;
            this.cmblocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmblocation_DropDown);
            this.cmblocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmblocation_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Location Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Month";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(309, 10);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(114, 21);
            this.cmbYear.TabIndex = 243;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(245, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 244;
            this.label22.Text = "Session";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(3, 573);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 13);
            this.label5.TabIndex = 245;
            this.label5.Text = "Ctrl + A >> All Absent // Ctrl + P >> All Present";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Ivory;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.ButtonText = "Save and Preview";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(997, 560);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(27, 26);
            this.btnSave.TabIndex = 246;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClientID.Location = new System.Drawing.Point(968, 12);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(2, 15);
            this.lblClientID.TabIndex = 310;
            this.lblClientID.Visible = false;
            // 
            // lblCoid
            // 
            this.lblCoid.AutoSize = true;
            this.lblCoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoid.Location = new System.Drawing.Point(1007, 13);
            this.lblCoid.Name = "lblCoid";
            this.lblCoid.Size = new System.Drawing.Size(2, 15);
            this.lblCoid.TabIndex = 309;
            this.lblCoid.Visible = false;
            // 
            // LblClient
            // 
            this.LblClient.AutoSize = true;
            this.LblClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblClient.Location = new System.Drawing.Point(987, 12);
            this.LblClient.Name = "LblClient";
            this.LblClient.Size = new System.Drawing.Size(2, 15);
            this.LblClient.TabIndex = 308;
            this.LblClient.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(440, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "MOD : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(532, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "WOff : ";
            // 
            // lblMOD
            // 
            this.lblMOD.AutoSize = true;
            this.lblMOD.Location = new System.Drawing.Point(484, 15);
            this.lblMOD.Name = "lblMOD";
            this.lblMOD.Size = new System.Drawing.Size(13, 13);
            this.lblMOD.TabIndex = 88;
            this.lblMOD.Text = "0";
            // 
            // lblWO
            // 
            this.lblWO.AutoSize = true;
            this.lblWO.Location = new System.Drawing.Point(575, 15);
            this.lblWO.Name = "lblWO";
            this.lblWO.Size = new System.Drawing.Size(13, 13);
            this.lblWO.TabIndex = 88;
            this.lblWO.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(619, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 88;
            this.label8.Text = "Total Days : ";
            // 
            // lblTdays
            // 
            this.lblTdays.AutoSize = true;
            this.lblTdays.Location = new System.Drawing.Point(695, 17);
            this.lblTdays.Name = "lblTdays";
            this.lblTdays.Size = new System.Drawing.Size(13, 13);
            this.lblTdays.TabIndex = 88;
            this.lblTdays.Text = "0";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExcel.BaseColor = System.Drawing.Color.Ivory;
            this.btnExcel.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnExcel.ButtonText = "Save and Export to Excel";
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExcel.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnExcel.Location = new System.Drawing.Point(1030, 560);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(163, 26);
            this.btnExcel.TabIndex = 246;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRecheck
            // 
            this.btnRecheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecheck.BackColor = System.Drawing.Color.Transparent;
            this.btnRecheck.BaseColor = System.Drawing.Color.Ivory;
            this.btnRecheck.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnRecheck.ButtonText = "Recheck";
            this.btnRecheck.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecheck.ForeColor = System.Drawing.Color.Black;
            this.btnRecheck.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnRecheck.Location = new System.Drawing.Point(752, 560);
            this.btnRecheck.Name = "btnRecheck";
            this.btnRecheck.Size = new System.Drawing.Size(145, 26);
            this.btnRecheck.TabIndex = 246;
            this.btnRecheck.Click += new System.EventHandler(this.btnRecheck_Click);
            // 
            // lbl_Log
            // 
            this.lbl_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Log.Location = new System.Drawing.Point(248, 560);
            this.lbl_Log.Name = "lbl_Log";
            this.lbl_Log.Size = new System.Drawing.Size(132, 13);
            this.lbl_Log.TabIndex = 320;
            this.lbl_Log.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.BaseColor = System.Drawing.Color.Ivory;
            this.btnImport.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnImport.ButtonText = "Import Excel";
            this.btnImport.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnImport.Location = new System.Drawing.Point(410, 560);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(147, 28);
            this.btnImport.TabIndex = 319;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BaseColor = System.Drawing.Color.Ivory;
            this.btnExport.ButtonColor = System.Drawing.Color.Blue;
            this.btnExport.ButtonText = "Export Excel for Import";
            this.btnExport.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnExport.Location = new System.Drawing.Point(563, 558);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(147, 30);
            this.btnExport.TabIndex = 318;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cmbOption
            // 
            this.cmbOption.BackColor = System.Drawing.Color.White;
            this.cmbOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOption.ForeColor = System.Drawing.Color.Black;
            this.cmbOption.FormattingEnabled = true;
            this.cmbOption.Items.AddRange(new object[] {
            "Excel Export",
            "Print Preview",
            "Both"});
            this.cmbOption.Location = new System.Drawing.Point(903, 562);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Size = new System.Drawing.Size(121, 21);
            this.cmbOption.TabIndex = 321;
            this.cmbOption.SelectedIndexChanged += new System.EventHandler(this.cmbOption_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_path.Location = new System.Drawing.Point(249, 576);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(2, 15);
            this.lbl_path.TabIndex = 322;
            this.lbl_path.Visible = false;
            // 
            // frmEmpAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1201, 596);
            this.Controls.Add(this.lbl_path);
            this.Controls.Add(this.cmbOption);
            this.Controls.Add(this.lbl_Log);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblClientID);
            this.Controls.Add(this.lblCoid);
            this.Controls.Add(this.LblClient);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRecheck);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblTdays);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblWO);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMOD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmblocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Closecmd);
            this.Controls.Add(this.DeleteSelcmd);
            this.Controls.Add(this.Extractcmd);
            this.Controls.Add(this.AttenDtTmPkr);
            this.Controls.Add(this.AttendanceGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daily Attendance";
            this.Load += new System.EventHandler(this.frmEmpAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AttendanceGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton Extractcmd;
        private EDPComponent.VistaButton DeleteSelcmd;
        private EDPComponent.VistaButton Closecmd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label5;
        public EDPComponent.ComboDialog cmblocation;
        public System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        public System.Windows.Forms.ComboBox cmbYear;
        private EDPComponent.VistaButton btnSave;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label lblCoid;
        private System.Windows.Forms.Label LblClient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMOD;
        private System.Windows.Forms.Label lblWO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTdays;
        private EDPComponent.VistaButton btnExcel;
        private EDPComponent.VistaButton btnRecheck;
        private System.Windows.Forms.Label lbl_Log;
        private EDPComponent.VistaButton btnImport;
        private EDPComponent.VistaButton btnExport;
        private System.Windows.Forms.ComboBox cmbOption;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbl_path;
    }
}