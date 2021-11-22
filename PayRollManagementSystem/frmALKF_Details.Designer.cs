namespace PayRollManagementSystem
{
    partial class frmALKF_Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmALKF_Details));
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.Label();
            this.txtDesgID = new System.Windows.Forms.Label();
            this.txtDeductionID = new System.Windows.Forms.Label();
            this.dgvRecoveries = new System.Windows.Forms.DataGridView();
            this.BtnEmp_Advance = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmt = new System.Windows.Forms.Label();
            this.DTP_MON = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.col_tid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_eid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desgid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_edate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_emon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecoveries)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Name : ";
            // 
            // txtEmpName
            // 
            this.txtEmpName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEmpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmpName.Location = new System.Drawing.Point(117, 16);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(589, 18);
            this.txtEmpName.TabIndex = 0;
            // 
            // txtDesgID
            // 
            this.txtDesgID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesgID.Location = new System.Drawing.Point(708, 99);
            this.txtDesgID.Name = "txtDesgID";
            this.txtDesgID.Size = new System.Drawing.Size(14, 19);
            this.txtDesgID.TabIndex = 0;
            this.txtDesgID.Visible = false;
            // 
            // txtDeductionID
            // 
            this.txtDeductionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeductionID.Location = new System.Drawing.Point(708, 63);
            this.txtDeductionID.Name = "txtDeductionID";
            this.txtDeductionID.Size = new System.Drawing.Size(14, 19);
            this.txtDeductionID.TabIndex = 0;
            this.txtDeductionID.Visible = false;
            // 
            // dgvRecoveries
            // 
            this.dgvRecoveries.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecoveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecoveries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tid,
            this.col_eid,
            this.col_ename,
            this.col_desgid,
            this.col_edate,
            this.col_emon,
            this.col_amt,
            this.col_type});
            this.dgvRecoveries.Location = new System.Drawing.Point(21, 63);
            this.dgvRecoveries.Name = "dgvRecoveries";
            this.dgvRecoveries.Size = new System.Drawing.Size(685, 302);
            this.dgvRecoveries.TabIndex = 1;
            this.dgvRecoveries.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecoveries_CellEndEdit);
            // 
            // BtnEmp_Advance
            // 
            this.BtnEmp_Advance.BackColor = System.Drawing.Color.Transparent;
            this.BtnEmp_Advance.BaseColor = System.Drawing.Color.Ivory;
            this.BtnEmp_Advance.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnEmp_Advance.ButtonText = "Ok";
            this.BtnEmp_Advance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmp_Advance.ForeColor = System.Drawing.Color.Black;
            this.BtnEmp_Advance.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnEmp_Advance.Location = new System.Drawing.Point(631, 401);
            this.BtnEmp_Advance.Name = "BtnEmp_Advance";
            this.BtnEmp_Advance.Size = new System.Drawing.Size(75, 26);
            this.BtnEmp_Advance.TabIndex = 41;
            this.BtnEmp_Advance.Click += new System.EventHandler(this.BtnEmp_Advance_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Month : ";
            // 
            // txtAmt
            // 
            this.txtAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmt.Location = new System.Drawing.Point(606, 368);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(100, 21);
            this.txtAmt.TabIndex = 0;
            this.txtAmt.Text = "0";
            this.txtAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DTP_MON
            // 
            this.DTP_MON.CustomFormat = "MMMM/ yyyy";
            this.DTP_MON.Enabled = false;
            this.DTP_MON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_MON.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_MON.Location = new System.Drawing.Point(117, 37);
            this.DTP_MON.Name = "DTP_MON";
            this.DTP_MON.Size = new System.Drawing.Size(128, 20);
            this.DTP_MON.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(18, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 11);
            this.label3.TabIndex = 43;
            this.label3.Text = "Make the changes and click on OK to implement in salary sheet";
            // 
            // col_tid
            // 
            this.col_tid.DataPropertyName = "tid";
            this.col_tid.HeaderText = "TID";
            this.col_tid.Name = "col_tid";
            this.col_tid.Visible = false;
            // 
            // col_eid
            // 
            this.col_eid.DataPropertyName = "eid";
            this.col_eid.HeaderText = "Emp Code";
            this.col_eid.Name = "col_eid";
            this.col_eid.Visible = false;
            // 
            // col_ename
            // 
            this.col_ename.DataPropertyName = "ename";
            this.col_ename.HeaderText = "Emp Name";
            this.col_ename.Name = "col_ename";
            this.col_ename.Visible = false;
            // 
            // col_desgid
            // 
            this.col_desgid.DataPropertyName = "desgid";
            this.col_desgid.HeaderText = "DesgID";
            this.col_desgid.Name = "col_desgid";
            this.col_desgid.Visible = false;
            // 
            // col_edate
            // 
            this.col_edate.DataPropertyName = "edate";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.col_edate.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_edate.HeaderText = "Date";
            this.col_edate.Name = "col_edate";
            this.col_edate.ReadOnly = true;
            // 
            // col_emon
            // 
            this.col_emon.DataPropertyName = "emon";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.col_emon.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_emon.HeaderText = "Month";
            this.col_emon.Name = "col_emon";
            this.col_emon.ReadOnly = true;
            // 
            // col_amt
            // 
            this.col_amt.DataPropertyName = "amt";
            this.col_amt.HeaderText = "Recover";
            this.col_amt.Name = "col_amt";
            // 
            // col_type
            // 
            this.col_type.DataPropertyName = "type";
            this.col_type.HeaderText = "Recovery";
            this.col_type.Name = "col_type";
            this.col_type.Visible = false;
            // 
            // frmALKF_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 437);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DTP_MON);
            this.Controls.Add(this.BtnEmp_Advance);
            this.Controls.Add(this.dgvRecoveries);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtDeductionID);
            this.Controls.Add(this.txtAmt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDesgID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmALKF_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recovery Details";
            this.Load += new System.EventHandler(this.frmALKF_Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecoveries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtEmpName;
        private System.Windows.Forms.Label txtDesgID;
        private System.Windows.Forms.Label txtDeductionID;
        private System.Windows.Forms.DataGridView dgvRecoveries;
        public EDPComponent.VistaButton BtnEmp_Advance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtAmt;
        public System.Windows.Forms.DateTimePicker DTP_MON;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_eid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ename;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desgid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_edate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_emon;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_type;
        private System.Windows.Forms.Label label3;
    }
}