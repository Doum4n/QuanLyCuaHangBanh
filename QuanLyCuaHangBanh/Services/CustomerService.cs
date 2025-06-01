using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Services
{
    /// <summary>
    /// Service xử lý nghiệp vụ liên quan đến khách hàng
    /// </summary>
    /// <param name="provider">Provider cung cấp các repository</param>
    public class CustomerService(IRepositoryProvider provider): IService
    {
        #region Public Methods

        /// <summary>
        /// Lấy danh sách tất cả khách hàng dưới dạng DTO
        /// </summary>
        /// <returns>Danh sách CustomerDTO chứa thông tin khách hàng</returns>
        public async Task<IList<CustomerDTO>> GetAllCustomers()
        {
            return await provider.GetRepository<Customer>().GetAllAsDto<CustomerDTO>(
                o => new CustomerDTO
                {
                    ID = o.ID,
                    Name = o.Name,
                    PhoneNumber = o.PhoneNumber,
                    Address = o.Address,
                    Type = o.Type,
                    TotalAccountPayable = o.AccountsReceivables.Sum(a => a.Amount),
                    Limit = o.Limit,
                }
            );
        }

        /// <summary>
        /// Thêm khách hàng mới vào database
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng cần thêm</param>
        public void AddCustomer(Customer customer)
        {
            provider.GetRepository<Customer>().Add(customer);
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng cần cập nhật</param>
        public void UpdateCustomer(Customer customer)
        {
            provider.GetRepository<Customer>().Update(customer);
        }

        /// <summary>
        /// Xóa khách hàng khỏi database
        /// </summary>
        /// <param name="customer">Đối tượng khách hàng cần xóa</param>
        public void DeleteCustomer(Customer customer)
        {
            provider.GetRepository<Customer>().Delete(customer);
        }

        /// <summary>
        /// Chuyển đổi danh sách khách hàng sang DataTable để xuất Excel
        /// </summary>
        /// <param name="customers">Danh sách khách hàng cần xuất</param>
        /// <returns>DataTable chứa thông tin khách hàng</returns>
        public DataTable ExportCustomersToDataTable(IEnumerable<CustomerDTO> customers)
        {
            DataTable dataTable = new DataTable("Customers");
            InitializeDataTableColumns(dataTable);
            
            foreach (var item in customers)
            {
                dataTable.Rows.Add(
                    item.ID, 
                    item.Name, 
                    item.PhoneNumber, 
                    item.Address, 
                    item.Type, 
                    item.Limit
                );
            }
            return dataTable;
        }

        /// <summary>
        /// Nhập thông tin khách hàng từ DataRow của file Excel
        /// </summary>
        /// <param name="row">DataRow chứa thông tin khách hàng</param>
        public void ImportCustomerFromDataRow(DataRow row)
        {
            Customer customer = new Customer()
            {
                Name = GetSafeString(row, "Tên khách hàng"),
                PhoneNumber = GetSafeString(row, "Số điện thoại"),
                Address = GetSafeString(row, "Địa chỉ"),
                Type = GetSafeString(row, "Loại khách hàng"),
                Limit = GetSafeDecimal(row, "Giới hạn nợ")
            };
            provider.GetRepository<Customer>().Add(customer);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Khởi tạo cấu trúc cột cho DataTable xuất Excel
        /// </summary>
        /// <param name="dataTable">DataTable cần khởi tạo cột</param>
        private void InitializeDataTableColumns(DataTable dataTable)
        {
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên khách hàng", typeof(string));
            dataTable.Columns.Add("Số điện thoại", typeof(string));
            dataTable.Columns.Add("Địa chỉ", typeof(string));
            dataTable.Columns.Add("Loại khách hàng", typeof(string));
            dataTable.Columns.Add("Giới hạn nợ", typeof(decimal));
        }

        /// <summary>
        /// Lấy giá trị string an toàn từ DataRow
        /// </summary>
        /// <param name="row">DataRow chứa dữ liệu</param>
        /// <param name="columnName">Tên cột cần lấy giá trị</param>
        /// <returns>Giá trị string, trả về rỗng nếu null</returns>
        private string GetSafeString(DataRow row, string columnName)
        {
            return row[columnName]?.ToString() ?? string.Empty;
        }

        /// <summary>
        /// Lấy giá trị decimal an toàn từ DataRow
        /// </summary>
        /// <param name="row">DataRow chứa dữ liệu</param>
        /// <param name="columnName">Tên cột cần lấy giá trị</param>
        /// <returns>Giá trị decimal, trả về 0 nếu không thể chuyển đổi</returns>
        private decimal GetSafeDecimal(DataRow row, string columnName)
        {
            return decimal.TryParse(row[columnName]?.ToString(), out decimal result) ? result : 0;
        }

        #endregion
    }
}