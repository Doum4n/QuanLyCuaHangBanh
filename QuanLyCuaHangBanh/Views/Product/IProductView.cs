using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Views.Product
{
    /// <summary>
    /// Interface định nghĩa các chức năng của form quản lý sản phẩm
    /// Kế thừa từ IView để có các chức năng cơ bản của một form
    /// </summary>
    public interface IProductView : IView
    {
        /// <summary>
        /// Sự kiện khi đơn vị được chọn thay đổi
        /// </summary>
        event EventHandler SelectedUnitChanged;
    }
}
