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

    

    public partial class ReportAccountsPayable : Form
    {
        private QLCHB_DBContext context = new QLCHB_DBContext();
        private QLCHBDataSet.AccountsPayableDataTable accountsPayableTable = new QLCHBDataSet.AccountsPayableDataTable();
        private List<Object> accountsPayableDTOs = new List<Object>();
        public ReportAccountsPayable()
        {
            InitializeComponent();
            this.Load += ReportAccountsPayable_Load;
        }

        private void ReportAccountsPayable_Load(object sender, EventArgs e)
        {
            cbb_Suppliers.DataSource = context.Suppliers.ToList();
            cbb_Suppliers.DisplayMember = "Name";
            cbb_Suppliers.ValueMember = "ID";

            accountsPayableDTOs = context.AccountsPayables
            .Include(ap => ap.Supplier)
            .Select(ap => new AccountsPayableDTO
            {
                SupplierName = ap.Supplier.Name,
                TotalAmount = ap.Amount,
                TransactionDate = ap.TransactionDate,
                Status = ap.IsPaid ? "Đã thanh toán" : "Chưa thanh toán",
                Limit = ap.Supplier.Limit,
                DueDate = ap.DueDate
            }).Cast<Object>().ToList();

            LoadData(accountsPayableDTOs);

       }

        private void LoadData(List<Object> ObjectList, bool isShowAll = false){
            ReportHanler.LoadData(
                reportViewer1,
                ObjectList,
                accountsPayableTable,
                "rptAccountsPayable.rdlc",
                "dsAccountsPayable",
                (row, entity) =>
                {
                    var accountsPayableDTO = (AccountsPayableDTO)entity;
                    row["SupplierName"] = accountsPayableDTO.SupplierName;
                    row["TotalAccountsPayable"] = accountsPayableDTO.TotalAmount;
                    row["TransactionDate"] = accountsPayableDTO.TransactionDate;
                    row["Limit"] = accountsPayableDTO.Limit;
                    row["DueDate"] = accountsPayableDTO.DueDate;
                    row["Status"] = accountsPayableDTO.Status;
                }
            );

            List<ReportParameter> parameters = new List<ReportParameter>();

            if(!isShowAll){
                parameters.Add(new ReportParameter("SupplierName", "Nhà cung cấp: " + cbb_Suppliers.Text));
            }else{
                parameters.Add(new ReportParameter("SupplierName", ""));
            }

            parameters.Add(new ReportParameter("TotalAmount", ObjectList.Sum(dto => ((AccountsPayableDTO)dto).TotalAmount).ToString("N0")));

            reportViewer1.LocalReport.SetParameters(parameters);
        }

        private void btn_Fiilter_Click(object sender, EventArgs e)
        {
            var selectedSupplier = cbb_Suppliers.SelectedItem as Supplier;
            if (selectedSupplier != null)
            {
                var filteredAccountsPayableDTOs = accountsPayableDTOs.Where(dto => ((AccountsPayableDTO)dto).SupplierName == selectedSupplier.Name).ToList();
                LoadData(filteredAccountsPayableDTOs);
            }
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            LoadData(accountsPayableDTOs, true);
        }

        public class AccountsPayableDTO
        {
            public string SupplierName { get; set; }
            public decimal TotalAmount { get; set; }
            public DateTime TransactionDate { get; set; }
            public string Status { get; set; }
            public decimal Limit { get; set; }
            public DateTime DueDate { get; set; }
        }
    }
}
