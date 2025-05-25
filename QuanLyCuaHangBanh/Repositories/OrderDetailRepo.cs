using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;

namespace QuanLyCuaHangBanh.Repositories
{
    public class OrderDetailRepo(QLCHB_DBContext context) : RepositoryBase<Order_Detail>(context)
    {
        public override void Add(Order_Detail entity)
        {
            // Thêm giá tiền vào Order_Detail
            var product = context.ProductUnits.Find(entity.Product_UnitID);
            if (product != null)
            {
                entity.Price = product.UnitPrice;
            }

            base.Add(entity);
        }

        public IList<Order_Detail> GetOrderDetail(int orderId)
        {
            var order = context.OrderDetails
                .Include(od => od.Product_Unit)
                .ThenInclude(pu => pu.Product)
                .ThenInclude(p => p.Category)
                .Include(od => od.Product_Unit.Unit)
                .Where(od => od.OrderId == orderId)
                .ToList();

            return order; 
        }
    }
}
