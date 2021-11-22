namespace PayRollManagementSystem
{
    partial class Cheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cheque));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBank_Name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.rdbCheque_DD = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new EDPComponent.VistaButton();
            this.txtChequeNo = new EDPComponent.ComboDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.BtnSubmit = new EDPComponent.VistaButton();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.txtGivenTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dbGridView = new System.Windows.Forms.DataGridView();
            this.dbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.search = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_search = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_search)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBank_Name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rdbCash);
            this.groupBox1.Controls.Add(this.rdbCheque_DD);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.txtChequeNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbYear);
            this.groupBox1.Controls.Add(this.BtnSubmit);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtPurpose);
            this.groupBox1.Controls.Add(this.txtGivenTo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cheque_Entry";
            // 
            // txtBank_Name
            // 
            this.txtBank_Name.Location = new System.Drawing.Point(118, 104);
            this.txtBank_Name.Name = "txtBank_Name";
            this.txtBank_Name.Size = new System.Drawing.Size(226, 20);
            this.txtBank_Name.TabIndex = 299;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(11, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 298;
            this.label6.Text = "Bank";
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.ForeColor = System.Drawing.Color.Maroon;
            this.rdbCash.Location = new System.Drawing.Point(14, 20);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(53, 17);
            this.rdbCash.TabIndex = 297;
            this.rdbCash.TabStop = true;
            this.rdbCash.Text = "Cash";
            this.rdbCash.UseVisualStyleBackColor = true;
            this.rdbCash.CheckedChanged += new System.EventHandler(this.rdbCash_CheckedChanged);
            // 
            // rdbCheque_DD
            // 
            this.rdbCheque_DD.AutoSize = true;
            this.rdbCheque_DD.ForeColor = System.Drawing.Color.Maroon;
            this.rdbCheque_DD.Location = new System.Drawing.Point(118, 19);
            this.rdbCheque_DD.Name = "rdbCheque_DD";
            this.rdbCheque_DD.Size = new System.Drawing.Size(92, 17);
            this.rdbCheque_DD.TabIndex = 296;
            this.rdbCheque_DD.TabStop = true;
            this.rdbCheque_DD.Text = "Cheque/DD";
            this.rdbCheque_DD.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BaseColor = System.Drawing.Color.Ivory;
            this.btnUpdate.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.btnUpdate.ButtonText = "Update";
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.btnUpdate.Location = new System.Drawing.Point(257, 139);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 26);
            this.btnUpdate.TabIndex = 295;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Connection = null;
            this.txtChequeNo.DialogResult = "";
            this.txtChequeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(118, 44);
            this.txtChequeNo.LOVFlag = 0;
            this.txtChequeNo.MaxCharLength = 500;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.ReturnIndex = -1;
            this.txtChequeNo.ReturnValue = "";
            this.txtChequeNo.ReturnValue_3rd = "";
            this.txtChequeNo.ReturnValue_4th = "";
            this.txtChequeNo.Size = new System.Drawing.Size(109, 21);
            this.txtChequeNo.TabIndex = 294;
            this.txtChequeNo.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.txtChequeNo_DropDown);
            this.txtChequeNo.CloseUp += new EDPComponent.ComboDialog.CloseUpHandler(this.txtChequeNo_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(346, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 238;
            this.label5.Text = "Session";
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Location = new System.Drawing.Point(422, 19);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(109, 21);
            this.cmbYear.TabIndex = 10;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.BtnSubmit.BaseColor = System.Drawing.Color.Ivory;
            this.BtnSubmit.ButtonColor = System.Drawing.Color.DarkKhaki;
            this.BtnSubmit.ButtonText = "Submit";
            this.BtnSubmit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmit.ForeColor = System.Drawing.Color.Black;
            this.BtnSubmit.GlowColor = System.Drawing.Color.MediumSpringGreen;
            this.BtnSubmit.Location = new System.Drawing.Point(142, 139);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(85, 26);
            this.BtnSubmit.TabIndex = 9;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(118, 74);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(109, 20);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.Text = "0";
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(422, 81);
            this.txtPurpose.Multiline = true;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(246, 57);
            this.txtPurpose.TabIndex = 7;
            // 
            // txtGivenTo
            // 
            this.txtGivenTo.Location = new System.Drawing.Point(422, 50);
            this.txtGivenTo.Name = "txtGivenTo";
            this.txtGivenTo.Size = new System.Drawing.Size(246, 20);
            this.txtGivenTo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(11, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(346, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Purpose";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(346, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Given_To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cheque/DD No.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dbGridView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(677, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cheque_Details";
            // 
            // dbGridView
            // 
            this.dbGridView.AllowUserToAddRows = false;
            this.dbGridView.AllowUserToDeleteRows = false;
            this.dbGridView.AllowUserToOrderColumns = true;
            this.dbGridView.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dbGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dbGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbGridView.Location = new System.Drawing.Point(3, 17);
            this.dbGridView.Name = "dbGridView";
            this.dbGridView.ReadOnly = true;
            this.dbGridView.Size = new System.Drawing.Size(671, 194);
            this.dbGridView.TabIndex = 0;
            // 
            // search
            // 
            this.search.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.search.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(281, 11);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 22);
            this.search.TabIndex = 1;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(95, 13);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(180, 20);
            this.txtSearchValue.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pic_search);
            this.panel1.Controls.Add(this.txtSearchValue);
            this.panel1.Controls.Add(this.search);
            this.panel1.Location = new System.Drawing.Point(173, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 43);
            this.panel1.TabIndex = 41;
            // 
            // pic_search
            // 
            this.pic_search.Image = ((System.Drawing.Image)(resources.GetObject("pic_search.Image")));
            this.pic_search.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_search.InitialImage")));
            this.pic_search.Location = new System.Drawing.Point(64, 11);
            this.pic_search.Name = "pic_search";
            this.pic_search.Size = new System.Drawing.Size(27, 22);
            this.pic_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pic_search.TabIndex = 42;
            this.pic_search.TabStop = false;
            // 
            // Cheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(701, 467);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Cheque";
            this.Text = "Check";
            this.Load += new System.EventHandler(this.Cheque_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.TextBox txtGivenTo;
        private System.Windows.Forms.TextBox txtAmount;
        private EDPComponent.VistaButton BtnSubmit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbYear;
        private EDPComponent.ComboDialog txtChequeNo;
        private EDPComponent.VistaButton btnUpdate;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.RadioButton rdbCheque_DD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dbGridView;
        private System.Windows.Forms.BindingSource dbBindingSource;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pic_search;
        private System.Windows.Forms.TextBox txtBank_Name;
        private System.Windows.Forms.Label label6;
    }
}