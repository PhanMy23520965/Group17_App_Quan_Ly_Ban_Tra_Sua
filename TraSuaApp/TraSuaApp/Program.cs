using TraSuaApp.View;
using TraSuaApp.Views;

namespace TraSuaApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //DonHangUser formDonHang = new DonHangUser();
            //try
            //{
            //    Application.Run(new Home1(formDonHang));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Lỗi xảy ra khi khởi tạo Home1:\n{ex.Message}\n{ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            Application.Run(new Dangnhap());

        }
    }
}