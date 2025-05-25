using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views.Order;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Presenters
{
    public class OrderPresenter(IOrderView view, IRepositoryProvider provider) : PresenterBase<Order>(view, provider)
    {
        public override void LoadData()
        {
            BindingSource.DataSource = Provider.GetRepository<Order>().GetAllAsDto<OrderDTO>(
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
                )).ToList();
        }

        public override void OnExport(object? sender, EventArgs e)
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

            foreach(var item in BindingSource.List)
            {
                if(item is OrderDTO orderDTO)
                {
                    var order = Provider.GetRepository<Order>().GetByValue(orderDTO.ID);
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
            }

            ExcelHandler.ExportExcel("Đơn hàng", "Đơn hàng", "Chi tiết đơn hàng", orderTable1, orderTable2);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(
                ImportOrder,
                ImportOrderDetail
            );
        }

        private void ImportOrderDetail(DataRow row)
        {
            var productId = int.Parse(row["Mã sản phẩm"].ToString());
            var unitId = int.Parse(row["Mã ĐVT"].ToString());

            var productUnitId = ((ProductUnitRepo)Provider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

            Order_Detail orderDetail = new Order_Detail()
            {
                OrderId = Convert.ToInt32(row["Mã đơn hàng"]),
                Product_UnitID = productUnitId,
                Quantity = Convert.ToInt32(row["Số lượng"]),
                Price = Convert.ToDecimal(row["Đơn giá"]),
                Note = row["Ghi chú"].ToString() ?? string.Empty
            };
            Provider.GetRepository<Order_Detail>().Add(orderDetail);
        }

        private void ImportOrder(DataRow row)
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
            Provider.GetRepository<Order>().Add(order);
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            OrderInputView orderInputView = new OrderInputView();
            if (orderInputView.ShowDialog() == DialogResult.OK)
            {
                if(orderInputView.Tag is Order order)
                {
                    Provider.GetRepository<Order>().Add(order);

                    foreach(var product in orderInputView.Products)
                    {
                        product.OrderId = order.ID;
                        product.ProductUnitId = product.ProductUnitId;
                        Provider.GetRepository<Order_Detail>().Add(product.ToOrderDetail());
                    }

                    View.Message = "Thêm đơn hàng thành công!";
                    LoadData();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (BindingSource.Current is OrderDTO orderDTO)
            {
                var order = Provider.GetRepository<Order>().GetByValue(orderDTO.ID);
                if (order != null)
                {
                    Provider.GetRepository<Order>().Delete(order);
                    View.Message = "Xóa đơn hàng thành công!";
                    LoadData();
                }
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
