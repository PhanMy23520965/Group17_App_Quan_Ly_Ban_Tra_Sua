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
using System.Net.Http;
using Models;
using System.Globalization;
using System.Xml.Linq;


namespace TraSuaApp.Views
{
    public partial class Home : Form
    {
        private FirestoreDb db;
        private static HttpClient httpClient = new HttpClient();
        private ChiTietDonHangUser formDonHang;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public Home(ChiTietDonHangUser donhang)
        {
            InitializeComponent();
            this.guna2Panel1.MouseDown += Form_MouseDown;
            this.Padding = new Padding(3);
            formDonHang = donhang;
            LoadTopProducts();
            LoadNewVouchers();
            LoadNewProducts();
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


        private async void product_Click(object sender, EventArgs e)
        {
            if (Program.MaKH == "")
            {
                MessageBox.Show("Vui lòng đăng nhập để tiếp tục");
                Dangnhap dangnhap = new Dangnhap();
                this.Hide();
                dangnhap.Show();
                return;
            }
            Control clickedControl = sender as Control;
            Panel panel = null;

            // Tìm panel chứa control được click
            while (clickedControl != null && !(clickedControl is Panel))
            {
                clickedControl = clickedControl.Parent;
            }

            panel = clickedControl as Panel;

            if (panel == null || panel.Tag == null)
            {
                MessageBox.Show("Không tìm thấy thông tin sản phẩm.");
                return;
            }

            string productId = panel.Tag.ToString();

            try
            {
                db = DBServices.Connect();
                var productDoc = await db.Collection("SanPham").Document(productId).GetSnapshotAsync();

                if (!productDoc.Exists)
                {
                    MessageBox.Show("Sản phẩm không tồn tại.");
                    return;
                }

                SanPham sp = new SanPham
                {
                    ID = productId,
                    TenSP = productDoc.GetValue<string>("TenSP"),
                    Gia = productDoc.GetValue<int>("Gia"),
                    HinhAnh = productDoc.GetValue<string>("HinhAnh"),
                    TrangThai = productDoc.GetValue<string>("TrangThai")
                };

                ChiTietSanPham chiTietSanPham = new ChiTietSanPham(sp, formDonHang);
                chiTietSanPham.Location = this.Location;
                chiTietSanPham.Size = this.Size;
                chiTietSanPham.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở chi tiết sản phẩm: {ex.Message}");
            }
        }



        private void voucher_Click(object sender, EventArgs e)
        {
            if (Program.MaKH == "")
            {
                MessageBox.Show("Vui lòng đăng nhập để tiếp tục");
                Dangnhap dangnhap = new Dangnhap();
                this.Hide();
                dangnhap.Show();
            }
            else
            {
                Control clickedControl = sender as Control;
                Panel panel = null;

                while (clickedControl != null && !(clickedControl is Panel))
                {
                    clickedControl = clickedControl.Parent;
                }

                panel = clickedControl as Panel;

                if (panel == null || panel.Tag == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin khuyến mãi.");
                    return;
                }

                KhuyenMai voucher = panel.Tag as KhuyenMai;

                if (voucher == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu khuyến mãi.");
                    return;
                }

                // Tạo panel thông tin khuyến mãi
                Panel infoPanel = new Panel
                {
                    Width = 500,
                    Height = 300,
                    BackColor = Color.Orange,
                    BorderStyle = BorderStyle.Fixed3D,
                    Location = new Point((this.Width - 350) / 2, (this.Height - 250) / 2)
                };

                // Nút đóng (X) ở góc trên bên phải
                Button closeButton = new Button
                {
                    Text = "X",
                    ForeColor = Color.Red,
                    BackColor = Color.LightGray,
                    FlatStyle = FlatStyle.Flat,
                    Width = 30,
                    Height = 30,
                    Location = new Point(infoPanel.Width - 35, 0)
                };
                closeButton.Click += (s, e) => infoPanel.Dispose(); // Đóng panel khi nhấn nút X

                // Label thông tin khuyến mãi
                Label labelInfo = new Label
                {
                    AutoSize = false,
                    Size = new Size(300, 150),
                    Location = new Point(30, 90),
                    Text = $"Chiết khấu: {voucher.ChietKhau}%\n" +

                           $"Giá tối thiểu: {voucher.GiaToiThieu:N0} đ\n" +

                           $"Giảm tối đa: {voucher.GiamToiDa:N0} đ\n" +

                           $"Ngày bắt đầu: {voucher.NgayBatDau:dd/MM/yyyy}\n" +

                           $"Ngày kết thúc: {voucher.NgayKetThuc:dd/MM/yyyy}",
                    Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                Label lblND = new Label
                {
                    Size = new Size(300, 50),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 15, FontStyle.Bold),
                    Text = $"{voucher.NoiDung}\n" +
                          "\n",
                    Location = new Point(30, 40),
                };

                // Thêm các control vào panel thông tin
                infoPanel.Controls.Add(lblND);
                infoPanel.Controls.Add(closeButton);
                infoPanel.Controls.Add(labelInfo);

                // Thêm panel thông tin vào form
                this.Controls.Add(infoPanel);
                infoPanel.BringToFront(); // Đưa panel lên trên cùng
                this.Hide();
            }
        }


        private async void LoadTopProducts()
        {
            db = DBServices.Connect();
            var orders = await db.Collection("DonHang").GetSnapshotAsync();
            var productSales = new Dictionary<string, int>();

            // Kiểm tra xem có đơn hàng nào trong Firestore không
            if (orders.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đơn hàng nào.");
                return;
            }

            foreach (var order in orders)
            {
                try
                {
                    var details = await db.Collection("DonHang").Document(order.Id).Collection("ChiTietDonHang").GetSnapshotAsync();

                    // Nếu không có chi tiết đơn hàng, bỏ qua
                    if (details.Count == 0)
                    {
                        MessageBox.Show($"Đơn hàng {order.Id} không có chi tiết.");
                        continue;
                    }

                    foreach (var detail in details)
                    {
                        try
                        {
                            // Lấy DocumentReference từ trường MaSP
                            var productRef = detail.GetValue<DocumentReference>("MaSP");

                            // Lấy ID từ DocumentReference (dạng "SanPham/SP001")
                            string productId = productRef.Path.Split('/').Last();
                            int quantity = detail.GetValue<int>("SoLuong");

                            if (!productSales.ContainsKey(productId))
                                productSales[productId] = 0;

                            productSales[productId] += quantity;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi lấy chi tiết sản phẩm: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lấy đơn hàng {order.Id}: {ex.Message}");
                }
            }

            // Nếu từ điển trống, hiển thị thông báo
            if (productSales.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để hiển thị.");
                return;
            }

            try
            {
                foreach (var product in productSales.ToList())
                {
                    var productDoc = await db.Collection("SanPham").Document(product.Key).GetSnapshotAsync();
                    if (productDoc.GetValue<string>("TrangThai") == "Hết hàng" || productDoc.GetValue<string>("TenSP") == "Ngừng bán")
                    {
                        // Xóa sản phẩm khỏi từ điển
                        productSales.Remove(product.Key);
                    }

                }

                var topProducts = productSales.OrderByDescending(x => x.Value).Take(5).ToList();


                foreach (var product in topProducts)
                {
                    var productDoc = await db.Collection("SanPham").Document(product.Key).GetSnapshotAsync();

                    // Kiểm tra xem sản phẩm có tồn tại trong Firestore không
                    if (!productDoc.Exists)
                    {
                        MessageBox.Show($"Sản phẩm với ID {product.Key} không tồn tại.");
                        continue;
                    }

                    string name = productDoc.GetValue<string>("TenSP");
                    int price = productDoc.GetValue<int>("Gia");
                    string imageUrl = productDoc.GetValue<string>("HinhAnh");

                    var panel = new Panel
                    {
                        Width = 212,
                        Height = 240,
                        Margin = new Padding(3),
                        BackColor = Color.PeachPuff,
                        Tag = product.Key,
                    };
                    var labelName = new Label { Text = name, AutoSize = false, Size = new Size(150, 30), Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Location = new Point(30, 175) };
                    var labelPrice = new Label { Text = $"{price}", AutoSize = false, Size = new Size(150, 30), Font = new Font("Segoe UI", 10), TextAlign = ContentAlignment.MiddleCenter, Location = new Point(30, 203) };
                    var pictureBox = new PictureBox { Size = new Size(161, 157), SizeMode = PictureBoxSizeMode.Zoom, Margin = new Padding(3), Location = new Point(24, 15) };

                    await LoadImageAsync(imageUrl, pictureBox);

                    panel.Controls.Add(labelPrice);
                    panel.Controls.Add(labelName);
                    panel.Controls.Add(pictureBox);

                    panel.Click += product_Click;
                    foreach (Control ctl in panel.Controls)
                        ctl.Click += product_Click;

                    flpBestSanPham.Controls.Add(panel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sắp xếp sản phẩm: {ex.Message}");
            }
        }

        private async void LoadNewProducts()
        {
            db = DBServices.Connect();

            // Lấy tất cả sản phẩm từ Firestore
            var products = await db.Collection("SanPham").GetSnapshotAsync();


            // Mảng lưu trữ các DocumentID
            var productIds = new List<string>();

            // Lặp qua các sản phẩm và lấy DocumentID
            foreach (var product in products)
            {
                productIds.Add(product.Id); // Lưu DocumentID vào mảng
            }

            for (int i = productIds.Count - 1; i >= 0; i--)
            {
                var productDoc = await db.Collection("SanPham").Document(productIds[i]).GetSnapshotAsync();
                if (productDoc.GetValue<string>("TrangThai") == "Hết hàng" || productDoc.GetValue<string>("TenSP") == "Ngừng bán")
                {
                    // Xóa sản phẩm khỏi danh sách
                    productIds.RemoveAt(i);
                }
            }
            // Sắp xếp mảng DocumentID theo thứ tự giảm dần
            var sortedProductIds = productIds.OrderByDescending(id => id).Take(5).ToList();

            // Hiển thị 5 sản phẩm mới nhất
            foreach (var productId in sortedProductIds)
            {
                // Lấy thông tin sản phẩm từ Firestore
                var productDoc = await db.Collection("SanPham").Document(productId).GetSnapshotAsync();

                // Kiểm tra xem sản phẩm có tồn tại không
                if (productDoc.Exists)
                {
                    string name = productDoc.GetValue<string>("TenSP");
                    int price = productDoc.GetValue<int>("Gia");
                    string imageUrl = productDoc.GetValue<string>("HinhAnh");

                    // Tạo giao diện để hiển thị sản phẩm
                    var panel = new Panel { Width = 212, Height = 240, Margin = new Padding(3), BackColor = Color.PeachPuff, Tag = productId };
                    var labelName = new Label { Text = name, AutoSize = false, Size = new Size(150, 30), Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter, Location = new Point(30, 175) };
                    var labelPrice = new Label { Text = $"{price}", AutoSize = false, Size = new Size(150, 30), Font = new Font("Segoe UI", 10), TextAlign = ContentAlignment.MiddleCenter, Location = new Point(30, 203) };
                    var pictureBox = new PictureBox { Size = new Size(161, 157), SizeMode = PictureBoxSizeMode.Zoom, Margin = new Padding(3), Location = new Point(24, 15) };

                    // Tải hình ảnh sản phẩm
                    await LoadImageAsync(imageUrl, pictureBox);

                    panel.Controls.Add(labelPrice);
                    panel.Controls.Add(labelName);
                    panel.Controls.Add(pictureBox);

                    panel.Click += product_Click;
                    foreach (Control ctl in panel.Controls)
                        ctl.Click += product_Click;

                    flpNewSanPham.Controls.Add(panel);
                }
            }
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

        private async void LoadNewVouchers()
        {
            db = DBServices.Connect();

            // Lấy tất cả voucher từ Firestore
            var vouchers = await db.Collection("KhuyenMai").GetSnapshotAsync();

            // Mảng lưu trữ các DocumentID
            var voucherIds = new List<string>();

            // Lặp qua các voucher và lấy DocumentID
            foreach (var voucher in vouchers)
            {
                voucherIds.Add(voucher.Id); // Lưu DocumentID vào mảng
            }

            // Sắp xếp mảng DocumentID theo thứ tự giảm dần và lấy 4 voucher mới nhất
            var sortedVoucherIds = voucherIds.OrderByDescending(id => id).Take(3).ToList();

            // Hiển thị 4 voucher mới nhất
            foreach (var voucherId in sortedVoucherIds)
            {
                // Lấy thông tin voucher từ Firestore
                var voucherDoc = await db.Collection("KhuyenMai").Document(voucherId).GetSnapshotAsync();

                // Kiểm tra xem voucher có tồn tại không
                if (voucherDoc.Exists)
                {
                    int discount = voucherDoc.GetValue<int>("ChietKhau");  // Chiết khấu (%)
                    DateTime expiryDate = voucherDoc.GetValue<DateTime>("NgayKetThuc");  // Hạn sử dụng
                    int minOrderValue = voucherDoc.GetValue<int>("GiaToiThieu");  // Giá trị đơn hàng tối thiểu

                    var km = new KhuyenMai
                    {
                        ID = voucherId,
                        ChietKhau = discount,
                        GiamToiDa = voucherDoc.ContainsField("GiamToiDa") ? voucherDoc.GetValue<int>("GiamToiDa") : 0,
                        GiaToiThieu = minOrderValue,
                        NgayBatDau = voucherDoc.GetValue<DateTime>("NgayBatDau"),
                        NgayKetThuc = expiryDate,
                        NoiDung = voucherDoc.GetValue<string>("NoiDung")
                    };

                    // Tạo giao diện để hiển thị voucher
                    var panel = new Panel { Width = 321, Height = 102, Margin = new Padding(10), BackColor = Color.Orange };
                    var panel1 = new Panel { Width = 71, Height = 102, BackColor = Color.DarkOrange, Location = new Point(0, 0) };
                    var labelDiscount = new Label
                    {
                        Text = $"{discount}%",
                        AutoSize = false,
                        Size = new Size(63, 32),
                        Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(4, 31)
                    };
                    var labelExpiry = new Label
                    {
                        Text = $"HSD: {expiryDate:dd/MM/yyyy}",
                        AutoSize = false,
                        Size = new Size(218, 25),
                        Font = new Font("Segoe UI", 10),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(97, 48)
                    };
                    var labelMinOrder = new Label
                    {
                        Text = $"Đơn từ {minOrderValue:N0} đ",
                        AutoSize = false,
                        Size = new Size(112, 25),
                        Font = new Font("Segoe UI", 10),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(97, 23)
                    };

                    panel1.Controls.Add(labelDiscount);
                    panel.Controls.Add(panel1);
                    panel.Controls.Add(labelExpiry);
                    panel.Controls.Add(labelMinOrder);

                    panel.Tag = km;
                    panel.Click += voucher_Click;
                    foreach (Control ctl in panel.Controls)
                        ctl.Click += voucher_Click;

                    flpNewKhuyenMai.Controls.Add(panel);
                }
            }
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (Program.MaKH == "")
            {
                MessageBox.Show("Vui lòng đăng nhập để tiếp tục");
                Dangnhap dangnhap = new Dangnhap();
                dangnhap.Show();
                return;
            }
            this.Hide();
            Menu formMenu = new Menu(formDonHang); // tạo mới form Menu
            formMenu.Show(); // hiển thị form Menu
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dangnhap dangnhap = new Dangnhap();
            dangnhap.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            if (Program.MaKH == "")
            {
                MessageBox.Show("Vui lòng đăng nhập để tiếp tục");
                Dangnhap dangnhap = new Dangnhap();
                dangnhap.Show();
                return;
            }
            ThongTinTaiKhoan taiKhoan = new ThongTinTaiKhoan();
            taiKhoan.Size = this.Size;
            taiKhoan.Location = this.Location;
            taiKhoan.Show();
            this.Hide();
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Đóng tất cả các form và thoát chương trình
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            if (Program.MaKH == "")
            {
                MessageBox.Show("Vui lòng đăng nhập để tiếp tục");
                Dangnhap dangnhap = new Dangnhap();
                dangnhap.Show();
                return;
            }
            LienHeUser lienhe = new LienHeUser();
            lienhe.Size = this.Size;
            lienhe.Location = this.Location;
            lienhe.Show();
            this.Hide();
        }
    }
}