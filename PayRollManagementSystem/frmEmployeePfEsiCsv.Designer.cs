namespace PayRollManagementSystem
{
    partial class frmEmployeePfEsiCsv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeePfEsiCsv));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblEPS_Wages = new System.Windows.Forms.Label();
            this.lblEPSContdue = new System.Windows.Forms.Label();
            this.dgvCsv = new System.Windows.Forms.DataGridView();
            this.dgv_pfesi_csv = new System.Windows.Forms.DataGridView();
            this.btnGenerate = new EDPComponent.VistaButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lbl_Month = new System.Windows.Forms.Label();
            this.lbl_yr = new System.Windows.Forms.Label();
            this.lblPF_Esi_edit = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pfesi_csv)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPF_Esi_edit);
            this.panel1.Controls.Add(this.lbl_yr);
            this.panel1.Controls.Add(this.lbl_Month);
            this.panel1.Controls.Add(this.lblMonth);
            this.panel1.Controls.Add(this.lblEPS_Wages);
            this.panel1.Controls.Add(this.lblEPSContdue);
            this.panel1.Controls.Add(this.dgvCsv);
            this.panel1.Controls.Add(this.dgv_pfesi_csv);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 572);
            this.panel1.TabIndex = 0;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.ForeColor = System.Drawing.Color.Black;
            this.lblMonth.Location = new System.Drawing.Point(83, 556);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(2, 18);
            this.lblMonth.TabIndex = 307;
            // 
            // lblEPS_Wages
            // 
            this.lblEPS_Wages.AutoSize = true;
            this.lblEPS_Wages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEPS_Wages.ForeColor = System.Drawing.Color.Navy;
            this.lblEPS_Wages.Location = new System.Drawing.Point(50, 506);
            this.lblEPS_Wages.Name = "lblEPS_Wages";
            this.lblEPS_Wages.Size = new System.Drawing.Size(74, 13);
            this.lblEPS_Wages.TabIndex = 306;
            this.lblEPS_Wages.Text = "EPS Wages";
            // 
            // lblEPSContdue
            // 
            this.lblEPSContdue.AutoSize = true;
            this.lblEPSContdue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEPSContdue.ForeColor = System.Drawing.Color.Navy;
            this.lblEPSContdue.Location = new System.Drawing.Point(50, 533);
            this.lblEPSContdue.Name = "lblEPSContdue";
            this.lblEPSContdue.Size = new System.Drawing.Size(194, 13);
            this.lblEPSContdue.TabIndex = 305;
            this.lblEPSContdue.Text = "EPS Contribution Due  [Max 541]";
            // 
            // dgvCsv
            // 
            this.dgvCsv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCsv.Location = new System.Drawing.Point(11, 43);
            this.dgvCsv.Name = "dgvCsv";
            this.dgvCsv.Size = new System.Drawing.Size(1195, 428);
            this.dgvCsv.TabIndex = 304;
            this.dgvCsv.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCsv_CellLeave);
            this.dgvCsv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCsv_KeyDown);
            // 
            // dgv_pfesi_csv
            // 
            this.dgv_pfesi_csv.BackgroundColor = System.Drawing.Color.White;
            this.dgv_pfesi_csv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pfesi_csv.Location = new System.Drawing.Point(536, 477);
            this.dgv_pfesi_csv.Name = "dgv_pfesi_csv";
            this.dgv_pfesi_csv.Size = new System.Drawing.Size(203, 10);
            this.dgv_pfesi_csv.TabIndex = 303;
            this.dgv_pfesi_csv.Visible = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerate.BaseColor = System.Drawing.Color.SlateGray;
            this.btnGenerate.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnGenerate.ButtonText = "Generate CSV";
            this.btnGenerate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.GlowColor = System.Drawing.Color.Aqua;
            this.btnGenerate.Location = new System.Drawing.Point(1058, 477);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(148, 29);
            this.btnGenerate.TabIndex = 302;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1217, 26);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1197, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(42, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export to CSV";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // lbl_Month
            // 
            this.lbl_Month.AutoSize = true;
            this.lbl_Month.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Month.Location = new System.Drawing.Point(50, 485);
            this.lbl_Month.Name = "lbl_Month";
            this.lbl_Month.Size = new System.Drawing.Size(2, 15);
            this.lbl_Month.TabIndex = 308;
            // 
            // lbl_yr
            // 
            this.lbl_yr.AutoSize = true;
            this.lbl_yr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_yr.Location = new System.Drawing.Point(144, 485);
            this.lbl_yr.Name = "lbl_yr";
            this.lbl_yr.Size = new System.Drawing.Size(2, 15);
            this.lbl_yr.TabIndex = 309;
            // 
            // lblPF_Esi_edit
            // 
            this.lblPF_Esi_edit.AutoSize = true;
            this.lblPF_Esi_edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPF_Esi_edit.Location = new System.Drawing.Point(14, 486);
            this.lblPF_Esi_edit.Name = "lblPF_Esi_edit";
            this.lblPF_Esi_edit.Size = new System.Drawing.Size(2, 15);
            this.lblPF_Esi_edit.TabIndex = 310;
            this.lblPF_Esi_edit.Visible = false;
            // 
            // frmEmployeePfEsiCsv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 572);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployeePfEsiCsv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeePfEsiCsv";
            this.Load += new System.EventHandler(this.frmEmployeePfEsiCsv_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCsv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pfesi_csv)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_pfesi_csv;
        private EDPComponent.VistaButton btnGenerate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgvCsv;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblEPSContdue;
        private System.Windows.Forms.Label lblEPS_Wages;
        public System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lbl_Month;
        private System.Windows.Forms.Label lbl_yr;
        private System.Windows.Forms.Label lblPF_Esi_edit;
    }
}