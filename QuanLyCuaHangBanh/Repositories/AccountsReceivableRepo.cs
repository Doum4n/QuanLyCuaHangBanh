using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace QuanLyCuaHangBanh.Repositories
{
    public class AccountsReceivableRepo(QLCHB_DBContext context) : RepositoryBase<AccountsReceivable>(context)
    {
    }
}