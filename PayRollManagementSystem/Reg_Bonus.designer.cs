namespace PayRollManagementSystem
{
    partial class Reg_Bonus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reg_Bonus));
            this.btnPrev = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btnlog = new EDPComponent.VistaButton();
            this.rdb_Co = new System.Windows.Forms.RadioButton();
            this.rdb_loc = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.BaseColor = System.Drawing.Color.Ivory;
            this.btnPrev.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnPrev.ButtonText = "Preview";
            this.btnPrev.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ForeColor = System.Drawing.Color.Black;
            this.btnPrev.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnPrev.Location = new System.Drawing.Point(224, 183);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(87, 26);
            this.btnPrev.TabIndex = 15;
            this.btnPrev.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Ivory;
            this.btnClose.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClose.Location = new System.Drawing.Point(411, 182);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 26);
            this.btnClose.TabIndex = 16;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(92, 28);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(137, 21);
            this.cmbYear.TabIndex = 262;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 263;
            this.label1.Text = "SESSION";
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "MMMM - yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(337, 29);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(133, 20);
            this.AttenDtTmPkr.TabIndex = 313;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 314;
            this.label4.Text = "MONTH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 315;
            this.label2.Text = "COMPANY";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(79, 99);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(399, 21);
            this.cmbcompany.TabIndex = 316;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 317;
            this.label3.Text = "LOCATION";
            // 
            // btnlog
            // 
            this.btnlog.BackColor = System.Drawing.Color.Transparent;
            this.btnlog.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnlog.ButtonText = "Select Location";
            this.btnlog.CornerRadius = 4;
            this.btnlog.ImageSize = new System.Drawing.Size(16, 16);
            this.btnlog.Location = new System.Drawing.Point(82, 135);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(132, 28);
            this.btnlog.TabIndex = 318;
            this.btnlog.Click += new System.EventHandler(this.btnlog_Click);
            // 
            // rdb_Co
            // 
            this.rdb_Co.AutoSize = true;
            this.rdb_Co.Checked = true;
            this.rdb_Co.Location = new System.Drawing.Point(107, 8);
            this.rdb_Co.Name = "rdb_Co";
            this.rdb_Co.Size = new System.Drawing.Size(93, 17);
            this.rdb_Co.TabIndex = 319;
            this.rdb_Co.TabStop = true;
            this.rdb_Co.Text = "Company wise";
            this.rdb_Co.UseVisualStyleBackColor = true;
            this.rdb_Co.CheckedChanged += new System.EventHandler(this.rdb_Co_CheckedChanged);
            // 
            // rdb_loc
            // 
            this.rdb_loc.AutoSize = true;
            this.rdb_loc.Location = new System.Drawing.Point(291, 8);
            this.rdb_loc.Name = "rdb_loc";
            this.rdb_loc.Size = new System.Drawing.Size(90, 17);
            this.rdb_loc.TabIndex = 320;
            this.rdb_loc.Text = "Location wise";
            this.rdb_loc.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_loc);
            this.groupBox1.Controls.Add(this.rdb_Co);
            this.groupBox1.Location = new System.Drawing.Point(15, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 30);
            this.groupBox1.TabIndex = 321;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search by";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.Ivory;
            this.vistaButton1.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.vistaButton1.ButtonText = "Print";
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.ForeColor = System.Drawing.Color.Black;
            this.vistaButton1.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.vistaButton1.Location = new System.Drawing.Point(318, 183);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(87, 26);
            this.vistaButton1.TabIndex = 322;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // Reg_Bonus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 234);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnlog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AttenDtTmPkr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrev);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reg_Bonus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BONUS REGISTER";
            this.Load += new System.EventHandler(this.Stock_inventory_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.VistaButton btnPrev;
        private EDPComponent.VistaButton btnClose;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label label3;
        private EDPComponent.VistaButton btnlog;
        private System.Windows.Forms.RadioButton rdb_Co;
        private System.Windows.Forms.RadioButton rdb_loc;
        private System.Windows.Forms.GroupBox groupBox1;
        private EDPComponent.VistaButton vistaButton1;
    }
}