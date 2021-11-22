namespace PayRollManagementSystem
{
    partial class frmAddErnDeduc
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Earning");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Deduction");
            this.tv = new System.Windows.Forms.TreeView();
            this.btnAdd = new EDPComponent.VistaButton();
            this.btnDel = new EDPComponent.VistaButton();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnSave = new EDPComponent.VistaButton();
            this.btnNew = new EDPComponent.VistaButton();
            this.btnClose = new EDPComponent.VistaButton();
            this.btnDelete = new EDPComponent.VistaButton();
            this.cmbdEmpId = new EDPComponent.ComboDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmpname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCmpCut = new TextBoxX.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.Location = new System.Drawing.Point(7, 53);
            this.tv.Name = "tv";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Earning";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Deduction";
            this.tv.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.tv.Size = new System.Drawing.Size(198, 343);
            this.tv.TabIndex = 2;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ButtonText = "Add";
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(12, 402);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 29);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.ButtonText = "Delete";
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(115, 402);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(88, 29);
            this.btnDel.TabIndex = 4;
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
            this.cmbMonth.Location = new System.Drawing.Point(303, 28);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(114, 21);
            this.cmbMonth.TabIndex = 1;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(213, 33);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(89, 13);
            this.label21.TabIndex = 13;
            this.label21.Text = "For The Month of";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(60, 28);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(131, 21);
            this.cmbYear.TabIndex = 0;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(51, 15);
            this.label22.TabIndex = 12;
            this.label22.Text = "Session";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Location = new System.Drawing.Point(216, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 260);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details:-";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Location = new System.Drawing.Point(9, 19);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(487, 233);
            this.dgv.TabIndex = 0;
            this.dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RowEnter);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Location = new System.Drawing.Point(355, 402);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 29);
            this.btnSave.TabIndex = 9;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.ButtonText = "New";
            this.btnNew.Location = new System.Drawing.Point(225, 402);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 29);
            this.btnNew.TabIndex = 8;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Location = new System.Drawing.Point(600, 402);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 29);
            this.btnClose.TabIndex = 11;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.ButtonText = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(478, 402);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 29);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbdEmpId
            // 
            this.cmbdEmpId.Connection = null;
            this.cmbdEmpId.DialogResult = "";
            this.cmbdEmpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdEmpId.Location = new System.Drawing.Point(303, 63);
            this.cmbdEmpId.LOVFlag = 0;
            this.cmbdEmpId.Name = "cmbdEmpId";
            this.cmbdEmpId.ReturnValue = "";
            this.cmbdEmpId.Size = new System.Drawing.Size(170, 21);
            this.cmbdEmpId.TabIndex = 5;
            this.cmbdEmpId.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.cmbdEmpId_DropDown);
            this.cmbdEmpId.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.cmbdEmpId_CloseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Employee";
            // 
            // lblEmpname
            // 
            this.lblEmpname.AutoSize = true;
            this.lblEmpname.Location = new System.Drawing.Point(301, 90);
            this.lblEmpname.Name = "lblEmpname";
            this.lblEmpname.Size = new System.Drawing.Size(0, 13);
            this.lblEmpname.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Amount";
            // 
            // txtCmpCut
            // 
            this.txtCmpCut.FocussedColor = System.Drawing.Color.Silver;
            this.txtCmpCut.Location = new System.Drawing.Point(303, 109);
            this.txtCmpCut.Name = "txtCmpCut";
            this.txtCmpCut.NumericStyle = TextBoxX.TextBoxX.Style.UnsignedFraction;
            this.txtCmpCut.Size = new System.Drawing.Size(114, 20);
            this.txtCmpCut.TabIndex = 6;
            this.txtCmpCut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "From Date ";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "From Date ";
            this.label4.Visible = false;
            // 
            // frmAddErnDeduc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 445);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCmpCut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEmpname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbdEmpId);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Payment for Extra Duty in Vacation and Holidays";
            this.Name = "frmAddErnDeduc";
            this.Load += new System.EventHandler(this.frmAddErnDeduc_Load);
            this.Controls.SetChildIndex(this.tv, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.cmbYear, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.cmbMonth, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.cmbdEmpId, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblEmpname, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtCmpCut, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv;
        private EDPComponent.VistaButton btnAdd;
        private EDPComponent.VistaButton btnDel;
        private System.Windows.Forms.ComboBox cmbMonth;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox1;
        private EDPComponent.VistaButton btnSave;
        private EDPComponent.VistaButton btnNew;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnDelete;
        private EDPComponent.ComboDialog cmbdEmpId;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblEmpname;
        internal System.Windows.Forms.Label label2;
        private TextBoxX.TextBoxX txtCmpCut;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}