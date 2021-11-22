namespace PayRollManagementSystem
{
    partial class frmAccountPosting
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountPosting));
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpDoc = new System.Windows.Forms.TabPage();
            this.pnlAuto = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDoc = new TextBoxX.TextBoxX();
            this.btnPrev = new System.Windows.Forms.Button();
            this.txtDemo = new System.Windows.Forms.TextBox();
            this.lblDemo = new System.Windows.Forms.Label();
            this.nudSuf = new System.Windows.Forms.NumericUpDown();
            this.nudPref = new System.Windows.Forms.NumericUpDown();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.lblPos = new System.Windows.Forms.Label();
            this.lblPossuf = new System.Windows.Forms.Label();
            this.lblPospref = new System.Windows.Forms.Label();
            this.txtNumsep = new System.Windows.Forms.TextBox();
            this.txtPad = new System.Windows.Forms.TextBox();
            this.txtSuf = new System.Windows.Forms.TextBox();
            this.txtPref = new System.Windows.Forms.TextBox();
            this.lblPad = new System.Windows.Forms.Label();
            this.lblSuf = new System.Windows.Forms.Label();
            this.lblPre = new System.Windows.Forms.Label();
            this.lblNumsep = new System.Windows.Forms.Label();
            this.gbxNum = new System.Windows.Forms.GroupBox();
            this.lblreq = new System.Windows.Forms.Label();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.rdbMan = new System.Windows.Forms.RadioButton();
            this.tbpAcpost = new System.Windows.Forms.TabPage();
            this.gbxReq = new System.Windows.Forms.GroupBox();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbYes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxRel = new System.Windows.Forms.GroupBox();
            this.lblAc = new System.Windows.Forms.Label();
            this.rdbSing = new System.Windows.Forms.RadioButton();
            this.rdbMul = new System.Windows.Forms.RadioButton();
            this.tbcActype = new System.Windows.Forms.TabControl();
            this.tbpSing = new System.Windows.Forms.TabPage();
            this.lblselected = new System.Windows.Forms.Label();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.lbxList = new System.Windows.Forms.ListBox();
            this.lblHeadlist = new System.Windows.Forms.Label();
            this.tbpMul = new System.Windows.Forms.TabPage();
            this.dgvPost = new System.Windows.Forms.DataGridView();
            this.lblHead = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblSeldoc = new System.Windows.Forms.Label();
            this.tpHint = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDesc = new EDPComponent.ComboDialog();
            this.txtSeldoc = new EDPComponent.ComboDialog();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnDel = new EDPComponent.VistaButton();
            this.btnSave = new EDPComponent.VistaButton();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.btn_showall = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.tbpDoc.SuspendLayout();
            this.pnlAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSuf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPref)).BeginInit();
            this.gbxNum.SuspendLayout();
            this.tbpAcpost.SuspendLayout();
            this.gbxReq.SuspendLayout();
            this.gbxRel.SuspendLayout();
            this.tbcActype.SuspendLayout();
            this.tbpSing.SuspendLayout();
            this.tbpMul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpDoc);
            this.tbcMain.Controls.Add(this.tbpAcpost);
            this.tbcMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcMain.Location = new System.Drawing.Point(13, 119);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(4);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(778, 375);
            this.tbcMain.TabIndex = 1;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tbpDoc
            // 
            this.tbpDoc.Controls.Add(this.pnlAuto);
            this.tbpDoc.Controls.Add(this.gbxNum);
            this.tbpDoc.Location = new System.Drawing.Point(4, 22);
            this.tbpDoc.Margin = new System.Windows.Forms.Padding(4);
            this.tbpDoc.Name = "tbpDoc";
            this.tbpDoc.Padding = new System.Windows.Forms.Padding(4);
            this.tbpDoc.Size = new System.Drawing.Size(770, 349);
            this.tbpDoc.TabIndex = 0;
            this.tbpDoc.Text = "Doc Numbering:-";
            this.tbpDoc.UseVisualStyleBackColor = true;
            // 
            // pnlAuto
            // 
            this.pnlAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuto.Controls.Add(this.lblMsg);
            this.pnlAuto.Controls.Add(this.label2);
            this.pnlAuto.Controls.Add(this.txtDoc);
            this.pnlAuto.Controls.Add(this.btnPrev);
            this.pnlAuto.Controls.Add(this.txtDemo);
            this.pnlAuto.Controls.Add(this.lblDemo);
            this.pnlAuto.Controls.Add(this.nudSuf);
            this.pnlAuto.Controls.Add(this.nudPref);
            this.pnlAuto.Controls.Add(this.txtPos);
            this.pnlAuto.Controls.Add(this.lblPos);
            this.pnlAuto.Controls.Add(this.lblPossuf);
            this.pnlAuto.Controls.Add(this.lblPospref);
            this.pnlAuto.Controls.Add(this.txtNumsep);
            this.pnlAuto.Controls.Add(this.txtPad);
            this.pnlAuto.Controls.Add(this.txtSuf);
            this.pnlAuto.Controls.Add(this.txtPref);
            this.pnlAuto.Controls.Add(this.lblPad);
            this.pnlAuto.Controls.Add(this.lblSuf);
            this.pnlAuto.Controls.Add(this.lblPre);
            this.pnlAuto.Controls.Add(this.lblNumsep);
            this.pnlAuto.Enabled = false;
            this.pnlAuto.Location = new System.Drawing.Point(7, 72);
            this.pnlAuto.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAuto.Name = "pnlAuto";
            this.pnlAuto.Size = new System.Drawing.Size(753, 271);
            this.pnlAuto.TabIndex = 4;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(436, 146);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(292, 77);
            this.lblMsg.TabIndex = 27;
            this.lblMsg.Text = "Can Use abbreviation in prefix for zone wise Document no\r\nComp - Company\r\nZ / Zon" +
                "e - Zone\r\nLoc - Location\r\nclient \r\nlocid \r\nclientid";
            this.lblMsg.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(457, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Last Doc Number";
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(592, 78);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedInteger;
            this.txtDoc.Size = new System.Drawing.Size(139, 21);
            this.txtDoc.TabIndex = 25;
            // 
            // btnPrev
            // 
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Location = new System.Drawing.Point(287, 197);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(136, 26);
            this.btnPrev.TabIndex = 19;
            this.btnPrev.Text = "Demo Preview";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // txtDemo
            // 
            this.txtDemo.BackColor = System.Drawing.Color.White;
            this.txtDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDemo.Location = new System.Drawing.Point(213, 236);
            this.txtDemo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDemo.Name = "txtDemo";
            this.txtDemo.ReadOnly = true;
            this.txtDemo.Size = new System.Drawing.Size(210, 21);
            this.txtDemo.TabIndex = 20;
            this.txtDemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDemo_KeyDown);
            // 
            // lblDemo
            // 
            this.lblDemo.AutoSize = true;
            this.lblDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDemo.Location = new System.Drawing.Point(10, 238);
            this.lblDemo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDemo.Name = "lblDemo";
            this.lblDemo.Size = new System.Drawing.Size(136, 13);
            this.lblDemo.TabIndex = 24;
            this.lblDemo.Text = "Demo Document Number :-";
            // 
            // nudSuf
            // 
            this.nudSuf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudSuf.Location = new System.Drawing.Point(592, 41);
            this.nudSuf.Margin = new System.Windows.Forms.Padding(4);
            this.nudSuf.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudSuf.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSuf.Name = "nudSuf";
            this.nudSuf.Size = new System.Drawing.Size(139, 21);
            this.nudSuf.TabIndex = 15;
            this.nudSuf.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSuf.Leave += new System.EventHandler(this.nudSuf_Leave);
            this.nudSuf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudSuf_KeyDown);
            // 
            // nudPref
            // 
            this.nudPref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPref.Location = new System.Drawing.Point(592, 7);
            this.nudPref.Margin = new System.Windows.Forms.Padding(4);
            this.nudPref.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudPref.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPref.Name = "nudPref";
            this.nudPref.Size = new System.Drawing.Size(139, 21);
            this.nudPref.TabIndex = 13;
            this.nudPref.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPref.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudPref_KeyDown);
            // 
            // txtPos
            // 
            this.txtPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPos.Location = new System.Drawing.Point(213, 163);
            this.txtPos.Margin = new System.Windows.Forms.Padding(4);
            this.txtPos.Name = "txtPos";
            this.txtPos.ReadOnly = true;
            this.txtPos.Size = new System.Drawing.Size(210, 21);
            this.txtPos.TabIndex = 18;
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPos.Location = new System.Drawing.Point(10, 168);
            this.lblPos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(159, 13);
            this.lblPos.TabIndex = 20;
            this.lblPos.Text = "Position of Document Number :-";
            // 
            // lblPossuf
            // 
            this.lblPossuf.AutoSize = true;
            this.lblPossuf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPossuf.Location = new System.Drawing.Point(457, 43);
            this.lblPossuf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPossuf.Name = "lblPossuf";
            this.lblPossuf.Size = new System.Drawing.Size(99, 13);
            this.lblPossuf.TabIndex = 17;
            this.lblPossuf.Text = "Position of Suffix :-";
            // 
            // lblPospref
            // 
            this.lblPospref.AutoSize = true;
            this.lblPospref.CausesValidation = false;
            this.lblPospref.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPospref.Location = new System.Drawing.Point(457, 9);
            this.lblPospref.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPospref.Name = "lblPospref";
            this.lblPospref.Size = new System.Drawing.Size(99, 13);
            this.lblPospref.TabIndex = 16;
            this.lblPospref.Text = "Position of Prefix :-";
            // 
            // txtNumsep
            // 
            this.txtNumsep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumsep.Location = new System.Drawing.Point(213, 122);
            this.txtNumsep.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumsep.Name = "txtNumsep";
            this.txtNumsep.Size = new System.Drawing.Size(210, 21);
            this.txtNumsep.TabIndex = 17;
            this.txtNumsep.TextChanged += new System.EventHandler(this.txtNumsep_TextChanged);
            this.txtNumsep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumsep_KeyDown);
            this.txtNumsep.Leave += new System.EventHandler(this.txtNumsep_Leave);
            // 
            // txtPad
            // 
            this.txtPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPad.Location = new System.Drawing.Point(213, 83);
            this.txtPad.Margin = new System.Windows.Forms.Padding(4);
            this.txtPad.Name = "txtPad";
            this.txtPad.Size = new System.Drawing.Size(210, 21);
            this.txtPad.TabIndex = 16;
            this.txtPad.TextChanged += new System.EventHandler(this.txtPad_TextChanged);
            this.txtPad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPad_KeyDown);
            this.txtPad.Leave += new System.EventHandler(this.txtPad_Leave);
            // 
            // txtSuf
            // 
            this.txtSuf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuf.Location = new System.Drawing.Point(213, 46);
            this.txtSuf.Margin = new System.Windows.Forms.Padding(4);
            this.txtSuf.Name = "txtSuf";
            this.txtSuf.Size = new System.Drawing.Size(210, 21);
            this.txtSuf.TabIndex = 14;
            this.txtSuf.TextChanged += new System.EventHandler(this.txtSuf_TextChanged);
            this.txtSuf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuf_KeyDown);
            this.txtSuf.Leave += new System.EventHandler(this.txtSuf_Leave);
            // 
            // txtPref
            // 
            this.txtPref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPref.Location = new System.Drawing.Point(213, 7);
            this.txtPref.Margin = new System.Windows.Forms.Padding(4);
            this.txtPref.Name = "txtPref";
            this.txtPref.Size = new System.Drawing.Size(210, 21);
            this.txtPref.TabIndex = 12;
            this.txtPref.TextChanged += new System.EventHandler(this.txtPref_TextChanged);
            this.txtPref.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPref_KeyDown);
            this.txtPref.Leave += new System.EventHandler(this.txtPref_Leave);
            // 
            // lblPad
            // 
            this.lblPad.AutoSize = true;
            this.lblPad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPad.Location = new System.Drawing.Point(10, 86);
            this.lblPad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPad.Name = "lblPad";
            this.lblPad.Size = new System.Drawing.Size(56, 13);
            this.lblPad.TabIndex = 11;
            this.lblPad.Text = "Padding :-";
            // 
            // lblSuf
            // 
            this.lblSuf.AutoSize = true;
            this.lblSuf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSuf.Location = new System.Drawing.Point(10, 49);
            this.lblSuf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuf.Name = "lblSuf";
            this.lblSuf.Size = new System.Drawing.Size(46, 13);
            this.lblSuf.TabIndex = 10;
            this.lblSuf.Text = "Suffix :-";
            // 
            // lblPre
            // 
            this.lblPre.AutoSize = true;
            this.lblPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPre.Location = new System.Drawing.Point(10, 13);
            this.lblPre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPre.Name = "lblPre";
            this.lblPre.Size = new System.Drawing.Size(46, 13);
            this.lblPre.TabIndex = 9;
            this.lblPre.Text = "Prefix :-";
            // 
            // lblNumsep
            // 
            this.lblNumsep.AutoSize = true;
            this.lblNumsep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNumsep.Location = new System.Drawing.Point(10, 124);
            this.lblNumsep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumsep.Name = "lblNumsep";
            this.lblNumsep.Size = new System.Drawing.Size(121, 13);
            this.lblNumsep.TabIndex = 8;
            this.lblNumsep.Text = "Number Of Separator :-";
            // 
            // gbxNum
            // 
            this.gbxNum.Controls.Add(this.lblreq);
            this.gbxNum.Controls.Add(this.rdbAuto);
            this.gbxNum.Controls.Add(this.rdbMan);
            this.gbxNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxNum.ForeColor = System.Drawing.Color.Black;
            this.gbxNum.Location = new System.Drawing.Point(7, 6);
            this.gbxNum.Margin = new System.Windows.Forms.Padding(4);
            this.gbxNum.Name = "gbxNum";
            this.gbxNum.Padding = new System.Windows.Forms.Padding(4);
            this.gbxNum.Size = new System.Drawing.Size(392, 59);
            this.gbxNum.TabIndex = 2;
            this.gbxNum.TabStop = false;
            this.gbxNum.Text = "Numbering System";
            // 
            // lblreq
            // 
            this.lblreq.AutoSize = true;
            this.lblreq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblreq.Location = new System.Drawing.Point(7, 22);
            this.lblreq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblreq.Name = "lblreq";
            this.lblreq.Size = new System.Drawing.Size(152, 13);
            this.lblreq.TabIndex = 7;
            this.lblreq.Text = "Required Document Number :-";
            // 
            // rdbAuto
            // 
            this.rdbAuto.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbAuto.AutoSize = true;
            this.rdbAuto.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdbAuto.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbAuto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.rdbAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbAuto.Location = new System.Drawing.Point(199, 16);
            this.rdbAuto.Margin = new System.Windows.Forms.Padding(4);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(67, 25);
            this.rdbAuto.TabIndex = 2;
            this.rdbAuto.Text = "Automatic";
            this.rdbAuto.UseVisualStyleBackColor = true;
            this.rdbAuto.Click += new System.EventHandler(this.rdbAuto_Click);
            this.rdbAuto.CheckedChanged += new System.EventHandler(this.rdbAuto_CheckedChanged);
            // 
            // rdbMan
            // 
            this.rdbMan.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbMan.AutoSize = true;
            this.rdbMan.Checked = true;
            this.rdbMan.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdbMan.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbMan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.rdbMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbMan.Location = new System.Drawing.Point(308, 16);
            this.rdbMan.Margin = new System.Windows.Forms.Padding(4);
            this.rdbMan.Name = "rdbMan";
            this.rdbMan.Size = new System.Drawing.Size(53, 25);
            this.rdbMan.TabIndex = 3;
            this.rdbMan.TabStop = true;
            this.rdbMan.Text = "Manual";
            this.rdbMan.UseVisualStyleBackColor = true;
            this.rdbMan.Click += new System.EventHandler(this.rdbAuto_Click);
            // 
            // tbpAcpost
            // 
            this.tbpAcpost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpAcpost.Controls.Add(this.gbxReq);
            this.tbpAcpost.Controls.Add(this.gbxRel);
            this.tbpAcpost.Controls.Add(this.tbcActype);
            this.tbpAcpost.Location = new System.Drawing.Point(4, 22);
            this.tbpAcpost.Margin = new System.Windows.Forms.Padding(4);
            this.tbpAcpost.Name = "tbpAcpost";
            this.tbpAcpost.Padding = new System.Windows.Forms.Padding(4);
            this.tbpAcpost.Size = new System.Drawing.Size(770, 349);
            this.tbpAcpost.TabIndex = 1;
            this.tbpAcpost.Text = "Account Posting Info:-";
            this.tbpAcpost.UseVisualStyleBackColor = true;
            // 
            // gbxReq
            // 
            this.gbxReq.Controls.Add(this.rdbNo);
            this.gbxReq.Controls.Add(this.rdbYes);
            this.gbxReq.Controls.Add(this.label1);
            this.gbxReq.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxReq.ForeColor = System.Drawing.Color.Black;
            this.gbxReq.Location = new System.Drawing.Point(12, 6);
            this.gbxReq.Name = "gbxReq";
            this.gbxReq.Size = new System.Drawing.Size(278, 95);
            this.gbxReq.TabIndex = 5;
            this.gbxReq.TabStop = false;
            this.gbxReq.Text = "A/C Posting Requirment";
            // 
            // rdbNo
            // 
            this.rdbNo.Checked = true;
            this.rdbNo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdbNo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.rdbNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbNo.Location = new System.Drawing.Point(182, 54);
            this.rdbNo.Margin = new System.Windows.Forms.Padding(4);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(48, 19);
            this.rdbNo.TabIndex = 10;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "NO";
            this.tpHint.SetToolTip(this.rdbNo, "Click No If Not Required");
            this.rdbNo.UseVisualStyleBackColor = true;
            this.rdbNo.Click += new System.EventHandler(this.rdbNo_CheckedChanged);
            this.rdbNo.CheckedChanged += new System.EventHandler(this.rdbNo_CheckedChanged);
            // 
            // rdbYes
            // 
            this.rdbYes.Checked = true;
            this.rdbYes.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdbYes.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.rdbYes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbYes.Location = new System.Drawing.Point(182, 27);
            this.rdbYes.Margin = new System.Windows.Forms.Padding(4);
            this.rdbYes.Name = "rdbYes";
            this.rdbYes.Size = new System.Drawing.Size(48, 19);
            this.rdbYes.TabIndex = 9;
            this.rdbYes.TabStop = true;
            this.rdbYes.Text = "YES";
            this.tpHint.SetToolTip(this.rdbYes, "Click YES If Required");
            this.rdbYes.UseVisualStyleBackColor = true;
            this.rdbYes.Click += new System.EventHandler(this.rdbYes_CheckedChanged);
            this.rdbYes.CheckedChanged += new System.EventHandler(this.rdbYes_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "A/C Posting Required";
            // 
            // gbxRel
            // 
            this.gbxRel.Controls.Add(this.lblAc);
            this.gbxRel.Controls.Add(this.rdbSing);
            this.gbxRel.Controls.Add(this.rdbMul);
            this.gbxRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxRel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRel.ForeColor = System.Drawing.Color.Black;
            this.gbxRel.Location = new System.Drawing.Point(297, 7);
            this.gbxRel.Margin = new System.Windows.Forms.Padding(4);
            this.gbxRel.Name = "gbxRel";
            this.gbxRel.Padding = new System.Windows.Forms.Padding(4);
            this.gbxRel.Size = new System.Drawing.Size(441, 94);
            this.gbxRel.TabIndex = 3;
            this.gbxRel.TabStop = false;
            this.gbxRel.Text = "A/C Relation:-";
            // 
            // lblAc
            // 
            this.lblAc.AutoSize = true;
            this.lblAc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAc.Location = new System.Drawing.Point(7, 41);
            this.lblAc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAc.Name = "lblAc";
            this.lblAc.Size = new System.Drawing.Size(101, 13);
            this.lblAc.TabIndex = 7;
            this.lblAc.Text = "A/C Posting Type :-";
            // 
            // rdbSing
            // 
            this.rdbSing.AutoSize = true;
            this.rdbSing.Checked = true;
            this.rdbSing.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdbSing.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbSing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.rdbSing.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbSing.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSing.Location = new System.Drawing.Point(130, 26);
            this.rdbSing.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSing.Name = "rdbSing";
            this.rdbSing.Size = new System.Drawing.Size(214, 17);
            this.rdbSing.TabIndex = 2;
            this.rdbSing.TabStop = true;
            this.rdbSing.Text = "Entire Bill Amount To Specific A/C Head.";
            this.rdbSing.UseVisualStyleBackColor = true;
            this.rdbSing.Click += new System.EventHandler(this.rdbSing_Click);
            // 
            // rdbMul
            // 
            this.rdbMul.AutoSize = true;
            this.rdbMul.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rdbMul.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rdbMul.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.rdbMul.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbMul.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMul.Location = new System.Drawing.Point(130, 58);
            this.rdbMul.Margin = new System.Windows.Forms.Padding(4);
            this.rdbMul.Name = "rdbMul";
            this.rdbMul.Size = new System.Drawing.Size(251, 17);
            this.rdbMul.TabIndex = 3;
            this.rdbMul.Text = "Specific Posting A/C Head Against Billing Terms.";
            this.rdbMul.UseVisualStyleBackColor = true;
            this.rdbMul.Click += new System.EventHandler(this.rdbMul_Click);
            this.rdbMul.CheckedChanged += new System.EventHandler(this.rdbMul_CheckedChanged);
            // 
            // tbcActype
            // 
            this.tbcActype.Controls.Add(this.tbpSing);
            this.tbcActype.Controls.Add(this.tbpMul);
            this.tbcActype.Location = new System.Drawing.Point(11, 109);
            this.tbcActype.Margin = new System.Windows.Forms.Padding(4);
            this.tbcActype.Name = "tbcActype";
            this.tbcActype.SelectedIndex = 0;
            this.tbcActype.Size = new System.Drawing.Size(733, 259);
            this.tbcActype.TabIndex = 4;
            this.tbcActype.SelectedIndexChanged += new System.EventHandler(this.tbcActype_SelectedIndexChanged);
            // 
            // tbpSing
            // 
            this.tbpSing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpSing.Controls.Add(this.lblselected);
            this.tbpSing.Controls.Add(this.txtSelected);
            this.tbpSing.Controls.Add(this.lbxList);
            this.tbpSing.Controls.Add(this.lblHeadlist);
            this.tbpSing.Location = new System.Drawing.Point(4, 22);
            this.tbpSing.Margin = new System.Windows.Forms.Padding(4);
            this.tbpSing.Name = "tbpSing";
            this.tbpSing.Padding = new System.Windows.Forms.Padding(4);
            this.tbpSing.Size = new System.Drawing.Size(725, 233);
            this.tbpSing.TabIndex = 0;
            this.tbpSing.Text = "Single:-";
            this.tbpSing.UseVisualStyleBackColor = true;
            // 
            // lblselected
            // 
            this.lblselected.AutoSize = true;
            this.lblselected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblselected.Location = new System.Drawing.Point(7, 199);
            this.lblselected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblselected.Name = "lblselected";
            this.lblselected.Size = new System.Drawing.Size(80, 13);
            this.lblselected.TabIndex = 11;
            this.lblselected.Text = "Selected A/C :-";
            this.lblselected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSelected
            // 
            this.txtSelected.BackColor = System.Drawing.Color.White;
            this.txtSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelected.Location = new System.Drawing.Point(119, 197);
            this.txtSelected.Margin = new System.Windows.Forms.Padding(4);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.ReadOnly = true;
            this.txtSelected.Size = new System.Drawing.Size(362, 21);
            this.txtSelected.TabIndex = 10;
            // 
            // lbxList
            // 
            this.lbxList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxList.FormattingEnabled = true;
            this.lbxList.Location = new System.Drawing.Point(119, 34);
            this.lbxList.Margin = new System.Windows.Forms.Padding(4);
            this.lbxList.Name = "lbxList";
            this.lbxList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbxList.Size = new System.Drawing.Size(362, 132);
            this.lbxList.Sorted = true;
            this.lbxList.TabIndex = 9;
            this.lbxList.SelectedIndexChanged += new System.EventHandler(this.lbxList_SelectedIndexChanged);
            // 
            // lblHeadlist
            // 
            this.lblHeadlist.AutoSize = true;
            this.lblHeadlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHeadlist.Location = new System.Drawing.Point(7, 36);
            this.lblHeadlist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeadlist.Name = "lblHeadlist";
            this.lblHeadlist.Size = new System.Drawing.Size(91, 13);
            this.lblHeadlist.TabIndex = 8;
            this.lblHeadlist.Text = "Select One A/C :-";
            this.lblHeadlist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbpMul
            // 
            this.tbpMul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpMul.Controls.Add(this.dgvPost);
            this.tbpMul.Location = new System.Drawing.Point(4, 22);
            this.tbpMul.Margin = new System.Windows.Forms.Padding(4);
            this.tbpMul.Name = "tbpMul";
            this.tbpMul.Padding = new System.Windows.Forms.Padding(4);
            this.tbpMul.Size = new System.Drawing.Size(725, 233);
            this.tbpMul.TabIndex = 1;
            this.tbpMul.Text = "Multiple:-";
            this.tbpMul.UseVisualStyleBackColor = true;
            // 
            // dgvPost
            // 
            this.dgvPost.AllowUserToResizeColumns = false;
            this.dgvPost.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            this.dgvPost.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPost.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPost.ColumnHeadersHeight = 25;
            this.dgvPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPost.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPost.Location = new System.Drawing.Point(7, 9);
            this.dgvPost.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPost.Name = "dgvPost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPost.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPost.RowHeadersVisible = false;
            this.dgvPost.RowHeadersWidth = 25;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPost.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPost.Size = new System.Drawing.Size(712, 214);
            this.dgvPost.TabIndex = 0;
            this.dgvPost.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPost_CellDoubleClick);
            this.dgvPost.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPost_CellClick);
            this.dgvPost.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPost_CellEnter);
            // 
            // lblHead
            // 
            this.lblHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.Location = new System.Drawing.Point(175, 4);
            this.lblHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(203, 17);
            this.lblHead.TabIndex = 12;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDesc.Location = new System.Drawing.Point(298, 48);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(152, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Select or Create Description :-";
            // 
            // lblSeldoc
            // 
            this.lblSeldoc.AutoSize = true;
            this.lblSeldoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSeldoc.Location = new System.Drawing.Point(298, 22);
            this.lblSeldoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeldoc.Name = "lblSeldoc";
            this.lblSeldoc.Size = new System.Drawing.Size(125, 13);
            this.lblSeldoc.TabIndex = 5;
            this.lblSeldoc.Text = "Select Document Type :-";
            // 
            // tpHint
            // 
            this.tpHint.IsBalloon = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtSeldoc);
            this.groupBox1.Controls.Add(this.lblSeldoc);
            this.groupBox1.Controls.Add(this.lblDesc);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(80, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(171, 21);
            this.cmbYear.TabIndex = 241;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(14, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 242;
            this.label22.Text = "Session";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.Connection = null;
            this.txtDesc.DialogResult = "";
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(491, 42);
            this.txtDesc.LOVFlag = 0;
            this.txtDesc.MaxCharLength = 500;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReturnIndex = -1;
            this.txtDesc.ReturnValue = "";
            this.txtDesc.ReturnValue_3rd = "";
            this.txtDesc.ReturnValue_4th = "";
            this.txtDesc.Size = new System.Drawing.Size(244, 21);
            this.txtDesc.TabIndex = 27;
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            this.txtDesc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txtDesc_DropDown);
            this.txtDesc.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.txtDesc_CloseUp);
            // 
            // txtSeldoc
            // 
            this.txtSeldoc.BackColor = System.Drawing.SystemColors.Info;
            this.txtSeldoc.Connection = null;
            this.txtSeldoc.DialogResult = "";
            this.txtSeldoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeldoc.Location = new System.Drawing.Point(491, 18);
            this.txtSeldoc.LOVFlag = 0;
            this.txtSeldoc.MaxCharLength = 500;
            this.txtSeldoc.Name = "txtSeldoc";
            this.txtSeldoc.ReturnIndex = -1;
            this.txtSeldoc.ReturnValue = "";
            this.txtSeldoc.ReturnValue_3rd = "";
            this.txtSeldoc.ReturnValue_4th = "";
            this.txtSeldoc.Size = new System.Drawing.Size(244, 21);
            this.txtSeldoc.TabIndex = 26;
            this.txtSeldoc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbDesg_DropDown);
            this.txtSeldoc.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbDesg_CloseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = " Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageSize = new System.Drawing.Size(18, 18);
            this.btnClose.Location = new System.Drawing.Point(695, 498);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 27;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnDel.ButtonText = " Delete";
            this.btnDel.CornerRadius = 4;
            this.btnDel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(609, 498);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(80, 30);
            this.btnDel.TabIndex = 26;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.ButtonText = " Save";
            this.btnSave.CornerRadius = 4;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageSize = new System.Drawing.Size(16, 16);
            this.btnSave.Location = new System.Drawing.Point(523, 498);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 25;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton1.ButtonText = "Clear";
            this.vistaButton1.CornerRadius = 4;
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton1.Location = new System.Drawing.Point(437, 498);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(80, 30);
            this.vistaButton1.TabIndex = 42;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // btn_showall
            // 
            this.btn_showall.Location = new System.Drawing.Point(609, 96);
            this.btn_showall.Name = "btn_showall";
            this.btn_showall.Size = new System.Drawing.Size(140, 23);
            this.btn_showall.TabIndex = 243;
            this.btn_showall.Text = "Show all Description";
            this.btn_showall.UseVisualStyleBackColor = true;
            this.btn_showall.Click += new System.EventHandler(this.btn_showall_Click);
            // 
            // frmAccountPosting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(792, 528);
            this.Controls.Add(this.btn_showall);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbcMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAccountPosting";
            this.Opacity = 0.95;
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmAccountPosting_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccountPosting_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccountPosting_KeyDown);
            this.Controls.SetChildIndex(this.tbcMain, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.vistaButton1, 0);
            this.Controls.SetChildIndex(this.btn_showall, 0);
            this.tbcMain.ResumeLayout(false);
            this.tbpDoc.ResumeLayout(false);
            this.pnlAuto.ResumeLayout(false);
            this.pnlAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSuf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPref)).EndInit();
            this.gbxNum.ResumeLayout(false);
            this.gbxNum.PerformLayout();
            this.tbpAcpost.ResumeLayout(false);
            this.gbxReq.ResumeLayout(false);
            this.gbxReq.PerformLayout();
            this.gbxRel.ResumeLayout(false);
            this.gbxRel.PerformLayout();
            this.tbcActype.ResumeLayout(false);
            this.tbpSing.ResumeLayout(false);
            this.tbpSing.PerformLayout();
            this.tbpMul.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblSeldoc;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpDoc;
        private System.Windows.Forms.GroupBox gbxNum;
        private System.Windows.Forms.Label lblreq;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.RadioButton rdbMan;
        private System.Windows.Forms.TabPage tbpAcpost;
        private System.Windows.Forms.Panel pnlAuto;
        private System.Windows.Forms.Label lblPad;
        private System.Windows.Forms.Label lblSuf;
        private System.Windows.Forms.Label lblPre;
        private System.Windows.Forms.Label lblNumsep;
        private System.Windows.Forms.TextBox txtPos;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblPossuf;
        private System.Windows.Forms.Label lblPospref;
        private System.Windows.Forms.TextBox txtNumsep;
        private System.Windows.Forms.TextBox txtPad;
        private System.Windows.Forms.TextBox txtSuf;
        private System.Windows.Forms.TextBox txtPref;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TextBox txtDemo;
        private System.Windows.Forms.Label lblDemo;
        private System.Windows.Forms.NumericUpDown nudSuf;
        private System.Windows.Forms.NumericUpDown nudPref;
        private System.Windows.Forms.GroupBox gbxRel;
        private System.Windows.Forms.Label lblAc;
        private System.Windows.Forms.RadioButton rdbSing;
        private System.Windows.Forms.RadioButton rdbMul;
        private System.Windows.Forms.TabControl tbcActype;
        private System.Windows.Forms.TabPage tbpSing;
        private System.Windows.Forms.Label lblHeadlist;
        private System.Windows.Forms.TabPage tbpMul;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Label lblselected;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.ListBox lbxList;
        private System.Windows.Forms.DataGridView dgvPost;
        private System.Windows.Forms.ToolTip tpHint;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox gbxReq;
        private System.Windows.Forms.RadioButton rdbYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnDel;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.Label label2;
        private TextBoxX.TextBoxX txtDoc;
        private EDPComponent.ComboDialog txtSeldoc;
        private EDPComponent.ComboDialog txtDesc;
        private EDPComponent.VistaButton vistaButton1;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btn_showall;
        private System.Windows.Forms.Label lblMsg;
    }
}