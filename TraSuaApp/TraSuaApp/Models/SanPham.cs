using Google.Cloud.Firestore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    [FirestoreData]
    public class SanPham 
    {
        // Không cần [FirestoreProperty] vì không lưu vào FireStore
        public string ID { get; set; } 

        [FirestoreProperty]
        public string TenSP { get; set; } = "";

        [FirestoreProperty]
        public double Gia { get; set; } = 0;

        [FirestoreProperty]
        public string LoaiSP { get; set; } = "";

        [FirestoreProperty]
        public string TrangThai { get; set; } = "";

        // Không cần [FirestoreProperty] vì không lưu vào Firebase
        [FirestoreProperty]
        public string HinhAnh { get; set; } = "";
    }
}
