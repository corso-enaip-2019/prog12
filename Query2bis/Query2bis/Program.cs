using System;
using System.Collections.Generic;
using System.Linq;


namespace Query2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = CreateMockUp();

            IEnumerable<string> result1 = list.Select(s => string.Concat(s.ToArray().Reverse()));

            Console.WriteLine("Results 1");

            foreach (string s in result1)
                Console.WriteLine($"Reversed: {s}");

            var result2 = list
                        .Select(s => string.Concat(s.ToArray().Reverse()))
                        .Where(s => !int.TryParse(s, out int _))
                        .Where(s => double.TryParse(s, out double _1))
                        .Select(s => double.Parse(s))
                        .Where(s => !int.TryParse(s.ToString(), out int _2))
                        .Select(s => Math.Sqrt(s))
                        .Where(s => s < 5);

            Console.WriteLine();
            Console.WriteLine("Results 2");

            foreach (double d in result2)
                Console.WriteLine($"Results: {d}");

            Console.ReadKey();

        }

        static List<string> CreateMockUp()
        {
            return new List<string>
            {
                "then", "you", "keep", "only", "the", "resulting", "strings", "that", "are", "convertible", "in",
                "32", "645.44", "0.439", "11", "34.555", "943.11", "74.2", "55.0",
            };
        }
    }
}
