using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
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
using TraSuaApp.Models;
using TraSuaApp.Models.Admin;
using TraSuaApp.Services;
using TraSuaApp.Views;

namespace TraSuaApp.View
{
    public partial class DonHangUser : Form
    {
        public List<ChiTietDonHangTam> danhSachTam = new();

        public DonHangUser()
        {
            InitializeComponent();
            KiemTraTrong(flowDonHang);
            CapNhapScrollMinSize(flowDonHang);
        }

        private void KiemTraTrong(FlowLayoutPanel flowPanel)
        {
            // Kiểm tra nếu không có control nào bên trong
            foreach (Control ct in flowPanel.Controls)
            {
                if (ct is Panel)
                {
                    lblTrong.Visible = false;  // An flowLayoutPanel
                    return;
                }
            }
            lblTrong.Visible = true;   // HienThi nếu có control
        }

        private async void LoadImageAsync(string imageUrl, PictureBox pictureBox)
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var imageBytes = await client.GetByteArrayAsync(imageUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}");
            }
        }


        // Hàm tính MinsizeScroll cho flowDonHang
        private void CapNhapScrollMinSize(FlowLayoutPanel flp)
        {
            flp.AutoScrollMinSize = new Size(0, flp.Controls.Count * 175); 
        }

        public void ThemChiTietVaoGiaoDien(ChiTietDonHangTam ct)
        {
            CapNhapScrollMinSize(flowDonHang);
            // Kiểm tra sản phẩm đã có chưa (dựa trên tên và size)
            var tonTai = danhSachTam.FirstOrDefault(x => x.TenSP == ct.TenSP && x.Size == ct.Size);

            if (tonTai != null)
            {
                tonTai.SoLuong += ct.SoLuong;
                tonTai.ThanhTien = tonTai.GiaBan * tonTai.SoLuong;

                // Cập nhật giao diện nếu cần (ví dụ bạn cần tìm control liên quan và cập nhật số lượng & tiền)
                // Gợi ý: Có thể lưu mapping Control <=> chi tiết nếu muốn cập nhật chính xác
                CapNhatGiaoDienChoSanPham(tonTai);
            }
            else
            {
                danhSachTam.Add(ct);
                lblTrong.Visible = false;
                ThemPanelMoi(ct); // Phương thức thêm panel mới vào FlowLayoutPanel
            }
            CapNhatTongTien();
        }

        private void CapNhatGiaoDienChoSanPham(ChiTietDonHangTam sp)
        {
            CapNhapScrollMinSize(flowDonHang);
            KiemTraTrong(flowDonHang);
            foreach (Control c in flowDonHang.Controls)
            {
                if (c is Panel panel && panel.Tag is ChiTietDonHangTam ct && ct.TenSP == sp.TenSP && ct.Size == sp.Size)
                {
                    foreach (Control sub in panel.Controls)
                    {
                        if (sub is TextBox txt && txt.Tag?.ToString() == "SoLuong")
                            txt.Text = sp.SoLuong.ToString();
                        else if (sub is Label lbl && lbl.Tag?.ToString() == "ThanhTien")
                            lbl.Text = sp.ThanhTien.ToString("N0");
                    }
                }
            }
            CapNhatTongTien();
        }

        public void ThemPanelMoi(ChiTietDonHangTam ct)
        {
            var panel = new Panel
            {
                Size = new Size(954, 150),
                BackColor = Color.Transparent,
                Margin = new Padding(3, 3, 3, 15)
            };

            var pic = new Guna2CirclePictureBox
            {
                Size = new Size(149, 149),
                Location = new Point(31, 0),
                Margin = new Padding(3,3,3,25),
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            string imageUrl = ct.HinhAnh; // Lấy URL ảnh từ Firestore

            if (!string.IsNullOrEmpty(imageUrl))
            {
                // Thử tải ảnh bằng cách sử dụng HttpClient
                LoadImageAsync(imageUrl, pic);
            }
            else
            {
                MessageBox.Show("Không có URL ảnh để tải.");
            }

            var lblTen = new Label
            {
                Text = $"{ct.TenSP}",
                AutoSize = false,
                Size = new Size(114, 67),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(187, 50),
                TextAlign = ContentAlignment.MiddleCenter,
            };

            RadioButton rbS = new RadioButton { Text = "S", Location = new Point(363, 25), AutoSize = true, ForeColor = Color.Peru, Font = new Font("Segoe UI Black", 10, FontStyle.Bold) };
            RadioButton rbM = new RadioButton { Text = "M", Location = new Point(363, 63), AutoSize = true, ForeColor = Color.DarkBlue, Font = new Font("Segoe UI Black", 10, FontStyle.Bold) };
            RadioButton rbL = new RadioButton { Text = "L", Location = new Point(363, 101), AutoSize = true, ForeColor = Color.Brown, Font = new Font("Segoe UI Black", 10, FontStyle.Bold) };

            // Gắn CheckedChanged cho RadioButton
            rbS.CheckedChanged += (s, e) => XuLyThayDoiSize(ct, "S", panel);
            rbM.CheckedChanged += (s, e) => XuLyThayDoiSize(ct, "M", panel);
            rbL.CheckedChanged += (s, e) => XuLyThayDoiSize(ct, "L", panel);

            // Chọn size mặc định
            if (ct.Size == "M") rbM.Checked = true;
            else if (ct.Size == "L") rbL.Checked = true;
            else rbS.Checked = true;

            // Nút trừ
            Button btnTru = new Button { Text = "-", Size = new Size(43, 43), Location = new Point(452, 68), BackColor = Color.Gray, Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            // TextBox số lượng
            Guna2HtmlLabel lbSoLuong = new Guna2HtmlLabel
            {
                Text = ct.SoLuong.ToString(),
                AutoSize = false,
                Size = new Size(17, 34),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(508, 72),
            };

            // Nút cộng
            Button btnCong = new Button { Text = "+", Size = new Size(43, 43), Location = new Point(541, 68), BackColor = Color.Gray, Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            // Giá
            Label lblThanhTien = new Label
            {
                Text = ct.ThanhTien.ToString("N0") + " VND",
                Font = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Underline),
                ForeColor = Color.Black,
                Location = new Point(655, 68),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight,
            };

            lbSoLuong.Tag = "SoLuong";
            lblThanhTien.Tag = "ThanhTien";

            // Xử lý tăng/giảm số lượng
            btnCong.Click += (s, e) =>
            {
                int sl = int.TryParse(lbSoLuong.Text, out var val) ? val : 1;
                sl++;
                lbSoLuong.Text = sl.ToString();
                ct.SoLuong = sl;
                ct.ThanhTien = TinhThanhTienTheoSize(sl, ct.GiaBan, ct.Size);
                lblThanhTien.Text = ct.ThanhTien.ToString("N0") + " VND";
                CapNhatTongTien();
                CapNhapScrollMinSize(flowDonHang);
            };

            btnTru.Click += (s, e) =>
            {
                int sl = int.TryParse(lbSoLuong.Text, out var val) ? val : 1;
                if (sl > 1)
                {
                    sl--;
                    lbSoLuong.Text = sl.ToString();
                    ct.SoLuong = sl;
                    ct.ThanhTien = TinhThanhTienTheoSize(sl, ct.GiaBan, ct.Size);
                    lblThanhTien.Text = ct.ThanhTien.ToString("N0") + " VND";
                    CapNhatTongTien();
                }
                else
                {
                    // Xóa khỏi danh sách dữ liệu
                    danhSachTam.Remove(ct);

                    // Xóa khỏi giao diện
                    flowDonHang.Controls.Remove(panel);
                    KiemTraTrong(flowDonHang);
                    CapNhatTongTien(); // cập nhật lại sau khi xóa
                }
            };

            Guna2ImageButton btnXoa = new Guna2ImageButton
            {
                Image = Properties.Resources.thungrac,
                Size = new Size(52, 67),
                Location = new Point(863, 50),
                ImageSize = new Size(40,40)
            };


            // Thêm các control vào panel
            panel.Controls.Add(btnXoa);
            panel.Controls.Add(pic);
            panel.Controls.Add(lblTen);
            panel.Controls.Add(rbS);
            panel.Controls.Add(rbM);
            panel.Controls.Add(rbL);
            panel.Controls.Add(btnTru);
            panel.Controls.Add(lbSoLuong);
            panel.Controls.Add(btnCong);
            panel.Controls.Add(lblThanhTien);

            // Thêm panel vào FlowLayoutPanel danh sách đơn hàng
            flowDonHang.Controls.Add(panel);
            panel.Tag = ct;

            btnXoa.Click += (s, e) =>
            {
                // Xóa khỏi danh sách dữ liệu
                danhSachTam.Remove(ct);

                // Xóa khỏi giao diện
                flowDonHang.Controls.Remove(panel);
                KiemTraTrong(flowDonHang);
                CapNhatTongTien(); // cập nhật lại sau khi xóa
            };
        }

        private void XuLyThayDoiSize(ChiTietDonHangTam ct, string newSize, Panel panelHienTai)
        {
            if (ct.Size == newSize) return; // Không thay đổi

            // Tìm sản phẩm trùng tên và size mới
            var trung = danhSachTam.FirstOrDefault(x => x != ct && x.TenSP == ct.TenSP && x.Size == newSize);

            if (trung != null)
            {
                // Gộp số lượng
                trung.SoLuong += ct.SoLuong;
                trung.Size = newSize;
                trung.ThanhTien = TinhThanhTienTheoSize(trung.SoLuong, trung.GiaBan, newSize);

                // Xóa ct cũ khỏi danh sách
                danhSachTam.Remove(ct);

                // Xóa panel cũ khỏi giao diện
                flowDonHang.Controls.Remove(panelHienTai);

                // Cập nhật lại giao diện
                CapNhatGiaoDienChoSanPham(trung);
            }
            else
            {
                // Chưa có, chỉ cập nhật size và thành tiền
                ct.Size = newSize;
                ct.ThanhTien = TinhThanhTienTheoSize(ct.SoLuong, ct.GiaBan, newSize);

                // Cập nhật lại giao diện cho panel hiện tại
                foreach (Control c in panelHienTai.Controls)
                {
                    if (c is Label lbl && lbl.Tag?.ToString() == "ThanhTien")
                    {
                        lbl.Text = ct.ThanhTien.ToString("N0") + " VND";
                        break;
                        CapNhatTongTien();
                    }
                }
            }
        }

        private double TinhThanhTienTheoSize(int soLuong, double giaBan, string size)
        {
            switch (size)
            {
                case "M": return soLuong * giaBan * 1.3;
                case "L": return soLuong * giaBan * 1.5;
                default: return soLuong * giaBan;
            }
        }

        private void CapNhatTongTien()
        {
            double tongTien = danhSachTam.Sum(ct => ct.ThanhTien);
            lblTongTien.Text = $"{tongTien:N0}" + " VND";
        }

        private async void btnThanhToan_Click(object sender, EventArgs e)
        {
            FirestoreDb db = DBServices.Connect();
            if (db == null) return;

            try
            {
                // 1. Truy vấn tất cả mã đơn hàng hiện có
                var donHangSnapshot = await db.Collection("DonHang").GetSnapshotAsync();

                // 2. Tìm mã đơn hàng lớn nhất
                int maxSo = 0;
                foreach (var doc in donHangSnapshot.Documents)
                {
                    string maDon = doc.Id; // ví dụ: DH001
                    if (maDon.StartsWith("DH") && int.TryParse(maDon.Substring(2), out int so))
                    {
                        if (so > maxSo) maxSo = so;
                    }
                }

                // 3. Tạo mã đơn hàng mới
                int soMoi = maxSo + 1;
                string maDonMoi = "DH" + soMoi.ToString().PadLeft(3, '0');

                // 4. Tính tổng tiền
                double tongTien = danhSachTam.Sum(ct => ct.ThanhTien);

                // 5. Tạo object đơn hàng
                var donHang = new DonHang
                {
                    NgayDat = Timestamp.FromDateTime(DateTime.UtcNow),
                    TongTien = tongTien,
                    TrangThai = "Chưa thanh toán",
                    MaKH = Dangnhap.MaKH
                };

                // 6. Lưu đơn hàng vào Firestore
                DocumentReference donHangRef = db.Collection("DonHang").Document(maDonMoi);
                await donHangRef.SetAsync(donHang);

                // 7. Thêm chi tiết đơn hàng vào collection con: DonHang/{MaDH}/ChiTietDonHang
                CollectionReference chiTietCollection = donHangRef.Collection("ChiTietDonHang");

                int iChiTiet = 1;
                foreach (var item in danhSachTam)
                {
                    string chiTietId = "CH" + iChiTiet.ToString().PadLeft(3, '0');
                    iChiTiet++;
                    DocumentReference spRef = db.Collection("SanPham").Document(item.MaSP);
                    var ct = new Dictionary<string, object>
                    {
                        {"MaDH", donHangRef },
                        { "MaSP", spRef },
                        { "SoLuong", item.SoLuong },
                        { "ThanhTien", item.ThanhTien },
                        { "Size", item.Size },
                    };

                    await chiTietCollection.Document(chiTietId).SetAsync(ct);

                    // Mở form mới sau khi đóng tất cả form cũ
                    Thanhtoan thanhtoan = new Thanhtoan(maDonMoi, 0);  // Khởi tạo form mới
                    Program.danhSachSPTam = danhSachTam; // Lưu danh sách sản phẩm tạm vào biến toàn cục

                    panel1.Controls.Clear();

                    thanhtoan.TopLevel = false;
                    thanhtoan.Dock = DockStyle.Fill;

                    // Thêm form con vào panel1
                    panel1.Controls.Add(thanhtoan);

                    // Hiển thị form con
                    thanhtoan.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnChonBan_Click(object sender, EventArgs e)
        {
            FirestoreDb db = DBServices.Connect();
            if (db == null) return;

            string maDonMoi = "";

            try
            {
                // 1. Truy vấn tất cả mã đơn hàng hiện có
                var donHangSnapshot = await db.Collection("DonHang").GetSnapshotAsync();

                // 2. Tìm mã đơn hàng lớn nhất
                int maxSo = 0;
                foreach (var doc in donHangSnapshot.Documents)
                {
                    string maDon = doc.Id; // ví dụ: DH001
                    if (maDon.StartsWith("DH") && int.TryParse(maDon.Substring(2), out int so))
                    {
                        if (so > maxSo) maxSo = so;
                    }
                }

                // 3. Tạo mã đơn hàng mới
                int soMoi = maxSo + 1;
                maDonMoi = "DH" + soMoi.ToString().PadLeft(3, '0');

                // 4. Tính tổng tiền
                double tongTien = danhSachTam.Sum(ct => ct.ThanhTien);

                // 5. Tạo object đơn hàng
                var donHang = new DonHang
                {
                    NgayDat = Timestamp.FromDateTime(DateTime.UtcNow),
                    TongTien = tongTien,
                    TrangThai = "Chưa thanh toán",
                    MaKH = Dangnhap.MaKH
                };

                // 6. Lưu đơn hàng vào Firestore
                DocumentReference donHangRef = db.Collection("DonHang").Document(maDonMoi);
                await donHangRef.SetAsync(donHang);

                // 7. Thêm chi tiết đơn hàng vào collection con: DonHang/{MaDH}/ChiTietDonHang
                CollectionReference chiTietCollection = donHangRef.Collection("ChiTietDonHang");

                int iChiTiet = 1;
                foreach (var item in danhSachTam)
                {
                    string chiTietId = "CH" + iChiTiet.ToString().PadLeft(3, '0');
                    iChiTiet++;
                    DocumentReference spRef = db.Collection("SanPham").Document(item.MaSP);
                    var ct = new Dictionary<string, object>
                    {
                        {"MaDH", donHangRef },
                        { "MaSP", spRef },
                        { "SoLuong", item.SoLuong },
                        { "ThanhTien", item.ThanhTien },
                        { "Size", item.Size },
                    };

                    await chiTietCollection.Document(chiTietId).SetAsync(ct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Mở form mới sau khi đóng tất cả form cũ
            Datban datban = new Datban(maDonMoi);  // Khởi tạo form mới
            Program.danhSachSPTam = danhSachTam; // Lưu danh sách sản phẩm tạm vào biến toàn cục

            panel1.Controls.Clear(); 

            datban.TopLevel = false;
            datban.Dock = DockStyle.Fill;

            // Thêm form con vào panel1
            panel1.Controls.Add(datban);

            // Hiển thị form con
            datban.Show();
        }
    }
}
