using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [FirestoreData]
    public class TaiKhoan
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; }

        [FirestoreProperty]
        public string Email { get; set; } = "";

        // [FirestoreProperty]
        // public string MatKhau { get; set; } = "";

        [FirestoreProperty]
        public string Quyen { get; set; } = "";
    }
}
