using Google.Cloud.Firestore;

namespace Models.Admin
{
    [FirestoreData]
    public class ChiTietDonHang
    {
        [FirestoreDocumentId]
        public string ID { get; set; }

        [FirestoreProperty]
        public DocumentReference MaDH { get; set; }

        [FirestoreProperty]
        public DocumentReference MaSP { get; set; }

        [FirestoreProperty]
        public int SoLuong { get; set; } = 1;

        [FirestoreProperty]
        public string Size { get; set; } = "S";

        [FirestoreProperty]
        public double ThanhTien { get; set; }
    }
}