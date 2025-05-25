using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views.ReleaseNote;
using System.Data;
using QuanLyCuaHangBanh.Data;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Presenters
{
    public class WarehouseReleaseNotePresenter(IWareHouseReleaseNoteView view, IRepositoryProvider provider) : PresenterBase<IWareHouseReleaseNoteView>(view, provider)
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private ProductReleaseDTO productReleaseDTO;
        public override void LoadData()
        {
            BindingSource.DataSource = Provider.GetRepository<WarehouseReleaseNote>().GetAllAsDto<WarehouseReleaseNoteDTO>(
                o => new WarehouseReleaseNoteDTO(
                    o.ID,
                    //o.CreatedById,
                    //o.CreatedBy.Name,
                    o.CreatedDate,
                    o.Status,
                    o.Note
                )
            );
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable releaseNoteDt = new DataTable();

            releaseNoteDt.Columns.Add("Mã phiếu xuất", typeof(int));
            releaseNoteDt.Columns.Add("Nhân viên lập", typeof(string));
            releaseNoteDt.Columns.Add("Ngày lập", typeof(string));
            releaseNoteDt.Columns.Add("Trạng thái", typeof(string));
            releaseNoteDt.Columns.Add("Ghi chú", typeof(string));

            DataTable releaseNoteDetailDt = new DataTable();
            releaseNoteDetailDt.Columns.Add("Mã phiếu xuất", typeof(string));
            releaseNoteDetailDt.Columns.Add("Mã sản phẩm", typeof(string));
            releaseNoteDetailDt.Columns.Add("Tên sản phẩm", typeof(string));
            releaseNoteDetailDt.Columns.Add("Mã nhà cung cấp", typeof(string));
            releaseNoteDetailDt.Columns.Add("Tên nhà cung cấp", typeof(string));
            releaseNoteDetailDt.Columns.Add("Mã ĐVT", typeof(string));
            releaseNoteDetailDt.Columns.Add("Tên ĐVT", typeof(string));
            releaseNoteDetailDt.Columns.Add("Số lượng", typeof(string));

            foreach (var item in BindingSource.List)
            {
                if( item is WarehouseReleaseNoteDTO dTO)
                {
                    var releaseNotes = context.WarehouseReleaseNotes
                        .Include(o => o.CreatedBy)
                        .Where(o => o.ID == dTO.ID)
                        .ToList();

                    foreach (var note in releaseNotes)
                    {
                        releaseNoteDt.Rows.Add(
                            note.ID,
                            note.CreatedBy?.Name ?? "",
                            note.CreatedDate.ToString(),
                            note.Status,
                            note.Note
                        );
                    }

                    var releaseNoteDetails = context.WarehouseReleaseNoteDetails
                        .Include(o => o.Product_Unit)
                        .ThenInclude(o => o.Product)
                        .ThenInclude(o => o.Category)
                        .Include(o => o.Product_Unit)
                        .ThenInclude(o => o.Unit)
                        .Where(o => o.WarehouseReleaseNoteId == dTO.ID)
                        .ToList();

                    foreach( var detail in releaseNoteDetails)
                    {
                        releaseNoteDetailDt.Rows.Add(
                            detail.WarehouseReleaseNoteId,
                            detail.Product_Unit.Product.ID,
                            detail.Product_Unit.Product.Name,
                            detail.Product_Unit.Product.CategoryID,
                            detail.Product_Unit.Product.Category.Name,
                            detail.Product_Unit.UnitID,
                            detail.Product_Unit.Unit.Name,
                            detail.Quantity
                        );
                    }
                }
            }


            ExcelHandler.ExportExcel("Phiếu xuất", "Phiếu xuất", "Chi tiết phiếu xuất", releaseNoteDt, releaseNoteDetailDt);
;        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(
            ImportReleaseNote,
            ImportReleaseNoteDetail
            );
        }


        private void ImportReleaseNote(DataRow row)
        {
            WarehouseReleaseNote warehouseReleaseNote = new WarehouseReleaseNote()
            {
                ID = int.Parse(row["Mã phiếu xuất"].ToString()),
                CreatedDate = DateOnly.Parse(row["Ngày lập"].ToString()),
                CreatedByID = int.Parse(row["Nhân viên lập"].ToString()),
                Note = row["Ghi chú"].ToString(),
                Status = row["Trạng thái"].ToString()
            };

            Provider.GetRepository<WarehouseReleaseNote>().Add(warehouseReleaseNote);
        }

        private void ImportReleaseNoteDetail(DataRow row)
        {
            var productId = int.Parse(row["Mã sản phẩm"].ToString());
            var unitId = int.Parse(row["Mã ĐVT"].ToString());

            var productUnitId = ((ProductUnitRepo) Provider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

            WarehouseReleaseNote_Detail warehouseReleaseNote_Detail = new WarehouseReleaseNote_Detail()
            {
                Product_UnitID = productUnitId,
                Quantity = int.Parse(row["Số lượng"].ToString()),
                Note = "",
                WarehouseReleaseNoteId = int.Parse(row["Mã phiếu xuất"].ToString())
            };

            Provider.GetRepository<WarehouseReleaseNote_Detail>().Add(warehouseReleaseNote_Detail);
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            ReleaseNoteInputView inputView = new ReleaseNoteInputView();

            inputView.AddProductEvent += (productReleaseDTO) =>
            {
                inputView.AddProduct(productReleaseDTO);
            };

            inputView.ShowSelectGoodsReciveNoteForm += (s, e) => ShowSelectGoodsReciveNoteForm(inputView);
            inputView.ShowSelectOrderForm += (s, e) => ShowSelectOrderForm(inputView);

            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is WarehouseReleaseNote warehouseReleaseNote)
                {
                    Provider.GetRepository<WarehouseReleaseNote>().Add(warehouseReleaseNote);

                    foreach (var item in inputView.Products)
                    {
                        item.WarehouseReleaseNoteId = warehouseReleaseNote.ID;
                        item.ProductUnitId = item.ProductUnitId;
                        Provider.GetRepository<WarehouseReleaseNote_Detail>().Add(item.ToWarehouseReleaseNoteDetail());

                        View.Message = "Thêm phiếu xuất thành công!";
                        LoadData();
                    }
                }
            }
        }

        private int ShowSelectOrderForm(ReleaseNoteInputView inputView)
        {
            SelectOrderView selectOrderForm = new SelectOrderView();
            if (selectOrderForm.ShowDialog() == DialogResult.OK)
            {
                if (selectOrderForm.Tag is int orderId)
                {
                    var order = ((OrderDetailRepo)Provider.GetRepository<Order_Detail>()).GetOrderDetail(orderId);
                    if (order != null)
                    {
                        foreach (var item in order)
                        {
                            foreach (var unit in item.Product_Unit.Product.ProductUnits)
                            {
                                var product = new ProductReleaseDTO(
                                    item.Product_Unit.Product.ID,
                                    item.Product_Unit.Product.Name,
                                    item.Product_Unit.Product.CategoryID,
                                    item.Product_Unit.Product.Category.Name,
                                    unit.Unit.Name,
                                    item.Product_UnitID,
                                    item.Product_Unit.ConversionRate,
                                    item.Quantity,
                                    item.Note
                                );
                                inputView.RaiseAddProductEvent(product);
                            }
                        }
                    }
                    MessageBox.Show(orderId.ToString());
                    return orderId;
                }
            }
            return 0;
        }

        private int ShowSelectGoodsReciveNoteForm(ReleaseNoteInputView inputView)
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
                            //foreach (var unit in item.ProductUnit)
                            {
                                var product = new ProductReleaseDTO(
                                    item.Product.ID,
                                    item.Product.Name,
                                    item.Product.CategoryID,
                                    item.Product.Category.Name,
                                    item.Unit.Name,
                                    item.ProductUnitId,
                                    item.ProductUnit.ConversionRate,
                                    item.Quantity,
                                    item.Note
                                );

                                MessageBox.Show(product.ProductUnitId.ToString());

                                inputView.RaiseAddProductEvent(product);
                            }
                        }
                    }
                    MessageBox.Show(goodsReceiptNoteId.ToString());
                    return goodsReceiptNoteId;
                }
            }
            return 0;
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is WarehouseReleaseNoteDTO selectedItem)
            {
                var warehouseReleaseNote = Provider.GetRepository<WarehouseReleaseNote>().GetByValue(selectedItem.ID);
                if (warehouseReleaseNote != null)
                {
                    Provider.GetRepository<WarehouseReleaseNote>().Delete(warehouseReleaseNote);
                    View.Message = "Xóa phiếu xuất thành công!";
                    LoadData();
                }
                else
                {
                    View.Message = "Phiếu xuất không tồn tại!";
                }
            }
            else
            {
                View.Message = "Vui lòng chọn phiếu xuất để xóa!";
            }
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            ReleaseNoteInputView inputView = new ReleaseNoteInputView((WarehouseReleaseNoteDTO)View.SelectedItem);

            inputView.AddProductEvent += (productReleaseDTO) =>
            {
                inputView.AddProduct(productReleaseDTO);
            };

            inputView.ShowSelectGoodsReciveNoteForm += (s, e) => ShowSelectGoodsReciveNoteForm(inputView);

            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is WarehouseReleaseNote warehouseReleaseNote)
                {
                    Provider.GetRepository<WarehouseReleaseNote>().Update(warehouseReleaseNote);

                    foreach (var item in inputView.Products)
                    {
                        switch (item.Status)
                        {
                            case DTO.Base.Status.New:
                                item.WarehouseReleaseNoteId = warehouseReleaseNote.ID;
                                item.ProductUnitId = item.ProductUnitId;
                                Provider.GetRepository<WarehouseReleaseNote_Detail>().Add(item.ToWarehouseReleaseNoteDetail());
                                break;
                            case DTO.Base.Status.Modified:
                                item.WarehouseReleaseNoteId = warehouseReleaseNote.ID;
                                item.ProductUnitId = item.ProductUnitId;
                                item.ID = item.ID; // Ensure ID is set for update
                                Provider.GetRepository<WarehouseReleaseNote_Detail>().Update(item.ToWarehouseReleaseNoteDetail());
                                break;
                            case DTO.Base.Status.Deleted:
                                ((WarehouseReleaseNoteDetailRepo)Provider.GetRepository<WarehouseReleaseNote_Detail>()).DeleteByID(item.ID);
                                break;
                            case DTO.Base.Status.None:
                                break;
                        }

                        View.Message = "Cập nhật phiếu xuất thành công!";
                        LoadData();
                    }
                }
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
