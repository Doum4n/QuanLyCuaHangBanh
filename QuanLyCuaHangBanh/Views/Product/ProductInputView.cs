using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Uitls;
using System.ComponentModel;

namespace QuanLyCuaHangBanh.Views
{
    /// <summary>
    /// Record lưu trữ thông tin liên kết giữa Product_Unit và Inventory
    /// </summary>
    /// <param name="Product_UnitID">ID của đơn vị sản phẩm</param>
    /// <param name="InventoryID">ID của kho hàng</param>
    public record ProductUnit_Inventory(
        int Product_UnitID,
        int InventoryID
    );

    /// <summary>
    /// Form nhập liệu cho sản phẩm
    /// Cho phép thêm mới và chỉnh sửa thông tin sản phẩm, bao gồm:
    /// - Thông tin cơ bản sản phẩm
    /// - Danh sách đơn vị tính
    /// - Thông tin kho hàng
    /// - Hình ảnh sản phẩm
    /// </summary>
    public partial class ProductInputView : Form
    {
        #region Fields & Properties

        /// <summary>
        /// Database context để truy cập dữ liệu
        /// </summary>
        private readonly QLCHB_DBContext context = new QLCHB_DBContext();

        /// <summary>
        /// DTO chứa thông tin sản phẩm cần chỉnh sửa (null nếu thêm mới)
        /// </summary>
        private readonly ProductDTO? _productDto;

        /// <summary>
        /// Đường dẫn đến hình ảnh sản phẩm
        /// </summary>
        private string? _imagePath;

        /// <summary>
        /// Sự kiện hiển thị form nhập liệu đơn vị tính
        /// </summary>
        public EventHandler ShowUnitInput;

        /// <summary>
        /// Sự kiện hiển thị form nhập liệu danh mục
        /// </summary>
        public EventHandler ShowCategoryInput;

        /// <summary>
        /// Sự kiện hiển thị form nhập liệu nhà cung cấp
        /// </summary>
        public EventHandler ShowProducerInput;

        /// <summary>
        /// Sự kiện chọn hình ảnh sản phẩm
        /// </summary>
        public EventHandler SelectImage;

        /// <summary>
        /// Binding source cho danh sách đơn vị tính
        /// </summary>
        public readonly BindingSource bs = new BindingSource();

        /// <summary>
        /// Danh sách đơn vị tính của sản phẩm
        /// </summary>
        private BindingList<Product_UnitDTO> product_Units = new BindingList<Product_UnitDTO>();

        /// <summary>
        /// Property public để truy cập danh sách đơn vị tính
        /// </summary>
        public BindingList<Product_UnitDTO> Product_UnitDTOs => product_Units;

        /// <summary>
        /// Flag đánh dấu form đang ở chế độ chỉnh sửa
        /// </summary>
        private readonly bool _isEdit;

        #endregion

        #region Constructor & Load

        /// <summary>
        /// Khởi tạo form nhập liệu sản phẩm
        /// </summary>
        /// <param name="productDto">DTO sản phẩm cần chỉnh sửa (null nếu thêm mới)</param>
        /// <param name="isEdit">True nếu ở chế độ chỉnh sửa, False nếu ở chế độ xem</param>
        public ProductInputView(ProductDTO? productDto = null, bool isEdit = true)
        {
            InitializeComponent();
            _productDto = productDto;
            _isEdit = isEdit;
            tabControl1.SelectedIndexChanged += tabControl1_TabIndexChanged;
        }

        /// <summary>
        /// Xử lý sự kiện load form
        /// - Khởi tạo các controls
        /// - Nạp dữ liệu cho các combobox
        /// - Thiết lập data bindings
        /// </summary>
        private void ProductInputView_Load(object sender, EventArgs e)
        {
            // Thiết lập trạng thái controls khi ở chế độ xem
            if (!_isEdit)
            {
                SetupViewMode();
            }

            // Nạp dữ liệu cho các combobox
            LoadComboBoxData();

            // Nạp thông tin sản phẩm nếu ở chế độ chỉnh sửa
            if (_productDto != null)
            {
                LoadExistingProduct();
            }
            else
            {
                InitializeNewProduct();
            }

            // Thiết lập data bindings
            SetupDataBindings();
        }

