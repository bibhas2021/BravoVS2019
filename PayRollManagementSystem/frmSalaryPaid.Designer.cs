namespace PayRollManagementSystem
{
    partial class frmSalaryPaid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalaryPaid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdb_due = new System.Windows.Forms.RadioButton();
            this.rdbpaid = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_view_all = new System.Windows.Forms.RadioButton();
            this.rdb_View_Cheque = new System.Windows.Forms.RadioButton();
            this.rdb_View_Cash = new System.Windows.Forms.RadioButton();
            this.rdb_View_Bank = new System.Windows.Forms.RadioButton();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnPreview = new EDPComponent.VistaButton();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnExport = new EDPComponent.VistaButton();
            this.dgvRow = new System.Windows.Forms.DataGridView();
            this.col_eid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_adhok = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_final = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_locid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_clid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Client_Loc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_net = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_curst = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_pdate = new EDPComponent.CalendarColumn();
            this.col_mod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_InstrumentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_instrument_date = new EDPComponent.CalendarColumn();
            this.col_bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_lock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cmbYear);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbcompany);
            this.panel1.Controls.Add(this.dtpMonth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 110);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbAll);
            this.groupBox2.Controls.Add(this.rdb_due);
            this.groupBox2.Controls.Add(this.rdbpaid);
            this.groupBox2.Location = new System.Drawing.Point(15, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 55);
            this.groupBox2.TabIndex = 303;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(131, 22);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(36, 17);
            this.rdbAll.TabIndex = 298;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdb_due
            // 
            this.rdb_due.AutoSize = true;
            this.rdb_due.Checked = true;
            this.rdb_due.Location = new System.Drawing.Point(24, 22);
            this.rdb_due.Name = "rdb_due";
            this.rdb_due.Size = new System.Drawing.Size(45, 17);
            this.rdb_due.TabIndex = 298;
            this.rdb_due.TabStop = true;
            this.rdb_due.Text = "Due";
            this.rdb_due.UseVisualStyleBackColor = true;
            // 
            // rdbpaid
            // 
            this.rdbpaid.AutoSize = true;
            this.rdbpaid.Location = new System.Drawing.Point(77, 22);
            this.rdbpaid.Name = "rdbpaid";
            this.rdbpaid.Size = new System.Drawing.Size(46, 17);
            this.rdbpaid.TabIndex = 298;
            this.rdbpaid.Text = "Paid";
            this.rdbpaid.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_view_all);
            this.groupBox1.Controls.Add(this.rdb_View_Cheque);
            this.groupBox1.Controls.Add(this.rdb_View_Cash);
            this.groupBox1.Controls.Add(this.rdb_View_Bank);
            this.groupBox1.Location = new System.Drawing.Point(227, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 58);
            this.groupBox1.TabIndex = 302;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View By";
            // 
            // rdb_view_all
            // 
            this.rdb_view_all.AutoSize = true;
            this.rdb_view_all.Location = new System.Drawing.Point(6, 19);
            this.rdb_view_all.Name = "rdb_view_all";
            this.rdb_view_all.Size = new System.Drawing.Size(36, 17);
            this.rdb_view_all.TabIndex = 298;
            this.rdb_view_all.Text = "All";
            this.rdb_view_all.UseVisualStyleBackColor = true;
            this.rdb_view_all.Visible = false;
            // 
            // rdb_View_Cheque
            // 
            this.rdb_View_Cheque.AutoSize = true;
            this.rdb_View_Cheque.Location = new System.Drawing.Point(178, 12);
            this.rdb_View_Cheque.Name = "rdb_View_Cheque";
            this.rdb_View_Cheque.Size = new System.Drawing.Size(62, 17);
            this.rdb_View_Cheque.TabIndex = 298;
            this.rdb_View_Cheque.Text = "Cheque";
            this.rdb_View_Cheque.UseVisualStyleBackColor = true;
            // 
            // rdb_View_Cash
            // 
            this.rdb_View_Cash.AutoSize = true;
            this.rdb_View_Cash.Checked = true;
            this.rdb_View_Cash.Location = new System.Drawing.Point(95, 12);
            this.rdb_View_Cash.Name = "rdb_View_Cash";
            this.rdb_View_Cash.Size = new System.Drawing.Size(49, 17);
            this.rdb_View_Cash.TabIndex = 298;
            this.rdb_View_Cash.TabStop = true;
            this.rdb_View_Cash.Text = "Cash";
            this.rdb_View_Cash.UseVisualStyleBackColor = true;
            // 
            // rdb_View_Bank
            // 
            this.rdb_View_Bank.AutoSize = true;
            this.rdb_View_Bank.Location = new System.Drawing.Point(95, 35);
            this.rdb_View_Bank.Name = "rdb_View_Bank";
            this.rdb_View_Bank.Size = new System.Drawing.Size(92, 17);
            this.rdb_View_Bank.TabIndex = 298;
            this.rdb_View_Bank.Text = "Bank Transfer";
            this.rdb_View_Bank.UseVisualStyleBackColor = true;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(787, 15);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(117, 21);
            this.cmbYear.TabIndex = 300;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(824, 61);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 299;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(722, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 301;
            this.label22.Text = "Session";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(515, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 294;
            this.label21.Text = "Month";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 297;
            this.label6.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(109, 12);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(373, 21);
            this.cmbcompany.TabIndex = 296;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MMMM - yyyy";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(573, 15);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(132, 20);
            this.dtpMonth.TabIndex = 295;
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 485);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1225, 50);
            this.panel2.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Ivory;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(951, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 26);
            this.btnSave.TabIndex = 333;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.ButtonText = "Export";
            this.btnExport.CornerRadius = 4;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExport.Location = new System.Drawing.Point(814, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 30);
            this.btnExport.TabIndex = 299;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvRow
            // 
            this.dgvRow.AllowUserToAddRows = false;
            this.dgvRow.AllowUserToDeleteRows = false;
            this.dgvRow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRow.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvRow.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_eid,
            this.col_adhok,
            this.col_final,
            this.col_name,
            this.col_locid,
            this.col_clid,
            this.col_Client_Loc,
            this.col_net,
            this.col_status,
            this.col_curst,
            this.col_pdate,
            this.col_mod,
            this.col_InstrumentNo,
            this.col_instrument_date,
            this.col_bank,
            this.col_remarks,
            this.col_lock,
            this.col_slno});
            this.dgvRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRow.Location = new System.Drawing.Point(0, 110);
            this.dgvRow.Name = "dgvRow";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRow.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRow.RowHeadersVisible = false;
            this.dgvRow.Size = new System.Drawing.Size(1225, 375);
            this.dgvRow.TabIndex = 8;
            this.dgvRow.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRow_CellValueChanged);
            this.dgvRow.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRow_DataError);
            // 
            // col_eid
            // 
            this.col_eid.HeaderText = "col_eid";
            this.col_eid.Name = "col_eid";
            this.col_eid.Visible = false;
            // 
            // col_adhok
            // 
            this.col_adhok.HeaderText = "col_Adhok";
            this.col_adhok.Name = "col_adhok";
            // 
            // col_final
            // 
            this.col_final.HeaderText = "Final";
            this.col_final.Name = "col_final";
            this.col_final.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_final.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_name
            // 
            this.col_name.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_name.HeaderText = "Employee Name";
            this.col_name.MinimumWidth = 150;
            this.col_name.Name = "col_name";
            // 
            // col_locid
            // 
            this.col_locid.HeaderText = "locid";
            this.col_locid.Name = "col_locid";
            this.col_locid.Visible = false;
            // 
            // col_clid
            // 
            this.col_clid.HeaderText = "clid";
            this.col_clid.Name = "col_clid";
            this.col_clid.Visible = false;
            // 
            // col_Client_Loc
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Client_Loc.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Client_Loc.HeaderText = "Client (Location)";
            this.col_Client_Loc.MinimumWidth = 150;
            this.col_Client_Loc.Name = "col_Client_Loc";
            // 
            // col_net
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.col_net.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_net.HeaderText = "Net Payment";
            this.col_net.Name = "col_net";
            // 
            // col_status
            // 
            this.col_status.DataPropertyName = "Status";
            this.col_status.HeaderText = "Paid / Unpaid";
            this.col_status.Name = "col_status";
            this.col_status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_curst
            // 
            this.col_curst.HeaderText = "Status";
            this.col_curst.Items.AddRange(new object[] {
            "Issued",
            "Transferred",
            "Cancelled",
            "Returned"});
            this.col_curst.Name = "col_curst";
            // 
            // col_pdate
            // 
            this.col_pdate.HeaderText = "Pay Date";
            this.col_pdate.Name = "col_pdate";
            // 
            // col_mod
            // 
            this.col_mod.HeaderText = "Mode of Payment";
            this.col_mod.MinimumWidth = 50;
            this.col_mod.Name = "col_mod";
            this.col_mod.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_mod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_InstrumentNo
            // 
            this.col_InstrumentNo.DataPropertyName = "InstrumentNo";
            this.col_InstrumentNo.HeaderText = "Instrument No";
            this.col_InstrumentNo.Name = "col_InstrumentNo";
            // 
            // col_instrument_date
            // 
            this.col_instrument_date.DataPropertyName = "InstrumentDate";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_instrument_date.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_instrument_date.HeaderText = "Instrument Date";
            this.col_instrument_date.MinimumWidth = 50;
            this.col_instrument_date.Name = "col_instrument_date";
            this.col_instrument_date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_instrument_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_bank
            // 
            this.col_bank.HeaderText = "Bank";
            this.col_bank.MinimumWidth = 70;
            this.col_bank.Name = "col_bank";
            // 
            // col_remarks
            // 
            this.col_remarks.DataPropertyName = "Remarks";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_remarks.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_remarks.HeaderText = "Remarks";
            this.col_remarks.Name = "col_remarks";
            // 
            // col_lock
            // 
            this.col_lock.HeaderText = "Lock / Unlock";
            this.col_lock.Name = "col_lock";
            this.col_lock.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_lock.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_slno
            // 
            this.col_slno.DataPropertyName = "SlNo";
            this.col_slno.HeaderText = "Id";
            this.col_slno.Name = "col_slno";
            this.col_slno.ReadOnly = true;
            this.col_slno.Visible = false;
            // 
            // frmSalaryPaid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 535);
            this.Controls.Add(this.dgvRow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalaryPaid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary Paid Unpaid";
            this.Load += new System.EventHandler(this.frmSalaryPaid_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbpaid;
        private System.Windows.Forms.RadioButton rdb_due;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label6;
        public EDPComponent.ComboDialog cmbcompany;
        public System.Windows.Forms.DateTimePicker dtpMonth;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnSave;
        private System.Windows.Forms.DataGridView dgvRow;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private EDPComponent.VistaButton btnExport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_View_Cheque;
        private System.Windows.Forms.RadioButton rdb_View_Cash;
        private System.Windows.Forms.RadioButton rdb_View_Bank;
        private System.Windows.Forms.RadioButton rdb_view_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_eid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_adhok;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_final;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_locid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_clid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Client_Loc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_net;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_status;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_curst;
        private EDPComponent.CalendarColumn col_pdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_mod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_InstrumentNo;
        private EDPComponent.CalendarColumn col_instrument_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_lock;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_slno;
    }
}