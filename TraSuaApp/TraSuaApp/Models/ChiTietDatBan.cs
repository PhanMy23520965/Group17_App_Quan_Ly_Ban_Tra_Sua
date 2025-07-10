using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Admin
{
    [FirestoreData]
    public class ChiTietDatBan
    {
        public string ID { get; set; }

        [FirestoreProperty]
        public string MaKH { get; set; } = "";

        [FirestoreProperty]
        public string MaBan { get; set; } = "";

        [FirestoreProperty]
        //public DateTime ThoiGianDB { get; set; }
        public Timestamp ThoiGianDB { get; set; }

        [FirestoreProperty]
        public string TrangThaiDB { get; set; } = "";

        [FirestoreProperty]
        public int SoNguoi { get; set; } = 0;
    }
}
