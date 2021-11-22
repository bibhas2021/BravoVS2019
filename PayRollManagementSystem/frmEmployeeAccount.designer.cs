namespace PayRollManagementSystem
{
    partial class frmEmployeeAccount
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbsalstruc = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvemployee = new System.Windows.Forms.DataGridView();
            this.btnclose = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.employee = new System.Windows.Forms.TabPage();
            this.bill = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.billno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicetax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transfar1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Employid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transfar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvemployee)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.employee.SuspendLayout();
            this.bill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbsalstruc);
            this.groupBox1.Location = new System.Drawing.Point(5, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 265;
            this.label22.Text = "Session";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "MMMM - yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(280, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 20);
            this.dateTimePicker1.TabIndex = 269;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(187, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 266;
            this.label21.Text = "For The Month of";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(61, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(118, 21);
            this.cmbYear.TabIndex = 264;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 267;
            this.label2.Text = "Location";
            // 
            // cmbsalstruc
            // 
            this.cmbsalstruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsalstruc.FormattingEnabled = true;
            this.cmbsalstruc.Location = new System.Drawing.Point(460, 13);
            this.cmbsalstruc.Name = "cmbsalstruc";
            this.cmbsalstruc.Size = new System.Drawing.Size(220, 21);
            this.cmbsalstruc.TabIndex = 268;
            this.cmbsalstruc.DropDownClosed += new System.EventHandler(this.cmbsalstruc_DropDownClosed);
            this.cmbsalstruc.DropDown += new System.EventHandler(this.cmbsalstruc_DropDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvemployee);
            this.groupBox2.Location = new System.Drawing.Point(4, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(677, 386);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dgvemployee
            // 
            this.dgvemployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvemployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Employid,
            this.employename,
            this.deg,
            this.transfar});
            this.dgvemployee.Location = new System.Drawing.Point(5, 13);
            this.dgvemployee.Name = "dgvemployee";
            this.dgvemployee.RowHeadersVisible = false;
            this.dgvemployee.Size = new System.Drawing.Size(665, 368);
            this.dgvemployee.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.ButtonText = "Close";
            this.btnclose.Location = new System.Drawing.Point(605, 512);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 29);
            this.btnclose.TabIndex = 277;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.ButtonText = "Next ";
            this.btnSubmit.Location = new System.Drawing.Point(519, 512);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 29);
            this.btnSubmit.TabIndex = 276;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(12, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 15);
            this.label1.TabIndex = 270;
            this.label1.Text = "Ctrl+A >> Check All // Ctrl+D >> Uncheck All";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.employee);
            this.tabControl1.Controls.Add(this.bill);
            this.tabControl1.Location = new System.Drawing.Point(5, 75);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(695, 418);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // employee
            // 
            this.employee.Controls.Add(this.groupBox2);
            this.employee.Location = new System.Drawing.Point(4, 22);
            this.employee.Name = "employee";
            this.employee.Padding = new System.Windows.Forms.Padding(3);
            this.employee.Size = new System.Drawing.Size(687, 392);
            this.employee.TabIndex = 0;
            this.employee.Text = "Employee";
            this.employee.UseVisualStyleBackColor = true;
            // 
            // bill
            // 
            this.bill.Controls.Add(this.dataGridView1);
            this.bill.Location = new System.Drawing.Point(4, 22);
            this.bill.Name = "bill";
            this.bill.Padding = new System.Windows.Forms.Padding(3);
            this.bill.Size = new System.Drawing.Size(687, 392);
            this.bill.TabIndex = 1;
            this.bill.Text = "Sales Bill";
            this.bill.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.billno,
            this.billdate,
            this.servicetax,
            this.transfar1});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(674, 379);
            this.dataGridView1.TabIndex = 0;
            // 
            // billno
            // 
            this.billno.HeaderText = "Bill No.";
            this.billno.Name = "billno";
            this.billno.Width = 250;
            // 
            // billdate
            // 
            this.billdate.HeaderText = "Bill Date";
            this.billdate.Name = "billdate";
            this.billdate.Width = 200;
            // 
            // servicetax
            // 
            this.servicetax.HeaderText = "Service Tax";
            this.servicetax.Name = "servicetax";
            // 
            // transfar1
            // 
            this.transfar1.HeaderText = "Transfer";
            this.transfar1.Name = "transfar1";
            this.transfar1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.transfar1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Employid
            // 
            this.Employid.DataPropertyName = "ID";
            this.Employid.HeaderText = "Employee ID";
            this.Employid.Name = "Employid";
            // 
            // employename
            // 
            this.employename.DataPropertyName = "Employee_Name";
            this.employename.HeaderText = "Employee Name";
            this.employename.Name = "employename";
            this.employename.Width = 300;
            // 
            // deg
            // 
            this.deg.DataPropertyName = "DesignationName";
            this.deg.HeaderText = "Designation";
            this.deg.Name = "deg";
            this.deg.Width = 150;
            // 
            // transfar
            // 
            this.transfar.DataPropertyName = "Acc_transfer";
            this.transfar.HeaderText = "Transfer";
            this.transfar.Name = "transfar";
            // 
            // frmEmployeeAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 545);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Name = "frmEmployeeAccount";
            this.Load += new System.EventHandler(this.frmEmployeeAccount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEmployeeAccount_KeyDown);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnSubmit, 0);
            this.Controls.SetChildIndex(this.btnclose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvemployee)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.employee.ResumeLayout(false);
            this.bill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbsalstruc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvemployee;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage employee;
        private System.Windows.Forms.TabPage bill;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn billno;
        private System.Windows.Forms.DataGridViewTextBoxColumn billdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicetax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn transfar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employid;
        private System.Windows.Forms.DataGridViewTextBoxColumn employename;
        private System.Windows.Forms.DataGridViewTextBoxColumn deg;
        private System.Windows.Forms.DataGridViewCheckBoxColumn transfar;
    }
}