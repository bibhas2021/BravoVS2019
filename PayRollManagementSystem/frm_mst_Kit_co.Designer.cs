namespace PayRollManagementSystem
{
    partial class frm_mst_Kit_co
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mst_Kit_co));
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dgv_Kit = new System.Windows.Forms.DataGridView();
            this.company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KTVAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpeningStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpeningValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblKVal = new System.Windows.Forms.Label();
            this.lblKQty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kit)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.BackColor = System.Drawing.Color.White;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(83, 5);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(145, 21);
            this.cmbYear.TabIndex = 259;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(10, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 15);
            this.label22.TabIndex = 260;
            this.label22.Text = "Session";
            // 
            // dgv_Kit
            // 
            this.dgv_Kit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Kit.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Kit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Kit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.company,
            this.KTNO,
            this.KTNAME,
            this.KTVAL,
            this.OpeningStock,
            this.Unit,
            this.Date,
            this.OpeningValue,
            this.MinStock,
            this.msUnit,
            this.roQty,
            this.roUnit,
            this.coid});
            this.dgv_Kit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgv_Kit.GridColor = System.Drawing.Color.DarkGray;
            this.dgv_Kit.Location = new System.Drawing.Point(4, 31);
            this.dgv_Kit.Name = "dgv_Kit";
            this.dgv_Kit.Size = new System.Drawing.Size(998, 412);
            this.dgv_Kit.TabIndex = 258;
            this.dgv_Kit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Kit_CellDoubleClick);
            this.dgv_Kit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Kit_CellEndEdit);
            // 
            // company
            // 
            this.company.DataPropertyName = "Company";
            this.company.HeaderText = "Company";
            this.company.Name = "company";
            // 
            // KTNO
            // 
            this.KTNO.DataPropertyName = "KTID";
            this.KTNO.HeaderText = "KIT NO";
            this.KTNO.Name = "KTNO";
            this.KTNO.Visible = false;
            // 
            // KTNAME
            // 
            this.KTNAME.DataPropertyName = "KTNAME";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.KTNAME.DefaultCellStyle = dataGridViewCellStyle1;
            this.KTNAME.HeaderText = "KIT NAME";
            this.KTNAME.MinimumWidth = 150;
            this.KTNAME.Name = "KTNAME";
            this.KTNAME.Width = 250;
            // 
            // KTVAL
            // 
            this.KTVAL.DataPropertyName = "KTVAL";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.KTVAL.DefaultCellStyle = dataGridViewCellStyle2;
            this.KTVAL.HeaderText = "RATE";
            this.KTVAL.Name = "KTVAL";
            // 
            // OpeningStock
            // 
            this.OpeningStock.DataPropertyName = "opn_stock";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OpeningStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.OpeningStock.HeaderText = "OPENING STOCK";
            this.OpeningStock.Name = "OpeningStock";
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Unit.DefaultCellStyle = dataGridViewCellStyle4;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "K_date";
            this.Date.HeaderText = "OPENING DATE";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OpeningValue
            // 
            this.OpeningValue.DataPropertyName = "opn_value";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OpeningValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.OpeningValue.HeaderText = "OPENING VALUE";
            this.OpeningValue.Name = "OpeningValue";
            // 
            // MinStock
            // 
            this.MinStock.DataPropertyName = "MinStock";
            this.MinStock.HeaderText = "Min Stock";
            this.MinStock.Name = "MinStock";
            // 
            // msUnit
            // 
            this.msUnit.DataPropertyName = "msUnit";
            this.msUnit.HeaderText = "Unit";
            this.msUnit.Name = "msUnit";
            // 
            // roQty
            // 
            this.roQty.DataPropertyName = "roQty";
            this.roQty.HeaderText = "Reorder Qty";
            this.roQty.Name = "roQty";
            // 
            // roUnit
            // 
            this.roUnit.DataPropertyName = "roUnit";
            this.roUnit.HeaderText = "Unit";
            this.roUnit.Name = "roUnit";
            // 
            // coid
            // 
            this.coid.DataPropertyName = "coid";
            this.coid.HeaderText = "coid";
            this.coid.Name = "coid";
            this.coid.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.Ivory;
            this.btnSave.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnSave.Location = new System.Drawing.Point(822, 449);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 26);
            this.btnSave.TabIndex = 262;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.Ivory;
            this.btnClose.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnClose.Location = new System.Drawing.Point(915, 449);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 26);
            this.btnClose.TabIndex = 261;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMsg.AutoSize = true;
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMsg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(639, 454);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(2, 16);
            this.lblMsg.TabIndex = 265;
            // 
            // lblKVal
            // 
            this.lblKVal.AutoSize = true;
            this.lblKVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKVal.Location = new System.Drawing.Point(476, 11);
            this.lblKVal.Name = "lblKVal";
            this.lblKVal.Size = new System.Drawing.Size(15, 15);
            this.lblKVal.TabIndex = 266;
            this.lblKVal.Text = "0";
            // 
            // lblKQty
            // 
            this.lblKQty.AutoSize = true;
            this.lblKQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKQty.Location = new System.Drawing.Point(600, 12);
            this.lblKQty.Name = "lblKQty";
            this.lblKQty.Size = new System.Drawing.Size(15, 15);
            this.lblKQty.TabIndex = 267;
            this.lblKQty.Text = "0";
            // 
            // frm_mst_Kit_co
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 478);
            this.Controls.Add(this.lblKQty);
            this.Controls.Add(this.lblKVal);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.dgv_Kit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_mst_Kit_co";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KIT Log";
            this.Load += new System.EventHandler(this.frm_mst_Kit_co_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Kit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView dgv_Kit;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn company;
        private System.Windows.Forms.DataGridViewTextBoxColumn KTNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn KTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn KTVAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpeningStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpeningValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn msUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn roQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn roUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn coid;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblKVal;
        private System.Windows.Forms.Label lblKQty;

    }
}