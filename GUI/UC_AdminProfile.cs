using Models.Admin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraSuaApp.Services;
using static System.Net.Mime.MediaTypeNames;

namespace TraSuaApp
{
    public partial class UC_AdminProfile : UserControl
    {
        string collectionName = "QuanTriVien";
        public UC_AdminProfile()
        {
            InitializeComponent();
        }
        private QuanTriVien createProduct()
        {
            try
            {
                QuanTriVien qtv = new QuanTriVien
                {
                    HoTen = tbName.Text.Trim(),
                    SoDienThoai = tbPhone.Text.Trim()
                };
                return qtv;
            }
            catch
            {
                return null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        /*private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await DBServices.PUT(tbProductID.Text.Trim(), collectionName, createProduct());

            Display();
        }*/
    }
}
