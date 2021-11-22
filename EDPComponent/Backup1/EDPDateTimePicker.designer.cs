namespace EDPComponent
{
    partial class EDPDateTimePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_DateTime = new System.Windows.Forms.TextBox();
            this.btn_DateTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(86, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            // 
            // txt_DateTime
            // 
            this.txt_DateTime.BackColor = System.Drawing.Color.SeaShell;
            this.txt_DateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_DateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_DateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DateTime.ForeColor = System.Drawing.Color.Maroon;
            this.txt_DateTime.Location = new System.Drawing.Point(0, 0);
            this.txt_DateTime.Name = "txt_DateTime";
            this.txt_DateTime.Size = new System.Drawing.Size(90, 21);
            this.txt_DateTime.TabIndex = 0;
            this.txt_DateTime.TextChanged += new System.EventHandler(this.txt_DateTime_TextChanged);
            this.txt_DateTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DateTime_KeyDown);
            this.txt_DateTime.Leave += new System.EventHandler(this.txt_DateTime_Leave);
            this.txt_DateTime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_DateTime_MouseClick);
            this.txt_DateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DateTime_KeyPress);
            this.txt_DateTime.Enter += new System.EventHandler(this.txt_DateTime_Enter);
            // 
            // btn_DateTime
            // 
            this.btn_DateTime.Image = global::EDPComponent.Properties.Resources.GotoShortcutsHS;
            this.btn_DateTime.Location = new System.Drawing.Point(68, 1);
            this.btn_DateTime.Name = "btn_DateTime";
            this.btn_DateTime.Size = new System.Drawing.Size(20, 18);
            this.btn_DateTime.TabIndex = 7;
            this.btn_DateTime.Click += new System.EventHandler(this.btn_DateTime_Click);
            // 
            // EDPDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.Controls.Add(this.btn_DateTime);
            this.Controls.Add(this.txt_DateTime);
            this.Controls.Add(this.dateTimePicker1);
            this.DoubleBuffered = true;
            this.Name = "EDPDateTimePicker";
            this.Size = new System.Drawing.Size(90, 21);
            this.Resize += new System.EventHandler(this.EDPDateTimePicker_Resize);
            this.Enter += new System.EventHandler(this.EDPDateTimePicker_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_DateTime;
        private System.Windows.Forms.Label btn_DateTime;
    }
}
