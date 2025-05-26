using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using QuanLyCuaHangBanh.Models.Base;

namespace QuanLyCuaHangBanh.Data
{
    public class QLCHB_DBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Invoice_Detail> InvoiceDetails { get; set; }
        public DbSet<Product_Unit> ProductUnits { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<GoodsReceiptNote> GoodsReceiptNotes { get; set; }
        public DbSet<GoodsReceiptNote_Detail> GoodsReceiptNoteDetails { get; set; }
        public DbSet<WarehouseReleaseNote> WarehouseReleaseNotes { get; set; }
        public DbSet<WarehouseReleaseNote_Detail> WarehouseReleaseNoteDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Detail> OrderDetails { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<SalesInvoice_Detail> SalesInvoiceDetails { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoice_Detail> PurchaseInvoiceDetails { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<AccountsPayable> AccountsPayables { get; set; }
        public DbSet<AccountsReceivable> AccountsReceivables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder configurationBuilder)
        {
            configurationBuilder
                .UseNpgsql(ConfigurationManager.ConnectionStrings["QLCHB_Connection"].ConnectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );

            modelBuilder.Entity<Invoice>()
                .Property(o => o.Date)
                .HasConversion(
                    v => v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );

            //modelBuilder.Entity<Product_Unit>()
            //    .HasOne(pu => pu.Inventory)
            //    .WithOne(i => i.ProductUnit)
            //    .HasForeignKey<Product_Unit>(pu => pu.InventoryID);

            modelBuilder.Entity<Product_Unit>()
                .HasOne(pu => pu.Unit)
                .WithMany()
                .HasForeignKey(pu => pu.UnitID)
                .OnDelete(DeleteBehavior.Restrict); // hoặc NoAction

            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<AccountsPayable>().ToTable("AccountsPayable");
            modelBuilder.Entity<AccountsReceivable>().ToTable("AccountsReceivable");

            modelBuilder.Entity<AccountsPayable>()
                .ToTable("AccountsPayable") // Bảng riêng cho AccountsPayable
                .HasBaseType<Account>();     // Chỉ định lớp cơ sở của nó

            // Cấu hình TPT cho lớp AccountsReceivable
            modelBuilder.Entity<AccountsReceivable>()
                .ToTable("AccountsReceivable") // Bảng riêng cho AccountsReceivable
                .HasBaseType<Account>();       // Chỉ định lớp cơ sở của nó

            // ==== KẾ THỪA CHO INVOICE (cha) ====
            modelBuilder.Entity<Invoice>().ToTable("Invoices");
            modelBuilder.Entity<SalesInvoice>().ToTable("SalesInvoices");
            modelBuilder.Entity<PurchaseInvoice>().ToTable("PurchaseInvoices");

            // ==== KẾ THỪA CHO INVOICE_DETAIL (cha) ====
            modelBuilder.Entity<SalesInvoice_Detail>()
                .HasBaseType<Invoice_Detail>(); // Khẳng định kế thừa
            modelBuilder.Entity<Invoice_Detail>().ToTable("InvoiceDetails");

            // KHÔNG thêm foreign key nào riêng tới SalesInvoice


            modelBuilder.Entity<SalesInvoice_Detail>().ToTable("SalesInvoiceDetails");
            modelBuilder.Entity<PurchaseInvoice_Detail>().ToTable("PurchaseInvoiceDetails");

            // ==== QUAN HỆ GIỮA InvoiceDetail → Invoice ====
            modelBuilder.Entity<Invoice_Detail>()
                .HasOne(d => d.Invoice)
                .WithMany() // hoặc WithMany(i => i.Details) nếu cần truy xuất ngược
                .HasForeignKey(d => d.InvoiceID);

        }

    }
}
