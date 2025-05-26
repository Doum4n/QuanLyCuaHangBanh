using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Uitls;
using System.ComponentModel;
using System.Data;
using QuanLyCuaHangBanh.DTO.Base;

namespace QuanLyCuaHangBanh.Views
{
    public partial class GoodsReceiptNoteInputView : Form
    {
        private QLCHB_DBContext? context = new QLCHB_DBContext();
        private GoodsReceiptNoteDTO? dTO;


        private BindingSource bs = new BindingSource();

        private BindingList<ProductReceiptDTO> productList = new BindingList<ProductReceiptDTO>();
        public BindingList<ProductReceiptDTO> ProductList => productList;

        public event EventHandler ShowAddProductForm;
        private int selectedProductUnitId = 0; // Assuming this is used to store the selected product unit ID

        //private List<>
        public GoodsReceiptNoteInputView(GoodsReceiptNoteDTO? dTO = null)
        {
            InitializeComponent();
            this.dTO = dTO;
        }

        private void GoodsReceiptNoteInputView_Load(object sender, EventArgs e)
        {
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

            cbb_Categories.DataSource = context.Categories.ToList();
            cbb_Categories.DisplayMember = "Name";
            cbb_Categories.ValueMember = "ID";

            cbb_Products.DataSource = context.Products.ToList();
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";

            cbb_Suppliers.DataSource = context.Suppliers.ToList();
            cbb_Suppliers.DisplayMember = "Name";
            cbb_Suppliers.ValueMember = "ID";

            cbb_Units.DataSource = context.Units.ToList();
            cbb_Units.DisplayMember = "Name";
            cbb_Units.ValueMember = "ID";


            if (dTO != null)
            {
                cbb_Suppliers.SelectedValue = dTO.SupplierId;
                cbb_Status.Text = dTO.Status;
                dateTimePicker.Value = dTO.CreatedDate.ToDateTime(new TimeOnly(0, 0, 0));
                rtb_Note.Text = dTO.Note;

                productList = new BindingList<ProductReceiptDTO>(context.GoodsReceiptNoteDetails
                    .Include(o => o.Product)
                    .ThenInclude(o => o.Category)
                    .Include(o => o.Unit)
                    .Where(o => o.GoodsReceiptNoteId == dTO.ID)
                    .Select(o => new ProductReceiptDTO(
                        o.ID,
                        o.ProductId,
                        o.Product.Name,
                        o.Product.CategoryID,
                        o.Product.Category.Name,
                        o.UnitId,
                        o.Unit.Name,
                        o.ProductUnitId,
                        o.ProductUnit.ConversionRate,
                        o.PurchasePrice,
                        o.Quantity,
                        o.Note,
                        o.ProductionDate,
                        o.ExpirationDate
                    )
                    {
                        Status = DTO.Base.Status.None
                    }).ToList());

                bs.DataSource = productList;
                dgv_ProductList.DataSource = bs;

                tb_Id.DataBindings.Add("Text", bs, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
                cbb_Categories.DataBindings.Add("SelectedValue", bs, "CategoryId", true, DataSourceUpdateMode.OnPropertyChanged);
                cbb_Products.DataBindings.Add("SelectedValue", bs, "ProductId", true, DataSourceUpdateMode.OnPropertyChanged);
                nmr_Quantity.DataBindings.Add("Value", bs, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);

                nmr_PurchasePrice.DataBindings.Add("Value", bs, "PurchasePrice", true, DataSourceUpdateMode.OnPropertyChanged);

                cbb_Units.DataBindings.Add("SelectedValue", bs, "UnitId", true, DataSourceUpdateMode.OnPropertyChanged);
                nmr_ConversionRate.DataBindings.Add("Value", bs, "ConversionRate", true, DataSourceUpdateMode.OnPropertyChanged);
                rtb_ProductNote.DataBindings.Add("Text", bs, "Note", true, DataSourceUpdateMode.OnPropertyChanged);
                //\dgv_ProductList.DataSource = dTO.Products;

            }
            else
            {
                productList = new BindingList<ProductReceiptDTO>();
                bs.DataSource = productList;
                dgv_ProductList.DataSource = bs;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            GoodsReceiptNote goodsReceiptNote = new GoodsReceiptNote
            {
                SupplierId = (int)cbb_Suppliers.SelectedValue,
                //CreatedById = (int)cbb_Suppliers.SelectedValue,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                LastModifiedById = null,
                LastModifiedDate = null,
                Note = rtb_Note.Text,
                Status = cbb_Status.Text,
            };

            if (dTO != null)
            {
                goodsReceiptNote.ID = dTO.ID;
                //goodsReceiptNote.LastModifiedById = Session.EmployeeId;
                goodsReceiptNote.LastModifiedDate = DateOnly.FromDateTime(DateTime.Now);
            }

            foreach (var item in ProductList)
            {
                MessageBox.Show(item.ProductName);
            }

            this.Tag = (goodsReceiptNote);
            this.DialogResult = DialogResult.OK;
        }

        public void LoadGoods(BindingSource bindingSource)
        {
            dgv_ProductList.DataSource = bindingSource;

            dgv_ProductList.Columns["ProductId"].Visible = false;
            dgv_ProductList.Columns["CategoryId"].Visible = false;
            dgv_ProductList.Columns["UnitId"].Visible = false;
            dgv_ProductList.Columns["GoodsReceiptNoteId"].Visible = false;
        }

        private void btn_Change_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var productReceiptDTO = new ProductReceiptDTO(
               0 , // Assuming ID is auto-generated
                (int)cbb_Products.SelectedValue,
                cbb_Products.Text,
                0, // Vì sản phẩm có sẵn
                "", // Vì sản phẩm có sẵn
                (int)cbb_Units.SelectedValue,
                cbb_Units.Text,
                selectedProductUnitId,
                1, // Vì sản phẩm có sẵn
                nmr_PurchasePrice.Value,
                (int)nmr_Quantity.Value,
                rtb_Note.Text,
                DateOnly.FromDateTime(dtp_ProductionDate.Value),
                DateOnly.FromDateTime(dtp_ExpirationDate.Value)
            );

            productReceiptDTO.Status = DTO.Base.Status.New;

            productList.Add(productReceiptDTO);
            bs.ResetBindings(false);
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_ProductList.SelectedRows[0];
                if (selectedRow.DataBoundItem is ProductReceiptDTO product)
                {
                    product.ProductId = (int)cbb_Products.SelectedValue;
                    product.ProductName = cbb_Products.Text;
                    product.UnitId = (int)cbb_Units.SelectedValue;
                    product.UnitName = cbb_Units.Text;
                    product.Quantity = (int)nmr_Quantity.Value;
                    product.PurchasePrice = nmr_PurchasePrice.Value;
                    product.Note = rtb_ProductNote.Text;
                    product.Status = DTO.Base.Status.Modified;

                    bs.ResetBindings(false);
                }
            }
        }

        private void btn_DeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgv_ProductList.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_ProductList.SelectedRows[0];
                if (selectedRow.DataBoundItem is ProductReceiptDTO product)
                {
                    product.Status = DTO.Base.Status.Deleted;

                    bs.DataSource = new BindingList<ProductReceiptDTO>(
                        productList.Where(p => p.Status != DTO.Base.Status.Deleted).ToList()
                    );

                    bs.ResetBindings(false);

                    dgv_ProductList.DataSource = bs;
                }
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
