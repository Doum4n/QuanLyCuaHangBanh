    using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Invoice;
using QuanLyCuaHangBanh.Views.Invoice.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Presenters
{
    public class SalesInvoicePresenter(ISalesInvoiceView view, IRepositoryProvider provider) : PresenterBase<SalesInvoice>(view, provider)
    {
        public override void LoadData()
        {
            BindingSource.DataSource = Provider.GetRepository<SalesInvoice>().GetAllAsDto<InvoiceDTO>(
                i => new SaleInvoiceDTO
                (
                    i.ID,
                    i.Employee.Name,
                    i.Date,
                    i.InvoiceDetails.Sum(o => o.Quantity * o.Product_Unit.UnitPrice),
                    i.Status
                )
            );
            View.SetBindingSource(BindingSource);
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnImport(object? sender, EventArgs e)
        {
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
                        Provider.GetRepository<SalesInvoice>().Update(salesInvoice);
                        foreach (var product in invoiceInputView.Products)
                        {
                            product.InvoiceID = salesInvoice.ID;
                            product.ProductUnitId = product.ProductUnitId;
                            Provider.GetRepository<SalesInvoice_Detail>().Add(product.ToSalesInvoiceDetail());
                            View.Message = "Cập nhật hóa đơn thành công!";
                            LoadData();
                        }
                    }
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            SalesInvoiceInputView invoiceInputView = new SalesInvoiceInputView();
            if (invoiceInputView.ShowDialog() == DialogResult.OK)
            {
                if(invoiceInputView.Tag is SalesInvoice salesInvoice)
                {
                    Provider.GetRepository<SalesInvoice>().Add(salesInvoice);

                    MessageBox.Show(salesInvoice.ID.ToString());

                    foreach (var product in invoiceInputView.Products)
                    {
                        product.InvoiceID = salesInvoice.ID;
                        product.ProductUnitId = product.ProductUnitId;
                        Provider.GetRepository<SalesInvoice_Detail>().Add(product.ToSalesInvoiceDetail());

                        View.Message = "Thêm hóa đơn thành công!";
                        LoadData();
                    }
                }
            }

        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is InvoiceDTO invoiceDTO)
            {
                var salesInvoice = Provider.GetRepository<SalesInvoice>().GetByValue(invoiceDTO.ID);
                if (salesInvoice != null)
                {
                    Provider.GetRepository<SalesInvoice>().Delete(salesInvoice);
                    View.Message = "Xóa hóa đơn thành công!";
                    LoadData();
                }
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
