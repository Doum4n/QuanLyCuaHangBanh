using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;

namespace QuanLyCuaHangBanh.Views.Order
{
    /// <summary>
    /// Form quản lý đơn hàng
    /// Cho phép xem danh sách, thêm, sửa, xóa đơn hàng
    /// </summary>
    public partial class OrderView : Form, IOrderView
    {
        #region Fields
        /// <summary>
        /// Giá trị tìm kiếm
        /// </summary>
        private string _searchValue = string.Empty;

        /// <summary>
        /// Thông báo hiển thị
        /// </summary>
        private string _message = string.Empty;

        /// <summary>
        /// Đơn hàng được chọn hiện tại
        /// </summary>
        private OrderDTO _selectedItem = null!;
        #endregion

        #region Properties
        /// <summary>
        /// Giá trị tìm kiếm từ IView
        /// </summary>
        string IView.SearchValue
        {
            get => _searchValue;
            set => _searchValue = value;
        }

        /// <summary>
        /// Thông báo từ IView
        /// </summary>
        string IView.Message
        {
            get => _message;
            set => _message = value;
        }

        /// <summary>
        /// Đơn hàng được chọn từ IView
        /// </summary>
        object IView.SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = (OrderDTO)value;
        }
        #endregion

        #region Events
        /// <summary>
        /// Sự kiện tìm kiếm
        /// </summary>
        public event EventHandler? SearchEvent;

        /// <summary>
        /// Sự kiện xóa đơn hàng
        /// </summary>
        public event EventHandler? DeleteEvent;

        /// <summary>
        /// Sự kiện thêm đơn hàng mới
        /// </summary>
        public event EventHandler? AddNewEvent;

        /// <summary>
        /// Sự kiện chỉnh sửa đơn hàng
        /// </summary>
        public event EventHandler? EditEvent;

        /// <summary>
        /// Sự kiện chọn dòng trong DataGridView
        /// </summary>
        public event EventHandler? RowSelected;

        /// <summary>
        /// Sự kiện nhập dữ liệu
        /// </summary>
        public event EventHandler ImportEvent;

        /// <summary>
        /// Sự kiện xuất dữ liệu
        /// </summary>
        public event EventHandler ExportEvent;
        #endregion

        #region Constructor
        /// <summary>
        /// Khởi tạo form quản lý đơn hàng
        /// </summary>
        public OrderView()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Xử lý sự kiện click nút Thêm
        /// </summary>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddNewEvent?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý sự kiện click nút Sửa
        /// </summary>
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditEvent?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý sự kiện click nút Xóa
        /// </summary>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý sự kiện click nút Nhập
        /// </summary>
        private void tsbtn_Import_Click(object sender, EventArgs e)
        {
            ImportEvent?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý sự kiện click nút Xuất
        /// </summary>
        private void tsbnt_Export_Click(object sender, EventArgs e)
        {
            ExportEvent?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi dòng được chọn trong DataGridView
        /// </summary>
        private void dgv_OrderList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_OrderList.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_OrderList.SelectedRows[0];
                if (selectedRow.DataBoundItem is OrderDTO order)
                {
                    _selectedItem = order;
                    RowSelected?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Thiết lập binding source cho DataGridView
        /// </summary>
        /// <param name="bindingSource">Binding source chứa dữ liệu</param>
        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_OrderList.DataSource = bindingSource;
        }

        /// <summary>
        /// Làm mới dữ liệu trong DataGridView
        /// </summary>
        public void RefreshData()
        {
            dgv_OrderList.Refresh();
            dgv_OrderList.ClearSelection();
            _selectedItem = null;
        }
        #endregion
    }
}
