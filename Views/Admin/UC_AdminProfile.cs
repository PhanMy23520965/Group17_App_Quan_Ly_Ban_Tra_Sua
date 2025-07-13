using Google.Cloud.Firestore;
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
    public partial class UC_AdminProfile : UserControl
    {
        string collectionName = "QuanTriVien";
        FirestoreDb db = DBServices.Connect();

        public UC_AdminProfile(string Id)
        {
            InitializeComponent();
            GetInfo(Id);
        }

        private async void GetInfo(string maQTV)
        {
            try
            {
                DocumentSnapshot snapshot_qtv = await db.Collection("QuanTriVien")
                    .Document(maQTV) // document ID 
                    .GetSnapshotAsync();

                if (snapshot_qtv.Exists)
                {
                    QuanTriVien qtv = snapshot_qtv.ConvertTo<QuanTriVien>();

                    // Gán vào các textbox 
                    tbID.Text = qtv.ID;
                    tbMaTK.Text = qtv.MaTK;
                    tbTen.Text = qtv.HoTen;
                    tbSDT.Text = qtv.SoDienThoai;
                }

                Listen();
            }
            catch
            {
                MessageBox.Show("Không tìm thấy quản trị viên");
            }
        }

        private QuanTriVien createQTV()
        {
            try
            {
                QuanTriVien qtv = new QuanTriVien
                {
                    ID = tbID.Text.Trim(),
                    MaTK = tbMaTK.Text.Trim(),
                    HoTen = tbTen.Text.Trim(),
                    SoDienThoai = tbSDT.Text.Trim()
                };
                return qtv;
            }
            catch
            {
                return null;
            }
        }

        // Lắng nghe
        public void Listen()
        {
            db.Collection(collectionName).Document(tbID.Text).Listen(snapshot =>
            {
                QuanTriVien qtv = snapshot.ConvertTo<QuanTriVien>();

                if (qtv != null)
                {
                    Invoke(new Action(() =>
                    {
                        tbTen.Text = qtv.HoTen;
                        tbSDT.Text = qtv.SoDienThoai;
                    }));
                }
            });
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                await DBServices.PUT1(createQTV(), collectionName, tbID.Text);
                MessageBox.Show($"Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show($"Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Dangnhap dn = new Dangnhap();
            dn.Show();
            // Tìm form chứa UserControl
            Form parent = this.FindForm(); 
            if (parent != null)
                parent.Close(); 
        }
    }
}
