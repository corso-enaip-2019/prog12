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

            Console.WriteLine("### Payroll ###" + Environment.NewLine);

            foreach (Employee employee in employees) { 

                if (employee.IsPayDay())
                {
                    PayRow payRow = employee.RecordPay();
                    payLog.Add(payRow);
                }
            }

            Console.WriteLine("Pay log of {0}" + Environment.NewLine, DateTime.Now.ToString("dd/MM/yyyy"));

            foreach (PayRow payRow in payLog)
            {
                Console.WriteLine(payRow);
            }

            Console.ReadKey();
        }

        static IEnumerable<Employee> CreateEmployeeMocks()
        {
            List<WorkedHours> workedHours = new List<WorkedHours>()
            {
                new WorkedHours(200, new DateTime(2019, 4, 25)),
                new WorkedHours(5,   new DateTime(2019, 4, 8)),
                new WorkedHours(3,   new DateTime(2019, 4, 9)),
                new WorkedHours(2,   new DateTime(2019, 4, 8)),
            };

            List<Sale> sales = new List<Sale>()
            {
                new Sale(10000m, new DateTime(2019, 4, 9)),
                new Sale(300m,   new DateTime(2019, 4, 9)),
                new Sale(200m,   new DateTime(2019, 4, 9)),
                new Sale(1000m,  new DateTime(2019, 4, 10)),
            };

            HourlyPaidEmployee pluto = new HourlyPaidEmployee(2, "Pluto");
            pluto.AddWorkedHours(workedHours);

            CommissionPaidEmployee paperone = new CommissionPaidEmployee(3, "Paperone");
            paperone.AddSales(sales);

            return new List<Employee>()
            {
                new FixedSalaryEmployee(1, "Pippo"),
                pluto,
                paperone,
            };
        }
    }
}
