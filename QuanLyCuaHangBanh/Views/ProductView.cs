using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangBanh.Views
{
    public partial class ProductView : Form, IProductView
    {

        private string searchValue;
        private string message;
        string IView.SearchValue { get => searchValue; set => searchValue = value; }
        string IView.Message { get => message; set => message = value; }

        private bool isFirstBinding = true;

        public ProductView()
        {
            InitializeComponent();
        }

        public event EventHandler SearchEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler SelectedUnitChanged;

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_ProductList.DataError += HandleDataError;

            dgv_ProductList.DataSource = bindingSource;

            dgv_ProductList.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewRow row in dgv_ProductList.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.DataBoundItem is ProductDTO product)
                    {
                        var comboCell = new DataGridViewComboBoxCell
                        {
                            DataSource = product.Unit.ToList(),
                            DisplayMember = "UnitName",
                            ValueMember = "ID",
                            ReadOnly = false,
                        };

                        if (row.Cells["Unit"].Value != null)
                        {
                            comboCell.Value = row.Cells["Unit"].Value;
                        }

                        if (product.SelectedUnitId.HasValue)
                            comboCell.Value = product.SelectedUnitId.Value;
                        else
                        {
                            if (product.Unit.Any())
                                comboCell.Value = product.Unit.First().ID;
                        }

                        row.Cells["Unit"] = comboCell;
                    }
                }

            };
        }


        private void HandleDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Log lỗi nếu cần
            MessageBox.Show($"DataError: {e.Exception.Message}");
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void ProductView_Load(object sender, EventArgs e)
        {
            dgv_ProductList.AutoGenerateColumns = false;
            dgv_ProductList.DataError += HandleDataError;
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
                    comboBox.DataSource = product.Unit.ToList(); // Đảm bảo DataSource đúng
                    comboBox.DisplayMember = "UnitName";
                    comboBox.ValueMember = "ID";
                    comboBox.SelectedValue = product.SelectedUnitId ?? product.Unit.FirstOrDefault()?.ID;

                    // Gán product cho ComboBox.Tag để khi chọn đọc ra
                    comboBox.Tag = product;
                }
            }
        }
    }
}
