namespace TraSuaApp.Views
{
    partial class VoucherCuaBan
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
            flpVoucher = new FlowLayoutPanel();
            pnlHienThi.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHienThi
            // 
            pnlHienThi.BackColor = Color.Transparent;
            pnlHienThi.Controls.Add(flpVoucher);
            pnlHienThi.Dock = DockStyle.Fill;
            pnlHienThi.Location = new Point(0, 0);
            pnlHienThi.Name = "pnlHienThi";
            pnlHienThi.Size = new Size(800, 700);
            pnlHienThi.TabIndex = 0;
            // 
            // flpVoucher
            // 
            flpVoucher.Dock = DockStyle.Fill;
            flpVoucher.Location = new Point(0, 0);
            flpVoucher.Name = "flpVoucher";
            flpVoucher.Padding = new Padding(50);
            flpVoucher.Size = new Size(800, 700);
            flpVoucher.TabIndex = 0;
            // 
            // VoucherCuaBan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.nền;
            ClientSize = new Size(800, 700);
            Controls.Add(pnlHienThi);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VoucherCuaBan";
            Text = "VoucherCuaBan";
            pnlHienThi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHienThi;
        private FlowLayoutPanel flpVoucher;
    }
}