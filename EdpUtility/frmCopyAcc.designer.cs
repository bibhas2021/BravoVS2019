namespace Utility
{
    partial class frmCopyAcc
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Select_Company = new System.Windows.Forms.Label();
            this.btn_Close = new EDPComponent.VistaButton();
            this.TRV_COMPNY = new System.Windows.Forms.TreeView();
            this.btn_Save = new EDPComponent.VistaButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chepricelist = new System.Windows.Forms.CheckBox();
            this.chkbx_Acc = new System.Windows.Forms.CheckBox();
            this.chk_Consignee = new System.Windows.Forms.CheckBox();
            this.chk_Currency = new System.Windows.Forms.CheckBox();
            this.chkBranch = new System.Windows.Forms.CheckBox();
            this.chkConfigaration = new System.Windows.Forms.CheckBox();
            this.chkUserProfile = new System.Windows.Forms.CheckBox();
            this.chk_AllMst = new System.Windows.Forms.CheckBox();
            this.chkbx_InvMst = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbl_Select_Company);
            this.groupBox1.Controls.Add(this.btn_Close);
            this.groupBox1.Controls.Add(this.TRV_COMPNY);
            this.groupBox1.Controls.Add(this.btn_Save);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(10, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 366);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company List With Financial Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(13, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ctrl + H : to Active Branch, Profile and Consignee";
            // 
            // lbl_Select_Company
            // 
            this.lbl_Select_Company.AutoSize = true;
            this.lbl_Select_Company.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Select_Company.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbl_Select_Company.Location = new System.Drawing.Point(6, 210);
            this.lbl_Select_Company.Name = "lbl_Select_Company";
            this.lbl_Select_Company.Size = new System.Drawing.Size(257, 13);
            this.lbl_Select_Company.TabIndex = 17;
            this.lbl_Select_Company.Text = "Please Select a Company Financial Year First";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Close.ButtonText = "      Close";
            this.btn_Close.CornerRadius = 4;
            this.btn_Close.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Image = global::Utility.Properties.Resources.W95MBX01;
            this.btn_Close.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Close.Location = new System.Drawing.Point(344, 325);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(74, 30);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // TRV_COMPNY
            // 
            this.TRV_COMPNY.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TRV_COMPNY.Location = new System.Drawing.Point(7, 19);
            this.TRV_COMPNY.Name = "TRV_COMPNY";
            this.TRV_COMPNY.Size = new System.Drawing.Size(411, 181);
            this.TRV_COMPNY.TabIndex = 0;
            this.TRV_COMPNY.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TRV_COMPNY_AfterSelect);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Save.ButtonText = "    Ok";
            this.btn_Save.CornerRadius = 4;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Image = global::Utility.Properties.Resources.DISK04;
            this.btn_Save.ImageSize = new System.Drawing.Size(16, 16);
            this.btn_Save.Location = new System.Drawing.Point(264, 325);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(76, 30);
            this.btn_Save.TabIndex = 11;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chepricelist);
            this.groupBox2.Controls.Add(this.chkbx_Acc);
            this.groupBox2.Controls.Add(this.chk_Consignee);
            this.groupBox2.Controls.Add(this.chk_Currency);
            this.groupBox2.Controls.Add(this.chkBranch);
            this.groupBox2.Controls.Add(this.chkConfigaration);
            this.groupBox2.Controls.Add(this.chkUserProfile);
            this.groupBox2.Controls.Add(this.chk_AllMst);
            this.groupBox2.Controls.Add(this.chkbx_InvMst);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 84);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // chepricelist
            // 
            this.chepricelist.AutoSize = true;
            this.chepricelist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chepricelist.Location = new System.Drawing.Point(7, 56);
            this.chepricelist.Name = "chepricelist";
            this.chepricelist.Size = new System.Drawing.Size(68, 17);
            this.chepricelist.TabIndex = 21;
            this.chepricelist.Text = "Price List";
            this.chepricelist.UseVisualStyleBackColor = true;
            // 
            // chkbx_Acc
            // 
            this.chkbx_Acc.AutoSize = true;
            this.chkbx_Acc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbx_Acc.Location = new System.Drawing.Point(119, 10);
            this.chkbx_Acc.Name = "chkbx_Acc";
            this.chkbx_Acc.Size = new System.Drawing.Size(155, 17);
            this.chkbx_Acc.TabIndex = 13;
            this.chkbx_Acc.Text = "Account Master And Group";
            this.chkbx_Acc.UseVisualStyleBackColor = true;
            this.chkbx_Acc.CheckStateChanged += new System.EventHandler(this.chkbx_Acc_CheckStateChanged);
            // 
            // chk_Consignee
            // 
            this.chk_Consignee.AutoSize = true;
            this.chk_Consignee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Consignee.Location = new System.Drawing.Point(7, 33);
            this.chk_Consignee.Name = "chk_Consignee";
            this.chk_Consignee.Size = new System.Drawing.Size(105, 17);
            this.chk_Consignee.TabIndex = 20;
            this.chk_Consignee.Text = "Consignee Party";
            this.chk_Consignee.UseVisualStyleBackColor = true;
            // 
            // chk_Currency
            // 
            this.chk_Currency.AutoSize = true;
            this.chk_Currency.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Currency.Location = new System.Drawing.Point(119, 33);
            this.chk_Currency.Name = "chk_Currency";
            this.chk_Currency.Size = new System.Drawing.Size(70, 17);
            this.chk_Currency.TabIndex = 19;
            this.chk_Currency.Text = "Currency";
            this.chk_Currency.UseVisualStyleBackColor = true;
            this.chk_Currency.CheckStateChanged += new System.EventHandler(this.chk_Currency_CheckStateChanged);
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBranch.Location = new System.Drawing.Point(297, 56);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(59, 17);
            this.chkBranch.TabIndex = 18;
            this.chkBranch.Text = "Branch";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.Visible = false;
            this.chkBranch.CheckStateChanged += new System.EventHandler(this.chkBranch_CheckStateChanged);
            // 
            // chkConfigaration
            // 
            this.chkConfigaration.AutoSize = true;
            this.chkConfigaration.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConfigaration.Location = new System.Drawing.Point(297, 33);
            this.chkConfigaration.Name = "chkConfigaration";
            this.chkConfigaration.Size = new System.Drawing.Size(91, 17);
            this.chkConfigaration.TabIndex = 17;
            this.chkConfigaration.Text = "Configuration";
            this.chkConfigaration.UseVisualStyleBackColor = true;
            this.chkConfigaration.CheckStateChanged += new System.EventHandler(this.chkConfigaration_CheckStateChanged);
            // 
            // chkUserProfile
            // 
            this.chkUserProfile.AutoSize = true;
            this.chkUserProfile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUserProfile.Location = new System.Drawing.Point(7, 10);
            this.chkUserProfile.Name = "chkUserProfile";
            this.chkUserProfile.Size = new System.Drawing.Size(81, 17);
            this.chkUserProfile.TabIndex = 16;
            this.chkUserProfile.Text = "User Profile";
            this.chkUserProfile.UseVisualStyleBackColor = true;
            this.chkUserProfile.CheckStateChanged += new System.EventHandler(this.chkUserProfile_CheckStateChanged);
            this.chkUserProfile.Click += new System.EventHandler(this.chkUserProfile_Click);
            this.chkUserProfile.CheckedChanged += new System.EventHandler(this.chkUserProfile_CheckedChanged);
            // 
            // chk_AllMst
            // 
            this.chk_AllMst.AutoSize = true;
            this.chk_AllMst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_AllMst.Location = new System.Drawing.Point(119, 56);
            this.chk_AllMst.Name = "chk_AllMst";
            this.chk_AllMst.Size = new System.Drawing.Size(94, 17);
            this.chk_AllMst.TabIndex = 15;
            this.chk_AllMst.Text = "All The Master";
            this.chk_AllMst.UseVisualStyleBackColor = true;
            this.chk_AllMst.Visible = false;
            this.chk_AllMst.CheckStateChanged += new System.EventHandler(this.chk_AllMst_CheckStateChanged);
            // 
            // chkbx_InvMst
            // 
            this.chkbx_InvMst.AutoSize = true;
            this.chkbx_InvMst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbx_InvMst.Location = new System.Drawing.Point(297, 10);
            this.chkbx_InvMst.Name = "chkbx_InvMst";
            this.chkbx_InvMst.Size = new System.Drawing.Size(110, 17);
            this.chkbx_InvMst.TabIndex = 14;
            this.chkbx_InvMst.Text = "Inventory Master";
            this.chkbx_InvMst.UseVisualStyleBackColor = true;
            this.chkbx_InvMst.CheckStateChanged += new System.EventHandler(this.chkbx_InvMst_CheckStateChanged);
            // 
            // frmCopyAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 422);
            this.Controls.Add(this.groupBox1);
            this.HeaderText = "Session : 0             User :              Branch Name :  ()";
            this.Name = "frmCopyAcc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy Masters";
            this.Load += new System.EventHandler(this.frmCopyAcc_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCopyAcc_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCopyAcc_KeyDown);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView TRV_COMPNY;
        private EDPComponent.VistaButton btn_Close;
        private EDPComponent.VistaButton btn_Save;
        private System.Windows.Forms.CheckBox chk_AllMst;
        private System.Windows.Forms.CheckBox chkbx_InvMst;
        private System.Windows.Forms.CheckBox chkbx_Acc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkUserProfile;
        private System.Windows.Forms.CheckBox chkBranch;
        private System.Windows.Forms.CheckBox chkConfigaration;
        private System.Windows.Forms.CheckBox chk_Currency;
        private System.Windows.Forms.CheckBox chk_Consignee;
        private System.Windows.Forms.Label lbl_Select_Company;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chepricelist;



    }
}