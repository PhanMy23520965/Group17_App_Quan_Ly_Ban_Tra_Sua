using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [FirestoreData]
    public class DanhGia
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; }

        [FirestoreProperty]
        public DocumentReference MaKH { get; set; }

        [FirestoreProperty]
        public DocumentReference MaDH { get; set; }

        [FirestoreProperty]
        public string NoiDung { get; set; } = "";

        [FirestoreProperty]
        public int SaoDG { get; set; } = 1;
    }
}
