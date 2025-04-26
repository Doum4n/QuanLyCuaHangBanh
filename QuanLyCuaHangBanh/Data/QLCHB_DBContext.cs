using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Data
{
    class QLCHB_DBContext : DbContext
    {
        public DbSet<Custumer> Custumers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Invoice_Detail> InvoiceDetails { get; set; }
        public DbSet<Product_Unit> ProductUnits { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder configurationBuilder)
        {
            configurationBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["QLCHB_Connection"].ConnectionString);
        }
    }
}
