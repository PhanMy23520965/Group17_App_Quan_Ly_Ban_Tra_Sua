using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraSuaApp.Models.Admin
{
    [FirestoreData]
    public class TaiKhoan
    {
        public string ID { get; set; }

        //[FirestoreProperty]
        //public string MatKhau { get; set; } = "";

        [FirestoreProperty]
        public string Email { get; set; } = "";

        [FirestoreProperty]
        public string Quyen { get; set; } = "";
    }
}
