using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraSuaApp.Models
{
    public class ChiTietDonHangTam
    {
        public DocumentReference MaDH { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; } = "";
        public string HinhAnh { get; set; } = "";
        public double GiaBan { get; set; }
        public int SoLuong { get; set; } = 1;
        public string Size { get; set; } = "S";
        public double ThanhTien { get; set; }
    }
}
