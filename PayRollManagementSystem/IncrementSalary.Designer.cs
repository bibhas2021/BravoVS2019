namespace PayRollManagementSystem
{
    partial class IncrementSalary
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
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIncId = new System.Windows.Forms.Label();
            this.btnInc = new System.Windows.Forms.Button();
            this.lblEmpId = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.txtAmount = new TextBoxX.TextBoxX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoPercentage = new System.Windows.Forms.RadioButton();
            this.rdoAmount = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSalHead = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPrevNet = new System.Windows.Forms.Label();
            this.lblPrevGross = new System.Windows.Forms.Label();
            this.lblCurrentNet = new System.Windows.Forms.Label();
            this.lblCurrentGross = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgEmpSal = new System.Windows.Forms.DataGridView();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.cmbSal = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIncname = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpSal)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(70, 36);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(93, 21);
            this.cmbYear.TabIndex = 240;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 241;
            this.label6.Text = "Session";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtIncname);
            this.panel1.Controls.Add(this.lblIncId);
            this.panel1.Controls.Add(this.btnInc);
            this.panel1.Controls.Add(this.lblEmpId);
            this.panel1.Controls.Add(this.lblEmpName);
            this.panel1.Controls.Add(this.lblText);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbSalHead);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 100);
            this.panel1.TabIndex = 243;
            // 
            // lblIncId
            // 
            this.lblIncId.AutoSize = true;
            this.lblIncId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncId.Location = new System.Drawing.Point(248, 41);
            this.lblIncId.Name = "lblIncId";
            this.lblIncId.Size = new System.Drawing.Size(78, 15);
            this.lblIncId.TabIndex = 260;
            this.lblIncId.Text = "Increment As";
            // 
            // btnInc
            // 
            this.btnInc.BackColor = System.Drawing.Color.Black;
            this.btnInc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInc.ForeColor = System.Drawing.Color.White;
            this.btnInc.Location = new System.Drawing.Point(478, 66);
            this.btnInc.Name = "btnInc";
            this.btnInc.Size = new System.Drawing.Size(71, 29);
            this.btnInc.TabIndex = 259;
            this.btnInc.Text = "Increment";
            this.btnInc.UseVisualStyleBackColor = false;
            this.btnInc.Click += new System.EventHandler(this.btnInc_Click);
            // 
            // lblEmpId
            // 
            this.lblEmpId.AutoSize = true;
            this.lblEmpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpId.Location = new System.Drawing.Point(82, 10);
            this.lblEmpId.Name = "lblEmpId";
            this.lblEmpId.Size = new System.Drawing.Size(0, 13);
            this.lblEmpId.TabIndex = 255;
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.Location = new System.Drawing.Point(353, 10);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(0, 13);
            this.lblEmpName.TabIndex = 254;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(347, 71);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(0, 13);
            this.lblText.TabIndex = 253;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.LightGray;
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(251, 67);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.NumericStyle = TextBoxX.TextBoxX.Style.SignedFraction;
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.Size = new System.Drawing.Size(93, 20);
            this.txtAmount.TabIndex = 252;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rdoPercentage);
            this.panel2.Controls.Add(this.rdoAmount);
            this.panel2.Location = new System.Drawing.Point(83, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 28);
            this.panel2.TabIndex = 251;
            // 
            // rdoPercentage
            // 
            this.rdoPercentage.AutoSize = true;
            this.rdoPercentage.Location = new System.Drawing.Point(4, 5);
            this.rdoPercentage.Name = "rdoPercentage";
            this.rdoPercentage.Size = new System.Drawing.Size(80, 17);
            this.rdoPercentage.TabIndex = 249;
            this.rdoPercentage.TabStop = true;
            this.rdoPercentage.Text = "Percentage";
            this.rdoPercentage.UseVisualStyleBackColor = true;
            this.rdoPercentage.CheckedChanged += new System.EventHandler(this.rdoPercentage_CheckedChanged);
            // 
            // rdoAmount
            // 
            this.rdoAmount.AutoSize = true;
            this.rdoAmount.Location = new System.Drawing.Point(88, 5);
            this.rdoAmount.Name = "rdoAmount";
            this.rdoAmount.Size = new System.Drawing.Size(61, 17);
            this.rdoAmount.TabIndex = 250;
            this.rdoAmount.TabStop = true;
            this.rdoAmount.Text = "Amount";
            this.rdoAmount.UseVisualStyleBackColor = true;
            this.rdoAmount.CheckedChanged += new System.EventHandler(this.rdoAmount_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 248;
            this.label7.Text = "Increment By";
            // 
            // cmbSalHead
            // 
            this.cmbSalHead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalHead.FormattingEnabled = true;
            this.cmbSalHead.Location = new System.Drawing.Point(83, 37);
            this.cmbSalHead.Name = "cmbSalHead";
            this.cmbSalHead.Size = new System.Drawing.Size(154, 21);
            this.cmbSalHead.TabIndex = 244;
            this.cmbSalHead.SelectedIndexChanged += new System.EventHandler(this.cmbSalHead_SelectedIndexChanged);
            this.cmbSalHead.DropDown += new System.EventHandler(this.cmbSalHead_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 246;
            this.label3.Text = "Salary Head";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 245;
            this.label2.Text = "Employee Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 244;
            this.label1.Text = "Employee Id";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblPrevNet);
            this.panel3.Controls.Add(this.lblPrevGross);
            this.panel3.Controls.Add(this.lblCurrentNet);
            this.panel3.Controls.Add(this.lblCurrentGross);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(574, 407);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 100);
            this.panel3.TabIndex = 244;
            // 
            // lblPrevNet
            // 
            this.lblPrevNet.AutoSize = true;
            this.lblPrevNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevNet.Location = new System.Drawing.Point(163, 77);
            this.lblPrevNet.Name = "lblPrevNet";
            this.lblPrevNet.Size = new System.Drawing.Size(0, 13);
            this.lblPrevNet.TabIndex = 259;
            // 
            // lblPrevGross
            // 
            this.lblPrevGross.AutoSize = true;
            this.lblPrevGross.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrevGross.Location = new System.Drawing.Point(163, 54);
            this.lblPrevGross.Name = "lblPrevGross";
            this.lblPrevGross.Size = new System.Drawing.Size(0, 13);
            this.lblPrevGross.TabIndex = 258;
            // 
            // lblCurrentNet
            // 
            this.lblCurrentNet.AutoSize = true;
            this.lblCurrentNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentNet.Location = new System.Drawing.Point(162, 32);
            this.lblCurrentNet.Name = "lblCurrentNet";
            this.lblCurrentNet.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentNet.TabIndex = 254;
            // 
            // lblCurrentGross
            // 
            this.lblCurrentGross.AutoSize = true;
            this.lblCurrentGross.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentGross.Location = new System.Drawing.Point(162, 10);
            this.lblCurrentGross.Name = "lblCurrentGross";
            this.lblCurrentGross.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentGross.TabIndex = 254;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 15);
            this.label8.TabIndex = 257;
            this.label8.Text = "Previous Net Salary (Rs.)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 15);
            this.label9.TabIndex = 256;
            this.label9.Text = "Previous Gross Salary (Rs.)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 15);
            this.label5.TabIndex = 255;
            this.label5.Text = "Current Net Salary (Rs.)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 15);
            this.label4.TabIndex = 254;
            this.label4.Text = "Current Gross Salary (Rs.)";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Black;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(663, 511);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(198, 29);
            this.btnSubmit.TabIndex = 254;
            this.btnSubmit.Text = "Save Increment";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgEmpSal
            // 
            this.dgEmpSal.AllowUserToAddRows = false;
            this.dgEmpSal.AllowUserToDeleteRows = false;
            this.dgEmpSal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgEmpSal.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEmpSal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEmpSal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmpSal.Location = new System.Drawing.Point(15, 65);
            this.dgEmpSal.Name = "dgEmpSal";
            this.dgEmpSal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgEmpSal.Size = new System.Drawing.Size(844, 337);
            this.dgEmpSal.TabIndex = 255;
            this.dgEmpSal.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgEmpSal_RowHeaderMouseClick);
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December",
            "January",
            "February",
            "March"});
            this.cmbMonth.Location = new System.Drawing.Point(265, 36);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(114, 21);
            this.cmbMonth.TabIndex = 256;
            this.cmbMonth.DropDown += new System.EventHandler(this.cmbMonth_DropDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(175, 41);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 257;
            this.label21.Text = "For The Month of";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Black;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Location = new System.Drawing.Point(661, 31);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(198, 29);
            this.btnShow.TabIndex = 258;
            this.btnShow.Text = "Show Details";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cmbSal
            // 
            this.cmbSal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSal.FormattingEnabled = true;
            this.cmbSal.Location = new System.Drawing.Point(459, 36);
            this.cmbSal.Name = "cmbSal";
            this.cmbSal.Size = new System.Drawing.Size(183, 21);
            this.cmbSal.TabIndex = 259;
        //    this.cmbSal.DropDown += new System.EventHandler(this.cmbSal_DropDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(385, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 260;
            this.label10.Text = "Sal Structure";
            // 
            // txtIncname
            // 
            this.txtIncname.Location = new System.Drawing.Point(350, 40);
            this.txtIncname.Name = "txtIncname";
            this.txtIncname.Size = new System.Drawing.Size(199, 20);
            this.txtIncname.TabIndex = 261;
            // 
            // IncrementSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 542);
            this.Controls.Add(this.cmbSal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dgEmpSal);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderText = "Increment Salary";
            this.Name = "IncrementSalary";
            this.Load += new System.EventHandler(this.IncrementSalary_Load);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.btnSubmit, 0);
            this.Controls.SetChildIndex(this.dgEmpSal, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.cmbMonth, 0);
            this.Controls.SetChildIndex(this.btnShow, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.cmbSal, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpSal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ComboBox cmbSalHead;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoPercentage;
        private System.Windows.Forms.RadioButton rdoAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblText;
        private TextBoxX.TextBoxX txtAmount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPrevNet;
        private System.Windows.Forms.Label lblPrevGross;
        private System.Windows.Forms.Label lblCurrentNet;
        private System.Windows.Forms.Label lblCurrentGross;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEmpId;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgEmpSal;
        private System.Windows.Forms.ComboBox cmbMonth;
        internal System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnInc;
        private System.Windows.Forms.Label lblIncId;
        private System.Windows.Forms.ComboBox cmbSal;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIncname;
    }
}