using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraSuaApp.Models.Admin
{
    [FirestoreData]
    public class DanhGia
    {
        public string ID { get; set; }

        [FirestoreProperty]
        public string MaKH { get; set; } = "";

        [FirestoreProperty]
        public string MaDH { get; set; } = "";

        [FirestoreProperty]
        public string NoiDung { get; set; } = "";

        [FirestoreProperty]
        public int SaoDG { get; set; } = 1;
    }
}
