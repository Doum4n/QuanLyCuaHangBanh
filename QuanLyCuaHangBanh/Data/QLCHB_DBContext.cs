﻿using Microsoft.EntityFrameworkCore;
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
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging(); // CHỈ DÙNG KHI DEBUG
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<LogEntry>(entity =>
            // {
            //     entity.ToTable("AppLogs"); // Đặt tên bảng là AppLogs
            //     entity.Property(e => e.Timestamp).IsRequired().HasDefaultValueSql("NOW()"); // Đặt giá trị mặc định cho Timestamp
            //     // Các cấu hình khác nếu cần
            // });

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

            // Cấu hình Kế thừa TPT cho Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");

                // Cấu hình mối quan hệ với Invoice
                entity.HasOne(d => d.Invoice)               
                      .WithMany(p => p.Accounts)           
                      .HasForeignKey(d => d.InvoiceID)     
                      .OnDelete(DeleteBehavior.Cascade);   
            });

            // Cấu hình TPT cho Account
            modelBuilder.Entity<AccountsPayable>()
                .ToTable("AccountsPayable")
                .HasBaseType<Account>();

            modelBuilder.Entity<AccountsReceivable>()
                .ToTable("AccountsReceivable")
                .HasBaseType<Account>();

            // Cấu hình Kế thừa TPT cho Invoice
            modelBuilder.Entity<Invoice>().ToTable("Invoices");
            modelBuilder.Entity<SalesInvoice>()
                .ToTable("SalesInvoices")
                .HasBaseType<Invoice>();

            modelBuilder.Entity<PurchaseInvoice>()
                .ToTable("PurchaseInvoices")
                .HasBaseType<Invoice>();

            // Cấu hình Kế thừa TPH cho Invoice_Detail
            modelBuilder.Entity<Invoice_Detail>()
                .ToTable("InvoiceDetails") // Bảng duy nhất cho TPH
                .HasDiscriminator<string>("Discriminator") // Cột phân biệt
                .HasValue<SalesInvoice_Detail>("sales_invoice_detail")
                .HasValue<PurchaseInvoice_Detail>("purchase_invoice_detail");
            // EF Core sẽ tự động xử lý SalesInvoice_Detail và PurchaseInvoice_Detail là một phần của bảng "InvoiceDetails"
            // Không cần .ToTable() riêng cho SalesInvoice_Detail và PurchaseInvoice_Detail khi dùng TPH

            // Quan hệ giữa Invoice_Detail và Invoice
            modelBuilder.Entity<Invoice_Detail>()
                .HasOne(d => d.Invoice) // Từ Invoice_Detail có một Invoice
                .WithMany(i => i.InvoiceDetails) // Invoice có nhiều InvoiceDetails (đảm bảo Invoice.cs có ICollection<Invoice_Detail> InvoiceDetails)
                .HasForeignKey(d => d.InvoiceID) // Khóa ngoại trong Invoice_Detail là InvoiceID
                .OnDelete(DeleteBehavior.Cascade); // Hoặc Restrict/NoAction tùy vào logic nghiệp vụ

        }

    }
}
