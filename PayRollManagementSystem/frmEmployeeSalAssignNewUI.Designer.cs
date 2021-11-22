namespace PayRollManagementSystem
{
    partial class frmEmployeeSalAssignNewUI
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
            this.CmbSalStructure = new EDPComponent.ComboDialog();
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new EDPComponent.VistaButton();
            this.dgvAssignHeads = new System.Windows.Forms.DataGridView();
            this.cmbCompany = new EDPComponent.ComboDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new EDPComponent.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignHeads)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbSalStructure
            // 
            this.CmbSalStructure.Connection = null;
            this.CmbSalStructure.DialogResult = "";
            this.CmbSalStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSalStructure.Location = new System.Drawing.Point(146, 57);
            this.CmbSalStructure.LOVFlag = 0;
            this.CmbSalStructure.MaxCharLength = 500;
            this.CmbSalStructure.Name = "CmbSalStructure";
            this.CmbSalStructure.ReturnIndex = -1;
            this.CmbSalStructure.ReturnValue = "";
            this.CmbSalStructure.ReturnValue_3rd = "";
            this.CmbSalStructure.ReturnValue_4th = "";
            this.CmbSalStructure.Size = new System.Drawing.Size(313, 21);
            this.CmbSalStructure.TabIndex = 93;
            this.CmbSalStructure.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.CmbSalStructure_DropDown);
            this.CmbSalStructure.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.CmbSalStructure_CloseUp);
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(146, 30);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(313, 21);
            this.cmbLocation.TabIndex = 94;
            this.cmbLocation.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbLocation_DropDown);
            this.cmbLocation.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbLocation_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 96;
            this.label2.Text = "Salary Structure Name";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.SlateGray;
            this.btnSave.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.GlowColor = System.Drawing.Color.Aqua;
            this.btnSave.Location = new System.Drawing.Point(1062, 497);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 29);
            this.btnSave.TabIndex = 315;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvAssignHeads
            // 
            this.dgvAssignHeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignHeads.Location = new System.Drawing.Point(12, 84);
            this.dgvAssignHeads.Name = "dgvAssignHeads";
            this.dgvAssignHeads.Size = new System.Drawing.Size(1239, 407);
            this.dgvAssignHeads.TabIndex = 316;
            this.dgvAssignHeads.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssignHeads_CellValueChanged);
            this.dgvAssignHeads.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAssignHeads_CellMouseUp);
            this.dgvAssignHeads.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAssignHeads_ColumnHeaderMouseDoubleClick);
            this.dgvAssignHeads.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvAssignHeads_CurrentCellDirtyStateChanged);
            this.dgvAssignHeads.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAssignHeads_DataError);
            // 
            // cmbCompany
            // 
            this.cmbCompany.Connection = null;
            this.cmbCompany.DialogResult = "";
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCompany.Location = new System.Drawing.Point(146, 3);
            this.cmbCompany.LOVFlag = 0;
            this.cmbCompany.MaxCharLength = 500;
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.ReturnIndex = -1;
            this.cmbCompany.ReturnValue = "";
            this.cmbCompany.ReturnValue_3rd = "";
            this.cmbCompany.ReturnValue_4th = "";
            this.cmbCompany.Size = new System.Drawing.Size(313, 21);
            this.cmbCompany.TabIndex = 317;
            this.cmbCompany.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbCompany_DropDown);
            this.cmbCompany.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbCompany_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 318;
            this.label3.Text = "Company";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BaseColor = System.Drawing.Color.SlateGray;
            this.btnClear.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnClear.ButtonText = "Clear";
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.GlowColor = System.Drawing.Color.Aqua;
            this.btnClear.Location = new System.Drawing.Point(1164, 497);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 29);
            this.btnClear.TabIndex = 319;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmEmployeeSalAssignNewUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 538);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.dgvAssignHeads);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.CmbSalStructure);
            this.Name = "frmEmployeeSalAssignNewUI";
            this.Text = "frmEmployeeSalAssignNewUI";
            this.Load += new System.EventHandler(this.frmEmployeeSalAssignNewUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignHeads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog CmbSalStructure;
        private EDPComponent.ComboDialog cmbLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private EDPComponent.VistaButton btnSave;
        private System.Windows.Forms.DataGridView dgvAssignHeads;
        private EDPComponent.ComboDialog cmbCompany;
        private System.Windows.Forms.Label label3;
        private EDPComponent.VistaButton btnClear;
    }
}