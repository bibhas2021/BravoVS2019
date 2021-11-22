namespace PayRollManagementSystem
{
    partial class EmpExp
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
            this.empEr = new System.Windows.Forms.DataGridView();
            this.lable1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.empEr)).BeginInit();
            this.SuspendLayout();
            // 
            // empEr
            // 
            this.empEr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.empEr.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.empEr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empEr.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.empEr.Location = new System.Drawing.Point(12, 1);
            this.empEr.Name = "empEr";
            this.empEr.Size = new System.Drawing.Size(952, 305);
            this.empEr.TabIndex = 0;
            this.empEr.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.empEr_CellContentClick);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lable1.Location = new System.Drawing.Point(853, 309);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(42, 13);
            this.lable1.TabIndex = 1;
            this.lable1.Text = "TOTAL";
            this.lable1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(911, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // EmpExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(972, 322);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.empEr);
            this.Name = "EmpExp";
            this.Text = "EmpExp";
            ((System.ComponentModel.ISupportInitialize)(this.empEr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView empEr;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Label label2;
    }
}