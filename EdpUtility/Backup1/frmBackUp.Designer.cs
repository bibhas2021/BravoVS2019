namespace Utility
{
    partial class frmBackUp
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
        /// the contents of   method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rbfullbckup = new System.Windows.Forms.RadioButton();
            this.rbotherbckup = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnclose = new EDPComponent.VistaButton();
            this.btnok = new EDPComponent.VistaButton();
            this.button3 = new EDPComponent.VistaButton();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbfullbckup
            // 
            this.rbfullbckup.AutoSize = true;
            this.rbfullbckup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbfullbckup.Location = new System.Drawing.Point(6, 16);
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
            this.rbotherbckup.Location = new System.Drawing.Point(380, 19);
            this.rbotherbckup.Name = "rbotherbckup";
            this.rbotherbckup.Size = new System.Drawing.Size(58, 17);
            this.rbotherbckup.TabIndex = 1;
            this.rbotherbckup.TabStop = true;
            this.rbotherbckup.Text = "Others";
            this.rbotherbckup.UseVisualStyleBackColor = true;
            this.rbotherbckup.CheckedChanged += new System.EventHandler(this.rbotherbckup_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbfullbckup);
            this.groupBox1.Controls.Add(this.rbotherbckup);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(9, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 45);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Backup";
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.btnclose.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnclose.ButtonText = "    Close";
            this.btnclose.CornerRadius = 4;
            this.btnclose.GlowColor = System.Drawing.Color.White;
            this.btnclose.Image = global::Utility.Properties.Resources.W95MBX01;
            this.btnclose.ImageSize = new System.Drawing.Size(18, 18);
            this.btnclose.Location = new System.Drawing.Point(394, 360);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(80, 30);
            this.btnclose.TabIndex = 7;
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
            this.btnok.Location = new System.Drawing.Point(311, 360);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(80, 30);
            this.btnok.TabIndex = 6;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.button3.ButtonText = "button3";
            this.button3.CornerRadius = 4;
            this.button3.GlowColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(226, 360);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 32);
            this.button3.TabIndex = 12;
            // 
            // frmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 404);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBackUp";
            this.ShowIcon = false;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBackUp_KeyDown);
            this.Load += new System.EventHandler(this.frmRestrBack_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbotherbckup;
        private System.Windows.Forms.RadioButton rbfullbckup;
        private System.Windows.Forms.GroupBox groupBox1;
        private EDPComponent.VistaButton button3;
        private System.Windows.Forms.Timer tmr;
        
        
        //public System.Windows.Forms.Button btnok;
        //public System.Windows.Forms.Button btnclose;

    }
}

