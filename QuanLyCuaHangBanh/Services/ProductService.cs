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
    /// <summary>
    /// Service xử lý các thao tác liên quan đến sản phẩm
    /// </summary>
    public class ProductService : IService
    {
        #region Fields
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly QLCHB_DBContext _context;
        #endregion

        #region Constructor
        /// <summary>
        /// Khởi tạo service xử lý sản phẩm
        /// </summary>
        /// <param name="repositoryProvider">Provider cung cấp các repository</param>
        /// <param name="context">Database context</param>
        public ProductService(IRepositoryProvider repositoryProvider, QLCHB_DBContext context)
        {
            _repositoryProvider = repositoryProvider;
            _context = context;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Lấy danh sách tất cả sản phẩm dưới dạng DTO
        /// </summary>
        /// <returns>Danh sách ProductDTO</returns>
        public async Task<IList<ProductDTO>> GetAllProductsAsDto()
        {
            return await _repositoryProvider.GetRepository<Product>().GetAllAsDto(o => new ProductDTO(
                    o.ID,
                    o.Name,
                    o.Category.ID,
                    o.Category.Name,
                    o.Producer.ID,
                    o.Producer.Name,
                    o.Manufacturer!.ID,
                    o.Manufacturer.Name,
                    o.ProductUnits,
                    o.Description,
                    o.Image ?? string.Empty
            ){
                TotalQuantity = o.ProductUnits.Sum(pu => pu.Inventory!.Quantity)
            });
        }

        /// <summary>
        /// Cập nhật giá và số lượng tồn kho của sản phẩm theo đơn vị được chọn
        /// </summary>
        /// <param name="product">Sản phẩm cần cập nhật</param>
        /// <param name="selectedUnitId">ID của đơn vị được chọn</param>
        public void UpdateProductUnitPriceAndQuantity(ProductDTO product, int selectedUnitId)
        {
            var units = product.Units.ToList();
            foreach (var _unit in units)
            {
                _unit.IsSelected = _unit.ID == selectedUnitId;
            }

            var unit = _context.ProductUnits
                .AsNoTracking()
                .FirstOrDefault(pu => pu.ProductID == product.ProductId && pu.UnitID == selectedUnitId);

            var inventory = _context.Inventories
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

        /// <summary>
        /// Tạo DataTable chứa dữ liệu sản phẩm để xuất Excel
        /// </summary>
        /// <returns>DataTable chứa thông tin sản phẩm</returns>
        public DataTable GetProductDataTableForExport()
        {
            DataTable dataTable = new DataTable("Products");
            InitializeDataTableColumns(dataTable);

            var products = _context.Products
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

        /// <summary>
        /// Nhập sản phẩm từ dữ liệu Excel
        /// </summary>
        /// <param name="row">Dòng dữ liệu từ Excel</param>
        public void ImportProduct(DataRow row)
        {
            // Đọc dữ liệu từ Excel
            string tenSanPham = SafeGet(row, "Tên sản phẩm");
            string danhMuc = SafeGet(row, "Danh mục");
            string nhaSanXuat = SafeGet(row, "Hãng sản xuất");
            string nhaCungCap = SafeGet(row, "Nhà cung cấp");
            string moTa = SafeGet(row, "Mô tả");
            string donVi = SafeGet(row, "Đơn vị");
            string soLuongStr = SafeGet(row, "Số lượng");
            string giaBanStr = SafeGet(row, "Giá bán");
            string image = SafeGet(row, "Hình ảnh");
            string conversionRateStr = SafeGet(row, "Tỷ lệ quy đổi");

            // Validate conversion rate
            if (!decimal.TryParse(conversionRateStr, out decimal conversionRate) || conversionRate <= 0)
            {
                MessageBox.Show("Tỷ lệ quy đổi không hợp lệ");
                return;
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.ChangeTracker.Clear();

                    // Lấy ID của các thực thể liên quan
                    int existingCategoryId = GetExistingCategoryId(danhMuc);
                    int existingSupplierId = GetExistingSupplierId(nhaCungCap);
                    int existingManufacturerId = GetExistingManufacturerId(nhaSanXuat);

                    // Lấy hoặc tạo đơn vị
                    var unit = _context.Units.FirstOrDefault(u => u.Name == donVi);
                    if (unit == null)
                    {
                        unit = new Unit { Name = donVi };
                        _context.Units.Add(unit);
                        _context.SaveChanges();
                        _context.ChangeTracker.Clear();
                    }

                    // Tìm sản phẩm hiện có
                    var existingProduct = _context.Products
                        .Include(p => p.ProductUnits)
                        .FirstOrDefault(p => p.Name == tenSanPham &&
                                           p.CategoryID == existingCategoryId &&
                                           p.ManufacturerID == existingManufacturerId);

                    Product product;
                    if (existingProduct == null)
                    {
                        // Tạo sản phẩm mới
                        product = new Product
                        {
                            Name = tenSanPham,
                            CategoryID = existingCategoryId,
                            ProducerID = existingSupplierId,
                            ManufacturerID = existingManufacturerId,
                            Description = moTa,
                            Image = image,
                            BaseUnitID = unit.ID
                        };
                        _context.Products.Add(product);
                    }
                    else
                    {
                        product = existingProduct;
                        if (conversionRate == 1 && !product.ProductUnits.Any(pu => pu.ConversionRate == 1))
                        {
                            product.BaseUnitID = unit.ID;
                        }
                    }
                    _context.SaveChanges();
                    _context.ChangeTracker.Clear();

                    // Xử lý đơn vị sản phẩm
                    var existingProductUnit = _context.ProductUnits
                        .Include(pu => pu.Inventory)
                        .FirstOrDefault(pu => pu.ProductID == product.ID && pu.UnitID == unit.ID);

                    Product_Unit productUnit;
                    if (existingProductUnit == null)
                    {
                        // Tạo mới đơn vị sản phẩm
                        productUnit = new Product_Unit
                        {
                            ProductID = product.ID,
                            UnitID = unit.ID,
                            ConversionRate = conversionRate,
                            UnitPrice = decimal.TryParse(giaBanStr, out decimal giaBan) ? giaBan : 0
                        };
                        _context.ProductUnits.Add(productUnit);
                    }
                    else
                    {
                        productUnit = existingProductUnit;
                        productUnit.ConversionRate = conversionRate;
                        productUnit.UnitPrice = decimal.TryParse(giaBanStr, out decimal giaBan) ? giaBan : productUnit.UnitPrice;
                    }
                    _context.SaveChanges();
                    _context.ChangeTracker.Clear();

                    // Xử lý tồn kho
                    var inventory = _context.Inventories
                        .FirstOrDefault(i => i.ProductUnitID == productUnit.ID);

                    if (inventory == null)
                    {
                        // Tạo mới tồn kho
                        inventory = new Inventory
                        {
                            ProductUnitID = productUnit.ID,
                            Quantity = int.TryParse(soLuongStr, out int soLuong) ? soLuong : 0
                        };
                        _context.Inventories.Add(inventory);
                    }
                    else
                    {
                        inventory.Quantity = int.TryParse(soLuongStr, out int soLuong) ? soLuong : inventory.Quantity;
                    }
                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Lỗi khi nhập sản phẩm: {ex.Message}");
                    throw; // Re-throw to see the full error in debug
                }
            }
        }

        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        /// <param name="product">Thông tin sản phẩm mới</param>
        /// <param name="productUnitDTOs">Danh sách đơn vị của sản phẩm</param>
        public void AddNewProduct(Product product, BindingList<Product_UnitDTO> productUnitDTOs)
        {
            _repositoryProvider.GetRepository<Product>().Add(product);
            foreach (var productUnitDto in productUnitDTOs)
            {
                productUnitDto.ID = 0; // ID = 0 để tạo mới
                productUnitDto.ProductID = product.ID;
                _repositoryProvider.GetRepository<Product_Unit>().Add(productUnitDto.ToProductUnit());
            }
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        /// <param name="product">Thông tin sản phẩm cần cập nhật</param>
        /// <param name="productUnitDTOs">Danh sách đơn vị của sản phẩm</param>
        public void UpdateProduct(Product product, BindingList<Product_UnitDTO> productUnitDTOs)
        {
            _repositoryProvider.GetRepository<Product>().Update(product);

            foreach (var productUnitDto in productUnitDTOs)
            {
                switch (productUnitDto.status)
                {
                    case DTO.Base.Status.New:
                        productUnitDto.ID = 0;
                        productUnitDto.ProductID = product.ID;
                        _repositoryProvider.GetRepository<Product_Unit>().Add(productUnitDto.ToProductUnit());
                        break;
                        
                    case DTO.Base.Status.Modified:
                        productUnitDto.ProductID = product.ID;
                        _repositoryProvider.GetRepository<Product_Unit>().Update(productUnitDto.ToProductUnit());
                        break;

                    case DTO.Base.Status.Deleted:
                        var productUnitToDelete = _repositoryProvider.GetRepository<Product_Unit>().GetAll().Result.
                            FirstOrDefault(pu => pu.ProductID == productUnitDto.ProductID && pu.UnitID == productUnitDto.UnitID);
                        if (productUnitToDelete != null)
                            _repositoryProvider.GetRepository<Product_Unit>().Delete(productUnitToDelete);
                        break;
                }
            }
        }

        /// <summary>
        /// Xóa sản phẩm khỏi database
        /// </summary>
        /// <param name="selectedProduct">DTO chứa thông tin sản phẩm cần xóa</param>
        public void DeleteProduct(ProductDTO selectedProduct)
        {
            var product = _context.Products.Find(selectedProduct.ProductId);
            if (product != null)
            {
                _repositoryProvider.GetRepository<Product>().Delete(product);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Khởi tạo cấu trúc cột cho DataTable xuất Excel
        /// </summary>
        /// <param name="dataTable">DataTable cần khởi tạo cột</param>
        private void InitializeDataTableColumns(DataTable dataTable)
        {
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên sản phẩm", typeof(string));
            dataTable.Columns.Add("Danh mục", typeof(string));
            dataTable.Columns.Add("Hãng sản xuất", typeof(string));
            dataTable.Columns.Add("Nhà cung cấp", typeof(string));
            dataTable.Columns.Add("Hình ảnh", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));
            dataTable.Columns.Add("Số lượng", typeof(int));
            dataTable.Columns.Add("Đơn vị", typeof(string));
            dataTable.Columns.Add("Tỷ lệ quy đổi", typeof(decimal));
            dataTable.Columns.Add("Giá bán", typeof(decimal));
        }

        /// <summary>
        /// Lấy giá trị an toàn từ DataRow
        /// </summary>
        /// <param name="row">DataRow chứa dữ liệu</param>
        /// <param name="columnName">Tên cột cần lấy giá trị</param>
        /// <returns>Giá trị dạng string, trả về rỗng nếu null</returns>
        private string SafeGet(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName) && !row.IsNull(columnName))
            {
                return row[columnName].ToString() ?? string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// Lấy ID của danh mục từ tên
        /// </summary>
        /// <param name="categoryName">Tên danh mục</param>
        /// <returns>ID của danh mục, tạo mới nếu chưa tồn tại</returns>
        private int GetExistingCategoryId(string categoryName)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (category == null)
            {
                category = new Category(categoryName, "");
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            return category.ID;
        }

        /// <summary>
        /// Lấy ID của nhà cung cấp từ tên
        /// </summary>
        /// <param name="supplierName">Tên nhà cung cấp</param>
        /// <returns>ID của nhà cung cấp, tạo mới nếu chưa tồn tại</returns>
        private int GetExistingSupplierId(string supplierName)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Name == supplierName);
            if (supplier == null)
            {
                supplier = new Supplier { Name = supplierName };
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
            return supplier.ID;
        }

        /// <summary>
        /// Lấy ID của nhà sản xuất từ tên
        /// </summary>
        /// <param name="manufacturerName">Tên nhà sản xuất</param>
        /// <returns>ID của nhà sản xuất, tạo mới nếu chưa tồn tại</returns>
        private int GetExistingManufacturerId(string manufacturerName)
        {
            var manufacturer = _context.Manufacturers.FirstOrDefault(m => m.Name == manufacturerName);
            if (manufacturer == null)
            {
                manufacturer = new Manufacturer { Name = manufacturerName };
                _context.Manufacturers.Add(manufacturer);
                _context.SaveChanges();
            }
            return manufacturer.ID;
        }
        #endregion
    }
}
