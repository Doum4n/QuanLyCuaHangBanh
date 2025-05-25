using QuanLyCuaHangBanh.Base;

namespace QuanLyCuaHangBanh.Views.Order
{
    public partial class OrderView : Form, IOrderView
    {

        private string _searchValue = string.Empty;
        private string _message = string.Empty;
        private Models.Order _selectedItem = null!;

        string IView.SearchValue
        {
            get => _searchValue;
            set => _searchValue = value;
        }
        string IView.Message
        {
            get => _message;
            set => _message = value;
        }
        public event EventHandler? SearchEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? RowSelected;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;

        object IView.SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = (Models.Order)value;
        }

        public OrderView()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddNewEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent?.Invoke(this, EventArgs.Empty);
        }


        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_OrderList.DataSource = bindingSource;
        }

        private void tsbtn_Import_Click(object sender, EventArgs e)
        {
            ImportEvent?.Invoke(this, EventArgs.Empty);
        }

        private void tsbnt_Export_Click(object sender, EventArgs e)
        {
            ExportEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
