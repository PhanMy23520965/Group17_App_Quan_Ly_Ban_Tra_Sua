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
using Guna.UI2.WinForms;
using Models.Admin;
using TraSuaApp.Models;
using TraSuaApp.Services;
using TraSuaApp.View;
using TraSuaApp.Views;

namespace TraSuaApp.Views
{
    public partial class Home1 : Form
    {
        private DonHangUser donhang;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Home1(DonHangUser formDonHang)
        {
            InitializeComponent();
            this.guna2HtmlLabel1.MouseDown += Form_MouseDown;
            this.Padding = new Padding(3);
            this.donhang = formDonHang;
            guna2HtmlLabel2.Text = Dangnhap.TenKH;
            guna2HtmlLabel2.MouseClick += Guna2HtmlLabel2_MouseClick;
        }

        // Xử lý sự kiện MouseClick
        private void Guna2HtmlLabel2_MouseClick(object sender, MouseEventArgs e)
        {
            // Tạo một danh sách tạm thời để lưu các form
            List<Form> openForms = new List<Form>(Application.OpenForms.Cast<Form>());

            // Xóa tất cả các form hiện tại (nếu cần)
            foreach (Form form in openForms)
            {
                // Kiểm tra nếu form không phải là form đăng nhập, thì đóng form
                if (form.Name != "Dangnhap")
                {
                    form.Close();
                }
            }

            //Xóa hết các thông tin setting cũ để nó ko tự động đăng nhập lại nick cũ :))
            Properties.Settings.Default.Email = "";
            Properties.Settings.Default.MatKhau = "";
            Properties.Settings.Default.Save();

            // Mở form đăng nhập
            Dangnhap dangNhapForm = new Dangnhap();
            dangNhapForm.Show(); // Mở form đăng nhập
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
        private void Home1_Load(object sender, EventArgs e)
        {
            Guna2Elipse gunaElipse = new Guna2Elipse
            {
                BorderRadius = 20,  // Bo góc 30
                TargetControl = this  // Áp dụng cho Form hiện tại
            };

            btnHome_Click(btnHome, EventArgs.Empty);
        }

        // nút mở dashboard
        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            // Đóng form con hiện tại trong Panel (nếu có)
            pnlHienThi.Controls.Clear();

            // Tạo form con
            Menu menuForm = new Menu(donhang)
            {
                TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                Dock = DockStyle.Fill      // Hiển thị full trong panel
            };

            btnHome.FillColor = Color.White;
            btnHome.ForeColor = Color.FromArgb(221, 168, 83);
            btnHome.BorderColor = Color.FromArgb(240, 166, 112);

            btnTaiKhoan.FillColor = Color.White;
            btnTaiKhoan.ForeColor = Color.FromArgb(221, 168, 83);
            btnTaiKhoan.BorderColor = Color.FromArgb(240, 166, 112);

            btnLienHe.FillColor = Color.White;
            btnLienHe.ForeColor = Color.FromArgb(221, 168, 83);
            btnLienHe.BorderColor = Color.FromArgb(240, 166, 112);

            btnDonHang.FillColor = Color.White;
            btnDonHang.ForeColor = Color.FromArgb(221, 168, 83);
            btnDonHang.BorderColor = Color.FromArgb(240, 166, 112);

            btnMenu.FillColor = Color.FromArgb(39, 84, 138);
            btnMenu.ForeColor = Color.White;
            btnMenu.BorderColor = Color.FromArgb(80, 133, 186);

            // Thêm form con vào panel và hiển thị
            pnlHienThi.Controls.Add(menuForm);
            menuForm.Show();
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            // Đóng form con hiện tại trong Panel (nếu có)
            pnlHienThi.Controls.Clear();

            donhang.TopLevel = false;      // Đặt form con không phải là cửa sổ cấp cao nhất
            donhang.Dock = DockStyle.Fill;     // Hiển thị full trong pane

            btnHome.FillColor = Color.White;
            btnHome.ForeColor = Color.FromArgb(221, 168, 83);
            btnHome.BorderColor = Color.FromArgb(240, 166, 112);

            btnTaiKhoan.FillColor = Color.White;
            btnTaiKhoan.ForeColor = Color.FromArgb(221, 168, 83);
            btnTaiKhoan.BorderColor = Color.FromArgb(240, 166, 112);

            btnLienHe.FillColor = Color.White;
            btnLienHe.ForeColor = Color.FromArgb(221, 168, 83);
            btnLienHe.BorderColor = Color.FromArgb(240, 166, 112);

            btnMenu.FillColor = Color.White;
            btnMenu.ForeColor = Color.FromArgb(221, 168, 83);
            btnMenu.BorderColor = Color.FromArgb(240, 166, 112);

            btnDonHang.FillColor = Color.FromArgb(39, 84, 138);
            btnDonHang.ForeColor = Color.White;
            btnDonHang.BorderColor = Color.FromArgb(80, 133, 186);

            // Thêm form con vào panel và hiển thị
            pnlHienThi.Controls.Add(donhang);
            donhang.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            // Đóng form con hiện tại trong Panel (nếu có)
            pnlHienThi.Controls.Clear();

            // Tạo form con
            ThongTinTaiKhoan tttkForm = new ThongTinTaiKhoan()
            {
                TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                Dock = DockStyle.Fill      // Hiển thị full trong panel
            };

            btnHome.FillColor = Color.White;
            btnHome.ForeColor = Color.FromArgb(221, 168, 83);
            btnHome.BorderColor = Color.FromArgb(240, 166, 112);

            btnMenu.FillColor = Color.White;
            btnMenu.ForeColor = Color.FromArgb(221, 168, 83);
            btnMenu.BorderColor = Color.FromArgb(240, 166, 112);

            btnLienHe.FillColor = Color.White;
            btnLienHe.ForeColor = Color.FromArgb(221, 168, 83);
            btnLienHe.BorderColor = Color.FromArgb(240, 166, 112);

            btnDonHang.FillColor = Color.White;
            btnDonHang.ForeColor = Color.FromArgb(221, 168, 83);
            btnDonHang.BorderColor = Color.FromArgb(240, 166, 112);

            btnTaiKhoan.FillColor = Color.FromArgb(39, 84, 138);
            btnTaiKhoan.ForeColor = Color.White;
            btnTaiKhoan.BorderColor = Color.FromArgb(80, 133, 186);

            // Thêm form con vào panel và hiển thị
            pnlHienThi.Controls.Add(tttkForm);
            tttkForm.Show();
        }



