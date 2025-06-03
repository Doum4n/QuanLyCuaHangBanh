using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.ComponentModel;
using System.Data;

namespace QuanLyCuaHangBanh.Views.Order
{
    /// <summary>
    /// Form nhập liệu cho đơn hàng
    /// Cho phép thêm mới và chỉnh sửa thông tin đơn hàng, bao gồm:
    /// - Thông tin khách hàng
    /// - Danh sách sản phẩm
    /// - Thông tin thanh toán và giao hàng
    /// </summary>
    public partial class OrderInputView : Form
    {
        #region Fields & Properties

        /// <summary>
        /// Database context để truy cập dữ liệu
        /// </summary>
        private readonly QLCHB_DBContext context = new QLCHB_DBContext();

        /// <summary>
        /// DTO chứa thông tin đơn hàng cần chỉnh sửa (null nếu thêm mới)
        /// </summary>
        private readonly OrderDTO? orderDTO;

        /// <summary>
        /// Binding source cho danh sách sản phẩm trong đơn hàng
        /// </summary>
        private readonly BindingSource bs = new BindingSource();

        /// <summary>
        /// Danh sách sản phẩm trong đơn hàng
        /// </summary>
        private BindingList<ProductOrderDTO> _products = new BindingList<ProductOrderDTO>();

        /// <summary>
        /// Property public để truy cập danh sách sản phẩm
        /// </summary>
        public BindingList<ProductOrderDTO> Products => _products;

        /// <summary>
        /// ID của đơn vị sản phẩm được chọn hiện tại
        /// </summary>
        private int selectedProductUnitId;

        /// <summary>
        /// Tổng số tiền cần thanh toán cho đơn hàng
        /// </summary>
        private decimal totalPaymentRequired;

        /// <summary>
        /// Danh sách phương thức thanh toán
        /// </summary>
        private BindingList<string> paymentMethod = new BindingList<string>();

        #endregion

        #region Constructor & Load

        public OrderInputView(OrderDTO? orderDTO = null)
        {
            InitializeComponent();
            this.orderDTO = orderDTO;
        }

        /// <summary>
        /// Xử lý sự kiện load form
        /// </summary>
        private void OrderInputView_Load(object sender, EventArgs e)
        {
            // Khởi tạo dữ liệu cho các combobox
            LoadComboBoxData();

            // Điều chỉnh trạng thái và phương thức thanh toán
            AdjustStatus();
            AdjustPaymentMethods();

            // Nếu là chỉnh sửa đơn hàng
            if (orderDTO != null)
            {
                LoadExistingOrder();
            }
            else
            {
                // Khởi tạo danh sách sản phẩm mới
                InitializeNewProductList();
            }

            Utils.DataGridView.HideColumn(dgv_ProductList, new string[] { "Status", "CategoryID", "ID", "ProductUnitID", "OrderID" });
            // Thiết lập data bindings
            SetupDataBindings();
        }

        

        #endregion

        #region Data Loading Methods

        /// <summary>
        /// Nạp dữ liệu cho các combobox từ database
        /// Bao gồm:
        /// - Danh sách sản phẩm
        /// - Danh sách khách hàng
        /// - Danh sách danh mục
        /// </summary>
        private void LoadComboBoxData()
        {
            cbb_Products.DataSource = context.Products.ToList();
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";

            cbb_Customer.DataSource = context.Customers.ToList();
            cbb_Customer.DisplayMember = "Name";
            cbb_Customer.ValueMember = "ID";

            cbb_Categories.DataSource = context.Categories.ToList();
            cbb_Categories.DisplayMember = "Name";
            cbb_Categories.ValueMember = "ID";
        }

