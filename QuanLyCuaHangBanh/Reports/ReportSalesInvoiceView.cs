using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Uitls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanh.Reports
{
    public class ReportSalesInvoiceItem
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public ReportSalesInvoiceItem() { }
        public ReportSalesInvoiceItem(int id, string customerName, int prductId, string productName, int unitId, string unitName, int quantity, decimal price, decimal totalPrice, DateTime saleDate)
        {
            ID = id;
            CustomerName = customerName;
            ProductName = productName;
            ProductID = prductId;
            UnitID = unitId;
            UnitName = unitName;
            Quantity = quantity;
            UnitPrice = price;
            TotalPrice = totalPrice;
            Date = saleDate;
        }
    }
    public partial class ReportSalesInvoiceView : Form
    {

        QLCHB_DBContext context = new QLCHB_DBContext();
        QLCHBDataSet.SalesInvoice_DetailsDataTable salesInvoice_Details = new QLCHBDataSet.SalesInvoice_DetailsDataTable();
        private int SalesInvoiceID;

        public ReportSalesInvoiceView(int salesInvoiceID)
        {
            InitializeComponent();
            SalesInvoiceID = salesInvoiceID;

            this.Load += ReportSalesInvoiceView_Load; 
        }

        private void ReportSalesInvoiceView_Load(object? sender, EventArgs e)
        {
            var salesInvoice = context.SalesInvoices
               .Include(s => s.Customer)
               .FirstOrDefault(s => s.ID == SalesInvoiceID);

            if (salesInvoice != null)
            {
                var salesInvoiceDetails = context.SalesInvoiceDetails
                    .Include(s => s.Product_Unit.Product)
                    .Include(s => s.Product_Unit.Unit)
                    .Include(s => s.Invoice)
                    .Where(s => s.Invoice.ID == SalesInvoiceID)
                    //.Where(s => s.InvoiceID == salesInvoiceID)
                    .Select(
                    s => new ReportSalesInvoiceItem(
                            s.ID,
                            (s.Invoice as SalesInvoice).Customer.Name,
                            s.Product_Unit.Product.ID,
                            s.Product_Unit.Product.Name,
                            s.Product_Unit.Unit.ID,
                            s.Product_Unit.Unit.Name,
                            s.Quantity,
                            s.UnitPrice,
                            s.UnitPrice * s.Quantity,
                            s.Invoice.Date
                        )
                    ).Cast<Object>().ToList();

                ReportHanler.LoadData(
                    this.reportViewer1,
                    salesInvoiceDetails,
                    salesInvoice_Details,
                    "rptSalesInvoice.rdlc",
                    "dsSalesInvoice",
                    (row, entity) =>
                    {
                        var salesInvoiceItem = (ReportSalesInvoiceItem)entity;
                        row["ID"] = salesInvoiceItem.ID;
                        //row["CustomerName"] = salesInvoiceItem.CustomerName;
                        row["ProductID"] = salesInvoiceItem.ProductID;
                        row["ProductName"] = salesInvoiceItem.ProductName;
                        row["UnitID"] = salesInvoiceItem.UnitID;
                        row["UnitName"] = salesInvoiceItem.UnitName;
                        row["Quantity"] = salesInvoiceItem.Quantity;
                        row["UnitPrice"] = salesInvoiceItem.UnitPrice;
                        row["TotalPrice"] = salesInvoiceItem.TotalPrice;
                        //row["Date"] = salesInvoiceItem.Date.ToString("dd/MM/yyyy");
                    }
                );

                IList<ReportParameter> parameters = new List<ReportParameter>
                {
                    new ReportParameter("CreatedDate", string.Format("Ngày {0} Tháng {1} Năm {2}",
                        salesInvoice.Date.Day,
                        salesInvoice.Date.Month,
                        salesInvoice.Date.Year)),

                    new ReportParameter("Seller_Name", ConfigurationManager.AppSettings["StoreName"].ToString()),
                    new ReportParameter("Seller_Address", ConfigurationManager.AppSettings["StoreAddress"].ToString()),
                    new ReportParameter("Seller_TaxCode", ConfigurationManager.AppSettings["StoreTaxCode"].ToString()),
                    new ReportParameter("Customer_Name", salesInvoice.Customer.Name),
                    new ReportParameter("Customer_Address", salesInvoice.Customer.Address),
                    new ReportParameter("TotalPrice", salesInvoiceDetails.Sum(o => ((ReportSalesInvoiceItem)o).TotalPrice).ToString()),

                };

                this.reportViewer1.LocalReport.SetParameters(parameters);
            }
        }
    }
}
