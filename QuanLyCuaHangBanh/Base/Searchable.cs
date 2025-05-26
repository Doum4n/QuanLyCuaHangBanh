using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    public abstract class Searchable : ISearchable
    {
        /// <summary>
        /// Triển khai mặc định cho phương thức tìm kiếm bằng Reflection.
        /// Phương thức này sẽ kiểm tra tất cả các thuộc tính kiểu string của đối tượng hiện tại
        /// để xem chúng có chứa giá trị tìm kiếm hay không (không phân biệt hoa thường).
        /// </summary>
        /// <param name="searchValue">Giá trị cần tìm kiếm.</param>
        /// <returns>True nếu tìm thấy giá trị trong bất kỳ thuộc tính string nào, ngược lại là False.</returns>
        public virtual bool MatchesSearch(string searchValue)
        {
            // Nếu giá trị tìm kiếm rỗng hoặc null, coi như khớp (tùy thuộc vào yêu cầu của bạn)
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                return true;
            }

            string lowerSearchValue = searchValue.ToLower(); // Chuyển sang chữ thường để so sánh

            // Lấy tất cả các thuộc tính kiểu string của đối tượng hiện tại (this)
            var stringProperties = this.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance) // Lấy các thuộc tính public instance
                .Where(p => p.PropertyType == typeof(string));

            // Kiểm tra xem bất kỳ thuộc tính string nào có chứa giá trị tìm kiếm không
            foreach (var property in stringProperties)
            {
                var value = property.GetValue(this) as string; // Lấy giá trị của thuộc tính từ đối tượng hiện tại

                if (value != null && value.ToLower().Contains(lowerSearchValue))
                {
                    return true; // Tìm thấy, trả về true ngay lập tức
                }
            }

            return false; // Không tìm thấy trong bất kỳ thuộc tính string nào
        }
    }
}
