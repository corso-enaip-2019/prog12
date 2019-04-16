using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public delegate int dgPointer(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            Adder a = new Adder();
            a.OnMultipleOfFive += xyz;

            

            dgPointer pAdder = new dgPointer(a.Add);

            int iAnswer = pAdder(3, 2);

            Console.WriteLine($"4 + 2 = {iAnswer}");

            Console.ReadKey();


        }

        static void xyz(object s, Multiple5EventArgs e)
        {
            Console.WriteLine("Multiple of five calculated...{0}", e.Total);
        }
    }

    public class Adder
    {
        public event EventHandler<Multiple5EventArgs> OnMultipleOfFive;
        public int Add(int x, int y)
        {
            int result = x + y;
            if (result == 5 && OnMultipleOfFive != null)
            {
                OnMultipleOfFive(this, new Multiple5EventArgs(result));
            }
            return x + y;
        }

    }

    public class Multiple5EventArgs : EventArgs
    {
        public Multiple5EventArgs(int i)
        {
            Total = i;
        }

        public int Total { get; }
    }
}
