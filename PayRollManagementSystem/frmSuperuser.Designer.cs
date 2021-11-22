namespace PayRollManagementSystem
{
    partial class frmSuperuser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuperuser));
            this.lblConfirmation = new System.Windows.Forms.Label();
            this.gbxConfirm = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConpass = new System.Windows.Forms.TextBox();
            this.btnAccept = new EDPComponent.VistaButton();
            this.lblConpass = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblSession = new System.Windows.Forms.Label();
            this.rdbAgre = new System.Windows.Forms.RadioButton();
            this.rdbDonot = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnNext = new EDPComponent.VistaButton();
            this.btnExit = new EDPComponent.VistaButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PB = new System.Windows.Forms.ProgressBar();
            this.gbxConfirm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConfirmation
            // 
            this.lblConfirmation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmation.Location = new System.Drawing.Point(3, 33);
            this.lblConfirmation.Name = "lblConfirmation";
            this.lblConfirmation.Size = new System.Drawing.Size(395, 197);
            this.lblConfirmation.TabIndex = 0;
            this.lblConfirmation.Text = resources.GetString("lblConfirmation.Text");
            // 
            // gbxConfirm
            // 
            this.gbxConfirm.BackColor = System.Drawing.Color.Transparent;
            this.gbxConfirm.Controls.Add(this.PB);
            this.gbxConfirm.Controls.Add(this.label1);
            this.gbxConfirm.Controls.Add(this.txtConpass);
            this.gbxConfirm.Controls.Add(this.btnAccept);
            this.gbxConfirm.Controls.Add(this.lblConpass);
            this.gbxConfirm.Controls.Add(this.lblPass);
            this.gbxConfirm.Controls.Add(this.lblUser);
            this.gbxConfirm.Controls.Add(this.txtPass);
            this.gbxConfirm.Controls.Add(this.txtUser);
            this.gbxConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxConfirm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxConfirm.ForeColor = System.Drawing.Color.Black;
            this.gbxConfirm.Location = new System.Drawing.Point(6, 10);
            this.gbxConfirm.Name = "gbxConfirm";
            this.gbxConfirm.Size = new System.Drawing.Size(391, 146);
            this.gbxConfirm.TabIndex = 10;
            this.gbxConfirm.TabStop = false;
            this.gbxConfirm.Text = "Enter the Super user name and password:-";
            this.gbxConfirm.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Please Wait ..";
            // 
            // txtConpass
            // 
            this.txtConpass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConpass.Location = new System.Drawing.Point(114, 63);
            this.txtConpass.Name = "txtConpass";
            this.txtConpass.PasswordChar = '*';
            this.txtConpass.Size = new System.Drawing.Size(184, 21);
            this.txtConpass.TabIndex = 12;
            this.toolTip1.SetToolTip(this.txtConpass, "Please Retype Password");
            this.txtConpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConpass_KeyDown);
            this.txtConpass.Leave += new System.EventHandler(this.txtConpass_Leave);
            this.txtConpass.Enter += new System.EventHandler(this.txtConpass_Enter);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Transparent;
            this.btnAccept.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnAccept.ButtonText = "     Accept";
            this.btnAccept.CornerRadius = 4;
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.GlowColor = System.Drawing.Color.White;
            //this.btnAccept.Image = global::PayRollManagementSystem.Properties.Resources.saveall;
            this.btnAccept.ImageSize = new System.Drawing.Size(16, 16);
            this.btnAccept.Location = new System.Drawing.Point(304, 52);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(80, 30);
            this.btnAccept.TabIndex = 60;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblConpass
            // 
            this.lblConpass.AutoSize = true;
            this.lblConpass.BackColor = System.Drawing.Color.Transparent;
            this.lblConpass.ForeColor = System.Drawing.Color.Black;
            this.lblConpass.Location = new System.Drawing.Point(14, 66);
            this.lblConpass.Name = "lblConpass";
            this.lblConpass.Size = new System.Drawing.Size(97, 13);
            this.lblConpass.TabIndex = 16;
            this.lblConpass.Text = "Confirm Password:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.BackColor = System.Drawing.Color.Transparent;
            this.lblPass.ForeColor = System.Drawing.Color.Black;
            this.lblPass.Location = new System.Drawing.Point(14, 42);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(57, 13);
            this.lblPass.TabIndex = 15;
            this.lblPass.Text = "Password:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(14, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(63, 13);
            this.lblUser.TabIndex = 14;
            this.lblUser.Text = "User Name:";
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Location = new System.Drawing.Point(114, 40);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(184, 21);
            this.txtPass.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtPass, "Please Type Password");
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Location = new System.Drawing.Point(114, 15);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(184, 21);
            this.txtUser.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtUser, "Please Type User Name");
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            // 
            // lblSession
            // 
            this.lblSession.Location = new System.Drawing.Point(166, 13);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(67, 20);
            this.lblSession.TabIndex = 11;
            this.lblSession.Text = "Session:";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbAgre
            // 
            this.rdbAgre.AutoSize = true;
            this.rdbAgre.BackColor = System.Drawing.Color.Transparent;
            this.rdbAgre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbAgre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAgre.Location = new System.Drawing.Point(28, 251);
            this.rdbAgre.Name = "rdbAgre";
            this.rdbAgre.Size = new System.Drawing.Size(64, 17);
            this.rdbAgre.TabIndex = 14;
            this.rdbAgre.TabStop = true;
            this.rdbAgre.Text = "I Agree.";
            this.toolTip1.SetToolTip(this.rdbAgre, "Confirmation");
            this.rdbAgre.UseVisualStyleBackColor = false;
            this.rdbAgre.CheckedChanged += new System.EventHandler(this.rdbAgre_CheckedChanged);
            // 
            // rdbDonot
            // 
            this.rdbDonot.AutoSize = true;
            this.rdbDonot.BackColor = System.Drawing.Color.Transparent;
            this.rdbDonot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rdbDonot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDonot.Location = new System.Drawing.Point(28, 268);
            this.rdbDonot.Name = "rdbDonot";
            this.rdbDonot.Size = new System.Drawing.Size(99, 17);
            this.rdbDonot.TabIndex = 15;
            this.rdbDonot.TabStop = true;
            this.rdbDonot.Text = "I Do not Agree.";
            this.toolTip1.SetToolTip(this.rdbDonot, "Confirmation");
            this.rdbDonot.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Snow;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 322);
            this.label3.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Snow;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(3, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(439, 3);
            this.label4.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Snow;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(439, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(3, 319);
            this.label5.TabIndex = 20;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnNext.ButtonText = "    Next";
            this.btnNext.CornerRadius = 4;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.GlowColor = System.Drawing.Color.White;
            //this.btnNext.Image = global::PayRollManagementSystem.Properties.Resources.right;
            this.btnNext.ImageSize = new System.Drawing.Size(16, 16);
            this.btnNext.Location = new System.Drawing.Point(243, 256);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 30);
            this.btnNext.TabIndex = 59;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ButtonColor = System.Drawing.Color.CornflowerBlue;
            this.btnExit.ButtonText = "     Close";
            this.btnExit.CornerRadius = 4;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.GlowColor = System.Drawing.Color.White;
            //this.btnExit.Image = global::PayRollManagementSystem.Properties.Resources.W95MBX01;
            this.btnExit.ImageSize = new System.Drawing.Size(16, 16);
            this.btnExit.Location = new System.Drawing.Point(329, 255);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 58;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.rdbAgre);
            this.groupBox1.Controls.Add(this.rdbDonot);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Location = new System.Drawing.Point(12, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 296);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbxConfirm);
            this.groupBox2.Controls.Add(this.lblSession);
            this.groupBox2.Controls.Add(this.lblConfirmation);
            this.groupBox2.Location = new System.Drawing.Point(6, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 241);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // PB
            // 
            this.PB.Location = new System.Drawing.Point(34, 117);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(318, 23);
            this.PB.TabIndex = 64;
            this.PB.Visible = false;
            // 
            // frmSuperuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(442, 322);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.HeaderText = "Session : 0             User :              Branch Name :  ()";
            this.Name = "frmSuperuser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accord Four Super User Creation Wizard";
            this.Load += new System.EventHandler(this.frmSuperuser_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSuperuser_FormClosing);
            this.Resize += new System.EventHandler(this.frmSuperuser_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSuperuser_KeyDown);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbxConfirm.ResumeLayout(false);
            this.gbxConfirm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConfirmation;
        private System.Windows.Forms.GroupBox gbxConfirm;
        private System.Windows.Forms.Label lblConpass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtConpass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.RadioButton rdbAgre;
        private System.Windows.Forms.RadioButton rdbDonot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private EDPComponent.VistaButton btnNext;
        private EDPComponent.VistaButton btnExit;
        private EDPComponent.VistaButton btnAccept;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar PB;
    }
}