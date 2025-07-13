using Firebase.Auth;
using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Services;
using TraSuaApp.Views.Admin;

namespace TraSuaApp.Views
{
    public partial class Dangnhap : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public static string MaQTV = "";
        public static string TenQTV = "";
        FirestoreDb db = DBServices.Connect();

        public Dangnhap()
        {
            InitializeComponent();
        }

        private void BoGocPanel()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            Rectangle bounds = guna2GradientPanel1.ClientRectangle;

            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            guna2GradientPanel1.Region = new Region(path);
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtEmail, "Nhập email");
            SetPlaceholder(txtMatKhau, "Nhập mật khẩu");

            BoGocPanel();

            // Tự động đăng nhập nếu có dữ liệu đã lưu
            /*string savedEmail = Properties.Settings.Default.Email;
            string savedPassword = Properties.Settings.Default.MatKhau;

            if (!string.IsNullOrEmpty(savedEmail) && !string.IsNullOrEmpty(savedPassword))
            {
                bool ok = await XacThucDangNhap(savedEmail, savedPassword);
                if (ok)
                {
                    MessageBox.Show($"Tự động đăng nhập thành công, Chào {TenQTV}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    try
                    {
                        Main AdminForm = new Main(MaQTV);
                        AdminForm.Show();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi xảy ra khi khởi tạo:\n{ex.Message}\n{ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Nếu thông tin sai, xóa đi để tránh lỗi lần sau
                    Properties.Settings.Default.Email = "";
                    Properties.Settings.Default.MatKhau = "";
                    Properties.Settings.Default.Save();
                }
            }*/
        }

        private void SetPlaceholder(Guna.UI2.WinForms.Guna2TextBox textBox, string placeholder)
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
                Properties.Settings.Default.Email = email;
                Properties.Settings.Default.MatKhau = matKhau;
                Properties.Settings.Default.Save();

                MessageBox.Show($"Đăng nhập thành công, Chào {TenQTV}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                try
                {
                    Main AdminForm = new Main(MaQTV);
                    AdminForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xảy ra khi khởi tạo:\n{ex.Message}\n{ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAQKaZZ7DQw2ktZ_2sFaQsi_f0oJRbm_1o"));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, matKhau);

                if (auth != null && !string.IsNullOrEmpty(auth.FirebaseToken))
                {
                    // Xác thực thành công, bây giờ truy vấn Firestore

                    // 1. Tìm TaiKhoan có Email = email đăng nhập
                    var taiKhoanQuery = await db.Collection("TaiKhoan")
                                                .WhereEqualTo("Email", email)
                                                .GetSnapshotAsync();

                    if (taiKhoanQuery.Count == 0)
                        return false; // Không tìm thấy tài khoản

                    var taiKhoanDoc = taiKhoanQuery.Documents.First();
                    string taiKhoanID = taiKhoanDoc.Id;

                    // 2. Tìm QuanTriVien có MaTK = ID của tài khoản
                    var QTVQuery = await db.Collection("QuanTriVien")
                                                 .WhereEqualTo("MaTK", taiKhoanID)
                                                 .GetSnapshotAsync();

                    if (QTVQuery.Count == 0)
                        return false; // Không tìm thấy QuanTriVien

                    var QTVDoc = QTVQuery.Documents.First();
                    string maQTV = QTVDoc.Id;
                    string tenQTV = QTVDoc.GetValue<string>("HoTen");

                    // 3. Lưu vào biến toàn cục
                    MaQTV = maQTV;
                    TenQTV = tenQTV;

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        // Xử lý sự kiện khi bấm "Đăng ký"
        private void linklabelDangKy_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky dangkyForm = new Dangky();
            dangkyForm.Show();
        }

        // Xử lý sự kiện khi bấm "Quen mat khau"
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Quenmatkhau quenmk = new Quenmatkhau();
            quenmk.Show();
        }
    }
}
