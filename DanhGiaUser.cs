using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
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

namespace TraSuaApp.View
{
    public partial class DanhGiaUser : Form
    {
        private DonHangUser donhang;
        private FirestoreDb db;
        private int Sao = 0;
        private DocumentReference MaDH = null;

        // Mảng chứa các nút ngôi sao
        private Guna2ImageButton[] starButtons;
        private bool isUpdating = false;
        public DanhGiaUser(DonHangUser formDonHang)
        {
            InitializeComponent();
            donhang = formDonHang;
            db = DBServices.Connect();
            //Luu tam MaDH
            MaDH = db.Collection("DonHang").Document("DH001");
            InitializeStarRating();
        }

        private void InitializeStarRating()
        {
            starButtons = new Guna2ImageButton[5];

            for (int i = 0; i < 5; i++)
            {
                starButtons[i] = new Guna2ImageButton
                {
                    ImageSize = new Size(80, 80),   // Kích thước hình ngôi sao
                    Size = new Size(80, 80),        // Kích thước nút
                    Location = new Point(290 + i * 80, 239),  // Vị trí
                    Image = Properties.Resources.saokhongdanhgia,  // Hình ngôi sao trống
                    Tag = i + 1,  // Số sao (1 đến 5)
                    Cursor = Cursors.Hand,
                    BackColor = Color.Transparent,
                    AutoSize = false,
                };

                // Sử dụng sự kiện Click
                starButtons[i].Click += StarButton_Click;

                // Thêm vào Panel hoặc Form
                pnlDanhGia.Controls.Add(starButtons[i]);
            }
        }

        private void StarButton_Click(object sender, EventArgs e)
        {
            Guna2ImageButton clickedStar = sender as Guna2ImageButton;
            int rating = (int)clickedStar.Tag;
            Sao = rating;

            // Cập nhật trạng thái cho tất cả các ngôi sao
            for (int i = 0; i < 5; i++)
            {
                if (i < rating)
                {
                    // Ngôi sao được chọn và trước đó đổi sang hình đầy
                    starButtons[i].Image = Properties.Resources.sao1;
                }
                else
                {
                    // Ngôi sao sau vị trí được chọn đổi sang hình trống
                    starButtons[i].Image = Properties.Resources.saokhongdanhgia;
                }
            }
        }


        private async void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (Sao==0)
            {
                MessageBox.Show("Hoàn thành form đánh giá nha khách iu!!! Cảm ơn bạn nhìu :3");
                return;
            }
            try
            {
                // Tạo ID tự động cho đánh giá
                string docID = await TaoDocumentID();

                if (docID == null)
                {
                    MessageBox.Show("Không thể tạo ID đánh giá.", "Lỗi");
                    return;
                }

                // Tạo đối tượng đánh giá
                DanhGia danhGia = new DanhGia
                {
                    MaKH = db.Collection("KhachHang").Document(Program.MaKH),
                    MaDH = MaDH,
                    NoiDung = rtbBinhLuan.Text,
                    SaoDG = Sao,
                };

                // Thêm vào Firestore
                DocumentReference docRef = db.Collection("DanhGia").Document(docID);
                await docRef.SetAsync(danhGia);

                MessageBox.Show("Cảm ơn bạn đã đánh giá ạ !!!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi đánh giá: {ex.Message}", "Lỗi");
            }
        }

        private async Task<string> TaoDocumentID()
        {
            try
            {
                // Lấy danh sách tất cả các document trong bộ sưu tập "DanhGia"
                CollectionReference danhGiaRef = db.Collection("DanhGia");
                QuerySnapshot snapshot = await danhGiaRef.GetSnapshotAsync();

                // Số lượng đánh giá hiện có
                int count = snapshot.Count;

                // Tạo ID mới dạng "DG001", "DG002", ...
                string newID = $"DG{(count + 1).ToString("D3")}";
                return newID;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo ID đánh giá: {ex.Message}", "Lỗi");
                return null;
            }
        }
    }
}
