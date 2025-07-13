using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Models;

namespace Models
{
    [FirestoreData]
    public class QuanTriVien
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; } // MaQTV

        [FirestoreProperty]
        public string MaTK { get; set; } = "";

        [FirestoreProperty]
        public string HoTen { get; set; } = "";

        [FirestoreProperty]
        public string SoDienThoai { get; set; } = "";
    }
}
