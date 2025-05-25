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
        private OrderDTO? orderDTO = null!;

        private BindingSource bs = new BindingSource();
        BindingList<ProductOrderDTO> _products = new BindingList<ProductOrderDTO>();
        public BindingList<ProductOrderDTO> Products => _products;

        private int selectedProductUnitId = 0;

        public OrderInputView(OrderDTO? orderDTO = null)
        {
            InitializeComponent();
            this.orderDTO = orderDTO;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Models.Order addedOrder = new Models.Order()
            {
                ID = orderDTO?.ID ?? 0,
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

            List<string> statusList = new List<string>()
            {
                "Chờ xác nhận",
                "Đang giao hàng",
                "Đã giao hàng",
                "Đã hủy"
            };

            cbb_Status.DataSource = statusList;

            List<string> paymentMethod = new List<string>()
            {
                "Tiền mặt",
                "Chuyển khoản",
                "Thẻ tín dụng",
                "Ghi nợ"
            };

            cbb_PaymentMethods.DataSource = paymentMethod;

            if (orderDTO != null)
            {
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
                            o.OrderId
                        )).ToList()
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

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            bs.Add(
                new ProductOrderDTO(
                    bs.Count + 1,
                    cbb_Products.Text,
                    (int)cbb_Products.SelectedValue,
                    cbb_Categories.Text,
                    cbb_Units.Text,
                    selectedProductUnitId,
                    nmr_ConversionRate.Value,
                    Convert.ToInt32(nmr_Quantity.Value),
                    rtb_ProductNote.Text,
                    0 // Assuming OrderId is 0 for new products
                 )
            );
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
                bs.ResetBindings(false);
            }
        }

        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.CurrentRow != null && dgv_ProductList.CurrentRow.DataBoundItem is ProductOrderDTO productOrderDTO)
            {
                bs.Remove(productOrderDTO);
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
                }
            }
        }

        private void cbb_PaymentMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_PaymentMethods.SelectedText == "Ghi nợ")
            {
                // Handle payment method selection if needed
            }
        }
    }
}
