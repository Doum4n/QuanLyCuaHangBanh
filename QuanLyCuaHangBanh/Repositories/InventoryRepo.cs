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
    public class InventoryRepo(QLCHB_DBContext context) : RepositoryBase<Inventory>(context)
    {
        public void UpdateQuantity(int productUnitId, int quantity, bool isIncrease)
        {
            // Do lưu tồn kho theo lô (Phiếu nnhập) nên có cùng 1 đvt của 1 sản phẩm có thể nhiều tồn kho
            var inventory = context.Inventories
                .Where(o => o.Quantity > 0) // Lấy tồn kho có số lượng > 0, trường hợp số lượng nhập đợt đó hết
                .FirstOrDefault(i => i.ProductUnitID == productUnitId);

            if (inventory != null)
            {
                inventory.Quantity = isIncrease ? 
                    inventory.Quantity + quantity : 
                    inventory.Quantity - quantity;

                context.Entry(inventory).State = EntityState.Modified;
            }
            else if (isIncrease)
            {
                // Only create new inventory when increasing quantity
                inventory = new Inventory
                {
                    ProductUnitID = productUnitId,
                    Quantity = quantity,
                    ReceivedDate = DateTime.UtcNow
                };
                context.Inventories.Add(inventory);
            }
        }

        internal void DeleteById(int inventoryId)
        {
            context.Inventories
                .Where(i => i.ID == inventoryId)
                .ToList()
                .ForEach(i => context.Inventories.Remove(i));
        }
    }
}
