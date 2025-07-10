using Google.Cloud.Firestore;
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

namespace TraSuaApp.Views
{
    public partial class Khuyenmai : Form
    {
        private readonly string MaDH;

        //Truyền vào maKH là MaKH hiện tại đang đăng nhập và maDH
        public Khuyenmai(string maDH)
        {
            InitializeComponent();
            MaDH = maDH;
            this.Load += Khuyenmai_Load;
        }

        private async void Khuyenmai_Load(object sender, EventArgs e)
        {
            await LoadKhuyenMaiAsync(); // Chờ load xong các voucher, khách hàng mới được phép thao tác
        }

        private KhuyenMai kmDaChon = null;
        private Panel panelDangChon = null;

        private async Task LoadKhuyenMaiAsync()
        {
            flowKhuyenMai.Controls.Clear();

            FirestoreDb db = DBServices.Connect();

            var khRef = db.Collection("KhachHang").Document(Dangnhap.MaKH);
            //Lấy collection con (Khuyến mãi) của khách hàng hiện tại đang đăng nhập
            var kmUserRef = khRef.Collection("KhuyenMai");

            QuerySnapshot snapshot = await kmUserRef.GetSnapshotAsync();

            foreach (var doc in snapshot.Documents)
            {
                var data = doc.ToDictionary();

                // 1. Kiểm tra đã dùng chưa
                if (data.ContainsKey("DaSuDung") && (bool)data["DaSuDung"] == true)
                    continue;

                // 2. Lấy MaKM (DocumentReference)
                if (!data.ContainsKey("MaKM") || !(data["MaKM"] is DocumentReference maKMRef))
                    continue;

                // 3. Lấy thông tin từ bảng gốc KhuyenMai + kiểm tra thời gian
                DocumentSnapshot kmDoc = await maKMRef.GetSnapshotAsync();
                if (!kmDoc.Exists) continue;

                var kmData = kmDoc.ToDictionary();

                KhuyenMai km = new KhuyenMai
                {
                    ID = kmDoc.Id,
                    ChietKhau = Convert.ToByte(kmData["ChietKhau"]),
                    NgayBatDau = ((Timestamp)kmData["NgayBatDau"]).ToDateTime(),
                    NgayKetThuc = ((Timestamp)kmData["NgayKetThuc"]).ToDateTime(),
                    GiaToiThieu = Convert.ToDecimal(kmData["GiaToiThieu"]),
                    GiamToiDa = Convert.ToDecimal(kmData["GiamToiDa"]),
                    NoiDung = kmData.ContainsKey("NoiDung") ? kmData["NoiDung"].ToString() : ""
                };

                //Bỏ qua nếu chưa tới ngày bắt đầu hoặc đã hết hạn
                if (DateTime.Now < km.NgayBatDau || DateTime.Now > km.NgayKetThuc)
                    continue;

                // 4. Tạo panel voucher
                // Tạo hình tròn nền trước
                var circleBg = new Guna.UI2.WinForms.Guna2GradientPanel
                {
                    Size = new Size(100, 100),
                    Location = new Point(220, 25),
                    BorderRadius = 50,
                    GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal,
                    FillColor = Color.FromArgb(204, 255, 255),   // xanh nhạt
                    FillColor2 = Color.FromArgb(255, 255, 204),  // vàng nhạt
                    BackColor = Color.Transparent
                };

                // Label chiết khấu
                Label lbl = new Label
                {
                    Text = $"{km.ChietKhau}%",
                    Font = new Font("Segoe UI", 32, FontStyle.Bold | FontStyle.Italic),
                    ForeColor = Color.OrangeRed,
                    BackColor = Color.Transparent,
                    AutoSize = true
                };

                // Căn giữa label
                lbl.Location = new Point(
                    (circleBg.Width - lbl.PreferredWidth) / 2,
                    (circleBg.Height - lbl.PreferredHeight) / 2
                );

                circleBg.Controls.Add(lbl);

                // Sau đó mới tạo panel, gán cả km + circleBg vào Tag
                var panel = new System.Windows.Forms.Panel
                {
                    Size = new Size(360, 150),
                    BackgroundImage = Properties.Resources.voucher,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Cursor = Cursors.Hand,
                    Tag = new object[] { km, circleBg },
                    Margin = new Padding(20, 10, 20, 10)
                };

                // Thêm hình tròn vào panel
                panel.Controls.Add(circleBg);

                // 6. Sự kiện click
                panel.Click += (s, e) => XuLyClickKhuyenMai(km, panel);
                circleBg.Click += (s, e) => XuLyClickKhuyenMai(km, panel);
                lbl.Click += (s, e) => XuLyClickKhuyenMai(km, panel);

                flowKhuyenMai.Controls.Add(panel);
            }
        }

