namespace PayRollManagementSystem
{
    partial class frmEmpMirroring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpMirroring));
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            this.cmbMComp = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnView = new EDPComponent.VistaButton();
            this.cmbMLoc = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btnclose_frm = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.dgvEmp = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLocation = new EDPComponent.ComboDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbCompany
            // 
            this.CmbCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(116, 12);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(889, 21);
            this.CmbCompany.TabIndex = 94;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompany.Location = new System.Drawing.Point(10, 15);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(79, 14);
            this.LblCompany.TabIndex = 93;
            this.LblCompany.Text = "From Company";
            // 
            // cmbMComp
            // 
            this.cmbMComp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMComp.Connection = null;
            this.cmbMComp.DialogResult = "";
            this.cmbMComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMComp.Location = new System.Drawing.Point(116, 71);
            this.cmbMComp.LOVFlag = 0;
            this.cmbMComp.MaxCharLength = 500;
            this.cmbMComp.Name = "cmbMComp";
            this.cmbMComp.ReturnIndex = -1;
            this.cmbMComp.ReturnValue = "";
            this.cmbMComp.ReturnValue_3rd = "";
            this.cmbMComp.ReturnValue_4th = "";
            this.cmbMComp.Size = new System.Drawing.Size(889, 21);
            this.cmbMComp.TabIndex = 96;
            this.cmbMComp.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbMComp_DropDown);
            this.cmbMComp.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbMComp_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 95;
            this.label1.Text = "Mirror to Company";
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.Color.Transparent;
            this.btnView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnView.BackgroundImage")));
            this.btnView.ButtonText = "View";
            this.btnView.Image = global::PayRollManagementSystem.Properties.Resources._41;
            this.btnView.ImageSize = new System.Drawing.Size(20, 20);
            this.btnView.Location = new System.Drawing.Point(922, 91);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(83, 26);
            this.btnView.TabIndex = 279;
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cmbMLoc
            // 
            this.cmbMLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMLoc.Connection = null;
            this.cmbMLoc.DialogResult = "";
            this.cmbMLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMLoc.Location = new System.Drawing.Point(117, 94);
            this.cmbMLoc.LOVFlag = 0;
            this.cmbMLoc.MaxCharLength = 500;
            this.cmbMLoc.Name = "cmbMLoc";
            this.cmbMLoc.ReturnIndex = -1;
            this.cmbMLoc.ReturnValue = "";
            this.cmbMLoc.ReturnValue_3rd = "";
            this.cmbMLoc.ReturnValue_4th = "";
            this.cmbMLoc.Size = new System.Drawing.Size(802, 21);
            this.cmbMLoc.TabIndex = 281;
            this.cmbMLoc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbMLoc_DropDown);
            this.cmbMLoc.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbMLoc_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 280;
            this.label2.Text = "Mirror to Location";
            // 
            // btnclose_frm
            // 
            this.btnclose_frm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose_frm.BackColor = System.Drawing.Color.Transparent;
            this.btnclose_frm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose_frm.BackgroundImage")));
            this.btnclose_frm.ButtonText = "Close";
            this.btnclose_frm.Image = ((System.Drawing.Image)(resources.GetObject("btnclose_frm.Image")));
            this.btnclose_frm.ImageSize = new System.Drawing.Size(20, 20);
            this.btnclose_frm.Location = new System.Drawing.Point(925, 442);
            this.btnclose_frm.Name = "btnclose_frm";
            this.btnclose_frm.Size = new System.Drawing.Size(80, 31);
            this.btnclose_frm.TabIndex = 283;
            this.btnclose_frm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnclose_frm.Click += new System.EventHandler(this.btnclose_frm_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSubmit.Location = new System.Drawing.Point(839, 442);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 31);
            this.btnSubmit.TabIndex = 282;
            this.btnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvEmp
            // 
            this.dgvEmp.AllowUserToAddRows = false;
            this.dgvEmp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmp.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.ID,
            this.Name,
            this.Location,
            this.Locid,
            this.Check});
            this.dgvEmp.Location = new System.Drawing.Point(13, 124);
            this.dgvEmp.Name = "dgvEmp";
            this.dgvEmp.Size = new System.Drawing.Size(992, 312);
            this.dgvEmp.TabIndex = 284;
            this.dgvEmp.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmp_CellDoubleClick);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // Locid
            // 
            this.Locid.DataPropertyName = "Locid";
            this.Locid.HeaderText = "Locid";
            this.Locid.Name = "Locid";
            this.Locid.Visible = false;
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.HeaderText = "Check";
            this.Check.Name = "Check";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(24, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 13);
            this.label3.TabIndex = 285;
            this.label3.Text = "Double click on Location to assign another location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 280;
            this.label4.Text = "From Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(116, 39);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(802, 21);
            this.cmbLocation.TabIndex = 281;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // frmEmpMirroring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1019, 485);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvEmp);
            this.Controls.Add(this.btnclose_frm);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMLoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.cmbMComp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.LblCompany);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Mirroring";
            this.Load += new System.EventHandler(this.frmEmpMirroring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblCompany;
        private EDPComponent.ComboDialog cmbMComp;
        private System.Windows.Forms.Label label1;
        private EDPComponent.VistaButton btnView;
        private EDPComponent.ComboDialog cmbMLoc;
        private System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton btnclose_frm;
        private EDPComponent.VistaButton btnSubmit;
        private System.Windows.Forms.DataGridView dgvEmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Locid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.Label label4;
        private EDPComponent.ComboDialog cmbLocation;
    }
}