using System.Windows.Forms;
using System.Drawing;

namespace TraSuaApp
{
    partial class Admin
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnNavigation = new System.Windows.Forms.Panel();
            this.btnKM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBan = new System.Windows.Forms.Button();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnLienHe = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnDonHang = new System.Windows.Forms.Button();
            this.pNav = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnMaxRestore = new System.Windows.Forms.Button();
            this.pnNavigation.SuspendLayout();
            this.pNav.SuspendLayout();
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
            this.pnMain.Location = new System.Drawing.Point(244, 32);
            this.pnMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1135, 718);
            this.pnMain.TabIndex = 2;
            // 
            // pnNavigation
            // 
            this.pnNavigation.BackColor = System.Drawing.Color.DarkOrange;
            this.pnNavigation.Controls.Add(this.btnKM);
            this.pnNavigation.Controls.Add(this.label1);
            this.pnNavigation.Controls.Add(this.btnBan);
            this.pnNavigation.Controls.Add(this.btnTaiKhoan);
            this.pnNavigation.Controls.Add(this.btnLienHe);
            this.pnNavigation.Controls.Add(this.btnMenu);
            this.pnNavigation.Controls.Add(this.btnDonHang);
            this.pnNavigation.Location = new System.Drawing.Point(-1, 32);
            this.pnNavigation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnNavigation.Name = "pnNavigation";
            this.pnNavigation.Size = new System.Drawing.Size(246, 718);
            this.pnNavigation.TabIndex = 0;
            // 
            // btnKM
            // 
            this.btnKM.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKM.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnKM.Location = new System.Drawing.Point(0, 335);
            this.btnKM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKM.Name = "btnKM";
            this.btnKM.Size = new System.Drawing.Size(246, 52);
            this.btnKM.TabIndex = 6;
            this.btnKM.Text = "KHUYẾN MÃI";
            this.btnKM.UseVisualStyleBackColor = true;
            this.btnKM.Click += new System.EventHandler(this.btnKM_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(180)))), ((int)(((byte)(140)))));
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 78);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thanh Long Milk Tea";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBan
            // 
            this.btnBan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBan.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnBan.Location = new System.Drawing.Point(0, 269);
            this.btnBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(246, 52);
            this.btnBan.TabIndex = 7;
            this.btnBan.Text = "BÀN ";
            this.btnBan.UseVisualStyleBackColor = true;
            this.btnBan.Click += new System.EventHandler(this.btnBan_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 471);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(246, 52);
            this.btnTaiKhoan.TabIndex = 4;
            this.btnTaiKhoan.Text = "TÀI KHOẢN";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnLienHe
            // 
            this.btnLienHe.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLienHe.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnLienHe.Location = new System.Drawing.Point(0, 402);
            this.btnLienHe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLienHe.Name = "btnLienHe";
            this.btnLienHe.Size = new System.Drawing.Size(246, 52);
            this.btnLienHe.TabIndex = 3;
            this.btnLienHe.Text = "LIÊN HỆ";
            this.btnLienHe.UseVisualStyleBackColor = true;
            this.btnLienHe.Click += new System.EventHandler(this.btnLienHe_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnMenu.Location = new System.Drawing.Point(0, 136);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(246, 52);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "MENU";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonHang.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnDonHang.Location = new System.Drawing.Point(0, 202);
            this.btnDonHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(246, 52);
            this.btnDonHang.TabIndex = 2;
            this.btnDonHang.Text = "ĐƠN HÀNG";
            this.btnDonHang.UseVisualStyleBackColor = true;
            this.btnDonHang.Click += new System.EventHandler(this.btnDonHang_Click);
            // 
            // pNav
            // 
            this.pNav.BackColor = System.Drawing.Color.Chocolate;
            this.pNav.Controls.Add(this.btnClose);
            this.pNav.Controls.Add(this.btnMinimize);
            this.pNav.Controls.Add(this.btnMaxRestore);
            this.pNav.Location = new System.Drawing.Point(-1, 0);
            this.pNav.Name = "pNav";
            this.pNav.Size = new System.Drawing.Size(1380, 32);
            this.pNav.TabIndex = 3;
            this.pNav.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Chocolate;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(1334, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Chocolate;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMinimize.Location = new System.Drawing.Point(1240, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(50, 32);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "---";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaxRestore
            // 
            this.btnMaxRestore.BackColor = System.Drawing.Color.Chocolate;
            this.btnMaxRestore.FlatAppearance.BorderSize = 0;
            this.btnMaxRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxRestore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMaxRestore.Location = new System.Drawing.Point(1287, 0);
            this.btnMaxRestore.Name = "btnMaxRestore";
            this.btnMaxRestore.Size = new System.Drawing.Size(50, 32);
            this.btnMaxRestore.TabIndex = 1;
            this.btnMaxRestore.Text = "[]";
            this.btnMaxRestore.UseVisualStyleBackColor = false;
            this.btnMaxRestore.Click += new System.EventHandler(this.btnMaxRestore_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.pNav);
            this.Controls.Add(this.pnNavigation);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.gbMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Admin";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Admin";
            this.pnNavigation.ResumeLayout(false);
            this.pNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox gbMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel pnMain;
        private Panel pnNavigation;
        private Button btnTaiKhoan;
        private Button btnLienHe;
        private Button btnMenu;
        private Button btnDonHang;
        private Label label1;
        private Button btnKM;
        private Button btnBan;
        private Panel pNav;
        private Button btnClose;
        private Button btnMinimize;
        private Button btnMaxRestore;
    }
}