        private void btnLienHe_Click(object sender, EventArgs e)
        {
            // Đóng form con hiện tại trong Panel (nếu có)
            pnlHienThi.Controls.Clear();

            // Tạo form con
            LienHe lhForm = new LienHe()
            {
                TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                Dock = DockStyle.Fill      // Hiển thị full trong panel
            };

            btnHome.FillColor = Color.White;
            btnHome.ForeColor = Color.FromArgb(221, 168, 83);
            btnHome.BorderColor = Color.FromArgb(240, 166, 112);

            btnMenu.FillColor = Color.White;
            btnMenu.ForeColor = Color.FromArgb(221, 168, 83);
            btnMenu.BorderColor = Color.FromArgb(240, 166, 112);

            btnTaiKhoan.FillColor = Color.White;
            btnTaiKhoan.ForeColor = Color.FromArgb(221, 168, 83);
            btnTaiKhoan.BorderColor = Color.FromArgb(240, 166, 112);

            btnDonHang.FillColor = Color.White;
            btnDonHang.ForeColor = Color.FromArgb(221, 168, 83);
            btnDonHang.BorderColor = Color.FromArgb(240, 166, 112);

            btnLienHe.FillColor = Color.FromArgb(39, 84, 138);
            btnLienHe.ForeColor = Color.White;
            btnLienHe.BorderColor = Color.FromArgb(80, 133, 186);

            // Thêm form con vào panel và hiển thị
            pnlHienThi.Controls.Add(lhForm);
            lhForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Đóng form con hiện tại trong Panel (nếu có)
            pnlHienThi.Controls.Clear();

            // Tạo form con
            Home hForm = new Home(donhang)
            {
                TopLevel = false,  // Đặt form con không phải là cửa sổ cấp cao nhất
                Dock = DockStyle.Fill      // Hiển thị full trong panel
            };

            btnLienHe.FillColor = Color.White;
            btnLienHe.ForeColor = Color.FromArgb(221, 168, 83);
            btnLienHe.BorderColor = Color.FromArgb(240, 166, 112);

            btnMenu.FillColor = Color.White;
            btnMenu.ForeColor = Color.FromArgb(221, 168, 83);
            btnMenu.BorderColor = Color.FromArgb(240, 166, 112);

            btnTaiKhoan.FillColor = Color.White;
            btnTaiKhoan.ForeColor = Color.FromArgb(221, 168, 83);
            btnTaiKhoan.BorderColor = Color.FromArgb(240, 166, 112);

            btnDonHang.FillColor = Color.White;
            btnDonHang.ForeColor = Color.FromArgb(221, 168, 83);
            btnDonHang.BorderColor = Color.FromArgb(240, 166, 112);

            btnHome.FillColor = Color.FromArgb(39, 84, 138);
            btnHome.ForeColor = Color.White;
            btnHome.BorderColor = Color.FromArgb(80, 133, 186);

            // Thêm form con vào panel và hiển thị
            pnlHienThi.Controls.Add(hForm);
            hForm.Show();
        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
