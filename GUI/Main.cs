using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Models.Admin;
using TraSuaApp.Services;
using Guna.UI2.WinForms;

namespace TraSuaApp.GUI
{
    public partial class Main : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Main()
        {
            InitializeComponent();
            this.guna2Panel1.MouseDown += Form_MouseDown;
            this.Padding = new Padding(3);
            LoadControl(new UC_Menu());
        }

        // Tạo khả năng kéo thả cho form
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        //Phóng to, thu nhỏ các viền của form
        protected override void WndProc(ref Message m)
        {
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;
            const int WM_NCHITTEST = 0x84;

            const int resizeAreaSize = 10; // vùng resize tính từ mép

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                if (clientPoint.Y <= resizeAreaSize)
                {
                    if (clientPoint.X <= resizeAreaSize)
                        m.Result = (IntPtr)HTTOPLEFT;
                    else if (clientPoint.X < (this.Width - resizeAreaSize))
                        m.Result = (IntPtr)HTTOP;
                    else
                        m.Result = (IntPtr)HTTOPRIGHT;
                }
                else if (clientPoint.Y <= (this.Height - resizeAreaSize))
                {
                    if (clientPoint.X <= resizeAreaSize)
                        m.Result = (IntPtr)HTLEFT;
                    else if (clientPoint.X >= (this.Width - resizeAreaSize))
                        m.Result = (IntPtr)HTRIGHT;
                }
                else
                {
                    if (clientPoint.X <= resizeAreaSize)
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    else if (clientPoint.X < (this.Width - resizeAreaSize))
                        m.Result = (IntPtr)HTBOTTOM;
                    else
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                }

                return;
            }

            base.WndProc(ref m);
        }

        private void UpdateButtonStyles(Guna2Button clickedButton)
        {
            // Đặt lại giao diện cho tất cả các nút
            ResetButtonStyles();

            // Cập nhật nút được nhấn
            if (clickedButton != null)
            {
                clickedButton.FillColor = Color.FromArgb(80, 133, 186);
                clickedButton.ForeColor = Color.White;
                clickedButton.BorderColor = Color.FromArgb(69, 115, 161);
            }
        }

        private void ResetButtonStyles()
        {
            // Danh sách các nút trong dashboard
            var buttons = new[] { btnKM, btnMN, btnDH, btnLH, btnTK, btnBan };
            foreach (var button in buttons)
            {
                button.FillColor = Color.White;
                button.ForeColor = Color.FromArgb(255, 172, 105);
                button.BorderColor = Color.FromArgb(240, 166, 112);
            }
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            if (pnlDashBoard.Visible)
            {
                pnlDashBoard.Visible = false;
            }
            else
            {
                pnlDashBoard.Visible = true;
            }
        }

        public void LoadControl(UserControl uc)
        {
            pnMain.Controls.Clear(); // Xóa nội dung cũ
            uc.Dock = DockStyle.Fill;  // Kéo giãn toàn bộ panel*/
            pnMain.Controls.Add(uc);
        }


        private void btnMN_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_Menu());
            UpdateButtonStyles(sender as Guna.UI2.WinForms.Guna2Button);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_DonHang());
            UpdateButtonStyles(sender as Guna.UI2.WinForms.Guna2Button);
        }

        private void btnLH_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_LienHe());
            UpdateButtonStyles(sender as Guna.UI2.WinForms.Guna2Button);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_AdminProfile());
            UpdateButtonStyles(sender as Guna.UI2.WinForms.Guna2Button);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_Ban());
            UpdateButtonStyles(sender as Guna.UI2.WinForms.Guna2Button);
        }

        private void btnKM_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_KhuyenMai());
            UpdateButtonStyles(sender as Guna.UI2.WinForms.Guna2Button);
        }
        private void btnTK_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_AdminProfile());
            UpdateButtonStyles(sender as Guna.UI2.WinForms.Guna2Button);
        }
    }
}
