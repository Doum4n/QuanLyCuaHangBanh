using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Helpers;
using QuanLyCuaHangBanh.Views.Product;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Presenters;

namespace QuanLyCuaHangBanh.Views
{
    public partial class ProductView : Form, IProductView
    {

        private string searchValue;
        private string message;
        private ProductDTO selecProduct;
        string IView.SearchValue { get => searchValue; set => searchValue = value; }

        string IView.Message
        {
            get => message;
            set
            {
                message = value;
                MessageBox.Show(message);
            }
        }

        object IView.SelectedItem
        {
            get => selecProduct;
            set
            {
                selecProduct = (ProductDTO)value;
                MessageBox.Show(selecProduct.Description);
            }
        }

        public ProductView()
        {
            InitializeComponent();

            dgv_ProductList.SelectionChanged += Dgv_ProductList_SelectionChanged;
        }

        private void Dgv_ProductList_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv_ProductList.SelectedRows.Count > 0)
            {
                selecProduct = (ProductDTO)dgv_ProductList.SelectedRows[0].DataBoundItem;
                RowSelected?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler SearchEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler SelectedUnitChanged;
        public event EventHandler RowSelected;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddNewEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditEvent?.Invoke(this, e);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent?.Invoke(this, EventArgs.Empty);
        }
        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_ProductList.DataError += HandleDataError;

            dgv_ProductList.DataSource = bindingSource;

