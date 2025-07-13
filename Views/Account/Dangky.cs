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
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using TraSuaApp.Services;

namespace TraSuaApp.Views
{
    public partial class Dangky : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Dangky()
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

        private void DangKy_Load(object sender, EventArgs e)
        {
            BoGocPanel();
        }

        private const string ApiKey = "AIzaSyAQKaZZ7DQw2ktZ_2sFaQsi_f0oJRbm_1o";

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string hoTen = txtTenQTV.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();

            FirestoreDb db = DBServices.Connect();
            if (db == null) return;

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

            CollectionReference colRef = db.Collection("TaiKhoan");
            QuerySnapshot snapshot = await colRef.GetSnapshotAsync();

            bool emailDaTonTai = snapshot.Documents.Any(doc =>
            {
                if (doc.ContainsField("Email"))
                {
                    return doc.GetValue<string>("Email") == email;
                }
                return false;
            });

            if (emailDaTonTai)
            {
                MessageBox.Show("Email đã tồn tại trong hệ thống, vui lòng nhập email khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Nếu qua tất cả kiểm tra, tiến hành đăng ký
            await DangKyTaiKhoanQTV(email, matKhau, hoTen, soDienThoai);
        }

        public async Task DangKyTaiKhoanQTV(string email, string matKhau, string hoTen, string soDienThoai)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, matKhau);
                await authProvider.SendEmailVerificationAsync(auth.FirebaseToken);
                // MessageBox.Show("Đã gửi email xác minh. Vui lòng kiểm tra hộp thư để kích hoạt tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FirestoreDb db = DBServices.Connect();
                if (db == null) return;

                // 1. Tạo tài khoản
                // Truy vấn tất cả mã tài khoản hiện có
                var taiKhoanSnapshot = await db.Collection("TaiKhoan").GetSnapshotAsync();

                // Tìm mã tài khoản lớn nhất
                int maxSo = 0;
                foreach (var doc in taiKhoanSnapshot.Documents)
                {
                    string maTK = doc.Id; // ví dụ: TK001
                    if (maTK.StartsWith("TK") && int.TryParse(maTK.Substring(2), out int so))
                    {
                        if (so > maxSo) maxSo = so;
                    }
                }

                // Tạo mã tài khoản mới
                int soMoi = maxSo + 1;
                string maTKMoi = "TK" + soMoi.ToString().PadLeft(3, '0');

                // Tạo tài khoản mới
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    Email = email,
                    Quyen = "Admin"
                };
                await DBServices.POST(maTKMoi, "TaiKhoan", taiKhoan);

                // 2.Tạo QTV
                // Truy vấn tất cả mã QTV hiện có
                var QTVSnapshot = await db.Collection("QuanTriVien").GetSnapshotAsync();

                // Tìm mã khách hàng lớn nhất
                maxSo = 0;
                foreach (var doc in QTVSnapshot.Documents)
                {
                    string maKH = doc.Id; 
                    if (maKH.StartsWith("QTV") && int.TryParse(maKH.Substring(2), out int so))
                    {
                        if (so > maxSo) maxSo = so;
                    }
                }

                // Tạo mã QTV mới
                soMoi = maxSo + 1;
                string maQTVMoi = "QTV" + soMoi.ToString().PadLeft(3, '0');

                // Tạo object QTV
                QuanTriVien qtv = new QuanTriVien
                {
                    MaTK = maTKMoi,
                    HoTen = hoTen,
                    SoDienThoai = soDienThoai,
                };
                await DBServices.POST(maQTVMoi, "QuanTriVien", qtv);

                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
