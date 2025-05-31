using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyCuaHangBanh.Data;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Uitls;

namespace QuanLyCuaHangBanh.Reports
{
    public class AccountsReceivableDTO
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public decimal Limit { get; set; }
        public DateTime DueDate { get; set; }   
    }
    public partial class ReportAccountsReceivableView : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private QLCHBDataSet.AccountsReceiablesDataTable accountsReceivableTable = new QLCHBDataSet.AccountsReceiablesDataTable();
        private List<Object> accountsReceivableDTOs = new List<Object>();
        public ReportAccountsReceivableView()
        {
            InitializeComponent();
            this.Load += ReportAccountsReceiableView_Load;
        }

        private void btn_Fiilter_Click(object sender, EventArgs e)
        {
            var selectedCustomer = cbb_Customers.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                var filteredAccountsReceivableDTOs = accountsReceivableDTOs.Where(dto => ((AccountsReceivableDTO)dto).CustomerName == selectedCustomer.Name).ToList();
                LoadData(filteredAccountsReceivableDTOs);
            }
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            LoadData(accountsReceivableDTOs);
        }

        private void ReportAccountsReceiableView_Load(object sender, EventArgs e)
        {
            cbb_Customers.DataSource = context.Customers.ToList();
            cbb_Customers.DisplayMember = "Name";
            cbb_Customers.ValueMember = "ID";

            accountsReceivableDTOs = context.AccountsReceivables
            .Include(ar => ar.Customer)
            .Select(ar => new AccountsReceivableDTO
            {
                CustomerName = ar.Customer.Name,
                TotalAmount = ar.Amount,
                TransactionDate = ar.TransactionDate,
                Status = ar.IsPaid ? "Đã thanh toán" : "Chưa thanh toán",
                Limit = ar.Customer.Limit,
                DueDate = ar.DueDate
            }).Cast<Object>().ToList();
            
            LoadData(accountsReceivableDTOs);
        }

        private void LoadData(List<Object> ObjectList){
            ReportHanler.LoadData(
                reportViewer1,
                ObjectList,
                accountsReceivableTable,
                "rptAccountsReceivable.rdlc",
                "dsAccountsReceivable",
                (row, entity) =>
                {
                    var accountsReceivableDTO = (AccountsReceivableDTO)entity;
                    row["CustomerName"] = accountsReceivableDTO.CustomerName;
                    row["TotalAccountsReceivable"] = accountsReceivableDTO.TotalAmount;
                    row["TransactionDate"] = accountsReceivableDTO.TransactionDate;
                    row["Limit"] = accountsReceivableDTO.Limit;
                    row["DueDate"] = accountsReceivableDTO.DueDate;
                    row["Status"] = accountsReceivableDTO.Status;
                }
            );

            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("TotalAmount", ObjectList.Sum(dto => ((AccountsReceivableDTO)dto).TotalAmount).ToString("N0")));
            parameters.Add(new ReportParameter("CustomerName", "Khách hàng: " + cbb_Customers.Text));

            reportViewer1.LocalReport.SetParameters(parameters);
        }
    }
}
