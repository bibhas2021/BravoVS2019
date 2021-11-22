namespace PayRollManagementSystem
{
    partial class frmOtherDeduction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtherDeduction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnclose_frm = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.dgvSalaryDeduction = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgSalaryEarning = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSearchEarn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSearchDeduction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryDeduction)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalaryEarning)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbcompany);
            this.panel1.Controls.Add(this.AttenDtTmPkr);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.cmbLocation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 70);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 297;
            this.label6.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(122, 7);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(474, 21);
            this.cmbcompany.TabIndex = 296;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(697, 8);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(143, 20);
            this.AttenDtTmPkr.TabIndex = 288;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(602, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 287;
            this.label21.Text = "For The Month of";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Location = new System.Drawing.Point(122, 34);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(718, 21);
            this.cmbLocation.TabIndex = 286;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 285;
            this.label2.Text = "Location";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnclose_frm);
            this.panel2.Controls.Add(this.btnSubmit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 57);
            this.panel2.TabIndex = 0;
            // 
            // btnclose_frm
            // 
            this.btnclose_frm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose_frm.BackColor = System.Drawing.Color.Transparent;
            this.btnclose_frm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose_frm.BackgroundImage")));
            this.btnclose_frm.ButtonText = "Close";
            this.btnclose_frm.Location = new System.Drawing.Point(959, 6);
            this.btnclose_frm.Name = "btnclose_frm";
            this.btnclose_frm.Size = new System.Drawing.Size(80, 31);
            this.btnclose_frm.TabIndex = 277;
            this.btnclose_frm.Click += new System.EventHandler(this.btnclose_frm_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(873, 6);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 31);
            this.btnSubmit.TabIndex = 276;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvSalaryDeduction
            // 
            this.dgvSalaryDeduction.AllowUserToAddRows = false;
            this.dgvSalaryDeduction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSalaryDeduction.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalaryDeduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalaryDeduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalaryDeduction.Location = new System.Drawing.Point(3, 3);
            this.dgvSalaryDeduction.Name = "dgvSalaryDeduction";
            this.dgvSalaryDeduction.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSalaryDeduction.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalaryDeduction.Size = new System.Drawing.Size(1050, 316);
            this.dgvSalaryDeduction.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1066, 379);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.dgSalaryEarning);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1058, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Earnings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgSalaryEarning
            // 
            this.dgSalaryEarning.AllowUserToAddRows = false;
            this.dgSalaryEarning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgSalaryEarning.BackgroundColor = System.Drawing.Color.White;
            this.dgSalaryEarning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSalaryEarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSalaryEarning.Location = new System.Drawing.Point(3, 3);
            this.dgSalaryEarning.Name = "dgSalaryEarning";
            this.dgSalaryEarning.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgSalaryEarning.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgSalaryEarning.Size = new System.Drawing.Size(1050, 316);
            this.dgSalaryEarning.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtSearchEarn);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 319);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1050, 29);
            this.panel3.TabIndex = 0;
            // 
            // txtSearchEarn
            // 
            this.txtSearchEarn.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSearchEarn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchEarn.Location = new System.Drawing.Point(121, 9);
            this.txtSearchEarn.Name = "txtSearchEarn";
            this.txtSearchEarn.Size = new System.Drawing.Size(615, 13);
            this.txtSearchEarn.TabIndex = 1;
            this.txtSearchEarn.TextChanged += new System.EventHandler(this.txtSearchEarn_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search by Employee";
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.dgvSalaryDeduction);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1058, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deduction";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtSearchDeduction);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 319);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1050, 29);
            this.panel4.TabIndex = 1;
            // 
            // txtSearchDeduction
            // 
            this.txtSearchDeduction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearchDeduction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchDeduction.Location = new System.Drawing.Point(121, 8);
            this.txtSearchDeduction.Name = "txtSearchDeduction";
            this.txtSearchDeduction.Size = new System.Drawing.Size(615, 13);
            this.txtSearchDeduction.TabIndex = 1;
            this.txtSearchDeduction.TextChanged += new System.EventHandler(this.txtSearchDeduction_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search by Employee";
            // 
            // frmOtherDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 506);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOtherDeduction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Deduction";
            this.Load += new System.EventHandler(this.frmOtherDeduction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryDeduction)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSalaryEarning)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.DataGridView dgvSalaryDeduction;
        private EDPComponent.VistaButton btnclose_frm;
        private EDPComponent.VistaButton btnSubmit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgSalaryEarning;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtSearchEarn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtSearchDeduction;
        private System.Windows.Forms.Label label3;
    }
}