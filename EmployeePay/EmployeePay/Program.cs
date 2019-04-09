using System;
using System.Collections.Generic;

namespace EmployeePay
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PayRow> payLog = new List<PayRow>();
            IEnumerable<Employee> employees = CreateEmployeeMocks();


            foreach (Employee employee in employees) { 

                if (employee.IsPayDay())
                {
                    PayRow payRow = employee.RecordPay();

                    payLog.Add(payRow);

                    payRow.Print();
                }
            }

            Console.ReadKey();
        }

        static IEnumerable<Employee> CreateEmployeeMocks()
        {
            List<WorkedHours> workedHours = new List<WorkedHours>()
            {
                new WorkedHours(5, new DateTime(2019, 4, 8)),
                new WorkedHours(3, new DateTime(2019, 4, 9)),
                new WorkedHours(2, new DateTime(2019, 4, 8)),
            };

            List<Sale> sales = new List<Sale>()
            {
                new Sale(1000m, new DateTime(2019, 4, 8)),
                new Sale(300m, new DateTime(2019, 4, 9)),
                new Sale(200m, new DateTime(2019, 4, 9)),
            };

            HourlyPaied pluto = new HourlyPaied(2, "Pluto");
            pluto.AddWorkedHours(workedHours);

            CommissionPaid paperone = new CommissionPaid(3, "Paperone");
            paperone.AddSales(sales);

            return new List<Employee>()
            {
                new FixedSalary(1, "Pippo"),
                pluto,
                paperone,
            };
        }
    }

    abstract class Employee
    {
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
//        public decimal TotalPayment { get; set; }
        public abstract bool IsPayDay();
        public abstract PayRow RecordPay();
    }

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

        public void Print()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Amount: {Amount} Pay Date: {PayDate}");
        }
    }

    class FixedSalary : Employee
    {
        const decimal salary = 1500m;

        public FixedSalary(int id, string name) : base(id, name)
        { }

        public override bool IsPayDay()
        {
            // FixedSalary employee is paied on the last day of month.
            return true;

            return IsLastDayOfMonth();
        }

        public override PayRow RecordPay()
        {
            return new PayRow(Id, Name, salary, DateTime.Now);
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
        decimal salary = 0m;
        const decimal hourlyPay = 40m;
        List<WorkedHours> _workedHours;

        public HourlyPaied(int id, string name) : base(id, name)
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
            DateTime toDay = DateTime.Now.Date;
            DateTime firstDayOfThisWeek = toDay.AddDays(-5);

            foreach (WorkedHours workedHours in _workedHours)
            {
                if (firstDayOfThisWeek <= workedHours.Date && workedHours.Date < toDay)
                {
                    salary += workedHours.Hours * hourlyPay;
                }
            }

            _workedHours = new List<WorkedHours>();

            return new PayRow(Id, Name, salary, toDay);
        }

    }

    class CommissionPaid : Employee
    {
        decimal salary = 0m;
        const decimal commissionPercentage = 0.1m;
        List<Sale> _sales;

        public CommissionPaid(int id, string name) : base(id, name)
        {
            _sales = new List<Sale>();
        }

        public void AddSales(List<Sale> sales)
        {
            _sales.AddRange(sales);
        }

        public override bool IsPayDay()
        {
            return true;

            // CommissionPaid employee is paid day by day.
            return true;
        }
        public override PayRow RecordPay()
        {
            DateTime toDay = DateTime.Now.Date;


            foreach (Sale sale in _sales)
            {
                if (toDay.Equals(sale.Date))
                {
                    salary += sale.Amount * commissionPercentage;
                }
            }

            _sales = new List<Sale>();

            return new PayRow(Id, Name, salary, toDay);
        }
    }

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
