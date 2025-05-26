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
        public override void LoadData()
        {
            BindingSource.DataSource = ((PurchaseService)Service).GetAllPurchaseInvoices();
            View.SetBindingSource(BindingSource);
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            if (BindingSource.List is IList<PurchaseInvoiceDTO> purchaseInvoiceDTOs)
            {
                ((PurchaseService)Service).ExportPurchaseInvoices(purchaseInvoiceDTOs);
            }
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ((PurchaseService)Service).ImportPurchaseInvoices();
            LoadData(); // Reload data after import
        }

        public override void OnEdit(object? sender, EventArgs e)
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
                    LoadData();
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
                            foreach (var unit in item.Product.ProductUnits)
                            {
                                var product = new ProductPurchaseInvoiceDTO(
                                    item.ID,
                                    0,
                                    item.Product.Name,
                                    item.Product.CategoryID,
                                    item.Product.Category.Name,
                                    unit.Unit.Name,
                                    unit.ID,
                                    unit.ConversionRate,
                                    item.Quantity,
                                    item.Note,
                                    item.PurchasePrice
                                );
                                purchaseInvoiceInputView.InvokeAddProductEvent(product);
                            }
                        }
                    }
                    MessageBox.Show(goodsReceiptNoteId.ToString());
                    return goodsReceiptNoteId;
                }
            }
            return 0;
        }

        public override void OnAddNew(object? sender, EventArgs e)
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
                    LoadData();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}