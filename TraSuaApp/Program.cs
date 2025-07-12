using TraSuaApp.Models;
using TraSuaApp.View;
using TraSuaApp.Views;
using System.Runtime.InteropServices;

namespace TraSuaApp
{
    internal static class Program
    {
        public static string MaKH = "KH002";
        public static string email = "";
        public static List<ChiTietDonHangTam> danhSachSPTam = new();
       
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DonHangUser formDonHang = new DonHangUser();

            // Khởi tạo quản lý phiên làm việc
            SessionManager.StartSessionMonitor();

            Application.Run(new Dangnhap());

        }
    }
}