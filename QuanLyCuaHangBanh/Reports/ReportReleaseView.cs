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
using Microsoft.EntityFrameworkCore;

namespace QuanLyCuaHangBanh.Reports
{
    public class ReportReleaseItem
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

        public ReportReleaseItem(int id, int receiptNoteId, int productId, string productName, int categoryId, string categoryName, int unitId, string unitName, int quantity)
        {
            ID = id;
            ReceiptNoteID = receiptNoteId;
            ProductID = productId;
            ProductName = productName;
            CategoryID = categoryId;
            CategoryName = categoryName;
            UnitID = unitId;
            UnitName = unitName;
            Quantity = quantity;
        }
    }
    public partial class ReportReleaseView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private QLCHBDataSet.ReleaseNotesDetailsDataTable releaseNotesDataTable = new QLCHBDataSet.ReleaseNotesDetailsDataTable();
        public ReportReleaseView()
        {
            InitializeComponent();
            this.Load += ReportReleaseView_Load;
        }

        private void ReportReleaseView_Load(object sender, EventArgs e)
        {
            var releaseNotes = context.WarehouseReleaseNoteDetails
                .Include(r => r.Product_Unit)
                .GroupBy(o => o.Product_Unit.UnitID)
                .Select(r => new ReportReleaseItem(
                    r.First().ID,
                    r.First().WarehouseReleaseNoteId,
                    r.First().Product_Unit.ProductID,
                    r.First().Product_Unit.Product.Name,
                    r.First().Product_Unit.Product.CategoryID,
                    r.First().Product_Unit.Product.Category.Name,
                    r.First().Product_Unit.UnitID,
                    r.First().Product_Unit.Unit.Name,
                    r.First().Quantity
                )).Cast<Object>().ToList();

            ReportHanler.LoadData(
                reportViewer1,
                releaseNotes,
                releaseNotesDataTable,
                "rptReleaseNote.rdlc",
                "dsReleaseNoteDetails",
                (row, entity) =>
                {
                    var item = (ReportReleaseItem)entity;
                    row["ID"] = item.ID;
                    row["ReleaseNoteID"] = item.ReceiptNoteID;
                    row["ProductID"] = item.ProductID;
                    row["ProductName"] = item.ProductName;
                    row["CategoryID"] = item.CategoryID;
                    row["CategoryName"] = item.CategoryName;
                    row["UnitID"] = item.UnitID;
                    row["UnitName"] = item.UnitName;
                    row["Quantity"] = item.Quantity;
                }
            );
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            var releaseNotes = context.WarehouseReleaseNoteDetails
                .Where(o => o.WarehouseReleaseNote.CreatedDate >= DateOnly.FromDateTime(dtp_FromDate.Value) && o.WarehouseReleaseNote.CreatedDate <= DateOnly.FromDateTime(dtp_ToDate.Value))
                .Select(r => new ReportReleaseItem(
                    r.ID,
                    r.WarehouseReleaseNoteId,
                    r.Product_Unit.ProductID,
                    r.Product_Unit.Product.Name,
                    r.Product_Unit.Product.CategoryID,
                    r.Product_Unit.Product.Category.Name,
                    r.Product_Unit.UnitID,
                    r.Product_Unit.Unit.Name,
                    r.Quantity
                )).Cast<Object>().ToList();

            ReportHanler.LoadData(
                reportViewer1,
                releaseNotes,
                releaseNotesDataTable,
                "rptReleaseNote.rdlc",
                "dsReleaseNoteDetails",
                (row, entity) =>
                {
                    var item = (ReportReleaseItem)entity;
                    row["ID"] = item.ID;
                    row["ReleaseNoteID"] = item.ReceiptNoteID;
                    row["ProductID"] = item.ProductID;
                    row["ProductName"] = item.ProductName;
                    row["CategoryID"] = item.CategoryID;
                    row["CategoryName"] = item.CategoryName;
                    row["UnitID"] = item.UnitID;
                    row["UnitName"] = item.UnitName;
                    row["Quantity"] = item.Quantity;
                }
            );

            IList<ReportParameter> parameters = new List<ReportParameter>
            {
                new ReportParameter("FilterResult", String.Format("{0} - {1}", dtp_FromDate.Value.ToString("dd/MM/yyyy"), dtp_ToDate.Value.ToString("dd/MM/yyyy"))),
            };

            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            ReportReleaseView_Load(sender, e);
        }
    }
}
