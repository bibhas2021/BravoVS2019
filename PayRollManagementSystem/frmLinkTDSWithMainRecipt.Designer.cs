namespace PayRollManagementSystem
{
    partial class frmLinkTDSWithMainRecipt
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMainRecipt = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTDSVoucher = new EDPComponent.ComboDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblInstrumentClrDate = new System.Windows.Forms.Label();
            this.lblBranchName = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblInstrumentNo = new System.Windows.Forms.Label();
            this.lblInstrumentDate = new System.Windows.Forms.Label();
            this.lblMainReceiptAmount = new System.Windows.Forms.Label();
            this.lblReceiptMode = new System.Windows.Forms.Label();
            this.lblMainVchrNo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTDSStatus = new System.Windows.Forms.Label();
            this.lblTDSCertificateDate = new System.Windows.Forms.Label();
            this.lblTDSCertificateNo = new System.Windows.Forms.Label();
            this.lblTDSAmount = new System.Windows.Forms.Label();
            this.lblTDSVoucherNo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Bill No";
            // 
            // cmbMainRecipt
            // 
            this.cmbMainRecipt.BackColor = System.Drawing.Color.Transparent;
            this.cmbMainRecipt.Connection = null;
            this.cmbMainRecipt.DialogResult = "";
            this.cmbMainRecipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMainRecipt.Location = new System.Drawing.Point(145, 68);
            this.cmbMainRecipt.LOVFlag = 0;
            this.cmbMainRecipt.MaxCharLength = 500;
            this.cmbMainRecipt.Name = "cmbMainRecipt";
            this.cmbMainRecipt.ReturnIndex = -1;
            this.cmbMainRecipt.ReturnValue = "";
            this.cmbMainRecipt.ReturnValue_3rd = "";
            this.cmbMainRecipt.ReturnValue_4th = "";
            this.cmbMainRecipt.Size = new System.Drawing.Size(168, 21);
            this.cmbMainRecipt.TabIndex = 308;
            this.cmbMainRecipt.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbMainRecipt_DropDown);
            this.cmbMainRecipt.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbMainRecipt_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 309;
            this.label2.Text = "Main Recipt Voucher No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 310;
            this.label3.Text = "TDS Voucher No.";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbTDSVoucher
            // 
            this.cmbTDSVoucher.BackColor = System.Drawing.Color.Transparent;
            this.cmbTDSVoucher.Connection = null;
            this.cmbTDSVoucher.DialogResult = "";
            this.cmbTDSVoucher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTDSVoucher.Location = new System.Drawing.Point(426, 68);
            this.cmbTDSVoucher.LOVFlag = 0;
            this.cmbTDSVoucher.MaxCharLength = 500;
            this.cmbTDSVoucher.Name = "cmbTDSVoucher";
            this.cmbTDSVoucher.ReturnIndex = -1;
            this.cmbTDSVoucher.ReturnValue = "";
            this.cmbTDSVoucher.ReturnValue_3rd = "";
            this.cmbTDSVoucher.ReturnValue_4th = "";
            this.cmbTDSVoucher.Size = new System.Drawing.Size(192, 21);
            this.cmbTDSVoucher.TabIndex = 311;
            this.cmbTDSVoucher.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbTDSVoucher_DropDown);
            this.cmbTDSVoucher.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbTDSVoucher_CloseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInstrumentClrDate);
            this.groupBox1.Controls.Add(this.lblBranchName);
            this.groupBox1.Controls.Add(this.lblBankName);
            this.groupBox1.Controls.Add(this.lblInstrumentNo);
            this.groupBox1.Controls.Add(this.lblInstrumentDate);
            this.groupBox1.Controls.Add(this.lblMainReceiptAmount);
            this.groupBox1.Controls.Add(this.lblReceiptMode);
            this.groupBox1.Controls.Add(this.lblMainVchrNo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 129);
            this.groupBox1.TabIndex = 312;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Recipt Voucher Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTDSStatus);
            this.groupBox2.Controls.Add(this.lblTDSCertificateDate);
            this.groupBox2.Controls.Add(this.lblTDSCertificateNo);
            this.groupBox2.Controls.Add(this.lblTDSAmount);
            this.groupBox2.Controls.Add(this.lblTDSVoucherNo);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(320, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 129);
            this.groupBox2.TabIndex = 313;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TDS Voucher Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Voucher No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Voucher No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Receipt Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Instrument Date";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Instrument No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Bank Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Branch Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Instrument Clear Date";
            // 
            // lblInstrumentClrDate
            // 
            this.lblInstrumentClrDate.AutoSize = true;
            this.lblInstrumentClrDate.Location = new System.Drawing.Point(165, 107);
            this.lblInstrumentClrDate.Name = "lblInstrumentClrDate";
            this.lblInstrumentClrDate.Size = new System.Drawing.Size(109, 13);
            this.lblInstrumentClrDate.TabIndex = 15;
            this.lblInstrumentClrDate.Text = "Instrument Clear Date";
            // 
            // lblBranchName
            // 
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.Location = new System.Drawing.Point(165, 94);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(72, 13);
            this.lblBranchName.TabIndex = 14;
            this.lblBranchName.Text = "Branch Name";
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Location = new System.Drawing.Point(165, 81);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(63, 13);
            this.lblBankName.TabIndex = 13;
            this.lblBankName.Text = "Bank Name";
            // 
            // lblInstrumentNo
            // 
            this.lblInstrumentNo.AutoSize = true;
            this.lblInstrumentNo.Location = new System.Drawing.Point(165, 68);
            this.lblInstrumentNo.Name = "lblInstrumentNo";
            this.lblInstrumentNo.Size = new System.Drawing.Size(73, 13);
            this.lblInstrumentNo.TabIndex = 12;
            this.lblInstrumentNo.Text = "Instrument No";
            // 
            // lblInstrumentDate
            // 
            this.lblInstrumentDate.AutoSize = true;
            this.lblInstrumentDate.Location = new System.Drawing.Point(165, 55);
            this.lblInstrumentDate.Name = "lblInstrumentDate";
            this.lblInstrumentDate.Size = new System.Drawing.Size(82, 13);
            this.lblInstrumentDate.TabIndex = 11;
            this.lblInstrumentDate.Text = "Instrument Date";
            // 
            // lblMainReceiptAmount
            // 
            this.lblMainReceiptAmount.AutoSize = true;
            this.lblMainReceiptAmount.Location = new System.Drawing.Point(165, 42);
            this.lblMainReceiptAmount.Name = "lblMainReceiptAmount";
            this.lblMainReceiptAmount.Size = new System.Drawing.Size(43, 13);
            this.lblMainReceiptAmount.TabIndex = 10;
            this.lblMainReceiptAmount.Text = "Amount";
            // 
            // lblReceiptMode
            // 
            this.lblReceiptMode.AutoSize = true;
            this.lblReceiptMode.Location = new System.Drawing.Point(165, 29);
            this.lblReceiptMode.Name = "lblReceiptMode";
            this.lblReceiptMode.Size = new System.Drawing.Size(74, 13);
            this.lblReceiptMode.TabIndex = 9;
            this.lblReceiptMode.Text = "Receipt Mode";
            // 
            // lblMainVchrNo
            // 
            this.lblMainVchrNo.AutoSize = true;
            this.lblMainVchrNo.Location = new System.Drawing.Point(165, 16);
            this.lblMainVchrNo.Name = "lblMainVchrNo";
            this.lblMainVchrNo.Size = new System.Drawing.Size(64, 13);
            this.lblMainVchrNo.TabIndex = 8;
            this.lblMainVchrNo.Text = "Voucher No";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Amount";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Certificate No";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Certificate Date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "TDS Status";
            // 
            // lblTDSStatus
            // 
            this.lblTDSStatus.AutoSize = true;
            this.lblTDSStatus.Location = new System.Drawing.Point(167, 68);
            this.lblTDSStatus.Name = "lblTDSStatus";
            this.lblTDSStatus.Size = new System.Drawing.Size(62, 13);
            this.lblTDSStatus.TabIndex = 11;
            this.lblTDSStatus.Text = "TDS Status";
            // 
            // lblTDSCertificateDate
            // 
            this.lblTDSCertificateDate.AutoSize = true;
            this.lblTDSCertificateDate.Location = new System.Drawing.Point(167, 55);
            this.lblTDSCertificateDate.Name = "lblTDSCertificateDate";
            this.lblTDSCertificateDate.Size = new System.Drawing.Size(80, 13);
            this.lblTDSCertificateDate.TabIndex = 10;
            this.lblTDSCertificateDate.Text = "Certificate Date";
            // 
            // lblTDSCertificateNo
            // 
            this.lblTDSCertificateNo.AutoSize = true;
            this.lblTDSCertificateNo.Location = new System.Drawing.Point(167, 42);
            this.lblTDSCertificateNo.Name = "lblTDSCertificateNo";
            this.lblTDSCertificateNo.Size = new System.Drawing.Size(71, 13);
            this.lblTDSCertificateNo.TabIndex = 9;
            this.lblTDSCertificateNo.Text = "Certificate No";
            // 
            // lblTDSAmount
            // 
            this.lblTDSAmount.AutoSize = true;
            this.lblTDSAmount.Location = new System.Drawing.Point(167, 29);
            this.lblTDSAmount.Name = "lblTDSAmount";
            this.lblTDSAmount.Size = new System.Drawing.Size(43, 13);
            this.lblTDSAmount.TabIndex = 8;
            this.lblTDSAmount.Text = "Amount";
            // 
            // lblTDSVoucherNo
            // 
            this.lblTDSVoucherNo.AutoSize = true;
            this.lblTDSVoucherNo.Location = new System.Drawing.Point(167, 16);
            this.lblTDSVoucherNo.Name = "lblTDSVoucherNo";
            this.lblTDSVoucherNo.Size = new System.Drawing.Size(64, 13);
            this.lblTDSVoucherNo.TabIndex = 7;
            this.lblTDSVoucherNo.Text = "Voucher No";
            // 
            // frmLinkTDSWithMainRecipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 467);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbTDSVoucher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMainRecipt);
            this.Controls.Add(this.label1);
            this.Name = "frmLinkTDSWithMainRecipt";
            this.Text = "frmLinkTDSWithMainRecipt";
            this.Load += new System.EventHandler(this.frmLinkTDSWithMainRecipt_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbMainRecipt, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cmbTDSVoucher, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private EDPComponent.ComboDialog cmbMainRecipt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private EDPComponent.ComboDialog cmbTDSVoucher;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblInstrumentClrDate;
        private System.Windows.Forms.Label lblBranchName;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label lblInstrumentNo;
        private System.Windows.Forms.Label lblInstrumentDate;
        private System.Windows.Forms.Label lblMainReceiptAmount;
        private System.Windows.Forms.Label lblReceiptMode;
        private System.Windows.Forms.Label lblMainVchrNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTDSStatus;
        private System.Windows.Forms.Label lblTDSCertificateDate;
        private System.Windows.Forms.Label lblTDSCertificateNo;
        private System.Windows.Forms.Label lblTDSAmount;
        private System.Windows.Forms.Label lblTDSVoucherNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}