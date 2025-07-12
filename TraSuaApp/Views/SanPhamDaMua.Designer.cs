namespace TraSuaApp.View
{
    partial class SanPhamDaMua
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
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnlHienThi = new Panel();
            flpSanPhamDaMua = new FlowLayoutPanel();
            pnlHienThi.SuspendLayout();
            SuspendLayout();
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI Black", 39F, FontStyle.Bold | FontStyle.Italic);
            guna2HtmlLabel5.ForeColor = Color.OrangeRed;
            guna2HtmlLabel5.Location = new Point(0, 25);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(110, 72);
            guna2HtmlLabel5.TabIndex = 14;
            guna2HtmlLabel5.Text = "50%";
            // 
            // pnlHienThi
            // 
            pnlHienThi.BackColor = Color.Transparent;
            pnlHienThi.Controls.Add(flpSanPhamDaMua);
            pnlHienThi.Dock = DockStyle.Fill;
            pnlHienThi.Location = new Point(0, 0);
            pnlHienThi.Margin = new Padding(2);
            pnlHienThi.Name = "pnlHienThi";
            pnlHienThi.Size = new Size(811, 490);
            pnlHienThi.TabIndex = 0;
            // 
            // flpSanPhamDaMua
            // 
            flpSanPhamDaMua.AutoScroll = true;
            flpSanPhamDaMua.BackColor = Color.FromArgb(255, 162, 2);
            flpSanPhamDaMua.BackgroundImage = Properties.Resources.nền;
            flpSanPhamDaMua.Dock = DockStyle.Fill;
            flpSanPhamDaMua.Font = new Font("Segoe UI", 11F);
            flpSanPhamDaMua.Location = new Point(0, 0);
            flpSanPhamDaMua.Margin = new Padding(2);
            flpSanPhamDaMua.Name = "flpSanPhamDaMua";
            flpSanPhamDaMua.Padding = new Padding(21, 18, 21, 0);
            flpSanPhamDaMua.Size = new Size(811, 490);
            flpSanPhamDaMua.TabIndex = 11;
            // 
            // SanPhamDaMua
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.nền;
            ClientSize = new Size(811, 490);
            Controls.Add(pnlHienThi);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "SanPhamDaMua";
            Text = "SanPhamDaMua";
            pnlHienThi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Panel pnlHienThi;
        private FlowLayoutPanel flpSanPhamDaMua;
    }
}