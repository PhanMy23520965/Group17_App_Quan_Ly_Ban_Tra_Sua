using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Models.Admin;
using TraSuaApp.Services;

namespace TraSuaApp
{
    public partial class Dangnhap : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Dangnhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtEmail, "Nhập email");
            SetPlaceholder(txtMatKhau, "Nhập mật khẩu");
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool dangNhapThanhCong = await XacThucDangNhap(email, matKhau);

            if (dangNhapThanhCong)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: Chuyển sang form chính của ứng dụng
                // this.Hide();
                // new MainForm().Show();
            }
            else
            {
                MessageBox.Show("Email hoặc Mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> XacThucDangNhap(string email, string matKhau)
        {
            try
            {
                // Sử dụng Firebase để xác thực người dùng
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAQKaZZ7DQw2ktZ_2sFaQsi_f0oJRbm_1o")); 
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, matKhau);

                // Kiểm tra xem người dùng có đăng nhập thành công không
                if (auth != null && !string.IsNullOrEmpty(auth.FirebaseToken))
                {
                    return true; // Đăng nhập thành công
                }
                return false; // Đăng nhập không thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Xử lý sự kiện khi bấm vào LinkLabel "Đăng ký"
        private void linklabelDangKy_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky dangkyForm = new Dangky();
            dangkyForm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Quenmatkhau quenmk = new Quenmatkhau();
            quenmk.Show();
        }
    }
}

//namespace TraSuaApp
//{
//    public partial class Dangnhap: Form
//    {
//        [DllImport("user32.dll")]
//        public static extern bool ReleaseCapture();
//        [DllImport("user32.dll")]
//        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
//        public Dangnhap()
//        {
//            InitializeComponent();
//        }

//        private void DangNhap_Load(object sender, EventArgs e)
//        {
//            SetPlaceholder(txtEmail, "Nhập email");
//            SetPlaceholder(txtMatKhau, "Nhập mật khẩu");
//        }

//        private void SetPlaceholder(TextBox textBox, string placeholder)
//        {
//            textBox.Text = placeholder;
//            textBox.ForeColor = Color.Gray;

//            textBox.GotFocus += (s, e) =>
//            {
//                if (textBox.Text == placeholder)
//                {
//                    textBox.Text = "";
//                    textBox.ForeColor = Color.Black;
//                }
//            };

//            textBox.LostFocus += (s, e) =>
//            {
//                if (string.IsNullOrWhiteSpace(textBox.Text))
//                {
//                    textBox.Text = placeholder;
//                    textBox.ForeColor = Color.Gray;
//                }
//            };
//        }

//        private async void btnDangNhap_Click(object sender, EventArgs e)
//        {
//            string email = txtEmail.Text.Trim();
//            string matKhau = txtMatKhau.Text.Trim();

//            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
//            {
//                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            bool dangNhapThanhCong = await XacThucDangNhap(email, matKhau);

//            if (dangNhapThanhCong)
//            {
//                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                // TODO: Chuyển sang form chính của ứng dụng
//                // this.Hide();
//                // new MainForm().Show();
//            }
//            else
//            {
//                MessageBox.Show("Email hoặc Mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private async Task<bool> XacThucDangNhap(string email, string matKhau)
//        {
//            try
//            {
//                string matKhauHash = HashPassword(matKhau);

//                var danhSachTaiKhoan = await DBServices.GET<TaiKhoan>("TaiKhoan");
//                if (danhSachTaiKhoan == null)
//                {
//                    MessageBox.Show("Không thể lấy dữ liệu từ máy chủ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return false;
//                }

//                foreach (var tk in danhSachTaiKhoan)
//                {
//                    if (tk.Email == email && tk.MatKhau == matKhauHash)
//                    {
//                        return true;
//                    }
//                }

//                return false;
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return false;
//            }
//        }

//        // Hàm băm mật khẩu bằng SHA256
//        private string HashPassword(string password)
//        {
//            using (SHA256 sha256 = SHA256.Create())
//            {
//                byte[] bytes = Encoding.UTF8.GetBytes(password);
//                byte[] hash = sha256.ComputeHash(bytes);
//                return Convert.ToBase64String(hash);
//            }
//        }

//        // Xử lý sự kiện khi bấm vào LinkLabel "Đăng ký"
//        private void linklabelDangKy_Click(object sender, LinkLabelLinkClickedEventArgs e)
//        {
//            Dangky dangkyForm = new Dangky();
//            dangkyForm.Show();
//        }
//    }
//}
