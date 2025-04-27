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
    class CategoryRepo : RepositoryBase<Category>
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();

        public CategoryRepo(QLCHB_DBContext context) : base(context)
        {

        }
    }
}
