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
    public class SalesInvoiceDetailRepo(QLCHB_DBContext context) : RepositoryBase<SalesInvoice_Detail>(context)
    {
        internal IList<SalesInvoice_Detail> GetBySalesInvoiceId(int iD)
        {
            return context.SalesInvoiceDetails
            .Include(s => s.Product_Unit)
            .ThenInclude(p => p.Product)
            .Include(s => s.Product_Unit)
            .ThenInclude(p => p.Unit)
            .Where(s => s.InvoiceID == iD).ToList();
        }
    }
}
