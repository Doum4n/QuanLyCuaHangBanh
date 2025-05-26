using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Services; // Thêm namespace của service
using QuanLyCuaHangBanh.Uitls; // Để sử dụng ExcelHandler
using QuanLyCuaHangBanh.Views.Unit;
using System;
using System.Data;
using System.Linq; // Để sử dụng Where
using System.Windows.Forms; // Thêm namespace này để sử dụng DialogResult và MessageBox

namespace QuanLyCuaHangBanh.Presenters
{
    public class UnitPresenter(IUnitView view, UnitService unitService) : PresenterBase<Unit>(view, unitService)
    {
        public override void LoadData()
        {
            BindingSource.DataSource = ((UnitService)Service).GetAllUnits();
        }

        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = ((UnitService)Service).ExportUnitsToDataTable((IEnumerable<Unit>)BindingSource.List);
            ExcelHandler.ExportExcel("Đơn vị tính", "Đơn vị tính", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(((UnitService)Service).ImportUnitFromDataRow);
            LoadData();
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Unit selectedUnit)
            {
                UnitInputView inputView = new UnitInputView(selectedUnit);
                if (inputView.ShowDialog() == DialogResult.OK)
                {
                    if (inputView.Tag is Unit updatedUnit)
                    {
                        ((UnitService)Service).UpdateUnit(updatedUnit);
                        View.Message = "Cập nhật đơn vị thành công!";
                        LoadData();
                    }
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một đơn vị để chỉnh sửa.";
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            UnitInputView inputView = new UnitInputView();
            if (inputView.ShowDialog() == DialogResult.OK)
            {
                if (inputView.Tag is Unit newUnit)
                {
                    ((UnitService)Service).AddUnit(newUnit);
                    View.Message = "Thêm đơn vị thành công!";
                    LoadData();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Unit unit)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn vị này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ((UnitService)Service).DeleteUnit(unit);
                    View.Message = "Xóa đơn vị thành công!";
                    LoadData();
                }
            }
            else
            {
                View.Message = "Vui lòng chọn một đơn vị để xóa.";
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(View.SearchValue))
            {
                LoadData(); // Reload all data if search text is empty
            }
            else
            {
                BindingSource.DataSource = ((UnitService)Service).SearchUnits(View.SearchValue);
            }
        }
    }
}