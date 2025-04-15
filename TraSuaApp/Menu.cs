using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp;
using static Guna.UI2.WinForms.Suite.Descriptions;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TraSuaApp.Services;


namespace TraSuaApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        private async void Menu_Load(object sender, EventArgs e)
        {
            FirebaseService firebase = new FirebaseService();
            var danhSach = await firebase.GetDanhSachSanPhamAsync();

            if (danhSach != null)
            {
                foreach (var sp in danhSach.Values)
                {
                    Panel panel = new Panel();
                    panel.BackColor = Color.PeachPuff;
                    panel.Width = 280;
                    panel.Height = 430;
                    panel.Margin = new Padding(10);

                    PictureBox pic = new PictureBox();
                    pic.Load(sp.HinhAnh);
                    pic.Width = 270;
                    pic.Height = 280;
                    pic.Top = 3;
                    pic.Left = (panel.Width - pic.Width) / 2; // canh ngang
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.BackColor = Color.Transparent;

                    // Label tên sản phẩm
                    Label ten = new Label();
                    ten.Text = sp.TenSP;
                    ten.Top = pic.Bottom + 10;
                    ten.Left = 0;
                    ten.Width = panel.Width;
                    ten.Height = 40;
                    ten.TextAlign = ContentAlignment.MiddleCenter; // căn giữa nội dung
                    ten.Font = new Font("Segoe UI", 15, FontStyle.Bold);
                    ten.AutoSize = false;

                    // Label giá
                    Label gia = new Label();
                    gia.Text = sp.Gia.ToString("N0") + " đ";
                    gia.Top = ten.Bottom;
                    gia.Left = 0;
                    gia.Width = panel.Width;
                    gia.Height = 25;
                    gia.TextAlign = ContentAlignment.MiddleCenter;
                    gia.ForeColor = Color.Green;
                    gia.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    gia.AutoSize = false;

                    // Label đè lên ảnh
                    Label trangThai = new Label();
                    trangThai.Text = sp.TrangThai;
                    trangThai.AutoSize = true;
                    trangThai.BackColor = Color.FromArgb(180, Color.White); // nền trắng trong suốt
                    trangThai.ForeColor = Color.DarkGreen;
                    trangThai.Font = new Font("Segoe UI", 17, FontStyle.Bold);

                    // 👉 Đè lên ảnh
                    trangThai.Parent = pic;
                    trangThai.Top = 5;
                    trangThai.Left = pic.Width - trangThai.PreferredWidth+18;

                    Button btnThem = new Button();
                    btnThem.Text = "Thêm vào đơn";
                    btnThem.Width = 180;
                    btnThem.Height = 44;

                    // 👉 Canh phải: đặt Right = 10px từ cạnh phải
                    btnThem.Left = panel.Width - btnThem.Width-15;
                    btnThem.Top = gia.Bottom + 15;

                    // 👉 Màu cam RGB
                    btnThem.BackColor = Color.FromArgb(255, 165, 0);
                    btnThem.ForeColor = Color.White;
                    btnThem.FlatStyle = FlatStyle.Flat;
                    btnThem.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                    // 👉 Sự kiện click (tuỳ bạn muốn làm gì)
                    btnThem.Click += (s, e) =>
                    {
                        MessageBox.Show($"Đã thêm {sp.TenSP} vào đơn hàng!");
                    };

                    
                    panel.Controls.Add(ten);
                    panel.Controls.Add(gia);
                    panel.Controls.Add(trangThai);
                    panel.Controls.Add(btnThem);
                    panel.Controls.Add(pic);

                    flowSanPham.Controls.Add(panel);
                }
            }
            else
            {
                MessageBox.Show("Không lấy được dữ liệu từ Firebase.");
            }
        }
    }
}
