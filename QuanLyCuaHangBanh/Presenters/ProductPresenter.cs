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
        private QLCHB_DBContext context = new QLCHB_DBContext();

        public ProductPresenter(IProductView view, IRepository<Product> repository) : base(view, repository)
        {
            ((IProductView)View).SelectedUnitChanged += OnSelectedUnitChanged;
        }

        private void OnSelectedUnitChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.Tag is ProductDTO product)
            {
                if (comboBox.SelectedValue is int selectedUnitId)
                {
                    product.SelectedUnitId = selectedUnitId;

                    // Tìm giá mới theo đơn vị
                    var unit = context.ProductUnits
                        .AsNoTracking()
                        .FirstOrDefault(pu => pu.ProductID == product.ID && pu.UnitID == selectedUnitId);

                    var inventory = context.Inventories
                        .AsNoTracking()
                        .FirstOrDefault(inv => inv.ProductID == product.ID && inv.UnitID == selectedUnitId);

                    if (unit != null)
                        product.Price = unit.UnitPrice;

                    if (inventory != null)
                        product.Quantity = inventory.Quantity;

                    BindingSource?.ResetBindings(false); // Cập nhật lại tất cả dữ liệu trong DataGridView
                }
            }
        }

        public override void LoadData()
        {
            BindingSource.DataSource = Repository.GetAllAsDto(o => new ProductDTO(
                    o.ID,
                    o.Name,
                    o.Category?.Name ?? "",
                    o.Producer?.Name ?? "",
                    o.ProductUnits.Select(pu => new UnitDTO(pu.Unit.ID, pu.Unit.Name)).ToList(),
                    o.ProductUnits.Select(pu => pu.UnitPrice).FirstOrDefault(),
                    o.Inventories.Select(i => i.Quantity).FirstOrDefault(),
                    o.Description,
                    ImageHelper.LoadImageFromUrl(o.Image)
                )
            );
        }




        public override void OnEdit(object? sender, EventArgs e)
        {
            ProductInputView productInputView = new ProductInputView((ProductDTO)this.View.SelectedItem);
            productInputView.SelectImage += SelectImage;
            if (productInputView.ShowDialog() == DialogResult.OK)
            {
                if (productInputView.Tag is (Product product, Product_Unit productUnit))
                {
                    var cloudinary = CloudinaryConfig.GetCloudinaryClient();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(product.Image)  // Đường dẫn tới hình ảnh bạn muốn tải lên
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);

                    product.ID = ((ProductDTO)this.View.SelectedItem).ID;
                    product.Image = uploadResult.SecureUri.ToString();

                    Repository.Update(product);

                    productUnit.ProductID = product.ID;
                    //productUnit.ID = (int)((ProductRepo)Repository).GetProductUnitID(productUnit.ProductID, product.BaseUnitID);

                    ((ProductRepo)Repository).UpdateProductUnit(productUnit);
                    this.View.Message = "Thêm sản phẩm thành công";
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
                if (productInputView.Tag is (Product producer, Product_Unit productUnit))
                {
                    var cloudinary = CloudinaryConfig.GetCloudinaryClient();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(producer.Image)  // Đường dẫn tới hình ảnh bạn muốn tải lên
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);

                    producer.Image = uploadResult.SecureUri.ToString();

                    Repository.Add(producer);

                    productUnit.ProductID = producer.ID;

                    ((ProductRepo)Repository).AddProductUnit(productUnit);
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
                ((ProductRepo)Repository).DeleteById(selectedProduct.ID);
                LoadData();
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}