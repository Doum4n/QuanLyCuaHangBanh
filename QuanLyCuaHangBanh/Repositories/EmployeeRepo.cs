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
    class EmployeeRepo(QLCHB_DBContext context) : RepositoryBase<Employee>(context)
    {
    }
}
