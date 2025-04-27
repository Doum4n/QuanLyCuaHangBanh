using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;

namespace QuanLyCuaHangBanh.Repositories
{
    class ProducerRepo : RepositoryBase<Producer>
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        public ProducerRepo(QLCHB_DBContext context) : base(context) { }

    }
}
