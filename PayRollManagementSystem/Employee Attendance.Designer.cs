namespace PayRollManagementSystem
{
    partial class Employee_Attendance
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
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbdEmpId = new EDPComponent.ComboDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEmpType = new EDPComponent.ComboDialog();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbDesg = new EDPComponent.ComboDialog();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DgAttendance = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new EDPComponent.CalendarColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LeaveTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeaveType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(664, 414);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(46, 13);
            this.lblToDate.TabIndex = 48;
            this.lblToDate.Text = "To Date";
            this.lblToDate.Visible = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(667, 431);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(86, 20);
            this.dtpToDate.TabIndex = 46;
            this.dtpToDate.Value = new System.DateTime(2009, 2, 14, 0, 0, 0, 0);
            this.dtpToDate.Visible = false;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(540, 414);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(56, 13);
            this.lblFromDate.TabIndex = 47;
            this.lblFromDate.Text = "From Date";
            this.lblFromDate.Visible = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(543, 431);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDate.TabIndex = 44;
            this.dtpDate.Value = new System.DateTime(2009, 2, 14, 0, 0, 0, 0);
            this.dtpDate.Visible = false;
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabPage1);
            this.tbcMain.Controls.Add(this.tabPage2);
            this.tbcMain.Location = new System.Drawing.Point(8, 30);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(914, 511);
            this.tbcMain.TabIndex = 247;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblEmpName);
            this.tabPage1.Controls.Add(this.btnSubmit);
            this.tabPage1.Controls.Add(this.cmbdEmpId);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cmbEmpType);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.cmbDesg);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.cmbMonth);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbYear);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DgAttendance);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(906, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Entry";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(412, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 256;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(632, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 255;
            this.label4.Text = "Employee Name";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.Location = new System.Drawing.Point(633, 32);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(163, 13);
            this.lblEmpName.TabIndex = 254;
            this.lblEmpName.Text = ".......................................";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Black;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(816, 20);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 25);
            this.btnSubmit.TabIndex = 253;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbdEmpId
            // 
            this.cmbdEmpId.Connection = null;
            this.cmbdEmpId.DialogResult = "";
            this.cmbdEmpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdEmpId.Location = new System.Drawing.Point(499, 29);
            this.cmbdEmpId.LOVFlag = 0;
            this.cmbdEmpId.Name = "cmbdEmpId";
            this.cmbdEmpId.ReturnValue = "";
            this.cmbdEmpId.Size = new System.Drawing.Size(128, 21);
            this.cmbdEmpId.TabIndex = 251;
            this.cmbdEmpId.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbdEmpId_DropDown);
            this.cmbdEmpId.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbdEmpId_CloseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 252;
            this.label6.Text = "Employee ID";
            // 
            // cmbEmpType
            // 
            this.cmbEmpType.BackColor = System.Drawing.Color.White;
            this.cmbEmpType.Connection = null;
            this.cmbEmpType.DialogResult = "";
            this.cmbEmpType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpType.Location = new System.Drawing.Point(365, 29);
            this.cmbEmpType.LOVFlag = 0;
            this.cmbEmpType.Name = "cmbEmpType";
            this.cmbEmpType.ReturnValue = "";
            this.cmbEmpType.Size = new System.Drawing.Size(122, 21);
            this.cmbEmpType.TabIndex = 249;
            this.cmbEmpType.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbEmpType_DropDown);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(362, 14);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(51, 13);
            this.label29.TabIndex = 250;
            this.label29.Text = "Job Type";
            // 
            // cmbDesg
            // 
            this.cmbDesg.BackColor = System.Drawing.Color.White;
            this.cmbDesg.Connection = null;
            this.cmbDesg.DialogResult = "";
            this.cmbDesg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesg.Location = new System.Drawing.Point(237, 29);
            this.cmbDesg.LOVFlag = 0;
            this.cmbDesg.Name = "cmbDesg";
            this.cmbDesg.ReturnValue = "";
            this.cmbDesg.Size = new System.Drawing.Size(122, 21);
            this.cmbDesg.TabIndex = 248;
            this.cmbDesg.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbDesg_DropDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(234, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 247;
            this.label19.Text = "Designation";
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(129, 29);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(93, 21);
            this.cmbMonth.TabIndex = 246;
            this.cmbMonth.DropDown += new System.EventHandler(this.cmbMonth_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 245;
            this.label2.Text = "Month";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(23, 29);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 21);
            this.cmbYear.TabIndex = 244;
            this.cmbYear.DropDown += new System.EventHandler(this.cmbYear_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 243;
            this.label1.Text = "Year";
            // 
            // DgAttendance
            // 
            this.DgAttendance.AllowUserToDeleteRows = false;
            this.DgAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlNo,
            this.ID,
            this.EmpName,
            this.Date,
            this.Status,
            this.LeaveTaken,
            this.LeaveType,
            this.Remarks});
            this.DgAttendance.Location = new System.Drawing.Point(7, 56);
            this.DgAttendance.Name = "DgAttendance";
            this.DgAttendance.RowHeadersVisible = false;
            this.DgAttendance.Size = new System.Drawing.Size(891, 392);
            this.DgAttendance.TabIndex = 51;
            this.DgAttendance.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgAttendance_CellMouseDoubleClick);
            this.DgAttendance.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DgAttendance_DataError);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(906, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Query";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SlNo
            // 
            this.SlNo.DataPropertyName = "SlNo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SlNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.SlNo.HeaderText = "SlNo";
            this.SlNo.Name = "SlNo";
            this.SlNo.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle3;
            this.ID.FillWeight = 81.1337F;
            this.ID.HeaderText = "Employee ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // EmpName
            // 
            this.EmpName.DataPropertyName = "Employee Name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.EmpName.DefaultCellStyle = dataGridViewCellStyle4;
            this.EmpName.FillWeight = 213.1981F;
            this.EmpName.HeaderText = "Employee Name";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
            this.EmpName.Visible = false;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Date.DefaultCellStyle = dataGridViewCellStyle5;
            this.Date.FillWeight = 81.1337F;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Date.ToolTipText = "Date";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.FillWeight = 81.1337F;
            this.Status.HeaderText = "Absent";
            this.Status.Name = "Status";
            // 
            // LeaveTaken
            // 
            this.LeaveTaken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.LeaveTaken.DataPropertyName = "LeaveTaken";
            this.LeaveTaken.FillWeight = 81.1337F;
            this.LeaveTaken.HeaderText = "Leave Taken";
            this.LeaveTaken.Name = "LeaveTaken";
            this.LeaveTaken.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LeaveTaken.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LeaveTaken.Width = 77;
            // 
            // LeaveType
            // 
            this.LeaveType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.LeaveType.DataPropertyName = "LeaveType";
            this.LeaveType.FillWeight = 81.1337F;
            this.LeaveType.HeaderText = "Leave Type";
            this.LeaveType.Items.AddRange(new object[] {
            "LP",
            "LWP"});
            this.LeaveType.Name = "LeaveType";
            this.LeaveType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LeaveType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LeaveType.Width = 89;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Remarks.DefaultCellStyle = dataGridViewCellStyle6;
            this.Remarks.FillWeight = 81.1337F;
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Employee_Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 553);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Employee Attendance";
            this.Name = "Employee_Attendance";
            this.Load += new System.EventHandler(this.Employee_Attendance_Load);
            this.Controls.SetChildIndex(this.lblFromDate, 0);
            this.Controls.SetChildIndex(this.lblToDate, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.dtpToDate, 0);
            this.Controls.SetChildIndex(this.tbcMain, 0);
            this.tbcMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DgAttendance;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Button btnSubmit;
        private EDPComponent.ComboDialog cmbdEmpId;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbEmpType;
        private System.Windows.Forms.Label label29;
        private EDPComponent.ComboDialog cmbDesg;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private EDPComponent.CalendarColumn Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeaveTaken;
        private System.Windows.Forms.DataGridViewComboBoxColumn LeaveType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}