using QuanLyCuaHangBanh.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class AccountsPayable : Account // Công nợ phải trả
    {
        public int SupplierID { get; set; } // Foreign key to the Supplier table
        public override string GetAccountType()
        {
            return "Công nợ phải trả"; // Trả về loại công nợ là "Công nợ phải trả"
        }
        public virtual Supplier Supplier { get; set; } // Navigation property to the Supplier
    }
}
