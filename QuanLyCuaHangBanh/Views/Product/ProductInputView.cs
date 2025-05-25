using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using System.ComponentModel;

namespace QuanLyCuaHangBanh.Views
{
    public record ProductUnit_Inventory(
        int Product_UnitID,
        int InventoryID
    );
    public partial class ProductInputView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();

        private ProductDTO? _productDto;

        private string? _imagePath;

        public EventHandler ShowUnitInput;
        public EventHandler ShowCategoryInput;
        public EventHandler ShowProducerInput;
        public EventHandler SelectImage;

        private Dictionary<String, String> keyValuePairs = new Dictionary<String, String>();

        public BindingList<Product_UnitDTO> Product_UnitDTOs => product_Units;
        public BindingList<Product_UnitDTO> product_Units = new BindingList<Product_UnitDTO>();

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

            cbb_Producers.DataSource = context.Suppliers.AsNoTracking().ToList();
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
                nmr_UnitPrice.Value = _productDto.Price;

                pictureBox.ImageLocation = _productDto.ImagePath;
                //_imagePath = _productDto.Image;

                nmr_Quantity.Value = _productDto.Quantity;

                product_Units = new BindingList<Product_UnitDTO>( context.ProductUnits
                    .Include(o => o.Inventory)
                    .Where(o => o.ProductID == _productDto.ProductId)
                    .Select(o => new Product_UnitDTO(
                        o.ID,
                        o.ProductID,
                        o.UnitID,
                        o.Unit.Name,
                        o.Inventory.ID,
                        o.ConversionRate,
                        o.UnitPrice,
                        o.Inventory.Quantity
                    )).ToList());

                dgv_ProductUnitList.DataSource = product_Units;
            }
            else
            {
                product_Units = new BindingList<Product_UnitDTO>();
                dgv_ProductUnitList.DataSource = product_Units;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Product product = new Models.Product
            {
                Name = tb_ProductName.Text,
                Description = mttb_Description.Text,
                CategoryID = (int)cbb_Categories.SelectedValue,
                ProducerID = (int)cbb_Producers.SelectedValue,
                BaseUnitID = (int)cbb_Units.SelectedValue,
                Image = pictureBox.ImageLocation
            };

            if (_productDto != null)
            {
                //product.Image = _imagePath;
                // Gán ID cho Product_Unit và Inventory
                //foreach (var unit in _productDto.Unit)
                //{
                //    if (unit.IsSelected)
                //    {

                //        productUnit.ID = unit.ProductUnitId;
                //        break;
                //    }
                //}
                //inventory.ID = _productDto?.InventoryId ?? 0;
                //inventory.Note = "";

                ////// Cập nhật ProductId cho Product_Unit và Inventory
                ////productUnit.ProductID = _productDto.ProductId;
                ////productUnit.InventoryID = inventory.ID;
                //inventory.ProductID = _productDto.ProductId;
            }

            foreach (var unit in product_Units)
            {
                MessageBox.Show(unit.UnitPrice.ToString());
            }

            this.Tag = (product);

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

        private void dgv_ProductUnitList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_AddUnit_Click(object sender, EventArgs e)
        {
            product_Units.Add(new Product_UnitDTO(
                0,
                0,
                (int)cbb_Units.SelectedValue,
                cbb_Units.Text,
                0,
                nmr_Conversion.Value,
                nmr_UnitPrice.Value,
                (int)nmr_Quantity.Value
            ));
        }
    }
}
