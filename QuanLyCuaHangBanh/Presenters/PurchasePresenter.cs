using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Models.Base;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.Views.Invoice.PurchaseInvoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Services; // Add this using statement

namespace QuanLyCuaHangBanh.Presenters
{
    public class PurchasePresenter(IPurchaseView view, PurchaseService service) : PresenterBase<PurchaseInvoice>(view, service)
    {
        private IList<PurchaseInvoiceDTO> purchaseInvoices = new List<PurchaseInvoiceDTO>();
        public override async Task InitializeAsync()
        {
            purchaseInvoices = await ((PurchaseService)Service).GetAllPurchaseInvoices();
            BindingSource.DataSource = purchaseInvoices;
        }

        public override async void OnExport(object? sender, EventArgs e)
        {
            if (BindingSource.List is IList<PurchaseInvoiceDTO> purchaseInvoiceDTOs)
            {
                await ((PurchaseService)Service).ExportPurchaseInvoices(purchaseInvoiceDTOs);
            }
        }

        public override async void OnImport(object? sender, EventArgs e)
        {
            ((PurchaseService)Service).ImportPurchaseInvoices();
            await InitializeAsync(); // Reload data after import
        }

        public override async void OnEdit(object? sender, EventArgs e)
        {
            PurchaseInvoiceInputView purchaseInvoiceInputView = new PurchaseInvoiceInputView((PurchaseInvoiceDTO)View.SelectedItem);

            purchaseInvoiceInputView.AddProductEvent += (productReleaseDTO) =>
            {
                purchaseInvoiceInputView.AddProduct(productReleaseDTO);
            };

            purchaseInvoiceInputView.ShowSelecteceiptFrom += (s, e) => ShowSelecteceiptFrom(purchaseInvoiceInputView);

            if (purchaseInvoiceInputView.ShowDialog() == DialogResult.OK)
            {
                if (purchaseInvoiceInputView.Tag is (PurchaseInvoice purchaseInvoice, AccountsPayable accountsPayable))
                {
                    ((PurchaseService)Service).UpdatePurchaseInvoice(purchaseInvoice, accountsPayable, purchaseInvoiceInputView.Products);
                    await InitializeAsync();
                }
            }
        }

        private int ShowSelecteceiptFrom(PurchaseInvoiceInputView purchaseInvoiceInputView)
        {
            SelectReceiptNoteView selectGoodsReciveNoteForm = new SelectReceiptNoteView();

            if (selectGoodsReciveNoteForm.ShowDialog() == DialogResult.OK)
            {
                if (selectGoodsReciveNoteForm.Tag is int goodsReceiptNoteId)
                {
                    var goodsReceiptNoteDetails = ((PurchaseService)Service).GetGoodsReceiptNoteDetails(goodsReceiptNoteId);
                    if (goodsReceiptNoteDetails != null)
                    {
                        foreach (var item in goodsReceiptNoteDetails)
                        {
                            if (item.Product != null)
                            {
                                foreach (var unit in item.Product.ProductUnits)
                                {
                                    var product = new ProductPurchaseInvoiceDTO(
                                    item.ID,
                                    0, // Invoice chưa được tạo
                                    item.Product.Name,
                                    item.Product.CategoryID,
                                    item.Product.Category.Name,
                                    unit.Unit.Name,
                                    unit.ID,
                                    unit.ConversionRate,
                                    item.Quantity,
                                    item.Note ?? string.Empty,
                                    item.PurchasePrice
                                    );

                                    product.Status = Status.New; // Gán status là mới
                                    purchaseInvoiceInputView.InvokeAddProductEvent(product);
                                }
                            }
                        }
                    }
                    return goodsReceiptNoteId;
                }
            }
            return 0;
        }

        public override async void OnAddNew(object? sender, EventArgs e)
        {
            PurchaseInvoiceInputView purchaseInvoiceInputView = new PurchaseInvoiceInputView();

            purchaseInvoiceInputView.AddProductEvent += (productReleaseDTO) =>
            {
                purchaseInvoiceInputView.AddProduct(productReleaseDTO);
            };

            purchaseInvoiceInputView.ShowSelecteceiptFrom += (s, e) => ShowSelecteceiptFrom(purchaseInvoiceInputView);

            if (purchaseInvoiceInputView.ShowDialog() == DialogResult.OK)
            {
                if (purchaseInvoiceInputView.Tag is (PurchaseInvoice purchaseInvoice, AccountsPayable accountsPayable))
                {
                    ((PurchaseService)Service).AddPurchaseInvoice(purchaseInvoice, accountsPayable, purchaseInvoiceInputView.Products);
                    await InitializeAsync();
                }
            }
        }

        public override async void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is PurchaseInvoiceDTO selectedPurchaseInvoice)
            {
                ((PurchaseService)Service).DeletePurchaseInvoice(selectedPurchaseInvoice);
                await InitializeAsync();
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
                purchaseInvoices = purchaseInvoices.Where(p => p.MatchesSearch(searchValue)).ToList();
                BindingSource.DataSource = purchaseInvoices;
            }
        }
    }
}