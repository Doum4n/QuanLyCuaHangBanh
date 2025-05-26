// QuanLyCuaHangBanh.Services/SalesInvoiceService.cs
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel; // For BindingList
using System.Linq;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO.Base;

namespace QuanLyCuaHangBanh.Services
{
    public class SalesInvoiceService : IService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly QLCHB_DBContext _context; // Required for direct EF Core operations like Includes, FirstOrDefault

        public SalesInvoiceService(IRepositoryProvider repositoryProvider, QLCHB_DBContext context)
        {
            _repositoryProvider = repositoryProvider;
            _context = context;
        }

        public IList<InvoiceDTO> GetAllSalesInvoicesAsDto()
        {
            // This logic is directly from your original LoadData method
            return _repositoryProvider.GetRepository<SalesInvoice>().GetAllAsDto<InvoiceDTO>(
                i => new SaleInvoiceDTO
                (
                    i.ID,
                    i.Employee.Name,
                    i.Date,
                    i.InvoiceDetails.Sum(o => o.Quantity * o.Product_Unit.UnitPrice),
                    i.Status
                )
            );
        }

        public void AddSalesInvoice(SalesInvoice salesInvoice, BindingList<ProductSaleInvoiceDTO> products)
        {
            _repositoryProvider.GetRepository<SalesInvoice>().Add(salesInvoice);
            // After adding, salesInvoice.ID should be populated by the database
            foreach (var productDto in products)
            {
                if (productDto != null) // Ensure productDto is not null
                {
                    // Map ProductDTO to SalesInvoice_Detail model
                    var salesInvoiceDetail = productDto.ToSalesInvoiceDetail();
                    salesInvoiceDetail.InvoiceID = salesInvoice.ID; // Link to the newly added invoice
                    _repositoryProvider.GetRepository<SalesInvoice_Detail>().Add(salesInvoiceDetail);
                }
            }
        }

        public void UpdateSalesInvoice(SalesInvoice salesInvoice, BindingList<ProductSaleInvoiceDTO> products)
        {
            _repositoryProvider.GetRepository<SalesInvoice>().Update(salesInvoice);

            // This part mirrors your original logic for updating invoice details.
            // It currently re-adds details without considering existing ones or deletions.
            // A more robust solution would involve tracking changes (added, modified, deleted)
            // within the 'products' list and applying appropriate repository actions.
            // However, sticking to the "no logic change" rule:
            foreach (var productDto in products)
            {
                if (productDto != null)
                {
                    // Assuming ToSalesInvoiceDetail creates a new instance.
                    // This might lead to duplicate entries if not handled carefully in the UI.
                    // For example, if a product is already on the invoice and just its quantity changes,
                    // you'd typically update the existing detail, not add a new one.
                    var salesInvoiceDetail = productDto.ToSalesInvoiceDetail();
                    salesInvoiceDetail.InvoiceID = salesInvoice.ID; // Ensure it's linked
                    _repositoryProvider.GetRepository<SalesInvoice_Detail>().Add(salesInvoiceDetail);
                }
            }
        }

        public void DeleteSalesInvoice(int invoiceId)
        {
            // IMPORTANT: Delete related entities first due to foreign key constraints.
            // You might need to adjust this based on your actual database cascade delete rules.

            // 1. Delete SalesInvoice_Details linked to this invoice
            var salesInvoiceDetails = _context.SalesInvoiceDetails
                                              .Where(d => d.InvoiceID == invoiceId)
                                              .ToList();
            foreach (var detail in salesInvoiceDetails)
            {
                _repositoryProvider.GetRepository<SalesInvoice_Detail>().Delete(detail);
            }

            // 2. Delete the SalesInvoice itself
            var salesInvoiceToDelete = _repositoryProvider.GetRepository<SalesInvoice>().GetByValue(invoiceId);
            if (salesInvoiceToDelete != null)
            {
                _repositoryProvider.GetRepository<SalesInvoice>().Delete(salesInvoiceToDelete);
            }
        }

        // You would also move other methods here if they become complex enough:
        // public DataTable GetSalesInvoiceDataTableForExport() { /* ... */ }
        // public void ImportSalesInvoice(DataRow row) { /* ... */ }
        // public IList<InvoiceDTO> SearchSalesInvoices(string searchValue) { /* ... */ }
    }
}