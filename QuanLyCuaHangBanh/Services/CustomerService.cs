using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.Models;
using QuanLyCuaHangBanh.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QuanLyCuaHangBanh.Services
{
    public class CustomerService(IRepositoryProvider provider): IService
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            return provider.GetRepository<Customer>().GetAll();
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

        public DataTable ExportCustomersToDataTable(IEnumerable<Customer> customers)
        {
            DataTable dataTable = new DataTable("Customers");
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Tên khách hàng", typeof(string));
            dataTable.Columns.Add("Số điện thoại", typeof(string));
            dataTable.Columns.Add("Địa chỉ", typeof(string));

            foreach (var item in customers)
            {
                dataTable.Rows.Add(item.ID, item.Name, item.PhoneNumber, item.Address);
            }
            return dataTable;
        }

        public void ImportCustomerFromDataRow(DataRow row)
        {
            Customer customer = new Customer()
            {
                //ID = Convert.ToInt32(row[0]), // ID thường được tự động gán khi thêm mới
                Name = row[1].ToString() ?? string.Empty,
                PhoneNumber = row[2].ToString() ?? string.Empty,
                Address = row[3].ToString() ?? string.Empty
            };
            provider.GetRepository<Customer>().Add(customer);
        }

        public IEnumerable<Customer> SearchCustomers(string searchValue)
        {
            var searchText = searchValue.Trim().ToLower();
            return provider.GetRepository<Customer>()
                .GetAll()
                .Where(c => c.Name.ToLower().Contains(searchText) ||
                            c.PhoneNumber.ToLower().Contains(searchText) ||
                            c.Address.ToLower().Contains(searchText))
                .ToList();
        }
    }
}