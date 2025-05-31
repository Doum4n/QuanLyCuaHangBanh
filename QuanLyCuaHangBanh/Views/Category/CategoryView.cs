using System.Data;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views.Category;

namespace QuanLyCuaHangBanh.Views
{
    public partial class CategoryView : Form, ICategoryView
    {
        private string searchValue;
        private string message;
        private Models.Category selectedCategory;
        public CategoryView()
        {
            InitializeComponent();

            dgv_CategoryList.SelectionChanged += DgvCategory_SelectionChanged;
        }

        private void DgvCategory_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv_CategoryList.SelectedRows.Count > 0)
            {
                if (dgv_CategoryList.SelectedRows[0].DataBoundItem is Models.Category category)
                {
                    selectedCategory = category;
                    RowSelected?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        object IView.SelectedItem
        {
            get => selectedCategory;
            set => selectedCategory = (Models.Category)value;
        }
        string IView.SearchValue { get => searchValue; set => searchValue = value; }
        string IView.Message { get => message; set => message = value; }

        public event EventHandler? SearchEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler RowSelected;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;

        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_CategoryList.DataSource = bindingSource;
        }

        public void RefreshData()
        {
            dgv_CategoryList.Refresh();
            dgv_CategoryList.ClearSelection();
            selectedCategory = null;
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

        private void tstb_Search_TextChanged(object sender, EventArgs e)
        {
            searchValue = tstb_Search.Text;
            SearchEvent?.Invoke(sender, e);
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
