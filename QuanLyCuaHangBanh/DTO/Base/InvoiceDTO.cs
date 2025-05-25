using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.DTO.Base
{
    public abstract class InvoiceDTO
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public InvoiceDTO(int id, string employeeName, DateTime createdDate, decimal totalAmount, string status)
        {
            ID = id;
            EmployeeName = employeeName;
            CreatedDate = createdDate;
            Status = status;
            TotalAmount = totalAmount;
        }
    }
}
