using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.Views.ReceiptNote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Presenters
{
    class GoodsReceiptNotePresenter(IGoodsReceiptNoteView view, IRepositoryProvider provider) : PresenterBase<GoodsReceiptNote>(view, provider)
    {

        public override void LoadData()
        {
            BindingSource.DataSource = Provider.GetRepository<GoodsReceiptNote>().GetAllAsDto(
            o => new GoodsReceiptNoteDTO(
                o.ID,
                //o.CreatedBy.ID,
                //o.CreatedBy.Name,
                o.SupplierId,
                o.Supplier.Name,
                o.CreatedDate,
                o.Status,
                o.Note,
                o.GoodsReceiptNoteDetails.Select(g => g.Product).ToList()
                )
            );
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable1 = new DataTable("GoodsReceiptNote");
            dataTable1.Columns.Add("Mã phiếu nhập", typeof(int));
            dataTable1.Columns.Add("Mã nhà cung cấp", typeof(int));
            dataTable1.Columns.Add("Nhà cung cấp", typeof(string));
            dataTable1.Columns.Add("Ngày nhập", typeof(string));
            dataTable1.Columns.Add("Trạng thái", typeof(string));
            dataTable1.Columns.Add("Ghi chú", typeof(string));

            DataTable dataTable2 = new DataTable("GoodsReceiptNote_Detail");
            dataTable2.Columns.Add("Mã phiếu nhập", typeof(int));
            dataTable2.Columns.Add("Mã sản phẩm", typeof(int));
            dataTable2.Columns.Add("Tên sản phẩm", typeof(string));
            dataTable2.Columns.Add("Mã danh mục", typeof(int));
            dataTable2.Columns.Add("Tên danh mục", typeof(string));
            dataTable2.Columns.Add("Mã ĐVT", typeof(int));
            dataTable2.Columns.Add("ĐVT", typeof(string));
            dataTable2.Columns.Add("Số lượng", typeof(int));
            dataTable2.Columns.Add("Giá nhập", typeof(decimal));
            dataTable2.Columns.Add("Ghi chú", typeof(string));

            foreach (var item in BindingSource.List)
            {
                if (item is GoodsReceiptNoteDTO goodsReceiptNote)
                {
                    dataTable1.Rows.Add(
                        goodsReceiptNote.ID, 
                        goodsReceiptNote.SupplierId, 
                        goodsReceiptNote.SupplierName, 
                        goodsReceiptNote.CreatedDate.ToString(), 
                        goodsReceiptNote.Status, 
                        goodsReceiptNote.Note);

                    var goodsReceiptNoteDetails = ((GoodsReceiptNoteDetailRepo)Provider.GetRepository<GoodsReceiptNote_Detail>()).GetReceiptNote_Details(goodsReceiptNote.ID);

                    foreach (var detail in goodsReceiptNoteDetails)
                    {
                        dataTable2.Rows.Add(
                            goodsReceiptNote.ID, 
                            detail.ProductId, 
                            detail.Product?.Name ?? string.Empty, 
                            detail.ProductUnit?.Product?.CategoryID ?? 0, 
                            detail.Product?.Category?.Name ?? string.Empty, 
                            detail.ProductUnit?.UnitID ?? 0, 
                            detail.ProductUnit?.Unit?.Name ?? string.Empty, 
                            detail.Quantity, 
                            detail.PurchasePrice, 
                            detail.Note ?? string.Empty
                        );
                    }

                }
            }

            ExcelHandler.ExportExcel("Phiếu nhập hàng", "Phiếu nhập hàng", "Chi tiết phiếu nhập hàng", dataTable1, dataTable2);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(
                ImportReceiptNote,
                ImportReceiptNoteDetail
            );
            LoadData();
        }

        private void ImportReceiptNoteDetail(DataRow row)
        {
            var productId = int.Parse(row["Mã sản phẩm"].ToString());
            var unitId = int.Parse(row["Mã ĐVT"].ToString());

            var productUnitId = ((ProductUnitRepo)Provider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

            GoodsReceiptNote_Detail goodsReceiptNoteDetail = new GoodsReceiptNote_Detail()
            {
                GoodsReceiptNoteId = int.Parse(row["Mã phiếu nhập"].ToString()),
                ProductId = int.Parse(row["Mã sản phẩm"].ToString()),
                UnitId = int.Parse(row["Mã ĐVT"].ToString()),
                ProductUnitId = productUnitId,
                Quantity = int.Parse(row["Số lượng"].ToString()),
                PurchasePrice = decimal.Parse(row["Giá nhập"].ToString()),
                Note = row["Ghi chú"].ToString()
            };
            Provider.GetRepository<GoodsReceiptNote_Detail>().Add(goodsReceiptNoteDetail);
        }

        private void ImportReceiptNote(DataRow row)
        {
            GoodsReceiptNote goodsReceiptNote = new GoodsReceiptNote()
            {
                ID = int.Parse(row["Mã phiếu nhập"].ToString()),
                SupplierId = int.Parse(row["Mã nhà cung cấp"].ToString()),
                CreatedDate = DateOnly.Parse(row["Ngày nhập"].ToString()),
                Status = row["Trạng thái"].ToString(),
                Note = row["Ghi chú"].ToString()
            };
            Provider.GetRepository<GoodsReceiptNote>().Add(goodsReceiptNote);
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            GoodsReceiptNoteInputView inputView = new GoodsReceiptNoteInputView();
            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is (GoodsReceiptNote goodsReceiptNote))
                {
                    Provider.GetRepository<GoodsReceiptNote>().Add(goodsReceiptNote);

                    foreach (var item in inputView.ProductList)
                    {
                        item.GoodsReceiptNoteId = goodsReceiptNote.ID;
                        Provider.GetRepository<GoodsReceiptNote_Detail>().Add(item.ToGoodsReceiptNoteDetail());
                    }

                    View.Message = "Thêm phiếu nhập thành công!";
                    LoadData();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is GoodsReceiptNoteDTO goodsReceiptNoteDTO)
            {
                var goodsReceiptNote = Provider.GetRepository<GoodsReceiptNote>().GetByValue(goodsReceiptNoteDTO.ID);
                if (goodsReceiptNote != null)
                {
                    Provider.GetRepository<GoodsReceiptNote>().Delete(goodsReceiptNote);
                    View.Message = "Xóa phiếu nhập thành công!";
                    LoadData();
                }
                else
                {
                    View.Message = "Phiếu nhập không tồn tại!";
                }
            }
            else
            {
                View.Message = "Vui lòng chọn phiếu nhập để xóa!";
            }
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            GoodsReceiptNoteInputView inputView = new GoodsReceiptNoteInputView((GoodsReceiptNoteDTO)View.SelectedItem);
            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is (GoodsReceiptNote goodsReceiptNote))
                {
                    Provider.GetRepository<GoodsReceiptNote>().Update(goodsReceiptNote);

                    foreach (var item in inputView.ProductList)
                    {
                        switch (item.Status)
                        {
                            case DTO.Base.Status.New:
                                item.GoodsReceiptNoteId = goodsReceiptNote.ID;
                                Provider.GetRepository<GoodsReceiptNote_Detail>().Add(item.ToGoodsReceiptNoteDetail());
                                break;
                            case DTO.Base.Status.Modified:
                                item.GoodsReceiptNoteId = goodsReceiptNote.ID;
                                Provider.GetRepository<GoodsReceiptNote_Detail>().Update(item.ToGoodsReceiptNoteDetail());
                                break;
                            case DTO.Base.Status.Deleted:
                                Provider.GetRepository<GoodsReceiptNote_Detail>().Delete(item.ToGoodsReceiptNoteDetail());
                                break;
                            case DTO.Base.Status.None:
                                break;
                        }
                    }

                    View.Message = "Cập nhật phiếu nhập thành công!";
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
