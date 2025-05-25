using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public record WarehouseReleaseNoteDTO(
        int ID,
        DateOnly CreatedDate,
        string Status,
        string Note
    );
}
