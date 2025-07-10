namespace TraSuaApp.Models
{
    partial class SanPhamHot
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
            pnlHienThi = new Panel();
            flpSanPhamHot = new FlowLayoutPanel();
            pnlHienThi.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHienThi
            // 
            pnlHienThi.BackColor = Color.Transparent;
            pnlHienThi.Controls.Add(flpSanPhamHot);
            pnlHienThi.Dock = DockStyle.Fill;
            pnlHienThi.Location = new Point(0, 0);
            pnlHienThi.Name = "pnlHienThi";
            pnlHienThi.Size = new Size(800, 450);
            pnlHienThi.TabIndex = 0;
            // 
            // flpSanPhamHot
            // 
            flpSanPhamHot.Dock = DockStyle.Fill;
            flpSanPhamHot.Location = new Point(0, 0);
            flpSanPhamHot.Name = "flpSanPhamHot";
            flpSanPhamHot.Size = new Size(800, 450);
            flpSanPhamHot.TabIndex = 0;
            // 
            // SanPhamHot
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.nền;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlHienThi);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SanPhamHot";
            Text = "SanPhamHot";
            pnlHienThi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHienThi;
        private FlowLayoutPanel flpSanPhamHot;
    }
}