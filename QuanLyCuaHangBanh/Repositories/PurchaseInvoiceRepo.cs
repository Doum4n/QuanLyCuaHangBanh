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
    public class PurchaseInvoiceRepo(QLCHB_DBContext context) : RepositoryBase<PurchaseInvoice>(context)
    {
        public override IList<TDto> GetAllAsDto<TDto>(Func<PurchaseInvoice, TDto> converter)
        {
            return context.PurchaseInvoices
                .Include(i => i.Supplier)
                .Include(i => i.Employee)
                .Include(i => i.InvoiceDetails)
                .ThenInclude(d => d.Product_Unit)
                .Select(converter)
                .ToList();
        }

        public override PurchaseInvoice? GetByValue(object value)
        {
            return context.PurchaseInvoices
                .Include(i => i.Supplier)
                .Include(i => i.Employee)
                .Include(i => i.InvoiceDetails)
                .ThenInclude(d => d.Product_Unit)
                .FirstOrDefault(i => i.ID == (int)value);
        }
    }
}
