using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Admin
{
    [FirestoreData]
    public class Ban
    {
        public string ID { get; set; } = "";

        [FirestoreProperty]
        public int SucChua { get; set; } = 0;

        [FirestoreProperty]
        public string TrangThai { get; set; } = ""; // Còn trống, Đã được đặt trước, Đang được sử dụng
    }
}
