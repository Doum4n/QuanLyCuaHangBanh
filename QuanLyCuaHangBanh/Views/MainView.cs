using Microsoft.Extensions.DependencyInjection;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Presenters;
using QuanLyCuaHangBanh.Reports;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Uitls;
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
using QuanLyCuaHangBanh.Views.Unit;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Views.Suplier;
using CloudinaryDotNet.Core;
using QuanLyCuaHangBanh.Base;
using System.Linq;
using System.Reflection;

namespace QuanLyCuaHangBanh
{
    /// <summary>
    /// Form chính của ứng dụng quản lý cửa hàng bánh
    /// </summary>
    public partial class MainView : Form
    {
        #region View Fields
        /// <summary>
        /// Các form con trong ứng dụng
        /// </summary>
        private ProductView? productView;
        private CategoryView? categoryView;
        private SuplierView? producerView;
        private CustomerView? customerView;
        private GoodsReceiptNoteView? purchaseReceiptView;
        private ReleaseNoteView? warehouseReleaseNoteView;
        private EmployeeView? employeeView;
        private OrderView? orderView;
        private InvoiceView? invoiceView;
        private UnitView? unitView;
        private ManufacturerView? manufacturerView;
        #endregion

        #region Presenter Fields
        /// <summary>
        /// Các presenter quản lý logic nghiệp vụ
        /// </summary>
        private ProductPresenter? _productPresenter;
        private CustomerPresenter? _customerPresenter;
        private CategoryPresenter? _categoryPresenter;
        private ProducerPresenter? _producerPresenter;
        private GoodsReceiptNotePresenter? _purchaseReceiptPresenter;
        private WarehouseReleaseNotePresenter? _warehouseReleaseNotePresenter;
        private EmployeePresenter? _employeePresenter;
        private OrderPresenter? _orderPresenter;
        private SalesInvoicePresenter? _invoicePresenter;
        private PurchasePresenter? _purchasePresenter;
        private UnitPresenter? _unitPresenter;
        private ManufacturerPresenter? _manufacturerPresenter;
        #endregion

        private readonly IServiceProvider _serviceProvider;

        #region Constructor & Load
        public MainView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            // Khởi tạo trạng thái ban đầu của form
            InitializeFormState();
        }

        /// <summary>
        /// Khởi tạo trạng thái ban đầu của form
        /// </summary>
        private void InitializeFormState()
        {
            tsslb_EmployeeName.Text = "Chưa đăng nhập";
            DisableAllMenuItems();
        }

        /// <summary>
        /// Vô hiệu hóa tất cả các menu item khi chưa đăng nhập
        /// </summary>
        private void DisableAllMenuItems()
        {
            tsmi_Products.Enabled = false;
            tsmi_Catogories.Enabled = false;
            tsmi_Producers.Enabled = false;
            tsmi_Customers.Enabled = false;
            tsmi_PurchaseReceipts.Enabled = false;
            tsmi_WarehouseNotes.Enabled = false;
            tsmi_Employees.Enabled = false;
            tsmi_Order.Enabled = false;
            tsmi_Invoices.Enabled = false;
            tsmi_Units.Enabled = false;
            stmi_Manufacturers.Enabled = false;
            tsmi_Statistical.Enabled = false;
        }
        #endregion

