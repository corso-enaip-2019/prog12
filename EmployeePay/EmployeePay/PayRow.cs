using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePay
{
    class PayRow
    {
        public PayRow(int id, string name, decimal amount, DateTime payDate)
        {
            Id = id;
            Name = name;
            Amount = amount;
            PayDate = payDate;
        }

        int Id { get; }
        string Name { get; }
        decimal Amount { get; }
        DateTime PayDate { get; }

        public override string ToString()
        {
            return $"ID: {Id,3}, Name: {Name,10}, Amount: {Amount,5} Pay Date: {PayDate}";
        }
    }
}
