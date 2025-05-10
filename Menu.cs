using Google.Cloud.Firestore;
using Models;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TraSuaApp.Models;
using TraSuaApp.Services;
using TraSuaApp.Views;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;

namespace TraSuaApp
{
    public partial class Menu : Form
    {
        private ChiTietDonHangUser formDonHang;
        private List<SanPham> danhSachSanPham = new(); // Khai báo danh sách toàn cục

        // Các hằng số và hàm cho việc kéo form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Menu(ChiTietDonHangUser donhang)
        {
            InitializeComponent();
            this.guna2Panel1.MouseDown += Form_MouseDown;
            this.Padding = new Padding(3);
            formDonHang = donhang;
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        // Tạo khả năng resize form viền
        protected override void WndProc(ref Message m)
        {
            const int resizeAreaSize = 10;
            const int HTLEFT = 10, HTRIGHT = 11, HTTOP = 12, HTTOPLEFT = 13, HTTOPRIGHT = 14;
            const int HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTBOTTOMRIGHT = 17;
            const int WM_NCHITTEST = 0x84;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                if (clientPoint.Y <= resizeAreaSize)
                {
                    if (clientPoint.X <= resizeAreaSize)
                        m.Result = (IntPtr)HTTOPLEFT;
                    else if (clientPoint.X >= (this.Width - resizeAreaSize))
                        m.Result = (IntPtr)HTTOPRIGHT;
                    else
                        m.Result = (IntPtr)HTTOP;
                }
                else if (clientPoint.Y >= (this.Height - resizeAreaSize))
                {
                    if (clientPoint.X <= resizeAreaSize)
                        m.Result = (IntPtr)HTBOTTOMLEFT;
                    else if (clientPoint.X >= (this.Width - resizeAreaSize))
                        m.Result = (IntPtr)HTBOTTOMRIGHT;
                    else
                        m.Result = (IntPtr)HTBOTTOM;
                }
                else
                {
                    if (clientPoint.X <= resizeAreaSize)
                        m.Result = (IntPtr)HTLEFT;
                    else if (clientPoint.X >= (this.Width - resizeAreaSize))
                        m.Result = (IntPtr)HTRIGHT;
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

        private void HienThiSanPham(List<SanPham> danhSach, string loai = "Tất cả", string tuKhoa = "")
        {
            flowSanPham.Controls.Clear();

            string Normalize(string text)
            {
                if (string.IsNullOrEmpty(text)) return "";
                var normalized = text.Normalize(System.Text.NormalizationForm.FormD);
                return new string(normalized.Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark).ToArray()).ToLowerInvariant();
            }

            string tuKhoaNorm = Normalize(tuKhoa);
            string loaiNorm = Normalize(loai);

            var locDanhSach = danhSach
                .Where(sp =>
                    (loaiNorm == "tat ca" || (!string.IsNullOrEmpty(sp.LoaiSP) && Normalize(sp.LoaiSP) == loaiNorm)) &&
                    (string.IsNullOrEmpty(tuKhoaNorm) || (!string.IsNullOrEmpty(sp.TenSP) && Normalize(sp.TenSP).Contains(tuKhoaNorm))))
                .ToList();

            foreach (var sp in locDanhSach)
            {
                Panel panel = new Panel
                {
                    BackColor = Color.PeachPuff,
                    Width = 280,
                    Height = 430,
                    Margin = new Padding(10)
                };

                PictureBox pic = new PictureBox
                {
                    Width = 270,
                    Height = 280,
                    Top = 3,
                    Left = (panel.Width - 270) / 2,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent
                };

                string imageUrl = sp.HinhAnh; // Lấy URL ảnh từ Firestore

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    // Thử tải ảnh bằng cách sử dụng HttpClient
                    LoadImageAsync(imageUrl, pic);
                }
                else
                {
                    MessageBox.Show("Không có URL ảnh để tải.");
                }

                Label ten = new Label
                {
                    Text = sp.TenSP,
                    Top = pic.Bottom + 10,
                    Left = 0,
                    Width = panel.Width,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 15, FontStyle.Bold),
                    AutoSize = false
                };

                Label gia = new Label
                {
                    Text = sp.Gia.ToString("N0") + " đ",
                    Top = ten.Bottom,
                    Left = 0,
                    Width = panel.Width,
                    Height = 28,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Green,
                    Font = new Font("Segoe UI", 12, FontStyle.Regular),
                    AutoSize = false
                };

                Label trangThai = new Label
                {
                    Text = sp.TrangThai,
                    AutoSize = true,
                    BackColor = Color.FromArgb(180, Color.White),
                    ForeColor = Color.DarkGreen,
                    Font = new Font("Segoe UI", 15, FontStyle.Bold)
                };

                trangThai.Parent = panel;
                trangThai.Left = panel.Width - trangThai.PreferredWidth + 5;

                Button btnThem = new Button
                {
                    Text = "Thêm vào đơn hàng",
                    Width = 280,
                    Height = 53,
                    Left = 0,
                    Top = gia.Bottom + 16,
                    BackColor = Color.FromArgb(255, 165, 0),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };

                btnThem.Click += (s, e) =>
                {
                    if (sp.TrangThai?.ToLower() == "hết hàng" || sp.TrangThai?.ToLower() == "ngừng bán")
                    {
                        MessageBox.Show($"{sp.TenSP} hiện đang hết hàng. Vui lòng chọn sản phẩm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy thông tin sản phẩm và thêm vào đơn hàng
                    AddToOrder(sp);
                    MessageBox.Show($"Đã thêm {sp.TenSP} vào đơn hàng!");
                };

                panel.Controls.Add(trangThai);
                panel.Controls.Add(pic);
                panel.Controls.Add(ten);
                panel.Controls.Add(gia);
                panel.Controls.Add(btnThem);

                panel.Tag = sp;

                // Gán sự kiện cho hiệu ứng hover
                AddHoverEffectToAllControls(panel, panel);

                // Gán sự kiện click toàn vùng panel
                panel.Click += MoChiTietSanPham;

                // Gán sự kiện click cho các control con
                foreach (Control ctrl in panel.Controls)
                {
                    if (!(ctrl is Button))
                    {
                        ctrl.Click += MoChiTietSanPham;
                    }
                }

                flowSanPham.Controls.Add(panel);
            }
        }

        // Hàm gán hiệu ứng hover cho panel và toàn bộ control con
        private void AddHoverEffectToAllControls(Control parent, Panel panelToChangeColor)
        {
            parent.MouseEnter += (s, e) => panelToChangeColor.BackColor = Color.Orange;
            parent.MouseLeave += (s, e) =>
            {
                // Kiểm tra nếu chuột thực sự đã rời khỏi toàn bộ panel
                Point cursorPos = panelToChangeColor.PointToClient(Cursor.Position);
                if (!panelToChangeColor.ClientRectangle.Contains(cursorPos))
                {
                    panelToChangeColor.BackColor = Color.PeachPuff;
                }
            };

            foreach (Control ctrl in parent.Controls)
            {
                AddHoverEffectToAllControls(ctrl, panelToChangeColor); // Gọi đệ quy cho các control con
            }
        }

        private void MoChiTietSanPham(object sender, EventArgs e)
        {
            Control clicked = sender as Control;

            // Nếu click vào control con, ta lấy Panel chứa nó
            Panel panel = clicked as Panel ?? clicked.Parent as Panel;

            if (panel?.Tag is SanPham sp)
            {
                try
                {
                    var form = new ChiTietSanPham(sp, formDonHang);
                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở form: " + ex.Message);
                }
            }
            this.Hide();
        }


        private void AddToOrder(SanPham sp)
        {
            FirestoreDb db = DBServices.Connect();
            var ct = new ChiTietDonHangTam
            {
                MaSP = sp.ID,
                TenSP = sp.TenSP,
                HinhAnh = sp.HinhAnh,
                GiaBan = sp.Gia,
                SoLuong = 1,
                Size = "S",
                ThanhTien = sp.Gia
            };

            formDonHang.ThemChiTietVaoGiaoDien(ct);
        }



        private async void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                FirestoreDb db = DBServices.Connect();
                if (db == null)
                {
                    MessageBox.Show("Không kết nối được với Firestore.");
                    return;
                }

                Query query = db.Collection("SanPham");
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                List<SanPham> danhSach = new();

                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    if (doc.Exists)
                    {
                        SanPham sp = doc.ConvertTo<SanPham>();
                        sp.ID = doc.Id; // Gán ID document làm mã sản phẩm (nếu chưa có)
                        danhSach.Add(sp);
                    }
                }

                if (danhSach.Any())
                {
                    danhSachSanPham = danhSach;
                    HienThiSanPham(danhSachSanPham);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm trong Firestore.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm từ Firestore: " + ex.Message);
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            HienThiSanPham(danhSachSanPham, tuKhoa: tuKhoa);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string loai = cbLoc.SelectedItem?.ToString() ?? "Tất cả"; // Lấy loại từ ComboBox
            string tuKhoa = tbTimKiem.Text.Trim(); // Lấy từ khóa tìm kiếm
            HienThiSanPham(danhSachSanPham, loai: loai, tuKhoa: tuKhoa); // Gọi phương thức lọc
        }

        private void btn_DonHang_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn form Menu

            // Hiện form đơn hàng dưới dạng modal (có thể chỉnh lại thành .Show nếu muốn song song)
            formDonHang.Show();
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng tất cả các form và thoát chương trình
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Application.OpenForms["Home"].Show();
            this.Hide();
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            LienHeUser lienhe = new LienHeUser();
            lienhe.Size = this.Size;
            lienhe.Location = this.Location;
            lienhe.Show();
            this.Hide();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan taiKhoan = new ThongTinTaiKhoan();
            taiKhoan.Size = this.Size;
            taiKhoan.Location = this.Location;
            taiKhoan.Show();
            this.Hide();
        }
    }
}
