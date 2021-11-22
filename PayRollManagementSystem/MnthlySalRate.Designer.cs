namespace PayRollManagementSystem
{
    partial class MnthlySalRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MnthlySalRate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvmnthsalrate = new System.Windows.Forms.DataGridView();
            this.btnfilter = new EDPComponent.VistaButton();
            this.lblsearch = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.cmbmonth = new System.Windows.Forms.ComboBox();
            this.lblmonth = new System.Windows.Forms.Label();
            this.cmbsession = new System.Windows.Forms.ComboBox();
            this.lblsession = new System.Windows.Forms.Label();
            this.cmbsalstruc = new System.Windows.Forms.ComboBox();
            this.lblsalstruc = new System.Windows.Forms.Label();
            this.pgmsr = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmnthsalrate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pgmsr);
            this.panel1.Controls.Add(this.dgvmnthsalrate);
            this.panel1.Controls.Add(this.btnfilter);
            this.panel1.Controls.Add(this.lblsearch);
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Controls.Add(this.cmbmonth);
            this.panel1.Controls.Add(this.lblmonth);
            this.panel1.Controls.Add(this.cmbsession);
            this.panel1.Controls.Add(this.lblsession);
            this.panel1.Controls.Add(this.cmbsalstruc);
            this.panel1.Controls.Add(this.lblsalstruc);
            this.panel1.Location = new System.Drawing.Point(5, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 473);
            this.panel1.TabIndex = 42;
            // 
            // dgvmnthsalrate
            // 
            this.dgvmnthsalrate.AllowUserToAddRows = false;
            this.dgvmnthsalrate.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmnthsalrate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvmnthsalrate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmnthsalrate.Location = new System.Drawing.Point(9, 55);
            this.dgvmnthsalrate.Name = "dgvmnthsalrate";
            this.dgvmnthsalrate.Size = new System.Drawing.Size(730, 336);
            this.dgvmnthsalrate.TabIndex = 286;
            // 
            // btnfilter
            // 
            this.btnfilter.BackColor = System.Drawing.Color.Transparent;
            this.btnfilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnfilter.BackgroundImage")));
            this.btnfilter.ButtonText = "Filter";
            this.btnfilter.Location = new System.Drawing.Point(652, 20);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(87, 29);
            this.btnfilter.TabIndex = 285;
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearch.Location = new System.Drawing.Point(464, 10);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(92, 15);
            this.lblsearch.TabIndex = 7;
            this.lblsearch.Text = "Quick Search";
            this.lblsearch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(467, 28);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(172, 20);
            this.txtsearch.TabIndex = 6;
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
            this.cmbmonth.Location = new System.Drawing.Point(339, 28);
            this.cmbmonth.Name = "cmbmonth";
            this.cmbmonth.Size = new System.Drawing.Size(125, 21);
            this.cmbmonth.TabIndex = 5;
            this.cmbmonth.SelectedIndexChanged += new System.EventHandler(this.cmbmonth_SelectedIndexChanged);
            // 
            // lblmonth
            // 
            this.lblmonth.AutoSize = true;
            this.lblmonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmonth.Location = new System.Drawing.Point(336, 10);
            this.lblmonth.Name = "lblmonth";
            this.lblmonth.Size = new System.Drawing.Size(47, 15);
            this.lblmonth.TabIndex = 4;
            this.lblmonth.Text = "Month";
            this.lblmonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbsession
            // 
            this.cmbsession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsession.FormattingEnabled = true;
            this.cmbsession.Location = new System.Drawing.Point(208, 28);
            this.cmbsession.Name = "cmbsession";
            this.cmbsession.Size = new System.Drawing.Size(125, 21);
            this.cmbsession.TabIndex = 3;
            this.cmbsession.SelectedIndexChanged += new System.EventHandler(this.cmbsession_SelectedIndexChanged);
            // 
            // lblsession
            // 
            this.lblsession.AutoSize = true;
            this.lblsession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsession.Location = new System.Drawing.Point(205, 10);
            this.lblsession.Name = "lblsession";
            this.lblsession.Size = new System.Drawing.Size(58, 15);
            this.lblsession.TabIndex = 2;
            this.lblsession.Text = "Session";
            // 
            // cmbsalstruc
            // 
            this.cmbsalstruc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsalstruc.FormattingEnabled = true;
            this.cmbsalstruc.Location = new System.Drawing.Point(9, 28);
            this.cmbsalstruc.Name = "cmbsalstruc";
            this.cmbsalstruc.Size = new System.Drawing.Size(194, 21);
            this.cmbsalstruc.TabIndex = 1;
            this.cmbsalstruc.SelectedIndexChanged += new System.EventHandler(this.cmbsalstruc_SelectedIndexChanged);
            this.cmbsalstruc.DropDown += new System.EventHandler(this.cmbsalstruc_DropDown);
            // 
            // lblsalstruc
            // 
            this.lblsalstruc.AutoSize = true;
            this.lblsalstruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsalstruc.Location = new System.Drawing.Point(6, 10);
            this.lblsalstruc.Name = "lblsalstruc";
            this.lblsalstruc.Size = new System.Drawing.Size(90, 15);
            this.lblsalstruc.TabIndex = 0;
            this.lblsalstruc.Text = "Sal Structure";
            // 
            // pgmsr
            // 
            this.pgmsr.Location = new System.Drawing.Point(9, 185);
            this.pgmsr.Name = "pgmsr";
            this.pgmsr.Size = new System.Drawing.Size(730, 23);
            this.pgmsr.TabIndex = 43;
            this.pgmsr.Visible = false;
            // 
            // MnthlySalRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 505);
            this.Controls.Add(this.panel1);
            this.HeaderText = "Monthly Salary Rate";
            this.Name = "MnthlySalRate";
            this.Load += new System.EventHandler(this.MnthlySalRate_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmnthsalrate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblsalstruc;
        private System.Windows.Forms.ComboBox cmbsalstruc;
        private System.Windows.Forms.ComboBox cmbsession;
        private System.Windows.Forms.Label lblsession;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.ComboBox cmbmonth;
        private System.Windows.Forms.Label lblmonth;
        private EDPComponent.VistaButton btnfilter;
        private System.Windows.Forms.DataGridView dgvmnthsalrate;
        private System.Windows.Forms.ProgressBar pgmsr;
    }
}