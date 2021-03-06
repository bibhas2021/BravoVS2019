namespace PayRollManagementSystem
{
    partial class frmSalMonthly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalMonthly));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnloc = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.rdbLocation = new System.Windows.Forms.RadioButton();
            this.rdbCompany = new System.Windows.Forms.RadioButton();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new EDPComponent.VistaButton();
            this.dgvSal = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSal)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnloc);
            this.panel1.Controls.Add(this.btnPreview);
            this.panel1.Controls.Add(this.rdbLocation);
            this.panel1.Controls.Add(this.rdbCompany);
            this.panel1.Controls.Add(this.CmbCompany);
            this.panel1.Controls.Add(this.LblCompany);
            this.panel1.Controls.Add(this.cmbClient);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbLocation);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.cmbYear);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 111);
            this.panel1.TabIndex = 1;
            // 
            // btnloc
            // 
            this.btnloc.BackColor = System.Drawing.Color.Transparent;
            this.btnloc.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnloc.ButtonText = "Select Location";
            this.btnloc.CornerRadius = 4;
            this.btnloc.ImageSize = new System.Drawing.Size(16, 16);
            this.btnloc.Location = new System.Drawing.Point(109, 58);
            this.btnloc.Name = "btnloc";
            this.btnloc.Size = new System.Drawing.Size(549, 28);
            this.btnloc.TabIndex = 331;
            this.btnloc.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(664, 71);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 330;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // rdbLocation
            // 
            this.rdbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdbLocation.AutoSize = true;
            this.rdbLocation.Location = new System.Drawing.Point(573, 13);
            this.rdbLocation.Name = "rdbLocation";
            this.rdbLocation.Size = new System.Drawing.Size(87, 17);
            this.rdbLocation.TabIndex = 329;
            this.rdbLocation.TabStop = true;
            this.rdbLocation.Text = "Loction Wise";
            this.rdbLocation.UseVisualStyleBackColor = true;
            // 
            // rdbCompany
            // 
            this.rdbCompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rdbCompany.AutoSize = true;
            this.rdbCompany.Location = new System.Drawing.Point(475, 14);
            this.rdbCompany.Name = "rdbCompany";
            this.rdbCompany.Size = new System.Drawing.Size(96, 17);
            this.rdbCompany.TabIndex = 329;
            this.rdbCompany.TabStop = true;
            this.rdbCompany.Text = "Company Wise";
            this.rdbCompany.UseVisualStyleBackColor = true;
            this.rdbCompany.CheckedChanged += new System.EventHandler(this.rdbCompany_CheckedChanged);
            // 
            // CmbCompany
            // 
            this.CmbCompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(109, 36);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(549, 21);
            this.CmbCompany.TabIndex = 328;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompany.Location = new System.Drawing.Point(16, 41);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(52, 14);
            this.LblCompany.TabIndex = 327;
            this.LblCompany.Text = "Company";
            // 
            // cmbClient
            // 
            this.cmbClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cmbClient.Enabled = false;
            this.cmbClient.ForeColor = System.Drawing.Color.Black;
            this.cmbClient.Location = new System.Drawing.Point(109, 81);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.ReadOnly = true;
            this.cmbClient.Size = new System.Drawing.Size(549, 20);
            this.cmbClient.TabIndex = 326;
            this.cmbClient.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 325;
            this.label8.Text = "Client Name";
            this.label8.Visible = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Location = new System.Drawing.Point(109, 58);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(549, 21);
            this.cmbLocation.TabIndex = 324;
            this.cmbLocation.Visible = false;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 320;
            this.label22.Text = "Session";
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(109, 9);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(118, 21);
            this.cmbYear.TabIndex = 319;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 322;
            this.label2.Text = "Location";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 440);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1015, 29);
            this.panel2.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.ButtonText = "Export";
            this.btnExport.CornerRadius = 4;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExport.Location = new System.Drawing.Point(895, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 29);
            this.btnExport.TabIndex = 23;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvSal
            // 
            this.dgvSal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSal.Location = new System.Drawing.Point(0, 111);
            this.dgvSal.Name = "dgvSal";
            this.dgvSal.Size = new System.Drawing.Size(1015, 329);
            this.dgvSal.TabIndex = 3;
            // 
            // frmSalMonthly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1015, 469);
            this.Controls.Add(this.dgvSal);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalMonthly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Month wise Gross / Net Salary";
            this.Load += new System.EventHandler(this.frmSalMonthly_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.RadioButton rdbLocation;
        private System.Windows.Forms.RadioButton rdbCompany;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.TextBox cmbClient;
        private System.Windows.Forms.Label label8;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private EDPComponent.VistaButton btnExport;
        private System.Windows.Forms.DataGridView dgvSal;
        private EDPComponent.VistaButton btnloc;
    }
}