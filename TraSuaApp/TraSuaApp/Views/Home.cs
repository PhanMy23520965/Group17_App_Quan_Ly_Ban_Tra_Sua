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
using TraSuaApp.View;

namespace TraSuaApp.Views
{
    public partial class Home : Form
    {
        private DonHangUser donhang;
        public Home(DonHangUser formDonHang)
        {
            InitializeComponent();
            this.donhang = formDonHang;
            btnSanPhamDaMua_Click(btnSanPhamDaMua, EventArgs.Empty);
        }

        private void btnSanPhamDaMua_Click(object sender, EventArgs e)
        {
            btnSanPhamDaMua.FillColor = Color.FromArgb(69, 115, 161);
            btnSanPhamDaMua.ForeColor = Color.White;

            btnSanPhamMoi.FillColor = Color.Transparent;
            btnSanPhamMoi.ForeColor = Color.FromArgb(73, 126, 209);

            btnVoucher.FillColor = Color.Transparent;
            btnVoucher.ForeColor = Color.FromArgb(73, 126, 209);

            btnSanPhamHot.FillColor = Color.Transparent;
            btnSanPhamHot.ForeColor = Color.FromArgb(73, 126, 209);

            pnlHienThiHome.Controls.Clear();

            // Tạo form con
            SanPhamDaMua spdmForm = new SanPhamDaMua(donhang)
            {
                TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                Dock = DockStyle.Fill      // Hiển thị full trong panel
            };

            // Thêm form con vào panel và hiển thị
            pnlHienThiHome.Controls.Add(spdmForm);
            spdmForm.Show();
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            btnSanPhamDaMua.FillColor = Color.Transparent;
            btnSanPhamDaMua.ForeColor = Color.FromArgb(73, 126, 209);

            btnSanPhamHot.FillColor = Color.Transparent;
            btnSanPhamHot.ForeColor = Color.FromArgb(73, 126, 209);

            btnSanPhamMoi.FillColor = Color.Transparent;
            btnSanPhamMoi.ForeColor = Color.FromArgb(73, 126, 209);

            btnVoucher.FillColor = Color.FromArgb(69, 115, 161);
            btnVoucher.ForeColor = Color.White;

            pnlHienThiHome.Controls.Clear();

            // Tạo form con
            VoucherCuaBan vForm = new VoucherCuaBan()
            {
                TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                Dock = DockStyle.Fill      // Hiển thị full trong panel
            };

            // Thêm form con vào panel và hiển thị
            pnlHienThiHome.Controls.Add(vForm);
            vForm.Show();
        }

        private void btnSanPhamHot_Click(object sender, EventArgs e)
        {
            btnSanPhamDaMua.FillColor = Color.Transparent;
            btnSanPhamDaMua.ForeColor = Color.FromArgb(73, 126, 209);

            btnSanPhamMoi.FillColor = Color.Transparent;
            btnSanPhamMoi.ForeColor = Color.FromArgb(73, 126, 209);

            btnVoucher.FillColor = Color.Transparent;
            btnVoucher.ForeColor = Color.FromArgb(73, 126, 209);

            btnSanPhamHot.FillColor = Color.FromArgb(69, 115, 161);
            btnSanPhamHot.ForeColor = Color.White;

            pnlHienThiHome.Controls.Clear();

            // Tạo form con
            SanPhamHot sphForm = new SanPhamHot(donhang)
            {
                TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                Dock = DockStyle.Fill      // Hiển thị full trong panel
            };

            // Thêm form con vào panel và hiển thị
            pnlHienThiHome.Controls.Add(sphForm);
            sphForm.Show();
        }

        private void btnSanPhamMoi_Click(object sender, EventArgs e)
        {
            btnSanPhamDaMua.FillColor = Color.Transparent;
            btnSanPhamDaMua.ForeColor = Color.FromArgb(73, 126, 209);

            btnSanPhamHot.FillColor = Color.Transparent;
            btnSanPhamHot.ForeColor = Color.FromArgb(73, 126, 209);

            btnVoucher.FillColor = Color.Transparent;
            btnVoucher.ForeColor = Color.FromArgb(73, 126, 209);

            btnSanPhamMoi.FillColor = Color.FromArgb(69, 115, 161);
            btnSanPhamMoi.ForeColor = Color.White;

            pnlHienThiHome.Controls.Clear();

            // Tạo form con
            SanPhamNew spmForm = new SanPhamNew(donhang)
            {
                TopLevel = false,         // Đặt form con không phải là cửa sổ cấp cao nhất
                Dock = DockStyle.Fill      // Hiển thị full trong panel
            };

            // Thêm form con vào panel và hiển thị
            pnlHienThiHome.Controls.Add(spmForm);
            spmForm.Show();
        }
    }
}
