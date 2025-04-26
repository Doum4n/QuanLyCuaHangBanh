using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Presenters
{
    public class ProductPresenter
    {

        private QLCHB_DBContext context = new QLCHB_DBContext();
        private IProductView view;
        private ProductRepo repo;
        private BindingSource bindingSource { get; set; }

        public ProductPresenter(IProductView view)
        {
            this.view = view;
            this.repo = new ProductRepo();
            this.view.SearchEvent += OnSearch;
            this.view.DeleteEvent += OnDelete;
            this.view.AddNewEvent += OnAddNew;
            this.view.EditEvent += OnEdit;
            this.view.SelectedUnitChanged += OnSelectedUnitChanged;
            this.bindingSource = new BindingSource();
            this.view.SetBindingSource(this.bindingSource);

            loadData();

        }
        private void OnSelectedUnitChanged(object? sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.Tag is ProductDTO product)
            {
                if (comboBox.SelectedValue is int selectedUnitId)
                {
                    product.SelectedUnitId = selectedUnitId;

                    // Tìm giá mới theo đơn vị
                    var unit = context.ProductUnits
                        .AsNoTracking()
                        .FirstOrDefault(pu => pu.ProductID == product.ID && pu.UnitID == selectedUnitId);

                    var inventory = context.Inventories
                        .AsNoTracking()
                        .FirstOrDefault(inv => inv.ProductID == product.ID && inv.UnitID == selectedUnitId);

                    if (unit != null)
                        product.Price = unit.UnitPrice;

                    if (inventory != null)
                        product.Quantity = inventory.Quantity;

                    bindingSource?.ResetBindings(false); // Cập nhật lại tất cả dữ liệu trong DataGridView
                }
            }
        }


        private void loadData()
        {
            bindingSource.DataSource = repo.getAllDto();
        }

        private void OnSearch(object sender, EventArgs e)
        {
            // Implement search logic
        }
        private void OnDelete(object sender, EventArgs e)
        {
            // Implement delete logic
        }
        private void OnAddNew(object sender, EventArgs e)
        {
            // Implement add new logic
        }
        private void OnEdit(object sender, EventArgs e)
        {
            // Implement edit logic
        }
    }
}
