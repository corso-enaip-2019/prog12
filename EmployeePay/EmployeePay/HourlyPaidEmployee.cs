using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePay
{
    class HourlyPaidEmployee : Employee
    {
        decimal salary = 0m;
        const decimal hourlyPay = 40m;
        List<WorkedHours> _workedHours;

        public HourlyPaidEmployee(int id, string name) : base(id, name)
        {
            _workedHours = new List<WorkedHours>();
        }

        public void AddWorkedHours(List<WorkedHours> workedHours)
        {
            _workedHours.AddRange(workedHours);
        }

        public override bool IsPayDay()
        {
            return true;
            // FixedSalary employee is paied on saturday.
            return DateTime.Now.DayOfWeek == System.DayOfWeek.Saturday;
        }

        public override PayRow RecordPay()
        {
            PayRow payRow = null;

            if (IsPayDay())
            {
                DateTime toDay = DateTime.Now.Date;
                DateTime firstDayOfThisWeek = toDay.AddDays(-5);

                foreach (WorkedHours workedHours in _workedHours)
                {
                    if (firstDayOfThisWeek <= workedHours.Date && workedHours.Date < toDay)
                    {
                        salary += workedHours.Hours * hourlyPay;
                    }
                }

                payRow = new PayRow(Id, Name, salary, toDay);

                _workedHours = new List<WorkedHours>();
            }

            return payRow;
        }

    }
}

