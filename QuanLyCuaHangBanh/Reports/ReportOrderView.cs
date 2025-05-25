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
using Microsoft.Reporting.WinForms;

namespace QuanLyCuaHangBanh.Reports
{
    public class ReportOrderItem
    {
        public int ID { get; set; }
        public int CustomerID { get; set; } 
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        public ReportOrderItem(int id, int customerId, string customerName, DateTime orderDate, string deliveryAddress, string phoneNumber, string paymentMethod, string status, decimal totalPrice)
        {
            ID = id;
            CustomerID = customerId;
            CustomerName = customerName;
            OrderDate = orderDate;
            DeliveryAddress = deliveryAddress;
            PhoneNumber = phoneNumber;
            PaymentMethod = paymentMethod;
            Status = status;
            TotalPrice = totalPrice;
        }
    }
    public partial class ReportOrderView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private QLCHBDataSet.OrderDataTable orderDataTable = new QLCHBDataSet.OrderDataTable();

        public ReportOrderView()
        {
            InitializeComponent();
            this.Load += ReportOrderView_Load;
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            ReportOrderView_Load(sender, e);
        }

        private void ReportOrderView_Load(object sender, EventArgs e)
        {
            var orders = context.Orders
                .Select(o => new ReportOrderItem(
                    o.ID,
                    o.CustomerID,
                    o.Customer.Name,
                    o.OrderDate,
                    o.DeliveryAddress,
                    o.Customer.PhoneNumber,
                    o.PaymentMethod.ToString(),
                    o.Status.ToString(),
                    o.OrderDetails.Sum(od => od.Quantity * od.Price)
                )).Cast<Object>().ToList();

            ReportHanler.LoadData(
                reportViewer1,
                orders,
                orderDataTable,
                "rptOrder.rdlc",
                "dsOrders",
                (row, entity) => {
                    var order = (ReportOrderItem)entity;
                    row["ID"] = order.ID;
                    row["CustomerID"] = order.CustomerID;
                    row["CustomerName"] = order.CustomerName;
                    row["OrderDate"] = order.OrderDate;
                    row["DeliveryAddress"] = order.DeliveryAddress;
                    row["PhoneNumber"] = order.PhoneNumber;
                    row["PaymentMethod"] = order.PaymentMethod;
                    row["Status"] = order.Status;
                    row["TotalPrice"] = order.TotalPrice;
                }
            );
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            var startDate = dtp_FormDate.Value.Date;
            var endDate = dtp_ToDate.Value.Date.AddDays(1).AddTicks(-1); // Include the end date
            var filteredOrders = context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .Select(o => new ReportOrderItem(
                    o.ID,
                    o.CustomerID,
                    o.Customer.Name,
                    o.OrderDate,
                    o.DeliveryAddress,
                    o.Customer.PhoneNumber,
                    o.PaymentMethod.ToString(),
                    o.Status.ToString(),
                    o.OrderDetails.Sum(od => od.Quantity * od.Price)
                )).Cast<Object>().ToList();

            ReportHanler.LoadData(
                reportViewer1,
                filteredOrders,
                orderDataTable,
                "rptOrder.rdlc",
                "dsOrders",
                (row, entity) => {
                    var order = (ReportOrderItem)entity;
                    row["ID"] = order.ID;
                    row["CustomerID"] = order.CustomerID;
                    row["CustomerName"] = order.CustomerName;
                    row["OrderDate"] = order.OrderDate;
                    row["DeliveryAddress"] = order.DeliveryAddress;
                    row["PhoneNumber"] = order.PhoneNumber;
                    row["PaymentMethod"] = order.PaymentMethod;
                    row["Status"] = order.Status;
                    row["TotalPrice"] = order.TotalPrice;
                }
            );

            IList<ReportParameter> parameters = new List<ReportParameter>
            {
                new ReportParameter("FilterResult", String.Format("{0} - {1}", dtp_FormDate.Value.ToString("dd/MM/yyyy"), dtp_ToDate.Value.ToString("dd/MM/yyyy"))),
            };

            reportViewer1.LocalReport.SetParameters(parameters);
        }
    }
}
