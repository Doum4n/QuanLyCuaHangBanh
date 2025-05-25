using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Views
{
    public record AddedProduct(
        int ID,
        int UnitId,
        string UnitName
    );
    public partial class AddProducts : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();

        private int productUnitID;

        public AddProducts()
        {
            InitializeComponent();
        }
        private void AddProducts_Load(object sender, EventArgs e)
        {
            cbb_Products.DataSource = context.Products.ToList();
            cbb_Products.DisplayMember = "Name";
            cbb_Products.ValueMember = "ID";

            cbb_Units.DataSource = context.Units.ToList();
            cbb_Units.DisplayMember = "Name";
            cbb_Units.ValueMember = "ID";

            cbb_Products.SelectedIndexChanged += cbb_Products_SelectedIndexChanged;
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            var addedProduct = new ProductReceiptDTO(
                0, // Assuming ID is auto-generated
                (int)cbb_Products.SelectedValue,
                cbb_Products.Text,
                0, // Assuming you will set this later
                "", // Assuming you will set this later
                (int)cbb_Units.SelectedValue,
                cbb_Units.Text,
                productUnitID,
                1, // Assuming a default conversion rate of 1
                nmr_PurchasePrice.Value,
                (int)nmr_Quantity.Value,
                rtb_Note.Text
            );

            this.Tag = addedProduct;
            this.DialogResult = DialogResult.OK;
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
                productUnitID = selectedUnit.ID;
            }
        }
    }
}
