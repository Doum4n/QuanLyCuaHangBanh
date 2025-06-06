﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangBanh.Models.Base
{
    public abstract class Invoice
    {
        public int ID { get; set; }
        public DateTime Date { get; set; } // Date of the invoice
        public int EmployeeID { get; set; } // ID of the employee who created the invoice
        public string Note { get; set; } = string.Empty;

        public virtual Employee Employee { get; set; } // Navigation property to the Employee
        public virtual ICollection<Invoice_Detail> InvoiceDetails { get; set; } = new List<Invoice_Detail>();
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
