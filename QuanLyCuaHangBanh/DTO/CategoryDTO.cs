using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    record CategoryDTO(
        int ID,
        string CategoryName,
        string Description
    );
}
