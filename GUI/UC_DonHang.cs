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
using Google.Type;
using System.Linq.Expressions;

namespace TraSuaApp
{
    public partial class UC_DonHang : UserControl
    {
        string collectionName = "DonHangTEMP";
        string subCollectionName = "ChiTietDonHang";

        FirestoreDb db = DBServices.Connect();

        public UC_DonHang()
        {
            InitializeComponent();
            Listen();

            string[] options = { "Chờ xác nhận", "Xác nhận", "Đã thanh toán" };
            cbTrangThaiDH.Items.AddRange(options);
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

        private async void dgvDH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // RowIndex: Số thứ tự của hàng được click
                // Đảm bảo không click vào tiêu đề cột (RowIndex = -1)
                // SelectionMode: FullRowSelect
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvDH.Rows[e.RowIndex];

                    tbMaDH.Text = row.Cells["ID"].Value?.ToString();
                    cbTrangThaiDH.Text = row.Cells["TrangThai"].Value?.ToString();

                    // string collectionName = "DonHang";
                    // string subCollectionName = "ChiTietDonHang";

                    DocumentSnapshot doc = await db.Collection(collectionName).Document("DH001").
                                                    Collection(subCollectionName).Document("CT001").GetSnapshotAsync();

                    ChiTietDonHang ct = doc.ConvertTo<ChiTietDonHang>();

                    // Dùng MaSP để truy vấn dữ liệu của sản phẩm được tham chiếu
                    DocumentSnapshot spSnapshot = await ct.MaSP.GetSnapshotAsync();

                    SanPham sp = spSnapshot.ConvertTo<SanPham>();
                    MessageBox.Show("Tên sản phẩm: " + sp.TenSP);

                    // Lắng nghe
                    db.Collection(collectionName).Document(tbMaDH.Text.ToString()).Collection(subCollectionName).Listen(snapshot =>
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
            DocumentReference doc = db.Collection(collectionName).Document(tbMaDH.Text);

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
            List<DonHang> list = await DBServices.GET<DonHang>(tbSearch.Text.Trim(), collectionName);

            // dgvDH.Rows.Clear();

            if (list == null) return;

            // Xóa dữ liệu từ gridview
            dgvDH.DataSource = null;
            // Cập nhật dữ liệu 
            dgvDH.DataSource = list;

            // Table Header
            setOrderHeader();
        }

    }
}
