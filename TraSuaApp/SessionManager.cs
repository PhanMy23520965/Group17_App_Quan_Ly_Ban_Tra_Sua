using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using TraSuaApp.Views;

namespace TraSuaApp
{
    public static class SessionManager
    {
        private static System.Windows.Forms.Timer inactivityTimer;
        private const int TIMEOUT_MINUTES = 3;

        // Dùng để lấy thời gian máy không thao tác
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        private static int GetIdleTime()
        {
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)System.Runtime.InteropServices.Marshal.SizeOf(lastInputInfo);
            GetLastInputInfo(ref lastInputInfo);

            return Environment.TickCount - (int)lastInputInfo.dwTime;
        }

        public static void StartSessionMonitor()
        {
            inactivityTimer = new System.Windows.Forms.Timer();
            inactivityTimer.Interval = 60 * 1000; // Kiểm tra mỗi phút
            inactivityTimer.Tick += CheckInactivity;
            inactivityTimer.Start();
        }

        private static void CheckInactivity(object sender, EventArgs e)
        {
            int idleMilliseconds = GetIdleTime();
            int timeoutMilliseconds = TIMEOUT_MINUTES * 60 * 10;

            if (idleMilliseconds >= timeoutMilliseconds)
            {
                AutoLogout();
            }
        }

        private static void AutoLogout()
        {
            // Dừng timer để không gọi lại
            inactivityTimer.Stop();

            // Đăng xuất
            Application.OpenForms[0].Invoke(new Action(() =>
            {
                // Xóa thông tin đăng nhập
                Properties.Settings.Default.Email = "";
                Properties.Settings.Default.MatKhau = "";
                Properties.Settings.Default.Save();

                // Đóng toàn bộ form trừ form đăng nhập
                List<Form> openForms = new List<Form>(Application.OpenForms.Cast<Form>());
                foreach (Form form in openForms)
                {
                    if (form.Name != "Dangnhap")
                    {
                        form.Close();
                    }
                }

                // Mở lại form đăng nhập
                Dangnhap dangNhapForm = new Dangnhap();
                dangNhapForm.Show();
            }));
        }
    }
}
