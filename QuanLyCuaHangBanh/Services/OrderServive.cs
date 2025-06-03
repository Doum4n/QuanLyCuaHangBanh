using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Services
{
    /// <summary>
    /// Service xử lý nghiệp vụ liên quan đến đơn hàng
    /// </summary>
    /// <param name="provider">Provider cung cấp các repository</param>
    public class OrderService(IRepositoryProvider provider) : IService
    {
        private readonly IRepositoryProvider _provider = provider;

        /// <summary>
        /// Lấy danh sách tất cả đơn hàng dưới dạng DTO
        /// </summary>
        /// <returns>Danh sách OrderDTO chứa thông tin đơn hàng</returns>
        public async Task<IList<OrderDTO>> GetAllOrdersAsDto()
        {
            return await _provider.GetRepository<Order>().GetAllAsDto<OrderDTO>(
                o => new OrderDTO
                (
                    o.ID,
                    o.Customer.Name,
                    o.Customer.PhoneNumber,
                    o.OrderDate,
                    o.OrderDetails.Sum(od => od.Price * od.Quantity),
                    o.Status,
                    o.PaymentMethod,
                    o.DeliveryAddress
                ));
        }

        /// <summary>
        /// Thêm đơn hàng mới vào database
        /// </summary>
        /// <param name="order">Thông tin đơn hàng cần thêm</param>
        /// <param name="products">Danh sách sản phẩm trong đơn hàng</param>
        public void AddOrder(Order order, BindingList<ProductOrderDTO> products)
        {
            order.ID = 0;
            _provider.GetRepository<Order>().Add(order);

            foreach (var product in products)
            {
                product.ID = 0; // Đặt ID thành 0 để tạo mới
                product.OrderId = order.ID;
                product.ProductUnitId = product.ProductUnitId;
                _provider.GetRepository<Order_Detail>().Add(product.ToOrderDetail());
            }
        }

        /// <summary>
        /// Cập nhật thông tin đơn hàng
        /// </summary>
        /// <param name="order">Thông tin đơn hàng cần cập nhật</param>
        /// <param name="products">Danh sách sản phẩm mới trong đơn hàng</param>
        public void UpdateOrder(Order order, BindingList<ProductOrderDTO> products)
        {
            _provider.GetRepository<Order>().Update(order);
            foreach (var product in products)
            {
                switch (product.Status)
                {
                    case DTO.Base.Status.New:
                        product.ID = 0;
                        product.OrderId = order.ID;
                        _provider.GetRepository<Order_Detail>().Add(product.ToOrderDetail());
                        break;
                    case DTO.Base.Status.Modified:
                        product.OrderId = order.ID;
                        _provider.GetRepository<Order_Detail>().Update(product.ToOrderDetail());
                        break;
                    case DTO.Base.Status.Deleted:
                        _provider.GetRepository<Order_Detail>().Delete(product.ToOrderDetail());
                        break;
                }
            }
        }

        /// <summary>
        /// Xóa đơn hàng khỏi database
        /// </summary>
        /// <param name="orderId">ID của đơn hàng cần xóa</param>
        public async Task DeleteOrder(int orderId)
        {
            var order = await _provider.GetRepository<Order>().GetByValue(orderId);
            if (order != null)
            {
                _provider.GetRepository<Order>().Delete(order);
            }
        }

        /// <summary>
        /// Xuất danh sách đơn hàng ra DataTable
        /// </summary>
        /// <param name="orderDtos">Danh sách đơn hàng cần xuất</param>
        /// <returns>Tuple chứa 2 DataTable: bảng đơn hàng và bảng chi tiết đơn hàng</returns>
        public async Task<(DataTable, DataTable)> ExportOrdersToDataTables(IEnumerable<OrderDTO> orderDtos)
        {
            DataTable orderTable1 = new DataTable("Orders");
            orderTable1.Columns.Add("Mã đơn hàng", typeof(int));
            orderTable1.Columns.Add("Mã khách hàng", typeof(int));
            orderTable1.Columns.Add("Tên khách hàng", typeof(string));
            orderTable1.Columns.Add("Số điện thoại", typeof(string));
            orderTable1.Columns.Add("Ngày đặt hàng", typeof(DateTime));
            orderTable1.Columns.Add("Địa chỉ giao hàng", typeof(string));
            orderTable1.Columns.Add("Phương thức thanh toán", typeof(string));
            orderTable1.Columns.Add("Trạng thái", typeof(string));
            orderTable1.Columns.Add("Tổng tiền", typeof(decimal));

            DataTable orderTable2 = new DataTable("OrderDetails");
            orderTable2.Columns.Add("Mã đơn hàng", typeof(int));
            orderTable2.Columns.Add("Mã sản phẩm", typeof(int));
            orderTable2.Columns.Add("Tên sản phẩm", typeof(string));
            orderTable2.Columns.Add("Mã lọai", typeof(int));
            orderTable2.Columns.Add("Tên loại", typeof(string));
            orderTable2.Columns.Add("Mã ĐVT", typeof(int));
            orderTable2.Columns.Add("ĐVT", typeof(string));
            orderTable2.Columns.Add("Số lượng", typeof(int));
            orderTable2.Columns.Add("Đơn giá", typeof(decimal));
            orderTable2.Columns.Add("Ghi chú", typeof(string));

            foreach (var orderDTO in orderDtos)
            {
                var order = await _provider.GetRepository<Order>().GetByValue(orderDTO.ID);
                if (order != null)
                {
                    orderTable1.Rows.Add(
                        order.ID,
                        order.CustomerID,
                        order.Customer.Name,
                        order.Customer.PhoneNumber,
                        order.OrderDate,
                        order.DeliveryAddress,
                        order.PaymentMethod,
                        order.Status,
                        order.OrderDetails.Sum(od => od.Price * od.Quantity));

                    foreach (var detail in order.OrderDetails)
                    {
                        orderTable2.Rows.Add(
                            order.ID,
                            detail.Product_Unit.ProductID,
                            detail.Product_Unit.Product.Name,
                            detail.Product_Unit.Product.CategoryID,
                            detail.Product_Unit.Product.Category.Name,
                            detail.Product_Unit.UnitID,
                            detail.Product_Unit.Unit.Name,
                            detail.Quantity,
                            detail.Price,
                            detail.Note
                        );
                    }
                }
            }
            return (orderTable1, orderTable2);
        }

        /// <summary>
        /// Nhập thông tin đơn hàng từ DataRow
        /// </summary>
        /// <param name="row">DataRow chứa thông tin đơn hàng cần nhập</param>
        public void ImportOrder(DataRow row)
        {
            Order order = new Order()
            {
                ID = Convert.ToInt32(row["Mã đơn hàng"]),
                CustomerID = Convert.ToInt32(row["Mã khách hàng"]),
                DeliveryAddress = row["Địa chỉ giao hàng"].ToString() ?? string.Empty,
                PaymentMethod = row["Phương thức thanh toán"].ToString() ?? string.Empty,
                OrderDate = Convert.ToDateTime(row["Ngày đặt hàng"]),
                Status = row["Trạng thái"].ToString() ?? string.Empty
            };
            _provider.GetRepository<Order>().Add(order);
        }

        /// <summary>
        /// Nhập chi tiết đơn hàng từ DataRow
        /// </summary>
        /// <param name="row">DataRow chứa thông tin chi tiết đơn hàng cần nhập</param>
        public void ImportOrderDetail(DataRow row)
        {
            var productId = int.Parse(row["Mã sản phẩm"].ToString());
            var unitId = int.Parse(row["Mã ĐVT"].ToString());

            var productUnitId = ((ProductUnitRepo)_provider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

            Order_Detail orderDetail = new Order_Detail()
            {
                OrderId = Convert.ToInt32(row["Mã đơn hàng"]),
                Product_UnitID = productUnitId,
                Quantity = Convert.ToInt32(row["Số lượng"]),
                Price = Convert.ToDecimal(row["Đơn giá"]),
                Note = row["Ghi chú"].ToString() ?? string.Empty
            };
            _provider.GetRepository<Order_Detail>().Add(orderDetail);
        }
    }
}