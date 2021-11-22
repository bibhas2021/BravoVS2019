namespace PayRollManagementSystem
{
    partial class FrmESICode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmESICode));
            this.btnsave = new EDPComponent.VistaButton();
            this.btnclose = new EDPComponent.VistaButton();
            this.btndelete = new EDPComponent.VistaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtesicode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbcompany = new EDPComponent.ComboDialog();
            this.dgvquery = new System.Windows.Forms.DataGridView();
            this.vistaButton2 = new EDPComponent.VistaButton();
            this.vistaButton1 = new EDPComponent.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvquery)).BeginInit();
            this.SuspendLayout();
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
            this.btnsave.TabIndex = 313;
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
            this.btnclose.Location = new System.Drawing.Point(257, 65);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(78, 29);
            this.btnclose.TabIndex = 312;
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
            this.btndelete.Location = new System.Drawing.Point(173, 65);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(78, 29);
            this.btndelete.TabIndex = 311;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 310;
            this.label2.Text = "ESI Code";
            // 
            // txtesicode
            // 
            this.txtesicode.Location = new System.Drawing.Point(95, 39);
            this.txtesicode.Name = "txtesicode";
            this.txtesicode.Size = new System.Drawing.Size(235, 20);
            this.txtesicode.TabIndex = 309;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 308;
            this.label1.Text = "Company Name";
            // 
            // cmbcompany
            // 
            this.cmbcompany.Connection = null;
            this.cmbcompany.DialogResult = "";
            this.cmbcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompany.Location = new System.Drawing.Point(95, 12);
            this.cmbcompany.LOVFlag = 0;
            this.cmbcompany.MaxCharLength = 500;
            this.cmbcompany.Name = "cmbcompany";
            this.cmbcompany.ReturnIndex = -1;
            this.cmbcompany.ReturnValue = "";
            this.cmbcompany.ReturnValue_3rd = "";
            this.cmbcompany.ReturnValue_4th = "";
            this.cmbcompany.Size = new System.Drawing.Size(235, 21);
            this.cmbcompany.TabIndex = 307;
            this.cmbcompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbcompany_DropDown);
            this.cmbcompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbcompany_CloseUp);
            // 
            // dgvquery
            // 
            this.dgvquery.AllowUserToAddRows = false;
            this.dgvquery.AllowUserToDeleteRows = false;
            this.dgvquery.AllowUserToResizeColumns = false;
            this.dgvquery.AllowUserToResizeRows = false;
            this.dgvquery.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvquery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvquery.Location = new System.Drawing.Point(10, 110);
            this.dgvquery.MultiSelect = false;
            this.dgvquery.Name = "dgvquery";
            this.dgvquery.ReadOnly = true;
            this.dgvquery.RowHeadersVisible = false;
            this.dgvquery.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvquery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvquery.Size = new System.Drawing.Size(320, 216);
            this.dgvquery.TabIndex = 306;
            this.dgvquery.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvquery_CellClick);
            // 
            // vistaButton2
            // 
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton2.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton2.ButtonText = "New Entry";
            this.vistaButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton2.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton2.Location = new System.Drawing.Point(3, 65);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(80, 29);
            this.vistaButton2.TabIndex = 315;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.SlateGray;
            this.vistaButton1.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.vistaButton1.ButtonText = "Update";
            this.vistaButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton1.GlowColor = System.Drawing.Color.Aqua;
            this.vistaButton1.Location = new System.Drawing.Point(89, 65);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(78, 29);
            this.vistaButton1.TabIndex = 314;
            this.vistaButton1.Visible = false;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // FrmESICode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(339, 334);
            this.Controls.Add(this.vistaButton2);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtesicode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbcompany);
            this.Controls.Add(this.dgvquery);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmESICode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Esi Code";
            this.Load += new System.EventHandler(this.FrmESICode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvquery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.VistaButton btnsave;
        private EDPComponent.VistaButton btnclose;
        private EDPComponent.VistaButton btndelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtesicode;
        private System.Windows.Forms.Label label1;
        private EDPComponent.ComboDialog cmbcompany;
        private System.Windows.Forms.DataGridView dgvquery;
        private EDPComponent.VistaButton vistaButton2;
        private EDPComponent.VistaButton vistaButton1;
    }
}