using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePay
{
    class Sale
    {
        public Sale(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date.Date;
        }

        public decimal Amount { get; }
        public DateTime Date { get; }
    }
}
