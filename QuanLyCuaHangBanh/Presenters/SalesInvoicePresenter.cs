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
using System.Windows.Forms;
using QuanLyCuaHangBanh.Views.ReleaseNote; // Required for DialogResult, MessageBox

namespace QuanLyCuaHangBanh.Presenters
{
    public class SalesInvoicePresenter(ISalesInvoiceView view, SalesInvoiceService service) : PresenterBase<SalesInvoice>(view, service)
    {
        private IList<SaleInvoiceDTO> saleInvoiceDTOs = new List<SaleInvoiceDTO>();
        public override async Task InitializeAsync()
        {
            // Call the service to get data
            saleInvoiceDTOs = await ((SalesInvoiceService)Service).GetAllSalesInvoicesAsDto();
            BindingSource.DataSource = saleInvoiceDTOs;
        }

        public override async void OnExport(object? sender, EventArgs e)
        {
            if (BindingSource.List is IList<SaleInvoiceDTO> saleInvoiceDTOs)
            {
                await ((SalesInvoiceService)Service).ExportSalesInvoices(saleInvoiceDTOs);
            }
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            // If import logic moves to service: _salesInvoiceService.ImportSalesInvoices();
            ((SalesInvoiceService)Service).ImportSalesInvoices();
            InitializeAsync(); // Reload data after import
        }

        public override async void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is SaleInvoiceDTO saleInvoiceDTO)
            {
                SalesInvoiceInputView invoiceInputView = new SalesInvoiceInputView(saleInvoiceDTO);

                invoiceInputView.ShowSelectOrderForm += (sender, e) => ShowSelectOrderForm(invoiceInputView);
                if (invoiceInputView.ShowDialog() == DialogResult.OK && invoiceInputView.Tag is SalesInvoiceData data)
                {
                    // Use the service to update the invoice
                    data.SalesInvoice.ID = saleInvoiceDTO.ID; // Ensure the ID is set for update
                    await ((SalesInvoiceService)Service).UpdateSalesInvoice(data.SalesInvoice, data.AccountsReceivable, invoiceInputView.Products);
                    View.Message = "Cập nhật hóa đơn thành công!";
                    await InitializeAsync(); // Reload data after update
                }
            }
        }
        private int ShowSelectOrderForm(SalesInvoiceInputView inputView)
        {
            SelectOrderView selectOrderForm = new SelectOrderView();
            if (selectOrderForm.ShowDialog() == DialogResult.OK)
            {
                if (selectOrderForm.Tag is int orderId)
                {
                    // Use the service to get order details
                    var order = ((SalesInvoiceService)Service).GetOrderDetails(orderId);
                    if (order != null)
                    {
                        foreach (var item in order)
                        {
                            // foreach (var unit in item. Product_Unit.Product.ProductUnits) // This might need careful review if ProductUnits is always loaded
                            // {
                                var product = new ProductSaleInvoiceDTO(
                                    item.Product_Unit.Product.ID,
                                    item.Product_Unit.Product.Name,
                                    item.Product_Unit.Product.CategoryID,
                                    item.Product_Unit.Product.Category.Name,
                                    item.Product_Unit.Unit.Name,
                                    item.Product_UnitID,
                                    item.Product_Unit.ConversionRate,
                                    item.Quantity,
                                    item.Note,
                                    item.Product_Unit.UnitPrice,
                                    item.Order.CustomerID,
                                    item.Order.PaymentMethod
                                );
                                inputView.AddProduct(product);
                            // }
                        }
                    }
                    return orderId;
                }
            }
            return 0;
        }

        public override async void OnAddNew(object? sender, EventArgs e)
        {
            SalesInvoiceInputView invoiceInputView = new SalesInvoiceInputView();

            invoiceInputView.ShowSelectOrderForm += (sender, e) => ShowSelectOrderForm(invoiceInputView);

            if (invoiceInputView.ShowDialog() == DialogResult.OK)
            {
                if (invoiceInputView.Tag is SalesInvoiceData data)
                {
                    // Use the service to add the new invoice
                    ((SalesInvoiceService)Service).AddSalesInvoice(data.SalesInvoice, data.AccountsReceivable, invoiceInputView.Products);

                    View.Message = "Thêm hóa đơn thành công!";
                    await InitializeAsync(); // Reload data after add
                }
            }
        }

        public override async void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is InvoiceDTO invoiceDTO)
            {
                // Use the service to delete the invoice
                await ((SalesInvoiceService)Service).DeleteSalesInvoice(invoiceDTO.ID);
                View.Message = "Xóa hóa đơn thành công!";
                await InitializeAsync(); // Reload data after deletes
            }
        }

        public override async void OnSearch(object? sender, EventArgs e)
        {
            string searchValue = this.View.SearchValue?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(searchValue))
            {
                await InitializeAsync();
            }
            else
            {
                if (saleInvoiceDTOs != null)
                {
                    var filteredItems = saleInvoiceDTOs
                        .Where(item => item.MatchesSearch(searchValue))
                        .ToList();

                    BindingSource.DataSource = filteredItems;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không khả dụng để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}