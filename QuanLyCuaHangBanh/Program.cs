using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; // Thêm namespace này
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Models.Base; // Đảm bảo namespace này đúng
using QuanLyCuaHangBanh.Presenters;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Services;
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
using QuanLyCuaHangBanh.Views.Suplier; // Để ý Producer thay cho Supplier
using QuanLyCuaHangBanh.Views.Unit;
using System;
using System.Windows.Forms;

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
            ApplicationConfiguration.Initialize();

            // Xử lý ngoại lệ trên luồng UI
            Application.ThreadException += (sender, args) =>
            {
                MessageBox.Show("Lỗi không mong muốn:\n" + args.Exception.Message, "Lỗi ứng dụng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // Xử lý ngoại lệ không được bắt trên bất kỳ luồng nào
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var ex = args.ExceptionObject as Exception;
                MessageBox.Show("Lỗi nghiêm trọng:\n" + ex?.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // 1. Tạo Host builder để cấu hình dịch vụ
            var host = CreateHostBuilder().Build();

            // 2. Chạy ứng dụng WinForms với ServiceProvider từ Host
            // Tạo một scope cho Form chính để đảm bảo DbContext và các dịch vụ liên quan
            // được quản lý đúng vòng đời.
            using (var scope = host.Services.CreateScope())
            {
                var mainForm = scope.ServiceProvider.GetRequiredService<MainView>();
                Application.Run(mainForm);
            }
        }

        // Phương thức này sẽ thay thế ConfigureServices cũ
        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Cấu hình DbContext với chuỗi kết nối và vòng đời Scoped
                    // AddDbContext mặc định là Scoped, nhưng chúng ta vẫn nên chỉ rõ để tường minh
                    services.AddScoped<QLCHB_DBContext>();

                    // Đăng ký RepositoryProvider với Scoped lifetime
                    // Để đảm bảo mỗi instance của RepositoryProvider nhận DbContext từ cùng một scope
                    services.AddScoped<IRepositoryProvider, RepositoryProvider>();

                    // Đăng ký các Repository riêng lẻ với Scoped lifetime
                    // Để đảm bảo mỗi Repository nhận DbContext từ cùng một scope
                    // Các Repository này nên nhận QLCHB_DBContext trong constructor của chúng.
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
                    services.AddScoped<IRepository<AccountsPayable>, AccountsPayableRepo>();
                    services.AddScoped<IRepository<AccountsReceivable>, AccountsReceivableRepo>();
                    services.AddScoped<IRepository<SalesInvoice>, SalesInvoiceRepo>();
                    services.AddScoped<IRepository<SalesInvoice_Detail>, SalesInvoiceDetailRepo>();
                    services.AddScoped<IRepository<PurchaseInvoice>, PurchaseInvoiceRepo>();
                    services.AddScoped<IRepository<PurchaseInvoice_Detail>, PurchaseInvoiceDetailRepo>();

                    // Đăng ký các Service với Scoped lifetime
                    // Để đảm bảo mỗi Service nhận Repository từ cùng một scope
                    services.AddScoped<ProductService>();
                    services.AddScoped<CustomerService>();
                    services.AddScoped<CategoryService>();
                    services.AddScoped<GoodsReceiptNoteService>();
                    services.AddScoped<WarehouseReleaseNoteService>();
                    services.AddScoped<EmployeeService>();
                    services.AddScoped<OrderService>();
                    services.AddScoped<SalesInvoiceService>();
                    services.AddScoped<PurchaseService>();
                    services.AddScoped<UnitService>();
                    services.AddScoped<ManufacturerService>();
                    services.AddScoped<SupplierService>(); // Đổi Suplier thành Producer


                    // Đăng ký các Presenter với Scoped lifetime
                    // Để đảm bảo mỗi Presenter nhận Service từ cùng một scope
                    services.AddScoped<ProductPresenter>();
                    services.AddScoped<CustomerPresenter>();
                    services.AddScoped<CategoryPresenter>();
                    services.AddScoped<ProducerPresenter>(); // Đổi Suplier thành Producer
                    services.AddScoped<GoodsReceiptNotePresenter>();
                    services.AddScoped<WarehouseReleaseNotePresenter>();
                    services.AddScoped<EmployeePresenter>();
                    services.AddScoped<OrderPresenter>();
                    services.AddScoped<SalesInvoicePresenter>();
                    services.AddScoped<PurchasePresenter>();
                    services.AddScoped<UnitPresenter>();
                    services.AddScoped<ManufacturerPresenter>();

                    services.AddScoped<IProductView, ProductView>();
                    services.AddScoped<ICustomerView, CustomerView>();
                    services.AddScoped<ICategoryView, CategoryView>();
                    services.AddScoped<ISuplierView, SuplierView>(); // Vẫn giữ ISuplierView nếu bạn chưa đổi
                    services.AddScoped<IGoodsReceiptNoteView, GoodsReceiptNoteView>();
                    services.AddScoped<IWareHouseReleaseNoteView, ReleaseNoteView>();
                    services.AddScoped<IEmployeeView, EmployeeView>();
                    services.AddScoped<IOrderView, OrderView>();
                    services.AddScoped<ISalesInvoiceView, InvoiceView>();
                    services.AddScoped<IPurchaseView, PurchaseInvoiceView>();
                    services.AddScoped<IUnitView, UnitView>();
                    services.AddScoped<IManufacturerView, ManufacturerView>();


                    // Đăng ký MainView là Singleton hoặc Scoped tùy thuộc vào cách bạn quản lý vòng đời của nó.
                    // Nếu MainView tạo ra các View con khác, nó nên là Singleton hoặc Scoped
                    // và các View con nên được tạo ra trong một scope mới từ MainView.
                    services.AddSingleton<MainView>();
                });
    }
}