namespace PayRollManagementSystem
{
    partial class PopUpDashBoard
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
            this.Loc_pop = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Loc_pop)).BeginInit();
            this.SuspendLayout();
            // 
            // Loc_pop
            // 
            this.Loc_pop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Loc_pop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Loc_pop.Location = new System.Drawing.Point(12, 12);
            this.Loc_pop.Name = "Loc_pop";
            this.Loc_pop.Size = new System.Drawing.Size(850, 280);
            this.Loc_pop.TabIndex = 0;
            this.Loc_pop.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Loc_pop_CellDoubleClick);
            this.Loc_pop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Loc_pop_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(744, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TOTAL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(807, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // PopUpDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(874, 315);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Loc_pop);
            this.Name = "PopUpDashBoard";
            this.Text = "PopUpDashBoard";
            this.Load += new System.EventHandler(this.PopUpDashBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Loc_pop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Loc_pop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}