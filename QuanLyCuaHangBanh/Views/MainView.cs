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
        private OrderView? orderView;
        private InvoiceView? invoiceView;
        //private PurchaseInvoiceView? purchaseInvoiceView;
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


        private async void tsmi_Products_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu Form đã được tạo và chưa bị Dispose
            if (productView == null || productView.IsDisposed)
            {
                IServiceScope scope = null; // Khởi tạo null để đảm bảo có thể dispose nếu lỗi

                try
                {
                    scope = _serviceProvider.CreateScope();

                    productView = scope.ServiceProvider.GetRequiredService<IProductView>() as ProductView;
                    _productPresenter = scope.ServiceProvider.GetRequiredService<ProductPresenter>();

                    // Gắn scope vào Tag của Form con để có thể Dispose sau
                    productView.Tag = scope;

                    // Đăng ký sự kiện FormClosed để Dispose scope khi Form đóng
                    productView.FormClosed += ProductView_FormClosed;

                    productView.MdiParent = this;
                    productView.Show();

                    await _productPresenter.InitializeAsync(); // Gọi phương thức khởi tạo dữ liệu

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null)
                    {
                        scope.Dispose();
                    }
                    productView = null; // Đặt lại về null để có thể thử mở lại
                    _productPresenter = null;
                }
            }
            else
            {
                // Nếu Form đã mở, chỉ cần kích hoạt nó
                productView.Activate();
            }
        }

        private async void tsmi_Catogories_Click(object sender, EventArgs e)
        {
            if (categoryView == null || categoryView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    categoryView = scope.ServiceProvider.GetRequiredService<ICategoryView>() as CategoryView;
                    _categoryPresenter = scope.ServiceProvider.GetRequiredService<CategoryPresenter>();
                    categoryView.Tag = scope;
                    categoryView.FormClosed += CategoryView_FormClosed;
                    categoryView.MdiParent = this;
                    categoryView.Show();
                    await _categoryPresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    categoryView = null;
                    _categoryPresenter = null;
                }
            }
            else
            {
                categoryView.Activate();
            }
        }

        private async void tsmi_Producers_Click(object sender, EventArgs e)
        {
            if (producerView == null || producerView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    producerView = scope.ServiceProvider.GetRequiredService<ISuplierView>() as SuplierView; // producerView là SuplierView
                    _producerPresenter = scope.ServiceProvider.GetRequiredService<ProducerPresenter>();
                    producerView.Tag = scope;
                    producerView.FormClosed += ProducerView_FormClosed;
                    producerView.MdiParent = this;
                    producerView.Show();
                    await _producerPresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    producerView = null;
                    _producerPresenter = null;
                }
            }
            else
            {
                producerView.Activate();
            }
        }

        private async void tsmi_Customers_Click(object sender, EventArgs e)
        {
            if (customerView == null || customerView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    customerView = scope.ServiceProvider.GetRequiredService<ICustomerView>() as CustomerView;
                    _customerPresenter = scope.ServiceProvider.GetRequiredService<CustomerPresenter>();
                    customerView.Tag = scope;
                    customerView.FormClosed += CustomerView_FormClosed;
                    customerView.MdiParent = this;
                    customerView.Show();
                    await _customerPresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    customerView = null;
                    _customerPresenter = null;
                }
            }
            else
            {
                customerView.Activate();
            }
        }

        private async void tsmi_PurchaseReceipts_Click(object sender, EventArgs e)
        {
            if (purchaseReceiptView == null || purchaseReceiptView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    purchaseReceiptView = scope.ServiceProvider.GetRequiredService<IGoodsReceiptNoteView>() as GoodsReceiptNoteView;
                    _purchaseReceiptPresenter = scope.ServiceProvider.GetRequiredService<GoodsReceiptNotePresenter>();
                    purchaseReceiptView.Tag = scope;
                    purchaseReceiptView.FormClosed += PurchaseReceiptView_FormClosed;
                    purchaseReceiptView.MdiParent = this;
                    purchaseReceiptView.Show();
                    await _purchaseReceiptPresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    purchaseReceiptView = null;
                    _purchaseReceiptPresenter = null;
                }
            }
            else
            {
                purchaseReceiptView.Activate();
            }
        }

        private async void tsmi_WarehouseNotes_Click(object sender, EventArgs e)
        {
            if (warehouseReleaseNoteView == null || warehouseReleaseNoteView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    warehouseReleaseNoteView = scope.ServiceProvider.GetRequiredService<IWareHouseReleaseNoteView>() as ReleaseNoteView;
                    _warehouseReleaseNotePresenter = scope.ServiceProvider.GetRequiredService<WarehouseReleaseNotePresenter>();
                    warehouseReleaseNoteView.Tag = scope;

                    warehouseReleaseNoteView.FormClosed += WarehouseReleaseNoteView_FormClosed;
                    warehouseReleaseNoteView.MdiParent = this;

                    warehouseReleaseNoteView.Show();
                    await _warehouseReleaseNotePresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form phiếu xuất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    warehouseReleaseNoteView = null;
                    _warehouseReleaseNotePresenter = null;
                }
            }
            else
            {
                warehouseReleaseNoteView.Activate();
            }
        }

        private async void tsmi_Employees_Click(object sender, EventArgs e)
        {
            if (employeeView == null || employeeView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    employeeView = scope.ServiceProvider.GetRequiredService<IEmployeeView>() as EmployeeView;
                    _employeePresenter = scope.ServiceProvider.GetRequiredService<EmployeePresenter>();
                    employeeView.Tag = scope;
                    employeeView.FormClosed += EmployeeView_FormClosed;
                    employeeView.MdiParent = this;
                    employeeView.Show();
                    await _employeePresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    employeeView = null;
                    _employeePresenter = null;
                }
            }
            else
            {
                employeeView.Activate();
            }
        }

        private async void tsmi_Order_Click(object sender, EventArgs e)
        {
            if (orderView == null || orderView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    orderView = scope.ServiceProvider.GetRequiredService<IOrderView>() as OrderView;
                    _orderPresenter = scope.ServiceProvider.GetRequiredService<OrderPresenter>();
                    orderView.Tag = scope;
                    orderView.FormClosed += OrderView_FormClosed;
                    orderView.MdiParent = this;
                    orderView.Show();
                    await _orderPresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form đơn đặt hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    orderView = null;
                    _orderPresenter = null;
                }
            }
            else
            {
                orderView.Activate();
            }
        }

        private async void tsmi_Invoices_Click(object sender, EventArgs e)
        {
            if (invoiceView == null || invoiceView.IsDisposed)
            {
                IServiceScope salesScope = null;
                IServiceScope purchaseScope = null;
                try
                {
                    salesScope = _serviceProvider.CreateScope();
                    invoiceView = salesScope.ServiceProvider.GetRequiredService<ISalesInvoiceView>() as InvoiceView;

                    _invoicePresenter = salesScope.ServiceProvider.GetRequiredService<SalesInvoicePresenter>();
                    _purchasePresenter = salesScope.ServiceProvider.GetRequiredService<PurchasePresenter>();

                    invoiceView.Tag = salesScope;
                    invoiceView.FormClosed += InvoiceView_FormClosed; // Sử dụng FormClosed cho SalesInvoiceView

                    invoiceView.MdiParent = this;
                    invoiceView.Show();

                    await _invoicePresenter.InitializeAsync(); // Gọi phương thức khởi tạo dữ liệu
                    await _purchasePresenter.InitializeAsync(); // Khởi tạo dữ liệu cho PurchaseInvoiceView nếu cần thiết

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (salesScope != null) salesScope.Dispose();
                    if (purchaseScope != null) purchaseScope.Dispose();
                    invoiceView = null;
                    _invoicePresenter = null;
                    _purchasePresenter = null;
                }
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

        private async void tsmi_Units_Click(object sender, EventArgs e)
        {
            if (unitView == null || unitView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    unitView = scope.ServiceProvider.GetRequiredService<IUnitView>() as UnitView;
                    _unitPresenter = scope.ServiceProvider.GetRequiredService<UnitPresenter>();
                    unitView.Tag = scope;
                    unitView.FormClosed += UnitView_FormClosed;
                    unitView.MdiParent = this;
                    unitView.Show();
                    await _unitPresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form đơn vị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    unitView = null;
                    _unitPresenter = null;
                }
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

        private async void stmi_Manufacturers_Click(object sender, EventArgs e)
        {
            if (manufacturerView == null || manufacturerView.IsDisposed)
            {
                IServiceScope scope = null;
                try
                {
                    scope = _serviceProvider.CreateScope();
                    manufacturerView = scope.ServiceProvider.GetRequiredService<IManufacturerView>() as ManufacturerView;
                    _manufacturerPresenter = scope.ServiceProvider.GetRequiredService<ManufacturerPresenter>();
                    manufacturerView.Tag = scope;
                    manufacturerView.FormClosed += ManufacturerView_FormClosed;
                    manufacturerView.MdiParent = this;
                    manufacturerView.Show();
                    await _manufacturerPresenter.InitializeAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form nhà sản xuất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (scope != null) scope.Dispose();
                    manufacturerView = null;
                    _manufacturerPresenter = null;
                }
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

        /// <summary>
        /// HANDEL FORM CLOSED EVENT TO DISPOSE SCOPE
        /// </summary>
        private void ProductView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose(); // Dispose scope khi Form đóng
                    closedForm.Tag = null; // Xóa tham chiếu
                }
                // Xóa tham chiếu đến ProductView nếu là ProductView
                if (closedForm == productView)
                {
                    productView = null;
                    _productPresenter = null;
                }
            }
        }

        private void CategoryView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == categoryView)
                {
                    categoryView = null;
                    _categoryPresenter = null;
                }
            }
        }

        private void ProducerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == producerView)
                {
                    producerView = null;
                    _producerPresenter = null;
                }
            }
        }

        private void CustomerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == customerView)
                {
                    customerView = null;
                    _customerPresenter = null;
                }
            }
        }

        private void PurchaseReceiptView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == purchaseReceiptView)
                {
                    purchaseReceiptView = null;
                    _purchaseReceiptPresenter = null;
                }
            }
        }

        private void WarehouseReleaseNoteView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == warehouseReleaseNoteView)
                {
                    warehouseReleaseNoteView = null;
                    _warehouseReleaseNotePresenter = null;
                }
            }
        }

        private void EmployeeView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == employeeView)
                {
                    employeeView = null;
                    _employeePresenter = null;
                }
            }
        }

        private void OrderView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == orderView)
                {
                    orderView = null;
                    _orderPresenter = null;
                }
            }
        }

        private void InvoiceView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == invoiceView)
                {
                    invoiceView = null;
                    _invoicePresenter = null;
                }
            }
        }

        private void UnitView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == unitView)
                {
                    unitView = null;
                    _unitPresenter = null;
                }
            }
        }

        private void ManufacturerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose();
                    closedForm.Tag = null;
                }
                if (closedForm == manufacturerView)
                {
                    manufacturerView = null;
                    _manufacturerPresenter = null;
                }
            }
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sender is Form closedForm)
            {
                // Kiểm tra xem Form có chứa scope trong Tag không
                if (closedForm.Tag is IServiceScope scopeToDispose)
                {
                    scopeToDispose.Dispose(); // Dispose scope khi Form đóng
                    closedForm.Tag = null;    // Xóa tham chiếu để tránh lỗi
                }

                // Xóa tham chiếu đến Form và Presenter để cho phép Garbage Collector giải phóng bộ nhớ
                if (closedForm == productView)
                {
                    productView = null;
                    _productPresenter = null;
                }
            }
        }

        private void tsmi_AccountsPayable_Click(object sender, EventArgs e)
        {
            ReportAccountsPayable accountsPayableView = new ReportAccountsPayable();
            accountsPayableView.MdiParent = this;
            accountsPayableView.Show();
        }

        private void tsmi_AccountsReceiable_Click(object sender, EventArgs e)
        {
            ReportAccountsReceivableView accountsReceiableView = new ReportAccountsReceivableView();
            accountsReceiableView.MdiParent = this;
            accountsReceiableView.Show();
        }
    }
}