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
using TraSuaApp.Models.Admin;
using TraSuaApp.Services;
using Firebase.Auth;
using System.Net.Mail;
//using Firebase.Auth.Providers;

namespace TraSuaApp
{
    public partial class Dangky: Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Dangky()
        {
            InitializeComponent();
        }

        private const string ApiKey = "APIKey";

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string hoTen = txtTenKH.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ, xin mời bạn nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem email đã tồn tại trong Firestore chưa
            var danhSachTaiKhoan = await DBServices.GET<TaiKhoan>("TaiKhoan");
            if (danhSachTaiKhoan != null && danhSachTaiKhoan.Any(tk => tk.Email == email))
            {
                MessageBox.Show("Email đã tồn tại trong hệ thống, vui lòng nhập email khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu qua tất cả kiểm tra, tiến hành đăng ký
            await DangKyTaiKhoanVaKhachHang(email, matKhau, hoTen, soDienThoai);
        }

        public async Task DangKyTaiKhoanVaKhachHang(string email, string matKhau, string hoTen, string soDienThoai)
        {
            try
            {
                // Đăng ký user trên Firebase Authentication
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, matKhau);

                // Gửi email xác minh
                await authProvider.SendEmailVerificationAsync(auth.FirebaseToken);
                MessageBox.Show("Đã gửi email xác minh. Vui lòng kiểm tra hộp thư để kích hoạt tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tạo ID tài khoản mới
                var danhSachTaiKhoan = await DBServices.GET<TaiKhoan>("TaiKhoan");
                int soTaiKhoan = danhSachTaiKhoan?.Count ?? 0;
                string taiKhoanID = $"TK{(soTaiKhoan + 1).ToString("D3")}";

                // Tạo và lưu thông tin tài khoản
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    ID = taiKhoanID,
                    Email = email,
                    Quyen = "User"
                };
                await DBServices.POST(taiKhoanID, "TaiKhoan", taiKhoan);

                // Tạo ID khách hàng mới
                var danhSachKhachHang = await DBServices.GET<KhachHang>("KhachHang");
                int soKhachHang = danhSachKhachHang?.Count ?? 0;
                string khachHangID = $"KH{(soKhachHang + 1).ToString("D3")}";

                // Tạo và lưu thông tin khách hàng
                KhachHang khachHang = new KhachHang
                {
                    ID = khachHangID,
                    MaTK = taiKhoanID,
                    HoTen = hoTen,
                    SoDienThoai = soDienThoai,
                    DiemTichLuy = 0
                };
                await DBServices.POST(khachHangID, "KhachHang", khachHang);

                MessageBox.Show("Đăng ký thành công! Vui lòng xác minh email để hoàn tất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng ký thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}


