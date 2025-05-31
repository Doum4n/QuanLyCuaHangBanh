using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace QuanLyCuaHangBanh.Services
{
    public class ProductService(IRepositoryProvider repositoryProvider, QLCHB_DBContext context) : IService
    {
        public async Task<IList<ProductDTO>> GetAllProductsAsDto()
        {
            return await repositoryProvider.GetRepository<Product>().GetAllAsDto(o => new ProductDTO(
                    o.ID,
                    o.Name,
                    o.Category.ID,
                    o.Category.Name,
                    o.Producer.ID,
                    o.Producer.Name,
                    o.Manufacturer.ID,
                    o.Manufacturer.Name,
                    o.ProductUnits, // Truyền trực tiếp collection ProductUnits
                    o.Description,
                    o.Image
                    // "Xem chi tiết" được gán cố định trong ProductDTO constructor
            ));
        }

        public void UpdateProductUnitPriceAndQuantity(ProductDTO product, int selectedUnitId)
        {
            var units = product.Units.ToList();
            foreach (var _unit in units)
            {
                _unit.IsSelected = _unit.ID == selectedUnitId;
            }

            var unit = context.ProductUnits
                .AsNoTracking()
                .FirstOrDefault(pu => pu.ProductID == product.ProductId && pu.UnitID == selectedUnitId);

            var inventory = context.Inventories
                .AsNoTracking()
                .FirstOrDefault(inv => inv.ProductUnitID == unit.ID);

            if (unit != null)
                product.UnitPrice = unit.UnitPrice;

            if (inventory != null)
            {
                product.InventoryId = inventory.ID;
                product.Quantity = inventory.Quantity;
            }
            else
            {
                product.InventoryId = 0;
                product.Quantity = 0;
            }
        }

        public DataTable GetProductDataTableForExport()
        {
            DataTable dataTable = new DataTable("Products");
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên sản phẩm", typeof(string));
            dataTable.Columns.Add("Danh mục", typeof(string));
            dataTable.Columns.Add("Hãng sản xuất", typeof(string));
            dataTable.Columns.Add("Nhà cung cấp", typeof(string));
            dataTable.Columns.Add("Hình ảnh", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));
            dataTable.Columns.Add("Số lượng", typeof(int));
            dataTable.Columns.Add("Đơn vị", typeof(string));
            dataTable.Columns.Add("Tỷ lệ chuyển đổi", typeof(decimal));
            dataTable.Columns.Add("Giá bán", typeof(decimal));

            var products = context.Products
                .Include(p => p.ProductUnits)
                    .ThenInclude(pu => pu.Unit)
                .Include(p => p.ProductUnits)
                    .ThenInclude(pu => pu.Inventory)
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .Include(o => o.Manufacturer)
                .ToList();

            foreach (var item in products)
            {
                foreach (var unit in item.ProductUnits)
                {
                    dataTable.Rows.Add(
                        item.ID,
                        item.Name,
                        item.Category?.Name ?? string.Empty,
                        item.Manufacturer?.Name ?? string.Empty,
                        item.Producer?.Name ?? string.Empty,
                        item.Image,
                        item.Description,
                        unit.Inventory?.Quantity ?? 0,
                        unit.Unit?.Name ?? string.Empty,
                        unit.ConversionRate,
                        unit.UnitPrice
                    );
                }
            }
            return dataTable;
        }

        public void ImportProduct(DataRow row)
        {
            string tenSanPham = SafeGet(row, "Tên sản phẩm");
            string danhMuc = SafeGet(row, "Danh mục");
            string nhaSanXuat = SafeGet(row, "Hãng sản xuất");
            string nhaCungCap = SafeGet(row, "Nhà cung cấp");
            string moTa = SafeGet(row, "Mô tả");
            string donVi = SafeGet(row, "Đơn vị");
            string soLuongStr = SafeGet(row, "Số lượng");
            string giaBanStr = SafeGet(row, "Giá bán");
            string image = SafeGet(row, "Hình ảnh");

            int existingCategoryId = context.Categories
                .Where(c => c.Name == danhMuc)
                .Select(c => c.ID)
                .FirstOrDefault();

            int existingSupplierId = context.Suppliers
                .Where(s => s.Name == nhaCungCap)
                .Select(s => s.ID)
                .FirstOrDefault();

            int existingManufacturerId = context.Manufacturers
                .Where(m => m.Name == nhaSanXuat)
                .Select(m => m.ID)
                .FirstOrDefault();

            // 1. Tìm sản phẩm hiện có
            Product product = context.Products
                .FirstOrDefault(p => p.Name == tenSanPham &&
                                     p.CategoryID == existingCategoryId &&
                                     p.ManufacturerID == existingManufacturerId);

            // 2. Nếu sản phẩm chưa tồn tại, tạo mới
            if (product == null)
            {
                product = new Product()
                {
                    Name = tenSanPham,
                    CategoryID = existingCategoryId,
                    ProducerID = existingSupplierId, // Có thể ProducerID là nhà cung cấp
                    BaseUnitID = 1, // Cần xem xét cách xác định BaseUnitID
                    ManufacturerID = existingManufacturerId,
                    Description = moTa,
                    Image = image
                };
                repositoryProvider.GetRepository<Product>().Add(product);
                // Lưu thay đổi để product.ID có giá trị trước khi thêm Product_Unit
                context.SaveChanges();
            }

            // 3. Xử lý đơn vị tính và tồn kho cho sản phẩm (có thể là mới hoặc đã tồn tại)
            int existingUnitId = context.Units
                .Where(u => u.Name == donVi)
                .Select(u => u.ID)
                .FirstOrDefault();

            // Kiểm tra xem Product_Unit cho đơn vị này đã tồn tại chưa
            Product_Unit productUnit = context.ProductUnits
                .FirstOrDefault(pu => pu.ProductID == product.ID && pu.UnitID == existingUnitId);

            if (productUnit == null)
            {
                productUnit = new Product_Unit()
                {
                    ProductID = product.ID,
                    UnitID = existingUnitId,
                    UnitPrice = decimal.TryParse(giaBanStr, out var price) ? price : 0,
                };
                repositoryProvider.GetRepository<Product_Unit>().Add(productUnit);
                context.SaveChanges();
            }
            else
            {
                // Nếu Product_Unit đã tồn tại, bạn có thể cập nhật giá nếu cần
                productUnit.UnitPrice = decimal.TryParse(giaBanStr, out var price) ? price : productUnit.UnitPrice;
                repositoryProvider.GetRepository<Product_Unit>().Update(productUnit);
                context.SaveChanges();
            }


            // Xử lý tồn kho (có thể là mới hoặc cập nhật)
            Inventory inventory = context.Inventories
                .FirstOrDefault(inv => inv.ProductUnitID == productUnit.ID);

            if (inventory == null)
            {
                inventory = new Inventory()
                {
                    ProductUnitID = productUnit.ID,
                    Quantity = int.TryParse(soLuongStr, out var qty) ? qty : 0,
                };
                repositoryProvider.GetRepository<Inventory>().Add(inventory);
            }
            else
            {
                // Cập nhật số lượng nếu Inventory đã tồn tại
                inventory.Quantity = int.TryParse(soLuongStr, out var qty) ? qty : inventory.Quantity;
                repositoryProvider.GetRepository<Inventory>().Update(inventory);
            }

            // Lưu tất cả các thay đổi vào DB một lần hoặc theo từng bước nếu có logic phức tạp hơn
            // Tuy nhiên, nếu dùng SaveChanges() sau mỗi Add/Update thì cần cấu hình phù hợp với DbContext lifespan.
            // Tốt nhất là chỉ gọi SaveChanges() một lần ở cuối phương thức ImportProduct nếu muốn tất cả thay đổi được commit cùng lúc.
            // repositoryProvider.SaveChanges(); // Hoặc context.SaveChanges();
        }

        private string SafeGet(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
                throw new Exception($"Thiếu cột '{columnName}' trong file Excel.");

            return row[columnName]?.ToString() ?? "";
        }

        public void AddNewProduct(Product product, BindingList<Product_UnitDTO> productUnitDTOs)
        {
            repositoryProvider.GetRepository<Product>().Add(product);
            foreach (var productUnitDto in productUnitDTOs)
            {
                productUnitDto.ProductID = product.ID;
                repositoryProvider.GetRepository<Product_Unit>().Add(productUnitDto.ToProductUnit());
                // Không cần tạo Inventory ở đây nếu logic nghiệp vụ cho phép Inventory được tạo riêng hoặc sau này.
                // Nếu Inventory phải được tạo cùng, bạn cần thêm logic vào đây.
            }
        }

        public void UpdateProduct(Product product, BindingList<Product_UnitDTO> productUnitDTOs)
        {
            repositoryProvider.GetRepository<Product>().Update(product);

            foreach (var productUnitDto in productUnitDTOs)
            {
                switch (productUnitDto.status)
                {
                    case DTO.Base.Status.New:
                        productUnitDto.ProductID = product.ID;
                        repositoryProvider.GetRepository<Product_Unit>().Add(productUnitDto.ToProductUnit());
                        break;

                    case DTO.Base.Status.Modified:
                        var existingProductUnit = context.ProductUnits
                            .FirstOrDefault(pu => pu.UnitID == productUnitDto.UnitID && pu.ProductID == productUnitDto.ProductID);
                        if (existingProductUnit != null)
                        {
                            existingProductUnit.UnitPrice = productUnitDto.UnitPrice;
                            existingProductUnit.ConversionRate = productUnitDto.ConversionRate;
                            repositoryProvider.GetRepository<Product_Unit>().Update(existingProductUnit);
                        }
                        break;

                    case DTO.Base.Status.Deleted:
                        var productUnitToDelete = context.ProductUnits
                            .FirstOrDefault(pu => pu.ProductID == productUnitDto.ProductID && pu.UnitID == productUnitDto.UnitID);
                        if (productUnitToDelete != null)
                        {
                            repositoryProvider.GetRepository<Product_Unit>().Delete(productUnitToDelete);
                        }
                        break;
                }
            }
        }

        public void DeleteProduct(ProductDTO selectedProduct)
        {
            // Cần xem xét thứ tự xóa để tránh lỗi ràng buộc khóa ngoại
            // Xóa Inventory trước, sau đó Product_Unit, cuối cùng là Product
            var inventoriesToDelete = context.Inventories
                .Where(inv => inv.ProductUnit.ProductID == selectedProduct.ProductId)
                .ToList();
            foreach (var inv in inventoriesToDelete)
            {
                repositoryProvider.GetRepository<Inventory>().Delete(inv);
            }

            var productUnitsToDelete = context.ProductUnits
                .Where(pu => pu.ProductID == selectedProduct.ProductId)
                .ToList();
            foreach (var pu in productUnitsToDelete)
            {
                repositoryProvider.GetRepository<Product_Unit>().Delete(pu);
            }

            var productToDelete = context.Products.FirstOrDefault(p => p.ID == selectedProduct.ProductId);
            if (productToDelete != null)
            {
                repositoryProvider.GetRepository<Product>().Delete(productToDelete);
            }
        }
    }
}
