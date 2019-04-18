using System;
using System.Collections.Generic;
using System.Linq;

namespace Query3
{
    class Program
    {

        class FarmExtention
        {
            public string Vegetable;
            public int TotalExtension;
        };

        class VegetableExtention
        {
            public string Vegetable;
            public int TotalExtension;
        };

        static void Main(string[] args)
        {
            List<Farm> list = CreateMockUp();

            var result = list
                            .SelectMany(f => f.Fields);

            foreach (var f in result)
                Console.WriteLine($"Vegetable: {f.Vegetable}, Extension: {f.Extension}");

            var result2 = list
                            .SelectMany(f => f.Fields)
                            .GroupBy(f => f.Vegetable);

                            
            foreach (var fieldsByVegetable in result2)
            {
                Console.WriteLine($"Vegetable: {fieldsByVegetable.Key}");

                foreach (var field in fieldsByVegetable)
                {
                    Console.WriteLine($"Field Extension: {field.Extension}");
                }
            }

            var result3 = list
                            .SelectMany(f => f.Fields)
                            .GroupBy(f => f.Vegetable)
                            .Select(f => new VegetableExtention
                            {
                                Vegetable = f.Key,
                                TotalExtension = f.Sum(x => x.Extension)
                            });

            foreach (VegetableExtention ve in result3)
            {
                Console.WriteLine($"Vegetable: {ve.Vegetable}, TotalExtension: {ve.TotalExtension}");
            }

            var result4 = list
                            .SelectMany(f => f.Fields)
                            .GroupBy(f => f.Extension)
                            

            Console.ReadKey();
        }

        static List<Farm> CreateMockUp()
        {
            return new List<Farm>
            {
                new Farm
                {
                    Owner = "Dario",
                    Fields = new List<Field>
                    {
                        new Field{Vegetable = "Potato", Extension = 100},
                        new Field{Vegetable = "Carrot", Extension = 300},
                        new Field{Vegetable = "Onion",  Extension = 200},
                        new Field{Vegetable = "Tomato", Extension = 800},
                    }
                },
                new Farm
                {
                    Owner = "Fabio",
                    Fields = new List<Field>
                    {
                        new Field{Vegetable = "Carrot", Extension = 400},
                        new Field{Vegetable = "Onion",  Extension = 100},
                        new Field{Vegetable = "Tomato", Extension = 1200},
                    }
                },
                new Farm
                {
                    Owner = "Francesco",
                    Fields = new List<Field>
                    {
                        new Field{Vegetable = "Potato", Extension = 10},
                        new Field{Vegetable = "Carrot", Extension = 40},
                        new Field{Vegetable = "Onion",  Extension = 150},
                    }
                },
            };
        }
    }

    public class Field
    {
        public string Vegetable { get; set; }
        public int Extension { get; set; }
    }

    public class Farm
    {
        public string Owner { get; set; }
        public List<Field> Fields { get; set; }
    }
}
