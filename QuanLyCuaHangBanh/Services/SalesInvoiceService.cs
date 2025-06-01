// QuanLyCuaHangBanh.Services/SalesInvoiceService.cs
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Models.Base;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel; // For BindingList
using System.Linq;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO.Base;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Services
{
    public class SalesInvoiceService(IRepositoryProvider repositoryProvider, QLCHB_DBContext context) : IService
    {
        private int _salesInvoiceId = 0;
        public async Task<IList<SaleInvoiceDTO>> GetAllSalesInvoicesAsDto()
        {
            return await repositoryProvider.GetRepository<SalesInvoice>().GetAllAsDto(i =>
                new SaleInvoiceDTO
                (
                    i.ID,
                    i.Employee.Name ?? "",
                    i.Date,
                    i.InvoiceDetails.OfType<SalesInvoice_Detail>().Sum(o => o.Quantity * o.UnitPrice),
                    i.Status,
                    i.CustomerID,
                    i.Customer.Name ?? "",
                    i.Customer.Type ?? "",
                    i.PaymentMethod,
                    i.Customer.CreditPeriod,
                    i.Accounts.OfType<AccountsReceivable>().Sum(o => o.Amount),
                    i.Note
                )
            );
        }

        public IEnumerable<Order_Detail> GetOrderDetails(int orderId)
        {
            return ((OrderDetailRepo)repositoryProvider.GetRepository<Order_Detail>()).GetOrderDetail(orderId);
        }

        public void AddSalesInvoice(SalesInvoice salesInvoice, AccountsReceivable? accountsReceivable, BindingList<ProductSaleInvoiceDTO> products)
        {
            salesInvoice.ID = 0; // Invoice chưa được tạo
            repositoryProvider.GetRepository<SalesInvoice>().Add(salesInvoice);
            if (accountsReceivable != null) // Khi thanh toán bằng hình thức ghi nợ
            {
                accountsReceivable.InvoiceID = salesInvoice.ID;
                repositoryProvider.GetRepository<AccountsReceivable>().Add(accountsReceivable);
            }
            foreach (var productDto in products)
            {
                if (productDto != null) // Ensure productDto is not null
                {
                    // Map ProductDTO to SalesInvoice_Detail model
                    productDto.ID = 0; // Set ID to 0 to ensure it's a new record
                    var salesInvoiceDetail = productDto.ToSalesInvoiceDetail();
                    salesInvoiceDetail.InvoiceID = salesInvoice.ID; // Link to the newly added invoice
                    repositoryProvider.GetRepository<SalesInvoice_Detail>().Add(salesInvoiceDetail);
                }
            }
        }

        public async Task UpdateSalesInvoice(SalesInvoice salesInvoice, AccountsReceivable? accountsReceivable, BindingList<ProductSaleInvoiceDTO> products)
        {
            repositoryProvider.GetRepository<SalesInvoice>().Update(salesInvoice);
            if (accountsReceivable != null)
            {
                accountsReceivable.InvoiceID = salesInvoice.ID;
                repositoryProvider.GetRepository<AccountsReceivable>().Update(accountsReceivable);
            }
            foreach (var productDto in products)
            {
                if (productDto != null)
                {

                    switch (productDto.Status)
                    {
                        case Status.New:
                            var salesInvoiceDetail = productDto.ToSalesInvoiceDetail();
                            salesInvoiceDetail.InvoiceID = salesInvoice.ID; // Ensure it's linked
                            repositoryProvider.GetRepository<SalesInvoice_Detail>().Add(salesInvoiceDetail);
                            break;
                        case Status.Modified:
                            productDto.InvoiceID = salesInvoice.ID; // Ensure it's linked
                            repositoryProvider.GetRepository<SalesInvoice_Detail>().Update(productDto.ToSalesInvoiceDetail());
                            break;
                        case Status.Deleted:
                            // Find the existing detail to delete
                            var existingDetail = await repositoryProvider.GetRepository<SalesInvoice_Detail>()
                                .GetByValue(productDto.ID);
                            if (existingDetail != null)
                            {
                                repositoryProvider.GetRepository<SalesInvoice_Detail>().Delete(existingDetail);
                            }
                            break;
                    }
                }
            }
        }

        public async Task DeleteSalesInvoice(int invoiceId)
        {
            // IMPORTANT: Delete related entities first due to foreign key constraints.
            // You might need to adjust this based on your actual database cascade delete rules.

            // 1. Delete SalesInvoice_Details linked to this invoice
            var salesInvoiceDetails = context.SalesInvoiceDetails
                                              .Where(d => d.InvoiceID == invoiceId)
                                              .ToList();
            foreach (var detail in salesInvoiceDetails)
            {
                repositoryProvider.GetRepository<SalesInvoice_Detail>().Delete(detail);
            }

            // 2. Delete the SalesInvoice itself
            var salesInvoiceToDelete = await repositoryProvider.GetRepository<SalesInvoice>().GetByValue(invoiceId);
            if (salesInvoiceToDelete != null)
            {
                repositoryProvider.GetRepository<SalesInvoice>().Delete(salesInvoiceToDelete);
            }
        }

        public async Task ExportSalesInvoices(IList<SaleInvoiceDTO> saleInvoiceDTOs)
        {
            var (dataTable, dataTableDetail) = await PrepareExportData(saleInvoiceDTOs);
            ExcelHandler.ExportExcel("Hóa đơn bán hàng", "Hóa đơn bán hàng", "Chi tiết hóa đơn bán hàng", dataTable, dataTableDetail);
        }

        public async Task<(DataTable salesInvoiceTable, DataTable salesInvoiceDetailTable)> PrepareExportData(IList<SaleInvoiceDTO> salesInvoiceDTOs)
        {
            DataTable dataTable = new DataTable("SalesInvoice");
            dataTable.Columns.Add("Mã hóa đơn", typeof(int));
            dataTable.Columns.Add("Mã khách hàng", typeof(int));
            dataTable.Columns.Add("Mã nhân viên lập", typeof(int));
            dataTable.Columns.Add("Ngày lập", typeof(DateTime));
            dataTable.Columns.Add("Trạng thái", typeof(string));
            dataTable.Columns.Add("Phương thức thanh toán", typeof(string));

            DataTable dataTableDetail = new DataTable("SalesInvoiceDetail");
            dataTableDetail.Columns.Add("Mã hóa đơn", typeof(int));
            dataTableDetail.Columns.Add("Mã sản phẩm", typeof(int));
            dataTableDetail.Columns.Add("Tên sản phẩm", typeof(string));
            dataTableDetail.Columns.Add("Mã đơn vị tính", typeof(int));
            dataTableDetail.Columns.Add("Tên đơn vị tính", typeof(string));
            dataTableDetail.Columns.Add("Số lượng", typeof(int));
            dataTableDetail.Columns.Add("Giá bán", typeof(decimal));
            dataTableDetail.Columns.Add("Ghi chú", typeof(string));

            foreach (var item in salesInvoiceDTOs)
            {
                var salesInvoice = await repositoryProvider.GetRepository<SalesInvoice>().GetByValue(item.ID);
                IList<SalesInvoice_Detail> salesInvoiceDetail = ((SalesInvoiceDetailRepo)repositoryProvider.GetRepository<SalesInvoice_Detail>()).GetBySalesInvoiceId(item.ID);

                if (salesInvoice != null)
                {
                    dataTable.Rows.Add(
                        salesInvoice.ID,
                        salesInvoice.CustomerID,
                        salesInvoice.EmployeeID,
                        salesInvoice.Date,
                        salesInvoice.Status,
                        salesInvoice.PaymentMethod
                    );
                    foreach (var detail in salesInvoiceDetail)
                    {
                        dataTableDetail.Rows.Add(
                            detail.InvoiceID,
                            detail.Product_Unit.ProductID,
                            detail.Product_Unit.Product.Name,
                            detail.Product_Unit.UnitID,
                            detail.Product_Unit.Unit.Name,
                            detail.Quantity,
                            detail.UnitPrice,
                            detail.Note
                        );
                    }
                }
            }
            return (dataTable, dataTableDetail);
        }

        public void ImportSalesInvoices()
        {
            ExcelHandler.ImportExcel(ImportSalesInvoice, ImportSalesInvoiceDetail);
        }

        public void ImportSalesInvoice(DataRow row)
        {
            var salesInvoice = new SalesInvoice
            {
                CustomerID = Convert.ToInt32(row["Mã khách hàng"]),
                EmployeeID = Convert.ToInt32(row["Mã nhân viên lập"]),
                Date = DateTime.UtcNow,
                Status = "Chờ xác nhận",
            };
            repositoryProvider.GetRepository<SalesInvoice>().Add(salesInvoice);
            _salesInvoiceId = salesInvoice.ID;
        }

        public void ImportSalesInvoiceDetail(DataRow row)
        {
            if (_salesInvoiceId == 0) return;

            var productId = Convert.ToInt32(row["Mã sản phẩm"]);
            var unitId = Convert.ToInt32(row["Mã đơn vị tính"]);

            var productUnit = ((ProductUnitRepo)repositoryProvider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

            var salesInvoiceDetail = new SalesInvoice_Detail
            {
                InvoiceID = _salesInvoiceId,
                Product_UnitID = productUnit,
                Quantity = Convert.ToInt32(row["Số lượng"]),
                UnitPrice = Convert.ToDecimal(row["Giá bán"]),
                Note = row["Ghi chú"].ToString(),
            };

            repositoryProvider.GetRepository<SalesInvoice_Detail>().Add(salesInvoiceDetail);
        }

        // You would also move other methods here if they become complex enough:
        // public DataTable GetSalesInvoiceDataTableForExport() { /* ... */ }
        // public void ImportSalesInvoice(DataRow row) { /* ... */ }
        // public IList<InvoiceDTO> SearchSalesInvoices(string searchValue) { /* ... */ }

    }
}