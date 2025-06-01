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
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Helpers;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Customer;

namespace QuanLyCuaHangBanh.Views
{
    /// <summary>
    /// Form quản lý khách hàng
    /// </summary>
    public partial class CustomerView : Form, ICustomerView
    {
        #region Fields
        private string searchValue;
        private CustomerDTO selectedCustomer;
        private string message;
        #endregion

        #region Constructor & Load
        /// <summary>
        /// Khởi tạo form quản lý khách hàng
        /// </summary>
        public CustomerView()
        {
            InitializeComponent();
            dgv_CustomerList.SelectionChanged += Dgv_CustomerList_SelectionChanged;
        }

        private void CustomerView_Load(object sender, EventArgs e)
        {
            // Khởi tạo dữ liệu khi form được load
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Xử lý sự kiện khi thay đổi dòng được chọn trong DataGridView
        /// </summary>
        private void Dgv_CustomerList_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv_CustomerList.SelectedRows.Count > 0)
            {
                selectedCustomer = (CustomerDTO)dgv_CustomerList.SelectedRows[0].DataBoundItem;
                RowSelected?.Invoke(sender, e);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút xóa
        /// </summary>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.ConfirmDelete($"Bạn có muốn xóa khách hàng tên: {dgv_CustomerList.SelectedRows[0].Cells[1].Value.ToString()}"))
                DeleteEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút thêm mới
        /// </summary>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddNewEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút chỉnh sửa
        /// </summary>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi nội dung tìm kiếm
        /// </summary>
        private void tstb_Search_TextChanged(object sender, EventArgs e)
        {
            searchValue = tstb_Search.Text;
            SearchEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút nhập Excel
        /// </summary>
        private void tsbtn_Import_Click(object sender, EventArgs e)
        {
            ImportEvent.Invoke(sender, e);
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút xuất Excel
        /// </summary>
        private void tsbnt_Export_Click(object sender, EventArgs e)
        {
            ExportEvent.Invoke(sender, e);
        }
        #endregion

        #region Interface Implementation
        string IView.SearchValue 
        { 
            get => searchValue; 
            set => searchValue = value; 
        }

        string IView.Message
        {
            get => message;
            set
            {
                message = value;
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        object IView.SelectedItem 
        { 
            get => selectedCustomer; 
            set => selectedCustomer = (CustomerDTO)value; 
        }

        /// <summary>
        /// Thiết lập binding source cho DataGridView
        /// </summary>
        /// <param name="bindingSource">Binding source chứa dữ liệu</param>
        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_CustomerList.DataSource = bindingSource;
        }

        /// <summary>
        /// Làm mới dữ liệu trong DataGridView
        /// </summary>
        public void RefreshData()
        {
            dgv_CustomerList.Refresh();
        }
        #endregion

        #region Events
        public event EventHandler? SearchEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? RowSelected;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;
        #endregion
    }
}
