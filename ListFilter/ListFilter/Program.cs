using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Init();

            Console.WriteLine("Starting data");
            Console.WriteLine();

            PrintStringArray(data);

            Console.WriteLine("Reversed");
            Console.WriteLine();

            PrintStringArray(GetReversed(data));

            Console.WriteLine("Int");
            Console.WriteLine();

            PrintIntArray(GetLength(data));

            Console.WriteLine("Less than 3");
            Console.WriteLine();

            PrintStringArray(GetLess3(data));

            Console.WriteLine("Starts with a");
            Console.WriteLine();

            PrintStringArray(StartsWithA(data));

            Console.WriteLine("Int Convertible");
            Console.WriteLine();

            PrintStringArray(GetInts(data));
            Console.ReadKey();
        }

        static List<string> Init()
        {
            List<string> data = new List<string>();

            data.Add("oggi");
            data.Add("casa");
            data.Add("famelico");
            data.Add("2343");
            data.Add("1.5E-3");
            data.Add("sinonimo");
            data.Add("366");
            data.Add("2");
            data.Add("21");
            data.Add("anonimo");
            data.Add("sintattico");
            data.Add("astratto");

            return data;
        }

        static List<string> GetReversed(List<string> data)
        {
            List<string> reversed = new List<string>();

            foreach (string s in data)
            {
                /*
                char[] tmp = s.ToCharArray();

                Array.Reverse(tmp);

                reversed.Add(new string(tmp));
                */
                reversed.Add

            }

            return reversed;
        }

        static List<int> GetLength(List<string> data)
        {
            List<int> length = new List<int>();

            foreach (string s in data)
            {
                length.Add(s.Length);
            }

            return length;
        }


        static List<string> GetLess3(List<string> data)
        {
            List<string> less3 = new List<string>();

            foreach (string s in data)
            {
                if (s.Length < 3)
                {
                    less3.Add(s);
                }
            }

            return less3;
        }

        static List<string> StartsWithA(List<string> data)
        {
            List<string> result = new List<string>();

            foreach (string s in data)
            {
                if (s[0] == 'A'  || s[0] == 'a')
                {
                    result.Add(s);
                }
            }

            return result;
        }

        static List<string> GetInts(List<string> data)
        {
            List<string> result = new List<string>();

            foreach (string s in data)
            {
                int t;

                if (int.TryParse(s, out t))
                {
                    result.Add(t.ToString());
                }
            }

            return result;
        }

        static void PrintStringArray(List<string> data)
        {
            foreach (string x in data)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintIntArray(List<int> data)
        {
            foreach (int x in data)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
