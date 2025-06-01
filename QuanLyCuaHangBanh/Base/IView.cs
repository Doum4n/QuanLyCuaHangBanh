using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    /// <summary>
    /// Giao diện cơ sở cho tất cả các form quản lý trong ứng dụng
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Giá trị tìm kiếm hiện tại
        /// </summary>
        String SearchValue { get; set; }

        /// <summary>
        /// Thông báo hiển thị cho người dùng
        /// </summary>
        String Message { get; set; }

        /// <summary>
        /// Sự kiện khi người dùng thực hiện tìm kiếm
        /// </summary>
        event EventHandler SearchEvent;

        /// <summary>
        /// Sự kiện khi người dùng xóa một mục
        /// </summary>
        event EventHandler DeleteEvent;

        /// <summary>
        /// Sự kiện khi người dùng thêm mục mới
        /// </summary>
        event EventHandler AddNewEvent;

        /// <summary>
        /// Sự kiện khi người dùng chỉnh sửa một mục
        /// </summary>
        event EventHandler EditEvent;

        /// <summary>
        /// Sự kiện khi người dùng nhập dữ liệu
        /// </summary>
        event EventHandler ImportEvent;

        /// <summary>
        /// Sự kiện khi người dùng xuất dữ liệu
        /// </summary>
        event EventHandler ExportEvent;

        /// <summary>
        /// Mục được chọn hiện tại
        /// </summary>
        Object SelectedItem { get; set; }

        /// <summary>
        /// Thiết lập nguồn dữ liệu cho điều khiển hiển thị
        /// </summary>
        /// <param name="bindingSource">Nguồn dữ liệu liên kết</param>
        void SetBindingSource(BindingSource bindingSource);
    }
}
