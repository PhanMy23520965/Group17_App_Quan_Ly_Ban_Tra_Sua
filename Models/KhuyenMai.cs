using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [FirestoreData]
    public class KhuyenMai
    {
        // Để Firestore tự gán document ID
        [FirestoreDocumentId]
        public string ID { get; set; }

        [FirestoreProperty]
        public int ChietKhau { get; set; } = 0;

        [FirestoreProperty]
        public DateTime NgayBatDau { get; set; } 

        [FirestoreProperty]
        public DateTime NgayKetThuc { get; set; }

        [FirestoreProperty]
        public double GiaToiThieu { get; set; } = 0; // Giá tối thiểu để nhận KM

        [FirestoreProperty]
        public double GiamToiDa { get; set; } = 0; // Tổng tiền tối đa có thể giảm

        [FirestoreProperty]
        public string NoiDung { get; set; } = "";
    }
}
