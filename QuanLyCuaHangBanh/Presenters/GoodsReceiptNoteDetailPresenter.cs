using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.DTO;

namespace QuanLyCuaHangBanh.Presenters
{
    class GoodsReceiptNoteDetailPresenter(IView view, IRepositoryProvider provider) : PresenterBase<GoodsReceiptNote_Detail>(view, provider)
    {
        public override void LoadData()
        {
            BindingSource.DataSource = Provider.GetRepository<GoodsReceiptNote_Detail>().GetAllAsDto(
                o => new ProductReceiptDTO(
                    o.ID,
                    o.Product.ID,
                    o.Product.Name,
                    o.Product.Category.ID,
                    o.Product.Category.Name,
                    o.Unit.ID,
                    o.Unit.Name,
                    o.ProductUnitId,
                    o.ProductUnit.ConversionRate,
                    o.PurchasePrice,
                    o.Quantity,
                    o.Note
                )
            );
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
