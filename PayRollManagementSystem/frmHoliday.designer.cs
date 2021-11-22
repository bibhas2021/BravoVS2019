namespace PayRollManagementSystem
{
    partial class frmHoliday
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
            this.LblSession = new System.Windows.Forms.Label();
            this.BtnHolidayList = new System.Windows.Forms.Button();
            this.AttenDtTmPkr = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Holiday List";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(371, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExpExc
            // 
            this.btnExpExc.Location = new System.Drawing.Point(40, 16);
            this.btnExpExc.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(160, 16);
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrnt
            // 
            this.btnPrnt.Location = new System.Drawing.Point(248, 16);
            this.btnPrnt.Click += new System.EventHandler(this.btnPrnt_Click);
            // 
            // btnClose2
            // 
            this.btnClose2.Location = new System.Drawing.Point(332, 16);
            this.btnClose2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LblSession
            // 
            this.LblSession.AutoSize = true;
            this.LblSession.Location = new System.Drawing.Point(107, 109);
            this.LblSession.Name = "LblSession";
            this.LblSession.Size = new System.Drawing.Size(62, 13);
            this.LblSession.TabIndex = 0;
            this.LblSession.Text = "Select Year";
            // 
            // BtnHolidayList
            // 
            this.BtnHolidayList.Location = new System.Drawing.Point(221, 170);
            this.BtnHolidayList.Name = "BtnHolidayList";
            this.BtnHolidayList.Size = new System.Drawing.Size(75, 23);
            this.BtnHolidayList.TabIndex = 7;
            this.BtnHolidayList.Text = "Holiday List";
            this.BtnHolidayList.UseVisualStyleBackColor = true;
            // 
            // AttenDtTmPkr
            // 
            this.AttenDtTmPkr.Checked = false;
            this.AttenDtTmPkr.CustomFormat = "yyyy";
            this.AttenDtTmPkr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AttenDtTmPkr.Location = new System.Drawing.Point(175, 107);
            this.AttenDtTmPkr.Name = "AttenDtTmPkr";
            this.AttenDtTmPkr.Size = new System.Drawing.Size(93, 20);
            this.AttenDtTmPkr.TabIndex = 265;
            this.AttenDtTmPkr.ValueChanged += new System.EventHandler(this.AttenDtTmPkr_ValueChanged);
            // 
            // frmHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 273);
            this.Controls.Add(this.BtnHolidayList);
            this.Controls.Add(this.AttenDtTmPkr);
            this.Controls.Add(this.LblSession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHoliday";
            this.Load += new System.EventHandler(this.frmHoliday_Load);
            this.Controls.SetChildIndex(this.LblSession, 0);
            this.Controls.SetChildIndex(this.AttenDtTmPkr, 0);
            this.Controls.SetChildIndex(this.BtnHolidayList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSession;
        private System.Windows.Forms.Button BtnHolidayList;
        private System.Windows.Forms.DateTimePicker AttenDtTmPkr;
    }
}