        /// <summary>
        /// Nạp thông tin đơn hàng hiện có khi ở chế độ chỉnh sửa
        /// Bao gồm:
        /// - Thông tin khách hàng
        /// - Địa chỉ giao hàng
        /// - Ngày đặt hàng
        /// - Trạng thái đơn hàng
        /// - Danh sách sản phẩm
        /// </summary>
        private void LoadExistingOrder()
        {
            cbb_Customer.Enabled = false;

            cbb_Customer.Text = orderDTO.CustomerName;
            rtb_DeliverAddress.Text = orderDTO.DeliveryAddress;
            dtpicker.Value = orderDTO.OrderDate;
            cbb_Status.Text = orderDTO.Status;

            _products = new BindingList<ProductOrderDTO>(
                context.OrderDetails
                    .Include(o => o.Product_Unit)
                    .ThenInclude(o => o.Product).ThenInclude(o => o.Category)
                    .Include(o => o.Product_Unit).ThenInclude(o => o.Unit)
                    .Where(o => o.OrderId == orderDTO.ID)
                    .Select(o => new ProductOrderDTO(
                        o.ID,
                        o.Product_Unit.Product.Name,
                        o.Product_Unit.Product.CategoryID,
                        o.Product_Unit.Product.Category.Name,
                        o.Product_Unit.Unit.Name,
                        o.Product_UnitID,
                        o.Product_Unit.ConversionRate,
                        o.Quantity,
                        o.Note,
                        o.OrderId,
                        o.Price
                    )
                    {
                        Status = DTO.Base.Status.None
                    }).ToList()
            );

            bs.DataSource = _products;
            dgv_ProductList.DataSource = bs;

            UpdateTotalPaymentRequired();
        }

        /// <summary>
        /// Khởi tạo danh sách sản phẩm mới rỗng cho đơn hàng mới
        /// </summary>
        private void InitializeNewProductList()
        {
            _products = new BindingList<ProductOrderDTO>();
            bs.DataSource = _products;
            dgv_ProductList.DataSource = bs;
        }

        /// <summary>
        /// Thiết lập data bindings giữa controls và properties
        /// Bao gồm:
        /// - Binding cho các combobox
        /// - Binding cho các numeric updown
        /// - Binding cho textbox ghi chú
        /// </summary>
        private void SetupDataBindings()
        {
            cbb_Categories.DataBindings.Add("Text", bs, "CategoryName", true, DataSourceUpdateMode.Never);
            cbb_Products.DataBindings.Add("Text", bs, "ProductName", true, DataSourceUpdateMode.Never);
            cbb_Units.DataBindings.Add("Text", bs, "UnitName", true, DataSourceUpdateMode.Never);
            nmr_ConversionRate.DataBindings.Add("Value", bs, "ConversionRate", true, DataSourceUpdateMode.Never);
            nmr_Quantity.DataBindings.Add("Value", bs, "Quantity", true, DataSourceUpdateMode.Never);
            rtb_ProductNote.DataBindings.Add("Text", bs, "Note", true, DataSourceUpdateMode.Never);
            nmr_Price.DataBindings.Add("Value", bs, "Price", true, DataSourceUpdateMode.Never);
        }

        #endregion

        #region Product Management

        /// <summary>
        /// Thêm sản phẩm mới vào đơn hàng với thông tin:
        /// - Tên sản phẩm
        /// - Danh mục
        /// - Đơn vị tính
        /// - Tỷ lệ quy đổi
        /// - Số lượng
        /// - Ghi chú
        /// - Giá bán
        /// </summary>
        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            var product = new ProductOrderDTO(
                    bs.Count + 1,
                    cbb_Products.Text,
                    (int)cbb_Categories.SelectedValue,
                    cbb_Categories.Text,
                    cbb_Units.Text,
                    selectedProductUnitId,
                    nmr_ConversionRate.Value,
                    Convert.ToInt32(nmr_Quantity.Value),
                    rtb_ProductNote.Text,
                    0,
                    nmr_Price.Value
            );

            product.Status = DTO.Base.Status.New;

