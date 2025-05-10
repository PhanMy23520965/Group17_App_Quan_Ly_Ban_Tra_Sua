using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TraSuaApp
{
    partial class ChiTietSanPham 
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ptBHinhAnh = new PictureBox();
            panel2 = new Panel();
            lbGiaL = new Label();
            lbGiaM = new Label();
            lbGiaS = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            lbTrangThai = new Label();
            lbLoaiSP = new Label();
            lbTenSP = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnThemVaoDonHang = new Button();
            rbtnS = new RadioButton();
            rbtnM = new RadioButton();
            rbtnL = new RadioButton();
            label15 = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2ControlBox4 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2ControlBox5 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2ControlBox6 = new Guna.UI2.WinForms.Guna2ControlBox();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            panel1 = new Panel();
            button5 = new Button();
            label1 = new Label();
            button4 = new Button();
            button1 = new Button();
            btnDonHang = new Button();
            btnMenu = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel3 = new Panel();
            label17 = new Label();
            label16 = new Label();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton6 = new RadioButton();
            radioButton7 = new RadioButton();
            radioButton8 = new RadioButton();
            panel4 = new Panel();
            label18 = new Label();
            label19 = new Label();
            radioButton9 = new RadioButton();
            radioButton10 = new RadioButton();
            radioButton11 = new RadioButton();
            radioButton12 = new RadioButton();
            radioButton13 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)ptBHinhAnh).BeginInit();
            panel2.SuspendLayout();
            guna2Panel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // ptBHinhAnh
            // 
            ptBHinhAnh.Location = new Point(441, 123);
            ptBHinhAnh.Margin = new Padding(5, 6, 5, 6);
            ptBHinhAnh.Name = "ptBHinhAnh";
            ptBHinhAnh.Size = new Size(352, 368);
            ptBHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            ptBHinhAnh.TabIndex = 2;
            ptBHinhAnh.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Bisque;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lbGiaL);
            panel2.Controls.Add(lbGiaM);
            panel2.Controls.Add(lbGiaS);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(lbTrangThai);
            panel2.Controls.Add(lbLoaiSP);
            panel2.Controls.Add(lbTenSP);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            panel2.Location = new Point(842, 130);
            panel2.Margin = new Padding(5, 6, 5, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(509, 428);
            panel2.TabIndex = 3;
            // 
            // lbGiaL
            // 
            lbGiaL.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbGiaL.ForeColor = Color.Firebrick;
            lbGiaL.Location = new Point(197, 342);
            lbGiaL.Margin = new Padding(5, 0, 5, 0);
            lbGiaL.Name = "lbGiaL";
            lbGiaL.Size = new Size(92, 38);
            lbGiaL.TabIndex = 12;
            lbGiaL.Text = "15000";
            // 
            // lbGiaM
            // 
            lbGiaM.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbGiaM.ForeColor = Color.Firebrick;
            lbGiaM.Location = new Point(197, 280);
            lbGiaM.Margin = new Padding(5, 0, 5, 0);
            lbGiaM.Name = "lbGiaM";
            lbGiaM.Size = new Size(92, 38);
            lbGiaM.TabIndex = 11;
            lbGiaM.Text = "13000";
            // 
            // lbGiaS
            // 
            lbGiaS.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbGiaS.ForeColor = Color.Firebrick;
            lbGiaS.Location = new Point(197, 212);
            lbGiaS.Margin = new Padding(5, 0, 5, 0);
            lbGiaS.Name = "lbGiaS";
            lbGiaS.Size = new Size(92, 38);
            lbGiaS.TabIndex = 10;
            lbGiaS.Text = "10000";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(143, 342);
            label11.Margin = new Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new Size(23, 30);
            label11.TabIndex = 9;
            label11.Text = "L";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(143, 280);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(33, 30);
            label10.TabIndex = 8;
            label10.Text = "M";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(143, 212);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(25, 30);
            label9.TabIndex = 7;
            label9.Text = "S";
            // 
            // lbTrangThai
            // 
            lbTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTrangThai.ForeColor = Color.ForestGreen;
            lbTrangThai.Location = new Point(197, 136);
            lbTrangThai.Margin = new Padding(5, 0, 5, 0);
            lbTrangThai.Name = "lbTrangThai";
            lbTrangThai.Size = new Size(139, 38);
            lbTrangThai.TabIndex = 6;
            lbTrangThai.Text = "Còn hàng";
            // 
            // lbLoaiSP
            // 
            lbLoaiSP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbLoaiSP.Location = new Point(197, 80);
            lbLoaiSP.Margin = new Padding(5, 0, 5, 0);
            lbLoaiSP.Name = "lbLoaiSP";
            lbLoaiSP.Size = new Size(124, 38);
            lbLoaiSP.TabIndex = 5;
            lbLoaiSP.Text = "Trà Sữa";
            // 
            // lbTenSP
            // 
            lbTenSP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbTenSP.Location = new Point(197, 32);
            lbTenSP.Margin = new Padding(5, 0, 5, 0);
            lbTenSP.Name = "lbTenSP";
            lbTenSP.Size = new Size(124, 38);
            lbTenSP.TabIndex = 4;
            lbTenSP.Text = "Trà Sữa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 180);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(44, 30);
            label5.TabIndex = 3;
            label5.Text = "Giá";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 136);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(111, 30);
            label4.TabIndex = 2;
            label4.Text = "Tình trạng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 80);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(52, 30);
            label3.TabIndex = 1;
            label3.Text = "Loại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 32);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 30);
            label2.TabIndex = 0;
            label2.Text = "Tên món";
            // 
            // btnThemVaoDonHang
            // 
            btnThemVaoDonHang.BackColor = Color.Chocolate;
            btnThemVaoDonHang.Location = new Point(441, 549);
            btnThemVaoDonHang.Margin = new Padding(5, 6, 5, 6);
            btnThemVaoDonHang.Name = "btnThemVaoDonHang";
            btnThemVaoDonHang.Size = new Size(295, 62);
            btnThemVaoDonHang.TabIndex = 4;
            btnThemVaoDonHang.Text = "THÊM VÀO ĐƠN HÀNG";
            btnThemVaoDonHang.UseVisualStyleBackColor = false;
            btnThemVaoDonHang.Click += btnThemVaoDonHang_Click;
            // 
            // rbtnS
            // 
            rbtnS.AutoSize = true;
            rbtnS.Location = new Point(452, 503);
            rbtnS.Margin = new Padding(5, 6, 5, 6);
            rbtnS.Name = "rbtnS";
            rbtnS.Size = new Size(50, 34);
            rbtnS.TabIndex = 5;
            rbtnS.TabStop = true;
            rbtnS.Text = "S";
            rbtnS.UseVisualStyleBackColor = true;
            // 
            // rbtnM
            // 
            rbtnM.AutoSize = true;
            rbtnM.Location = new Point(552, 503);
            rbtnM.Margin = new Padding(5, 6, 5, 6);
            rbtnM.Name = "rbtnM";
            rbtnM.Size = new Size(58, 34);
            rbtnM.TabIndex = 6;
            rbtnM.TabStop = true;
            rbtnM.Text = "M";
            rbtnM.UseVisualStyleBackColor = true;
            // 
            // rbtnL
            // 
            rbtnL.AutoSize = true;
            rbtnL.Location = new Point(660, 503);
            rbtnL.Margin = new Padding(5, 6, 5, 6);
            rbtnL.Name = "rbtnL";
            rbtnL.Size = new Size(48, 34);
            rbtnL.TabIndex = 7;
            rbtnL.TabStop = true;
            rbtnL.Text = "L";
            rbtnL.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(1264, 616);
            label15.Margin = new Padding(5, 0, 5, 0);
            label15.Name = "label15";
            label15.Size = new Size(171, 28);
            label15.TabIndex = 0;
            label15.Text = "Đánh giá gần đây";
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Chocolate;
            guna2Panel1.Controls.Add(guna2ControlBox4);
            guna2Panel1.Controls.Add(guna2ControlBox5);
            guna2Panel1.Controls.Add(guna2ControlBox6);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.ForeColor = Color.SandyBrown;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Margin = new Padding(4);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1478, 55);
            guna2Panel1.TabIndex = 14;
            // 
            // guna2ControlBox4
            // 
            guna2ControlBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox4.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            guna2ControlBox4.CustomizableEdges = customizableEdges1;
            guna2ControlBox4.FillColor = Color.Chocolate;
            guna2ControlBox4.IconColor = Color.White;
            guna2ControlBox4.Location = new Point(1313, 0);
            guna2ControlBox4.Margin = new Padding(4);
            guna2ControlBox4.Name = "guna2ControlBox4";
            guna2ControlBox4.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ControlBox4.Size = new Size(82, 53);
            guna2ControlBox4.TabIndex = 16;
            // 
            // guna2ControlBox5
            // 
            guna2ControlBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox5.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            guna2ControlBox5.CustomizableEdges = customizableEdges3;
            guna2ControlBox5.FillColor = Color.Chocolate;
            guna2ControlBox5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            guna2ControlBox5.ForeColor = SystemColors.ActiveCaptionText;
            guna2ControlBox5.IconColor = Color.White;
            guna2ControlBox5.Location = new Point(1233, 0);
            guna2ControlBox5.Margin = new Padding(4);
            guna2ControlBox5.Name = "guna2ControlBox5";
            guna2ControlBox5.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ControlBox5.Size = new Size(82, 53);
            guna2ControlBox5.TabIndex = 15;
            // 
            // guna2ControlBox6
            // 
            guna2ControlBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            guna2ControlBox6.CustomizableEdges = customizableEdges5;
            guna2ControlBox6.FillColor = Color.Chocolate;
            guna2ControlBox6.IconColor = Color.White;
            guna2ControlBox6.Location = new Point(1395, 0);
            guna2ControlBox6.Margin = new Padding(4);
            guna2ControlBox6.Name = "guna2ControlBox6";
            guna2ControlBox6.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2ControlBox6.Size = new Size(82, 53);
            guna2ControlBox6.TabIndex = 14;
            guna2ControlBox6.Click += guna2ControlBox6_Click;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(238, 118, 30);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnDonHang);
            panel1.Controls.Add(btnMenu);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 55);
            panel1.Margin = new Padding(5, 6, 5, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(377, 989);
            panel1.TabIndex = 15;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top;
            button5.Font = new Font("Segoe UI Variable Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.FromArgb(238, 118, 0);
            button5.Location = new Point(0, 601);
            button5.Margin = new Padding(5, 6, 5, 6);
            button5.Name = "button5";
            button5.Size = new Size(377, 74);
            button5.TabIndex = 11;
            button5.Text = "TÀI KHOẢN";
            button5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(248, 180, 140);
            label1.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(155, 0, 0);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(377, 142);
            label1.TabIndex = 9;
            label1.Text = "Thanh Long Milk Tea";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top;
            button4.Font = new Font("Segoe UI Variable Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.FromArgb(238, 118, 0);
            button4.Location = new Point(0, 515);
            button4.Margin = new Padding(5, 6, 5, 6);
            button4.Name = "button4";
            button4.Size = new Size(377, 74);
            button4.TabIndex = 14;
            button4.Text = "LIÊN HỆ";
            button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Font = new Font("Segoe UI Variable Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(238, 118, 0);
            button1.Location = new Point(0, 256);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(377, 74);
            button1.TabIndex = 10;
            button1.Text = "HOME";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnDonHang
            // 
            btnDonHang.Anchor = AnchorStyles.Top;
            btnDonHang.Font = new Font("Segoe UI Variable Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDonHang.ForeColor = Color.FromArgb(238, 118, 0);
            btnDonHang.Location = new Point(0, 428);
            btnDonHang.Margin = new Padding(5, 6, 5, 6);
            btnDonHang.Name = "btnDonHang";
            btnDonHang.Size = new Size(377, 74);
            btnDonHang.TabIndex = 13;
            btnDonHang.Text = "ĐƠN HÀNG";
            btnDonHang.UseVisualStyleBackColor = true;
            btnDonHang.Click += btnDonHang_Click;
            // 
            // btnMenu
            // 
            btnMenu.Anchor = AnchorStyles.Top;
            btnMenu.BackColor = Color.FromArgb(238, 118, 0);
            btnMenu.Font = new Font("Segoe UI Variable Text", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(0, 342);
            btnMenu.Margin = new Padding(5, 6, 5, 6);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(377, 74);
            btnMenu.TabIndex = 12;
            btnMenu.Text = "MENU";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.PeachPuff;
            flowLayoutPanel1.Controls.Add(panel3);
            flowLayoutPanel1.Controls.Add(panel4);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(377, 696);
            flowLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1101, 348);
            flowLayoutPanel1.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel3.AutoScroll = true;
            panel3.BackColor = Color.AntiqueWhite;
            panel3.Controls.Add(label17);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(radioButton5);
            panel3.Controls.Add(radioButton4);
            panel3.Controls.Add(radioButton6);
            panel3.Controls.Add(radioButton7);
            panel3.Controls.Add(radioButton8);
            panel3.Location = new Point(5, 6);
            panel3.Margin = new Padding(5, 6, 5, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(738, 170);
            panel3.TabIndex = 0;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(133, 92);
            label17.Margin = new Padding(5, 0, 5, 0);
            label17.Name = "label17";
            label17.Size = new Size(208, 30);
            label17.TabIndex = 13;
            label17.Text = "He He, cho 1 sao nè";
            // 
            // label16
            // 
            label16.BackColor = Color.Coral;
            label16.Location = new Point(35, 18);
            label16.Margin = new Padding(5, 0, 5, 0);
            label16.Name = "label16";
            label16.Size = new Size(212, 46);
            label16.TabIndex = 12;
            label16.Text = "Táo Xanh Chua Lè";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(612, 24);
            radioButton5.Margin = new Padding(5, 6, 5, 6);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(50, 34);
            radioButton5.TabIndex = 11;
            radioButton5.TabStop = true;
            radioButton5.Text = "5";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(528, 24);
            radioButton4.Margin = new Padding(5, 6, 5, 6);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(50, 34);
            radioButton4.TabIndex = 10;
            radioButton4.TabStop = true;
            radioButton4.Text = "4";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(444, 24);
            radioButton6.Margin = new Padding(5, 6, 5, 6);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(50, 34);
            radioButton6.TabIndex = 9;
            radioButton6.TabStop = true;
            radioButton6.Text = "3";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            radioButton7.AutoSize = true;
            radioButton7.Location = new Point(360, 24);
            radioButton7.Margin = new Padding(5, 6, 5, 6);
            radioButton7.Name = "radioButton7";
            radioButton7.Size = new Size(50, 34);
            radioButton7.TabIndex = 8;
            radioButton7.TabStop = true;
            radioButton7.Text = "2";
            radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            radioButton8.AutoSize = true;
            radioButton8.Location = new Point(276, 24);
            radioButton8.Margin = new Padding(5, 6, 5, 6);
            radioButton8.Name = "radioButton8";
            radioButton8.Size = new Size(50, 34);
            radioButton8.TabIndex = 7;
            radioButton8.TabStop = true;
            radioButton8.Text = "1";
            radioButton8.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoScroll = true;
            panel4.BackColor = Color.AntiqueWhite;
            panel4.Controls.Add(label18);
            panel4.Controls.Add(label19);
            panel4.Controls.Add(radioButton9);
            panel4.Controls.Add(radioButton10);
            panel4.Controls.Add(radioButton11);
            panel4.Controls.Add(radioButton12);
            panel4.Controls.Add(radioButton13);
            panel4.Location = new Point(5, 188);
            panel4.Margin = new Padding(5, 6, 5, 6);
            panel4.Name = "panel4";
            panel4.Size = new Size(738, 170);
            panel4.TabIndex = 1;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(133, 92);
            label18.Margin = new Padding(5, 0, 5, 0);
            label18.Name = "label18";
            label18.Size = new Size(208, 30);
            label18.TabIndex = 13;
            label18.Text = "He He, cho 1 sao nè";
            // 
            // label19
            // 
            label19.BackColor = Color.Coral;
            label19.Location = new Point(35, 18);
            label19.Margin = new Padding(5, 0, 5, 0);
            label19.Name = "label19";
            label19.Size = new Size(212, 46);
            label19.TabIndex = 12;
            label19.Text = "Táo Xanh Chua Lè";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // radioButton9
            // 
            radioButton9.AutoSize = true;
            radioButton9.Location = new Point(614, 24);
            radioButton9.Margin = new Padding(5, 6, 5, 6);
            radioButton9.Name = "radioButton9";
            radioButton9.Size = new Size(50, 34);
            radioButton9.TabIndex = 11;
            radioButton9.TabStop = true;
            radioButton9.Text = "5";
            radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            radioButton10.AutoSize = true;
            radioButton10.Location = new Point(530, 24);
            radioButton10.Margin = new Padding(5, 6, 5, 6);
            radioButton10.Name = "radioButton10";
            radioButton10.Size = new Size(50, 34);
            radioButton10.TabIndex = 10;
            radioButton10.TabStop = true;
            radioButton10.Text = "4";
            radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            radioButton11.AutoSize = true;
            radioButton11.Location = new Point(446, 24);
            radioButton11.Margin = new Padding(5, 6, 5, 6);
            radioButton11.Name = "radioButton11";
            radioButton11.Size = new Size(50, 34);
            radioButton11.TabIndex = 9;
            radioButton11.TabStop = true;
            radioButton11.Text = "3";
            radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            radioButton12.AutoSize = true;
            radioButton12.Location = new Point(362, 24);
            radioButton12.Margin = new Padding(5, 6, 5, 6);
            radioButton12.Name = "radioButton12";
            radioButton12.Size = new Size(50, 34);
            radioButton12.TabIndex = 8;
            radioButton12.TabStop = true;
            radioButton12.Text = "2";
            radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            radioButton13.AutoSize = true;
            radioButton13.Location = new Point(278, 24);
            radioButton13.Margin = new Padding(5, 6, 5, 6);
            radioButton13.Name = "radioButton13";
            radioButton13.Size = new Size(50, 34);
            radioButton13.TabIndex = 7;
            radioButton13.TabStop = true;
            radioButton13.Text = "1";
            radioButton13.UseVisualStyleBackColor = true;
            // 
            // ChiTietSanPham
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            ClientSize = new Size(1478, 1044);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(guna2Panel1);
            Controls.Add(label15);
            Controls.Add(rbtnL);
            Controls.Add(rbtnM);
            Controls.Add(rbtnS);
            Controls.Add(btnThemVaoDonHang);
            Controls.Add(panel2);
            Controls.Add(ptBHinhAnh);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(24, 12);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ChiTietSanPham";
            Text = "Chi Tiết Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)ptBHinhAnh).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            guna2Panel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox ptBHinhAnh;
        private Panel panel2;
        private Label lbLoaiSP;
        private Label lbTenSP;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label lbGiaL;
        private Label lbGiaM;
        private Label lbGiaS;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label lbTrangThai;
        private Button btnThemVaoDonHang;
        private RadioButton rbtnS;
        private RadioButton rbtnM;
        private RadioButton rbtnL;
        private Label label15;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox4;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox5;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox6;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Panel panel1;
        private Button button5;
        private Label label1;
        private Button button4;
        private Button button1;
        private Button btnDonHang;
        private Button btnMenu;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel3;
        private Label label17;
        private Label label16;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton6;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private Panel panel4;
        private Label label18;
        private Label label19;
        private RadioButton radioButton9;
        private RadioButton radioButton10;
        private RadioButton radioButton11;
        private RadioButton radioButton12;
        private RadioButton radioButton13;
    }
}