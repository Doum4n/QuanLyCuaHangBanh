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
using QuanLyCuaHangBanh.Views.Product;
using QuanLyCuaHangBanh.Uitls;
using System.Data;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.ComponentModel;
using QuanLyCuaHangBanh.Services;

namespace QuanLyCuaHangBanh.Presenters
{
    /// <summary>
    /// Event args cho các sự kiện của ProductView
    /// </summary>
    /// <param name="isEdit">True nếu là chỉnh sửa, False nếu là xem chi tiết</param>
    public class ProductViewEventArgs : EventArgs
    {
        public ProductViewEventArgs(bool isEdit)
        {
            IsEdit = isEdit;
        }   
        public bool IsEdit { get; }
    }

    /// <summary>
    /// Presenter xử lý logic cho màn hình quản lý sản phẩm
    /// </summary>
    public class ProductPresenter : PresenterBase<Product>
    {
        #region Fields
        private IList<ProductDTO> products = new List<ProductDTO>();
        private QLCHB_DBContext context = new QLCHB_DBContext();
        #endregion

        #region Constructor
        /// <summary>
        /// Khởi tạo presenter cho màn hình quản lý sản phẩm
        /// </summary>
        /// <param name="view">View interface để tương tác với UI</param>
        /// <param name="service">Service xử lý business logic cho sản phẩm</param>
        public ProductPresenter(IProductView view, ProductService service) : base(view, service)
        {
            ((IProductView)View).SelectedUnitChanged += OnSelectedUnitChanged;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Xử lý sự kiện khi thay đổi đơn vị trong ComboBox
        /// </summary>
        /// <param name="sender">ComboBox chứa danh sách đơn vị</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Xử lý sự kiện chọn ảnh cho sản phẩm
        /// </summary>
        /// <param name="sender">Form nhập liệu sản phẩm</param>
        /// <param name="e">Event arguments</param>
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
        #endregion

        #region Override Methods
        /// <summary>
        /// Khởi tạo dữ liệu ban đầu cho màn hình
        /// </summary>
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

        /// <summary>
        /// Xuất dữ liệu sản phẩm ra Excel
        /// </summary>
        /// <param name="sender">Nút xuất Excel</param>
        /// <param name="e">Event arguments</param>
        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = ((ProductService)Service).GetProductDataTableForExport();
            ExcelHandler.ExportExcel("Sản phẩm", "Sản phẩm", dataTable);
        }

        /// <summary>
        /// Nhập dữ liệu sản phẩm từ Excel
        /// </summary>
        /// <param name="sender">Nút nhập Excel</param>
        /// <param name="e">Event arguments</param>
        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(async (DataRow row) =>
            {
                ((ProductService)Service).ImportProduct(row);
                await InitializeAsync();
                ShowMessage("Nhập sản phẩm thành công!", "Thông báo", MessageBoxIcon.Information);
            });
        }

        /// <summary>
        /// Chỉnh sửa thông tin sản phẩm
        /// </summary>
        /// <param name="sender">Nút chỉnh sửa</param>
        /// <param name="e">Event arguments chứa thông tin về mode chỉnh sửa</param>
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

        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        /// <param name="sender">Nút thêm mới</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="sender">Nút xóa</param>
        /// <param name="e">Event arguments</param>
        public override async void OnDelete(object? sender, EventArgs e)
        {
            if (this.View.SelectedItem is ProductDTO selectedProduct)
            {
                if (ShowConfirmationDialog($"Bạn có chắc chắn muốn xóa sản phẩm {selectedProduct.ProductName}?", "Xác nhận xóa"))
                {
                    try
                    {
                        ((ProductService)Service).DeleteProduct(selectedProduct);
                        ShowMessage("Xóa sản phẩm thành công!", "Thông báo", MessageBoxIcon.Information);
                        await InitializeAsync();
                    }
                    catch (Exception ex)
                    {
                        ShowMessage($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo từ khóa
        /// </summary>
        /// <param name="sender">Nút tìm kiếm</param>
        /// <param name="e">Event arguments</param>
        public override async void OnSearch(object? sender, EventArgs e)
        {
            string searchValue = View.SearchValue.ToLower();
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                await InitializeAsync();
            }
            else
            {
                if (products != null)
                {
                    var filtered = products
                        .Where(p => p.MatchesSearch(searchValue))
                        .ToList();
                    BindingSource.DataSource = filtered;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không khả dụng để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Hiển thị thông báo cho người dùng
        /// </summary>
        /// <param name="message">Nội dung thông báo</param>
        /// <param name="title">Tiêu đề thông báo</param>
        /// <param name="icon">Icon hiển thị</param>
        private void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Hiển thị hộp thoại xác nhận
        /// </summary>
        /// <param name="message">Nội dung cần xác nhận</param>
        /// <param name="title">Tiêu đề hộp thoại</param>
        /// <returns>True nếu người dùng đồng ý, False nếu không</returns>
        private bool ShowConfirmationDialog(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        #endregion
    }
}