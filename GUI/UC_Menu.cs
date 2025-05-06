using System;
using System.Collections;
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
using Models.Admin;
using TraSuaApp.Services;

namespace TraSuaApp
{
    public partial class UC_Menu : UserControl
    {
        string collectionName = "SanPham";

        public UC_Menu()
        {
            InitializeComponent();
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
            FirestoreDb db = DBServices.Connect();
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
                }));

                // Table Header
                setProductHeader();
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

                tbProductID.Text = row.Cells["ID"].Value?.ToString();
                tbProductName.Text = row.Cells["TenSP"].Value?.ToString();
                tbPrice.Text = row.Cells["Gia"].Value?.ToString();
                tbType.Text = row.Cells["LoaiSP"].Value?.ToString();
                tbStatus.Text = row.Cells["TrangThai"].Value?.ToString();
                tbImage.Text = row.Cells["HinhAnh"].Value?.ToString();
            }
        }


        private SanPham createProduct()
        {
            try
            {
                SanPham sp = new SanPham
                {
                    TenSP = tbProductName.Text.Trim(),
                    Gia = int.Parse(tbPrice.Text),
                    LoaiSP = tbType.Text.Trim(),
                    TrangThai = tbStatus.Text.Trim(),
                    HinhAnh = tbImage.Text.Trim()
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
            await DBServices.POST(createProduct(), collectionName, tbProductID.Text.Trim());
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await DBServices.PUT(createProduct(), collectionName, tbProductID.Text.Trim());
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DBServices.DELETE(collectionName, tbProductID.Text.Trim());
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            List<SanPham> list = await DBServices.GET<SanPham>(tbSearch.Text.Trim(), collectionName);

            // dgvMenu.Rows.Clear();

            if (list == null) return;

            // Xóa dữ liệu từ gridview
            dgvMenu.DataSource = null;
            // Cập nhật dữ liệu 
            dgvMenu.DataSource = list;

            // Table Header
            setProductHeader();
        }
    }
}
