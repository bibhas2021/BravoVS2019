namespace PayRollManagementSystem
{
    partial class frmRptZone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptZone));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblID = new System.Windows.Forms.Label();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btn_exp = new EDPComponent.VistaButton();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.lbltype = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdballzone = new System.Windows.Forms.RadioButton();
            this.rdbCompany = new System.Windows.Forms.RadioButton();
            this.rdbZone = new System.Windows.Forms.RadioButton();
            this.dgvZone = new System.Windows.Forms.DataGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZone)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblID);
            this.splitContainer1.Panel1.Controls.Add(this.btnPreview);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btn_exp);
            this.splitContainer1.Panel1.Controls.Add(this.cmbcompany);
            this.splitContainer1.Panel1.Controls.Add(this.lbltype);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvZone);
            this.splitContainer1.Size = new System.Drawing.Size(1142, 525);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Location = new System.Drawing.Point(332, 63);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(2, 15);
            this.lblID.TabIndex = 299;
            this.lblID.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(757, 61);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 298;
            this.btnPreview.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(841, 61);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 296;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btn_exp
            // 
            this.btn_exp.BackColor = System.Drawing.Color.Transparent;
            this.btn_exp.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btn_exp.ButtonText = "Export To Excel";
            this.btn_exp.CornerRadius = 4;
            this.btn_exp.ImageSize = new System.Drawing.Size(16, 16);
            this.btn_exp.Location = new System.Drawing.Point(632, 61);
            this.btn_exp.Name = "btn_exp";
            this.btn_exp.Size = new System.Drawing.Size(120, 30);
            this.btn_exp.TabIndex = 297;
            this.btn_exp.Visible = false;
            this.btn_exp.Click += new System.EventHandler(this.btn_exp_Click);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(302, 34);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(619, 21);
            this.cmbcompany.TabIndex = 295;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltype.Location = new System.Drawing.Point(300, 14);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(91, 16);
            this.lbltype.TabIndex = 1;
            this.lbltype.Text = "Select Zone";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdballzone);
            this.groupBox1.Controls.Add(this.rdbCompany);
            this.groupBox1.Controls.Add(this.rdbZone);
            this.groupBox1.Location = new System.Drawing.Point(22, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Option";
            // 
            // rdballzone
            // 
            this.rdballzone.AutoSize = true;
            this.rdballzone.Location = new System.Drawing.Point(62, 47);
            this.rdballzone.Name = "rdballzone";
            this.rdballzone.Size = new System.Drawing.Size(125, 17);
            this.rdballzone.TabIndex = 0;
            this.rdballzone.Text = "All Zone All Company";
            this.rdballzone.UseVisualStyleBackColor = true;
            this.rdballzone.Click += new System.EventHandler(this.rdbZone_CheckedChanged);
            // 
            // rdbCompany
            // 
            this.rdbCompany.AutoSize = true;
            this.rdbCompany.Location = new System.Drawing.Point(157, 19);
            this.rdbCompany.Name = "rdbCompany";
            this.rdbCompany.Size = new System.Drawing.Size(93, 17);
            this.rdbCompany.TabIndex = 0;
            this.rdbCompany.Text = "Company wise";
            this.rdbCompany.UseVisualStyleBackColor = true;
            this.rdbCompany.Click += new System.EventHandler(this.rdbZone_CheckedChanged);
            // 
            // rdbZone
            // 
            this.rdbZone.AutoSize = true;
            this.rdbZone.Checked = true;
            this.rdbZone.Location = new System.Drawing.Point(15, 19);
            this.rdbZone.Name = "rdbZone";
            this.rdbZone.Size = new System.Drawing.Size(74, 17);
            this.rdbZone.TabIndex = 0;
            this.rdbZone.TabStop = true;
            this.rdbZone.Text = "Zone wise";
            this.rdbZone.UseVisualStyleBackColor = true;
            this.rdbZone.CheckedChanged += new System.EventHandler(this.rdbZone_CheckedChanged);
            // 
            // dgvZone
            // 
            this.dgvZone.AllowUserToAddRows = false;
            this.dgvZone.AllowUserToDeleteRows = false;
            this.dgvZone.BackgroundColor = System.Drawing.Color.White;
            this.dgvZone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvZone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvZone.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvZone.Location = new System.Drawing.Point(0, 0);
            this.dgvZone.Name = "dgvZone";
            this.dgvZone.ReadOnly = true;
            this.dgvZone.Size = new System.Drawing.Size(1140, 413);
            this.dgvZone.TabIndex = 0;
            // 
            // frmRptZone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1142, 525);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptZone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zone Report";
            this.Load += new System.EventHandler(this.frmRptZone_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvZone;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdballzone;
        private System.Windows.Forms.RadioButton rdbCompany;
        private System.Windows.Forms.RadioButton rdbZone;
        private EDPComponent.ComboDialog cmbcompany;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btn_exp;
        private EDPComponent.VistaButton btnPreview;
        private System.Windows.Forms.Label lblID;
    }
}