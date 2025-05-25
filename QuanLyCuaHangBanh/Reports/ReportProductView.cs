using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Uitls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanh.Reports
{
    public class ProductReportItem
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProducerID { get; set; }
        public string SupplierName { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public ProductReportItem() { }

        public ProductReportItem(int id, string productName, int categoryID, string categoryName, int producerID, string supplierName, DateOnly productionDate, DateOnly expirationDate, string description, string image)
        {
            ID = id;
            ProductName = productName;
            CategoryID = categoryID;
            CategoryName = categoryName;
            ProducerID = producerID;
            SupplierName = supplierName;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            Description = description;
            Image = image;
        }
    }

    public partial class ReportProductView : Form
    {
        QLCHB_DBContext context = new QLCHB_DBContext();
        QLCHBDataSet.ProductsDataTable productsDataTable = new QLCHBDataSet.ProductsDataTable();

        public ReportProductView()
        {
            InitializeComponent();
        }

        private void ReportProductView_Load(object sender, EventArgs e)
        {

            var Products = context.Products
                .Include(o => o.Category)
                .Include(o => o.Producer)
                .Select(o => new ProductReportItem
                (
                    o.ID,
                    o.Name,
                    o.CategoryID,
                    o.Category.Name,
                    o.ProducerID,
                    o.Producer.Name,
                    o.ProductionDate,
                    o.ExpirationDate,
                    o.Description,
                    o.Image
                )).Cast<Object>().ToList();

            ReportHanler.LoadData(
                    this.reportViewer1,
                    Products,
                    productsDataTable,
                    "ReportProduct.rdlc",
                    "dbProduct",
                    (row, entity) =>
                    {
                        var product = (ProductReportItem)entity;
                        row["ID"] = product.ID;
                        row["Name"] = product.ProductName;
                        row["CategoryID"] = product.CategoryID;
                        row["CategoryName"] = product.CategoryName;
                        row["SupplierID"] = product.ProducerID;
                        row["SupplierName"] = product.SupplierName;
                        row["ProductionDate"] = product.ProductionDate.ToDateTime(TimeOnly.MinValue);
                        row["ExpirationDate"] = product.ExpirationDate.ToDateTime(TimeOnly.MinValue);
                        row["Description"] = product.Description;
                        row["Image"] = product.Image;
                    }
                );
        }
    }
}
