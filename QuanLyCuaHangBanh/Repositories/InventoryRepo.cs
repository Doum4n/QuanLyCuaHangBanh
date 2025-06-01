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
            var inventory = context.Inventories
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
