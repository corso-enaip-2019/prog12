using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exponentiation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the base: ");
            double number = double.Parse(Console.ReadLine());

            Console.Write("Enter the power: ");
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(number + " to the " + power + " power equals " +
                              Math.Pow(number, power));

            Console.ReadLine();
        }
    }
}
