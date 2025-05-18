using Google.Cloud.Firestore;
using Guna.UI2.WinForms;
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
using TraSuaApp.View;
using TraSuaApp.Models;
using Guna.UI2.WinForms.Suite;

namespace TraSuaApp.Views
{
    public partial class VoucherCuaBan : Form
    {
        private FirestoreDb db;
        private string userId = Program.MaKH;
        public VoucherCuaBan()
        {
            InitializeComponent();
            db = DBServices.Connect();
            LoadKhuyenMai();
        }

        private async void LoadKhuyenMai()
        {
            try
            {
                var userRef = db.Collection("KhachHang").Document(userId);
                var voucherSnapshots = await userRef.Collection("KhuyenMai").GetSnapshotAsync();

                if (voucherSnapshots.Count == 0)
                {
                    MessageBox.Show("Không có khuyến mãi nào.");
                    return;
                }

                flpVoucher.Controls.Clear();

                foreach (var voucherDoc in voucherSnapshots)
                {
                    var voucherRef = voucherDoc.GetValue<DocumentReference>("MaKM");
                    var voucherData = await voucherRef.GetSnapshotAsync();

                    if (voucherData.Exists)
                    {
                        string id = voucherData.Id;
                        int chietKhau = voucherData.GetValue<int>("ChietKhau");
                        DateTime ngayBatDau = voucherData.GetValue<DateTime>("NgayBatDau");
                        DateTime ngayKetThuc = voucherData.GetValue<DateTime>("NgayKetThuc");
                        double giamToiDa = voucherData.GetValue<double>("GiamToiDa");
                        double giaToiThieu = voucherData.GetValue<double>("GiaToiThieu");
                        string noidung = voucherData.GetValue<string>("NoiDung");

                        Guna2Panel panel = new Guna2Panel
                        {
                            BackColor = Color.Transparent,
                            BackgroundImage = Properties.Resources.voucher,
                            BackgroundImageLayout = ImageLayout.Stretch,
                            Margin = new Padding(3, 3, 40, 40),
                            Padding = new Padding(0, 0, 30, 30),
                            Size = new Size(445, 168),
                            TabIndex = 21,
                            Tag = voucherData,
                        };

                        Guna2GradientPanel panel1 = new Guna2GradientPanel
                        {
                            BorderColor = Color.FromArgb(219, 191, 163),
                            BorderRadius = 80,
                            BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot,
                            BorderThickness = 3,
                            FillColor = Color.FromArgb(207, 240, 255),
                            FillColor2 = Color.FromArgb(255, 240, 209),
                            GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical,
                            Location = new Point(248, 11),
                            Size = new Size(148, 143),
                            TabIndex = 0,
                        };

                        Guna2HtmlLabel lblVoucher = new Guna2HtmlLabel
                        {
                            Text = $"{chietKhau}%",
                            BackColor = Color.Transparent,
                            Font = new Font("Segoe UI Black", 36F, FontStyle.Bold | FontStyle.Italic),
                            ForeColor = Color.OrangeRed,
                            Location = new Point(0, 24),
                            Size = new Size(151, 98),
                            TabIndex = 14,
                        };

                        panel1.Controls.Add(lblVoucher);
                        panel.Controls.Add(panel1);
                        panel.Click += (s, e) => ShowVoucherDetail(voucherData);

                        flpVoucher.Controls.Add(panel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy khuyến mãi: {ex.Message}");
            }
        }

        private void ShowVoucherDetail(DocumentSnapshot voucherData)
        {
            string id = voucherData.Id;
            int chietKhau = voucherData.GetValue<int>("ChietKhau");
            DateTime ngayBatDau = voucherData.GetValue<DateTime>("NgayBatDau");
            DateTime ngayKetThuc = voucherData.GetValue<DateTime>("NgayKetThuc");
            double giamToiDa = voucherData.GetValue<double>("GiamToiDa");
            double giaToiThieu = voucherData.GetValue<double>("GiaToiThieu");
            string noidung = voucherData.GetValue<string>("NoiDung");

            Guna2Panel pnlVoucherDetail = new Guna2Panel
            {
                BackgroundImage = Properties.Resources.nenvoucher1,
                BackgroundImageLayout = ImageLayout.Zoom,
                Location = new Point(500,40),
                Size = new Size(450, 630),
                TabIndex = 0,
        };

            Guna2Button btnClose = new Guna2Button
            {
                Text = "X",
                Size = new Size(40,42),
                Location = new Point(405, 2),
                FillColor = Color.FromArgb(117,112,109),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                BorderRadius = 4
            };
            btnClose.Click += (s, e) => pnlVoucherDetail.Dispose();

            Label lblNoiDung = new Label
            {
                Text = $"{noidung.ToUpper()}\r\n",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(74, 147),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(300, 32),
                AutoSize = false,
                TabIndex = 8,
                BackColor = Color.Transparent,

            };

            Label lblThoiGian = new Label
            {
                Text = $"({ngayBatDau:dd/MM/yyyy} - {ngayKetThuc:dd/MM/yyyy})",
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                ForeColor = Color.FromArgb(0, 49, 120),
                Location = new Point(121, 179),
                Size = new Size(197, 25),
                TabIndex = 9,
                BackColor = Color.Transparent,
            };


            Label lblVoucherDetail = new Label
            {
                Text = $"- Giảm trực tiếp {chietKhau}% vào tổng hóa đơn \n- Giảm tối đa: {giamToiDa:N0} VND\n- Áp dụng một hóa đơn duy nhất trên một tài khoản\n- Đơn từ {giaToiThieu:N0} VND",
                Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Location = new Point(80, 226),
                AutoSize = false,
                Size = new Size(315, 235),
                TabIndex = 9,
                BackColor = Color.Transparent,
            };

            pnlVoucherDetail.Controls.Add(lblNoiDung);
            pnlVoucherDetail.Controls.Add(lblThoiGian);
            pnlVoucherDetail.Controls.Add(btnClose);
            pnlVoucherDetail.Controls.Add(lblVoucherDetail);
            Controls.Add(pnlVoucherDetail);
            pnlVoucherDetail.BringToFront();
        }
    }
}
