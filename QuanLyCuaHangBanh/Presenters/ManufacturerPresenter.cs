using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Reports;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views.Manufacturer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Presenters
{
    public class ManufacturerPresenter(IManufacturerView view, IRepositoryProvider provider) : PresenterBase<Manufacturer>(view, provider)
    {
        private QLCHBDataSet.ManufacturersDataTable _manufacturersDataTable = new QLCHBDataSet.ManufacturersDataTable();
        public override void OnExport(object? sender, EventArgs e)
        {
            DataTable dataTable = new DataTable("Manufacturers");
            dataTable.Columns.Add("Mã nhà cung cấp", typeof(int));
            dataTable.Columns.Add("Nhà cung cấp", typeof(string));
            dataTable.Columns.Add("Mô tả", typeof(string));

            foreach (var manufacturer in Provider.GetRepository<Manufacturer>().GetAll())
            {
                dataTable.Rows.Add(manufacturer.ID, manufacturer.Name, manufacturer.Description);
            }

            ExcelHandler.ExportExcel("Danh sách nhà sản xuất", "Nhà sản xuất", dataTable);
        }

        public override void OnImport(object? sender, EventArgs e)
        {
            ExcelHandler.ImportExcel(
                (row) =>
                {
                    var manufacturer = new Manufacturer
                    {
                        //ID = Convert.ToInt32(row["Mã nhà cung cấp"]),
                        Name = row["Nhà cung cấp"].ToString() ?? string.Empty,
                        Description = row["Mô tả"].ToString() ?? string.Empty
                    };

                    Provider.GetRepository<Manufacturer>().Add(manufacturer);
                    LoadData();
                }
            );
        }

        public override void OnEdit(object? sender, EventArgs e)
        {
            var inputView = new IManufacturerInputView((Manufacturer)View.SelectedItem);
            if (inputView.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(inputView.Tag is Manufacturer manufacturer)
                {
                    Provider.GetRepository<Manufacturer>().Update(manufacturer);
                    LoadData();
                }
            }
        }

        public override void OnAddNew(object? sender, EventArgs e)
        {
            var inputView = new IManufacturerInputView();
            if (inputView.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (inputView.Tag is Manufacturer manufacturer)
                {
                    Provider.GetRepository<Manufacturer>().Add(manufacturer);
                    LoadData();
                }
            }
        }

        public override void OnDelete(object? sender, EventArgs e)
        {
            if (View.SelectedItem is Manufacturer manufacturer)
            {
                Provider.GetRepository<Manufacturer>().Delete(manufacturer);
                LoadData();
            }
            else
            {
                // Handle case where no item is selected or selected item is not a Manufacturer
                System.Windows.Forms.MessageBox.Show("Please select a manufacturer to delete.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public override void OnSearch(object? sender, EventArgs e)
        {
            if (View.SearchValue != "")
            {
                var searchText = View.SearchValue.Trim().ToLower();
                BindingSource.DataSource = Provider.GetRepository<Manufacturer>()
                    .GetAll()
                    .Where(m => m.Name.ToLower().Contains(searchText) || m.Description.ToLower().Contains(searchText))
                    .ToList();
            }
            else
            {
                LoadData(); // Reload all data if search text is empty
            }
        }
    }
}
