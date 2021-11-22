namespace PayRollManagementSystem
{
    partial class frmorderdetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmorderdetails));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEnclosureId = new System.Windows.Forms.CheckedListBox();
            this.chkEnclosure = new System.Windows.Forms.CheckedListBox();
            this.label18 = new System.Windows.Forms.Label();
            this.nudTo = new System.Windows.Forms.NumericUpDown();
            this.nudFrom = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboDialog2 = new EDPComponent.ComboDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.comboDialog1 = new EDPComponent.ComboDialog();
            this.cmblocation = new EDPComponent.ComboDialog();
            this.txtReff = new System.Windows.Forms.TextBox();
            this.txtclintorder = new System.Windows.Forms.TextBox();
            this.cmborderno = new EDPComponent.ComboDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpenddate = new System.Windows.Forms.DateTimePicker();
            this.dtpstartdate = new System.Windows.Forms.DateTimePicker();
            this.dtporderdate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbclintname = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbcompanyname = new EDPComponent.ComboDialog();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtphoneno = new System.Windows.Forms.TextBox();
            this.txtcontractperson = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.dgemployjob = new System.Windows.Forms.DataGridView();
            this.chkAc = new System.Windows.Forms.CheckBox();
            this.btnSave2 = new System.Windows.Forms.Button();
            this.chkAuthorise = new System.Windows.Forms.CheckBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.orderdate = new EDPComponent.CalendarColumn();
            this.Designation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sacno = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Hour = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MontOfDays = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_bmod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colODesg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgemployjob)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnclosureId);
            this.groupBox1.Controls.Add(this.chkEnclosure);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.nudTo);
            this.groupBox1.Controls.Add(this.nudFrom);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.comboDialog2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboDialog1);
            this.groupBox1.Controls.Add(this.cmblocation);
            this.groupBox1.Controls.Add(this.txtReff);
            this.groupBox1.Controls.Add(this.txtclintorder);
            this.groupBox1.Controls.Add(this.cmborderno);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpenddate);
            this.groupBox1.Controls.Add(this.dtpstartdate);
            this.groupBox1.Controls.Add(this.dtporderdate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbclintname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbcompanyname);
            this.groupBox1.Controls.Add(this.txtremarks);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtphoneno);
            this.groupBox1.Controls.Add(this.txtcontractperson);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(11, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1139, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkEnclosureId
            // 
            this.chkEnclosureId.BackColor = System.Drawing.Color.White;
            this.chkEnclosureId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkEnclosureId.CheckOnClick = true;
            this.chkEnclosureId.FormattingEnabled = true;
            this.chkEnclosureId.Location = new System.Drawing.Point(626, 227);
            this.chkEnclosureId.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnclosureId.Name = "chkEnclosureId";
            this.chkEnclosureId.Size = new System.Drawing.Size(109, 87);
            this.chkEnclosureId.TabIndex = 34;
            this.chkEnclosureId.Visible = false;
            // 
            // chkEnclosure
            // 
            this.chkEnclosure.BackColor = System.Drawing.Color.White;
            this.chkEnclosure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkEnclosure.CheckOnClick = true;
            this.chkEnclosure.ForeColor = System.Drawing.Color.Black;
            this.chkEnclosure.FormattingEnabled = true;
            this.chkEnclosure.Location = new System.Drawing.Point(777, 202);
            this.chkEnclosure.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnclosure.Name = "chkEnclosure";
            this.chkEnclosure.Size = new System.Drawing.Size(293, 104);
            this.chkEnclosure.TabIndex = 34;
            this.chkEnclosure.SelectedIndexChanged += new System.EventHandler(this.chkEnclosure_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(614, 200);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 16);
            this.label18.TabIndex = 33;
            this.label18.Text = "Enclosures";
            // 
            // nudTo
            // 
            this.nudTo.Location = new System.Drawing.Point(550, 270);
            this.nudTo.Margin = new System.Windows.Forms.Padding(4);
            this.nudTo.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.nudTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTo.Name = "nudTo";
            this.nudTo.Size = new System.Drawing.Size(55, 22);
            this.nudTo.TabIndex = 32;
            this.nudTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudFrom
            // 
            this.nudFrom.Location = new System.Drawing.Point(432, 270);
            this.nudFrom.Margin = new System.Windows.Forms.Padding(4);
            this.nudFrom.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.nudFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrom.Name = "nudFrom";
            this.nudFrom.Size = new System.Drawing.Size(55, 22);
            this.nudFrom.TabIndex = 31;
            this.nudFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(516, 273);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 16);
            this.label17.TabIndex = 30;
            this.label17.Text = "To";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(384, 273);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 16);
            this.label16.TabIndex = 29;
            this.label16.Text = "From";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(38, 290);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(198, 16);
            this.label15.TabIndex = 28;
            this.label15.Text = "Range Details If Applicable";
            this.label15.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(38, 266);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "Month Of Days";
            this.label13.Visible = false;
            // 
            // comboDialog2
            // 
            this.comboDialog2.Connection = null;
            this.comboDialog2.DialogResult = "";
            this.comboDialog2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDialog2.Location = new System.Drawing.Point(97, 270);
            this.comboDialog2.LOVFlag = 0;
            this.comboDialog2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboDialog2.MaxCharLength = 500;
            this.comboDialog2.Name = "comboDialog2";
            this.comboDialog2.ReturnIndex = -1;
            this.comboDialog2.ReturnValue = "";
            this.comboDialog2.ReturnValue_3rd = "";
            this.comboDialog2.ReturnValue_4th = "";
            this.comboDialog2.Size = new System.Drawing.Size(41, 21);
            this.comboDialog2.TabIndex = 26;
            this.comboDialog2.Visible = false;
            this.comboDialog2.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.comboDialog2_DropDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(38, 237);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Hour";
            this.label11.Visible = false;
            // 
            // comboDialog1
            // 
            this.comboDialog1.Connection = null;
            this.comboDialog1.DialogResult = "";
            this.comboDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDialog1.Location = new System.Drawing.Point(92, 237);
            this.comboDialog1.LOVFlag = 0;
            this.comboDialog1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboDialog1.MaxCharLength = 500;
            this.comboDialog1.Name = "comboDialog1";
            this.comboDialog1.ReturnIndex = -1;
            this.comboDialog1.ReturnValue = "";
            this.comboDialog1.ReturnValue_3rd = "";
            this.comboDialog1.ReturnValue_4th = "";
            this.comboDialog1.Size = new System.Drawing.Size(47, 21);
            this.comboDialog1.TabIndex = 24;
            this.comboDialog1.Visible = false;
            this.comboDialog1.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.comboDialog1_DropDown);
            // 
            // cmblocation
            // 
            this.cmblocation.Connection = null;
            this.cmblocation.DialogResult = "";
            this.cmblocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmblocation.Location = new System.Drawing.Point(235, 72);
            this.cmblocation.LOVFlag = 0;
            this.cmblocation.Margin = new System.Windows.Forms.Padding(4);
            this.cmblocation.MaxCharLength = 500;
            this.cmblocation.Name = "cmblocation";
            this.cmblocation.ReturnIndex = -1;
            this.cmblocation.ReturnValue = "";
            this.cmblocation.ReturnValue_3rd = "";
            this.cmblocation.ReturnValue_4th = "";
            this.cmblocation.Size = new System.Drawing.Size(834, 21);
            this.cmblocation.TabIndex = 23;
            this.cmblocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmblocation_DropDown);
            this.cmblocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmblocation_CloseUp);
            // 
            // txtReff
            // 
            this.txtReff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReff.Location = new System.Drawing.Point(235, 148);
            this.txtReff.Margin = new System.Windows.Forms.Padding(4);
            this.txtReff.Name = "txtReff";
            this.txtReff.Size = new System.Drawing.Size(371, 21);
            this.txtReff.TabIndex = 21;
            // 
            // txtclintorder
            // 
            this.txtclintorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclintorder.Location = new System.Drawing.Point(235, 123);
            this.txtclintorder.Margin = new System.Windows.Forms.Padding(4);
            this.txtclintorder.Name = "txtclintorder";
            this.txtclintorder.Size = new System.Drawing.Size(371, 21);
            this.txtclintorder.TabIndex = 21;
            // 
            // cmborderno
            // 
            this.cmborderno.Connection = null;
            this.cmborderno.DialogResult = "";
            this.cmborderno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmborderno.Location = new System.Drawing.Point(235, 97);
            this.cmborderno.LOVFlag = 0;
            this.cmborderno.Margin = new System.Windows.Forms.Padding(4);
            this.cmborderno.MaxCharLength = 500;
            this.cmborderno.Name = "cmborderno";
            this.cmborderno.ReturnIndex = -1;
            this.cmborderno.ReturnValue = "";
            this.cmborderno.ReturnValue_3rd = "";
            this.cmborderno.ReturnValue_4th = "";
            this.cmborderno.Size = new System.Drawing.Size(371, 21);
            this.cmborderno.TabIndex = 0;
            this.cmborderno.Leave += new System.EventHandler(this.cmborderno_Leave);
            this.cmborderno.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmborderno_DropDown);
            this.cmborderno.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmborderno_CloseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 76);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Location";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(615, 149);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "End Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(615, 126);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Order Start Date";
            // 
            // dtpenddate
            // 
            this.dtpenddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpenddate.Location = new System.Drawing.Point(776, 147);
            this.dtpenddate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpenddate.Name = "dtpenddate";
            this.dtpenddate.Size = new System.Drawing.Size(292, 22);
            this.dtpenddate.TabIndex = 7;
            // 
            // dtpstartdate
            // 
            this.dtpstartdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpstartdate.Location = new System.Drawing.Point(777, 121);
            this.dtpstartdate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpstartdate.Name = "dtpstartdate";
            this.dtpstartdate.Size = new System.Drawing.Size(292, 22);
            this.dtpstartdate.TabIndex = 6;
            // 
            // dtporderdate
            // 
            this.dtporderdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtporderdate.Location = new System.Drawing.Point(777, 97);
            this.dtporderdate.Margin = new System.Windows.Forms.Padding(4);
            this.dtporderdate.Name = "dtporderdate";
            this.dtporderdate.Size = new System.Drawing.Size(292, 22);
            this.dtporderdate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(614, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Order Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 206);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Remarks";
            // 
            // cmbclintname
            // 
            this.cmbclintname.Connection = null;
            this.cmbclintname.DialogResult = "";
            this.cmbclintname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclintname.Location = new System.Drawing.Point(235, 48);
            this.cmbclintname.LOVFlag = 0;
            this.cmbclintname.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclintname.MaxCharLength = 500;
            this.cmbclintname.Name = "cmbclintname";
            this.cmbclintname.ReturnIndex = -1;
            this.cmbclintname.ReturnValue = "";
            this.cmbclintname.ReturnValue_3rd = "";
            this.cmbclintname.ReturnValue_4th = "";
            this.cmbclintname.Size = new System.Drawing.Size(834, 21);
            this.cmbclintname.TabIndex = 3;
            this.cmbclintname.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbclintname_DropDown);
            this.cmbclintname.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbclintname_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client Name";
            // 
            // cmbcompanyname
            // 
            this.cmbcompanyname.Connection = null;
            this.cmbcompanyname.DialogResult = "";
            this.cmbcompanyname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompanyname.Location = new System.Drawing.Point(235, 23);
            this.cmbcompanyname.LOVFlag = 0;
            this.cmbcompanyname.Margin = new System.Windows.Forms.Padding(4);
            this.cmbcompanyname.MaxCharLength = 500;
            this.cmbcompanyname.Name = "cmbcompanyname";
            this.cmbcompanyname.ReturnIndex = -1;
            this.cmbcompanyname.ReturnValue = "";
            this.cmbcompanyname.ReturnValue_3rd = "";
            this.cmbcompanyname.ReturnValue_4th = "";
            this.cmbcompanyname.Size = new System.Drawing.Size(834, 21);
            this.cmbcompanyname.TabIndex = 2;
            this.cmbcompanyname.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompanyname_DropDown);
            this.cmbcompanyname.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompanyname_CloseUp);
            // 
            // txtremarks
            // 
            this.txtremarks.Location = new System.Drawing.Point(236, 206);
            this.txtremarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(369, 59);
            this.txtremarks.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(615, 179);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Phone No.";
            // 
            // txtphoneno
            // 
            this.txtphoneno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphoneno.Location = new System.Drawing.Point(777, 176);
            this.txtphoneno.Margin = new System.Windows.Forms.Padding(4);
            this.txtphoneno.Name = "txtphoneno";
            this.txtphoneno.Size = new System.Drawing.Size(292, 21);
            this.txtphoneno.TabIndex = 5;
            // 
            // txtcontractperson
            // 
            this.txtcontractperson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontractperson.Location = new System.Drawing.Point(236, 179);
            this.txtcontractperson.Margin = new System.Windows.Forms.Padding(4);
            this.txtcontractperson.Name = "txtcontractperson";
            this.txtcontractperson.Size = new System.Drawing.Size(371, 21);
            this.txtcontractperson.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contract Person";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(35, 152);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 16);
            this.label14.TabIndex = 22;
            this.label14.Text = "Reference No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Order No.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 126);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 16);
            this.label12.TabIndex = 22;
            this.label12.Text = "Client Order No.";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(337, 530);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 31);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(948, 530);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 31);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1051, 530);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 31);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnclear
            // 
            this.btnclear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnclear.BackColor = System.Drawing.Color.Black;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(258, 530);
            this.btnclear.Margin = new System.Windows.Forms.Padding(4);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(71, 31);
            this.btnclear.TabIndex = 42;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // dgemployjob
            // 
            this.dgemployjob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgemployjob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgemployjob.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgemployjob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgemployjob.ColumnHeadersHeight = 30;
            this.dgemployjob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Client_id,
            this.Loc_id,
            this.OrderNo,
            this.orderdate,
            this.Designation,
            this.sacno,
            this.Hour,
            this.MontOfDays,
            this.col_bmod,
            this.Rate,
            this.nop,
            this.colRem,
            this.colODesg});
            this.dgemployjob.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgemployjob.Location = new System.Drawing.Point(13, 351);
            this.dgemployjob.Margin = new System.Windows.Forms.Padding(4);
            this.dgemployjob.Name = "dgemployjob";
            this.dgemployjob.RowHeadersVisible = false;
            this.dgemployjob.Size = new System.Drawing.Size(1138, 169);
            this.dgemployjob.TabIndex = 84;
            this.dgemployjob.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgemployjob_UserDeletingRow);
            this.dgemployjob.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgemployjob_CellEndEdit);
            this.dgemployjob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgemployjob_KeyDown);
            this.dgemployjob.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgemployjob_CellEnter);
            // 
            // chkAc
            // 
            this.chkAc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAc.AutoSize = true;
            this.chkAc.Location = new System.Drawing.Point(14, 525);
            this.chkAc.Margin = new System.Windows.Forms.Padding(4);
            this.chkAc.Name = "chkAc";
            this.chkAc.Size = new System.Drawing.Size(184, 36);
            this.chkAc.TabIndex = 85;
            this.chkAc.Text = "Include Addtional Charges\r\nand save";
            this.chkAc.UseVisualStyleBackColor = true;
            this.chkAc.Visible = false;
            // 
            // btnSave2
            // 
            this.btnSave2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave2.BackColor = System.Drawing.Color.Black;
            this.btnSave2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave2.ForeColor = System.Drawing.Color.White;
            this.btnSave2.Location = new System.Drawing.Point(485, 530);
            this.btnSave2.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(326, 32);
            this.btnSave2.TabIndex = 23;
            this.btnSave2.Text = "Save and go to additional charges";
            this.btnSave2.UseVisualStyleBackColor = false;
            this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
            // 
            // chkAuthorise
            // 
            this.chkAuthorise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAuthorise.AutoSize = true;
            this.chkAuthorise.Location = new System.Drawing.Point(862, 535);
            this.chkAuthorise.Margin = new System.Windows.Forms.Padding(4);
            this.chkAuthorise.Name = "chkAuthorise";
            this.chkAuthorise.Size = new System.Drawing.Size(83, 20);
            this.chkAuthorise.TabIndex = 285;
            this.chkAuthorise.Text = "Authorise";
            this.chkAuthorise.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "STATE_CODE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.FillWeight = 5F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // Client_id
            // 
            this.Client_id.FillWeight = 5F;
            this.Client_id.HeaderText = "Client_id";
            this.Client_id.Name = "Client_id";
            this.Client_id.ReadOnly = true;
            this.Client_id.Visible = false;
            // 
            // Loc_id
            // 
            this.Loc_id.FillWeight = 5F;
            this.Loc_id.HeaderText = "Loc_id";
            this.Loc_id.Name = "Loc_id";
            this.Loc_id.ReadOnly = true;
            this.Loc_id.Visible = false;
            // 
            // OrderNo
            // 
            this.OrderNo.FillWeight = 5F;
            this.OrderNo.HeaderText = "Order No";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OrderNo.Visible = false;
            // 
            // orderdate
            // 
            this.orderdate.FillWeight = 5F;
            this.orderdate.HeaderText = "Order Date";
            this.orderdate.Name = "orderdate";
            this.orderdate.Visible = false;
            // 
            // Designation
            // 
            this.Designation.DataPropertyName = "DesignationName";
            this.Designation.FillWeight = 37.5453F;
            this.Designation.HeaderText = "Designation";
            this.Designation.Name = "Designation";
            this.Designation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Designation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // sacno
            // 
            this.sacno.FillWeight = 14.07949F;
            this.sacno.HeaderText = "SAC No";
            this.sacno.Name = "sacno";
            // 
            // Hour
            // 
            this.Hour.DataPropertyName = "Hour";
            this.Hour.FillWeight = 10.38035F;
            this.Hour.HeaderText = "Hrs Basis";
            this.Hour.Name = "Hour";
            this.Hour.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Hour.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // MontOfDays
            // 
            this.MontOfDays.DataPropertyName = "MontOfDays";
            this.MontOfDays.FillWeight = 10.38035F;
            this.MontOfDays.HeaderText = "Attendance Unit";
            this.MontOfDays.Name = "MontOfDays";
            this.MontOfDays.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MontOfDays.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_bmod
            // 
            this.col_bmod.FillWeight = 14.07949F;
            this.col_bmod.HeaderText = "Bill Mod";
            this.col_bmod.Items.AddRange(new object[] {
            "Sal 08hrs - Bill 08hrs",
            "Sal 08hrs - Bill 12hrs",
            "Sal 12hrs - Bill 12hrs"});
            this.col_bmod.Name = "col_bmod";
            // 
            // Rate
            // 
            this.Rate.FillWeight = 10.38035F;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // nop
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.nop.DefaultCellStyle = dataGridViewCellStyle3;
            this.nop.FillWeight = 8F;
            this.nop.HeaderText = "N.O.P";
            this.nop.MinimumWidth = 8;
            this.nop.Name = "nop";
            this.nop.ToolTipText = "NoOfPersonnel";
            // 
            // colRem
            // 
            this.colRem.FillWeight = 19.76241F;
            this.colRem.HeaderText = "Remarks";
            this.colRem.Name = "colRem";
            // 
            // colODesg
            // 
            this.colODesg.HeaderText = "ODesg";
            this.colODesg.Name = "colODesg";
            this.colODesg.Visible = false;
            // 
            // frmorderdetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1164, 562);
            this.Controls.Add(this.chkAuthorise);
            this.Controls.Add(this.chkAc);
            this.Controls.Add(this.dgemployjob);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmorderdetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.frmorderdetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgemployjob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private EDPComponent.ComboDialog cmbclintname;
        private System.Windows.Forms.Label label2;
        private EDPComponent.ComboDialog cmbcompanyname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtporderdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpenddate;
        private System.Windows.Forms.DateTimePicker dtpstartdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtphoneno;
        private System.Windows.Forms.TextBox txtcontractperson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private EDPComponent.ComboDialog cmborderno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtclintorder;
        private EDPComponent.ComboDialog cmblocation;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.DataGridView dgemployjob;
        private System.Windows.Forms.Label label13;
        private EDPComponent.ComboDialog comboDialog2;
        private System.Windows.Forms.Label label11;
        private EDPComponent.ComboDialog comboDialog1;
        private System.Windows.Forms.TextBox txtReff;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkAc;
        private System.Windows.Forms.Button btnSave2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudTo;
        private System.Windows.Forms.NumericUpDown nudFrom;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkAuthorise;
        private System.Windows.Forms.CheckedListBox chkEnclosure;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckedListBox chkEnclosureId;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loc_id;
        private System.Windows.Forms.DataGridViewComboBoxColumn OrderNo;
        private EDPComponent.CalendarColumn orderdate;
        private System.Windows.Forms.DataGridViewComboBoxColumn Designation;
        private System.Windows.Forms.DataGridViewComboBoxColumn sacno;
        private System.Windows.Forms.DataGridViewComboBoxColumn Hour;
        private System.Windows.Forms.DataGridViewComboBoxColumn MontOfDays;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_bmod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn nop;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colODesg;
    }
}