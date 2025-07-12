using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Services;

namespace TraSuaApp.View
{
    public partial class LienHe : Form
    {
        private FirestoreDb db = DBServices.Connect();
        public LienHe()
        {
            InitializeComponent();
        }

        private async void LienHe_Load(object sender, EventArgs e)
        {
            await LayThongTinLienHe();

            // Gán sự kiện Click cho các LinkLabel
            llblInstagram.Click += LinkLabel_Click;
            llblFacebook.Click += LinkLabel_Click;
            llblShopeefood.Click += LinkLabel_Click;
        }

        private void LinkLabel_Click(object sender, EventArgs e)
        {
            if (sender is LinkLabel linkLabel)
            {
                string url = linkLabel.Tag?.ToString();
                if (!string.IsNullOrEmpty(url) && url != "N/A")
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở liên kết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Liên kết không khả dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public async Task LayThongTinLienHe()
        {
            try
            { 
                // Truy vấn tới document duy nhất trong bảng "LienHe"
                DocumentReference docRef = db.Collection("LienHe").Document("LH001");
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    // Lấy dữ liệu từ document
                    var data = snapshot.ToDictionary();

                    // Gán dữ liệu lên các Label
                    lblSDT.Text = data.TryGetValue("SDT", out var sdt) ? sdt.ToString() : "Không có dữ liệu";
                    lblDiaChi.Text = data.TryGetValue("DiaChi", out var diachi) ? diachi.ToString() : "Không có dữ liệu";

                    // Gán dữ liệu lên các LinkLabel
                    llblInstagram.Text = "Instagram";
                    llblInstagram.Tag = data.TryGetValue("Instagram", out var instagram) ? instagram.ToString() : "N/A";

                    llblFacebook.Text = "Facebook";
                    llblFacebook.Tag = data.TryGetValue("Facebook", out var facebook) ? facebook.ToString() : "N/A";

                    llblShopeefood.Text = "ShopeeFood";
                    llblShopeefood.Tag = data.TryGetValue("Shopeefood", out var shopeefood) ? shopeefood.ToString() : "N/A";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin liên hệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ Firestore: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
