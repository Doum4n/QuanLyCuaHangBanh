using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Data;
using Microsoft.EntityFrameworkCore;

namespace QuanLyCuaHangBanh.Repositories
{
    public class OrderRepo(QLCHB_DBContext context) : RepositoryBase<Order>(context)
    {
        public override IList<TDto> GetAllAsDto<TDto>(Func<Order, TDto> converter)
        {
              return context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .Select(converter)
                .ToList();
        }

        public override Order? GetByValue(object value)
        {
            return context.Orders
                .AsNoTracking()
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product_Unit)
                .ThenInclude(o => o.Product)
                .ThenInclude(o => o.Category)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product_Unit)
                .ThenInclude(o => o.Unit)
                .FirstOrDefault(o => o.ID == (int)value);
        }
    }
}
