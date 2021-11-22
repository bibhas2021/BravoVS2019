namespace PayRollManagementSystem
{
    partial class frmEmployee_ProfitLossReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee_ProfitLossReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmblocation = new EDPComponent.ComboDialog();
            this.dgPfEsi = new System.Windows.Forms.DataGridView();
            this.eid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pf_bs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esi_bs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pf_contribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esi_contribution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbClient = new EDPComponent.ComboDialog();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.raddetails = new System.Windows.Forms.RadioButton();
            this.radconsoli = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpForm = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtEsi = new System.Windows.Forms.TextBox();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.btnPreview = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnPrnt = new EDPComponent.VistaButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbReport = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.txtEmpContribut = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPfEsi)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CmbReport);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.txtEmpContribut);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 284);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.cmblocation);
            this.groupBox2.Controls.Add(this.dgPfEsi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbClient);
            this.groupBox2.Controls.Add(this.cmbcompany);
            this.groupBox2.Location = new System.Drawing.Point(6, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 103);
            this.groupBox2.TabIndex = 265;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Details";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 310;
            this.button1.Text = "Select Locations";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(29, 67);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 17);
            this.checkBox1.TabIndex = 309;
            this.checkBox1.Text = "All Locations";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmblocation
            // 
            this.cmblocation.Connection = null;
            this.cmblocation.DialogResult = "";
            this.cmblocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.Location = new System.Drawing.Point(6, 105);
            this.cmblocation.LOVFlag = 0;
            this.cmblocation.MaxCharLength = 500;
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.ReturnIndex = -1;
            this.cmblocation.ReturnValue = "";
            this.cmblocation.ReturnValue_3rd = "";
            this.cmblocation.ReturnValue_4th = "";
            this.cmblocation.Size = new System.Drawing.Size(366, 21);
            this.cmblocation.TabIndex = 307;
            this.cmblocation.Visible = false;
            this.cmblocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmblocation_DropDown);
            this.cmblocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmblocation_CloseUp);
            // 
            // dgPfEsi
            // 
            this.dgPfEsi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPfEsi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eid,
            this.pf_bs,
            this.esi_bs,
            this.pf_contribution,
            this.esi_contribution});
            this.dgPfEsi.Location = new System.Drawing.Point(6, 101);
            this.dgPfEsi.Name = "dgPfEsi";
            this.dgPfEsi.Size = new System.Drawing.Size(451, 28);
            this.dgPfEsi.TabIndex = 308;
            this.dgPfEsi.Visible = false;
            this.dgPfEsi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPfEsi_CellContentClick);
            // 
            // eid
            // 
            this.eid.HeaderText = "eid";
            this.eid.Name = "eid";
            // 
            // pf_bs
            // 
            this.pf_bs.HeaderText = "pf_bs";
            this.pf_bs.Name = "pf_bs";
            // 
            // esi_bs
            // 
            this.esi_bs.HeaderText = "esi_bs";
            this.esi_bs.Name = "esi_bs";
            // 
            // pf_contribution
            // 
            this.pf_contribution.HeaderText = "pf_contribution";
            this.pf_contribution.Name = "pf_contribution";
            // 
            // esi_contribution
            // 
            this.esi_contribution.HeaderText = "esi_contribution";
            this.esi_contribution.Name = "esi_contribution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 293;
            this.label5.Text = "Client Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 293;
            this.label6.Text = "Company Name";
            // 
            // cmbClient
            // 
            this.cmbClient.Connection = null;
            this.cmbClient.DialogResult = "";
            this.cmbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClient.Location = new System.Drawing.Point(91, 40);
            this.cmbClient.LOVFlag = 0;
            this.cmbClient.MaxCharLength = 500;
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.ReturnIndex = -1;
            this.cmbClient.ReturnValue = "";
            this.cmbClient.ReturnValue_3rd = "";
            this.cmbClient.ReturnValue_4th = "";
            this.cmbClient.Size = new System.Drawing.Size(366, 21);
            this.cmbClient.TabIndex = 292;
            this.cmbClient.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbclintname_DropDown);
            this.cmbClient.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbclintname_CloseUp);
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(91, 14);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(366, 21);
            this.cmbcompany.TabIndex = 292;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.raddetails);
            this.groupBox9.Controls.Add(this.radconsoli);
            this.groupBox9.Location = new System.Drawing.Point(162, 165);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(152, 47);
            this.groupBox9.TabIndex = 20;
            this.groupBox9.TabStop = false;
            this.groupBox9.Visible = false;
            // 
            // raddetails
            // 
            this.raddetails.AutoSize = true;
            this.raddetails.Location = new System.Drawing.Point(11, 27);
            this.raddetails.Name = "raddetails";
            this.raddetails.Size = new System.Drawing.Size(57, 17);
            this.raddetails.TabIndex = 3;
            this.raddetails.TabStop = true;
            this.raddetails.Text = "Details";
            this.raddetails.UseVisualStyleBackColor = true;
            // 
            // radconsoli
            // 
            this.radconsoli.AutoSize = true;
            this.radconsoli.Location = new System.Drawing.Point(11, 7);
            this.radconsoli.Name = "radconsoli";
            this.radconsoli.Size = new System.Drawing.Size(86, 17);
            this.radconsoli.TabIndex = 2;
            this.radconsoli.TabStop = true;
            this.radconsoli.Text = "Consolidated";
            this.radconsoli.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpto);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpForm);
            this.groupBox3.Location = new System.Drawing.Point(6, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 56);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Period";
            this.groupBox3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(44, 33);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(92, 20);
            this.dtpto.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Form";
            // 
            // dtpForm
            // 
            this.dtpForm.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpForm.Location = new System.Drawing.Point(44, 10);
            this.dtpForm.Name = "dtpForm";
            this.dtpForm.Size = new System.Drawing.Size(92, 20);
            this.dtpForm.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtEsi);
            this.groupBox7.Controls.Add(this.vistaButton1);
            this.groupBox7.Controls.Add(this.btnPreview);
            this.groupBox7.Controls.Add(this.btnClose);
            this.groupBox7.Controls.Add(this.btnPrnt);
            this.groupBox7.Location = new System.Drawing.Point(6, 214);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 50);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Print Details";
            // 
            // txtEsi
            // 
            this.txtEsi.Location = new System.Drawing.Point(9, 19);
            this.txtEsi.Name = "txtEsi";
            this.txtEsi.Size = new System.Drawing.Size(73, 20);
            this.txtEsi.TabIndex = 271;
            this.txtEsi.Text = "4.75";
            this.txtEsi.Visible = false;
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton1.ButtonText = "Export To Excel";
            this.vistaButton1.CornerRadius = 4;
            this.vistaButton1.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton1.Location = new System.Drawing.Point(88, 13);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(120, 30);
            this.vistaButton1.TabIndex = 22;
            this.vistaButton1.Visible = false;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPreview.ButtonText = "  Preview";
            this.btnPreview.CornerRadius = 4;
            this.btnPreview.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPreview.Location = new System.Drawing.Point(214, 13);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(80, 30);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(386, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 18;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrnt
            // 
            this.btnPrnt.BackColor = System.Drawing.Color.Transparent;
            this.btnPrnt.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnPrnt.ButtonText = "     Print";
            this.btnPrnt.CornerRadius = 4;
            this.btnPrnt.ImageSize = new System.Drawing.Size(16, 16);
            this.btnPrnt.Location = new System.Drawing.Point(300, 13);
            this.btnPrnt.Name = "btnPrnt";
            this.btnPrnt.Size = new System.Drawing.Size(80, 30);
            this.btnPrnt.TabIndex = 17;
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 268;
            this.label3.Text = "PF / ESI Report";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 270;
            this.label4.Text = "Employers Contribution";
            this.label4.Visible = false;
            // 
            // CmbReport
            // 
            this.CmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbReport.FormattingEnabled = true;
            this.CmbReport.Items.AddRange(new object[] {
            "PF",
            "ESI"});
            this.CmbReport.Location = new System.Drawing.Point(404, 187);
            this.CmbReport.Name = "CmbReport";
            this.CmbReport.Size = new System.Drawing.Size(59, 21);
            this.CmbReport.TabIndex = 267;
            this.CmbReport.Visible = false;
            this.CmbReport.SelectedIndexChanged += new System.EventHandler(this.CmbReport_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbYear);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.dateTimePicker1);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Location = new System.Drawing.Point(6, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 55);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(63, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(126, 21);
            this.cmbYear.TabIndex = 259;
            this.cmbYear.DropDown += new System.EventHandler(this.cmbYear_DropDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(6, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 258;
            this.label22.Text = "Session";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "MMMM - yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(333, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(133, 20);
            this.dateTimePicker1.TabIndex = 264;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(290, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 260;
            this.label21.Text = "Month";
            // 
            // txtEmpContribut
            // 
            this.txtEmpContribut.Location = new System.Drawing.Point(404, 155);
            this.txtEmpContribut.Name = "txtEmpContribut";
            this.txtEmpContribut.Size = new System.Drawing.Size(56, 20);
            this.txtEmpContribut.TabIndex = 269;
            this.txtEmpContribut.Visible = false;
            // 
            // frmEmployee_ProfitLossReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 312);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployee_ProfitLossReport";
            this.Text = "Profit and Loss";
            this.Load += new System.EventHandler(this.frmEmployeeSalarySheet_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPfEsi)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private EDPComponent.VistaButton btnPreview;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnPrnt;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpForm;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton raddetails;
        private System.Windows.Forms.RadioButton radconsoli;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.ComboBox cmbYear;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CmbReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmpContribut;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbcompany;
        private EDPComponent.VistaButton vistaButton1;
        private EDPComponent.ComboDialog cmblocation;
        private System.Windows.Forms.TextBox txtEsi;
        private System.Windows.Forms.DataGridView dgPfEsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn eid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pf_bs;
        private System.Windows.Forms.DataGridViewTextBoxColumn esi_bs;
        private System.Windows.Forms.DataGridViewTextBoxColumn pf_contribution;
        private System.Windows.Forms.DataGridViewTextBoxColumn esi_contribution;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private EDPComponent.ComboDialog cmbClient;
    }
}