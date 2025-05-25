using QuanLyCuaHangBanh.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models.Base;

namespace QuanLyCuaHangBanh.Repositories
{
    public class InvoiceRepo(QLCHB_DBContext context) : RepositoryBase<Invoice>(context)
    {
    }
}
