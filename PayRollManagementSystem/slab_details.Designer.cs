namespace PayRollManagementSystem
{
    partial class slab_details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(slab_details));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnnew = new EDPComponent.VistaButton();
            this.btnslab = new EDPComponent.VistaButton();
            this.btnclose = new EDPComponent.VistaButton();
            this.btndelete = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.dgvfmula = new System.Windows.Forms.DataGridView();
            this.cmbslab = new System.Windows.Forms.ComboBox();
            this.lblslab = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtamt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtslno = new System.Windows.Forms.TextBox();
            this.lblslno = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtmax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfmula)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Controls.Add(this.btnslab);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.dgvfmula);
            this.panel1.Controls.Add(this.cmbslab);
            this.panel1.Controls.Add(this.lblslab);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 389);
            this.panel1.TabIndex = 42;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.Transparent;
            this.btnnew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnnew.BackgroundImage")));
            this.btnnew.ButtonText = "New Entry";
            this.btnnew.Location = new System.Drawing.Point(30, 351);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(80, 29);
            this.btnnew.TabIndex = 281;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnslab
            // 
            this.btnslab.BackColor = System.Drawing.Color.Transparent;
            this.btnslab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnslab.BackgroundImage")));
            this.btnslab.ButtonText = "--";
            this.btnslab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnslab.Location = new System.Drawing.Point(329, 7);
            this.btnslab.Name = "btnslab";
            this.btnslab.Size = new System.Drawing.Size(26, 22);
            this.btnslab.TabIndex = 280;
            this.btnslab.Click += new System.EventHandler(this.btnslab_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.ButtonText = "Close";
            this.btnclose.Location = new System.Drawing.Point(288, 351);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 29);
            this.btnclose.TabIndex = 279;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndelete.BackgroundImage")));
            this.btndelete.ButtonText = "Delete";
            this.btndelete.Location = new System.Drawing.Point(116, 351);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(80, 29);
            this.btndelete.TabIndex = 278;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(202, 351);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 29);
            this.btnSubmit.TabIndex = 277;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvfmula
            // 
            this.dgvfmula.AllowUserToAddRows = false;
            this.dgvfmula.AllowUserToDeleteRows = false;
            this.dgvfmula.AllowUserToResizeColumns = false;
            this.dgvfmula.AllowUserToResizeRows = false;
            this.dgvfmula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfmula.Location = new System.Drawing.Point(9, 185);
            this.dgvfmula.MultiSelect = false;
            this.dgvfmula.Name = "dgvfmula";
            this.dgvfmula.ReadOnly = true;
            this.dgvfmula.RowHeadersVisible = false;
            this.dgvfmula.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvfmula.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfmula.Size = new System.Drawing.Size(359, 160);
            this.dgvfmula.TabIndex = 271;
            this.dgvfmula.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvfmula_CellClick);
            // 
            // cmbslab
            // 
            this.cmbslab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbslab.FormattingEnabled = true;
            this.cmbslab.Location = new System.Drawing.Point(83, 7);
            this.cmbslab.Name = "cmbslab";
            this.cmbslab.Size = new System.Drawing.Size(239, 21);
            this.cmbslab.TabIndex = 4;
            this.cmbslab.SelectionChangeCommitted += new System.EventHandler(this.cmbslab_SelectionChangeCommitted);
            this.cmbslab.SelectedIndexChanged += new System.EventHandler(this.cmbslab_SelectedIndexChanged);
            this.cmbslab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbslab_MouseDown);
            // 
            // lblslab
            // 
            this.lblslab.AutoSize = true;
            this.lblslab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblslab.Location = new System.Drawing.Point(14, 8);
            this.lblslab.Name = "lblslab";
            this.lblslab.Size = new System.Drawing.Size(32, 15);
            this.lblslab.TabIndex = 3;
            this.lblslab.Text = "Slab";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtamt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtslno);
            this.groupBox1.Controls.Add(this.lblslno);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(17, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 151);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // txtamt
            // 
            this.txtamt.Location = new System.Drawing.Point(101, 121);
            this.txtamt.Name = "txtamt";
            this.txtamt.Size = new System.Drawing.Size(192, 20);
            this.txtamt.TabIndex = 284;
            this.txtamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 283;
            this.label3.Text = "Amount";
            // 
            // txtslno
            // 
            this.txtslno.Location = new System.Drawing.Point(101, 16);
            this.txtslno.Name = "txtslno";
            this.txtslno.Size = new System.Drawing.Size(192, 20);
            this.txtslno.TabIndex = 281;
            this.txtslno.TextChanged += new System.EventHandler(this.txtslno_TextChanged);
            // 
            // lblslno
            // 
            this.lblslno.AutoSize = true;
            this.lblslno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblslno.Location = new System.Drawing.Point(29, 17);
            this.lblslno.Name = "lblslno";
            this.lblslno.Size = new System.Drawing.Size(40, 15);
            this.lblslno.TabIndex = 280;
            this.lblslno.Text = "Sl. No";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtmax);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtmin);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(21, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 80);
            this.groupBox2.TabIndex = 282;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Salary Range";
            // 
            // txtmax
            // 
            this.txtmax.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmax.Location = new System.Drawing.Point(80, 45);
            this.txtmax.Name = "txtmax";
            this.txtmax.ReadOnly = true;
            this.txtmax.Size = new System.Drawing.Size(192, 20);
            this.txtmax.TabIndex = 285;
            this.txtmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 284;
            this.label2.Text = "Maximum";
            // 
            // txtmin
            // 
            this.txtmin.Location = new System.Drawing.Point(80, 19);
            this.txtmin.Name = "txtmin";
            this.txtmin.Size = new System.Drawing.Size(192, 20);
            this.txtmin.TabIndex = 283;
            this.txtmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtmin.TextChanged += new System.EventHandler(this.txtmin_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 282;
            this.label1.Text = "Minimum";
            // 
            // slab_details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 423);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Slab Details";
            this.Name = "slab_details";
            this.Load += new System.EventHandler(this.slab_details_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfmula)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbslab;
        private System.Windows.Forms.Label lblslab;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtslno;
        private System.Windows.Forms.Label lblslno;
        private System.Windows.Forms.TextBox txtamt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtmax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvfmula;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btndelete;
        private EDPComponent.VistaButton btnSubmit;
        private EDPComponent.VistaButton btnslab;
        private EDPComponent.VistaButton btnnew;
    }
}