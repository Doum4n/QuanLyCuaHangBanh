using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    public interface IPresenter<T> where T : class
    {
        IRepositoryProvider Provider { get; set; }
        IView View { get; set; }
        BindingSource BindingSource { get; set; }

        void LoadData();
    }
}
