namespace PayRollManagementSystem
{
    partial class frm_register_FORM_XII
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_register_FORM_XII));
            this.btnclient = new System.Windows.Forms.Button();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.LblLocation = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_ic_emp = new System.Windows.Forms.RadioButton();
            this.rdb_ic_loc = new System.Windows.Forms.RadioButton();
            this.rdb_ic_co = new System.Windows.Forms.RadioButton();
            this.btnicard_prev = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnclient
            // 
            this.btnclient.Location = new System.Drawing.Point(90, 63);
            this.btnclient.Name = "btnclient";
            this.btnclient.Size = new System.Drawing.Size(325, 26);
            this.btnclient.TabIndex = 315;
            this.btnclient.Text = "Select Employee";
            this.btnclient.UseVisualStyleBackColor = true;
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(90, 12);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(325, 21);
            this.CmbCompany.TabIndex = 316;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(19, 12);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 319;
            this.LblCompany.Text = "Company";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(90, 36);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(325, 21);
            this.cmbLocation.TabIndex = 317;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(19, 40);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 318;
            this.LblLocation.Text = "Location";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_ic_emp);
            this.groupBox1.Controls.Add(this.rdb_ic_loc);
            this.groupBox1.Controls.Add(this.rdb_ic_co);
            this.groupBox1.Location = new System.Drawing.Point(22, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 87);
            this.groupBox1.TabIndex = 320;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print icard";
            // 
            // rdb_ic_emp
            // 
            this.rdb_ic_emp.AutoSize = true;
            this.rdb_ic_emp.Checked = true;
            this.rdb_ic_emp.Location = new System.Drawing.Point(19, 62);
            this.rdb_ic_emp.Name = "rdb_ic_emp";
            this.rdb_ic_emp.Size = new System.Drawing.Size(119, 17);
            this.rdb_ic_emp.TabIndex = 4;
            this.rdb_ic_emp.TabStop = true;
            this.rdb_ic_emp.Text = "Individual Employee";
            this.rdb_ic_emp.UseVisualStyleBackColor = true;
            // 
            // rdb_ic_loc
            // 
            this.rdb_ic_loc.AutoSize = true;
            this.rdb_ic_loc.Location = new System.Drawing.Point(19, 41);
            this.rdb_ic_loc.Name = "rdb_ic_loc";
            this.rdb_ic_loc.Size = new System.Drawing.Size(90, 17);
            this.rdb_ic_loc.TabIndex = 4;
            this.rdb_ic_loc.Text = "Location wise";
            this.rdb_ic_loc.UseVisualStyleBackColor = true;
            // 
            // rdb_ic_co
            // 
            this.rdb_ic_co.AutoSize = true;
            this.rdb_ic_co.Location = new System.Drawing.Point(19, 18);
            this.rdb_ic_co.Name = "rdb_ic_co";
            this.rdb_ic_co.Size = new System.Drawing.Size(96, 17);
            this.rdb_ic_co.TabIndex = 4;
            this.rdb_ic_co.Text = "Company Wise";
            this.rdb_ic_co.UseVisualStyleBackColor = true;
            // 
            // btnicard_prev
            // 
            this.btnicard_prev.BackColor = System.Drawing.Color.Transparent;
            this.btnicard_prev.BaseColor = System.Drawing.Color.Ivory;
            this.btnicard_prev.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnicard_prev.ButtonText = "Employement Card";
            this.btnicard_prev.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnicard_prev.ForeColor = System.Drawing.Color.Black;
            this.btnicard_prev.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnicard_prev.Location = new System.Drawing.Point(213, 149);
            this.btnicard_prev.Name = "btnicard_prev";
            this.btnicard_prev.Size = new System.Drawing.Size(202, 30);
            this.btnicard_prev.TabIndex = 321;
            this.btnicard_prev.Click += new System.EventHandler(this.btnicard_prev_Click);
            // 
            // frm_register_FORM_XII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(449, 187);
            this.Controls.Add(this.btnicard_prev);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.btnclient);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_register_FORM_XII";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FORM XII";
            this.Load += new System.EventHandler(this.frm_register_FORM_XII_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclient;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblCompany;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_ic_emp;
        private System.Windows.Forms.RadioButton rdb_ic_loc;
        private System.Windows.Forms.RadioButton rdb_ic_co;
        private EDPComponent.VistaButton btnicard_prev;
    }
}