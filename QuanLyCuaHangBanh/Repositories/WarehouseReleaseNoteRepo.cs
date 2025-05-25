using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Repositories
{
    public class WarehouseReleaseNoteRepo(QLCHB_DBContext context) : RepositoryBase<WarehouseReleaseNote>(context)
    {
        public override IList<TDto> GetAllAsDto<TDto>(Func<WarehouseReleaseNote, TDto> converter)
        {
            return context.WarehouseReleaseNotes
                .Include(g => g.WarehouseReleaseNoteDetails) // Load dữ liệu WarehouseReleaseNoteDetails
                .ThenInclude(prd => prd.Product_Unit).ThenInclude(o => o.Product) // Load dữ liệu Product trong WarehouseReleaseNoteDetails
                .Include(p => p.WarehouseReleaseNoteDetails)
                .Select(converter)
                .ToList();
        }

        public override WarehouseReleaseNote? GetByValue(object value)
        {
            return context.WarehouseReleaseNotes
                .FirstOrDefault(o => o.ID.Equals(value));
        }
    }
}
