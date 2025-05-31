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
    public class OrderPresenter(IOrderView view, OrderService orderService) : PresenterBase<Order>(view, (IService)orderService)
    {
        public override async Task InitializeAsync()
        {
            BindingSource.DataSource = await ((OrderService)Service).GetAllOrdersAsDto();
        }

        public override async void OnExport(object? sender, EventArgs e)
        {
            var (orderTable1, orderTable2) = await ((OrderService)Service).ExportOrdersToDataTables((IEnumerable<OrderDTO>)BindingSource.List);
            ExcelHandler.ExportExcel("Đơn hàng", "Đơn hàng", "Chi tiết đơn hàng", orderTable1, orderTable2);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(
                ((OrderService)Service).ImportOrder,
                ((OrderService)Service).ImportOrderDetail
            );
            InitializeAsync(); // Load lại dữ liệu sau khi import
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            OrderInputView orderInputView = new OrderInputView((OrderDTO)View.SelectedItem);
            if (orderInputView.ShowDialog() == DialogResult.OK)
            {
                if (orderInputView.Tag is Order order)
                {
                    ((OrderService)Service).UpdateOrder(order, orderInputView.Products);
                    View.Message = "Cập nhật đơn hàng thành công!";
                    InitializeAsync();
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            OrderInputView orderInputView = new OrderInputView();
            if (orderInputView.ShowDialog() == DialogResult.OK)
            {
                if (orderInputView.Tag is Order order)
                {
                    ((OrderService)Service).AddOrder(order, orderInputView.Products);
                    View.Message = "Thêm đơn hàng thành công!";
                    InitializeAsync();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (BindingSource.Current is OrderDTO orderDTO)
            {
                ((OrderService)Service).DeleteOrder(orderDTO.ID);
                View.Message = "Xóa đơn hàng thành công!";
                InitializeAsync();
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}