        #region Menu Item Click Events
        /// <summary>
        /// Mở form quản lý sản phẩm
        /// </summary>
        private async void tsmi_Products_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<ProductView, IProductView, ProductPresenter>(
                productView,
                _productPresenter,
                "sản phẩm",
                view => view.FormClosed += ProductView_FormClosed
            );
            productView = result.View;
            _productPresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form quản lý danh mục
        /// </summary>
        private async void tsmi_Catogories_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<CategoryView, ICategoryView, CategoryPresenter>(
                categoryView,
                _categoryPresenter,
                "danh mục",
                view => view.FormClosed += CategoryView_FormClosed
            );
            categoryView = result.View;
            _categoryPresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form quản lý nhà cung cấp
        /// </summary>
        private async void tsmi_Producers_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<SuplierView, ISuplierView, ProducerPresenter>(
                producerView,
                _producerPresenter,
                "nhà cung cấp",
                view => view.FormClosed += ProducerView_FormClosed
            );
            producerView = result.View;
            _producerPresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form quản lý khách hàng
        /// </summary>
        private async void tsmi_Customers_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<CustomerView, ICustomerView, CustomerPresenter>(
                customerView,
                _customerPresenter,
                "khách hàng",
                view => view.FormClosed += CustomerView_FormClosed
            );
            customerView = result.View;
            _customerPresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form phiếu nhập
        /// </summary>
        private async void tsmi_PurchaseReceipts_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<GoodsReceiptNoteView, IGoodsReceiptNoteView, GoodsReceiptNotePresenter>(
                purchaseReceiptView,
                _purchaseReceiptPresenter,
                "phiếu nhập",
                view => view.FormClosed += PurchaseReceiptView_FormClosed
            );
            purchaseReceiptView = result.View;
            _purchaseReceiptPresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form phiếu xuất
        /// </summary>
        private async void tsmi_WarehouseNotes_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<ReleaseNoteView, IWareHouseReleaseNoteView, WarehouseReleaseNotePresenter>(
                warehouseReleaseNoteView,
                _warehouseReleaseNotePresenter,
                "phiếu xuất",
                view => view.FormClosed += WarehouseReleaseNoteView_FormClosed
            );
            warehouseReleaseNoteView = result.View;
            _warehouseReleaseNotePresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form nhân viên
        /// </summary>
        private async void tsmi_Employees_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<EmployeeView, IEmployeeView, EmployeePresenter>(
                employeeView,
                _employeePresenter,
                "nhân viên",
                view => view.FormClosed += EmployeeView_FormClosed
            );
            employeeView = result.View;
            _employeePresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form đơn đặt hàng
        /// </summary>
        private async void tsmi_Order_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<OrderView, IOrderView, OrderPresenter>(
                orderView,
                _orderPresenter,
                "đơn đặt hàng",
                view => view.FormClosed += OrderView_FormClosed
            );
            orderView = result.View;
            _orderPresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form hóa đơn
        /// </summary>
        private async void tsmi_Invoices_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<InvoiceView, ISalesInvoiceView, SalesInvoicePresenter>(
                invoiceView,
                _invoicePresenter,
                "hóa đơn",
                view => view.FormClosed += InvoiceView_FormClosed
            );
            invoiceView = result.View;
            _invoicePresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form báo cáo sản phẩm
        /// </summary>
        private void tsmi_ReportProduct_Click(object sender, EventArgs e)
        {
            ReportProductView reportProductView = new ReportProductView();
            reportProductView.MdiParent = this;
            reportProductView.Show();
        }

        /// <summary>
        /// Mở form báo cáo thống kê doanh thu
        /// </summary>
        private void tsmi_RevenueStatistics_Click(object sender, EventArgs e)
        {
            ReportRevenueStatisticsView revenueStatisticsView = new ReportRevenueStatisticsView();
            revenueStatisticsView.MdiParent = this;
            revenueStatisticsView.Show();
        }

        /// <summary>
        /// Mở form báo cáo nhập kho
        /// </summary>
        private void tsmi_ImportWarehouse_Click(object sender, EventArgs e)
        {
            ReportReceiptView reportReceiptView = new ReportReceiptView();
            reportReceiptView.MdiParent = this;
            reportReceiptView.Show();
        }

        /// <summary>
        /// Mở form báo cáo xuất kho
        /// </summary>
        private void tsmi_ExportWarehouse_Click(object sender, EventArgs e)
        {
            ReportReleaseView reportReleaseView = new ReportReleaseView();
            reportReleaseView.MdiParent = this;
            reportReleaseView.Show();
        }

