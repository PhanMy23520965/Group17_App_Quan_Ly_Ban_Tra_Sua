using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraSuaApp
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        public void LoadControl(UserControl uc)
        {
            pnMain.Controls.Clear(); // Xóa nội dung cũ
            uc.Dock = DockStyle.Fill;  // Kéo giãn toàn bộ panel
            pnMain.Controls.Add(uc);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // LoadControl(new UC_UserHome());
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            // LoadControl(new UC_UserMenu());
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            // LoadControl(new UC_UserDonHang());
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            // LoadControl(new UC_UserLienHe());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadControl(new UC_UserProfile());
        }
    }
}
