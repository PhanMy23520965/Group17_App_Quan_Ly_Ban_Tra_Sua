using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
using Models.Admin;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Services;
using TraSuaApp.View;
using TraSuaApp.Models;

namespace TraSuaApp.Views
{
    public partial class Thanhtoan : Form
    {
        public readonly string MaDH;
        private FirestoreChangeListener donHangListener;
        private readonly decimal TongTienSauKM;

        public Thanhtoan(string maDH, decimal TienSauKM = 0)
        {
            InitializeComponent();
            this.FormClosed += Thanhtoan_FormClosed;

            MaDH = maDH;
            TongTienSauKM = TienSauKM;
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

        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaKH_Value;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTenKH_Value;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaDH_Value;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongTien_Value;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaKM_Value;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTongTienSauKM_Value;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTrangThai_Value;

        // Hàm tạo các label động
        private Guna.UI2.WinForms.Guna2HtmlLabel TaoLabelDong(string text, Point location)
        {
            return new Guna.UI2.WinForms.Guna2HtmlLabel
            {
                Text = text,
                Location = location,
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.Black
            };
        }

        private async void Thanhtoan_Load(object sender, EventArgs e)
        {
            BoGocPanel();

            // Các label động cho các thông tin khách hàng và đơn hàng
            lblMaKH_Value = TaoLabelDong(Dangnhap.MaKH, new Point(140, 19));  // Chỉ hiển thị giá trị của MaKH
            guna2GradientPanel1.Controls.Add(lblMaKH_Value);

            lblTenKH_Value = TaoLabelDong(Dangnhap.TenKH, new Point(390, 19));  // Chỉ hiển thị giá trị của TenKH
            guna2GradientPanel1.Controls.Add(lblTenKH_Value);

            lblMaDH_Value = TaoLabelDong(MaDH, new Point(190, 67));  // Chỉ hiển thị giá trị của MaDH
            guna2GradientPanel1.Controls.Add(lblMaDH_Value);

            lblTongTien_Value = TaoLabelDong("0 VND", new Point(170, 530));  // Chỉ hiển thị giá trị của TongTien (sẽ cập nhật sau)
            guna2GradientPanel1.Controls.Add(lblTongTien_Value);

            lblMaKM_Value = TaoLabelDong("", new Point(210, 572));  // Chỉ hiển thị giá trị của MaKM (sẽ cập nhật sau)
            guna2GradientPanel1.Controls.Add(lblMaKM_Value);

            lblTongTienSauKM_Value = TaoLabelDong("", new Point(320, 614));
            guna2GradientPanel1.Controls.Add(lblTongTienSauKM_Value);
            lblTongTienSauKM_Value.Text = TongTienSauKM.ToString("N0") + " VND";

            lblTrangThai_Value = TaoLabelDong("", new Point(270, 656));  // Chỉ hiển thị giá trị của TrangThai (sẽ cập nhật sau)
            guna2GradientPanel1.Controls.Add(lblTrangThai_Value);

            FirestoreDb db = DBServices.Connect();
            if (db == null) return;

            try
            {
                // Lấy thông tin đơn hàng
                DocumentReference donHangRef = db.Collection("DonHang").Document(MaDH);
                var donHangDoc = await donHangRef.GetSnapshotAsync();
                if (donHangDoc.Exists)
                {
                    // Lấy các giá trị từ tài liệu Firestore mà không sử dụng ConvertTo
                    string trangThai = donHangDoc.GetValue<string>("TrangThai");
                    string maKM = donHangDoc.GetValue<string>("MaKM");

                    // Kiểm tra giá trị của TongTien (Firestore lưu dưới dạng number)
                    object tongTienObject = donHangDoc.GetValue<object>("TongTien");
                    decimal tongTien = 0;

                    if (tongTienObject != null)
                    {
                        // Chuyển đổi TongTien sang decimal nếu cần
                        if (tongTienObject is long)
                        {
                            tongTien = Convert.ToDecimal(tongTienObject);  // nếu Firestore lưu là long
                        }
                        else if (tongTienObject is double)
                        {
                            tongTien = Convert.ToDecimal(tongTienObject);  // nếu Firestore lưu là double
                        }
                    }

                    // Cập nhật thông tin đơn hàng vào các label
                    lblTrangThai_Value.Text = trangThai;
                    // Kiểm tra trạng thái thanh toán và thay đổi màu sắc
                    if (trangThai == "Đã thanh toán")
                    {
                        lblTrangThai_Value.ForeColor = Color.Green;  // Màu xanh lá cây cho đã thanh toán
                    }
                    else if (trangThai == "Chưa thanh toán")
                    {
                        lblTrangThai_Value.ForeColor = Color.Red;  // Màu đỏ cho chưa thanh toán
                    }
                    lblMaKM_Value.Text = maKM;
                    lblTongTien_Value.Text = tongTien.ToString("N0") + " VND";  // Hiển thị giá trị decimal
                    lblTongTienSauKM_Value.Text = tongTien.ToString("N0")   + " VND";  // Hiển thị giá trị decimal sau khi áp dụng khuyến mãi
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng.");
                }

                // Lấy chi tiết đơn hàng
                CollectionReference chiTietCollection = donHangRef.Collection("ChiTietDonHang");
                QuerySnapshot snapshot = await chiTietCollection.GetSnapshotAsync();

                if (snapshot.Count > 0)
                {
                    // Thêm chi tiết đơn hàng vào giao diện
                    foreach (var doc in snapshot.Documents)
                    {
                        ChiTietDonHang chiTiet = doc.ConvertTo<ChiTietDonHang>();
                        ThemChiTietVaoGiaoDien(chiTiet);
                    }
                }

                else
                {
                    MessageBox.Show("Không có chi tiết đơn hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }

            // Sau khi load xong dữ liệu, bắt đầu lắng nghe đơn hàng
            ListenTrangThaiDonHang();

        }

        public async void ThemChiTietVaoGiaoDien(ChiTietDonHang ct)
        {
            CapNhapScrollMinSize(flowLayoutPanel1);  // Cập nhật lại kích thước của FlowLayoutPanel

            // Tạo một panel để chứa thông tin chi tiết đơn hàng (tăng chiều rộng để chứa thông tin mà không che ảnh)
            var panel = new Panel
            {
                Size = new Size(954, 180),  // Tăng chiều rộng của panel để chứa thông tin và không che ảnh
                BackColor = Color.Transparent,
                Margin = new Padding(3, 3, 3, 10)  // Giảm khoảng cách dưới giữa các panel
            };

            // Tạo hình ảnh sản phẩm (hình vuông)
            var pic = new Guna2CirclePictureBox
            {
                Size = new Size(150, 150), // Hình vuông
                Location = new Point(10, 15), // Đặt vị trí hình ảnh
                Margin = new Padding(3, 3, 3, 15),  // Giảm margin dưới
                SizeMode = PictureBoxSizeMode.Zoom, // Đảm bảo ảnh không bị kéo dãn
            };

            FirestoreDb db = DBServices.Connect();
            if (db == null) return;

            try
            {
                // Lấy thông tin sản phẩm từ Firestore thông qua MaSP (reference)
                if (ct.MaSP is DocumentReference spRef)  // Kiểm tra nếu MaSP là DocumentReference
                {
                    // Truy xuất tài liệu sản phẩm từ Firestore
                    DocumentSnapshot spDoc = await spRef.GetSnapshotAsync(); // Lấy snapshot tài liệu sản phẩm

                    if (spDoc.Exists)
                    {
                        // Chuyển snapshot thành đối tượng SanPham
                        var sanPham = spDoc.ConvertTo<SanPham>();

                        // Tải hình ảnh sản phẩm
                        if (!string.IsNullOrEmpty(sanPham.HinhAnh))
                        {
                            LoadImageAsync(sanPham.HinhAnh, pic);  // Tải ảnh sản phẩm từ URL
                        }
                        else
                        {
                            MessageBox.Show("Không có URL ảnh để tải.");
                        }

                        // Tạo các label cho thông tin (dàn đều và căn giữa theo chiều ngang)
                        // Tên sản phẩm
                        var lblTen = new Label
                        {
                            Text = $"{sanPham.TenSP}",
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12, FontStyle.Regular),  // Font chữ bình thường
                            Location = new Point(230, 30),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Width = 230,  // Chiều rộng đủ để căn giữa
                        };

                        // Size
                        Label lblSize = new Label
                        {
                            Text = "Size: " + ct.Size,
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12, FontStyle.Regular),
                            Location = new Point(230, 55),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Width = 230,  // Chiều rộng đủ để căn giữa
                        };

                        // Số lượng
                        Label lbSoLuong = new Label
                        {
                            Text = "x" + ct.SoLuong.ToString(),
                            AutoSize = true,
                            Font = new Font("Segoe UI", 12, FontStyle.Regular),
                            Location = new Point(230, 80),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Width = 230,  // Chiều rộng đủ để căn giữa
                        };

                        // Thành tiền
                        Label lblThanhTien = new Label
                        {
                            Text = ct.ThanhTien.ToString("N0") + " VND",
                            Font = new Font("Segoe UI", 12, FontStyle.Regular),
                            ForeColor = Color.Black,
                            Location = new Point(230, 105),
                            AutoSize = true,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Width = 230,  // Chiều rộng đủ để căn giữa
                        };

                        // Thêm các control vào panel
                        panel.Controls.Add(pic);
                        panel.Controls.Add(lblTen);  // Thêm tên sản phẩm vào trên hình ảnh
                        panel.Controls.Add(lblSize);  // Thêm Size vào panel
                        panel.Controls.Add(lbSoLuong);  // Thêm số lượng vào panel
                        panel.Controls.Add(lblThanhTien);  // Thêm thành tiền vào panel

                        // Thêm panel vào FlowLayoutPanel
                        flowLayoutPanel1.Controls.Add(panel);
                        panel.Tag = ct;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin sản phẩm.");
                    }
                }
                else
                {
                    MessageBox.Show("Không phải là DocumentReference hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin sản phẩm: {ex.Message}");
            }
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

        private void CapNhapScrollMinSize(FlowLayoutPanel flp)
        {
            // Cập nhật lại kích thước của FlowLayoutPanel theo số lượng control bên trong
            flp.AutoScrollMinSize = new Size(0, flp.Controls.Count * 175);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            // Mở form mới sau khi đóng tất cả form cũ
            Khuyenmai khuyenmai = new Khuyenmai(MaDH);  // Khởi tạo form mới

            pnlHienThiHome.Controls.Clear();

            khuyenmai.TopLevel = false;
            khuyenmai.Dock = DockStyle.Fill;

            // Thêm form con vào panel1
            pnlHienThiHome.Controls.Add(khuyenmai);

            // Hiển thị form con
            khuyenmai.Show();
        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            await donHangListener.StopAsync();
            donHangListener = null;
            // Mở form mới sau khi đóng tất cả form cũ
            DonHangUser donhang = new DonHangUser();  // Khởi tạo form mới

            pnlHienThiHome.Controls.Clear();

            donhang.TopLevel = false;
            donhang.Dock = DockStyle.Fill;

            // Thêm form con vào panel1
            pnlHienThiHome.Controls.Add(donhang);

            foreach (ChiTietDonHangTam ct in Program.danhSachSPTam)
            {
                donhang.ThemChiTietVaoGiaoDien(ct);
            }

            // Hiển thị form con
            donhang.Show();
        }

        private void ListenTrangThaiDonHang()
        {
            FirestoreDb db = DBServices.Connect();
            if (db == null) return;

            DocumentReference donHangRef = db.Collection("DonHang").Document(MaDH);

            donHangListener = donHangRef.Listen(snapshot =>
            {
                if (snapshot.Exists)
                {
                    string trangThai = snapshot.GetValue<string>("TrangThai");

                    this.Invoke(new Action(() =>
                    {
                        lblTrangThai_Value.Text = trangThai;

                        if (trangThai == "Đã thanh toán")
                        {
                            lblTrangThai_Value.ForeColor = Color.Green;
                            btnDanhGia.Visible = true;
                        }
                        else if (trangThai == "Hủy")
                        {
                            btnDanhGia.Visible = false;

                            // 🛠 Không dùng await ở đây
                            Task.Run(async () =>
                            {
                                await donHangListener.StopAsync();
                                donHangListener = null;

                                this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show("Đơn hàng không còn hiệu lực hoặc chưa thanh toán.");
                                }));
                            });
                        }
                    }));
                }
                else
                {
                    // Nếu đơn hàng bị xóa khỏi Firestore
                    Task.Run(async () =>
                    {
                        await donHangListener.StopAsync();
                        donHangListener = null;

                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Đơn hàng không tồn tại.");
                            btnDanhGia.Visible = false;
                        }));
                    });
                }
            });
        }


        private async void Thanhtoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (donHangListener != null)
            {
                await donHangListener.StopAsync();
                donHangListener = null;
            }
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            // Tạo form đánh giá và truyền MaDH
            DanhGiaUser formDanhGia = new DanhGiaUser(MaDH);

            // Thiết lập form ở giữa màn hình
            formDanhGia.StartPosition = FormStartPosition.CenterScreen;

            // Hiển thị form dưới dạng dialog (modal)
            formDanhGia.ShowDialog();
        }
    }
}
