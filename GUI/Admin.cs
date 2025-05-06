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

namespace TraSuaApp
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            btnMenu.Click += new EventHandler(Button_Click);
            btnDonHang.Click += new EventHandler(Button_Click);
            btnBan.Click += new EventHandler(Button_Click);
            btnKM.Click += new EventHandler(Button_Click);
            btnLienHe.Click += new EventHandler(Button_Click);
            btnTaiKhoan.Click += new EventHandler(Button_Click);

            // Thiết lập nút mặc định (nếu có)
            selectedButton = btnMenu; // Ví dụ: Mặc định chọn MENU
            selectedButton.BackColor = selectedColor;

            LoadControl(new UC_Menu());

        }

        private Button selectedButton; // Biến theo dõi nút được chọn
        private Color defaultColor = Color.White; // Màu mặc định
        private Color selectedColor = Color.DarkOrange; // Màu khi được chọn

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Tạo khả năng kéo thả cho form
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaxRestore_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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

        public void LoadControl(UserControl uc)
        {
            pnMain.Controls.Clear(); // Xóa nội dung cũ
            // uc.Dock = DockStyle.Fill;  // Kéo giãn toàn bộ panel*/
            pnMain.Controls.Add(uc);
        }

        private void Button_Click(object sender, EventArgs e)
        {

        }

        private void SwitchContent(string buttonName)
        {
            // Xóa nội dung cũ (nếu có)
            this.Controls.Clear();

            // Tải UserControl tương ứng
            switch (buttonName)
            {
                case "btnMenu":
                    this.Controls.Add(new UC_Menu()); // Hoặc UserControl khác
                    break;
                case "btnDonHang":
                    this.Controls.Add(new UC_DonHang());
                    break;
                case "btnBan":
                    Controls.Add(new UC_Ban());
                    break;
                case "btnKhuyenMai":
                    Controls.Add(new UC_KhuyenMai());
                    break;
                case "btnLienHe":
                    Controls.Add(new UC_LienHe());
                    break;
                case "btnTaiKhoan":
                    Controls.Add(new UC_AdminProfile());
                    break;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_Menu());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_DonHang());
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_LienHe());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_AdminProfile());
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_Ban());
        }

        private void btnKM_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_KhuyenMai());
        }

    }
}
