using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    record Product_UnitDTO(
        int ID,
        string UnitName,
        decimal ConversionRate,
        decimal UnitPrice,
        decimal Quantity
    );
}
