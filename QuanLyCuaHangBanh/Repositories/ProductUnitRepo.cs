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
    class ProductUnitRepo(QLCHB_DBContext context) : RepositoryBase<Product_Unit>(context)
    {
        internal void DeleteById(int productId)
        {
            var productUnit = context.ProductUnits
                .Where(p => p.ProductID == productId)
                .ToList();
            if (productUnit.Count > 0)
            {
                foreach (var unit in productUnit)
                {
                    context.ProductUnits.Remove(unit);
                }
                context.SaveChanges();
            }
        }

        public int GetProductUnitId(int productId, int unitId)
        {
            var productUnit = context.ProductUnits
                .Where(p => p.ProductID == productId && p.UnitID == unitId)
                .FirstOrDefault();
            if (productUnit != null)
            {
                return productUnit.ID;
            }
            return 0;
        }

        public Product_Unit AddWithReturn(Product_Unit productUnit)
        {
            context.ProductUnits.Add(productUnit);
            context.SaveChanges();
            return productUnit;
        }
    }
}
