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

        public abstract void LoadData();

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
            View.SetBindingSource(BindingSource);

            LoadData();
        }

        public abstract void OnExport(object? sender, EventArgs e);
        public abstract void OnImport(object? sender, EventArgs e);
        public abstract void OnEdit(object? sender, EventArgs e);
        public abstract void OnAddNew(object? sender, EventArgs e);
        public abstract void OnDelete(object? sender, EventArgs e);
        public abstract void OnSearch(object? sender, EventArgs e);
    }
}