        /// <summary>
        /// Mở form đơn vị
        /// </summary>
        private async void tsmi_Units_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<UnitView, IUnitView, UnitPresenter>(
                unitView,
                _unitPresenter,
                "đơn vị",
                view => view.FormClosed += UnitView_FormClosed
            );
            unitView = result.View;
            _unitPresenter = result.Presenter;
        }

        /// <summary>
        /// Mở form báo cáo thống kê đơn đặt hàng
        /// </summary>
        private void stmi_OrderStatistics_Click(object sender, EventArgs e)
        {
            ReportOrderView reportOrderView = new ReportOrderView();
            reportOrderView.MdiParent = this;
            reportOrderView.Show();
        }

        /// <summary>
        /// Đăng nhập vào hệ thống
        /// </summary>
        private void tsmi_Login_Click(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            if (loginView.ShowDialog() == DialogResult.OK)
            {
                tsslb_EmployeeName.Text = $"{Session.Role}: {Session.EmployeeName}";
                applyPermissions();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Áp dụng quyền truy cập cho người dùng
        /// </summary>
        private void applyPermissions()
        {
            switch (Session.Role)
            {
                case "Nhân viên bán hàng":
                    DisableAllMenuItems();
                    tsmi_Order.Enabled = true;
                    tsmi_Invoices.Enabled = true;
                    tsmi_Statistical.Enabled = false;
                    break;
                case "Quản lý":
                    EnableAllMenuItems();
                    break;
                case "Nhân viên kho":
                    DisableAllMenuItems();
                    tsmi_PurchaseReceipts.Enabled = true;
                    tsmi_WarehouseNotes.Enabled = true;
                    tsmi_Statistical.Enabled = false;
                    break;
                default:
                    tsslb_EmployeeName.Text = "Chưa đăng nhập";
                    break;
            }
        }

        /// <summary>
        /// Mở form nhà sản xuất
        /// </summary>
        private async void stmi_Manufacturers_Click(object sender, EventArgs e)
        {
            var result = await OpenFormWithScope<ManufacturerView, IManufacturerView, ManufacturerPresenter>(
                manufacturerView,
                _manufacturerPresenter,
                "nhà sản xuất",
                view => view.FormClosed += ManufacturerView_FormClosed
            );
            manufacturerView = result.View;
            _manufacturerPresenter = result.Presenter;
        }

        /// <summary>
        /// Đăng xuất khỏi hệ thống
        /// </summary>
        private void tsmi_Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            tsslb_EmployeeName.Text = "Chưa đăng nhập";
            DisableAllMenuItems();
        }

        /// <summary>
        /// Mở form thay đổi thông tin tài khoản
        /// </summary>
        private void stmi_ChangePassword_Click(object sender, EventArgs e)
        {
            AccoutView accoutView = new AccoutView();
            accoutView.MdiParent = this;
            accoutView.Show();
        }

        /// <summary>
        /// Đóng ứng dụng
        /// </summary>
        private void tsmi_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Mở form báo cáo tồn kho
        /// </summary>
        private void tsmi_InventoryStatistical_Click(object sender, EventArgs e)
        {
            ReportInventoryView reportInventoryView = new ReportInventoryView();
            reportInventoryView.MdiParent = this;
            reportInventoryView.Show();
        }
        #endregion

        #region Form Closed Events
        private void ProductView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            productView = null;
            _productPresenter = null;
        }

        private void CategoryView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            categoryView = null;
            _categoryPresenter = null;
        }

        private void ProducerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            producerView = null;
            _producerPresenter = null;
        }

        private void CustomerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            customerView = null;
            _customerPresenter = null;
        }

        private void PurchaseReceiptView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            purchaseReceiptView = null;
            _purchaseReceiptPresenter = null;
        }

        private void WarehouseReleaseNoteView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            warehouseReleaseNoteView = null;
            _warehouseReleaseNotePresenter = null;
        }

        private void EmployeeView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            employeeView = null;
            _employeePresenter = null;
        }

        private void OrderView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            orderView = null;
            _orderPresenter = null;
        }

        private void InvoiceView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            invoiceView = null;
            _invoicePresenter = null;
        }

        private void UnitView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            unitView = null;
            _unitPresenter = null;
        }

        private void ManufacturerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form && form.Tag is IServiceScope scope)
            {
                scope.Dispose();
            }
            manufacturerView = null;
            _manufacturerPresenter = null;
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == productView)
                {
                    productView = null;
                    _productPresenter = null;
                }
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Phương thức generic để mở form với scope
        /// </summary>
        private async Task<(TView? View, TPresenter? Presenter)> OpenFormWithScope<TView, TInterface, TPresenter>(
            TView? existingView,
            TPresenter? existingPresenter,
            string formName,
            Action<TView> setupAction) where TView : Form where TPresenter : class
        {
            if (existingView == null || existingView.IsDisposed)
            {
                IServiceScope? scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    var view = scope.ServiceProvider.GetRequiredService<TInterface>() as TView;
                    var presenter = scope.ServiceProvider.GetRequiredService<TPresenter>();

                    if (view != null)
                    {
                        view.Tag = scope;
                        setupAction(view);
                        view.MdiParent = this;
                        view.Show();

                        // Gọi InitializeAsync thông qua dynamic để tránh vấn đề về generic type
                        dynamic dynamicPresenter = presenter;
                        await dynamicPresenter.InitializeAsync();

                        return (view, presenter);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form {formName}: {ex.Message}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    scope?.Dispose();
                }
                return (null, default);
            }
            else
            {
                existingView.Activate();
                return (existingView, existingPresenter);
            }
        }

        /// <summary>
        /// Vô hiệu hóa tất cả các menu item
        /// </summary>
        private void EnableAllMenuItems()
        {
            tsmi_Products.Enabled = true;
            tsmi_Catogories.Enabled = true;
            tsmi_Producers.Enabled = true;
            tsmi_Customers.Enabled = true;
            tsmi_PurchaseReceipts.Enabled = true;
            tsmi_WarehouseNotes.Enabled = true;
            tsmi_Employees.Enabled = true;
            tsmi_Order.Enabled = true;
            tsmi_Invoices.Enabled = true;
            tsmi_Units.Enabled = true;
            stmi_Manufacturers.Enabled = true;
            tsmi_Statistical.Enabled = true;
        }
        #endregion
    }
}