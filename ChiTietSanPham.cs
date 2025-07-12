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
using TraSuaApp.Models;
using TraSuaApp.Models.Admin;
using TraSuaApp.Services;

namespace TraSuaApp.View
{
    public partial class ChiTietSanPham : Form
    {
        private DonHangUser donhang; // tham chiếu tới form giỏ hàng
        private SanPham Sp;
        private string AnhSanPham = "";
        private FirestoreDb db = DBServices.Connect();
        private Guna.UI2.WinForms.Guna2WinProgressIndicator loadingDanhGia;

        public ChiTietSanPham(SanPham sp, DonHangUser formDonHang)
        {
            InitializeComponent();

            loadingDanhGia = new Guna2WinProgressIndicator
            {
                Name = "loadingDanhGia",
                Size = new Size(60, 60),
                CircleSize = 1.0F,
                ProgressColor = Color.FromArgb(255, 141, 31),
                BackColor = Color.Transparent,
                Visible = false,
                Location = new Point(this.Width / 2 - 30, this.Height / 2 - 30), // Canh giữa
                Anchor = AnchorStyles.None
            };
            this.Controls.Add(loadingDanhGia);

            lblTen.Text = sp.TenSP;
            lblGia.Text = sp.Gia.ToString("N0") + " VND";
            lblTrangThai.Text = sp.TrangThai.ToUpper();
            if (sp.TrangThai.ToLower() != "còn hàng") lblTrangThai.ForeColor = Color.Red;
            else lblTrangThai.ForeColor = Color.DarkGreen;
            AnhSanPham = sp.HinhAnh;
            Sp = sp;

            HienThiDanhGia(Sp.ID);

            try
            {
                picBoxAnhLon.Load(sp.HinhAnh);
                picBoxAnhNho.Load(sp.HinhAnh);
            }
            catch
            {
                picBoxAnhLon.Image = null;
                picBoxAnhNho.Image = null;
            }

            this.donhang = formDonHang;
        }

