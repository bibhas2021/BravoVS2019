namespace PayRollManagementSystem
{
    partial class frmPFLoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPFLoan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsave = new EDPComponent.VistaButton();
            this.btnclose = new EDPComponent.VistaButton();
            this.btndelete = new EDPComponent.VistaButton();
            this.dgvpfloan = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbsession = new System.Windows.Forms.ComboBox();
            this.lblsession = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblempcd = new System.Windows.Forms.Label();
            this.lblempcode = new System.Windows.Forms.Label();
            this.txtrem = new System.Windows.Forms.TextBox();
            this.lblrem = new System.Windows.Forms.Label();
            this.txtinstallment = new TextBoxX.TextBoxX();
            this.lblinstallment = new System.Windows.Forms.Label();
            this.txtirate = new TextBoxX.TextBoxX();
            this.lblirate = new System.Windows.Forms.Label();
            this.txtamt = new TextBoxX.TextBoxX();
            this.lblamt = new System.Windows.Forms.Label();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.lbldate = new System.Windows.Forms.Label();
            this.cmbloantype = new System.Windows.Forms.ComboBox();
            this.lblloantype = new System.Windows.Forms.Label();
            this.cmbempname = new System.Windows.Forms.ComboBox();
            this.lblempname = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpfloan)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.dgvpfloan);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(5, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 440);
            this.panel1.TabIndex = 42;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnsave.BackgroundImage")));
            this.btnsave.ButtonText = "Save";
            this.btnsave.Location = new System.Drawing.Point(408, 202);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(90, 29);
            this.btnsave.TabIndex = 281;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.ButtonText = "Close";
            this.btnclose.Location = new System.Drawing.Point(600, 202);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(90, 29);
            this.btnclose.TabIndex = 280;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndelete.BackgroundImage")));
            this.btndelete.ButtonText = "Delete";
            this.btndelete.Location = new System.Drawing.Point(504, 202);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(90, 29);
            this.btndelete.TabIndex = 279;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // dgvpfloan
            // 
            this.dgvpfloan.AllowUserToAddRows = false;
            this.dgvpfloan.AllowUserToDeleteRows = false;
            this.dgvpfloan.AllowUserToResizeColumns = false;
            this.dgvpfloan.AllowUserToResizeRows = false;
            this.dgvpfloan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpfloan.Location = new System.Drawing.Point(6, 237);
            this.dgvpfloan.Name = "dgvpfloan";
            this.dgvpfloan.RowHeadersVisible = false;
            this.dgvpfloan.Size = new System.Drawing.Size(684, 192);
            this.dgvpfloan.TabIndex = 5;
            this.dgvpfloan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpfloan_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbsession);
            this.groupBox2.Controls.Add(this.lblsession);
            this.groupBox2.Location = new System.Drawing.Point(6, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 59);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            this.label1.Visible = false;
            // 
            // cmbsession
            // 
            this.cmbsession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsession.FormattingEnabled = true;
            this.cmbsession.Location = new System.Drawing.Point(127, 19);
            this.cmbsession.Name = "cmbsession";
            this.cmbsession.Size = new System.Drawing.Size(183, 21);
            this.cmbsession.TabIndex = 1;
            // 
            // lblsession
            // 
            this.lblsession.AutoSize = true;
            this.lblsession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsession.Location = new System.Drawing.Point(6, 20);
            this.lblsession.Name = "lblsession";
            this.lblsession.Size = new System.Drawing.Size(51, 15);
            this.lblsession.TabIndex = 2;
            this.lblsession.Text = "Session";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblempcd);
            this.groupBox1.Controls.Add(this.lblempcode);
            this.groupBox1.Controls.Add(this.txtrem);
            this.groupBox1.Controls.Add(this.lblrem);
            this.groupBox1.Controls.Add(this.txtinstallment);
            this.groupBox1.Controls.Add(this.lblinstallment);
            this.groupBox1.Controls.Add(this.txtirate);
            this.groupBox1.Controls.Add(this.lblirate);
            this.groupBox1.Controls.Add(this.txtamt);
            this.groupBox1.Controls.Add(this.lblamt);
            this.groupBox1.Controls.Add(this.dtpdate);
            this.groupBox1.Controls.Add(this.lbldate);
            this.groupBox1.Controls.Add(this.cmbloantype);
            this.groupBox1.Controls.Add(this.lblloantype);
            this.groupBox1.Controls.Add(this.cmbempname);
            this.groupBox1.Controls.Add(this.lblempname);
            this.groupBox1.Location = new System.Drawing.Point(6, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblempcd
            // 
            this.lblempcd.AutoSize = true;
            this.lblempcd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblempcd.Location = new System.Drawing.Point(487, 15);
            this.lblempcd.Name = "lblempcd";
            this.lblempcd.Size = new System.Drawing.Size(0, 15);
            this.lblempcd.TabIndex = 15;
            // 
            // lblempcode
            // 
            this.lblempcode.AutoSize = true;
            this.lblempcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblempcode.Location = new System.Drawing.Point(369, 16);
            this.lblempcode.Name = "lblempcode";
            this.lblempcode.Size = new System.Drawing.Size(94, 15);
            this.lblempcode.TabIndex = 14;
            this.lblempcode.Text = "Employee Code";
            this.lblempcode.Visible = false;
            // 
            // txtrem
            // 
            this.txtrem.Location = new System.Drawing.Point(490, 95);
            this.txtrem.Name = "txtrem";
            this.txtrem.Size = new System.Drawing.Size(183, 20);
            this.txtrem.TabIndex = 8;
            // 
            // lblrem
            // 
            this.lblrem.AutoSize = true;
            this.lblrem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrem.Location = new System.Drawing.Point(369, 97);
            this.lblrem.Name = "lblrem";
            this.lblrem.Size = new System.Drawing.Size(57, 15);
            this.lblrem.TabIndex = 12;
            this.lblrem.Text = "Remarks";
            // 
            // txtinstallment
            // 
            this.txtinstallment.Location = new System.Drawing.Point(127, 95);
            this.txtinstallment.Name = "txtinstallment";
            this.txtinstallment.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedInteger;
            this.txtinstallment.Size = new System.Drawing.Size(183, 20);
            this.txtinstallment.TabIndex = 5;
            this.txtinstallment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtinstallment.TextChanged += new System.EventHandler(this.txtinstallment_TextChanged);
            // 
            // lblinstallment
            // 
            this.lblinstallment.AutoSize = true;
            this.lblinstallment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinstallment.Location = new System.Drawing.Point(6, 96);
            this.lblinstallment.Name = "lblinstallment";
            this.lblinstallment.Size = new System.Drawing.Size(67, 15);
            this.lblinstallment.TabIndex = 10;
            this.lblinstallment.Text = "Installment";
            this.lblinstallment.Click += new System.EventHandler(this.lblinstallment_Click);
            // 
            // txtirate
            // 
            this.txtirate.Location = new System.Drawing.Point(490, 70);
            this.txtirate.Name = "txtirate";
            this.txtirate.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtirate.Size = new System.Drawing.Size(183, 20);
            this.txtirate.TabIndex = 7;
            this.txtirate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblirate
            // 
            this.lblirate.AutoSize = true;
            this.lblirate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblirate.Location = new System.Drawing.Point(369, 71);
            this.lblirate.Name = "lblirate";
            this.lblirate.Size = new System.Drawing.Size(76, 15);
            this.lblirate.TabIndex = 8;
            this.lblirate.Text = "Interest Rate";
            // 
            // txtamt
            // 
            this.txtamt.Location = new System.Drawing.Point(127, 69);
            this.txtamt.Name = "txtamt";
            this.txtamt.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedInteger;
            this.txtamt.Size = new System.Drawing.Size(183, 20);
            this.txtamt.TabIndex = 4;
            this.txtamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblamt
            // 
            this.lblamt.AutoSize = true;
            this.lblamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblamt.Location = new System.Drawing.Point(6, 70);
            this.lblamt.Name = "lblamt";
            this.lblamt.Size = new System.Drawing.Size(49, 15);
            this.lblamt.TabIndex = 6;
            this.lblamt.Text = "Amount";
            // 
            // dtpdate
            // 
            this.dtpdate.CustomFormat = "dd MMMM,yyyy";
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdate.Location = new System.Drawing.Point(490, 43);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(183, 20);
            this.dtpdate.TabIndex = 6;
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(369, 43);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(96, 15);
            this.lbldate.TabIndex = 4;
            this.lbldate.Text = "With Effect From";
            // 
            // cmbloantype
            // 
            this.cmbloantype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbloantype.FormattingEnabled = true;
            this.cmbloantype.Items.AddRange(new object[] {
            "Refundable",
            "Non-Refundable"});
            this.cmbloantype.Location = new System.Drawing.Point(127, 42);
            this.cmbloantype.Name = "cmbloantype";
            this.cmbloantype.Size = new System.Drawing.Size(183, 21);
            this.cmbloantype.TabIndex = 3;
            // 
            // lblloantype
            // 
            this.lblloantype.AutoSize = true;
            this.lblloantype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblloantype.Location = new System.Drawing.Point(6, 43);
            this.lblloantype.Name = "lblloantype";
            this.lblloantype.Size = new System.Drawing.Size(64, 15);
            this.lblloantype.TabIndex = 2;
            this.lblloantype.Text = "Loan Type";
            // 
            // cmbempname
            // 
            this.cmbempname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbempname.FormattingEnabled = true;
            this.cmbempname.Location = new System.Drawing.Point(127, 15);
            this.cmbempname.Name = "cmbempname";
            this.cmbempname.Size = new System.Drawing.Size(183, 21);
            this.cmbempname.TabIndex = 2;
            this.cmbempname.SelectionChangeCommitted += new System.EventHandler(this.cmbempname_SelectionChangeCommitted);
            this.cmbempname.SelectedIndexChanged += new System.EventHandler(this.cmbempname_SelectedIndexChanged);
            this.cmbempname.TextChanged += new System.EventHandler(this.cmbempname_TextChanged);
            this.cmbempname.DropDown += new System.EventHandler(this.cmbempname_DropDown);
            // 
            // lblempname
            // 
            this.lblempname.AutoSize = true;
            this.lblempname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblempname.Location = new System.Drawing.Point(6, 16);
            this.lblempname.Name = "lblempname";
            this.lblempname.Size = new System.Drawing.Size(99, 15);
            this.lblempname.TabIndex = 0;
            this.lblempname.Text = "Employee Name";
            // 
            // frmPFLoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 472);
            this.Controls.Add(this.panel1);
            this.HeaderText = "PF Loan";
            this.Name = "frmPFLoan";
            this.Load += new System.EventHandler(this.frmPFLoan_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpfloan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblempname;
        private System.Windows.Forms.ComboBox cmbsession;
        private System.Windows.Forms.Label lblsession;
        private System.Windows.Forms.ComboBox cmbempname;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.ComboBox cmbloantype;
        private System.Windows.Forms.Label lblloantype;
        private TextBoxX.TextBoxX txtamt;
        private System.Windows.Forms.Label lblamt;
        private TextBoxX.TextBoxX txtinstallment;
        private System.Windows.Forms.Label lblinstallment;
        private TextBoxX.TextBoxX txtirate;
        private System.Windows.Forms.Label lblirate;
        private System.Windows.Forms.Label lblrem;
        private System.Windows.Forms.DataGridView dgvpfloan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtrem;
        private System.Windows.Forms.Label lblempcd;
        private System.Windows.Forms.Label lblempcode;
        private EDPComponent.VistaButton btnsave;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btndelete;
        private System.Windows.Forms.Label label1;
    }
}