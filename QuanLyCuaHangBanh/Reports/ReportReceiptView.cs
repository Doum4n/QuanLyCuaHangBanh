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

    public class ReportReceiptItem
    {
        public int ID { get; set; }
        public int ReceiptNoteID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpirationDate { get; set; }

        public ReportReceiptItem(int id, int receiptNoteID, int productID, string productName, int categoryID, string categoryName, int unitID, string unitName, int quantity, decimal purchasePrice, decimal totalPrice, DateOnly productionDate, DateOnly expirationDate)
        {
            ID = id;
            ReceiptNoteID = receiptNoteID;
            ProductID = productID;
            ProductName = productName;
            CategoryID = categoryID;
            CategoryName = categoryName;
            UnitID = unitID;
            UnitName = unitName;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
            TotalPrice = totalPrice;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }
    }

    public partial class ReportReceiptView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private QLCHBDataSet.ReceiptNoteDetailsDataTable dataTable = new QLCHBDataSet.ReceiptNoteDetailsDataTable();
        public ReportReceiptView()
        {
            InitializeComponent();
            this.Load += ReportReceiptView_Load;
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            var reportItems = context.GoodsReceiptNoteDetails
                .Where(o => o.GoodsReceiptNote.CreatedDate >= DateOnly.FromDateTime(dtp_FromDate.Value) && o.GoodsReceiptNote.CreatedDate <= DateOnly.FromDateTime(dpt_ToDate.Value))
                .Select(x => new ReportReceiptItem(
                    x.ID,
                    x.GoodsReceiptNoteId,
                    x.ProductId,
                    x.Product.Name,
                    x.Product.CategoryID,
                    x.Product.Category.Name,
                    x.ProductUnit.UnitID,
                    x.Unit.Name,
                    x.Quantity,
                    x.PurchasePrice,
                    x.Quantity * x.PurchasePrice,
                    x.ProductionDate,
                    x.ExpirationDate
                ))
                .Cast<Object>().ToList();

            ReportHanler.LoadData(
                reportViewer1,
                reportItems,
                dataTable,
                "rptReceiptNote.rdlc",
                "dsReceiptNoteDetails",
                (row, entity) =>
                {
                    var item = (ReportReceiptItem)entity;
                    row["ID"] = item.ID;
                    row["ReceiptNoteID"] = item.ReceiptNoteID;
                    row["ProductID"] = item.ProductID;
                    row["ProductName"] = item.ProductName;
                    row["CategoryID"] = item.CategoryID;
                    row["CategoryName"] = item.CategoryName;
                    row["UnitID"] = item.UnitID;
                    row["UnitName"] = item.UnitName;
                    row["Quantity"] = item.Quantity;
                    row["PurchasePrice"] = item.PurchasePrice;
                    row["TotalPrice"] = item.TotalPrice;
                    row["ProductionDate"] = item.ProductionDate;
                    row["ExpirationDate"] = item.ExpirationDate;
                }
            );

            IList<ReportParameter> parameters = new List<ReportParameter>
            {
                new ReportParameter("FilterResult", String.Format("{0} - {1}", dtp_FromDate.Value.ToString("dd/MM/yyyy"), dpt_ToDate.Value.ToString("dd/MM/yyyy"))),
            };

            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {

        }

        private void ReportReceiptView_Load(object sender, EventArgs e)
        {
            var reportItems = context.GoodsReceiptNoteDetails
                .Select(x => new ReportReceiptItem(
                    x.ID,
                    x.GoodsReceiptNoteId,
                    x.ProductId,
                    x.Product.Name,
                    x.Product.CategoryID,
                    x.Product.Category.Name,
                    x.ProductUnit.UnitID,
                    x.Unit.Name,
                    x.Quantity,
                    x.PurchasePrice,
                    x.Quantity * x.PurchasePrice,
                    x.ProductionDate,
                    x.ExpirationDate
                )).Cast<Object>().ToList();

            ReportHanler.LoadData(
                reportViewer1,
                reportItems,
                dataTable,
                "rptReceiptNote.rdlc",
                "dsReceiptNoteDetails",
                (row, entity) =>
                {
                    var item = (ReportReceiptItem)entity;
                    row["ID"] = item.ID;
                    row["ReceiptNoteID"] = item.ReceiptNoteID;
                    row["ProductID"] = item.ProductID;
                    row["ProductName"] = item.ProductName;
                    row["CategoryID"] = item.CategoryID;
                    row["CategoryName"] = item.CategoryName;
                    row["UnitID"] = item.UnitID;
                    row["UnitName"] = item.UnitName;
                    row["Quantity"] = item.Quantity;
                    row["PurchasePrice"] = item.PurchasePrice;
                    row["TotalPrice"] = item.TotalPrice;
                    row["ProductionDate"] = item.ProductionDate;
                    row["ExpirationDate"] = item.ExpirationDate;
                }
            );


        }
    }
}
