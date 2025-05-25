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
        public IRepositoryProvider Provider { get; set; }
        public IView View { get; set; }
        public BindingSource BindingSource { get; set; }

        public virtual void LoadData()
        {
            BindingSource.DataSource = Provider.GetRepository<T>().GetAll();
        }

        protected PresenterBase(IView view, IRepositoryProvider provider)
        {
            View = view;
            Provider = provider;
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
