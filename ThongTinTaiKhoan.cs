using Google.Cloud.Firestore;
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
using TraSuaApp.Models;
using TraSuaApp.Services;

namespace TraSuaApp.Views
{
    public partial class ThongTinTaiKhoan : Form
    {
        private FirestoreDb db = DBServices.Connect();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
            this.guna2Panel1.MouseDown += Form_MouseDown;
            this.Padding = new Padding(3);
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

        private async void btnDoiTen_Click(object sender, EventArgs e)
        {
            string tenMoi = tbSuaTenTK.Text;  // Nhập tên mới

            if (string.IsNullOrWhiteSpace(tenMoi) || string.IsNullOrWhiteSpace(tenMoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await DoiTenKhachHangAsync(lblMaKH.Text, tenMoi);
        }

        // Hàm đổi tên khách hàng
        private async Task<bool> DoiTenKhachHangAsync(string maKH, string tenMoi)
        {
            try
            {
                // Truy vấn khách hàng trong Firestore
                DocumentReference docRef = db.Collection("KhachHang").Document(maKH);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    // Cập nhật tên khách hàng
                    await docRef.UpdateAsync(new Dictionary<string, object>
                    {
                        { "HoTen", tenMoi }
                    });

                    MessageBox.Show("Đổi tên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Tải lại form để cập nhật thông tin
                    ThongTinTaiKhoan_Load(this, EventArgs.Empty);

                    return true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đổi tên khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Hàm lấy thông tin khách hàng từ Firestore

        private async void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            string maKH = Program.MaKH;
            await GetKhachHangAsync(maKH);
            LoadLichSuDonHang();
        }

        private async Task GetKhachHangAsync(string maKH)
        {
            try
            {
                // Truy vấn Firestore
                DocumentReference docRef = db.Collection("KhachHang").Document(maKH);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    // Lấy dữ liệu từ snapshot
                    var khachHang = snapshot.ToDictionary();
                    lblMaKH.Text = maKH; // Lấy luôn Document ID
                    lblTenKH.Text = khachHang["HoTen"].ToString();
                    lblSDT.Text = khachHang["SoDienThoai"].ToString();
                    lblDiemTichLuy.Text = khachHang["DiemTichLuy"].ToString();

                    // Lấy mã tài khoản để tìm email
                    if (khachHang.ContainsKey("MaTK"))
                    {
                        string maTK = khachHang["MaTK"].ToString();
                        string email = await GetEmailAsync(maTK);
                        lblEmail.Text = email;
                    }
                    else
                    {
                        lblEmail.Text = "Không có tài khoản";
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm lấy email từ bảng TaiKhoan
        private async Task<string> GetEmailAsync(string maTK)
        {
            try
            {
                DocumentReference docRef = db.Collection("TaiKhoan").Document(maTK);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    var taiKhoan = snapshot.ToDictionary();
                    return taiKhoan.ContainsKey("Email") ? taiKhoan["Email"].ToString() : "Không có email";
                }
                return "Không tìm thấy tài khoản";
            }
            catch (Exception ex)
            {
                return $"Lỗi lấy email: {ex.Message}";
            }
        }

        // Hàm tạo Panel hiển thị đơn hàng
        private Panel CreateOrderPanel(string maDH, string ngayDat, string tongTien, string trangThai, string chietKhau)
        {
            Panel panel = new Panel
            {
                Width = 537,
                Height = 164,
                BackColor = Color.Bisque,
                Margin = new Padding(5)
            };

            Label lblMaDH = new Label
            {
                Text = $"Mã DH: {maDH}",
                AutoSize = true,
                Location = new System.Drawing.Point(17, 15)
            };

            Label lblNgayDat = new Label
            {
                Text = $"Ngày đặt: {ngayDat}",
                AutoSize = true,
                Location = new System.Drawing.Point(17, 53)
            };

            Label lblTongTien = new Label
            {
                Text = $"Tổng tiền: {tongTien}",
                AutoSize = true,
                Location = new System.Drawing.Point(328, 121),
                Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
            };

            Label lblTrangThai = new Label
            {
                Text = $"Trạng thái: {trangThai}",
                AutoSize = true,
                Location = new System.Drawing.Point(17, 89)
            };

            Label lblChietKhau = new Label
            {
                Text = $"Chiết khấu: {chietKhau}",
                AutoSize = true,
                Location = new System.Drawing.Point(17, 124)
            };

            panel.Controls.Add(lblChietKhau);
            panel.Controls.Add(lblMaDH);
            panel.Controls.Add(lblNgayDat);
            panel.Controls.Add(lblTongTien);
            panel.Controls.Add(lblTrangThai);

            return panel;
        }


        // Hàm load lịch sử đơn hàng
        private async void LoadLichSuDonHang()
        {
            try
            {
                // Lấy MaKH từ Program
                string maKH = Program.MaKH;

                // Truy vấn đơn hàng từ Firestore
                CollectionReference donHangRef = db.Collection("DonHang");
                Query query = donHangRef.WhereEqualTo("MaKH", maKH);
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                // Xóa các đơn hàng cũ trong FlowLayoutPanel
                flpLichSuMuaHang.Controls.Clear();

                // Duyệt qua từng đơn hàng
                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    if (doc.Exists)
                    {
                        var donHang = doc.ToDictionary();
                        string maDH = doc.Id;
                        string tongTien = donHang.ContainsKey("TongTien") ? donHang["TongTien"].ToString() : "0";
                        string trangThai = donHang.ContainsKey("TrangThai") ? donHang["TrangThai"].ToString() : "Không rõ";
                        string chietKhau = "0%";

                        // Xử lý ngày đặt (Timestamp -> DateTime)
                        string ngayDat = "Không có";
                        if (donHang.ContainsKey("NgayDat") && donHang["NgayDat"] is Timestamp timestamp)
                        {
                            DateTime utcDateTime = timestamp.ToDateTime();
                            DateTime localDateTime = utcDateTime.ToLocalTime(); // Chuyển đổi sang giờ địa phương
                            ngayDat = localDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                        }

                        // Kiểm tra và lấy thông tin khuyến mãi
                        if (donHang.ContainsKey("MaKM"))
                        {
                            string maKM = donHang["MaKM"].ToString();
                            if (!string.IsNullOrEmpty(maKM))
                            {
                                DocumentReference kmRef = db.Collection("KhuyenMai").Document(maKM);
                                DocumentSnapshot kmDoc = await kmRef.GetSnapshotAsync();
                                if (kmDoc.Exists && kmDoc.ContainsField("ChietKhau"))
                                {
                                    chietKhau = $"{kmDoc.GetValue<int>("ChietKhau")}%";
                                }
                            }
                        }

                        // Tạo panel hiển thị đơn hàng
                        Panel panel = CreateOrderPanel(maDH, ngayDat, tongTien, trangThai, chietKhau);
                        flpLichSuMuaHang.Controls.Add(panel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch sử đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ControlBox9_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng tất cả các form và thoát chương trình
        }
    }

}
