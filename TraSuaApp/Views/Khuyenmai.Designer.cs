using Guna.UI2.WinForms;

namespace TraSuaApp.Views
{
    partial class Khuyenmai
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
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.pnlHienThiHome = new System.Windows.Forms.Panel();
            this.btnThanhToan = new Guna.UI2.WinForms.Guna2GradientButton();
            this.flowKhuyenMai = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHienThi.SuspendLayout();
            this.pnlHienThiHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.Controls.Add(this.pnlHienThiHome);
            this.pnlHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHienThi.Location = new System.Drawing.Point(0, 0);
            this.pnlHienThi.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(1300, 851);
            this.pnlHienThi.TabIndex = 2;
            // 
            // pnlHienThiHome
            // 
            this.pnlHienThiHome.BackColor = System.Drawing.Color.Transparent;
            this.pnlHienThiHome.BackgroundImage = Properties.Resources.nền;
            this.pnlHienThiHome.Controls.Add(this.btnThanhToan);
            this.pnlHienThiHome.Controls.Add(this.flowKhuyenMai);
            this.pnlHienThiHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHienThiHome.Location = new System.Drawing.Point(0, 0);
            this.pnlHienThiHome.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHienThiHome.Name = "pnlHienThiHome";
            this.pnlHienThiHome.Size = new System.Drawing.Size(1300, 851);
            this.pnlHienThiHome.TabIndex = 11;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BorderRadius = 20;
            this.btnThanhToan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhToan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhToan.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhToan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThanhToan.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnThanhToan.Location = new System.Drawing.Point(1064, 106);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(192, 81);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Quay lại Thanh Toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // flowKhuyenMai
            // 
            this.flowKhuyenMai.AutoScroll = true;
            this.flowKhuyenMai.Location = new System.Drawing.Point(50, 67);
            this.flowKhuyenMai.Name = "flowKhuyenMai";
            this.flowKhuyenMai.Size = new System.Drawing.Size(953, 672);
            this.flowKhuyenMai.TabIndex = 0;
            // 
            // Khuyenmai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(1300, 851);
            this.Controls.Add(this.pnlHienThi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Khuyenmai";
            this.Text = "Khuyenmai";
            this.pnlHienThi.ResumeLayout(false);
            this.pnlHienThiHome.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel pnlHienThi;
        private Panel pnlHienThiHome;
        private FlowLayoutPanel flowKhuyenMai;
        private Guna2GradientButton btnThanhToan;
    }
}