using Google.Cloud.Firestore;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraSuaApp.Services
{
    public static class KhachHangServices
    {
        public static async Task<string> GetMaKHByMaTK(string uid)
        {
            FirestoreDb db = DBServices.Connect();
            if (db == null)
                throw new InvalidOperationException("Không thể kết nối đến Firestore");

            Query query = db.Collection("KhachHang").WhereEqualTo("MaTK", uid);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            if (snapshot.Documents.Count == 0)
                return null;

            return snapshot.Documents[0].Id;
        }


        public static async Task<string> GetMaTKByEmail(string email)
        {
            try
            {
                FirestoreDb db = DBServices.Connect();
                if (db == null) return null;

                // Truy vấn lấy MaTK theo Email
                CollectionReference collection = db.Collection("TaiKhoan");
                Query query = collection.WhereEqualTo("Email", email);
                QuerySnapshot snapshot = await query.GetSnapshotAsync();

                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    if (doc.Exists)
                    {
                        return doc.Id; // Document ID chính là MaTK
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy MaTK: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
