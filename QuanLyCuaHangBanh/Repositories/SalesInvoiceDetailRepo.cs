using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Data;

namespace QuanLyCuaHangBanh.Repositories
{
    public class SalesInvoiceDetailRepo(QLCHB_DBContext context) : RepositoryBase<SalesInvoice_Detail>(context)
    {
    }
}
