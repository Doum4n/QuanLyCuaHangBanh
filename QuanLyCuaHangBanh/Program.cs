using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Presenters;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;

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
            services.AddScoped<IRepository<Producer>, ProducerRepo>();
            services.AddScoped<IRepository<Customer>, CustomerRepo>();

            // Đăng ký RepositoryProvider
            services.AddScoped<IRepositoryProvider, RepositoryProvider>();

            // Đăng ký các View và Presenter
            services.AddScoped<IProductView, ProductView>();
            services.AddScoped<ProductPresenter>();
            services.AddScoped<ICustomerView, CustomerView>();
            services.AddScoped<CustomerPresenter>();
            services.AddScoped<ICategoryView, CategoryView>();
            services.AddScoped<CategoryPresenter>();
            services.AddScoped<IProducerView, ProducerView>();
            services.AddScoped<ProducerPresenter>();

            services.AddScoped<MainView>();  // Đảm bảo đăng ký MainView
        }
    }
}