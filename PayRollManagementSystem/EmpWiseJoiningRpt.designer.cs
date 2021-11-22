namespace PayRollManagementSystem
{
    partial class EmpWiseJoiningRpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpWiseJoiningRpt));
            this.CmbSession = new System.Windows.Forms.ComboBox();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.BtnEmpJoin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbID = new System.Windows.Forms.RadioButton();
            this.rdbName = new System.Windows.Forms.RadioButton();
            this.rdbLocation = new System.Windows.Forms.RadioButton();
            this.rdbJoining_Date = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.frmdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.chkallloc = new System.Windows.Forms.CheckBox();
            this.butselloc = new System.Windows.Forms.Button();
            this.dgvloc = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblloc = new System.Windows.Forms.Label();
            this.cmblocation = new EDPComponent.ComboDialog();
            this.chkYr = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvloc)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbSession
            // 
            this.CmbSession.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSession.FormattingEnabled = true;
            this.CmbSession.Location = new System.Drawing.Point(171, 34);
            this.CmbSession.Margin = new System.Windows.Forms.Padding(4);
            this.CmbSession.Name = "CmbSession";
            this.CmbSession.Size = new System.Drawing.Size(176, 24);
            this.CmbSession.TabIndex = 0;
            this.CmbSession.SelectedIndexChanged += new System.EventHandler(this.CmbSession_SelectedIndexChanged);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(171, 66);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(497, 21);
            this.cmbcompany.TabIndex = 293;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompany.Location = new System.Drawing.Point(44, 66);
            this.LblCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(73, 16);
            this.LblCompany.TabIndex = 294;
            this.LblCompany.Text = "Company";
            // 
            // BtnEmpJoin
            // 
            this.BtnEmpJoin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BtnEmpJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmpJoin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BtnEmpJoin.Location = new System.Drawing.Point(468, 261);
            this.BtnEmpJoin.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEmpJoin.Name = "BtnEmpJoin";
            this.BtnEmpJoin.Size = new System.Drawing.Size(200, 34);
            this.BtnEmpJoin.TabIndex = 295;
            this.BtnEmpJoin.Text = "Employee Wise Joining";
            this.BtnEmpJoin.UseVisualStyleBackColor = false;
            this.BtnEmpJoin.Click += new System.EventHandler(this.BtnEmpJoin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 196);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 296;
            this.label1.Text = "Order By";
            // 
            // rdbID
            // 
            this.rdbID.AutoSize = true;
            this.rdbID.Location = new System.Drawing.Point(171, 192);
            this.rdbID.Margin = new System.Windows.Forms.Padding(4);
            this.rdbID.Name = "rdbID";
            this.rdbID.Size = new System.Drawing.Size(39, 20);
            this.rdbID.TabIndex = 297;
            this.rdbID.Text = "ID";
            this.rdbID.UseVisualStyleBackColor = true;
            // 
            // rdbName
            // 
            this.rdbName.AutoSize = true;
            this.rdbName.Checked = true;
            this.rdbName.Location = new System.Drawing.Point(171, 220);
            this.rdbName.Margin = new System.Windows.Forms.Padding(4);
            this.rdbName.Name = "rdbName";
            this.rdbName.Size = new System.Drawing.Size(63, 20);
            this.rdbName.TabIndex = 298;
            this.rdbName.TabStop = true;
            this.rdbName.Text = "Name";
            this.rdbName.UseVisualStyleBackColor = true;
            // 
            // rdbLocation
            // 
            this.rdbLocation.AutoSize = true;
            this.rdbLocation.Location = new System.Drawing.Point(171, 249);
            this.rdbLocation.Margin = new System.Windows.Forms.Padding(4);
            this.rdbLocation.Name = "rdbLocation";
            this.rdbLocation.Size = new System.Drawing.Size(77, 20);
            this.rdbLocation.TabIndex = 299;
            this.rdbLocation.Text = "Location";
            this.rdbLocation.UseVisualStyleBackColor = true;
            // 
            // rdbJoining_Date
            // 
            this.rdbJoining_Date.AutoSize = true;
            this.rdbJoining_Date.Location = new System.Drawing.Point(171, 277);
            this.rdbJoining_Date.Margin = new System.Windows.Forms.Padding(4);
            this.rdbJoining_Date.Name = "rdbJoining_Date";
            this.rdbJoining_Date.Size = new System.Drawing.Size(101, 20);
            this.rdbJoining_Date.TabIndex = 301;
            this.rdbJoining_Date.Text = "Joining Date";
            this.rdbJoining_Date.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 306;
            this.label3.Text = "Session";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 307;
            this.label4.Text = "From Date";
            // 
            // frmdate
            // 
            this.frmdate.CustomFormat = "";
            this.frmdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.frmdate.Location = new System.Drawing.Point(171, 128);
            this.frmdate.Margin = new System.Windows.Forms.Padding(4);
            this.frmdate.Name = "frmdate";
            this.frmdate.Size = new System.Drawing.Size(176, 22);
            this.frmdate.TabIndex = 264;
            this.frmdate.ValueChanged += new System.EventHandler(this.frmdate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 308;
            this.label5.Text = "To Date";
            // 
            // todate
            // 
            this.todate.CustomFormat = "";
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.todate.Location = new System.Drawing.Point(171, 158);
            this.todate.Margin = new System.Windows.Forms.Padding(4);
            this.todate.MaxDate = new System.DateTime(2018, 3, 15, 0, 0, 0, 0);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(176, 22);
            this.todate.TabIndex = 309;
            this.todate.Value = new System.DateTime(2018, 3, 14, 0, 0, 0, 0);
            // 
            // chkallloc
            // 
            this.chkallloc.AutoSize = true;
            this.chkallloc.Location = new System.Drawing.Point(678, 97);
            this.chkallloc.Margin = new System.Windows.Forms.Padding(4);
            this.chkallloc.Name = "chkallloc";
            this.chkallloc.Size = new System.Drawing.Size(96, 20);
            this.chkallloc.TabIndex = 311;
            this.chkallloc.Text = "All Location";
            this.chkallloc.UseVisualStyleBackColor = true;
            this.chkallloc.CheckedChanged += new System.EventHandler(this.chkallloc_CheckedChanged);
            // 
            // butselloc
            // 
            this.butselloc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.butselloc.ForeColor = System.Drawing.Color.White;
            this.butselloc.Location = new System.Drawing.Point(468, 221);
            this.butselloc.Margin = new System.Windows.Forms.Padding(4);
            this.butselloc.Name = "butselloc";
            this.butselloc.Size = new System.Drawing.Size(200, 32);
            this.butselloc.TabIndex = 312;
            this.butselloc.Text = "Select Location";
            this.butselloc.UseVisualStyleBackColor = false;
            this.butselloc.Visible = false;
            this.butselloc.Click += new System.EventHandler(this.butselloc_Click);
            // 
            // dgvloc
            // 
            this.dgvloc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Location});
            this.dgvloc.Location = new System.Drawing.Point(560, 129);
            this.dgvloc.Margin = new System.Windows.Forms.Padding(4);
            this.dgvloc.Name = "dgvloc";
            this.dgvloc.Size = new System.Drawing.Size(108, 21);
            this.dgvloc.TabIndex = 10;
            this.dgvloc.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // lblloc
            // 
            this.lblloc.AutoSize = true;
            this.lblloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloc.Location = new System.Drawing.Point(44, 97);
            this.lblloc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblloc.Name = "lblloc";
            this.lblloc.Size = new System.Drawing.Size(67, 16);
            this.lblloc.TabIndex = 313;
            this.lblloc.Text = "Location";
            // 
            // cmblocation
            // 
            this.cmblocation.Connection = null;
            this.cmblocation.DialogResult = "";
            this.cmblocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.Location = new System.Drawing.Point(171, 95);
            this.cmblocation.LOVFlag = 0;
            this.cmblocation.Margin = new System.Windows.Forms.Padding(4);
            this.cmblocation.MaxCharLength = 500;
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.ReturnIndex = -1;
            this.cmblocation.ReturnValue = "";
            this.cmblocation.ReturnValue_3rd = "";
            this.cmblocation.ReturnValue_4th = "";
            this.cmblocation.Size = new System.Drawing.Size(497, 21);
            this.cmblocation.TabIndex = 314;
            this.cmblocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmblocation_DropDown_1);
            this.cmblocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmblocation_DropDown_1);
            // 
            // chkYr
            // 
            this.chkYr.AutoSize = true;
            this.chkYr.Location = new System.Drawing.Point(434, 160);
            this.chkYr.Margin = new System.Windows.Forms.Padding(4);
            this.chkYr.Name = "chkYr";
            this.chkYr.Size = new System.Drawing.Size(74, 20);
            this.chkYr.TabIndex = 311;
            this.chkYr.Text = "All Year";
            this.chkYr.UseVisualStyleBackColor = true;
            this.chkYr.CheckedChanged += new System.EventHandler(this.chkallloc_CheckedChanged);
            // 
            // EmpWiseJoiningRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 344);
            this.Controls.Add(this.cmblocation);
            this.Controls.Add(this.lblloc);
            this.Controls.Add(this.dgvloc);
            this.Controls.Add(this.butselloc);
            this.Controls.Add(this.chkYr);
            this.Controls.Add(this.chkallloc);
            this.Controls.Add(this.todate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.frmdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdbJoining_Date);
            this.Controls.Add(this.rdbLocation);
            this.Controls.Add(this.rdbName);
            this.Controls.Add(this.rdbID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnEmpJoin);
            this.Controls.Add(this.CmbSession);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.LblCompany);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "EmpWiseJoiningRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Joining Report";
            this.Load += new System.EventHandler(this.EmpWiseJoining_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvloc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbSession;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Button BtnEmpJoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbID;
        private System.Windows.Forms.RadioButton rdbName;
        private System.Windows.Forms.RadioButton rdbLocation;
        private System.Windows.Forms.RadioButton rdbJoining_Date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker frmdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.CheckBox chkallloc;
        private System.Windows.Forms.Button butselloc;
        private System.Windows.Forms.DataGridView dgvloc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.Label lblloc;
        private EDPComponent.ComboDialog cmblocation;
        private System.Windows.Forms.CheckBox chkYr;
    }
}