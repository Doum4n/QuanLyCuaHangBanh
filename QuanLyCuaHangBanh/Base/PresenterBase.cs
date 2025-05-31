using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Data;

namespace QuanLyCuaHangBanh.Base
{
    public abstract class PresenterBase<T> : IPresenter<T> where T : class
    {
        public IService Service { get; set; }
        public IView View { get; set; }
        public BindingSource BindingSource { get; set; }

        public virtual async Task InitializeAsync()
        {
            await Task.CompletedTask; // Trả về một Task đã hoàn thành
        }

        protected PresenterBase(IView view, IService service)
        {
            View = view;
            Service = service;
            BindingSource = new BindingSource();

            View.SearchEvent += OnSearch;
            View.DeleteEvent += OnDelete;
            View.AddNewEvent += OnAddNew;
            View.EditEvent += OnEdit;
            View.ImportEvent += OnImport;
            View.ExportEvent += OnExport;

            // Set BindingSource trước ròi mới tải dữ liệu
            View.SetBindingSource(BindingSource);
        }

        public abstract void OnExport(object? sender, EventArgs e);
        public abstract void OnImport(object? sender, EventArgs e);
        public abstract void OnEdit(object? sender, EventArgs e);
        public abstract void OnAddNew(object? sender, EventArgs e);
        public abstract void OnDelete(object? sender, EventArgs e);
        public abstract void OnSearch(object? sender, EventArgs e);

        public virtual void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

    }
}
