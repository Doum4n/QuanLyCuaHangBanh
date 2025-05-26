// QuanLyCuaHangBanh.Presenters/SalesInvoicePresenter.cs
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.DTO.Base; // For Status enum if used in DTOs
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views.Invoice;
using QuanLyCuaHangBanh.Views.Invoice.SalesInvoice;
using QuanLyCuaHangBanh.Services; // Add this namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Required for DialogResult, MessageBox

namespace QuanLyCuaHangBanh.Presenters
{
    public class SalesInvoicePresenter : PresenterBase<SalesInvoice>
    {
        // Declare the service as a readonly field

        // Constructor now takes SalesInvoiceService via DI
        public SalesInvoicePresenter(ISalesInvoiceView view, SalesInvoiceService service)
            : base(view, service) // Pass view and provider to the base class
        {
            // Initialize BindingSource here to prevent NullReferenceException
            BindingSource = new BindingSource();

            // Assign the injected service
        }

        public override void LoadData()
        {
            // Call the service to get data
            BindingSource.DataSource = ((SalesInvoiceService)Service).GetAllSalesInvoicesAsDto();
            View.SetBindingSource(BindingSource);
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            // If export logic moves to service: _salesInvoiceService.ExportSalesInvoices();
            throw new NotImplementedException();
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            // If import logic moves to service: _salesInvoiceService.ImportSalesInvoices();
            throw new NotImplementedException();
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is InvoiceDTO invoiceDTO)
            {
                SalesInvoiceInputView invoiceInputView = new SalesInvoiceInputView(invoiceDTO);
                if (invoiceInputView.ShowDialog() == DialogResult.OK)
                {
                    if (invoiceInputView.Tag is SalesInvoice salesInvoice)
                    {
                        // Use the service to update the invoice
                        ((SalesInvoiceService)Service).UpdateSalesInvoice(salesInvoice, invoiceInputView.Products);
                        View.Message = "Cập nhật hóa đơn thành công!";
                        LoadData(); // Reload data after update
                    }
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            SalesInvoiceInputView invoiceInputView = new SalesInvoiceInputView();
            if (invoiceInputView.ShowDialog() == DialogResult.OK)
            {
                if (invoiceInputView.Tag is SalesInvoice salesInvoice)
                {
                    // Use the service to add the new invoice
                    ((SalesInvoiceService)Service).AddSalesInvoice(salesInvoice, invoiceInputView.Products);

                    MessageBox.Show(salesInvoice.ID.ToString()); // Keep for showing the new ID

                    View.Message = "Thêm hóa đơn thành công!";
                    LoadData(); // Reload data after add
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is InvoiceDTO invoiceDTO)
            {
                // Use the service to delete the invoice
                ((SalesInvoiceService)Service).DeleteSalesInvoice(invoiceDTO.ID);
                View.Message = "Xóa hóa đơn thành công!";
                LoadData(); // Reload data after delete
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            // If search logic moves to service:
            // string searchValue = this.View.SearchValue?.Trim() ?? string.Empty;
            // BindingSource.DataSource = _salesInvoiceService.SearchSalesInvoices(searchValue);
            throw new NotImplementedException();
        }
    }
}