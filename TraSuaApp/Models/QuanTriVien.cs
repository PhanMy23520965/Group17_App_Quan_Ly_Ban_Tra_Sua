using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Models.Admin
{
    [FirestoreData]
    public class QuanTriVien
    {
        public string ID { get; set; }

        [FirestoreProperty]
        public string MaTK { get; set; } = "";

        [FirestoreProperty]
        public string HoTen { get; set; } = "";

        [FirestoreProperty]
        public string SoDienThoai { get; set; } = "";
    }
}
