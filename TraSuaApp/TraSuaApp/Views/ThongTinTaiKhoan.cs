using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Services;
using TraSuaApp.Views;

namespace TraSuaApp.View
{
    public partial class ThongTinTaiKhoan : Form
    {
        private FirestoreDb db = DBServices.Connect();
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private async void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            string maKH = Dangnhap.MaKH;
            await GetKhachHangAsync(maKH);
            LoadLichSuDonHang();
        }

        private async void btnSuaTenTK_Click(object sender, EventArgs e)
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
            Guna2GradientPanel panel = new Guna2GradientPanel
            {
                BorderRadius = 50,
                FillColor = Color.FromArgb(115, 192, 255),
                FillColor2 = Color.FromArgb(255, 207, 144),
                Size = new Size(568, 150),
            };

            // Thiết lập các cạnh tùy chỉnh
            panel.CustomizableEdges = new CustomizableEdges
            {
                BottomRight = false,
                TopRight = false,
                TopLeft = true,
                BottomLeft = true
            };

            // MaDH:
            Label lblMaDH = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                Location = new Point(49, 22),
                Size = new Size(81, 30),
                Text = "MaDH:",
            };

            //NgayDat:
            Label lblNgayDat = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                Location = new Point(49, 60),
                Size = new Size(108, 30),
                Text = "Ngày đặt:",
            };

            //TrangThai:
            Label lblTrangThai = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                Location = new Point(49, 99),
                Size = new Size(117, 30),
                Text = "Trạng thái:",
            };

            Label lblMaDonHang = new Label
            {
                Text = $"{maDH}",
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(175, 22),
            };

            Label lblTongTien = new Label
            {
                Text = $"{tongTien} VND",
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0),
                ForeColor = Color.White,
                Location = new Point(350, 6),
                Size = new Size(175, 38),
            };

            Label lbltrangthai = new Label
            {
                Text = $"{trangThai}",
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(175, 99),
                Size = new Size(126, 30),
            };

            Label lblNDat = new Label
            {
                Text = $"{ngayDat}",
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 11F),
                Location = new Point(175, 60),
                Size = new Size(127, 30),
            };

            panel.Controls.Add(lblMaDonHang);
            panel.Controls.Add(lblMaDH);
            panel.Controls.Add(lblNDat);
            panel.Controls.Add(lblTongTien);
            panel.Controls.Add(lblTrangThai);
            panel.Controls.Add(lbltrangthai);
            panel.Controls.Add(lblNgayDat);

            return panel;
        }


        // Hàm load lịch sử đơn hàng
        private async void LoadLichSuDonHang()
        {
            try
            {
                // Lấy MaKH từ Program
                string maKH = Dangnhap.MaKH;

                // Truy vấn đơn hàng từ Firestore
                CollectionReference donHangRef = db.Collection("DonHang");
                Query query = donHangRef.WhereEqualTo("MaKH", maKH);
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                // Xóa các đơn hàng cũ trong FlowLayoutPanel
                flpLichSuDonHang.Controls.Clear();

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
                        flpLichSuDonHang.Controls.Add(panel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch sử đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
