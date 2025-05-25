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

namespace QuanLyCuaHangBanh.Presenters
{
    public class PurchasePresenter(IPurchaseView view, IRepositoryProvider provider) : PresenterBase<PurchaseInvoice>(view, provider)
    {

        private int purchaseInvoiceId { get; set; } = 0;

        public override void LoadData()
        {
            BindingSource.DataSource = Provider.GetRepository<PurchaseInvoice>().GetAllAsDto<PurchaseInvoiceDTO>(
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
            View.SetBindingSource(BindingSource);
        }

        public override void OnExport(object? sender, EventArgs e)
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

            foreach (var item in BindingSource.List)
            {
                if (item is PurchaseInvoiceDTO purchaseInvoiceDTO)
                {
                    var purchaseInvoice = Provider.GetRepository<PurchaseInvoice>().GetByValue(purchaseInvoiceDTO.ID);
                    IList<PurchaseInvoice_Detail> purchaseInvoiceDetail = ((PurchaseInvoiceDetailRepo)Provider.GetRepository<PurchaseInvoice_Detail>()).GetByPurchaseInvoiceId(purchaseInvoiceDTO.ID);
                    
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
            }

            ExcelHandler.ExportExcel("Hóa đơn nhập", "Hóa đơn nhập", "Chi tiết hóa đơn nhập", dataTable, dataTableDetail);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(
                ImportPurchaseInvoice,
                ImportPurchaseInvoiceDetail
            );
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
            Provider.GetRepository<PurchaseInvoice>().Add(purchaseInvoice);
            purchaseInvoiceId = purchaseInvoice.ID;
        }

        private void ImportPurchaseInvoiceDetail(DataRow row)
        {
            if (purchaseInvoiceId == 0) return;

            var productId = Convert.ToInt32(row["Mã sản phẩm"]);
            var unitId = Convert.ToInt32(row["Mã đơn vị tính"]);

            var productUnit = ((ProductUnitRepo)Provider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

            var purchaseInvoiceDetail = new PurchaseInvoice_Detail
            {
                InvoiceID = purchaseInvoiceId,
                Product_UnitID = productUnit,
                Quantity = Convert.ToInt32(row["Số lượng"]),
                UnitCost = Convert.ToDecimal(row["Giá nhập"]),
                Note = row["Ghi chú"].ToString(),
            };

            Provider.GetRepository<PurchaseInvoice_Detail>().Add(purchaseInvoiceDetail);
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
                if (purchaseInvoiceInputView.Tag is PurchaseInvoice purchaseInvoice)
                {
                    Provider.GetRepository<PurchaseInvoice>().Update(purchaseInvoice);
                    foreach (var item in purchaseInvoiceInputView.Products)
                    {
                        switch(item.Status)
                        {
                            case Status.New:
                                // Add the new item
                                item.InvoiceID = purchaseInvoice.ID;
                                Provider.GetRepository<PurchaseInvoice_Detail>().Add(item.ToPurchaseInvoice_Detail());
                                break;
                            case Status.Deleted:
                                // Remove the item
                                ((PurchaseInvoiceDetailRepo)Provider.GetRepository<PurchaseInvoice_Detail>()).DeleteById(item.ID);
                                break;
                            case Status.Modified:
                                // Update the item
                                item.InvoiceID = purchaseInvoice.ID;
                                Provider.GetRepository<PurchaseInvoice_Detail>().Update(item.ToPurchaseInvoice_Detail());
                                break;
                        }
                        LoadData();
                    }
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
                    var goodsReceiptNote = ((GoodsReceiptNoteDetailRepo)Provider.GetRepository<GoodsReceiptNote_Detail>()).GetReceiptNote_Details(goodsReceiptNoteId);
                    if (goodsReceiptNote != null)
                    {
                        foreach (var item in goodsReceiptNote)
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
                                    item.Note
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
                if(purchaseInvoiceInputView.Tag is PurchaseInvoice purchaseInvoice)
                {
                    Provider.GetRepository<PurchaseInvoice>().Add(purchaseInvoice);

                    foreach (var item in purchaseInvoiceInputView.Products)
                    {
                        item.InvoiceID = purchaseInvoice.ID;
                        Provider.GetRepository<PurchaseInvoice_Detail>().Add(item.ToPurchaseInvoice_Detail());
                    }

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
