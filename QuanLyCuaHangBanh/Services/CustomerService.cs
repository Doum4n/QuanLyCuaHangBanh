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
    public class CustomerService(IRepositoryProvider provider): IService
    {
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

        public void AddCustomer(Customer customer)
        {
            provider.GetRepository<Customer>().Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            provider.GetRepository<Customer>().Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            provider.GetRepository<Customer>().Delete(customer);
        }

        public DataTable ExportCustomersToDataTable(IEnumerable<CustomerDTO> customers)
        {
            DataTable dataTable = new DataTable("Customers");
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên khách hàng", typeof(string));
            dataTable.Columns.Add("Số điện thoại", typeof(string));
            dataTable.Columns.Add("Địa chỉ", typeof(string));
            dataTable.Columns.Add("Loại khách hàng", typeof(string));
            dataTable.Columns.Add("Giới hạn nợ", typeof(decimal));
            
            foreach (var item in customers)
            {
                dataTable.Rows.Add(item.ID, item.Name, item.PhoneNumber, item.Address, item.Type, item.Limit);
            }
            return dataTable;
        }

        public void ImportCustomerFromDataRow(DataRow row)
        {
            Customer customer = new Customer()
            {
                //ID = Convert.ToInt32(row[0]), // ID thường được tự động gán khi thêm mới
                Name = row["Tên khách hàng"].ToString() ?? string.Empty,
                PhoneNumber = row["Số điện thoại"].ToString() ?? string.Empty,
                Address = row["Địa chỉ"].ToString() ?? string.Empty,
                Type = row["Loại khách hàng"].ToString() ?? string.Empty,
                Limit = Convert.ToDecimal(row["Giới hạn nợ"].ToString() ?? "0")
            };
            provider.GetRepository<Customer>().Add(customer);
        }
    }
}