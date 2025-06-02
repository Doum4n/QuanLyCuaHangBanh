using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Services
{
    public class GoodsReceiptNoteService : IService
    {
        private readonly IRepositoryProvider _provider;

        public GoodsReceiptNoteService(IRepositoryProvider provider)
        {
            _provider = provider;
        }

        public async Task<IList<GoodsReceiptNoteDTO>> GetAllGoodsReceiptNotesAsDto()
        {
            return await _provider.GetRepository<GoodsReceiptNote>().GetAllAsDto(
                o => new GoodsReceiptNoteDTO{
                    ID = o.ID,
                    SupplierId = o.SupplierId,
                    SupplierName = o.Supplier != null ? o.Supplier.Name : string.Empty,
                    CreatedDate = o.CreatedDate,
                    Status = o.Status ?? string.Empty,
                    Note = o.Note ?? string.Empty,
                    Products = o.GoodsReceiptNoteDetails.Select(g => g.Product).ToList()
                }
            );
        }

        public void AddGoodsReceiptNote(GoodsReceiptNote goodsReceiptNote, BindingList<ProductReceiptDTO> productList)
        {
            _provider.GetRepository<GoodsReceiptNote>().Add(goodsReceiptNote);

            foreach (var item in productList)
            {
                item.GoodsReceiptNoteId = goodsReceiptNote.ID;
                _provider.GetRepository<GoodsReceiptNote_Detail>().Add(item.ToGoodsReceiptNoteDetail());
            }
        }

        public void UpdateGoodsReceiptNote(GoodsReceiptNote goodsReceiptNote, BindingList<ProductReceiptDTO> productList)
        {
            _provider.GetRepository<GoodsReceiptNote>().Update(goodsReceiptNote);

            foreach (var item in productList)
            {
                switch (item.Status)
                {
                    case DTO.Base.Status.New:
                        item.GoodsReceiptNoteId = goodsReceiptNote.ID;
                        _provider.GetRepository<GoodsReceiptNote_Detail>().Add(item.ToGoodsReceiptNoteDetail());
                        break;
                    case DTO.Base.Status.Modified:
                        item.GoodsReceiptNoteId = goodsReceiptNote.ID;
                        _provider.GetRepository<GoodsReceiptNote_Detail>().Update(item.ToGoodsReceiptNoteDetail());
                        break;
                    case DTO.Base.Status.Deleted:
                        _provider.GetRepository<GoodsReceiptNote_Detail>().Delete(item.ToGoodsReceiptNoteDetail());
                        break;
                    case DTO.Base.Status.None:
                        break;
                }
            }
        }

        public async Task DeleteGoodsReceiptNote(int id)
        {
            var goodsReceiptNote = await _provider.GetRepository<GoodsReceiptNote>().GetByValue(id);
            if (goodsReceiptNote != null)
            {
                _provider.GetRepository<GoodsReceiptNote>().Delete(goodsReceiptNote);
            }
            else
            {
                throw new InvalidOperationException("Phiếu nhập không tồn tại!");
            }
        }

        public void ImportGoodsReceiptNote(DataRow row)
        {
            GoodsReceiptNote goodsReceiptNote = new GoodsReceiptNote()
            {
                ID = int.Parse(row["Mã phiếu nhập"].ToString()),
                SupplierId = int.Parse(row["Mã nhà cung cấp"].ToString()),
                CreatedDate = DateOnly.Parse(row["Ngày nhập"].ToString()),
                Status = row["Trạng thái"].ToString(),
                Note = row["Ghi chú"].ToString()
            };
            _provider.GetRepository<GoodsReceiptNote>().Add(goodsReceiptNote);
        }

        public void ImportGoodsReceiptNoteDetail(DataRow row)
        {
            var productId = int.Parse(row["Mã sản phẩm"].ToString());
            var unitId = int.Parse(row["Mã ĐVT"].ToString());

            var productUnitId = ((ProductUnitRepo)_provider.GetRepository<Product_Unit>()).GetProductUnitId(productId, unitId);

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
            _provider.GetRepository<GoodsReceiptNote_Detail>().Add(goodsReceiptNoteDetail);
        }

        public (DataTable, DataTable) ExportGoodsReceiptNotes(IEnumerable<GoodsReceiptNoteDTO> goodsReceiptNotes)
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

            foreach (var goodsReceiptNote in goodsReceiptNotes)
            {
                dataTable1.Rows.Add(
                    goodsReceiptNote.ID,
                    goodsReceiptNote.SupplierId,
                    goodsReceiptNote.SupplierName,
                    goodsReceiptNote.CreatedDate.ToString(),
                    goodsReceiptNote.Status,
                    goodsReceiptNote.Note);

                var goodsReceiptNoteDetails = ((GoodsReceiptNoteDetailRepo)_provider.GetRepository<GoodsReceiptNote_Detail>()).GetReceiptNote_Details(goodsReceiptNote.ID);

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
            return (dataTable1, dataTable2);
        }
    }
}