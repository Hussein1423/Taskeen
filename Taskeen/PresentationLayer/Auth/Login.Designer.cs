namespace PresentationLayer
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gtxtbUser = new Guna.UI.WinForms.GunaTextBox();
            this.gtxtbPassword = new Guna.UI.WinForms.GunaTextBox();
            this.chkbRemember = new System.Windows.Forms.CheckBox();
            this.gbtnLogin = new Guna.UI.WinForms.GunaButton();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(-6, 4);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(531, 482);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(664, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 81);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lbl.Location = new System.Drawing.Point(581, 136);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(135, 19);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Username / Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(585, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // gtxtbUser
            // 
            this.gtxtbUser.BaseColor = System.Drawing.Color.White;
            this.gtxtbUser.BorderColor = System.Drawing.Color.Silver;
            this.gtxtbUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gtxtbUser.FocusedBaseColor = System.Drawing.Color.White;
            this.gtxtbUser.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gtxtbUser.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gtxtbUser.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtxtbUser.Location = new System.Drawing.Point(585, 176);
            this.gtxtbUser.Name = "gtxtbUser";
            this.gtxtbUser.PasswordChar = '\0';
            this.gtxtbUser.SelectedText = "";
            this.gtxtbUser.Size = new System.Drawing.Size(312, 34);
            this.gtxtbUser.TabIndex = 4;
            this.gtxtbUser.Validated += new System.EventHandler(this.gtxtbUser_Validated);
            // 
            // gtxtbPassword
            // 
            this.gtxtbPassword.BaseColor = System.Drawing.Color.White;
            this.gtxtbPassword.BorderColor = System.Drawing.Color.Silver;
            this.gtxtbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gtxtbPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.gtxtbPassword.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gtxtbPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.gtxtbPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gtxtbPassword.Location = new System.Drawing.Point(589, 277);
            this.gtxtbPassword.Name = "gtxtbPassword";
            this.gtxtbPassword.PasswordChar = '●';
            this.gtxtbPassword.SelectedText = "";
            this.gtxtbPassword.Size = new System.Drawing.Size(312, 34);
            this.gtxtbPassword.TabIndex = 5;
            this.gtxtbPassword.UseSystemPasswordChar = true;
            this.gtxtbPassword.Validated += new System.EventHandler(this.gtxtbPassword_Validated);
            // 
            // chkbRemember
            // 
            this.chkbRemember.AutoSize = true;
            this.chkbRemember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.chkbRemember.Location = new System.Drawing.Point(589, 338);
            this.chkbRemember.Name = "chkbRemember";
            this.chkbRemember.Size = new System.Drawing.Size(137, 23);
            this.chkbRemember.TabIndex = 6;
            this.chkbRemember.Text = "Remember Me";
            this.chkbRemember.UseVisualStyleBackColor = true;
            // 
            // gbtnLogin
            // 
            this.gbtnLogin.AnimationHoverSpeed = 0.07F;
            this.gbtnLogin.AnimationSpeed = 0.03F;
            this.gbtnLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.gbtnLogin.BorderColor = System.Drawing.Color.Black;
            this.gbtnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gbtnLogin.Enabled = false;
            this.gbtnLogin.FocusedColor = System.Drawing.Color.Empty;
            this.gbtnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbtnLogin.ForeColor = System.Drawing.Color.White;
            this.gbtnLogin.Image = null;
            this.gbtnLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.gbtnLogin.Location = new System.Drawing.Point(679, 398);
            this.gbtnLogin.Name = "gbtnLogin";
            this.gbtnLogin.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.gbtnLogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gbtnLogin.OnHoverForeColor = System.Drawing.Color.White;
            this.gbtnLogin.OnHoverImage = null;
            this.gbtnLogin.OnPressedColor = System.Drawing.Color.Black;
            this.gbtnLogin.Size = new System.Drawing.Size(160, 42);
            this.gbtnLogin.TabIndex = 7;
            this.gbtnLogin.Text = "Login";
            this.gbtnLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gbtnLogin.Click += new System.EventHandler(this.gbtnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1008, 482);
            this.Controls.Add(this.gbtnLogin);
            this.Controls.Add(this.chkbRemember);
            this.Controls.Add(this.gtxtbPassword);
            this.Controls.Add(this.gtxtbUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gunaPictureBox1);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaTextBox gtxtbUser;
        private Guna.UI.WinForms.GunaTextBox gtxtbPassword;
        private System.Windows.Forms.CheckBox chkbRemember;
        private Guna.UI.WinForms.GunaButton gbtnLogin;
    }
}

