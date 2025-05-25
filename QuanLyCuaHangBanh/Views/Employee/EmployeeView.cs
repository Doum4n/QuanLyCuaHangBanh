using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Employee;

namespace QuanLyCuaHangBanh.Views
{
    public partial class EmployeeView : Form, IEmployeeView
    {
        private string messsage;
        private string searchvalue;
        private Models.Employee selectedEmployee;

        string IView.SearchValue
        {
            get => searchvalue;
            set => searchvalue = value;
        }
        string IView.Message
        {
            get
            {
                MessageBox.Show(messsage);
                return messsage;
            }
            set => messsage = value;
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
            get => selectedEmployee;
            set => selectedEmployee = (Models.Employee)selectedEmployee;
        }

        public EmployeeView()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddNewEvent?.Invoke(sender, e);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditEvent?.Invoke(sender, e);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent?.Invoke(sender, e);
        }


        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_EmployeeList.DataSource = bindingSource;
        }

        private void dgv_EmployeeList_SelectionChanged(object sender, EventArgs e)
        {
            selectedEmployee = (Models.Employee)dgv_EmployeeList.CurrentRow?.DataBoundItem;
            RowSelected?.Invoke(sender, e);
        }

        private void tsbtn_Import_Click(object sender, EventArgs e)
        {
            ImportEvent?.Invoke(sender, e);
        }

        private void tsbnt_Export_Click(object sender, EventArgs e)
        {
            ExportEvent?.Invoke(sender, e);
        }
    }
}
