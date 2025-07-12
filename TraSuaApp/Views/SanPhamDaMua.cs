using Google.Cloud.Firestore;
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
using TraSuaApp.Services;
using TraSuaApp.Models;
using Guna.UI2.WinForms;
using Models;
using TraSuaApp.Views;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;

namespace TraSuaApp.View
{
    public partial class SanPhamDaMua : Form
    {
        SanPham sp;
        private DonHangUser donhang;
        private FirestoreDb db;
        private static HttpClient httpClient = new HttpClient();
        private Guna2WinProgressIndicator loadingSpinner; // Biến để hiển thị spinner

        private readonly string MaKH;
        public SanPhamDaMua(DonHangUser formDonHang)
        {
            InitializeComponent();

            

            loadingSpinner = new Guna2WinProgressIndicator
            {
                Name = "loadingSpinner",
                Size = new Size(60, 60),
                CircleSize = 1.0F,
                ProgressColor = Color.FromArgb(255, 141, 31),
                BackColor = Color.Transparent,
                Visible = false,
                Location = new Point(this.Width / 2 - 30, this.Height / 2 - 30), // Canh giữa
                Anchor = AnchorStyles.None
            };

            this.Controls.Add(loadingSpinner);
            loadingSpinner.BringToFront();  // Luôn hiển thị trên cùng

            donhang = formDonHang;
            db = DBServices.Connect();
            SanPhamDaMua_load();  // Thêm sự kiện Load
        }

