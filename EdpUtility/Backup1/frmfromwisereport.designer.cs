namespace Utility
{
    partial class frmfromwisereport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblComName = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnInv = new EDPComponent.VistaButton();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblFrmName = new System.Windows.Forms.Label();
            this.txtSession = new System.Windows.Forms.TextBox();
            this.txtSession1 = new System.Windows.Forms.TextBox();
            this.lblForm1 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lblFincYrStDt = new System.Windows.Forms.Label();
            this.lblFincYrEnDt = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.lblFincYrStDt);
            this.groupBox1.Controls.Add(this.lblFincYrEnDt);
            this.groupBox1.Controls.Add(this.lblComName);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblMachineName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 94);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // lblComName
            // 
            this.lblComName.AutoSize = true;
            this.lblComName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComName.Location = new System.Drawing.Point(87, 13);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(82, 13);
            this.lblComName.TabIndex = 21;
            this.lblComName.Text = "Company Name";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Sienna;
            this.lblDate.Location = new System.Drawing.Point(293, 11);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 13);
            this.lblDate.TabIndex = 34;
            this.lblDate.Text = " Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(87, 73);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 26;
            this.lblUserName.Text = "User Name:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Sienna;
            this.lblTime.Location = new System.Drawing.Point(367, 11);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 33;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(205, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Machine  Name:";
            // 
            // lblMachineName
            // 
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachineName.Location = new System.Drawing.Point(291, 73);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(76, 13);
            this.lblMachineName.TabIndex = 28;
            this.lblMachineName.Text = "Machine Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(24, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "User Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(1, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Company Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(10, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Financial Year:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInv);
            this.groupBox2.Location = new System.Drawing.Point(5, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 53);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // btnInv
            // 
            this.btnInv.BackColor = System.Drawing.Color.Transparent;
            this.btnInv.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnInv.ButtonText = "Select Form Name";
            this.btnInv.CornerRadius = 4;
            this.btnInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInv.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInv.GlowColor = System.Drawing.Color.White;
            this.btnInv.Location = new System.Drawing.Point(3, 17);
            this.btnInv.Name = "btnInv";
            this.btnInv.Size = new System.Drawing.Size(445, 33);
            this.btnInv.TabIndex = 35;
            this.btnInv.Click += new System.EventHandler(this.btnInv_Click);
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.AllowUserToDeleteRows = false;
            this.dgvShow.AllowUserToResizeColumns = false;
            this.dgvShow.AllowUserToResizeRows = false;
            this.dgvShow.BackgroundColor = System.Drawing.Color.White;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Location = new System.Drawing.Point(6, 177);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.RowHeadersVisible = false;
            this.dgvShow.RowHeadersWidth = 30;
            this.dgvShow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(448, 144);
            this.dgvShow.TabIndex = 40;
            this.dgvShow.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFrmName
            // 
            this.lblFrmName.BackColor = System.Drawing.Color.White;
            this.lblFrmName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFrmName.Location = new System.Drawing.Point(6, 352);
            this.lblFrmName.Name = "lblFrmName";
            this.lblFrmName.Size = new System.Drawing.Size(134, 65);
            this.lblFrmName.TabIndex = 41;
            this.lblFrmName.Text = "label2";
            // 
            // txtSession
            // 
            this.txtSession.Location = new System.Drawing.Point(140, 352);
            this.txtSession.Multiline = true;
            this.txtSession.Name = "txtSession";
            this.txtSession.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSession.Size = new System.Drawing.Size(314, 65);
            this.txtSession.TabIndex = 42;
            // 
            // txtSession1
            // 
            this.txtSession1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSession1.Location = new System.Drawing.Point(140, 322);
            this.txtSession1.Multiline = true;
            this.txtSession1.Name = "txtSession1";
            this.txtSession1.Size = new System.Drawing.Size(314, 30);
            this.txtSession1.TabIndex = 44;
            this.txtSession1.Text = "Session Number";
            this.txtSession1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblForm1
            // 
            this.lblForm1.BackColor = System.Drawing.Color.White;
            this.lblForm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblForm1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblForm1.Location = new System.Drawing.Point(6, 322);
            this.lblForm1.Name = "lblForm1";
            this.lblForm1.Size = new System.Drawing.Size(134, 30);
            this.lblForm1.TabIndex = 43;
            this.lblForm1.Text = "Form Name:";
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Maroon;
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label48.Location = new System.Drawing.Point(155, 52);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(3, 3);
            this.label48.TabIndex = 45;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Maroon;
            this.label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label47.Location = new System.Drawing.Point(155, 46);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(3, 3);
            this.label47.TabIndex = 44;
            // 
            // lblFincYrStDt
            // 
            this.lblFincYrStDt.AutoSize = true;
            this.lblFincYrStDt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFincYrStDt.Location = new System.Drawing.Point(87, 43);
            this.lblFincYrStDt.Name = "lblFincYrStDt";
            this.lblFincYrStDt.Size = new System.Drawing.Size(75, 13);
            this.lblFincYrStDt.TabIndex = 42;
            this.lblFincYrStDt.Text = "Starting Date:";
            this.lblFincYrStDt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFincYrEnDt
            // 
            this.lblFincYrEnDt.AutoSize = true;
            this.lblFincYrEnDt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFincYrEnDt.Location = new System.Drawing.Point(166, 43);
            this.lblFincYrEnDt.Name = "lblFincYrEnDt";
            this.lblFincYrEnDt.Size = new System.Drawing.Size(69, 13);
            this.lblFincYrEnDt.TabIndex = 43;
            this.lblFincYrEnDt.Text = "Ending Date:";
            this.lblFincYrEnDt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmfromwisereport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 435);
            this.Controls.Add(this.txtSession1);
            this.Controls.Add(this.lblForm1);
            this.Controls.Add(this.txtSession);
            this.Controls.Add(this.lblFrmName);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(461, 435);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(461, 435);
            this.Name = "frmfromwisereport";
            this.ShowClose = true;
            this.ShowMin = true;
            this.Text = "frmfromwisereport";
            this.Load += new System.EventHandler(this.frmfromwisereport_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.dgvShow, 0);
            this.Controls.SetChildIndex(this.lblFrmName, 0);
            this.Controls.SetChildIndex(this.txtSession, 0);
            this.Controls.SetChildIndex(this.lblForm1, 0);
            this.Controls.SetChildIndex(this.txtSession1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblComName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private EDPComponent.VistaButton btnInv;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFrmName;
        private System.Windows.Forms.TextBox txtSession;
        private System.Windows.Forms.TextBox txtSession1;
        private System.Windows.Forms.Label lblForm1;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lblFincYrStDt;
        private System.Windows.Forms.Label lblFincYrEnDt;
    }
}