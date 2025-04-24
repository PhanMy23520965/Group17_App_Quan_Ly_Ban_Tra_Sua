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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadControl(new UC_Menu());
        }

        public void LoadControl(UserControl uc)
        {
            pnMain.Controls.Clear(); // Xóa nội dung cũ
            /*uc.Dock = DockStyle.Fill;  // Kéo giãn toàn bộ panel*/
            pnMain.Controls.Add(uc);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_Menu());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_DonHang());
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_LienHe());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_AdminProfile());
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_Ban());
        }

        private void btnKM_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_KhuyenMai());
        }
    }
}
