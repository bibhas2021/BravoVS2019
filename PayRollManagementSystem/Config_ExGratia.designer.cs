namespace PayRollManagementSystem
{
    partial class Config_ExGratia
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
            this.label8 = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.txtAmount = new TextBoxX.TextBoxX();
            this.rdoAmount = new System.Windows.Forms.RadioButton();
            this.rdoPercentage = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaxPay = new TextBoxX.TextBoxX();
            this.cmbExgratiaName = new EDPComponent.ComboDialog();
            this.cmbPayMonth = new System.Windows.Forms.ComboBox();
            this.cmbToMonth = new System.Windows.Forms.ComboBox();
            this.cmbFromMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblExg = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblText);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.rdoAmount);
            this.panel1.Controls.Add(this.rdoPercentage);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtMaxPay);
            this.panel1.Controls.Add(this.cmbExgratiaName);
            this.panel1.Controls.Add(this.cmbPayMonth);
            this.panel1.Controls.Add(this.cmbToMonth);
            this.panel1.Controls.Add(this.cmbFromMonth);
            this.panel1.Controls.Add(this.cmbYear);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 228);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 250;
            this.label8.Text = "( Rs. )";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(198, 169);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(0, 13);
            this.lblText.TabIndex = 249;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.LightGray;
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(102, 165);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.NumericStyle = TextBoxX.TextBoxX.Style.SignedFraction;
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.Size = new System.Drawing.Size(93, 20);
            this.txtAmount.TabIndex = 248;
            // 
            // rdoAmount
            // 
            this.rdoAmount.AutoSize = true;
            this.rdoAmount.Location = new System.Drawing.Point(200, 142);
            this.rdoAmount.Name = "rdoAmount";
            this.rdoAmount.Size = new System.Drawing.Size(91, 17);
            this.rdoAmount.TabIndex = 247;
            this.rdoAmount.TabStop = true;
            this.rdoAmount.Text = "Exact Amount";
            this.rdoAmount.UseVisualStyleBackColor = true;
            this.rdoAmount.CheckedChanged += new System.EventHandler(this.rdoAmount_CheckedChanged);
            // 
            // rdoPercentage
            // 
            this.rdoPercentage.AutoSize = true;
            this.rdoPercentage.Location = new System.Drawing.Point(102, 142);
            this.rdoPercentage.Name = "rdoPercentage";
            this.rdoPercentage.Size = new System.Drawing.Size(80, 17);
            this.rdoPercentage.TabIndex = 246;
            this.rdoPercentage.TabStop = true;
            this.rdoPercentage.Text = "Percentage";
            this.rdoPercentage.UseVisualStyleBackColor = true;
            this.rdoPercentage.CheckedChanged += new System.EventHandler(this.rdoPercentage_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 245;
            this.label7.Text = "Pay By";
            // 
            // txtMaxPay
            // 
            this.txtMaxPay.Location = new System.Drawing.Point(102, 191);
            this.txtMaxPay.Name = "txtMaxPay";
            this.txtMaxPay.NumericStyle = TextBoxX.TextBoxX.Style.SignedFraction;
            this.txtMaxPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMaxPay.Size = new System.Drawing.Size(94, 20);
            this.txtMaxPay.TabIndex = 244;
            // 
            // cmbExgratiaName
            // 
            this.cmbExgratiaName.Connection = null;
            this.cmbExgratiaName.DialogResult = "";
            this.cmbExgratiaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExgratiaName.Location = new System.Drawing.Point(102, 35);
            this.cmbExgratiaName.LOVFlag = 0;
            this.cmbExgratiaName.Name = "cmbExgratiaName";
            this.cmbExgratiaName.ReturnValue = "";
            this.cmbExgratiaName.Size = new System.Drawing.Size(184, 21);
            this.cmbExgratiaName.TabIndex = 243;
            this.cmbExgratiaName.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbExgratiaName_DropDown);
            this.cmbExgratiaName.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbExgratiaName_CloseUp);
            // 
            // cmbPayMonth
            // 
            this.cmbPayMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayMonth.FormattingEnabled = true;
            this.cmbPayMonth.Location = new System.Drawing.Point(102, 115);
            this.cmbPayMonth.Name = "cmbPayMonth";
            this.cmbPayMonth.Size = new System.Drawing.Size(184, 21);
            this.cmbPayMonth.TabIndex = 242;
            this.cmbPayMonth.DropDown += new System.EventHandler(this.cmbPayMonth_DropDown);
            // 
            // cmbToMonth
            // 
            this.cmbToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToMonth.FormattingEnabled = true;
            this.cmbToMonth.Location = new System.Drawing.Point(102, 88);
            this.cmbToMonth.Name = "cmbToMonth";
            this.cmbToMonth.Size = new System.Drawing.Size(184, 21);
            this.cmbToMonth.TabIndex = 241;
            this.cmbToMonth.DropDown += new System.EventHandler(this.cmbToMonth_DropDown);
            // 
            // cmbFromMonth
            // 
            this.cmbFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromMonth.FormattingEnabled = true;
            this.cmbFromMonth.Location = new System.Drawing.Point(102, 61);
            this.cmbFromMonth.Name = "cmbFromMonth";
            this.cmbFromMonth.Size = new System.Drawing.Size(184, 21);
            this.cmbFromMonth.TabIndex = 240;
            this.cmbFromMonth.DropDown += new System.EventHandler(this.cmbFromMonth_DropDown);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(102, 8);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 21);
            this.cmbYear.TabIndex = 238;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 239;
            this.label6.Text = "Session";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Maximum Pay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pay Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "To Month";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "From Month";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ex - Gratia Name";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Black;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(244, 265);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(68, 29);
            this.btnSubmit.TabIndex = 253;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Black;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(10, 265);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 29);
            this.btnDelete.TabIndex = 253;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblExg
            // 
            this.lblExg.AutoSize = true;
            this.lblExg.Location = new System.Drawing.Point(139, 299);
            this.lblExg.Name = "lblExg";
            this.lblExg.Size = new System.Drawing.Size(0, 13);
            this.lblExg.TabIndex = 254;
            // 
            // Config_ExGratia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 297);
            this.Controls.Add(this.lblExg);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderText = "Exgratia Master";
            this.Name = "Config_ExGratia";
            this.Load += new System.EventHandler(this.Config_ExGratia_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSubmit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.lblExg, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbPayMonth;
        internal System.Windows.Forms.ComboBox cmbToMonth;
        internal System.Windows.Forms.ComboBox cmbFromMonth;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label6;
        private EDPComponent.ComboDialog cmbExgratiaName;
        private TextBoxX.TextBoxX txtMaxPay;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblExg;
        private TextBoxX.TextBoxX txtAmount;
        private System.Windows.Forms.RadioButton rdoAmount;
        private System.Windows.Forms.RadioButton rdoPercentage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label label8;
    }
}