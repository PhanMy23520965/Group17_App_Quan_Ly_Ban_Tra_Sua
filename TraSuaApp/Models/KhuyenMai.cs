using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraSuaApp.Models.Admin
{
    [FirestoreData]
    public class KhuyenMai
    {
        public string ID { get; set; }

        [FirestoreProperty]
        public int ChietKhau { get; set; } = 0;

        [FirestoreProperty]
        public DateTime NgayBatDau { get; set; } 

        [FirestoreProperty]
        public DateTime NgayKetThuc { get; set; }

        [FirestoreProperty]
        public decimal GiaToiThieu { get; set; } = 0; // Giá tối thiểu để nhận KM

        [FirestoreProperty]
        public decimal GiamToiDa { get; set; } = 0; // Tổng tiền tối đa có thể giảm

        [FirestoreProperty]
        public string NoiDung { get; set; } = "";
    }
}
