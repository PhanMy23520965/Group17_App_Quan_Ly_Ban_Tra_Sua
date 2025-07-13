using Google.Api;
using Google.Cloud.Firestore;
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
using Models;
using TraSuaApp.Services;

namespace TraSuaApp.Views.Admin
{
    public partial class UC_LienHe : UserControl
    {
        string collectionName = "LienHe";
        FirestoreDb db = DBServices.Connect();

        public UC_LienHe()
        {
            InitializeComponent();
            Listen();
        }

        public void Listen()
        {
            // Lắng nghe
            // Lỗi "Cross-thread operation not valid" xảy ra khi bạn cập nhật control UI từ một thread khác ngoài thread giao diện chính(UI thread).
            // Gọi Invoke() để chuyển về UI thread.
            // Listen() chạy trong một thread nền (background thread)
            db.Collection(collectionName).Document("LH001").Listen(snapshot =>
            {
                LienHe contact = snapshot.ConvertTo<LienHe>();

                if(contact != null )
                {
                    this.Invoke(new Action(() =>
                    {
                        tbSDT.Text = contact.SDT;
                        tbFB.Text = contact.Facebook;
                        tbIG.Text = contact.Instagram;
                        tbSF.Text = contact.ShopeeFood;
                        tbDC.Text = contact.DiaChi;
                    }));
                }
            });
        }

        private LienHe createContact()
        {
            try
            {
                LienHe sp = new LienHe
                {
                    SDT = tbSDT.Text.Trim(),
                    Facebook = tbFB.Text.Trim(),
                    Instagram = tbIG.Text.Trim(),
                    ShopeeFood = tbSF.Text.Trim(),
                    DiaChi = tbDC.Text.Trim()
                };
                return sp;
            }
            catch
            {
                return null;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                await DBServices.PUT1(createContact(), collectionName, "LH001");
                MessageBox.Show($"Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show($"Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
