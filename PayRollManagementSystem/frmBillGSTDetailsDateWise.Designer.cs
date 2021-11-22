namespace PayRollManagementSystem
{
    partial class frmBillGSTDetailsDateWise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillGSTDetailsDateWise));
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbcompanyname = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnCLear = new EDPComponent.VistaButton();
            this.dgvGSTStatement = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGSTStatement)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(167, 38);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(161, 20);
            this.dateTo.TabIndex = 43;
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(167, 12);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(161, 20);
            this.dateFrom.TabIndex = 42;
            // 
            // cmbcompanyname
            // 
            this.cmbcompanyname.Connection = null;
            this.cmbcompanyname.DialogResult = "";
            this.cmbcompanyname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompanyname.Location = new System.Drawing.Point(182, 14);
            this.cmbcompanyname.LOVFlag = 0;
            this.cmbcompanyname.MaxCharLength = 500;
            this.cmbcompanyname.Name = "cmbcompanyname";
            this.cmbcompanyname.ReturnIndex = -1;
            this.cmbcompanyname.ReturnValue = "";
            this.cmbcompanyname.ReturnValue_3rd = "";
            this.cmbcompanyname.ReturnValue_4th = "";
            this.cmbcompanyname.Size = new System.Drawing.Size(577, 21);
            this.cmbcompanyname.TabIndex = 44;
            this.cmbcompanyname.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompanyname_DropDown);
            this.cmbcompanyname.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompanyname_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 46;
            this.label2.Text = "Bill Date From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 47;
            this.label3.Text = "Bill Date To";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCLear);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Location = new System.Drawing.Point(15, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 73);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill Date Details";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(14, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(745, 52);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Print Details";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(559, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 30);
            this.button1.TabIndex = 315;
            this.button1.Text = "Preview to Print";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.SlateGray;
            this.btnSave.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ButtonText = "Preview";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.GlowColor = System.Drawing.Color.Aqua;
            this.btnSave.Location = new System.Drawing.Point(558, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 29);
            this.btnSave.TabIndex = 313;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCLear
            // 
            this.btnCLear.BackColor = System.Drawing.Color.Transparent;
            this.btnCLear.BaseColor = System.Drawing.Color.SlateGray;
            this.btnCLear.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnCLear.ButtonText = "Clear";
            this.btnCLear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLear.GlowColor = System.Drawing.Color.Aqua;
            this.btnCLear.Location = new System.Drawing.Point(651, 19);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(87, 29);
            this.btnCLear.TabIndex = 314;
            this.btnCLear.Click += new System.EventHandler(this.btnCLear_Click);
            // 
            // dgvGSTStatement
            // 
            this.dgvGSTStatement.AllowUserToAddRows = false;
            this.dgvGSTStatement.AllowUserToDeleteRows = false;
            this.dgvGSTStatement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGSTStatement.Location = new System.Drawing.Point(14, 188);
            this.dgvGSTStatement.Name = "dgvGSTStatement";
            this.dgvGSTStatement.ReadOnly = true;
            this.dgvGSTStatement.Size = new System.Drawing.Size(745, 284);
            this.dgvGSTStatement.TabIndex = 50;
            this.dgvGSTStatement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGSTStatement_CellContentClick);
            // 
            // frmBillGSTDetailsDateWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(771, 484);
            this.Controls.Add(this.dgvGSTStatement);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbcompanyname);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBillGSTDetailsDateWise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill & GST Details DateWise";
            this.Load += new System.EventHandler(this.frmBillGSTDetailsDateWise_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGSTStatement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private EDPComponent.ComboDialog cmbcompanyname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnCLear;
        private System.Windows.Forms.DataGridView dgvGSTStatement;
        private System.Windows.Forms.Button button1;
    }
}