using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Models.Base;
using QuanLyCuaHangBanh.Presenters;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;
using QuanLyCuaHangBanh.Views.Category;
using QuanLyCuaHangBanh.Views.Customer;
using QuanLyCuaHangBanh.Views.Employee;
using QuanLyCuaHangBanh.Views.Invoice;
using QuanLyCuaHangBanh.Views.Invoice.PurchaseInvoice;
using QuanLyCuaHangBanh.Views.Invoice.SalesInvoice;
using QuanLyCuaHangBanh.Views.Manufacturer;
using QuanLyCuaHangBanh.Views.Order;
using QuanLyCuaHangBanh.Views.Product;
using QuanLyCuaHangBanh.Views.ReceiptNote;
using QuanLyCuaHangBanh.Views.ReleaseNote;
using QuanLyCuaHangBanh.Views.Suplier;
using QuanLyCuaHangBanh.Views.Unit;

namespace QuanLyCuaHangBanh
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show("Lỗi không mong muốn:\n" + args.Exception.Message);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var ex = args.ExceptionObject as Exception;
                MessageBox.Show("Lỗi nghiêm trọng:\n" + ex?.Message);
            };

            // Lấy Form chính từ DI
            var mainForm = serviceProvider.GetRequiredService<MainView>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // DbContext hoặc DbConnection nếu cần
            services.AddScoped<QLCHB_DBContext>();

            // Đăng ký repository
            services.AddScoped<IRepository<Product>, ProductRepo>();
            services.AddScoped<IRepository<Product_Unit>, ProductUnitRepo>();
            services.AddScoped<IRepository<Inventory>, InventoryRepo>();
            services.AddScoped<IRepository<Category>, CategoryRepo>();
            services.AddScoped<IRepository<Supplier>, ProducerRepo>();
            services.AddScoped<IRepository<Customer>, CustomerRepo>();
            services.AddScoped<IRepository<GoodsReceiptNote>, GoodsReceiptNoteRepo>();
            services.AddScoped<IRepository<GoodsReceiptNote_Detail>, GoodsReceiptNoteDetailRepo>();
            services.AddScoped<IRepository<WarehouseReleaseNote>, WarehouseReleaseNoteRepo>();
            services.AddScoped<IRepository<WarehouseReleaseNote_Detail>, WarehouseReleaseNoteDetailRepo>();
            services.AddScoped<IRepository<Employee>, EmployeeRepo>();
            services.AddScoped<IRepository<Order>, OrderRepo>();
            services.AddScoped<IRepository<Order_Detail>, OrderDetailRepo>();
            services.AddScoped<IRepository<Invoice>, InvoiceRepo>();
            services.AddScoped<IRepository<Unit>, UnitRepo>();
            services.AddScoped<IRepository<Manufacturer>, ManufacturerRepo>();


            services.AddScoped<IRepository<SalesInvoice>, SalesInvoiceRepo>();
            services.AddScoped<IRepository<SalesInvoice_Detail>, SalesInvoiceDetailRepo>();
            services.AddScoped<IRepository<PurchaseInvoice>, PurchaseInvoiceRepo>();
            services.AddScoped<IRepository<PurchaseInvoice_Detail>, PurchaseInvoiceDetailRepo>();

            // Đăng ký RepositoryProvider
            services.AddScoped<IRepositoryProvider, RepositoryProvider>();

            // Đăng ký các View và Presenter
            services.AddScoped<IProductView, ProductView>();
            services.AddScoped<ProductPresenter>();
            services.AddScoped<ICustomerView, CustomerView>();
            services.AddScoped<CustomerPresenter>();
            services.AddScoped<ICategoryView, CategoryView>();
            services.AddScoped<CategoryPresenter>();
            services.AddScoped<ISuplierView, SuplierView>();
            services.AddScoped<ProducerPresenter>();
            services.AddScoped<IGoodsReceiptNoteView, GoodsReceiptNoteView>();
            services.AddScoped<GoodsReceiptNotePresenter>();
            services.AddScoped<IWareHouseReleaseNoteView, ReleaseNoteView>();
            services.AddScoped<WarehouseReleaseNotePresenter>();
            services.AddScoped<IEmployeeView, EmployeeView>();
            services.AddScoped<EmployeePresenter>();
            services.AddScoped<IOrderView, OrderView>();
            services.AddScoped<OrderPresenter>();
            services.AddScoped<ISalesInvoiceView, InvoiceView>();
            services.AddScoped<SalesInvoicePresenter>();
            services.AddScoped<IPurchaseView, PurchaseInvoiceView>();
            services.AddScoped<PurchasePresenter>();
            services.AddScoped<IUnitView, UnitView>();
            services.AddScoped<UnitPresenter>();
            services.AddScoped<IManufacturerView, ManufacturerView>();
            services.AddScoped<ManufacturerPresenter>();

            services.AddScoped<MainView>();  // Đảm bảo đăng ký MainView
        }
    }
}