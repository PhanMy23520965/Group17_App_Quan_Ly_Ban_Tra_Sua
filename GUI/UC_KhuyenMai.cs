using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GD
{
    public partial class UC_KhuyenMai : UserControl
    {
        public UC_KhuyenMai()
        {
            InitializeComponent();
            LoadDanhSachKhuyenMai();
        }

        private void LoadDanhSachKhuyenMai()
        {
            dgvKhuyenMai.Columns.Clear();
            dgvKhuyenMai.AllowUserToAddRows = false;
            dgvKhuyenMai.RowHeadersVisible = false;
            dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhuyenMai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Tạo các cột
            dgvKhuyenMai.Columns.Add("MaKM", "Mã KM");
            dgvKhuyenMai.Columns.Add("TenKM", "Tên Khuyến Mãi");
            dgvKhuyenMai.Columns.Add("GiamGia", "Giảm Giá (%)");
            dgvKhuyenMai.Columns.Add("NgayBatDau", "Ngày Bắt Đầu");
            dgvKhuyenMai.Columns.Add("NgayKetThuc", "Ngày Kết Thúc");

            // Thêm dữ liệu mẫu
            dgvKhuyenMai.Rows.Add("KM001", "Giảm giá hè", 10, "01/04/2025", "30/04/2025");
            dgvKhuyenMai.Rows.Add("KM002", "Mừng lễ 30/4", 15, "25/04/2025", "01/05/2025");
            dgvKhuyenMai.Rows.Add("KM003", "Giảm giá sinh nhật", 20, "10/05/2025", "20/05/2025");
            dgvKhuyenMai.Rows.Add("KM004", "Ưu đãi khách hàng mới", 5, "01/04/2025", "31/05/2025");
            dgvKhuyenMai.Rows.Add("KM005", "Khuyến mãi cuối tuần", 25, "06/04/2025", "07/04/2025");
        }
    }
}
