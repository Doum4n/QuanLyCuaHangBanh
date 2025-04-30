using Microsoft.Extensions.DependencyInjection;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Presenters;
using QuanLyCuaHangBanh.Repositories;
using QuanLyCuaHangBanh.Views;

namespace QuanLyCuaHangBanh
{
    public partial class MainView : Form
    {
        private ProductView? productView;
        private CategoryView? categoryView;
        private ProducerView? producerView;
        private CustomerView? customerView;

        private ProductPresenter? _productPresenter;
        private CustomerPresenter? _customerPresenter;
        private CategoryPresenter? _categoryPresenter;
        private ProducerPresenter? _producerPresenter;

        private readonly IServiceProvider _serviceProvider;

        public MainView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void MainView_Load(object sender, EventArgs e)
        {

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
                categoryView = new CategoryView();
                new CategoryPresenter(categoryView);
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
                producerView = new ProducerView();
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
                _customerPresenter =  _serviceProvider.GetRequiredService<CustomerPresenter>();
                customerView.MdiParent = this;
                customerView.Show();
            }
            else
            {
                customerView.Activate();
            }
        }
    }
}