            bs.Add(product);
            UpdateTotalPaymentRequired();
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm đã chọn trong đơn hàng
        /// Bao gồm cập nhật:
        /// - Thông tin sản phẩm
        /// - Số lượng
        /// - Đơn vị tính
        /// - Giá bán
        /// - Ghi chú
        /// </summary>
        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow?.DataBoundItem is ProductOrderDTO productOrderDTO)
            {
                productOrderDTO.ProductName = cbb_Products.Text;
                productOrderDTO.CategoryId = cbb_Products.SelectedValue != null ? (int)cbb_Products.SelectedValue : throw new Exception("Xin chọn sản phẩm");
                productOrderDTO.UnitName = cbb_Units.Text;
                productOrderDTO.ProductUnitId = selectedProductUnitId;
                productOrderDTO.ConversionRate = nmr_ConversionRate.Value;
                productOrderDTO.Quantity = Convert.ToInt32(nmr_Quantity.Value);
                productOrderDTO.Note = rtb_ProductNote.Text;
                productOrderDTO.Price = nmr_Price.Value;

                // Nếu sản phẩm mới được thêm vào thì không cập nhật trạng thái (giữ nguyên trạng thái)
                if (productOrderDTO.Status != DTO.Base.Status.New)
                {
                    productOrderDTO.Status = DTO.Base.Status.Modified;
                }

                bs.ResetBindings(false);
                UpdateTotalPaymentRequired();
            }
        }

        /// <summary>
        /// Xóa sản phẩm đã chọn khỏi đơn hàng
        /// Cập nhật lại tổng tiền sau khi xóa
        /// </summary>
        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow?.DataBoundItem is ProductOrderDTO productOrderDTO)
            {
                if (productOrderDTO.Status == DTO.Base.Status.New)
                {
                    bs.Remove(productOrderDTO);
                }
                else
                {
                    productOrderDTO.Status = DTO.Base.Status.Deleted;
                    bs.DataSource = _products.Where(p => p.Status != DTO.Base.Status.Deleted).ToList();
                    bs.ResetBindings(false);
                    dgv_ProductList.DataSource = bs;
                }
                UpdateTotalPaymentRequired();
            }
        }

        #endregion

        #region ComboBox Event Handlers

        /// <summary>
        /// Xử lý sự kiện khi thay đổi đơn vị tính
        /// - Cập nhật tỷ lệ quy đổi
        /// - Cập nhật giá bán theo đơn vị mới
        /// </summary>
        private void cbb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Units.SelectedItem is AddedProduct selectedUnit)
            {
                selectedProductUnitId = selectedUnit.ID;

                if (cbb_Products.SelectedItem is Models.Product selectedProduct)
                {
                    UpdateProductUnitDetails(selectedProduct);

                    // var productUnit = context.ProductUnits.Where(p => p.ProductID == selectedProduct.ID && p.UnitID == selectedUnit.ID).FirstOrDefault();
                    // if (productUnit != null)
                    // {
                    //     nmr_Price.Value = productUnit.UnitPrice;
                    //     nmr_ConversionRate.Value = productUnit.ConversionRate;
                    //     nmr_Quantity.Maximum = productUnit.Inventory != null ? productUnit.Inventory.Quantity : 0;
                    // }
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi sản phẩm
        /// - Cập nhật danh mục sản phẩm
        /// - Cập nhật danh sách đơn vị tính
        /// - Cập nhật giá bán mặc định
        /// </summary>
        private void cbb_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Products.SelectedItem is Models.Product selectedProduct)
            {
                var productUnit = context.ProductUnits
                    .Where(p => p.ProductID == selectedProduct.ID)
                    .Select(o => new AddedProduct(o.ID, o.Unit.ID, o.Unit.Name))
                    .ToList();

                if (productUnit != null)
                {
                    cbb_Units.DataSource = productUnit;
                    cbb_Units.DisplayMember = "UnitName";
                    cbb_Units.ValueMember = "UnitId";

                    UpdateProductUnitDetails(selectedProduct);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi danh mục
        /// - Lọc danh sách sản phẩm theo danh mục
        /// </summary>
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

        /// <summary>
        /// Xử lý sự kiện khi thay đổi khách hàng
        /// - Cập nhật địa chỉ giao hàng mặc định
        /// </summary>
        private void cbb_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Customer.SelectedItem is Models.Customer selectedCustomer)
            {
                tb_PhoneNumber.Text = selectedCustomer.PhoneNumber;
                tb_TypeCustomer.Text = selectedCustomer.Type;

                if (selectedCustomer.Type == "Doanh nghiệp")
                {
                    paymentMethod.Add("Ghi nợ");
                }
                else
                {
                    paymentMethod.Remove("Ghi nợ");
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi trạng thái đơn hàng
        /// - Cập nhật các controls liên quan đến trạng thái
        /// </summary>
        private void cbb_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustStatus();
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi phương thức thanh toán
        /// - Cập nhật các controls liên quan đến thanh toán
        /// </summary>
        private void cbb_PaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_PaymentMethods.SelectedText == "Ghi nợ")
            {
                // Xử lý khi chọn phương thức thanh toán ghi nợ
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Cập nhật thông tin chi tiết về đơn vị tính của sản phẩm
        /// - Lấy danh sách đơn vị tính
        /// - Cập nhật tỷ lệ quy đổi
        /// - Cập nhật giá bán theo đơn vị
        /// </summary>
        /// <param name="selectedProduct">Sản phẩm được chọn</param>
        private void UpdateProductUnitDetails(Models.Product selectedProduct)
        {
            if (cbb_Units.SelectedItem is AddedProduct selectedUnit)
            {
                var selectedUnitId = selectedUnit.ID;
                var _productUnit = context.ProductUnits
                    .Include(o => o.Inventory)
                    .Where(o => o.ProductID == selectedProduct.ID && o.ID == selectedUnitId)
                    .FirstOrDefault();

                if (_productUnit != null)
                {
                    nmr_ConversionRate.Value = _productUnit.ConversionRate;
                    nmr_Price.Value = _productUnit.UnitPrice;

                    var totalQuantity = context.ProductUnits
                        .Include(o => o.Inventory)
                        .Where(o => o.ProductID == selectedProduct.ID && o.ID == selectedUnitId)
                        .Sum(g => g.Inventory != null ? g.Inventory.Quantity : 0);

                    nmr_Quantity.Maximum = totalQuantity;
                }
            }
        }

        /// <summary>
        /// Điều chỉnh trạng thái đơn hàng và các controls liên quan
        /// - Thiết lập danh sách trạng thái có thể chọn
        /// - Cập nhật trạng thái mặc định
        /// </summary>
        private void AdjustStatus()
        {
            if (cbb_Customer.SelectedItem is Models.Customer)
            {
                List<string> allStatuses = new List<string>
                {
                    "Chờ xác nhận",
                    "Đã xác nhận",
                    "Đang chuẩn bị",
                    "Đã chuẩn bị xong",
                    "Đang giao hàng",
                    "Đã giao hàng",
                    "Đã nhận hàng",
                    "Đã hủy"
                };

                //Chỉ được chọn trạng thái theo thứ tự từ trên xuống dưới
                //Các trạng thái trước đó sẽ không được hiển thị

                int currentIndex = allStatuses.IndexOf(cbb_Status.Text);

                if (currentIndex != -1)
                {
                    List<string> availableStatuses = allStatuses.Skip(currentIndex).ToList();
                    cbb_Status.DataSource = availableStatuses;
                }
                else
                {
                    cbb_Status.DataSource = allStatuses;
                }
            }
        }

        /// <summary>
        /// Điều chỉnh phương thức thanh toán và các controls liên quan
        /// - Thiết lập danh sách phương thức thanh toán
        /// - Cập nhật phương thức mặc định
        /// </summary>
        private void AdjustPaymentMethods()
        {
            paymentMethod.Add("Tiền mặt");
            paymentMethod.Add("Chuyển khoản");

            cbb_PaymentMethods.DataSource = paymentMethod;
        }

        /// <summary>
        /// Cập nhật tổng số tiền cần thanh toán
        /// Tính toán dựa trên:
        /// - Giá bán của từng sản phẩm
        /// - Số lượng sản phẩm
        /// - Tỷ lệ quy đổi đơn vị
        /// </summary>
        private void UpdateTotalPaymentRequired()
        {
            totalPaymentRequired = _products.Sum(p => p.Quantity * p.Price);
            nmr_TotalPaymentRequired.Value = totalPaymentRequired;
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Lưu
        /// - Kiểm tra dữ liệu hợp lệ
        /// - Lưu thông tin đơn hàng vào database
        /// - Đóng form sau khi lưu thành công
        /// </summary>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Order addedOrder = new Models.Order()
            {
                CustomerID = Convert.ToInt32(cbb_Customer.SelectedValue),
                DeliveryAddress = rtb_DeliverAddress.Text,
                PaymentMethod = cbb_PaymentMethods.Text,
                OrderDate = dtpicker.Value,
                Status = cbb_Status.Text
            };

            if (orderDTO != null)
            {
                addedOrder.ID = orderDTO.ID;
            }

            this.Tag = addedOrder;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Hủy
        /// - Đóng form mà không lưu thay đổi
        /// </summary>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cbb_Categories.SelectedIndex = -1;
            cbb_Products.SelectedIndex = -1;
            cbb_Units.SelectedIndex = -1;
            nmr_ConversionRate.Value = 1;
            nmr_Quantity.Value = 1;
            nmr_Price.Value = 0;
            rtb_ProductNote.Text = "";
        }

        /// <summary>
        /// Xử lý sự kiện khi chuyển tab
        /// - Cập nhật dữ liệu cho tab được chọn
        /// - Tải danh sách phiếu xuất kho nếu cần
        /// </summary>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    if (orderDTO != null)
                    {
                        LoadReleaseList();
                    }
                    break;
            }
        }

        /// <summary>
        /// Tải danh sách phiếu xuất kho liên quan đến đơn hàng
        /// - Lọc theo ID đơn hàng
        /// - Hiển thị thông tin chi tiết phiếu xuất
        /// </summary>
        private void LoadReleaseList()
        {
            dgv_ReleaseList.DataSource = context.WarehouseReleaseNoteDetails
                .Include(o => o.WarehouseReleaseNote)
                .ThenInclude(o => o.CreatedBy)
                .Include(o => o.Product_Unit)
                .ThenInclude(o => o.Product)
                .Include(o => o.Product_Unit)
                    .ThenInclude(o => o.Unit)
                .Where(o => o.WarehouseReleaseNote.LinkedId == orderDTO.ID)
                .Select(o => new
                {
                    o.ID,
                    ReleasedProductName = o.Product_Unit.Product.Name,
                    UnitName = o.Product_Unit.Unit.Name,
                    o.Product_Unit.ConversionRate,
                    o.Quantity,
                    CreatedBy = o.WarehouseReleaseNote.CreatedBy.Name,
                    ReleaseDate = o.WarehouseReleaseNote.CreatedDate,
                    o.Note
                })
                .OrderByDescending(o => o.ReleaseDate)
                .ToList();
        }

        #endregion

        private void dgv_ProductList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_ProductList.Rows.Count)
            {
                var row = dgv_ProductList.Rows[e.RowIndex];
                if (row.DataBoundItem is ProductOrderDTO product)
                {
                    row.DefaultCellStyle.BackColor = Utils.DataGridView.GetStatusColor(product.Status);
                }
            }
        }
    }
}
