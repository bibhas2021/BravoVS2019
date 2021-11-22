namespace Utility
{
    partial class FrmGlobalBackup
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
            this.rbfullbckup = new System.Windows.Forms.RadioButton();
            this.rbotherbckup = new System.Windows.Forms.RadioButton();
            this.button3 = new EDPComponent.VistaButton();
            this.btnclose = new EDPComponent.VistaButton();
            this.btnok = new EDPComponent.VistaButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbfullbckup);
            this.groupBox1.Controls.Add(this.rbotherbckup);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 45);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Backup";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbfullbckup
            // 
            this.rbfullbckup.AutoSize = true;
            this.rbfullbckup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbfullbckup.Location = new System.Drawing.Point(26, 19);
            this.rbfullbckup.Name = "rbfullbckup";
            this.rbfullbckup.Size = new System.Drawing.Size(78, 17);
            this.rbfullbckup.TabIndex = 0;
            this.rbfullbckup.TabStop = true;
            this.rbfullbckup.Text = "Full Backup";
            this.rbfullbckup.UseVisualStyleBackColor = true;
            this.rbfullbckup.CheckedChanged += new System.EventHandler(this.rbfullbckup_CheckedChanged);
            // 
            // rbotherbckup
            // 
            this.rbotherbckup.AutoSize = true;
            this.rbotherbckup.Enabled = false;
            this.rbotherbckup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbotherbckup.Location = new System.Drawing.Point(146, 19);
            this.rbotherbckup.Name = "rbotherbckup";
            this.rbotherbckup.Size = new System.Drawing.Size(58, 17);
            this.rbotherbckup.TabIndex = 1;
            this.rbotherbckup.TabStop = true;
            this.rbotherbckup.Text = "Others";
            this.rbotherbckup.UseVisualStyleBackColor = true;
            this.rbotherbckup.CheckedChanged += new System.EventHandler(this.rbotherbckup_CheckedChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.button3.ButtonText = "button3";
            this.button3.CornerRadius = 4;
            this.button3.GlowColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(12, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 30);
            this.button3.TabIndex = 15;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnclose.ButtonText = "    Close";
            this.btnclose.CornerRadius = 4;
            this.btnclose.GlowColor = System.Drawing.Color.White;
            this.btnclose.Image = global::Utility.Properties.Resources._2;
            this.btnclose.ImageSize = new System.Drawing.Size(18, 18);
            this.btnclose.Location = new System.Drawing.Point(184, 18);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 30);
            this.btnclose.TabIndex = 14;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnok
            // 
            this.btnok.AutoSize = true;
            this.btnok.BackColor = System.Drawing.Color.Transparent;
            this.btnok.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnok.ButtonText = "Ok";
            this.btnok.CornerRadius = 4;
            this.btnok.GlowColor = System.Drawing.Color.White;
            this.btnok.Image = global::Utility.Properties.Resources.DISK04;
            this.btnok.ImageSize = new System.Drawing.Size(18, 18);
            this.btnok.Location = new System.Drawing.Point(98, 18);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(80, 30);
            this.btnok.TabIndex = 13;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btnclose);
            this.groupBox2.Controls.Add(this.btnok);
            this.groupBox2.Location = new System.Drawing.Point(159, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 60);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // FrmGlobalBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGlobalBackup";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBackUp_KeyDown);
            this.Load += new System.EventHandler(this.frmRestrBack_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbfullbckup;
        private System.Windows.Forms.RadioButton rbotherbckup;
        private EDPComponent.VistaButton button3;
        private System.Windows.Forms.GroupBox groupBox2;
       
    }
}