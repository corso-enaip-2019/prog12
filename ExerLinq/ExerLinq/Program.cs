using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Smartphone> list = CreateMocks();

            IEnumerable<string> orderedNamea = list
                .Select(x => x.Model)
                .OrderBy(x => x);

            IEnumerable<IGrouping<string, Smartphone>> groups =
                list
                .GroupBy(x => x.Color);

            foreach (IGrouping<string, Smartphone> group in groups)
            {
                Console.WriteLine($"{group.Key}");

                foreach (Smartphone s in group)
                {
                    Console.WriteLine($"\t{s.Model} {s.Version}");
                }
            }

            IEnumerable<ColorAverage> averagePricePerColor = list
                .GroupBy(x => x.Color)
                .Select(g => new ColorAverage
                {
                    Color = g.Key,
                    Average = g.Average(x => x.Price)
                });

            foreach (ColorAverage ca in averagePricePerColor)
            {
                Console.WriteLine($"{ca.Color} {ca.Average}");
            }
            Console.ReadKey();
        }
        static List<Smartphone> CreateMocks()
        {
            return new List<Smartphone>
            {
                new Smartphone("iPhone", 8, "Grey", 1200),
                new Smartphone("Galaxy S8", 0, "White", 800),
                new Smartphone("Nokia", 3310, "White", 200),
                new Smartphone("iPhone", 5, "Pink", 400),
                new Smartphone("Huawei", 8, "Black", 500),
            };
        }

    }

    class Smartphone
    {
        public Smartphone()
        {
        }

        public Smartphone(string model, int version, string color, decimal price)
        {
            Model = model;
            Version = version;
            Color = color;
            Price = price;
        }

        public string Model { get; }
        public int Version { get; }
        public string Color { get; }
        public decimal Price { get; set; }
    }

    class ColorAverage
    {
        public string Color { get; set; }
        public decimal Average { get; set; }
    }
}
