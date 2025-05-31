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
    public class OrderService(IRepositoryProvider provider) : IService
    {
        private readonly IRepositoryProvider _provider = provider;

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsDto()
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

        public void AddOrder(Order order, BindingList<ProductOrderDTO> products)
        {
            _provider.GetRepository<Order>().Add(order);

            foreach (var product in products)
            {
                product.OrderId = order.ID;
                product.ProductUnitId = product.ProductUnitId;
                _provider.GetRepository<Order_Detail>().Add(product.ToOrderDetail());
            }
        }

        public void UpdateOrder(Order order, BindingList<ProductOrderDTO> products)
        {
            _provider.GetRepository<Order>().Update(order);

            // Xóa các chi tiết đơn hàng cũ
            var existingDetails = _provider.GetRepository<Order_Detail>().GetAll().Result.Where(od => od.OrderId == order.ID).ToList();
            foreach (var detail in existingDetails)
            {
                _provider.GetRepository<Order_Detail>().Delete(detail);
            }
            // Thêm lại các chi tiết đơn hàng (có thể bao gồm các mục mới, đã sửa hoặc còn lại)
            foreach (var product in products)
            {
                switch (product.Status)
                {
                    case DTO.Base.Status.New:
                    case DTO.Base.Status.Modified:
                    case DTO.Base.Status.None: // Nếu không thay đổi thì cũng thêm lại
                        product.OrderId = order.ID;
                        _provider.GetRepository<Order_Detail>().Add(product.ToOrderDetail());
                        break;
                    case DTO.Base.Status.Deleted:
                        // Đã xóa ở bước xóa toàn bộ chi tiết cũ, không cần làm gì thêm ở đây
                        break;
                }
            }
        }


        public async Task DeleteOrder(int orderId)
        {
            var order = await _provider.GetRepository<Order>().GetByValue(orderId);
            if (order != null)
            {
                _provider.GetRepository<Order>().Delete(order);
            }
        }

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