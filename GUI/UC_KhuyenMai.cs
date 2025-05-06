using Google.Cloud.Firestore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using TraSuaApp.Services;
using TraSuaApp;
using TraSuaApp.Models.Admin;
using System.Collections;

namespace TraSuaApp
{
    public partial class UC_KhuyenMai : UserControl
    {
        string collectionName = "KhuyenMai";
        public UC_KhuyenMai()
        {
            InitializeComponent();
            Listen();
        }

        public void setCouponHeader()
        {
            // Config
            dgvKM.AllowUserToAddRows = false;
            dgvKM.RowHeadersVisible = false;
            dgvKM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvKM.Columns["ID"].HeaderText = "Mã KM";
            dgvKM.Columns["NoiDung"].HeaderText = "Nội dung";
            dgvKM.Columns["ChietKhau"].HeaderText = "Chiết khấu";
            dgvKM.Columns["NgayBatDau"].HeaderText = "Ngày BĐ";
            dgvKM.Columns["NgayKetThuc"].HeaderText = "Ngày KT";
            dgvKM.Columns["GiamToiDa"].HeaderText = "Giảm tối đa";
            dgvKM.Columns["GiaToiThieu"].HeaderText = "Giá tối thiểu";

        }

        public void Listen()
        {
            // Lắng nghe
            FirestoreDb db = DBServices.Connect();
            db.Collection(collectionName).Listen(snapshot =>
            {
                List<KhuyenMai> danhSach = new List<KhuyenMai>();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    KhuyenMai obj = document.ConvertTo<KhuyenMai>();

                    danhSach.Add(obj);
                }

                // Cập nhật lại DataGridView
                dgvKM.Invoke(new Action(() =>
                {
                    dgvKM.DataSource = null; // Clear cũ
                    dgvKM.DataSource = danhSach; // Gán danh sách mới
                }));

                // Table Header
                setCouponHeader();
            });
        }

        private void dgvMenu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // RowIndex: Số thứ tự của hàng được click
            // Đảm bảo không click vào tiêu đề cột (RowIndex = -1)
            // SelectionMode: FullRowSelect
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKM.Rows[e.RowIndex];

                tbCouponID.Text = row.Cells["ID"].Value?.ToString();
                tbND.Text = row.Cells["NoiDung"].Value?.ToString();
                dtpBatDau.Text = row.Cells["NgayBatDau"].Value?.ToString();
                dtpBatDau.Text = row.Cells["NgayKetThuc"].Value?.ToString();
                tbChietKhau.Text = row.Cells["ChietKhau"].Value?.ToString();
                tbGTD.Text = row.Cells["GiamToiDa"].Value?.ToString();
                tbGTT.Text = row.Cells["GiaToiThieu"].Value?.ToString();
            }
        }

        private KhuyenMai createCoupon()
        {
            try
            {
                KhuyenMai sp = new KhuyenMai
                {
                    NoiDung = tbND.Text,
                    ChietKhau = int.Parse(tbChietKhau.Text),
                    NgayBatDau = DateTime.SpecifyKind(dtpBatDau.Value, DateTimeKind.Utc),
                    NgayKetThuc = DateTime.SpecifyKind(dtpKetThuc.Value, DateTimeKind.Utc),
                    GiamToiDa = int.Parse(tbGTD.Text),
                    GiaToiThieu = int.Parse(tbGTT.Text),
                };
                return sp;
            }
            catch
            {
                return null;
            }
        }

        private void LoadDanhSachKhuyenMai()
        {
            dgvKM.Columns.Clear();
            dgvKM.AllowUserToAddRows = false;
            dgvKM.RowHeadersVisible = false;
            dgvKM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            // Thêm dữ liệu mẫu
            dgvKM.Rows.Add("KM001", "Giảm giá hè", 10, "01/04/2025", "30/04/2025");
            dgvKM.Rows.Add("KM002", "Mừng lễ 30/4", 15, "25/04/2025", "01/05/2025");
            dgvKM.Rows.Add("KM003", "Giảm giá sinh nhật", 20, "10/05/2025", "20/05/2025");
            dgvKM.Rows.Add("KM004", "Ưu đãi khách hàng mới", 5, "01/04/2025", "31/05/2025");
            dgvKM.Rows.Add("KM005", "Khuyến mãi cuối tuần", 25, "06/04/2025", "07/04/2025");
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            await DBServices.POST(createCoupon(), collectionName, tbCouponID.Text.Trim());
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await DBServices.PUT(createCoupon(), collectionName, tbCouponID.Text.Trim());
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DBServices.DELETE(collectionName, tbCouponID.Text.Trim());
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            List<KhuyenMai> list = await DBServices.GET<KhuyenMai>(tbSearch.Text.Trim(), collectionName);

            // dgvMenu.Rows.Clear();

            if (list == null) return;

            // Xóa dữ liệu từ gridview
            dgvKM.DataSource = null;
            // Cập nhật dữ liệu 
            dgvKM.DataSource = list;

            // Table Header
            setCouponHeader();
        }
    }
}

