using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public int ProductUnitID { get; set; } // Foreign key to the Product_Unit table
        public int Quantity { get; set; } // Quantity of the product in stock
        public DateTime ReceivedDate { get; set; } // Date when the product was received
        public string? Note { get; set; } // Additional notes about the inventory item
        public virtual Product_Unit ProductUnit { get; set; } // Navigation property to the Product_Unit

        public int? GoodsReceiptNoteDetailID { get; set; } // Liên kết đến chi tiết nhập kho
        public virtual GoodsReceiptNote_Detail GoodsReceiptNoteDetail { get; set; } // Navigation property

        public override string ToString()
        {
            return $"ID: {ID}, ProductUnitID: {ProductUnitID}, Quantity: {Quantity}, ReceivedDate: {ReceivedDate}, Note: {Note}";
        }
    }
}
