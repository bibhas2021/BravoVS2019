namespace MidasReport
{
    partial class frmRptJurnal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboDialog2 = new EDPComponent.ComboDialog();
            this.comboDialog1 = new EDPComponent.ComboDialog();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFormDate = new System.Windows.Forms.DateTimePicker();
            this.radioVoucher = new System.Windows.Forms.RadioButton();
            this.radioPeriod = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cbVchNo = new System.Windows.Forms.CheckBox();
            this.cbNar = new System.Windows.Forms.CheckBox();
            this.btnDosPrint = new System.Windows.Forms.Button();
            this.lbl_close = new System.Windows.Forms.Label();
            this.lbl_Minz = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboDialog2);
            this.panel1.Controls.Add(this.comboDialog1);
            this.panel1.Controls.Add(this.dtpToDate);
            this.panel1.Controls.Add(this.dtpFormDate);
            this.panel1.Controls.Add(this.radioVoucher);
            this.panel1.Controls.Add(this.radioPeriod);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 98);
            this.panel1.TabIndex = 1;
            // 
            // comboDialog2
            // 
            this.comboDialog2.Connection = null;
            this.comboDialog2.DialogResult = "";
            this.comboDialog2.Location = new System.Drawing.Point(181, 63);
            this.comboDialog2.LOVFlag = 0;
            this.comboDialog2.Name = "comboDialog2";
            this.comboDialog2.ReturnValue = "";
            this.comboDialog2.Size = new System.Drawing.Size(169, 21);
            this.comboDialog2.TabIndex = 11;
            this.comboDialog2.Click += new System.EventHandler(this.comboDialog2_Click);
            this.comboDialog2.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.comboDialog2_CloseUp);
            // 
            // comboDialog1
            // 
            this.comboDialog1.Connection = null;
            this.comboDialog1.DialogResult = "";
            this.comboDialog1.Location = new System.Drawing.Point(181, 35);
            this.comboDialog1.LOVFlag = 0;
            this.comboDialog1.Name = "comboDialog1";
            this.comboDialog1.ReturnValue = "";
            this.comboDialog1.Size = new System.Drawing.Size(169, 21);
            this.comboDialog1.TabIndex = 10;
            this.comboDialog1.Click += new System.EventHandler(this.comboDialog1_Click);
            this.comboDialog1.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.comboDialog1_CloseUp);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(39, 62);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(107, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpFormDate
            // 
            this.dtpFormDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFormDate.Location = new System.Drawing.Point(39, 36);
            this.dtpFormDate.Name = "dtpFormDate";
            this.dtpFormDate.Size = new System.Drawing.Size(107, 20);
            this.dtpFormDate.TabIndex = 2;
            // 
            // radioVoucher
            // 
            this.radioVoucher.AutoSize = true;
            this.radioVoucher.Location = new System.Drawing.Point(181, 12);
            this.radioVoucher.Name = "radioVoucher";
            this.radioVoucher.Size = new System.Drawing.Size(85, 17);
            this.radioVoucher.TabIndex = 1;
            this.radioVoucher.TabStop = true;
            this.radioVoucher.Text = "Voucher No.";
            this.radioVoucher.UseVisualStyleBackColor = true;
            this.radioVoucher.Click += new System.EventHandler(this.radioVoucher_Click);
            // 
            // radioPeriod
            // 
            this.radioPeriod.AutoSize = true;
            this.radioPeriod.Location = new System.Drawing.Point(39, 13);
            this.radioPeriod.Name = "radioPeriod";
            this.radioPeriod.Size = new System.Drawing.Size(55, 17);
            this.radioPeriod.TabIndex = 0;
            this.radioPeriod.TabStop = true;
            this.radioPeriod.Text = "Period";
            this.radioPeriod.UseVisualStyleBackColor = true;
            this.radioPeriod.Click += new System.EventHandler(this.radioPeriod_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnPreview);
            this.panel2.Controls.Add(this.cbVchNo);
            this.panel2.Controls.Add(this.cbNar);
            this.panel2.Controls.Add(this.btnDosPrint);
            this.panel2.Location = new System.Drawing.Point(12, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 82);
            this.panel2.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(268, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 25);
            this.button4.TabIndex = 12;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(180, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 25);
            this.button3.TabIndex = 11;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(268, 12);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(82, 27);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // cbVchNo
            // 
            this.cbVchNo.AutoSize = true;
            this.cbVchNo.Location = new System.Drawing.Point(40, 48);
            this.cbVchNo.Name = "cbVchNo";
            this.cbVchNo.Size = new System.Drawing.Size(111, 17);
            this.cbVchNo.TabIndex = 9;
            this.cbVchNo.Text = "With Voucher No.";
            this.cbVchNo.UseVisualStyleBackColor = true;
            // 
            // cbNar
            // 
            this.cbNar.AutoSize = true;
            this.cbNar.Location = new System.Drawing.Point(40, 22);
            this.cbNar.Name = "cbNar";
            this.cbNar.Size = new System.Drawing.Size(91, 17);
            this.cbNar.TabIndex = 8;
            this.cbNar.Text = "With Naration";
            this.cbNar.UseVisualStyleBackColor = true;
            // 
            // btnDosPrint
            // 
            this.btnDosPrint.Location = new System.Drawing.Point(180, 12);
            this.btnDosPrint.Name = "btnDosPrint";
            this.btnDosPrint.Size = new System.Drawing.Size(82, 27);
            this.btnDosPrint.TabIndex = 0;
            this.btnDosPrint.Text = "Dos Print";
            this.btnDosPrint.UseVisualStyleBackColor = true;
            this.btnDosPrint.Click += new System.EventHandler(this.btnDosPrint_Click);
            // 
            // lbl_close
            // 
            this.lbl_close.BackColor = System.Drawing.Color.Black;
            this.lbl_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_close.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_close.ForeColor = System.Drawing.Color.Red;
            this.lbl_close.Location = new System.Drawing.Point(398, -1);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(22, 25);
            this.lbl_close.TabIndex = 16;
            this.lbl_close.Text = "X";
            this.lbl_close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // lbl_Minz
            // 
            this.lbl_Minz.BackColor = System.Drawing.Color.Black;
            this.lbl_Minz.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Minz.ForeColor = System.Drawing.Color.Red;
            this.lbl_Minz.Location = new System.Drawing.Point(382, -1);
            this.lbl_Minz.Name = "lbl_Minz";
            this.lbl_Minz.Size = new System.Drawing.Size(22, 25);
            this.lbl_Minz.TabIndex = 15;
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
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(420, 25);
            this.label13.TabIndex = 14;
            this.label13.Text = "          Jurnal";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = global::MidasReport.Properties.Resources.Money;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(-369, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // frmRptJurnal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 238);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_close);
            this.Controls.Add(this.lbl_Minz);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmRptJurnal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmRptJurnal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioVoucher;
        private System.Windows.Forms.RadioButton radioPeriod;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFormDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.CheckBox cbVchNo;
        private System.Windows.Forms.CheckBox cbNar;
        private System.Windows.Forms.Button btnDosPrint;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Label lbl_Minz;
        private System.Windows.Forms.Label label13;
        private EDPComponent.ComboDialog comboDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private EDPComponent.ComboDialog comboDialog2;
    }
}