using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Models.Base;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using QuanLyCuaHangBanh.DTO.Base;

namespace QuanLyCuaHangBanh.Services
{
    public class PurchaseService(IRepositoryProvider provider) : IService
    {
        private int _purchaseInvoiceId = 0;

        public IList<PurchaseInvoiceDTO> GetAllPurchaseInvoices()
        {
            return provider.GetRepository<PurchaseInvoice>().GetAllAsDto<PurchaseInvoiceDTO>(
                i => new PurchaseInvoiceDTO
                (
                    i.ID,
                    i.Employee.Name,
                    i.Supplier.ID,
                    i.Supplier.Name,
                    i.Date,
                    i.InvoiceDetails.Sum(o => o.Quantity * o.Product_Unit.UnitPrice),
                    i.Status
                )
            );
        }

        public (DataTable purchaseInvoiceTable, DataTable purchaseInvoiceDetailTable) PrepareExportData(IList<PurchaseInvoiceDTO> purchaseInvoiceDTOs)
        {
            DataTable dataTable = new DataTable("PurchaseInvoice");
            dataTable.Columns.Add("Mã hóa đơn", typeof(int));
            dataTable.Columns.Add("Mã nhà cung cấp", typeof(int));
            dataTable.Columns.Add("Mã nhân viên lập", typeof(int));
            dataTable.Columns.Add("Ngày lập", typeof(DateTime));
            dataTable.Columns.Add("Trạng thái", typeof(string));

            DataTable dataTableDetail = new DataTable("PurchaseInvoiceDetail");
            dataTableDetail.Columns.Add("Mã hóa đơn", typeof(int));
            dataTableDetail.Columns.Add("Mã sản phẩm", typeof(int));
            dataTableDetail.Columns.Add("Tên sản phẩm", typeof(string));
            dataTableDetail.Columns.Add("Mã đơn vị tính", typeof(int));
            dataTableDetail.Columns.Add("Tên đơn vị tính", typeof(string));
            dataTableDetail.Columns.Add("Số lượng", typeof(int));
            dataTableDetail.Columns.Add("Giá nhập", typeof(decimal));
            dataTableDetail.Columns.Add("Ghi chú", typeof(string));

            foreach (var item in purchaseInvoiceDTOs)
            {
                var purchaseInvoice = provider.GetRepository<PurchaseInvoice>().GetByValue(item.ID);
                IList<PurchaseInvoice_Detail> purchaseInvoiceDetail = ((PurchaseInvoiceDetailRepo)provider.GetRepository<PurchaseInvoice_Detail>()).GetByPurchaseInvoiceId(item.ID);

                if (purchaseInvoice != null)
                {
                    dataTable.Rows.Add(
                        purchaseInvoice.ID,
                        purchaseInvoice.SupplierID,
                        purchaseInvoice.EmployeeID,
                        purchaseInvoice.Date,
                        purchaseInvoice.Status
                    );
                    foreach (var detail in purchaseInvoiceDetail)
                    {
                        dataTableDetail.Rows.Add(
                            detail.InvoiceID,
                            detail.Product_Unit.ProductID,
                            detail.Product_Unit.Product.Name,
                            detail.Product_Unit.UnitID,
                            detail.Product_Unit.Unit.Name,
                            detail.Quantity,
                            detail.UnitCost,
                            detail.Note
                        );
                    }
                }
            }
            return (dataTable, dataTableDetail);
        }

        public void ExportPurchaseInvoices(IList<PurchaseInvoiceDTO> purchaseInvoiceDTOs)
        {
            var (purchaseInvoiceTable, purchaseInvoiceDetailTable) = PrepareExportData(purchaseInvoiceDTOs);
            ExcelHandler.ExportExcel("Hóa đơn nhập", "Hóa đơn nhập", "Chi tiết hóa đơn nhập", purchaseInvoiceTable, purchaseInvoiceDetailTable);
        }

        public void ImportPurchaseInvoices()
        {
            ExcelHandler.ImportExcel(ImportPurchaseInvoice, ImportPurchaseInvoiceDetail);
        }

        private void ImportPurchaseInvoice(DataRow row)
        {
            var purchaseInvoice = new PurchaseInvoice
            {
                SupplierID = Convert.ToInt32(row["Mã nhà cung cấp"]),
                EmployeeID = Convert.ToInt32(row["Mã nhân viên lập"]),
                Date = DateTime.UtcNow,
                Status = "Chờ xác nhận",
            };
            provider.GetRepository<PurchaseInvoice>().Add(purchaseInvoice);
            _purchaseInvoiceId = purchaseInvoice.ID;
        }

        private void ImportPurchaseInvoiceDetail(DataRow row)
        {
            if (_purchaseInvoiceId == 0) return;

            var productId = Convert.ToInt32(row["Mã sản phẩm"]);
            var unitId = Convert.ToInt32(row["Mã đơn vị tính"]);

            var productUnit = ((ProductUnitRepo)provider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

            var purchaseInvoiceDetail = new PurchaseInvoice_Detail
            {
                InvoiceID = _purchaseInvoiceId,
                Product_UnitID = productUnit,
                Quantity = Convert.ToInt32(row["Số lượng"]),
                UnitCost = Convert.ToDecimal(row["Giá nhập"]),
                Note = row["Ghi chú"].ToString(),
            };

            provider.GetRepository<PurchaseInvoice_Detail>().Add(purchaseInvoiceDetail);
        }

        public void AddPurchaseInvoice(PurchaseInvoice purchaseInvoice, AccountsPayable accountsPayable, IEnumerable<ProductPurchaseInvoiceDTO> products)
        {
            provider.GetRepository<PurchaseInvoice>().Add(purchaseInvoice);

            accountsPayable.InvoiceID = purchaseInvoice.ID;
            provider.GetRepository<AccountsPayable>().Add(accountsPayable);

            foreach (var item in products)
            {
                item.InvoiceID = purchaseInvoice.ID;
                provider.GetRepository<PurchaseInvoice_Detail>().Add(item.ToPurchaseInvoice_Detail());
            }
        }

        public void UpdatePurchaseInvoice(PurchaseInvoice purchaseInvoice, AccountsPayable accountsPayable, IEnumerable<ProductPurchaseInvoiceDTO> products)
        {
            provider.GetRepository<PurchaseInvoice>().Update(purchaseInvoice);

            accountsPayable.InvoiceID = purchaseInvoice.ID;
            provider.GetRepository<AccountsPayable>().Update(accountsPayable);

            foreach (var item in products)
            {
                switch (item.Status)
                {
                    case Status.New:
                        item.InvoiceID = purchaseInvoice.ID;
                        provider.GetRepository<PurchaseInvoice_Detail>().Add(item.ToPurchaseInvoice_Detail());
                        break;
                    case Status.Deleted:
                        ((PurchaseInvoiceDetailRepo)provider.GetRepository<PurchaseInvoice_Detail>()).DeleteById(item.ID);
                        break;
                    case Status.Modified:
                        item.InvoiceID = purchaseInvoice.ID;
                        provider.GetRepository<PurchaseInvoice_Detail>().Update(item.ToPurchaseInvoice_Detail());
                        break;
                }
            }
        }

        public IList<GoodsReceiptNote_Detail> GetGoodsReceiptNoteDetails(int goodsReceiptNoteId)
        {
            return ((GoodsReceiptNoteDetailRepo)provider.GetRepository<GoodsReceiptNote_Detail>()).GetReceiptNote_Details(goodsReceiptNoteId);
        }
    }
}