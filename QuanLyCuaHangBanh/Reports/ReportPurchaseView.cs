using QuanLyCuaHangBanh.Data;
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
using Microsoft.Reporting.WinForms;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Reports
{

    public class ReportPurchaseInvoiceItem
    {
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public ReportPurchaseInvoiceItem() { }
        public ReportPurchaseInvoiceItem(int id, string supplierName, int prductId, string productName, int unitId, string unitName, int quantity, decimal price, decimal totalPrice, DateTime saleDate)
        {
            ID = id;
            SupplierName = supplierName;
            ProductName = productName;
            ProductID = prductId;
            UnitID = unitId;
            UnitName = unitName;
            Quantity = quantity;
            UnitCost= price;
            TotalPrice = totalPrice;
            Date = saleDate;
        }
    }

    public partial class ReportPurchaseView : Form
    {

        QLCHB_DBContext context = new QLCHB_DBContext();
        QLCHBDataSet.PurchaseInvoice_DetailsDataTable purchaseInvoice_Details = new QLCHBDataSet.PurchaseInvoice_DetailsDataTable();

        private int PurchaseInvoiceID;
        public ReportPurchaseView(int purchaseInvoiceID)
        {
            InitializeComponent();
            PurchaseInvoiceID = purchaseInvoiceID;

            this.Load += ReportPurchaseView_Load;
        }

        private void ReportPurchaseView_Load(object sender, EventArgs e)
        {
            var purchaseInvoices = context.PurchaseInvoices
                .Include(p => p.Supplier)
                .FirstOrDefault(p => p.ID == PurchaseInvoiceID);

            if (purchaseInvoices != null)
            {
                var purchaseInvoiceDetails = context.PurchaseInvoiceDetails
                    .Include(p => p.Product_Unit.Product)
                    .Include(p => p.Product_Unit.Unit)
                    //.Include(p => p.Invoice.Supplier)
                    .Where(p => p.InvoiceID == PurchaseInvoiceID)
                    .Select(p => new ReportPurchaseInvoiceItem(
                        p.ID,
                        purchaseInvoices.Supplier.Name,
                        p.Product_Unit.Product.ID,
                        p.Product_Unit.Product.Name,
                        p.Product_Unit.Unit.ID,
                        p.Product_Unit.Unit.Name,
                        p.Quantity,
                        p.UnitCost,
                        p.UnitCost * p.Quantity,
                        purchaseInvoices.Date
                    )).Cast<Object>().ToList();

                ReportHanler.LoadData(
                    this.reportViewer1,
                    purchaseInvoiceDetails,
                    purchaseInvoice_Details,
                    "rptPurchaseInvoice.rdlc",
                    "dsPurchaseInvoice",
                    (row, enity) =>
                    {
                        var item = (ReportPurchaseInvoiceItem)enity;
                        row["ID"] = item.ID;
                        //row["SupplierName"] = item.SupplierName;
                        row["ProductID"] = item.ProductID;
                        row["ProductName"] = item.ProductName;
                        row["UnitID"] = item.UnitID;
                        row["UnitName"] = item.UnitName;
                        row["Quantity"] = item.Quantity;
                        row["UnitCost"] = item.UnitCost;
                        row["TotalPrice"] = item.TotalPrice;
                        //row["Date"] = item.Date.ToString("dd/MM/yyyy");
                    }
                );

                IList<ReportParameter> parameters = new List<ReportParameter>
                {

                    //new ReportParameter("InvoiceID", purchaseInvoices.ID.ToString()),
                    new ReportParameter("CreatedDate", purchaseInvoices.Date.ToString("dd/MM/yyyy")),
                    new ReportParameter("Supplier_Name", purchaseInvoices.Supplier.Name),
                    new ReportParameter("Supplier_Address", purchaseInvoices.Supplier.Address),
                    //new ReportParameter("TotalPrice", purchaseInvoiceDetails.Sum(p => ((ReportPurchaseInvoiceItem)p).TotalPrice).ToString())
                };

                this.reportViewer1.LocalReport.SetParameters(parameters);
            }


        }
    }
}
