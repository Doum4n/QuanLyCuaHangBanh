using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangBanh.Base;

namespace QuanLyCuaHangBanh.DTO
{
    public class OrderDTO : ISearchable
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;

        public OrderDTO(int id, string customerName, string phoneNumber, DateTime orderDate, decimal totalAmount, string status, string paymentMethod, string deliveryAddress)
        {
            ID = id;
            CustomerName = customerName;
            OrderDate = orderDate;
            Status = status;
            PaymentMethod = paymentMethod;
            DeliveryAddress = deliveryAddress;
            TotalAmount = totalAmount;
        }

        public bool MatchesSearch(string searchValue)
        {
            return ID.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   CustomerName.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   OrderDate.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   Status.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   PaymentMethod.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                   DeliveryAddress.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
