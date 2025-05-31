using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.ComponentModel;
using System.Data;

namespace QuanLyCuaHangBanh.Views.Order
{
    public partial class OrderInputView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private OrderDTO? orderDTO;

        private BindingSource bs = new BindingSource();
        BindingList<ProductOrderDTO> _products = new BindingList<ProductOrderDTO>();
        public BindingList<ProductOrderDTO> Products => _products;

        private int selectedProductUnitId = 0;

        private decimal totalPaymentRequired = 0;

        public OrderInputView(OrderDTO? orderDTO = null)
        {
            InitializeComponent();
            this.orderDTO = orderDTO;
        }

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

        private void OrderInputView_Load(object sender, EventArgs e)
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

            AdjustStatus();

            AdjustPaymentMethods();

            if (orderDTO != null)
            {
                MessageBox.Show("Chỉnh sửa đơn hàng: " + orderDTO.ID, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //tb_PhoneNumber.Text = order.;
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

                cbb_Categories.DataBindings.Add("Text", bs, "CategoryName", true, DataSourceUpdateMode.OnPropertyChanged);
                cbb_Products.DataBindings.Add("Text", bs, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged);
                cbb_Units.DataBindings.Add("Text", bs, "UnitName", true, DataSourceUpdateMode.OnPropertyChanged);
                nmr_ConversionRate.DataBindings.Add("Value", bs, "ConversionRate", true, DataSourceUpdateMode.OnPropertyChanged);
                nmr_Quantity.DataBindings.Add("Value", bs, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
                rtb_ProductNote.DataBindings.Add("Text", bs, "Note", true, DataSourceUpdateMode.OnPropertyChanged);
                nmr_Price.DataBindings.Add("Value", bs, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            else
            {
                _products = new BindingList<ProductOrderDTO>();
                bs.DataSource = _products;
                dgv_ProductList.DataSource = bs;
            }
        }

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
                    0, // Assuming OrderId is 0 for new products,
                    nmr_Price.Value
            );

            product.Status = DTO.Base.Status.New;

            bs.Add(product);
        }

        private void AdjustStatus()
        {
            if (cbb_Customer.SelectedItem is Models.Customer selectedCustomer)
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

                // Find the index of the current status
                int currentIndex = allStatuses.IndexOf(cbb_Status.Text);

                if (currentIndex != -1)
                {
                    // Create a new list containing statuses from the current one onwards
                    List<string> availableStatuses = allStatuses.Skip(currentIndex).ToList();
                    cbb_Status.DataSource = availableStatuses;
                }
                else
                {
                    // If the current status text isn't found in the list,
                    // perhaps set the data source to the full list or handle as an error
                    cbb_Status.DataSource = allStatuses;
                }
            }
        }

        private void UpdateTotalPaymentRequired()
        {
            totalPaymentRequired = _products.Sum(p => p.Quantity * p.Price);
            nmr_TotalPaymentRequired.Value = totalPaymentRequired;
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow != null && dgv_ProductList.CurrentRow.DataBoundItem is ProductOrderDTO productOrderDTO)
            {
                productOrderDTO.ProductName = cbb_Products.Text;
                productOrderDTO.CategoryId = (int)cbb_Products.SelectedValue;
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

        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow != null && dgv_ProductList.CurrentRow.DataBoundItem is ProductOrderDTO productOrderDTO)
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
                    UpdateTotalPaymentRequired();
                }
            }
        }

        private void cbb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Units.SelectedItem is AddedProduct selectedUnit)
            {
                selectedProductUnitId = selectedUnit.ID;


            }
        }

        private void cbb_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Products.SelectedItem is Models.Product selectedProduct)
            {
                var productUnit = context.ProductUnits.Where(p => p.ProductID == selectedProduct.ID).Select(o => new AddedProduct(o.ID, o.Unit.ID, o.Unit.Name)).ToList();
                if (productUnit != null)
                {
                    cbb_Units.DataSource = productUnit;
                    cbb_Units.DisplayMember = "UnitName";
                    cbb_Units.ValueMember = "UnitId";

                    var _productUnit = context.ProductUnits.Include(o => o.Inventory).
                        FirstOrDefault(o => o.UnitID == Convert.ToInt32(cbb_Units.SelectedValue) && o.ProductID == Convert.ToInt32(selectedProduct.ID));
                    if (_productUnit != null)
                    {
                        nmr_ConversionRate.Value = _productUnit.ConversionRate;
                        nmr_Price.Value = _productUnit.UnitPrice;
                        nmr_Quantity.Maximum = _productUnit.Inventory.Quantity; // Assuming you want to limit the quantity to available stock
                    }
                }
            }
        }

        private void cbb_PaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_PaymentMethods.SelectedText == "Ghi nợ")
            {
                // Handle payment method selection if needed
            }
        }

        private void cbb_Categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Categories.SelectedItem is Models.Category selectedCategory)
            {
                cbb_Products.DataSource = context.Products.Where(p => p.CategoryID == selectedCategory.ID).ToList();
                cbb_Products.DisplayMember = "Name";
                cbb_Products.ValueMember = "ID";

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {

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
    }
}
