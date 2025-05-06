using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using TraSuaApp.Models.Admin;

namespace Models.Admin
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
