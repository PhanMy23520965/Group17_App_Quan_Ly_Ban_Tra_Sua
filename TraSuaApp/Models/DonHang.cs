using Google.Cloud.Firestore;
using System;
using TraSuaApp.Models;


namespace Models.Admin
{
    [FirestoreData]
    public class DonHang
    {
        public string ID { get; set; }

        [FirestoreProperty]
        public string MaKH { get; set; } = "";

        [FirestoreProperty]
        public Timestamp NgayDat { get; set; }  

        [FirestoreProperty]
        public double TongTien { get; set; } = 0;

        [FirestoreProperty]
        public string MaKM { get; set; } = "";

        [FirestoreProperty]
        public string TrangThai { get; set; } = "";

        [FirestoreProperty]
        public string GhiChu { get; set; } = "";

    }
}
