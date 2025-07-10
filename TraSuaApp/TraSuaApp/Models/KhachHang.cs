using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraSuaApp.Models.Admin
{
    [FirestoreData]
    public class KhachHang
    {
        public string ID { get; set; }

        [FirestoreProperty]
        public string MaTK { get; set; } = "";

        [FirestoreProperty]
        public string HoTen { get; set; } = "";

        [FirestoreProperty]
        public string SoDienThoai { get; set; } = "";

        [FirestoreProperty]
        public int DiemTichLuy { get; set; } = 0;
    }
}
