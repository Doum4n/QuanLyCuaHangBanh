using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.DTO;
using System.Data;
using System.Windows.Forms;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Helpers;
using QuanLyCuaHangBanh.Views.Product;

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
            EditEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteEvent?.Invoke(this, EventArgs.Empty);
        }
        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_ProductList.DataError += HandleDataError;

            dgv_ProductList.DataSource = bindingSource;

            dgv_ProductList.DataBindingComplete += (s, e) =>
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    foreach (DataGridViewRow row in dgv_ProductList.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.DataBoundItem is ProductDTO product)
                        {
                            #region Thêm dữ liệu cho comboBox cho cột "Unit"
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

                            // Nếu có đơn vị nào được chọn thì gán giá trị cho comboCell
                            // Nếu không có đơn vị nào được chọn thì gán giá trị cho đơn vị đầu tiên
                            var selectedUnit = product.Unit.FirstOrDefault(o => o.IsSelected == true);
                            if (selectedUnit != null)
                                comboCell.Value = selectedUnit.ID;
                            else
                            {
                                if (product.Unit.Any())
                                {
                                    comboCell.Value = product.Unit.First().ID;
                                    product.Unit.First().IsSelected = true; // Đánh dấu đơn vị đầu tiên là true
                                }
                            }

                            row.Cells["Unit"] = comboCell;
                            row.Cells["Unit"].ReadOnly = false;
                            #endregion

                            #region Thêm dữ liệu cho cột "Image"
                            var imageCell = new DataGridViewImageCell
                            {
                                ImageLayout = DataGridViewImageCellLayout.Zoom,
                                Value = ImageHelper.LoadImageFromUrl(product.ImagePath),
                            };
                            row.Cells["Image"] = imageCell;
                            #endregion
                        }
                    }
                }));

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
                    comboBox.DataSource = product.Unit.ToList(); // Đảm bảo DataSource đúng
                    comboBox.DisplayMember = "UnitName";
                    comboBox.ValueMember = "ID";
                    assignComboboxSelectedValue(product, comboBox);

                    // Gán giá trị hiện tại cho ComboBox
                    product.Unit.First().IsSelected = true; // Đánh dấu đơn vị đầu tiên là true

                    // Gán product cho ComboBox.Tag để khi chọn đọc ra
                    comboBox.Tag = product;
                }
            }
        }

        private void assignComboboxSelectedValue(ProductDTO product, ComboBox comboBox)
        {
            // Nếu có đơn vị nào được chọn thì gán giá trị cho comboCell
            // Nếu không có đơn vị nào được chọn thì gán giá trị cho đơn vị đầu tiên
            var selectedUnit = product.Unit.FirstOrDefault(o => o.IsSelected == true);
            if (selectedUnit != null)
                comboBox.SelectedValue = selectedUnit.ID;
            else
            {
                if (product.Unit.Any())
                    comboBox.SelectedValue = product.Unit.First().ID;
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
    }
}
