using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Data;
using Microsoft.EntityFrameworkCore;

namespace QuanLyCuaHangBanh.Repositories
{
    class GoodsReceiptNoteDetailRepo(QLCHB_DBContext context) : RepositoryBase<GoodsReceiptNote_Detail>(context)
    {
        private readonly InventoryRepo _inventoryRepo = new(context);

        public override void Add(GoodsReceiptNote_Detail entity)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                base.Add(entity);
                _inventoryRepo.UpdateQuantity(entity.ProductUnitId, entity.Quantity, true);
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        internal List<GoodsReceiptNote_Detail> GetReceiptNote_Details(int value)
        {
            return context.GoodsReceiptNoteDetails
                .Include(g => g.GoodsReceiptNote)
                .Include(g => g.Product)
                .ThenInclude(o => o.Category)
                .Include(g => g.Unit)
                .Include(g => g.Product)
                .ThenInclude(p => p.Category)
                .Include(g => g.ProductUnit)
                .Where(g => g.GoodsReceiptNoteId == value)
                .ToList();
        }
    }
}
