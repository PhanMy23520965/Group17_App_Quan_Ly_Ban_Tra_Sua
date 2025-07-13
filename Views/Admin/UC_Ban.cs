using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TraSuaApp.Views.Admin
{
    public partial class UC_Ban : UserControl
    {
        string collectionName = "Ban";
        string subCollectionName = "ChiTietBan";
        FirestoreDb db = DBServices.Connect();

        public UC_Ban()
        {
            InitializeComponent();
            Init();
            Listen();
        }
        private void Init()
        {
            /*string[] TableStatus = { "Trống", "Đã đặt" };
            cbTrangThaiBan.Items.AddRange(TableStatus);*/

            string[] OrderStatus = { "Chờ xác nhận", "Xác nhận", "Hủy", "Done" };
            cbTrangThaiDatBan.Items.AddRange(OrderStatus);

            dgvCTBan.ColumnHeadersVisible = true;
            dgvCTBan.ColumnHeadersHeight = 40;
        }

        public void Listen()
        {
            // Lắng nghe
            db.Collection(collectionName).Listen(snapshot =>
            {
                List<Ban> danhSach = new List<Ban>();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    Ban obj = document.ConvertTo<Ban>();
                    danhSach.Add(obj);
                }

                // Cập nhật lại DataGridView
                flpBan.Invoke(new Action(() =>
                {
                    // Xóa bàn
                    foreach (Control control in flpBan.Controls.OfType<Guna2GradientButton>().ToList())
                    {
                        flpBan.Controls.Remove(control);
                        control.Dispose();
                    }

                    // Tạo bàn 
                    foreach (Ban table in danhSach)
                        createTableCell(table);
                }));
            });

        }
        public void setHeader()
        {
            dgvCTBan.Invoke(new Action(() =>
            {
                dgvCTBan.Columns["ID"].HeaderText = "Mã CTDB";
                dgvCTBan.Columns["MaBan"].HeaderText = "Mã bàn";
                dgvCTBan.Columns["MaKH"].HeaderText = "Mã KH";
                dgvCTBan.Columns["SoNguoi"].HeaderText = "Số người";
                dgvCTBan.Columns["ThoiGianDB"].HeaderText = "Thời gian đặt";
                dgvCTBan.Columns["TrangThaiDB"].HeaderText = "Trạng thái";
            }));
        }

        private void createTableCell(Ban Table)
        {
            // Tạo danh sách bàn 
            Guna2GradientButton btn = new Guna2GradientButton();

            // Thiết lập nội dung và giao diện
            btn.Font = new Font("Arial", 8); // FontStyle.Bold
            btn.Text = $"Bàn {Table.ID}\nSức chứa: {Table.SucChua}\n({Table.TrangThai})";
            btn.Size = new Size(85, 80);
            btn.ForeColor = Color.White;
            btn.TextAlign = (HorizontalAlignment)ContentAlignment.MiddleCenter;
            btn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;

            // Thiết lập màu gradient dựa trên trạng thái
            if (Table.TrangThai.Trim() == "Trống")
            {
                btn.FillColor = Color.DodgerBlue;
                btn.FillColor2 = Color.DodgerBlue;
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn.FillColor = Color.Red;
                btn.FillColor2 = Color.Red;
                btn.ForeColor = Color.Black;
            }

            // Thiết lập hành vi click
            btn.Click += (s, e) =>
            {
                tbMaBan.Text = Table.ID;
                tbSucChua.Text = Table.SucChua.ToString();
                // cbTrangThaiBan.Text = Table.TrangThai;

                // Chi tiet ban
                db.Collection(collectionName).Document(tbMaBan.Text.ToString()).Collection(subCollectionName).Listen(snapshot =>
                {
                    List<DatBan> danhSach = new List<DatBan>();
                    foreach (DocumentSnapshot document in snapshot.Documents)
                    {
                        DatBan obj = document.ConvertTo<DatBan>();
                        danhSach.Add(obj);
                    }

                    // Cập nhật lại DataGridView
                    dgvCTBan.Invoke(new Action(() =>
                    {
                        dgvCTBan.DataSource = null; // Clear cũ
                        dgvCTBan.DataSource = danhSach; // Gán danh sách mới
                    }));
                });
            };

            // Thêm vào FlowLayoutPanel
            flpBan.Controls.Add(btn);
        }

        private Ban createTable()
        {
            try
            {
                Ban sp = new Ban
                {
                    SucChua = int.Parse(tbSucChua.Text),
                    TrangThai = "Trống", // cbTrangThaiBan.Text.Trim()
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
            await DBServices.POST1(createTable(), collectionName, tbMaBan.Text.Trim());
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await DBServices.PUT1(createTable(), collectionName, tbMaBan.Text.Trim());
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DBServices.DELETE1(collectionName, tbMaBan.Text.Trim());
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            List<DatBan> list = await DBServices.GET1<DatBan>(tbSearch.Text.Trim(), collectionName, tbMaBan.Text, subCollectionName);

            if (list == null) return;

            // Xóa dữ liệu từ gridview
            dgvCTBan.DataSource = null;
            // Cập nhật dữ liệu 
            dgvCTBan.DataSource = list;

            // setHeader();
        }

        private void btnUpdateDetail_Click(object sender, EventArgs e)
        {
            DocumentReference docDetail = db.Collection(collectionName).Document(tbMaBan.Text).
                                    Collection(subCollectionName).Document(tbMaDB.Text);

            DocumentReference docTable = db.Collection(collectionName).Document(tbMaBan.Text);

            if (docDetail != null)
            {
                var updates = new Dictionary<string, object>
                {
                    { "TrangThaiDB", cbTrangThaiDatBan.Text.ToString() }
                };

                docDetail.UpdateAsync(updates);
            }

            if (docTable != null)
            {
                string status = "Trống";
                if (cbTrangThaiDatBan.Text.ToString() == "Xác nhận")
                    status = "Đã đặt";

                var updates = new Dictionary<string, object>
                {
                    { "TrangThai", status }
                };

                docTable.UpdateAsync(updates);
            }
        }

        private void dgvCTBan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvCTBan.Rows[e.RowIndex];

                    tbMaDB.Text = row.Cells["ID"].Value?.ToString();
                    cbTrangThaiDatBan.Text = row.Cells["TrangThaiDB"].Value?.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