        /// <summary>
        /// Thiết lập trạng thái các controls khi ở chế độ xem
        /// </summary>
        private void SetupViewMode()
        {
            cbb_Units.Enabled = false;
            cbb_Units.SelectedIndex = -1;
            cbb_Units.Text = "";
            nmr_Conversion.Value = 1;
            nmr_UnitPrice.Value = 0;
            nmr_Quantity.Value = 0;
            btn_EditUnit.Enabled = false;
            btn_DeleteUnit.Enabled = false;
            btn_AddUnit.Enabled = false;
            btn_Cancel.Enabled = false;
            btn_Save.Enabled = false;
            nmr_Quantity.Enabled = false;
            nmr_TotalQuantity.Enabled = false;
            nmr_UnitPrice.Enabled = false;
            cbb_Categories.Enabled = false;
            cbb_Producers.Enabled = false;
            cbb_Manufacturers.Enabled = false;
            mttb_Description.Enabled = false;
            pictureBox.Enabled = false;

            dgv_ProductUnitList.Columns["UnitName"].ReadOnly = true;
        }

        /// <summary>
        /// Nạp dữ liệu cho các combobox từ database
        /// </summary>
        private void LoadComboBoxData()
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
        }

        /// <summary>
        /// Nạp thông tin sản phẩm hiện có khi ở chế độ chỉnh sửa
        /// </summary>
        private void LoadExistingProduct()
        {
            // Chọn đơn vị tính mặc định
            foreach (var unit in _productDto.Units)
            {
                if (unit.IsSelected)
                {
                    cbb_Units.SelectedValue = unit.ID;
                    break;
                }
            }

            // Nạp thông tin cơ bản
            tb_ProductName.Text = _productDto.ProductName;
            mttb_Description.Text = _productDto.Description;
            cbb_Categories.SelectedValue = _productDto.CategoryId;
            cbb_Producers.SelectedValue = _productDto.ProducerId;
            nmr_UnitPrice.Value = _productDto.UnitPrice;
            cbb_Manufacturers.SelectedValue = _productDto.ManufacturerId;
            pictureBox.ImageLocation = _productDto.ImagePath;
            _imagePath = _productDto.ImagePath;

            nmr_Quantity.Value = _productDto.Quantity;
            nmr_TotalQuantity.Value = _productDto.TotalQuantity;

            // Nạp danh sách đơn vị tính
            LoadProductUnits();
        }

        /// <summary>
        /// Nạp danh sách đơn vị tính của sản phẩm
        /// </summary>
        private void LoadProductUnits()
        {
            product_Units = new BindingList<Product_UnitDTO>(context.ProductUnits
                .Include(o => o.Product)
                .Include(o => o.Inventory)
                .Where(o => o.ProductID == _productDto.ProductId)
                .Select(o => new Product_UnitDTO(
                    o.ID,
                    o.ProductID,
                    o.UnitID,
                    o.Unit.Name,
                    o.Inventory != null ? o.Inventory.ID : 0,
                    o.ConversionRate,
                    o.UnitPrice,
                    o.Inventory != null ? o.Inventory.Quantity : 0,
                    o.Product.BaseUnitID == o.UnitID
                )
                {
                    status = DTO.Base.Status.None
                }).ToList());

            bs.DataSource = product_Units;
            dgv_ProductUnitList.DataSource = bs;
        }

        /// <summary>
        /// Khởi tạo sản phẩm mới
        /// </summary>
        private void InitializeNewProduct()
        {
            product_Units = new BindingList<Product_UnitDTO>();
            bs.DataSource = product_Units;
            dgv_ProductUnitList.DataSource = bs;
        }