        private async void SanPhamDaMua_load()
        {
            loadingSpinner.Visible = true;
            loadingSpinner.Start();
            Application.DoEvents(); // Cập nhật UI

            try
            {
                string maKH = Dangnhap.MaKH;

                var orders = await db.Collection("DonHang")
                                     .WhereEqualTo("MaKH", maKH)
                                     .GetSnapshotAsync();

                var purchasedProducts = new Dictionary<string, (string TenSP, double Gia, string HinhAnh, string TrangThai)>();

                foreach (var order in orders)
                {
                    var chiTietDonHang = await db.Collection("DonHang")
                                                 .Document(order.Id)
                                                 .Collection("ChiTietDonHang")
                                                 .GetSnapshotAsync();

                    foreach (var item in chiTietDonHang)
                    {
                        string productId = item.GetValue<DocumentReference>("MaSP").Id;
                        var productDoc = await db.Collection("SanPham").Document(productId).GetSnapshotAsync();

                        if (productDoc.Exists && !purchasedProducts.ContainsKey(productId))  // 🔒 chỉ thêm nếu chưa có
                        {
                            string name = productDoc.GetValue<string>("TenSP");
                            double price = productDoc.GetValue<double>("Gia");
                            string imageUrl = productDoc.GetValue<string>("HinhAnh");
                            string trangthai = productDoc.GetValue<string>("TrangThai");

                            sp = new SanPham
                            {
                                TenSP = name,
                                Gia = price,
                                HinhAnh = imageUrl,
                                TrangThai = trangthai,
                                LoaiSP = productDoc.GetValue<string>("LoaiSP"),
                                ID = productDoc.Id,
                            };

                            purchasedProducts[productId] = (name, price, imageUrl, trangthai);
                        }
                    }
                }

                if (purchasedProducts.Count == 0)
                {
                    MessageBox.Show("Bạn chưa mua sản phẩm nào.");
                }

                foreach (var (name, price, imageUrl, trangthai) in purchasedProducts.Values)
                {
                    Guna2GradientPanel panel = new Guna2GradientPanel
                    {
                        BackColor = Color.Transparent,
                        Width = 560,
                        Height = 301,
                        FillColor = Color.FromArgb(255, 192, 125),
                        FillColor2 = Color.FromArgb(208, 241, 255),
                        GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal,
                        BorderColor = Color.FromArgb(255, 162, 2),
                        BorderRadius = 20,
                        BorderThickness = 5,
                        BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash,
                        Margin = new Padding(30)
                    };

                    Guna2PictureBox pic = new Guna2PictureBox
                    {
                        Width = 286,
                        Height = 292,
                        Location = new Point(7, 5),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.Transparent,
                        BorderRadius = 20,
                        CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges
                        {
                            TopLeft = true,
                            TopRight = false,
                            BottomLeft = true,
                            BottomRight = false
                        },

                    };

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
                        Text = $"<div style='text-align:center; line-height:43px;'>{name}</div>",
                        Location = new Point(304, 60),
                        Font = new Font("Segoe UI", 15, FontStyle.Bold),
                        ForeColor = Color.FromArgb(20, 44, 161),
                        AutoSize = false,
                        Size = new Size(240, 43)
                    };

                    Guna2HtmlLabel gia = new Guna2HtmlLabel
                    {
                        Text = $"<div style='text-align:center; line-height:43px;'>{price.ToString("N0")} VND</div>",
                        ForeColor = Color.FromArgb(0, 22, 61),
                        Font = new Font("Segoe UI Semibold", 13, FontStyle.Bold),
                        Location = new Point(353, 110),
                        AutoSize = false,
                        Size = new Size(138, 38),
                    };

                    Color tt;

                    if (trangthai != "Còn hàng")
                    {
                        tt = Color.Red;
                    }
                    else tt = Color.DarkGreen;

                    // Tạo Panel để chứa Label và bo góc
                    Guna2Panel panel1 = new Guna2Panel
                    {
                        Size = new Size(250, 52),
                        BackColor = Color.Transparent,
                        BorderRadius = 20,     // Bo góc 20
                        FillColor = Color.FromArgb(100, Color.White),  // Màu nền
                        Padding = new Padding(20, 0, 0, 0)
                    };

                    // Tạo Guna2HtmlLabel
                    Label trangThai = new Label
                    {
                        Text = trangthai,
                        AutoSize = false,
                        Size = new Size(250, 52),
                        BackColor = Color.Transparent,  // Để nền trong suốt
                        ForeColor = tt,
                        Font = new Font("Segoe UI", 15, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleLeft,
                        Padding = new Padding(10, 0, 0, 0) // Điều chỉnh thụt vào bên trái
                    };

                    panel1.Controls.Add(trangThai);
                    panel1.Parent = panel;
                    panel1.Left = panel.Width - 170;

                    Guna2TileButton btnThem = new Guna2TileButton
                    {
                        Text = "MUA LẠI NGAY",
                        Size = new Size(243, 57),
                        FillColor = Color.FromArgb(255, 141, 31),
                        Location = new Point(303, 188),
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        BorderColor = Color.GhostWhite,
                        BorderRadius = 15,
                        BorderThickness = 2,
                    };

                    btnThem.Click += (s, e) =>
                    {
                        if (trangthai?.ToLower() == "hết hàng" || trangthai?.ToLower() == "ngừng bán")
                        {
                            MessageBox.Show($"{name} hiện đang hết hàng. Vui lòng chọn sản phẩm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Lấy thông tin sản phẩm và thêm vào đơn hàng
                        AddToOrder(sp);
                        MessageBox.Show($"Đã thêm {name} vào đơn hàng!");
                    };

                    panel.Controls.Add(panel1);
                    panel.Controls.Add(pic);
                    panel.Controls.Add(ten);
                    panel.Controls.Add(gia);
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

                    flpSanPhamDaMua.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm đã mua: " + ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingSpinner.Stop();
                loadingSpinner.Visible = false;
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
                    pnlHienThi.Controls.Clear();
                    ChiTietSanPham form = new ChiTietSanPham(sp, donhang)
                    {
                        TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                        Dock = DockStyle.Fill      // Hiển thị full trong panel
                    };
                    pnlHienThi.Controls.Add(form);
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

        private async Task LoadImageAsync(string imageUrl, PictureBox pictureBox)
        {
            try
            {
                // Sử dụng HttpClient chung để tải ảnh
                var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    // Tạo một bản sao của ảnh để tránh xung đột khi tải ảnh giống nhau
                    Image img = Image.FromStream(ms);
                    pictureBox.Image = new Bitmap(img);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}");
            }
        }

    }
}
