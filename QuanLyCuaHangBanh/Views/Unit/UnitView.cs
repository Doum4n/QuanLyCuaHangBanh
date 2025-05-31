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

namespace QuanLyCuaHangBanh.Views.Unit
{
    public partial class UnitView : Form, IUnitView
    {
        private string _searchValue;
        private string _message;
        private Models.Unit _selectedItem;

        string IView.SearchValue
        {
            get => _searchValue;
            set => _searchValue = value;
        }
        string IView.Message
        {
            get => _message;
            set
            {
                MessageBox.Show(value, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _message = value;
            }
        }
        public event EventHandler? SearchEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? ImportEvent;
        public event EventHandler? ExportEvent;
        object IView.SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = (Models.Unit)value;
        }

        public UnitView()
        {
            InitializeComponent();
        }


        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_UnitList.DataSource = bindingSource;
        }

        public void RefreshData()
        {
            dgv_UnitList.Refresh();
            dgv_UnitList.ClearSelection();
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

        private void tsbtn_Import_Click(object sender, EventArgs e)
        {
            ImportEvent?.Invoke(sender, e);
        }

        private void tsbnt_Export_Click(object sender, EventArgs e)
        {
            ExportEvent?.Invoke(sender, e);
        }

        private void dgv_CustomerList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_UnitList.SelectedRows.Count > 0)
            {
                _selectedItem = (Models.Unit)dgv_UnitList.SelectedRows[0].DataBoundItem;
            }
        }

        private void UnitView_Load(object sender, EventArgs e)
        {

        }

        private void tstb_Search_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tstb_Search_TextChanged(object sender, EventArgs e)
        {
            _searchValue = tstb_Search.Text.Trim();
            SearchEvent?.Invoke(sender, e);
        }
    }
}
