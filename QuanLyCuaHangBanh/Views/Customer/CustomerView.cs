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
using QuanLyCuaHangBanh.Helpers;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Customer;

namespace QuanLyCuaHangBanh.Views
{
    public partial class CustomerView : Form, ICustomerView
    {
        private string searchValue;
        private Models.Customer selectedCustomer;
        private string message;

        public CustomerView()
        {
            InitializeComponent();

            dgv_CustomerList.SelectionChanged += Dgv_CustomerList_SelectionChanged;
        }

        private void Dgv_CustomerList_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv_CustomerList.SelectedRows.Count > 0)
            {
                selectedCustomer = (Models.Customer)dgv_CustomerList.SelectedRows[0].DataBoundItem;
                RowSelected?.Invoke(sender, e);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.ConfirmDelete($"Bạn có muốn xóa khách hàng tên: {dgv_CustomerList.SelectedRows[0].Cells[1].Value.ToString()}"))
                DeleteEvent?.Invoke(sender, e);
        }

        private void CustomerView_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddNewEvent?.Invoke(sender, e);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditEvent?.Invoke(sender, e);
        }

        string IView.SearchValue { get => searchValue; set => searchValue = value; }

        string IView.Message
        {
            get => message;
            set
            {
                message = value;
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public event EventHandler? SearchEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? RowSelected;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;

        object IView.SelectedItem { get => selectedCustomer; set => selectedCustomer = (Models.Customer)value; }

        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_CustomerList.DataSource = bindingSource;
        }

        private void tstb_Search_TextChanged(object sender, EventArgs e)
        {
            searchValue = tstb_Search.Text;
            SearchEvent?.Invoke(sender, e);
        }

        private void tsbtn_Import_Click(object sender, EventArgs e)
        {
            ImportEvent.Invoke(sender, e);
        }

        private void tsbnt_Export_Click(object sender, EventArgs e)
        {
            ExportEvent.Invoke(sender, e);
        }
    }
}
