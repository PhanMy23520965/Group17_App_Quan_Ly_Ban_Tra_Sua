using Google.Cloud.Firestore;

namespace Models.Admin
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
        public string Size { get; set; } = "";

        [FirestoreProperty]
        public int ThanhTien { get; set; } = 0;
    }
}