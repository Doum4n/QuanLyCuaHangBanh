using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.ComponentModel;
using System.Data;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Views.Invoice.PurchaseInvoice
{
    public partial class PurchaseInvoiceInputView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private BindingList<ProductPurchaseInvoiceDTO> _product = new BindingList<ProductPurchaseInvoiceDTO>();
        public BindingList<ProductPurchaseInvoiceDTO> Products => _product;

        private PurchaseInvoiceDTO? _purchaseInvoiceDTO;

        public BindingSource bs = new BindingSource();
        private int selectedProductUnitId;

        public event Func<object, EventArgs, int> ShowSelecteceiptFrom;

        private int accountPayableId;

        private decimal limitAmount = 0; // Assuming you will set this later

        private decimal totalPaymentRequired = 0;

        public PurchaseInvoiceInputView(PurchaseInvoiceDTO? purchaseInvoiceDTO = null)
        {
            InitializeComponent();
            _purchaseInvoiceDTO = purchaseInvoiceDTO;
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            var product = new ProductPurchaseInvoiceDTO(
                bs.Count + 1,
                0,
                cbb_Products.Text,
                (int)cbb_Categories.SelectedValue,
                cbb_Categories.Text,
                cbb_Units.Text,
                selectedProductUnitId,
                nmr_ConversionRate.Value,
                (int)nmr_Quantity.Value,
                rtb_ProductNote.Text,
                nmr_Price.Value
            );

            product.Status = DTO.Base.Status.New;

            _product.Add(product);

            UpdateTotalPaymentRequired();
            bs.ResetBindings(false);
        }

        public void AddProduct(ProductPurchaseInvoiceDTO productPurchaseInvoiceDTO)
        {
            bs.Add(productPurchaseInvoiceDTO);
            UpdateTotalPaymentRequired();
        }

        private void UpdateTotalPaymentRequired()
        {
            totalPaymentRequired = _product.Sum(p => p.Quantity * p.Price);
            nmr_TotalPaymentRequired.Value = totalPaymentRequired;
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (bs.Current is ProductPurchaseInvoiceDTO selectedProduct)
            {
                selectedProduct.ProductName = cbb_Products.Text;
                selectedProduct.CategoryId = (int)cbb_Categories.SelectedValue;
                selectedProduct.UnitName = cbb_Units.Text;
                selectedProduct.Quantity = (int)nmr_Quantity.Value;
                selectedProduct.Note = rtb_ProductNote.Text;
                selectedProduct.ConversionRate = nmr_ConversionRate.Value;
                selectedProduct.ProductUnitId = selectedProductUnitId;
                selectedProduct.Price = (int)nmr_Price.Value;

                selectedProduct.Status = DTO.Base.Status.Modified;
                UpdateTotalPaymentRequired();

                bs.ResetCurrentItem();
            }
        }

        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (bs.Current is ProductPurchaseInvoiceDTO selectedProduct)
            {
                if (selectedProduct.Status == DTO.Base.Status.None)
                {
                    //bs.Remove(selectedProduct);
                    selectedProduct.Status = DTO.Base.Status.Deleted;

                    bs.DataSource = new BindingList<ProductPurchaseInvoiceDTO>(
                        _product.Where(p => p.Status != DTO.Base.Status.Deleted).ToList()
                    );

                    UpdateTotalPaymentRequired();

                    bs.ResetBindings(false);
                }
            }
        }

        private void PurchaseInvoiceInputView_Load(object sender, EventArgs e)
        {
            cbb_Categories.DataSource = context.Categories.ToList();
            cbb_Categories.DisplayMember = "Name";
            cbb_Categories.ValueMember = "Id";

            cbb_Products.DataSource = context.Products.ToList();
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "Id";

            cbb_Units.DataSource = context.Units.ToList();
            cbb_Units.DisplayMember = "Name";
            cbb_Units.ValueMember = "Id";

            cbb_Suppliers.DataSource = context.Suppliers.ToList();
            cbb_Suppliers.DisplayMember = "Name";
            cbb_Suppliers.ValueMember = "Id";

            List<String> status = new List<string>()
            {
                "Chờ xác nhận",
                "Đã xác nhận",
                "Đã hủy",
                "Đang giao hàng",
                "Đã giao hàng",
                "Hoàn tất"
            };

            cbb_Status.DataSource = status;

            List<String> paymentMethod = new List<string>() {
                "Tiền mặt",
                "Chuyển khoản",
                "Ghi nợ"
            };

            cbb_PaymentMethod.DataSource = paymentMethod;

            limitAmount = context.Suppliers
                .Where(s => s.ID == (int)cbb_Suppliers.SelectedValue)
                .Select(s => s.Limit)
                .FirstOrDefault();

            if (_purchaseInvoiceDTO != null)
            {
                cbb_Suppliers.SelectedValue = _purchaseInvoiceDTO.SupplierID;
                cbb_Status.SelectedItem = _purchaseInvoiceDTO.Status;
                dateTimePicker.Value = _purchaseInvoiceDTO.CreatedDate;
                rtb_Note.Text = _purchaseInvoiceDTO.Note ?? string.Empty;

                _product = new BindingList<ProductPurchaseInvoiceDTO>(context.PurchaseInvoiceDetails
                    .Where(p => p.InvoiceID == _purchaseInvoiceDTO.ID)
                    .Select(p => new ProductPurchaseInvoiceDTO(
                        p.ID,
                        p.InvoiceID,
                        p.Product_Unit.Product.Name,
                        p.Product_Unit.Product.CategoryID,
                        p.Product_Unit.Product.Category.Name,
                        p.Product_Unit.Unit.Name,
                        p.Product_Unit.ID,
                        p.Product_Unit.ConversionRate,
                        p.Quantity,
                        p.Note ?? string.Empty,
                        p.UnitCost
                    )
                    {
                        Status = DTO.Base.Status.None
                    }).ToList()
                );

                bs.DataSource = _product;
                dgv_ProductList.DataSource = bs;

                nmr_TotalPaymentRequired.Value = _product.Sum(p => p.Quantity * p.Price);

                var accountPayable = context.AccountsPayables.FirstOrDefault(a => a.InvoiceID == _purchaseInvoiceDTO.ID);

                if (accountPayable != null)
                {
                    accountPayableId = accountPayable.ID;
                    nmr_TotalAmountOwed.Value = accountPayable.Amount;
                    nmr_TotalPaid.Maximum = nmr_TotalPaymentRequired.Value;
                    nmr_TotalPaid.Value = nmr_TotalPaymentRequired.Value - nmr_TotalAmountOwed.Value;
                    dtp_TransactionDate.Value = accountPayable.TransactionDate;
                    dtp_DueDate.Value = dtp_TransactionDate.Value.AddDays(_purchaseInvoiceDTO.CreditPeriod);

                    if (accountPayable.PaidDate != null)
                    {
                        dtp_PaymentDate.Value = accountPayable.PaidDate.Value;
                    }
                    else
                    {
                        dtp_PaymentDate.Format = DateTimePickerFormat.Custom;
                        dtp_PaymentDate.CustomFormat = " "; // Hiển thị rỗng
                    }
                }
            }
            else
            {
                _product = new BindingList<ProductPurchaseInvoiceDTO>();
                bs.DataSource = _product;
                dgv_ProductList.DataSource = bs;
            }

            cbb_Products.DataBindings.Add("Text", bs, "ProductName", true, DataSourceUpdateMode.Never);
            cbb_Categories.DataBindings.Add("Text", bs, "CategoryName", true, DataSourceUpdateMode.Never);
            cbb_Units.DataBindings.Add("Text", bs, "UnitName", true, DataSourceUpdateMode.Never);
            nmr_Quantity.DataBindings.Add("Value", bs, "Quantity", true, DataSourceUpdateMode.Never);
            rtb_ProductNote.DataBindings.Add("Text", bs, "Note", true, DataSourceUpdateMode.Never);
            nmr_ConversionRate.DataBindings.Add("Value", bs, "ConversionRate", true, DataSourceUpdateMode.Never);
            nmr_Price.DataBindings.Add("Value", bs, "Price", true, DataSourceUpdateMode.Never);

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
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.PurchaseInvoice purchaseInvoice = new Models.PurchaseInvoice()
            {
                ID = 0, // Invoice chưa được tạo
                EmployeeID = 1, // Assuming you will set this later
                SupplierID = (int)cbb_Suppliers.SelectedValue,
                Date = dateTimePicker.Value.ToUniversalTime(),
                Status = cbb_Status.Text,
                Note = rtb_Note.Text,
            };

            if (_purchaseInvoiceDTO != null)
            {
                purchaseInvoice.ID = _purchaseInvoiceDTO.ID;
            }

            var amount = nmr_TotalPaymentRequired.Value - nmr_TotalPaid.Value;
            if (amount < 0 && nmr_TotalPaid.Value > nmr_TotalPaymentRequired.Value)
            {
                MessageBox.Show("Số tiền đã thanh toán không thể lớn hơn tổng số tiền cần thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (amount < 0)
            {
                MessageBox.Show("Số tiền đã thanh toán không thể lớn hơn tổng số tiền cần thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AccountsPayable accountsPayable = new AccountsPayable()

            {
                SupplierID = (int)cbb_Suppliers.SelectedValue,
                Amount = amount, // Calculating the amount owed
                TransactionDate = dtp_TransactionDate.Value.ToUniversalTime(),
                DueDate = dtp_DueDate.Value.ToUniversalTime(),
                IsPaid = nmr_TotalPaid.Value >= nmr_TotalPaymentRequired.Value, // Assuming payment is made if total paid is greater than or equal to total required
                // Note = rtb_Note.Text,
            };

            if (accountsPayable.IsPaid)
            {
                accountsPayable.PaidDate = DateTime.Now.ToUniversalTime();
            }
            else
            {
                accountsPayable.PaidDate = null; // If not paid, set PaidDate to null
            }

            if (_purchaseInvoiceDTO != null)
            {
                accountsPayable.ID = accountPayableId;
            }

            this.Tag = (purchaseInvoice, accountsPayable);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_SelectReceiptNote_Click(object sender, EventArgs e)
        {
            ShowSelecteceiptFrom?.Invoke(this, new EventArgs());
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
            cbb_Products.Text = string.Empty;
            cbb_Categories.Text = string.Empty;
            cbb_Units.Text = string.Empty;
            nmr_Quantity.Value = 0;
            rtb_ProductNote.Text = string.Empty;
            nmr_ConversionRate.Value = 1;
            nmr_Price.Value = 0;
            nmr_TotalPaymentRequired.Value = 0;
            nmr_TotalAmountOwed.Value = 0;
            nmr_TotalPaid.Value = 0;
            dtp_TransactionDate.Value = DateTime.Now;
            dtp_DueDate.Value = DateTime.Now;
            dtp_PaymentDate.Value = DateTime.Now;
            cbb_Status.SelectedItem = "Chờ xác nhận";
            cbb_PaymentMethod.SelectedItem = "Tiền mặt";
            cbb_Suppliers.SelectedItem = null;
            _product.Clear();
            bs.ResetBindings(false);
            bs.DataSource = _product;
            dgv_ProductList.DataSource = bs;
        }

        private void nmr_Quantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbb_PaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_PaymentMethod.Text == "Ghi nợ")
            {
                pane_Payment.Visible = true;
            }
            else
            {
                pane_Payment.Visible = false;
            }
        }
    }
}
