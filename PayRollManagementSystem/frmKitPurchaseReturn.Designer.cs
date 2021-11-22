namespace PayRollManagementSystem
{
    partial class frmKitPurchaseReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKitPurchaseReturn));
            this.label1 = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.dgv_show = new System.Windows.Forms.DataGridView();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetPBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kt_nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stk_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rmrks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbCompany = new EDPComponent.ComboDialog();
            this.LblCompany = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(689, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 321;
            this.label1.Text = "SELECT MONTH";
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(796, 5);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(133, 20);
            this.AttenDtTmPkr.TabIndex = 320;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // dgv_show
            // 
            this.dgv_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_show.BackgroundColor = System.Drawing.Color.White;
            this.dgv_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_show.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PID,
            this.dt,
            this.RetPBill,
            this.pbill,
            this.vname,
            this.kt_nm,
            this.stk_in,
            this.unit,
            this.rt,
            this.amt,
            this.rmrks,
            this.kid,
            this.rid});
            this.dgv_show.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgv_show.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_show.Location = new System.Drawing.Point(12, 32);
            this.dgv_show.Name = "dgv_show";
            this.dgv_show.Size = new System.Drawing.Size(1203, 446);
            this.dgv_show.TabIndex = 316;
            this.dgv_show.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show_CellDoubleClick);
            this.dgv_show.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show_CellEndEdit);
            this.dgv_show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_show_CellClick);
            // 
            // PID
            // 
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.Visible = false;
            // 
            // dt
            // 
            this.dt.FillWeight = 50F;
            this.dt.HeaderText = "Purchase Return Date";
            this.dt.Name = "dt";
            this.dt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // RetPBill
            // 
            this.RetPBill.HeaderText = "Return Purchase Bill No";
            this.RetPBill.Name = "RetPBill";
            // 
            // pbill
            // 
            this.pbill.FillWeight = 80.70319F;
            this.pbill.HeaderText = "Purchase Bill / GRN no";
            this.pbill.Name = "pbill";
            // 
            // vname
            // 
            this.vname.HeaderText = "Vendor Name";
            this.vname.Name = "vname";
            // 
            // kt_nm
            // 
            this.kt_nm.FillWeight = 115F;
            this.kt_nm.HeaderText = "Kit Name";
            this.kt_nm.Name = "kt_nm";
            this.kt_nm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // stk_in
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.stk_in.DefaultCellStyle = dataGridViewCellStyle1;
            this.stk_in.FillWeight = 55F;
            this.stk_in.HeaderText = "Number of Unit";
            this.stk_in.Name = "stk_in";
            // 
            // unit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.unit.DefaultCellStyle = dataGridViewCellStyle2;
            this.unit.FillWeight = 70F;
            this.unit.HeaderText = "Unit";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // rt
            // 
            this.rt.HeaderText = "rt";
            this.rt.Name = "rt";
            // 
            // amt
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amt.DefaultCellStyle = dataGridViewCellStyle3;
            this.amt.FillWeight = 60F;
            this.amt.HeaderText = "Amount";
            this.amt.Name = "amt";
            // 
            // rmrks
            // 
            this.rmrks.HeaderText = "Remarks";
            this.rmrks.Name = "rmrks";
            // 
            // kid
            // 
            this.kid.HeaderText = "kid";
            this.kid.Name = "kid";
            this.kid.Visible = false;
            // 
            // rid
            // 
            this.rid.HeaderText = "rid";
            this.rid.Name = "rid";
            this.rid.Visible = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1139, 482);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 23);
            this.button3.TabIndex = 319;
            this.button3.Text = "CLOSE";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1057, 482);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 23);
            this.button2.TabIndex = 318;
            this.button2.Text = "DELETE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(975, 482);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 23);
            this.btnSave.TabIndex = 317;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYear.BackColor = System.Drawing.Color.White;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(84, 5);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(141, 21);
            this.cmbYear.TabIndex = 338;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(11, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 339;
            this.label22.Text = "Session";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 487);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 13);
            this.label2.TabIndex = 340;
            this.label2.Text = "Double Click on Ref Purchase bill no to get purchase records";
            // 
            // CmbCompany
            // 
            this.CmbCompany.Connection = null;
            this.CmbCompany.DialogResult = "";
            this.CmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCompany.Location = new System.Drawing.Point(297, 5);
            this.CmbCompany.LOVFlag = 0;
            this.CmbCompany.MaxCharLength = 500;
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.ReturnIndex = -1;
            this.CmbCompany.ReturnValue = "";
            this.CmbCompany.ReturnValue_3rd = "";
            this.CmbCompany.ReturnValue_4th = "";
            this.CmbCompany.Size = new System.Drawing.Size(356, 21);
            this.CmbCompany.TabIndex = 341;
            this.CmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbCompany_DropDown);
            this.CmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbCompany_CloseUp);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Location = new System.Drawing.Point(240, 10);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(51, 13);
            this.LblCompany.TabIndex = 342;
            this.LblCompany.Text = "Company";
            this.LblCompany.Click += new System.EventHandler(this.LblCompany_Click);
            // 
            // frmKitPurchaseReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 505);
            this.Controls.Add(this.CmbCompany);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AttenDtTmPkr);
            this.Controls.Add(this.dgv_show);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKitPurchaseReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kit Purchase Return";
            this.Load += new System.EventHandler(this.frmKitPurchaseReturn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private System.Windows.Forms.DataGridView dgv_show;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label2;
        private EDPComponent.ComboDialog CmbCompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dt;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetPBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn pbill;
        private System.Windows.Forms.DataGridViewTextBoxColumn vname;
        private System.Windows.Forms.DataGridViewTextBoxColumn kt_nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn stk_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn rt;
        private System.Windows.Forms.DataGridViewTextBoxColumn amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn rmrks;
        private System.Windows.Forms.DataGridViewTextBoxColumn kid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rid;
    }
}