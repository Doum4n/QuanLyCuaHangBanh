using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Repositories
{
    class ProducerRepo(QLCHB_DBContext context) : RepositoryBase<Supplier>(context)
    {
        public override IList<TDto> GetAllAsDto<TDto>(Func<Supplier, TDto> converter)
        {
            return context.Suppliers
                .Include(o => o.AccountsPayables) // Include AccountsPayables to calculate total amount
                .Select(converter)
                .ToList();
        }
    }
}
