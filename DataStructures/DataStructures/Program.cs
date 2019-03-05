using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringhe = new List<string>();

            stringhe.Add("zero");
            stringhe.Add("one");
            stringhe.Add("two");
            stringhe.Add("three");
            stringhe.Add("four");

            for (int i = 0; i < stringhe.Count(); i++)
            {
                Console.WriteLine(stringhe[i]);
            }

            Console.ReadLine();
        }
    }
}
