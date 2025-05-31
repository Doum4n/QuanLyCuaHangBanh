using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Reports; // Vẫn cần nếu sử dụng QLCHBDataSet
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views.Manufacturer;
using QuanLyCuaHangBanh.Services; // Thêm namespace của Service
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks; // Thêm để sử dụng DialogResult và MessageBox

namespace QuanLyCuaHangBanh.Presenters
{
    public class ManufacturerPresenter : PresenterBase<Manufacturer>
    {
        public ManufacturerPresenter(IManufacturerView view, ManufacturerService manufacturerService)
            : base(view, (IService)manufacturerService) // Truyền service vào PresenterBase
        {
        }

        public override async Task InitializeAsync()
        {
            BindingSource.DataSource = await ((ManufacturerService)Service).GetAllManufacturers();
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = ((ManufacturerService)Service).ExportManufacturersToDataTable((IEnumerable<Manufacturer>)BindingSource.List);
            ExcelHandler.ExportExcel("Danh sách nhà sản xuất", "Nhà sản xuất", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(((ManufacturerService)Service).ImportManufacturerFromDataRow);
            InitializeAsync(); // Load lại dữ liệu sau khi import
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Manufacturer selectedManufacturer)
            {
                // Chú ý: IManufacturerInputView có thể cần là một lớp cụ thể (ví dụ: ManufacturerInputView)
                var inputView = new ManufacturerInputView(selectedManufacturer);
                if (inputView.ShowDialog() == DialogResult.OK)
                {
                    if (inputView.Tag is Manufacturer manufacturer)
                    {
                        ((ManufacturerService)Service).UpdateManufacturer(manufacturer);
                        View.Message = "Cập nhật nhà sản xuất thành công!";
                        InitializeAsync();
                    }
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một nhà sản xuất để chỉnh sửa.";
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            // Chú ý: IManufacturerInputView có thể cần là một lớp cụ thể (ví dụ: ManufacturerInputView)
            var inputView = new ManufacturerInputView();
            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is Manufacturer manufacturer)
                {
                    ((ManufacturerService)Service).AddManufacturer(manufacturer);
                    View.Message = "Thêm nhà sản xuất thành công!";
                    InitializeAsync();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Manufacturer manufacturer)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà sản xuất này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ((ManufacturerService)Service).DeleteManufacturer(manufacturer);
                    View.Message = "Xóa nhà sản xuất thành công!";
                    InitializeAsync();
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một nhà sản xuất để xóa.";
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(View.SearchValue))
            {
                InitializeAsync(); // Reload all data if search text is empty
            }
            else
            {
                BindingSource.DataSource = ((ManufacturerService)Service).SearchManufacturers(View.SearchValue);
            }
        }
    }
}