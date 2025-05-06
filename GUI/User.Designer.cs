using System.Windows.Forms;
using System.Drawing;

namespace TraSuaApp
{
    partial class User
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnNavigation = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnLienHe = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.BackColor = System.Drawing.Color.Bisque;
            this.gbMain.Location = new System.Drawing.Point(221, -9);
            this.gbMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbMain.Name = "gbMain";
            this.gbMain.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbMain.Size = new System.Drawing.Size(0, 0);
            this.gbMain.TabIndex = 1;
            this.gbMain.TabStop = false;
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.Bisque;
            this.pnMain.Location = new System.Drawing.Point(244, 1);
            this.pnMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1139, 754);
            this.pnMain.TabIndex = 2;
            // 
            // pnNavigation
            // 
            this.pnNavigation.BackColor = System.Drawing.Color.DarkOrange;
            this.pnNavigation.Controls.Add(this.label1);
            this.pnNavigation.Controls.Add(this.btnTaiKhoan);
            this.pnNavigation.Controls.Add(this.btnHome);
            this.pnNavigation.Controls.Add(this.btnLienHe);
            this.pnNavigation.Controls.Add(this.btnMenu);
            this.pnNavigation.Controls.Add(this.btnDonHang);
            this.pnNavigation.Location = new System.Drawing.Point(-1, 1);
            this.pnNavigation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnNavigation.Name = "pnNavigation";
            this.pnNavigation.Size = new System.Drawing.Size(246, 754);
            this.pnNavigation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PeachPuff;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 59);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thanh Long Milk Tea";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 388);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(246, 34);
            this.btnTaiKhoan.TabIndex = 4;
            this.btnTaiKhoan.Text = "TÀI KHOẢN";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnHome
            // 
            this.btnHome.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnHome.Location = new System.Drawing.Point(0, 177);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(246, 34);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "HOME";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnLienHe
            // 
            this.btnLienHe.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLienHe.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnLienHe.Location = new System.Drawing.Point(0, 333);
            this.btnLienHe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLienHe.Name = "btnLienHe";
            this.btnLienHe.Size = new System.Drawing.Size(246, 34);
            this.btnLienHe.TabIndex = 3;
            this.btnLienHe.Text = "LIÊN HỆ";
            this.btnLienHe.UseVisualStyleBackColor = true;
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnMenu.Location = new System.Drawing.Point(0, 229);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(246, 34);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "MENU";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonHang.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnDonHang.Location = new System.Drawing.Point(0, 282);
            this.btnDonHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(246, 34);
            this.btnDonHang.TabIndex = 2;
            this.btnDonHang.Text = "ĐƠN HÀNG";
            this.btnDonHang.UseVisualStyleBackColor = true;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.pnNavigation);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.gbMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "User";
            this.Text = "Form1";
            this.pnNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox gbMain;
        private Panel pnMain;
        private Panel pnNavigation;
        private Button btnTaiKhoan;
        private Button btnHome;
        private Button btnLienHe;
        private Button btnMenu;
        private Button btnDonHang;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
