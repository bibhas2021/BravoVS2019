namespace PayRollManagementSystem
{
    partial class FrmPFCode
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
            this.btnsave = new EDPComponent.VistaButton();
            this.btnclose = new EDPComponent.VistaButton();
            this.btndelete = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpfcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.dgvquery = new System.Windows.Forms.DataGridView();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.vistaButton2 = new EDPComponent.VistaButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvquery)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vistaButton2);
            this.groupBox1.Controls.Add(this.vistaButton1);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Controls.Add(this.btnclose);
            this.groupBox1.Controls.Add(this.btndelete);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtpfcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbcompany);
            this.groupBox1.Controls.Add(this.dgvquery);
            this.groupBox1.Location = new System.Drawing.Point(8, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 314);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Transparent;
            this.btnsave.BaseColor = System.Drawing.Color.SlateGray;
            this.btnsave.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.ButtonText = "Save";
            this.btnsave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.GlowColor = System.Drawing.Color.Aqua;
            this.btnsave.Location = new System.Drawing.Point(90, 65);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(78, 29);
            this.btnsave.TabIndex = 297;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.BaseColor = System.Drawing.Color.SlateGray;
            this.btnclose.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnclose.ButtonText = "Close";
            this.btnclose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.GlowColor = System.Drawing.Color.Aqua;
            this.btnclose.Location = new System.Drawing.Point(254, 65);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(78, 29);
            this.btnclose.TabIndex = 296;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Transparent;
            this.btndelete.BaseColor = System.Drawing.Color.SlateGray;
            this.btndelete.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btndelete.ButtonText = "Delete";
            this.btndelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.GlowColor = System.Drawing.Color.Aqua;
            this.btndelete.Location = new System.Drawing.Point(172, 65);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(78, 29);
            this.btndelete.TabIndex = 295;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 291;
            this.label2.Text = "PF Code";
            // 
            // txtpfcode
            // 
            this.txtpfcode.Location = new System.Drawing.Point(92, 39);
            this.txtpfcode.Name = "txtpfcode";
            this.txtpfcode.Size = new System.Drawing.Size(239, 20);
            this.txtpfcode.TabIndex = 290;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 289;
            this.label1.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(92, 12);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(239, 21);
            this.cmbcompany.TabIndex = 288;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbstructure_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbstructure_CloseUp);
            // 
            // dgvquery
            // 
            this.dgvquery.AllowUserToAddRows = false;
            this.dgvquery.AllowUserToDeleteRows = false;
            this.dgvquery.AllowUserToResizeColumns = false;
            this.dgvquery.AllowUserToResizeRows = false;
            this.dgvquery.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvquery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvquery.Location = new System.Drawing.Point(7, 104);
            this.dgvquery.MultiSelect = false;
            this.dgvquery.Name = "dgvquery";
            this.dgvquery.ReadOnly = true;
            this.dgvquery.RowHeadersVisible = false;
            this.dgvquery.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvquery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvquery.Size = new System.Drawing.Size(324, 201);
            this.dgvquery.TabIndex = 287;
            this.dgvquery.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvquery_CellClick);
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton1.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton1.ButtonText = "Update";
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton1.Location = new System.Drawing.Point(90, 65);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(78, 29);
            this.vistaButton1.TabIndex = 298;
            this.vistaButton1.Visible = false;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // vistaButton2
            // 
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton2.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton2.ButtonText = "New Entry";
            this.vistaButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton2.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton2.Location = new System.Drawing.Point(6, 65);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(80, 29);
            this.vistaButton2.TabIndex = 299;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // FrmPFCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 348);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPFCode";
            this.Load += new System.EventHandler(this.FrmPFCode_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvquery)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvquery;
        private System.Windows.Forms.Label label1;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpfcode;
        private EDPComponent.VistaButton btnsave;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btndelete;
        private EDPComponent.VistaButton vistaButton1;
        private EDPComponent.VistaButton vistaButton2;

    }
}