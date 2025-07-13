using Google.Cloud.Firestore;

namespace Models
{
    [FirestoreData]
    public class ChiTietDonHang
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; }

        [FirestoreProperty]
        public DocumentReference MaDH { get; set; }

        [FirestoreProperty]
        public DocumentReference MaSP { get; set; }

        [FirestoreProperty]
        public int SoLuong { get; set; } = 0;

        [FirestoreProperty]
        public string Size { get; set; } = "S";

        [FirestoreProperty]
        public double ThanhTien { get; set; } = 0;
    }
}