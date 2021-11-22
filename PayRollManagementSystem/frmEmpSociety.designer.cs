namespace PayRollManagementSystem
{
    partial class frmEmpSociety
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpSociety));
            this.LblCompany = new System.Windows.Forms.Label();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.BtnEmp_Loan = new EDPComponent.VistaButton();
            this.btnClear_Loan = new EDPComponent.VistaButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtmMonthSelect = new System.Windows.Forms.DateTimePicker();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.societyemi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opn_bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curr_bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acc_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.SuspendLayout();
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(68, 20);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 10;
            this.LblCompany.Text = "Company";
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(141, 12);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(356, 21);
            this.CmbCompany.TabIndex = 11;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(71, 47);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 12;
            this.LblLocation.Text = "Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(141, 39);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(356, 21);
            this.cmbLocation.TabIndex = 13;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // BtnEmp_Loan
            // 
            this.BtnEmp_Loan.BackColor = System.Drawing.Color.Transparent;
            this.BtnEmp_Loan.BaseColor = System.Drawing.Color.Ivory;
            this.BtnEmp_Loan.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnEmp_Loan.ButtonText = "Save";
            this.BtnEmp_Loan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmp_Loan.ForeColor = System.Drawing.Color.Black;
            this.BtnEmp_Loan.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnEmp_Loan.Location = new System.Drawing.Point(679, 7);
            this.BtnEmp_Loan.Name = "BtnEmp_Loan";
            this.BtnEmp_Loan.Size = new System.Drawing.Size(87, 26);
            this.BtnEmp_Loan.TabIndex = 15;
            this.BtnEmp_Loan.Click += new System.EventHandler(this.BtnEmp_Loan_Click);
            // 
            // btnClear_Loan
            // 
            this.btnClear_Loan.BackColor = System.Drawing.Color.Transparent;
            this.btnClear_Loan.BaseColor = System.Drawing.Color.Ivory;
            this.btnClear_Loan.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClear_Loan.ButtonText = "Close";
            this.btnClear_Loan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear_Loan.ForeColor = System.Drawing.Color.Black;
            this.btnClear_Loan.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClear_Loan.Location = new System.Drawing.Point(772, 7);
            this.btnClear_Loan.Name = "btnClear_Loan";
            this.btnClear_Loan.Size = new System.Drawing.Size(87, 26);
            this.btnClear_Loan.TabIndex = 16;
            this.btnClear_Loan.Click += new System.EventHandler(this.btnClear_Loan_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtmMonthSelect);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbCompany);
            this.panel1.Controls.Add(this.LblCompany);
            this.panel1.Controls.Add(this.LblLocation);
            this.panel1.Controls.Add(this.cmbLocation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 93);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnEmp_Loan);
            this.panel2.Controls.Add(this.btnClear_Loan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 417);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(871, 45);
            this.panel2.TabIndex = 17;
            // 
            // dgv_show
            // 
            this.dgv_show.AllowUserToAddRows = false;
            this.dgv_show.AllowUserToDeleteRows = false;
            this.dgv_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.EmployeeName,
            this.societyemi,
            this.opn_bal,
            this.curr_bal,
            this.acc_no});
            this.dgv_show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_show.Location = new System.Drawing.Point(0, 93);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.RowHeadersVisible = false;
            this.dgv_show.Size = new System.Drawing.Size(871, 324);
            this.dgv_show.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(529, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Effective Date";
            // 
            // dtmMonthSelect
            // 
            this.dtmMonthSelect.Location = new System.Drawing.Point(606, 14);
            this.dtmMonthSelect.Name = "dtmMonthSelect";
            this.dtmMonthSelect.Size = new System.Drawing.Size(200, 20);
            this.dtmMonthSelect.TabIndex = 312;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 70F;
            this.ID.HeaderText = " ID";
            this.ID.Name = "ID";
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "ename";
            this.EmployeeName.FillWeight = 140F;
            this.EmployeeName.HeaderText = "Employee Name";
            this.EmployeeName.Name = "EmployeeName";
            // 
            // societyemi
            // 
            this.societyemi.DataPropertyName = "societyemi";
            this.societyemi.FillWeight = 70F;
            this.societyemi.HeaderText = "society emi";
            this.societyemi.Name = "societyemi";
            // 
            // opn_bal
            // 
            this.opn_bal.DataPropertyName = "opn_bal";
            this.opn_bal.HeaderText = "opening balance";
            this.opn_bal.Name = "opn_bal";
            // 
            // curr_bal
            // 
            this.curr_bal.DataPropertyName = "curr_bal";
            this.curr_bal.HeaderText = "current balance";
            this.curr_bal.Name = "curr_bal";
            // 
            // acc_no
            // 
            this.acc_no.DataPropertyName = "acc_no";
            this.acc_no.HeaderText = "Account No.";
            this.acc_no.Name = "acc_no";
            // 
            // frmEmpSociety
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 462);
            this.Controls.Add(this.dgv_show);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpSociety";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee wise Society";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblCompany;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblLocation;
        private EDPComponent.ComboDialog cmbLocation;
        private EDPComponent.VistaButton BtnEmp_Loan;
        private EDPComponent.VistaButton btnClear_Loan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtmMonthSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn societyemi;
        private System.Windows.Forms.DataGridViewTextBoxColumn opn_bal;
        private System.Windows.Forms.DataGridViewTextBoxColumn curr_bal;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_no;
    }
}