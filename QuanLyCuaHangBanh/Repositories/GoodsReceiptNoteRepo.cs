using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet.Core;

namespace QuanLyCuaHangBanh.Repositories
{
    public class GoodsReceiptNoteRepo(QLCHB_DBContext context) : RepositoryBase<GoodsReceiptNote>(context)
    {
       
        public override void Add(GoodsReceiptNote entity)
        {

            base.Add(entity);
        }
    }
}
