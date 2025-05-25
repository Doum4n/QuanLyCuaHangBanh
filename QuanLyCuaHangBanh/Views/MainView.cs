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

namespace QuanLyCuaHangBanh
{
    public partial class MainView : Form
    {
        private ProductView? productView;
        private CategoryView? categoryView;
        private SuplierView? producerView;
        private CustomerView? customerView;
        private GoodsReceiptNoteView? purchaseReceiptView;
        private ReleaseNoteView? warehouseReleaseNoteView;
        private EmployeeView? employeeView;
        private OrderView? OrderView;
        private InvoiceView? invoiceView;
        private PurchaseInvoiceView? PurchaseInvoiceView;
        private UnitView? unitView;
        private ManufacturerView? manufacturerView;

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

        private readonly IServiceProvider _serviceProvider;

        public MainView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            //tsslb_EmployeeName.Text = "Chưa đăng nhập";
            //tsmi_Products.Enabled = false;
            //tsmi_Catogories.Enabled = false;
            //tsmi_Producers.Enabled = false;
            //tsmi_Customers.Enabled = false;
            //tsmi_PurchaseReceipts.Enabled = false;
            //tsmi_WarehouseNotes.Enabled = false;
            //tsmi_Employees.Enabled = false;
            //tsmi_Order.Enabled = false;
            //tsmi_Invoices.Enabled = false;
            //tsmi_Units.Enabled = false;
            //stmi_Manufacturers.Enabled = false;

            //tsmi_Statistical.Enabled = false;
        }


        private void tsmi_Products_Click(object sender, EventArgs e)
        {
            if (productView == null || productView.IsDisposed)
            {
                productView = _serviceProvider.GetRequiredService<IProductView>() as ProductView;
                _serviceProvider.GetRequiredService<ProductPresenter>();

                productView.MdiParent = this;
                productView.FormClosed += (_, __) => productView = null;
                productView.Show();
            }
            else
            {
                productView.Activate();
            }
        }

        private void tsmi_Catogories_Click(object sender, EventArgs e)
        {
            if (categoryView == null || categoryView.IsDisposed)
            {
                categoryView = _serviceProvider.GetRequiredService<ICategoryView>() as CategoryView;
                _categoryPresenter = _serviceProvider.GetRequiredService<CategoryPresenter>();
                categoryView.MdiParent = this;
                categoryView.Show();
            }
            else
            {
                categoryView.Activate();
            }
        }

        private void tsmi_Producers_Click(object sender, EventArgs e)
        {
            if (producerView == null || producerView.IsDisposed)
            {
                producerView = new SuplierView();
                new ProducerPresenter(producerView);
                producerView.MdiParent = this;
                producerView.Show();
            }
            else
            {
                producerView.Activate();
            }
        }

        private void tsmi_Customers_Click(object sender, EventArgs e)
        {
            if (customerView == null || customerView.IsDisposed)
            {
                customerView = _serviceProvider.GetRequiredService<ICustomerView>() as CustomerView;
                _customerPresenter = _serviceProvider.GetRequiredService<CustomerPresenter>();
                customerView.MdiParent = this;
                customerView.Show();
            }
            else
            {
                customerView.Activate();
            }
        }

        private void tsmi_PurchaseReceipts_Click(object sender, EventArgs e)
        {
            if (purchaseReceiptView == null || purchaseReceiptView.IsDisposed)
            {
                purchaseReceiptView = _serviceProvider.GetRequiredService<IGoodsReceiptNoteView>() as GoodsReceiptNoteView;
                _purchaseReceiptPresenter = _serviceProvider.GetRequiredService<GoodsReceiptNotePresenter>();
                purchaseReceiptView.MdiParent = this;
                purchaseReceiptView.Show();
            }
            else
            {
                purchaseReceiptView.Activate();
            }
        }

        private void tsmi_WarehouseNotes_Click(object sender, EventArgs e)
        {
            if (warehouseReleaseNoteView == null || warehouseReleaseNoteView.IsDisposed)
            {
                warehouseReleaseNoteView = _serviceProvider.GetRequiredService<IWareHouseReleaseNoteView>() as ReleaseNoteView;
                _warehouseReleaseNotePresenter = _serviceProvider.GetRequiredService<WarehouseReleaseNotePresenter>();
                warehouseReleaseNoteView.MdiParent = this;
                warehouseReleaseNoteView.Show();
            }
            else
            {
                warehouseReleaseNoteView.Activate();
            }
        }

        private void tsmi_Employees_Click(object sender, EventArgs e)
        {
            if (employeeView == null || employeeView.IsDisposed)
            {
                employeeView = _serviceProvider.GetRequiredService<IEmployeeView>() as EmployeeView;
                _employeePresenter = _serviceProvider.GetRequiredService<EmployeePresenter>();
                employeeView.MdiParent = this;
                employeeView.Show();
            }
            else
            {
                employeeView.Activate();
            }
        }

        private void tsmi_Order_Click(object sender, EventArgs e)
        {
            if (OrderView == null || OrderView.IsDisposed)
            {
                OrderView = _serviceProvider.GetRequiredService<IOrderView>() as OrderView;
                _orderPresenter = _serviceProvider.GetRequiredService<OrderPresenter>();
                OrderView.MdiParent = this;
                OrderView.Show();
            }
            else
            {
                OrderView.Activate();
            }
        }