        /// <summary>
        /// Thiết lập data bindings giữa controls và properties
        /// </summary>
        private void SetupDataBindings()
        {
            cbb_Units.DataBindings.Add("SelectedValue", bs, "UnitID", true, DataSourceUpdateMode.Never);
            cbb_Units.DataBindings.Add("Text", bs, "UnitName", true, DataSourceUpdateMode.Never);
            nmr_Conversion.DataBindings.Add("Value", bs, "ConversionRate", true, DataSourceUpdateMode.Never);
            nmr_UnitPrice.DataBindings.Add("Value", bs, "UnitPrice", true, DataSourceUpdateMode.Never);
            nmr_Quantity.DataBindings.Add("Value", bs, "Quantity", true, DataSourceUpdateMode.Never);
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu
        /// - Tạo đối tượng sản phẩm mới
        /// - Kiểm tra dữ liệu hợp lệ
        /// - Đóng form và trả về kết quả
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Product product = new Models.Product
            {
                Name = tb_ProductName?.Text ?? string.Empty,
                Description = mttb_Description?.Text ?? string.Empty,
                CategoryID = (int?)cbb_Categories?.SelectedValue ?? 0,
                ProducerID = (int?)cbb_Producers?.SelectedValue ?? 0,
                ManufacturerID = (int?)cbb_Manufacturers?.SelectedValue,
                Image = _productDto != null ? _productDto.ImagePath : (pictureBox?.ImageLocation ?? string.Empty)
            };

            // Kiểm tra đơn vị cơ bản
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

            this.Tag = product;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn link thêm đơn vị tính mới
        /// </summary>
        private void llb_AddUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowUnitInput?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn link thêm danh mục mới
        /// </summary>
        private void llb_AddCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCategoryInput?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            SelectImage?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Cập nhật hình ảnh cho pictureBox
        /// </summary>
        /// <param name="imagePath">Đường dẫn hình ảnh</param>
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

        /// <summary>
        /// Xử lý sự kiện khi thay đổi giá trị ô combobox đơn vị tính
        /// </summary>
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

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút thêm đơn vị tính
        /// Uses <see cref="QuanLyCuaHangBanh.Services.ProductService.UpdateProduct"/>
        /// Uses <see cref="QuanLyCuaHangBanh.Services.ProductService.AddNewProduct"/>
        /// </summary>
        private void btn_AddUnit_Click(object sender, EventArgs e)
        {
            var productUnit = new Product_UnitDTO(
                bs.Count + 1, // ID tự động tăng (Không ảnh hưởng đến việc thêm hay sửa do việc đó được sử lý trong ProductService)
                Convert.ToInt32(cbb_Producers.SelectedValue),
                Convert.ToInt32(cbb_Units.SelectedValue),
                cbb_Units.Text,
                0, // Tồn kho chưa được tạo trong database
                nmr_Conversion.Value,
                nmr_UnitPrice.Value,
                0 // Mặc định số lượng là 0 khi thêm đơn vị tính mới, số lượng sẽ được cập nhật khi nhập hàngs
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

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút chỉnh sửa đơn vị tính
        /// </summary>
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

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút xóa đơn vị tính
        /// </summary>
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

        /// <summary>
        /// Xử lý sự kiện khi thay đổi index của tabControl
        /// </summary>
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

        /// <summary>
        /// Reset các giá trị đơn vị tính
        /// </summary>
        private void ClearProductUnitInputControls()
        {
            cbb_Units.SelectedIndex = -1; // Chọn không có gì
            nmr_Conversion.Value = 1;
            nmr_UnitPrice.Value = 0;
            nmr_Quantity.Value = 0;
            // cbb_Units.Focus(); // Có thể focus hoặc không tùy ý
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút hủy
        /// </summary>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearProductUnitInputControls();
        }

        #endregion

        private void dgv_ProductUnitList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_ProductUnitList.Rows.Count)
            {   
                var row = dgv_ProductUnitList.Rows[e.RowIndex];
                if (row.DataBoundItem is Product_UnitDTO product_UnitDTO)
                {
                    row.DefaultCellStyle.BackColor = Utils.DataGridView.GetStatusColor(product_UnitDTO.status);
                }
            }
        }
    }
}
