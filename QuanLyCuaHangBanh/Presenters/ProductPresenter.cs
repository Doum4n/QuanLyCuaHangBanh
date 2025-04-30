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

namespace QuanLyCuaHangBanh.Presenters
{
    public class ProductPresenter : PresenterBase<Product>
    {
        private QLCHB_DBContext context;

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
                        .FirstOrDefault(inv => inv.ProductID == product.ProductId && inv.UnitID == selectedUnitId);

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
            BindingSource.DataSource = null;
            BindingSource.DataSource = Provider.GetRepository<Product>().GetAllAsDto(o => new ProductDTO(
                    o.ID,
                    o.Name,
                    o.Category.ID,
                    o.Category?.Name ?? "",
                    o.Producer.ID,
                    o.Producer?.Name ?? "",
                    o.ProductUnits.Select(pu => new UnitDTO(pu.Unit.ID, pu.Unit.Name, pu.ID, false)).ToList(),
                    o.ProductUnits.Select(pu => pu.UnitPrice).FirstOrDefault(),
                    o.Inventories.Where(i => i.UnitID == o.BaseUnitID && i.ProductID == o.ID).Select(i => i.ID).FirstOrDefault(),
                    o.Inventories.Where(i => i.UnitID == o.BaseUnitID && i.ProductID == o.ID).Select(i => i.Quantity).FirstOrDefault(),
                    o.Description,
                    o.Image
                )
            );
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            ProductInputView productInputView = new ProductInputView((ProductDTO)this.View.SelectedItem);
            productInputView.SelectImage += SelectImage;
            if (productInputView.ShowDialog() == DialogResult.OK)
            {
                if (productInputView.Tag is (Product product, Product_Unit productUnit, Inventory inventory))
                {
                    product.ID = ((ProductDTO)this.View.SelectedItem).ProductId;

                    Provider.GetRepository<Product>().Update(product);
                    Provider.GetRepository<Product_Unit>().Update(productUnit);
                    Provider.GetRepository<Inventory>().Update(inventory);

                    this.View.Message = "Cập nhật sản phẩm thành công!";
                    LoadData();
                    BindingSource?.ResetBindings(false);
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            ProductInputView productInputView = new ProductInputView();
            productInputView.SelectImage += SelectImage;
            if (productInputView.ShowDialog() == DialogResult.OK)
            {
                if (productInputView.Tag is (Product product, Product_Unit productUnit, Inventory inventory))
                {
                    // Thêm sản phẩm vào bảng Product
                    Provider.GetRepository<Product>().Add(product);

                    // Thêm thông tin vào bảng Inventory
                    inventory.ProductID = product.ID;
                    inventory.UnitID = product.BaseUnitID;
                    Provider.GetRepository<Inventory>().Add(inventory);

                    // Lấy ID của sản phẩm vừa thêm
                    productUnit.ProductID = product.ID;
                    productUnit.UnitID = product.BaseUnitID;
                    productUnit.InventoryID = inventory.ID;
                    Provider.GetRepository<Product_Unit>().Add(productUnit);

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