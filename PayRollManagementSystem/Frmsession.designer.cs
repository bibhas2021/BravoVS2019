namespace PayRollManagementSystem
{
    partial class Frmsession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmsession));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label63 = new System.Windows.Forms.Label();
            this.btncreate = new System.Windows.Forms.Button();
            this.txtSessionname = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.label58 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.White;
            this.groupBox6.Controls.Add(this.label63);
            this.groupBox6.Controls.Add(this.btncreate);
            this.groupBox6.Controls.Add(this.txtSessionname);
            this.groupBox6.Controls.Add(this.label57);
            this.groupBox6.Controls.Add(this.dtpto);
            this.groupBox6.Controls.Add(this.dtpfrom);
            this.groupBox6.Controls.Add(this.label58);
            this.groupBox6.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox6.Location = new System.Drawing.Point(11, 13);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(307, 183);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.BackColor = System.Drawing.Color.Transparent;
            this.label63.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label63.Location = new System.Drawing.Point(38, 33);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(75, 13);
            this.label63.TabIndex = 66;
            this.label63.Text = "Session Name";
            // 
            // btncreate
            // 
            this.btncreate.Location = new System.Drawing.Point(199, 138);
            this.btncreate.Margin = new System.Windows.Forms.Padding(2);
            this.btncreate.Name = "btncreate";
            this.btncreate.Size = new System.Drawing.Size(68, 25);
            this.btncreate.TabIndex = 6;
            this.btncreate.Text = "Create";
            this.btncreate.UseVisualStyleBackColor = true;
            this.btncreate.Click += new System.EventHandler(this.btncreate_Click);
            // 
            // txtSessionname
            // 
            this.txtSessionname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSessionname.Location = new System.Drawing.Point(147, 31);
            this.txtSessionname.MaxLength = 10;
            this.txtSessionname.Name = "txtSessionname";
            this.txtSessionname.Size = new System.Drawing.Size(120, 20);
            this.txtSessionname.TabIndex = 65;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(38, 102);
            this.label57.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(46, 13);
            this.label57.TabIndex = 0;
            this.label57.Text = "To Date";
            // 
            // dtpto
            // 
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(147, 98);
            this.dtpto.Margin = new System.Windows.Forms.Padding(2);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(120, 20);
            this.dtpto.TabIndex = 3;
            // 
            // dtpfrom
            // 
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrom.Location = new System.Drawing.Point(147, 66);
            this.dtpfrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(120, 20);
            this.dtpfrom.TabIndex = 4;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(38, 70);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(56, 13);
            this.label58.TabIndex = 1;
            this.label58.Text = "From Date";
            // 
            // Frmsession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 215);
            this.Controls.Add(this.groupBox6);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frmsession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Session";
            this.Load += new System.EventHandler(this.Frmsession_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Button btncreate;
        private System.Windows.Forms.TextBox txtSessionname;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.Label label58;
    }
}