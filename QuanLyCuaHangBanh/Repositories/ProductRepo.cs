using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Repositories
{
    class ProductRepo : RepositoryBase<Product>
    {
        public ProductRepo(QLCHB_DBContext context) : base(context) { }

        public override IList<TDto> GetAllAsDto<TDto>(Func<Product, TDto> converter)
        {
            return context.Products.
                 Include(p => p.Category)       // Load dữ liệu Category
                .Include(p => p.Producer)       // Load dữ liệu Producer
                .Include(o => o.Inventories)
                .Include(p => p.ProductUnits)    // Load dữ liệu ProductUnits
                    .ThenInclude(pu => pu.Unit)
                .Select(converter)
                .ToList();
        }

        public void DeleteById(int ID)
        {
            context.Products.Remove(context.Products.Find(ID)!);
            context.ProductUnits.RemoveRange(context.ProductUnits.Where(pu => pu.ProductID == ID));
            context.SaveChanges();
        }

        public void AddProductUnit(Product_Unit productUnit)
        {
            context.ProductUnits.Add(productUnit);
            context.SaveChanges();
        }

        public int? GetProductUnitID(int productId, int unitId)
        {
            return context.ProductUnits.Where(pu => pu.ProductID == productId && pu.UnitID == unitId).Select(pu => pu.ID).FirstOrDefault();
        }

        public void UpdateProductUnit(Product_Unit productUnit)
        {
            context.ProductUnits.Update(productUnit);
            context.SaveChanges();
        }
    }
}
