using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Base
{
    public interface ISearchable
    {
        bool MatchesSearch(string searchValue);

    }
}
