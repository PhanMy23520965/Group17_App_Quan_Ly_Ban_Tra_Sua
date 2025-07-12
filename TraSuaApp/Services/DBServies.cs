using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Google.Protobuf.WellKnownTypes;
using Models.Admin;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace TraSuaApp.Services
{
    public abstract class DBServices
    {
        // Kết nối CSDL
        public static FirestoreDb Connect()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "firebase-adminsdk.json");
                FirestoreDb db = FirestoreDb.Create("quan-ly-quan-tra", new FirestoreClientBuilder
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

        // Phương thức đẩy dữ liệu lên CSDL
        public static async Task POST<T>(string ID, string collectionName, T obj) where T : class
        {
            // Kết nối CSDL
            FirestoreDb db = Connect();
            if (db == null) return;

            // Kiểm tra sự tồn tại của đối tượng 
            if (obj == null)
            {
  
                return;
            }

            // Truy cập collection (bảng)
            CollectionReference collection = db.Collection(collectionName);

            // Tham chiếu đến document với ID cụ thể (1 dòng dữ liệu)
            // Nếu chưa có: tạo mới
            DocumentReference docRef = collection.Document(ID);

            // Gửi object lên Firestore để lưu
            await docRef.SetAsync(obj);

           
        }

        // Phương thức lấy dữ liệu (danh sách dữ liệu T)
        public static async Task<List<T>> GET<T>(string collectionName, string search = "") where T : class
        {
            // Kết nối CSDL
            FirestoreDb db = Connect();
            if (db == null) return null;

            try
            {
                // Truy cập collection và lấy snapshot (bản sao của dữ liệu)
                CollectionReference collection = db.Collection(collectionName);
                QuerySnapshot snapshot = await collection.GetSnapshotAsync();

                // Lấy dữ liệu từ snapshot, chuyển thành object kiểu T và lưu vào danh sách 
                List<T> danhSach = new List<T>();
                foreach (DocumentSnapshot doc in snapshot.Documents)
                {
                    T obj = doc.ConvertTo<T>();

                    // Nếu obj có thuộc tính "ID", gán doc.Id vào ID
                    var ID = obj.GetType().GetProperty("ID");
                    ID.SetValue(obj, doc.Id);

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

                
                return danhSach;
            }
            catch // (Exception ex)
            {
                MessageBox.Show($"GET dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Phương thức sửa đổi dữ liệu 
        public static async Task PUT<T>(string ID, string collectionName, T obj) where T : class
        {
            // Kết nối CSDL
            FirestoreDb db = Connect();
            if (db == null) return;

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
                DocumentReference docRef = collection.Document(ID);

                // Cập nhật dòng dữ liệu trên DB
                await docRef.SetAsync(obj, SetOptions.Overwrite);

                
            }
            catch
            {
                MessageBox.Show($"PUT dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static async Task DELETE(string ID, string collectionName)
        {
            // Kết nối CSDL
            FirestoreDb db = Connect();
            if (db == null) return;

            try
            {
                // Truy cập collection (bảng)
                CollectionReference collection = db.Collection(collectionName);

                // Tham chiếu đến document với ID cụ thể (1 dòng dữ liệu)
                DocumentReference docRef = collection.Document(ID);

                // Xóa dòng dữ liệu khỏi DB
                await docRef.DeleteAsync();

                
            }
            catch
            {
                MessageBox.Show($"DELETE dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task SendPasswordResetEmailAuth(string email)
        {
            try
            {
                string apiKey = "AIzaSyAQKaZZ7DQw2ktZ_2sFaQsi_f0oJRbm_1o";
                string url = $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={apiKey}";

                var payload = new
                {
                    requestType = "PASSWORD_RESET",
                    email = email
                };

                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Đã gửi link reset mật khẩu tới {email}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Gửi link thất bại: {result}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi reset email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
