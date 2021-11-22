namespace PayRollManagementSystem
{
    partial class frm_salary_print_setup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.redlocation = new System.Windows.Forms.RadioButton();
            this.dgvquery = new System.Windows.Forms.DataGridView();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAcountNo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DesignationName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Basic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DaysPresent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TotalDays = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnnentry = new EDPComponent.VistaButton();
            this.btnsave = new EDPComponent.VistaButton();
            this.btnclose = new EDPComponent.VistaButton();
            this.btndelete = new EDPComponent.VistaButton();
            this.cmblocation = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvquery)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.redlocation);
            this.panel1.Controls.Add(this.dgvquery);
            this.panel1.Controls.Add(this.btnnentry);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.cmblocation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(7, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 363);
            this.panel1.TabIndex = 0;
            // 
            // redlocation
            // 
            this.redlocation.AutoSize = true;
            this.redlocation.Checked = true;
            this.redlocation.Location = new System.Drawing.Point(71, 51);
            this.redlocation.Name = "redlocation";
            this.redlocation.Size = new System.Drawing.Size(93, 17);
            this.redlocation.TabIndex = 288;
            this.redlocation.TabStop = true;
            this.redlocation.Text = "Location Wise";
            this.redlocation.UseVisualStyleBackColor = true;
            this.redlocation.Visible = false;
            // 
            // dgvquery
            // 
            this.dgvquery.AllowUserToAddRows = false;
            this.dgvquery.AllowUserToDeleteRows = false;
            this.dgvquery.AllowUserToResizeColumns = false;
            this.dgvquery.AllowUserToResizeRows = false;
            this.dgvquery.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvquery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvquery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Location,
            this.BankAcountNo,
            this.DesignationName,
            this.Basic,
            this.DaysPresent,
            this.OT,
            this.TotalDays});
            this.dgvquery.Location = new System.Drawing.Point(9, 80);
            this.dgvquery.MultiSelect = false;
            this.dgvquery.Name = "dgvquery";
            this.dgvquery.ReadOnly = true;
            this.dgvquery.RowHeadersVisible = false;
            this.dgvquery.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvquery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvquery.Size = new System.Drawing.Size(538, 278);
            this.dgvquery.TabIndex = 286;
            this.dgvquery.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvquery_CellValueChanged);
            this.dgvquery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvquery_CellContentClick);
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // BankAcountNo
            // 
            this.BankAcountNo.DataPropertyName = "BankAcountNo";
            this.BankAcountNo.HeaderText = "BankAcountNo";
            this.BankAcountNo.Name = "BankAcountNo";
            this.BankAcountNo.ReadOnly = true;
            // 
            // DesignationName
            // 
            this.DesignationName.DataPropertyName = "DesignationName";
            this.DesignationName.HeaderText = "DesignationName";
            this.DesignationName.Name = "DesignationName";
            this.DesignationName.ReadOnly = true;
            // 
            // Basic
            // 
            this.Basic.DataPropertyName = "Basic";
            this.Basic.HeaderText = "Basic";
            this.Basic.Name = "Basic";
            this.Basic.ReadOnly = true;
            // 
            // DaysPresent
            // 
            this.DaysPresent.DataPropertyName = "DaysPresent";
            this.DaysPresent.HeaderText = "WDays";
            this.DaysPresent.Name = "DaysPresent";
            this.DaysPresent.ReadOnly = true;
            // 
            // OT
            // 
            this.OT.DataPropertyName = "OT";
            this.OT.HeaderText = "OT";
            this.OT.Name = "OT";
            this.OT.ReadOnly = true;
            // 
            // TotalDays
            // 
            this.TotalDays.DataPropertyName = "TotalDays";
            this.TotalDays.HeaderText = "TotWdays";
            this.TotalDays.Name = "TotalDays";
            this.TotalDays.ReadOnly = true;
            // 
            // btnnentry
            // 
            this.btnnentry.BackColor = System.Drawing.Color.Transparent;
            this.btnnentry.BaseColor = System.Drawing.Color.SlateGray;
            this.btnnentry.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnnentry.ButtonText = "New Entry";
            this.btnnentry.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnentry.GlowColor = System.Drawing.Color.Aqua;
            this.btnnentry.Location = new System.Drawing.Point(189, 45);
            this.btnnentry.Name = "btnnentry";
            this.btnnentry.Size = new System.Drawing.Size(80, 29);
            this.btnnentry.TabIndex = 285;
            this.btnnentry.Visible = false;
            this.btnnentry.Click += new System.EventHandler(this.btnnentry_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.BaseColor = System.Drawing.Color.SlateGray;
            this.btnsave.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.ButtonText = "Save";
            this.btnsave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.GlowColor = System.Drawing.Color.Aqua;
            this.btnsave.Location = new System.Drawing.Point(357, 18);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(78, 29);
            this.btnsave.TabIndex = 284;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BaseColor = System.Drawing.Color.SlateGray;
            this.btnclose.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnclose.ButtonText = "Close";
            this.btnclose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.GlowColor = System.Drawing.Color.Aqua;
            this.btnclose.Location = new System.Drawing.Point(441, 18);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(78, 29);
            this.btnclose.TabIndex = 283;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.BaseColor = System.Drawing.Color.SlateGray;
            this.btndelete.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btndelete.ButtonText = "Delete";
            this.btndelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.GlowColor = System.Drawing.Color.Aqua;
            this.btndelete.Location = new System.Drawing.Point(275, 45);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(78, 29);
            this.btndelete.TabIndex = 282;
            this.btndelete.Visible = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // cmblocation
            // 
            this.cmblocation.Connection = null;
            this.cmblocation.DialogResult = "";
            this.cmblocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.Location = new System.Drawing.Point(71, 18);
            this.cmblocation.LOVFlag = 0;
            this.cmblocation.MaxCharLength = 500;
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.ReturnIndex = -1;
            this.cmblocation.ReturnValue = "";
            this.cmblocation.ReturnValue_3rd = "";
            this.cmblocation.ReturnValue_4th = "";
            this.cmblocation.Size = new System.Drawing.Size(187, 21);
            this.cmblocation.TabIndex = 4;
            this.cmblocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmblocation_DropDown);
            this.cmblocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmblocation_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Location";
            // 
            // frm_salary_print_setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 396);
            this.Controls.Add(this.panel1);
            this.Name = "frm_salary_print_setup";
            this.Load += new System.EventHandler(this.frm_salary_print_setup_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvquery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private EDPComponent.ComboDialog cmblocation;
        private System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton btnnentry;
        private EDPComponent.VistaButton btnsave;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btndelete;
        private System.Windows.Forms.RadioButton redlocation;
        private System.Windows.Forms.DataGridView dgvquery;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BankAcountNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DesignationName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Basic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DaysPresent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TotalDays;
    }
}