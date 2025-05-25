using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Base;

namespace QuanLyCuaHangBanh.Views.Manufacturer
{
    public partial class ManufacturerView : Form, IManufacturerView
    {
        private string _searchValue;
        private string _message;
        private Models.Manufacturer _selectedItem;
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
        object IView.SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = (Models.Manufacturer)value;
        }

        public ManufacturerView()
        {
            InitializeComponent();
        }

        public event EventHandler SearchEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;

        private void ManufacturerView_Load(object sender, EventArgs e)
        {

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

        private void tsbtn_Import_Click(object sender, EventArgs e)
        {
            ImportEvent?.Invoke(this, EventArgs.Empty);
        }

        private void tsbnt_Export_Click(object sender, EventArgs e)
        {
            ExportEvent?.Invoke(this, EventArgs.Empty);
        }

        private void tsbtn_Search_Click(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }

        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_ManufacturerList.DataSource = bindingSource;
        }

        private void dgv_ManufacturerList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ManufacturerList.SelectedRows.Count > 0)
            {
                _selectedItem = (Models.Manufacturer)dgv_ManufacturerList.SelectedRows[0].DataBoundItem;
            }
            else
            {
                _selectedItem = null;
            }
        }

        private void tstb_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
                e.SuppressKeyPress = true; // Prevents the 'ding' sound on Enter key press
            }
        }

        private void tstb_Search_TextChanged(object sender, EventArgs e)
        {
            _searchValue = tstb_Search.Text.Trim();
            SearchEvent?.Invoke(this, EventArgs.Empty); // Trigger search when text changes
        }
    }
}
