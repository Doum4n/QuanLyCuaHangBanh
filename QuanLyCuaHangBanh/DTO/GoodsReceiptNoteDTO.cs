using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class GoodsReceiptNoteDTO : ISearchable
    {
        public int ID { get; set; }
        // public int CreatorId { get; set; } // Uncomment if needed
        // public string CreatorName { get; set; } // Uncomment if needed

        [Browsable(false)]
        public int SupplierId { get; set; }

        public string SupplierName { get; set; }
        public DateOnly CreatedDate { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }

        [Browsable(false)]
        public List<Product> Products { get; set; } = new List<Product>(); // Initialize to prevent null reference

        public bool MatchesSearch(string searchValue)
        {
            return ID.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   SupplierName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   CreatedDate.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Status.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Note.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
        }

        // You might need a Product class definition if it's not already defined elsewhere
        // public class Product
        // {
        //     public int ProductId { get; set; }
        //     public string ProductName { get; set; }
        //     public int Quantity { get; set; }
        //     // Add other product properties as needed
        // }
    }
}
