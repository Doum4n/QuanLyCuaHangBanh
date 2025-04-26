using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    public interface IView
    {
        String SearchValue { get; set; }
        String Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler DeleteEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;

        void SetBindingSource(BindingSource bindingSource);
    }
}
