using QuanLyCuaHangBanh.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO
{
    public class SaleInvoiceDTO(int id, string employeeName, DateTime createdDate, decimal totalAmount, string status) : InvoiceDTO(id, employeeName, createdDate, totalAmount, status)
    {
    }
}
