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
    class ProductRepo : IRepository<Product, ProductDTO>
    {

        QLCHB_DBContext context = new QLCHB_DBContext();

        public void Add(Product entity)
        {
        }

        public void Delete(Product entity)
        {
        }

        public List<Product> getAll()
        {
            return context.Products.ToList();
        }

        public List<ProductDTO> getAllDto()
        {

            return context.Products
                .Include(p => p.Category)       // Load dữ liệu Category
                .Include(p => p.Producer)       // Load dữ liệu Producer
                .Include(p => p.ProductUnits)    // Load dữ liệu ProductUnits
                    .ThenInclude(pu => pu.Unit) // Load dữ liệu Unit liên quan
                .Select(o => new ProductDTO(
                    o.ID,
                    o.Name,
                    o.Category.Name,
                    o.Producer.Name,
                    o.ProductUnits.Select(o => new UnitDTO (o.Unit.ID, o.Unit.Name)).ToList(),
                    o.ProductUnits.Select(o => o.UnitPrice).First(),
                    o.Inventories.Select(o => o.Quantity).First(),
                    o.Description
                ))
                .ToList();
        }

        public List<ProductDTO> GetAllDtoByUnit(int unitId, int productId)
        {
            var products = context.Products
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .Include(p => p.ProductUnits)
                .ThenInclude(pu => pu.Unit)
                .Include(p => p.Inventories)
                .AsNoTracking() // 👈 Thêm dòng này cho nhẹ nếu chỉ đọc
                .ToList(); // 👈 Ép ToList() để load về RAM trước

            return products.Select(p =>
            {
                var matchingProductUnit = p.ProductUnits.FirstOrDefault(pu => pu.UnitID == unitId && pu.ProductID == productId);
                var matchingInventory = p.Inventories.FirstOrDefault(i => i.UnitID == unitId && i.ProductID == productId);

                return new ProductDTO(
                    p.ID,
                    p.Name,
                    p.Category?.Name ?? "",
                    p.Producer?.Name ?? "",
                    p.ProductUnits.Select(pu => new UnitDTO(pu.Unit.ID, pu.Unit.Name)).ToList(),
                    matchingProductUnit?.UnitPrice ?? p.ProductUnits.FirstOrDefault()?.UnitPrice ?? 0,
                    matchingInventory?.Quantity ?? p.Inventories.FirstOrDefault()?.Quantity ?? 0,
                    p.Description
                );
            }).ToList();
        }



        public Product getByValue(object value)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
        }
    }
}
