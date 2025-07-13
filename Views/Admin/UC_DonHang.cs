using Google.Cloud.Firestore;
using Models;
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
using Google.Type;
using System.Linq.Expressions;
using static Google.Cloud.Firestore.V1.StructuredQuery.Types;

namespace TraSuaApp.Views.Admin
{
    public partial class UC_DonHang : UserControl
    {
        string collectionName = "DonHang";
        string subCollectionName = "ChiTietDonHang";
        FirestoreDb db = DBServices.Connect();

        public UC_DonHang()
        {
            InitializeComponent();
            dgvDH.ColumnHeadersVisible = dgvCTDH.ColumnHeadersVisible =  true;
            dgvDH.ColumnHeadersHeight = dgvCTDH.ColumnHeadersHeight = 40;
            Listen();

            string[] options = { "", "Chưa thanh toán", "Đã thanh toán" };
            cbTrangThaiDH.Items.AddRange(options);
            cbTrangThai.Items.AddRange(options);
        }

        public void setOrderHeader()
        {
            dgvDH.Invoke(new Action(() =>
            {
                dgvDH.Columns["ID"].HeaderText = "Mã Đơn Hàng";
                dgvDH.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                dgvDH.Columns["NgayDat"].HeaderText = "Ngày Đặt";
                dgvDH.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvDH.Columns["MaKM"].HeaderText = "Mã Khuyến Mãi";
                dgvDH.Columns["TrangThai"].HeaderText = "Trạng Thái";
                dgvDH.Columns["GhiChu"].HeaderText = "Ghi Chú";
            }));
        }

        public void setDetailOrderHeader()
        {
            dgvCTDH.Invoke(new Action(() =>
            {
                dgvCTDH.Columns["ID"].HeaderText = "Mã Chi Tiết ĐH";
                dgvCTDH.Columns["MaDH"].HeaderText = "Mã Đơn Hàng";
                dgvCTDH.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
                dgvCTDH.Columns["SoLuong"].HeaderText = "Số Lượng";
                // dgvCTDH.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgvCTDH.Columns["Size"].HeaderText = "Kích Cỡ";
                dgvCTDH.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            }));

        }

        public void Listen()
        {
            // Lắng nghe
            db.Collection(collectionName).Listen(snapshot =>
            {
                List<DonHang> danhSach = new List<DonHang>();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    DonHang obj = document.ConvertTo<DonHang>();

                    /*// Gán document.Id vào thuộc tính ID nếu có
                    var idProp = obj.GetType().GetProperty("ID");
                    if (idProp != null)
                        idProp.SetValue(obj, document.Id);*/

                    danhSach.Add(obj);
                }

                // Cập nhật lại DataGridView
                dgvDH.Invoke(new Action(() =>
                {
                    dgvDH.DataSource = null; // Clear cũ
                    dgvDH.DataSource = danhSach; // Gán danh sách mới
                }));

                // Table Header
                setOrderHeader();
            });
        }

        private void dgvDH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // RowIndex: Số thứ tự của hàng được click
                // Đảm bảo không click vào tiêu đề cột (RowIndex = -1)
                // SelectionMode: FullRowSelect
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvDH.Rows[e.RowIndex];

                    tbMaCT.Text = row.Cells["ID"].Value?.ToString();
                    cbTrangThaiDH.Text = row.Cells["TrangThai"].Value?.ToString();

                    // Lắng nghe
                    db.Collection(collectionName).Document(tbMaCT.Text.ToString()).Collection(subCollectionName).Listen(snapshot =>
                    {
                        List<ChiTietDonHang> danhSach = new List<ChiTietDonHang>();

                        if(danhSach != null)
                        {
                            foreach (DocumentSnapshot document in snapshot.Documents)
                            {
                                ChiTietDonHang obj = document.ConvertTo<ChiTietDonHang>();
                                danhSach.Add(obj);
                            }

                            // Cập nhật lại DataGridView
                            dgvCTDH.Invoke(new Action(() =>
                            {
                                dgvCTDH.DataSource = null; // Clear cũ
                                dgvCTDH.DataSource = danhSach; // Gán danh sách mới
                            }));

                            // Table Header
                            setDetailOrderHeader();
                        }
                    });
                }
            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }


        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            DocumentReference doc = db.Collection(collectionName).Document(tbMaCT.Text);

            if (doc != null)
            {
                var updates = new Dictionary<string, object>
                {
                    { "TrangThai", cbTrangThaiDH.Text.ToString() }
                };

                doc.UpdateAsync(updates);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            List<DonHang> list = await DBServices.GET1<DonHang>(tbMaKH.Text.Trim(), collectionName, "", "");

            // dgvMenu.Rows.Clear();

            List<DonHang> filtered_list = null;
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
                        if (min > max)
                        {
                            MessageBox.Show("Giá tiền tối đa không được nhỏ hơn giá tiền tối thiểu!");
                            return;
                        }

                        if(min < 0 || max < 0)
                        {
                            MessageBox.Show("Giá tiền phải là số không âm!");
                            return;
                        }

                        filtered_list = status == "" ?
                            list.Where(order => min <= order.TongTien && order.TongTien <= max).ToList() :
                            list.Where(order => min <= order.TongTien && order.TongTien <= max && order.TrangThai == status).ToList();
                    }
                    else MessageBox.Show("Giá tiền không hợp lệ!");
                }
                else if (Min.Text.Trim() == "" && Max.Text.Trim() == "" && status != "")
                    filtered_list = list.Where(order => order.TrangThai == status).ToList();
            }
            catch
            {
                MessageBox.Show("Tìm kiếm thất bại!");
            }

            if (list == null) return;

            // Xóa dữ liệu từ gridview
            dgvDH.DataSource = null;
            // Cập nhật dữ liệu 
            dgvDH.DataSource = filtered_list != null ? filtered_list : list;

            // Table Header
            setOrderHeader();
        }
    }
}
