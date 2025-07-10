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
            this.flowLayoutPanelBan = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHienThiHome = new System.Windows.Forms.Panel();
            this.btnLoc = new Guna.UI2.WinForms.Guna2GradientButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnThanhtoan = new Guna.UI2.WinForms.Guna2GradientButton();
            this.pnlHienThiHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelBan
            // 
            this.flowLayoutPanelBan.AutoScroll = true;
            this.flowLayoutPanelBan.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelBan.Location = new System.Drawing.Point(47, 114);
            this.flowLayoutPanelBan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanelBan.Name = "flowLayoutPanelBan";
            this.flowLayoutPanelBan.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanelBan.Size = new System.Drawing.Size(969, 648);
            this.flowLayoutPanelBan.TabIndex = 32;
            // 
            // pnlHienThiHome
            // 
            this.pnlHienThiHome.BackColor = System.Drawing.Color.Transparent;
            this.pnlHienThiHome.BackgroundImage = Properties.Resources.nền;
            this.pnlHienThiHome.Controls.Add(this.flowLayoutPanelBan);
            this.pnlHienThiHome.Controls.Add(this.btnLoc);
            this.pnlHienThiHome.Controls.Add(this.comboBox1);
            this.pnlHienThiHome.Controls.Add(this.btnThanhtoan);
            this.pnlHienThiHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHienThiHome.Location = new System.Drawing.Point(0, 0);
            this.pnlHienThiHome.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHienThiHome.Name = "pnlHienThiHome";
            this.pnlHienThiHome.Size = new System.Drawing.Size(1152, 895);
            this.pnlHienThiHome.TabIndex = 11;
            // 
            // btnLoc
            // 
            this.btnLoc.BorderRadius = 20;
            this.btnLoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLoc.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnLoc.Location = new System.Drawing.Point(80, 53);
            this.btnLoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(166, 40);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "LỌC";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tất cả",
            "1 người",
            "2 người",
            "3 người",
            "4 người",
            "5 người"});
            this.comboBox1.Location = new System.Drawing.Point(19, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 31);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.Text = "Lọc theo sức chứa";
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.BorderRadius = 20;
            this.btnThanhtoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhtoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThanhtoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhtoan.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThanhtoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThanhtoan.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThanhtoan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhtoan.ForeColor = System.Drawing.Color.White;
            this.btnThanhtoan.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.btnThanhtoan.Location = new System.Drawing.Point(703, 49);
            this.btnThanhtoan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(218, 44);
            this.btnThanhtoan.TabIndex = 0;
            this.btnThanhtoan.Text = "THANH TOÁN";
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // Ban
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(1456, 988);
            this.Controls.Add(this.pnlHienThiHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ban";
            this.Text = "Test";
            this.pnlHienThiHome.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanelBan;
        private Panel pnlHienThiHome;
        private Guna.UI2.WinForms.Guna2GradientButton btnThanhtoan;
        private Guna2GradientButton btnLoc;
        private ComboBox comboBox1;
    }
}