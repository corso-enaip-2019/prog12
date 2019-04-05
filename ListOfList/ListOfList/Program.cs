using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfList
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("### List of list ###");
            Console.WriteLine();

            int rows = ReadRows("Please enter the number of rows of the list: ");

            Console.WriteLine();
            Console.WriteLine("Starting list");
            Console.WriteLine();

            List<List<int>> list = CreateList(rows);

            Print(list);

            Console.WriteLine("Reverse each single row");
            Console.WriteLine();

            ReverseRows(list);

            Print(list);

            Console.WriteLine("Reverse list");
            Console.WriteLine();

            Reverse(list);

            Print(list);

            Console.ReadKey();
        }

        static List<List<int>> CreateList(int rows)
        {
            List<List<int>> outer = new List<List<int>>();

            for (int o = 1; o <= rows; o++)
            {
                List<int> inner = new List<int>();

                for (int i = 1; i <= o; i++)
                {
                    inner.Add(i);
                }

                outer.Add(inner);
            }

            return outer;
        }

        static void Print(List<List<int>> list)
        {
            int fieldWidth = list.Count().ToString().Length;
            string format = string.Concat("{0,", fieldWidth, "} ");

            foreach (List<int> inner in list)
            {
                foreach (int i in inner)
                {
                    Console.Write(format, i);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void ReverseRows(List<List<int>> list)
        {
            foreach (List<int> inner in list)
            {
                inner.Reverse();
            }
        }

        static void Reverse(List<List<int>> list)
        {
            list.Reverse();
        }

        static int ReadRows(string message)
        {
            int rows;

            do
            {
                rows = ReadInteger(message);

                if (rows < 1)
                {
                    Console.WriteLine("The enetered value should be > 0. Please try again...");
                }
            }
            while (rows < 1);

            return rows;
        }

        static int ReadInteger(string message)
        {
            int result;
            bool validInput;

            do
            {
                Console.Write(message);

                validInput = int.TryParse(Console.ReadLine(), out result);

                if (!validInput)
                {
                    Console.WriteLine();
                    Console.WriteLine("The value provided is invalid! Please try again...");
                    Console.WriteLine();
                }
            }
            while (!validInput);

            return result;
        }

    }
}
