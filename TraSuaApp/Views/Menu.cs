using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
using Models;
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
using TheArtOfDevHtmlRenderer.Adapters;
using TraSuaApp.Models;
using TraSuaApp.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TraSuaApp.View
{
    public partial class Menu : Form
    {
        private CancellationTokenSource _cts;
        private FirestoreChangeListener listener;
        private DonHangUser donhang;
        private List<SanPham> danhSachSanPham = new(); // Khai báo danh sách toàn cục
        private ListBox listBoxGoiY;
        public Menu(DonHangUser formDonHang)
        {
            InitializeComponent();
            this.FormClosing += Menu_FormClosing;
            tbTimKiem.TextChanged += TbTimKiem_TextChanged;
            loadingSpinner = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            loadingSpinner.Name = "loadingSpinner";
            loadingSpinner.Size = new Size(60, 60);
            loadingSpinner.CircleSize = 1.0F;
            loadingSpinner.ProgressColor = Color.FromArgb(255, 141, 31);
            loadingSpinner.BackColor = Color.Transparent;
            loadingSpinner.Visible = false;

            // Canh giữa form
            loadingSpinner.Location = new Point(this.Width / 2 - loadingSpinner.Width / 2, this.Height / 2 - loadingSpinner.Height / 2);
            loadingSpinner.Anchor = AnchorStyles.None;

            this.Controls.Add(loadingSpinner);
            loadingSpinner.BringToFront();  // Bảo đảm nằm trên cùng

            donhang = formDonHang;

            // Khởi tạo ListBox
            listBoxGoiY = new ListBox
            {
                Visible = false,
                Height = 100,
                Width = tbTimKiem.Width,
                BackColor = Color.White,
                ForeColor = Color.Black,
            };

            // Lấy vị trí tuyệt đối trên màn hình
            Point screenPos = tbTimKiem.PointToScreen(Point.Empty);

            // Chuyển thành tọa độ theo Form
            Point formPos = this.PointToClient(screenPos);

            // Đặt vị trí listBox ngay dưới tbTimKiem, căn chuẩn
            listBoxGoiY.Location = new Point(formPos.X + 50, formPos.Y + 30 + tbTimKiem.Height);

            // Add listbox vào form gốc (không phải panel)
            this.Controls.Add(listBoxGoiY);
            listBoxGoiY.BringToFront();

            // Gắn sự kiện click
            listBoxGoiY.Click += ListBoxGoiY_Click;
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
                Guna2GradientPanel panel = new Guna2GradientPanel
                {
                    BackColor = Color.Transparent,
                    Size = new Size(235, 360),
                    FillColor = Color.FromArgb(255, 192, 125),
                    FillColor2 = Color.FromArgb(208, 241, 255),
                    GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal,
                    BorderColor = Color.FromArgb(255, 162, 2),
                    BorderRadius = 20,
                    BorderThickness = 4,
                    BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash,
                    Margin = new Padding(30, 30, 30, 0)
                };

                Guna2PictureBox pic = new Guna2PictureBox
                {
                    Size = new Size(220, 208),
                    Location = new Point(8, 17),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                    BorderRadius = 20,

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

                Guna2HtmlLabel ten = new Guna2HtmlLabel
                {
                    Text = $"{sp.TenSP}</div>",
                    Location = new Point(20, 235),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(20, 44, 161),
                    AutoSize = false,
                    Size = new Size(150, 35),
                };

                Guna2HtmlLabel gia = new Guna2HtmlLabel
                {
                    Text = $"{sp.Gia.ToString("N0")} VND</div>",
                    ForeColor = Color.FromArgb(0, 22, 61),
                    Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                    Location = new Point(25, 265),
                    AutoSize = false,
                    Size = new Size(150, 38),
                };

                Color tt;

                if (sp.TrangThai != "Còn hàng")
                {
                    tt = Color.Red;
                }
                else tt = Color.DarkGreen;

                // Tạo Panel để chứa Label và bo góc
                Guna2Panel panel1 = new Guna2Panel
                {
                    Size = new Size(180, 35),
                    BorderRadius = 10,     // Bo góc 7
                    FillColor = Color.FromArgb(100, 255, 255, 255),
                    Padding = new Padding(20, 0, 0, 3)
                };

                // Tạo Guna2HtmlLabel
                Label trangThai = new Label
                {
                    Text = sp.TrangThai,
                    AutoSize = false,
                    Size = new Size(180, 35),
                    BackColor = Color.Transparent,  // Để nền trong suốt
                    ForeColor = tt,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(10, 0, 0, 0) // Điều chỉnh thụt vào bên trái
                };

                panel1.Controls.Add(trangThai);
                panel1.Parent = panel;
                panel1.Left = panel.Width - 140;

                Guna2TileButton btnThem = new Guna2TileButton
                {
                    Text = "THÊM NGAY",
                    Size = new Size(180, 40),
                    FillColor = Color.FromArgb(255, 141, 31),
                    Location = new Point(30, 304),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BorderColor = Color.GhostWhite,
                    BorderRadius = 10,
                    BorderThickness = 2,
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

                panel.Controls.Add(ten);
                panel.Controls.Add(gia);
                panel.Controls.Add(panel1);
                panel.Controls.Add(pic);

                panel.Controls.Add(btnThem);

                panel.Tag = sp;

                // Gán sự kiện click toàn vùng panel
                panel.Click += MoChiTietSanPham;

                // Gán sự kiện click cho các control con

                foreach (Control ctrl in panel.Controls)
                {
                    if (!(ctrl is Button))
                    {
                        //ctrl.Click += MoChiTietSanPham;
                    }
                }

                flowSanPham.Controls.Add(panel);
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
                    pnlHienThiMenu.Controls.Clear();
                    ChiTietSanPham form = new ChiTietSanPham(sp, donhang)
                    {
                        TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                        Dock = DockStyle.Fill      // Hiển thị full trong panel
                    };
                    pnlHienThiMenu.Controls.Add(form);
                    form.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không xem được chi tiết sản phẩm: " + ex.Message);
                }
            }
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

            donhang.ThemChiTietVaoGiaoDien(ct);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            loadingSpinner.Visible = true;
            loadingSpinner.Start();
            Application.DoEvents();

            var db = DBServices.Connect();
            _cts = new CancellationTokenSource();

            // Lắng nghe theo thời gian thực
            db.Collection("SanPham").Listen(snapshot =>
            {
                var list = snapshot.Documents.Select(doc =>
                {
                    var sp = doc.ConvertTo<SanPham>();
                    sp.ID = doc.Id;
                    return sp;
                }).ToList();

                this.Invoke(() =>
                {
                    danhSachSanPham = list;
                    HienThiSanPham(danhSachSanPham);
                    loadingSpinner.Stop();
                    loadingSpinner.Visible = false;
                });
            }, _cts.Token); // truyền vào CancellationToken
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts?.Cancel();
            _cts?.Dispose();
        }


        private void ListBoxGoiY_Click(object sender, EventArgs e)
        {
            if (listBoxGoiY.SelectedItem != null)
            {
                tbTimKiem.Text = listBoxGoiY.SelectedItem.ToString();
                listBoxGoiY.Visible = false;
                HienThiSanPham(danhSachSanPham, tuKhoa: tbTimKiem.Text.Trim());
            }
        }

        private void TbTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            // Gọi gợi ý mỗi lần người dùng nhấn phím
            HienThiGoiY(tbTimKiem.Text);
        }

        private void TbTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Trường hợp người dùng paste văn bản
            HienThiGoiY(tbTimKiem.Text);
        }

        private void HienThiGoiY(string tuKhoa)
        {
            tuKhoa = tuKhoa.Trim().ToLower();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                listBoxGoiY.Visible = false;
                return;
            }

            // Lọc danh sách sản phẩm theo tên gần đúng
            var goiY = danhSachSanPham
                .Where(sp => !string.IsNullOrEmpty(sp.TenSP) && sp.TenSP.ToLower().Contains(tuKhoa))
                .Select(sp => sp.TenSP)
                .Distinct()
                .Take(10)
                .ToList();

            if (goiY.Any())
            {
                listBoxGoiY.DataSource = goiY;
                listBoxGoiY.Visible = true;
            }
            else
            {
                listBoxGoiY.Visible = false;
            }
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            HienThiSanPham(danhSachSanPham, tuKhoa: tuKhoa);
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            string loai = cbLoc.SelectedItem?.ToString() ?? "Tất cả"; // Lấy loại từ ComboBox
            string tuKhoa = tbTimKiem.Text.Trim(); // Lấy từ khóa tìm kiếm
            HienThiSanPham(danhSachSanPham, loai: loai, tuKhoa: tuKhoa); // Gọi phương thức lọc
        }
    }
}
