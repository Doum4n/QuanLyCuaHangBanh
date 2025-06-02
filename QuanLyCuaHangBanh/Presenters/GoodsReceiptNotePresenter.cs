using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories; // Vẫn cần để ép kiểu hoặc nếu có các repo cụ thể
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.Views.ReceiptNote;
using QuanLyCuaHangBanh.Services; // Thêm namespace của Service
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Thêm nếu dùng DialogResult

namespace QuanLyCuaHangBanh.Presenters
{
    class GoodsReceiptNotePresenter(IGoodsReceiptNoteView view, GoodsReceiptNoteService goodsReceiptNoteService) : PresenterBase<GoodsReceiptNote>(view, (IService)goodsReceiptNoteService)
    {
        private IList<GoodsReceiptNoteDTO> _goodsReceiptNoteDTOs = new List<GoodsReceiptNoteDTO>();
        public override async Task InitializeAsync()
        {
            _goodsReceiptNoteDTOs = await ((GoodsReceiptNoteService)Service).GetAllGoodsReceiptNotesAsDto();
            BindingSource.DataSource = _goodsReceiptNoteDTOs;
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            var (dataTable1, dataTable2) = ((GoodsReceiptNoteService)Service).ExportGoodsReceiptNotes((IEnumerable<GoodsReceiptNoteDTO>)BindingSource.List);
            ExcelHandler.ExportExcel("Phiếu nhập hàng", "Phiếu nhập hàng", "Chi tiết phiếu nhập hàng", dataTable1, dataTable2);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(
                ((GoodsReceiptNoteService)Service).ImportGoodsReceiptNote,
                ((GoodsReceiptNoteService)Service).ImportGoodsReceiptNoteDetail
            );
            InitializeAsync();
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            GoodsReceiptNoteInputView inputView = new GoodsReceiptNoteInputView();
            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is (GoodsReceiptNote goodsReceiptNote))
                {
                    ((GoodsReceiptNoteService)Service).AddGoodsReceiptNote(goodsReceiptNote, inputView.ProductList);
                    View.Message = "Thêm phiếu nhập thành công!";
                    InitializeAsync();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is GoodsReceiptNoteDTO goodsReceiptNoteDTO)
            {
                try
                {
                    ((GoodsReceiptNoteService)Service).DeleteGoodsReceiptNote(goodsReceiptNoteDTO.ID);
                    View.Message = "Xóa phiếu nhập thành công!";
                    InitializeAsync();
                }
                catch (InvalidOperationException ex)
                {
                    View.Message = ex.Message;
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
                    ((GoodsReceiptNoteService)Service).UpdateGoodsReceiptNote(goodsReceiptNote, inputView.ProductList);
                    View.Message = "Cập nhật phiếu nhập thành công!";
                    InitializeAsync();
                }
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            string searchValue = this.View.SearchValue.ToLower();  // Chuyển đổi sang chữ thường để tìm kiếm không phân biệt chữ hoa/thường
            if (string.IsNullOrEmpty(searchValue))
            {
                InitializeAsync(); // Reload all data if search value is empty
            }
            else
            {
                if (_goodsReceiptNoteDTOs != null)
                {
                    var searchResult = _goodsReceiptNoteDTOs.Where(x => x.MatchesSearch(searchValue)).ToList();
                    BindingSource.DataSource = searchResult;
                }
                else
                {
                    MessageBox.Show("Dữ liệu không khả dụng để tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}