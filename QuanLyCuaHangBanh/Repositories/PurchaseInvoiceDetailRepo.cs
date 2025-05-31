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
    public class PurchaseInvoiceDetailRepo(QLCHB_DBContext context) : RepositoryBase<PurchaseInvoice_Detail>(context)
    {

        public void DeleteById(int Id)
        {
            var entity = context.PurchaseInvoiceDetails.Find(Id);
            if (entity != null)
            {
                base.Delete(entity);
            }
        }

        public IList<PurchaseInvoice_Detail> GetByPurchaseInvoiceId(int purchaseInvoiceId)
        {
            return context.PurchaseInvoiceDetails
                .Include(i => i.Product_Unit.Product)
                .Include(i => i.Product_Unit.Unit)
                .Include(i => i.Product_Unit)
                .Where(i => i.InvoiceID == purchaseInvoiceId)
                .ToList();
        }
    }
}
