using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Views.Order
{
    /// <summary>
    /// Interface định nghĩa các chức năng cơ bản của form quản lý đơn hàng
    /// Kế thừa từ IView để có các chức năng cơ bản của một form
    /// </summary>
    public interface IOrderView : IView
    {
        // Interface không cần thêm phương thức mới
        // Tất cả các chức năng cần thiết đã được định nghĩa trong IView
    }
}
