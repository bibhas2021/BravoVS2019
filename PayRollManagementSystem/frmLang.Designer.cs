namespace PayRollManagementSystem
{
    partial class frmLang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLang));
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLang1 = new System.Windows.Forms.TextBox();
            this.txtLang2 = new System.Windows.Forms.TextBox();
            this.txtLang3 = new System.Windows.Forms.TextBox();
            this.txtLang4 = new System.Windows.Forms.TextBox();
            this.txtLang5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(0, 163);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(244, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 23);
            this.label1.TabIndex = 91;
            this.label1.Text = "Languages";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLang1
            // 
            this.txtLang1.BackColor = System.Drawing.Color.White;
            this.txtLang1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLang1.Location = new System.Drawing.Point(10, 31);
            this.txtLang1.Name = "txtLang1";
            this.txtLang1.Size = new System.Drawing.Size(222, 20);
            this.txtLang1.TabIndex = 0;
            // 
            // txtLang2
            // 
            this.txtLang2.BackColor = System.Drawing.Color.White;
            this.txtLang2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLang2.Location = new System.Drawing.Point(10, 57);
            this.txtLang2.Name = "txtLang2";
            this.txtLang2.Size = new System.Drawing.Size(222, 20);
            this.txtLang2.TabIndex = 1;
            // 
            // txtLang3
            // 
            this.txtLang3.BackColor = System.Drawing.Color.White;
            this.txtLang3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLang3.Location = new System.Drawing.Point(10, 83);
            this.txtLang3.Name = "txtLang3";
            this.txtLang3.Size = new System.Drawing.Size(222, 20);
            this.txtLang3.TabIndex = 2;
            // 
            // txtLang4
            // 
            this.txtLang4.BackColor = System.Drawing.Color.White;
            this.txtLang4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLang4.Location = new System.Drawing.Point(10, 109);
            this.txtLang4.Name = "txtLang4";
            this.txtLang4.Size = new System.Drawing.Size(222, 20);
            this.txtLang4.TabIndex = 3;
            // 
            // txtLang5
            // 
            this.txtLang5.BackColor = System.Drawing.Color.White;
            this.txtLang5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLang5.Location = new System.Drawing.Point(10, 135);
            this.txtLang5.Name = "txtLang5";
            this.txtLang5.Size = new System.Drawing.Size(222, 20);
            this.txtLang5.TabIndex = 4;
            // 
            // frmLang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(244, 188);
            this.Controls.Add(this.txtLang5);
            this.Controls.Add(this.txtLang4);
            this.Controls.Add(this.txtLang3);
            this.Controls.Add(this.txtLang2);
            this.Controls.Add(this.txtLang1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Language Master";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLang1;
        private System.Windows.Forms.TextBox txtLang2;
        private System.Windows.Forms.TextBox txtLang3;
        private System.Windows.Forms.TextBox txtLang4;
        private System.Windows.Forms.TextBox txtLang5;
    }
}