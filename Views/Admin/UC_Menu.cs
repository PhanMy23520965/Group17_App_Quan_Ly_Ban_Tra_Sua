using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Models;
using TraSuaApp.Services;

namespace TraSuaApp.Views.Admin
{
    public partial class UC_Menu : UserControl
    {
        string collectionName = "SanPham";
        FirestoreDb db = DBServices.Connect();

        public UC_Menu()
        {
            InitializeComponent();

            string[] Status = { "", "Còn hàng", "Hết hàng" };
            cbTrangThai.Items.AddRange(Status);

            // Đảm bảo header được hiển thị
            dgvMenu.ColumnHeadersVisible = true;
            dgvMenu.ColumnHeadersHeight = 40;
            Listen();
        }

        public void setProductHeader()
        {
            dgvMenu.Columns["ID"].HeaderText = "Mã sản phẩm";
            dgvMenu.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvMenu.Columns["Gia"].HeaderText = "Giá bán";
            dgvMenu.Columns["LoaiSP"].HeaderText = "Loại";
            dgvMenu.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvMenu.Columns["HinhAnh"].HeaderText = "Hình ảnh";
        }

        public void Listen()
        {
            // Lắng nghe
            db.Collection(collectionName).Listen(snapshot =>
            {
                List<SanPham> danhSach = new List<SanPham>();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    SanPham obj = document.ConvertTo<SanPham>();
                    danhSach.Add(obj);
                }

                // Cập nhật lại DataGridView
                dgvMenu.Invoke(new Action(() =>
                {
                    dgvMenu.DataSource = null; // Clear cũ
                    dgvMenu.DataSource = danhSach; // Gán danh sách mới
                    // Table Header
                    setProductHeader();
                }));
            });
        }

        private void dgvMenu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // RowIndex: Số thứ tự của hàng được click
            // Đảm bảo không click vào tiêu đề cột (RowIndex = -1)
            // SelectionMode: FullRowSelect
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];

                tbMaSP.Text = row.Cells["ID"].Value?.ToString();
                tbTenSP.Text = row.Cells["TenSP"].Value?.ToString();
                tbGia.Text = row.Cells["Gia"].Value?.ToString();
                tbLoai.Text = row.Cells["LoaiSP"].Value?.ToString();
                tbTT.Text = row.Cells["TrangThai"].Value?.ToString();
                tbHA.Text = row.Cells["HinhAnh"].Value?.ToString();
            }
        }


        private SanPham createProduct()
        {
            try
            {
                SanPham sp = new SanPham
                {
                    TenSP = tbTenSP.Text.Trim(),
                    Gia = double.Parse(tbGia.Text),
                    LoaiSP = tbLoai.Text.Trim(),
                    TrangThai = tbTT.Text.Trim(),
                    HinhAnh = tbHA.Text.Trim()
                };
                return sp;
            }
            catch
            {
                return null;
            }
        }

        // 
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            await DBServices.POST1(createProduct(), collectionName, tbMaSP.Text.Trim());
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await DBServices.PUT1(createProduct(), collectionName, tbMaSP.Text.Trim());
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DBServices.DELETE1(collectionName, tbMaSP.Text.Trim(), "", "");
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            List<SanPham> list = await DBServices.GET1<SanPham>(tbSearch.Text.Trim(), collectionName, "", "");

            // dgvMenu.Rows.Clear();

            List<SanPham> filtered_list = null;
            bool isMinValid = double.TryParse(Min.Text.Trim(), out double min);
            bool isMaxValid = double.TryParse(Max.Text.Trim(), out double max);
            string status = cbTrangThai.Text.Trim();

            try
            {
                // Chỉ nhập 1 
                if ((Min.Text.Trim() != "" && Max.Text.Trim() == "") || (Min.Text.Trim() == "" && Max.Text.Trim() != ""))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ giá tiền tối thiểu và giá tiền tối đa!");
                    return;
                }
                // Nhập cả 2
                else if (Min.Text.Trim() != "" && Max.Text.Trim() != "")
                {
                    if (isMinValid && isMaxValid)
                    {
                        filtered_list = status == "" ?
                            list.Where(sp => min <= sp.Gia && sp.Gia <= max).ToList() :
                            list.Where(sp => min <= sp.Gia && sp.Gia <= max && sp.TrangThai == status).ToList();
                    }
                    else MessageBox.Show("Giá tiền không hợp lệ!");
                }
                else if (Min.Text.Trim() == "" && Max.Text.Trim() == "" && status != "")
                    filtered_list = list.Where(sp => sp.TrangThai == status).ToList();
            }
            catch
            {
                MessageBox.Show("Tìm kiếm thất bại!");
            }

            if (list == null) return;

            // Xóa dữ liệu từ gridview
            dgvMenu.DataSource = null;
            // Cập nhật dữ liệu 
            dgvMenu.DataSource = filtered_list != null ? filtered_list : list;

            // Table Header
            setProductHeader();
        }
    }
}
