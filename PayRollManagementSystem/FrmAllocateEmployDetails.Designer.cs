namespace PayRollManagementSystem
{
    partial class FrmAllocateEmployDetails
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
            this.cmborderno = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.dgemployjob = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliantname = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.locationname = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Designation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.personName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderdate = new EDPComponent.CalendarColumn();
            this.fromdate = new EDPComponent.CalendarColumn();
            this.todate = new EDPComponent.CalendarColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgemployjob)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(770, 32);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1098, 0);
            this.btnClose.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmborderno
            // 
            this.cmborderno.Connection = null;
            this.cmborderno.DialogResult = "";
            this.cmborderno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmborderno.Location = new System.Drawing.Point(606, 13);
            this.cmborderno.LOVFlag = 0;
            this.cmborderno.MaxCharLength = 500;
            this.cmborderno.Name = "cmborderno";
            this.cmborderno.ReturnIndex = -1;
            this.cmborderno.ReturnValue = "";
            this.cmborderno.ReturnValue_3rd = "";
            this.cmborderno.ReturnValue_4th = "";
            this.cmborderno.Size = new System.Drawing.Size(353, 21);
            this.cmborderno.TabIndex = 84;
            this.cmborderno.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmborderno_DropDown);
            this.cmborderno.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmborderno_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Employee Name";
            // 
            // dgemployjob
            // 
            this.dgemployjob.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgemployjob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgemployjob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgemployjob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.transaction,
            this.Cliantname,
            this.locationname,
            this.Designation,
            this.OrderNo,
            this.personName,
            this.orderdate,
            this.fromdate,
            this.todate,
            this.username});
            this.dgemployjob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgemployjob.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgemployjob.Location = new System.Drawing.Point(0, 0);
            this.dgemployjob.Name = "dgemployjob";
            this.dgemployjob.RowHeadersVisible = false;
            this.dgemployjob.Size = new System.Drawing.Size(1136, 504);
            this.dgemployjob.TabIndex = 83;
            this.dgemployjob.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgemployjob_CellEndEdit);
            this.dgemployjob.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgemployjob_DataError);
            this.dgemployjob.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgemployjob_CellEnter);
            // 
            // id
            // 
            this.id.DataPropertyName = "STATE_CODE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // transaction
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.transaction.DefaultCellStyle = dataGridViewCellStyle3;
            this.transaction.HeaderText = "Transaction No.";
            this.transaction.Name = "transaction";
            this.transaction.Width = 80;
            // 
            // Cliantname
            // 
            this.Cliantname.DataPropertyName = "STATE_Name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Cliantname.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cliantname.HeaderText = "Client Name";
            this.Cliantname.MinimumWidth = 180;
            this.Cliantname.Name = "Cliantname";
            this.Cliantname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Cliantname.Sorted = true;
            this.Cliantname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Cliantname.Width = 300;
            // 
            // locationname
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.locationname.DefaultCellStyle = dataGridViewCellStyle5;
            this.locationname.HeaderText = "Location Site Name";
            this.locationname.MinimumWidth = 180;
            this.locationname.Name = "locationname";
            this.locationname.Width = 300;
            // 
            // Designation
            // 
            this.Designation.HeaderText = "Designation";
            this.Designation.MinimumWidth = 100;
            this.Designation.Name = "Designation";
            this.Designation.Width = 150;
            // 
            // OrderNo
            // 
            this.OrderNo.HeaderText = "Order No";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OrderNo.Visible = false;
            this.OrderNo.Width = 120;
            // 
            // personName
            // 
            this.personName.HeaderText = "Order Person";
            this.personName.Name = "personName";
            this.personName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.personName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.personName.Visible = false;
            this.personName.Width = 120;
            // 
            // orderdate
            // 
            this.orderdate.HeaderText = "Order Date";
            this.orderdate.Name = "orderdate";
            this.orderdate.Visible = false;
            // 
            // fromdate
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fromdate.DefaultCellStyle = dataGridViewCellStyle6;
            this.fromdate.HeaderText = "From Date";
            this.fromdate.MinimumWidth = 100;
            this.fromdate.Name = "fromdate";
            // 
            // todate
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.todate.DefaultCellStyle = dataGridViewCellStyle7;
            this.todate.HeaderText = "To Date";
            this.todate.Name = "todate";
            this.todate.Width = 85;
            // 
            // username
            // 
            this.username.HeaderText = "User Name";
            this.username.Name = "username";
            this.username.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.username.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.username.Width = 120;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1061, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 32);
            this.btnExit.TabIndex = 92;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(911, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 90;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbmonth
            // 
            this.cmbmonth.FormattingEnabled = true;
            this.cmbmonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbmonth.Location = new System.Drawing.Point(365, 13);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(133, 21);
            this.cmbmonth.TabIndex = 93;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "Select Month";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(88, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(171, 21);
            this.cmbYear.TabIndex = 241;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(22, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 242;
            this.label22.Text = "Session";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.cmbmonth);
            this.splitContainer1.Panel1.Controls.Add(this.cmbYear);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label22);
            this.splitContainer1.Panel1.Controls.Add(this.cmborderno);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1136, 610);
            this.splitContainer1.SplitterDistance = 66;
            this.splitContainer1.TabIndex = 243;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1086, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(38, 21);
            this.comboBox1.TabIndex = 84;
            this.comboBox1.Visible = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgemployjob);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnExit);
            this.splitContainer2.Size = new System.Drawing.Size(1136, 540);
            this.splitContainer2.SplitterDistance = 504;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(986, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 93;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmAllocateEmployDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 642);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmAllocateEmployDetails";
            this.Load += new System.EventHandler(this.FrmAllocateEmployDetails_Load);
            this.Shown += new System.EventHandler(this.FrmAllocateEmployDetails_Shown);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgemployjob)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EDPComponent.ComboDialog cmborderno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgemployjob;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn transaction;
        private System.Windows.Forms.DataGridViewComboBoxColumn Cliantname;
        private System.Windows.Forms.DataGridViewComboBoxColumn locationname;
        private System.Windows.Forms.DataGridViewComboBoxColumn Designation;
        private System.Windows.Forms.DataGridViewComboBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn personName;
        private EDPComponent.CalendarColumn orderdate;
        private EDPComponent.CalendarColumn fromdate;
        private EDPComponent.CalendarColumn todate;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
    }
}