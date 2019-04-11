using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePay
{
    class Employee
    {
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; }
        public string Name { get; }
        public IPayCheckCalculator payCalculator { get; set; }
        public IPayDayCalculator dayPayCalculator { get; set; }
    }

    class PayCalcular : IPayDayCalculator
    {
        bool Test(DateTime date)
        {

        }


    }



    public interface IPayCheckCalculator
    {
        decimal Run(DateTime date);
    }

    public interface IPayDayCalculator
    {
        bool Test(DateTime date);
    }




/*
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
*/
}
