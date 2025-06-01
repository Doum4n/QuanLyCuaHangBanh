using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.ComponentModel;
using System.Data;

namespace QuanLyCuaHangBanh.Views.Order
{
    /// <summary>
    /// Form nhập liệu cho đơn hàng
    /// </summary>
    public partial class OrderInputView : Form
    {
        #region Fields & Properties

        // Database context
        private QLCHB_DBContext context = new QLCHB_DBContext();
        
        // DTO chứa thông tin đơn hàng
        private OrderDTO? orderDTO;

        // Binding sources cho danh sách sản phẩm
        private BindingSource bs = new BindingSource();
        private BindingList<ProductOrderDTO> _products = new BindingList<ProductOrderDTO>();
        public BindingList<ProductOrderDTO> Products => _products;

        // ID của đơn vị sản phẩm được chọn
        private int selectedProductUnitId = 0;

        // Tổng tiền cần thanh toán
        private decimal totalPaymentRequired = 0;

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

            // Thiết lập data bindings
            SetupDataBindings();
        }

        #endregion

        #region Data Loading Methods

        /// <summary>
        /// Nạp dữ liệu cho các combobox
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
        /// Nạp thông tin đơn hàng hiện có
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
        /// Khởi tạo danh sách sản phẩm mới
        /// </summary>
        private void InitializeNewProductList()
        {
            _products = new BindingList<ProductOrderDTO>();
            bs.DataSource = _products;
            dgv_ProductList.DataSource = bs;
        }

        /// <summary>
        /// Thiết lập data bindings
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
        /// Thêm sản phẩm mới vào đơn hàng
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
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow?.DataBoundItem is ProductOrderDTO productOrderDTO)
            {
                productOrderDTO.ProductName = cbb_Products.Text;
                productOrderDTO.CategoryId = cbb_Products.SelectedValue != null ? 
                    (int)cbb_Products.SelectedValue : 
                    throw new Exception("Xin chọn sản phẩm");
                productOrderDTO.UnitName = cbb_Units.Text;
                productOrderDTO.ProductUnitId = selectedProductUnitId;
                productOrderDTO.ConversionRate = nmr_ConversionRate.Value;
                productOrderDTO.Quantity = Convert.ToInt32(nmr_Quantity.Value);
                productOrderDTO.Note = rtb_ProductNote.Text;
                productOrderDTO.Price = nmr_Price.Value;
                productOrderDTO.Status = DTO.Base.Status.Modified;
                
                bs.ResetBindings(false);
                UpdateTotalPaymentRequired();
            }
        }

        /// <summary>
        /// Xóa sản phẩm khỏi đơn hàng
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

        private void cbb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Units.SelectedItem is AddedProduct selectedUnit)
            {
                selectedProductUnitId = selectedUnit.ID;

                if (cbb_Products.SelectedItem is Models.Product selectedProduct)
                {
                    UpdateProductUnitDetails(selectedProduct);
                }
            }
        }

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

        private void cbb_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Customer.SelectedItem is Models.Customer selectedCustomer)
            {
                tb_PhoneNumber.Text = selectedCustomer.PhoneNumber;
            }
        }

        private void cbb_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustStatus();
        }

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
        /// Cập nhật chi tiết đơn vị sản phẩm
        /// </summary>
        private void UpdateProductUnitDetails(Models.Product selectedProduct)
        {
            var selectedUnitId = Convert.ToInt32(cbb_Units.SelectedValue);
            var _productUnit = context.ProductUnits
                .Include(o => o.Inventory)
                .Where(o => o.ProductID == selectedProduct.ID && o.UnitID == selectedUnitId)
                .FirstOrDefault();

            if (_productUnit != null)
            {
                nmr_ConversionRate.Value = _productUnit.ConversionRate;
                nmr_Price.Value = _productUnit.UnitPrice;

                var totalQuantity = context.ProductUnits
                    .Include(o => o.Inventory)
                    .Where(o => o.ProductID == selectedProduct.ID && o.UnitID == selectedUnitId)
                    .Sum(g => g.Inventory != null ? g.Inventory.Quantity : -1);

                nmr_Quantity.Maximum = totalQuantity != -1 ? 
                    totalQuantity : 
                    throw new Exception("Không tìm thấy kho hàng");

                nmr_ConversionRate.Value = _productUnit.ConversionRate;
            }
        }

        /// <summary>
        /// Điều chỉnh trạng thái đơn hàng
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
        /// Thiết lập phương thức thanh toán
        /// </summary>
        private void AdjustPaymentMethods()
        {
            List<string> paymentMethod = new List<string>()
            {
                "Tiền mặt",
                "Chuyển khoản",
                "Thẻ tín dụng",
            };

            cbb_PaymentMethods.DataSource = paymentMethod;
        }

        /// <summary>
        /// Cập nhật tổng tiền cần thanh toán
        /// </summary>
        private void UpdateTotalPaymentRequired()
        {
            totalPaymentRequired = _products.Sum(p => p.Quantity * p.Price);
            nmr_TotalPaymentRequired.Value = totalPaymentRequired;
        }

        #endregion

        #region Form Events

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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Xử lý khi nhấn nút hủy
        }

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
        /// Nạp danh sách phiếu xuất kho
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
    }
}