            dgv_ProductList.DataBindingComplete += dgv_ProductList_DataBindingComplete;
        }

        public void RefreshData()
        {
            dgv_ProductList.Refresh();
            dgv_ProductList.ClearSelection();
            selecProduct = null;
            dgv_ProductList.DataBindingComplete -= dgv_ProductList_DataBindingComplete; // Ngăn chặn sự kiện này được gọi nhiều lần
            dgv_ProductList.DataBindingComplete += dgv_ProductList_DataBindingComplete; // Đăng ký lại sự kiện
        }

        private async void dgv_ProductList_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Kiểm tra xem DataGridView đã được khởi tạo hoàn chỉnh chưa
            if (dgv_ProductList.IsDisposed || !dgv_ProductList.IsHandleCreated) return;

            // Dùng Task.WhenAll nếu muốn tải ảnh song song và không chặn UI
            var tasks = new List<Task>();

            foreach (DataGridViewRow row in dgv_ProductList.Rows)
            {
                if (row.IsNewRow) continue;

                // Kiểm tra lại row có hợp lệ không
                if (row == null || row.Cells == null || row.DataBoundItem == null) continue;

                if (row.DataBoundItem is ProductDTO product)
                {
                    #region Cập nhật dữ liệu cho ComboBox cho cột "Unit" (Cell type là DataGridViewComboBoxCell)
                    // Cần đảm bảo cột "Unit" là DataGridViewComboBoxColumn trong designer hoặc khi tạo cột
                    if (dgv_ProductList.Columns.Contains("Unit") && row.Cells["Unit"] is DataGridViewComboBoxCell comboCell)
                    {
                        // Gán DataSource cho cell cụ thể (rất quan trọng)
                        comboCell.DataSource = product.Units.ToList();
                        comboCell.DisplayMember = "UnitName";
                        comboCell.ValueMember = "ID";
                        comboCell.ReadOnly = false;

                        // Gán giá trị được chọn
                        var selectedUnit = product.Units.FirstOrDefault(o => o.IsSelected);
                        if (selectedUnit != null)
                        {
                            comboCell.Value = selectedUnit.ID;
                        }
                        else if (product.Units.Any())
                        {
                            comboCell.Value = product.Units.First().ID;
                        }
                    }
                    #endregion

                    #region Thêm dữ liệu cho cột "Image" (Cell type là DataGridViewImageCell)
                    if (dgv_ProductList.Columns.Contains("Image") && row.Cells["Image"] is DataGridViewImageCell imageCell)
                    {
                        imageCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        // Bắt đầu tải ảnh bất đồng bộ và thêm vào danh sách tasks
                        tasks.Add(LoadImageForCellAsync(imageCell, product.ImagePath));
                    }
                    #endregion
                }
            }
            // Chờ tất cả các tác vụ tải ảnh hoàn thành
            await Task.WhenAll(tasks);
        }

        private async Task LoadImageForCellAsync(DataGridViewImageCell cell, string imagePath)
        {
            // Kiểm tra null và disposed trước khi truy cập
            if (cell == null || cell.OwningRow == null || cell.OwningColumn == null || cell.OwningColumn.DataGridView == null)
            {
                return;
            }

            var dgv = cell.OwningColumn.DataGridView;
            if (dgv.IsDisposed || !dgv.IsHandleCreated)
            {
                return;
            }

            try
            {
                Image image = null;
                if (!string.IsNullOrEmpty(imagePath))
                {
                    // Tải ảnh bất đồng bộ từ ImageHelper
                    image = await ImageHelper.LoadImageFromUrl(imagePath);
                }

                // Cập nhật UI trên luồng UI chính
                if (dgv.InvokeRequired)
                {
                    dgv.Invoke(new MethodInvoker(() =>
                    {
                        // Kiểm tra lại các đối tượng có còn hợp lệ sau khi Invoke không
                        if (cell.OwningRow != null && cell.OwningColumn != null && !dgv.IsDisposed)
                        {
                            cell.Value = image;
                        }
                    }));
                }
                else
                {
                    cell.Value = image;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải ảnh cho ô: {ex.Message}");
                // Có thể gán một ảnh lỗi mặc định ở đây nếu muốn
            }
        }



        private void HandleDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"DataError: {e.Exception.Message}");
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void ProductView_Load(object sender, EventArgs e)
        {
            dgv_ProductList.AutoGenerateColumns = false;
            dgv_ProductList.DataError += HandleDataError;

            //dgv_ProductList.Columns["SelectedUnitId"].Visible = false;
        }

        private void dgv_ProductList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgv_ProductList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_ProductList.CurrentCell.OwningColumn?.Name == "Unit" && e.Control is ComboBox comboBox)
            {
                // Chỉ gán 1 lần event Handler duy nhất
                if (!(comboBox.Tag is bool))
                {
                    comboBox.SelectionChangeCommitted += SelectedUnitChanged;
                    comboBox.Tag = true; // Đánh dấu đã gán event
                }

                // Gán thêm dữ liệu dòng hiện tại
                if (dgv_ProductList.CurrentRow?.DataBoundItem is ProductDTO product)
                {
                    // Gán DataSource cho ComboBox
                    comboBox.DataSource = product.Units.ToList(); // Đảm bảo DataSource đúng
                    comboBox.DisplayMember = "UnitName";
                    comboBox.ValueMember = "ID";
                    assignComboboxSelectedValue(product, comboBox);

                    // Gán giá trị hiện tại cho ComboBox
                    product.Units.First().IsSelected = true; // Đánh dấu đơn vị đầu tiên là true

                    // Gán product cho ComboBox.Tag để khi chọn đọc ra
                    comboBox.Tag = product;
                }
            }
        }

        private void assignComboboxSelectedValue(ProductDTO product, ComboBox comboBox)
        {
            // Nếu có đơn vị nào được chọn thì gán giá trị cho comboCell
            // Nếu không có đơn vị nào được chọn thì gán giá trị cho đơn vị đầu tiên
            var selectedUnit = product.Units.FirstOrDefault(o => o.IsSelected == true);
            if (selectedUnit != null)
                comboBox.SelectedValue = selectedUnit.ID;
            else
            {
                if (product.Units.Any())
                    comboBox.SelectedValue = product.Units.First().ID;
            }
        }

        private void dgv_ProductList_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            int maxHeight = 50; // Chiều cao tối đa bạn muốn

            if (e.Row.Height > maxHeight)
            {
                e.Row.Height = maxHeight;
            }
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

        private void dgv_ProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgv_ProductList.Columns["ViewDetail"].Index)
            {
                btn_Edit_Click(sender, new ProductViewEventArgs(false));
            }
        }

        private void tsbtn_Search_Click_1(object sender, EventArgs e)
        {

        }

        private void tstb_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn chặn âm thanh "ding" khi nhấn Enter
                SearchEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        private void tstb_Search_TextChanged(object sender, EventArgs e)
        {
            searchValue = tstb_Search.Text.Trim(); // Cập nhật giá trị tìm kiếm khi người dùng nhập
        }
    }
}
