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

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void tsmi_Products_Click(object sender, EventArgs e)
        {
            if (productView == null || productView.IsDisposed)
            {
                productView = new ProductView();
                QLCHB_DBContext ctx = new QLCHB_DBContext();
                new ProductPresenter(productView, new ProductRepo(ctx));
                productView.MdiParent = this;
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
                QLCHB_DBContext ctx = new QLCHB_DBContext();
                customerView = new CustomerView();
                new CustomerPresenter(customerView, new CustomerRepo(ctx));
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
