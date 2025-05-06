using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraSuaApp.Models.Admin
{
    [FirestoreData]
    public class ThanhToan
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; }

        [FirestoreProperty]
        public string MaDH { get; set; } = "";

        [FirestoreProperty]
        public string PhuongThucTT { get; set; } = "";

        [FirestoreProperty]
        public string TrangThaiTT { get; set; } = "";
    }
}
