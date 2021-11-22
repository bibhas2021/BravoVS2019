namespace PayRollManagementSystem
{
    partial class frmBillOpening
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillOpening));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new EDPComponent.VistaButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnSave = new EDPComponent.VistaButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvOpening = new System.Windows.Forms.DataGridView();
            this.col_clid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_locid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_stcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_gstin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_op_bill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_op_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_op_tds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_op_oth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_op_net_ledger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_opid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpening)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 34);
            this.panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExport.ButtonText = "Export";
            this.btnExport.CornerRadius = 4;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExport.Location = new System.Drawing.Point(837, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 32);
            this.btnExport.TabIndex = 317;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(927, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 32);
            this.splitter1.TabIndex = 316;
            this.splitter1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.SlateGray;
            this.btnSave.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.GlowColor = System.Drawing.Color.Aqua;
            this.btnSave.Location = new System.Drawing.Point(937, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 314;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbYear);
            this.panel2.Controls.Add(this.cmbcompany);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.dtpMonth);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 75);
            this.panel2.TabIndex = 1;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(354, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(117, 22);
            this.cmbYear.TabIndex = 306;
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(98, 38);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(373, 21);
            this.cmbcompany.TabIndex = 304;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(277, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 307;
            this.label22.Text = "Session";
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MMMM - yyyy";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(97, 12);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(132, 20);
            this.dtpMonth.TabIndex = 303;
            this.dtpMonth.ValueChanged += new System.EventHandler(this.dtpMonth_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 14);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 14);
            this.label21.TabIndex = 302;
            this.label21.Text = "Month";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 14);
            this.label6.TabIndex = 305;
            this.label6.Text = "Company Name";
            // 
            // dgvOpening
            // 
            this.dgvOpening.AllowUserToAddRows = false;
            this.dgvOpening.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpening.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOpening.BackgroundColor = System.Drawing.Color.White;
            this.dgvOpening.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOpening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpening.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_clid,
            this.col_locid,
            this.col_Client,
            this.col_stcode,
            this.col_gstin,
            this.col_op_bill,
            this.col_op_pay,
            this.col_op_tds,
            this.col_op_oth,
            this.col_op_net_ledger,
            this.col_opid});
            this.dgvOpening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOpening.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvOpening.GridColor = System.Drawing.Color.DimGray;
            this.dgvOpening.Location = new System.Drawing.Point(0, 75);
            this.dgvOpening.Name = "dgvOpening";
            this.dgvOpening.Size = new System.Drawing.Size(1020, 371);
            this.dgvOpening.TabIndex = 2;
            this.dgvOpening.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvOpening_KeyUp);
            // 
            // col_clid
            // 
            this.col_clid.DataPropertyName = "clid";
            this.col_clid.HeaderText = "clid";
            this.col_clid.Name = "col_clid";
            this.col_clid.Visible = false;
            // 
            // col_locid
            // 
            this.col_locid.DataPropertyName = "locid";
            this.col_locid.HeaderText = "locid";
            this.col_locid.Name = "col_locid";
            this.col_locid.Visible = false;
            // 
            // col_Client
            // 
            this.col_Client.DataPropertyName = "client_location";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Client.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_Client.HeaderText = "Client [Location]";
            this.col_Client.Name = "col_Client";
            // 
            // col_stcode
            // 
            this.col_stcode.DataPropertyName = "stcode";
            this.col_stcode.FillWeight = 14.62853F;
            this.col_stcode.HeaderText = "State Code";
            this.col_stcode.Name = "col_stcode";
            // 
            // col_gstin
            // 
            this.col_gstin.DataPropertyName = "gstin";
            this.col_gstin.FillWeight = 50F;
            this.col_gstin.HeaderText = "GSTIN";
            this.col_gstin.Name = "col_gstin";
            // 
            // col_op_bill
            // 
            this.col_op_bill.DataPropertyName = "opBill";
            this.col_op_bill.FillWeight = 23.28683F;
            this.col_op_bill.HeaderText = "Opening Undjusted Bill";
            this.col_op_bill.Name = "col_op_bill";
            // 
            // col_op_pay
            // 
            this.col_op_pay.DataPropertyName = "opPay";
            this.col_op_pay.FillWeight = 23.28683F;
            this.col_op_pay.HeaderText = "Opening Undjusted Payment";
            this.col_op_pay.Name = "col_op_pay";
            // 
            // col_op_tds
            // 
            this.col_op_tds.DataPropertyName = "opTds";
            this.col_op_tds.FillWeight = 23.28683F;
            this.col_op_tds.HeaderText = "Opening Undjusted TDS";
            this.col_op_tds.Name = "col_op_tds";
            // 
            // col_op_oth
            // 
            this.col_op_oth.DataPropertyName = "opOth";
            this.col_op_oth.FillWeight = 23.28683F;
            this.col_op_oth.HeaderText = "Opening Unadjusted Other";
            this.col_op_oth.Name = "col_op_oth";
            // 
            // col_op_net_ledger
            // 
            this.col_op_net_ledger.DataPropertyName = "opLedger";
            this.col_op_net_ledger.FillWeight = 23.28683F;
            this.col_op_net_ledger.HeaderText = "Opening Ledger Balance";
            this.col_op_net_ledger.Name = "col_op_net_ledger";
            // 
            // col_opid
            // 
            this.col_opid.DataPropertyName = "opid";
            this.col_opid.HeaderText = "opid";
            this.col_opid.Name = "col_opid";
            this.col_opid.Visible = false;
            // 
            // frmBillOpening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 480);
            this.Controls.Add(this.dgvOpening);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBillOpening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Unadjusted Opening";
            this.Load += new System.EventHandler(this.frmBillOpening_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpening)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOpening;
        internal System.Windows.Forms.ComboBox cmbYear;
        public EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.DateTimePicker dtpMonth;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label6;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnExport;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_clid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_locid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_stcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_gstin;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_op_bill;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_op_pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_op_tds;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_op_oth;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_op_net_ledger;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_opid;
    }
}