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
    public partial class UC_Ban : UserControl
    {
        public UC_Ban()
        {
            InitializeComponent();
            LoadBan();
        }
        private void LoadBan()
        {
            /*dgvBaverage.RowHeadersVisible = false; // Ẩn cột chọn hàng đầu tiên
            dgvBaverage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Cột giãn tự động


            // Tạo cột cho DataGridView
            dgvBaverage.Columns.Add("TenDoUong", "Tên đồ uống");
            dgvBaverage.Columns.Add("SoLuong", "Số lượng");

            // Thêm dữ liệu mẫu
            dgvBaverage.Rows.Add("Trà sữa trân châu", 2);
            dgvBaverage.Rows.Add("Matcha", 4);
            dgvBaverage.Rows.Add("Coffee sữa", 1);
            dgvBaverage.Rows.Add("Trà thảo mộc", 2);*/
        }
    }
}
