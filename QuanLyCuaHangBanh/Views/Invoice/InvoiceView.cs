using Microsoft.Extensions.DependencyInjection;
using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO.Base;
using QuanLyCuaHangBanh.Presenters;
using QuanLyCuaHangBanh.Reports;
using QuanLyCuaHangBanh.Uitls;
using QuanLyCuaHangBanh.Views.Invoice.PurchaseInvoice;
using QuanLyCuaHangBanh.Views.Invoice.SalesInvoice;
using System.Windows.Forms;

namespace QuanLyCuaHangBanh.Views.Invoice
{
    public partial class InvoiceView : Form, ISalesInvoiceView
    {
        private string messenge;
        private string searchValue;
        private InvoiceDTO selectedInvoice;
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
            get => selectedInvoice;
            set => selectedInvoice = (InvoiceDTO)selectedInvoice;
        }
        private readonly IServiceProvider serviceProvider;
        public InvoiceView(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
        }

        public void SetBindingSource(BindingSource bindingSource)
        {
            dgv_InvoiceList.DataSource = bindingSource;
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

        private void dgv_InvoiceList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_InvoiceList.CurrentRow != null && dgv_InvoiceList.CurrentRow.DataBoundItem is InvoiceDTO selectedInvoice)
            {
                this.selectedInvoice = selectedInvoice;
                RowSelected?.Invoke(sender, e);
            }
        }

        private void btn_AddPurchaseInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btn_EditPurchaseInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btn_DeletePurchaseInvoice_Click(object sender, EventArgs e)
        {

        }

        private void InvoiceView_Load(object sender, EventArgs e)
        {
            if(Session.Role == "Nhân viên bán hàng")
            {
                tabControl2.TabPages.Remove(tabPane_PurchaseInvoice);
            }
            else if (Session.Role == "Nhân viên kho")
            {
                tabControl2.TabPages.Remove(tabPage_SalesInvoice);
            }  
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 0)
            {

            }
            else if (tabControl2.SelectedIndex == 1)
            {
                tabPane_PurchaseInvoice.Controls.Clear();

                // LẤY VIEW QUA DI
                var purchaseView = serviceProvider.GetRequiredService<IPurchaseView>() as PurchaseInvoiceView;
                var purchasePresenter = serviceProvider.GetRequiredService<PurchasePresenter>();

                tabPane_PurchaseInvoice.Controls.Add(purchaseView);

                purchaseView.Dock = DockStyle.Fill;
            }
        }

        private void btn_PrintInvoice_Click(object sender, EventArgs e)
        {
            ReportSalesInvoiceView reportSalesInvoiceView = new ReportSalesInvoiceView((int)selectedInvoice.ID);
            reportSalesInvoiceView.ShowDialog();
        }
    }
}
