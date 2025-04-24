using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Models;

namespace GD
{
    public partial class UC_Menu : UserControl
    {
        

        public UC_Menu()
        {
            InitializeComponent();
            LoadDanhSachSanPham();
        }

        private void LoadDanhSachSanPham()
        {
            /*dgvMenu.RowHeadersVisible = false; // Ẩn cột chọn hàng đầu tiên
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Cột giãn tự động

            // Tạo cột cho DataGridView
            dgvMenu.Columns.Add("MaSP", "Mã Sản Phẩm");
            dgvMenu.Columns.Add("TenSP", "Tên Sản Phẩm");
            dgvMenu.Columns.Add("Gia", "Giá");
            dgvMenu.Columns.Add("LoaiSP", "Loại");
            dgvMenu.Columns.Add("TrangThai", "Trạng Thái");
            dgvMenu.Columns.Add("HinhAnh", "Hình ảnh");

            // Thêm một số dòng dữ liệu mẫu
            dgvMenu.Rows.Add("SP001", "Cà phê đen", 10000, "Cà Phê", "Còn hàng", "");
            dgvMenu.Rows.Add("SP002", "Cà phê sữa", 12000, "Cà Phê", "Còn hàng", "");
            dgvMenu.Rows.Add("SP003", "Bạc xỉu", 15000, "Cà Phê", "Còn hàng", "");
            dgvMenu.Rows.Add("SP004", "Cam vắt", 10000, "Nước ép", "Còn hàng", "");
            dgvMenu.Rows.Add("SP005", "Trà Sữa Truyền Thống", 30000, "Đồ uống", "Còn hàng", "");
            dgvMenu.Rows.Add("SP006", "Trà Đào", 35000, "Đồ uống", "Hết hàng", "");*/
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {

        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            // B1: Kết nối Firestore
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "firebase-adminsdk.json");
            FirestoreDb db = FirestoreDb.Create("quan-ly-quan-tra", new FirestoreClientBuilder
            {
                CredentialsPath = "Resources\\firebase-adminsdk.json"
            }.Build());

            // B1: Tạo object
            SanPham sp = new SanPham
            {
                TenSP = tbProductName.Text.Trim(),
                Gia = decimal.Parse(tbPrice.Text),
                Loai = tbType.Text.Trim(),
                TrangThai = tbStatus.Text.Trim(),
                HinhAnh = tbImage.Text.Trim()
            };

            // B2: Gửi lên Firestore như 1 POST
            // Truy cập collection "products"
            CollectionReference collection = db.Collection("SanPham");

            // Thiết lập ID thủ công
            DocumentReference docRef = collection.Document(tbProductID.Text.Trim());

            // Thêm tài liệu với ID được chỉ định
            await docRef.SetAsync(sp);

            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }
    }
}
