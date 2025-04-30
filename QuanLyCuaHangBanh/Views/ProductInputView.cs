using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Views
{
    public partial class ProductInputView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();

        private ProductDTO? _productDto;

        private string? _imagePath;

        public EventHandler ShowUnitInput;
        public EventHandler ShowCategoryInput;
        public EventHandler ShowProducerInput;
        public EventHandler SelectImage;

        public ProductInputView(ProductDTO? productDto = null)
        {
            InitializeComponent();
            _productDto = productDto;
        }

        private void ProductInputView_Load(object sender, EventArgs e)
        {
            cbb_Categories.DataSource = context.Categories.AsNoTracking().ToList();
            cbb_Categories.DisplayMember = "Name";
            cbb_Categories.ValueMember = "ID";

            cbb_Producers.DataSource = context.Producers.AsNoTracking().ToList();
            cbb_Producers.DisplayMember = "Name";
            cbb_Producers.ValueMember = "ID";

            cbb_Units.DataSource = context.Units.AsNoTracking().ToList();
            cbb_Units.DisplayMember = "Name";
            cbb_Units.ValueMember = "ID";

            if (_productDto != null)
            {
                foreach (var unit in _productDto.Unit)
                {
                    if (unit.IsSelected)
                    {
                        cbb_Units.SelectedValue = unit.ID;
                        break;
                    }
                }

                tb_ProductName.Text = _productDto.ProductName;
                mttb_Description.Text = _productDto.Description;
                cbb_Categories.SelectedText = _productDto.CategoryName;
                cbb_Producers.SelectedValue = _productDto.ProducerId;
                nmr_BaseUnitPrice.Value = _productDto.Price;

                pictureBox.ImageLocation = _productDto.ImagePath;
                //_imagePath = _productDto.Image;

                nmr_Quantity.Value = _productDto.Quantity;

                dgv_ProductUnitList.DataSource = context.ProductUnits  
                    .Where(o => o.ProductID == _productDto.ProductId)
                    .Select(o => new Product_UnitDTO(
                        o.ID,
                        o.Unit.Name,
                        o.ConversionRate,
                        o.UnitPrice,
                        o.Inventory.Quantity
                    )).ToList();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Name = tb_ProductName.Text,
                Description = mttb_Description.Text,
                CategoryID = (int)cbb_Categories.SelectedValue,
                ProducerID = (int)cbb_Producers.SelectedValue,
                BaseUnitID = (int)cbb_Units.SelectedValue,
                Image = pictureBox.ImageLocation
            };

            Product_Unit productUnit = new Product_Unit
            {
                UnitID = (int)cbb_Units.SelectedValue,
                UnitPrice = nmr_BaseUnitPrice.Value,
            };

            Inventory inventory = new Inventory
            {
                ProductID = product.ID,
                Quantity = (int)nmr_Quantity.Value,
                Note = "Khởi tạo sản phẩm",
                UnitID = (int)cbb_Units.SelectedValue,
            };

            if (_productDto != null)
            {
                //product.Image = _imagePath;
                // Gán ID cho Product_Unit và Inventory
                foreach (var unit in _productDto.Unit)
                {
                    if (unit.IsSelected)
                    {
                        productUnit.ID = unit.ProductUnitId;
                        break;
                    }
                }
                inventory.ID = _productDto?.InventoryId ?? 0;
                inventory.Note = "";

                // Cập ProductId cho Product_Unit và Inventory
                productUnit.ProductID = _productDto.ProductId;
                productUnit.InventoryID = inventory.ID;
                inventory.ProductID = _productDto.ProductId;
            }

            this.Tag = (product, productUnit, inventory);

            this.DialogResult = DialogResult.OK;
        }

        private void llb_AddUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowUnitInput?.Invoke(this, EventArgs.Empty);
        }

        private void llb_AddCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCategoryInput?.Invoke(this, EventArgs.Empty);
        }

        private void llb_AddProducer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowProducerInput?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            SelectImage?.Invoke(this, EventArgs.Empty);
        }

        internal void SetImage(string imagePath)
        {
            // Kiểm tra nếu đường dẫn hình ảnh hợp lệ
            if (File.Exists(imagePath))
            {
                // Cập nhật hình ảnh cho pictureBox
                pictureBox.ImageLocation = imagePath;
            }
            else
            {
                MessageBox.Show("Không tìm thấy hình ảnh.");
            }
        }
    }
}
