namespace PayRollManagementSystem
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeJoiningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryStructureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryHeadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.employeeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(678, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "FIle";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeJoiningToolStripMenuItem,
            this.salaryStructureToolStripMenuItem,
            this.salaryHeadToolStripMenuItem});
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // employeeJoiningToolStripMenuItem
            // 
            this.employeeJoiningToolStripMenuItem.Name = "employeeJoiningToolStripMenuItem";
            this.employeeJoiningToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.employeeJoiningToolStripMenuItem.Text = "Employee Joining";
            this.employeeJoiningToolStripMenuItem.Click += new System.EventHandler(this.employeeJoiningToolStripMenuItem_Click);
            // 
            // salaryStructureToolStripMenuItem
            // 
            this.salaryStructureToolStripMenuItem.Name = "salaryStructureToolStripMenuItem";
            this.salaryStructureToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.salaryStructureToolStripMenuItem.Text = "Salary Structure";
            this.salaryStructureToolStripMenuItem.Click += new System.EventHandler(this.salaryStructureToolStripMenuItem_Click);
            // 
            // salaryHeadToolStripMenuItem
            // 
            this.salaryHeadToolStripMenuItem.Name = "salaryHeadToolStripMenuItem";
            this.salaryHeadToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.salaryHeadToolStripMenuItem.Text = "Salary Head";
            this.salaryHeadToolStripMenuItem.Click += new System.EventHandler(this.salaryHeadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 409);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PayRoll Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeJoiningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryStructureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryHeadToolStripMenuItem;

    }
}

