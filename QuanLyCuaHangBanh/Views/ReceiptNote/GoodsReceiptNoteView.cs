using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Views.ReceiptNote;

namespace QuanLyCuaHangBanh.Views
{
    public partial class GoodsReceiptNoteView : Form, IGoodsReceiptNoteView
    {
        private string searchValue;
        private string message;
        private GoodsReceiptNoteDTO selectedItem;
        public GoodsReceiptNoteView()
        {
            InitializeComponent();
        }

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
                MessageBox.Show(message);
            }
        }
        object IView.SelectedItem
        {
            get => selectedItem;
            set => selectedItem = (GoodsReceiptNoteDTO)value;
        }

        public event EventHandler SearchEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler RowSelected;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;

        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_PurchaseReceiptList.DataSource = bindingSource;
        }

        private void dgv_PurchaseReceiptList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_PurchaseReceiptList.SelectedRows.Count > 0)
            {
                selectedItem = (GoodsReceiptNoteDTO)dgv_PurchaseReceiptList.SelectedRows[0].DataBoundItem;
                RowSelected?.Invoke(sender, e);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddNewEvent?.Invoke(this, EventArgs.Empty);
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
    }
}
