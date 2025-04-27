using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Data
{
    class CloudinaryConfig
    {
        public static Cloudinary GetCloudinaryClient()
        {
            // Đọc các giá trị cấu hình từ App.config
            string cloudName = ConfigurationManager.AppSettings["CloudinaryCloudName"];
            string apiKey = ConfigurationManager.AppSettings["CloudinaryApiKey"];
            string apiSecret = ConfigurationManager.AppSettings["CloudinaryApiSecret"];

            // Tạo tài khoản Cloudinary với các thông tin lấy từ App.config
            var account = new Account(cloudName, apiKey, apiSecret);

            return new Cloudinary(account);
        }
    }
}
