namespace EDPComponent
{
    partial class Preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.button1 = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.vistaButton2 = new EDPComponent.VistaButton();
            this.vistaButton1 = new EDPComponent.VistaButton();
            this.myXPButton1 = new EDPComponent.MyXPButton();
            this.progressBar1 = new EDPComponent.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new EDPComponent.ComboColumn();
            this.comboDialog2 = new EDPComponent.ComboDialog();
            this.comboDialog1 = new EDPComponent.ComboDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(278, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(420, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(230, 335);
            this.propertyGrid1.TabIndex = 27;
            // 
            // vistaButton2
            // 
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.vistaButton2.ButtonText = "Insert";
            this.vistaButton2.CornerRadius = 4;
            this.vistaButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton2.GlowColor = System.Drawing.Color.LightSkyBlue;
            this.vistaButton2.Image = ((System.Drawing.Image)(resources.GetObject("vistaButton2.Image")));
            this.vistaButton2.ImageSize = new System.Drawing.Size(16, 16);
            this.vistaButton2.Location = new System.Drawing.Point(62, 289);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(101, 27);
            this.vistaButton2.TabIndex = 26;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.BaseColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonText = "Vista Button";
            this.vistaButton1.ForeColor = System.Drawing.Color.Red;
            this.vistaButton1.GlowColor = System.Drawing.Color.Teal;
            this.vistaButton1.Image = ((System.Drawing.Image)(resources.GetObject("vistaButton1.Image")));
            this.vistaButton1.Location = new System.Drawing.Point(169, 282);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(126, 34);
            this.vistaButton1.TabIndex = 6;
            this.vistaButton1.Click += new System.EventHandler(this.vistaButton1_Click);
            // 
            // myXPButton1
            // 
            this.myXPButton1.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.myXPButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("myXPButton1.BackgroundImage")));
            this.myXPButton1.BtnShape = EDPComponent.emunType.BtnShape.Rectangle;
            this.myXPButton1.BtnStyle = EDPComponent.emunType.XPStyle.Default;
            this.myXPButton1.Location = new System.Drawing.Point(312, 289);
            this.myXPButton1.Name = "myXPButton1";
            this.myXPButton1.Size = new System.Drawing.Size(86, 27);
            this.myXPButton1.TabIndex = 5;
            this.myXPButton1.Text = "myXPButton1";
            this.myXPButton1.UseVisualStyleBackColor = true;
            this.myXPButton1.Click += new System.EventHandler(this.myXPButton1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.ForeColor = System.Drawing.Color.Gray;
            this.progressBar1.Location = new System.Drawing.Point(0, 344);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ShowPercentage = false;
            this.progressBar1.Size = new System.Drawing.Size(650, 13);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.TextAllign = System.Windows.Forms.HorizontalAlignment.Left;
            this.progressBar1.Value = 100;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(341, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DialogResult = "";
            this.Column1.HeaderText = "Column1";
            this.Column1.LookUpTable = null;
            this.Column1.LOVFlag = 0;
            this.Column1.Name = "Column1";
            this.Column1.ReturnValue = "";
            // 
            // comboDialog2
            // 
            this.comboDialog2.CommandString = null;
            this.comboDialog2.Connection = null;
            this.comboDialog2.DialogResult = null;
            this.comboDialog2.Heading = "ii3";
            this.comboDialog2.Location = new System.Drawing.Point(12, 51);
            this.comboDialog2.LOVFlag = 0;
            this.comboDialog2.Name = "comboDialog2";
            this.comboDialog2.OpeningDialog = this;
            this.comboDialog2.ReturnIndex = 1;
            this.comboDialog2.ReturnValue = null;
            this.comboDialog2.Size = new System.Drawing.Size(206, 21);
            this.comboDialog2.SubHeading = "afassas111";
            this.comboDialog2.TabIndex = 1;
            this.comboDialog2.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.comboDialog2_DropDown);
            // 
            // comboDialog1
            // 
            this.comboDialog1.BackColor = System.Drawing.SystemColors.Control;
            this.comboDialog1.CommandString = null;
            this.comboDialog1.Connection = null;
            this.comboDialog1.DialogResult = null;
            this.comboDialog1.Heading = "ii3";
            this.comboDialog1.Location = new System.Drawing.Point(12, 3);
            this.comboDialog1.LOVFlag = 0;
            this.comboDialog1.Name = "comboDialog1";
            this.comboDialog1.OpeningDialog = this;
            this.comboDialog1.ReadOnly = true;
            this.comboDialog1.ReturnIndex = 1;
            this.comboDialog1.ReturnValue = null;
            this.comboDialog1.SelectSingleItem = true;
            this.comboDialog1.Size = new System.Drawing.Size(206, 21);
            this.comboDialog1.SubHeading = "fff";
            this.comboDialog1.TabIndex = 0;
            this.comboDialog1.Click += new System.EventHandler(this.comboDialog1_Click);
            this.comboDialog1.DropDown += new EDPComponent.ComboDialog.DropDownHandler(this.comboDialog1_DropDown);
            this.comboDialog1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboDialog1_KeyDown);
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 357);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.vistaButton2);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.myXPButton1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboDialog2);
            this.Controls.Add(this.comboDialog1);
            this.Name = "Preview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Preview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboDialog comboDialog1;
        private ComboDialog comboDialog2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ComboColumn Column1;
        private System.Windows.Forms.Button button1;
        private ProgressBar progressBar1;
        private MyXPButton myXPButton1;
        private VistaButton vistaButton1;
        private VistaButton vistaButton2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;





    }
}