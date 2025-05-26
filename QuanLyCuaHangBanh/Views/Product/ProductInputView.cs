using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Uitls;
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

        public BindingSource bs = new BindingSource();
        public BindingList<Product_UnitDTO> Product_UnitDTOs => product_Units;
        public BindingList<Product_UnitDTO> product_Units = new BindingList<Product_UnitDTO>();


        public ProductInputView(ProductDTO? productDto = null)
        {
            InitializeComponent();
            _productDto = productDto;
            tabControl1.SelectedIndexChanged += tabControl1_TabIndexChanged;
        }

        private void ProductInputView_Load(object sender, EventArgs e)
        {
            cbb_Manufacturers.DataSource = context.Manufacturers.AsNoTracking().ToList();
            cbb_Manufacturers.DisplayMember = "Name";
            cbb_Manufacturers.ValueMember = "ID";

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
                foreach (var unit in _productDto.Units)
                {
                    if (unit.IsSelected)
                    {
                        cbb_Units.SelectedValue = unit.ID;
                        break;
                    }
                }

                tb_ProductName.Text = _productDto.ProductName;
                mttb_Description.Text = _productDto.Description;
                cbb_Categories.SelectedValue = _productDto.CategoryId;
                cbb_Producers.SelectedValue = _productDto.ProducerId;
                nmr_UnitPrice.Value = _productDto.Price;
                cbb_Manufacturers.SelectedValue = _productDto.ManufactureId;
                //dtp_ProductionDate.Value = _productDto.ProductionDate.ToDateTime(new TimeOnly(0, 0, 0));
                //dtp_ExpirationDate.Value = _productDto.ExpirationDate.ToDateTime(new TimeOnly(0, 0, 0));
                pictureBox.ImageLocation = _productDto.ImagePath;
                _imagePath = _productDto.ImagePath;

                nmr_Quantity.Value = _productDto.Quantity;
                nmr_TotalQuantity.Value = _productDto.TotalQuantity;

                product_Units = new BindingList<Product_UnitDTO>(context.ProductUnits
                    .Include(o => o.Product)
                    .Include(o => o.Inventory)
                    .Where(o => o.ProductID == _productDto.ProductId)
                    .Select(o => new Product_UnitDTO(
                        o.ID,
                        o.ProductID,
                        o.UnitID,
                        o.Unit.Name,
                        // Xử lý Inventory.ID:
                        // Kiểm tra o.Inventory có null không, nếu null thì trả về 0
                        o.Inventory != null ? o.Inventory.ID : 0,
                        o.ConversionRate,
                        o.UnitPrice,
                        // Xử lý Inventory.Quantity:
                        // Kiểm tra o.Inventory có null không, nếu null thì trả về 0
                        o.Inventory != null ? o.Inventory.Quantity : 0,
                        o.Product.BaseUnitID == o.UnitID // Kiểm tra xem đây có phải là đơn vị cơ bản không 
                    )
                    {
                        status = DTO.Base.Status.None
                    }).ToList());

                bs.DataSource = product_Units;

                dgv_ProductUnitList.DataSource = bs;
            }
            else
            {
                product_Units = new BindingList<Product_UnitDTO>();
                bs.DataSource = product_Units;
                dgv_ProductUnitList.DataSource = bs;
            }


            cbb_Units.DataBindings.Add("SelectedValue", bs, "UnitID", true, DataSourceUpdateMode.Never);
            cbb_Units.DataBindings.Add("Text", bs, "UnitName", true, DataSourceUpdateMode.Never);
            nmr_Conversion.DataBindings.Add("Value", bs, "ConversionRate", true, DataSourceUpdateMode.Never);
            nmr_UnitPrice.DataBindings.Add("Value", bs, "UnitPrice", true, DataSourceUpdateMode.Never);
            nmr_Quantity.DataBindings.Add("Value", bs, "Quantity", true, DataSourceUpdateMode.Never);

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Product product = new Models.Product
            {
                Name = tb_ProductName?.Text ?? string.Empty,
                Description = mttb_Description?.Text ?? string.Empty,
                CategoryID = (int?)cbb_Categories?.SelectedValue ?? 0,
                ProducerID = (int?)cbb_Producers?.SelectedValue ?? 0,
                ManufacturerID = (int?)cbb_Manufacturers?.SelectedValue,
                //ProductionDate = dtp_ProductionDate?.Value != null ? DateOnly.FromDateTime(dtp_ProductionDate.Value) : default,
                //ExpirationDate = dtp_ExpirationDate?.Value != null ? DateOnly.FromDateTime(dtp_ExpirationDate.Value) : default,
                Image = pictureBox?.ImageLocation
            };

            if (_productDto != null)
            {
                product.Image = _imagePath;
            }

            foreach (var unit in product_Units)
            {
                if (unit.IsChecked)
                {
                    product.BaseUnitID = unit.UnitID;
                    if (unit.ConversionRate != 1)
                    {
                        MessageBox.Show("Tỷ lệ chuyển đổi phải là 1 cho đơn vị cơ bản.");
                        return;
                    }
                }
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
                _imagePath = imagePath; // Lưu đường dẫn hình ảnh để sử dụng sau này
            }
            else
            {
                _imagePath = _productDto.ImagePath;
                MessageBox.Show("Không tìm thấy hình ảnh.");
            }
        }

        private void dgv_ProductUnitList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Kiểm tra xem cột có phải là cột checkbox không
            if (dgv_ProductUnitList.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                // Lấy ô checkbox hiện tại
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgv_ProductUnitList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Đảo ngược giá trị của ô checkbox
                bool currentValue = checkBoxCell.Value != null && (bool)checkBoxCell.Value;
                checkBoxCell.Value = !currentValue;
                // Nếu ô checkbox được đánh dấu, bỏ đánh dấu các ô khác trong cùng cột
                if ((bool)checkBoxCell.Value)
                {
                    // Đổi giá trị của thuộc tính IsChecked trong Product_UnitDTO
                    var productUnit = (Product_UnitDTO)dgv_ProductUnitList.Rows[e.RowIndex].DataBoundItem;
                    productUnit.IsChecked = true;

                    // Bỏ đánh dấu các ô checkbox khác trong cùng cột
                    ColumnCheckBox.UncheckOtherCheckBoxes(dgv_ProductUnitList, e);

                    // Cập nhật giá trị của các ô checkbox khác trong cùng cột
                    for (int i = 0; i < dgv_ProductUnitList.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            DataGridViewCheckBoxCell otherCheckBoxCell = (DataGridViewCheckBoxCell)dgv_ProductUnitList.Rows[i].Cells[e.ColumnIndex];
                            otherCheckBoxCell.Value = false;
                            // Cập nhật giá trị IsChecked cho các Product_UnitDTO khác
                            var otherProductUnit = (Product_UnitDTO)dgv_ProductUnitList.Rows[i].DataBoundItem;
                            otherProductUnit.IsChecked = false;
                        }
                    }
                }
            }
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

            if (product_Units.Any(u => u.UnitID == productUnit.UnitID && u.ProductID == _productDto?.ProductId))
            {
                MessageBox.Show("Đơn vị này đã tồn tại trong danh sách.");
                return;
            }

            if (cbb_Units.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một đơn vị.");
                return;
            }

            productUnit.status = DTO.Base.Status.New;

            product_Units.Add(productUnit);
        }

        private void btn_EditUnit_Click(object sender, EventArgs e)
        {
            if (dgv_ProductUnitList.SelectedRows.Count > 0 && cbb_Units.SelectedIndex != -1)
            {
                var selectedRow = dgv_ProductUnitList.SelectedRows[0];
                var productUnit = (Product_UnitDTO)selectedRow.DataBoundItem;
                if (productUnit != null)
                {
                    productUnit.UnitID = (int)cbb_Units.SelectedValue;
                    productUnit.UnitName = cbb_Units.Text;
                    productUnit.ConversionRate = nmr_Conversion.Value;
                    productUnit.UnitPrice = nmr_UnitPrice.Value;
                    productUnit.Quantity = (int)nmr_Quantity.Value;
                    productUnit.status = DTO.Base.Status.Modified;
                    dgv_ProductUnitList.Refresh();
                }
                else
                {

                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đơn vị để chỉnh sửa.");
            }
        }

        private void btn_DeleteUnit_Click(object sender, EventArgs e)
        {
            if (bs.Current is Product_UnitDTO selectedProduct)
            {
                if (selectedProduct.status == DTO.Base.Status.New)
                {
                    product_Units.Remove(selectedProduct);
                    bs.ResetBindings(false);
                }
                else
                {
                    selectedProduct.status = DTO.Base.Status.Deleted;
                    bs.DataSource = new BindingList<Product_UnitDTO>(
                        product_Units.Where(p => p.status != DTO.Base.Status.Deleted).ToList()
                    );
                    bs.ResetBindings(false);
                }
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

        private void ClearProductUnitInputControls()
        {
            cbb_Units.SelectedIndex = -1; // Chọn không có gì
            nmr_Conversion.Value = 0;
            nmr_UnitPrice.Value = 0;
            nmr_Quantity.Value = 0;
            // cbb_Units.Focus(); // Có thể focus hoặc không tùy ý
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearProductUnitInputControls();
        }
    }
}
