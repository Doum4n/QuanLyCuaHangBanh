using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangBanh.DTO.Base;

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

        public event Action<ProductPurchaseInvoiceDTO> AddProductEvent;
        public event Func<object, EventArgs, int> ShowSelecteceiptFrom;

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
            bs.ResetBindings(false);
        }

        public void InvokeAddProductEvent(ProductPurchaseInvoiceDTO product)
        {
            AddProductEvent?.Invoke(product);
        }

        public void AddProduct(ProductPurchaseInvoiceDTO productPurchaseInvoiceDTO)
        {
            bs.Add(productPurchaseInvoiceDTO);
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

                    dgv_ProductList.DataSource = new BindingList<ProductPurchaseInvoiceDTO>(
                        _product.Where(p => p.Status != DTO.Base.Status.Deleted).ToList()
                    );
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
                "Thẻ tín dụng",
                "Ví điện tử"
            };

            cbb_PaymentMethod.DataSource = paymentMethod;

            if (_purchaseInvoiceDTO != null)
            {
                cbb_Suppliers.SelectedValue = _purchaseInvoiceDTO.SupplierID;
                cbb_Status.SelectedItem = _purchaseInvoiceDTO.Status;
                dateTimePicker.Value = _purchaseInvoiceDTO.CreatedDate;

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
                        p.Note,
                        p.UnitCost
                    )
                    {
                        Status = DTO.Base.Status.None
                    }).ToList()
                );

                bs.DataSource = _product;
                dgv_ProductList.DataSource = bs;
            }
            else
            {
                _product = new BindingList<ProductPurchaseInvoiceDTO>();
                bs.DataSource = _product;
                dgv_ProductList.DataSource = bs;
            }

            cbb_Products.DataBindings.Add("Text", bs, "ProductName", true, DataSourceUpdateMode.OnPropertyChanged);
            cbb_Categories.DataBindings.Add("Text", bs, "CategoryName", true, DataSourceUpdateMode.OnPropertyChanged);
            cbb_Units.DataBindings.Add("Text", bs, "UnitName", true, DataSourceUpdateMode.OnPropertyChanged);
            nmr_Quantity.DataBindings.Add("Value", bs, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
            rtb_ProductNote.DataBindings.Add("Text", bs, "Note", true, DataSourceUpdateMode.OnPropertyChanged);
            nmr_ConversionRate.DataBindings.Add("Value", bs, "ConversionRate", true, DataSourceUpdateMode.OnPropertyChanged);
            nmr_Price.DataBindings.Add("Value", bs, "Price", true, DataSourceUpdateMode.OnPropertyChanged);

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
                EmployeeID = 1, // Assuming you will set this later
                SupplierID = (int)cbb_Suppliers.SelectedValue,
                Date = dateTimePicker.Value,
                Status = cbb_Status.Text,
            };

            if (_purchaseInvoiceDTO != null)
            {
                purchaseInvoice.ID = _purchaseInvoiceDTO.ID;
            }


            foreach (var item in _product)
            {
                MessageBox.Show(item.Status.ToString());
            }

            this.Tag = purchaseInvoice;
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
    }
}
