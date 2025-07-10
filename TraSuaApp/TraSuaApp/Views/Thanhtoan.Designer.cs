using Guna.UI2.WinForms;
using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using Guna.UI2.WinForms.Suite;

namespace TraSuaApp.Views
{
    partial class Thanhtoan
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
            components = new System.ComponentModel.Container();
            CustomizableEdges customizableEdges1 = new CustomizableEdges();
            CustomizableEdges customizableEdges2 = new CustomizableEdges();
            CustomizableEdges customizableEdges3 = new CustomizableEdges();
            CustomizableEdges customizableEdges4 = new CustomizableEdges();
            pnlHienThiHome = new Panel();
            btnKhuyenMai = new Guna2GradientButton();
            guna2HtmlLabel2 = new Guna2HtmlLabel();
            guna2GradientPanel1 = new Guna2GradientPanel();
            guna2HtmlLabel10 = new Guna2HtmlLabel();
            guna2HtmlLabel9 = new Guna2HtmlLabel();
            guna2HtmlLabel8 = new Guna2HtmlLabel();
            guna2HtmlLabel7 = new Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna2HtmlLabel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            guna2HtmlLabel6 = new Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            guna2ContextMenuStrip1 = new Guna2ContextMenuStrip();
            guna2AnimateWindow1 = new Guna2AnimateWindow(components);
            pnlHienThiHome.SuspendLayout();
            guna2GradientPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHienThiHome
            // 
            pnlHienThiHome.BackColor = Color.Transparent;
            pnlHienThiHome.BackgroundImage = Properties.Resources.nền;
            pnlHienThiHome.Controls.Add(btnKhuyenMai);
            pnlHienThiHome.Controls.Add(guna2HtmlLabel2);
            pnlHienThiHome.Controls.Add(guna2GradientPanel1);
            pnlHienThiHome.Controls.Add(guna2HtmlLabel1);
            pnlHienThiHome.Dock = DockStyle.Fill;
            pnlHienThiHome.Location = new Point(0, 0);
            pnlHienThiHome.Margin = new Padding(2);
            pnlHienThiHome.Name = "pnlHienThiHome";
            pnlHienThiHome.Size = new Size(1300, 851);
            pnlHienThiHome.TabIndex = 11;
            // 
            // btnKhuyenMai
            // 
            btnKhuyenMai.BorderRadius = 20;
            btnKhuyenMai.CustomizableEdges = customizableEdges1;
            btnKhuyenMai.DisabledState.BorderColor = Color.DarkGray;
            btnKhuyenMai.DisabledState.CustomBorderColor = Color.DarkGray;
            btnKhuyenMai.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnKhuyenMai.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnKhuyenMai.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnKhuyenMai.FillColor2 = Color.FromArgb(255, 128, 0);
            btnKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKhuyenMai.ForeColor = Color.White;
            btnKhuyenMai.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnKhuyenMai.Location = new Point(936, 435);
            btnKhuyenMai.Margin = new Padding(2);
            btnKhuyenMai.Name = "btnKhuyenMai";
            btnKhuyenMai.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnKhuyenMai.Size = new Size(259, 60);
            btnKhuyenMai.TabIndex = 5;
            btnKhuyenMai.Text = "Chọn Khuyến mãi";
            btnKhuyenMai.Click += btnKhuyenMai_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.Blue;
            guna2HtmlLabel2.Location = new Point(12, 36);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(311, 43);
            guna2HtmlLabel2.TabIndex = 4;
            guna2HtmlLabel2.Text = "ĐƠN HÀNG CỦA BẠN";
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.BackColor = Color.White;
            guna2GradientPanel1.BorderColor = Color.Blue;
            guna2GradientPanel1.BorderRadius = 20;
            guna2GradientPanel1.BorderThickness = 2;
            guna2GradientPanel1.Controls.Add(guna2HtmlLabel10);
            guna2GradientPanel1.Controls.Add(guna2HtmlLabel9);
            guna2GradientPanel1.Controls.Add(guna2HtmlLabel8);
            guna2GradientPanel1.Controls.Add(guna2HtmlLabel7);
            guna2GradientPanel1.Controls.Add(guna2HtmlLabel5);
            guna2GradientPanel1.Controls.Add(guna2HtmlLabel4);
            guna2GradientPanel1.Controls.Add(guna2HtmlLabel3);
            guna2GradientPanel1.Controls.Add(flowLayoutPanel1);
            guna2GradientPanel1.CustomizableEdges = customizableEdges3;
            guna2GradientPanel1.Location = new Point(12, 105);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GradientPanel1.Size = new Size(824, 699);
            guna2GradientPanel1.TabIndex = 3;
            // 
            // guna2HtmlLabel10
            // 
            guna2HtmlLabel10.BackColor = Color.Transparent;
            guna2HtmlLabel10.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel10.ForeColor = Color.Blue;
            guna2HtmlLabel10.Location = new Point(53, 656);
            guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            guna2HtmlLabel10.Size = new Size(211, 30);
            guna2HtmlLabel10.TabIndex = 7;
            guna2HtmlLabel10.Text = "Trạng thái thanh toán";
            // 
            // guna2HtmlLabel9
            // 
            guna2HtmlLabel9.BackColor = Color.Transparent;
            guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel9.ForeColor = Color.Blue;
            guna2HtmlLabel9.Location = new Point(53, 614);
            guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            guna2HtmlLabel9.Size = new Size(248, 30);
            guna2HtmlLabel9.TabIndex = 6;
            guna2HtmlLabel9.Text = "Tổng tiền sau khuyến mãi";
            // 
            // guna2HtmlLabel8
            // 
            guna2HtmlLabel8.BackColor = Color.Transparent;
            guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel8.ForeColor = Color.Blue;
            guna2HtmlLabel8.Location = new Point(53, 572);
            guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            guna2HtmlLabel8.Size = new Size(149, 30);
            guna2HtmlLabel8.TabIndex = 5;
            guna2HtmlLabel8.Text = "Mã khuyến mãi";
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel7.ForeColor = Color.Blue;
            guna2HtmlLabel7.Location = new Point(53, 530);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(94, 30);
            guna2HtmlLabel7.TabIndex = 4;
            guna2HtmlLabel7.Text = "Tổng tiền";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel5.ForeColor = Color.Blue;
            guna2HtmlLabel5.Location = new Point(53, 67);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(130, 30);
            guna2HtmlLabel5.TabIndex = 3;
            guna2HtmlLabel5.Text = "Mã đơn hàng";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.ForeColor = Color.Blue;
            guna2HtmlLabel4.Location = new Point(304, 19);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(72, 30);
            guna2HtmlLabel4.TabIndex = 2;
            guna2HtmlLabel4.Text = "Tên KH";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = Color.Blue;
            guna2HtmlLabel3.Location = new Point(53, 19);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(67, 30);
            guna2HtmlLabel3.TabIndex = 1;
            guna2HtmlLabel3.Text = "Mã KH";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.AutoScrollMinSize = new Size(0, 1000);
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanel1.Controls.Add(guna2HtmlLabel6);
            flowLayoutPanel1.Location = new Point(53, 97);
            flowLayoutPanel1.Margin = new Padding(2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(16, 0, 48, 38);
            flowLayoutPanel1.Size = new Size(673, 410);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel6.ForeColor = Color.Blue;
            guna2HtmlLabel6.Location = new Point(19, 3);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(169, 30);
            guna2HtmlLabel6.TabIndex = 2;
            guna2HtmlLabel6.Text = "Chi tiết đơn hàng";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(0, 0);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.TabIndex = 6;
            guna2HtmlLabel1.Text = null;
            // 
            // guna2ContextMenuStrip1
            // 
            guna2ContextMenuStrip1.ImageScalingSize = new Size(20, 20);
            guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            guna2ContextMenuStrip1.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
            guna2ContextMenuStrip1.RenderStyle.BorderColor = Color.Gainsboro;
            guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = Color.White;
            guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
            guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = Color.White;
            guna2ContextMenuStrip1.RenderStyle.SeparatorColor = Color.Gainsboro;
            guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            guna2ContextMenuStrip1.Size = new Size(61, 4);
            // 
            // Thanhtoan
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(255, 209, 160);
            ClientSize = new Size(1300, 851);
            Controls.Add(pnlHienThiHome);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Thanhtoan";
            Text = "Thanhtoan";
            Load += Thanhtoan_Load;
            pnlHienThiHome.ResumeLayout(false);
            pnlHienThiHome.PerformLayout();
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private Panel pnlHienThiHome;
        private Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2GradientPanel guna2GradientPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Guna2HtmlLabel guna2HtmlLabel2;
        private Guna2AnimateWindow guna2AnimateWindow1;
        private Guna2HtmlLabel guna2HtmlLabel5;
        private Guna2HtmlLabel guna2HtmlLabel4;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2HtmlLabel guna2HtmlLabel6;
        private Guna2GradientButton btnKhuyenMai;
        private Guna2HtmlLabel guna2HtmlLabel9;
        private Guna2HtmlLabel guna2HtmlLabel8;
        private Guna2HtmlLabel guna2HtmlLabel7;
        private Guna2HtmlLabel guna2HtmlLabel10;
    }
}