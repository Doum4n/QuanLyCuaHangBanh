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
        public override IList<TDto> GetAllAsDto<TDto>(Func<GoodsReceiptNote_Detail, TDto> converter)
        {
            return context.GoodsReceiptNoteDetails
                .Include(g => g.GoodsReceiptNote)
                .Include(g => g.Product)
                .Include(g => g.Unit)
                .Include(o => o.ProductUnit)
                .Include(g => g.Product)
                .ThenInclude(p => p.Category)
                .Select(converter)
                .ToList();
        }

        public override void Add(GoodsReceiptNote_Detail entity)
        {

            base.Add(entity);

            // Update the quantity in the inventory
            var inventory = context.Inventories
                .FirstOrDefault(i => i.ProductUnitID == entity.ProductUnitId && i.GoodsReceiptNoteDetailID == entity.ID);
            if (inventory != null)
            {
                inventory.Quantity += entity.Quantity;
                context.Inventories.Update(inventory);
            }
            else
            {
                MessageBox.Show("it work");
                // If inventory doesn't exist, create a new one
                Inventory newInventory = new Inventory
                {
                    ProductUnitID = entity.ProductUnitId,
                    GoodsReceiptNoteDetailID = entity.ID,
                    Quantity = entity.Quantity
                };
                context.Inventories.Add(newInventory);
            }
            context.SaveChanges();

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
