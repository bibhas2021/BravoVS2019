namespace MidasReport
{
    partial class frmCashBook
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSide = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboDialog1 = new EDPComponent.ComboDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chbConsolidated = new System.Windows.Forms.CheckBox();
            this.chbNaration = new System.Windows.Forms.CheckBox();
            this.chbVoucher = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDosPrnt = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_close = new System.Windows.Forms.Label();
            this.lbl_Minz = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Period";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(68, 40);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(86, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(68, 14);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(86, 20);
            this.dtpFromDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSide);
            this.groupBox2.Controls.Add(this.rbMonthly);
            this.groupBox2.Controls.Add(this.rbDaily);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 90);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Balance Type";
            // 
            // rbSide
            // 
            this.rbSide.AutoSize = true;
            this.rbSide.Location = new System.Drawing.Point(22, 67);
            this.rbSide.Name = "rbSide";
            this.rbSide.Size = new System.Drawing.Size(88, 17);
            this.rbSide.TabIndex = 2;
            this.rbSide.TabStop = true;
            this.rbSide.Text = "Side Balance";
            this.rbSide.UseVisualStyleBackColor = true;
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(22, 44);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(104, 17);
            this.rbMonthly.TabIndex = 1;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly Balance";
            this.rbMonthly.UseVisualStyleBackColor = true;
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.Location = new System.Drawing.Point(22, 18);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(90, 17);
            this.rbDaily.TabIndex = 0;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily Balance";
            this.rbDaily.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboDialog1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(190, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 61);
            this.panel1.TabIndex = 2;
            // 
            // comboDialog1
            // 
            this.comboDialog1.Connection = null;
            this.comboDialog1.DialogResult = "";
            this.comboDialog1.Location = new System.Drawing.Point(140, 20);
            this.comboDialog1.LOVFlag = 0;
            this.comboDialog1.Name = "comboDialog1";
            this.comboDialog1.ReturnValue = "";
            this.comboDialog1.Size = new System.Drawing.Size(209, 21);
            this.comboDialog1.TabIndex = 11;
            this.comboDialog1.Click += new System.EventHandler(this.comboDialog1_Click);
            this.comboDialog1.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.comboDialog1_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select Cash Account";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbConsolidated);
            this.groupBox3.Controls.Add(this.chbNaration);
            this.groupBox3.Controls.Add(this.chbVoucher);
            this.groupBox3.Location = new System.Drawing.Point(190, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 89);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Added Features";
            // 
            // chbConsolidated
            // 
            this.chbConsolidated.AutoSize = true;
            this.chbConsolidated.Location = new System.Drawing.Point(29, 66);
            this.chbConsolidated.Name = "chbConsolidated";
            this.chbConsolidated.Size = new System.Drawing.Size(87, 17);
            this.chbConsolidated.TabIndex = 2;
            this.chbConsolidated.Text = "Consolidated";
            this.chbConsolidated.UseVisualStyleBackColor = true;
            this.chbConsolidated.Click += new System.EventHandler(this.chbConsolidated_Click);
            // 
            // chbNaration
            // 
            this.chbNaration.AutoSize = true;
            this.chbNaration.Location = new System.Drawing.Point(29, 44);
            this.chbNaration.Name = "chbNaration";
            this.chbNaration.Size = new System.Drawing.Size(66, 17);
            this.chbNaration.TabIndex = 1;
            this.chbNaration.Text = "Naration";
            this.chbNaration.UseVisualStyleBackColor = true;
            // 
            // chbVoucher
            // 
            this.chbVoucher.AutoSize = true;
            this.chbVoucher.Location = new System.Drawing.Point(29, 19);
            this.chbVoucher.Name = "chbVoucher";
            this.chbVoucher.Size = new System.Drawing.Size(86, 17);
            this.chbVoucher.TabIndex = 0;
            this.chbVoucher.Text = "Voucher No.";
            this.chbVoucher.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnDosPrnt);
            this.panel2.Location = new System.Drawing.Point(373, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(174, 83);
            this.panel2.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(91, 44);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnDosPrnt
            // 
            this.btnDosPrnt.Location = new System.Drawing.Point(10, 8);
            this.btnDosPrnt.Name = "btnDosPrnt";
            this.btnDosPrnt.Size = new System.Drawing.Size(75, 28);
            this.btnDosPrnt.TabIndex = 0;
            this.btnDosPrnt.Text = "Dos Print";
            this.btnDosPrnt.UseVisualStyleBackColor = true;
            this.btnDosPrnt.Click += new System.EventHandler(this.btnDosPrnt_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = global::MidasReport.Properties.Resources.Money;
            this.pictureBox2.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_close
            // 
            this.lbl_close.BackColor = System.Drawing.Color.Black;
            this.lbl_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_close.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_close.ForeColor = System.Drawing.Color.Red;
            this.lbl_close.Location = new System.Drawing.Point(539, 1);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(22, 25);
            this.lbl_close.TabIndex = 21;
            this.lbl_close.Text = "X";
            this.lbl_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // lbl_Minz
            // 
            this.lbl_Minz.BackColor = System.Drawing.Color.Black;
            this.lbl_Minz.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Minz.ForeColor = System.Drawing.Color.Red;
            this.lbl_Minz.Location = new System.Drawing.Point(523, -2);
            this.lbl_Minz.Name = "lbl_Minz";
            this.lbl_Minz.Size = new System.Drawing.Size(22, 25);
            this.lbl_Minz.TabIndex = 20;
            this.lbl_Minz.Text = "_";
            this.lbl_Minz.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Minz.Click += new System.EventHandler(this.lbl_Minz_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(-2, -1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(563, 30);
            this.label13.TabIndex = 19;
            this.label13.Text = "          Cash Book";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCashBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(560, 211);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_close);
            this.Controls.Add(this.lbl_Minz);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCashBook";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCashBook_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private EDPComponent.ComboDialog comboDialog1;
        private System.Windows.Forms.RadioButton rbSide;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chbConsolidated;
        private System.Windows.Forms.CheckBox chbNaration;
        private System.Windows.Forms.CheckBox chbVoucher;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDosPrnt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Label lbl_Minz;
        private System.Windows.Forms.Label label13;
    }
}