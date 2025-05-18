using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Services;
using TraSuaApp.View;

namespace TraSuaApp.Models
{
    public partial class SanPhamNew : Form
    {
        SanPham sp;
        private DonHangUser donhang;
        private FirestoreDb db;
        private static HttpClient httpClient = new HttpClient();
        public SanPhamNew(DonHangUser formDonHang)
        {
            InitializeComponent();
            donhang = formDonHang;
            db = DBServices.Connect();
            SanPhamNew_Load();
        }

        private async Task<List<DocumentSnapshot>> GetLatestProducts()
        {
            try
            {
                var products = await db.Collection("SanPham").GetSnapshotAsync();

                if (products.Count == 0)
                {
                    MessageBox.Show("Không có sản phẩm nào trong cơ sở dữ liệu.");
                    return new List<DocumentSnapshot>();
                }

                var sortedProducts = products.Documents
                    .OrderByDescending(doc => int.Parse(doc.Id.Substring(2)))
                    .Take(6)
                    .ToList();

                return sortedProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy sản phẩm mới nhất: {ex.Message}");
                return new List<DocumentSnapshot>();
            }
        }



        private async void SanPhamNew_Load()
        {
            try
            {
                var latestProducts = await GetLatestProducts();

                if (latestProducts.Count == 0)
                    return;

                flpSanPhamNew.Controls.Clear();

                foreach (var productDoc in latestProducts)
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

                    Guna2GradientPanel panel1 = new Guna2GradientPanel
                    {
                        BackColor = Color.Transparent,
                        Width = 710,
                        Height = 370,
                    };

                    Guna2GradientPanel panel = new Guna2GradientPanel
                    {
                        Location = new Point(40, 30),
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
                    };

                    panel.Parent = panel1;

                    // Tạo PictureBox nằm lệch ra ngoài góc trên bên trái
                    Guna2PictureBox picOut = new Guna2PictureBox
                    {
                        Width = 120,     // Kích thước ảnh
                        Height = 80,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.Transparent, // Nền trong suốt
                        Image = Properties.Resources.New, // Thay bằng ảnh của bạn
                    };



                    // Đặt Parent của PictureBox là cùng cấp với panel
                    picOut.Parent = panel1;

                    // Thiết lập vị trí dựa trên vị trí của panel
                    picOut.Location = new Point(panel.Location.X + 550, panel.Location.Y + 10);

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
                        Text = $"<div style='text-align:center; line-height:43px;'>{price}</div>",
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


                    Guna2TileButton btnThem = new Guna2TileButton
                    {
                        Text = "MUA NGAY",
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
                        // Lấy thông tin sản phẩm và thêm vào đơn hàng
                        AddToOrder(sp);
                        MessageBox.Show($"Đã thêm {name} vào đơn hàng!");
                    };

                    panel.Controls.Add(pic);
                    panel.Controls.Add(ten);
                    panel.Controls.Add(gia);
                    panel.Controls.Add(btnThem);
                    panel1.Controls.Add(panel);
                    // Thêm PictureBox vào cùng cấp với panel
                    panel1.Controls.Add(picOut);
                    panel.Tag = sp;

                    // Gán sự kiện click toàn vùng panel
                    panel.Click += MoChiTietSanPham;

                    // Gán sự kiện click cho các control con

                    foreach (Control ctrl in panel.Controls)
                    {
                        if (!(ctrl is Guna2TileButton))
                        {
                            ctrl.Click += MoChiTietSanPham;
                        }
                    }

                    flpSanPhamNew.Controls.Add(panel1);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm mới nhất: {ex.Message}");
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
