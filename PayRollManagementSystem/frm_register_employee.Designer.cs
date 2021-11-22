namespace PayRollManagementSystem
{
    partial class frm_register_employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_register_employee));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCo = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoc = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExp = new EDPComponent.VistaButton();
            this.dgvEmp = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCo);
            this.panel1.Controls.Add(this.lblClient);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbLoc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblLoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1303, 76);
            this.panel1.TabIndex = 0;
            // 
            // lblCo
            // 
            this.lblCo.AutoSize = true;
            this.lblCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCo.Location = new System.Drawing.Point(523, 42);
            this.lblCo.Name = "lblCo";
            this.lblCo.Size = new System.Drawing.Size(2, 15);
            this.lblCo.TabIndex = 296;
            this.lblCo.Visible = false;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClient.Location = new System.Drawing.Point(524, 16);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(2, 15);
            this.lblClient.TabIndex = 296;
            this.lblClient.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 12);
            this.label1.TabIndex = 295;
            this.label1.Text = "Select particular location to generate Employee list";
            // 
            // cmbLoc
            // 
            this.cmbLoc.Connection = null;
            this.cmbLoc.DialogResult = "";
            this.cmbLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoc.Location = new System.Drawing.Point(14, 26);
            this.cmbLoc.LOVFlag = 0;
            this.cmbLoc.MaxCharLength = 500;
            this.cmbLoc.Name = "cmbLoc";
            this.cmbLoc.ReturnIndex = -1;
            this.cmbLoc.ReturnValue = "";
            this.cmbLoc.ReturnValue_3rd = "";
            this.cmbLoc.ReturnValue_4th = "";
            this.cmbLoc.Size = new System.Drawing.Size(469, 21);
            this.cmbLoc.TabIndex = 294;
            this.cmbLoc.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLoc_DropDown);
            this.cmbLoc.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLoc_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 293;
            this.label2.Text = "Select Location from list";
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoc.Location = new System.Drawing.Point(735, 42);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(2, 15);
            this.lblLoc.TabIndex = 293;
            this.lblLoc.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 541);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1303, 25);
            this.panel2.TabIndex = 1;
            // 
            // btnExp
            // 
            this.btnExp.BackColor = System.Drawing.Color.Transparent;
            this.btnExp.BaseColor = System.Drawing.Color.Ivory;
            this.btnExp.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnExp.ButtonText = "Export to Excel";
            this.btnExp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExp.ForeColor = System.Drawing.Color.Black;
            this.btnExp.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnExp.Location = new System.Drawing.Point(1158, 0);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(145, 25);
            this.btnExp.TabIndex = 5;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // dgvEmp
            // 
            this.dgvEmp.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmp.Location = new System.Drawing.Point(0, 76);
            this.dgvEmp.Name = "dgvEmp";
            this.dgvEmp.Size = new System.Drawing.Size(1303, 465);
            this.dgvEmp.TabIndex = 2;
            // 
            // frm_register_employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1303, 566);
            this.Controls.Add(this.dgvEmp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_register_employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form A - Employment Register";
            this.Load += new System.EventHandler(this.frm_register_employee_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvEmp;
        private EDPComponent.ComboDialog cmbLoc;
        private System.Windows.Forms.Label lblLoc;
        private EDPComponent.VistaButton btnExp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblCo;
        private System.Windows.Forms.Label label2;
    }
}