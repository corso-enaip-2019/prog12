using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePay
{
    class CommissionPaidEmployee : Employee
    {
        decimal salary = 0m;
        const decimal commissionPercentage = 0.1m;
        List<Sale> _sales;

        public CommissionPaidEmployee(int id, string name) : base(id, name)
        {
            _sales = new List<Sale>();
        }

        public void AddSales(List<Sale> sales)
        {
            _sales.AddRange(sales);
        }

        public override bool IsPayDay()
        {
            // CommissionPaid employee is paid day by day.
            return true;
        }

        public override PayRow RecordPay()
        {
            PayRow payRow = null;

            if (IsPayDay())
            {
                DateTime toDay = DateTime.Now.Date;

                foreach (Sale sale in _sales)
                {
                    if (toDay.Equals(sale.Date))
                    {
                        salary += sale.Amount * commissionPercentage;
                    }
                }

                payRow = new PayRow(Id, Name, salary, toDay);

                _sales = new List<Sale>();
            }

            return payRow;
        }
    }

}
