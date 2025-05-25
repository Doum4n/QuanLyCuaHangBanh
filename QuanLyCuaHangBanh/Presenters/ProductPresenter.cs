using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using QuanLyCuaHangBanh.Helpers;
using QuanLyCuaHangBanh.Views.Product;
using QuanLyCuaHangBanh.Uitls;
using System.Data;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.ComponentModel;

namespace QuanLyCuaHangBanh.Presenters
{
    public class ProductPresenter : PresenterBase<Product>
    {
        private QLCHB_DBContext context;

        private IList<ProductDTO> products = new List<ProductDTO>();

        public ProductPresenter(IProductView view, IRepositoryProvider repository, QLCHB_DBContext context) : base(view, repository)
        {
            ((IProductView)View).SelectedUnitChanged += OnSelectedUnitChanged;

            this.context = context;
        }

        // Sự kiện khi thay đổi đơn vị trong ComboBox
        private void OnSelectedUnitChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.Tag is ProductDTO product)
            {
                if (comboBox.SelectedValue is int selectedUnitId)
                {
                    var units = product.Unit.ToList();

                    foreach (var _unit in units)
                    {
                        // Gán true cho đơn vị được chọn, false cho đơn vị khác
                        _unit.IsSelected = _unit.ID == selectedUnitId;
                    }

                    // Tìm giá mới theo đơn vị
                    var unit = context.ProductUnits
                        .AsNoTracking()
                        .FirstOrDefault(pu => pu.ProductID == product.ProductId && pu.UnitID == selectedUnitId);

                    var inventory = context.Inventories
                        .AsNoTracking()
                        .FirstOrDefault(inv => inv.ProductUnitID == unit.ID);

                    // Cập nhật giá và số lượng sản phẩm
                    if (unit != null)
                        product.Price = unit.UnitPrice;

                    if (inventory != null)
                    {
                        product.InventoryId = inventory.ID;
                        product.Quantity = inventory.Quantity;
                    }

                    BindingSource?.ResetBindings(false); // Cập nhật lại tất cả dữ liệu trong DataGridView
                }
            }
        }

        public override void LoadData()
        {
            try
            {
                products = Provider.GetRepository<Product>().GetAllAsDto(o => new ProductDTO(
                    o.ID,
                    o.Name,
                    o.Category?.ID ?? 0,
                    o.Category?.Name ?? "",
                    o.Producer?.ID ?? 0,
                    o.Producer?.Name ?? "",
                    o.ProductUnits
                        .Where(pu => pu.Unit != null)
                        .Select(pu => new UnitDTO(pu.Unit.ID, pu.Unit.Name, pu.ID, false)).ToList(),
                    o.ProductUnits.Select(pu => pu.UnitPrice).FirstOrDefault(),
                    o.ProductUnits.Select(o => o.Inventory.ID).FirstOrDefault(),
                    o.ProductUnits.Select(o => o.Inventory.Quantity).FirstOrDefault(),
                    o.ProductUnits.Sum(pu => pu.Inventory.Quantity),
                    o.Description,
                    o.Image
                ));

                BindingSource.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message);
            }
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = new DataTable("Products");
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên sản phẩm", typeof(string));
            dataTable.Columns.Add("Danh mục", typeof(string));
            dataTable.Columns.Add("Nhà sản xuất", typeof(string));
            dataTable.Columns.Add("Hình ảnh", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));
            dataTable.Columns.Add("Số lượng", typeof(int));
            dataTable.Columns.Add("Đơn vị", typeof(string));
            dataTable.Columns.Add("Tỷ lệ chuyển đổi", typeof(decimal));
            dataTable.Columns.Add("Giá bán", typeof(decimal));

            var productss = context.Products
                .Include(p => p.ProductUnits)
                .ThenInclude(pu => pu.Unit)
                .Include(p => p.ProductUnits)
                .ThenInclude(pu => pu.Inventory)
                .Include(p => p.Category)
                .Include(p => p.Producer)
                .ToList();

            foreach (var item in productss)
            {
                foreach (var unit in item.ProductUnits)
                {
                    dataTable.Rows.Add(
                        item.ID,
                        item.Name,
                        item.Category.Name,
                        item.Producer.Name,
                        item.Image,
                        item.Description,
                        unit.Inventory.Quantity,
                        unit.Unit.Name,
                        unit.ConversionRate,
                        unit.UnitPrice
                    );
                }     
            }

            ExcelHandler.ExportExcel("Sản phẩm", "Sản phẩm", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel((DataRow row) =>
            {
                string tenSanPham = SafeGet(row, "Tên sản phẩm");
                string danhMuc = SafeGet(row, "Danh mục");
                string nhaSanXuat = SafeGet(row, "Nhà sản xuất");
                string moTa = SafeGet(row, "Mô tả");
                string donVi = SafeGet(row, "Đơn vị");
                string soLuongStr = SafeGet(row, "Số lượng");
                string giaBanStr = SafeGet(row, "Giá bán");

                int existingProductId = context.Products
                    .Where(p => p.Name == tenSanPham)
                    .Select(p => p.ID)
                    .FirstOrDefault();

                int existingCategoryId = context.Categories
                    .Where(c => c.Name == danhMuc)
                    .Select(c => c.ID)
                    .FirstOrDefault();

                int existingSupplierId = context.Suppliers
                    .Where(s => s.Name == nhaSanXuat)
                    .Select(s => s.ID)
                    .FirstOrDefault();

                Product product = new Product()
                //if (existingProductId != 0)
                //{
                    //product = new Product()
                    {
                        Name = tenSanPham,
                        CategoryID = existingCategoryId,
                        ProducerID = existingSupplierId,
                        BaseUnitID = 1,
                        Description = moTa,
                    };
                //}

                int existingUnitId = context.Units
                    .Where(u => u.Name == donVi)
                    .Select(u => u.ID)
                    .FirstOrDefault();

                int existingProductUnitId = context.ProductUnits
                    .Where(pu => pu.ProductID == product.ID && pu.Unit.Name == donVi)
                    .Select(pu => pu.ID)
                    .FirstOrDefault();

                Inventory inventory = new Inventory();
                Product_Unit productUnit = new Product_Unit();
                //if (existingProductUnitId != 0)
                //{
                    inventory = new Inventory()
                    {
                        Quantity = int.TryParse(soLuongStr, out var qty) ? qty : 0,
                    };

                    productUnit = new Product_Unit()
                    {
                        UnitID = existingUnitId,
                        UnitPrice = decimal.TryParse(giaBanStr, out var price) ? price : 0,
                    };
                //}


                Provider.GetRepository<Product>().Add(product);

                productUnit.ProductID = product.ID;
                Provider.GetRepository<Product_Unit>().Add(productUnit);

                inventory.ProductUnitID = productUnit.ID;
                Provider.GetRepository<Inventory>().Add(inventory);

                //MessageBox.Show(product.ToString());
                //MessageBox.Show(productUnit.ToString());
                //MessageBox.Show(inventory.ToString());

                LoadData();

                this.View.Message = "Nhập dữ liệu thành công!";
            });

        }

        private string SafeGet(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
                throw new Exception($"Thiếu cột '{columnName}' trong file Excel.");

            return row[columnName]?.ToString() ?? "";
        }


        public override void OnEdit(object? sender, EventArgs e)
        {
            ProductInputView productInputView = new ProductInputView((ProductDTO)this.View.SelectedItem);
            productInputView.SelectImage += SelectImage;
            if (productInputView.ShowDialog() == DialogResult.OK)
            {
                if (productInputView.Tag is Product product)
                {
                    product.ID = ((ProductDTO)this.View.SelectedItem).ProductId;

                    Provider.GetRepository<Product>().Update(product);

                    foreach (var productUnit in productInputView.Product_UnitDTOs)
                    {
                        productUnit.ProductID = product.ID;
                        Provider.GetRepository<Product_Unit>().Add(productUnit.ToProductUnit());
                        View.Message = "Cập nhật sản phẩm thành công";

                        //Inventory inventory = new Inventory();
                        //inventory.ProductUnitID = addedProductUnit.ID;
                        //inventory.Quantity = productUnit.Quantity;
                        //Provider.GetRepository<Inventory>().Add(inventory);

                    }
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            ProductInputView productInputView = new ProductInputView();
            productInputView.SelectImage += SelectImage;
            if (productInputView.ShowDialog() == DialogResult.OK)
            {
                if (productInputView.Tag is (Product product))
                {
                    Provider.GetRepository<Product>().Add(product);

                    foreach (var productUnit in productInputView.Product_UnitDTOs)
                    {
                        productUnit.ProductID = product.ID;
                        Provider.GetRepository<Product_Unit>().Add(productUnit.ToProductUnit());
                        View.Message = "Thêm sản phẩm thành công";

                        //Inventory inventory = new Inventory();
                        //inventory.ProductUnitID = addedProductUnit.ID;
                        //inventory.Quantity = productUnit.Quantity;
                        //Provider.GetRepository<Inventory>().Add(inventory);

                    }

                    this.View.Message = "Thêm sản phẩm thành công";
                    LoadData();
                }
            }
        }

        private void SelectImage(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Truyền đường dẫn hình ảnh vào ProductInputView
                if (sender is ProductInputView productInputView)
                {
                    productInputView.SetImage(imagePath); // Gọi phương thức SetImage để cập nhật hình ảnh
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (this.View.SelectedItem is ProductDTO selectedProduct)
            {
                ((ProductRepo)Provider.GetRepository<Product>()).DeleteById(selectedProduct.ProductId);
                ((ProductUnitRepo)Provider.GetRepository<Product_Unit>()).DeleteById(selectedProduct.ProductId);
                ((InventoryRepo)Provider.GetRepository<Inventory>()).DeleteById(selectedProduct.InventoryId);
                this.View.Message = "Xóa sản phẩm thành công!";
                LoadData();
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}