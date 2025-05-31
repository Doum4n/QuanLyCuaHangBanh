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
using QuanLyCuaHangBanh.Views.ReleaseNote;

namespace QuanLyCuaHangBanh.Views
{
    public partial class ReleaseNoteView : Form, IWareHouseReleaseNoteView
    {

        private string searchValue;
        private string message;
        private WarehouseReleaseNoteDTO selectedItem;

        public ReleaseNoteView()
        {
            InitializeComponent();
        }

        string IView.SearchValue { get; set; }
        string IView.Message
        {
            get
            {
                MessageBox.Show(message);
                return message;
            }
            set => message = value;
        }
        public event EventHandler? SearchEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? RowSelected;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;

        object IView.SelectedItem
        {
            get => selectedItem;
            set => selectedItem = (WarehouseReleaseNoteDTO)selectedItem;
        }
        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_WarehouseNoteList.DataSource = bindingSource;
        }

        public void RefreshData()
        {
            dgv_WarehouseNoteList.Refresh();
            dgv_WarehouseNoteList.ClearSelection(); 
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

        private void dgv_WarehouseNoteList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_WarehouseNoteList.SelectedRows.Count > 0)
            {
                selectedItem = (WarehouseReleaseNoteDTO)dgv_WarehouseNoteList.SelectedRows[0].DataBoundItem;
                RowSelected?.Invoke(sender, e);
            }
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