        private void tsmi_Invoices_Click(object sender, EventArgs e)
        {
            if (invoiceView == null || invoiceView.IsDisposed)
            {

                invoiceView = _serviceProvider.GetRequiredService<ISalesInvoiceView>() as InvoiceView;
                _invoicePresenter = _serviceProvider.GetRequiredService<SalesInvoicePresenter>();

                PurchaseInvoiceView = _serviceProvider.GetRequiredService<IPurchaseView>() as PurchaseInvoiceView;
                _purchasePresenter = _serviceProvider.GetRequiredService<PurchasePresenter>();

                invoiceView.MdiParent = this;
                invoiceView.Show();
            }
            else
            {
                invoiceView.Activate();
            }
        }

        private void tsmi_ReportProduct_Click(object sender, EventArgs e)
        {
            ReportProductView reportProductView = new ReportProductView();
            reportProductView.MdiParent = this;
            reportProductView.Show();
        }

        private void tsmi_ReportSalesInvoice_Click(object sender, EventArgs e)
        {
            //ReportSalesInvoiceView reportSalesInvoiceView = new ReportSalesInvoiceView();
            //reportSalesInvoiceView.MdiParent = this;
            //reportSalesInvoiceView.Show();
        }

        private void tsmi_RevenueStatistics_Click(object sender, EventArgs e)
        {
            ReportRevenueStatisticsView revenueStatisticsView = new ReportRevenueStatisticsView();
            revenueStatisticsView.MdiParent = this;
            revenueStatisticsView.Show();
        }

        private void tsmi_ImportWarehouse_Click(object sender, EventArgs e)
        {
            ReportReceiptView reportReceiptView = new ReportReceiptView();
            reportReceiptView.MdiParent = this;
            reportReceiptView.Show();
        }

        private void tsmi_ExportWarehouse_Click(object sender, EventArgs e)
        {
            ReportReleaseView reportReleaseView = new ReportReleaseView();
            reportReleaseView.MdiParent = this;
            reportReleaseView.Show();
        }

        private void tsmi_Units_Click(object sender, EventArgs e)
        {
            if (unitView == null || unitView.IsDisposed)
            {
                unitView = _serviceProvider.GetRequiredService<IUnitView>() as UnitView;
                _unitPresenter = _serviceProvider.GetRequiredService<UnitPresenter>();
                unitView.MdiParent = this;
                unitView.Show();
            }
            else
            {
                unitView.Activate();
            }
        }

        private void stmi_OrderStatistics_Click(object sender, EventArgs e)
        {
            ReportOrderView reportOrderView = new ReportOrderView();
            reportOrderView.MdiParent = this;
            reportOrderView.Show();
        }

        private void tsmi_Login_Click(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();
            if (loginView.ShowDialog() == DialogResult.OK)
            {
                tsslb_EmployeeName.Text = $"{Session.Role}: {Session.EmployeeName}";

                //applyPermissions();
            }
            else
            {
                // Handle failed login, e.g., show an error message
                MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyPermissions()
        {
            switch (Session.Role)
            {
                case "Nhân viên bán hàng":
                    tsmi_Products.Enabled = false;
                    tsmi_Catogories.Enabled = false;
                    tsmi_Producers.Enabled = false;
                    tsmi_Customers.Enabled = false;
                    tsmi_PurchaseReceipts.Enabled = false;
                    tsmi_WarehouseNotes.Enabled = false;
                    tsmi_Employees.Enabled = false;
                    tsmi_Order.Enabled = true;
                    tsmi_Invoices.Enabled = true;
                    tsmi_Units.Enabled = false;
                    stmi_Manufacturers.Enabled = false;

                    tsmi_Statistical.Enabled = false;

                    break;
                case "Quản lý":
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
                    break;
                case "Nhân viên kho":
                    tsmi_Products.Enabled = false;
                    tsmi_Catogories.Enabled = false;
                    tsmi_Producers.Enabled = false;
                    tsmi_Customers.Enabled = false;
                    tsmi_PurchaseReceipts.Enabled = true;
                    tsmi_WarehouseNotes.Enabled = true;
                    tsmi_Employees.Enabled = false;
                    tsmi_Order.Enabled = false;
                    tsmi_Invoices.Enabled = true;
                    tsmi_Units.Enabled = false;
                    stmi_Manufacturers.Enabled = false;

                    tsmi_Statistical.Enabled = false;
                    break;
                default:
                    tsslb_EmployeeName.Text = "Chưa đăng nhập";
                    break;
            }
        }

        private void stmi_Manufacturers_Click(object sender, EventArgs e)
        {
            if (manufacturerView == null || manufacturerView.IsDisposed)
            {
                manufacturerView = _serviceProvider.GetRequiredService<IManufacturerView>() as ManufacturerView;
                _manufacturerPresenter = _serviceProvider.GetRequiredService<ManufacturerPresenter>();
                manufacturerView.MdiParent = this;
                manufacturerView.Show();
            }
            else
            {
                manufacturerView.Activate();
            }
        }

        private void tsmi_Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            tsslb_EmployeeName.Text = "Chưa đăng nhập";
        }

        private void stmi_ChangePassword_Click(object sender, EventArgs e)
        {
            AccoutView accoutView = new AccoutView();
            accoutView.MdiParent = this;
            accoutView.Show();
        }

        private void tsmi_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmi_InventoryStatistical_Click(object sender, EventArgs e)
        {
            ReportInventoryView reportInventoryView = new ReportInventoryView();
            reportInventoryView.MdiParent = this;
            reportInventoryView.Show();
        }
    }
}
