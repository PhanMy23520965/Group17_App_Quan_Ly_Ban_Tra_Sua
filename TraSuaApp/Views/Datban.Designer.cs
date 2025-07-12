using Guna.UI2.WinForms;

namespace TraSuaApp.Views
{
    partial class Datban
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            flowLayoutPanelBan = new FlowLayoutPanel();
            pnlHienThiHome = new Panel();
            guna2GradientButton1 = new Guna2GradientButton();
            btnLoc = new Guna2GradientButton();
            comboBox1 = new ComboBox();
            btnThanhtoan = new Guna2GradientButton();
            pnlHienThiHome.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelBan
            // 
            flowLayoutPanelBan.AutoScroll = true;
            flowLayoutPanelBan.BackColor = Color.Transparent;
            flowLayoutPanelBan.Location = new Point(47, 114);
            flowLayoutPanelBan.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanelBan.Name = "flowLayoutPanelBan";
            flowLayoutPanelBan.Padding = new Padding(5);
            flowLayoutPanelBan.Size = new Size(969, 648);
            flowLayoutPanelBan.TabIndex = 32;
            // 
            // pnlHienThiHome
            // 
            pnlHienThiHome.BackColor = Color.Transparent;
            pnlHienThiHome.BackgroundImage = Properties.Resources.nền;
            pnlHienThiHome.Controls.Add(guna2GradientButton1);
            pnlHienThiHome.Controls.Add(flowLayoutPanelBan);
            pnlHienThiHome.Controls.Add(btnLoc);
            pnlHienThiHome.Controls.Add(comboBox1);
            pnlHienThiHome.Controls.Add(btnThanhtoan);
            pnlHienThiHome.Dock = DockStyle.Fill;
            pnlHienThiHome.Location = new Point(0, 0);
            pnlHienThiHome.Margin = new Padding(2);
            pnlHienThiHome.Name = "pnlHienThiHome";
            pnlHienThiHome.Size = new Size(1456, 988);
            pnlHienThiHome.TabIndex = 11;
            pnlHienThiHome.Paint += pnlHienThiHome_Paint;
            // 
            // guna2GradientButton1
            // 
            guna2GradientButton1.BorderRadius = 20;
            guna2GradientButton1.CustomizableEdges = customizableEdges1;
            guna2GradientButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2GradientButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2GradientButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2GradientButton1.FillColor2 = Color.FromArgb(255, 128, 0);
            guna2GradientButton1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2GradientButton1.ForeColor = Color.White;
            guna2GradientButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            guna2GradientButton1.Location = new Point(766, 49);
            guna2GradientButton1.Margin = new Padding(2);
            guna2GradientButton1.Name = "guna2GradientButton1";
            guna2GradientButton1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GradientButton1.Size = new Size(250, 44);
            guna2GradientButton1.TabIndex = 33;
            guna2GradientButton1.Text = "QUAY LẠI GIỎ HÀNG";
            guna2GradientButton1.Click += guna2GradientButton1_Click;
            // 
            // btnLoc
            // 
            btnLoc.BorderRadius = 20;
            btnLoc.CustomizableEdges = customizableEdges3;
            btnLoc.DisabledState.BorderColor = Color.DarkGray;
            btnLoc.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLoc.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLoc.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnLoc.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLoc.FillColor2 = Color.FromArgb(255, 128, 0);
            btnLoc.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoc.ForeColor = Color.White;
            btnLoc.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnLoc.Location = new Point(80, 53);
            btnLoc.Margin = new Padding(2);
            btnLoc.Name = "btnLoc";
            btnLoc.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnLoc.Size = new Size(166, 40);
            btnLoc.TabIndex = 3;
            btnLoc.Text = "LỌC";
            btnLoc.Click += btnLoc_Click;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tất cả", "1 người", "2 người", "3 người", "4 người", "5 người" });
            comboBox1.Location = new Point(19, 17);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(177, 27);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Lọc theo sức chứa";
            // 
            // btnThanhtoan
            // 
            btnThanhtoan.BorderRadius = 20;
            btnThanhtoan.CustomizableEdges = customizableEdges5;
            btnThanhtoan.DisabledState.BorderColor = Color.DarkGray;
            btnThanhtoan.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThanhtoan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThanhtoan.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnThanhtoan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThanhtoan.FillColor2 = Color.FromArgb(255, 128, 0);
            btnThanhtoan.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThanhtoan.ForeColor = Color.White;
            btnThanhtoan.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnThanhtoan.Location = new Point(517, 49);
            btnThanhtoan.Margin = new Padding(2);
            btnThanhtoan.Name = "btnThanhtoan";
            btnThanhtoan.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnThanhtoan.Size = new Size(218, 44);
            btnThanhtoan.TabIndex = 0;
            btnThanhtoan.Text = "THANH TOÁN";
            btnThanhtoan.Click += btnThanhToan_Click;
            // 
            // Datban
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(255, 209, 160);
            ClientSize = new Size(1456, 988);
            Controls.Add(pnlHienThiHome);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Datban";
            Text = "Test";
            pnlHienThiHome.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanelBan;
        private Panel pnlHienThiHome;
        private Guna.UI2.WinForms.Guna2GradientButton btnThanhtoan;
        private Guna2GradientButton btnLoc;
        private ComboBox comboBox1;
        private Guna2GradientButton guna2GradientButton1;
    }
}