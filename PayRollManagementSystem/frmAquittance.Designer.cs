namespace PayRollManagementSystem
{
    partial class frmAquittance
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
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.lblmonth = new System.Windows.Forms.Label();
            this.cmbsession = new System.Windows.Forms.ComboBox();
            this.lblsession = new System.Windows.Forms.Label();
            this.cmbsalstruc = new System.Windows.Forms.ComboBox();
            this.lblsalstruc = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbmonth);
            this.panel1.Controls.Add(this.lblmonth);
            this.panel1.Controls.Add(this.cmbsession);
            this.panel1.Controls.Add(this.lblsession);
            this.panel1.Controls.Add(this.cmbsalstruc);
            this.panel1.Controls.Add(this.lblsalstruc);
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 473);
            this.panel1.TabIndex = 42;
            // 
            // cmbmonth
            // 
            this.cmbmonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmonth.FormattingEnabled = true;
            this.cmbmonth.Items.AddRange(new object[] {
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December",
            "January",
            "February",
            "March",
            "April"});
            this.cmbmonth.Location = new System.Drawing.Point(341, 25);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(125, 21);
            this.cmbmonth.TabIndex = 292;
            // 
            // lblmonth
            // 
            this.lblmonth.AutoSize = true;
            this.lblmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmonth.Location = new System.Drawing.Point(338, 7);
            this.lblmonth.Name = "lblmonth";
            this.lblmonth.Size = new System.Drawing.Size(47, 15);
            this.lblmonth.TabIndex = 291;
            this.lblmonth.Text = "Month";
            this.lblmonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbsession
            // 
            this.cmbsession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsession.FormattingEnabled = true;
            this.cmbsession.Location = new System.Drawing.Point(210, 25);
            this.cmbsession.Name = "cmbsession";
            this.cmbsession.Size = new System.Drawing.Size(125, 21);
            this.cmbsession.TabIndex = 290;
            // 
            // lblsession
            // 
            this.lblsession.AutoSize = true;
            this.lblsession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsession.Location = new System.Drawing.Point(207, 7);
            this.lblsession.Name = "lblsession";
            this.lblsession.Size = new System.Drawing.Size(58, 15);
            this.lblsession.TabIndex = 289;
            this.lblsession.Text = "Session";
            // 
            // cmbsalstruc
            // 
            this.cmbsalstruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsalstruc.FormattingEnabled = true;
            this.cmbsalstruc.Location = new System.Drawing.Point(11, 25);
            this.cmbsalstruc.Name = "cmbsalstruc";
            this.cmbsalstruc.Size = new System.Drawing.Size(194, 21);
            this.cmbsalstruc.TabIndex = 288;
            this.cmbsalstruc.SelectedIndexChanged += new System.EventHandler(this.cmbsalstruc_SelectedIndexChanged);
            this.cmbsalstruc.DropDown += new System.EventHandler(this.cmbsalstruc_DropDown);
            // 
            // lblsalstruc
            // 
            this.lblsalstruc.AutoSize = true;
            this.lblsalstruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsalstruc.Location = new System.Drawing.Point(8, 7);
            this.lblsalstruc.Name = "lblsalstruc";
            this.lblsalstruc.Size = new System.Drawing.Size(90, 15);
            this.lblsalstruc.TabIndex = 287;
            this.lblsalstruc.Text = "Sal Structure";
            // 
            // frmAquittance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 505);
            this.Controls.Add(this.panel1);
            this.HeaderText = "Aquittance";
            this.Name = "frmAquittance";
            this.Load += new System.EventHandler(this.frmAquittance_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.Label lblmonth;
        private System.Windows.Forms.ComboBox cmbsession;
        private System.Windows.Forms.Label lblsession;
        private System.Windows.Forms.ComboBox cmbsalstruc;
        private System.Windows.Forms.Label lblsalstruc;
    }
}