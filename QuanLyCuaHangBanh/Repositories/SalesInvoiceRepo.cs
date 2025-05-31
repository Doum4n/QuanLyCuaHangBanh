using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models.Base;
using System.Linq.Expressions;

namespace QuanLyCuaHangBanh.Repositories
{
    public class SalesInvoiceRepo(QLCHB_DBContext context) : RepositoryBase<SalesInvoice>(context)
    {
        
    }
}
