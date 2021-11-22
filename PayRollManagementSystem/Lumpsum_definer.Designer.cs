namespace PayRollManagementSystem
{
    partial class Lumpsum_definer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lumpsum_definer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtpEDate = new System.Windows.Forms.DateTimePicker();
            this.txtpfamt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnnew = new EDPComponent.VistaButton();
            this.txtamt = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.cmbsal_structure = new System.Windows.Forms.ComboBox();
            this.lblsalstruc = new System.Windows.Forms.Label();
            this.btnclose = new EDPComponent.VistaButton();
            this.btndelete = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.dgvlsum = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblamt = new System.Windows.Forms.Label();
            this.lblgrade = new System.Windows.Forms.Label();
            this.rbgradewise = new System.Windows.Forms.RadioButton();
            this.rbeveryone = new System.Windows.Forms.RadioButton();
            this.lbltype = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.cmbDesignation = new EDPComponent.ComboDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlsum)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbDesignation);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.dtpEDate);
            this.panel1.Controls.Add(this.txtpfamt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Controls.Add(this.txtamt);
            this.panel1.Controls.Add(this.txtname);
            this.panel1.Controls.Add(this.cmbsal_structure);
            this.panel1.Controls.Add(this.lblsalstruc);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.dgvlsum);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblamt);
            this.panel1.Controls.Add(this.lblgrade);
            this.panel1.Controls.Add(this.rbgradewise);
            this.panel1.Controls.Add(this.rbeveryone);
            this.panel1.Controls.Add(this.lbltype);
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Location = new System.Drawing.Point(4, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 459);
            this.panel1.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(317, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 284;
            this.label7.Text = "( Simple naming ) ";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(8, 393);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(408, 20);
            this.txtSearch.TabIndex = 283;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dtpEDate
            // 
            this.dtpEDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpEDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEDate.Location = new System.Drawing.Point(131, 126);
            this.dtpEDate.Name = "dtpEDate";
            this.dtpEDate.Size = new System.Drawing.Size(285, 20);
            this.dtpEDate.TabIndex = 282;
            // 
            // txtpfamt
            // 
            this.txtpfamt.Location = new System.Drawing.Point(314, 102);
            this.txtpfamt.Name = "txtpfamt";
            this.txtpfamt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpfamt.Size = new System.Drawing.Size(102, 20);
            this.txtpfamt.TabIndex = 281;
            this.txtpfamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpfamt.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 280;
            this.label1.Text = "PF Amt";
            this.label1.Visible = false;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.Transparent;
            this.btnnew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnnew.BackgroundImage")));
            this.btnnew.ButtonText = "New Entry";
            this.btnnew.Location = new System.Drawing.Point(10, 420);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(80, 29);
            this.btnnew.TabIndex = 279;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // txtamt
            // 
            this.txtamt.Location = new System.Drawing.Point(131, 102);
            this.txtamt.Name = "txtamt";
            this.txtamt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtamt.Size = new System.Drawing.Size(285, 20);
            this.txtamt.TabIndex = 277;
            this.txtamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtamt.Validated += new System.EventHandler(this.txtamt_Validated);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(131, 34);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(180, 20);
            this.txtname.TabIndex = 276;
            // 
            // cmbsal_structure
            // 
            this.cmbsal_structure.FormattingEnabled = true;
            this.cmbsal_structure.Location = new System.Drawing.Point(131, 10);
            this.cmbsal_structure.Name = "cmbsal_structure";
            this.cmbsal_structure.Size = new System.Drawing.Size(285, 21);
            this.cmbsal_structure.TabIndex = 275;
            this.cmbsal_structure.Visible = false;
            // 
            // lblsalstruc
            // 
            this.lblsalstruc.AutoSize = true;
            this.lblsalstruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsalstruc.Location = new System.Drawing.Point(14, 11);
            this.lblsalstruc.Name = "lblsalstruc";
            this.lblsalstruc.Size = new System.Drawing.Size(77, 15);
            this.lblsalstruc.TabIndex = 274;
            this.lblsalstruc.Text = "Sal Structure";
            this.lblsalstruc.Visible = false;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.ButtonText = "Close";
            this.btnclose.Location = new System.Drawing.Point(336, 419);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 29);
            this.btnclose.TabIndex = 273;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndelete.BackgroundImage")));
            this.btndelete.ButtonText = "Delete";
            this.btndelete.Location = new System.Drawing.Point(119, 419);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(80, 29);
            this.btndelete.TabIndex = 272;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(230, 419);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 29);
            this.btnSubmit.TabIndex = 271;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvlsum
            // 
            this.dgvlsum.AllowUserToAddRows = false;
            this.dgvlsum.AllowUserToDeleteRows = false;
            this.dgvlsum.AllowUserToResizeColumns = false;
            this.dgvlsum.AllowUserToResizeRows = false;
            this.dgvlsum.BackgroundColor = System.Drawing.Color.White;
            this.dgvlsum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlsum.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvlsum.Location = new System.Drawing.Point(8, 152);
            this.dgvlsum.MultiSelect = false;
            this.dgvlsum.Name = "dgvlsum";
            this.dgvlsum.ReadOnly = true;
            this.dgvlsum.RowHeadersVisible = false;
            this.dgvlsum.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvlsum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlsum.Size = new System.Drawing.Size(408, 235);
            this.dgvlsum.TabIndex = 270;
            this.dgvlsum.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlsum_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Effective Date";
            // 
            // lblamt
            // 
            this.lblamt.AutoSize = true;
            this.lblamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblamt.Location = new System.Drawing.Point(14, 103);
            this.lblamt.Name = "lblamt";
            this.lblamt.Size = new System.Drawing.Size(49, 15);
            this.lblamt.TabIndex = 7;
            this.lblamt.Text = "Amount";
            // 
            // lblgrade
            // 
            this.lblgrade.AutoSize = true;
            this.lblgrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgrade.Location = new System.Drawing.Point(14, 78);
            this.lblgrade.Name = "lblgrade";
            this.lblgrade.Size = new System.Drawing.Size(73, 15);
            this.lblgrade.TabIndex = 5;
            this.lblgrade.Text = "Designation";
            // 
            // rbgradewise
            // 
            this.rbgradewise.AutoSize = true;
            this.rbgradewise.Location = new System.Drawing.Point(205, 57);
            this.rbgradewise.Name = "rbgradewise";
            this.rbgradewise.Size = new System.Drawing.Size(81, 17);
            this.rbgradewise.TabIndex = 4;
            this.rbgradewise.Text = "Designation";
            this.rbgradewise.UseVisualStyleBackColor = true;
            this.rbgradewise.CheckedChanged += new System.EventHandler(this.rbgradewise_CheckedChanged);
            // 
            // rbeveryone
            // 
            this.rbeveryone.AutoSize = true;
            this.rbeveryone.Checked = true;
            this.rbeveryone.Location = new System.Drawing.Point(133, 57);
            this.rbeveryone.Name = "rbeveryone";
            this.rbeveryone.Size = new System.Drawing.Size(70, 17);
            this.rbeveryone.TabIndex = 3;
            this.rbeveryone.TabStop = true;
            this.rbeveryone.Text = "Everyone";
            this.rbeveryone.UseVisualStyleBackColor = true;
            this.rbeveryone.CheckedChanged += new System.EventHandler(this.rbgradewise_CheckedChanged);
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltype.Location = new System.Drawing.Point(14, 57);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(33, 15);
            this.lbltype.TabIndex = 1;
            this.lbltype.Text = "Type";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(14, 35);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(100, 15);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "Lumpsum Name";
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.Connection = null;
            this.cmbDesignation.DialogResult = "";
            this.cmbDesignation.Enabled = false;
            this.cmbDesignation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDesignation.Location = new System.Drawing.Point(131, 78);
            this.cmbDesignation.LOVFlag = 0;
            this.cmbDesignation.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDesignation.MaxCharLength = 500;
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.ReturnIndex = -1;
            this.cmbDesignation.ReturnValue = "";
            this.cmbDesignation.ReturnValue_3rd = "";
            this.cmbDesignation.ReturnValue_4th = "";
            this.cmbDesignation.Size = new System.Drawing.Size(285, 21);
            this.cmbDesignation.TabIndex = 285;
            this.cmbDesignation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbDesignation_DropDown);
            this.cmbDesignation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbDesignation_CloseUp);
            // 
            // Lumpsum_definer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 497);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Lumpsum_definer";
            this.Load += new System.EventHandler(this.Lumpsum_definer_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlsum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbeveryone;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblamt;
        private System.Windows.Forms.Label lblgrade;
        private System.Windows.Forms.RadioButton rbgradewise;
        private System.Windows.Forms.DataGridView dgvlsum;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btndelete;
        private EDPComponent.VistaButton btnSubmit;
        public System.Windows.Forms.ComboBox cmbsal_structure;
        public System.Windows.Forms.Label lblsalstruc;
        private System.Windows.Forms.TextBox txtamt;
        private System.Windows.Forms.TextBox txtname;
        private EDPComponent.VistaButton btnnew;
        private System.Windows.Forms.TextBox txtpfamt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEDate;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label7;
        private EDPComponent.ComboDialog cmbDesignation;
    }
}