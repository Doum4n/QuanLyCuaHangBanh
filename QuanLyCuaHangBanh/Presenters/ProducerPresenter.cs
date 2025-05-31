using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Services;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.Views.Suplier;

namespace QuanLyCuaHangBanh.Presenters
{
    class ProducerPresenter(ISuplierView view, SupplierService service) : PresenterBase<Supplier>(view, service)
    {
        private IList<SupplierDTO> supplies = new List<SupplierDTO>();
        public override async Task InitializeAsync()
        {
            supplies = await ((SupplierService)Service).GetAllOrdersAsDto();
            BindingSource.DataSource = supplies;
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
            SuplierInputView producerInputView = new SuplierInputView((SupplierDTO)this.View.SelectedItem);
            if (producerInputView.ShowDialog() == DialogResult.OK)
            {
                
                if (producerInputView.Tag is (Supplier producer))
                {
                    producer.ID = ((SupplierDTO)this.View.SelectedItem).ID;
                    ((SupplierService)Service).UpdateSupplier(producer);
                    InitializeAsync();
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            SuplierInputView producerInputView = new SuplierInputView();
            if (producerInputView.ShowDialog() == DialogResult.OK)
            {
                if (producerInputView.Tag is (Supplier producer))
                {
                    ((SupplierService)Service).AddSupplier(producer);
                    InitializeAsync();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (this.View.SelectedItem is SupplierDTO selectedSupplier)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp {selectedSupplier.Name} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ((SupplierService)Service).DeleteSupplier(selectedSupplier.ID);
                    InitializeAsync();  // Tải lại dữ liệu sau khi xóa
                }
            }
            else
            {
                ShowMessage("Vui lòng chọn nhà cung cấp để xóa.", "Thông báo", MessageBoxIcon.Warning);
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            string searchValue = this.View.SearchValue.ToLower();  // Chuyển đổi sang chữ thường để tìm kiếm không phân biệt chữ hoa/thường
                                                                   // 
            if (string.IsNullOrEmpty(searchValue))
            {
                InitializeAsync();  // Nếu không có giá trị tìm kiếm, tải lại tất cả dữ liệu
            }
            else
            {
                if(supplies != null)
                {
                    var filteredItems = supplies
                        .Where(item => item.MatchesSearch(searchValue))
                        .ToList();
                    BindingSource.DataSource = filteredItems;
                }
                else
                {
                    ShowMessage("Dữ liệu không khả dụng để tìm kiếm.", "Lỗi", MessageBoxIcon.Error);
                }
            }
        }
    }
}
