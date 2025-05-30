﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public int? ManufacturerID { get; set; } // Nullable if the product is not associated with a manufacturer
        public int ProducerID { get; set; }
        //public DateOnly ProductionDate { get; set; } // Ngày sản xuất
        //public DateOnly ExpirationDate { get; set; } // Ngày hết hạn
        public string Description { get; set; }
        public string? Image { get; set; } // URL or path to the product image
        public int BaseUnitID { get; set; } // Chỉ dùng 1 đơn vị cơ bản

        public virtual Category Category { get; set; }
        public virtual Unit BaseUnit { get; set; }
        public virtual Supplier Producer { get; set; }


        public virtual ICollection<Product_Unit> ProductUnits { get; set; } = new List<Product_Unit>();
        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
        public virtual Manufacturer? Manufacturer { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, CategoryID: {CategoryID}, ProducerID: {ProducerID}, Description: {Description}, Image: {Image}, BaseUnitID: {BaseUnitID}";
        }
    }

}
