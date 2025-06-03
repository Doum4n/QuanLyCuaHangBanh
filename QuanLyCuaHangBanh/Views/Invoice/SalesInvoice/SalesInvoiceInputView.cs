using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views.Invoice.SalesInvoice;

namespace QuanLyCuaHangBanh.Views.Invoice
{
    public partial class SalesInvoiceInputView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private SaleInvoiceDTO? _invoiceDTO;
        private BindingSource bs = new BindingSource();
        BindingList<ProductSaleInvoiceDTO> _products = new BindingList<ProductSaleInvoiceDTO>();
        public BindingList<ProductSaleInvoiceDTO> Products => _products;

        public event Func<object, EventArgs, int> ShowSelectOrderForm;

        List<string> paymentMethods = new List<string>();

        private int selectedProductUnitId = 0;

        private int accountsReceivableId = 0;

        private decimal totalPaymentRequired = 0;

        public SalesInvoiceInputView(SaleInvoiceDTO? invoiceDTO = null)
        {
            InitializeComponent();
            _invoiceDTO = invoiceDTO;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            AccountsReceivable? accountsReceivable = null;
            if (cbb_PaymentMethod.Text == "Ghi nợ")
            {
                var customerId = cbb_Customers.SelectedValue != null ? (int)cbb_Customers.SelectedValue : throw new InvalidOperationException("Please select a customer");
                accountsReceivable = new AccountsReceivable
                {
                    CustomerID = customerId,
                    Amount = nmr_TotalPaymentRequired.Value - nmr_TotalPaid.Value,
                    TransactionDate = dateTimePicker.Value.ToUniversalTime(),
                    DueDate = dtp_DueDate.Value.ToUniversalTime(),
                    IsPaid = nmr_TotalPaid.Value >= nmr_TotalPaymentRequired.Value,
                    PaidDate = dtp_TransactionDate.Value.ToUniversalTime()
                };
            }

            Models.SalesInvoice salesInvoice = new Models.SalesInvoice()
            {
                Date = dateTimePicker.Value,
                EmployeeID = Session.EmployeeId,
                CustomerID = cbb_Customers.SelectedValue != null ? (int)cbb_Customers.SelectedValue : throw new InvalidOperationException("Please select a customer"),
                PaymentMethod = cbb_PaymentMethod.Text,
                Status = cbb_Status.Text,
                Note = rtb_Note.Text,
            };

            if (_invoiceDTO != null && accountsReceivable != null)
            {
                // salesInvoice.ID = _invoiceDTO.ID;  // Cập nhật ID từ PresePresenter
                accountsReceivable.ID = accountsReceivableId;
                accountsReceivable.InvoiceID = _invoiceDTO.ID;
            }

            this.Tag = new SalesInvoiceData(salesInvoice, accountsReceivable);  // AccountsReceivable có thể null khi không phải Ghi nợ
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            var productSaleInvoiceDTO = new ProductSaleInvoiceDTO(
                0,
                cbb_Products.Text,
                cbb_Categories.SelectedValue != null ? (int)cbb_Categories.SelectedValue : throw new InvalidOperationException("Please select a category"),
                cbb_Categories.Text,
                cbb_Units.Text,
                selectedProductUnitId,
                nmr_ConversionRate.Value, // Assuming a default conversion rate of 1
                (int)nmr_Quantity.Value,
                rtb_ProductNote.Text,
                nmr_Price.Value,
                0, // không cần customerId
                string.Empty // không cần paymentMethod
            );

            productSaleInvoiceDTO.Status = Status.New; // Set default status to Active

            bs.Add(productSaleInvoiceDTO);
            UpdateTotalPaymentRequired();
        }

        private void UpdateTotalPaymentRequired()
        {
            totalPaymentRequired = _products.Sum(p => p.Quantity * p.Price);
            nmr_TotalPaymentRequired.Value = totalPaymentRequired;
        }

