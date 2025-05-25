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
    public partial class ReleaseNoteInputView : Form
    {
        private QLCHB_DBContext? context = new QLCHB_DBContext();
        private WarehouseReleaseNoteDTO? dTO;

        BindingSource bs = new BindingSource();
        public BindingSource ProductsBindingSource => bs;

        public event Action<ProductReleaseDTO> AddProductEvent;

        public event Func<object, EventArgs, int> ShowSelectGoodsReciveNoteForm;
        public event Func<object, EventArgs, int> ShowSelectOrderForm;

        BindingList<ProductReleaseDTO> _products;
        public BindingList<ProductReleaseDTO> Products => _products;

        private int selectedReleaseNoteId = 0;

        private int productUnitID;

        public ReleaseNoteInputView(WarehouseReleaseNoteDTO? dTO = null)
        {
            InitializeComponent();
            this.dTO = dTO;
        }

        private void WarehouseReleaseNoteInputView_Load(object sender, EventArgs e)
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

            cbb_Status.DataSource = new List<string>
            {
                "Mới",
                "Đã lưu",
                "Đã duyệt",
                "Đã nhập vào kho",
                "Đã hủy",
                "Đang xử lý",
                "Đã thanh toán một phần",
                "Đã thanh toán",
            };


            if (dTO != null)
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

                bs.DataSource = _products;
                dgv_ProductList.DataSource = bs;

                cbb_Categories.DataBindings.Add("SelectedValue", bs, "CategoryID");
                cbb_Products.DataBindings.Add("Text", bs, "productName");
                cbb_Units.DataBindings.Add("Text", bs, "unitName");
                nmr_Quantity.DataBindings.Add("Text", bs, "Quantity");
                nmr_ConversionRate.DataBindings.Add("Text", bs, "ConversionRate");
                rtb_ProductNote.DataBindings.Add("Text", bs, "Note");
            }
            else
            {
                _products = new BindingList<ProductReleaseDTO>();

                bs.DataSource = _products;
                dgv_ProductList.DataSource = bs;
            }
        }

        public void AddProduct(ProductReleaseDTO productReleaseDTO)
        {
            productReleaseDTO.IsNewlyAdded = true;
            productReleaseDTO.Status = DTO.Base.Status.New;
            bs.Add(productReleaseDTO);
        }

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

            bs.Add(
                productReleaseDTO
            );
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            WarehouseReleaseNote warehouseReleaseNote = new WarehouseReleaseNote
            {
                ID = dTO?.ID ?? 0,
                CreatedByID = Session.EmployeeId,
                CreatedDate = DateOnly.FromDateTime(dateTimePicker.Value),
                Note = rtb_Note.Text,
                Status = cbb_Status.SelectedItem.ToString(),
                LinkedId = selectedReleaseNoteId, // Set this to the appropriate value if needed
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

        private void rbtn_GoodsReciveNote_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_GoodsReciveNote.Checked)
            {
                if (ShowSelectGoodsReciveNoteForm.Invoke(sender, e) != 0)
                {
                    selectedReleaseNoteId = ShowSelectGoodsReciveNoteForm.Invoke(sender, e);
                }
            }
            else if (rbtn_Order.Checked)
            {
                if (ShowSelectOrderForm.Invoke(sender, e) != 0)
                {
                    selectedReleaseNoteId = ShowSelectOrderForm.Invoke(sender, e);
                }
            }
        }

        public void RaiseAddProductEvent(ProductReleaseDTO product)
        {
            AddProductEvent?.Invoke(product);
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (bs.Current is ProductReleaseDTO selectedProduct)
            {
                selectedProduct.ProductName = cbb_Products.Text;
                selectedProduct.CategoryId = (int)cbb_Categories.SelectedValue;
                selectedProduct.CategoryName = cbb_Categories.Text;
                selectedProduct.ProductUnitId = productUnitID;
                selectedProduct.UnitName = cbb_Units.Text;
                selectedProduct.Quantity = Convert.ToInt32(nmr_Quantity.Value);
                selectedProduct.ConversionRate = (decimal)nmr_ConversionRate.Value;
                selectedProduct.Note = rtb_ProductNote.Text;
                selectedProduct.Status = DTO.Base.Status.Modified;

                // Cập nhật lại giao diện
                bs.ResetCurrentItem();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                nmr_Quantity.Maximum = context.Inventories
                    .Include(i => i.ProductUnit)
                    .ThenInclude(pu => pu.Product)
                    .FirstOrDefault(i => i.ProductUnit.ProductID == selectedProduct.ID && i.ProductUnit.UnitID == (int)cbb_Units.SelectedValue)
                    .Quantity;

                nmr_ConversionRate.Value = context.ProductUnits
                    .Where(pu => pu.ProductID == selectedProduct.ID && pu.UnitID == (int)cbb_Units.SelectedValue)
                    .Select(pu => pu.ConversionRate)
                    .FirstOrDefault();
                nmr_ConversionRate.Enabled = false;
            }

        }

        private void cbb_Units_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_Units.SelectedItem is AddedProduct selectedUnit)
            {
                productUnitID = selectedUnit.ID;
            }
        }

        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (bs.Current is ProductReleaseDTO selectedProduct)
            {
                selectedProduct.Status = DTO.Base.Status.Deleted;

                bs.DataSource = new BindingList<ProductReleaseDTO>(
                    _products.Where(p => p.Status != DTO.Base.Status.Deleted).ToList()
                );

                bs.ResetBindings(false);

                dgv_ProductList.DataSource = bs;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_ProductList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgv_ProductList.Rows[e.RowIndex].DataBoundItem is ProductReleaseDTO product)
            {
                if (product.IsNewlyAdded)
                {
                    dgv_ProductList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dgv_ProductList.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgv_ProductList.DefaultCellStyle.BackColor;
                }
            }
        }

        private void rbtn_Order_CheckedChanged(object sender, EventArgs e)
        {

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
    }
}
