using QuanLyCuaHangBanh.Presenters;
using QuanLyCuaHangBanh.Views;

namespace QuanLyCuaHangBanh
{
    public partial class MainView : Form
    {
        private ProductView? productView; 

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
                new ProductPresenter(productView);
                productView.MdiParent = this;
                productView.Show();
            }
            else
            {
                productView.Activate();
            }
        }
    }
}
