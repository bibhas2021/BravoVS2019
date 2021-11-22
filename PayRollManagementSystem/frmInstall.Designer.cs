namespace PayRollManagementSystem
{
    partial class frmInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstall));
            this.gpbIns = new System.Windows.Forms.GroupBox();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmbcountry = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtState = new EDPComponent.ComboDialog();
            this.btnClo = new EDPComponent.VistaButton();
            this.btnAdd = new EDPComponent.VistaButton();
            this.btnBack = new EDPComponent.VistaButton();
            this.mtxEnddate = new System.Windows.Forms.DateTimePicker();
            this.mtxStrdate = new System.Windows.Forms.DateTimePicker();
            this.lblEnddate = new System.Windows.Forms.Label();
            this.lblStrdate = new System.Windows.Forms.Label();
            this.cboCompanyname = new System.Windows.Forms.ComboBox();
            this.lblCom = new System.Windows.Forms.Label();
            this.lbxFi = new System.Windows.Forms.ListBox();
            this.gpbMain = new System.Windows.Forms.GroupBox();
            this.btnNext = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.rdbEx = new System.Windows.Forms.RadioButton();
            this.rdbNew = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gpbIns.SuspendLayout();
            this.gpbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbIns
            // 
            this.gpbIns.BackColor = System.Drawing.Color.Snow;
            this.gpbIns.Controls.Add(this.vistaButton1);
            this.gpbIns.Controls.Add(this.label2);
            this.gpbIns.Controls.Add(this.Cmbcountry);
            this.gpbIns.Controls.Add(this.label1);
            this.gpbIns.Controls.Add(this.txtState);
            this.gpbIns.Controls.Add(this.btnClo);
            this.gpbIns.Controls.Add(this.btnAdd);
            this.gpbIns.Controls.Add(this.btnBack);
            this.gpbIns.Controls.Add(this.mtxEnddate);
            this.gpbIns.Controls.Add(this.mtxStrdate);
            this.gpbIns.Controls.Add(this.lblEnddate);
            this.gpbIns.Controls.Add(this.lblStrdate);
            this.gpbIns.Controls.Add(this.cboCompanyname);
            this.gpbIns.Controls.Add(this.lblCom);
            this.gpbIns.Controls.Add(this.lbxFi);
            this.gpbIns.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbIns.ForeColor = System.Drawing.Color.Black;
            this.gpbIns.Location = new System.Drawing.Point(10, 10);
            this.gpbIns.Name = "gpbIns";
            this.gpbIns.Size = new System.Drawing.Size(485, 290);
            this.gpbIns.TabIndex = 0;
            this.gpbIns.TabStop = false;
            this.gpbIns.Text = "Details";
            this.gpbIns.Visible = false;
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton1.ButtonText = "    Create Currency";
            this.vistaButton1.CornerRadius = 4;
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.GlowColor = System.Drawing.Color.White;
            ////////////this.vistaButton1.Image = global::PayRollManagementSystem.Properties.Resources.free1;
            this.vistaButton1.ImageSize = new System.Drawing.Size(14, 14);
            this.vistaButton1.Location = new System.Drawing.Point(70, 247);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(121, 30);
            this.vistaButton1.TabIndex = 60;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 59;
            this.label2.Text = "Country Name ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cmbcountry
            // 
            this.Cmbcountry.Connection = null;
            this.Cmbcountry.DialogResult = "";
            this.Cmbcountry.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmbcountry.Heading = "f";
            this.Cmbcountry.Location = new System.Drawing.Point(93, 64);
            this.Cmbcountry.LOVFlag = 0;
            this.Cmbcountry.MaxCharLength = 500;
            this.Cmbcountry.Name = "Cmbcountry";
            this.Cmbcountry.ReturnIndex = -1;
            this.Cmbcountry.ReturnValue = "";
            this.Cmbcountry.ReturnValue_3rd = "";
            this.Cmbcountry.ReturnValue_4th = "";
            this.Cmbcountry.SelectSingleItem = true;
            this.Cmbcountry.Size = new System.Drawing.Size(192, 21);
            this.Cmbcountry.TabIndex = 1;
            this.Cmbcountry.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.Cmbcountry_DropDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 57;
            this.label1.Text = "State Name ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtState
            // 
            this.txtState.Connection = null;
            this.txtState.DialogResult = "";
            this.txtState.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.Heading = "f";
            this.txtState.Location = new System.Drawing.Point(93, 103);
            this.txtState.LOVFlag = 0;
            this.txtState.MaxCharLength = 500;
            this.txtState.Name = "txtState";
            this.txtState.ReturnIndex = -1;
            this.txtState.ReturnValue = "";
            this.txtState.ReturnValue_3rd = "";
            this.txtState.ReturnValue_4th = "";
            this.txtState.SelectSingleItem = true;
            this.txtState.Size = new System.Drawing.Size(192, 21);
            this.txtState.TabIndex = 2;
            this.txtState.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txtState_DropDown);
            this.txtState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtState_KeyDown);
            // 
            // btnClo
            // 
            this.btnClo.BackColor = System.Drawing.Color.Transparent;
            this.btnClo.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClo.ButtonText = "     Close";
            this.btnClo.CornerRadius = 4;
            this.btnClo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClo.GlowColor = System.Drawing.Color.White;
            ////////////this.btnClo.Image = global::PayRollManagementSystem.Properties.Resources.W95MBX01;
            this.btnClo.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClo.Location = new System.Drawing.Point(400, 247);
            this.btnClo.Name = "btnClo";
            this.btnClo.Size = new System.Drawing.Size(80, 30);
            this.btnClo.TabIndex = 6;
            this.btnClo.Click += new System.EventHandler(this.btnClo_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.ButtonText = "    Install";
            this.btnAdd.CornerRadius = 4;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.GlowColor = System.Drawing.Color.White;
            ////////////////this.btnAdd.Image = global::PayRollManagementSystem.Properties.Resources._02;
            this.btnAdd.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAdd.Location = new System.Drawing.Point(305, 247);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnBack.ButtonText = "    Back";
            this.btnBack.CornerRadius = 4;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.GlowColor = System.Drawing.Color.White;
            ////////////////this.btnBack.Image = global::PayRollManagementSystem.Properties.Resources.top;
            this.btnBack.ImageSize = new System.Drawing.Size(16, 16);
            this.btnBack.Location = new System.Drawing.Point(205, 247);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 53;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // mtxEnddate
            // 
            this.mtxEnddate.CustomFormat = "dd/MM/yyyy";
            this.mtxEnddate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxEnddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mtxEnddate.Location = new System.Drawing.Point(94, 176);
            this.mtxEnddate.Name = "mtxEnddate";
            this.mtxEnddate.Size = new System.Drawing.Size(191, 21);
            this.mtxEnddate.TabIndex = 4;
            this.mtxEnddate.Value = new System.DateTime(2008, 2, 9, 0, 0, 0, 0);
            this.mtxEnddate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxEnddate_KeyDown);
            // 
            // mtxStrdate
            // 
            this.mtxStrdate.CustomFormat = "dd/MM/yyyy";
            this.mtxStrdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxStrdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mtxStrdate.Location = new System.Drawing.Point(93, 139);
            this.mtxStrdate.Name = "mtxStrdate";
            this.mtxStrdate.Size = new System.Drawing.Size(192, 21);
            this.mtxStrdate.TabIndex = 3;
            this.mtxStrdate.Value = new System.DateTime(2008, 2, 9, 0, 0, 0, 0);
            this.mtxStrdate.Leave += new System.EventHandler(this.mtxStrdate_Leave);
            this.mtxStrdate.CloseUp += new System.EventHandler(this.mtxStrdate_CloseUp);
            this.mtxStrdate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxStrdate_KeyDown);
            // 
            // lblEnddate
            // 
            this.lblEnddate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnddate.Location = new System.Drawing.Point(11, 177);
            this.lblEnddate.Name = "lblEnddate";
            this.lblEnddate.Size = new System.Drawing.Size(94, 18);
            this.lblEnddate.TabIndex = 14;
            this.lblEnddate.Text = "Ending Date";
            this.lblEnddate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStrdate
            // 
            this.lblStrdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrdate.Location = new System.Drawing.Point(10, 140);
            this.lblStrdate.Name = "lblStrdate";
            this.lblStrdate.Size = new System.Drawing.Size(94, 18);
            this.lblStrdate.TabIndex = 10;
            this.lblStrdate.Text = "Starting Date ";
            this.lblStrdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCompanyname
            // 
            this.cboCompanyname.BackColor = System.Drawing.SystemColors.Window;
            this.cboCompanyname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboCompanyname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCompanyname.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompanyname.FormattingEnabled = true;
            this.cboCompanyname.Location = new System.Drawing.Point(92, 24);
            this.cboCompanyname.Name = "cboCompanyname";
            this.cboCompanyname.Size = new System.Drawing.Size(388, 23);
            this.cboCompanyname.TabIndex = 0;
            this.cboCompanyname.Leave += new System.EventHandler(this.cboCompanyname_Leave);
            this.cboCompanyname.SelectedIndexChanged += new System.EventHandler(this.cboCompanyname_SelectedIndexChanged);
            this.cboCompanyname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCompanyname_KeyDown);
            // 
            // lblCom
            // 
            this.lblCom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCom.Location = new System.Drawing.Point(9, 25);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(94, 19);
            this.lblCom.TabIndex = 3;
            this.lblCom.Text = "Company Name ";
            this.lblCom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbxFi
            // 
            this.lbxFi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxFi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxFi.FormattingEnabled = true;
            this.lbxFi.HorizontalScrollbar = true;
            this.lbxFi.Location = new System.Drawing.Point(314, 63);
            this.lbxFi.Name = "lbxFi";
            this.lbxFi.Size = new System.Drawing.Size(166, 132);
            this.lbxFi.TabIndex = 23;
            this.lbxFi.Visible = false;
            // 
            // gpbMain
            // 
            this.gpbMain.Controls.Add(this.btnClose);
            this.gpbMain.Controls.Add(this.rdbEx);
            this.gpbMain.Controls.Add(this.rdbNew);
            this.gpbMain.Controls.Add(this.btnNext);
            this.gpbMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbMain.ForeColor = System.Drawing.Color.Black;
            this.gpbMain.Location = new System.Drawing.Point(7, 12);
            this.gpbMain.Name = "gpbMain";
            this.gpbMain.Size = new System.Drawing.Size(490, 288);
            this.gpbMain.TabIndex = 1;
            this.gpbMain.TabStop = false;
            this.gpbMain.Text = "Select One Option:-";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnNext.ButtonText = "  Next";
            this.btnNext.CornerRadius = 4;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.GlowColor = System.Drawing.Color.White;
            //////////////this.btnNext.Image = global::PayRollManagementSystem.Properties.Resources.bot;
            this.btnNext.ImageSize = new System.Drawing.Size(16, 16);
            this.btnNext.Location = new System.Drawing.Point(269, 245);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 30);
            this.btnNext.TabIndex = 57;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = "   Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.GlowColor = System.Drawing.Color.White;
            //////////////this.btnClose.Image = global::PayRollManagementSystem.Properties.Resources.W95MBX01;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(375, 245);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 56;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rdbEx
            // 
            this.rdbEx.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbEx.AutoSize = true;
            this.rdbEx.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.rdbEx.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.rdbEx.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.rdbEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbEx.Location = new System.Drawing.Point(117, 132);
            this.rdbEx.Name = "rdbEx";
            this.rdbEx.Size = new System.Drawing.Size(246, 25);
            this.rdbEx.TabIndex = 17;
            this.rdbEx.Text = "Install New Financial Year for Existing Company";
            this.rdbEx.UseVisualStyleBackColor = true;
            // 
            // rdbNew
            // 
            this.rdbNew.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbNew.AutoSize = true;
            this.rdbNew.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSteelBlue;
            this.rdbNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.rdbNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.rdbNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbNew.Location = new System.Drawing.Point(146, 77);
            this.rdbNew.Name = "rdbNew";
            this.rdbNew.Size = new System.Drawing.Size(193, 25);
            this.rdbNew.TabIndex = 16;
            this.rdbNew.Text = "Create New Company Or Investor\'s ";
            this.rdbNew.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            ////////////this.pictureBox2.Image = global::PayRollManagementSystem.Properties.Resources.FILECOPY_16;
            this.pictureBox2.Location = new System.Drawing.Point(114, 324);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(293, 42);
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(173, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Wait Company is being Installed";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(328, 402);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(4, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 14);
            this.label3.TabIndex = 61;
            this.label3.Text = "Press F5 >> For Save";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // frmInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(502, 325);
            this.Controls.Add(this.gpbIns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.gpbMain);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmInstall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInstall_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInstall_KeyDown);
            this.Load += new System.EventHandler(this.frmInstall_Load);
            this.gpbIns.ResumeLayout(false);
            this.gpbMain.ResumeLayout(false);
            this.gpbMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbIns;
        private System.Windows.Forms.DateTimePicker mtxEnddate;
        private System.Windows.Forms.DateTimePicker mtxStrdate;
        private System.Windows.Forms.Label lblEnddate;
        private System.Windows.Forms.Label lblStrdate;
        private System.Windows.Forms.ComboBox cboCompanyname;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.ListBox lbxFi;
        private System.Windows.Forms.GroupBox gpbMain;
        private System.Windows.Forms.RadioButton rdbEx;
        private System.Windows.Forms.RadioButton rdbNew;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private EDPComponent.VistaButton btnBack;
        private EDPComponent.VistaButton btnClo;
        private EDPComponent.VistaButton btnAdd;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnNext;
        private System.Windows.Forms.Label label1;
        private EDPComponent.ComboDialog txtState;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private EDPComponent.ComboDialog Cmbcountry;
        private EDPComponent.VistaButton vistaButton1;
        private System.Windows.Forms.Label label3;
    }
}