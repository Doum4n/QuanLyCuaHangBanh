using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Helpers
{
    class ImageHelper
    {
        public static Image LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Tải stream hình ảnh từ URL
                    var stream = client.GetStreamAsync(imageUrl).Result;

                    // Chuyển stream thành Image
                    return Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu không tải được hình ảnh
                MessageBox.Show($"Error loading image: {ex.Message}");
                return null;
            }
        }
    }
}
