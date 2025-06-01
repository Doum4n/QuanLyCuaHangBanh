using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Repositories
{
    public class WarehouseReleaseNoteDetailRepo(QLCHB_DBContext context) : RepositoryBase<WarehouseReleaseNote_Detail>(context)
    {
        private readonly InventoryRepo _inventoryRepo = new(context);

        public override void Add(WarehouseReleaseNote_Detail entity)
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                base.Add(entity);
                _inventoryRepo.UpdateQuantity(entity.Product_UnitID, entity.Quantity, false);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public void DeleteByID(int id)
        {
            var entity = context.WarehouseReleaseNoteDetails
                .FirstOrDefault(e => e.ID == id);

            if (entity != null)
            {
                using var transaction = context.Database.BeginTransaction();
                try
                {
                    // Restore inventory quantity before deleting
                    _inventoryRepo.UpdateQuantity(entity.Product_UnitID, entity.Quantity, true);
                    Delete(entity);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
