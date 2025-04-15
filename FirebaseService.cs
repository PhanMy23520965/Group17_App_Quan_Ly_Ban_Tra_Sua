using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TraSuaApp.Models;

namespace TraSuaApp.Services
{
    public class FirebaseService
    {
        private readonly string databaseURL = "https://console.firebase.google.com/project/trasuaapp-9532f/database/trasuaapp-9532f-default-rtdb/data/~2F"; // THAY BẰNG LINK THỰC TẾ

        public async Task<Dictionary<string, SanPham>> GetDanhSachSanPhamAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"{databaseURL}/SanPham.json";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var danhSach = JsonConvert.DeserializeObject<Dictionary<string, SanPham>>(json);
                    return danhSach;
                }
                return null;
            }
        }
    }
}
