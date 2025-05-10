using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Models;
using TraSuaApp.Models;
using Google.Cloud.Firestore;
using TraSuaApp.Services;

namespace TraSuaApp
{
    public partial class ChiTietSanPham : Form
    {
        private ChiTietDonHangUser formDonHang; // tham chiếu tới form giỏ hàng
        private string masp = "";
        private string AnhSanPham = "";
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public ChiTietSanPham(SanPham sp, ChiTietDonHangUser formDonHang)
        {
            InitializeComponent();
            this.guna2Panel1.MouseDown += Form_MouseDown;
            this.Padding = new Padding(3);

            lbTenSP.Text = sp.TenSP;
            lbGiaS.Text = sp.Gia.ToString("N0");
            lbGiaM.Text = (sp.Gia * 1.3).ToString("N0");
            lbGiaL.Text = (sp.Gia * 1.5).ToString("N0");
            lbLoaiSP.Text = sp.LoaiSP;
            lbTrangThai.Text = sp.TrangThai;
            AnhSanPham = sp.HinhAnh;
            masp = sp.ID;

            try
            {
                ptBHinhAnh.Load(sp.HinhAnh);
            }
            catch
            {
                ptBHinhAnh.Image = null;
            }

            this.formDonHang = formDonHang;
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

        private void btnThemVaoDonHang_Click(object sender, EventArgs e)
        {
            if (lbTrangThai.Text?.ToLower() == "hết hàng" || lbTrangThai.Text?.ToLower() == "ngừng bán")
            {
                MessageBox.Show($"{lbTenSP} hiện đang hết hàng. Vui lòng chọn sản phẩm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xác định size được chọn
            string size = "S"; // mặc định

            if (rbtnM.Checked) size = "M";
            else if (rbtnL.Checked) size = "L";
            else if (rbtnS.Checked) size = "S";

            // Tạo chi tiết đơn hàng mới
            FirestoreDb db = DBServices.Connect();
            ChiTietDonHangTam ct = new ChiTietDonHangTam
            {
                MaSP = masp,
                TenSP = lbTenSP.Text, // tên sản phẩm từ label
                GiaBan = double.Parse(lbGiaS.Text)*1000, // giá gốc
                SoLuong = 1, // mặc định 1
                Size = size,
                HinhAnh = AnhSanPham,
            };

            // Tính tiền theo size
            double heSo = 1.0;
            if (size == "M") heSo = 1.3;
            else if (size == "L") heSo = 1.5;

            ct.ThanhTien = ct.GiaBan * ct.SoLuong * heSo;

            // Gọi form giỏ hàng để thêm
            formDonHang.ThemChiTietVaoGiaoDien(ct);

            // thông báo
            MessageBox.Show("Đã thêm vào giỏ hàng!");
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            this.Close();
            // Hiện form đơn hàng dưới dạng modal (có thể chỉnh lại thành .Show nếu muốn song song)
            formDonHang.ShowDialog();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu formMenu = new Menu(formDonHang); // tạo mới form Menu
            formMenu.ShowDialog(); // hiển thị form Menu
        }

        private void guna2ControlBox6_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng tất cả các form và thoát chương trình
        }
    }
}
