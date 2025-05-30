﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; } // e.g., Cake, Drink, etc.
        public string Description { get; set; } // e.g., "All types of cakes"

        public Category(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public List<Product> Products { get; set; } // List of products in this category
    }
}
