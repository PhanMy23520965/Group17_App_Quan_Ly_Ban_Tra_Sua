using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Services;

namespace TraSuaApp.Views
{
    public partial class Quenmatkhau : Form
    {
        public Quenmatkhau()
        {
            InitializeComponent();
        }

        private void Quenmatkhau_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtEmail, "Nhập email để reset mật khẩu");

            BoGocPanel();
        }

        private void BoGocPanel()
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            Rectangle bounds = guna2GradientPanel1.ClientRectangle;

            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            guna2GradientPanel1.Region = new Region(path);
        }

        private void SetPlaceholder(Guna.UI2.WinForms.Guna2TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = System.Drawing.Color.Gray;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng email
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                {
                    MessageBox.Show("Địa chỉ email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gửi yêu cầu reset mật khẩu
            try
            {
                await DBServices.SendPasswordResetEmailAuth(email);

                // Firebase sẽ KHÔNG thông báo nếu email có tồn tại hay không, đây là chủ ý bảo mật
                MessageBox.Show("Nếu email tồn tại trong hệ thống, một liên kết đặt lại mật khẩu đã được gửi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi gửi yêu cầu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
