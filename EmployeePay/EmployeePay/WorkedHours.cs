using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePay
{
    class WorkedHours
    {
        public WorkedHours(int hours, DateTime date)
        {
            Hours = hours;
            Date = date.Date;
        }

        public int Hours { get; }
        public DateTime Date { get; }
    }
}
