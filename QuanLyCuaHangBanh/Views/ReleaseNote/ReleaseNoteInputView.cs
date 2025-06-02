using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Views
{
    /// <summary>
    /// Form nhập liệu cho phiếu xuất kho
    /// Cho phép thêm mới và chỉnh sửa thông tin phiếu xuất kho, bao gồm:
    /// - Thông tin phiếu (ngày tạo, ghi chú, trạng thái)
    /// - Danh sách sản phẩm xuất kho
    /// - Liên kết với đơn hàng hoặc phiếu nhập kho
    /// </summary>
    public partial class ReleaseNoteInputView : Form
    {
        #region Fields

        /// <summary>
        /// Database context để truy cập dữ liệu
        /// </summary>
        private readonly QLCHB_DBContext? context = new QLCHB_DBContext();

        /// <summary>
        /// DTO chứa thông tin phiếu xuất kho cần chỉnh sửa (null nếu thêm mới)
        /// </summary>
        private readonly WarehouseReleaseNoteDTO? dTO;

        /// <summary>
        /// BindingSource cho danh sách sản phẩm
        /// </summary>
        private readonly BindingSource bs = new();

        /// <summary>
        /// Danh sách sản phẩm trong phiếu xuất kho
        /// </summary>
        private BindingList<ProductReleaseDTO> _products;

        /// <summary>
        /// ID của phiếu liên kết (đơn hàng hoặc phiếu nhập kho)
        /// </summary>
        private int selectedReleaseNoteId;

        /// <summary>
        /// ID của đơn vị tính sản phẩm đang chọn
        /// </summary>
        private int productUnitID;

        #endregion

        #region Properties

        /// <summary>
        /// BindingSource cho danh sách sản phẩm
        /// </summary>
        public BindingSource ProductsBindingSource => bs;

        /// <summary>
        /// Danh sách sản phẩm trong phiếu xuất kho
        /// </summary>
        public BindingList<ProductReleaseDTO> Products => _products;

        #endregion

        #region Events

        /// <summary>
        /// Event khi thêm sản phẩm mới vào phiếu
        /// </summary>
        public event Action<ProductReleaseDTO> AddProductEvent;

        /// <summary>
        /// Event hiển thị form chọn phiếu nhập kho
        /// </summary>
        public event Func<object, EventArgs, int> ShowSelectGoodsReciveNoteForm;

        /// <summary>
        /// Event hiển thị form chọn đơn hàng
        /// </summary>
        public event Func<object, EventArgs, int> ShowSelectOrderForm;

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo form nhập liệu phiếu xuất kho
        /// </summary>
        /// <param name="dTO">DTO chứa thông tin phiếu xuất kho cần chỉnh sửa (null nếu thêm mới)</param>
        public ReleaseNoteInputView(WarehouseReleaseNoteDTO? dTO = null)
        {
            InitializeComponent();
            this.dTO = dTO;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Xử lý sự kiện load form
        /// - Khởi tạo dữ liệu cho các combobox
        /// - Nạp thông tin phiếu xuất kho nếu ở chế độ chỉnh sửa
        /// </summary>
        private void WarehouseReleaseNoteInputView_Load(object sender, EventArgs e)
        {
            InitializeComboboxes();

            if (dTO != null)
            {
                LoadExistingReleaseNote();
            }
            else
            {
                InitializeNewReleaseNote();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút thêm sản phẩm
        /// </summary>
        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            var productReleaseDTO = new ProductReleaseDTO(
                bs.Count + 1,
                cbb_Products.Text,
                (int)cbb_Categories.SelectedValue,
                cbb_Categories.Text,
                cbb_Units.Text,
                productUnitID,
                (decimal)nmr_ConversionRate.Value,
                Convert.ToInt32(nmr_Quantity.Value),
                rtb_ProductNote.Text
            );

            bs.Add(productReleaseDTO);
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu
        /// - Tạo đối tượng phiếu xuất kho mới
        /// - Đóng form và trả về kết quả
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            WarehouseReleaseNote warehouseReleaseNote = new()
            {
                ID = dTO?.ID ?? 0,
                CreatedByID = Session.EmployeeId,
                CreatedDate = DateOnly.FromDateTime(dateTimePicker.Value),
                Note = rtb_Note.Text,
                Status = cbb_Status.SelectedItem.ToString(),
                LinkedId = selectedReleaseNoteId
            };

            if (dTO != null)
            {
                warehouseReleaseNote.ID = dTO.ID;
                warehouseReleaseNote.LastModifiedByID = Session.EmployeeId;
                warehouseReleaseNote.LastModifiedDate = DateOnly.FromDateTime(DateTime.Now);
            }

            this.Tag = warehouseReleaseNote;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi lựa chọn phiếu liên kết
        /// </summary>
        private void rbtn_GoodsReciveNote_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_GoodsReciveNote.Checked)
            {
                var result = ShowSelectGoodsReciveNoteForm?.Invoke(sender, e) ?? 0;
                if (result != 0)
                {
                    selectedReleaseNoteId = result;
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút cập nhật sản phẩm
        /// </summary>
        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (bs.Current is ProductReleaseDTO selectedProduct)
            {
                UpdateSelectedProduct(selectedProduct);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút hủy
        /// </summary>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cbb_Products.SelectedIndex = -1;
            cbb_Units.SelectedIndex = -1;
            nmr_ConversionRate.Value = 0;
            nmr_Quantity.Value = 0;
            rtb_ProductNote.Text = "";
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi sản phẩm
        /// - Cập nhật danh sách đơn vị tính
        /// - Cập nhật tỷ lệ quy đổi
        /// </summary>
        private void cbb_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Products.SelectedItem is Models.Product selectedProduct)
            {
                var units = context.ProductUnits
                    .Include(o => o.Unit)
                    .Where(o => o.ProductID == selectedProduct.ID)
                    .Select(o => o.Unit)
                    .ToList();

                cbb_Units.DataSource = units;
                cbb_Units.DisplayMember = "Name";
                cbb_Units.ValueMember = "ID";

                var baseUnit = context.ProductUnits
                    .FirstOrDefault(o => o.ProductID == selectedProduct.ID && o.UnitID == selectedProduct.BaseUnitID);

                if (baseUnit != null)
                {
                    cbb_Units.SelectedValue = baseUnit.UnitID;
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi đơn vị tính
        /// - Cập nhật ID đơn vị tính
        /// - Cập nhật tỷ lệ quy đổi và số lượng tối đa
        /// </summary>
        private void cbb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Products.SelectedItem is Models.Product selectedProduct && cbb_Units.SelectedItem is Models.Unit selectedUnit)
            {
                var selectedUnitId = selectedUnit.ID;
                var _productUnit = context.ProductUnits
                    .Include(o => o.Inventory)
                    .Where(o => o.ProductID == selectedProduct.ID && o.UnitID == selectedUnitId)
                    .FirstOrDefault();

                if (_productUnit != null)
                {
                    productUnitID = _productUnit.ID;
                    nmr_ConversionRate.Value = _productUnit.ConversionRate;

                    var totalQuantity = context.ProductUnits
                        .Include(o => o.Inventory)
                        .Where(o => o.ProductID == selectedProduct.ID && o.UnitID == selectedUnitId)
                        .Sum(g => g.Inventory != null ? g.Inventory.Quantity : -1);

                    nmr_Quantity.Maximum = totalQuantity != -1 ?
                        totalQuantity :
                        throw new Exception("Không tìm thấy kho hàng");
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút xóa sản phẩm
        /// </summary>
        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (bs.Current is ProductReleaseDTO selectedProduct)
            {
                if (ShowConfirmationDialog($"Bạn có chắc chắn muốn xóa sản phẩm {selectedProduct.ProductName}?"))
                {
                    bs.Remove(selectedProduct);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện vẽ hàng trong DataGridView
        /// - Tô màu các hàng theo trạng thái
        /// </summary>
        private void dgv_ProductList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_ProductList.Rows.Count)
            {
                var row = dgv_ProductList.Rows[e.RowIndex];
                if (row.DataBoundItem is ProductReleaseDTO product)
                {
                    row.DefaultCellStyle.BackColor = Utils.DataGridView.GetStatusColor(product.Status);
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Khởi tạo dữ liệu cho các combobox
        /// </summary>
        private void InitializeComboboxes()
        {
            cbb_Categories.DataSource = context.Categories.ToList();
            cbb_Categories.DisplayMember = "Name";
            cbb_Categories.ValueMember = "ID";

            cbb_Products.DataSource = context.Products.ToList();
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";

            cbb_Units.DataSource = context.Units.ToList();
            cbb_Units.DisplayMember = "Name";
            cbb_Units.ValueMember = "ID";

            CreatorName.Text = Session.EmployeeName;

            cbb_Status.DataSource = new List<string>
            {
                "Mới",
                "Đã duyệt",
                "Đang xuất kho",
                "Đã xuất kho",
                "Đã hủy"
            };
        }

        /// <summary>
        /// Nạp thông tin phiếu xuất kho hiện có khi ở chế độ chỉnh sửa
        /// </summary>
        private void LoadExistingReleaseNote()
        {
            cbb_Status.Text = dTO.Status;
            dateTimePicker.Value = dTO.CreatedDate.ToDateTime(TimeOnly.MinValue);
            rtb_Note.Text = dTO.Note;

            _products = new BindingList<ProductReleaseDTO>(
                context.WarehouseReleaseNoteDetails
                    .Include(o => o.Product_Unit)
                    .ThenInclude(o => o.Product).ThenInclude(o => o.Category)
                    .Include(o => o.Product_Unit).ThenInclude(o => o.Unit)
                    .Where(o => o.WarehouseReleaseNoteId == dTO.ID)
                    .Select(o => new ProductReleaseDTO(
                        o.ID,
                        o.Product_Unit.Product.Name,
                        o.Product_Unit.Product.CategoryID,
                        o.Product_Unit.Product.Category.Name,
                        o.Product_Unit.Unit.Name,
                        o.Product_UnitID,
                        o.Product_Unit.ConversionRate,
                        o.Quantity,
                        o.Note
                    )
                    {
                        Status = DTO.Base.Status.None,
                    }).ToList()
            );

            InitializeBindings();
        }

        /// <summary>
        /// Khởi tạo phiếu xuất kho mới
        /// </summary>
        private void InitializeNewReleaseNote()
        {
            _products = new BindingList<ProductReleaseDTO>();
            InitializeBindings();
        }

        /// <summary>
        /// Khởi tạo các binding giữa controls và dữ liệu
        /// </summary>
        private void InitializeBindings()
        {
            bs.DataSource = _products;
            dgv_ProductList.DataSource = bs;

            cbb_Categories.DataBindings.Add("SelectedValue", bs, "CategoryID", true, DataSourceUpdateMode.Never);
            cbb_Products.DataBindings.Add("Text", bs, "productName", true, DataSourceUpdateMode.Never);
            cbb_Units.DataBindings.Add("Text", bs, "unitName", true, DataSourceUpdateMode.Never);
            nmr_Quantity.DataBindings.Add("Text", bs, "Quantity", true, DataSourceUpdateMode.Never);
            nmr_ConversionRate.DataBindings.Add("Text", bs, "ConversionRate", true, DataSourceUpdateMode.Never);
            rtb_ProductNote.DataBindings.Add("Text", bs, "Note", true, DataSourceUpdateMode.Never);
        }

        /// <summary>
        /// Thêm sản phẩm mới vào phiếu
        /// </summary>
        /// <param name="productReleaseDTO">Thông tin sản phẩm cần thêm</param>
        public void AddProduct(ProductReleaseDTO productReleaseDTO)
        {
            productReleaseDTO.IsNewlyAdded = true;
            productReleaseDTO.Status = DTO.Base.Status.New;
            bs.Add(productReleaseDTO);
        }

        /// <summary>
        /// Kích hoạt event thêm sản phẩm
        /// </summary>
        /// <param name="product">Sản phẩm cần thêm</param>
        public void RaiseAddProductEvent(ProductReleaseDTO product)
        {
            AddProductEvent?.Invoke(product);
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm đang chọn
        /// </summary>
        /// <param name="selectedProduct">Sản phẩm cần cập nhật</param>
        private void UpdateSelectedProduct(ProductReleaseDTO selectedProduct)
        {
            selectedProduct.ProductName = cbb_Products.Text;
            selectedProduct.CategoryId = (int)cbb_Categories.SelectedValue;
            selectedProduct.CategoryName = cbb_Categories.Text;
            selectedProduct.ProductUnitId = productUnitID;
            selectedProduct.UnitName = cbb_Units.Text;
            selectedProduct.ConversionRate = (decimal)nmr_ConversionRate.Value;
            selectedProduct.Quantity = Convert.ToInt32(nmr_Quantity.Value);
            selectedProduct.Note = rtb_ProductNote.Text;

            // Nếu sản phẩm mới được thêm vào thì không cập nhật trạng thái (giữ nguyên trạng thái)
            if (selectedProduct.Status != DTO.Base.Status.New)
            {
                selectedProduct.Status = DTO.Base.Status.Modified;
            }

            bs.ResetBindings(false);
        }

        /// <summary>
        /// Hiển thị hộp thoại xác nhận
        /// </summary>
        /// <param name="message">Nội dung cần xác nhận</param>
        /// <returns>True nếu người dùng đồng ý, False nếu không</returns>
        private bool ShowConfirmationDialog(string message)
        {
            return MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }


        private void cbb_Categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Categories.SelectedItem is Models.Category selectedCategory)
            {
                cbb_Products.DataSource = context.Products
                    .Where(p => p.CategoryID == selectedCategory.ID)
                    .ToList();
                cbb_Products.DisplayMember = "Name";
                cbb_Products.ValueMember = "ID";
            }
        }

        #endregion

        private void rbtn_Order_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_Order.Checked)
            {
                var result = ShowSelectOrderForm?.Invoke(sender, e) ?? 0;
                if (result != 0)
                {
                    selectedReleaseNoteId = result;
                }
            }
        }
    }
}
