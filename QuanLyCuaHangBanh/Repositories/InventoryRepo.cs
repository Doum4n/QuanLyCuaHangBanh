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
        internal void DeleteById(int inventoryId)
        {
            context.Inventories
                .Where(i => i.ID == inventoryId)
                .ToList()
                .ForEach(i => context.Inventories.Remove(i));
        }
    }
}