        private void btnMuaNgay_Click(object sender, EventArgs e)
        {
            if (lblTrangThai.Text?.ToLower() == "hết hàng" || lblTrangThai.Text?.ToLower() == "ngừng bán")
            {
                MessageBox.Show($"{lblTen} hiện đang hết hàng. Vui lòng chọn sản phẩm khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xác định size được chọn
            string size = "S"; // mặc định

            if (rbtnM.Checked) size = "M";
            else if (rbtnL.Checked) size = "L";
            else if (rbtnS.Checked) size = "S";

            // Tạo chi tiết đơn hàng mới
            FirestoreDb db = DBServices.Connect();
            ChiTietDonHangTam ct = new ChiTietDonHangTam
            {
                MaSP = Sp.ID,
                TenSP = Sp.TenSP,
                HinhAnh = Sp.HinhAnh,
                GiaBan = Sp.Gia,
                SoLuong = 1,
                Size = "S",
                ThanhTien = Sp.Gia
            };

            // Tính tiền theo size
            double heSo = 1.0;
            if (size == "M") heSo = 1.3;
            else if (size == "L") heSo = 1.5;

            ct.ThanhTien = ct.GiaBan * ct.SoLuong * heSo;

            // Gọi form giỏ hàng để thêm
            donhang.ThemChiTietVaoGiaoDien(ct);

            // thông báo
            MessageBox.Show("Đã thêm vào giỏ hàng!");
        }

        private async Task<List<DanhGia>> LayDanhGiaTheoSanPham(string maSP)
        {
            List<DanhGia> danhSachDanhGia = new List<DanhGia>();

            try
            {
                // 1. Chuyển maSP từ string sang DocumentReference
                DocumentReference spRef = db.Collection("SanPham").Document(maSP);

                // 2. Truy vấn tất cả các đơn hàng
                QuerySnapshot donHangSnapshot = await db.Collection("DonHang").GetSnapshotAsync();

                List<DocumentReference> dsMaDH = new List<DocumentReference>();

                foreach (DocumentSnapshot donHangDoc in donHangSnapshot.Documents)
                {
                    // 3. Lấy subcollection ChiTietDonHang của từng đơn hàng
                    CollectionReference chiTietRef = donHangDoc.Reference.Collection("ChiTietDonHang");

                    Query chiTietQuery = chiTietRef.WhereEqualTo("MaSP", spRef);
                    QuerySnapshot chiTietSnapshot = await chiTietQuery.GetSnapshotAsync();

                    // 4. Lấy MaDH nếu có sản phẩm trùng khớp
                    if (chiTietSnapshot.Count > 0)
                    {
                        dsMaDH.Add(donHangDoc.Reference);  // Thêm MaDH vào danh sách
                    }
                }

                if (dsMaDH.Count == 0) return danhSachDanhGia; // Không có đánh giá nào

                // 2. Lấy các đánh giá từ MaDH
                Query danhGiaQuery = db.Collection("DanhGia")
                                       .WhereIn("MaDH", dsMaDH);

                QuerySnapshot danhGiaSnapshot = await danhGiaQuery.GetSnapshotAsync();

                foreach (DocumentSnapshot doc in danhGiaSnapshot.Documents)
                {
                    DanhGia danhGia = doc.ConvertTo<DanhGia>();
                    danhGia.ID = doc.Id;
                    danhSachDanhGia.Add(danhGia);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy đánh giá: {ex.Message}");
            }

            return danhSachDanhGia;
        }



        private async Task<string> LayTenKhachHang(DocumentReference maKH)
        {
            try
            {
                DocumentSnapshot doc = await maKH.GetSnapshotAsync();
                if (doc.Exists && doc.ContainsField("TenKH"))
                {
                    return doc.GetValue<string>("TenKH");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy tên khách hàng: {ex.Message}", "Lỗi");
            }
            return "Khách hàng ẩn danh";
        }

        private async void HienThiDanhGia(string maSP)
        {
            try
            {
                // Xóa các đánh giá cũ trong panel
                flpDanhGia.Controls.Clear();
                loadingDanhGia.Visible = true;
                loadingDanhGia.Start();

                // Lấy danh sách đánh giá từ Firestore
                List<DanhGia> danhGiaList = await LayDanhGiaTheoSanPham(maSP);

                foreach (var danhGia in danhGiaList)
                {
                    // Lấy tên khách hàng từ DocumentReference
                    string tenKH = await LayTenKhachHang(danhGia.MaKH);

                    // Tạo Panel con chứa đánh giá
                    Panel pnlDanhGia = new Panel
                    {
                        Width = flpDanhGia.Width - 50,
                        Height = 110,
                        Margin = new Padding(5),
                        BackColor = Color.Transparent,
                    };

                    PictureBox pic = new PictureBox
                    {
                        Image = Properties.Resources.daunguoi,
                        Location = new Point(25, 5),
                        Size = new Size(50, 40),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        TabIndex = 2,
                        TabStop = false,
                    };


                    // Tên khách hàng
                    Label lblTenKH = new Label
                    {
                        Text = $"{tenKH}",
                        Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                        Location = new Point(71, 10),
                        ForeColor = Color.Black,
                        AutoSize = true,
                    };

                    pnlDanhGia.Controls.Add(pic);
                    pnlDanhGia.Controls.Add(lblTenKH);

                    // Hiển thị số sao

                    Panel pnlsao = new Panel
                    {
                        Location = new Point(lblTenKH.Location.X + lblTenKH.Width + 5, lblTenKH.Location.Y-4),
                        BackColor = Color.Transparent,
                        Size = new Size(205, 41),
                    };

                    Guna2PictureBox[] starts = new Guna2PictureBox[5];
                    for(int i=0;i<danhGia.SaoDG;++i)
                    {
                        starts[i] = new Guna2PictureBox
                        {
                            Image = Properties.Resources.sao,
                            Size = new Size(34, 38),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            TabStop = false,
                            Location = new Point(34 * i, 0),
                        };

                        pnlsao.Controls.Add(starts[i]);
                    }
                    for(int i=danhGia.SaoDG;i<5;++i)
                    {
                        starts[i] = new Guna2PictureBox
                        {
                            Image = Properties.Resources.saokhongsanpham,
                            Size = new Size(34, 38),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Location = new Point(34 * i, 0),
                        };

                        pnlsao.Controls.Add(starts[i]);
                    }

                    pnlDanhGia.Controls.Add(pnlsao);

                    // Hiển thị nội dung đánh giá
                    Label lblNoiDung = new Label
                    {
                        Text = $"{danhGia.NoiDung}",
                        Font = new Font("Segoe UI", 10),
                        AutoSize = true,
                        ForeColor = Color.Black,
                        Location = new Point(25, 50),
                        Padding = new Padding(5),

                    };
                    pnlDanhGia.Controls.Add(lblNoiDung);

                    // Thêm panel đánh giá vào FlowLayoutPanel
                    flpDanhGia.Controls.Add(pnlDanhGia);
                }

                if (danhGiaList.Count == 0)
                {
                    Label lblThongBao = new Label
                    {
                        Text = "Chưa có đánh giá nào cho sản phẩm này.",
                        Font = new Font("Segoe UI", 12, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Margin = new Padding(5),
                    };
                    flpDanhGia.Controls.Add(lblThongBao);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị đánh giá: {ex.Message}", "Lỗi");
            }
            finally
            {
                loadingDanhGia.Stop();
                loadingDanhGia.Visible = false;
            }
        }

    }
}
