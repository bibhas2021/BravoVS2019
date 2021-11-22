namespace PayRollManagementSystem
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.chk_activate_limit_PF = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtGross_PF = new System.Windows.Forms.TextBox();
            this.chk_activate_limit_ESI = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGross_ESI = new System.Windows.Forms.TextBox();
            this.chkLocContribution = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chk_activate_limit_PF
            // 
            this.chk_activate_limit_PF.AutoSize = true;
            this.chk_activate_limit_PF.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_activate_limit_PF.Location = new System.Drawing.Point(117, 34);
            this.chk_activate_limit_PF.Name = "chk_activate_limit_PF";
            this.chk_activate_limit_PF.Size = new System.Drawing.Size(120, 19);
            this.chk_activate_limit_PF.TabIndex = 1;
            this.chk_activate_limit_PF.Text = "Check to Activate PF";
            this.chk_activate_limit_PF.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max Gross Salary - PF";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(150, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 24);
            this.btnSave.TabIndex = 84;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtGross_PF
            // 
            this.txtGross_PF.BackColor = System.Drawing.Color.White;
            this.txtGross_PF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGross_PF.Location = new System.Drawing.Point(137, 59);
            this.txtGross_PF.Name = "txtGross_PF";
            this.txtGross_PF.Size = new System.Drawing.Size(100, 20);
            this.txtGross_PF.TabIndex = 85;
            this.txtGross_PF.Text = "0";
            this.txtGross_PF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chk_activate_limit_ESI
            // 
            this.chk_activate_limit_ESI.AutoSize = true;
            this.chk_activate_limit_ESI.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_activate_limit_ESI.Location = new System.Drawing.Point(114, 107);
            this.chk_activate_limit_ESI.Name = "chk_activate_limit_ESI";
            this.chk_activate_limit_ESI.Size = new System.Drawing.Size(123, 19);
            this.chk_activate_limit_ESI.TabIndex = 1;
            this.chk_activate_limit_ESI.Text = "Check to Activate ESI";
            this.chk_activate_limit_ESI.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max Gross Salary - ESI";
            // 
            // txtGross_ESI
            // 
            this.txtGross_ESI.BackColor = System.Drawing.Color.White;
            this.txtGross_ESI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGross_ESI.Location = new System.Drawing.Point(136, 132);
            this.txtGross_ESI.Name = "txtGross_ESI";
            this.txtGross_ESI.Size = new System.Drawing.Size(100, 20);
            this.txtGross_ESI.TabIndex = 85;
            this.txtGross_ESI.Text = "0";
            this.txtGross_ESI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkLocContribution
            // 
            this.chkLocContribution.AutoSize = true;
            this.chkLocContribution.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLocContribution.Location = new System.Drawing.Point(9, 164);
            this.chkLocContribution.Name = "chkLocContribution";
            this.chkLocContribution.Size = new System.Drawing.Size(233, 19);
            this.chkLocContribution.TabIndex = 1;
            this.chkLocContribution.Text = "Check to Activate Location wise Contribution";
            this.chkLocContribution.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(249, 225);
            this.Controls.Add(this.txtGross_ESI);
            this.Controls.Add(this.txtGross_PF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkLocContribution);
            this.Controls.Add(this.chk_activate_limit_ESI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk_activate_limit_PF);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_activate_limit_PF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtGross_PF;
        private System.Windows.Forms.CheckBox chk_activate_limit_ESI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGross_ESI;
        private System.Windows.Forms.CheckBox chkLocContribution;
    }
}