using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
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
                nmr_TotalQuantity.Value = _productDto.TotalQuantity;

                product_Units = new BindingList<Product_UnitDTO>(context.ProductUnits
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
                    )
                    {
                        status = DTO.Base.Status.None
                    }).ToList());

                dgv_ProductUnitList.DataSource = product_Units;
            }
            else
            {
                product_Units = new BindingList<Product_UnitDTO>();
                dgv_ProductUnitList.DataSource = product_Units;
            }

            //cbb_Categories.DataBindings.Add("SelectedValue", _productDto, "CategoryID", true, DataSourceUpdateMode.OnPropertyChanged);
            //cbb_Producers.DataBindings.Add("SelectedValue", _productDto, "ProducerID", true, DataSourceUpdateMode.OnPropertyChanged);
            ////cbb_Units.DataBindings.Add("SelectedValue", _productDto, "BaseUnitID", true, DataSourceUpdateMode.OnPropertyChanged);
            //tb_ProductName.DataBindings.Add("Text", _productDto, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged);
            //mttb_Description.DataBindings.Add("Text", _productDto, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
            ////nmr_UnitPrice.DataBindings.Add("Value", _productDto, "UnitPrice", true, DataSourceUpdateMode.OnPropertyChanged);
            ////nmr_Quantity.DataBindings.Add("Value", _productDto, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
            ///

            cbb_Units.DataBindings.Add("SelectedValue", product_Units, "UnitID", true, DataSourceUpdateMode.OnPropertyChanged);
            cbb_Units.DataBindings.Add("Text", product_Units, "UnitName", true, DataSourceUpdateMode.OnPropertyChanged);
            nmr_Conversion.DataBindings.Add("Value", product_Units, "ConversionRate", true, DataSourceUpdateMode.OnPropertyChanged);
            nmr_UnitPrice.DataBindings.Add("Value", product_Units, "UnitPrice", true, DataSourceUpdateMode.OnPropertyChanged);
            nmr_Quantity.DataBindings.Add("Value", product_Units, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
        
            tabControl1.SelectedIndexChanged += tabControl1_TabIndexChanged;
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
                product.Image = _imagePath;
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
            var productUnit = new Product_UnitDTO(
                0,
                Convert.ToInt32(cbb_Producers.SelectedValue),
                Convert.ToInt32(cbb_Units.SelectedValue),
                cbb_Units.Text,
                0,
                nmr_Conversion.Value,
                nmr_UnitPrice.Value,
                (int)nmr_Quantity.Value
            );
            product_Units.Add(productUnit);
        }

        private void btn_EditUnit_Click(object sender, EventArgs e)
        {
            if (dgv_ProductUnitList.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_ProductUnitList.SelectedRows[0];
                var productUnit = (Product_UnitDTO)selectedRow.DataBoundItem;
                productUnit.UnitID = (int)cbb_Units.SelectedValue;
                productUnit.UnitName = cbb_Units.Text;
                productUnit.ConversionRate = nmr_Conversion.Value;
                productUnit.UnitPrice = nmr_UnitPrice.Value;
                productUnit.Quantity = (int)nmr_Quantity.Value;
                productUnit.status = DTO.Base.Status.Deleted;
                dgv_ProductUnitList.Refresh();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn vị để chỉnh sửa.");
            }
        }

        private void btn_DeleteUnit_Click(object sender, EventArgs e)
        {
            if (dgv_ProductUnitList.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_ProductUnitList.SelectedRows[0];
                var productUnit = (Product_UnitDTO)selectedRow.DataBoundItem;
                if (productUnit.status == DTO.Base.Status.New)
                {
                    product_Units.Remove(productUnit);
                }
                else
                {
                    productUnit.status = DTO.Base.Status.Deleted;
                    product_Units = new BindingList<Product_UnitDTO>(product_Units.Where(u => u.status != DTO.Base.Status.Deleted).ToList());
                    dgv_ProductUnitList.DataSource = product_Units;
                    dgv_ProductUnitList.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn vị để xóa.");
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if (_productDto == null)
                    {
                        MessageBox.Show("Vui lòng chọn sản phẩm để xem thông tin sản phẩm.");
                        return;
                    }
                    break;
                case 1:
                    if (_productDto == null)
                    {
                        MessageBox.Show("Vui lòng chọn sản phẩm để xem thông tin nhập hàng.");
                        return;
                    }
                    dgv_ReceiptList.DataSource = context.GoodsReceiptNoteDetails
                        .Include(o => o.GoodsReceiptNote)
                        .Include(o => o.ProductUnit)
                        .Include(o => o.Product)
                        .Where(o => o.ProductUnit.ProductID == _productDto.ProductId)
                        .Select(o => new
                        {
                            o.ID,
                            UnitName = o.Unit.Name,
                            o.ProductUnit.ConversionRate,
                            o.PurchasePrice,
                            o.Quantity,
                            TotalPrice = o.PurchasePrice * o.Quantity,
                            ReceiptDate = o.GoodsReceiptNote.CreatedDate,
                            o.Note
                        }).OrderByDescending(o => o.ReceiptDate).ToList();
                    break;
                case 2:
                    if (_productDto == null)
                    {
                        MessageBox.Show("Vui lòng chọn sản phẩm để xem thông tin xuất hàng.");
                        return;
                    }
                    dgv_ReleaseList.DataSource = context.WarehouseReleaseNoteDetails
                        .Include(o => o.WarehouseReleaseNote)
                        .Include(o => o.Product_Unit)
                        .Where(o => o.Product_Unit.ProductID == _productDto.ProductId)
                        .Select(o => new
                        {
                            o.ID,
                            UnitName = o.Product_Unit.Unit.Name,
                            o.Product_Unit.ConversionRate,
                            o.Quantity,
                            ReleaseDate = o.WarehouseReleaseNote.CreatedDate,
                            o.Note
                        }).OrderByDescending(o => o.ReleaseDate).ToList();
                    break;
            }
        }
    }
}
