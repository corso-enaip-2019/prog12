using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePay
{
    class FixedSalaryEmployee : Employee
    {
        const decimal salary = 1500m;

        public FixedSalaryEmployee(int id, string name) : base(id, name)
        { }

        public override bool IsPayDay()
        {
            // FixedSalary employee is paied on the last day of month.
            return true;

            return IsLastDayOfMonth();
        }

        public override PayRow RecordPay()
        {
            PayRow payRow = null;

            if (IsPayDay())
            {
                payRow = new PayRow(Id, Name, salary, DateTime.Now.Date);
            }

            return payRow;
        }

        bool IsLastDayOfMonth()
        {
            DateTime toDay = DateTime.Now;

            int year = toDay.Year;
            int month = toDay.Month;
            int day = toDay.Day;

            return day == DateTime.DaysInMonth(year, month) ? true : false;
        }
    }
}