        private decimal TongTienSauKM = 0;
        // Chỉ được chọn 1 khuyến mãi
        private async void XuLyClickKhuyenMai(KhuyenMai km, Panel panel)
        {
            // Gỡ đánh dấu panel cũ nếu có
            if (panelDangChon != null)
            {
                panelDangChon.BorderStyle = BorderStyle.None;
                panelDangChon.BackColor = Color.Transparent;

                // Lấy lại circle cũ nếu có để đổi lại màu nhạt
                if (panelDangChon.Tag is object[] tagArrOld && tagArrOld[1] is Guna.UI2.WinForms.Guna2GradientPanel oldCircle)
                {
                    oldCircle.FillColor = Color.FromArgb(204, 255, 255); // màu nhạt lại
                    oldCircle.FillColor2 = Color.FromArgb(255, 255, 204);
                }
            }

            // Đánh dấu panel mới
            panelDangChon = panel;
            if (panel.Tag is object[] tagArrNew && tagArrNew[1] is Guna.UI2.WinForms.Guna2GradientPanel newCircle)
            {
                newCircle.FillColor = Color.FromArgb(102, 204, 204);  // xanh đậm
                newCircle.FillColor2 = Color.FromArgb(255, 204, 102); // vàng đậm
            }

            string thongBao = "";

            if (kmDaChon != null)
            {
                string thongBaoBoChon = $"Bạn đã bỏ chọn voucher mã: {kmDaChon.ID}";
                MessageBox.Show(thongBaoBoChon, "Đã bỏ chọn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Reset để in voucher mới
            thongBao = "";

            // Lấy đơn hàng hiện tại từ Firestore
            FirestoreDb db = DBServices.Connect();
            DocumentReference dhRef = db.Collection("DonHang").Document(MaDH);
            DocumentSnapshot dhSnap = await dhRef.GetSnapshotAsync();

            decimal tongTien = 0; //Lưu giá trị tổng tiền khi chưa áp dụng khuyến mãi

            if (dhSnap.Exists && dhSnap.ContainsField("TongTien"))
                tongTien = Convert.ToDecimal(dhSnap.GetValue<double>("TongTien"));

            // Kiểm tra tổng tiền có đạt mức tối thiểu không
            if (tongTien < km.GiaToiThieu)
            {
                thongBao += $"❌ Đơn hàng hiện tại không đủ điều kiện để áp dụng voucher này.\n" +
                            $"- Yêu cầu tối thiểu: {km.GiaToiThieu:N0}đ\n" +
                            $"- Tổng tiền hiện tại: {tongTien:N0}đ\n\n" +
                            $"Vui lòng chọn một voucher khác phù hợp.";

                //Gỡ màu panel cũ
                panelDangChon.BorderStyle = BorderStyle.None;
                panelDangChon.BackColor = Color.Transparent;

                // Lấy lại circle cũ nếu có để đổi lại màu nhạt
                if (panelDangChon.Tag is object[] tagArrOld && tagArrOld[1] is Guna.UI2.WinForms.Guna2GradientPanel oldCircle)
                {
                    oldCircle.FillColor = Color.FromArgb(204, 255, 255); // màu nhạt lại
                    oldCircle.FillColor2 = Color.FromArgb(255, 255, 204);
                }

                // Bỏ chọn voucher
                kmDaChon = null;
                panelDangChon = null;
                panel.BorderStyle = BorderStyle.None;

                MessageBox.Show(thongBao, "Không đủ điều kiện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán voucher được chọn
            kmDaChon = km;

            // Cập nhật mã KM vào đơn hàng trong Firestore
            Dictionary<string, object> update = new Dictionary<string, object>
            {
                { "MaKM", km.ID }
            };

            await dhRef.UpdateAsync(update);

            // Tính số tiền đc giảm (giới hạn theo GiamToiDa)
            decimal giamGia = ((decimal)km.ChietKhau / 100m) * tongTien;
            if (giamGia > km.GiamToiDa)
                giamGia = km.GiamToiDa;

            //Tính Tổng tiền sau KM
            TongTienSauKM = tongTien - giamGia;

            // Thông báo chi tiết
            thongBao += $"Bạn đã chọn voucher:\n" +
                        $"- Mã: {km.ID}\n" +
                        $"- Chiết khấu: {km.ChietKhau}%\n" +
                        $"- Giảm tối đa: {km.GiamToiDa:N0}đ\n" +
                        $"- Tổng tiền đơn hàng: {tongTien:N0}đ\n" +
                        $"- Số tiền giảm: {giamGia:N0}đ\n" +
                        $"- Tổng tiền sau khuyến mãi: {TongTienSauKM:N0}đ";

            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Mở form mới sau khi đóng tất cả form cũ
            Thanhtoan thanhtoan = new Thanhtoan(MaDH, TongTienSauKM);  // Khởi tạo form mới

            pnlHienThi.Controls.Clear();

            thanhtoan.TopLevel = false;
            thanhtoan.Dock = DockStyle.Fill;

            // Thêm form con vào panel1
            pnlHienThi.Controls.Add(thanhtoan);

            // Hiển thị form con
            thanhtoan.Show();
        }
    }
}
