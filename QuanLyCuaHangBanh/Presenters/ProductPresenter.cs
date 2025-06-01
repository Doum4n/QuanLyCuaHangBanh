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
using QuanLyCuaHangBanh.Services; // Thêm namespace của Service

namespace QuanLyCuaHangBanh.Presenters
{
    public class ProductViewEventArgs : EventArgs
    {
        public ProductViewEventArgs(bool isEdit)
        {
            IsEdit = isEdit;
        }   
        public bool IsEdit { get; }
    }
    public class ProductPresenter : PresenterBase<Product>
    {
        private IList<ProductDTO> products = new List<ProductDTO>();
        private QLCHB_DBContext context = new QLCHB_DBContext(); // Khởi tạo DbContext

        public ProductPresenter(IProductView view, ProductService service) : base(view, service)
        {
            ((IProductView)View).SelectedUnitChanged += OnSelectedUnitChanged;
        }

        // Sự kiện khi thay đổi đơn vị trong ComboBox
        private void OnSelectedUnitChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.Tag is ProductDTO product)
            {
                if (comboBox.SelectedValue is int selectedUnitId)
                {
                    ((ProductService)Service).UpdateProductUnitPriceAndQuantity(product, selectedUnitId);
                    BindingSource?.ResetBindings(false);
                }
            }
        }

        public override async Task InitializeAsync()
        {
            try
            {
                products = await ((ProductService)Service).GetAllProductsAsDto();
                BindingSource.DataSource = products;
            }
            catch (Exception ex)
            {
                ShowMessage($"Lỗi khi tải dữ liệu sản phẩm: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
            }
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = ((ProductService)Service).GetProductDataTableForExport();
            ExcelHandler.ExportExcel("Sản phẩm", "Sản phẩm", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(async (DataRow row) =>
            {
                ((ProductService)Service).ImportProduct(row);
                await InitializeAsync();
                ShowMessage("Nhập sản phẩm thành công!", "Thông báo", MessageBoxIcon.Information);
            });
        }

        public override async void OnEdit(object? sender, EventArgs e)
        {
            ProductInputView productInputView = new ProductInputView();
            if(e is ProductViewEventArgs productViewEventArgs)
            {
                if(productViewEventArgs.IsEdit == false){
                    productInputView = new ProductInputView(productDto: (ProductDTO)this.View.SelectedItem, isEdit: false);
                }
            }else
            {
                productInputView = new ProductInputView((ProductDTO)this.View.SelectedItem);
            }
            
            productInputView.SelectImage += SelectImage;
            if (productInputView.ShowDialog() == DialogResult.OK)
            {
                if (productInputView.Tag is Product product)
                {
                    product.ID = ((ProductDTO)this.View.SelectedItem).ProductId;
                    ((ProductService)Service).UpdateProduct(product, productInputView.Product_UnitDTOs);

                    ShowMessage("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxIcon.Information);
                    await InitializeAsync();
                }
            }
        }

        public override async void OnAddNew(object? sender, EventArgs e)
        {
            ProductInputView productInputView = new ProductInputView();
            productInputView.SelectImage += SelectImage;
            if (productInputView.ShowDialog() == DialogResult.OK)
            {
                if (productInputView.Tag is Product product)
                {
                    ((ProductService)Service).AddNewProduct(product, productInputView.Product_UnitDTOs);
                    ShowMessage("Thêm sản phẩm thành công!", "Thông báo", MessageBoxIcon.Information);
                    await InitializeAsync();
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
                if (sender is ProductInputView productInputView)
                {
                    productInputView.SetImage(imagePath);
                }
            }
        }

        public override async void OnDelete(object? sender, EventArgs e)
        {
            if (this.View.SelectedItem is ProductDTO selectedProduct)
            {
                ((ProductService)Service).DeleteProduct(selectedProduct);
                ShowMessage("Xóa sản phẩm thành công!", "Thông báo", MessageBoxIcon.Information);
                await InitializeAsync();
            }
        }

        public override async void OnSearch(object? sender, EventArgs e)
        {
            string searchValue = this.View.SearchValue?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(searchValue))
            {
                await InitializeAsync();
            }
            else
            {
                if (products != null)
                {
                    var filteredItems = products
                        .Where(item => item.MatchesSearch(searchValue))
                        .ToList();

                    BindingSource.DataSource = filteredItems;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không khả dụng để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}