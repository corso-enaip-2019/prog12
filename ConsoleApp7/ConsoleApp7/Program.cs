using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        public delegate int AdderPointer(int a, int b);

        static void Main(string[] args)
        {
            Adder a = new Adder();

            a.OnItIs5 += Message;

            AdderPointer ap = a.add;

            int res = ap(2, 3);

            Console.WriteLine($"Result: {res}");

            Console.ReadKey();

        }

        static void Message(object o, EventArgsSumResult e)
        {
            Console.WriteLine("It is " + e.Result);
        }
    }

    public class Adder
    {
        public delegate void EventItIs5();
//        public event EventItIs5 OnItIs5;

        public event EventHandler<EventArgsSumResult> OnItIs5;

        public int add(int x, int y)
        {
            int result = x + y;

            if (result == 5 && OnItIs5 != null)
            {
                OnItIs5.Invoke(this, new EventArgsSumResult(result));
            }

            return result;
        }
    }

    public class EventArgsSumResult : EventArgs
    {
        public EventArgsSumResult(int result)
        {
            Result = result;
        }

        public int Result { get; }
    }
}
