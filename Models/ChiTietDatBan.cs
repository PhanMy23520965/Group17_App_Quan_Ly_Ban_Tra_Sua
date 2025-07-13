using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [FirestoreData]
    public class DatBan
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; }

        [FirestoreProperty]
        public string MaKH { get; set; } = "";

        [FirestoreProperty]
        public string MaBan { get; set; } = "";

        [FirestoreProperty]
        public DateTime ThoiGianDB { get; set; }

        [FirestoreProperty]
        public string TrangThaiDB { get; set; } = ""; // Chờ xác nhận, Xác nhận, Đã hủy 

        [FirestoreProperty]
        public int SoNguoi { get; set; } = 0;
    }
}
