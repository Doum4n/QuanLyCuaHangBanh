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
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Views.Suplier;

namespace QuanLyCuaHangBanh.Views
{
    public partial class SuplierView : Form, ISuplierView
    {
        private string message;
        private string searchValue;
        private Supplier selectedProducer;
        public SuplierView()
        {
            InitializeComponent();

            dgv_ProducerList.SelectionChanged += Dgv_ProducerList_SelectionChanged;
        }

        private void Dgv_ProducerList_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv_ProducerList.SelectedRows.Count > 0)
            {
                selectedProducer = (Supplier)dgv_ProducerList.SelectedRows[0].DataBoundItem;
                RowSelected?.Invoke(this, EventArgs.Empty);
            }
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

        string IView.SearchValue
        {
            get => searchValue;
            set => searchValue = value;
        }
        string IView.Message { get => message; set => message = value; }
        public event EventHandler? SearchEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? AddNewEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? RowSelected;
        public event EventHandler ImportEvent;
        public event EventHandler ExportEvent;

        object IView.SelectedItem { get => selectedProducer; set => selectedProducer = (Supplier)value; }
        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_ProducerList.DataSource = bindingSource;
        }

        private void tstb_Search_TextChanged(object sender, EventArgs e)
        {
            searchValue = tstb_Search.Text;
            SearchEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
