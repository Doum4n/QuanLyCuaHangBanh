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
    public class SalesInvoiceRepo(QLCHB_DBContext context) : RepositoryBase<SalesInvoice>(context)
    {
        public override IList<TDto> GetAllAsDto<TDto>(Func<SalesInvoice, TDto> converter)
        {
            return context.SalesInvoices
                .Include(i => i.InvoiceDetails)
                .ThenInclude(o => o.Product_Unit)   
                .Include(i => i.Employee)
                .Select(converter).ToList();
        }

        public override SalesInvoice? GetByValue(object value)
        {
            return context.SalesInvoices
                .Include(i => i.InvoiceDetails)
                .Include(i => i.Employee)
                .FirstOrDefault(i => i.ID == (int)value);
        }
    }
}
