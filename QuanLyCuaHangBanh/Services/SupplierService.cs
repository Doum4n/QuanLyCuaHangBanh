using QuanLyCuaHangBanh.Base;
using QuanLyCuaHangBanh.DTO;
using QuanLyCuaHangBanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Services
{
    public class SupplierService(IRepositoryProvider provider) : IService
    {
        public async Task<IList<SupplierDTO>> GetAllOrdersAsDto()
        {
            return await provider.GetRepository<Supplier>().GetAllAsDto<SupplierDTO>(
                o => new SupplierDTO
                {
                    ID = o.ID,
                    Name = o.Name,
                    PhoneNumber = o.PhoneNumber,
                    Email = o.Email,
                    Address = o.Address,
                    Description = o.Description,
                    Limit = o.Limit, // Giới hạn công nợ
                    TotalAccountPayable = o.AccountsPayables.Sum(a => a.Amount) // Tính tổng công nợ phải trả
                }
            );
        }

        public void AddSupplier(Supplier supplier)
        {
            provider.GetRepository<Supplier>().Add(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            provider.GetRepository<Supplier>().Update(supplier);
        }

        public async Task DeleteSupplier(int supplierId)
        {
            var supplier = await provider.GetRepository<Supplier>().GetByValue(supplierId);
            if (supplier != null)
            {
                provider.GetRepository<Supplier>().Delete(supplier);
            }
        }
    }
}
