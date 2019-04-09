using System;
using System.Collections.Generic;

namespace EmployeePay
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    abstract class Employee
    {
        public string Name { get; set; }
        public decimal TotalPayment { get; set; }
        public abstract bool IsPayDay();
        public abstract PayRow RecordPay();
    }

    class PayRow
    {
        string Name { get; set; };
        decimal Dmount { get; set; };
        DateTime PayDate { get; set; };
    }
    class FixedSalary : Employee
    {
        const decimal salary = 1500m;

        public override bool IsPayDay()
        {
            // On last day of the month
            return false;
        }
        public override PayRow RecordPay()
        {
            PayRow payRow = new PayRow();

            return payRow;
        }

        bool IsLastDayOfMonth()
        {
            DateTime toDay = DateTime.Now;

            int year  = toDay.Year;
            int month = toDay.Month;
            int day   = toDay.Day;

            return day == DateTime.DaysInMonth(year, month) ? true : false;
        }
    }

    class HourlyPaied : Employee
    {
        List<WorkedHours> _workedHours;

        HourlyPaied()
        {
            _workedHours = new List<WorkedHours>;
        }

        public void AddWorkedHours(List<WorkedHours> workedHours)
        {
            _workedHours.AddRange(workedHours); 
        }
        
        public override bool IsPayDay()
        {
            // Paied on saturday based on the list of worked hours
            return false;
        }

        public override PayRow RecordPay()
        {
            PayRow payRow = new PayRow();

            return payRow;
        }

    }

    class CommissionPaid : Employee
    {
        

        public override bool IsPayDay()
        {
            // Paied on current date if worked on commission
            return false;
        }
        public override PayRow RecordPay()
        {
            PayRow payRow = new PayRow();

            return payRow;
        }
    }

    class WorkedHours
    {
        public int hours { get; set; }
        public DateTime Date { get; set; }
    }
}
