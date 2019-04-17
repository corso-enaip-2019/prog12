using System;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ConvertToStringDelegate> lm = CreateMocksDelegate();
            List<int> li = CreateMocksData();
            foreach (ConvertToStringDelegate m in lm)
            {
                foreach (string s in Run(m, li))
                {
                    Console.Write($"{s} ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        static List<ConvertToStringDelegate> CreateMocksDelegate()
        {
            IntToStringUtility st = new IntToStringUtility();

            return new List<ConvertToStringDelegate>
            {
                JustToString,
                NumberWithThousandsSeparator,
                OddOrEven,
                st.JustToString,
                st.NumberWithThousandsSeparator,
                st.OddOrEven,
                number => number.ToString(),
                number => String.Format("{0:n0}", number),
                number => (number % 2 == 0) ? "even" : "odd",
            };
        }
        static List<int> CreateMocksData()
        {
            return new List<int>
            {
                21, 300, 1550, 3960, 8055, 10740, 11000324
            };
        }
        static List<string> Run(ConvertToStringDelegate method, List<int> l)
        {
            List<string> result = new List<string>();

            foreach (int n in l)
            {
                result.Add(method(n));
            }

            return result;
        }

        //number => number.number.ToString()
        static public string JustToString(int number)
        {
            return number.ToString();
        }

        //number => String.Format("{0:n0}", number)
        static public string NumberWithThousandsSeparator(int number)
        {
            return String.Format("{0:n0}", number);
        }

        //number => (number % 2 == 0) ? "even" : "odd"
        static public string OddOrEven(int number)
        {
            return (number % 2 == 0) ? "even" : "odd";
        }

        public delegate string ConvertToStringDelegate(int number);
    }

    class IntToStringUtility
    {
        public string JustToString(int number)
        {
            return number.ToString();
        }

        public string NumberWithThousandsSeparator(int number)
        {
            return String.Format("{0:n0}", number);
        }

        public string OddOrEven(int number)
        {
            return (number % 2 == 0) ? "even" : "odd";
        }
    }
}
