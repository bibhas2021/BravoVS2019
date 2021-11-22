namespace PayRollManagementSystem
{
    partial class FRMCOMP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMCOMP));
            this.LblSession = new System.Windows.Forms.Label();
            this.CmbSession = new System.Windows.Forms.ComboBox();
            this.LblCompany = new System.Windows.Forms.Label();
            this.LblLocation = new System.Windows.Forms.Label();
            this.LblEmployee = new System.Windows.Forms.Label();
            this.CmbEmployee = new System.Windows.Forms.ComboBox();
            this.BtnReport = new System.Windows.Forms.Button();
            this.CmbCompany_id = new System.Windows.Forms.ComboBox();
            this.CmbLocation_id = new System.Windows.Forms.ComboBox();
            this.CmbEmployee_id = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.CmbLocation = new EDPComponent.ComboDialog();
            this.SuspendLayout();
            // 
            // LblSession
            // 
            this.LblSession.AutoSize = true;
            this.LblSession.Location = new System.Drawing.Point(30, 12);
            this.LblSession.Name = "LblSession";
            this.LblSession.Size = new System.Drawing.Size(44, 13);
            this.LblSession.TabIndex = 0;
            this.LblSession.Text = "Session";
            // 
            // CmbSession
            // 
            this.CmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSession.ForeColor = System.Drawing.Color.Black;
            this.CmbSession.FormattingEnabled = true;
            this.CmbSession.Location = new System.Drawing.Point(107, 12);
            this.CmbSession.Name = "CmbSession";
            this.CmbSession.Size = new System.Drawing.Size(121, 21);
            this.CmbSession.TabIndex = 1;
            this.CmbSession.SelectedIndexChanged += new System.EventHandler(this.CmbSession_SelectedIndexChanged);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(30, 49);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 2;
            this.LblCompany.Text = "Company";
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(31, 77);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 4;
            this.LblLocation.Text = "Location";
            // 
            // LblEmployee
            // 
            this.LblEmployee.AutoSize = true;
            this.LblEmployee.Location = new System.Drawing.Point(33, 133);
            this.LblEmployee.Name = "LblEmployee";
            this.LblEmployee.Size = new System.Drawing.Size(53, 13);
            this.LblEmployee.TabIndex = 6;
            this.LblEmployee.Text = "Employee";
            this.LblEmployee.Visible = false;
            // 
            // CmbEmployee
            // 
            this.CmbEmployee.FormattingEnabled = true;
            this.CmbEmployee.Location = new System.Drawing.Point(107, 133);
            this.CmbEmployee.Name = "CmbEmployee";
            this.CmbEmployee.Size = new System.Drawing.Size(339, 21);
            this.CmbEmployee.TabIndex = 7;
            this.CmbEmployee.Visible = false;
            this.CmbEmployee.SelectedIndexChanged += new System.EventHandler(this.CmbEmployee_SelectedIndexChanged);
            // 
            // BtnReport
            // 
            this.BtnReport.Location = new System.Drawing.Point(349, 232);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(97, 29);
            this.BtnReport.TabIndex = 8;
            this.BtnReport.Text = "REPORT";
            this.BtnReport.UseVisualStyleBackColor = true;
            this.BtnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // CmbCompany_id
            // 
            this.CmbCompany_id.FormattingEnabled = true;
            this.CmbCompany_id.Location = new System.Drawing.Point(452, 49);
            this.CmbCompany_id.Name = "CmbCompany_id";
            this.CmbCompany_id.Size = new System.Drawing.Size(32, 21);
            this.CmbCompany_id.TabIndex = 9;
            this.CmbCompany_id.Visible = false;
            // 
            // CmbLocation_id
            // 
            this.CmbLocation_id.FormattingEnabled = true;
            this.CmbLocation_id.Location = new System.Drawing.Point(452, 72);
            this.CmbLocation_id.Name = "CmbLocation_id";
            this.CmbLocation_id.Size = new System.Drawing.Size(32, 21);
            this.CmbLocation_id.TabIndex = 10;
            this.CmbLocation_id.Visible = false;
            // 
            // CmbEmployee_id
            // 
            this.CmbEmployee_id.FormattingEnabled = true;
            this.CmbEmployee_id.Location = new System.Drawing.Point(452, 133);
            this.CmbEmployee_id.Name = "CmbEmployee_id";
            this.CmbEmployee_id.Size = new System.Drawing.Size(32, 21);
            this.CmbEmployee_id.TabIndex = 11;
            this.CmbEmployee_id.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(179, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 27);
            this.button1.TabIndex = 308;
            this.button1.Text = "Select Employee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(33, 183);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(144, 18);
            this.checkBox1.TabIndex = 307;
            this.checkBox1.Text = "Select All Employee";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(107, 44);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(339, 21);
            this.CmbCompany.TabIndex = 309;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            // 
            // CmbLocation
            // 
            this.CmbLocation.Connection = null;
            this.CmbLocation.DialogResult = "";
            this.CmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLocation.Location = new System.Drawing.Point(107, 72);
            this.CmbLocation.LOVFlag = 0;
            this.CmbLocation.MaxCharLength = 500;
            this.CmbLocation.Name = "CmbLocation";
            this.CmbLocation.ReturnIndex = -1;
            this.CmbLocation.ReturnValue = "";
            this.CmbLocation.ReturnValue_3rd = "";
            this.CmbLocation.ReturnValue_4th = "";
            this.CmbLocation.Size = new System.Drawing.Size(339, 21);
            this.CmbLocation.TabIndex = 310;
            this.CmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbLocation_DropDown);
            // 
            // FRMCOMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 286);
            this.Controls.Add(this.CmbLocation);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CmbEmployee_id);
            this.Controls.Add(this.CmbLocation_id);
            this.Controls.Add(this.CmbCompany_id);
            this.Controls.Add(this.BtnReport);
            this.Controls.Add(this.CmbEmployee);
            this.Controls.Add(this.LblEmployee);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.CmbSession);
            this.Controls.Add(this.LblSession);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMCOMP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Posting";
            this.Load += new System.EventHandler(this.FRMCOMP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSession;
        private System.Windows.Forms.ComboBox CmbSession;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.Label LblEmployee;
        private System.Windows.Forms.ComboBox CmbEmployee;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.ComboBox CmbCompany_id;
        private System.Windows.Forms.ComboBox CmbLocation_id;
        private System.Windows.Forms.ComboBox CmbEmployee_id;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private EDPComponent.ComboDialog CmbCompany;
        private EDPComponent.ComboDialog CmbLocation;
    }
}