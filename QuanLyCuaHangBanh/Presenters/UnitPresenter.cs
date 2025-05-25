using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Unit;
using System.Data;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Presenters
{
    public class UnitPresenter(IUnitView view, IRepositoryProvider provider) : PresenterBase<Unit>(view, provider)
    {
        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = new DataTable("Units");
            dataTable.Columns.Add("Mã ĐVT", typeof(int));
            dataTable.Columns.Add("ĐVT", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));

            foreach (var unit in Provider.GetRepository<Unit>().GetAll())
            {
                dataTable.Rows.Add(unit.ID, unit.Name, unit.Description);
            }

            ExcelHandler.ExportExcel("Đơn vị tính", "Đơn vị tính", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel((row) =>
            {
                if (row.ItemArray.Length >= 3)
                {
                    Unit unit = new Unit
                    {
                        //ID = Convert.ToInt32(row[0]),
                        Name = row[1].ToString() ?? string.Empty,
                        Description = row[2].ToString() ?? string.Empty
                    };
                    Provider.GetRepository<Unit>().Add(unit);
                }
            });
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            UnitInputView inputView = new UnitInputView((Unit)View.SelectedItem);
            if(inputView.ShowDialog() == DialogResult.OK)
            {
                if(inputView.Tag is Unit updatedUnit)
                {
                    Provider.GetRepository<Unit>().Update(updatedUnit);
                    View.Message = "Cập nhật đơn vị thành công!";
                    LoadData();
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            UnitInputView inputView = new UnitInputView();
            if(inputView.ShowDialog() == DialogResult.OK)
            {
                if(inputView.Tag is Unit newUnit)
                {
                    Provider.GetRepository<Unit>().Add(newUnit);
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
                    Provider.GetRepository<Unit>().Delete(unit);
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
                var searchResults = Provider.GetRepository<Unit>()
                    .GetAll()
                    .Where(u => u.Name.Contains(View.SearchValue, StringComparison.OrdinalIgnoreCase) ||
                                u.Description.Contains(View.SearchValue, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                BindingSource.DataSource = searchResults;
            }
        }
    }
}
