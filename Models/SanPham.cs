using Google.Cloud.Firestore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Models.Admin
{
    [FirestoreData]
    public class SanPham 
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; } 

        [FirestoreProperty]
        public string TenSP { get; set; } = "";

        [FirestoreProperty]
        public int Gia { get; set; } = 0;

        [FirestoreProperty]
        public string LoaiSP { get; set; } = "";

        [FirestoreProperty]
        public string TrangThai { get; set; } = "";

        [FirestoreProperty]
        public string HinhAnh { get; set; } = "";
    }
}
