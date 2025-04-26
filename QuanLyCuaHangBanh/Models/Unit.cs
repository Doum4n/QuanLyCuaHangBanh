using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Unit
    {
        public int ID { get; set; }
        public string Name { get; set; } // e.g., Piece, Box, etc.
        public string Description { get; set; } // e.g., "1 box of 10 pieces"

        public virtual ICollection<Product> Products { get; } = new List<Product>(); // List of products in this unit
    }
}
