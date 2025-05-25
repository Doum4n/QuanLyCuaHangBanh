using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;

namespace QuanLyCuaHangBanh.Views.Category
{
    public interface ICategoryView : IView
    {
        public event EventHandler ImportEvent;
    }
}
