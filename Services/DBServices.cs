using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Models.Admin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace TraSuaApp.Services
{
    public class DBServices
    {
        // Kết nối CSDL
        static FirestoreDb db = Connect();
        public static FirestoreDb Connect()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "firebase-adminsdk.json");
                db = FirestoreDb.Create("quan-ly-quan-tra", new FirestoreClientBuilder
                {
                    CredentialsPath = jsonPath
                }.Build());

                return db;
            }
            catch
            {
                MessageBox.Show($"Kết nối CSDL thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // -----------------------------------------------------Phương thức đẩy dữ liệu lên CSDL-----------------------------------------------------
        public static async Task POST<T>(T obj, string collectionName, string ID, string subCollectionName = "", string subID = "") where T : class
        {
            // Kiểm tra sự tồn tại của đối tượng 
            if(obj == null)
            {
                MessageBox.Show($"POST dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Truy cập collection (bảng)
            CollectionReference collection = db.Collection(collectionName);

            // Tham chiếu đến document với ID cụ thể (1 dòng dữ liệu)
            // Nếu chưa có: tạo mới
            DocumentReference doc = subID == "" ? collection.Document(ID) :
                                                  collection.Document(ID).Collection(subCollectionName).Document(subID);

            // Gửi object lên Firestore để lưu
            await doc.SetAsync(obj);

            // MessageBox.Show($"POST dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // ------------------------------------------------Phương thức lấy dữ liệu (trả về danh sách dữ liệu T)------------------------------------------------
        public static async Task<List<T>> GET<T>(string search = "", string collectionName = "", string ID = "", string subCollectionName = "") where T : class
        {
            try
            {
                // Truy cập collection và lấy snapshot (bản sao của dữ liệu)
                CollectionReference collection = ID == "" ? db.Collection(collectionName) :
                                                            db.Collection(collectionName).Document(ID).Collection(subCollectionName);

                QuerySnapshot snapshot = await collection.GetSnapshotAsync();   

                // Lấy dữ liệu từ snapshot, chuyển thành object kiểu T và lưu vào danh sách 
                List<T> danhSach = new List<T>(); 
                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    T obj = doc.ConvertTo<T>();

                    // Chức năng tìm kiếm (nếu có dữ liệu từ search)
                    if (!string.IsNullOrEmpty(search))
                    {
                        bool matched = false;

                        // Duyệt từng thuộc tính của object để tìm từ khóa
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            // Lấy giá trị thuộc tính của obj
                            var value = prop.GetValue(obj);
                            if (value != null && value.ToString().ToLower().Contains(search.ToLower()))
                            {
                                matched = true;
                                break;
                            }
                        }

                        // Bỏ qua object này nếu không khớp
                        if (!matched) continue;
                    }

                    // Thêm object vào danh sách
                    danhSach.Add(obj); 
                }

                // MessageBox.Show($"GET dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return danhSach;
            }
            catch // (Exception ex)
            {
                // MessageBox.Show($"GET dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;    
            }
        }


        // ------------------------------------------------------Phương thức sửa đổi dữ liệu------------------------------------------------------
        public static async Task PUT<T>(T obj, string collectionName, string ID, string subCollectionName = "", string subID = "") where T : class
        {
            if (obj == null)
            {
                MessageBox.Show($"PUT dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Truy cập collection (bảng)
                CollectionReference collection = db.Collection(collectionName);

                // Tham chiếu đến document với ID cụ thể (1 dòng dữ liệu)
                // Nếu chưa có: tạo mới
                DocumentReference doc = subID == "" ? collection.Document(ID) :
                                                      collection.Document(ID).Collection(subCollectionName).Document(subID);

                // Cập nhật dòng dữ liệu trên DB
                await doc.SetAsync(obj, SetOptions.Overwrite);

                // MessageBox.Show($"PUT dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                // MessageBox.Show($"PUT dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        // --------------------------------------------Phương thức xóa dữ liệu---------------------------------------------
        public static async Task DELETE(string collectionName, string ID, string subCollectionName = "", string subID = "")
        {
            try
            {
                // Truy cập collection (bảng)
                CollectionReference collection = db.Collection(collectionName);

                // Tham chiếu đến document với ID cụ thể (1 dòng dữ liệu)
                // Nếu chưa có: tạo mới
                DocumentReference doc = subID == "" ? collection.Document(ID) :
                                                      collection.Document(ID).Collection(subCollectionName).Document(subID);

                // Xóa dòng dữ liệu khỏi DB
                await doc.DeleteAsync();

                // MessageBox.Show($"DELETE dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                // MessageBox.Show($"DELETE dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
