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
        public override void Add(WarehouseReleaseNote_Detail entity)
        {
            Product_Unit productUnit = context.ProductUnits.FirstOrDefault(o => o.ID == entity.Product_UnitID);

            if (productUnit != null)
            {
                // Cập nhật số lượng tồn kho khi lập phiếu xuất kho
                context.Inventories
                    .Where(i => i.ProductUnitID == productUnit.ID)
                    .ToList()
                    .ForEach(i =>
                    {
                        i.Quantity -= entity.Quantity;
                        context.Entry(i).State = EntityState.Modified;
                    });

                context.SaveChanges();
            }

            base.Add(entity);
        }

        public void DeleteByID(int id)
        {
            var entity = context.WarehouseReleaseNoteDetails
                .FirstOrDefault(e => e.ID == id);

            if (entity != null)
            {
                Delete(entity);
            }
        }
    }
}
