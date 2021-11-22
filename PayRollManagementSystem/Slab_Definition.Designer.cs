namespace PayRollManagementSystem
{
    partial class Slab_Definition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Slab_Definition));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnfmula = new EDPComponent.VistaButton();
            this.cmbfmula = new System.Windows.Forms.ComboBox();
            this.lblfmula = new System.Windows.Forms.Label();
            this.txtdes = new System.Windows.Forms.TextBox();
            this.txtslno = new System.Windows.Forms.TextBox();
            this.lbldes = new System.Windows.Forms.Label();
            this.lblslno = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.rbbof = new System.Windows.Forms.RadioButton();
            this.lblname = new System.Windows.Forms.Label();
            this.rbte = new System.Windows.Forms.RadioButton();
            this.btnclose = new EDPComponent.VistaButton();
            this.btndelete = new EDPComponent.VistaButton();
            this.btnSubmit = new EDPComponent.VistaButton();
            this.dgvfmula = new System.Windows.Forms.DataGridView();
            this.btnnew = new EDPComponent.VistaButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfmula)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.dgvfmula);
            this.panel1.Location = new System.Drawing.Point(2, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 377);
            this.panel1.TabIndex = 42;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnfmula);
            this.groupBox1.Controls.Add(this.cmbfmula);
            this.groupBox1.Controls.Add(this.lblfmula);
            this.groupBox1.Controls.Add(this.txtdes);
            this.groupBox1.Controls.Add(this.txtslno);
            this.groupBox1.Controls.Add(this.lbldes);
            this.groupBox1.Controls.Add(this.lblslno);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.rbbof);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.rbte);
            this.groupBox1.Location = new System.Drawing.Point(9, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 165);
            this.groupBox1.TabIndex = 277;
            this.groupBox1.TabStop = false;
            // 
            // btnfmula
            // 
            this.btnfmula.BackColor = System.Drawing.Color.Transparent;
            this.btnfmula.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnfmula.BackgroundImage")));
            this.btnfmula.ButtonText = "--";
            this.btnfmula.Enabled = false;
            this.btnfmula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfmula.Location = new System.Drawing.Point(285, 131);
            this.btnfmula.Name = "btnfmula";
            this.btnfmula.Size = new System.Drawing.Size(26, 22);
            this.btnfmula.TabIndex = 286;
            this.btnfmula.Click += new System.EventHandler(this.btnfmula_Click);
            // 
            // cmbfmula
            // 
            this.cmbfmula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfmula.Enabled = false;
            this.cmbfmula.FormattingEnabled = true;
            this.cmbfmula.Location = new System.Drawing.Point(65, 132);
            this.cmbfmula.Name = "cmbfmula";
            this.cmbfmula.Size = new System.Drawing.Size(214, 21);
            this.cmbfmula.TabIndex = 285;
            this.cmbfmula.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmbfmula_MouseDown);
            // 
            // lblfmula
            // 
            this.lblfmula.AutoSize = true;
            this.lblfmula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfmula.Location = new System.Drawing.Point(8, 133);
            this.lblfmula.Name = "lblfmula";
            this.lblfmula.Size = new System.Drawing.Size(53, 15);
            this.lblfmula.TabIndex = 284;
            this.lblfmula.Text = "Formula";
            // 
            // txtdes
            // 
            this.txtdes.Location = new System.Drawing.Point(96, 67);
            this.txtdes.Name = "txtdes";
            this.txtdes.Size = new System.Drawing.Size(215, 20);
            this.txtdes.TabIndex = 283;
            // 
            // txtslno
            // 
            this.txtslno.Location = new System.Drawing.Point(96, 15);
            this.txtslno.Name = "txtslno";
            this.txtslno.Size = new System.Drawing.Size(215, 20);
            this.txtslno.TabIndex = 279;
            this.txtslno.TextChanged += new System.EventHandler(this.txtslno_TextChanged);
            // 
            // lbldes
            // 
            this.lbldes.AutoSize = true;
            this.lbldes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldes.Location = new System.Drawing.Point(8, 68);
            this.lbldes.Name = "lbldes";
            this.lbldes.Size = new System.Drawing.Size(69, 15);
            this.lbldes.TabIndex = 282;
            this.lbldes.Text = "Description";
            // 
            // lblslno
            // 
            this.lblslno.AutoSize = true;
            this.lblslno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblslno.Location = new System.Drawing.Point(8, 16);
            this.lblslno.Name = "lblslno";
            this.lblslno.Size = new System.Drawing.Size(40, 15);
            this.lblslno.TabIndex = 278;
            this.lblslno.Text = "Sl. No";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(96, 41);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(215, 20);
            this.txtname.TabIndex = 281;
            // 
            // rbbof
            // 
            this.rbbof.AutoSize = true;
            this.rbbof.Location = new System.Drawing.Point(199, 110);
            this.rbbof.Name = "rbbof";
            this.rbbof.Size = new System.Drawing.Size(112, 17);
            this.rbbof.TabIndex = 10;
            this.rbbof.Text = "Based On Formula";
            this.rbbof.UseVisualStyleBackColor = true;
            this.rbbof.CheckedChanged += new System.EventHandler(this.rbbof_CheckedChanged);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(8, 42);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(41, 15);
            this.lblname.TabIndex = 280;
            this.lblname.Text = "Name";
            // 
            // rbte
            // 
            this.rbte.AutoSize = true;
            this.rbte.Checked = true;
            this.rbte.Location = new System.Drawing.Point(96, 110);
            this.rbte.Name = "rbte";
            this.rbte.Size = new System.Drawing.Size(93, 17);
            this.rbte.TabIndex = 9;
            this.rbte.TabStop = true;
            this.rbte.Text = "Total Earnings";
            this.rbte.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.ButtonText = "Close";
            this.btnclose.Location = new System.Drawing.Point(246, 340);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 29);
            this.btnclose.TabIndex = 276;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndelete.BackgroundImage")));
            this.btndelete.ButtonText = "Delete";
            this.btndelete.Location = new System.Drawing.Point(74, 307);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(80, 29);
            this.btndelete.TabIndex = 275;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.ButtonText = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(160, 307);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 29);
            this.btnSubmit.TabIndex = 274;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvfmula
            // 
            this.dgvfmula.AllowUserToAddRows = false;
            this.dgvfmula.AllowUserToDeleteRows = false;
            this.dgvfmula.AllowUserToResizeColumns = false;
            this.dgvfmula.AllowUserToResizeRows = false;
            this.dgvfmula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfmula.Location = new System.Drawing.Point(9, 169);
            this.dgvfmula.MultiSelect = false;
            this.dgvfmula.Name = "dgvfmula";
            this.dgvfmula.ReadOnly = true;
            this.dgvfmula.RowHeadersVisible = false;
            this.dgvfmula.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvfmula.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfmula.Size = new System.Drawing.Size(317, 132);
            this.dgvfmula.TabIndex = 271;
            this.dgvfmula.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvfmula_CellClick);
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.Transparent;
            this.btnnew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnnew.BackgroundImage")));
            this.btnnew.ButtonText = "New Entry";
            this.btnnew.Location = new System.Drawing.Point(246, 307);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(80, 29);
            this.btnnew.TabIndex = 278;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // Slab_Definition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 410);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Slab Definition";
            this.Name = "Slab_Definition";
            this.Load += new System.EventHandler(this.Slab_Definition_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfmula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbbof;
        private System.Windows.Forms.RadioButton rbte;
        private System.Windows.Forms.DataGridView dgvfmula;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btndelete;
        private EDPComponent.VistaButton btnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtdes;
        private System.Windows.Forms.TextBox txtslno;
        private System.Windows.Forms.Label lbldes;
        private System.Windows.Forms.Label lblslno;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lblname;
        private EDPComponent.VistaButton btnfmula;
        private System.Windows.Forms.ComboBox cmbfmula;
        private System.Windows.Forms.Label lblfmula;
        private EDPComponent.VistaButton btnnew;
    }
}