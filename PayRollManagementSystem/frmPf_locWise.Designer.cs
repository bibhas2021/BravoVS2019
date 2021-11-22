namespace PayRollManagementSystem
{
    partial class frmPf_locWise
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPf_locWise));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContributeSave = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbPf = new System.Windows.Forms.RadioButton();
            this.rdbEsi = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLocation = new System.Windows.Forms.DataGridView();
            this.btnloc = new EDPComponent.VistaButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dgPfContribution = new System.Windows.Forms.DataGridView();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.CSlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cfull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cshort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGlcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPfContribution)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnContributeSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnContributeSave
            // 
            this.btnContributeSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContributeSave.BackColor = System.Drawing.Color.Black;
            this.btnContributeSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContributeSave.ForeColor = System.Drawing.Color.White;
            this.btnContributeSave.Location = new System.Drawing.Point(698, 5);
            this.btnContributeSave.Name = "btnContributeSave";
            this.btnContributeSave.Size = new System.Drawing.Size(75, 25);
            this.btnContributeSave.TabIndex = 69;
            this.btnContributeSave.Text = "Save";
            this.btnContributeSave.UseVisualStyleBackColor = false;
            this.btnContributeSave.Click += new System.EventHandler(this.btnContributeSave_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(113, 19);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(109, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Implementation Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbEsi);
            this.groupBox1.Controls.Add(this.rdbPf);
            this.groupBox1.Location = new System.Drawing.Point(6, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(105, 27);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // rdbPf
            // 
            this.rdbPf.AutoSize = true;
            this.rdbPf.Checked = true;
            this.rdbPf.Location = new System.Drawing.Point(6, 8);
            this.rdbPf.Name = "rdbPf";
            this.rdbPf.Size = new System.Drawing.Size(38, 17);
            this.rdbPf.TabIndex = 0;
            this.rdbPf.Text = "PF";
            this.rdbPf.UseVisualStyleBackColor = true;
            // 
            // rdbEsi
            // 
            this.rdbEsi.AutoSize = true;
            this.rdbEsi.Location = new System.Drawing.Point(50, 8);
            this.rdbEsi.Name = "rdbEsi";
            this.rdbEsi.Size = new System.Drawing.Size(42, 17);
            this.rdbEsi.TabIndex = 0;
            this.rdbEsi.Text = "ESI";
            this.rdbEsi.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLocation);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 429);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saved Locations";
            // 
            // dgvLocation
            // 
            this.dgvLocation.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocation.Location = new System.Drawing.Point(3, 16);
            this.dgvLocation.Name = "dgvLocation";
            this.dgvLocation.Size = new System.Drawing.Size(241, 410);
            this.dgvLocation.TabIndex = 0;
            // 
            // btnloc
            // 
            this.btnloc.BackColor = System.Drawing.Color.Transparent;
            this.btnloc.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnloc.ButtonText = "Select Location";
            this.btnloc.CornerRadius = 4;
            this.btnloc.ImageSize = new System.Drawing.Size(16, 16);
            this.btnloc.Location = new System.Drawing.Point(325, 73);
            this.btnloc.Name = "btnloc";
            this.btnloc.Size = new System.Drawing.Size(132, 28);
            this.btnloc.TabIndex = 297;
            this.btnloc.Click += new System.EventHandler(this.btnloc_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cmbcompany);
            this.panel2.Controls.Add(this.lstLog);
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Controls.Add(this.btnloc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(247, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 108);
            this.panel2.TabIndex = 298;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.dgPfContribution);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(247, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(534, 321);
            this.groupBox4.TabIndex = 299;
            this.groupBox4.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(52, -2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 16);
            this.label12.TabIndex = 75;
            this.label12.Text = "PF Contribution";
            // 
            // dgPfContribution
            // 
            this.dgPfContribution.AllowUserToAddRows = false;
            this.dgPfContribution.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgPfContribution.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPfContribution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPfContribution.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPfContribution.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPfContribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPfContribution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CSlNo,
            this.Cfull,
            this.Cshort,
            this.CAmount,
            this.CGlcode});
            this.dgPfContribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPfContribution.Location = new System.Drawing.Point(3, 16);
            this.dgPfContribution.MultiSelect = false;
            this.dgPfContribution.Name = "dgPfContribution";
            this.dgPfContribution.RowHeadersVisible = false;
            this.dgPfContribution.Size = new System.Drawing.Size(528, 302);
            this.dgPfContribution.TabIndex = 74;
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(469, 0);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(65, 108);
            this.lstLog.TabIndex = 298;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 300;
            this.label6.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(101, 49);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(356, 21);
            this.cmbcompany.TabIndex = 299;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // CSlNo
            // 
            this.CSlNo.DataPropertyName = "SlNo";
            this.CSlNo.HeaderText = "Sl No.";
            this.CSlNo.Name = "CSlNo";
            this.CSlNo.Visible = false;
            // 
            // Cfull
            // 
            this.Cfull.DataPropertyName = "SalaryHead_Full";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cfull.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cfull.HeaderText = "Contribution Head ( Full Name )";
            this.Cfull.MinimumWidth = 196;
            this.Cfull.Name = "Cfull";
            // 
            // Cshort
            // 
            this.Cshort.DataPropertyName = "SalaryHead_Short";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cshort.DefaultCellStyle = dataGridViewCellStyle4;
            this.Cshort.HeaderText = "Short Name";
            this.Cshort.MinimumWidth = 90;
            this.Cshort.Name = "Cshort";
            this.Cshort.Visible = false;
            // 
            // CAmount
            // 
            this.CAmount.DataPropertyName = "Amount";
            this.CAmount.HeaderText = "Percentage(%)";
            this.CAmount.Name = "CAmount";
            // 
            // CGlcode
            // 
            this.CGlcode.DataPropertyName = "Glcode";
            this.CGlcode.HeaderText = "glcode";
            this.CGlcode.Name = "CGlcode";
            this.CGlcode.Visible = false;
            // 
            // frmPf_locWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(781, 464);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPf_locWise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location Wise PF Contribution";
            this.Load += new System.EventHandler(this.frmPf_locWise_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPfContribution)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnContributeSave;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbEsi;
        private System.Windows.Forms.RadioButton rdbPf;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvLocation;
        private EDPComponent.VistaButton btnloc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgPfContribution;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cfull;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cshort;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGlcode;

    }
}