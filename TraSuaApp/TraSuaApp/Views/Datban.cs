using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Models.Admin;
using TraSuaApp.Services;
using TraSuaApp.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TraSuaApp.Views
{
    public partial class Datban : Form
    {
        private string MaDH;
        private int soLuongLy = -1;
        public Datban(string maDonMoi) //string maDonMoi truyền từ Form trước là Form ChiTietDonHangUser
        {
            InitializeComponent();
            this.MaDH = maDonMoi;
            this.Load += Ban_LoadAsync;
        }

        private async void Ban_LoadAsync(object sender, EventArgs e)
        {
            soLuongLy = await GetTongSoLuongLy(MaDH); // Lấy xong mới Load bàn theo logic phù hợp
            await LoadBan(); // người dùng có thể bấm chọn bàn sau khi tính số lượng ly xong --> xử lý logic chọn bàn
        }

        public static async Task<int> GetTongSoLuongLy(string MaDH)
        {
            FirestoreDb db = DBServices.Connect();
            if (db == null) return 0;

            try
            {
                DocumentReference donHangRef = db.Collection("DonHang").Document(MaDH);
                CollectionReference chiTietCollection = donHangRef.Collection("ChiTietDonHang");

                QuerySnapshot snapshot = await chiTietCollection.GetSnapshotAsync();

                int tongSoLuong = 0;
                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    if (doc.Exists)
                    {
                        ChiTietDonHang chiTiet = doc.ConvertTo<ChiTietDonHang>();
                        tongSoLuong += chiTiet.SoLuong;
                    }
                }

                return tongSoLuong;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy tổng số lượng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private string selectedBanId = null;
        private List<global::Models.Admin.Ban> danhSachBan = new List<global::Models.Admin.Ban>();

        private async Task LoadBan(int sucChuaFilter = 0, string selected = "")
        {
            flowLayoutPanelBan.Controls.Clear();// Xóa control cũ

            // Lấy danh sách bàn từ Firestore
            danhSachBan = await DBServices.GET<global::Models.Admin.Ban>("Ban");

            if (sucChuaFilter > 0)
                danhSachBan = danhSachBan.Where(b => b.SucChua == sucChuaFilter).ToList();

            if (danhSachBan.Count == 0)
            {
                // Nếu không có bàn nào thỏa mãn, hiển thị thông báo
                MessageBox.Show($"Không tồn tại bàn với sức chứa {selected}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (var ban in danhSachBan)
            {
                int panelWidth = (flowLayoutPanelBan.ClientSize.Width - (2 * flowLayoutPanelBan.Padding.All) - (4 * 10)) / 3;

                Panel panel = new Panel
                {
                    Width = panelWidth,
                    Height = 150,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(255, 201, 137),
                    Margin = new Padding(5)
                };

                Label label1 = new Label
                {
                    Text = $"BÀN {ban.ID}",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    Location = new Point(1, 17),
                    AutoSize = true
                };

                Label label5 = new Label
                {
                    Text = ban.TrangThai,
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = ban.TrangThai.Contains("Trống") ? Color.DarkGreen : Color.Red,
                    Location = new Point(110, 17),
                    AutoSize = true
                };

                Label label4 = new Label
                {
                    Text = "Sức chứa tối đa",
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    Location = new Point(1, 60),
                    AutoSize = true
                };

                Label label3 = new Label
                {
                    Text = ban.SucChua.ToString(),
                    Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                    Location = new Point(130, 60),
                    AutoSize = true
                };

                var btnChon = new Guna.UI2.WinForms.Guna2GradientButton
                {
                    Text = "CHỌN",
                    Size = new Size(120, 45),
                    Location = new Point(100, 90),
                    BorderRadius = 20,
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    ForeColor = Color.White,
                    FillColor2 = Color.FromArgb(255, 128, 0), // Màu cam đậm
                    GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal,
                    Tag = ban.ID,
                    Name = "btnChon_" + ban.ID,
                    Cursor = Cursors.Hand,
                };

                btnChon.Click += btnChon_Click;

                panel.Controls.Add(label1);
                panel.Controls.Add(label5);
                panel.Controls.Add(label4);
                panel.Controls.Add(label3);
                panel.Controls.Add(btnChon);

                flowLayoutPanelBan.Controls.Add(panel);
            }

        }

        // Xử lý sự kiện lọc bàn theo comboBox
        private async void btnLoc_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();

            // Kiểm tra nếu chưa chọn gì từ ComboBox
            if (string.IsNullOrEmpty(selected))
            {
                MessageBox.Show("Vui lòng chọn số lượng sức chứa để lọc bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng hàm và không lọc
            }

            int sucChuaFilter = 0; // Mặc định lọc tất cả bàn

            // Kiểm tra giá trị người dùng chọn từ ComboBox
            switch (selected)
            {
                case "1 người":
                    sucChuaFilter = 1; // Lọc bàn có sức chứa 1 người
                    break;
                case "2 người":
                    sucChuaFilter = 2; // Lọc bàn có sức chứa 2 người
                    break;
                case "3 người":
                    sucChuaFilter = 3; // Lọc bàn có sức chứa 3 người
                    break;
                case "4 người":
                    sucChuaFilter = 4; // Lọc bàn có sức chứa 4 người
                    break;
                case "5 người":
                    sucChuaFilter = 5; // Lọc bàn có sức chứa 5 người
                    break;
                case "Tất cả":
                    sucChuaFilter = 0; // Hiện tất cả bàn
                    break;
            }

            // Gọi phương thức LoadBan với bộ lọc sức chứa
            await LoadBan(sucChuaFilter, selected);
        }

        // Xử lý sự kiện khi người dùng chọn bàn
        private List<global::Models.Admin.Ban> banDangChon = new List<global::Models.Admin.Ban>();
        private void btnChon_Click(object sender, EventArgs e)
        {
            if (soLuongLy == -1)
            {
                MessageBox.Show("Dữ liệu chưa sẵn sàng. Vui lòng thử lại sau.");
                return;
            }

            var button = sender as Guna.UI2.WinForms.Guna2GradientButton;
            string banId = button.Tag.ToString();

            global::Models.Admin.Ban ban = danhSachBan.FirstOrDefault(b => b.ID == banId);

            if (ban == null || ban.TrangThai != "Trống")
            {
                MessageBox.Show("Bàn không khả dụng.");
                return;
            }

            bool daChon = banDangChon.Any(b => b.ID == ban.ID);

            if (daChon)
            {
                // Bỏ chọn bàn
                banDangChon.RemoveAll(b => b.ID == ban.ID);
                //Đặt lại màu gốc
                button.FillColor = Color.FromArgb(94, 148, 255);
                button.FillColor2 = Color.FromArgb(255, 128, 0);
                // Đổi chữ trên nút thành "Chọn"
                button.Text = "CHỌN";
            }
            else
            {
                int tongSucChua = banDangChon.Sum(b => b.SucChua) + ban.SucChua;

                if (tongSucChua > soLuongLy + 2)
                {
                    MessageBox.Show($"Bạn chỉ đặt {soLuongLy} ly, nhưng tổng sức chứa của bàn đã vượt quá {soLuongLy + 2}. Vui lòng chọn bàn phù hợp hơn để tránh lãng phí chỗ.");
                    return;
                }

                // Thỏa điều kiện → thêm bàn
                banDangChon.Add(ban);
                button.FillColor = Color.FromArgb(255, 94, 0);        // Cam rất đậm
                button.FillColor2 = Color.FromArgb(230, 80, 10);       // Đỏ cam
                // Đổi chữ trên nút thành "Bỏ chọn"
                button.Text = "BỎ CHỌN";
            }

            // Cập nhật label hoặc log lại danh sách bàn đã chọn (nếu cần)
            selectedBanId = string.Join(", ", banDangChon.Select(b => b.ID));
        }

        private async Task<string> GetNextChiTietDatBanID()
        {
            FirestoreDb db = DBServices.Connect();
            if (db == null) return "CTB001"; // Mặc định nếu không kết nối được

            try
            {
                // Lấy tất cả các tài liệu từ collection "ChiTietDatBan"
                var chiTietDatBanSnapshot = await db.Collection("ChiTietDatBan").GetSnapshotAsync();

                // Tìm mã ChiTietDatBan lớn nhất
                int maxSo = 0;
                foreach (var doc in chiTietDatBanSnapshot.Documents)
                {
                    string id = doc.Id; // ID của ChiTietDatBan (ví dụ: CTB001)
                    if (id.StartsWith("CTB") && int.TryParse(id.Substring(3), out int so)) // Lấy phần số từ "CTBxxx"
                    {
                        if (so > maxSo) maxSo = so;
                    }
                }

                // Tạo ID mới
                int soMoi = maxSo + 1;
                string newID = "CTB" + soMoi.ToString().PadLeft(3, '0'); // Đảm bảo ID có 3 chữ số (CTB001, CTB002, ...)

                return newID;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy ID ChiTietDatBan: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "CTB001"; // Trả về mặc định nếu có lỗi
            }
        }

        private async void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (banDangChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thanh toán!");
                return;
            }

            try
            {
                // Cập nhật trạng thái của các bàn đã chọn trong Firestore
                foreach (var ban in banDangChon)
                {
                    await UpdateBanStatus(ban.ID, "Đã đặt"); // Hoặc trạng thái bạn muốn gán
                }

                // Lấy thông tin khách hàng (MaKH) và thời gian đặt bàn
                string maKH = Dangnhap.MaKH; // Cập nhật theo cách lấy MaKH từ hệ thống
                DateTime thoiGianDatBan = DateTime.Now.ToUniversalTime();
                string trangThaiDB = "Đang chờ xác nhận"; // Trạng thái mặc định khi đặt bàn
                int soNguoi = banDangChon.Sum(b => b.SucChua); // Tổng số người theo sức chứa của các bàn đã chọn

                // Chuyển DateTime thành Firestore Timestamp
                Timestamp firestoreThoiGianDatBan = Timestamp.FromDateTime(thoiGianDatBan);

                // Lấy ID của ChiTietDatBan mới
                string newID = await GetNextChiTietDatBanID();

                // Lưu thông tin vào ChiTietDatBan
                foreach (var ban in banDangChon)
                {
                    ChiTietDatBan chiTietDatBan = new ChiTietDatBan
                    {
                        MaKH = maKH,
                        MaBan = ban.ID,
                        ThoiGianDB = firestoreThoiGianDatBan,
                        TrangThaiDB = trangThaiDB,
                        SoNguoi = soNguoi
                    };

                    // Lưu vào Firestore
                    await DBServices.POST(newID, "ChiTietDatBan", chiTietDatBan);

                    // Tăng ID cho lần tiếp theo
                    newID = IncrementID(newID); // Tăng ID cho lần kế tiếp
                }

                // Sau khi thanh toán, có thể xóa danh sách bàn đã chọn
                banDangChon.Clear();
                selectedBanId = null;

                // Cập nhật lại giao diện (nếu cần)
                await LoadBan();

                // Mở form mới sau khi đóng tất cả form cũ
                Thanhtoan thanhtoan = new Thanhtoan(MaDH, 0);  // Khởi tạo form mới
                pnlHienThiHome.Controls.Clear();
                thanhtoan.TopLevel = false;
                thanhtoan.Dock = DockStyle.Fill;

                // Thêm form con vào panel1
                pnlHienThiHome.Controls.Add(thanhtoan);

                // Hiển thị form con
                thanhtoan.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức tăng ID lên 1
        private string IncrementID(string currentID)
        {
            // Lấy phần số trong ID (CTBxxx)
            string numberPart = currentID.Substring(3);  // Lấy phần số sau "CTB"
            int number = int.Parse(numberPart);
            number++; // Tăng số lên 1
            return "CTB" + number.ToString("D3"); // Đảm bảo số có 3 chữ số (CTB001, CTB002, ...)
        }

        // Lưu thông tin vào Firestore
        private async Task SaveChiTietDatBan(ChiTietDatBan chiTietDatBan)
        {
            FirestoreDb db = DBServices.Connect();
            if (db == null) return;

            try
            {
                // Lưu thông tin vào collection "ChiTietDatBan"
                await db.Collection("ChiTietDatBan").AddAsync(chiTietDatBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu chi tiết đặt bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task UpdateBanStatus(string banId, string trangThaiMoi)
        {
            FirestoreDb db = DBServices.Connect();
            if (db == null) return;

            try
            {
                DocumentReference banRef = db.Collection("Ban").Document(banId);
                await banRef.UpdateAsync("TrangThai", trangThaiMoi); // Cập nhật trạng thái của bàn
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật trạng thái bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
