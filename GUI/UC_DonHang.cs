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
    public partial class UC_DonHang : UserControl
    {
        public UC_DonHang()
        {
            InitializeComponent();
            LoadDonHang();
        }


        private void LoadDonHang()
        {
            dgvDonHang.RowHeadersVisible = false; // Ẩn cột chọn hàng đầu tiên
            dgvDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Cột giãn tự động

            // Tạo cột cho DataGridView
            dgvDonHang.Columns.Add("TenKhachHang", "Tên khách hàng");
            dgvDonHang.Columns.Add("MaDonHang", "Mã đơn hàng");
            dgvDonHang.Columns.Add("NgayDat", "Ngày đặt");
            dgvDonHang.Columns.Add("TongTien", "Tổng Tiền");
            dgvDonHang.Columns.Add("ThanhToan", "Thanh toán");
            dgvDonHang.Columns.Add("BanDat", "Bán đặt");
            // dgvHDList.Columns.Add("KhuyenMai", "Khuyến mãi");

            // Thêm dữ liệu mẫu
            dgvDonHang.Rows.Add("Táo xanh chua lệ", "DH00000001", "31/3/2025", "100,000", "Tiền mặt", "Mang về");
            dgvDonHang.Rows.Add("Lê ngọt mùa thu", "DH00000002", "01/4/2025", "120,000", "Chuyển khoản", "Tại quán");
            dgvDonHang.Rows.Add("Cam vàng óng ánh", "DH00000003", "02/4/2025", "80,000", "Tiền mặt", "Mang về");
            dgvDonHang.Rows.Add("Dứa thơm nhiệt đới", "DH00000004", "03/4/2025", "150,000", "Chuyển khoản", "Tại quán");
            dgvDonHang.Rows.Add("Chanh dây chua mát", "DH00000005", "04/4/2025", "90,000", "Tiền mặt", "Mang về");
        }


    }
}
