using Google.Cloud.Firestore;
using System;


namespace Models
{
    [FirestoreData]
    public class DonHang
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId] 
        public string ID { get; set; }

        [FirestoreProperty]
        public string MaKH { get; set; } = "";

        [FirestoreProperty]
        public string MaKM { get; set; } = "";

        [FirestoreProperty]
        public DateTime NgayDat { get; set; }

        [FirestoreProperty]
        public double TongTien { get; set; } = 0;

        [FirestoreProperty]
        public string TrangThai { get; set; } = "";

        [FirestoreProperty]
        public string GhiChu { get; set; } = "";
    }
}
