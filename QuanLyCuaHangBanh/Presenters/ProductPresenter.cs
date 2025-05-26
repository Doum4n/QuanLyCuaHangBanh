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
                    BindingSource?.ResetBindings(false); // Cập nhật lại tất cả dữ liệu trong DataGridView
                }
            }
        }

        public override void LoadData()
        {
            try
            {
                products = ((ProductService)Service).GetAllProductsAsDto();
                BindingSource.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message);
            }
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = ((ProductService)Service).GetProductDataTableForExport();
            ExcelHandler.ExportExcel("Sản phẩm", "Sản phẩm", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel((DataRow row) =>
            {
                ((ProductService)Service).ImportProduct(row);
                LoadData();
                this.View.Message = "Nhập dữ liệu thành công!";
            });
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
                    ((ProductService)Service).UpdateProduct(product, productInputView.Product_UnitDTOs);

                    View.Message = "Cập nhật sản phẩm thành công";
                    LoadData();
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            ProductInputView productInputView = new ProductInputView();
            productInputView.SelectImage += SelectImage;
            if (productInputView.ShowDialog() == DialogResult.OK)
            {
                if (productInputView.Tag is Product product)
                {
                    ((ProductService)Service).AddNewProduct(product, productInputView.Product_UnitDTOs);
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
                if (sender is ProductInputView productInputView)
                {
                    productInputView.SetImage(imagePath);
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (this.View.SelectedItem is ProductDTO selectedProduct)
            {
                ((ProductService)Service).DeleteProduct(selectedProduct);
                this.View.Message = "Xóa sản phẩm thành công!";
                LoadData();
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            string searchValue = this.View.SearchValue?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(searchValue))
            {
                LoadData();
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