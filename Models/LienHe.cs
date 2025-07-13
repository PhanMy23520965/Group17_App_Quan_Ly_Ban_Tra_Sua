using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [FirestoreData]
    public class LienHe
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; } = "";

        [FirestoreProperty]
        public string SDT { get; set; } = "";

        [FirestoreProperty]
        public string DiaChi { get; set; } = "";

        [FirestoreProperty]
        public string Facebook { get; set; } = "";

        [FirestoreProperty]
        public string Instagram { get; set; } = "";

        [FirestoreProperty]
        public string ShopeeFood { get; set; } = "";

    }
}
