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

namespace QuanLyCuaHangBanh.Views.Invoice
{
    public partial class SalesInvoiceInputView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private InvoiceDTO? _invoiceDTO;

        private BindingSource bs = new BindingSource();
        BindingList<ProductSaleInvoiceDTO> _products = new BindingList<ProductSaleInvoiceDTO>();
        public BindingList<ProductSaleInvoiceDTO> Products => _products;

        private int selectedProductUnitId = 0;

        public SalesInvoiceInputView(InvoiceDTO? invoiceDTO = null)
        {
            InitializeComponent();
            _invoiceDTO = invoiceDTO;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.SalesInvoice salesInvoice = new Models.SalesInvoice()
            {
                Date = dateTimePicker.Value,
                EmployeeID = 1,
                CustomerID = (int)cbb_Customers.SelectedValue,
                PaymentMethod = cbb_PaymentMethod.Text,
                Status = cbb_Status.Text
            };

            this.Tag = salesInvoice;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            bs.Add(
                new ProductSaleInvoiceDTO(
                    0,
                    cbb_Products.Text,
                    (int)cbb_Categories.SelectedValue,
                    cbb_Categories.Text,
                    cbb_Units.Text,
                    selectedProductUnitId,
                    nmr_ConversionRate.Value, // Assuming a default conversion rate of 1
                    (int)nmr_Quantity.Value,
                    rtb_ProductNote.Text,
                    nmr_Price.Value
                )
            );
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow != null && dgv_ProductList.CurrentRow.DataBoundItem is ProductSaleInvoiceDTO selectedProduct)
            {
                selectedProduct.ProductName = cbb_Products.Text;
                selectedProduct.CategoryId = (int)cbb_Categories.SelectedValue;
                selectedProduct.CategoryName = cbb_Categories.Text;
                selectedProduct.UnitName = cbb_Units.Text;
                selectedProduct.ProductUnitId = selectedProductUnitId;
                selectedProduct.ConversionRate = nmr_ConversionRate.Value;
                selectedProduct.Quantity = (int)nmr_Quantity.Value;
                selectedProduct.Note = rtb_Note.Text;
                selectedProduct.Price = nmr_Price.Value;
                bs.ResetBindings(false);
            }
        }

        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow != null && dgv_ProductList.CurrentRow.DataBoundItem is ProductSaleInvoiceDTO selectedProduct)
            {
                bs.Remove(selectedProduct);
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

            List<string> paymentMethods = new List<string>()
            {
                "Cash",
                "Credit Card",
                "Bank Transfer"
            };
            cbb_PaymentMethod.DataSource = paymentMethods;

            List<string> statuses = new List<string>()
            {
                "Paid",
                "Unpaid",
                "Refunded"
            };
            cbb_Status.DataSource = statuses;

            if (_invoiceDTO != null)
            {

                dateTimePicker.Value = _invoiceDTO.CreatedDate;

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
                            o.Note,
                            o.UnitPrice
                        )
                    ).ToList()
                );

                bs.DataSource = _products;
                dgv_ProductList.DataSource = bs;
            }
            else
            {
                bs.DataSource = _products;
                dgv_ProductList.DataSource = bs;
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

        private void cbb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Units.SelectedItem is AddedProduct selectedUnit)
            {
                selectedProductUnitId = selectedUnit.ID;
            }
        }
    }
}
