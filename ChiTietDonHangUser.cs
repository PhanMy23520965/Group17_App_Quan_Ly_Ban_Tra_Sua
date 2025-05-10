using Google.Cloud.Firestore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Models;
using TraSuaApp.Services;
using TraSuaApp.Models.Admin;

namespace TraSuaApp
{
    
    public partial class ChiTietDonHangUser : Form
    {
        private Menu formSanPham;
        public List<ChiTietDonHangTam> danhSachTam = new();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public ChiTietDonHangUser()
        {
            InitializeComponent();
            this.guna2Panel1.MouseDown += Form_MouseDown;
            this.Padding = new Padding(3);
            formSanPham = new Menu(this);
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

        public void ThemChiTietVaoGiaoDien(ChiTietDonHangTam ct)
        {
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
                ThemPanelMoi(ct); // Phương thức thêm panel mới vào FlowLayoutPanel
            }
            CapNhatTongTien();


        }

        private void CapNhatGiaoDienChoSanPham(ChiTietDonHangTam sp)
        {
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
                Width = 658,
                Height = 165,
                BackColor = Color.Bisque,
                BorderStyle = BorderStyle.FixedSingle,
            };

            var pic = new PictureBox
            {
                Width = 143,
                Height = 160,
                Margin = new Padding(10),
                SizeMode = PictureBoxSizeMode.Zoom,
                Left = 10,
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
                AutoSize = true,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(177, 72)
            };

            RadioButton rbS = new RadioButton { Text = "S", Location = new Point(287, 23), AutoSize = true };
            RadioButton rbM = new RadioButton { Text = "M", Location = new Point(287, 68), AutoSize = true };
            RadioButton rbL = new RadioButton { Text = "L", Location = new Point(287, 110), AutoSize = true };

            // Gắn CheckedChanged cho RadioButton
            rbS.CheckedChanged += (s, e) => XuLyThayDoiSize(ct, "S", panel);
            rbM.CheckedChanged += (s, e) => XuLyThayDoiSize(ct, "M", panel);
            rbL.CheckedChanged += (s, e) => XuLyThayDoiSize(ct, "L", panel);

            // Chọn size mặc định
            if (ct.Size == "M") rbM.Checked = true;
            else if (ct.Size == "L") rbL.Checked = true;
            else rbS.Checked = true;

            // Label "Số lượng"
            Label lblSL = new Label { Text = "Số lượng", Location = new Point(389, 20), AutoSize = true };

            // Nút trừ
            Button btnTru = new Button { Text = "-", Width = 34, Height = 38, Location = new Point(347, 61), BackColor = Color.White };

            // TextBox số lượng
            TextBox txtSoLuong = new TextBox
            {
                Text = ct.SoLuong.ToString(),
                Width = 93,
                Height = 31,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Location = new Point(389, 61),
                TextAlign = HorizontalAlignment.Center
            };

            // Nút cộng
            Button btnCong = new Button { Text = "+", Width = 34, Height = 38, Location = new Point(491, 61), BackColor = Color.White };

            // Giá
            Label lblThanhTien = new Label
            {
                Text = ct.ThanhTien.ToString("N0"),
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.DarkGreen,
                Location = new Point(403, 115),
                AutoSize = true
            };

            txtSoLuong.Tag = "SoLuong";
            lblThanhTien.Tag = "ThanhTien";

            // Xử lý tăng/giảm số lượng
            btnCong.Click += (s, e) =>
            {
                int sl = int.TryParse(txtSoLuong.Text, out var val) ? val : 1;
                sl++;
                txtSoLuong.Text = sl.ToString();
                ct.SoLuong = sl;
                ct.ThanhTien = TinhThanhTienTheoSize(sl, ct.GiaBan, ct.Size);
                lblThanhTien.Text = ct.ThanhTien.ToString("N0");
                CapNhatTongTien();
            };

            btnTru.Click += (s, e) =>
            {
                int sl = int.TryParse(txtSoLuong.Text, out var val) ? val : 1;
                if (sl > 1)
                {
                    sl--;
                    txtSoLuong.Text = sl.ToString();
                    ct.SoLuong = sl;
                    ct.ThanhTien = TinhThanhTienTheoSize(sl, ct.GiaBan, ct.Size);
                    lblThanhTien.Text = ct.ThanhTien.ToString("N0");
                    CapNhatTongTien();
                }
                else
                {
                    // Xóa khỏi danh sách dữ liệu
                    danhSachTam.Remove(ct);

                    // Xóa khỏi giao diện
                    flowDonHang.Controls.Remove(panel);
                    CapNhatTongTien(); // cập nhật lại sau khi xóa
                }
            };

            Button btnXoa = new Button
            {
                Text = "Xóa",
                Width = 89,
                Height = 166,
                BackColor = Color.SandyBrown,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(568, -2),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
            };
            btnXoa.FlatAppearance.BorderSize = 0;


            // Thêm các control vào panel
            panel.Controls.Add(btnXoa);
            panel.Controls.Add(pic);
            panel.Controls.Add(lblTen);
            panel.Controls.Add(rbS);
            panel.Controls.Add(rbM);
            panel.Controls.Add(rbL);
            panel.Controls.Add(lblSL);
            panel.Controls.Add(btnTru);
            panel.Controls.Add(txtSoLuong);
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
                        lbl.Text = ct.ThanhTien.ToString("N0");
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
            lblTongTien.Text = $"{tongTien:N0}";
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu formMenu = new Menu(this); // tạo mới form Menu
            formMenu.Show(); // hiển thị form Menu
            this.Hide();    // đóng form chi tiết hiện tại
        }

        private void guna2ControlBox9_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng tất cả các form và thoát chương trình
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
                    MaKH = Program.MaKH
                };

                // 6. Lưu đơn hàng vào Firestore
                DocumentReference donHangRef = db.Collection("DonHang").Document(maDonMoi);
                await donHangRef.SetAsync(donHang);

                // 7. Thêm chi tiết đơn hàng vào collection con: DonHang/{MaDH}/ChiTietSanPham
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

                // 8. Mở form hóa đơn
                var hoaDonForm = new ThanhToan(maDonMoi);
                hoaDonForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
