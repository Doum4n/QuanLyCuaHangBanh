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
    class CustomerRepo(QLCHB_DBContext context) : RepositoryBase<Customer>(context)
    {
        
    }
}
