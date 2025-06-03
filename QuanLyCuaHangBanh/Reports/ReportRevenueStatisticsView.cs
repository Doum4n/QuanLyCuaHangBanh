using Microsoft.EntityFrameworkCore;
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
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Reports
{
    public class ReportSalesInvoiceItem1
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public ReportSalesInvoiceItem1() { }
        public ReportSalesInvoiceItem1(int id, int employeeId, string employeeName, int customerId, string customerName, decimal totalPrice, DateTime date)
        {
            ID = id;
            EmployeeID = employeeId;
            EmployeeName = employeeName;
            CustomerID = customerId;
            CustomerName = customerName;
            TotalPrice = totalPrice;
            Date = date;
        }
    }
    public partial class ReportRevenueStatisticsView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private QLCHBDataSet.PurchaseInvoicesDataTable purchaseInvoicesDT = new QLCHBDataSet.PurchaseInvoicesDataTable();
        public ReportRevenueStatisticsView()
        {
            InitializeComponent();
            this.Load += RevenueStatisticsView_Load;
        }

        private void RevenueStatisticsView_Load(object sender, EventArgs e)
        {
            var grouped = context.SalesInvoiceDetails
                .Include(d => d.Invoice)
                .ThenInclude(i => i.Employee)
                .Include(d => d.Invoice)
                .ThenInclude(i => ((SalesInvoice)i).Customer)
                .Include(d => d.Invoice)
                .ThenInclude(i => i.Accounts)
                .AsNoTracking()
                .ToList()
                .GroupBy(d => new {
                    CustomerID = ((SalesInvoice)d.Invoice).CustomerID,
                    CustomerName = ((SalesInvoice)d.Invoice).Customer.Name
                })
                .Select(g => {
                    var first = g.First();
                    var invoice = (SalesInvoice)first.Invoice;
                    var totalReceivable = invoice.Accounts //TODO: Sửa lại
                        .Where(a => a is AccountsReceivable)
                        .Sum(a => a.Amount);

                    return new ReportSalesInvoiceItem1(
                        0,
                        invoice.EmployeeID,
                        invoice.Employee?.Name ?? "",
                        g.Key.CustomerID,
                        g.Key.CustomerName,
                        g.Sum(d => d.Quantity * d.UnitPrice) - totalReceivable,
                        invoice.Date
                    );
                })
                .Cast<object>()
                .ToList();

            ReportHanler.LoadData(
                this.reportViewer1,
                grouped,
                purchaseInvoicesDT,
                "rptRevenueStatistics.rdlc",
                "dsSalesInvoice",
                (row, entity) => 
                { 
                    var item = entity as ReportSalesInvoiceItem1;
                    row["ID"] = item.ID;
                    row["EmployeeID"] = item.EmployeeID;
                    row["EmployeeName"] = item.EmployeeName;
                    row["CustomerID"] = item.CustomerID;
                    row["CustomerName"] = item.CustomerName;
                    row["TotalPrice"] = item.TotalPrice;
                    row["Date"] = item.Date;
                }
            );
        }
    }
}
