using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Reports;
using QuanLyCuaHangBanh.Views.Invoice.PurchaseInvoice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanh.Views.Invoice
{
    public partial class PurchaseInvoiceView : UserControl, IPurchaseView
    {
        private string messenge;
        private string searchValue;
        private PurchaseInvoiceDTO selectedPurchaseInvoice;
        string IView.SearchValue
        {
            get => searchValue;
            set => searchValue = value;
        }
        string IView.Message
        {
            get => messenge;
            set => messenge = value;
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
            get => selectedPurchaseInvoice;
            set => selectedPurchaseInvoice = (PurchaseInvoiceDTO)value;
        }

        public PurchaseInvoiceView()
        {
            InitializeComponent();
        }

        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_PurchaseInvoiceList.DataSource = bindingSource;
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

        private void dgv_PurchaseInvoiceList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_PurchaseInvoiceList.CurrentRow != null && dgv_PurchaseInvoiceList.CurrentRow.DataBoundItem is PurchaseInvoiceDTO purchaseInvoiceDTO)
            {
                this.selectedPurchaseInvoice = purchaseInvoiceDTO;
                RowSelected?.Invoke(sender, e);
            }
        }

        private void btn_PrintInvoice_Click(object sender, EventArgs e)
        {
            ReportPurchaseView reportPurchaseView = new ReportPurchaseView(selectedPurchaseInvoice.ID);
            reportPurchaseView.ShowDialog();
        }

        private void tsbtn_Import_Click(object sender, EventArgs e)
        {
            ImportEvent?.Invoke(sender, e);
        }

        private void tsbnt_Export_Click(object sender, EventArgs e)
        {
            ExportEvent?.Invoke(sender, e);
        }

        private void tsbtn_Search_Click(object sender, EventArgs e)
        {
            SearchEvent?.Invoke(sender, e);
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchEvent?.Invoke(sender, e);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            searchValue = toolStripTextBox1.Text.Trim();
        }
    }
}
