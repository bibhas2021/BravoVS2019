namespace PayRollManagementSystem
{
    partial class frmSelectcomp
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
            this.btnClose = new EDPComponent.VistaButton();
            this.btnSelect = new EDPComponent.VistaButton();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lbxSelectyear = new System.Windows.Forms.ListBox();
            this.lbxSelectname = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Snow;
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.lblDisplay);
            this.groupBox1.Controls.Add(this.lbxSelectyear);
            this.groupBox1.Controls.Add(this.lbxSelectname);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(11, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company Information";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.ButtonText = "  Close";
            this.btnClose.CornerRadius = 4;
            this.btnClose.GlowColor = System.Drawing.Color.White;
            ////////////this.btnClose.Image = global::PayRollManagementSystem.Properties.Resources.W95MBX011;
            this.btnClose.ImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(332, 234);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnSelect.ButtonText = "  Select";
            this.btnSelect.CornerRadius = 4;
            this.btnSelect.GlowColor = System.Drawing.Color.White;
            //////////this.btnSelect.Image = global::PayRollManagementSystem.Properties.Resources.bot;
            this.btnSelect.ImageSize = new System.Drawing.Size(16, 16);
            this.btnSelect.Location = new System.Drawing.Point(456, 160);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(80, 30);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblDisplay
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Location = new System.Drawing.Point(1, 137);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(0, 13);
            this.lblDisplay.TabIndex = 4;
            // 
            // lbxSelectyear
            // 
            this.lbxSelectyear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxSelectyear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxSelectyear.FormattingEnabled = true;
            this.lbxSelectyear.Location = new System.Drawing.Point(402, 15);
            this.lbxSelectyear.Name = "lbxSelectyear";
            this.lbxSelectyear.Size = new System.Drawing.Size(134, 119);
            this.lbxSelectyear.TabIndex = 1;
            this.lbxSelectyear.Leave += new System.EventHandler(this.lbxSelectname_Leave);
            this.lbxSelectyear.Enter += new System.EventHandler(this.lbxSelectname_Enter);
            this.lbxSelectyear.SelectedIndexChanged += new System.EventHandler(this.lbxSelectyear_SelectedIndexChanged);
            this.lbxSelectyear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxSelectyear_KeyDown);
            // 
            // lbxSelectname
            // 
            this.lbxSelectname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxSelectname.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxSelectname.FormattingEnabled = true;
            this.lbxSelectname.Location = new System.Drawing.Point(4, 15);
            this.lbxSelectname.Name = "lbxSelectname";
            this.lbxSelectname.Size = new System.Drawing.Size(392, 119);
            this.lbxSelectname.TabIndex = 0;
            this.lbxSelectname.Leave += new System.EventHandler(this.lbxSelectname_Leave);
            this.lbxSelectname.DoubleClick += new System.EventHandler(this.btnSelect_Click);
            this.lbxSelectname.Enter += new System.EventHandler(this.lbxSelectname_Enter);
            this.lbxSelectname.SelectedIndexChanged += new System.EventHandler(this.lbxSelectname_SelectedIndexChanged);
            this.lbxSelectname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxSelectname_KeyDown);
            // 
            // frmSelectcomp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(565, 234);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HeaderText = "Session : 0             User :              Branch Name :  ()";
            this.Name = "frmSelectcomp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Company";
            this.Shown += new System.EventHandler(this.frmSelectcomp_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelectcomp_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSelectcomp_KeyDown);
            this.Load += new System.EventHandler(this.frmSelectcomp_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxSelectyear;
        private System.Windows.Forms.ListBox lbxSelectname;
        private System.Windows.Forms.Label lblDisplay;
        private EDPComponent.VistaButton btnClose;
        private EDPComponent.VistaButton btnSelect;
    }
}