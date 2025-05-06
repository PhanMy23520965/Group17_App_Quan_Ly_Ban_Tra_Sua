namespace TraSuaApp
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.lbAdminInfo = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.Location = new System.Drawing.Point(467, 428);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(142, 40);
            this.btnUpdate.TabIndex = 52;
            this.btnUpdate.Text = "Sửa hồ sơ";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSignOut.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.ForeColor = System.Drawing.Color.Black;
            this.btnSignOut.Location = new System.Drawing.Point(906, 626);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(142, 40);
            this.btnSignOut.TabIndex = 51;
            this.btnSignOut.Text = "Đăng xuất";
            this.btnSignOut.UseVisualStyleBackColor = false;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.DarkOrange;
            this.btnResetPassword.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.ForeColor = System.Drawing.Color.Black;
            this.btnResetPassword.Location = new System.Drawing.Point(741, 626);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(142, 40);
            this.btnResetPassword.TabIndex = 50;
            this.btnResetPassword.Text = "Đổi mật khẩu";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            // 
            // lbAdminInfo
            // 
            this.lbAdminInfo.BackColor = System.Drawing.Color.Bisque;
            this.lbAdminInfo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdminInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbAdminInfo.Location = new System.Drawing.Point(441, 189);
            this.lbAdminInfo.Name = "lbAdminInfo";
            this.lbAdminInfo.Size = new System.Drawing.Size(249, 42);
            this.lbAdminInfo.TabIndex = 43;
            this.lbAdminInfo.Text = "Quản trị viên";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(467, 361);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(287, 22);
            this.tbEmail.TabIndex = 57;
            // 
            // lbEmail
            // 
            this.lbEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.Color.Black;
            this.lbEmail.Location = new System.Drawing.Point(314, 358);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(147, 28);
            this.lbEmail.TabIndex = 58;
            this.lbEmail.Text = "Email";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(467, 308);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(287, 22);
            this.tbPhone.TabIndex = 55;
            // 
            // lbPhone
            // 
            this.lbPhone.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.ForeColor = System.Drawing.Color.Black;
            this.lbPhone.Location = new System.Drawing.Point(314, 305);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(147, 28);
            this.lbPhone.TabIndex = 56;
            this.lbPhone.Text = "Số điện thoại";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(467, 255);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(287, 22);
            this.tbName.TabIndex = 53;
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.Black;
            this.lbName.Location = new System.Drawing.Point(314, 252);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(147, 28);
            this.lbName.TabIndex = 54;
            this.lbName.Text = "Họ tên";
            // 
            // UC_AdminProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.lbAdminInfo);
            this.Name = "UC_AdminProfile";
            this.Size = new System.Drawing.Size(1139, 723);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Label lbAdminInfo;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
    }
}
