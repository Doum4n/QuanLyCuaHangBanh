using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public record GoodsReceiptNoteDTO(
        int ID,
        //int CreatorId,
        //string CreatorName,
        int SupplierId,
        string SupplierName,
        DateOnly CreatedDate,
        string Status,
        string Note,
        List<Product> Products
    ){
        [Browsable(false)]
        public List<Product> Products { get; set; } = Products;
        [Browsable(false)]
        public int SupplierId { get; set; } = SupplierId;
    }
}
