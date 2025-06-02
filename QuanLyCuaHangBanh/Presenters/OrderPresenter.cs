using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories; // Vẫn cần nếu ProductUnitRepo không được di chuyển
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views.Order;
using QuanLyCuaHangBanh.Services; // Thêm namespace của Service
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks; // Thêm để sử dụng DialogResult

namespace QuanLyCuaHangBanh.Presenters
{
    /// <summary>
    /// Presenter cho quản lý đơn hàng
    /// Xử lý logic nghiệp vụ giữa view và service
    /// </summary>
    /// <param name="view">View hiển thị giao diện đơn hàng</param>
    /// <param name="orderService">Service xử lý nghiệp vụ đơn hàng</param>
    public class OrderPresenter(IOrderView view, OrderService orderService) : PresenterBase<Order>(view, (IService)orderService)
    {

        private IList<OrderDTO> _orders = new List<OrderDTO>();

        /// <summary>
        /// Khởi tạo dữ liệu ban đầu
        /// - Tải danh sách đơn hàng
        /// - Binding dữ liệu lên view
        /// </summary>
        public override async Task InitializeAsync()
        {
            _orders = await ((OrderService)Service).GetAllOrdersAsDto();
            BindingSource.DataSource = _orders;
        }

        /// <summary>
        /// Xử lý xuất dữ liệu đơn hàng ra Excel
        /// </summary>
        /// <param name="sender">Đối tượng gọi sự kiện</param>
        /// <param name="e">Tham số sự kiện</param>
        public override async void OnExport(object? sender, EventArgs e)
        {
            var (orderTable1, orderTable2) = await ((OrderService)Service).ExportOrdersToDataTables((IEnumerable<OrderDTO>)BindingSource.List);
            ExcelHandler.ExportExcel("Đơn hàng", "Đơn hàng", "Chi tiết đơn hàng", orderTable1, orderTable2);
        }

        /// <summary>
        /// Xử lý nhập dữ liệu đơn hàng từ Excel
        /// </summary>
        /// <param name="sender">Đối tượng gọi sự kiện</param>
        /// <param name="e">Tham số sự kiện</param>
        public override async void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(
                ((OrderService)Service).ImportOrder,
                ((OrderService)Service).ImportOrderDetail
            );
            await InitializeAsync(); // Load lại dữ liệu sau khi import
        }

        /// <summary>
        /// Xử lý chỉnh sửa đơn hàng
        /// </summary>
        /// <param name="sender">Đối tượng gọi sự kiện</param>
        /// <param name="e">Tham số sự kiện</param>
        public override async void OnEdit(object? sender, EventArgs e)
        {
            OrderInputView orderInputView = new OrderInputView((OrderDTO)View.SelectedItem);
            if (orderInputView.ShowDialog() == DialogResult.OK)
            {
                if (orderInputView.Tag is Order order)
                {
                    ((OrderService)Service).UpdateOrder(order, orderInputView.Products);
                    View.Message = "Cập nhật đơn hàng thành công!";
                    await InitializeAsync();
                }
            }
        }

        /// <summary>
        /// Xử lý thêm đơn hàng mới
        /// </summary>
        /// <param name="sender">Đối tượng gọi sự kiện</param>
        /// <param name="e">Tham số sự kiện</param>
        public override async void OnAddNew(object? sender, EventArgs e)
        {
            OrderInputView orderInputView = new OrderInputView();
            if (orderInputView.ShowDialog() == DialogResult.OK)
            {
                if (orderInputView.Tag is Order order)
                {
                    ((OrderService)Service).AddOrder(order, orderInputView.Products);
                    View.Message = "Thêm đơn hàng thành công!";
                   await InitializeAsync();
                }
            }
        }

        /// <summary>
        /// Xử lý xóa đơn hàng
        /// </summary>
        /// <param name="sender">Đối tượng gọi sự kiện</param>
        /// <param name="e">Tham số sự kiện</param>
        public override async void OnDelete(object? sender, EventArgs e)
        {
            if (BindingSource.Current is OrderDTO orderDTO)
            {
                await ((OrderService)Service).DeleteOrder(orderDTO.ID);
                View.Message = "Xóa đơn hàng thành công!";
                await InitializeAsync();
            }
        }

        /// <summary>
        /// Xử lý tìm kiếm đơn hàng
        /// </summary>
        /// <param name="sender">Đối tượng gọi sự kiện</param>
        /// <param name="e">Tham số sự kiện</param>
        public override async void OnSearch(object? sender, EventArgs e)
        {
            var searchValue = this.View.SearchValue.ToLower();
            if (string.IsNullOrEmpty(searchValue))
            {
                await InitializeAsync();
            }
            else
            {
                if (_orders != null)
                {
                    var searchResult = _orders.Where(x => x.MatchesSearch(searchValue)).ToList();
                    BindingSource.DataSource = searchResult;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không khả dụng để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}