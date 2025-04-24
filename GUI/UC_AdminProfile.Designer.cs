namespace GD
{
    partial class UC_AdminProfile
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
        private void InitializeComponent()
        {
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbAdminInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdateProfile.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProfile.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateProfile.Location = new System.Drawing.Point(498, 389);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(142, 50);
            this.btnUpdateProfile.TabIndex = 52;
            this.btnUpdateProfile.Text = "Sửa hồ sơ";
            this.btnUpdateProfile.UseVisualStyleBackColor = false;
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSignOut.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.ForeColor = System.Drawing.Color.Black;
            this.btnSignOut.Location = new System.Drawing.Point(907, 660);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(142, 50);
            this.btnSignOut.TabIndex = 51;
            this.btnSignOut.Text = "Đăng xuất";
            this.btnSignOut.UseVisualStyleBackColor = false;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.DarkOrange;
            this.btnResetPassword.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.ForeColor = System.Drawing.Color.Black;
            this.btnResetPassword.Location = new System.Drawing.Point(742, 660);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(142, 50);
            this.btnResetPassword.TabIndex = 50;
            this.btnResetPassword.Text = "Đổi mật khẩu";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(498, 336);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(259, 22);
            this.textBox3.TabIndex = 48;
            // 
            // lbPhone
            // 
            this.lbPhone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.Black;
            this.lbPhone.Location = new System.Drawing.Point(317, 333);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(175, 28);
            this.lbPhone.TabIndex = 49;
            this.lbPhone.Text = "Số điện thoại";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(498, 279);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(259, 22);
            this.textBox4.TabIndex = 46;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(498, 226);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(259, 22);
            this.textBox5.TabIndex = 44;
            // 
            // lbEmail
            // 
            this.lbEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.Color.Black;
            this.lbEmail.Location = new System.Drawing.Point(317, 276);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(175, 28);
            this.lbEmail.TabIndex = 47;
            this.lbEmail.Text = "Email";
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.Black;
            this.lbName.Location = new System.Drawing.Point(317, 223);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(175, 28);
            this.lbName.TabIndex = 45;
            this.lbName.Text = "Tên tài khoản";
            // 
            // lbAdminInfo
            // 
            this.lbAdminInfo.BackColor = System.Drawing.Color.Bisque;
            this.lbAdminInfo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdminInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbAdminInfo.Location = new System.Drawing.Point(456, 147);
            this.lbAdminInfo.Name = "lbAdminInfo";
            this.lbAdminInfo.Size = new System.Drawing.Size(249, 42);
            this.lbAdminInfo.TabIndex = 43;
            this.lbAdminInfo.Text = "Quản trị viên";
            // 
            // UC_AdminProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.btnUpdateProfile);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbAdminInfo);
            this.Name = "UC_AdminProfile";
            this.Size = new System.Drawing.Size(1139, 754);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbAdminInfo;
    }
}
