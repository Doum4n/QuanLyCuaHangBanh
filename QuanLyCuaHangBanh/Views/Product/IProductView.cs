using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Views.Product
{
    public interface IProductView : IView
    {
        event EventHandler SelectedUnitChanged;
    }
}
