namespace PayRollManagementSystem
{
    partial class frm_shift_link
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_shift_link));
            this.cmbLocation = new EDPComponent.ComboDialog();
            this.cmbShift = new EDPComponent.ComboDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbLocation
            // 
            this.cmbLocation.Connection = null;
            this.cmbLocation.DialogResult = "";
            this.cmbLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.Location = new System.Drawing.Point(111, 12);
            this.cmbLocation.LOVFlag = 0;
            this.cmbLocation.MaxCharLength = 500;
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.ReturnIndex = -1;
            this.cmbLocation.ReturnValue = "";
            this.cmbLocation.ReturnValue_3rd = "";
            this.cmbLocation.ReturnValue_4th = "";
            this.cmbLocation.Size = new System.Drawing.Size(286, 21);
            this.cmbLocation.TabIndex = 295;
            // 
            // cmbShift
            // 
            this.cmbShift.Connection = null;
            this.cmbShift.DialogResult = "";
            this.cmbShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.Location = new System.Drawing.Point(111, 35);
            this.cmbShift.LOVFlag = 0;
            this.cmbShift.MaxCharLength = 500;
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.ReturnIndex = -1;
            this.cmbShift.ReturnValue = "";
            this.cmbShift.ReturnValue_3rd = "";
            this.cmbShift.ReturnValue_4th = "";
            this.cmbShift.Size = new System.Drawing.Size(286, 21);
            this.cmbShift.TabIndex = 294;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 297;
            this.label2.Text = "Loction Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 296;
            this.label11.Text = "Shift Name";
            // 
            // frm_shift_link
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(801, 348);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_shift_link";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Link Shift with Location";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EDPComponent.ComboDialog cmbLocation;
        private EDPComponent.ComboDialog cmbShift;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
    }
}