        public void AddProduct(ProductSaleInvoiceDTO productSaleInvoiceDTO)
        {
            bs.Add(productSaleInvoiceDTO);
            UpdateTotalPaymentRequired();

            cbb_Customers.SelectedValue = productSaleInvoiceDTO.CategoryId;
            cbb_PaymentMethod.Text = productSaleInvoiceDTO.PaymentMethod;
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow != null && dgv_ProductList.CurrentRow.DataBoundItem is ProductSaleInvoiceDTO selectedProduct)
            {
                selectedProduct.ProductName = cbb_Products.Text;
                selectedProduct.CategoryId = cbb_Categories.SelectedValue != null ? (int)cbb_Categories.SelectedValue : throw new InvalidOperationException("Please select a category");
                selectedProduct.CategoryName = cbb_Categories.Text;
                selectedProduct.UnitName = cbb_Units.Text;
                selectedProduct.ProductUnitId = selectedProductUnitId;
                selectedProduct.ConversionRate = nmr_ConversionRate.Value;
                selectedProduct.Quantity = (int)nmr_Quantity.Value;
                selectedProduct.Note = rtb_ProductNote.Text;
                selectedProduct.Price = nmr_Price.Value;

                selectedProduct.Status = Status.Modified; // Set status to Updated
                UpdateTotalPaymentRequired();
                bs.ResetBindings(false);
            }
        }

        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow != null && dgv_ProductList.CurrentRow.DataBoundItem is ProductSaleInvoiceDTO selectedProduct)
            {
                if (selectedProduct.Status == Status.New)
                {
                    // If the product is new, just remove it from the list
                    bs.Remove(selectedProduct);
                }
                else
                {
                    // If the product is already saved, mark it as deleted
                    selectedProduct.Status = Status.Deleted;
                    bs.DataSource = _products.Where(p => p.Status != Status.Deleted).ToList(); // Filter out deleted products
                    UpdateTotalPaymentRequired();
                    bs.ResetBindings(false); // Refresh the DataGridView to reflect the change
                }
            }
        }

        private void InvoiceInputView_Load(object sender, EventArgs e)
        {
            cbb_Customers.DataSource = context.Customers.ToList();
            cbb_Customers.DisplayMember = "Name";
            cbb_Customers.ValueMember = "ID";

            cbb_Categories.DataSource = context.Categories.ToList();
            cbb_Categories.DisplayMember = "Name";
            cbb_Categories.ValueMember = "ID";

            cbb_Products.DataSource = context.Products.ToList();
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";

            cbb_Units.DataSource = context.Units.ToList();
            cbb_Units.DisplayMember = "Name";
            cbb_Units.ValueMember = "ID";

            paymentMethods = new List<string>()
            {
                "Tiền mặt",
                "Chuyển khoản",
                "Thẻ tín dụng",
                // "Ghi nợ"
            };
            cbb_PaymentMethod.DataSource = paymentMethods;

            List<string> statuses = new List<string>()
            {
                "Đã thanh toán",
                "Chưa thanh toán",
                "Đã thanh toán một phần"
            };
            cbb_Status.DataSource = statuses;

            CreatorName.Text = Session.EmployeeName;

            if (_invoiceDTO != null)
            {
                // cbb_Customers.Text = _invoiceDTO.;
                cbb_Customers.SelectedValue = _invoiceDTO.CustomerID;
                dateTimePicker.Value = _invoiceDTO.CreatedDate;
                cbb_PaymentMethod.Text = _invoiceDTO.PaymentMethod;
                rtb_Note.Text = _invoiceDTO.Note;

                _products = new BindingList<ProductSaleInvoiceDTO>(
                    context.SalesInvoiceDetails
                    .Where(o => o.InvoiceID == _invoiceDTO.ID)
                    .Select(
                        o => new ProductSaleInvoiceDTO(
                            o.ID,
                            o.Product_Unit.Product.Name,
                            o.Product_Unit.Product.CategoryID,
                            o.Product_Unit.Product.Category.Name,
                            o.Product_Unit.Unit.Name,
                            o.Product_Unit.ID,
                            o.Product_Unit.ConversionRate,
                            o.Quantity,
                            o.Note ?? "",
                            o.UnitPrice,
                            0, // không cần customerId
                            string.Empty // không cần paymentMethod
                        )
                        {
                            Status = Status.None // Assuming existing products are active by default
                        }
                    ).ToList()
                );

                bs.DataSource = _products;
                dgv_ProductList.DataSource = bs;

                nmr_TotalPaymentRequired.Value = _products.Sum(p => p.Quantity * p.Price);

                var accountsReceivable = context.AccountsReceivables.FirstOrDefault(a => a.InvoiceID == _invoiceDTO.ID);
                if (accountsReceivable != null)
                {
                    accountsReceivableId = accountsReceivable.ID;
                    nmr_TotalAmountOwed.Value = accountsReceivable.Amount;
                    nmr_TotalPaid.Value = nmr_TotalPaymentRequired.Value - nmr_TotalAmountOwed.Value;
                    nmr_TotalPaid.Maximum = nmr_TotalPaymentRequired.Value;
                    dtp_TransactionDate.Value = accountsReceivable.TransactionDate;
                    dtp_DueDate.Value = dtp_TransactionDate.Value.AddDays(_invoiceDTO.CreditPeriod);

                    if (accountsReceivable.PaidDate != null)
                    {
                        dtp_PaymentDate.Value = accountsReceivable.PaidDate.Value;
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
                bs.DataSource = _products;
                dgv_ProductList.DataSource = bs;
            }

            cbb_Categories.DataBindings.Add("SelectedValue", bs, "CategoryId", true, DataSourceUpdateMode.Never);
            cbb_Products.DataBindings.Add("Text", bs, "ProductName", true, DataSourceUpdateMode.Never);
            cbb_Units.DataBindings.Add("Text", bs, "UnitName", true, DataSourceUpdateMode.Never);
            nmr_ConversionRate.DataBindings.Add("Value", bs, "ConversionRate", true, DataSourceUpdateMode.Never);
            nmr_Quantity.DataBindings.Add("Value", bs, "Quantity", true, DataSourceUpdateMode.Never);
            rtb_ProductNote.DataBindings.Add("Text", bs, "Note", true, DataSourceUpdateMode.Never);
            nmr_Price.DataBindings.Add("Value", bs, "Price", true, DataSourceUpdateMode.Never);
            // rtb_Note.DataBindings.Add("Text", bs, "Note", true, DataSourceUpdateMode.Never);

            Utils.DataGridView.HideColumn(dgv_ProductList, new string[] { "Status", "CategoryID", "ID", "ProductUnitID", "InvoiceID", "PaymentMethod", "CustomerID" });
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

        private void cbb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Units.SelectedItem is AddedProduct selectedUnit)
            {
                selectedProductUnitId = selectedUnit.ID;

                var productUnit = context.ProductUnits.Find(selectedProductUnitId);
                if (productUnit != null)
                {
                    nmr_Price.Value = productUnit.UnitPrice;
                    nmr_ConversionRate.Value = productUnit.ConversionRate;
                }
            }
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

        private void cbb_Customers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Customers.SelectedItem is Models.Customer selectedCustomer)
            {
                if (selectedCustomer.Type == "Doanh nghiệp")
                {
                    if (!paymentMethods.Contains("Ghi nợ"))
                        paymentMethods.Add("Ghi nợ");
                }
                else
                {
                    paymentMethods.Remove("Ghi nợ");
                }
            }
            cbb_PaymentMethod.DataSource = null;
            cbb_PaymentMethod.DataSource = paymentMethods;
        }

        private void rbtn_Order_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_Order.Checked)
            {
                ShowSelectOrderForm?.Invoke(sender, e);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            cbb_Products.Text = string.Empty;
            cbb_Categories.Text = string.Empty;
            cbb_Units.Text = string.Empty;
            nmr_Quantity.Value = 0;
            rtb_ProductNote.Text = string.Empty;
            nmr_ConversionRate.Value = 0;
            nmr_Price.Value = 0;
            cbb_Status.SelectedItem = "Chưa thanh toán";
            cbb_PaymentMethod.SelectedItem = "Tiền mặt";
            cbb_Customers.SelectedItem = null;
            // _products.Clear();
            // bs.ResetBindings(false);
            // bs.DataSource = _products;
            // dgv_ProductList.DataSource = bs;
        }

        private void dgv_ProductList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv_ProductList.Rows.Count)
            {
                var row = dgv_ProductList.Rows[e.RowIndex];
                if (row.DataBoundItem is ProductSaleInvoiceDTO product)
                {
                    row.DefaultCellStyle.BackColor = Utils.DataGridView.GetStatusColor(product.Status);
                }
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
    }
}
