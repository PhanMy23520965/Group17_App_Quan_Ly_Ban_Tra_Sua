using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using TraSuaApp.Services;
using TraSuaApp.Views.Admin;

namespace TraSuaApp.Views
{
    internal static class Program
    {
        public static string MaKH = "KH002";
        public static string MaQTV = "QTV001";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dangnhap());

            //Application.Run(new Main(MaQTV));  

            /*DonHangUser formDonHang = new DonHangUser();
            try
            {
                Application.Run(new Home1(formDonHang));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi khởi tạo Home1:\n{ex.Message}\n{ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        /*public static string id = ""; // MaKH / MaQTV
        public static string email = "";

        static void Main1()
        {
            try
            {
                // Đăng nhập ... --> Lấy id = ...
                DonHangUser formDonHang = new DonHangUser();

                if (id.StartsWith("KH"))
                    Application.Run(new Main(MaQTV));
                else if (id.StartsWith("QTV"))
                    Application.Run(new Home1(formDonHang));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra khi khởi tạo:\n{ex.Message}\n{ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
    }
}
